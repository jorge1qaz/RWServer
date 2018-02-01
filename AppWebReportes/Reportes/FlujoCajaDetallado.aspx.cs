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
        Paths paths                 = new Paths();
        MergeTables mergeTables     = new MergeTables();
        string  list1               = "";
        decimal totalSaldoInicial   = 0;
        decimal totalIngresos       = 0;
        decimal totalEgresos        = 0;
        int frecuencia              = 0;
        int periodo                 = 0;
        bool moneda                 = true; // Por defecto en soles

        DateTime fechaInicial        = new DateTime();
        DateTime sinFechaVencimiento = Convert.ToDateTime("12/12/1800");
        DateTime conFechaVencimiento = Convert.ToDateTime("12/12/1900");

        //Tablas
        DataSet dataSetListDatos                    = new DataSet();
        DataTable tableInitDatosSaldoInicial        = new DataTable();
        DataTable tableInitDatosIngresos            = new DataTable();
        DataTable tableInitDatosEgresos             = new DataTable();

        DataSet dataSetListDescripcion              = new DataSet();
        DataTable tableInitDescripcionSaldoInicial  = new DataTable();
        DataTable tableInitDescripcionIngresos      = new DataTable();
        DataTable tableInitDescripcionEgresos       = new DataTable();
        DataTable tableInitDescripcionCostumer      = new DataTable();

        DataTable tableJustNamesSaldoInicial        = new DataTable();
        DataTable tableJustNamesListCustumers       = new DataTable();
        DataTable tableReport                       = new DataTable();

        List<string> listDates = new List<string>();

        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        protected void Page_Load(object sender, EventArgs e)
        {
            frecuencia  = int.Parse(Session["FCDFrecuencia"].ToString());
            periodo     = int.Parse(Session["FCDPeriodo"].ToString());

            dataSetListDatos = JsonConvert.DeserializeObject<DataSet>(GetPathFile("ListDatos")); // Deserealización del dataSet
            tableInitDatosSaldoInicial = dataSetListDatos.Tables["dataTableListSaldoInicialDatos"];
            tableInitDatosIngresos = dataSetListDatos.Tables["dataTableListIngresosDatos"];
            tableInitDatosEgresos = dataSetListDatos.Tables["dataTableListEgresosDatos"];

            dataSetListDescripcion = JsonConvert.DeserializeObject<DataSet>(GetPathFile("ListDescripcion"));
            tableInitDescripcionSaldoInicial = dataSetListDescripcion.Tables["dataTableListSaldoInicialDescripcion"];
            tableInitDescripcionIngresos = dataSetListDatos.Tables["dataTableListIngresosDescripcion"];
            tableInitDescripcionEgresos = dataSetListDatos.Tables["dataTableListEgresosDescripcion"];
            tableInitDescripcionCostumer = dataSetListDatos.Tables["dataTableListCustumers"];

            tableJustNamesSaldoInicial = mergeTables.GetListDist(tableInitDescripcionSaldoInicial, "a");
            tableJustNamesListCustumers = mergeTables.GetListDist(dataSetListDescripcion.Tables["dataTableListCustumers"], "a");
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
            { }
            int frecuenciaIncremetado = 0;
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
            //GenerateReportSaldoInicial();
            temp();
        }
        public void GenerateReportSaldoInicial() {
            
            DataRow row = tableReport.NewRow();
            row["Cuenta"] = "Saldo";
            row["Descripción"] = "Saldo inicial";
            tableReport.Rows.Add(row);

            DataTable tableResultSaldoInicial = mergeTables.GetTotalByTable(mergeTables.GetTableByDate(tableInitDatosSaldoInicial, conFechaVencimiento, fechaInicial, 1),
                tableJustNamesSaldoInicial, "a", "c", "d", "g", "D", listDates[0], moneda); //True moneda soles
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
            DataTable tableResultIngresos = mergeTables.GetTotalByTable(mergeTables.GetTableByDate(tableInitDatosIngresos, Convert.ToDateTime("30/12/1900"), fechaInicial.AddDays(frecuencia), 3),
                tableJustNamesSaldoInicial, "a", "c", "d", "g", "D", listDates[0], moneda); //True moneda soles
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
            row[listDates[0]] = totalSaldoInicial + totalIngresos + totalEgresos;
            tableReport.Rows.Add(row);

            for (int i = 4; i < listDates.Count; i++)
                row[listDates[i]] = totalSaldoInicial + totalIngresos + totalEgresos;

            DataRow[] customerRow = tableReport.Select("Cuenta = 'Saldo'");

            customerRow[0][listDates[0]] = totalSaldoInicial + totalIngresos + totalEgresos;
            customerRow[0][listDates[1]] = totalSaldoInicial + totalIngresos + totalEgresos;

            grdPruebas.DataSource = tableReport; // GridView de pruebas
            grdPruebas.DataBind();

            //grdPruebas.DataSource = mergeTables.GetTableByDate(tableInitDatosIngresos, Convert.ToDateTime("30/12/1888"), fechaInicial.AddDays(frecuencia), 3);
            //grdPruebas.DataBind();
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptFldcd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
        public void temp()
        {
            int frecuenciaTemporal = 0;
            DateTime fechaTemporalTope = new DateTime();
            DateTime fechaTemporalInicio = new DateTime();
            List<DateTime> rangoFechas = new List<DateTime>();
            rangoFechas.Add(conFechaVencimiento);

            for (int i = 1; i < periodo; i++)
            {
                frecuenciaTemporal = frecuencia * i;
                fechaTemporalTope = fechaInicial.AddDays(frecuenciaTemporal - 1);
                fechaTemporalInicio = fechaInicial.AddDays(frecuenciaTemporal);
                rangoFechas.Add(fechaTemporalTope);
                rangoFechas.Add(fechaTemporalInicio);
            }
            foreach (var item in rangoFechas)
            {
                Response.Write(" i " + item + " f ");
            }
            DataTable tempDtListDistCuentas = mergeTables.GetListDist(tableInitDatosIngresos, "a");
            DataTable tempSoles = mergeTables.GetTableByFilters(tableInitDatosIngresos, "S", 6);
            DataTable tempDolares = mergeTables.GetTableByFilters(tableInitDatosIngresos, "D", 6);

            grdPruebas.DataSource = tempDolares;
            grdPruebas.DataBind();
        }
    }
}