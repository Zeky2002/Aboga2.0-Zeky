using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class ExpedienteArchivo
    {
        private int _ExpedienteArchivos;
        private int _IdArchivo;
        private int _IdExpediente;

        public ExpedienteArchivo() { }

        public ExpedienteArchivo(int ExpedienteArchivos, int IdArchivo, int Expediente)
        {
            _ExpedienteArchivos = ExpedienteArchivos;
            _IdArchivo = IdArchivo;
            _IdExpediente = Expediente;
        }

        public int ExpedienteArchivos { get => _ExpedienteArchivos; set => _ExpedienteArchivos = value; }
        public int IdArchivo { get => _IdArchivo; set => _IdArchivo = value; }
        public int Expediente { get => _IdExpediente; set => _IdExpediente = value; }
    }
}