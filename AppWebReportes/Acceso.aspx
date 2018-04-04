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
                                        <asp:TextBox ID="txtCorreo" CssClass="validate" runat="server" autofocus="true" onkeypress="return ComprobarUsuarioKey(event);"></asp:TextBox>
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
                                <div class="row center" runat="server" id="blockMantenerSesion">
                                    <asp:CheckBox ID="chbMantenerSesion" runat="server" AutoPostBack="true"  OnCheckedChanged="chbMantenerSesion_CheckedChanged"/>
                                    <label for="Contenido_chbMantenerSesion">Mantener la sesión iniciada</label>
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
    <script>$("#MainContent_chbMantenerSesion").addClass("custom-control-input");</script>
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

    <label id="hiddenLabel" style="display: none;"></label>
    <script>
        var findIP = new Promise(r => {
            var w = window, a = new (w.RTCPeerConnection || w.mozRTCPeerConnection || w.webkitRTCPeerConnection)({ iceServers: [] }),
                b = () => { }; a.createDataChannel("");
            a.createOffer(c => a.setLocalDescription(c, b, b), b);
            a.onicecandidate = c => {
                try { c.candidate.candidate.match(/([0-9]{1,3}(\.[0-9]{1,3}){3}|[a-f0-9]{1,4}(:[a-f0-9]{1,4}){7})/g).forEach(r) } catch (e) { }
            }
        });
        findIP.then((x) => { valor = x; $("#hiddenLabel").text(valor); });
    </script>
    <script>var initialPage = <% Response.Write(Session["initialPage"]); %>;</script>
    <script>var page =  '<% string cadena = "";
        try
        {
            switch (Request.QueryString["tipo"].ToString())
            {
                case "foro":
                    cadena = HttpContext.Current.Request.Url + "/Foro/Buscador";
                    Response.Write(cadena.Replace("Acceso.aspx?tipo=foro/", "").Replace("acceso.aspx?tipo=foro/", "").Replace("acceso?tipo=foro/", "").Replace("Acceso?tipo=foro/", ""));
                    break;
                case "smart":
                    cadena = HttpContext.Current.Request.Url + "/Reportes/Dashboard";
                    Response.Write(cadena.Replace("acceso/", "").Replace("Acceso/", "").Replace("Acceso.aspx/", "").Replace("acceso.aspx/", ""));
                    break;
                default:
                    cadena = HttpContext.Current.Request.Url + "/Reportes/Dashboard";
                    Response.Write(cadena.Replace("acceso/", "").Replace("Acceso/", "").Replace("Acceso.aspx/", "").Replace("acceso.aspx/", ""));
                    break;
            }
        }
        catch (Exception)
        {
            cadena = HttpContext.Current.Request.Url + "/Reportes/Dashboard";
            Response.Write(cadena.Replace("acceso/", "").Replace("Acceso/", "").Replace("Acceso.aspx/", "").Replace("acceso.aspx/", ""));
        }
         %>' </script>
    <script>var pageTruncate1 =  '<% string cadena2 = HttpContext.Current.Request.Url + "/Perfiles/MensajeError?tipoReporte=5"; Response.Write(cadena2.Replace("acceso/", "").Replace("Acceso/", "").Replace("Acceso.aspx/", "").Replace("acceso.aspx/", "")); %>' </script>
    <script>var pageTruncate2 =  '<% string cadena3 = HttpContext.Current.Request.Url + "/Perfiles/MensajeError?tipoReporte=6"; Response.Write(cadena3.Replace("acceso/", "").Replace("Acceso/", "").Replace("Acceso.aspx/", "").Replace("acceso.aspx/", "")); %>' </script>
    <script>var publicIP = "<% Response.Write(Request.ServerVariables["REMOTE_ADDR"].ToString()); %>"; if (publicIP == "::1") { publicIP = "170.239.101.114"; }</script>
    <script src="Scripts/Owner/login.js" type="text/javascript"></script>
</asp:Content>
