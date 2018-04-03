<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="AppWebReportes.Foro.Buscador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" id="navMaster" runat="server" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a href="https://contasis.net/">
                    <img class="nav-link" src="../images/logo-contasis.png" alt="Logo del sistema" /></a></li>
                <li class="nav-item">
                    <br />
                    <a runat="server" id="linkCrearItem" class="nav-link" href="~/Foro/CrearItem.aspx">Crear ítem</a></li>
                <li class="nav-item">
                    <br />
                    <a class="nav-link" runat="server" href="~/Foro/Buscador.aspx">Buscar ítems</a></li>
                <li class="nav-item">
                    <br />
                    <a runat="server" id="linkItemsSinRespuesta" class="nav-link" href="~/Foro/PreguntasSinRespuesta.aspx">Ítems sin respuesta </a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label ID="lblNombreUsuario" runat="server" Style="margin-right: 15px;" Text=""></asp:Label>
                <a runat="server" id="linkSesion" class="btn btn-outline-info my-2 my-sm-0" href="~/Acceso.aspx?tipo=foro">Iniciar sesión</a>
                <a runat="server" id="linkCerrarSesion" class="btn btn-outline-info my-2 my-sm-0" href="~/Acceso.aspx?tipo=foro">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br />
</asp:Content>
