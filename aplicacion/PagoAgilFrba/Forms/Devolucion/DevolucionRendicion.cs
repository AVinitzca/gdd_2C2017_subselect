using PagoAgilFrba.DB;
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

namespace PagoAgilFrba.Forms.Devolucion
{
    public partial class FormDevolucionRendicion : Form
    {
        public FormDevolucionRendicion()
        {
            InitializeComponent();
        }

        private void DevolucionRendicion_Load(object sender, EventArgs e)
        {
            this.cmbRendiciones.Items.AddRange(DB.DB.Instancia.obtenerRendiciones().ToArray());
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if(this.cmbRendiciones.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe especificar el motivo de la devolucion");
            }
            else if(this.txtMotivo.Text == "")
            {
                MessageBox.Show("Error: Se debe especificar el motivo de la devolucion");
            }
            else
            {
                RendicionFacturas aDevolver = (RendicionFacturas)this.cmbRendiciones.SelectedItem;
                Respuesta respuesta = DB.DB.Instancia.devolverRendicion(aDevolver, this.txtMotivo.Text);                
                if(respuesta.Codigo == 0)
                {
                    MessageBox.Show("La rendicion fue devuelta con exito");
                    this.cmbRendiciones.SelectedIndex = -1;
                    this.txtMotivo.Clear();
                    this.cmbRendiciones.Items.Remove(aDevolver);
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje);
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }
    }
}
