<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebReportes.Reportes.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="offset-md-1 col-md-10 offset-sm-0 col-sm-12">
        <br />
        <div class="card text-center">
            <div class="card-header">
                <ul class="nav nav-pills nav-fill" role="tablist">
                    <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#navRPC" role="tab" id="triggerNavRPC">Cuentas pendientes</a></li>
                    <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#navRMU" role="tab" id="triggerNavRMU" >Margen de utilidad por producto</a></li>
                </ul>
            </div>
            <div class="card-block">
                <h4 class="card-title">Bienvenido al sistema de reportes web Contasis</h4>
                <div class="row">
                    <div class="offset-md-2 col-md-8 offset-sm-0 col-sm-12">
                        <div class="d-flex justify-content-center">
                            <div class="card">
                                <div class="card-block">
                                    <div class="tab-content">
                                        <div class="tab-pane active" id="navRPC" role="tabpanel">
                                            <p class="card-text">Seleccione la empresa para el reporte de cuentas pendientes</p>
                                            <table class="table table-striped table-bordered table-responsive" id="dataRCP" role="grid">
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
                                        <div class="tab-pane active" id="navRMU" role="tabpanel">
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
                                        </div>
                                    </div>
                                </div>
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
</asp:Content>
