<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearItem.aspx.cs" Inherits="AppWebReportes.Foro.CrearItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" id="navMaster" runat="server" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a href="https://contasis.net/">
                    <img class="nav-link" src="../images/logo-contasis.png" alt="Logo del sistema" /></a></li>
                <li class="nav-item">
                    <br />
                    <a runat="server" id="linkCrearItem" class="nav-link" href="javascript: void(0);">Crear ítem</a></li>
                <li class="nav-item">
                    <br />
                    <a class="nav-link" href="javascript: void(0);">Buscar ítems</a></li>
                <li class="nav-item">
                    <br />
                    <a runat="server" id="linkItemsSinRespuesta" class="nav-link" href="javascript: void(0);">Ítems sin respuesta </a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label ID="lblNombreUsuario" runat="server" Style="margin-right: 15px;" Text=""></asp:Label><a class="btn btn-outline-info my-2 my-sm-0" href="~/Acceso.aspx" runat="server">Iniciar sesión</a>
            </div>
        </div>
    </nav>
    <br />
    <div class="container">
        <div class="row">
            <div class="offset-md-1 offset-sm-0 col-md-10 col-sm-12">
                <div class="form" id="Formulario">
                    <div class="card card-secondary bg-faded">
                        <div class="card-block">
                            <h5 class="text-center">Creación de ítem</h5>
                            <div class="text-center"><em>Los campos marcados con un asterisco (*) son obligatorios.</em></div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="txtTitulo">Título *</label>
                                        <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Ingrese el título"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label for="txtDescripcion">Descripción</label>
                                        <textarea class="form-control" runat="server" id="txtDescripcion" placeholder="Ingrese la descripción" rows="10"></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label for="txtCodigo">Código</label>
                                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código del ítem"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label for="lstRol">Producto al que pertenece *</label>
                                        <asp:DropDownList CssClass="form-control" ID="lstProductos" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-12">
                                    <%--<div class="row">
                                        <div class="col-md-8">
                                            <div class="form-group ui-widget">
                                                <label for="tags">Selecionar etiqueta </label>
                                                <asp:TextBox ID="txtTag" runat="server" CssClass="form-control" placeholder="Ingrese la etiqueta"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <br />
                                            <button id="btnRegistrarTag" class="btn btn-success">Agregar</button>
                                        </div>
                                    </div>--%>
                                    <div class="form-group">
                                        <div class="text-center">
                                            <label class="custom-control custom-checkbox">
                                                <asp:CheckBox ID="chbMarcadaComoRespuesta" runat="server" />
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Marcar como respondido  </span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 offset-md-3 col-sm-12 offset-sm-0">
                                    <div class="form-group">
                                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary btn-block" OnClick="BtnRegistrar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="modal fade" id="modalTags" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Agregar etiqueta</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                </div>
                <div class="modal-body">
                    <div class="form">
                        <div class="form-group">
                            <label class="text-justify">Las etiquetas o tags son palabras que agrupan artículos o ítems relacionados. Son palabras que los definen de forma más sencilla, además de proporcionar más facilidad en las búsquedas. <em>Recuerde escribir en minúsculas y no dejar espacios, o si prefiere separar palabras hágalo mediante guiones.</em></label>
                        </div>
                        <div class="form-group">
                            <label class="col-form-label" for="txtAddTag">Etiqueta</label>
                            <asp:TextBox ID="txtAddTag" runat="server" CssClass="form-control" placeholder="Escriba la etiqueta correspondiente"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cerrar</button>
                    <button class="btn btn-primary" type="button" id="btnRegistrarEtiqueta">Guardar etiqueta</button>
                    <%--evento con ajax, por eso el boton es html--%>
                </div>
            </div>
        </div>
    </div>
    <script>
        $("#MainContent_chbMarcadaComoRespuesta").addClass("custom-control-input");
        $(function () {
            $("#triggerModalTag").on("click", function () {
                $('#modalTags').modal('show');
            });
        });
    </script>
    <script>
        var availableTags = <% Response.Write(jsonListaTags.ToString());%>;
    </script>
    <script src="../Scripts/Owner/FORO-001.js"></script>

</asp:Content>
