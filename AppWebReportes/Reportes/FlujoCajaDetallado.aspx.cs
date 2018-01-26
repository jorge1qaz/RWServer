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
        DateTime fechaInicial = new DateTime();
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dataTable = new DataTable();
            //dataTable = GetFullTables();
            try
            {
                fechaInicial = DateTime.Parse(Session["FCDFechaInicio"].ToString());
            }
            catch (Exception)
            {
                fechaInicial = DateTime.Now;
            }
            //Response.Write(Session["FCDFechaInicio"].ToString());
            //grdPruebas.DataSource = GetTableEstadoInicial();
            //grdPruebas.DataBind();

            //GetTableEstadoInicial();

            MetodoDePruebas();
        }
        
        public void MetodoDePruebas() {
            try
            {
                fechaInicial = DateTime.Parse(Session["FCDFechaInicio"].ToString());
            }
            catch (Exception)
            {
                fechaInicial = DateTime.Now;
            }
            string cadenaDataSetListDatos = GetPathFile("ListDatos");       // Declaración de la varaible que contendrá todo el dataSet
            DataSet dataSetListDatos = JsonConvert.DeserializeObject<DataSet>(cadenaDataSetListDatos); // Deserealización del dataSet
            DataTable tableInit = dataSetListDatos.Tables["dataTableListSaldoInicialDatos"];
            DataTable tableFiltered = mergeTables.GetTableByDate(tableInit, fechaInicial);

            DataTable dataTableListSaldoInicialDatosListNames = mergeTables.GetListDist(tableFiltered, "a");
            //decimal GetTotalByTable(DataTable tableData, DataTable tableList, string idColumn, string NameColumn1, string NameColumn2, bool discriminative, bool negativeValue)

            decimal valoorrrr = mergeTables.GetTotalByTable(tableFiltered, dataTableListSaldoInicialDatosListNames, "a", "c", "d", "g", "S");

            Response.Write(valoorrrr.ToString());

            DataTable tableSumByCount = new DataTable();

            int frecuencia = int.Parse(Session["FCDFrecuencia"].ToString()); // 7 días
            int periodo = int.Parse(Session["FCDPeriodo"].ToString()); // Periodo es de 10
            int frecuenciaIncremetado = frecuencia;
            //DataColumn[] column = new DataColumn[periodo];

            List<string> listDates = new List<string>();

            DataColumn column = new DataColumn();
            #region Declaración de columnas
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cuenta";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Documento";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Número";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Moneda";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Descripción";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fecha documento";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fecha vencimiento";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "SolesDolares vencidos";
            tableSumByCount.Columns.Add(column);
            #endregion

            for (int i = 0; i < periodo; i++)
            { 
                frecuenciaIncremetado += frecuencia;

                Type columnType = Type.GetType("System.Decimal");
                String columnName = fechaInicial.AddDays(frecuenciaIncremetado - 1).ToShortDateString().Trim();
                listDates.Add(columnName);
                tableSumByCount.Columns.Add(new DataColumn(columnName, columnType));
            }
            DataRow row = tableSumByCount.NewRow();

            int val = 5; 
            for (int i = 0; i < listDates.Count; i++)
            {
                row[listDates[i]] = val++;

            }
            tableSumByCount.Rows.Add(row);
            grdPruebas.DataSource = tableSumByCount; // GridView de pruebas
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
            //Response.Write();
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