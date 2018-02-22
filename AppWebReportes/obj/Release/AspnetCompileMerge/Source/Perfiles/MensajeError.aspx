<%@ Page Title="Mensaje de error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MensajeError.aspx.cs" Inherits="AppWebReportes.Perfiles.MensajeError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <br />
        <div class="row align-items-center">
            <div class="col-md-12">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <h4 class="card-title">
                            <asp:Label ID="lblHeader" runat="server" Text="Label"></asp:Label></h4>
                        <div class="row justify-content-center">
                            <div class="col-md-8"><i class="material-icons text-danger" style="font-size: 160px;">error_outline</i></div>
                        </div>
                        <div class="row justify-content-center">
                            <div class="col-md-8">
                                <div class="card bg-danger text-white">
                                    <div class="card-block">
                                        <asp:Label ID="lblMensajePrincipal" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <a runat="server" href="~/Perfiles/CambioPassword?tipoReporte=1" id="linkCambiarPassword" class="btn btn-primary">Volver</a>
                                        <a runat="server" href="~/Perfiles/frmRegistroUsuario?tipoReporte=1" id="linkRegistroUsuario" class="btn btn-primary">Volver</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
