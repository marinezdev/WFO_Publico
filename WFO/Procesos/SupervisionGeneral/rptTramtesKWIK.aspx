<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="rptTramtesKWIK.aspx.cs" Inherits="WFO.Procesos.SupervisionGeneral.rptTramtesKWIK" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
  

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Trámites procesados en KWIK.</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <p class="text-muted font-13 m-b-30">
                        Listado de trámites que se han procesado en KWIK (remoteScan)
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
                        <asp:Label runat="server" ID="label2"  Font-Bold="True" Text="* Flujo" class="control-label col-md-1 col-sm-1 col-xs-6"></asp:Label>
                        <div class="col-md-3 col-sm-3 col-xs-12 form-group has-feedback">
                            <dx:ASPxComboBox ID="cbFlujos" runat="server" Theme="Material" EditFormat="Custom" Width="100%">
                            </dx:ASPxComboBox>
                            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="cbFlujos" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
                        </div>
                        
                    </div>
                    <div class="row">
                        <div class="col-md-1 col-sm-1 col-xs-12 text-center">
                            <asp:Button ID="Button1" runat="server"  AutoPostBack="True" Text="Consultar" Class="btn btn-success" OnClick="btnFiltroMes_Click"/>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <asp:Label runat="server" ForeColor="Red" ID="Mensaje" Text =""></asp:Label>
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClick="lnkExportar_Click"><img src="../../Imagenes/ExcelIcon.png" style="vertical-align:top"/>--%>
                            <%--</asp:LinkButton>--%>
                            <%--<a class="btn btn-app" onclick="BitacoraSabana();">--%>
                              <%--<i class="fa fa-file-excel-o"></i> Descarga Excel--%> 
                            <%--</a>--%>
                        </div>
                        
                    </div>
                    <hr />
                    <div class="row">
                        <asp:Repeater ID="rptTramites" runat="server">
                            <HeaderTemplate>
                                <table id="example" class="table table-striped table-bordered table-hover jambo_table" style='width:100%'>
                                    <thead>
                                        <th>IdTramite</th>
                                        <th>StatusTramite</th>
                                        <th>Folio</th>
                                        <th>RegistroTrámite</th>
                                        <th>Mesa</th>
                                        <th>StatusMesa</th>
                                        <th>FechaProceso</th>
                                        <th>Poliza</th>
                                        <th>DCNKWIK</th>
                                        <th>ObsPublica</th>
                                        <th>ObsPrivada</th>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("IdTramite")%></td>
                                    <td><%#Eval("StatusTramite")%></td>
                                    <td><%#Eval("Folio")%></td>
                                    <td><%#Eval("RegistroTrámite")%></td>
                                    <td><%#Eval("Mesa")%></td>
                                    <td><%#Eval("StatusMesa")%></td>
                                    <td><%#Eval("FechaProceso")%></td>
                                    <td><%#Eval("Poliza")%></td>
                                    <td><%#Eval("DCNKWIK")%></td>
                                    <td><%#Eval("ObsPublica")%></td>
                                    <td><%#Eval("ObsPrivada")%></td>
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