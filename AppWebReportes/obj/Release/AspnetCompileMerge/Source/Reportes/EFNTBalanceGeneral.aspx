<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EFNTBalanceGeneral.aspx.cs" Inherits="AppWebReportes.Reportes.EFNTBalanceGeneral" %>

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
                            <asp:Button ID="btnGenerarReporteS" runat="server" CssClass="btn btn-primary form-control" Text="Generar reporte" OnClick="btnGenerarReporte_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9 col-sm-12" id="blockReportContent">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <div class="row">
                            <div class="offset-md-2 col-md-8">
                                <h4 class="card-title">Estados financieros: Tributario</h4>
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
                                    <th id="tittleActivo">Activo</th>
                                    <th id="tittleMonto1">Monto</th>
                                    <th>Código</th>
                                    <th id="tittlePasivoPatrimonio">Pasivo y patrimonio</th>
                                    <th id="tittleMonto2">Monto</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>A105</td>
                                    <td>Caja y bancos</td>
                                    <td>
                                        <asp:Label ID="lblA105" runat="server"></asp:Label>
                                    </td>
                                    <th></th>
                                    <th>Pasivo</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>A106</td>
                                    <td>Inversiones a valor razonable y disponible venta</td>
                                    <td>
                                        <asp:Label ID="lblA106" runat="server"></asp:Label>
                                    </td>
                                    <td>P105</td>
                                    <td>Sobregiros bancarios</td>
                                    <td>
                                        <asp:Label ID="lblP105" runat="server">   </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A110</td>
                                    <td>Cuentas cobrar comerciales - terceros</td>
                                    <td>
                                        <asp:Label ID="lblA110" runat="server"></asp:Label>
                                    </td>
                                    <td>P110</td>
                                    <td>Tributos por pagar </td>
                                    <td>
                                        <asp:Label ID="lblP110" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A111</td>
                                    <td>Cuentas cobrar comerciales - relacionado</td>
                                    <td>
                                        <asp:Label ID="lblA111" runat="server"></asp:Label>
                                    </td>
                                    <td>P115</td>
                                    <td>Remuneraciones y participaciones, por pagar</td>
                                    <td>
                                        <asp:Label ID="lblP115" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A115</td>
                                    <td>Cuentas que cobrar a personas, accionistas y gerentes</td>
                                    <td>
                                        <asp:Label ID="lblA115" runat="server"></asp:Label>
                                    </td>
                                    <td>P120</td>
                                    <td>Cuentas pagar comerciales - terceros </td>
                                    <td>
                                        <asp:Label ID="lblP120" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A120</td>
                                    <td>Cuentas cobrar diversas - terceros</td>
                                    <td>
                                        <asp:Label ID="lblA120" runat="server"></asp:Label>
                                    </td>
                                    <td>P121</td>
                                    <td>Cuentas pagar comerciales - relacionados</td>
                                    <td>
                                        <asp:Label ID="lblP121" runat="server">  </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A121</td>
                                    <td>Cuentas cobrar diversas - relacionados</td>
                                    <td>
                                        <asp:Label ID="lblA121" runat="server"></asp:Label>
                                    </td>
                                    <td>P122</td>
                                    <td>Cuentas pagar accionista director y gerente</td>
                                    <td>
                                        <asp:Label ID="lblP122" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A122</td>
                                    <td>Servicios y otros contratados anticipados</td>
                                    <td>
                                        <asp:Label ID="lblA122" runat="server"></asp:Label>
                                    </td>
                                    <td>P128</td>
                                    <td>Cuentas por pagar diversas - terceros</td>
                                    <td>
                                        <asp:Label ID="lblP128" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A123</td>
                                    <td>Estimación cuentas cobranza dudosa</td>
                                    <td>
                                        <asp:Label ID="lblA123" runat="server"></asp:Label>
                                    </td>
                                    <td>P129</td>
                                    <td>Cuentas pagar diversas - relacionados</td>
                                    <td>
                                        <asp:Label ID="lblP129" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A124</td>
                                    <td>Mercaderías</td>
                                    <td>
                                        <asp:Label ID="lblA124" runat="server"></asp:Label>
                                    </td>
                                    <td>P133</td>
                                    <td>Obligaciones financieras </td>
                                    <td>
                                        <asp:Label ID="lblP133" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A125</td>
                                    <td>Productos terminados</td>
                                    <td>
                                        <asp:Label ID="lblA125" runat="server"></asp:Label>
                                    </td>
                                    <td>P135</td>
                                    <td>Provisiones </td>
                                    <td>
                                        <asp:Label ID="lblP135" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A130</td>
                                    <td>Sub productos, desechos y desperdicios</td>
                                    <td>
                                        <asp:Label ID="lblA130" runat="server"></asp:Label>
                                    </td>
                                    <td>P141</td>
                                    <td>Pasivo diferido</td>
                                    <td>
                                        <asp:Label ID="lblP141" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A135</td>
                                    <td>Productos en proceso</td>
                                    <td>
                                        <asp:Label ID="lblA135" runat="server"></asp:Label>
                                    </td>
                                    <th>P199</th>
                                    <th>Total pasivo</th>
                                    <th>
                                        <asp:Label ID="lblP199" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>A140</td>
                                    <td>Materias primas</td>
                                    <td>
                                        <asp:Label ID="lblA140" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>A142</td>
                                    <td>Materiales auxiliares, suministros y repuestos</td>
                                    <td>
                                        <asp:Label ID="lblA142" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>A145</td>
                                    <td>Envases y embalajes</td>
                                    <td>
                                        <asp:Label ID="lblA145" runat="server"></asp:Label>
                                    </td>
                                    <th></th>
                                    <th>Patrimonio</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>A151</td>
                                    <td>Existencias por recibir</td>
                                    <td>
                                        <asp:Label ID="lblA151" runat="server"></asp:Label>
                                    </td>
                                    <td>P505</td>
                                    <td>Capital</td>
                                    <td>
                                        <asp:Label ID="lblP505" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A152</td>
                                    <td>Desvalorización de existencias</td>
                                    <td>
                                        <asp:Label ID="lblA152" runat="server"></asp:Label>
                                    </td>
                                    <td>P507</td>
                                    <td>Acciones de inversión </td>
                                    <td>
                                        <asp:Label ID="lblP507" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A153</td>
                                    <td>Activos no corrientes mantenido para venta</td>
                                    <td>
                                        <asp:Label ID="lblA153" runat="server"></asp:Label>
                                    </td>
                                    <td>P510</td>
                                    <td>Capital adicional</td>
                                    <td>
                                        <asp:Label ID="lblP510" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A155</td>
                                    <td>Otros activos corrientes</td>
                                    <td>
                                        <asp:Label ID="lblA155" runat="server"></asp:Label>
                                    </td>
                                    <td>P511</td>
                                    <td>Resultados no realizados</td>
                                    <td>
                                        <asp:Label ID="lblP511" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A157</td>
                                    <td>Inversiones mobiliarias</td>
                                    <td>
                                        <asp:Label ID="lblA157" runat="server"></asp:Label>
                                    </td>
                                    <td>P515</td>
                                    <td>Excedente de revaluación </td>
                                    <td>
                                        <asp:Label ID="lblP515" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A158</td>
                                    <td>Inversiones inmobiliarias (1)</td>
                                    <td>
                                        <asp:Label ID="lblA158" runat="server"></asp:Label>
                                    </td>
                                    <td>P520</td>
                                    <td>Reservas</td>
                                    <td>
                                        <asp:Label ID="lblP520" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A159</td>
                                    <td>Activos adquiridos. Arrendamiento financiero (2)</td>
                                    <td>
                                        <asp:Label ID="lblA159" runat="server"></asp:Label>
                                    </td>
                                    <td>P530</td>
                                    <td>Resultados acumulados positivo</td>
                                    <td>
                                        <asp:Label ID="lblP530" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A160</td>
                                    <td>Inmuebles, maquinarias y equipos</td>
                                    <td>
                                        <asp:Label ID="lblA160" runat="server"></asp:Label>
                                    </td>
                                    <td>P531</td>
                                    <td>Resultados acumulados negativo</td>
                                    <td>
                                        <asp:Label ID="lblP531" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A164</td>
                                    <td>Depreciación de 1 y 2 e inmueble maquinaria equipo acumulado</td>
                                    <td>
                                        <asp:Label ID="lblA164" runat="server"></asp:Label>
                                    </td>
                                    <td>P540</td>
                                    <td>Utilidad del ejercicio</td>
                                    <td>
                                        <asp:Label ID="lblPResultado" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A176</td>
                                    <td>Intangibles</td>
                                    <td>
                                        <asp:Label ID="lblA176" runat="server"></asp:Label>
                                    </td>
                                    <td>P541</td>
                                    <td>Pérdida del ejercicio</td>
                                    <td>
                                        <asp:Label ID="lblP541" runat="server"> </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>A177</td>
                                    <td>Activos biológicos</td>
                                    <td>
                                        <asp:Label ID="lblA177" runat="server"></asp:Label>
                                    </td>
                                    <th>P599</th>
                                    <th>Total patrimonio</th>
                                    <th>
                                        <asp:Label ID="lblP599" runat="server"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>A178</td>
                                    <td>Depreciación activo biológico amortizado y agotamiento acumulado</td>
                                    <td>
                                        <asp:Label ID="lblA178" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>A179</td>
                                    <td>Desvalorización de activo inmovilizado</td>
                                    <td>
                                        <asp:Label ID="lblA179" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>A180</td>
                                    <td>Activo diferido</td>
                                    <td>
                                        <asp:Label ID="lblA180" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>A185</td>
                                    <td>Otros activos no corrientes</td>
                                    <td>
                                        <asp:Label ID="lblA185" runat="server"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>A999</th>
                                    <th>Total activo neto</th>
                                    <th>
                                        <asp:Label ID="lblA999" runat="server"></asp:Label>
                                    </th>
                                    <th>P999</th>
                                    <th>Total pasivo y patrimonio</th>
                                    <th>
                                        <asp:Label ID="lblP999" runat="server"></asp:Label>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script> var columnA = 2; var columnB = 5; </script>
    <script>var moneda = "<% Response.Write(Session["TipoMonedaEFNT"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["TipoReporteEFNT"].ToString()); %>"; var ruta = "../..";</script>
    <script src="../Scripts/Owner/RW-009-b.js"></script>
    <script src="../Scripts/Owner/general.js"></script>
</asp:Content>
