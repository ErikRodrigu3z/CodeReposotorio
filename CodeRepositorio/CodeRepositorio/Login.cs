using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO; // import para el configuration manager

namespace CodeRepositorio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        #region Eventos
        //evento keypress
        private void txtPassord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtPassord.Text == "Batch0021")
                {
                    Main m = new Main();
                    m.Show(); //hola mundo
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password Incorrecto", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassord.ResetText();
                }

            }
        }
        //evento load
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {                
                string rutaImagen = ConfigurationManager.AppSettings["ImagenFondoLogin"];
                string imagepath = Path.Combine(Application.StartupPath, @"imagenes\" + rutaImagen + "");
                this.BackgroundImageLayout = ImageLayout.Stretch;
                //this.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + @"\" + rutaImagen + "");
                this.BackgroundImage = Image.FromFile(imagepath);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
