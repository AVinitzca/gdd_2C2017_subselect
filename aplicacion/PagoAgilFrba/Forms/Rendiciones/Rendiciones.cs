using PagoAgilFrba.DB;
using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.MenuPrincipal;
using System;
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
            // Agrega las empresas al listado
            this.cmbEmpresas.Items.AddRange(DB.DB.Instancia.obtenerEmpresas("", "", null, true).ToArray());
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            // Valida el formulario
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
                // Crea una rendicion y le asigna el valor de los campos
                RendicionFacturas rendicion = new RendicionFacturas();
                rendicion.Empresa = (Empresa)this.cmbEmpresas.SelectedItem;
                rendicion.Fecha = Configuracion.Configuracion.fecha();
                rendicion.Porcentaje = Double.Parse(this.txtPorcentaje.Text);

                // Informa a la DB
                Respuesta respuesta = DB.DB.Instancia.crearRendicion(rendicion);
                if (respuesta.Codigo == 0)
                {
                    // Si todo sale bien, limpia los campos y recarga las facturas
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
            // Solo deja ingresar caracteres numericos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Vuelve al menu principal
            FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }
    }
}
