using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicacion_Aboga2.Models
{
    public class EventoArchi
    {
        private int _IdEventoArchi;
        private int _IdEvento;
        private int _IdArchivo;

        public EventoArchi()
        {
        }
        public EventoArchi(int IdEventoArchi, int IdEvento, int IdArchivo)
        {
            _IdEventoArchi = IdEventoArchi;
            _IdEvento = IdEvento;
            _IdArchivo = IdArchivo;
        }

        public int IdEventoArchi { get => _IdEventoArchi; set => _IdEventoArchi = value; }
        public int IdEvento { get => _IdEvento; set => _IdEvento = value; }
        public int IdArchivo { get => _IdArchivo; set => _IdArchivo = value; }
    }
}