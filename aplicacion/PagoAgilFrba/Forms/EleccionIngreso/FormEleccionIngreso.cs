using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.cmbRoles.Items.AddRange(Usuario.Logeado.roles().ToArray());
            this.cmbRoles.Items.AddRange(Usuario.Logeado.sucursales().ToArray());
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if(this.cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un rol");
            }
            else
            {
                Usuario.Logeado.asignarRol((Rol)this.cmbRoles.SelectedValue);
                Form form = new FormMenuPrincipal();
                form.Show();
                this.Hide();                
            }
        }
    }
}
