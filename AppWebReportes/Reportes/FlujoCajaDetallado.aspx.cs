using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AppWebReportes.Reportes
{
    public partial class FlujoCajaDetallado : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string list1 = "";
        decimal totalSaldoInicial = 0;
        decimal totalIngresos = 0;
        decimal totalEgresos = 0;
        int frecuencia = 0;
        int periodo = 0;
        bool moneda = true; // Por defecto en soles
        DateTime fechaInicial = new DateTime();
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        protected void Page_Load(object sender, EventArgs e)
        {
            frecuencia  = int.Parse(Session["FCDFrecuencia"].ToString());
            periodo     = int.Parse(Session["FCDPeriodo"].ToString());
            try
            {
                fechaInicial = DateTime.Parse(Session["FCDFechaInicio"].ToString());
            }
            catch (Exception)
            {
                fechaInicial = DateTime.Now;
            }
            try
            {
                if (Session["TipoMonedaFCD"].ToString() == "Nuevos soles")
                    moneda = true;
                else
                    moneda = false;
            }
            catch (Exception)
            {

                throw;
            }
            GenerateReport();
        }
        public void GenerateReport() {
            try
            {
                fechaInicial = DateTime.Parse(Session["FCDFechaInicio"].ToString());
            }
            catch (Exception)
            {
                fechaInicial = DateTime.Now;
            }
            DataSet dataSetListDatos                = JsonConvert.DeserializeObject<DataSet>(GetPathFile("ListDatos")); // Deserealización del dataSet
            DataTable tableInitDatosSaldoInicial    = dataSetListDatos.Tables["dataTableListSaldoInicialDatos"];
            DataTable tableInitDatosIngresos        = dataSetListDatos.Tables["dataTableListIngresosDatos"];
            DataTable tableInitDatosEgresos         = dataSetListDatos.Tables["dataTableListEgresosDatos"];

            DataSet dataSetListDescripcion              = JsonConvert.DeserializeObject<DataSet>(GetPathFile("ListDescripcion"));
            DataTable tableInitDescripcionSaldoInicial  = dataSetListDescripcion.Tables["dataTableListSaldoInicialDescripcion"];
            DataTable tableInitDescripcionIngresos      = dataSetListDatos.Tables["dataTableListIngresosDescripcion"];
            DataTable tableInitDescripcionEgresos       = dataSetListDatos.Tables["dataTableListEgresosDescripcion"];
            DataTable tableInitDescripcionCostumer      = dataSetListDatos.Tables["dataTableListCustumers"];

            // Tablas con descripciones
            DataTable tableNamesOnlySaldoInicial            = mergeTables.GetListDist(tableInitDescripcionSaldoInicial, "a");

            //DataTable tableInitdataTableListCustumers     = dataSetListDescripcion.Tables["dataTableListCustumers"];
            DataTable tableNamesOnlyListCustumers           = mergeTables.GetListDist(dataSetListDescripcion.Tables["dataTableListCustumers"], "a");

            ///DataTable tableNamesOnlyIngresosClientes     = mergeTables.GetListDist(tableInitDescripcionSaldoInicial, "a");
            // Fin Tablas con descripciones

            DataTable tableReport = new DataTable();
            int frecuenciaIncremetado = 0;
            List<string> listDates = new List<string>();
            DataColumn column = new DataColumn();
            #region Declaración de columnas
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cuenta";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Documento";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Número";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Moneda";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Descripción";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fecha documento";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fecha vencimiento";
            tableReport.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Vencidos";
            tableReport.Columns.Add(column);
            #endregion

            for (int i = 0; i < periodo; i++)
            { 
                frecuenciaIncremetado += frecuencia;
                Type columnType = Type.GetType("System.Decimal");
                String columnName = fechaInicial.AddDays(frecuenciaIncremetado - 1).ToShortDateString().Trim();
                listDates.Add(columnName);
                tableReport.Columns.Add(new DataColumn(columnName, columnType));
            }
            DataRow row = tableReport.NewRow();
            row["Cuenta"]       = "Saldo";
            row["Descripción"]  = "Saldo inicial";
            tableReport.Rows.Add(row);
            
            DataTable tableResultSaldoInicial = mergeTables.GetTotalByTable(mergeTables.GetTableByDate(tableInitDatosSaldoInicial, fechaInicial), 
                tableNamesOnlySaldoInicial, "a", "c", "d", "g", "D", listDates[0], moneda); //True moneda soles
            string nameByCuentaSaldoInicial = "";
            foreach (DataRow dataRow in tableResultSaldoInicial.Rows)
            {
                nameByCuentaSaldoInicial = mergeTables.GetStringByIdInDataTable(tableInitDescripcionSaldoInicial, "a", dataRow[0].ToString().Trim(), "b");
                dataRow[4] = nameByCuentaSaldoInicial;
                totalSaldoInicial += decimal.Parse(dataRow[8].ToString());

            }
            tableReport.Merge(tableResultSaldoInicial);
            row = tableReport.NewRow();
            row["Descripción"] = "Total saldo inicial";
            row[listDates[0]] = totalSaldoInicial;
            tableReport.Rows.Add(row);

            //Ingresos
            //Response.Write(" fechaInicial: " + fechaInicial.ToString() + " fecha para ingresos: " + fechaInicial.AddDays(frecuencia).ToString());
            DataTable tableResultIngresos = mergeTables.GetTotalByTable(mergeTables.GetTableByDate(tableInitDatosSaldoInicial, fechaInicial.AddDays(frecuencia)), 
                tableNamesOnlySaldoInicial, "a", "c", "d", "g", "D", listDates[0], moneda); //True moneda soles
            string nameByCuentaIngresos = "";
            foreach (DataRow dataRow in tableResultSaldoInicial.Rows)
            {
                nameByCuentaIngresos = mergeTables.GetStringByIdInDataTable(tableInitDescripcionSaldoInicial, "a", dataRow[0].ToString().Trim(), "b");
                dataRow[4] = nameByCuentaIngresos;
                totalIngresos += decimal.Parse(dataRow[8].ToString());
            }

            row = tableReport.NewRow();
            row["Descripción"] = "Ingresos";
            tableReport.Rows.Add(row);

            row = tableReport.NewRow();
            row["Descripción"] = "Total ingresos";
            row[listDates[0]] = "0.0";
            tableReport.Rows.Add(row);

            row = tableReport.NewRow();
            row["Descripción"] = "Egresos";
            tableReport.Rows.Add(row);

            row = tableReport.NewRow();
            row["Descripción"] = "Total egresos";
            row[listDates[0]] = "0.0";
            tableReport.Rows.Add(row);

            row = tableReport.NewRow();
            row["Descripción"] = "Saldo final";
            row[listDates[0]] = totalSaldoInicial + totalIngresos + totalEgresos ;
            tableReport.Rows.Add(row);
            
            for (int i = 4; i < listDates.Count; i++)
                row[listDates[i]] = totalSaldoInicial + totalIngresos + totalEgresos;

            DataRow[] customerRow = tableReport.Select("Cuenta = 'Saldo'");

            customerRow[0][listDates[0]] = totalSaldoInicial + totalIngresos + totalEgresos;
            customerRow[0][listDates[1]] = totalSaldoInicial + totalIngresos + totalEgresos;

            //grdPruebas.DataSource = tableReport; // GridView de pruebas
            //grdPruebas.DataBind();


            //Pruebas ingresos
            //DataTable pruebas = mergeTables.GetTableByDate(tableInitDatosIngresos, fechaInicial.AddDays(frecuencia));
            grdPruebas.DataSource = tableInitDatosIngresos;
            grdPruebas.DataBind();

        }
        
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        private void GetTableEstadoInicial()
        {
            string cadenaDataSetListDatos = GetPathFile("ListDatos");       // Declaración de la varaible que contendrá todo el dataSet 
            DataSet dataSetListDatos = JsonConvert.DeserializeObject<DataSet>(cadenaDataSetListDatos); // Deserealización del dataSet
            DataTable dataTableListSaldoInicialDatos = new DataTable();     // Declaración del dataTable para Saldo inicial
            try
            {
                fechaInicial = DateTime.Parse(Session["FCDFechaInicio"].ToString());
            }
            catch (Exception)
            {
                fechaInicial = DateTime.Now;
            }
            dataTableListSaldoInicialDatos = mergeTables.GetTableByDate(dataSetListDatos.Tables["dataTableListSaldoInicialDatos"], fechaInicial) ; //Obtención de la tabla

            DataTable dataTableList = new DataTable();
            dataTableList = mergeTables.GetListDist(dataTableListSaldoInicialDatos, "a");
            // GetTotalByTable(tabla, ListCuentas, columnName1, columnName2, columnName3, discriminative, negativeValue);
            decimal valooooor = mergeTables.GetTotalByTable(dataTableListSaldoInicialDatos, dataTableList, "a", "d", "c", false, false);
            foreach (DataRow item in dataTableList.Rows)
            {
                Response.Write("tabla " + item[0].ToString());
            }
            Response.Write("Aquí " + valooooor.ToString());
            int frecuencia  = int.Parse(Session["FCDFrecuencia"].ToString());
            int periodo     = int.Parse(Session["FCDPeriodo"].ToString());
            int frecuenciaIncremetado = frecuencia;

            DataTable tableSumByCount = new DataTable();
            DataColumn column = new DataColumn();
            DataRow row;
            #region Declaración de columnas
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "Cuenta";
            tableSumByCount.Columns.Add(column);
            #endregion

            for (int i = 0; i <= periodo - 1; i++)
            {
                frecuenciaIncremetado += frecuencia; 
                
                row = tableSumByCount.NewRow();
                row["Cuenta"] = fechaInicial.AddDays(frecuenciaIncremetado - 1);
                tableSumByCount.Rows.Add(row);
            }
            
            grdPruebas.DataSource = tableSumByCount;
            grdPruebas.DataBind();
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        private DataTable GetFullTables()
        {
            string cadenaDataSetListDatos = GetPathFile("ListDatos");
            DataSet dataSetListDatos = JsonConvert.DeserializeObject<DataSet>(cadenaDataSetListDatos);
            DataTable dataTableListSaldoInicialDatos = new DataTable();
            dataTableListSaldoInicialDatos = dataSetListDatos.Tables["dataTableListSaldoInicialDatos"];

            DataTable dataTableListIngresosDatos = new DataTable();
            dataTableListIngresosDatos = dataSetListDatos.Tables["dataTableListIngresosDatos"];
            DataTable dataTableListListEgresosDatos = new DataTable();
            dataTableListListEgresosDatos = dataSetListDatos.Tables["dataTableListListEgresosDatos"];
            string cadenaDataSetListDescripcion = GetPathFile("ListDatos");
            DataSet dataSetListDescripcion = JsonConvert.DeserializeObject<DataSet>(cadenaDataSetListDescripcion);
            DataTable dataTableListSaldoInicialDescripcion = new DataTable();
            dataTableListSaldoInicialDescripcion = dataSetListDatos.Tables["dataTableListSaldoInicialDescripcion"];
            DataTable dataTableListIngresosDescripcion = new DataTable();
            dataTableListIngresosDescripcion = dataSetListDatos.Tables["dataTableListIngresosDescripcion"];
            DataTable dataTableListEgresosDescripcion = new DataTable();
            dataTableListEgresosDescripcion = dataSetListDatos.Tables["dataTableListEgresosDescripcion"];
            DataTable dataTableListCustumers = new DataTable();
            dataTableListCustumers = dataSetListDatos.Tables["dataTableListCustumers"];
            return dataTableListSaldoInicialDatos;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        private DataTable FilterTable(DataTable table, DateTime fechaInicio)
        {
            var filteredRows =
                from row in table.Rows.OfType<DataRow>()
                where (DateTime)row[1] <= fechaInicio
                select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptFldcd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}