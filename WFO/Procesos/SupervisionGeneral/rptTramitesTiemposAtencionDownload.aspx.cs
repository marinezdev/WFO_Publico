using System;
using ClosedXML.Excel;
using System.Data;
using System.IO;
using System.Web;
using prosu = WFO.Propiedades.Procesos.SupervisionGeneral;
using System.Collections.Generic;


namespace WFO.Procesos.SupervisionGeneral
{
    public partial class rptTramitesTiemposAtencionDownload : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!String.IsNullOrEmpty(Request.QueryString["In"]) && !String.IsNullOrEmpty(Request.QueryString["Fn"]) && !String.IsNullOrEmpty(Request.QueryString["Us"]))
            {
                DateTime CalDesde = Convert.ToDateTime(Request.QueryString["In"].ToString());
                DateTime CalHasta = Convert.ToDateTime(Request.QueryString["Fn"].ToString());
                int _idUsuario = Convert.ToInt32(Request.QueryString["Us"].ToString());

                LabelFechaInicio.Text = CalDesde.Date.ToShortDateString();
                LabelFechaFin.Text = CalHasta.Date.ToShortDateString();
                LabelNum.Text = _idUsuario.ToString();
                LabelNum.Text = manejo_sesion.Usuarios.Nombre.ToUpper();
            }
        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {
            DateTime CalDesde = Convert.ToDateTime(LabelFechaInicio.Text.ToString());
            DateTime CalHasta = Convert.ToDateTime(LabelFechaFin.Text.ToString());
            DataSet dsSLA = null;
            int idFlujoConversiones = 3;

            WFO.Negocio.Procesos.Supervision.ReportesSupervision reporte = new WFO.Negocio.Procesos.Supervision.ReportesSupervision();
            dsSLA = reporte.rptTramietsTiemposAtencion(idFlujoConversiones, CalDesde, CalHasta, manejo_sesion.Usuarios.IdUsuario);

            Informacion.Visible = false;
            InformacionFin.Visible = true;
            Descarga(dsSLA);
        }

        protected void Descarga(DataSet dt)
        {
            var wb = new XLWorkbook();
            // Add all DataTables in the DataSet as a worksheets
            wb.Worksheets.Add(dt);

            // Prepare the response
            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"Sabana.xlsx\"");

            // Flush the workbook to the Response.OutputStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                wb.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.OutputStream);
                memoryStream.Close();
            }

            httpResponse.End();
        }
    }
}