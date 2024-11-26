<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="rptOperacionResumen.aspx.cs" Inherits="WFO.Procesos.SupervisionGeneral.rptOperacionResumen" %>
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
                                <h2>Trámites en Operación - Resumen.</h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <p class="text-muted font-13 m-b-30">
                                    Resumen de trámites en operación (Se toma un día y en base a la operación de ese día se realiza el resumen). 
                                    Se utiliza el horario de operaciones (8am a 5pm).
                                </p>
                                <div class="row">
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
                                    <div class="col-md-2 col-sm-2 col-xs-12 text-center">
                                        <asp:Button ID="Button1" runat="server"  AutoPostBack="True" Text="Consultar" Class="btn btn-success" OnClick="btnFiltroMes_Click"/>
                                    </div>
                                    <div class="col-md-2 col-sm-2 col-xs-12 text-center">
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <asp:Label runat="server" ForeColor="Red" ID="Mensaje" Text =""></asp:Label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <h3>Operación de Trámites</h3>
                                        <p>Trámites procesados en Mesa de Operación</p>
                                        <table id="example" class="table table-striped table-bordered table-hover" style='width:100%'>
                                            <thead>
                                                <tr>
                                                    <th style="background-color:#00B0F0; color:white; text-align:center;"><strong>Concepto</strong></th>
                                                    <th style="background-color:#00B0F0; color:white; text-align:center;"><strong>Normales</strong></th>
                                                    <th style="background-color:#00B0F0; color:white; text-align:center;"><strong>Banamex</strong></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="background-color:#FFFF00; color:black;">Inventario Inicial (Ingresados)</small></td>
                                                    <td style="background-color:#FFFF00; color:black; text-align:center;"><asp:Label ID="lblTramitesIngresados1" runat="server" Text="0" ToolTip="Trámites ingresados después de las 5pm (día anterior al reporte solicitado)"></asp:Label></td>
                                                    <td style="background-color:#FFFF00; color:black; text-align:center;"><asp:Label ID="lblTramitesIngresados1Banamex" runat="server" Text="0" ToolTip="Trámites ingresados después de las 5pm (día anterior al reporte solicitado)"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color:#FFFF00; color:black;">Inventario Inicial (Reingresados)</td>
                                                    <td style="background-color:#FFFF00; color:black; text-align:center;"><asp:Label ID="lblTramitesReingresados1" runat="server" Text="0" ToolTip="Trámites reingresados después de las 5pm (día anterior al reporte solicitado)"></asp:Label></td>
                                                    <td style="background-color:#FFFF00; color:black; text-align:center;"><asp:Label ID="lblTramitesReingresados1Banamex" runat="server" Text="0" ToolTip="Trámites reingresados después de las 5pm (día anterior al reporte solicitado)"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color:#EDEDED; color:black;">Trámites Ingresados</td>
                                                    <td style="background-color:#EDEDED; color:black; text-align:center;"><asp:Label ID="lblTramitesIngresados2" runat="server" Text="0" ToolTip="Trámites ingresados en el periodo de operación diaria (8am a 5pm)"></asp:Label></td>
                                                    <td style="background-color:#EDEDED; color:black; text-align:center;"><asp:Label ID="lblTramitesIngresados2Banamex" runat="server" Text="0" ToolTip="Trámites ingresados en el periodo de operación diaria (8am a 5pm)"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color:#EDEDED; color:black;">Trámites Reingresados</td>
                                                    <td style="background-color:#EDEDED; color:black; text-align:center;"><asp:Label ID="lblTramitesReingresados2" runat="server" Text="0" ToolTip="Trámites reingresados en el periodo de operación diaria (8am a 5pm)"></asp:Label></td>
                                                    <td style="background-color:#EDEDED; color:black; text-align:center;"><asp:Label ID="lblTramitesReingresados2Banamex" runat="server" Text="0" ToolTip="Trámites reingresados en el periodo de operación diaria (8am a 5pm)"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color:#F06F34; color:white;">Trámites Suspendidos</td>
                                                    <td style="background-color:#F06F34; color:white; text-align:center;"><asp:Label ID="lblTramitesSuspendidos" runat="server" Text="0" ToolTip="Trámites ejecutados en el día del reporte solicitado"></asp:Label></td>
                                                    <td style="background-color:#F06F34; color:white; text-align:center;"><asp:Label ID="lblTramitesSuspendidosBanamex" runat="server" Text="0" ToolTip="Trámites ejecutados en el día del reporte solicitado"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color:#FF0000; color:white;">Trámites Rechazados</td>
                                                    <td style="background-color:#FF0000; color:white; text-align:center;"><asp:Label ID="lblTramitesRechazados" runat="server" Text="0" ToolTip="Trámites rechazados en el día del reporte solicitado"></asp:Label></td>
                                                    <td style="background-color:#FF0000; color:white; text-align:center;"><asp:Label ID="lblTramitesRechazadosBanamex" runat="server" Text="0" ToolTip="Trámites rechazados en el día del reporte solicitado"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="background-color:#26B99A; color:white;">Trámites Ejecutados</td>
                                                    <td style="background-color:#26B99A; color:white; text-align:center;"><asp:Label ID="lblTramitesEjecutados" runat="server" Text="0" ToolTip="Trámites ejecutados en el día del reporte solicitado"></asp:Label></td>
                                                    <td style="background-color:#26B99A; color:white; text-align:center;"><asp:Label ID="lblTramitesEjecutadosBanamex" runat="server" Text="0" ToolTip="Trámites ejecutados en el día del reporte solicitado"></asp:Label></td>
                                                </tr>
                                                <tr style="display:none;">
                                                    <td style="background-color:#F06F34; color:white;">Trámites Pausados</td>
                                                    <td style="background-color:#F06F34; color:white; text-align:center;"><asp:Label ID="lblTramitesPausados" runat="server" Text="0" ToolTip="Trámites ejecutados en el día del reporte solicitado"></asp:Label></td>
                                                    <td style="background-color:#F06F34; color:white; text-align:center;"><asp:Label ID="lblTramitesPausadosBanamex" runat="server" Text="0" ToolTip="Trámites ejecutados en el día del reporte solicitado"></asp:Label></td>
                                                </tr>
                                                
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td style="background-color:#00B0F0; color:white;"><strong>Inventario Final</strong></td>
                                                    <td style="background-color:#00B0F0; color:white; text-align:center;"><asp:Label ID="lblTotalTramites" runat="server" Text="0" ToolTip="Total de Trámites" Font-Bold="true" Font-Size="Large"></asp:Label></td>
                                                    <td style="background-color:#00B0F0; color:white; text-align:center;"><asp:Label ID="lblTotalTramitesBanamex" runat="server" Text="0" ToolTip="Total de Trámites Banamex" Font-Bold="true" Font-Size="Larger"></asp:Label></td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="background-color:#00B0F0; color:black; text-align:right; font-size:x-large;"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
                                                    <td style="background-color:#00B0F0; color:black; text-align:right; font-size:x-large;"><strong>TOTAL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></td>
                                                    <td style="background-color:#00B0F0; color:black; text-align:center;"><asp:Label ID="lblTotal" runat="server" Text="0" ToolTip="Total de Trámites" Font-Bold="true" Font-Size="X-Large"></asp:Label></td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <h3>Trámites en proceso</h3>
                                        <p>Trámites que se encuentran en proceso</p>
                                        <table id="TítuloTabla" class="table table-striped table-bordered table-hover" style='width:100%'>
                                            <tr>
                                                <td colspan="5" style="background-color:#00B0F0; color:white;"><strong>Antiguedad en días</strong></td>
                                            </tr>
                                        </table>
                                        <table id="resumenDias" class="table table-striped table-bordered table-hover" style='width:100%'>
                                            <thead>
                                                <tr>
                                                    <th style="background-color:#92D050; text-align:center; font-size:large;"><strong>&nbsp;1 - &nbsp;2</strong></th>
                                                    <th style="background-color:#FFFF00; text-align:center; font-size:large;"><strong>&nbsp;3 - &nbsp;5</strong></th>
                                                    <th style="background-color:#FF0000; text-align:center; color:white; font-size:large;"><strong>&nbsp;6 - 10</strong></th>
                                                    <th style="background-color:#C00000; text-align:center; color:white; font-size:large;"><strong>mayor a 10</strong></th>
                                                    <th style="background-color:#00B0F0; text-align:center; color:white; font-size:large;"><strong>TOTAL</strong></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="background-color:#EDEDED; text-align:center;"><asp:Label ID="lblRango1" runat="server" Text="0" Font-Size="Large" Font-Bold="true" ToolTip="Trámites en el sistema en el rando de días [01 - 02] a partir del último reingreso"></asp:Label></td>
                                                    <td style="background-color:#EDEDED; text-align:center;"><asp:Label ID="lblRango2" runat="server" Text="0" Font-Size="Large" Font-Bold="true" ToolTip="Trámites en el sistema en el rando de días [03 - 05] a partir del último reingreso"></asp:Label></td>
                                                    <td style="background-color:#EDEDED; text-align:center;"><asp:Label ID="lblRango3" runat="server" Text="0" Font-Size="Large" Font-Bold="true" ToolTip="Trámites en el sistema en el rando de días [06 - 10] a partir del último reingreso"></asp:Label></td>
                                                    <td style="background-color:#EDEDED; text-align:center;"><asp:Label ID="lblRango4" runat="server" Text="0" Font-Size="Large" Font-Bold="true" ToolTip="Trámites en el sistema en el rando de días [mayor 10] a partir del último reingreso"></asp:Label></td>
                                                    <td style="background-color:#EDEDED; text-align:center;"><asp:Label ID="lblTotalRango" runat="server" Text="0" Font-Size="Large" Font-Bold="true" ToolTip="Trámites en el sistema que se encuentran en proceso"></asp:Label></td>
                                                </tr>
                                            </tbody>
                                            <tfoot></tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>