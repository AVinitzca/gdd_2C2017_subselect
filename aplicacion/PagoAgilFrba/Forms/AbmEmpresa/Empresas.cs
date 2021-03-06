﻿using PagoAgilFrba.DB;
using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.MenuPrincipal;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Forms.AbmEmpresa
{
    public partial class FormEmpresas : Form
    {
        private BindingList<Empresa> empresas;

        public FormEmpresas()
        {
            InitializeComponent();
        }

        private void Empresas_Load(object sender, EventArgs e)
        {
            // Carga la lista de empresas
            // Tambien la lista de rubros

            this.empresas = new BindingList<Empresa>();
            this.cmbRubro.Items.AddRange(DB.DB.Instancia.obtenerRubros().ToArray());
            this.cmbFiltroRubro.Items.AddRange(DB.DB.Instancia.obtenerRubros().ToArray());
            this.cargarEmpresas();
            this.dgvEmpresas.DataSource = empresas;
            // Pone el nombre de la propiedad en el datagridview
            foreach(DataGridViewColumn c in this.dgvEmpresas.Columns)
            {
                if(c.Name == "Rubro")
                {
                    c.DataPropertyName = "RubroDescripcion";
                }
            }
            // Crea los botones de modificar y borrar
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
            this.dgvEmpresas.Columns.Add(modificar);
            this.dgvEmpresas.Columns.Add(borrar);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {            
            if (!this.validarFormulario())
            {
                return;
            }
            // Crea una nueva empresa
            // La llena con los datos del formulario
            Empresa nueva = new Empresa();
            this.llenar(ref nueva);            
            // Informa a la DB
            // Si no hubo ningun problema, agrega la empresa
            Respuesta respuesta = DB.DB.Instancia.crearEmpresa(nueva);
            if (respuesta.Codigo == 0)
            {
                this.empresas.Add(nueva);
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje);
            }
        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se fija que columna fue clickeada
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Si fue clickeada modificar, obtiene al objeto de esa fila y llena los campos con sus datos
                // Tambien pone un tag para marcar a ese objeto
                if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnModificar" && this.gpbIngreso.Tag == null)
                {
                    Empresa empresa = this.empresas[e.RowIndex];

                    this.txtNombre.Text = empresa.Nombre;
                    this.txtCuit.Text = empresa.Cuit;
                    this.txtDireccion.Text = empresa.Direccion;
                    this.cmbRubro.SelectedItem = empresa.Rubro;
                    this.numDiasRend.Text = Convert.ToString(empresa.DiaRendicion);
                    this.gpbIngreso.Text = "Modificar Empresa";
                    this.btnModificar.Visible = true;
                    this.btnCancelar.Visible = true;
                    this.btnCrear.Visible = false;
                    this.gpbIngreso.Tag = empresa;
                }
                // Si fue clickeada borrar, trata de borrar al objeto en la DB
                // Si todo sale bien, actualiza la vista y borra el tag
                else if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnBorrar")
                {
                    Respuesta respuesta = DB.DB.Instancia.cambiarEstado(this.empresas[e.RowIndex]);
                    if(respuesta.Codigo != 0)
                    {
                        MessageBox.Show(respuesta.Mensaje);
                    }
                    else
                    {
                        this.empresas.ResetItem(e.RowIndex);
                        if (this.gpbIngreso != null)
                        {
                            this.cancelar();
                        }
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
            // Modifica una Empresa segun el tag
            // Llena la empresa con los datos del formulario
            // Limpia el formulario
            Empresa modificada = ((Empresa)this.gpbIngreso.Tag);
            String cuit = modificada.Cuit;
            this.llenar(ref modificada);
            this.gpbIngreso.Text = "Nueva Empresa";            
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
            // Llama a la DB
            // Si no hubo problema en modificar, refresca el item
            Respuesta respuesta = DB.DB.Instancia.modificarEmpresa(modificada);
            if(respuesta.Codigo == 0)
            {
                this.gpbIngreso.Tag = null;
                this.empresas.ResetItem(this.empresas.IndexOf(modificada));
            }
            else
            {
                modificada.Cuit = cuit;
                MessageBox.Show(respuesta.Mensaje);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        protected void cancelar()
        {
            // Borra el tag y limpia el formulario
            this.gpbIngreso.Tag = null;
            this.gpbIngreso.Text = "Nueva Empresa";
            this.txtNombre.Clear();
            this.txtCuit.Clear();
            this.txtDireccion.Clear();
            this.cmbRubro.SelectedIndex = -1;
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
        }

        protected bool validarFormulario()
        {
            // Valida el formulario
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Error: El nombre de la empresa no puede estar vacio");                
            }
            else if (this.txtCuit.Text == "")
            {
                MessageBox.Show("Error: El cuit de la empresa no puede estar vacio");
            }
            else if (this.txtDireccion.Text == "")
            {
                MessageBox.Show("Error: La direccion de la empresa no puede estar vacia");
            }
            else if (this.cmbRubro.SelectedItem == null)
            {
                MessageBox.Show("Error: El rubro de la empresa no puede estar vacio");
            }
            else if (this.numDiasRend.Text == null)
            {
                MessageBox.Show("Error: El dia de rendicion no puede ser nulo");
            }
            else
            {
                return true;
            }
            return false;
        }

        protected void llenar(ref Empresa empresa)
        {
            // Llena la Empresa y limpia el formulario
            empresa.Nombre = this.txtNombre.Text;
            empresa.Cuit = this.txtCuit.Text;
            empresa.Direccion = this.txtDireccion.Text;
            empresa.Rubro = (Rubro)this.cmbRubro.SelectedItem;
            empresa.DiaRendicion = Convert.ToInt32(this.numDiasRend.Text);
            this.txtNombre.Clear();
            this.txtCuit.Clear();
            this.txtDireccion.Clear();
            this.cmbRubro.SelectedIndex = -1;
        }

        protected void cargarEmpresas()
        {
            // Busca empresas segun los campos de filtro
            this.empresas = new BindingList<Empresa>(DB.DB.Instancia.obtenerEmpresas(this.txtFiltroNombre.Text, this.txtFiltroCuit.Text, (Rubro)this.cmbFiltroRubro.SelectedItem, false));
            this.dgvEmpresas.DataSource = this.empresas;
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            this.cargarEmpresas();
        }

        private void txtFiltroCuit_TextChanged(object sender, EventArgs e)
        {
            this.cargarEmpresas();
        }

        private void cmbFiltroRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarEmpresas();
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
