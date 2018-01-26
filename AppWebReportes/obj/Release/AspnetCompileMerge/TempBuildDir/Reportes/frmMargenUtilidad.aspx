<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMargenUtilidad.aspx.cs" Inherits="AppWebReportes.Reportes.frmMargenUtilidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a runat="server" class="nav-link" href="~/Reportes/Dashboard.aspx">Inicio</a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>

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
                                    <asp:ListItem Value="false">Dólares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="lstMes">Mes de proceso</label>
                                <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstMes_SelectedIndexChanged">
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
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <a href="#" id="btnFiltrosAvanzados" data-toggle="modal" data-target=".bd-example-modal-sm">Filtros avanzados</a>
                            </div>
                            <div id="blockFiltrosAvanzados">
                                <div class="form-group" runat="server" id="blockStore">
                                    <label for="lstAlmacenes">Almacén</label>
                                    <asp:DropDownList ID="lstAlmacenes" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblTitleCliente" runat="server" Text="Cliente"></asp:Label>
                                    <div class="input-group" runat="server" id="blockCostumers">
                                        <div class="input-group-addon" role="button" id="triggerCostumer">Buscar</div>
                                        <asp:TextBox ID="txtClienteRUC" CssClass="form-control" placeholder="Ingrese el RUC" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" runat="server" id="blockCosto1">
                                    <label for="lstCOSTO1">COSTO 1</label>
                                    <asp:DropDownList ID="lstCOSTO1" CssClass="form-control" runat="server">
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
                                    <label for="lstTipoStock">Tipo</label>
                                    <asp:DropDownList ID="lstTipoStock" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="true">Inciden en stock</asp:ListItem>
                                        <asp:ListItem Value="false">No inciden en stock</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" runat="server" id="blockAlcance">
                                    <label for="lstAlcance">Alcance</label>
                                    <asp:DropDownList ID="lstAlcance" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="true">Incide a registros</asp:ListItem>
                                        <asp:ListItem Value="false">No incide a registros</asp:ListItem>
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
                                    <asp:Label ID="lblFilter" runat="server" Text="Se ha agregado el filtro de, "></asp:Label>
                                </div>
                                <div class="offset-lg-1 col-lg-2 offset-md-1 col-md-2 offset-sm-1 col-sm-4">
                                    <asp:Button ID="btnDeleteFilter" CssClass="btn btn-outline-danger" runat="server" Text="Eliminar filtro" OnClick="btnDeleteFilter_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-11 col-md-11 col-xs-12">
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
    <div class="modal fade bd-example-modal" id="modalListCostumer" tabindex="-1" role="dialog" aria-labelledby="modalListCostumerLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalListCostumerLabel">Cuentas contables</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row justify-content-md-center">
                            <div class="col-md-10 col-sm-12">
                                <table class="table table-striped table-bordered center" id="tablaCostumer">
                                    <thead>
                                        <tr>
                                            <th>RUC</th>
                                            <th>Detalle</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>RUC</th>
                                            <th>Detalle</th>
                                            <th></th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Seleccione el filtro a emplear</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbStore" runat="server" OnCheckedChanged="chbStore_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Almacén</span>
                    </label>
                    <br />
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbCostumers" runat="server" OnCheckedChanged="chbCostumers_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Clientes</span>
                    </label>
                    <br />
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbCosto1" runat="server" OnCheckedChanged="chbCosto1_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Centro de costo 1</span>
                    </label>
                    <br />
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbVendedor" runat="server" OnCheckedChanged="chbVendedor_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Vendedor</span>
                    </label>
                    <br />
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbStock" runat="server" OnCheckedChanged="chbStock_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Tipo</span>
                    </label>
                    <br />
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbAlcance" runat="server" OnCheckedChanged="chbAlcance_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Alcance</span>
                    </label>
                    <br />
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbCosto2" runat="server" OnCheckedChanged="chbCosto2_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description">Centro de costo 2</span>
                    </label>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnSaveFilters" CssClass="btn btn-primary" runat="server" Text="Guardar filtros" OnClick="btnSaveFilters_Click" />
                </div>
            </div>
        </div>
    </div>
    <script>
        $("#MainContent_chbStore").addClass("custom-control-input");
        $("#MainContent_chbCostumers").addClass("custom-control-input");
        $("#MainContent_chbCosto1").addClass("custom-control-input");
        $("#MainContent_chbVendedor").addClass("custom-control-input");
        $("#MainContent_chbStock").addClass("custom-control-input");
        $("#MainContent_chbAlcance").addClass("custom-control-input");
        $("#MainContent_chbCosto2").addClass("custom-control-input");
    </script>
    <script src="../Scripts/DataTables/export/dataTables.buttons.min.js"></script>
    <script src="../Scripts/DataTables/export/buttons.flash.min.js"></script>
    <script src="../Scripts/DataTables/export/jszip.min.js"></script>
    <script src="../Scripts/DataTables/export/pdfmake.min.js"></script>
    <script src="../Scripts/DataTables/export/vfs_fonts.js"></script>
    <script src="../Scripts/DataTables/export/buttons.html5.min.js"></script>
    <script src="../Scripts/DataTables/export/buttons.print.min.js"></script>
    <script>
        var idEmpresa = "01";
    </script>
    <script>
        var listCostumer = <% Response.Write(Session["listCostumer"].ToString()); %>;
    </script>
    <script>
        var dataSet = <% Response.Write(Session["queryJson"].ToString()); %>;
    </script>
    <script src="../Scripts/Owner/RW-006.js"></script>
</asp:Content>
