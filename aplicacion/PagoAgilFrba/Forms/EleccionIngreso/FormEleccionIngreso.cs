using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.MenuPrincipal;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PagoAgilFrba.EleccionRol
{
    public partial class FormEleccionRol : Form
    {
        public FormEleccionRol()
        {
            InitializeComponent();
        }

        private void formElegirRol_Load(object sender, EventArgs e)
        {            
            // Carga los roles y sucursales activas del usuario
            this.cmbRoles.Items.AddRange(Usuario.Logeado.Roles.Where(rol => rol.Activo).ToArray());
            this.cmbSucursales.Items.AddRange(Usuario.Logeado.Sucursales.Where(sucursal => sucursal.Activa).ToArray());
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if(this.cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un rol");
            }
            else if(this.cmbSucursales.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una sucursal");
            }
            else
            {
                // Asigna rol y sucursal seleccionados
                // Obtiene las funcionalidades del Rol seleccionado
                // Va al menu principal
                Usuario.Logeado.asignarRol((Rol)this.cmbRoles.SelectedItem);
                Usuario.Logeado.asignarSucursal((Sucursal)this.cmbSucursales.SelectedItem);
                DB.DB.Instancia.obtenerFuncionalidadesPorRol(Usuario.Logeado.Rol);
                Form form = new FormMenuPrincipal();
                form.Show();
                this.Hide();                
            }
        }
    }
}
