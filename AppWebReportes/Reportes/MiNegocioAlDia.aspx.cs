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
                lblDebo.Text = "0.0";
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
        }
        public void GetTotalForCajaBancos() {
            String rootPath = Server.MapPath("~");
            string JsonA105 = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "A105.json").Trim().Replace("\\'", "'");
            DataTable tabla = new DataTable();
            tabla = mergeTables.GetAccumulatedTables(JsonA105, lstMes.SelectedValue.ToString());
            try
            {
                DataTable ListCuentas = new DataTable();
                ListCuentas = mergeTables.GetListDist(tabla, "a");
                string total = "";
                total = mergeTables.GetTotalByTable(tabla, ListCuentas, "a", "b", "c");
                lblCajaBancos.Text = total.ToString();
            }
            catch (Exception)
                { Response.Write("<script>alert('No se obtuvieron datos, intenta con otro mes.');</script>"); }
        }
        public void GetTotalForResultado()
        {
            string JsonTableN005 = GetPathFile("N005");
            decimal sumN005 = Convert.ToDecimal(mergeTables.GetSumTotal(JsonTableN005, lstMes.SelectedValue.ToString(), "a"));
            Response.Write(sumN005.ToString());
            
        }
        public string GetPathFile(string nameFile) {
            String rootPath = Server.MapPath("~");
            string JsonTable = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptMNgcLd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonTable;
        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            GetTotalForVentas();
            GetTotalForCajaBancos();
            GetTotalForResultado();
        }
    } 
}