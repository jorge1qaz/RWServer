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
        #region Declaración de variables
        Paths paths                 = new Paths();
        MergeTables mergeTables     = new MergeTables();
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
        #endregion
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { frecuencia  = int.Parse(Session["FCDFrecuencia"].ToString()); }
            catch (Exception)
            { frecuencia = 7; }
            try
            { periodo     = int.Parse(Session["FCDPeriodo"].ToString()); }
            catch (Exception)
            { periodo = 12; }

            if (!Page.IsPostBack)
            {
                #region Fill tables
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
                #endregion
            }
            try
            { fechaInicial = DateTime.Parse(Session["FCDFechaInicio"].ToString()); }
            catch (Exception)
            { fechaInicial = DateTime.Now; }
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
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = "";
            try
            { JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptFldcd/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'"); }
            catch (Exception)
            {
                Response.Write("<script>alert('Ha ocurrido un error inesperado, vuelva a ingresar al reporte.')</script>");
                Response.Redirect("~/Reportes/Dashboard.aspx");
            }
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
            DataTable listCuentasTable = mergeTables.GetListDist(tableInitDatosIngresos, "a");

            List<string> listCuentas    = new List<string>();
            List<string> listDocumentos = new List<string>();

            foreach (DataRow item in listCuentasTable.Rows)
                listCuentas.Add(item[0].ToString());
            
            DataTable[] tableFirstBlockIngresos = new DataTable[listCuentas.Count + 1];

            for (int i = 0; i < listCuentas.Count; i++)
                tableFirstBlockIngresos[i] = mergeTables.GetTableByFilters(tableInitDatosIngresos, "b", listCuentas[i], "a");

            DataTable[] tableSecondBlockIngresosSoles = new DataTable[listCuentas.Count + 1];
            DataTable[] tableSecondBlockIngresosDolares= new DataTable[listCuentas.Count + 1];

            for (int i = 0; i < listCuentas.Count; i++)
                tableSecondBlockIngresosSoles[i] = mergeTables.GetTableByFilters(tableFirstBlockIngresos[i], "b", "S", "f");

            for (int i = 0; i < listCuentas.Count; i++)
                tableSecondBlockIngresosDolares[i] = mergeTables.GetTableByFilters(tableFirstBlockIngresos[i], "b", "D", "f");

            DataTable[] tableThirdBlockIngresosCFVSoles = new DataTable[listCuentas.Count];
            DataTable[] tableThirdBlockIngresosSFVSoles = new DataTable[listCuentas.Count];
            DataTable[] tableThirdBlockIngresosCFVDolares = new DataTable[listCuentas.Count];
            DataTable[] tableThirdBlockIngresosSFVDolares = new DataTable[listCuentas.Count];
            
            for (int i = 0; i < listCuentas.Count; i++) // Obtienes las tablas básicas, pero por cada cuenta
            {
                tableThirdBlockIngresosCFVSoles[i]  = mergeTables.GetTableByFilters(tableSecondBlockIngresosSoles[i], conFechaVencimiento, DateTime.Now, 3);
                tableThirdBlockIngresosSFVSoles[i]  = mergeTables.GetTableByFilters(tableSecondBlockIngresosSoles[i], sinFechaVencimiento, DateTime.Now, 3); // Tú tú
                tableThirdBlockIngresosCFVDolares[i] = mergeTables.GetTableByFilters(tableSecondBlockIngresosDolares[i], conFechaVencimiento, DateTime.Now, 3);
                tableThirdBlockIngresosSFVDolares[i] = mergeTables.GetTableByFilters(tableSecondBlockIngresosDolares[i], sinFechaVencimiento, DateTime.Now, 3);
            }
            //DataTable pum = new DataTable();
            //pum = resultado2(tableThirdBlockIngresosSFVSoles, 0); // trigger

            //grdPruebas.DataSource = pum;
            //grdPruebas.DataBind();

            DataTable[] arraySFVS = new DataTable[tableThirdBlockIngresosSFVSoles.Length]; // Este array de tablas, almacena los datos de todas las cuentas en base a SFVSoles
            DataTable[] arraySFVD = new DataTable[tableThirdBlockIngresosSFVDolares.Length];

            for (Int16 i = 0; i < tableThirdBlockIngresosSFVSoles.Length; i++)
            {
                arraySFVS[i] = ProcesarDatosSinFechaVencimiento(tableThirdBlockIngresosSFVSoles, i, true);
                arraySFVS[0].Merge(arraySFVS[i]);
            }
            for (Int16 i = 0; i < tableThirdBlockIngresosSFVDolares.Length; i++)
            {
                arraySFVD[i] = ProcesarDatosSinFechaVencimiento(tableThirdBlockIngresosSFVDolares, i, true);
                arraySFVD[0].Merge(arraySFVD[i]);
            }
            arraySFVS[0].Merge(arraySFVD[0]);
            grdPruebas.DataSource = arraySFVS[0];
            grdPruebas.DataBind();
        }

        public DataTable ProcesarDatosSinFechaVencimiento(DataTable[] tableBlock, Int16 index, bool moneda)
        {
            string debe = "";
            string haber = "";
            if (moneda) // if true then soles else dólares
            {
                debe = "h"; haber = "i";
            }
            else
            {
                debe = "hd"; haber = "id";
            }
            DataTable finalFlash = new DataTable();
            finalFlash = CalculoTotales(tableBlock[index], tableBlock[index].DefaultView.ToTable(true, "g", "e", "a", "f", "b", "c", "d"), "g", "e", debe, haber, "Vencidos");
            return finalFlash; // Devuelve la tabla contenedora de todos los datos procesados, listos para la fuuuusión!
        }
        public DataTable CalculoTotales(DataTable tableDocumento, DataTable tableDist, string columnNameFilter1, string columnNameFilter2, //columnNameFilter1 = documento [0]; 
            string columnNameDebe, string columnNameHaber, string columnNameResult) { // columnNameFilter2 = número de documento [1]
            double debe = 0, haber = 0;
            decimal resultado = 0;
            DataTable tableContent = new DataTable(); // Instancia de tabla la cual se exportará al reporte
            DataColumn column = new DataColumn();
            DataRow row;
            #region Declaración de columnas
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cuenta";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Documento";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Número";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Moneda";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Descripción";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fecha documento";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Fecha vencimiento";
            tableContent.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Vencidos";
            tableContent.Columns.Add(column);
           
            #endregion
            foreach (DataRow item in tableDist.Rows)
            {
                try
                { // Con este filtro se puede recolectar los datos según su código de documento y su número de documento, y totalizar los resultados del 'debe'
                    debe    = tableDocumento.AsEnumerable().Where(x => x.Field<string>(columnNameFilter1).Trim() == item[0].ToString()).
                                Where(x => x.Field<string>(columnNameFilter2).Trim() == item[1].ToString()).Select(x => x.Field<double>(columnNameDebe)).Sum();
                }
                catch (Exception)
                {   debe    = 0; }
                try
                { // Con este filtro se puede recolectar los datos según su código de documento y su número de documento, y totalizar los resultados del 'haber'
                    haber   = tableDocumento.AsEnumerable().Where(x => x.Field<string>(columnNameFilter1).Trim() == item[0].ToString()).
                                Where(x => x.Field<string>(columnNameFilter2).Trim() == item[1].ToString()).Select(x => x.Field<double>(columnNameHaber)).Sum();
                }
                catch (Exception)
                {   haber = 0; }
                resultado   = Convert.ToDecimal(debe) - Convert.ToDecimal(haber);
                DateTime fechaDocumento = DateTime.Parse(item[5].ToString());
                DateTime fechaVencimiento = DateTime.Parse(item[6].ToString());
                row         = tableContent.NewRow();
                row["Cuenta"]               = item[2].ToString();
                row["Documento"]            = item[1].ToString();
                row["Número"]               = item[0].ToString();
                row["Moneda"]               = item[3].ToString();
                row["Descripción"]          = item[4].ToString();
                row["Fecha documento"]      = fechaDocumento.ToShortDateString();
                row["Fecha vencimiento"]    = fechaVencimiento.ToShortDateString();
                row[columnNameResult] = resultado;
                tableContent.Rows.Add(row);
            }
            return tableContent;
        }
    }
}