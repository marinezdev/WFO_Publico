using System;
using System.Data;
using System.Collections.Generic;
using prop = WFO.Propiedades.Procesos.SupervisionGeneral;

namespace WFO.Negocio.Procesos.Supervision
{
    public class ReportesSupervision
    {
        AccesoDatos.Procesos.ReportesSupervion dReportes = new AccesoDatos.Procesos.ReportesSupervion();
        AccesoDatos.Procesos.Mesa mM = new AccesoDatos.Procesos.Mesa();

        public List<prop.rptResumenSuspension> rpt_ResumenSuspenciones(DateTime FechaInicial, DateTime FechaFinal)
        {
            return dReportes.rpt_ResumenSuspenciones(FechaInicial, FechaFinal);
        }

        public DataSet rpt_ResumenOperacion(int idFlujo, DateTime FechaReporte)
        {
            return dReportes.rpt_ResumenOperacion(idFlujo, FechaReporte);
        }

        public List<prop.rptTramitesKWIK> rpt_TramitesKWIK(int idFlujo, DateTime FechaInicio, DateTime FechaFinal)
        {
            return dReportes.rpt_TramitesKWIK(idFlujo, FechaInicio, FechaFinal);
        }
        
        public List<prop.rpt_TiemposAtencionOperacionEspera> rpt_TramietsTiemposAtencion(int idFlujo, DateTime FechaInicio, DateTime FechaFinal)
        {
            return dReportes.rpt_TramietsTiemposAtencion(idFlujo, FechaInicio, FechaFinal);
        }

        public DataSet rptTramietsTiemposAtencion(int idFlujo, DateTime FechaInicio, DateTime FechaFinal, int IdUsuario)
        {
            return dReportes.rptTramietsTiemposAtencion(idFlujo, FechaInicio, FechaFinal, IdUsuario);
        }

        public DataTable getBitacoraDownload()
        {
            return dReportes.getBitacoraDownload();
        }
    }
}
