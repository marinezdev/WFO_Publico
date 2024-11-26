using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO.Propiedades.Procesos.Operacion;
using prosu = WFO.Propiedades.Procesos.SupervisionGeneral;
using ClosedXML.Excel;
using System.IO;

namespace WFO.Procesos.SupervisionGeneral
{
    public partial class rptTramtesKWIK : Utilerias.Comun
    {
        WFO.Negocio.Procesos.Operacion.UsuariosFlujo usuariosFlujo = new Negocio.Procesos.Operacion.UsuariosFlujo();

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            if (!IsPostBack)
            {
                CalDesde.EditFormatString = "dd/MM/yyyy";
                CalDesde.Date = DateTime.Now.AddDays(-1);
                CalDesde.MaxDate = DateTime.Today;
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
            DateTime fechaI = DateTime.Parse(CalDesde.Date.ToString("yyyy/MM/dd 00:00:00"));
            DateTime fechaF = DateTime.Parse(CalHasta.Date.ToString("yyyy/MM/dd 23:59:59"));
            String script;
            Mensaje.Text = "";
            if (fechaI < fechaF)
            {
                int IdFlujo = Convert.ToInt32(cbFlujos.SelectedItem.Value.ToString());

                WFO.Negocio.Procesos.Supervision.ReportesSupervision reporte = new WFO.Negocio.Procesos.Supervision.ReportesSupervision();
                List<prosu.rptTramitesKWIK> tramites = reporte.rpt_TramitesKWIK(IdFlujo, fechaI, fechaF);
                int num = tramites.Count;
                rptTramites.DataSource = tramites;
                rptTramites.DataBind();

                // Formato de tabla
                script = "";
                script = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                Mensaje.Text = "La fecha 'Desde' debe ser menor a la fecha 'Hasta'";
            }
        }

    }
}