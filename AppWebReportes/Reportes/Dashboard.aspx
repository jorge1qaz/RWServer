<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebReportes.Reportes.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li>
                    <label>Usted tiene datos hasta la fecha: <asp:Label ID="lblDateUpdate" runat="server"></asp:Label></label>
                </li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br /><br />
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
                    <div class="col-md-4 col-sm-12" id="blockCuentasPendientes">
                        <div class="card card-outline-secondary text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <p>Cuentas pendientes</p>
                                    <div class="row">
                                        <div class="col-md-8 offset-md-2 col-sm-12 offset-md-0">
                                            <div id="blockCompanyDetailsForRCP">
                                                <asp:GridView ID="grdConta" runat="server"></asp:GridView>
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
                                                        <tr>
                                                            <td>
                                                                <button class="btn btn-success">Seleccione</button>
                                                            </td>
                                                            <td>
                                                                <select class="custom-select" id="lstAnioCompany1" name="lst">
                                                                    <option value="2017">2017</option>
                                                                    <option value="2017">2016</option>
                                                                </select>
                                                            </td>
                                                            <td>
                                                                <span>01</span>
                                                            </td>
                                                            <td>
                                                                <span>PRUEBAS</span>
                                                            </td>
                                                            <td>
                                                                <span>12345678910</span>
                                                            </td>
                                                        </tr>
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
                    <div class="col-md-4 col-sm-12" id="blockMargenUtilidad">
                        <div class="card card-outline-success text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <p>Margen de utilidad por producto</p>
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
                                                        <tr>
                                                            <td>
                                                                <button class="btn btn-success">Seleccione</button>
                                                            </td>
                                                            <td>
                                                                <select class="custom-select" id="lstAnioCompany2" name="lst">
                                                                    <option value="2017">2017</option>
                                                                    <option value="2017">2016</option>
                                                                </select>
                                                            </td>
                                                            <td>
                                                                <span>01</span>
                                                            </td>
                                                            <td>
                                                                <span>PRUEBAS</span>
                                                            </td>
                                                            <td>
                                                                <span>12345678910</span>
                                                            </td>
                                                        </tr>
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
                    <div class="col-md-4 col-sm-12" id="blockMinegocioAlDia">
                        <div class="card card-outline-info text-center">
                            <div class="card-block">
                                <blockquote class="card-blockquote">
                                    <p>Mi negocio al día</p>
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
                                                        <tr>
                                                            <td>
                                                                <button class="btn btn-success">Seleccione</button>
                                                            </td>
                                                            <td>
                                                                <select class="custom-select" id="lstAnioCompany3" name="lst">
                                                                    <option value="2017">2017</option>
                                                                    <option value="2017">2016</option>
                                                                </select>
                                                            </td>
                                                            <td>
                                                                <span>01</span>
                                                            </td>
                                                            <td>
                                                                <span>PRUEBAS</span>
                                                            </td>
                                                            <td>
                                                                <span>12345678910</span>
                                                            </td>
                                                        </tr>
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
            </div>
        </div>
    </div>

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
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
