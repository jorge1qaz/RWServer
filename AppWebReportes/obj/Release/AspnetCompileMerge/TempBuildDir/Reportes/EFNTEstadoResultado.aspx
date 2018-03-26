<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EFNTEstadoResultado.aspx.cs" Inherits="AppWebReportes.Reportes.EFNTEstadoResultado" %>

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
                            <div class="offset-md-2 col-md-8">
                                <h4 class="card-title">Estados financieros: NIIF</h4>
                            </div>
                            <div class="col-md-2" id="blockbtnFullScreen">
                                <button class='material-icons btn btn-sm btn-outline-primary' type="button" id="btnFullScreen">fullscreen</button>
                            </div>
                        </div>
                        <asp:Label ID="lblTipoReporte" runat="server"></asp:Label><span> - Expresado en </span>
                        <asp:Label ID="lblTipoMoneda" runat="server"></asp:Label><span> - Para el mes de </span>
                        <asp:Label ID="lblMesProceso" runat="server"></asp:Label>
                        <table class="table table-bordered table-hover table-sm table-striped" id="tableReport" width="100%">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th id="tittleActivo">Estado de resultados (por naturaleza)</th>
                                    <th id="tittleMonto1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                    <th>Código</th>
                                    <th id="tittlePasivoPatrimonio">Estado de resultados (por función)</th>
                                    <th id="tittleMonto2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>N005</td>
                                    <td>Venta de mercadería</td>
                                    <td>
                                        <asp:Label ID="lblN005" runat="server"></asp:Label>
                                    </td>
                                    <td>F005</td>
                                    <td>Ingresos de actividades ordinarias</td>
                                    <td>
                                        <asp:Label ID="lblF005" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N010</td>
                                    <td>Compra de mercadería</td>
                                    <td>
                                        <asp:Label ID="lblN010" runat="server"></asp:Label>
                                    </td>
                                    <td>F105</td>
                                    <td>Costo de ventas</td>
                                    <td>
                                        <asp:Label ID="lblF105" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N015</td>
                                    <td>Variación de mercadería</td>
                                    <td>
                                        <asp:Label ID="lblN015" runat="server"></asp:Label>
                                    </td>
                                    <td>F199</td>
                                    <td class="font-weight-bold">Ganancia (pérdida) bruta</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblF199" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="font-weight-bold">
                                    <td>N099</td>
                                    <td>Margen comercial</td>
                                    <td>
                                        <asp:Label ID="lblN099" runat="server"></asp:Label>
                                    </td>
                                    <td>F200</td>
                                    <td>Gastos operacionales</td>
                                    <td>
                                        <asp:Label ID="lblF200" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N103</td>
                                    <td>Venta de productos terminados, sub producto</td>
                                    <td>
                                        <asp:Label ID="lblN103" runat="server"></asp:Label>
                                    </td>
                                    <td>F206</td>
                                    <td>Gastos de ventas y distribución</td>
                                    <td>
                                        <asp:Label ID="lblF206" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N105</td>
                                    <td>Variación de la producción almacenado</td>
                                    <td>
                                        <asp:Label ID="lblN105" runat="server"></asp:Label>
                                    </td>
                                    <td>F211</td>
                                    <td>Gastos de administración</td>
                                    <td>
                                        <asp:Label ID="lblF211" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N110</td>
                                    <td>Producción activo inmovilizado</td>
                                    <td>
                                        <asp:Label ID="lblN110" runat="server"></asp:Label>
                                    </td>
                                    <td>F212</td>
                                    <td>Ganancia(pérdida) baja activos financieros</td>
                                    <td>
                                        <asp:Label ID="lblF212" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">N199</td>
                                    <td class="font-weight-bold">Producción del ejercicio</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblN199" runat="server"></asp:Label>
                                    </td>
                                    <td>F213</td>
                                    <td>Otros ingresos operativos</td>
                                    <td>
                                        <asp:Label ID="lblF213" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N205</td>
                                    <td>Compra de materias primas </td>
                                    <td>
                                        <asp:Label ID="lblN205" runat="server"></asp:Label>
                                    </td>
                                    <td>F214</td>
                                    <td>Otros gastos operativos</td>
                                    <td>
                                        <asp:Label ID="lblF214" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N210</td>
                                    <td>Variación materias primas </td>
                                    <td>
                                        <asp:Label ID="lblN210" runat="server"></asp:Label>
                                    </td>
                                    <td>F215</td>
                                    <td>Otras ganancias (pérdidas) </td>
                                    <td>
                                        <asp:Label ID="lblF215" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N215</td>
                                    <td>Compra de materiales auxiliares</td>
                                    <td>
                                        <asp:Label ID="lblN215" runat="server"></asp:Label>
                                    </td>
                                    <td class="font-weight-bold">F299</td>
                                    <td class="font-weight-bold">Ganancia (pérdida) por actividades de operaciones</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblF299" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N220</td>
                                    <td>Variación de materiales auxiliares </td>
                                    <td>
                                        <asp:Label ID="lblN220" runat="server"></asp:Label>
                                    </td>
                                    <td>F320</td>
                                    <td>Ingresos financieros</td>
                                    <td>
                                        <asp:Label ID="lblF320" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N225</td>
                                    <td>Compra de envases y embalajes</td>
                                    <td>
                                        <asp:Label ID="lblN225" runat="server"></asp:Label>
                                    </td>
                                    <td>F350</td>
                                    <td>Gastos financieros</td>
                                    <td>
                                        <asp:Label ID="lblF350" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N230</td>
                                    <td>Variación de envases y embalajes </td>
                                    <td>
                                        <asp:Label ID="lblN230" runat="server"></asp:Label>
                                    </td>
                                    <td>F380</td>
                                    <td>Diferencias de cambio neto</td>
                                    <td>
                                        <asp:Label ID="lblF380" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N235</td>
                                    <td>Servicios prestados por terceros </td>
                                    <td>
                                        <asp:Label ID="lblN235" runat="server"></asp:Label>
                                    </td>
                                    <td>F403</td>
                                    <td>Otros ingresos (gastos) de las subsidiar</td>
                                    <td>
                                        <asp:Label ID="lblF403" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">N299</td>
                                    <td class="font-weight-bold">Valor agregado </td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblN299" runat="server"></asp:Label>
                                    </td>
                                    <td>F405</td>
                                    <td>Ganancias (pérdidas) que surgen de la diferencia</td>
                                    <td>
                                        <asp:Label ID="lblF405" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N305</td>
                                    <td>Subsidios gubernamentales</td>
                                    <td>
                                        <asp:Label ID="lblN305" runat="server"></asp:Label>
                                    </td>
                                    <td>F415</td>
                                    <td>Diferencia entre el importe en libros</td>
                                    <td>
                                        <asp:Label ID="lblF415" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N310</td>
                                    <td>Cargas de personal </td>
                                    <td>
                                        <asp:Label ID="lblN310" runat="server"></asp:Label>
                                    </td>
                                    <td class="font-weight-bold">F699</td>
                                    <td class="font-weight-bold">Resultado antes de impuesto a las ganancias</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblF699" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N315</td>
                                    <td>Tributos</td>
                                    <td>
                                        <asp:Label ID="lblN315" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold"> class="font-weight-bold">N399</td>
                                    <td class="font-weight-bold">Excedente bruto de explotación </td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblN399" runat="server"></asp:Label>
                                    </td>
                                    <td>F710</td>
                                    <td>Gasto por impuesto a las ganancias</td>
                                    <td>
                                        <asp:Label ID="lblF710" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N405</td>
                                    <td>Descuentos rebajas y bonificación obtenidos </td>
                                    <td>
                                        <asp:Label ID="lblN405" runat="server"></asp:Label>
                                    </td>
                                    <td class="font-weight-bold">F799</td>
                                    <td class="font-weight-bold">Ganancia(pérdida) neta operaciones contable</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblF799" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N410</td>
                                    <td>Otros ingresos de gestión</td>
                                    <td>
                                        <asp:Label ID="lblN410" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N415</td>
                                    <td>Ganancia por medición de activos no financieros</td>
                                    <td>
                                        <asp:Label ID="lblN415" runat="server"></asp:Label>
                                    </td>
                                    <td>F805</td>
                                    <td>Ganancia (pérdida) impuesto ganancia de operaciones diversos</td>
                                    <td>
                                        <asp:Label ID="lblF805" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N420</td>
                                    <td>Otros gastos de gestión</td>
                                    <td>
                                        <asp:Label ID="lblN420" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N425</td>
                                    <td>Perdida por medición de activos no financieros</td>
                                    <td>
                                        <asp:Label ID="lblN425" runat="server"></asp:Label>
                                    </td>
                                    <td class="font-weight-bold">F999</td>
                                    <td class="font-weight-bold">Ganancia (pérdida) neta del ejercicio</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblF999" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>N430</td>
                                    <td>Valuación y deterioro de activos y provisiones</td>
                                    <td>
                                        <asp:Label ID="lblN430" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">N499</td>
                                    <td class="font-weight-bold">Resultado de explotación</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblN499" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N505</td>
                                    <td>Ingresos financieros</td>
                                    <td>
                                        <asp:Label ID="lblN505" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N510</td>
                                    <td>Gastos financieros</td>
                                    <td>
                                        <asp:Label ID="lblN510" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N515</td>
                                    <td>Costos financiación capitalizados</td>
                                    <td>
                                        <asp:Label ID="lblN515" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N520</td>
                                    <td>Costo neto enajenación activos inmovilizados</td>
                                    <td>
                                        <asp:Label ID="lblN520" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N525</td>
                                    <td>Donaciones y sanciones administrativas financieras</td>
                                    <td>
                                        <asp:Label ID="lblN525" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">N599</td>
                                    <td class="font-weight-bold">Resultado antes de participaciones e impuestos </td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblN599" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N805</td>
                                    <td>Participación de los Trabajadores </td>
                                    <td>
                                        <asp:Label ID="lblN805" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>N810</td>
                                    <td>Impuesto a la Renta</td>
                                    <td>
                                        <asp:Label ID="lblN810" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td class="font-weight-bold">N999</td>
                                    <td class="font-weight-bold">Resultado del ejercicio</td>
                                    <td class="font-weight-bold">
                                        <asp:Label ID="lblN999" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script> var columnA = 2; var columnB = 5; </script>
    <script> var column2A = 1; var column2B = 4; </script>
    <script>var moneda = "<% Response.Write(Session["TipoMonedaEFNT"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["TipoReporteEFNT"].ToString()); %>"; var ruta = "../..";</script>
    <script src="../Scripts/Owner/RW-009-b.js"></script>
    <script src="../Scripts/Owner/general.js"></script>
</asp:Content>
