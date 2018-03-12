<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="AppWebReportes.Reportes.FlujoCajaSimpleSoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function re() {
            alert("red");
            location.href = "http://licenciacontasis.net/reportweb/Reportes/Pruebas";
        }
    </script>
    <button onclick="re();">ssss</button>
</asp:Content>
