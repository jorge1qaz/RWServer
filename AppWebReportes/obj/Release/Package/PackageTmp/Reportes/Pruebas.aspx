<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="AppWebReportes.Reportes.FlujoCajaSimpleSoles" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>var ruta = "../..";</script>
    <script src="../Scripts/Owner/general.js"></script>


    <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
    <asp:Button ID="btnConsultar" runat="server" Text="Button" OnClick="btnConsultar_Click"  />
    <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
</asp:Content>
