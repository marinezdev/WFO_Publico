<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="rptTramitesTiemposAtencion.aspx.cs" Inherits="WFO.Procesos.SupervisionGeneral.rptTramitesTiemposAtencion" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    
    <script src="../../JS/jquery/dist/jquery.min.js"></script>


    <script type="text/javascript">

        function Carga() {
            $('#DatosConsultaBitacora').html("");
            $('#DatosConsultaBitacora').html("<h3> Cargando ... </h3><p>Al finalizar cierra esta ventana, para realizar otra operación. </p>");
        }

        function CloseModal() {
            $('#CloseModal').click();
        }

        function TiemposAtencion()
        {
            $.ajax({
                type: "POST",
                url: "rptTramitesTiemposAtencion.aspx/BusquedaBitacoraDescraga",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: resultadoDownload,
                error: errores
            });
        }

        function errores(data) {
            alert('Error: ' + msg.responseText);
        }

        function resultadoDownload(data) {
            console.log(data);
            $("#BitacoraDescarga").modal("show");
            $('#DatosConsultaBitacora').html("");

            var tabla = "<table id='InfomacionBitacora' class='table  table-responsive table-striped table-bordered table-hover jambo_table' style='width:100%'>" +
                "<thead>" +
                "<tr>" +
                "<td>Fecha descarga</td>" +
                "<td>Rango inicial</td>" +
                "<td>Rango final</td>" +
                "<td>Número de registros incluidos en el reporte</td>" +
                "<td>Usuario Solicitante </td>" +
                "<td>Total de descargas acumuladas</td>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            for (var b = 0; b < data.d.bitacoraSabanas.length; b++) {
                tabla += "<tr>" +
                    "<td>" + data.d.bitacoraSabanas[b].FechaRegistro + "</td>" +
                    "<td>" + data.d.bitacoraSabanas[b].FechaInicio + "</td>" +
                    "<td>" + data.d.bitacoraSabanas[b].FechaFin + "</td>" +
                    "<td>" + data.d.bitacoraSabanas[b].NumRegistros + "</td>" +
                    "<td>" + data.d.bitacoraSabanas[b].Usuario + "</td>" +
                    "<td>" + data.d.bitacoraSabanas[b].NumSolicitudes + "</td>" +
                    "</tr>";
            }
            tabla += "</tbody>" +
                "</table>";

            $('#DatosConsultaBitacora').html(tabla);
        }
    </script>

    <div class="modal fade " id="BitacoraDescarga" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Bitácora de descargas</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body text-justify">
                    <p>La descargar puede demorar un par de minutos, esto puede variar a partir del número de registros solicitados y la velocidad de navegación de su internet.</p>
                    <p><strong>Importante:</strong>Se debe permitir las pantallas PopUp para poder realizar la descarga.</p>
                    <p>Descargas anteriores:</p>
                    <div  id="DatosConsultaBitacora" class="text-center">
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="DescargaExcel"  class="btn btn-primary" text="Descargar Excel" OnClientClick="Carga();" onclick="btnExportar_Click"/>
                    <br /><br />
                    <button type="button" id="CloseModal" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
  
    

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Conversiones. Tiempos de Atención en Trámites.</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <p class="text-muted font-13 m-b-30">
                        Listado de trámites indicando la cantidad de proceso y tiempos de atención...
                    </p>
                    <div class="row">
                        <asp:Label runat="server" ID="label1"  Font-Bold="True" Text="* Desde" class="control-label col-md-1 col-sm-1 col-xs-6"></asp:Label>
                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <dx:ASPxDateEdit ID="CalDesde" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="" >
                                <TimeSectionProperties>
                                    <TimeEditProperties EditFormatString="dd/MM/yyyy"/>
                                </TimeSectionProperties>
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                            </dx:ASPxDateEdit>
                            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="CalDesde" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
                        </div>

                        <asp:Label runat="server" ID="labelFechaSolicitud"  Font-Bold="True" Text="* Hasta" class="control-label col-md-1 col-sm-1 col-xs-6"></asp:Label>
                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <dx:ASPxDateEdit ID="CalHasta" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="">
                                <TimeSectionProperties>
                                    <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                </TimeSectionProperties>
                                <CalendarProperties>
                                    <FastNavProperties DisplayMode="Inline" />
                                </CalendarProperties>
                            </dx:ASPxDateEdit>
                            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="CalHasta" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
                        </div>

                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <button type="button" id="reporteToExcel" onclick="TiemposAtencion(); ">
                                <img src="../../Imagenes/excel.png">
                            </button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2 col-sm-2 col-xs-12 text-center">
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:Label runat="server" ForeColor="Red" ID="Mensaje" Text =""></asp:Label>
                        </div>
                        <div class="col-md-6 col-sm-6">
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Repeater ID="rptTramites" runat="server">
                            <HeaderTemplate>
                                <table id="example" class="table table-striped table-bordered table-hover jambo_table" style='width:100%'>
                                    <thead>
                                        <th>IdTramite</th>
                                        <th>Folio</th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("IdTramite")%></td>
                                    <td><%#Eval("Folio")%></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                            </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div> 
            
            </ContentTemplate>

    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({ 'language': { 'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json' }, scrollY: '400px', scrollX: true, scrollCollapse: true, fixedColumns: true, dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm' }, { extend: 'csv', className: 'btn-sm' }, { extend: 'excel', className: 'btn-sm' }, { extend: 'pdfHtml5', className: 'btn-sm' }, { extend: 'print', className: 'btn-sm' }] });
            /*$('select').removeClass('custom-select custom-select-sm form-control form-control-sm');*/
        });
    </script>
</asp:Content>