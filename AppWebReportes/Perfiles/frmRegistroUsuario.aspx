<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroUsuario.aspx.cs" Inherits="AppWebReportes.Perfiles.frmRegistroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: -20px;">
        <div class="row">
            <div class="offset-md-2 offset-sm-0 col-md-8 col-sm-12">
                <div id="Formulario">
                    <div class="card card-inverse card-info text-white">
                        <div class="card-header bg-primary">
                            <h5 class="text-center">Registro de usuario</h5>
                        </div>
                        <div class="card-block">
                            <div class="row justify-content-center" style="margin-bottom: 5px;">
                                <em>Los campos marcados con un asterisco (*) son obligatorios.</em>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtEmail">Correo Electrónico *</label>
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" AutoCompleteType="Email" placeholder="Ingrese su correo electrónico" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtConfirmarEmail">Confirmar correo Electrónico *</label>
                                        <asp:TextBox CssClass="form-control" ID="txtConfirmarEmail" AutoCompleteType="Email" placeholder="Vuelva a ingresar su correo electrónico" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtPassword">Contraseña *</label>
                                        <asp:TextBox ID="txtPassword" type="password" CssClass="form-control" placeholder="Ingrese su contraseña" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtConfirmarPassword">Confirmar contraseña *</label>
                                        <asp:TextBox ID="txtConfirmarPassword" type="password" CssClass="form-control" placeholder="Vuelva a ingresar su contraseña" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtNombre">Nombre(s) *</label>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Ingrese su nombre(s)" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtApellidos">Apellidos *</label>
                                        <asp:TextBox ID="txtApellidos" CssClass="form-control" placeholder="Ingrese sus apellidos" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtRUC">RUC</label>
                                        <asp:TextBox ID="txtRUC" CssClass="form-control" placeholder="Ingrese el número de su RUC" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="lstRol">Rol</label>
                                        <asp:DropDownList ID="lstRol" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="imagenes">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="fileImagenEmpresa">Imagen de empresa</label>
                                        <asp:FileUpload ID="fileImagenEmpresa" CssClass="form-control-file" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="fileImagenPerfil">Imagen de perfil</label>
                                        <asp:FileUpload ID="fileImagenPerfil" CssClass="form-control-file" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 offset-md-2 col-sm-12 offset-sm-0">
                                    <div class="form-group">
                                        <asp:Button ID="btnRegistrar" CssClass="btn btn-primary btn-block" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade bd-example-modal-sm" id="modalUserExistente" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Dirección de correo electrónico ya existente</h5>
                        </div>
                        <div class="modal-body">
                            <div class="card card-outline-secondary">
                                <div class="card-block">
                                    <p>Estimado usuario, tu dirección de correo electrónico ya existe en nuestra base de datos, sí tienes alguna duda o problema, no dudes en contactarnos.</p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
                    </div>
                </div>
            </div>
        <div class="modal fade bd-example-modal-sm" id="modalUserLicenciador"  tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">RUC/DNI no registrado en el licenciador</h5>
                        </div>
                        <div class="modal-body">
                            <div class="card card-outline-secondary">
                                <div class="card-block">
                                    <p>Estimado usuario, el RUC/DNI que estas empleando no está registrado en las licencias que ofrecemos, esto conlleva ciertas limitaciones en el uso del sistema, pero descuida aun puedes crear tu cuenta y acceder a diversos servicios en línea, como el foro de ayuda al cliente y mucho más.</p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
                    </div>
                </div>
            </div>
    </div>
    <script>
        
        function triggerUserExistente() {
            $(function () {
                $('#modalUserExistente').modal();
            });
        }
        function triggerUserLicenciador() {
            $(function () {
                $('#modalUserLicenciador').modal();
            });
        }
    </script>
    <script src="../Scripts/Owner/RW-005.js"></script>
    <script>var msgError = true;</script>
</asp:Content>
