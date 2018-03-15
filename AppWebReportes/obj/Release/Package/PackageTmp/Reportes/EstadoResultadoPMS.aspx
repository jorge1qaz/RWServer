<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoResultadoPMS.aspx.cs" Inherits="AppWebReportes.Reportes.EstadoResultadoPMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a runat="server" class="nav-link" href="~/Reportes/Dashboard.aspx"><i class="material-icons left" id="home" data-toggle="tooltip" data-placement="right" title="Regresar al inicio">home</i></a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <div class=""> <%--Se esta ocultando la clase "container" para hacer mas grande el reporte--%>
        <div class="row">
            <div class="col-md-12">
                <div class="card text-center">
                    <div class="card-block">
                        <h4 class="card-title">Estado de resultado por naturaleza</h4>
                        <table id="tableNaturaleza" class="table table-striped table-bordered display table-responsive table-sm table-striped table-hover" width="100%">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th id="labelTittle">Descripción</th>
                                    <th>Enero</th>
                                    <th>Febrero</th>
                                    <th>Marzo</th>
                                    <th>Abril</th>
                                    <th>Mayo</th>
                                    <th>Junio</th>
                                    <th>Julio</th>
                                    <th>Agosto</th>
                                    <th>Setiembre</th>
                                    <th>Octubre</th>
                                    <th>Noviembre</th>
                                    <th>Diciembre</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>N005</td>
                                    <td>Venta de mercadería</td>
                                    <td>
                                        <asp:Label ID="N005lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N005lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N010</td>
                                    <td>Compra de mercadería</td>
                                    <td>
                                        <asp:Label ID="N010lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N010lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N015</td>
                                    <td>Variación de  mercadería</td>
                                    <td>
                                        <asp:Label ID="N015lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N015lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N099</td>
                                    <td>Margen comercial</td>
                                    <td>
                                        <asp:Label ID="N099lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N099lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N103</td>
                                    <td>Venta de productos terminados, sub producto</td>
                                    <td>
                                        <asp:Label ID="N103lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N103lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N105</td>
                                    <td>Variación  de  la  producción  almacenado</td>
                                    <td>
                                        <asp:Label ID="N105lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N105lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N110</td>
                                    <td>Producción activo inmovilizado</td>
                                    <td>
                                        <asp:Label ID="N110lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N110lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N199</td>
                                    <td>Producción del ejercicio</td>
                                    <td>
                                        <asp:Label ID="N199lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N199lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N205</td>
                                    <td>Compra de materias primas </td>
                                    <td>
                                        <asp:Label ID="N205lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N205lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N210</td>
                                    <td>Variación materias primas </td>
                                    <td>
                                        <asp:Label ID="N210lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N210lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N215</td>
                                    <td>Compra de  materiales  auxiliares</td>
                                    <td>
                                        <asp:Label ID="N215lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N215lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N220</td>
                                    <td>Variación de materiales auxiliares </td>
                                    <td>
                                        <asp:Label ID="N220lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N220lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N225</td>
                                    <td>Compra de  envases  y  embalajes</td>
                                    <td>
                                        <asp:Label ID="N225lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N225lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N230</td>
                                    <td>Variación  de  envases y  embalajes   </td>
                                    <td>
                                        <asp:Label ID="N230lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N230lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N235</td>
                                    <td>Servicios  prestados por  terceros </td>
                                    <td>
                                        <asp:Label ID="N235lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N235lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N299</td>
                                    <td>Valor agregado </td>
                                    <td>
                                        <asp:Label ID="N299lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N299lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N305</td>
                                    <td>Subsidios  gubernamentales</td>
                                    <td>
                                        <asp:Label ID="N305lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N305lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N310</td>
                                    <td>Cargas  de  personal  </td>
                                    <td>
                                        <asp:Label ID="N310lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N310lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N315</td>
                                    <td>Tributos</td>
                                    <td>
                                        <asp:Label ID="N315lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N315lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N399</td>
                                    <td>Excedente bruto de explotación </td>
                                    <td>
                                        <asp:Label ID="N399lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N399lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N405</td>
                                    <td>Descuentos rebajas y bonificación obtenidos </td>
                                    <td>
                                        <asp:Label ID="N405lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N405lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N410</td>
                                    <td>Otros ingresos de gestión</td>
                                    <td>
                                        <asp:Label ID="N410lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N410lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N415</td>
                                    <td>Ganancia por medición de activos no financieros</td>
                                    <td>
                                        <asp:Label ID="N415lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N415lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N420</td>
                                    <td>Otros gastos de gestión</td>
                                    <td>
                                        <asp:Label ID="N420lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N420lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N425</td>
                                    <td>Perdida por medición de activos no financieros</td>
                                    <td>
                                        <asp:Label ID="N425lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N425lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N430</td>
                                    <td>Valuación y deterioro de activos y  provisiones</td>
                                    <td>
                                        <asp:Label ID="N430lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N430lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N499</td>
                                    <td>Resultado de explotación</td>
                                    <td>
                                        <asp:Label ID="N499lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N499lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N505</td>
                                    <td>Ingresos financieros</td>
                                    <td>
                                        <asp:Label ID="N505lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N505lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N510</td>
                                    <td>Gastos financieros</td>
                                    <td>
                                        <asp:Label ID="N510lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N510lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N515</td>
                                    <td>Costos financiación capitalizados</td>
                                    <td>
                                        <asp:Label ID="N515lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N515lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N520</td>
                                    <td>Costo neto enajenación activos inmovilizados</td>
                                    <td>
                                        <asp:Label ID="N520lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N520lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N525</td>
                                    <td>Donaciones y sanciones administrativas financieras</td>
                                    <td>
                                        <asp:Label ID="N525lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N525lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N599</td>
                                    <td>Resultado antes de participaciones e impuestos </td>
                                    <td>
                                        <asp:Label ID="N599lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N599lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N805</td>
                                    <td>Participación de los Trabajadores </td>
                                    <td>
                                        <asp:Label ID="N805lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N805lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>N810</td>
                                    <td>Impuesto a la Renta</td>
                                    <td>
                                        <asp:Label ID="N810lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N810lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr style="font-weight: bold;">
                                    <td>N999</td>
                                    <td>Resultado del ejercicio</td>
                                    <td>
                                        <asp:Label ID="N999lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="N999lbl11" runat="server"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>var moneda = "<% Response.Write(Session["EDRPMSTipoMoneda"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["EDRPMSTipoReporte"].ToString()); %>";</script>
    <script src="../Scripts/Owner/RW-008.js"></script>
</asp:Content>
