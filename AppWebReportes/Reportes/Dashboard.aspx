﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebReportes.Reportes.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a class="nav-link" href="#"></a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br />
    <div class="container">
        <div class="col-sm-12">
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
                    <div class="row">
                        <div class="card">
                            <div class="card-block">
                                <h4 class="card-title">Bienvenido al sistema de reportes web Contasis</h4>
                                <p class="card-text">Seleccione</p>
                                <div class="row">
                                    <div class="col-md-4 col-sm-12" id="blockCuentasPendientes">
                                        <div class="card card-outline-primary text-center">
                                            <div class="card-block">
                                                <blockquote class="card-blockquote">
                                                    <p>Cuentas pendientes</p>
                                                    <br />
                                                    <footer>
                                                        <button type="button" class="btn btn-info" id="btnCuentasPendientes" role="button">Ver detalles</button>
                                                    </footer>
                                                </blockquote>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12" id="blockMargenUtilidad">
                                        <div class="card card-outline-primary text-center">
                                            <div class="card-block">
                                                <blockquote class="card-blockquote">
                                                    <p>Margen de utilidad por producto</p>
                                                    <footer>
                                                        <button type="button" class="btn btn-info" id="btnMargenUtilidad" role="button">Ver detalles</button>
                                                    </footer>
                                                </blockquote>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-sm-12" id="blockMinegocioAlDia">
                                        <div class="card card-outline-primary text-center">
                                            <div class="card-block">
                                                <blockquote class="card-blockquote">
                                                    <p>Mi negocio al día</p>
                                                    <br />
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
                    <div class="row">
                        <p class="card-text">Seleccione la empresa para el reporte de cuentas pendientes</p>
                        <table class="table table-striped table-bordered table-responsive" id="dataRCP" role="grid" style="margin: auto;">
                            <thead>
                                <tr>
                                    <th>Código de empresa</th>
                                    <th>Razón social</th>
                                    <th>Año de proceso</th>
                                    <th>RUC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>Código de empresa</th>
                                    <th>Razón social</th>
                                    <th>Año de proceso</th>
                                    <th>RUC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </tfoot>
                        </table>

                        <p class="card-text">Seleccione la empresa para el reporte de margen de utilidad</p>
                        <table class="table table-striped table-bordered table-responsive" id="dataRMU">
                            <thead>
                                <tr>
                                    <th>Código de empresa</th>
                                    <th>Razón social</th>
                                    <th>Año de proceso</th>
                                    <th>RUC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>Código de empresa</th>
                                    <th>Razón social</th>
                                    <th>Año de proceso</th>
                                    <th>RUC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </tfoot>
                        </table>

                        <p class="card-text">Seleccione la empresa para el reporte de Mi negocio al día</p>
                        <table class="table table-striped table-bordered table-responsive" id="dataRMND">
                            <thead>
                                <tr>
                                    <th>Código de empresa</th>
                                    <th>Razón social</th>
                                    <th>Año de proceso</th>
                                    <th>RUC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>Código de empresa</th>
                                    <th>Razón social</th>
                                    <th>Año de proceso</th>
                                    <th>RUC</th>
                                    <th>Seleccione</th>
                                </tr>
                            </tfoot>
                        </table>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalProgress" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Cargando</h5>
                </div>
                <div class="modal-body">
                    <div class="progress">
                        <div class="progress-bar progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100" style="width: 75%"></div>
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
        $("#Formulario").submit(function (event) {
            $('#modalProgress').modal('show');
            event.preventDefault();
        });
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
</asp:Content>
