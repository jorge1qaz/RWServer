using System;
using BusinessLayer;
using System.Data;
using Newtonsoft.Json;
using System.Linq;

namespace AppWebReportes.Reportes
{
    public partial class frmMargenUtilidad : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        static double totalUnidades;
        static double totalPuVentas;
        static double totalPuCosto;
        static decimal PuVentas;
        static decimal PuCosto;
        static decimal muUnitario;
        static decimal mu;
        static decimal montoVentas;
        static decimal montoCosto;
        static decimal margenUtil;
        static string descripcion;
        static string medida;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUser"] == null)
                Response.Redirect("~/Acceso");
            if (!Page.IsPostBack)
            {
                string JsonQuerys = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01" + "/" + "2017" + "/" + "Querys" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");

                DataSet dataSetQuerys = JsonConvert.DeserializeObject<DataSet>(JsonQuerys);
                DataTable datatableQuerys0 = dataSetQuerys.Tables["data0"];
                DataTable datatableQuerys1 = dataSetQuerys.Tables["data1"];
                DataTable datatableQuerys2 = dataSetQuerys.Tables["data2"];
                DataTable datatableQuerys3 = dataSetQuerys.Tables["data3"];
                DataTable datatableQuerys4 = dataSetQuerys.Tables["data4"];
                DataTable datatableQuerys5 = dataSetQuerys.Tables["data5"];
                Session["queryJson"] = "";
                lstAlmacenes.DataSource = dataSetQuerys.Tables[0].DefaultView;
                lstAlmacenes.DataTextField = "cdsc";
                lstAlmacenes.DataValueField = "ccod_alma";
                lstAlmacenes.DataBind();
                lstAlmacenes.Items.Insert(0, "Seleccione");

                lstCOSTO1.DataTextField = "b";
                lstCOSTO1.DataValueField = "a";
                lstCOSTO1.DataBind();
                lstCOSTO1.Items.Insert(0, "Seleccione");
            }
            if (Session["valLstAlmacen"] != null)
            {
                lstAlmacenes.Items.FindByValue(Session["valLstAlmacen"].ToString());
                spanFilters.Visible = true;
                lblFilter.Text += "Almacén ( " + lstAlmacenes.SelectedItem.ToString() + ")";
            }
            else
            {
                spanFilters.Visible = false;
            }
            //Bloques de filtros bloqueados
            blockAlcance.Visible = false;
            blockCosto2.Visible = false;
            blockStock.Visible = false;
            blockVendedor.Visible = false;
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string JsonProductsByMonth = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01" + "/" + "2017" + "/" + "Products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByStore = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01" + "/" + "2017" + "/" + lstAlmacenes.SelectedValue.ToString() + "StoreProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");

            if (Session["valLstAlmacen"] != null)
                GenerateReport(JsonProductsByStore);
            else
                GenerateReport(JsonProductsByMonth);
        }
        public void GenerateReport(string filtro)
        {
            string JsonCadena = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01"+ "/" + "2017" + "/" + "Fulltable" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonCadena);
            DataTable dataTable = dataSet.Tables["data"];

            DataSet dataSetProducts = JsonConvert.DeserializeObject<DataSet>(filtro);
            DataTable dataTableProducts = dataSetProducts.Tables["data"];

            DataTable tablaReporte = new DataTable();
            DataColumn column;
            #region DeclaracionColumnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "C";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "D";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "M";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "U";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "PV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "PC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "MUU";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "MV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "MC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "MU";
            tablaReporte.Columns.Add(column);
            #endregion
            DataSet dsReporte = new DataSet();
            dsReporte.Tables.Add(tablaReporte);
            dsReporte.Tables[0].TableName = "data";
            foreach (DataRow row in dataTableProducts.Rows)
                ProcesarDatos(row["a"].ToString().Trim(), row["b"].ToString().Trim(), tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
            string queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
            Session["queryJson"] = queryJson;
        }
        public void ProcesarDatos(string idFactura, string idProduct, DataTable tableContent, DataTable tableData, bool moneda)
        {
            /*Si la elección del cliente fue en soles la variable "moneda" debería estar en true, en caso contrarío 
             se le asigna el valor de falso lo cual significa que está en dólares. */
            string npu;
            string ncosto;
            if (moneda)
            { npu = "g"; ncosto = "i"; }
            else
            { npu = "j"; ncosto = "k"; }
            #region CalculosMatematicos
            descripcion = tableData.AsEnumerable().Where(x => x.Field<string>("c").Trim() == idProduct).Where(x => x.Field<string>("a").Trim() == idFactura).Select(x => x.Field<string>("d")).FirstOrDefault();
            medida = tableData.AsEnumerable().Where(x => x.Field<string>("c").Trim() == idProduct).Where(x => x.Field<string>("a").Trim() == idFactura).Select(x => x.Field<string>("f")).FirstOrDefault();
            try
            {
                totalUnidades = tableData.AsEnumerable().Where(x => x.Field<string>("c").Trim() == idProduct).Where(x => x.Field<string>("a").Trim() == idFactura).Select(x => x.Field<double>("e")).Sum();
            }
            catch (Exception)
            { totalUnidades = 0; }
            try
            {
                totalPuVentas = tableData.AsEnumerable().Where(x => x.Field<string>("c").Trim() == idProduct).Where(x => x.Field<string>("a").Trim() == idFactura).Select(
                    (x => x.Field<double>("e") * (x.Field<double>(npu) / (1 + (x.Field<double>("h") / 100))))).Sum();
            }
            catch (Exception)
            { totalPuVentas = 0; }
            try
            {
                totalPuCosto = tableData.AsEnumerable().Where(x => x.Field<string>("c").Trim() == idProduct).Where(x => x.Field<string>("a").Trim() == idFactura).Select(
                    (x => x.Field<double>(ncosto) * x.Field<double>("e"))).Sum();
            }
            catch (Exception)
            { totalPuCosto = 0; }
            Convert.ToDecimal(totalUnidades);
            Convert.ToDecimal(totalPuVentas);
            Convert.ToDecimal(totalPuCosto);
            if (totalUnidades != 0)
            {
                PuVentas = Convert.ToDecimal(totalPuVentas) / Convert.ToDecimal(totalUnidades);
                PuCosto = Convert.ToDecimal(totalPuCosto) / Convert.ToDecimal(totalUnidades);
            }
            else
            { PuVentas = 0; PuCosto = 0; }
            muUnitario = PuVentas - PuCosto;
            if (PuCosto != 0)
                mu = (muUnitario / PuCosto) * 100;
            else
                mu = 0;
            montoVentas = PuVentas * Convert.ToDecimal(totalUnidades);
            montoCosto = PuCosto * Convert.ToDecimal(totalUnidades);
            margenUtil = montoVentas - montoCosto;
            #endregion

            DataRow row;
            row = tableContent.NewRow();
            row["C"] = idProduct.Trim();
            row["D"] = Convert.ToString(descripcion);
            row["M"] = Convert.ToString(medida);
            row["U"] = Math.Round(Convert.ToDecimal(totalUnidades), 2);
            row["PV"] = Math.Round(Convert.ToDecimal(PuVentas), 4);
            row["PC"] = Math.Round(Convert.ToDecimal(PuCosto), 4);
            row["MUU"] = Math.Round(Convert.ToDecimal(muUnitario), 4);
            row["MV"] = Math.Round(Convert.ToDecimal(montoVentas), 4);
            row["MC"] = Math.Round(Convert.ToDecimal(montoCosto), 4);
            row["MU"] = Math.Round(Convert.ToDecimal(margenUtil), 4);
            tableContent.Rows.Add(row);
        }

        protected void lstAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["valLstAlmacen"] = lstAlmacenes.SelectedValue.ToString();
            lblFilter.Text = "";
        }

        protected void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            Session["valLstAlmacen"] = null;
            spanFilters.Visible = false;
            Session["queryJson"] = "";
        }
    }
}