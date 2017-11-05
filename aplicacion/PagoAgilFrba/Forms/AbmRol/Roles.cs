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

namespace PagoAgilFrba.AbmRol
{
    public partial class FormRoles : Form
    {
        private BindingList<Rol> roles;
        private List<Funcionalidad> aBorrar = new List<Funcionalidad>();
        private List<Funcionalidad> aAgregar = new List<Funcionalidad>();
        public FormRoles()
        {
            InitializeComponent();
        }
                
        private void FormRoles_Load(object sender, EventArgs e)
        {
            this.roles = new BindingList<Rol>();
            this.lstFuncionalidades.Items.AddRange(DB.DB.Instancia.obtenerFuncionalidades().ToArray());
            this.cargarRoles();            
            this.dgvRoles.DataSource = roles;
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
            this.dgvRoles.Columns.Add(modificar);
            this.dgvRoles.Columns.Add(borrar);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(!this.validarFormulario())
            {
                return;
            }

            Rol rolNuevo = new Rol();
            this.llenar(ref rolNuevo);
            this.roles.Add(rolNuevo);
            DB.DB.Instancia.crearRol(rolNuevo);
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if(senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnModificar" && this.gpbNuevoRol.Tag == null)
                {
                    Rol rol = this.roles[e.RowIndex];
                    this.txtNombre.Text = rol.Nombre;                    
                    for(int index = 0; index < this.lstFuncionalidades.Items.Count; index++)
                    {
                        if(rol.Funcionalidades.Contains(((Funcionalidad)this.lstFuncionalidades.Items[index])))
                        {
                            this.lstFuncionalidades.SelectedIndices.Add(index);
                        }                        
                    }
                    this.btnModificar.Visible = true;
                    this.btnCancelar.Visible = true;
                    this.btnCrear.Visible = false;
                    this.gpbNuevoRol.Tag = rol;
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnBorrar")
                {                    
                    DB.DB.Instancia.cambiarEstado(this.roles[e.RowIndex]);                    
                    if(this.gpbNuevoRol.Tag != null)
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

            Rol modificado = ((Rol)this.gpbNuevoRol.Tag);
            this.llenar(ref modificado);
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
            DB.DB.Instancia.modificarRol(modificado, this.aAgregar, this.aBorrar);
            this.gpbNuevoRol.Tag = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }
        
        protected void cancelar()
        {
            this.gpbNuevoRol.Tag = null;
            this.txtNombre.Clear();
            this.lstFuncionalidades.ClearSelected();
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
        }

        protected bool validarFormulario()
        {
            if (this.txtNombre.Text == "")
            {
                MessageBox.Show("Error: El nombre del rol no puede estar vacio");                
            }
            else if (this.lstFuncionalidades.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error: El rol debe contener al menos una funcionalidad");                
            }
            else
            {
                return true;
            }
            return true;
        }

        protected void llenar(ref Rol rol)
        {
            rol.Nombre = this.txtNombre.Text;            
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            aBorrar.Clear();
            aAgregar.Clear();
            foreach (object item in this.lstFuncionalidades.SelectedItems)
            {
                Funcionalidad funcionalidad = (Funcionalidad)item;
                funcionalidades.Add(funcionalidad);
                if(!rol.Funcionalidades.Contains(funcionalidad))
                {
                    aAgregar.Add(funcionalidad);
                }
            }
            foreach (Funcionalidad funcionalidad in rol.Funcionalidades)
            {
                if (!funcionalidades.Contains(funcionalidad))
                {
                    aBorrar.Add(funcionalidad);
                }
            }

            rol.Funcionalidades = funcionalidades;
            this.txtNombre.Clear();
            this.lstFuncionalidades.ClearSelected();            
        }

        protected void cargarRoles()
        {
            this.roles = new BindingList<Rol>(DB.DB.Instancia.obtenerRoles("", false));
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }
    }
}
