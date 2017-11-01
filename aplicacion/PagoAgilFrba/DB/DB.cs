using PagoAgilFrba.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.DB
{
    public class DB
    {
        private static readonly DB instancia = new DB();

        private DB()
        {
            
        }

        public static DB Instancia
        {
            get
            {
                return instancia;
            }
        }
        

        public List<Rubro> obtenerRubros()
        {
            List<Rubro> rubros = new List<Rubro>();

            Rubro rubroUno = new Rubro();
            rubroUno.Descripcion = "Materiales";

            rubros.Add(rubroUno);
            return rubros;
        }

        public List<RendicionFacturas> obtenerRendiciones()
        {
            return new List<RendicionFacturas>();
        }

        public List<Empresa> obtenerEmpresas(string nombre, string cuit, Rubro rubro)
        {
            List<Empresa> empresas = new List<Empresa>();
            empresas.Add(new Empresa());
            return empresas;
        }

        public List<Sucursal> obtenerSucursales(string nombre, string direccion, int codigoPostal)
        {
            return new List<Sucursal>();
        }

        public List<Factura> obtenerFacturas(Empresa selectedItem)
        {
            return new List<Factura>();
        }

        public List<Factura> obtenerFacturasPagas()
        {
            return new List<Factura>();
        }

        public List<Rol> obtenerRoles()
        {
            return new List<Rol>();
        }


        public List<Cliente> obtenerClientes(string text1, string text2, string text3)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente());
            return clientes;
        }

        public List<FormaDePago> obtenerFormasDePago()
        {
            List<FormaDePago> formasDePago = new List<FormaDePago>();            
            return formasDePago;
        }


        public void crearRol(Rol rolNuevo)
        {
            //
        }

        public void crearEmpresa(Empresa nueva)
        {
            //
        }

        public void crearSucursal(Sucursal nueva)
        {
        }


        public void crearCliente(Cliente nuevo)
        {
            
        }


        public void crearFactura(Factura factura)
        {

        }

        public void crearItem(ItemFactura item)
        {

        }

        public void crearPago(Pago pago)
        {

        }

        public void crearRendicion(RendicionFacturas rendicion)
        {
            
        }

        public void modificarEmpresa(Empresa modificada)
        {

        }

        public void modificarRol(Rol modificado)
        {

        }

        public void modificarSucursal(Sucursal modificada)
        {

        }

        public void modificarCliente(Cliente modificada)
        {
            
        }


        public void eliminarEmpresa(Empresa empresa)
        {

        }
        public void eliminarRol(Rol rol)
        {
        }


        public void eliminarSucursal(Sucursal sucursal)
        {
           
        }

        public void eliminarCliente(Cliente cliente)
        {

        }

        public void devolverFactura(Factura factura, string motivo)
        {

        }
        
        public void devolverRendicion(RendicionFacturas selectedItem, string text)
        {
            
        }
    }
}
