<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EFEstadoSitucionFinanciera.aspx.cs" Inherits="AppWebReportes.Reportes.EstadosFinancieros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <nav runat="server" id="navMaster" class="navbar navbar-toggleable-md navbar-light bg-faded bg-dark" style="margin-top: -50px;">
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active"><a class="nav-link disabled" href="#"><span class="sr-only">(current)</span></a></li>
                <li class="nav-item"><a runat="server" class="nav-link" href="~/Reportes/Dashboard.aspx">Inicio</a></li>
            </ul>
            <div class="form-inline my-2 my-lg-0">
                <asp:Label runat="server" ID="lblNombreUsuario" Style="margin-right: 15px;" Text=""></asp:Label>
                <a href="~/Acceso.aspx" class="btn btn-outline-info my-2 my-sm-0" runat="server">Cerrar sesión</a>
            </div>
        </div>
    </nav>
    <br />
    <br />
    <div class="container">
			<div class="row">
				<div class="col-md-3 col-sm-12">
					<div class="card card-inverse card-info text-center">
						<div class="card-block">
							<div class="form-group">
                                <label for="lstTipoMoneda">Tipo de moneda</label>
                                <asp:DropDownList ID="lstTipoMoneda" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="true">Nuevos soles</asp:ListItem>
                                    <asp:ListItem Value="false">Dolares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="lstMes">Mes de proceso</label>
                                <asp:DropDownList ID="lstMes" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstMes_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Enero</asp:ListItem>
                                    <asp:ListItem Value="2">Febrero</asp:ListItem>
                                    <asp:ListItem Value="3">Marzo</asp:ListItem>
                                    <asp:ListItem Value="4">Abril</asp:ListItem>
                                    <asp:ListItem Value="5">Mayo</asp:ListItem>
                                    <asp:ListItem Value="6">Junio</asp:ListItem>
                                    <asp:ListItem Value="7">Julio</asp:ListItem>
                                    <asp:ListItem Value="8">Agosto</asp:ListItem>
                                    <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </div>
							<div class="form-group">
                                <asp:Button ID="btnGenerarReporte" CssClass="btn btn-success form-control" runat="server" Text="Generar reporte" />
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-9 col-sm-12">
					<div class="card card-outline-secondary text-center">
						<div class="card-block">
							<h4 class="card-title">Estado de situación financiera</h4>
							<table class="table table-bordered table-responsive table-hover table-sm table-striped">
								<tbody>
									<tr>
										<th class="text-center" colspan="2">Activo</th>
										<th class="text-center" colspan="2">Pasivo y patrimonio </th>
									</tr>
									<tr>
										<th class="text-center" colspan="2">Activo corriente</th>
										<th class="text-center" colspan="2">Pasivo corriente</th>
									</tr>
									<tr>
										<td>
											<label>Efectivo y equivalentes de efectivo</label>
										</td>
										<td><asp:Label ID="lblA105" runat="server"></asp:Label></td>
										<td>
											<label>Otros pasivos financieros </label>
										</td>
										<td>
                                    <asp:Label ID="lblA110" runat="server" Text="Label"></asp:Label></td>
									</tr>
									<tr>
										<td>
											<label>Otros activos financieros</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Cuentas por pagar comerciales</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Cuentas por cobrar comerciales (neto)</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Otras cuentas por pagar</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Otras cuentas por cobrar (neto)</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Cuentas por pagar a entidades relacionadas</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Cuentas por cobrar a entidades relacionadas</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Ingresos diferidos</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Anticipos</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Provisión por beneficios a los empleados</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Inventarios</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Otras provisiones</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Activos biológicos </label>
										</td>
										<td><span></span></td>
										<td>
											<label>Pasivos por impuestos a las ganancias </label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Activos por impuestos a las ganancias </label>
										</td>
										<td><span></span></td>
										<td>
											<label>Otros pasivos no financieros</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Otros activos no financieros</label>
										</td>
										<td><span></span></td>
										<th class="text-center">
											<label>Total pasivo corriente distintos mantenidos para la venta</label>
										</th>
										<td><span></span></td>
									</tr>
									<tr>
										<th class="text-center"> 
											<label>Total activos corrientes distintos mantenidos para la venta</label>
										</th>
										<th class="text-center"><span></span></th>
										<td>
											<label>Pasivo incluido en activo mantenido para la venta</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Activos no corrientes mantenidos para la venta</label>
										</td>
										<td><span></span></td>
										<th class="text-center">
											<label>Total pasivos corrientes</label>
										</th>
										<th class="text-center"><span></span></th>
									</tr>
									<tr>
										<td>
											<label>Activos no corrientes para distribuir a propiedades</label>
										</td>
										<td><span></span></td>
										<th class="text-center">
											<label>Pasivos no corrientes</label>
										</th>
										<th class="text-center"><span></span></th>
									</tr>
									<tr>
										<th class="text-center">
											<label>Activo no corriente mantenidos para la venta y operaciones discontinuadas</label>
										</th>
										<th class="text-center"><span></span></th>
										<td>
											<label>Otros pasivos financieros</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<th class="text-center">
											<label>Total activo corriente</label>
										</th>
										<th class="text-center"><span></span></th>
										<td>
											<label>Cuentas por pagar comerciales</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<th class="text-center">
											<label>Activos no corrientes</label>
										</th>
										<th class="text-center"><span></span></th>
										<td>
											<label>Otras cuentas por pagar</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Otros activos financieros</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Cuentas por pagar a entidades relacionadas</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Inversiones en subsidiarias, negocios con activos</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Ingresos diferidos</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Cuentas por cobrar comerciales </label>
										</td>
										<td><span></span></td>
										<td>
											<label>Provisión por beneficios a los empleados</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Otras cuentas por cobrar</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Otras provisiones</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Cuentas por cobrar a entidades relacionadas</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Pasivos por impuestos diferidos</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Anticipos</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Otros pasivos no financieros</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Activos biológicos</label>
										</td>
										<td><span></span></td>
										<th class="text-center">
											<label>Total pasivos no corrientes</label>
										</th>
										<th class="text-center"><span></span></th>
									</tr>
									<tr>
										<td>
											<label>Propiedades de inversión</label>
										</td>
										<td><span></span></td>
										<th class="text-center">
											<label>Total pasivo</label>
										</th>
										<th class="text-center"><span></span></th>
									</tr>
									<tr>
										<td>
											<label>Propiedades plantas y equipos (neto)</label>
										</td>
										<td><span></span></td>
										<th class="text-center">
											<label>Patrimonio</label>
										</th>
										<th class="text-center"><span></span></th>
									</tr>
									<tr>
										<td>
											<label>Activos intangibles distintos de la plusvalía</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Capital emitido</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Activos por impuestos diferidos</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Primas de emisión</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Plusvalía</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Acciones de inversión</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<td>
											<label>Otros activos no financieros</label>
										</td>
										<td><span></span></td>
										<td>
											<label>Acciones propias en cartera</label>
										</td>
										<td><span></span></td>
									</tr>
									<tr>
										<th class="text-center">
											<label>Total activo</label>
										</th>
										<th class="text-center"><span></span></th>
										<td>
											<label></label>
										</td>
										<td><span></span></td>
									</tr>
								</tbody>
							</table>
						</div>
					</div>
				</div>
			</div>
		</div>
</asp:Content>
