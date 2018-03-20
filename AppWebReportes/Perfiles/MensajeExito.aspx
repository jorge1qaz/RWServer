<%@ Page Title="Mensaje de éxito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MensajeExito.aspx.cs" Inherits="AppWebReportes.Perfiles.MensajeExito" %>

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
                            <div class="col-md-8"><i class="material-icons" style="font-size: 160px; color: #70bbe8 !important;">done</i></div>
                        </div>
                        <div class="row justify-content-center">
                            <div class="col-md-8">
                                <div class="card bg-success text-white">
                                    <div class="card-block">
                                        <asp:Label ID="lblMensajePrincipal" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <a runat="server" href="~/Acceso.aspx" id="linkAcceso" class="btn btn-primary">Iniciar sesión</a>
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
    <script>var msgError = true;</script>
</asp:Content>
