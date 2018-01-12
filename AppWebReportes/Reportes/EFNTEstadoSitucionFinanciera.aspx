<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EFNTEstadoSitucionFinanciera.aspx.cs" Inherits="AppWebReportes.Reportes.EstadosFinancieros" %>

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
                        <table class="table table-bordered table-responsive table-hover table-sm table-striped" id="tableReport">
                            <tbody>
                                <tr>
                                    <th class="text-center" colspan="1">Activo</th>
                                    <th class="text-center" colspan="1">Pasivo y patrimonio </th>
                                </tr>
                                <tr>
                                    <th class="text-center" colspan="1">Activo corriente</th>
                                    <th class="text-center" colspan="1">Pasivo corriente</th>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Efectivo y equivalentes de efectivo</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA105" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Otros pasivos financieros </label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP105" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Otros activos financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA110" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Cuentas por pagar comerciales</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP110" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Cuentas por cobrar comerciales (neto)</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA115" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Otras cuentas por pagar</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP120" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Otras cuentas por cobrar (neto)</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA120" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Cuentas por pagar a entidades relacionadas</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP121" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Cuentas por cobrar a entidades relacionadas</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA125" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Ingresos diferidos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP123" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Anticipos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA128" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Provisión por beneficios a los empleados</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP125" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Inventarios</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA130" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Otras provisiones</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP130" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos biológicos </label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA131" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Pasivos por impuestos a las ganancias </label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP135" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos por impuestos a las ganancias </label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA133" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Otros pasivos no financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP137" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Otros activos no financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA140" runat="server"></asp:Label>
                                    </td>
                                    <th class="text-center">
                                        <label>Total pasivo corriente distintos mantenidos para la venta</label>
                                    </th>
                                    <td>
                                        <asp:Label ID="lblP199" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label>Total activos corrientes distintos mantenidos para la venta</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblA199" runat="server"></asp:Label>
                                    </th>
                                    <td>
                                        <label>Pasivo incluido en activo mantenido para la venta</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP210" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos no corrientes mantenidos para la venta</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA210" runat="server"></asp:Label>
                                    </td>
                                    <th class="text-center">
                                        <label>Total pasivos corrientes</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP399" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos no corrientes para distribuir a propiedades</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA220" runat="server"></asp:Label>
                                    </td>
                                    <th class="text-center">
                                        <label>Pasivos no corrientes</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP400" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label>Activo no corriente mantenidos para la venta y operaciones discontinuadas</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblA299" runat="server"></asp:Label>
                                    </th>
                                    <td>
                                        <label>Otros pasivos financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP410" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label>Total activo corriente</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblA399" runat="server"></asp:Label>
                                    </th>
                                    <td>
                                        <label>Cuentas por pagar comerciales</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP415" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label>Activos no corrientes</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblA500" runat="server"></asp:Label>
                                    </th>
                                    <td>
                                        <label>Otras cuentas por pagar</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP420" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Otros activos financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA510" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Cuentas por pagar a entidades relacionadas</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP425" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Inversiones en subsidiarias, negocios con activos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA513" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Ingresos diferidos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP430" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Cuentas por cobrar comerciales </label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA515" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Provisión por beneficios a los empleados</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP435" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Otras cuentas por cobrar</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA517" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Otras provisiones</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP440" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Cuentas por cobrar a entidades relacionadas</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA520" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Pasivos por impuestos diferidos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP445" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Anticipos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA525" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Otros pasivos no financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP450" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos biológicos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA530" runat="server"></asp:Label>
                                    </td>
                                    <th class="text-center">
                                        <label>Total pasivos no corrientes</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP499" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Propiedades de inversión</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA540" runat="server"></asp:Label>
                                    </td>
                                    <th class="text-center">
                                        <label>Total pasivo</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP699" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Propiedades plantas y equipos (neto)</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA550" runat="server"></asp:Label>
                                    </td>
                                    <th class="text-center">
                                        <label>Patrimonio</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP800" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos intangibles distintos de la plusvalía</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA560" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Capital emitido</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP805" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Activos por impuestos diferidos</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA570" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Primas de emisión</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP810" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Plusvalía</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA575" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Acciones de inversión</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP815" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Otros activos no financieros</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblA580" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>Acciones propias en cartera</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP820" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label>Total activo no corriente</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblA599" runat="server"></asp:Label>
                                    </th>
                                    <td>
                                        <label>Otras reservas de capital</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP830" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label></label>
                                    </td>
                                    <td>
                                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                                    </td>
                                    <td>
                                        <label>Resultados acumulados</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP835" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label></label>
                                    </td>
                                    <td>
                                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                                    </td>
                                    <td>
                                        <label>Otras reservas de patrimonio</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblP840" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label>Total activo</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblA999" runat="server"></asp:Label>
                                    </th>
                                    <th class="text-center">
                                        <label>Total patrimonio</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP899" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label></label>
                                    </th>
                                    <th class="text-center">
                                        <span></span>
                                    </th>
                                    <th class="text-center">
                                        <label>Total pasivo y patrimonio neto</label>
                                    </th>
                                    <th class="text-center">
                                        <asp:Label ID="lblP999" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <th class="text-center">
                                        <label></label>
                                    </th>
                                    <th class="text-center">
                                        <span></span>
                                    </th>
                                    <th class="text-center">
                                        <label></label>
                                    </th>
                                    <th class="text-center">
                                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
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
