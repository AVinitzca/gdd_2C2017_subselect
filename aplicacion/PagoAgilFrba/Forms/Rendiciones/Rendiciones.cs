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
            this.cmbEmpresas.Items.AddRange(DB.DB.Instancia.obtenerEmpresas("", "", null, true).ToArray());
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            if(this.cmbEmpresas.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una empresa para rendir");
            }
            else if(this.txtPorcentaje.Text == "")
            {
                MessageBox.Show("Error: Se debe ingresar un porcentaje de comision para la rendicion");
            }
            else if (((Empresa)this.cmbEmpresas.SelectedItem).DiaRendicion != Configuracion.Configuracion.fecha().Day)
            {
                MessageBox.Show("Error: La empresa no tiene permitido rendir este dia");
            }
            else
            {
                RendicionFacturas rendicion = new RendicionFacturas();
                rendicion.Empresa = (Empresa)this.cmbEmpresas.SelectedItem;
                rendicion.Fecha = Configuracion.Configuracion.fecha();
                rendicion.Porcentaje = Double.Parse(this.txtPorcentaje.Text);

                Respuesta respuesta = DB.DB.Instancia.crearRendicion(rendicion);
                if (respuesta.Codigo == 0)
                {
                    this.cmbEmpresas.SelectedIndex = -1;
                    this.txtPorcentaje.Clear();
                    DB.DB.Instancia.recargarFacturas();
                    MessageBox.Show("Se rindieron las facturas pagas para la empresa");
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje);
                }
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }
    }
}
