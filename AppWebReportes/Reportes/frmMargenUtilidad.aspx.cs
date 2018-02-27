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
            if (Session["IdUser"] == null || Request.QueryString["idCompany"] == null || Request.QueryString["year"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
                { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
            string JsonQuerys = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "Querys" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            DataSet dataSetQuerys = JsonConvert.DeserializeObject<DataSet>(JsonQuerys);
            DataTable datatableQuerys0 = dataSetQuerys.Tables["almacenes"];
            DataTable datatableQuerys1 = dataSetQuerys.Tables["costo1"];
            DataTable datatableQuerys2 = dataSetQuerys.Tables["data"];
            DataTable datatableQuerys3 = dataSetQuerys.Tables["vendedor"];
            DataTable datatableQuerys4 = dataSetQuerys.Tables["costo2"];
            if (!Page.IsPostBack)
            {
                #region Filtros bloqueados
                blockStore.Visible = false;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
                blockCosto1.Visible = false;
                blockAlcance.Visible = false;
                blockCosto2.Visible = false;
                blockStock.Visible = false;
                blockVendedor.Visible = false;
                Session["valLstEmployee"] = "";
                #endregion
                Session["queryJson"] = "";
            }
            #region Filters
            lstAlmacenes.DataSource = dataSetQuerys.Tables["almacenes"].DefaultView;
            lstAlmacenes.DataTextField = "b";
            lstAlmacenes.DataValueField = "a";
            lstAlmacenes.DataBind();

            lstCOSTO1.DataSource = dataSetQuerys.Tables["costo1"].DefaultView;
            lstCOSTO1.DataTextField = "b";
            lstCOSTO1.DataValueField = "a";
            lstCOSTO1.DataBind();

            string listCostumer = JsonConvert.SerializeObject(dataSetQuerys, Formatting.None).ToString();
            Session["listCostumer"] = listCostumer;

            lstVendedor.DataSource = dataSetQuerys.Tables["vendedor"].DefaultView;
            lstVendedor.DataTextField = "b";
            lstVendedor.DataValueField = "a";
            lstVendedor.DataBind();

            lstCOSTO2.DataSource = dataSetQuerys.Tables["costo2"].DefaultView;
            lstCOSTO2.DataTextField = "b";
            lstCOSTO2.DataValueField = "a";
            lstCOSTO2.DataBind();
            #endregion
            if (Session["filtersState"] != null)
                spanFilters.Visible = true;
            else
                spanFilters.Visible = false;
        }
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            string JsonProductsByMonth = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() +
                "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "Products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByStore = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "StoreProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByCosto1 = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "Costo1Products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByCostumer = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "CustomerProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByEmployee = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "EmployeeProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByAlcance = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "AlcanceProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByStock = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "StockProducts" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            string JsonProductsByCosto2 = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" +
                Request.QueryString["year"].ToString() + "/" + "Costo2Products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");

            // dataTable => Fulltable; dataTableProducts = el json que tengo el respectivo filtro (filter)
            string JsonCadena = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "Fulltable" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonCadena);
            DataTable dataTable = dataSet.Tables["data"]; //Declaración de la tabla donde se va a hacer la extracción de datos

            DataSet dataSetProducts; //Se trae la lista de productos con su respectivo filtro
            DataTable dataTableProducts; //Obtiene la tabla con sus datos

            DataTable tablaReporte = new DataTable(); //Declaración de la tabla contenedora del reporte a generar
            DataColumn column = new DataColumn();
            #region DeclaracionColumnas
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
            if (Session["filtersState"] == null)
                Session["filtersState"] = "none";
            string queryJson = "";
            switch (Session["filtersState"].ToString())
            {
                #region Un solo filtro
                case "0000000":
                    spanFilters.Visible = false;
                    dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByMonth);
                    dataTableProducts = dataSetProducts.Tables["data"]; //Obtiene la tabla con sus datos
                    //El recorrido de este bucle es para la lista de todos los productos
                    //Sí se hace la consulta sin filtros los parametros son "a" para idProducto, idFiltro (aun no se programa)
                    foreach (DataRow row in dataTableProducts.Rows)
                        ProcesarDatos(row["a"].ToString().Trim(), row["a"].ToString().Trim(), "a", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                    queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                    Session["queryJson"] = queryJson;
                    break;
                case "0000001": // único filtro para costo2
                    if (lstCOSTO2.SelectedValue.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar el centro de costo 2.');</script>");
                    else
                    {
                        spanFilters.Visible = true;
                        lblFilter.Text = "Se ha agregado el filtro de, Centro de costo 2:  " + lstCOSTO2.SelectedItem.ToString();
                        dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByCosto2);
                        dataTableProducts = dataSetProducts.Tables[lstCOSTO2.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                        foreach (DataRow row in dataTableProducts.Rows)                                        //El recorrido de este bucle es para la lista de todos los productos con su filtro de costo1
                            ProcesarDatos(row["a"].ToString().Trim(), lstCOSTO2.SelectedValue.ToString(), "n", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                        queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                        Session["queryJson"] = queryJson;
                    }
                    break;
                case "0000010": // único filtro para Alcance
                    if (lstAlcance.SelectedValue.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar el alcance.');</script>");
                    else
                    {
                        spanFilters.Visible = true;
                        lblFilter.Text = "Se ha agregado el filtro de, Alcance:  " + lstAlcance.SelectedItem.ToString();
                        dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByAlcance);
                        dataTableProducts = dataSetProducts.Tables[lstAlcance.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                        foreach (DataRow row in dataTableProducts.Rows)                                        //El recorrido de este bucle es para la lista de todos los productos con su filtro de costo1
                            ProcesarDatos(row["a"].ToString().Trim(), lstAlcance.SelectedValue.ToString(), "q", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                        queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                        Session["queryJson"] = queryJson;
                    }
                    break;
                case "0000100": // único filtro para stock
                    if (lstVendedor.SelectedValue.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar algún stock.');</script>");
                    else
                    {
                        spanFilters.Visible = true;
                        lblFilter.Text = "Se ha agregado el filtro de, stock:  " + lstTipoStock.SelectedItem.ToString();
                        dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByStock);
                        dataTableProducts = dataSetProducts.Tables[lstTipoStock.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                        foreach (DataRow row in dataTableProducts.Rows)                                        //El recorrido de este bucle es para la lista de todos los productos con su filtro de costo1
                            ProcesarDatos(row["a"].ToString().Trim(), lstTipoStock.SelectedValue.ToString(), "p", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                        queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                        Session["queryJson"] = queryJson;
                    }
                    break;
                case "0001000": // único filtro para vendedor
                    if (lstVendedor.SelectedValue.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar algún vendedor.');</script>");
                    else
                    {
                        spanFilters.Visible = true;
                        lblFilter.Text = "Se ha agregado el filtro de, Vendedor:  " + lstVendedor.SelectedItem.ToString();
                        dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByEmployee);
                        dataTableProducts = dataSetProducts.Tables[lstVendedor.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                        foreach (DataRow row in dataTableProducts.Rows)                                        //El recorrido de este bucle es para la lista de todos los productos con su filtro de costo1
                            ProcesarDatos(row["a"].ToString().Trim(), lstVendedor.SelectedValue.ToString(), "o", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                        queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                        Session["queryJson"] = queryJson;
                    }
                    break;
                case "0010000": // único filtro para Costo 1
                    if (lstCOSTO1.SelectedValue.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar algún centro de Costo 1.');</script>");
                    else {
                        spanFilters.Visible = true;
                        lblFilter.Text = "Se ha agregado el filtro de, Costo 1:  " + lstCOSTO1.SelectedItem.ToString();
                        dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByCosto1);
                        dataTableProducts = dataSetProducts.Tables[lstCOSTO1.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                        foreach (DataRow row in dataTableProducts.Rows)                                        //El recorrido de este bucle es para la lista de todos los productos con su filtro de costo1
                            ProcesarDatos(row["a"].ToString().Trim(), lstCOSTO1.SelectedValue.ToString(), "m", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                        queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                        Session["queryJson"] = queryJson;
                    }
                    break;
                case "0100000": // único filtro para clientes
                    if (txtClienteRUC.Text.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar un RUC de cliente.');</script>");
                    else
                    {
                        try
                        {
                            spanFilters.Visible = true;
                            lblFilter.Text = "Se ha agregado el filtro de, RUC de cliente: " + txtClienteRUC.Text.ToString();
                            dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByCostumer);
                            dataTableProducts = dataSetProducts.Tables[txtClienteRUC.Text.ToString()]; //Obtiene la tabla con sus datos
                                                                                                       //El recorrido de este bucle es para la lista de todos los productos con su filtro de cliente
                            foreach (DataRow row in dataTableProducts.Rows)
                                ProcesarDatos(row["a"].ToString().Trim(), txtClienteRUC.Text.ToString(), "j", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                            queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                            Session["queryJson"] = queryJson;
                        }
                        catch (Exception)
                        {
                            Response.Write("<script>alert('No tenemos registros de este RUC.');</script>");
                        }
                    }
                    break;
                case "1000000": // único filtro para almacén
                    if (lstAlmacenes.SelectedValue.ToString() == "")
                        Response.Write("<script>alert('Antes de continuar, debe seleccionar algún almacén.');</script>");
                    else
                    {
                        spanFilters.Visible = true;
                        lblFilter.Text = "Se ha agregado el filtro de almacén: " + lstAlmacenes.SelectedItem.ToString();
                        dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByStore);
                        dataTableProducts = dataSetProducts.Tables[lstAlmacenes.SelectedValue.ToString().Trim()]; //Obtiene la tabla con sus datos
                        //El recorrido de este bucle es para la lista de todos los productos con su filtro de almacén
                        foreach (DataRow row in dataTableProducts.Rows)
                            ProcesarDatos(row["a"].ToString().Trim(), lstAlmacenes.SelectedValue.ToString(), "k", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                        queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                        Session["queryJson"] = queryJson;
                    }
                    break;
                #endregion
                case "0000011":
                    spanFilters.Visible = false;
                    dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByMonth);
                    dataTableProducts = dataSetProducts.Tables["data"]; //Obtiene la tabla con sus datos
                    //El recorrido de este bucle es para la lista de todos los productos
                    //Sí se hace la consulta sin filtros los parametros son "a" para idProducto, idFiltro (aun no se programa)
                    foreach (DataRow row in dataTableProducts.Rows)
                        ProcesarDatos(row["a"].ToString().Trim(), row["a"].ToString().Trim(), "a", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                    queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                    Session["queryJson"] = queryJson;
                    break;
                default:
                    spanFilters.Visible = false;
                    dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByMonth);
                    dataTableProducts = dataSetProducts.Tables["data"]; //Obtiene la tabla con sus datos
                    //El recorrido de este bucle es para la lista de todos los productos
                    //Sí se hace la consulta sin filtros los parametros son "a" para idProducto, idFiltro (aun no se programa)
                    foreach (DataRow row in dataTableProducts.Rows)
                        ProcesarDatos(row["a"].ToString().Trim(), row["a"].ToString().Trim(), "a", tablaReporte, dataTable, bool.Parse(lstTipoMoneda.SelectedValue));
                    queryJson = JsonConvert.SerializeObject(dsReporte, Formatting.None).ToString();
                    Session["queryJson"] = queryJson;
                    break;
            }
        }
        public void GenerateReport(string filter, string typeFilter)
        {
            String rootPath = Server.MapPath("~");
            // dataTable => Fulltable; dataTableProducts = el json que tengo el respectivo filtro (filter)
            string JsonCadena = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptsMrgTld/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "Fulltable" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");
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
            try
            {
                descripcion = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                                Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(x => x.Field<string>("b")).FirstOrDefault();
            }
            catch (Exception)
            {
                descripcion = "";
            }
            try
            {
                medida = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                                Where(x => x.Field<string>(filtro).Trim() == idFiltro).Select(x => x.Field<string>("d")).FirstOrDefault();
            }
            catch (Exception)
            {
                medida = "";
            }
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
            row["U"] = Math.Round(Convert.ToDecimal(totalUnidades), 2);
            row["PV"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(PuVentas), 4));
            row["PC"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(PuCosto), 4));
            row["MUU"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(muUnitario), 4));
            row["MV"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(montoVentas), 4));
            row["MC"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(montoCosto), 4));
            row["MU"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(margenUtil), 4));
            tableContent.Rows.Add(row);
        }
        public void ProcesarDatos(string idProduct, string idFiltro, string filtro, string idFiltro2, string filtro2, DataTable tableContent, DataTable tableData, bool moneda)
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
            descripcion     = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
                            Where(x => x.Field<string>(filtro).Trim() == idFiltro).Where(x => x.Field<string>(filtro2).Trim() == idFiltro2)
                            .Select(x => x.Field<string>("b")).FirstOrDefault();
            medida          = tableData.AsEnumerable().Where(x => x.Field<string>("a").Trim() == idProduct).
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
            row["U"] = Math.Round(Convert.ToDecimal(totalUnidades), 2);
            row["PV"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(PuVentas), 4));
            row["PC"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(PuCosto), 4));
            row["MUU"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(muUnitario), 4));
            row["MV"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(montoVentas), 4));
            row["MC"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(montoCosto), 4));
            row["MU"] = cal.CompleteZeros(Math.Round(Convert.ToDecimal(margenUtil), 4));
            tableContent.Rows.Add(row);
        }
        protected void btnDeleteFilter_Click(object sender, EventArgs e)
        {
            Session.Remove("filtersState");
            spanFilters.Visible = false;
            blockStore.Visible = false;
            blockCostumers.Visible = false;
            lblTitleCliente.Visible = false;
            blockCosto1.Visible = false;
            blockAlcance.Visible = false;
            blockCosto2.Visible = false;
            blockStock.Visible = false;
            blockVendedor.Visible = false;
            Session["queryJson"] = "";
        }
        protected void btnSaveFilters_Click(object sender, EventArgs e)
        {
            Int16[] chbSelected = new Int16[] { 0, 0, 0, 0, 0, 0, 0 }; //chbStore, chbCostumers, chbCosto1, chbVendedor, chbStock, chbAlcance, chbCosto2
            int chbSelectedCount = 0;
            #region chbStore
            if (chbStore.Checked) {
                chbSelected[0] = 1;
                blockStore.Visible = true;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
                blockCosto1.Visible = false;
                blockAlcance.Visible = false;
                blockCosto2.Visible = false;
                blockStock.Visible = false;
                blockVendedor.Visible = false;
            }
            #endregion
            #region chbCostumers
            if (chbCostumers.Checked)
            {
                chbSelected[1] = 1;
                blockCostumers.Visible = true;
                lblTitleCliente.Visible = true;
                blockStore.Visible = false;
                blockCosto1.Visible = false;
                blockAlcance.Visible = false;
                blockCosto2.Visible = false;
                blockStock.Visible = false;
                blockVendedor.Visible = false;
            }
            #endregion
            #region chbCosto1
            if (chbCosto1.Checked) {
                chbSelected[2] = 1;
                blockCosto1.Visible = true;
                blockStore.Visible = false;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
                blockAlcance.Visible = false;
                blockCosto2.Visible = false;
                blockStock.Visible = false;
                blockVendedor.Visible = false;
            }
            #endregion
            #region chbVendedor
            if (chbVendedor.Checked)
            {
                chbSelected[3] = 1;
                blockVendedor.Visible = true;
                blockCosto1.Visible = false;
                blockStore.Visible = false;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
                blockAlcance.Visible = false;
                blockCosto2.Visible = false;
                blockStock.Visible = false;
            }
            #endregion
            #region chbStock
            if (chbStock.Checked)
            {
                chbSelected[4] = 1;
                blockStock.Visible = true;
                blockVendedor.Visible = false;
                blockCosto1.Visible = false;
                blockStore.Visible = false;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
                blockAlcance.Visible = false;
                blockCosto2.Visible = false;
            }
            #endregion
            #region chbAlcance
            if (chbAlcance.Checked)
            {
                chbSelected[5] = 1;
                blockAlcance.Visible = true;
                blockStock.Visible = false;
                blockVendedor.Visible = false;
                blockCosto1.Visible = false;
                blockStore.Visible = false;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
                blockCosto2.Visible = false;
            }
            #endregion
            #region chbCosto2
            if (chbCosto2.Checked)
            {
                chbSelected[6] = 1;
                blockCosto2.Visible = true;
                blockAlcance.Visible = false;
                blockStock.Visible = false;
                blockVendedor.Visible = false;
                blockCosto1.Visible = false;
                blockStore.Visible = false;
                blockCostumers.Visible = false;
                lblTitleCliente.Visible = false;
            }
            #endregion
            chbSelectedCount = chbSelected[0] + chbSelected[1] + chbSelected[2] + chbSelected[3] + chbSelected[4] + chbSelected[5] + chbSelected[6];
            Session["filtersState"] = chbSelected[0].ToString() + chbSelected[1].ToString() + chbSelected[2].ToString() + chbSelected[3].ToString() + chbSelected[4].ToString() + chbSelected[5].ToString() + chbSelected[6].ToString();
        }
        protected void chbStore_CheckedChanged(object sender, EventArgs e)
            { chbCostumers.Checked = false; chbCosto1.Checked = false; chbVendedor.Checked = false; chbStock.Checked = false; chbAlcance.Checked = false; }
        protected void chbCostumers_CheckedChanged(object sender, EventArgs e)
            { chbStore.Checked = false; chbCosto1.Checked = false; chbVendedor.Checked = false; chbStock.Checked = false; chbAlcance.Checked = false; chbCosto2.Checked = false; }
        protected void chbCosto1_CheckedChanged(object sender, EventArgs e)
            { chbCostumers.Checked = false; chbStore.Checked = false; chbVendedor.Checked = false; chbStock.Checked = false; chbAlcance.Checked = false; chbCosto2.Checked = false; }
        protected void chbVendedor_CheckedChanged(object sender, EventArgs e)
            { chbCostumers.Checked = false; chbStore.Checked = false; chbCosto1.Checked = false; chbStock.Checked = false; chbAlcance.Checked = false; chbCosto2.Checked = false; }
        protected void chbStock_CheckedChanged(object sender, EventArgs e)
            { chbCostumers.Checked = false; chbStore.Checked = false; chbCosto1.Checked = false; chbAlcance.Checked = false; chbVendedor.Checked = false; chbCosto2.Checked = false; }
        protected void chbAlcance_CheckedChanged(object sender, EventArgs e)
            { chbCostumers.Checked = false; chbStore.Checked = false; chbCosto1.Checked = false; chbStock.Checked = false; chbVendedor.Checked = false; chbCosto2.Checked = false; }
        protected void chbCosto2_CheckedChanged(object sender, EventArgs e)
            { chbCostumers.Checked = false; chbStore.Checked = false; chbCosto1.Checked = false; chbStock.Checked = false; chbVendedor.Checked = false; chbAlcance.Checked = false; }

        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e) => Session["queryJson"] = "";
    }
}