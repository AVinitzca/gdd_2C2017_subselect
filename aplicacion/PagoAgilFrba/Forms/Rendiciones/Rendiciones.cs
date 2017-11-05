using PagoAgilFrba.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Rendicion
{
    public partial class FormRendiciones : Form
    {
        public FormRendiciones()
        {
            InitializeComponent();
        }

        private void FormRendiciones_Load(object sender, EventArgs e)
        {
            this.cmbEmpresas.Items.AddRange(DB.DB.Instancia.obtenerEmpresas(null, null, null, true).ToArray());
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            if(this.cmbEmpresas.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una empresa para rendir");
            }
            else if(this.txtPorcentaje.Text == null)
            {
                MessageBox.Show("Error: Se debe ingresar un porcentaje de comision para la rendicion");
            }
            else
            {
                RendicionFacturas rendicion = new RendicionFacturas();
                rendicion.Empresa = (Empresa)this.cmbEmpresas.SelectedItem;
                rendicion.Fecha = Configuracion.Configuracion.fecha();
                rendicion.Porcentaje = Double.Parse(this.txtPorcentaje.Text);
                DB.DB.Instancia.crearRendicion(rendicion);
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
    }
}
