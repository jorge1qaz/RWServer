<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="AppWebReportes.Perfiles.CambiarPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="row align-items-center">
            <div class="col-md-12">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <h4 class="card-title">Ingrese su nueva contraseña</h4>
                        <div class="row">
                            <div class="offset-md-1 offset-sm-0 col-md-6 col-sm-12">
                                <div class="form">
                                    <div class="form-group">
                                        <label for="txtPassword">Contraseña *</label>
                                        <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" placeholder="Ingrese su contraseña" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtConfirmarPassword">Confirmar contraseña *</label>
                                        <asp:TextBox ID="txtConfirmarPassword" type="password" CssClass="form-control" placeholder="Vuelva a ingresar su contraseña" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="offset-md-1 offset-sm-0 col-md-4 col-sm-12">
                                <div class="row align-items-center">
                                    <div class="col"><i class="material-icons text-info" style="font-size: 160px;">vpn_key</i></div>
                                    <div class="col">
                                        <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-primary" Text="Cambiar contraseña" OnClick="btnChangePassword_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/Owner/RW-005.js"></script>
</asp:Content>
