﻿using PagoAgilFrba.DB;
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
                Factura aDevolver = (Factura)this.cmbFacturas.SelectedItem;
                Respuesta respuesta = DB.DB.Instancia.devolverFactura(aDevolver, this.txtMotivo.Text);             
                if (respuesta.Codigo == 0)
                {
                    MessageBox.Show("La rendicion fue devuelta con exito");
                    this.cmbFacturas.SelectedIndex = -1;
                    this.txtMotivo.Clear();
                    this.cmbFacturas.Items.Remove(aDevolver);
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
