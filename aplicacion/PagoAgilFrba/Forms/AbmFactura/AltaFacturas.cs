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

namespace PagoAgilFrba.AbmFactura
{
    public partial class FormAltaFactura : Form
    {
        public FormAltaFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            this.cmbCliente.Items.AddRange(DB.DB.Instancia.obtenerClientes("", "", 0).ToArray());
            this.cmbEmpresa.Items.AddRange(DB.DB.Instancia.obtenerEmpresas("", "", null).ToArray());
        }
        

        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(numericColumnKeyPress);
            if(this.dgvItems.CurrentCell.ColumnIndex == 1 || this.dgvItems.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(numericColumnKeyPress);
                }
            }
        }
        
        private void numericColumnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvItems_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            double suma = 0;
            foreach (DataGridViewRow row in this.dgvItems.Rows)
            {
                double monto = row.Cells[1].Value == null ? 0 : Double.Parse(row.Cells[1].Value.ToString());
                double cantidad = row.Cells[2].Value == null ? 0 : Double.Parse(row.Cells[2].Value.ToString());
                row.Cells[3].Value = monto * cantidad;
                suma += (double)row.Cells[3].Value;
            }
            this.lblTotal.Text = "Total: " + suma.ToString();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(this.cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar un cliente");
            }
            else if (this.cmbEmpresa.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una empresa");
            }
            else if (this.dtpFechaVencimiento.Value < DateTime.Today)
            {
                MessageBox.Show("Error: La fecha de vencimiento debe ser mayor a la fecha actual");
            }
            else if (this.dgvItems.Rows.Count == 1)
            {
                MessageBox.Show("Error: No se ingresaron items para la factura");
            }
            else
            {
                for(int index = 0; index < this.dgvItems.Rows.Count - 1; index++)
                {
                    DataGridViewRow row = this.dgvItems.Rows[index];
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                    {
                        MessageBox.Show("Error: Un item de la factura se encuentra vacio");
                        return;
                    }
                }
                Factura factura = new Factura();
                factura.Cliente = (Cliente)this.cmbCliente.SelectedItem;
                factura.Empresa = (Empresa)this.cmbEmpresa.SelectedItem;
                factura.Creacion = Configuracion.Configuracion.fecha();
                factura.Vencimiento = (DateTime)this.dtpFechaVencimiento.Value;
                for (int index = 0; index < this.dgvItems.Rows.Count - 1; index++)
                {
                    DataGridViewRow row = this.dgvItems.Rows[index];
                    ItemFactura itemFactura = new ItemFactura();
                    itemFactura.Factura = factura;
                    itemFactura.Monto = Double.Parse(row.Cells[1].Value.ToString());
                    itemFactura.Cantidad = Int32.Parse(row.Cells[2].Value.ToString());
                    factura.Items.Add(itemFactura);
                }
                DB.DB.Instancia.crearFactura(factura);
               
                MessageBox.Show("La factura se registro satisfactoriamente");
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
