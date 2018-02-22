<%@ Page Title="Solicitud de cambio de contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="AppWebReportes.Perfiles.CambioPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="row align-items-center">
            <div class="col-md-12">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <h4 class="card-title">Solicitar cambio de contraseña</h4>
                        <div class="row">
                            <div class="offset-md-1 offset-sm-0 col-md-6 col-sm-12">
                                <div class="form">
                                    <div class="form-group">
                                        <label for="txtEmail">Correo Electrónico</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" AutoCompleteType="Email" placeholder="Escriba su correo electrónico"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtRUC">Número de RUC</label>
                                        <asp:TextBox ID="txtRUC" runat="server" CssClass="form-control" placeholder="Escriba el número de RUC con el cual se registró"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="offset-md-1 offset-sm-0 col-md-4 col-sm-12">
                                <div class="row align-items-center">
                                    <div class="col"><i class="material-icons text-info" style="font-size: 160px; color: #70bbe8 !important;">vpn_key</i></div>
                                    <div class="col">
                                        <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-primary" Text="Confirmar" OnClick="btnChangePassword_Click" />
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
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
