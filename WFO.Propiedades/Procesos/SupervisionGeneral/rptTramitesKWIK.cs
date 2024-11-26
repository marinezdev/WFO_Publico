using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.Propiedades.Procesos.SupervisionGeneral
{
    public class rptTramitesKWIK
    {

        public int IdTramite { get; set; }
        public string StatusTramite { get; set; }
        public string Folio { get; set; }
        public DateTime RegistroTrámite { get; set; }
        public string Mesa { get; set; }
        public string StatusMesa { get; set; }
        public DateTime FechaProceso { get; set; }
        public string Poliza { get; set; }
        public string DCNKWIK { get; set; }
        public string ObsPublica { get; set; }
        public string ObsPrivada { get; set; }
        public string Revisión { get; set; }
    }
}
