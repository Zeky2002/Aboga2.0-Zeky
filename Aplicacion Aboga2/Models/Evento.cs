using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class Evento
    {
        private int _IdEvento;
        private int _IdExpediente;
        private int _IdContacto;
        private string _Descripcion;
        private string _Titulo;
        private DateTime _Fecha;

        public Evento()
        {
        }

        public Evento(int IdEvento, int IdExpediente, int IdContacto, string Descripcion, string Titulo, DateTime Fecha)
        {
            _IdEvento = IdEvento;
            _IdExpediente = IdExpediente;
            _IdContacto = IdContacto;
            _Descripcion = Descripcion;
            _Titulo = Titulo;
            _Fecha = Fecha;
        }

        public int IdEvento { get => _IdEvento; set => _IdEvento = value; }
        public int IdExpediente { get => _IdExpediente; set => _IdExpediente = value; }
        public int IdContacto { get => _IdContacto; set => _IdContacto = value; }
        public string Titulo { get => _Titulo; set => _Titulo = value; }
        [Range(typeof(DateTime),"1/1/1900","31/12/2500",ErrorMessage ="Fecha fuera de rango")]
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}