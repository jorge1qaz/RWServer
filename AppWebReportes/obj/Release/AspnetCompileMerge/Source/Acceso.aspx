<%@ Page Title="Acceso" Language="C#" MasterPageFile="~/Materialize.master" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="AppWebReportes.prueba3" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="grey lighten-5">
        <div class="container">
            <div class="row">
                <br />
                <br />
                <br />
                <div class="col offset-m2 offset-s0 offset-l3 m8 s12 l6">
                    <div class="card-panel z-depth-4">
                        <div class="center">
                            <div class="row">
                                <div class="col m12 s12">
                                    <img class="responsive-img" src="./Images/logo.png" alt="imagen de logo" />
                                </div>
                            </div>
                        </div>
                        <h5 class="center">Acceda a su cuenta de SmartReport</h5>
                        <div class="row">
                            <div class="form">
                                <div class="row" id="blockCorreo" runat="server">
                                    <div class="input-field col offset-m1 offset-s1 m10 s10">
                                        <asp:TextBox ID="txtCorreo" CssClass="validate" runat="server" onkeypress="return ComprobarUsuarioKey(event);"></asp:TextBox>
                                        <label for="txtCorreo">Correo electrónico</label>
                                        <div class="red-text center">
                                            <asp:Label ID="lblDoesNotExistUser" Text="" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="blockContrasenia" runat="server">
                                    <div class="input-field col offset-m1 offset-s1 m10 s10" id="txtPassword">
                                        <asp:TextBox ID="txtContrasenia" CssClass="validate" runat="server" type="password" onkeypress="return AccederKey(event);"></asp:TextBox>
                                        <label for="txtContrasenia">Contraseña</label>
                                        <div class="red-text center">
                                            <asp:Label ID="lblErrorPassword" Text="" runat="server" />
                                        </div>
                                        <div class="blue-text center">
                                            <asp:LinkButton ID="btnLinkCambiarContrasenia" CssClass="" runat="server" OnClick="btnLinkCambiarContrasenia_Click">¿Olvidaste tu contraseña?</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="center">
                                        <button id="btnHtmlComprobarUsuario" type="button" class="btn indigo waves-effect waves-light darken-4">Siguiente</button>
                                        <button id="btnHtmlAcceder" type="button" class="btn indigo waves-effect waves-light darken-4">Acceder</button>
                                    </div>
                                </div>
                                <div class="row center">
                                    <a runat="server" href="~/Perfiles/frmRegistroUsuario.aspx" id="linkCrearCuenta">Crear cuenta</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div runat="server" id="blockRegisterSuccess" class="col offset-m2 offset-s1 offset-l3 m8 s10 l6">
            <div class="card teal accent-3">
                <div class="card-content white-text center">
                    <span class="card-title">¡Se ha registrado con éxito!</span>
                </div>
            </div>
        </div>
    </div>

    <div id="ModalProcesamientoDatos" class="modal bottom-sheet green accent-1">
        <div class="modal-content">
            <h4>Procesando datos</h4>
            <p>Estamos recopilando su información, este proceso puede tardar varios minutos.</p>
            <div class="red">
                <div class="progress blue lighten-3">
                    <div class="indeterminate blue darken-3"></div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function trigger() {
            $(function () {
                $('.modal').modal();
                $('#ModalProcesamientoDatos').modal('open');
            });
        }
        function CloseModal() {
            $(function () {
                $('.modal').modal();
                $('#ModalProcesamientoDatos').modal('close');
            });
        }
    </script>

    <%--joder--%>
    <script>var initialPage = <% Response.Write(Session["initialPage"]); %>;</script>
    <script>

        function ComprobarUsuario() {
            var user = $("#Contenido_txtCorreo").val();
            $.ajax({
                type: "POST",
                url: "Acceso.aspx/ComprobarUsuarioKey",
                data: "{paramIdCliente: '" + user + "' }",
                contentType: "application/json",
                dataType: "json",
                success: function (msg) {
                    if (msg.hasOwnProperty("d")) {
                        if (msg.d == true) {
                            $("#Contenido_blockCorreo").css("display", "none");
                            $("#btnHtmlComprobarUsuario").css("display", "none");
                            $("#Contenido_txtCorreo").css("display", "none");
                            $("#Contenido_blockContrasenia").css("display", "block");
                            $("#Contenido_btnLinkCambiarContrasenia").css("display", "inline-block");
                            $("#btnHtmlAcceder").css("display", "inline-block");
                            $("#Contenido_txtContrasenia").focus();
                        } else {
                            $("#Contenido_lblDoesNotExistUser").text("No pudimos encontrar su cuenta de SmartReport");
                        }
                    } else {
                        if (msg == true) {
                            $("#Contenido_blockCorreo").css("display", "none");
                            $("#btnHtmlComprobarUsuario").css("display", "none");
                            $("#Contenido_txtCorreo").css("display", "none");
                            $("#Contenido_blockContrasenia").css("display", "block");
                            $("#Contenido_btnLinkCambiarContrasenia").css("display", "inline-block");
                            $("#btnHtmlAcceder").css("display", "inline-block");
                            $("#Contenido_txtContrasenia").focus();
                        } else {
                            $("#Contenido_lblDoesNotExistUser").text("No pudimos encontrar su cuenta de SmartReport");
                        }
                    }
                }, error: function (msg) {
                    alert("error " + msg.responseText);
                }
            });
        }
        function ComprobarUsuarioKey(e) {
            if (e.keyCode == 13) {
                ComprobarUsuario();
            }
        }
        function Acceder() {
            var user = $("#Contenido_txtCorreo").val();
            var contrasenia = $("#Contenido_txtContrasenia").val();
            $.ajax({
                type: "POST",
                url: "Acceso.aspx/AccederKey",
                data: "{paramIdCliente: '" + user + "', paramContrasenia: '" + contrasenia + "' }",
                contentType: "application/json",
                dataType: "json",
                async: true,
                success: function (msg, data) {
                    switch (msg.d) {
                        case "éxito":
                            if (data) {
                                window.location.href = '<% string cadena = HttpContext.Current.Request.Url + "/Reportes/Dashboard"; Response.Write(cadena.Replace("acceso/", "").Replace("Acceso/", "").Replace("Acceso.aspx/", "").Replace("acceso.aspx/", "")); %>';
                                    return false;
                                }
                                break;
                            case "comprobación de cuenta activada":
                                $("#Contenido_lblErrorPassword").text("Tu cuenta no esta activada, por favor revisa tu correo.");
                                break;
                            case "comprobación de contraseña":
                                $("#Contenido_lblErrorPassword").text("La contraseña es incorrecta. Vuelve a intentarlo.");
                                break;
                        }
                    }, error: function (msg) {
                        alert("error " + msg.responseText);
                    }
                });
        }
        function AccederKey(e) {
            if (e.keyCode == 13) {
                Acceder();
            }
        }
    </script>
    <script src="Scripts/Owner/login.js" type="text/javascript"></script>
</asp:Content>
