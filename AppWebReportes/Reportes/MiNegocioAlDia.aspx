<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiNegocioAlDia.aspx.cs" Inherits="AppWebReportes.Reportes.MiNegocioAlDia" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script src="http://code.highcharts.com/highcharts.js"></script>
    <script src="http://code.highcharttable.org/master/jquery.highchartTable-min.js"></script>

 <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a runat="server" class="nav-link" href="~/Reportes/Dashboard.aspx">Inicio</a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>

    <div class="form" id="Formulario">
        <div class="container">
            <br />
            <div class="row">
                <div class="col-lg-3 col-md-12 col-sm-12">
                    <div class="card card-inverse card-info text-center">
                        <div class="card-block">
                            <div class="form-group">
                                <label for="lstTipoMoneda">Tipo de moneda</label>
                                <asp:DropDownList ID="lstTipoMoneda" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="true">Nuevos soles</asp:ListItem>
                                    <asp:ListItem Value="false">Dolares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="lstMes">Mes de proceso</label>
                                <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server" AutoPostBack="False">
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
                                <asp:Button ID="btnGenerarReporte" runat="server" CssClass="btn btn-success form-control" Text="Generar reporte"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-9 col-md-12 col-sm-12">
                    <div class="card card-outline-secondary text-center">
                        <div class="card-block">
                            <h4 class="card-title">Reporte de Mi negocio al día <span id="monthtitle">para el mes de </span><span id="monthHeader"></span></h4>
                            
                            <div class="row">
                                <div class="col-lg-12 col-md-11 col-xs-12">
                                    <table class="highchart table table-striped table-bordered table-responsive" data-graph-container-before="1" data-graph-type="column" id="tablaReporte" data-graph-datalabels-enabled="1" data-graph-datalabels-formatter="foo.myAwesomeCallback">
                                        <thead>
                                            <tr>
                                                <th>Resultado</th>
                                                <th>Ventas</th>
                                                <th>Caja y bancos</th>
                                                <th>Deben</th>
                                                <th>Debo</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><asp:Label ID="lblResultado" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblVentas" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblCajaBancos" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblDeben" runat="server"></asp:Label></td>
                                                <td><asp:Label ID="lblDebo" runat="server"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>Resultado</th>
                                                <th>Ventas</th>
                                                <th>Caja y bancos</th>
                                                <th>Deben</th>
                                                <th>Debo</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $("#MainContent_chbStore").addClass("custom-control-input");
        $("#MainContent_chbCostumers").addClass("custom-control-input");
        $("#MainContent_chbCosto1").addClass("custom-control-input");
        $("#MainContent_chbVendedor").addClass("custom-control-input");
        $("#MainContent_chbStock").addClass("custom-control-input");
        $("#MainContent_chbAlcance").addClass("custom-control-input");
        $("#MainContent_chbCosto2").addClass("custom-control-input");
    </script>
        <script src="https://cdn.datatables.net/buttons/1.4.2/js/dataTables.buttons.min.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.flash.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
        <script src="../Scripts/DataTables/export/pdfmake.min.js"></script>
        <script src="../Scripts/DataTables/export/vfs_fonts.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.html5.min.js"></script>
        <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.print.min.js"></script>

    
    <script src="../Scripts/Owner/RW-007.js"></script>
</asp:Content>
