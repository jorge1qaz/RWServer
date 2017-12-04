<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebReportes.Reportes.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h5>Bienvenido al Sistema de Reportes Contasis</h5>
    </div>
    <div class="row">
        <h4>Cuentas pendientes</h4>
        <h4>Margen de utilidad por producto</h4>
        <div class="row">
            <div class="col-lg-9 col-md-12 col-sm-12">
                    <div class="card card-outline-secondary text-center">
                        <div class="card-block">
                            <div class="row">
                                <div class="col-lg-12 col-md-11 col-xs-12">
                                    <table class="table table-striped table-bordered display table-responsive" id="tablaReporte">
                                        <thead>
                                            <tr>
                                                <th>a</th>
                                                <th>b</th>
                                                <th>c</th>
                                                <th>d</th>
                                                <th>e</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th>a</th>
                                                <th>b</th>
                                                <th>c</th>
                                                <th>d</th>
                                                <th>e</th>
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
    <script src="../Scripts/Owner/dashboard.js"></script>
</asp:Content>
