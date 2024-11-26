using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO.Propiedades.Procesos.Operacion;

namespace WFO.Procesos.Operador
{
    public partial class Default : Utilerias.Comun
    {
        WFO.Negocio.Procesos.Operacion.Mesas mesas = new Negocio.Procesos.Operacion.Mesas();
        WFO.Negocio.Procesos.Operacion.UsuariosFlujo usuariosFlujo = new Negocio.Procesos.Operacion.UsuariosFlujo();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["TramitesAutomaticos"] = true;

                    if (!String.IsNullOrEmpty(Request.QueryString["msj"]))
                    {
                        if (Request.QueryString["msj"].ToString() == "1")
                        {
                            mensajes.MostrarMensaje(this, "No hay trámites disponibles...");
                        }
                    }

                    manejo_sesion = (WFO.IU.ManejadorSesion)Session["Sesion"];
                    CargaFlujos(manejo_sesion.Usuarios.IdUsuario);
                    //PintaMesas(manejo_sesion.Usuarios.IdUsuario);
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex.Message + " // " + ex.Source );
            }
        }

        protected void CargaFlujos(int Id)
        {
            List<prop.UsuariosFlujo> Flujos = usuariosFlujo.SelecionarFlujo(Id);
            cbFlujos.DataSource = Flujos;
            cbFlujos.DataBind();
            cbFlujos.DataTextField = "Nombre";
            cbFlujos.DataValueField = "Id";
            cbFlujos.DataBind();
        }

        protected void CargaFlujos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdFlujo = Convert.ToInt32(cbFlujos.SelectedValue.ToString());
            manejo_sesion = (WFO.IU.ManejadorSesion)Session["Sesion"];
            PintaMesas(manejo_sesion.Usuarios.IdUsuario, IdFlujo);
        }

        protected void PintaMesas(int Id, int IdFlujo)
        {
            
            List<prop.Mesa> MesasUsurio = mesas.SelecionarMesas(Id, IdFlujo);

            string MesaUsuario = "";
            for (int i=0; i<MesasUsurio.Count;i++)
            {
                MesaUsuario += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                            "<div class='x_panel text-center'>" +
                                //"<a href='TramiteProcesar.aspx?IdMesa=" + MesasUsurio[i].Id + "'>" +
                                "<a onclick='TramiteProcesar(" + MesasUsurio[i].Id + ")' >" +
                                    "<img src='" + MesasUsurio[i].icono + "'/>" +
                                    //"<i class='fa " + MesasUsurio[i].icono + " fa-5x'></i>" +
                                    "<div class='form-group text-center'>" +
                                        "<hr />" +
                                        "<h2><small>"+ MesasUsurio[i].nombre +"</small></h2>" +
                                    "</div>" +
                                "</a>" +
                            "</div>" +
                         "</div>";
            }

            MesasLiteral.Text = MesaUsuario;
        }

        [WebMethod]
        public static Propiedades.UrlCifrardo BusquedaId(int Id)
        {
            Propiedades.UrlCifrardo urlCifrardo = new Propiedades.UrlCifrardo();
            string parametros = "IdMesa=" + Id + ",";

            urlCifrardo.URL = Negocio.Sistema.UrlCifrardo.Encrypt(parametros.ToString());

            if (urlCifrardo.URL.Length > 0)
            {
                urlCifrardo.Result = true;
            }

            return urlCifrardo;
        }

    }
}