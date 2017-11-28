<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AppWebReportes.Reportes.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="offset-lg-4 col-lg-4 offset-md-2 col-md-8 offset-sm-0 col-sm-12">
        <asp:GridView ID="grdPruebas" runat="server">
        </asp:GridView>
        <br />
        <div class="card card-inverse card-info text-center">
            <div class="card-block">
                <h5>Dashboard Contasis</h5>
                <div class="form-group">
                    <label for="lstEmpresas">Reportes</label>
                    <asp:DropDownList ID="lstReportes" CssClass="form-control" runat="server">
                        <asp:ListItem Selected="True" Value="rptCntsPndts">Cuentas pendientes</asp:ListItem>
                        <asp:ListItem Value="rptsMrgTld">Margen de utilidad por producto</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="lstEmpresas">Tipo de moneda</label>
                    <asp:DropDownList ID="lstTipoMoneda" CssClass="form-control" runat="server">
                        <asp:ListItem Selected="True" Value="1">Nuevos soles</asp:ListItem>
                        <asp:ListItem Value="2">Dolares</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="exampleSelect1">Mes de proceso</label>
                    <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0">Apertura</asp:ListItem>
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
                    <asp:Button ID="btnGenerarReporte" runat="server" CssClass="btn btn-success form-control" Text="Generar reporte" OnClick="btnGenerarReporte_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
