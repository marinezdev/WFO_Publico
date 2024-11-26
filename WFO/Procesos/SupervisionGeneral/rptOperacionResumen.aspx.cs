using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using prop = WFO.Propiedades.Procesos.Operacion;
using prosu = WFO.Propiedades.Procesos.SupervisionGeneral;
using ClosedXML.Excel;
using System.IO;

namespace WFO.Procesos.SupervisionGeneral
{
    public partial class rptOperacionResumen : Utilerias.Comun
    {
        WFO.Negocio.Procesos.Operacion.UsuariosFlujo usuariosFlujo = new Negocio.Procesos.Operacion.UsuariosFlujo();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            if (!IsPostBack)
            {
                //CalDesde.EditFormatString = "dd/MM/yyyy";
                //CalDesde.Date = DateTime.Now.AddDays(-1);
                //CalDesde.MaxDate = DateTime.Today;
                CalHasta.EditFormatString = "dd/MM/yyyy";
                CalHasta.Date = DateTime.Today;
                CalHasta.MaxDate = DateTime.Today;
                CargaFlujos(manejo_sesion.Usuarios.IdUsuario);
            }
        }

        protected void CargaFlujos(int Id)
        {
            List<prop.UsuariosFlujo> Flujos = usuariosFlujo.SelecionarFlujoSabana(Id);
            cbFlujos.DataSource = Flujos;
            cbFlujos.DataBind();
            cbFlujos.TextField = "Nombre";
            cbFlujos.ValueField = "Id";
            cbFlujos.DataBind();
        }

        protected void btnFiltroMes_Click(object sender, EventArgs e)
        {
            //DateTime fechaI = DateTime.Parse(CalDesde.Date.ToString("yyyy/MM/dd 00:00:00"));
            DateTime fechaF = DateTime.Parse(CalHasta.Date.ToString("yyyy/MM/dd 23:59:59"));
            String script;
            Mensaje.Text = "";
            int IdFlujo = Convert.ToInt32(cbFlujos.SelectedItem.Value.ToString());

            WFO.Negocio.Procesos.Supervision.ReportesSupervision reporte = new WFO.Negocio.Procesos.Supervision.ReportesSupervision();
            DataSet tramites = reporte.rpt_ResumenOperacion(IdFlujo, fechaF);

            int tIngresados1 = int.Parse(tramites.Tables[0].Rows[0]["Trámites Ingresados (outtime)"].ToString());
            int tIngresados1Banamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Ingresados (outtime) Banamex"].ToString());
            int tReingresados1 = int.Parse(tramites.Tables[0].Rows[0]["Trámites Reingresados (outtime)"].ToString());
            int tReingresados1Banamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Reingresados (outtime) Banamex"].ToString());
            int tIngresados2 = int.Parse(tramites.Tables[0].Rows[0]["Trámites Ingresados (día)"].ToString());
            int tIngresados2Banamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Ingresados (día) Banamex"].ToString());
            int tReingresados2 = int.Parse(tramites.Tables[0].Rows[0]["Trámites Reingresados (día)"].ToString());
            int tReingresados2Banamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Reingresados (día) Banamex"].ToString());
            int tPausados = int.Parse(tramites.Tables[0].Rows[0]["Trámites Pausados"].ToString());
            int tPausadosBanamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Pausados Banamex"].ToString());
            int tSuspendidos = int.Parse(tramites.Tables[0].Rows[0]["Trámites Suspendidos"].ToString());
            int tSuspendidosBanamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Suspedidos Banamex"].ToString());
            int tEjecutados = int.Parse(tramites.Tables[0].Rows[0]["Trámites Ejecutados"].ToString());
            int tEjecutadosBanamex = int.Parse(tramites.Tables[0].Rows[0]["Trámites Ejecutados Banamex"].ToString());
            int tRechazados = int.Parse(tramites.Tables[0].Rows[0]["Tramites Rechazados"].ToString());
            int tRechazadosBanamex = int.Parse(tramites.Tables[0].Rows[0]["Tramites Rechazados Banamex"].ToString());
            int tTotalN = tIngresados1 + tReingresados1 + tIngresados2 + tReingresados2 + tSuspendidos + tEjecutados + tRechazados + tPausados;
            int tTotalBanamex = tIngresados1Banamex + tReingresados1Banamex + tIngresados2Banamex + tReingresados2Banamex + tSuspendidosBanamex + tEjecutadosBanamex + tRechazadosBanamex + tPausadosBanamex;
            int tTotales = tTotalN + tTotalBanamex;
            int tRango1 = int.Parse(tramites.Tables[2].Rows[0]["Rango 1"].ToString());
            int tRango2 = int.Parse(tramites.Tables[2].Rows[0]["Rango 2"].ToString());
            int tRango3 = int.Parse(tramites.Tables[2].Rows[0]["Rango 3"].ToString());
            int tRango4 = int.Parse(tramites.Tables[2].Rows[0]["Rango 4"].ToString());

            // Resumen de operación al día (se toman los trámites ingresados fuera del horairo operacional. después de las 5 pm)
            lblTramitesIngresados1.Text = tIngresados1.ToString();
            lblTramitesIngresados1Banamex.Text = tIngresados1Banamex.ToString();
            lblTramitesReingresados1.Text = tReingresados1.ToString();
            lblTramitesReingresados1Banamex.Text = tReingresados1Banamex.ToString();
            lblTramitesIngresados2.Text = tIngresados2.ToString();
            lblTramitesIngresados2Banamex.Text = tIngresados2Banamex.ToString();
            lblTramitesReingresados2.Text = tReingresados2.ToString();
            lblTramitesReingresados2Banamex.Text = tReingresados2Banamex.ToString();
            lblTramitesPausados.Text = tPausados.ToString();
            lblTramitesPausadosBanamex.Text = tPausadosBanamex.ToString();
            lblTramitesSuspendidos.Text = tSuspendidos.ToString();
            lblTramitesSuspendidosBanamex.Text = tSuspendidosBanamex.ToString();
            lblTramitesEjecutados.Text = tEjecutados.ToString();
            lblTramitesEjecutadosBanamex.Text = tEjecutadosBanamex.ToString();
            lblTramitesRechazados.Text = tRechazados.ToString();
            lblTramitesRechazadosBanamex.Text = tRechazadosBanamex.ToString();
            lblTotalTramites.Text = tTotalN.ToString();
            lblTotalTramitesBanamex.Text = tTotalBanamex.ToString();
            lblTotal.Text = tTotales.ToString();
            lblRango1.Text = tRango1.ToString();
            lblRango2.Text = tRango2.ToString();
            lblRango3.Text = tRango3.ToString();
            lblRango4.Text = tRango4.ToString();
            lblTotalRango.Text = (tRango1 + tRango2 + tRango3 + tRango4).ToString();

            // Formato de tabla
            script = "";
            script += "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', order: [], bFilter: false, bInfo: false, bPaginate: false, buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]});";
            script += "$('#resumenDias').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', order: [], bFilter: false, bInfo: false, bPaginate: false, buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]});";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            exportar();
        }

        protected void exportar()
        {
            DataSet ds = new DataSet();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataRow row = null;

            table1.Columns.Add("Concepto", typeof(string));
            table1.Columns.Add("Normal", typeof(int));
            table1.Columns.Add("Banamex", typeof(int));

            row = table1.NewRow();
            row["Concepto"] = "Inventario Inicial";
            row["Normal"] = 10;
            row["Banamex"] = 100;
            table1.Rows.Add(row);
            ds.Tables.Add(table1);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(ds);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;
                wb.Worksheets.Worksheet(1).Name = "ASAE";
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=ASAE_Consultores.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}