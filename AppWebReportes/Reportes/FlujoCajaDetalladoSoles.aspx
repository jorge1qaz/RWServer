<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlujoCajaDetalladoSoles.aspx.cs" Inherits="AppWebReportes.Reportes.FlujoCajaDetallado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grdTableReport" runat="server" CssClass="table table-bordered table-responsive table-hover table-sm table-striped text-center"></asp:GridView>
    <script>
        $("td:contains('30/12/1899')").text('Sin fecha');
        $("th:contains('Descripción')").html('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;');
        $("td:contains('Saldo inicial')").parent().css('font-weight', 'bold');
        $("td:contains('Ingresos')").parent().css('font-weight', 'bold');
        $("td:contains('Total ingresos')").parent().css('font-weight', 'bold');
        $("td:contains('Egresos')").parent().css('font-weight', 'bold');
        $("td:contains('Total egresos')").parent().css('font-weight', 'bold');
        $("td:contains('Saldo final')").parent().css('font-weight', 'bold');
    </script>
    <script src="../Scripts/DataTables/export/dataTables.buttons.min.js"></script>
    <script src="../Scripts/DataTables/export/buttons.flash.min.js"></script>
    <script src="../Scripts/DataTables/export/jszip.min.js"></script>
    <script src="../Scripts/DataTables/export/pdfmake.min.js"></script>
    <script src="../Scripts/DataTables/export/vfs_fonts.js"></script>
    <script src="../Scripts/DataTables/export/buttons.html5.min.js"></script>
    <script src="../Scripts/DataTables/export/buttons.print.min.js"></script>
    <script>var moneda = "<% Response.Write(Session["TipoMonedaFCD"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["TipoReporteFCD"].ToString()); %>";</script>
    <script src="../Scripts/Owner/RW-010.js"></script>
</asp:Content>
