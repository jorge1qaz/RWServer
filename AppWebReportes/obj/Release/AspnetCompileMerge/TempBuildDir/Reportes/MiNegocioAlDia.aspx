<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiNegocioAlDia.aspx.cs" Inherits="AppWebReportes.Reportes.MiNegocioAlDia" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a runat="server" class="nav-link" href="~/Reportes/Dashboard.aspx"><i class="material-icons left" id="home" data-toggle="tooltip" data-placement="right" title="Regresar al inicio">home</i></a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br />
    <br />

    <div class="form" id="Formulario">
        <div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-12" id="blockOptions">
                    <div class="card card-inverse card-info text-center">
                        <div class="card-block">
                            <div class="form-group">
                                <label for="lstTipoMoneda">Tipo de moneda</label>
                                <asp:DropDownList ID="lstTipoMoneda" CssClass="form-control" runat="server" OnSelectedIndexChanged="lstTipoMoneda_SelectedIndexChanged">
                                    <asp:ListItem Value="true">Nuevos soles</asp:ListItem>
                                    <asp:ListItem Value="false">Dolares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="lstMes">Mes de proceso</label>
                                <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server" AutoPostBack="False" OnSelectedIndexChanged="lstMes_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Apertura</asp:ListItem>
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnGenerarReporte" runat="server" CssClass="btn btn-primary form-control" Text="Generar reporte" OnClick="btnGenerarReporte_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-9 col-sm-12" id="blockReportContent">
                    <div class="card card-outline-secondary text-center">
                        <div class="card-block">
                            <div class="row">
                                <div class="offset-md-10 col-md-2" id="blockbtnFullScreen">
                                    <button class='material-icons btn btn-sm btn-outline-primary' type="button" id="btnFullScreen">fullscreen</button>
                                </div>
                            </div>
                            <div id="container" style="width: 100%"></div>
                            <div class="row align-items-center">
                                <div class="col"><a href="javascript: void(0)" id="btnShowOptions">Mostrar opciones de gráfico</a></div>
                            </div>
                            <br />
                            <div class="card card-outline-secondary" id="blockImageOptions">
                                <div class="card-block">
                                    <label>Opciones de gráfico</label>
                                    <div id="sliders">
                                        <div class="row align-items-center">
                                            <div class="col-3">
                                                <label>Ángulo alfa</label>
                                            </div>
                                            <div class="col-6 slidecontainer">
                                                <input type="range" min="0" max="45" value="0" class="slider" id="alpha">
                                            </div>
                                            <div class="col-3">
                                                <span id="messageAlpha"></span>
                                            </div>
                                        </div>
                                        <div class="row align-items-center">
                                            <div class="col-3">
                                                <label>Ángulo beta</label>
                                            </div>
                                            <div class="col-6 slidecontainer">
                                                <input type="range" min="-45" max="45" value="6" class="slider" id="beta">
                                            </div>
                                            <div class="col-3">
                                                <span id="messageBeta"></span>
                                            </div>
                                        </div>
                                        <div class="row align-items-center">
                                            <div class="col-3">
                                                <label>Profundidad</label>
                                            </div>
                                            <div class="col-6 slidecontainer">
                                                <input type="range" min="20" max="100" value="52" class="slider" id="depth">
                                            </div>
                                            <div class="col-3">
                                                <span id="messageDepth"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script> 
        var simboloMoneda = "<% Response.Write(Session["simboloMoneda"]);%>"; var tipoMoneda = "<% Response.Write(Session["tipoMoneda"]);%>";
        var valor1 = <% Response.Write(Session["Resultado"]);%> ; 
        var valor2 = <% Response.Write(Session["Ventas"]);%> ; 
        var valor3 = <% Response.Write(Session["CajaBancos"]);%> ; 
        var valor4 = <% Response.Write(Session["Deben"]);%> ; 
        var valor5 = <% Response.Write(Session["debo"]);%> ; 
        var ruta = "../..";
    </script>
    <script src="../Scripts/Owner/RW-007.js"></script>
    <script src="../Scripts/Owner/general.js"></script>
</asp:Content>
