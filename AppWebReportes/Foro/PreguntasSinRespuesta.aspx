<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreguntasSinRespuesta.aspx.cs" Inherits="AppWebReportes.Foro.PreguntasSinRespuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col text-center">
                <h2>Ítems sin responder </h2>
            </div>
        </div>
        <div class="row">

            <div class="offset-md-2 col-md-8 offset-sm-0 col-sm-12">
                <asp:DataList ID="dtlListaPreguntasSinRespuesta" runat="server" RepeatLayout="Flow" ShowFooter="False" DataKeyField="IdForo" OnItemCommand="dtlListaPreguntasSinRespuesta_ItemCommand">
                    <ItemTemplate>
                        <table>
                            <tbody>
                                <tr>
                                    <td class="font-weight-bold">
                                        <asp:LinkButton ID="LinkButton1" runat="server">
                                            <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("Codigo") %>'></asp:Label>&nbsp;
                                            <asp:Label ID="lblTitulo" runat="server" Text='<%# Eval("Titulo") %>'></asp:Label>
                                        </asp:LinkButton>
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
