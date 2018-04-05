<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="AppWebReportes.Foro.Resultados" %>
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
    <div class="container">
        <div class="row">
            <div class="col text-center">
                <h2>Resultados de 
                    <em>
                        <asp:Label ID="lblQuery" runat="server" ></asp:Label>
                    </em>
                </h2>
                <p class="text-warning">
                    <asp:Label ID="lblMensajeCeroResultados" runat="server" Text="Lo sentimos, no encontramos ningún resultado para su búsqueda."></asp:Label>
                </p>
            </div>
        </div>
        <div class="row">

            <div class="offset-md-2 col-md-8 offset-sm-0 col-sm-12">
                <asp:DataList ID="dtlListaResultados" runat="server" RepeatLayout="Flow" ShowFooter="False" DataKeyField="IdForo" OnItemCommand="dtlListaResultados_ItemCommand">
                    <ItemTemplate>
                        <table>
                            <tbody>
                                <tr>
                                    <td class="font-weight-bold">
                                        <asp:LinkButton ID="linkVerDetalle" runat="server">
                                            <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("Codigo") %>'></asp:Label>&nbsp;
                                            <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDescripcion" CssClass="text-justify" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <em>Fecha de creación 
                                            <asp:Label ID="lblFechaCreacion" runat="server" Text='<%# Eval("FechaCreacion") %>'></asp:Label>
                                        </em>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Aplica para 
                                        <asp:Label ID="lblProducto" runat="server" CssClass="font-weight-bold" Text='<%# Eval("NombreProducto") %>'></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
