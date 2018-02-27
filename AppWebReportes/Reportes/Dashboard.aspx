<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebReportes.Reportes.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li>
                    <label>
                        Usted tiene datos hasta la fecha:
                        <asp:Label ID="lblDateUpdate" runat="server"></asp:Label></label>
                </li>
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
        <div class="card text-center">
            <div class="card-header bg-primary">
                <h2 class="text-center text-white">Inicio</h2>
            </div>
            <div class="card-block">
                <h4 class="card-title">Bienvenido al sistema de reportes web Contasis</h4>
                <div class="row" runat="server" id="blockUpdateData">
                    <div class="card card-inverse card-success text-center text-white">
                        <div class="card-block">
                            <p>
                                Hemos detectado una nueva actualización a sus datos correspondiente a la fecha
                                    <asp:Label ID="lblCurrentData" runat="server"></asp:Label>. Su última actualización fue
                                    <asp:Label ID="lblOutdatedData" runat="server"></asp:Label>, La actualización a sus datos puede tardar varios segundos en terminar de ser procesados. ¿Desea actualizar sus datos?
                            </p>
                            <div class="row">
                                <div class="offset-md-3 col-md-3 offset-sm-1 col-sm-5">
                                    <div class="d-flex justify-content-center">
                                        <asp:Button ID="btnCloseBlockUpdate" CssClass="btn btn-danger btn-block" runat="server" Text="Por ahora, No." OnClick="btnCloseBlockUpdate_Click" />


                                    </div>
                                </div>
                                <div class="offset-md-0 col-md-3 offset-sm-1 col-sm-5">
                                    <div class="d-flex justify-content-center">
                                        <asp:Button ID="btnUpdateData" CssClass="btn btn-info btn-block" runat="server" Text="Acepto" OnClick="btnUpdateData_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" runat="server" id="imageDashboardBlock">
                    <img src="../Images/image-dashboard.png" class="img-fluid" id="imageDashboard"/>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockCuentasPendientes">
                        <div class="card card-outline-success text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <label class="font-weight-bold">Cuentas pendientes</label>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-2 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForRCP">
                                                <table class="table table-striped table-bordered table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Seleccione</th>
                                                            <th>Año de proceso</th>
                                                            <th>Código de empresa</th>
                                                            <th>Razón social</th>
                                                            <th>RUC</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:DataList ID="dlstCuentasPendientes" runat="server" RepeatLayout="Flow" DataKeyField="c" OnItemCommand="SelectCompanyByYearRCP">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-success" runat="server" Text="Seleccione" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("c") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCodigoEmpresa" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("d") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <footer>
                                        <button type="button" class="btn btn-info" id="btnCuentasPendientes" role="button">Ver detalles</button>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockMargenUtilidad">
                        <div class="card card-outline-success text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <label class="font-weight-bold">Margen de utilidad por producto</label>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-2 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForRMU">
                                                <table class="table table-striped table-bordered table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Seleccione</th>
                                                            <th>Año de proceso</th>
                                                            <th>Código de empresa</th>
                                                            <th>Razón social</th>
                                                            <th>RUC</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:DataList ID="dlstMargenDeUtilidad" runat="server" DataKeyField="c" RepeatLayout="Flow" OnItemCommand="SelectCompanyByYearRMU">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-success" runat="server" Text="Seleccione" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("c") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCodigoEmpresa" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("d") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <footer>
                                        <button type="button" class="btn btn-info" id="btnMargenUtilidad" role="button">Ver detalles</button>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockMinegocioAlDia">
                        <div class="card card-outline-success text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <label class="font-weight-bold">Mi negocio al día</label>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-2 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForRMND">
                                                <table class="table table-striped table-bordered table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Seleccione</th>
                                                            <th>Año de proceso</th>
                                                            <th>Código de empresa</th>
                                                            <th>Razón social</th>
                                                            <th>RUC</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:DataList ID="dlstMiNegocioAlDia" runat="server" DataKeyField="c" RepeatLayout="Flow" OnItemCommand="SelectCompanyByYearRMND">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-success" runat="server" Text="Seleccione" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("c") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCodigoEmpresa" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("d") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <footer>
                                        <button type="button" class="btn btn-info" id="btnMinegocioAlDia" role="button">Ver detalles</button>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockEstadoResultadoPMS">
                        <div class="card card-outline-success  text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <label class="font-weight-bold">Estado de resultado mensual</label>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-1 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForREDRPMS">
                                                <table class="table table-striped table-bordered table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Seleccione</th>
                                                            <th>Año de proceso</th>
                                                            <th>Código de empresa</th>
                                                            <th>Razón social</th>
                                                            <th>RUC</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:DataList ID="dlstEstadoResultadoPMS" runat="server" RepeatLayout="Flow" DataKeyField="c" OnItemCommand="SelectCompanyByYearEDRPMS">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-success" runat="server" Text="Seleccione" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("c") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCodigoEmpresa" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("d") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <a href="#" id="btnTriggerModalREDRPMS" class="btn btn-outline-warning" data-toggle="modal" data-target=".bd-example-modal-sm">Configuración</a>
                                        </div>
                                    </div>
                                    <footer>
                                        <button type="button" class="btn btn-info" id="btnEstadoResultadoPMS" role="button">Ver detalles</button>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockEstadosFinancierosNT">
                        <div class="card card-outline-success  text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <label class="font-weight-bold">Estados financieros NIIF y tributario</label>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-1 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForEFNT">
                                                <table class="table table-striped table-bordered table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Seleccione</th>
                                                            <th>Año de proceso</th>
                                                            <th>Código de empresa</th>
                                                            <th>Razón social</th>
                                                            <th>RUC</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:DataList ID="dlstEFNT" runat="server" RepeatLayout="Flow" DataKeyField="c" OnItemCommand="SelectCompanyByYearEFNT">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-success" runat="server" Text="Seleccione" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("c") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCodigoEmpresa" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("d") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <a href="#" id="btnTriggerModalEFNT" class="btn btn-outline-secondary" data-toggle="modal" data-target="modalEFNT">Configuración</a>
                                        </div>
                                    </div>
                                    <footer>
                                        <button type="button" class="btn btn-info" id="btnEFNT" role="button">Ver detalles</button>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockFlujoCajaDetallado">
                        <div class="card card-outline-success  text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <label class="font-weight-bold">Flujo de caja detallado</label>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-1 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForFCD">
                                                <table class="table table-striped table-bordered table-responsive">
                                                    <thead>
                                                        <tr>
                                                            <th>Seleccione</th>
                                                            <th>Año de proceso</th>
                                                            <th>Código de empresa</th>
                                                            <th>Razón social</th>
                                                            <th>RUC</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:DataList ID="dlstFCD" runat="server" RepeatLayout="Flow" DataKeyField="c" OnItemCommand="SelectCompanyByYearFCD">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-success" runat="server" Text="Seleccione" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("c") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCodigoEmpresa" runat="server" Text='<%# Eval("a") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("b") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("d") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <a href="#" id="btnTriggerModalFCD" class="btn btn-outline-primary" data-toggle="modal" data-target="modalEFNT">Configuración</a>
                                        </div>
                                    </div>
                                    <footer>
                                        <button type="button" class="btn btn-info" id="btnFCD" role="button">Ver detalles</button>
                                    </footer>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-sm" id="modalREDRPMS" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Seleccione</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="card card-outline-secondary">
                        <div class="card-block bg-faded">
                            <label class="font-weight-bold">Estado financiero comparativo</label>
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEDRPMSNaturaleza" runat="server" GroupName="radioEGP" OnCheckedChanged="rdbEDRPMSNaturaleza_CheckedChanged" Checked="true" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">EGP por naturaleza</span>
                            </label>
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEDRPMSFuncion" runat="server" GroupName="radioEGP" OnCheckedChanged="rdbEDRPMSFuncion_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">EGP por función</span>
                            </label>
                        </div>
                    </div>
                    <div class="card card-outline-secondary">
                        <div class="card-block bg-faded">
                            <label class="font-weight-bold">Tipo de moneda</label>
                            <br />
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEDRPMSSoles" runat="server" GroupName="radioMonedaERPMS" OnCheckedChanged="rdbEDRPMSSoles_CheckedChanged" Checked="true" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Nuevos soles</span>
                            </label>
                            <br />
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEDRPMSDolares" runat="server" GroupName="radioMonedaERPMS" OnCheckedChanged="rdbEDRPMSDolares_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Dólares</span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-sm" id="modalEFNT" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Seleccione</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="card card-outline-secondary">
                        <div class="card-block bg-faded">
                            <label class="font-weight-bold">Tipo de reporte</label>
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEFNT1" runat="server" GroupName="radioTipoReporteEFNT" OnCheckedChanged="rdbEFNT1_CheckedChanged" Checked="true" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Estado de situación financiera NIIF</span>
                            </label>
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEFNT2" runat="server" GroupName="radioTipoReporteEFNT" OnCheckedChanged="rdbEFNT2_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Estado de resultado NIIF: Naturaleza y función</span>
                            </label>
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEFNT3" runat="server" GroupName="radioTipoReporteEFNT" OnCheckedChanged="rdbEFNT3_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Balance general tributario</span>
                            </label>
                            <label class="custom-control custom-radio">
                                <asp:RadioButton ID="rdbEFNT4" runat="server" GroupName="radioTipoReporteEFNT" OnCheckedChanged="rdbEFNT4_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Estado de ganancias y pérdidas tributario: Función</span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bd-example-modal-lg" id="modalFCD" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Seleccione</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6 col-sm-12">
                                <div class="card card-outline-secondary">
                                    <div class="card-block bg-faded">
                                        <label class="font-weight-bold">Tipo de reporte</label>
                                        <br />
                                        <label class="custom-control custom-radio">
                                            <asp:RadioButton ID="rdbFCDSimple" runat="server" GroupName="radioFCDTTypeReport" Checked="true" OnCheckedChanged="rdbFCDSimple_CheckedChanged" />
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Reporte simple</span>
                                        </label>
                                        <label class="custom-control custom-radio">
                                            <asp:RadioButton ID="rdbFCDDetallado" runat="server" GroupName="radioFCDTTypeReport" OnCheckedChanged="rdbFCDDetallado_CheckedChanged" />
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Reporte detallado</span>
                                        </label>
                                    </div>
                                </div>
                                <br />
                                <div class="card card-outline-secondary">
                                    <div class="card-block bg-faded">
                                        <label class="font-weight-bold">Tipo de moneda</label>
                                        <br />
                                        <label class="custom-control custom-radio">
                                            <asp:RadioButton ID="rdbFCDSoles" runat="server" GroupName="radioMonedaFCD" Checked="true" OnCheckedChanged="rdbFCDSoles_CheckedChanged" />
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Nuevos soles</span>
                                        </label>
                                        <br />
                                        <label class="custom-control custom-radio">
                                            <asp:RadioButton ID="rdbFCDDolares" runat="server" GroupName="radioMonedaFCD" OnCheckedChanged="rdbFCDDolares_CheckedChanged" />
                                            <span class="custom-control-indicator"></span>
                                            <span class="custom-control-description">Dólares</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 col-sm-12">
                                <div class="card card-outline-secondary">
                                    <div class="card-block bg-faded">
                                        <label class="font-weight-bold">Opciones</label>
                                        <div class="form-group">
                                            <label for="txtFechaInicio">Fecha de inicio</label>
                                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="lstFrecuenciaPerdiodoFCD">Frecuencia del periodo</label>
                                            <asp:DropDownList ID="lstFrecuenciaPerdiodoFCD" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="7">7</asp:ListItem>
                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                <asp:ListItem Value="30">30</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label for="lstNumeroPeriodosFCD">Número de periodos</label>
                                            <asp:DropDownList ID="lstNumeroPeriodosFCD" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                <asp:ListItem Value="30">30</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-sm" id="modalProgress" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Procesando datos</h5>
                </div>
                <div class="modal-body">
                    <div class="card card-outline-secondary">
                        <div class="card-block">
                            <div class="progress">
                                <div id="progressBar" class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" style="width: 75%"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $("#MainContent_rdbEDRPMSNaturaleza").addClass("custom-control-input");
        $("#MainContent_rdbEDRPMSFuncion").addClass("custom-control-input");
        $("#MainContent_rdbEDRPMSSoles").addClass("custom-control-input");
        $("#MainContent_rdbEDRPMSDolares").addClass("custom-control-input");
        $("#MainContent_rdbEFNT1").addClass("custom-control-input");
        $("#MainContent_rdbEFNT2").addClass("custom-control-input");
        $("#MainContent_rdbEFNT3").addClass("custom-control-input");
        $("#MainContent_rdbEFNT4").addClass("custom-control-input");
        $("#MainContent_rdbEFNTSoles").addClass("custom-control-input");
        $("#MainContent_rdbEFNTDolares").addClass("custom-control-input");
        $("#MainContent_rdbFCDSimple").addClass("custom-control-input");
        $("#MainContent_rdbFCDDetallado").addClass("custom-control-input");
        $("#MainContent_rdbFCDSoles").addClass("custom-control-input");
        $("#MainContent_rdbFCDDolares").addClass("custom-control-input");
    </script>
    <script>
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
    <script>
        var idCliente = "<% Response.Write(Session["IdUser"].ToString()); %>";
    </script>
    <script src="../Scripts/Owner/dashboard.js"></script>
    <script src="../Scripts/DataTables/export/dataTables.buttons.min.js"></script>
    <script src="../Scripts/DataTables/export/buttons.flash.min.js"></script>
    <script src="../Scripts/DataTables/export/jszip.min.js"></script>
    <script src="../Scripts/DataTables/export/pdfmake.min.js"></script>
    <script src="../Scripts/DataTables/export/vfs_fonts.js"></script>
    <script src="../Scripts/DataTables/export/buttons.html5.min.js"></script>
    <script src="../Scripts/DataTables/export/buttons.print.min.js"></script>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
