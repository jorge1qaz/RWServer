<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoResultadoPMSF.aspx.cs" Inherits="AppWebReportes.Reportes.EstadoResultadoPMSF" %>
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
    <div class="">
        <div class="row">
            <div class="col-md-12">
                <div class="card text-center">
                    <div class="card-block">
                        <h4 class="card-title">Estado de resultado por función</h4>
                        <table id="tableNaturaleza" class="table table-striped table-bordered display table-responsive table-sm table-striped table-hover">
                            <thead>
                                <tr>
                                    <th>Código</th>
                                    <th>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
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
                                    <td>F005</td>
                                    <td>Ingresos de actividades ordinarias</td>
                                    <td>
                                        <asp:Label ID="F005lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F005lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F105</td>
                                    <td>Costo de ventas</td>
                                    <td>
                                        <asp:Label ID="F105lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F105lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr class="font-weight-bold">
                                    <td>F199</td>
                                    <td>Ganancia (pérdida) bruta</td>
                                    <td>
                                        <asp:Label ID="F199lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F199lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>F200</th>
                                    <th>Gastos operacionales</th>
                                    <th>
                                        <asp:Label ID="F200lbl0" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl1" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl2" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl3" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl4" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl5" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl6" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl7" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl8" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl9" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl10" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F200lbl11" runat="server"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td>F206</td>
                                    <td>Gastos de ventas y distribución</td>
                                    <td>
                                        <asp:Label ID="F206lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F206lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F211</td>
                                    <td>Gastos de administración</td>
                                    <td>
                                        <asp:Label ID="F211lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F211lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F212</td>
                                    <td>Ganancia(pérdida) baja activos financieros</td>
                                    <td>
                                        <asp:Label ID="F212lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F212lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F213</td>
                                    <td>Otros ingresos operativos</td>
                                    <td>
                                        <asp:Label ID="F213lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F213lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F214</td>
                                    <td>Otros gastos operativos</td>
                                    <td>
                                        <asp:Label ID="F214lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F214lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F215</td>
                                    <td>Otras ganancias (pérdidas)  </td>
                                    <td>
                                        <asp:Label ID="F215lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F215lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>F299</th>
                                    <th>Ganancia (pérdida) por actividades de operaciones</th>
                                    <th>
                                        <asp:Label ID="F299lbl0" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl1" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl2" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl3" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl4" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl5" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl6" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl7" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl8" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl9" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl10" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F299lbl11" runat="server"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td>F320</td>
                                    <td>Ingresos financieros</td>
                                    <td>
                                        <asp:Label ID="F320lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F320lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F350</td>
                                    <td>Gastos financieros</td>
                                    <td>
                                        <asp:Label ID="F350lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F350lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F380</td>
                                    <td>Diferencias de cambio neto</td>
                                    <td>
                                        <asp:Label ID="F380lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F380lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F403</td>
                                    <td>Otros ingresos (gastos) de las subsidiar</td>
                                    <td>
                                        <asp:Label ID="F403lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F403lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F405</td>
                                    <td>Ganancias (pérdidas) que surgen de la diferencia</td>
                                    <td>
                                        <asp:Label ID="F405lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F405lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>F415</td>
                                    <td>Diferencia entre el importe en libros</td>
                                    <td>
                                        <asp:Label ID="F415lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F415lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>F699</th>
                                    <th>Resultado antes de impuesto a las ganancias</th>
                                    <th>
                                        <asp:Label ID="F699lbl0" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl1" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl2" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl3" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl4" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl5" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl6" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl7" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl8" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl9" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl10" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F699lbl11" runat="server"></asp:Label></th>
                                </tr>
                                <tr>
                                    <td>F710</td>
                                    <td>Gasto por impuesto a las ganancias</td>
                                    <td>
                                        <asp:Label ID="F710lbl0" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl7" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl8" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl9" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl10" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="F710lbl11" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>F799</th>
                                    <th>Ganancia(pérdida) neta operaciones contable</th>
                                    <th>
                                        <asp:Label ID="F799lbl0" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl1" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl2" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl3" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl4" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl5" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl6" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl7" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl8" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl9" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl10" runat="server"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="F799lbl11" runat="server"></asp:Label></th>
                                </tr>
                                    <tr>
                                        <td>F805</td>
                                        <td>Ganancia (pérdida) impuesto ganancia de operaciones diversos</td>
                                        <td>
                                            <asp:Label ID="F805lbl0" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl1" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl2" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl3" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl4" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl5" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl6" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl7" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl8" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl9" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl10" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="F805lbl11" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <th>F999</th>
                                        <th>Ganancia (pérdida) neta del ejercicio</th>
                                        <th>
                                            <asp:Label ID="F999lbl0" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl1" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl2" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl3" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl4" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl5" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl6" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl7" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl8" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl9" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl10" runat="server"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="F999lbl11" runat="server"></asp:Label></th>
                                    </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>var moneda = "<% Response.Write(Session["EDRPMSTipoMoneda"].ToString()); %>";</script>
    <script>var tipoReporte = "<% Response.Write(Session["EDRPMSTipoReporte"].ToString()); %>"; var ruta = "../..";</script>
    <script src="../Scripts/Owner/RW-008.js"></script>
    <script src="../Scripts/Owner/general.js"></script>
</asp:Content>
