using System;
using System.Drawing;
using PagoAgilFrba.EleccionRol;
using System.Windows.Forms;
using PagoAgilFrba.Configuracion;
using PagoAgilFrba.Dominio;
using PagoAgilFrba.DB;

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
        

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;                     
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String email    = this.txtNombreUsuario.Text;
            String password = this.txtPassword.Text;

            Usuario usuario = new Usuario(email, password);

            Respuesta respuesta = usuario.logear();
            if(respuesta.Codigo == 0)
            {                
                Form formEleccionRol = new FormEleccionRol();                
                formEleccionRol.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: " + respuesta.Mensaje);
            }
        }
        
    
    }
}
