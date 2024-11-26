using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.Propiedades.Procesos.Promotoria
{
    public class bitacora
    {
        public int Numero { get; set; }
        public string Mesa { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public string Usuario { get; set; }
        public string EstatusMesa { get; set; }
        public string Observacion { get; set; }
    }
}
