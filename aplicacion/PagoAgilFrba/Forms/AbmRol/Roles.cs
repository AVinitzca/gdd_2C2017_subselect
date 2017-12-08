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
            // Crea la lista de roles
            this.roles = new BindingList<Rol>();
            this.lstFuncionalidades.Items.AddRange(DB.DB.Instancia.obtenerFuncionalidades().ToArray());
            this.cargarRoles();            
            this.dgvRoles.DataSource = roles;

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
            this.dgvRoles.Columns.Add(modificar);
            this.dgvRoles.Columns.Add(borrar);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(!this.validarFormulario())
            {
                return;
            }

            // Crea un rol nuevo
            // Lo llena con los datos del formulario
            // Trata de crear un Rol nuevo
            // Si todo sale bien, lo agrega a la lista

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
            // Escucha clicks del datagridview
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Si se clickeo modificar busca sus funcionalidades y las selecciona de la lista
                // Tambien agrega el valor de su nombre a los campos
                // Crea un Tag a ese rol y oculta/muestra botones
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
                // Si se quiere borrar, se llama a la DB
                // Si todo sale bien, se actualiza la lista
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

            // Se modifica el Rol
            // Se lo llena con los valores de los campos
            // Se ocultan/muestran botones

            Rol modificado = ((Rol)this.gpbNuevoRol.Tag);
            this.llenar(ref modificado);
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;

            // Se llama a la DB
            // Si todo sale bien, borra el tag y actualiza el item

            Respuesta respuesta = DB.DB.Instancia.modificarRol(modificado, this.aAgregar, this.aBorrar);
            if (respuesta.Codigo != 0)
            {
                MessageBox.Show(respuesta.Mensaje);
            }
            else
            {
                this.roles.ResetItem(this.roles.IndexOf(modificado));
                this.gpbNuevoRol.Tag = null;
            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }
        
        protected void cancelar()
        {
            // Limpia los campos y el tag
            this.gpbNuevoRol.Tag = null;
            this.txtNombre.Clear();
            this.lstFuncionalidades.ClearSelected();
            this.btnCancelar.Visible = false;
            this.btnModificar.Visible = false;
            this.btnCrear.Visible = true;
        }

        protected bool validarFormulario()
        {
            // Valida el formulario
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
            // Llena al Rol con los datos del formulario
            // Llena dos listas: aAgregar y aBorrar
            // Cada lista funciona como diferencia con el Rol sin modificar
            // Es decir, si el Rol tenia la funcionalidad "Facturas" y ahora ya no la tiene
            // La funcionalidad esta en la lista "aBorrar"
            // Si el Rol tiene una funcionalidad que antes no tenia "Clientes"
            // La funcionalidad esta en la lista "aAgregar"
            // Esto es para comunicacion con la base de datos
            // Por ultimo limpia los campos

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
            // Obtiene los roles
            this.roles = new BindingList<Rol>(DB.DB.Instancia.obtenerRoles("", false));
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
