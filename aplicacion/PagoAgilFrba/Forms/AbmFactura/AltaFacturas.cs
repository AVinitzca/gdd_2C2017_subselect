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

namespace PagoAgilFrba.AbmFactura
{
    public partial class FormAltaFactura : Form
    {
        private BindingList<Factura> facturas;
        private BindingList<ItemFactura> itemsFactura;
        private BindingList<ItemFactura> originales;

        public FormAltaFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            this.cmbCliente.Items.AddRange(DB.DB.Instancia.obtenerClientes("", "", 0, true).ToArray());
            this.cmbEmpresa.Items.AddRange(DB.DB.Instancia.obtenerEmpresas("", "", null, true).ToArray());
            this.facturas = new BindingList<Factura>(DB.DB.Instancia.obtenerFacturas());
            this.itemsFactura = new BindingList<ItemFactura>();
            this.dgvItems.DataSource = this.itemsFactura;
            this.dgvFacturas.DataSource = this.facturas;
            this.dtpCreacion.Value = Configuracion.Configuracion.fecha();

            DataGridViewButtonColumn modificar = new DataGridViewButtonColumn();
            modificar.Name = "dgvColumnModificar";
            modificar.HeaderText = "Modificar";
            modificar.Text = modificar.HeaderText;
            modificar.UseColumnTextForButtonValue = true;
            this.dgvFacturas.Columns.Add(modificar);
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
                if (row.Cells[1] != null && row.Cells[1].Value != null)
                {
                    suma += (double)row.Cells[1].Value;
                }
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
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null)
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
                    itemFactura.Monto = Double.Parse(row.Cells[0].Value.ToString());
                    itemFactura.Cantidad = Int32.Parse(row.Cells[1].Value.ToString());
                    factura.Items.Add(itemFactura);
                }
                Respuesta respuesta = DB.DB.Instancia.crearFactura(factura);
                if(respuesta.Codigo == 0)
                {
                    facturas.Add(factura);
                    MessageBox.Show("La factura se registro satisfactoriamente");
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

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnModificar" && this.gpbIngreso.Tag == null)
                {
                    Factura factura = this.facturas[e.RowIndex];
                    factura.Items = DB.DB.Instancia.obtenerItemsFactura(factura);
                    this.itemsFactura = new BindingList<ItemFactura>(factura.Items);
                    this.originales = new BindingList<ItemFactura>(new List<ItemFactura>(factura.Items.ToArray()));
                    this.dgvItems.DataSource = this.itemsFactura;
                    this.cmbCliente.SelectedItem = factura.Cliente;
                    this.cmbEmpresa.SelectedItem = factura.Empresa;
                    this.dtpFechaVencimiento.Value = factura.Vencimiento;
                    this.dtpCreacion.Value = factura.Creacion;
                    this.lblTotal.Text = "Total: " + factura.Total;
                    
                    this.btnModificar.Visible = true;
                    this.btnCancelar.Visible = true;
                    this.btnCrear.Visible = false;
                    this.gpbIngreso.Tag = factura;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.cmbCliente.SelectedItem == null)
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
                for (int index = 0; index < this.dgvItems.Rows.Count - 1; index++)
                {
                    DataGridViewRow row = this.dgvItems.Rows[index];
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    {
                        MessageBox.Show("Error: Un item de la factura se encuentra vacio");
                        return;
                    }
                }
                Factura factura = ((Factura)this.gpbIngreso.Tag);
                factura.Cliente = (Cliente)this.cmbCliente.SelectedItem;
                factura.Empresa = (Empresa)this.cmbEmpresa.SelectedItem;
                factura.Creacion = this.dtpCreacion.Value;
                factura.Vencimiento = this.dtpFechaVencimiento.Value;
                factura.Items = this.itemsFactura.ToList();

                Respuesta respuesta = DB.DB.Instancia.modificarFactura(factura, originales.ToList());
                if (respuesta.Codigo == 0)
                {
                    this.gpbIngreso.Tag = null;
                    this.cmbCliente.SelectedIndex = -1;
                    this.cmbEmpresa.SelectedIndex = -1;
                    this.dtpCreacion.Value = Configuracion.Configuracion.fecha();
                    this.dtpFechaVencimiento.Value = Configuracion.Configuracion.fecha();
                    this.itemsFactura.Clear();
                    this.originales.Clear();
                    this.btnCrear.Show();
                    this.btnModificar.Hide();
                    this.btnCancelar.Hide();
                    MessageBox.Show("La factura se modifico satisfactoriamente");
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.gpbIngreso.Tag = null;
            this.cmbCliente.SelectedIndex = -1;
            this.cmbEmpresa.SelectedIndex = -1;
            this.dtpCreacion.Value = Configuracion.Configuracion.fecha();
            this.dtpFechaVencimiento.Value = Configuracion.Configuracion.fecha();
            this.itemsFactura.Clear();
            this.originales.Clear();
            this.btnCrear.Show();
            this.btnModificar.Hide();
            this.btnCancelar.Hide();
        }
    }
}
