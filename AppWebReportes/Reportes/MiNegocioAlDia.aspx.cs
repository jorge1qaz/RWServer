using System;
using BusinessLayer;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace AppWebReportes.Reportes
{
    public partial class MiNegocioAlDia : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        Calculos cal = new Calculos();
        MergeTables mergeTables = new MergeTables();

        double totalVentas;
        double totalCajaBancosHaber;
        double totalCajaBancosDebe;
        decimal totalCajaBancos;
        double totalCobrarHaber;
        double totalCobrarDebe;
        decimal totalCobrar;
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null || Request.QueryString["idCompany"] == null || Request.QueryString["year"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");

            if (!Page.IsPostBack)
            {
                lblResultado.Text = "0.0";
                lblVentas.Text = "0.0";
                lblCajaBancos.Text = "0.0";
                lblDeben.Text = "0.0";
                lbldebo.Text = "0.0";
            }
        }
        public void GetTotalForVentas()
        {
            String rootPath = Server.MapPath("~");
            string JsonN005 = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "N005.json").Trim().Replace("\\'", "'");
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonN005);
            DataTable datatableMes1 = dataSet.Tables["1"];
            DataTable datatableMes2 = dataSet.Tables["2"];
            DataTable datatableMes3 = dataSet.Tables["3"];
            DataTable datatableMes4 = dataSet.Tables["4"];
            DataTable datatableMes5 = dataSet.Tables["5"];
            DataTable datatableMes6 = dataSet.Tables["6"];
            DataTable datatableMes7 = dataSet.Tables["7"];
            DataTable datatableMes8 = dataSet.Tables["8"];
            DataTable datatableMes9 = dataSet.Tables["9"];
            DataTable datatableMes10 = dataSet.Tables["10"];
            DataTable datatableMes11 = dataSet.Tables["11"];
            DataTable datatableMes12 = dataSet.Tables["12"];
            #region Total del mes
            switch (lstMes.SelectedValue.ToString())
            {
                case "1":
                    try
                    { totalVentas = datatableMes1.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "2":
                    try
                    { totalVentas = datatableMes2.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "3":
                    try
                    { totalVentas = datatableMes3.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "4":
                    try
                    { totalVentas = datatableMes4.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "5":
                    try
                    { totalVentas = datatableMes5.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "6":
                    try
                    { totalVentas = datatableMes6.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "7":
                    try
                    { totalVentas = datatableMes7.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "8":
                    try
                    { totalVentas = datatableMes8.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "9":
                    try
                    { totalVentas = datatableMes9.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "10":
                    try
                    { totalVentas = datatableMes10.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "11":
                    try
                    { totalVentas = datatableMes11.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
                case "12":
                    try
                    { totalVentas = datatableMes12.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    lblVentas.Text = totalVentas.ToString();
                    break;
            }
            #endregion
        }
        public void GetTotalForCajaBancos() {
            string JsonA105 = GetPathFile("A105");
            DataTable tabla = new DataTable();
            tabla = mergeTables.GetAccumulatedTables(JsonA105, lstMes.SelectedValue.ToString());
            decimal total = 0;
            try
            {
                DataTable ListCuentas = new DataTable();
                ListCuentas = mergeTables.GetListDist(tabla, "a");
                total = mergeTables.GetTotalByTable(tabla, ListCuentas, "a", "b", "c", true, false);
                lblCajaBancos.Text = total.ToString();
            }
            catch (Exception)
                { lblCajaBancos.Text = "0.0"; }
        }
        public void GetTotalForResultado()
        {
            string JsonTableN005 = GetPathFile("N005");
            string JsonTableN010 = GetPathFile("N010");
            string JsonTableN103 = GetPathFile("N103");
            string JsonTableN105 = GetPathFile("N105");
            string JsonTableN110 = GetPathFile("N110");
            string JsonTableN205 = GetPathFile("N205");
            string JsonTableN215 = GetPathFile("N215");
            string JsonTableN225 = GetPathFile("N225");
            string JsonTableN235 = GetPathFile("N235");
            string JsonTableN305 = GetPathFile("N305");
            string JsonTableN310 = GetPathFile("N310");
            string JsonTableN315 = GetPathFile("N315");
            string JsonTableN405 = GetPathFile("N405");
            string JsonTableN410 = GetPathFile("N410");
            string JsonTableN415 = GetPathFile("N415");
            string JsonTableN420 = GetPathFile("N420");
            string JsonTableN425 = GetPathFile("N425");
            string JsonTableN430 = GetPathFile("N430");
            string JsonTableN505 = GetPathFile("N505");
            string JsonTableN510 = GetPathFile("N510");
            string JsonTableN515 = GetPathFile("N515");
            string JsonTableN525 = GetPathFile("N525");
            string JsonTableN805 = GetPathFile("N805");
            string JsonTableN810 = GetPathFile("N810");

            string JsonTableA105 = GetPathFile("A105");
            string JsonTableN015 = GetPathFile("N015");
            string JsonTableN210 = GetPathFile("N210");
            string JsonTableN220 = GetPathFile("N220");
            string JsonTableN230 = GetPathFile("N230");
            string JsonTableN520 = GetPathFile("N520");


            decimal sumN005 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN005, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN010 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN010, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN103 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN103, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN105 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN105, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN110 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN110, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN205 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN205, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN215 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN215, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN225 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN225, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN235 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN235, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN305 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN305, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN310 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN310, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN315 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN315, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN405 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN405, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN410 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN410, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN415 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN415, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN420 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN420, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN425 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN425, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN430 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN430, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN505 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN505, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN510 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN510, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN515 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN515, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN525 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN525, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN805 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN805, lstMes.SelectedValue.ToString(), "a"));
            decimal sumN810 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN810, lstMes.SelectedValue.ToString(), "a"));

            decimal sumA105 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA105, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumN015 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN015, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumN210 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN210, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumN220 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN220, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumN230 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN230, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumN520 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableN520, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));

            decimal margenComercial = 0;
            decimal produccionDelEjercicio = 0;
            decimal valorAgregado = 0;
            decimal exdenteBrutoDeExplotacion = 0;
            decimal resultadoDeExplotacion = 0;
            decimal resultadoAntesDeParticipacionesImpuestos = 0;
            decimal resultadoDelEjercicio = 0;
            margenComercial = sumN005 - sumN010 + (-1)*(sumN015);
            produccionDelEjercicio = margenComercial + sumN103 + sumN105 + sumN110;
            valorAgregado = produccionDelEjercicio - sumN205 + (-1) * (sumN220) - sumN225 + (-1) * (sumN230) - sumN235;
            exdenteBrutoDeExplotacion = valorAgregado + sumN305 - sumN310 - sumN315;
            resultadoDeExplotacion = exdenteBrutoDeExplotacion + sumN405 + sumN410 + sumN415 - sumN420 - sumN425 - sumN430;
            resultadoAntesDeParticipacionesImpuestos = resultadoDeExplotacion + sumN505 - sumN510 + sumN515 + (-1) * (sumN520) - sumN525;
            resultadoDelEjercicio = resultadoAntesDeParticipacionesImpuestos - sumN805 - sumN810;
            
            lblResultado.Text = resultadoAntesDeParticipacionesImpuestos.ToString();
        }
        public void GetTotalByCuentasCobrarPagar() {
            string JsonTableA115 = GetPathFile("A115");
            string JsonTableA120N = GetPathFileN("A120");
            string JsonTableA125 = GetPathFile("A125");
            decimal sumA115 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA115, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumA120N = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA120N, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumA125 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA125, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal totalCuentasPorCobrar = 0;
            totalCuentasPorCobrar = sumA115 + sumA120N + sumA125;

            string JsonTableP120N = GetPathFileN("P120");
            string JsonTableP120 = GetPathFile("P120");
            string JsonTableP110 = GetPathFile("P110");
            string JsonTableP121 = GetPathFile("P121");
            decimal sumP120N = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP120N, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumP120 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP120, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumP110 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP110, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            decimal sumP121 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP121, lstMes.SelectedValue.ToString(), "a", "b", "c", false, false));
            //totalCuentasPorCobrar = sumP120N + sumP120 + sumP110 + sumP121;
            //totalCuentasPorCobrar = totalCuentasPorCobrar * -1;
            lblDeben.Text = totalCuentasPorCobrar.ToString();

        }
        public string GetPathFile(string nameFile) {
            String rootPath = Server.MapPath("~");
            string JsonTable = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonTable;
        }
        public string GetPathFileN(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonTable = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/NRubro" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonTable;
        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GetTotalForVentas();
            GetTotalForCajaBancos();
            GetTotalForResultado();
            GetTotalByCuentasCobrarPagar();
        }
    } 
}