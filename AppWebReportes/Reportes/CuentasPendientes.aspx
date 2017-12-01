<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CuentasPendientes.aspx.cs" Inherits="AppWebReportes.CP_Reportes.RW_004" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <br />
                <div class="row">
                    <div class="card card-inverse card-info text-center">
                        <div class="card-block">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Número de cuenta</label>
                                <input class="form-control" id="txtCuenta" type="text" placeholder="Escribe el número de cuenta" name="txtCuentaName" /><small class="form-text text-muted" id="Help">También puedes revisar las cuentas que tengan registros en tu base de datos.</small>
                            </div>
                            <div class="form-group">
                                <button class="btn btn-primary form-control" type="button" id="triggerModal">Buscar cuenta</button>
                            </div>
                            <div class="form-group">
                                <label for="lstEmpresas">Código de empresa</label>
                                <asp:DropDownList ID="lstEmpresas" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstEmpresas_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="exampleSelect1">Mes de proceso</label>
                                <select class="form-control" id="optMes">
                                    <option value="" disabled="" selected="">Seleccione</option>
                                    <option value="0">Apertura</option>
                                    <option value="1">Enero</option>
                                    <option value="2">Febrero</option>
                                    <option value="3">Marzo</option>
                                    <option value="4">Abril</option>
                                    <option value="5">Mayo</option>
                                    <option value="6">Junio</option>
                                    <option value="7">Julio</option>
                                    <option value="8">Agosto</option>
                                    <option value="9">Septiembre</option>
                                    <option value="10">Octubre</option>
                                    <option value="11">Noviembre</option>
                                    <option value="12">Diciembre</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label>Año de proceso</label>
                                <asp:DropDownList ID="lstAnios" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <button class="btn btn-success form-control" id="btnPruebas" type="button">
                                    Generar reporte
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <br />
                <div class="row">
                    <div class="card card-outline-secondary mb-3 text-center">
                        <div class="card-block">
                            <h4 class="card-title">Reporte de Cuentas pendientes</h4>
                            <table class="table table-striped table-bordered table-responsive" id="tablaReporte">
                                <thead>
                                    <tr>
                                        <th>RUC</th>
                                        <th>Debe</th>
                                        <th>Haber</th>
                                        <th>Total</th>
                                        <th>Razón social</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th class="center">RUC</th>
                                        <th class="center">Debe</th>
                                        <th class="center">Haber</th>
                                        <th class="center">Total</th>
                                        <th class="center">Razón social</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-lg" id="modalBuscarCuenta" tabindex="-1" role="dialog" aria-labelledby="modalBuscarCuentaLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalBuscarCuentaLabel">Cuentas contables</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <table class="table table-striped table-bordered" id="tablaCuentas">
                        <thead>
                            <tr>
                                <th>Cuenta</th>
                                <th>Detalle</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Cuenta</th>
                                <th>Detalle</th>
                                <th></th>
                            </tr>
                        </tfoot>
                    </table>
                    <br />
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.print.min.js"></script>
    <script>
        //var idCliente = "<% Response.Write(Session["IdUser"].ToString());%>";
        //var idEmpresa = <%--"<% Response.Write(Session["idCompany"].ToString());%>";--%>
        console.log(idEmpresa);
    </script>
    <script src="../Scripts/Owner/RW-004-b.js"></script>
</asp:Content>
