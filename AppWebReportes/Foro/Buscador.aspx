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


    <link rel="stylesheet" href="../Content/owner.css" />
    <style>
        .container-text-parallax {
            position: absolute;
            margin: 8% 15%;
            padding: 1%;
            color: white !important;
            background-color: rgba(0,0,0,0.4);
            filter: alpha(opacity=50);
            border-radius: 10px;
            z-index: 1000;
        }

        @media (max-width: 700px) {
            .container-text-parallax {
                margin: 5% 1%;
            }
        }
    </style>
    <div class="container-text-parallax">
        <br />
        <h2 class="text-white text-center">Le damos la bienvenida al soporte en línea de nuestros productos Contasis</h2>
        <br />
        <div class="row">
            <div class="col-md-6 offset-md-2 col-sm-12 offset-sm-0">
                <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" placeholder="¿Cómo podemos ayudarle?" autofocus="autofocus"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-12">
                <asp:Button ID="btnBuscar" CssClass="btn btn-primary form-control" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />
    </div>
    <img class="img-fluid" src="../Images/foroBuscar.jpg" style="width: 100%; max-height: 500px; object-fit: cover;" /><br />
    <br />
    <br />
    <br />

</asp:Content>
