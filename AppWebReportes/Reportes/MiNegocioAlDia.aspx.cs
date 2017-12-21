using System;
using BusinessLayer;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace AppWebReportes.Reportes
{
    public partial class MiNegocioAlDia : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        Calculos cal = new Calculos();

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
            #region Ventas
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
            #endregion
            GetTotalForVentas();
            GetTotalForCajaBancos();
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
            DataTable tableSumByCount = new DataTable(); //Declaración de la tabla contenedora del reporte a generar
            DataColumn column;
            #region Declaración de columnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cuenta";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "Total";
            tableSumByCount.Columns.Add(column);
            #endregion
            #region Declaración de tablas
            DataSet dataSetCajaBancos = JsonConvert.DeserializeObject<DataSet>(JsonA105);
            DataTable datatableCajaBancosMes0 = dataSetCajaBancos.Tables["0"];
            DataTable datatableCajaBancosMes1 = dataSetCajaBancos.Tables["1"];
            DataTable datatableCajaBancosMes2 = dataSetCajaBancos.Tables["2"];
            DataTable datatableCajaBancosMes3 = dataSetCajaBancos.Tables["3"];
            DataTable datatableCajaBancosMes4 = dataSetCajaBancos.Tables["4"];
            DataTable datatableCajaBancosMes5 = dataSetCajaBancos.Tables["5"];
            DataTable datatableCajaBancosMes6 = dataSetCajaBancos.Tables["6"];
            DataTable datatableCajaBancosMes7 = dataSetCajaBancos.Tables["7"];
            DataTable datatableCajaBancosMes8 = dataSetCajaBancos.Tables["8"];
            DataTable datatableCajaBancosMes9 = dataSetCajaBancos.Tables["9"];
            DataTable datatableCajaBancosMes10 = dataSetCajaBancos.Tables["10"];
            DataTable datatableCajaBancosMes11 = dataSetCajaBancos.Tables["11"];
            DataTable datatableCajaBancosMes12 = dataSetCajaBancos.Tables["12"];
            #endregion
            #region Fusión de tablas... Fuuuuuu...sión!
            switch (lstMes.SelectedValue.ToString())
            {
                case "1":
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "2":
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "3":
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "4":
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "5":
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "6":
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "7":
                    datatableCajaBancosMes6.Merge(datatableCajaBancosMes7);
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "8":
                    datatableCajaBancosMes7.Merge(datatableCajaBancosMes8);
                    datatableCajaBancosMes6.Merge(datatableCajaBancosMes7);
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "9":
                    datatableCajaBancosMes8.Merge(datatableCajaBancosMes9);
                    datatableCajaBancosMes7.Merge(datatableCajaBancosMes8);
                    datatableCajaBancosMes6.Merge(datatableCajaBancosMes7);
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "10":
                    datatableCajaBancosMes9.Merge(datatableCajaBancosMes10);
                    datatableCajaBancosMes8.Merge(datatableCajaBancosMes9);
                    datatableCajaBancosMes7.Merge(datatableCajaBancosMes8);
                    datatableCajaBancosMes6.Merge(datatableCajaBancosMes7);
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "11":
                    datatableCajaBancosMes10.Merge(datatableCajaBancosMes11);
                    datatableCajaBancosMes9.Merge(datatableCajaBancosMes10);
                    datatableCajaBancosMes8.Merge(datatableCajaBancosMes9);
                    datatableCajaBancosMes7.Merge(datatableCajaBancosMes8);
                    datatableCajaBancosMes6.Merge(datatableCajaBancosMes7);
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
                case "12":
                    datatableCajaBancosMes11.Merge(datatableCajaBancosMes12);
                    datatableCajaBancosMes10.Merge(datatableCajaBancosMes11);
                    datatableCajaBancosMes9.Merge(datatableCajaBancosMes10);
                    datatableCajaBancosMes8.Merge(datatableCajaBancosMes9);
                    datatableCajaBancosMes7.Merge(datatableCajaBancosMes8);
                    datatableCajaBancosMes6.Merge(datatableCajaBancosMes7);
                    datatableCajaBancosMes5.Merge(datatableCajaBancosMes6);
                    datatableCajaBancosMes4.Merge(datatableCajaBancosMes5);
                    datatableCajaBancosMes3.Merge(datatableCajaBancosMes4);
                    datatableCajaBancosMes2.Merge(datatableCajaBancosMes3);
                    datatableCajaBancosMes1.Merge(datatableCajaBancosMes2);
                    datatableCajaBancosMes0.Merge(datatableCajaBancosMes1);
                    break;
            }
            #endregion
            DataRow row;
            DataTable dtNew = new DataTable();
            try
            {
                DataTable distintos = datatableCajaBancosMes0.DefaultView.ToTable(true, "a");
                foreach (DataColumn dcName in datatableCajaBancosMes0.Columns)
                    dtNew.Columns.Add(new DataColumn(dcName.Caption, dcName.DataType));
                foreach (DataRow drRow in distintos.Rows)
                    dtNew.ImportRow(datatableCajaBancosMes0.Select("a" + " = '" + drRow[0] + "'")[0]);
                foreach (DataRow item in distintos.Rows)
                {
                    try
                    { totalCajaBancosHaber = datatableCajaBancosMes0.AsEnumerable().Where(x => x.Field<string>("a") == item[0].ToString()).Select(x => x.Field<double>("b")).Sum(); }
                    catch (Exception)
                    { totalCajaBancosHaber = 0; }
                    try
                    { totalCajaBancosDebe = datatableCajaBancosMes0.AsEnumerable().Where(x => x.Field<string>("a") == item[0].ToString()).Select(x => x.Field<double>("c")).Sum(); }
                    catch (Exception)
                    { totalCajaBancosDebe = 0; }
                    totalCajaBancos = Convert.ToDecimal(totalCajaBancosDebe) - Convert.ToDecimal(totalCajaBancosHaber);
                    row = tableSumByCount.NewRow();
                    row["Cuenta"] = item.ToString();
                    row["Total"] = totalCajaBancos;
                    tableSumByCount.Rows.Add(row);
                }
                decimal valor = 0;
                foreach (DataRow item in tableSumByCount.Rows)
                {
                    if (decimal.Parse(item[1].ToString()) > 0)
                        valor += decimal.Parse(item[1].ToString());
                }
                lblCajaBancos.Text = valor.ToString();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('No se obtuvieron datos, intenta con otro mes.');</script>");
            }

        }
    } 
}