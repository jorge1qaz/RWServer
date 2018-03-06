using System;
using BusinessLayer;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Globalization;

namespace AppWebReportes.Reportes
{
    public partial class MiNegocioAlDia : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        double totalVentas;
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
                Session["Resultado"]    = "0.0";
                Session["Ventas"]       = "0.0";
                Session["CajaBancos"]   = "0.0";
                Session["Deben"]        = "0.0";
                Session["debo"]         = "0.0";
                Session["tipoMoneda"]       = "nuevos soles";
                Session["simboloMoneda"]    = "S/ ";
            }
        }
        public void GetTotalForVentas(bool moneda)
        {
            NumberFormatInfo nfi;
            if (moneda)
            {
                nfi = new CultureInfo("es-PE", false).NumberFormat;
                //lblTipoMoneda.Text = "Nuevos soles";
            }
            else
            {
                nfi = new CultureInfo("en-US", false).NumberFormat;
                //lblTipoMoneda.Text = "Dólares";
            }
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
                    break;
                case "2":
                    try
                    { totalVentas = datatableMes2.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "3":
                    try
                    { totalVentas = datatableMes3.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "4":
                    try
                    { totalVentas = datatableMes4.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "5":
                    try
                    { totalVentas = datatableMes5.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "6":
                    try
                    { totalVentas = datatableMes6.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "7":
                    try
                    { totalVentas = datatableMes7.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "8":
                    try
                    { totalVentas = datatableMes8.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "9":
                    try
                    { totalVentas = datatableMes9.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "10":
                    try
                    { totalVentas = datatableMes10.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "11":
                    try
                    { totalVentas = datatableMes11.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
                case "12":
                    try
                    { totalVentas = datatableMes12.AsEnumerable().Select(x => x.Field<double>("a")).Sum(); }
                    catch (Exception)
                    { totalVentas = 0; }
                    break;
            }
            Session.Remove("Ventas");
            Session["Ventas"] =  totalVentas;
            #endregion
        }
        public void GetTotalForCajaBancos(bool moneda) {
            NumberFormatInfo nfi;
            if (moneda)
            {
                nfi = new CultureInfo("es-PE", false).NumberFormat;
                //lblTipoMoneda.Text = "Nuevos soles";
            }
            else
            {
                nfi = new CultureInfo("en-US", false).NumberFormat;
                //lblTipoMoneda.Text = "Dólares";
            }
            string JsonA105 = GetPathFile("A105");
            DataTable tabla = new DataTable();
            tabla = mergeTables.GetAccumulatedTables(JsonA105, lstMes.SelectedValue.ToString());
            decimal total = 0;
            try
            {
                DataTable ListCuentas = new DataTable();
                ListCuentas = mergeTables.GetListDist(tabla, "a");
                total = mergeTables.GetTotalByTable(tabla, ListCuentas, "a", "b", "c", true, false);
                Session.Remove("CajaBancos");
                Session["CajaBancos"] = total;
            }
            catch (Exception)
            {
                Session.Remove("CajaBancos");
                Session["CajaBancos"] = 0;
            }
        }
        public void GetTotalByCuentasCobrar(bool moneda) {
            NumberFormatInfo nfi;
            if (moneda)
            {
                nfi = new CultureInfo("es-PE", false).NumberFormat;
                //lblTipoMoneda.Text = "Nuevos soles";
            }
            else
            {
                nfi = new CultureInfo("en-US", false).NumberFormat;
                //lblTipoMoneda.Text = "Dólares";
            }
            string JsonTableA115 = GetPathFile("A115");
            string JsonTableA120N = GetPathFileN("A120");
            string JsonTableA120 = GetPathFile("A120");
            decimal sumA115 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA115, lstMes.SelectedValue.ToString(), "a", "b", "c", true, false));
            decimal sumA120N = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA120N, lstMes.SelectedValue.ToString(), "a", "b", "c", true, false));
            decimal sumA120 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableA120, lstMes.SelectedValue.ToString(), "a", "b", "c", true, false));
            decimal totalCuentasPorCobrar = 0;
            
            totalCuentasPorCobrar = sumA115 + sumA120N + sumA120;
            Session.Remove("Deben");
            Session["Deben"] = totalCuentasPorCobrar;
        }
        public void GetTotalByCuentasPagar(bool moneda) {
            NumberFormatInfo nfi;
            if (moneda)
            {
                nfi = new CultureInfo("es-PE", false).NumberFormat;
                //lblTipoMoneda.Text = "Nuevos soles";
            }
            else
            {
                nfi = new CultureInfo("en-US", false).NumberFormat;
                //lblTipoMoneda.Text = "Dólares";
            }
            string JsonTableP120N = GetPathFileN("P120");
            string JsonTableP120 = GetPathFile("P120");
            string JsonTableP110 = GetPathFile("P110");
            //string JsonTableP121 = GetPathFile("P121"); // Este cambia
            string JsonTableP105N = GetPathFileN("P105");
            string JsonTableP105 = GetPathFile("P105");
            decimal totalCuentasPorPagar = 0;

            decimal nSumP120N = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP120N, lstMes.SelectedValue.ToString(), "a", "b", "c", true, true));
            decimal nSumP105N = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP105N, lstMes.SelectedValue.ToString(), "a", "b", "c", true, true));
            decimal nSumP105 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP105, lstMes.SelectedValue.ToString(), "a", "b", "c", true, true));
            decimal nSumP120 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP120, lstMes.SelectedValue.ToString(), "a", "b", "c", true, true));
            decimal nSumP110 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP110, lstMes.SelectedValue.ToString(), "a", "b", "c", true, true));
            //decimal nSumP121 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonTableP121, lstMes.SelectedValue.ToString(), "a", "b", "c", true, true));
            totalCuentasPorPagar = (nSumP120N + nSumP120 + nSumP110 + /*nSumP121*/ + nSumP105 + nSumP105N) * -1;
            Session.Remove("debo");
            Session["debo"] = totalCuentasPorPagar;
        }
        //Jorge Luis|26/12/2017|RW-91
        /*Método para obtener una dataset json de tipo (N) con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile) {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
        //Jorge Luis|26/12/2017|RW-91
        /*Método para obtener una dataset json de tipo (N) con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFileN(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/N" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (bool.Parse(lstTipoMoneda.SelectedValue) == true)
            {
                GetTotalForVentas(true);
                GetTotalForCajaBancos(true);
                //GetTotalForResultado(true);
                GetTotalEstadoDeResultado();
                GetTotalByCuentasCobrar(true);
                GetTotalByCuentasPagar(true);
            }
            else {
                GetTotalForVentas(false);
                GetTotalForCajaBancos(false);
                //GetTotalForResultado(false);
                GetTotalEstadoDeResultado();
                GetTotalByCuentasCobrar(false);
                GetTotalByCuentasPagar(false);
            }
            
        }
        // Modificaciones
        public void GetTotalEstadoDeResultado()
        {
            int mes = 0;
            if (int.Parse(lstMes.SelectedValue) > 0)
                mes = int.Parse(lstMes.SelectedValue) - 1;
            else
                mes = 1;
            bool moneda = bool.Parse(lstTipoMoneda.SelectedValue);
            String rootPath = Server.MapPath("~");
            Consultas estadoResultado = new Consultas()
            {
                rootPath = rootPath,
                user = Session["IdUser"].ToString(),
                nameReport = "/rptStdPmS/",
                idCompany = Request.QueryString["idCompany"].ToString(),
                year = Request.QueryString["year"].ToString(),
            };
            decimal valorFinal = estadoResultado.GetTotalByReportEFNTER(moneda, mes);
            Session.Remove("Resultado");
            Session["Resultado"] = Math.Round(valorFinal, 2);
        }

        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lstTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bool.Parse(lstTipoMoneda.SelectedValue) == true) {
                Session["tipoMoneda"]       = "nuevos soles";
                Session["simboloMoneda"]    = "S/ ";
            }
            else
            {
                Session["tipoMoneda"]       = "dólares";
                Session["simboloMoneda"]    = "$ ";
            }
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para */
        //protected void lstMes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
        //        //GetReport(true, int.Parse(lstMes.SelectedValue));
        //    else
        //        //GetReport(false, int.Parse(lstMes.SelectedValue));
        //}
        ////Jorge Luis|17/01/2018|RW-97
        ///*Método para */
        //protected void lstTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (bool.Parse(lstTipoMoneda.SelectedValue) == true)
        //    {
        //        Session["TipoMonedaEFNT"] = "Nuevos soles";
        //        //GetReport(true, int.Parse(lstMes.SelectedValue));
        //    }
        //    else
        //    {
        //        Session["TipoMonedaEFNT"] = "Dólares";
        //        //GetReport(false, int.Parse(lstMes.SelectedValue));
        //    }
        //}
    } 
}