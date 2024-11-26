using System;
using System.Collections.Generic;
using System.Data;
using prop = WFO.Propiedades.Procesos.SupervisionGeneral;


namespace WFO.AccesoDatos.Procesos
{
    public class ReportesSupervion
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.rptResumenSuspension> rpt_ResumenSuspenciones(DateTime FechaInicial, DateTime FechaFinal)
        {
            b.ExecuteCommandSP("Tramites_ResumenSuspendidos");
            b.AddParameter("@FechaI", FechaInicial, SqlDbType.DateTime);
            b.AddParameter("@FechaF", FechaFinal, SqlDbType.DateTime);
            List<prop.rptResumenSuspension> resultado = new List<prop.rptResumenSuspension>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.rptResumenSuspension item = new prop.rptResumenSuspension()
                {
                    Mesa = reader["Mesa"].ToString(),
                    Operador = reader["Operador"].ToString(),
                    Folio = reader["Folio"].ToString(),
                    FechaIngreso = DateTime.Parse(reader["Fecha Ingresó"].ToString()),
                    FechaSuspension = DateTime.Parse(reader["Fecha Suspensión"].ToString()),
                    Agente = reader["Agente"].ToString(),
                    AgenteClave = reader["Clave Agente"].ToString(),
                    MotivosSuspension = reader["Motivos Suspensión WFO"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.rptTramitesKWIK> rpt_TramitesKWIK(int idFlujo, DateTime FechaInicio, DateTime FechaFinal)
        {
            b.ExecuteCommandSP("Tramites_ProcesadosKWIK");
            b.AddParameter("@IdFlujo", idFlujo, SqlDbType.Int);
            b.AddParameter("@FechaI", FechaInicio, SqlDbType.DateTime);
            b.AddParameter("@FechaF", FechaFinal, SqlDbType.DateTime);
            List<prop.rptTramitesKWIK> resultado = new List<prop.rptTramitesKWIK>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.rptTramitesKWIK item = new prop.rptTramitesKWIK()
                {
                    IdTramite = int.Parse(reader["IdTramite"].ToString()),
                    StatusTramite = reader["Status Trámite"].ToString(),
                    Folio = reader["Folio"].ToString(),
                    RegistroTrámite = DateTime.Parse(reader["Registro trámite"].ToString()),
                    Mesa = reader["Mesa"].ToString(),
                    StatusMesa = reader["Status Mesa"].ToString(),
                    FechaProceso = DateTime.Parse(reader["Fecha Procesó en KWIK"].ToString()),
                    Poliza = reader["Póliza"].ToString(),
                    DCNKWIK = reader["DCN KWIK"].ToString(),
                    ObsPublica = reader["Obs Pública"].ToString(),
                    ObsPrivada = reader["Obs Privada"].ToString(),
                    Revisión = reader["Revisión"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.rpt_TiemposAtencionOperacionEspera> rpt_TramietsTiemposAtencion(int idFlujo, DateTime FechaInicio, DateTime FechaFinal)
        {
            b.ExecuteCommandSP("rpt_TiemposAtencionOperacionEspera");
            b.AddParameter("@IdFlujo", idFlujo, SqlDbType.Int);
            b.AddParameter("@FechaInicial", FechaInicio, SqlDbType.DateTime);
            b.AddParameter("@FechaTermino", FechaFinal, SqlDbType.DateTime);
            List<prop.rpt_TiemposAtencionOperacionEspera> resultado = new List<prop.rpt_TiemposAtencionOperacionEspera>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.rpt_TiemposAtencionOperacionEspera item = new prop.rpt_TiemposAtencionOperacionEspera()
                {
                    idTramite = int.Parse(reader["idTramite"].ToString()),
                    Folio = reader["Folio"].ToString(),
                    Promotoria = reader["Promotoria"].ToString(),
                    promoVecesTotales = int.Parse(reader["promoVecesTotales"].ToString()),
                    promoVecesPausadas = int.Parse(reader["promoVecesPausadas"].ToString()),
                    promoVecesSuspendidas = int.Parse(reader["promoVecesSuspendidas"].ToString()),
                    promoVecesProcesadas = int.Parse(reader["promoVecesProcesadas"].ToString()),
                    promoTiempoEfectivo = double.Parse(reader["promoTiempoEfectivo"].ToString()),
                    promoTiempoTotalOperacion = double.Parse(reader["promoTiempoTotalOperacion"].ToString()),
                    promoTiempoEspera = double.Parse(reader["promoTiempoEspera"].ToString()),
                    Admision = reader["Admision"].ToString(),
                    ADMVecesTotales = int.Parse(reader["ADMVecesTotales"].ToString()),
                    ADMVecesPausadas = int.Parse(reader["ADMVecesPausadas"].ToString()),
                    ADMVecesSuspendidas = int.Parse(reader["ADMVecesSuspendidas"].ToString()),
                    ADMVecesProcesadas = int.Parse(reader["ADMVecesProcesadas"].ToString()),
                    ADMTiempoEfectivo = double.Parse(reader["ADMTiempoEfectivo"].ToString()),
                    ADMTiempoTotalOperacion = double.Parse(reader["ADMTiempoTotalOperacion"].ToString()),
                    ADMTiempoEspera = double.Parse(reader["ADMTiempoEspera"].ToString()),
                    RevDoc = reader["RevDoc"].ToString(),
                    RevDocVecesTotales = int.Parse(reader["RevDocVecesTotales"].ToString()),
                    RevDocVecesPausadas = int.Parse(reader["RevDocVecesPausadas"].ToString()),
                    RevDocVecesSuspendidas = int.Parse(reader["RevDocVecesSuspendidas"].ToString()),
                    RevDocVecesProcesadas = int.Parse(reader["RevDocVecesProcesadas"].ToString()),
                    RevDocTiempoEfectivo = double.Parse(reader["RevDocTiempoEfectivo"].ToString()),
                    RevDocTiempoTotalOperacion = double.Parse(reader["RevDocTiempoTotalOperacion"].ToString()),
                    RevDocTiempoEspera = double.Parse(reader["RevDocTiempoEspera"].ToString()),
                    RevPlad = reader["RevPlad"].ToString(),
                    RevPladVecesTotales = int.Parse(reader["RevPladVecesTotales"].ToString()),
                    RevPladVecesPausadas = int.Parse(reader["RevPladVecesPausadas"].ToString()),
                    RevPladVecesSuspendidas = int.Parse(reader["RevPladVecesSuspendidas"].ToString()),
                    RevPladVecesProcesadas = int.Parse(reader["RevPladVecesProcesadas"].ToString()),
                    RevPladTiempoEfectivo = double.Parse(reader["RevPladTiempoEfectivo"].ToString()),
                    RevPladTiempoTotalOperacion = double.Parse(reader["RevPladTiempoTotalOperacion"].ToString()),
                    RevPladTiempoEspera = double.Parse(reader["RevPladTiempoEspera"].ToString()),
                    Seleccion = reader["Seleccion"].ToString(),
                    SelecVecesTotales = int.Parse(reader["SelecVecesTotales"].ToString()),
                    SelecVecesPausadas = int.Parse(reader["SelecVecesPausadas"].ToString()),
                    SelecVecesSuspendidas = int.Parse(reader["SelecVecesSuspendidas"].ToString()),
                    SelecVecesProcesadas = int.Parse(reader["SelecVecesProcesadas"].ToString()),
                    SelecTiempoEfectivo = double.Parse(reader["SelecTiempoEfectivo"].ToString()),
                    SelecTiempoTotalOperacion = double.Parse(reader["SelecTiempoTotalOperacion"].ToString()),
                    SelecTiempoEspera = double.Parse(reader["SelecTiempoEspera"].ToString()),
                    Captura = reader["Captura"].ToString(),
                    CapVecesTotales = int.Parse(reader["CapVecesTotales"].ToString()),
                    CapVecesPausadas = int.Parse(reader["CapVecesPausadas"].ToString()),
                    CapVecesSuspendidas = int.Parse(reader["CapVecesSuspendidas"].ToString()),
                    CapVecesProcesadas = int.Parse(reader["CapVecesProcesadas"].ToString()),
                    CapTiempoEfectivo = double.Parse(reader["CapTiempoEfectivo"].ToString()),
                    CapTiempoTotalOperacion = double.Parse(reader["CapTiempoTotalOperacion"].ToString()),
                    CapTiempoEspera = double.Parse(reader["CapTiempoEspera"].ToString()),
                    Control = reader["Control"].ToString(),
                    CTRLVecesTotales = int.Parse(reader["CTRLVecesTotales"].ToString()),
                    CTRLVecesPausadas = int.Parse(reader["CTRLVecesPausadas"].ToString()),
                    CTRLVecesSuspendidas = int.Parse(reader["CTRLVecesSuspendidas"].ToString()),
                    CTRLVecesProcesadas = int.Parse(reader["CTRLVecesProcesadas"].ToString()),
                    CTRLTiempoEfectivo = double.Parse(reader["CTRLTiempoEfectivo"].ToString()),
                    CTRLTiempoTotalOperacion = double.Parse(reader["CTRLTiempoTotalOperacion"].ToString()),
                    CTRLTiempoEspera = double.Parse(reader["CTRLTiempoEspera"].ToString()),
                    Emision = reader["Emision"].ToString(),
                    EmisionVecesTotales = int.Parse(reader["EmisionVecesTotales"].ToString()),
                    EmisionVecesPausadas = int.Parse(reader["EmisionVecesPausadas"].ToString()),
                    EmisionVecesSuspendidas = int.Parse(reader["EmisionVecesSuspendidas"].ToString()),
                    EmisionVecesProcesadas = int.Parse(reader["EmisionVecesProcesadas"].ToString()),
                    EmisionTiempoEfectivo = double.Parse(reader["EmisionTiempoEfectivo"].ToString()),
                    EmisionTiempoTotalOperacion = double.Parse(reader["EmisionTiempoTotalOperacion"].ToString()),
                    EmisionTiempoEspera = double.Parse(reader["EmisionTiempoEspera"].ToString()),
                    Calidad = reader["Calidad"].ToString(),
                    CalVecesTotales = int.Parse(reader["CalVecesTotales"].ToString()),
                    CalVecesPausadas = int.Parse(reader["CalVecesPausadas"].ToString()),
                    CalVecesSuspendidas = int.Parse(reader["CalVecesSuspendidas"].ToString()),
                    CalVecesProcesadas = int.Parse(reader["CalVecesProcesadas"].ToString()),
                    CalTiempoEfectivo = double.Parse(reader["CalTiempoEfectivo"].ToString()),
                    CalTiempoTotalOperacion = double.Parse(reader["CalTiempoTotalOperacion"].ToString()),
                    CalTiempoEspera = double.Parse(reader["CalTiempoEspera"].ToString()),
                    Kwik = reader["Kwik"].ToString(),
                    KwikVecesTotales = int.Parse(reader["KwikVecesTotales"].ToString()),
                    KwikVecesPausadas = int.Parse(reader["KwikVecesPausadas"].ToString()),
                    KwikVecesSuspendidas = int.Parse(reader["KwikVecesSuspendidas"].ToString()),
                    KwikVecesProcesadas = int.Parse(reader["KwikVecesProcesadas"].ToString()),
                    KwikTiempoEfectivo = double.Parse(reader["KwikTiempoEfectivo"].ToString()),
                    KwikTiempoTotalOperacion = double.Parse(reader["KwikTiempoTotalOperacion"].ToString()),
                    KwikTiempoEspera = double.Parse(reader["KwikTiempoEspera"].ToString()),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataSet rptTramietsTiemposAtencion(int idFlujo, DateTime FechaInicio, DateTime FechaFinal, int IdUsuario)
        {
            DataSet dsResultado = null;

            b.ExecuteCommandSP("rpt_TiemposAtencionOperacionEspera");
            b.AddParameter("@IdFlujo", idFlujo, SqlDbType.Int);
            b.AddParameter("@FechaInicial", FechaInicio, SqlDbType.DateTime);
            b.AddParameter("@FechaTermino", FechaFinal, SqlDbType.DateTime);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            dsResultado = b.SelectExecuteFunctions();

            return dsResultado;
        }

        public DataSet rpt_ResumenOperacion(int IdFlujo, DateTime FechaReporte)
        {
            DataSet resultado = null;
            b.ExecuteCommandSP("Tramites_ResumenOperación");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            b.AddParameter("@FechaReporte", FechaReporte, SqlDbType.DateTime);
            resultado = b.SelectExecuteFunctions();
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataTable getBitacoraDownload()
        {
            DataTable dtResultado = null;
            b.ExecuteCommandSP("TiemposAtencionConsultaBitacoraDescarga");
            dtResultado = b.Select();
            return dtResultado;
        }

    }
}
