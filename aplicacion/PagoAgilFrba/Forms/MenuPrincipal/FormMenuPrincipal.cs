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
            foreach(Funcionalidad funcionalidad in Usuario.Logeado.Rol.Funcionalidades)
            {
                ToolStripButton btnOpcion = new ToolStripButton(funcionalidad.Descripcion);
                btnOpcion.Tag = funcionalidad;
                btnOpcion.Click += new System.EventHandler(this.irAFormulario);
                this.mnsNavbar.Items.Add(btnOpcion);
            }
        }

        public void irAFormulario(object sender, EventArgs e)
        {
            Funcionalidad funcionalidad = ((Funcionalidad)((ToolStripButton)sender).Tag);
            Type form = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Name.Equals("Form" + funcionalidad.Descripcion.Replace(" ", ""))).FirstOrDefault();
            if(form == null)
            {
                throw new Exception("Funcionalidad no encontrada");
            }
            ((Form)Activator.CreateInstance(form)).Show();
            this.Hide();
        }
    }
}
