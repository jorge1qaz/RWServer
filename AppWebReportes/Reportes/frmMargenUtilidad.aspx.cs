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
        Calculos cal = new Calculos();
        #region VariablesToCalculate
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
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null)
                Response.Redirect("~/Acceso");
            if (Session["prueba"] != null)
            {
                Response.Write(Session["prueba"].ToString());

            }
            if (!Page.IsPostBack)
            {
                string JsonQuerys = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01" + "/" + "2017" + "/" + "Querys" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");

                DataSet dataSetQuerys = JsonConvert.DeserializeObject<DataSet>(JsonQuerys);
                DataTable datatableQuerys0 = dataSetQuerys.Tables["data0"];
                DataTable datatableQuerys1 = dataSetQuerys.Tables["data1"];
                DataTable datatableQuerys2 = dataSetQuerys.Tables["data2"];
                DataTable datatableQuerys3 = dataSetQuerys.Tables["data3"];
                DataTable datatableQuerys4 = dataSetQuerys.Tables["data4"];
                DataTable datatableQuerys5 = dataSetQuerys.Tables["data5"];
                Session["queryJson"] = "";
                #region Filters
                lstAlmacenes.DataSource = dataSetQuerys.Tables[0].DefaultView;
                lstAlmacenes.DataTextField = "cdsc";
                lstAlmacenes.DataValueField = "ccod_alma";
                lstAlmacenes.DataBind();
                lstAlmacenes.Items.Insert(0, "Seleccione");

                lstCOSTO1.DataSource = dataSetQuerys.Tables[1].DefaultView;
                lstCOSTO1.DataTextField = "b";
                lstCOSTO1.DataValueField = "a";
                lstCOSTO1.DataBind();
                lstCOSTO1.Items.Insert(0, "Seleccione");
                #endregion
            }
            if (Session["valLstAlmacen"] != null)
            {
                lstAlmacenes.Items.FindByValue(Session["valLstAlmacen"].ToString());
                spanFilters.Visible = true;
                lblFilter.Text += "Almacén ( " + lstAlmacenes.SelectedItem.ToString() + ")";
            }
            else
                spanFilters.Visible = false;
            //Bloques de filtros bloqueados
            blockAlcance.Visible = false;
            blockCosto2.Visible = false;
            blockStock.Visible = false;
            blockVendedor.Visible = false;
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            string JsonProductsByMonth = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() +
                "/rptsMrgTld/" + "01" + "/" + "2017" + "/" + "Products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByStore = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01" + "/" + 
                "2017" + "/" + "StoreProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByCosto1 = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01" + "/" +
                "2017" + "/" + "Costo1Products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");

            if (Session["valLstAlmacen"] != null)
                GenerateReport(JsonProductsByStore, "storeProducts"); //Indica que el filtro debe ser en base al almacén
                if (Session["valLstCosto1"] != null)
                    GenerateReport(JsonProductsByCosto1, "costo1Products"); //Indica que el filtro debe ser en base al costo1
            else
                GenerateReport(JsonProductsByMonth, "allProducts");
        }
        public void GenerateReport(string filter, string typeFilter)
        {
            String rootPath = Server.MapPath("~");
            // dataTable => Fulltable; dataTableProducts = el json que tengo el respectivo filtro (filter)
            string JsonCadena = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + "01"+ "/" + "2017" +"/" + "Fulltable" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonCadena);
            DataTable dataTable = dataSet.Tables["data"]; //Declaración de la tabla donde se va a hacer la extracción de datos

            DataSet dataSetProducts = JsonConvert.DeserializeObject<DataSet>(filter); //Se trae la lista de productos con su respectivo filtro
            DataTable dataTableProducts; //Obtiene la tabla con sus datos

            DataTable tablaReporte = new DataTable(); //Declaración de la tabla contenedora del reporte a generar
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
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "PC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MUU";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "MU";
            tablaReporte.Columns.Add(column);
            #endregion 
            DataSet dsReporte = new DataSet();
            dsReporte.Tables.Add(tablaReporte);
            dsReporte.Tables[0].TableName = "data";
            switch (typeFilter)
            {
                case "allProducts":
                    dataTableProducts = dataSetProducts.Tables["data"]; //Obtiene la tabla con sus datos
                    //El recorrido de este bucle es para la lista de todos los productos
                    //Sí se hace la consulta sin filtros los parametros son "a" para idProducto, idFiltro (aun no se programa)
                    Response.Write("con pana");
                    foreach (DataRow row in dataTableProducts.Rows)
                        ProcesarDatos(row["a"].ToString().Trim(), row["a"].ToString().Trim(), "a", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                    break;
                case "storeProducts":
                    dataTableProducts = dataSetProducts.Tables[lstAlmacenes.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                    //El recorrido de este bucle es para la lista de todos los productos con su filtro de almacén
                    foreach (DataRow row in dataTableProducts.Rows)
                        ProcesarDatos(row["a"].ToString().Trim(), lstAlmacenes.SelectedValue.ToString(), "k", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                    break;
                case "costo1Products":
                    dataTableProducts = dataSetProducts.Tables[lstCOSTO1.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                    //El recorrido de este bucle es para la lista de todos los productos con su filtro de costo1
                    foreach (DataRow row in dataTableProducts.Rows)
                        ProcesarDatos(row["a"].ToString().Trim(), lstCOSTO1.SelectedValue.ToString(), "m", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                    break;
            }
            string queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
            Session["queryJson"] = queryJson;
        }
        public void ProcesarDatos(string idProduct, string idFiltro, string filtro, DataTable tableContent, DataTable tableData, bool moneda)
        {
            /*Si la elección del cliente fue en soles la variable "moneda" debería estar en true, en caso contrarío 
             se le asigna el valor de falso lo cual significa que está en dólares. */
            string npu;
            string ncosto;
            if (moneda) //soles
                { npu = "e"; ncosto = "g"; }
            else //dolares
                { npu = "h"; ncosto = "i"; }

            #region CalculosMatematicos
            descripcion = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                            Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(x => x.Field<string>("b")).FirstOrDefault();
            medida = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                            Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(x => x.Field<string>("d")).FirstOrDefault();
            try
            {
                totalUnidades = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                            Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(x => x.Field<double>("c")).Sum();
            }
            catch (Exception)
            { totalUnidades = 0; }
            try
            {
                totalPuVentas = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                            Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(
                            (x => x.Field<double>("c") * (x.Field<double>(npu) / (1 + (x.Field<double>("f") / 100))))).Sum();
            }
            catch (Exception)
                { totalPuVentas = 0; }
            try
            {
                totalPuCosto = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                            Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(
                            (x => x.Field<double>(ncosto) * x.Field<double>("c"))).Sum();
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
            row["U"] =  Math.Round(Convert.ToDecimal(totalUnidades), 2);
            row["PV"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(PuVentas), 4));
            row["PC"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(PuCosto), 4));
            row["MUU"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(muUnitario), 4));
            row["MV"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(montoVentas), 4));
            row["MC"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(montoCosto), 4));
            row["MU"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(margenUtil), 4));
            tableContent.Rows.Add(row);
        }
        protected void lstAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Guarda en una variable de sesión, el valor de la lista de almacenes
            Session["valLstAlmacen"] = lstAlmacenes.SelectedValue.ToString();
            lblFilter.Text = "";
            Session.Remove("valLstCosto1");
        }
        protected void lstCOSTO1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Guarda en una variable de sesión, el valor de la lista de costo1
            Session["valLstCosto1"] = lstAlmacenes.SelectedValue.ToString();
            lblFilter.Text = "";
            Session.Remove("valLstAlmacen");
        }
        protected void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            Session.Remove("valLstAlmacen");
            spanFilters.Visible = false;
            Session["queryJson"] = "";
        }
    }
}