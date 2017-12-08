using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.AbmRol;
using PagoAgilFrba.Dominio;
using PagoAgilFrba.Forms.AbmEmpresa;
using PagoAgilFrba.Forms.AbmSucursal;
using PagoAgilFrba.Forms.Devolucion;
using PagoAgilFrba.RegistroPago;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Forms.MenuPrincipal
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {   
            // Por cada funcionalidad, agrega un boton que redirige a ese formulario en la barra de navegacion
            // Agrega el listener de click ("irAFormulario") de cada boton                        
            foreach(int id in Usuario.Logeado.Rol.Funcionalidades)
            {
                Funcionalidad funcionalidad = (Funcionalidad)DB.DB.Instancia.encontrar(typeof(Funcionalidad), id);
                ToolStripButton btnOpcion = new ToolStripButton(funcionalidad.Descripcion);
                btnOpcion.Tag = funcionalidad;
                btnOpcion.Click += new System.EventHandler(this.irAFormulario);
                this.mnsNavbar.Items.Add(btnOpcion);
            }
        }

        public void irAFormulario(object sender, EventArgs e)
        {
            // Busca el formulario segun nombre "Form" + descripcion de funcionalidad
            Funcionalidad funcionalidad = ((Funcionalidad)((ToolStripButton)sender).Tag);
            Type form = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Name.Equals("Form" + funcionalidad.Descripcion.Replace(" ", ""))).FirstOrDefault();
            // Si no lo encuentra, tira una excepcion
            if (form == null)
            {
                throw new Exception("Funcionalidad no encontrada");
            }
            // Si lo encuntra, crea una instancia y direcciona ahi
            ((Form)Activator.CreateInstance(form)).Show();
            this.Hide();
        }
    }
}
