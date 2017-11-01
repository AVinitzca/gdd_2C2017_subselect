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

namespace PagoAgilFrba.RegistroPago
{
    public partial class FormPagos : Form
    {
        public FormPagos()
        {
            InitializeComponent();
        }

        private void FormPagos_Load(object sender, EventArgs e)
        {
            this.cmbEmpresas.Items.AddRange(DB.DB.Instancia.obtenerEmpresas(null, null, null).ToArray());
            this.cmbCliente.Items.AddRange(DB.DB.Instancia.obtenerClientes(null, null, null).ToArray());
            this.cmbFormaPago.Items.AddRange(DB.DB.Instancia.obtenerFormasDePago().ToArray());
        }

        private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbEmpresas.SelectedItem != null)
            {
                this.lstFacturas.Items.Clear();
                this.lstFacturas.Items.AddRange(DB.DB.Instancia.obtenerFacturas((Empresa)this.cmbEmpresas.SelectedItem).ToArray()   );
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if(this.cmbEmpresas.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una empresa");
            }
            else if (this.cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar un cliente");
            }
            else if (this.cmbFormaPago.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una forma de pago");
            }
            else if (this.lstFacturas.SelectedIndices == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una o mas facturas");
            }
            else
            {
                Pago pago = new Pago();
                pago.Empresa = (Empresa)this.cmbEmpresas.SelectedItem;
                pago.Cliente = (Cliente)this.cmbCliente.SelectedItem;
                pago.FormaDePago = (FormaDePago)this.cmbFormaPago.SelectedItem;                
                List<Factura> facturas = new List<Factura>();
                foreach (object item in this.lstFacturas.SelectedItems)
                {
                    facturas.Add((Factura)item);
                }
                pago.Facturas = facturas;
                pago.Fecha = (DateTime)Configuracion.Configuracion.valor("fecha");
                pago.Sucursal = Usuario.Logeado.Sucursal;
                pago.Total = pago.Facturas.Aggregate(0d, (prev, post) => prev + ((Factura)post).Total);
                DB.DB.Instancia.crearPago(pago);
                this.Hide();
                FormMenuPrincipal menu = new FormMenuPrincipal();
                menu.Show();
            }
        }

        private void lstFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            double suma = 0;
            foreach (object item in this.lstFacturas.SelectedItems)
            {
                suma += ((Factura)item).Total;
            }
            this.lblImporte.Text = "Importe: " + suma.ToString();
        }
    }
}
