<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptTramitesTiemposAtencionDownload.aspx.cs" Inherits="WFO.Procesos.SupervisionGeneral.rptTramitesTiemposAtencionDownload" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="../../CSS/bootstrap.css" rel="stylesheet" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Tiempos de Atención</title>
    </head>
    <body style="background-color:whitesmoke;">

        <form id="form1" runat="server">
            <div class="row" style="background-color:dimgray;">
                <div class="col-md-1 col-sm-1 col-xs-1"></div>
                <div class="col-md-10 col-sm-10 col-xs-10">
                    <h3 style="color:white; ">Conversiones</h3>
                </div>
                <div class="col-md-1 col-sm-1 col-xs-1"></div>
            </div>
            
            <main role="main" class="container">
                <div class="jumbotron" style="background-color:#C6DFD1; margin:0px;">
                    <h2 style="color:darkolivegreen"><strong>Tiempos de Atención</strong></h2>

                    <asp:Panel ID="InformacionFin" runat="server" Visible="false">
                        <p>Descarga Finalizada.</p>
                    </asp:Panel>

                    <asp:Panel ID="Informacion" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <p>Tu reporte está siendo procesado, por favor no cierras la ventana de tu navegador hasta que finalice la descarga.</p>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-3 col-sm-3">
                                <strong>Fecha Inicio: </strong>
                                <asp:Label runat="server" ID="LabelFechaInicio" Text="" Font-Bold="True" ></asp:Label>
                            </div>

                            <div class="col-md-3 col-sm-3">
                                <strong>Fecha Fin:</strong>
                                <asp:Label runat="server" ID="LabelFechaFin" Text="" Font-Bold="True" ></asp:Label>
                            </div>

                            <div class="col-md-3 col-sm-3">
                                <asp:Label runat="server" ID="LabelNum" Text="" Font-Bold="true" ></asp:Label>
                            </div>

                            <div class="col-md-3 col-sm-3">
                                <img src="../../Imagenes/Loading-36.gif" width="100%" />
                            </div>
                        </div> 
                    </asp:Panel>

                    <div style="visibility:collapse">
                        <asp:Button ID="BtnContinuar" runat="server"  AutoPostBack="True" Text="Iniciar Descarga" Class="btn btn-success" OnClick="BtnDescargar_Click"/>
                    </div>
                </div>
            </main>

            <script src="../../JS/jquery/dist/jquery.min.js"></script>
            <script>
                $(document).ready(function () {
                    setTimeout(function () {
                        document.getElementById("<%= BtnContinuar.ClientID %>").click();
                        //alert(1);
                    },1000); // el tiempo a que pasara antes de ejecutar el código
                });
            </script>
        </form>
    </body>
</html>
