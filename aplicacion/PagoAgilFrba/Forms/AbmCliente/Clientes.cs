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

namespace PagoAgilFrba.AbmCliente
{
    public partial class FormClientes : Form
    {
        protected BindingList<Cliente> clientes; 

        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            this.clientes = new BindingList<Cliente>();
            this.cargarClientes();
            this.dgvClientes.DataSource = clientes;
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
            this.dgvClientes.Columns.Add(modificar);
            this.dgvClientes.Columns.Add(borrar);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
            {
                return;
            }

            Cliente nuevo = new Cliente();
            this.llenar(ref nuevo);
            this.clientes.Add(nuevo);
            DB.DB.Instancia.crearCliente(nuevo);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnModificar" && this.gpbIngreso.Tag == null)
                {
                    Cliente cliente = this.clientes[e.RowIndex];

                    this.txtNombre.Text = cliente.Nombre;
                    this.txtApellido.Text = cliente.Apellido;
                    this.txtDNI.Text = cliente.DNI.ToString();
                    this.txtEmail.Text = cliente.Email;
                    this.txtTelefono.Text = cliente.Telefono.ToString();
                    this.txtDireccion.Text = cliente.Direccion;
                    this.txtCodigoPostal.Text = cliente.CodigoPostal.ToString();
                    this.dtpFechaDeNacimiento.Value = cliente.FechaDeNacimiento;
                    this.gpbIngreso.Text = "Modificar Cliente";
                    this.btnModificar.Visible = true;
                    this.btnCancelar.Visible = true;
                    this.btnCrear.Visible = false;
                    this.gpbIngreso.Tag = cliente;
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnBorrar")
                {                                  
                    DB.DB.Instancia.cambiarEstado(this.clientes[e.RowIndex]);                    
                    if (this.gpbIngreso != null)
                    {
                        this.cancelar();
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

            Cliente modificada = ((Cliente)this.gpbIngreso.Tag);
            this.llenar(ref modificada);
            this.gpbIngreso.Text = "Nueva Cliente";
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
            DB.DB.Instancia.modificarCliente(modificada);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        protected void cancelar()
        {
            this.gpbIngreso.Tag = null;
            this.gpbIngreso.Text = "Nueva Cliente";
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtDNI.Clear();
            this.txtEmail.Clear();
            this.txtTelefono.Clear();
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
            this.dtpFechaDeNacimiento.Value = DateTime.Today;
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
        }

        protected bool validarFormulario()
        {
            int i;
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Error: El nombre del cliente no puede estar vacio");
            }
            else if(this.txtApellido.Text == "")
            {
                MessageBox.Show("Error: El apellido del cliente no puede estar vacio");
            }
            else if(this.txtDNI.Text == "")
            {
                MessageBox.Show("Error: El DNI del cliente no puede estar vacio");
            }
            else if(this.txtTelefono.Text == "")
            {
                MessageBox.Show("Error: El telefono no puede estar vacio");
            }
            else if(this.txtEmail.Text == "")
            {
                MessageBox.Show("Error: El email no puede estar vacio");
            }
            else if (this.txtDireccion.Text == "")
            {
                MessageBox.Show("Error: La direccion de la cliente no puede estar vacia");
            }
            else if (this.txtCodigoPostal.Text == "" || !Int32.TryParse(this.txtCodigoPostal.Text, out i))
            {
                MessageBox.Show("Error: El Codigo Postal de la cliente no puede estar vacio");
            }
            else
            {
                return true;
            }
            return false;
        }

        protected void llenar(ref Cliente cliente)
        {
            cliente.Nombre = this.txtNombre.Text;
            cliente.Apellido = this.txtApellido.Text;
            cliente.DNI = Int32.Parse(this.txtDNI.Text);
            cliente.Email = this.txtEmail.Text;
            cliente.Telefono = Int32.Parse(this.txtTelefono.Text);
            cliente.Direccion = this.txtDireccion.Text;
            cliente.CodigoPostal = Int32.Parse(this.txtCodigoPostal.Text);
            cliente.FechaDeNacimiento = this.dtpFechaDeNacimiento.Value;
            this.txtNombre.Clear();
            this.txtApellido.Clear();
            this.txtDNI.Clear();
            this.txtEmail.Clear();
            this.txtTelefono.Clear();
            this.txtDireccion.Clear();
            this.txtCodigoPostal.Clear();
            this.dtpFechaDeNacimiento.Value = DateTime.Today;
        }

        protected void cargarClientes()
        {        
            this.clientes = new BindingList<Cliente>(DB.DB.Instancia.obtenerClientes(this.txtFiltroNombre.Text, this.txtFiltroApellido.Text, this.txtFiltroDNI.Text == "" ? 0 : Int32.Parse(this.txtFiltroDNI.Text), false));
            this.dgvClientes.DataSource = this.clientes;
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
            this.cargarClientes();
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

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
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
        
        private void txtFiltroApellido_TextChanged(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void txtFiltroDNI_TextChanged(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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
            menuPrincipal.Show();
            this.Hide();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
