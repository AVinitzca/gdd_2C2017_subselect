using PagoAgilFrba.DB;
using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.MenuPrincipal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            // Agrega listados de empresas, clientes y formas de pago
            this.cmbEmpresas.Items.AddRange(DB.DB.Instancia.obtenerEmpresas("", "", null, true).ToArray());
            this.cmbCliente.Items.AddRange(DB.DB.Instancia.obtenerClientes("", "", 0, true).ToArray());
            this.cmbFormaPago.Items.AddRange(DB.DB.Instancia.obtenerFormasDePago().ToArray());
        }

        private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si cambia el seleccionador de empresas
            // Borra las facturas listadas y busca las facturas
            // para la empresa seleccionada
            this.lstFacturas.Items.Clear();
            if(this.cmbEmpresas.SelectedItem != null)
            {
                this.lstFacturas.Items.AddRange(DB.DB.Instancia.obtenerFacturas((Empresa)this.cmbEmpresas.SelectedItem).Where(
                    factura => factura.Vencimiento >= Configuracion.Configuracion.fecha() && factura.Paga == false).ToArray());
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            // Valida el formulario
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
            else if (this.lstFacturas.SelectedIndices == null || this.lstFacturas.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Error: Se debe seleccionar una o mas facturas");
            }
            else
            {
                // Crea el pago, asignandole los valores de los listados
                Pago pago = new Pago();
                pago.Empresa = (Empresa)this.cmbEmpresas.SelectedItem;
                pago.Cliente = (Cliente)this.cmbCliente.SelectedItem;
                pago.FormaDePago = (FormaDePago)this.cmbFormaPago.SelectedItem;                

                // Asigna la lista de facturas seleccionadas
                List<Factura> facturas = new List<Factura>();
                foreach (object item in this.lstFacturas.SelectedItems)
                {
                    facturas.Add((Factura)item);
                }
                // Toma la fecha actual, sucursal del usuario
                pago.Facturas = facturas;
                pago.Fecha = Configuracion.Configuracion.fecha();
                pago.Sucursal = Usuario.Logeado.Sucursal;    
                
                // Avisa a la DB
                // Si todo sale bien, actualiza cada factura paga y las borra de la lista        
                Respuesta respuesta = DB.DB.Instancia.crearPago(pago);
                if(respuesta.Codigo == 0)
                {
                    foreach(Factura facturaDevuelta in facturas)
                    {
                        facturaDevuelta.Paga = true;
                        this.lstFacturas.Items.Remove(facturaDevuelta);
                    }                    
                    MessageBox.Show("La factura fue pagada");                    
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje);
                }
            }
        }

        private void lstFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualiza el importe a pagar segun facturas seleccionadas
            double suma = 0;
            foreach (object item in this.lstFacturas.SelectedItems)
            {
                suma += ((Factura)item).Total;
            }
            this.lblImporte.Text = "Importe: " + suma.ToString();
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
