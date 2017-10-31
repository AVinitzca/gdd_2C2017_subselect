using System;
using System.Drawing;
using PagoAgilFrba.EleccionRol;
using System.Windows.Forms;
using PagoAgilFrba.Configuracion;
using PagoAgilFrba.Dominio;

namespace PagoAgilFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Configuracion.Configuracion.inicializar();
            if(Configuracion.Configuracion.TieneError)
            {
                MessageBox.Show(Configuracion.Configuracion.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(((TextBox)sender).Text);
                ((TextBox)sender).ForeColor = Color.Black;                
            }
            catch (FormatException ex)
            {
                ((TextBox)sender).ForeColor = Color.Red;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;            
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String email    = this.Controls.Find("txtEmail", true)[0].Text;
            String password = this.Controls.Find("txtPassword", true)[0].Text;

            Usuario usuario = new Usuario(email, password);

            if(usuario.logear())
            {                
                Form formEleccionRol = new FormEleccionRol();                
                formEleccionRol.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
        
    
    }
}
