﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Rol
    {
       
        private string nombre;

        // Es un entero para evitar problemas de referencias, se guarda su ID
        private List<int> funcionalidades = new List<int>();

        private bool activo = true;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        [Browsable(false)]
        public List<int> Funcionalidades
        {
            get
            {
                return this.funcionalidades;
            }
            set
            {
                this.funcionalidades = value;
            }
        }

        public String ListaFuncionalidades
        {
            get
            {
                // Devuelve la lista de funcionalidades como una cadena de caraceteres
                // Por Descripcion, separadas por una coma
                return this.funcionalidades.Select(funcionalidad => DB.DB.Instancia.encontrar(typeof(Funcionalidad), funcionalidad)).Cast<Funcionalidad>().Aggregate("", (prev, next) => (prev == "") ? next.Descripcion : (prev + ", " + next.Descripcion));
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public void agregarFuncionalidad(Funcionalidad funcionalidad)
        {
            this.funcionalidades.Add(DB.DB.Instancia.id(funcionalidad));
        }


    }
}
