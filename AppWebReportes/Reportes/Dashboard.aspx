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
            <div class="card-header">
                <h2 class="text-center">Inicio</h2>
            </div>
            <div class="card-block">
                <h4 class="card-title">Bienvenido al sistema de reportes web Contasis</h4>
                <div class="row" runat="server" id="blockUpdateData">
                    <div class="card card-inverse card-success text-center">
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
                <br />
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-12" id="blockCuentasPendientes">
                        <div class="card card-outline-secondary text-center">
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
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-secondary" runat="server" Text="Seleccione" />
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
                        <div class="card card-outline-info text-center">
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
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-info" runat="server" Text="Seleccione" />
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
                        <div class="card card-outline-warning  text-center">
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
                                                                        <asp:Button ID="btnSeleccionar" CssClass="btn btn-warning" runat="server" Text="Seleccione" />
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
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
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
                        <div class="card-block">
                            <label class="font-weight-bold">Estado financiero comparativo</label>
                            <label class="custom-control custom-checkbox">
                                <asp:CheckBox ID="chbEDRPMSNaturaleza" runat="server" OnCheckedChanged="chbEDRPMSNaturaleza_CheckedChanged" Checked="true" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">EGP por naturaleza</span>
                            </label>
                            <br />
                            <label class="custom-control custom-checkbox">
                                <asp:CheckBox ID="chbEDRPMSFuncion" runat="server" OnCheckedChanged="chbEDRPMSFuncion_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">EGP por función</span>
                            </label>
                        </div>
                    </div>
                    <div class="card card-outline-secondary">
                        <div class="card-block">
                            <label class="font-weight-bold">Tipo de moneda</label>
                            <br />
                            <label class="custom-control custom-checkbox">
                                <asp:CheckBox ID="chbchbEDRPMSSoles" runat="server" OnCheckedChanged="chbchbEDRPMSSoles_CheckedChanged" Checked="true" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Soles</span>
                            </label>
                            <br />
                            <label class="custom-control custom-checkbox">
                                <asp:CheckBox ID="chbchbEDRPMSDolares" runat="server" OnCheckedChanged="chbchbEDRPMSDolares_CheckedChanged" />
                                <span class="custom-control-indicator"></span>
                                <span class="custom-control-description">Dólares</span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnSaveFilters" CssClass="btn btn-primary" runat="server" Text="Guardar filtros" />
                </div>
            </div>
        </div>
    </div>
    <script>
        $("#MainContent_chbEDRPMSNaturaleza").addClass("custom-control-input");
        $("#MainContent_chbEDRPMSFuncion").addClass("custom-control-input");
        $("#MainContent_chbchbEDRPMSSoles").addClass("custom-control-input");
        $("#MainContent_chbchbEDRPMSDolares").addClass("custom-control-input");
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
    <script>
        $("#Formulario").ready(function () {
            $('#modalProgress').modal('hide');
        });
    </script>
    <script>
        function responsive() {
            $("#dataRCP_info").hide();
            $("#dataRMU_info").hide();
        }
        responsive();
    </script>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
