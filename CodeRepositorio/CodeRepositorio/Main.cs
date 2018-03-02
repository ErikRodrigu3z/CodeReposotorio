using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; //para usar el archivo config
using System.Data.SQLite;
using System.IO; //sql lite

/* tabla Codigo(id_codigo,codigo,id_lenguaje,titulo)  
 * tabla Lenguajes(id_lenguaje,nombre)
 * 
 * select * from Codigo c
 * left join Lenguajes l on l.id_lenguaje = c.id_lenguaje 
 * 
 * https://danielggarcia.wordpress.com/2013/12/21/bases-de-datos-portables-utilizando-sqlite-en-una-aplicacion-net/
 * 
 */
namespace CodeRepositorio
{
    public partial class Main : Form 
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLInsert = "INSERT INTO Lenguajes(nombre) VALUES(?)";
        private String SQLInsertCodigo = "INSERT INTO Codigo(codigo,id_lenguaje,titulo) VALUES(?,?,?)";
        private String SQLUpdate = "UPDATE Codigo SET titulo = ?, codigo = ? where id_codigo = ?";
        private String SQLSelectCombo = "SELECT id_lenguaje,nombre FROM Lenguajes";
        private String SQLSelect = "SELECT * FROM Lenguajes"; 
        //private String SQLDelete = "DELETE FROM User WHERE UserId = ?";

        //instancia del form Modificador 
        Modificador Form2 = new Modificador(); 

        //constructor
        public Main()
        {
            InitializeComponent();
            //llenaLenguajes();
            llenaCombo();
        }

        #region Eventos
        //evento load
        private void Main_Load(object sender, EventArgs e)
        {
            //manejador de eventos
            Form2.cargar += new Modificador.delegado1(cargarDatos); 

            try
            {
                string rutaImagen = ConfigurationManager.AppSettings["ImagenFondo"];
                string imagepath = Path.Combine(Application.StartupPath, @"imagenes\" + rutaImagen + "");
                //this.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + @"\" + rutaImagen + "");
                this.BackgroundImage = Image.FromFile(imagepath);
                llenaGrid();        

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //evento para cerrar form       
        private void Main_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("Deseas Salir ?", "Cerrar Aplicaión", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                this.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }        
        //Copiar
        private void menuCopiar_Click(object sender, EventArgs e)
        {
            string descripcion = txtCodigo.Text;
            try
            {
                Clipboard.SetDataObject(descripcion, true);
                MessageBox.Show("Campo Copiado", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception o)
            {
                MessageBox.Show("No se pudo copiar campo", "Error: " + o.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        //Guardar
        private void menuGuardar_Click(object sender, EventArgs e)
        {
            guardaCodigo();
            limpiar();
            llenaGrid();
        }
        //actualizar
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actulizaCodigo();
            llenaGrid();
            limpiar();
        }
        //Limpiar
        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }
         //agregar lenguaje
        private void txtAgrLenguaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                insertaLenguaje();
                //llenaLenguajes();
                llenaCombo();
            }
            
        }
        //evento de combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdLenguaje.Text = comboBox1.SelectedValue.ToString();
            llenaGrid();
        }
        //evento cell click para copiar datos
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow fila = dataGridView1.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
                txtTitulo.Text = Convert.ToString(fila.Cells[1].Value); //optengo valor de la primar columna
                txtCodigo.Text = Convert.ToString(fila.Cells[2].Value); //optengo valor de la segunda columna
                txtIdCodigo.Text = Convert.ToString(fila.Cells[3].Value); //optengo valor de la segunda columna
               

                string descripcion = txtCodigo.Text;
                //reemplaza 
                descripcion = descripcion.Replace("char(39)", "'");
                txtCodigo.Text = descripcion;
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i.Message, "Codigo: " + i.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //evento buscar
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection(); //limpia el foco del grid
            buscaGrid();
        }
        //modificar lenguaje
        private void modificarLenguajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.ShowDialog();
        }
        #endregion
        //---------------------------------------------------------------//
        #region Metodos
        //metodo para delegado cargarDatos y llenar grid con lenguajes 
        void cargarDatos(Boolean mensajeEnviar)//metodo para cambiar atributos en Form1 
        {   
            llenaCombo();
        }
        //llena el grid con los lengujes
        public void llenaLenguajes() 
        {
            try
            {
                //conexion
                connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                connection = new SQLiteConnection(connectionString);

                // Abrimos la conexión
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Creamos un SQLiteCommand y le asignamos la cadena de consulta
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLSelect;

                // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
                // A continuación, rellenamos la tabla con el DataAdapter
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                // Asignamos el DataTable al DataGrid y cerramos la conexión
                dataGridView1.DataSource = dt;
                connection.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
        }
        //inserta lenguaje
        public void insertaLenguaje()
        {
            try
            {
                if (String.IsNullOrEmpty(txtAgrLenguaje.Text))
                {
                    MessageBox.Show("Campo vacio","Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = SQLInsert;

                    command.Parameters.AddWithValue("nombre", txtAgrLenguaje.Text);

                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Campo Guardado", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    llenaCombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiar();
            }
        }
        //llena codigo
        public void guardaCodigo()
        {
            try
            {
                string descripcion = txtCodigo.Text;
                //reemplaza 
                descripcion = descripcion.Replace("'", "char(39)");
                //valida que no esten vacios
                if (String.IsNullOrEmpty(txtCodigo.Text) || String.IsNullOrEmpty(txtTitulo.Text))
                {
                    MessageBox.Show("No debe estar vacios los campos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
	            {                    
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = SQLInsertCodigo;

                    command.Parameters.AddWithValue("codigo", txtCodigo.Text);
                    command.Parameters.AddWithValue("id_lenguaje", Convert.ToInt32(txtIdLenguaje.Text));
                    command.Parameters.AddWithValue("titulo", txtTitulo.Text);

                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Campo Guardado", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    
	            }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
        //llena combo
        public void llenaCombo()
        {
            try
            {
                //conexion
                connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                connection = new SQLiteConnection(connectionString);

                // Abrimos la conexión
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Creamos un SQLiteCommand y le asignamos la cadena de consulta
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLSelectCombo;

                // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
                // A continuación, rellenamos la tabla con el DataAdapter
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                // Asignamos el DataTable al Combo y cerramos la conexión
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "id_lenguaje";
                connection.Close();
                txtIdLenguaje.Text = comboBox1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        //resetea texbox
        public void limpiar()
        {
            txtCodigo.ResetText();
            txtAgrLenguaje.Text = "";
            txtTitulo.ResetText();
        }
        //llena grid con codigo
        public void llenaGrid()
        {
            string SQLSelectCodigo = "select l.nombre,c.titulo,c.codigo,c.id_codigo from Codigo c left join Lenguajes l on l.id_lenguaje = c.id_lenguaje where l.id_lenguaje =" + comboBox1.SelectedValue + ""; 

            try
            {
                //conexion
                connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                connection = new SQLiteConnection(connectionString);

                // Abrimos la conexión
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Creamos un SQLiteCommand y le asignamos la cadena de consulta
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLSelectCodigo;

                // Creamos un nuevo DataTable y un DataAdapter a partir de la SELECT.
                // A continuación, rellenamos la tabla con el DataAdapter
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                da.Fill(dt);

                // Asignamos el DataTable al Grid y cerramos la conexión
                dataGridView1.DataSource = dt;
                connection.Close();             
            }
            catch (Exception ex)
            {
                if (ex.HResult != -2147467259)
                {
                    MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }
        //actualiza codigo
        public void actulizaCodigo()
        {
            try
            {
                if (String.IsNullOrEmpty(txtIdCodigo.Text) || String.IsNullOrEmpty(txtTitulo.Text))
                {
                    MessageBox.Show("No debe estar vacios los campos.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    SQLiteCommand command = connection.CreateCommand();
                    command.CommandText = SQLUpdate;

                    command.Parameters.AddWithValue("titulo", txtTitulo.Text);
                    command.Parameters.AddWithValue("codigo", txtCodigo.Text);
                    command.Parameters.AddWithValue("id_codigo", int.Parse(txtIdCodigo.Text));

                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Dato Actulizado. ","ACTUALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        //buscar en grid
        public void buscaGrid()
        {
            string busqueda = comboBox1.Text.ToLower();
            
           
            List<DataGridViewRow> rows = (from item in dataGridView1.Rows.Cast<DataGridViewRow>()
                                          let nombre = Convert.ToString(item.Cells["nombre"].Value ?? string.Empty).ToLower()
                                          let titulo = Convert.ToString(item.Cells["titulo"].Value ?? string.Empty).ToLower()
                                          let codigo = Convert.ToString(item.Cells["codigo"].Value ?? string.Empty).ToLower()                                         
                                          where nombre.Contains(busqueda) ||
                                                 titulo.Contains(busqueda) ||
                                                 codigo.Contains(busqueda)                                                 
                                          select item).ToList<DataGridViewRow>();

            foreach (DataGridViewRow row in rows)
            {
                List<DataGridViewCell> cells = (from item in row.Cells.Cast<DataGridViewCell>()
                                                let cell = Convert.ToString(item.Value)
                                                where cell.Contains(busqueda)
                                                select item).ToList<DataGridViewCell>();

                foreach (DataGridViewCell item in cells)
                {
                    item.Selected = true;
                }

            }
        }

        #endregion
        
            
    

        

    }
}
