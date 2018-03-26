<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlujoCajaDetalladoSoles.aspx.cs" Inherits="AppWebReportes.Reportes.FlujoCajaDetallado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a runat="server" class="nav-link" href="~/Reportes/Dashboard.aspx"><i class="material-icons left" id="home" data-toggle="tooltip" data-placement="right" title="Regresar al inicio">home</i></a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <div class="">
        <div class="row">
            <div class="card card-outline-secondary text-center">
                <div class="card-block">
                    <div class="row">
                        <div class="offset-md-2 col-md-8">
                            <h4 class="card-title">Flujo de caja detallado</h4>
                        </div>
                    </div>
                    <asp:Label ID="lblTipoReporte" runat="server"></asp:Label><span> - Expresado en </span>
                        <asp:Label ID="lblTipoMoneda" runat="server"></asp:Label>

                    <asp:GridView ID="grdTableReport" runat="server" CssClass="table table-bordered table-hover table-sm table-striped text-center"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script>
        $("td:contains('30/12/1899')").text('Sin fecha');
        $("th:contains('Descripción')").html('Descripción');
        $("td:contains('Saldo inicial')").parent().css('font-weight', 'bold');
        $("td:contains('Ingresos')").parent().css('font-weight', 'bold');
        $("td:contains('Total ingresos')").parent().css('font-weight', 'bold');
        $("td:contains('Egresos')").parent().css('font-weight', 'bold');
        $("td:contains('Total egresos')").parent().css('font-weight', 'bold');
        $("td:contains('Saldo final')").parent().css('font-weight', 'bold');
    </script>
    <script>var moneda = "<% Response.Write(Session["TipoMonedaFCD"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["TipoReporteFCD"].ToString()); %>";</script>
    <script>var cantidadDeperiodos = parseInt("<% Response.Write(Session["FCDPeriodo"].ToString()); %>");</script>
    <script>var cantidadFilas = parseInt("<% Response.Write(Session["cantidadFilasFinalFlash"].ToString()); %>");</script>

    <script>
        if (tipoReporte == "Formato simple") {
            $("th:contains('Descripción')").css("min-width", "250px");
        }
        var ruta = "../..";
    </script>
    <script src="../Scripts/Owner/RW-010.js"></script>
    <script src="../Scripts/Owner/general.js"></script>
</asp:Content>
