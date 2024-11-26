using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.Propiedades.Procesos.SupervisionGeneral
{
    public class rptResumenSuspension
    {
        public string Mesa { get; set; }
        public string Operador { get; set; }
        public string Folio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSuspension { get; set; }
        public string Agente { get; set; }
        public string AgenteClave { get; set; }
        public string MotivosSuspension { get; set; }
    }
}
