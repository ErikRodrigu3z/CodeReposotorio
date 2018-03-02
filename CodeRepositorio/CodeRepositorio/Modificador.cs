using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite; // sql Lite 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CodeRepositorio
{
    public partial class Modificador : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        //private String SQLInsert = "INSERT INTO Lenguajes(nombre) VALUES(?)";
        //private String SQLInsertCodigo = "INSERT INTO Codigo(codigo,id_lenguaje,titulo) VALUES(?,?,?)";
        private String SQLUpdate = "UPDATE Lenguajes SET nombre = ? where id_lenguaje = ?";
        //private String SQLSelectCombo = "SELECT id_lenguaje,nombre FROM Lenguajes";
        private String SQLSelect = "SELECT * FROM Lenguajes";
        //private String SQLDelete = "DELETE FROM User WHERE UserId = ?";

        //variables para update de lenguajes
        string nombreLenguaje = "";
        int id_lenguaje = 0;

        //constructor
        public Modificador()
        {
            InitializeComponent();
        }

        //se crea el delegado
        public delegate void delegado1(Boolean cargarDatos);
        //se crea el evento
        public event delegado1 cargar;

        #region Eventos
        //load
        private void Modificador_Load(object sender, EventArgs e)
        {
            llenaLenguajes();
            //bloquea la primer columna
            dataGridView1.Columns[0].ReadOnly = true;

        }               
        // evento para cuando se termina de editar fila de grid
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            nombreLenguaje = Convert.ToString(fila.Cells[1].Value); //optengo valor de la segunda columna
            actualizaLenguajes();
            //evento cargar
            this.cargar(true);
        }
        //evento click del grid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            id_lenguaje = Convert.ToInt32(fila.Cells[0].Value); //optengo valor de la primer columna
            nombreLenguaje = Convert.ToString(fila.Cells[1].Value); //optengo valor de la segunda columna
        }
        #endregion

        //--------------------------------------------------------------//

        #region metodos
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
        //update lenguajes
        public void actualizaLenguajes()
        {
            try
            {                
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLUpdate;
               
                command.Parameters.AddWithValue("nombre", nombreLenguaje);
                command.Parameters.AddWithValue("id_lenguaje", id_lenguaje);

                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Dato Actulizado. ", "ACTUALIZAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
 
        }


        #endregion
        
        
       
    }
}
