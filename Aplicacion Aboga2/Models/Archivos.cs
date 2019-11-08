using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class Archivos
    {
        private int _IdArchivo;
        private string _Nombre;

        public Archivos() { }

        public Archivos(int IdArchivo,string Nombre)
        {
            _IdArchivo = IdArchivo;
             _Nombre = Nombre;
        }

        public int IdArchivo { get => _IdArchivo; set => _IdArchivo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
    }
}