using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.MenuPrincipal;

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class FormListadoEstadistico : Form
    {
        public FormListadoEstadistico()
        {
            InitializeComponent();
        }


        private void FormListadoEstadistico_Load(object sender, EventArgs e)
        {
            // Configura los campos
            this.numAnio.Maximum = Configuracion.Configuracion.fecha().Year;
            this.numAnio.Value = this.numAnio.Maximum;
            this.cmbListado.Items.AddRange(Listado.Listados.ToArray());
        }
        
        private void cmbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.recalcularListado();
        }

        private void numAnio_ValueChanged(object sender, EventArgs e)
        {
            this.recalcularListado();
        }

        private void numTrimestre_ValueChanged(object sender, EventArgs e)
        {
            this.recalcularListado();
        }

        protected void recalcularListado()
        {
            // Recarga el listado en base a filtros y el listado seleccionado
            if(this.cmbListado.SelectedItem != null)
            {
                this.dgvListado.DataSource = DB.DB.Instancia.obtenerListado(this.cmbListado.SelectedItem.GetType(), Convert.ToInt32(this.numAnio.Value), Convert.ToInt32(this.numTrimestre.Value));
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
