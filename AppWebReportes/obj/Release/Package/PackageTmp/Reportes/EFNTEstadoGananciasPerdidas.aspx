﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EFNTEstadoGananciasPerdidas.aspx.cs" Inherits="AppWebReportes.Reportes.EFNTEstadoGananciasPerdidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                            <label for="lstMes">Mes de proceso</label>
                            <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstMes_SelectedIndexChanged">
                                <asp:ListItem Value="0">Enero</asp:ListItem>
                                <asp:ListItem Value="1">Febrero</asp:ListItem>
                                <asp:ListItem Value="2">Marzo</asp:ListItem>
                                <asp:ListItem Value="3">Abril</asp:ListItem>
                                <asp:ListItem Value="4">Mayo</asp:ListItem>
                                <asp:ListItem Value="5">Junio</asp:ListItem>
                                <asp:ListItem Value="6">Julio</asp:ListItem>
                                <asp:ListItem Value="7">Agosto</asp:ListItem>
                                <asp:ListItem Value="8">Septiembre</asp:ListItem>
                                <asp:ListItem Value="9">Octubre</asp:ListItem>
                                <asp:ListItem Value="10">Noviembre</asp:ListItem>
                                <asp:ListItem Value="11">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9 col-sm-12" id="blockReportContent">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <div class="row">
                            <div class="offset-md-2 col-md-8">
                                <h4 class="card-title">Estados financieros NIIF y tributario</h4>
                            </div>
                            <div class="col-md-2" id="blockbtnFullScreen">
                                <button class='material-icons btn btn-sm btn-outline-primary' type="button" id="btnFullScreen">fullscreen</button>
                            </div>
                        </div>
                        <asp:Label ID="lblTipoReporte" runat="server"></asp:Label><span> - Expresado en </span>
                        <asp:Label ID="lblTipoMoneda" runat="server"></asp:Label><span> - Para el mes de </span>
                        <asp:Label ID="lblMesProceso" runat="server"></asp:Label>
                        <div class="row justify-content-md-center">
                            <table class="table table-bordered table-responsive table-hover table-sm table-striped text-center" id="tableReport" width="100%">
                                <thead>
                                    <tr>
                                        <th>Código</th>
                                        <th>Descripción</th>
                                        <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Código</th>
                                        <th>Descripción</th>
                                        <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                    </tr>
                                </tfoot>
                                <tbody>
                                    <tr>
                                        <td>F005</td>
                                        <td>Ventas netas o ingresos por servicios</td>
                                        <td>
                                            <asp:Label ID="lblF005" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F010</td>
                                        <td>( - ) descuentos rebajas y bonificaciones concedidas</td>
                                        <td>
                                            <asp:Label ID="lblF010" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>F099</th>
                                        <th>Ventas netas </th>
                                        <th>
                                            <asp:Label ID="lblF099" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>F115</td>
                                        <td>( - ) costo de ventas </td>
                                        <td>
                                            <asp:Label ID="lblF115" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>F199</th>
                                        <th>Resultado bruto </th>
                                        <th>
                                            <asp:Label ID="lblF199" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>F205</td>
                                        <td>( - ) gastos de ventas</td>
                                        <td>
                                            <asp:Label ID="lblF205" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F210</td>
                                        <td>( - ) gastos de administración</td>
                                        <td>
                                            <asp:Label ID="lblF210" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>F299</th>
                                        <th>Resultado de operación</th>
                                        <th>
                                            <asp:Label ID="lblF299" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>F502</td>
                                        <td>Gastos financieros </td>
                                        <td>
                                            <asp:Label ID="lblF502" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F505</td>
                                        <td>Ingresos financieros gravados </td>
                                        <td>
                                            <asp:Label ID="lblF505" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F510</td>
                                        <td>Otros ingresos gravados  </td>
                                        <td>
                                            <asp:Label ID="lblF510" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F515</td>
                                        <td>Otros ingresos no gravados  </td>
                                        <td>
                                            <asp:Label ID="lblF515" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F520</td>
                                        <td>Enajenación de valores y bienes del activo fijo </td>
                                        <td>
                                            <asp:Label ID="lblF520" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F525</td>
                                        <td>Costo enajenación de valores y bienes - activo fijo</td>
                                        <td>
                                            <asp:Label ID="lblF525" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F530</td>
                                        <td>Gastos diversos </td>
                                        <td>
                                            <asp:Label ID="lblF530" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>F560</td>
                                        <td>Resultado por exposición a la inflación del ejercicio </td>
                                        <td>
                                            <asp:Label ID="lblF560" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>F599</th>
                                        <th>Resultados antes de participaciones</th>
                                        <th>
                                            <asp:Label ID="lblF599" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>F605</td>
                                        <td>( - ) distribución legal de la renta </td>
                                        <td>
                                            <asp:Label ID="lblF605" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>F699</th>
                                        <th>Resultado antes del impuesto</th>
                                        <th>
                                            <asp:Label ID="lblF699" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>F705</td>
                                        <td>( - ) impuesto a la renta</td>
                                        <td>
                                            <asp:Label ID="lblF705" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>F999</th>
                                        <th>Resultado del ejercicio </th>
                                        <th>
                                            <asp:Label ID="lblF999" runat="server"></asp:Label>
                                        </th>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="../Scripts/DataTables/export/pdfmake.min.js"></script>
    <script src="../Scripts/DataTables/export/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.print.min.js"></script>
    <script>var moneda = "<% Response.Write(Session["TipoMonedaEFNT"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["TipoReporteEFNT"].ToString()); %>";</script>
    <script src="../Scripts/Owner/RW-009.js"></script>
</asp:Content>