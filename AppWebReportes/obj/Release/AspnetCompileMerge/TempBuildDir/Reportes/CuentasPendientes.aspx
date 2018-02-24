<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuentasPendientes.aspx.cs" Inherits="AppWebReportes.CP_Reportes.RW_004" %>

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
    <div class="container">
        <div class="row">
            <div class="col-md-3 col-sm-12" id="blockOptions">
                <div class="card card-inverse card-info text-center">
                    <div class="card-block">
                        <div class="form-group">
                            <label for="lstTipoMoneda">Tipo de moneda</label>
                            <asp:DropDownList ID="lstTipoMoneda" CssClass="form-control" runat="server" OnSelectedIndexChanged="lstTipoMoneda_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="true">Nuevos soles</asp:ListItem>
                                <asp:ListItem Value="false">Dólares</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Número de cuenta</label>
                            <input class="form-control" id="txtCuenta" type="text" placeholder="Escriba la cuenta" name="txtCuentaName" /><small class="form-text text-muted" id="Help">También puedes revisar las cuentas que tengan registros en tu base de datos.</small>
                        </div>
                        <div class="form-group">
                            <button class="btn btn-primary form-control" type="button" id="triggerModal">
                                <i class="material-icons left icon-button">search</i>Buscar cuenta
                            </button>
                        </div>
                        <div class="form-group">
                            <label for="lstMes">Mes de proceso</label>
                            <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server" AutoPostBack="false" OnSelectedIndexChanged="lstMes_SelectedIndexChanged">
                                <asp:ListItem Value="0">Apertura</asp:ListItem>
                                <asp:ListItem Value="1">Enero</asp:ListItem>
                                <asp:ListItem Value="2">Febrero</asp:ListItem>
                                <asp:ListItem Value="3">Marzo</asp:ListItem>
                                <asp:ListItem Value="4">Abril</asp:ListItem>
                                <asp:ListItem Value="5">Mayo</asp:ListItem>
                                <asp:ListItem Value="6">Junio</asp:ListItem>
                                <asp:ListItem Value="7">Julio</asp:ListItem>
                                <asp:ListItem Value="8">Agosto</asp:ListItem>
                                <asp:ListItem Value="9">Setiembre</asp:ListItem>
                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <button class="btn btn-primary form-control" id="btnPruebas" type="button">
                                <i class="material-icons left icon-button">play_arrow</i>Generar reporte
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9 col-sm-12" id="blockReportContent">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <div class="row">
                            <div class="offset-md-2 col-md-8">
                                <h4 class="card-title">Reporte de Cuentas pendientes</h4>
                            </div>
                            <div class="col-md-2" id="blockbtnFullScreen">
                                <button class='material-icons btn btn-sm btn-outline-primary' type="button" id="btnFullScreen">fullscreen</button>
                            </div>
                        </div>
                        <span>Expresado en </span>
                        <asp:Label ID="lblTipoMoneda" runat="server"></asp:Label>
                        <span> - Para el mes de </span>
                        <asp:Label ID="lblMesProceso" runat="server"></asp:Label>
                        <span> del </span><asp:Label ID="lblAnio" runat="server"></asp:Label>
                        <table class="table table-bordered table-responsive table-hover table-sm table-striped" id="tablaReporte" width="100%">
                            <thead>
                                <tr>
                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RUC&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                    <th id="thDebe">Debe</th>
                                    <th id="thHaber">Haber</th>
                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Saldo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Razón social&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-lg" id="modalBuscarCuenta" tabindex="-1" role="dialog" aria-labelledby="modalBuscarCuentaLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalBuscarCuentaLabel">Cuentas contables</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <table class="table table-striped table-bordered" id="tablaCuentas">
                        <thead>
                            <tr>
                                <th>Cuenta</th>
                                <th>Detalle</th>
                                <th></th>
                            </tr>
                        </thead>
                    </table>
                    <br />
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-lg" id="modalLeyenda" tabindex="-1" role="dialog" aria-labelledby="modalLeyendaLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLeyendaLabel">Cuentas contables</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <table class="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Cuenta</th>
                                <th>Detalle</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>12</td>
                                <td>Clientes</td>
                            </tr>
                            <tr>
                                <td>42</td>
                                <td>Proveedores</td>
                            </tr>
                            <tr>
                                <td>45</td>
                                <td>Bancos</td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>Cuenta</th>
                                <th>Detalle</th>
                            </tr>
                        </tfoot>
                    </table>
                    <br />
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        var idAnio      = "<% Response.Write(Request.QueryString["year"]);%>";
        var idCliente   = "<% Response.Write(Session["IdUser"].ToString());%>";
        var idEmpresa   = "<% Response.Write(Request.QueryString["idCompany"].ToString());%>";
    </script>
    <script>
        var tipoMonedaRCP = "<% Response.Write(Session["tipoMonedaRCP"]);%>";
    </script>
    <script>
        var simboloMonedaRCP = "<% Response.Write(Session["simboloMonedaRCP"]);%>";
    </script>

    <script src="../Scripts/Owner/RW-004-b.js"></script>
</asp:Content>
