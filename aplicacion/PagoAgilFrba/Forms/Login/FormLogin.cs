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
            // Carga la configuracion y verifica que no hayan errores
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
            // Crea al usuario
            // Si la DB deja logear, carga sus roles y sucursales posibles
            // Si no tiene alguna de estas dos, informa un error
            Respuesta respuesta = usuario.logear();
            if(respuesta.Codigo == 0)
            {
                if(usuario.Sucursales.Exists(sucursal => sucursal.Activa))
                {
                    if (usuario.Roles.Exists(rol => rol.Activo))
                    {
                        // Va al formulario de eleccion de roles y sucursales
                        Form formEleccionRol = new FormEleccionRol();
                        formEleccionRol.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Erorr: El usuario no tiene roles activos");
                    }
                }
                else
                {
                    MessageBox.Show("Erorr: El usuario no tiene sucursales activas");
                }                
            }
            else
            {
                MessageBox.Show("Error: " + respuesta.Mensaje);
            }
        }
        
    
    }
}
