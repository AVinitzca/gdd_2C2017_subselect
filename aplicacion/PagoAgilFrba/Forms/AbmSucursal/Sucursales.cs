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

namespace PagoAgilFrba.Forms.AbmSucursal
{
    public partial class FormSucursales : Form
    {
        private BindingList<Sucursal> sucursales;
        
        public FormSucursales()
        {
            InitializeComponent();
        }

        private void FormSucursales_Load(object sender, EventArgs e)
        {
            this.sucursales = new BindingList<Sucursal>();
            this.cargarSucursales();
            DataGridViewButtonColumn modificar = new DataGridViewButtonColumn();
            DataGridViewButtonColumn borrar = new DataGridViewButtonColumn();
            modificar.Name = "dgvColumnModificar";
            borrar.Name = "dgvColumnBorrar";
            modificar.HeaderText = "Modificar";
            borrar.HeaderText = "Borrar";
            modificar.Text = modificar.HeaderText;
            borrar.Text = borrar.HeaderText;
            modificar.UseColumnTextForButtonValue = true;
            borrar.UseColumnTextForButtonValue = true;
            this.dgvSucursales.Columns.Add(modificar);
            this.dgvSucursales.Columns.Add(borrar);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
            {
                return;
            }

            Sucursal nueva = new Sucursal();
            this.llenar(ref nueva);
            
            Respuesta respuesta = DB.DB.Instancia.crearSucursal(nueva);
            if(respuesta.Codigo != 0)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                this.sucursales.Add(nueva);
            }               
        }

        private void dgvSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnModificar" && this.gpbIngreso.Tag == null)
                {
                    Sucursal sucursal = this.sucursales[e.RowIndex];

                    this.txtNombre.Text = sucursal.Nombre;                    
                    this.txtDireccion.Text = sucursal.Direccion;
                    this.txtCodigoPostal.Text = sucursal.CodigoPostal.ToString();
                    this.gpbIngreso.Text = "Modificar Sucursal";
                    this.btnModificar.Visible = true;
                    this.btnCancelar.Visible = true;
                    this.btnCrear.Visible = false;
                    this.gpbIngreso.Tag = sucursal;
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnBorrar")
                {
                    Respuesta respuesta = DB.DB.Instancia.cambiarEstado(this.sucursales[e.RowIndex]);
                    if(respuesta.Codigo == 0)
                    {
                        this.sucursales.ResetItem(e.RowIndex);
                        if (this.gpbIngreso.Tag != null)
                        {
                            this.cancelar();
                        }
                    }
                    else
                    {
                        MessageBox.Show(respuesta.Mensaje);
                    }                    
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
            {
                return;
            }

            Sucursal modificada = ((Sucursal)this.gpbIngreso.Tag);
            int codpos = modificada.CodigoPostal;
            this.llenar(ref modificada);
            this.gpbIngreso.Text = "Nueva Sucursal";
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;            
            Respuesta respuesta = DB.DB.Instancia.modificarSucursal(modificada);
            if(respuesta.Codigo != 0)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                modificada.CodigoPostal = codpos;
                this.sucursales.ResetItem(this.sucursales.IndexOf(modificada));
            }
            this.gpbIngreso.Tag = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        protected void cancelar()
        {
            this.gpbIngreso.Tag = null;
            this.gpbIngreso.Text = "Nueva Sucursal";
            this.txtNombre.Clear();
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
        }

        protected bool validarFormulario()
        {
            int i;
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Error: El nombre de la sucursal no puede estar vacio");
            }
            else if (this.txtDireccion.Text == "")
            {
                MessageBox.Show("Error: La direccion de la sucursal no puede estar vacia");
            }
            else if (this.txtCodigoPostal.Text == "" || !Int32.TryParse(this.txtCodigoPostal.Text, out i))
            {
                MessageBox.Show("Error: El Codigo Postal de la sucursal no puede estar vacio");
            }
            else
            {
                return true;
            }
            return false;
        }

        protected void llenar(ref Sucursal sucursal)
        {
            sucursal.Nombre = this.txtNombre.Text;            
            sucursal.Direccion = this.txtDireccion.Text;
            sucursal.CodigoPostal = Int32.Parse(this.txtCodigoPostal.Text);
            this.txtNombre.Clear();            
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
        }

        protected void cargarSucursales()
        {
            this.sucursales = new BindingList<Sucursal>(DB.DB.Instancia.obtenerSucursales(this.txtFiltroNombre.Text, this.txtFiltroCuit.Text, (this.txtFiltroCodigoPostal.Text == "") ? 0 : Int32.Parse(this.txtFiltroCodigoPostal.Text), false));
            this.dgvSucursales.DataSource = this.sucursales;
        }
        
        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            this.cargarSucursales();
        }

        private void txtFiltroCuit_TextChanged(object sender, EventArgs e)
        {
            this.cargarSucursales();
        }

        private void txtFiltroCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            this.cargarSucursales();
        }

        private void txtFiltroCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
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
