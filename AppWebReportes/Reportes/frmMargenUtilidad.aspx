<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMargenUtilidad.aspx.cs" Inherits="AppWebReportes.Reportes.frmMargenUtilidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form" id="Formulario">
        <div class="container">
            <br />
            <div class="row">
                <div class="col-lg-3 col-md-12 col-sm-12">
                    <div class="card card-inverse card-info text-center">
                        <div class="card-block">
                            <div class="form-group">
                                <label for="lstTipoMoneda">Tipo de moneda</label>
                                <asp:DropDownList ID="lstTipoMoneda" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="true">Nuevos soles</asp:ListItem>
                                    <asp:ListItem Value="false">Dolares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="lstMes">Mes de proceso</label>
                                <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                    <asp:ListItem Value="12">Acumulado hasta la fecha</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <a href="javascript: void(0)" id="btnFiltrosAvanzados">Filtros avanzados</a>
                            </div>
                            <div id="blockFiltrosAvanzados">
                                <div class="form-group">
                                    <label for="lstAlmacenes">Almacén</label>
                                    <asp:DropDownList ID="lstAlmacenes" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstAlmacenes_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label for="lstCOSTO1">COSTO 1</label>
                                    <asp:DropDownList ID="lstCOSTO1" CssClass="form-control" runat="server" OnSelectedIndexChanged="lstCOSTO1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" runat="server" id="blockCosto2">
                                    <label for="lstCOSTO2">COSTO 2</label>
                                    <asp:DropDownList ID="lstCOSTO2" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" runat="server" id="blockVendedor">
                                    <label for="lstVendedor">Vendedor</label>
                                    <asp:DropDownList ID="lstVendedor" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" runat="server" id="blockStock">
                                    <label for="lstTipoStock">Stock</label>
                                    <asp:DropDownList ID="lstTipoStock" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" runat="server" id="blockAlcance">
                                    <label for="lstAlcance">Alcance</label>
                                    <asp:DropDownList ID="lstAlcance" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnGenerarReporte" runat="server" CssClass="btn btn-success form-control" Text="Generar reporte" OnClick="btnGenerarReporte_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-9 col-md-12 col-sm-12">
                    <div class="card card-outline-secondary text-center">
                        <div class="card-block">
                            <h4 class="card-title">Reporte de Margen de utilidad <span id="monthtitle">para el mes de </span><span id="monthHeader"></span></h4>
                            <div runat="server" class="row" id="spanFilters" style="margin-bottom: 5px;">
                                <div class="offset-lg-3 col-lg-3 offset-md-2 col-md-5 offset-sm-1 col-sm-6">
                                    <asp:Label ID="lblFilter" runat="server" Text="Se ha agregado el filtro de: "></asp:Label>
                                </div>
                                <div class="offset-lg-1 col-lg-2 offset-md-1 col-md-2 offset-sm-1 col-sm-4">
                                    <asp:Button ID="btnDeleteFilter" CssClass="btn btn-outline-danger" runat="server" Text="Eliminar filtro" OnClick="btnDeleteFilter_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 col-md-11 col-xs-12">
                                    <table class="table table-striped table-bordered display table-responsive" id="tablaReporte">
                                        <thead>
                                            <tr>
                                                <th>Código</th>
                                                <th>Descripción</th>
                                                <th>Medida</th>
                                                <th>Unidades</th>
                                                <th>Precio venta</th>
                                                <th>Precio costo</th>
                                                <th>Margen de utilidad unitario</th>
                                                <th>Monto de ventas</th>
                                                <th>Monto de costo</th>
                                                <th>Margen de utilidad</th>
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th class="center">Código</th>
                                                <th class="center">Descripción</th>
                                                <th class="center">Medida</th>
                                                <th class="center">Unidades</th>
                                                <th class="center">Precio venta</th>
                                                <th class="center">Precio costo</th>
                                                <th class="center">Margen de utilidad unitario</th>
                                                <th class="center">Monto de ventas</th>
                                                <th class="center">Monto de costo</th>
                                                <th class="center">Margen de utilidad</th>
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
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.32/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.print.min.js"></script>
    <script>
        var dataSet = <% Response.Write(Session["queryJson"].ToString()); %>;
    </script>
    <script src="../Scripts/Owner/RW-006.js"></script>
</asp:Content>
