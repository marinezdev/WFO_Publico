using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO.Propiedades.Procesos.Operacion;

namespace WFO.Procesos.Supervision
{
    public partial class MapaGeneralDetalle : Utilerias.Comun
    {
        WFO.Negocio.Procesos.Operacion.MapaGeneral TableroControl = new Negocio.Procesos.Operacion.MapaGeneral();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Propiedades.UrlCifrardo urlCifrardo = ConsultaParametros();

                if (urlCifrardo.Result)
                {
                    if (urlCifrardo.IdMesa.Length > 0)
                    {
                        if (urlCifrardo.IdFlujo.Length > 0)
                        {
                            hfIdMesa.Value = urlCifrardo.IdMesa;
                            hfIdFlujo.Value = urlCifrardo.IdFlujo;
                        }   
                    }
                }
                else
                {
                    string script = "";
                    script = "window.location.href='Default.aspx'; ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }

                manejo_sesion = (WFO.IU.ManejadorSesion)Session["Sesion"];
                //hfIdMesa.Value = Request.QueryString["IdMesa"].ToString();
                //hfIdFlujo.Value = Request.QueryString["IdFlujo"].ToString();
                Resumen();
                TramitesDetalle();
            }
        }

        protected void Resumen()
        {
            List<prop.MapaGeneral> WFODashboard = TableroControl.DashboardMesa(int.Parse(hfIdFlujo.Value), int.Parse(hfIdMesa.Value));
            lblTitulo.Text = "Mapa General. Mesas de " + WFODashboard[0].Mesa;
            MesaResumen.DataSource = WFODashboard;
            MesaResumen.DataBind();
            MesaResumen.Visible = true;
            string script2 = "";
            script2 = "$('#tMesaResumen').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
        }

        private void TramitesDetalle()
        {
            List<prop.MapaGeneralMesaDetalleTramite> WFODashboard = TableroControl.getDashboardMesaDetalleTramite(int.Parse(hfIdFlujo.Value), int.Parse(hfIdMesa.Value));
            RepeaterFechas.DataSource = WFODashboard;
            RepeaterFechas.DataBind();
            RepeaterFechas.Visible = true;
            string script2 = "";
            script2 = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                string IdTramite = e.CommandArgument.ToString();
                //Response.Redirect("../SupervisionGeneral/ConsultaTramite.aspx?Procesable=" + IdTramite);
                Response.Redirect(EncripParametros("Procesable=" + IdTramite, "../SupervisionGeneral/ConsultaTramite.aspx").URL, true);
            }
        }

        private Propiedades.UrlCifrardo ConsultaParametros()
        {
            Propiedades.UrlCifrardo urlCifrardo = new Propiedades.UrlCifrardo();
            try
            {
                string parametros = Negocio.Sistema.UrlCifrardo.Decrypt(Request.QueryString["data"].ToString());
                string IdMesa = "";
                string IdFlujo = "";

                String[] spearator = { "," };
                String[] strlist = parametros.Split(spearator, StringSplitOptions.RemoveEmptyEntries);

                foreach (String s in strlist)
                {

                    string BusqeudaIdMesa = stringBetween(s + ".", "IdMesa=", ".");
                    if (BusqeudaIdMesa.Length > 0)
                    {
                        IdMesa = BusqeudaIdMesa;
                    }

                    string BusqeudaIdFlujo = stringBetween(s + ".", "IdFlujo=", ".");
                    if (BusqeudaIdFlujo.Length > 0)
                    {
                        IdFlujo = BusqeudaIdFlujo;
                    }
                }

                if (IdMesa.Length > 0)
                {
                    urlCifrardo.IdMesa = IdMesa.ToString();
                    urlCifrardo.Result = true;
                }
                else
                {
                    urlCifrardo.IdMesa = "";

                }

                if (IdFlujo.Length > 0)
                {
                    urlCifrardo.IdFlujo = IdFlujo.ToString();
                    urlCifrardo.Result = true;
                }
                else
                {
                    urlCifrardo.IdTramite = "";
                }

            }
            catch (Exception)
            {
                urlCifrardo.Result = false;
            }

            return urlCifrardo;
        }

        private Propiedades.UrlCifrardo EncripParametros(string parametros, string Direccion)
        {
            Propiedades.UrlCifrardo urlCifrardo = new Propiedades.UrlCifrardo();

            string Encrypt = Negocio.Sistema.UrlCifrardo.Encrypt(parametros);

            urlCifrardo.URL = Direccion + "?data=" + Encrypt;

            return urlCifrardo;
        }

        public static string stringBetween(string Source, string Start, string End)
        {
            string result = "";
            if (Source.Contains(Start) && Source.Contains(End))
            {
                int StartIndex = Source.IndexOf(Start, 0) + Start.Length;
                int EndIndex = Source.IndexOf(End, StartIndex);
                result = Source.Substring(StartIndex, EndIndex - StartIndex);
                return result;
            }

            return result;
        }

    }
}