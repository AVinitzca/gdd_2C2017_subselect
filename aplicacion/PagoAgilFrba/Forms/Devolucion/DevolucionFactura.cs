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

namespace PagoAgilFrba.Forms.Devolucion
{
    public partial class FormDevolucionFactura : Form
    {
        public FormDevolucionFactura()
        {
            InitializeComponent();
        }

        private void FormDevolucionFactura_Load(object sender, EventArgs e)
        {
            this.cmbFacturas.Items.AddRange(DB.DB.Instancia.obtenerFacturasPagas().ToArray());
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if(this.cmbFacturas.SelectedItem == null)
            {
                MessageBox.Show("Error: Se debe seleccionar una factura a devolver");
            }
            else if(this.txtMotivo.Text == "")
            {
                MessageBox.Show("Error: Se debe seleccionar una motivo de la devolucion");
            }
            else
            {
                DB.DB.Instancia.devolverFactura((Factura)this.cmbFacturas.SelectedItem, this.txtMotivo.Text);
            }
        }
    }
}
