<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDatos.aspx.cs" Inherits="AppWebReportes.Perfiles.EditarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="row align-items-center">
            <div class="col-md-12">
                <div class="card card-outline-secondary text-center">
                    <div class="card-block">
                        <h4 class="card-title">Actualice sus datos</h4>
                        <div class="row">
                            <div class="offset-md-1 offset-sm-0 col-md-5 col-sm-12">
                                <div class="form">
                                    <div class="form-group">
                                        <label for="txtNombre">Nombre(s) *</label>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Ingrese su nombre(s)" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtApellidos">Apellidos *</label>
                                        <asp:TextBox ID="txtApellidos" CssClass="form-control" placeholder="Ingrese sus apellidos" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="txtRUC">RUC</label>
                                        <asp:TextBox ID="txtRUC" CssClass="form-control" placeholder="Ingrese el número de su RUC" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="offset-md-1 offset-sm-0 col-md-5 col-sm-12">
                                <div class="row align-items-center">
                                    <div class="col"><i class="material-icons text-info" style="font-size: 160px;">border_color</i></div>
                                    <div class="col">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Guardar cambios" OnClick="btnSave_Click"/>
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
