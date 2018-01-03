<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoResultadoPMS.aspx.cs" Inherits="AppWebReportes.Reportes.EstadoResultadoPMS" %>

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
    <br />
    <div class="">
        <div class="card text-center">
            <div class="card-block">
                <h4 class="card-title">Estado de Resultado por Naturaleza</h4>
                <div class="row">
                    <table id="example" class="table table-striped table-bordered display table-responsive">
                        <thead>
                            <tr>
                                <th>Código</th>
                                <th>Descripción</th>
                                <th>Enero</th>
                                <th>Febrero</th>
                                <th>Marzo</th>
                                <th>Abril</th>
                                <th>Mayo</th>
                                <th>Junio</th>
                                <th>Julio</th>
                                <th>Agosto</th>
                                <th>Setiembre</th>
                                <th>Octubre</th>
                                <th>Noviembre</th>
                                <th>Diciembre</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Código</th>
                                <th>Descripción</th>
                                <th>Enero</th>
                                <th>Febrero</th>
                                <th>Marzo</th>
                                <th>Abril</th>
                                <th>Mayo</th>
                                <th>Junio</th>
                                <th>Julio</th>
                                <th>Agosto</th>
                                <th>Setiembre</th>
                                <th>Octubre</th>
                                <th>Noviembre</th>
                                <th>Diciembre</th>
                            </tr>
                        </tfoot>
                        <tbody>
                            <tr>
                                <td>N005</td>
                                <td>Venta de mercadería</td>
                                <td><asp:Label ID="N005lbl1" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl2" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl3" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl4" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl5" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl6" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl7" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl8" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl9" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl10" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl11" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N005lbl12" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>N010</td>
                                <td>Compra de mercadería</td>
                                <td><asp:Label ID="N010lbl1" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl2" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl3" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl4" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl5" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl6" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl7" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl8" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl9" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl10" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl11" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N010lbl12" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                            <td>N015</td>
                                <td>Variación de  mercadería</td>
                                <td><asp:Label ID="N015lbl1" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl2" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl3" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl4" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl5" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl6" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl7" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl8" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl9" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl10" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl11" runat="server"></asp:Label></td>
                                <td><asp:Label ID="N015lbl12" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>N099</th>
                                <th>Margen comercial</th>
                                <th><asp:Label ID="N099lbl1" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl2" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl3" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl4" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl5" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl6" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl7" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl8" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl9" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl10" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl11" runat="server"></asp:Label></th>
                                <th><asp:Label ID="N099lbl12" runat="server"></asp:Label></th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.flash.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="../Scripts/DataTables/export/pdfmake.min.js"></script>
    <script src="../Scripts/DataTables/export/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.4.2/js/buttons.print.min.js"></script>
    <script src="../Scripts/Owner/RW-008.js"></script>
</asp:Content>
