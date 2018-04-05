<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="AppWebReportes.Foro.Detalle" %>

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
            <h2>
                <asp:Label ID="lblTitulo" runat="server"></asp:Label>
            </h2>
        </div>
        <div class="row">
            <div class="col-md-4 col-sm-12">
                <p class="font-weight-bold">
                    Código 
                    <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                </p>
            </div>
            <div class="offset-md-5 col-md-3 col-sm-12">
                <div class="text-center" runat="server" id="blockMarcarVotoUtil">
                    <label class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chbVotoUtilItem" runat="server" AutoPostBack="True" OnCheckedChanged="chbVotoUtilItem_CheckedChanged" />
                        <span class="custom-control-indicator"></span>
                        <span class="custom-control-description" runat="server" id="lblMarcarDesmarcarVoto"></span>
                    </label>
                </div>
            </div>
        </div>
        <div class="row text-justify">
            <asp:Label ID="lblDescripción" runat="server"></asp:Label>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6 col-sm-12">
                <p>Ver quienes aportaron a esta respuesta <a id="btnTriggerContribuyentes" href="javascript: void(0);">Contribuyentes</a></p>
            </div>
            <div class="col-md-3 col-sm-12">
                <p>
                    Votos 
                    <asp:Label ID="lblVotosItem" runat="server"></asp:Label>
                </p>
            </div>
            <div class="col-md-3 col-sm-12">
                <em>Realizado el 
                    <asp:Label ID="lblFechaCreacion" runat="server"></asp:Label>
                </em>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form" id="Formulario">
                    <div class="card card-secondary">
                        <div class="card-block">
                            <h5 class="text-center">¿Está de acuerdo con la respuesta? Haga un comentario.</h5>
                            <div class="form-group">
                                <label for="txtTitulo">Escribir comentario</label>
                                <textarea class="form-control" runat="server" id="txtComentario" placeholder="Déjenos su opinión"></textarea>
                            </div>
                            <div class="float-right">
                                <div class="form-group">
                                    <a href="~/Acceso.aspx?tipo=foro" runat="server" id="linkIniciarSesionComentarios">Debe iniciar sesión para hacer un comentario    </a>
                                    <asp:Button ID="btnHacerComentario" CssClass="btn btn-success" runat="server" Text="Dejar comentario" OnClick="btnHacerComentario_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="offset-md-1">
                <h3 class="text-justify font-weight-bold">Comentarios</h3>
                <div class="row">
                    <div class="col-sm-12">
                        <em>Todos los comentarios deben pasar por un proceso de moderación, por lo cual, su comentario no aparecerá de inmediato, sino que sólo después de que un moderador haya habilitado su comentario.</em>
                        <br /><br />
                        <asp:DataList ID="dtlComentarios" runat="server" ShowFooter="False" DataKeyField="IdComentario" OnItemCommand="dtlComentarios_ItemCommand" RepeatLayout="Flow">
                            <ItemTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="text-justify font-weight-bold">
                                            <asp:Label ID="lblNombres" runat="server" Text='<%# Eval("Nombres") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-justify">
                                            <asp:Label ID="lblDescripcion" CssClass="text-justify" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <em>Realizado el 
                                                        <asp:Label ID="lblFechaCreacion" runat="server" Text='<%# Eval("FechaCreacion") %>'></asp:Label>
                                                    </em>
                                                </div>
                                                <%--<div class="col-md-3">
                                                    <p>
                                                        Votos 
                                                        <asp:Label ID="lblVotos" runat="server" Text='<%# Eval("VotosUtiles") %>'></asp:Label>
                                                    </p>
                                                </div>--%>
                                                <%--<div class="col-md-3">
                                                    <label class="custom-control custom-checkbox">
                                                        <input class="custom-control-input" type="checkbox" /><span class="custom-control-indicator"></span><span class="custom-control-description">Marcar como útil </span>
                                                    </label>
                                                </div>--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:DataList ID="dtlComentariosModeracion" runat="server" ShowFooter="False" DataKeyField="IdComentario" OnItemCommand="dtlComentariosModeracion_ItemCommand" RepeatLayout="Flow">
                            <ItemTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="text-justify font-weight-bold">
                                            <asp:Label ID="lblNombres" runat="server" Text='<%# Eval("Nombres") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-justify">
                                            <asp:Label ID="lblDescripcion" CssClass="text-justify" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>
                                        <em>Realizado el 
                                            <asp:Label ID="lblFechaModificacionComentario" runat="server" Text='<%# Eval("FechaCreacion") %>'></asp:Label>
                                        </em>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMensajeBloqueoComentario" runat="server" Text='<%# Eval("BloqueoEdicion") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnHabilitarComentario" CssClass="btn btn-primary" runat="server" Text="Habilitar pregunta" />
                                    </td>
                                </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalContribuyentes" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Lista de contribuyentes</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <asp:DataList ID="dtlEditores" runat="server" ShowFooter="False" OnItemCommand="dtlEditores_ItemCommand" RepeatLayout="Flow">
                        <ItemTemplate>
                            <table style="width: 100%;" class="table">
                                <tr class="text-justify font-weight-bold">
                                    <td>Contribuyente</td>
                                    <td>Detalle</td>
                                </tr>
                                <tr class="text-justify">
                                    <td>
                                        <asp:Label ID="lblNameContribuyente" runat="server" Text='<%# Eval("Nombres") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDetalleEdicion" runat="server" Text='<%# Eval("DetalleEdicion") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <em>Fecha edición </em>
                                    </td>
                                    <td>
                                        <em> 
                                            <asp:Label ID="lblFechaModificacion" runat="server" Text='<%# Eval("FechaModificación") %>'></asp:Label>
                                        </em>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>

                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        $("#MainContent_chbVotoUtilItem").addClass("custom-control-input");
        $(function () {
            $("#btnTriggerContribuyentes").on("click", function () {
                $('#modalContribuyentes').modal('show');
            });
        });
    </script>
</asp:Content>
