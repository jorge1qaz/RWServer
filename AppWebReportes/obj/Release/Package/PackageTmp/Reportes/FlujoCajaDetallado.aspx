<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FlujoCajaDetallado.aspx.cs" Inherits="AppWebReportes.Reportes.FlujoCajaDetallado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grdPruebas" runat="server" CssClass="table table-bordered table-responsive table-hover table-sm table-striped text-center"></asp:GridView>
    <script>
        $("td:contains('30/12/1899')").text('Sin fecha');
    </script>
</asp:Content>
