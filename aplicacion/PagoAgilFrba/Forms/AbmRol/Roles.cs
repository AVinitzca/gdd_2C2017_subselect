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

namespace PagoAgilFrba.AbmRol
{
    public partial class FormRoles : Form
    {
        private BindingList<Rol> roles;
        private List<int> aBorrar = new List<int>();
        private List<int> aAgregar = new List<int>();
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
            Respuesta respuesta = DB.DB.Instancia.crearRol(rolNuevo);
            if(respuesta.Codigo == 0)
            {
                this.roles.Add(rolNuevo);
            }
            else
            {
                MessageBox.Show(respuesta.Mensaje);
            }
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
                    foreach (int funcionalidad in rol.Funcionalidades)
                    {
                        this.lstFuncionalidades.SelectedItems.Add(DB.DB.Instancia.encontrar(typeof(Funcionalidad), funcionalidad));
                    }
                    this.btnModificar.Visible = true;
                    this.btnCancelar.Visible = true;
                    this.btnCrear.Visible = false;
                    this.gpbNuevoRol.Tag = rol;
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "dgvColumnBorrar")
                {
                    Respuesta respuesta = DB.DB.Instancia.cambiarEstado(this.roles[e.RowIndex]);
                    if (respuesta.Codigo != 0)
                    {
                        MessageBox.Show(respuesta.Mensaje);
                    }
                    else
                    {
                        this.roles.ResetItem(e.RowIndex);
                        if (this.gpbNuevoRol.Tag != null)
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

            Rol modificado = ((Rol)this.gpbNuevoRol.Tag);
            this.llenar(ref modificado);
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
            Respuesta respuesta = DB.DB.Instancia.modificarRol(modificado, this.aAgregar, this.aBorrar);
            if (respuesta.Codigo != 0)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            this.roles.ResetItem(this.roles.IndexOf(modificado));
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
            return false;
        }

        protected void llenar(ref Rol rol)
        {
            rol.Nombre = this.txtNombre.Text;            
            List<int> funcionalidades = new List<int>();
            aBorrar.Clear();
            aAgregar.Clear();
            foreach (object item in this.lstFuncionalidades.SelectedItems)
            {
                int id = DB.DB.Instancia.id(item);
                funcionalidades.Add(id);
                if(!rol.Funcionalidades.Contains(id))
                {
                    aAgregar.Add(id);
                }
            }
            foreach (int funcionalidad in rol.Funcionalidades)
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
