using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace BusinessLayer
{
    public class QueriesCompleteDatabase
    {
        public int identificacionReporte { get; set; } // 1 = Estado de situación financiera, 2 = ...
        public string jsonDataSetDBComplete { get; set; }
        public string jsonDataSetRubrosByFormatos { get; set; } // Se le pasa la tabla que tiene la lista de cuentas según su formato (activo/pasivo)
        public bool tipoMoneda { get; set; }
        public int mesProceso { get; set; }
        MergeTables mergeTables = new MergeTables();
        public DataTable GenerateReportEstadosFinancieros()
        {
            DataSet dataSetRubros = JsonConvert.DeserializeObject<DataSet>(jsonDataSetRubrosByFormatos); // Desearealización del dataset que contiene las listas de activo, pasivo y patrominio
            DataTable[] listRubrosActivo = new DataTable[10];
            DataTable[] listRubrosPasivo = new DataTable[10];
            for (int i = 0; i < 10; i++)
            {
                listRubrosActivo[i] = dataSetRubros.Tables["listNamesActivo" + i.ToString()]; // Tabla con los rubros y sus descripciones
                listRubrosPasivo[i] = dataSetRubros.Tables["listNamesPasivo" + i.ToString()];
            }
            DataTable[] listRubrosActivoFinalFlash = new DataTable[10];
            DataTable[] listRubrosPasivoFinalFlash = new DataTable[10];
            DataSet ActivosComplete = new DataSet();
            for (int i = 0; i < 10; i++)
            {
                listRubrosActivoFinalFlash[i]   = AddColumnWithValues(listRubrosActivo[i], GetDataEstadosFinancieros(), "Decimal", "Total", "Rubro");
                listRubrosPasivoFinalFlash[i]   = AddColumnWithValues(listRubrosPasivo[i], GetDataEstadosFinancieros(), "Decimal", "Total", "Rubro");
            }
            for (int i = 1; i < 10; i++)
            {
                if (listRubrosActivoFinalFlash[i].Rows.Count > 2)
                {
                    foreach (DataRow item in listRubrosActivoFinalFlash[i].Rows)
                    {
                        listRubrosActivoFinalFlash[0].ImportRow(item);
                    }
                }
                if (listRubrosPasivoFinalFlash[i].Rows.Count > 2)
                {
                    foreach (DataRow item in listRubrosPasivoFinalFlash[i].Rows)
                    {
                        listRubrosPasivoFinalFlash[0].ImportRow(item);
                    }
                }
            }
            DataTable tableActivosFinalFlash    = listRubrosActivoFinalFlash[0]; // Neta estas tablas si son la culminación de los procesamientos, ahora falta darle el orden para que se unan todos y formen una sola big table
            DataTable tablePasivosFinalFlash    = listRubrosPasivoFinalFlash[0];
            DataTable tableFinalFlash           = new DataTable();
            tableFinalFlash                     = AddColumn(tableFinalFlash, "String", "Rubro A");
            tableFinalFlash                     = AddColumn(tableFinalFlash, "String", "Activo");
            tableFinalFlash                     = AddColumn(tableFinalFlash, "String", "Total activo");
            tableFinalFlash                     = AddColumn(tableFinalFlash, "String", "Rubro B");
            tableFinalFlash                     = AddColumn(tableFinalFlash, "String", "Pasivo y patrimonio");
            tableFinalFlash                     = AddColumn(tableFinalFlash, "String", "Total pasivo y patrimonio");

            DataRow row;
            foreach (DataRow item in tableActivosFinalFlash.Rows)
            {
                row = tableFinalFlash.NewRow();
                row["Rubro A"]      = item[0].ToString();
                row["Activo"]       = item[1].ToString();
                row["Total activo"] = item[2].ToString();
                tableFinalFlash.Rows.Add(row);
            }
            tablePasivosFinalFlash.Columns[0].ColumnName = "Rubro B";
            tablePasivosFinalFlash.Columns[1].ColumnName = "Pasivo y patrimonio";
            tablePasivosFinalFlash.Columns[2].ColumnName = "Total pasivo y patrimonio";
            if (tableActivosFinalFlash.Rows.Count > tablePasivosFinalFlash.Rows.Count)
            {
                int diferencia = tableActivosFinalFlash.Rows.Count - tablePasivosFinalFlash.Rows.Count;
                for (int i = 0; i < diferencia; i++)
                {
                    tablePasivosFinalFlash.Rows.Add();
                }
            }
            for (int i = 0; i < tablePasivosFinalFlash.Rows.Count; i++)
            {
                tableFinalFlash.Rows[i]["Rubro B"]                      = tablePasivosFinalFlash.Rows[i]["Rubro B"].ToString();
                tableFinalFlash.Rows[i]["Pasivo y patrimonio"]          = tablePasivosFinalFlash.Rows[i]["Pasivo y patrimonio"].ToString();
                tableFinalFlash.Rows[i]["Total pasivo y patrimonio"]    = tablePasivosFinalFlash.Rows[i]["Total pasivo y patrimonio"].ToString();
            }
            // Agregar totales
            decimal totalActivo = 0;
            foreach (DataRow item in tableFinalFlash.Rows)
            {
                if (item["Rubro A"].ToString() != "")
                {
                    if (item["Rubro A"].ToString().Substring(2, 2) == "99")
                    {
                        try
                        {
                            totalActivo += decimal.Parse(item["Total activo"].ToString());
                        }
                        catch (Exception)
                        {
                            totalActivo += 0;
                        }
                    }
                }
            }
            decimal totalPasivo = 0;
            foreach (DataRow item in tableFinalFlash.Rows)
            {
                if (item["Rubro B"].ToString() != "")
                {
                    if (item["Rubro B"].ToString().Substring(2, 2) == "99")
                    {
                        try
                        {
                            totalPasivo += decimal.Parse(item["Total pasivo y patrimonio"].ToString());
                        }
                        catch (Exception)
                        {
                            totalPasivo += 0;
                        }
                    }
                }
            }
            DataRow rowTotales = tableFinalFlash.NewRow();
            rowTotales["Rubro A"]       = "A999";
            rowTotales["Activo"]        = "Total Activo";
            rowTotales["Total activo"]  = totalActivo.ToString();
            rowTotales["Rubro B"]       = "P999";
            rowTotales["Pasivo y patrimonio"]       = "Total pasivo y patrimonio neto";
            rowTotales["Total pasivo y patrimonio"] = totalPasivo.ToString();
            tableFinalFlash.Rows.Add(rowTotales);

            //Agregar separadores de miles y símbolo
            tableFinalFlash = AddFormatToTable(tableFinalFlash, "Total activo", "Total pasivo y patrimonio");
            return tableFinalFlash;
        }
        public DataTable GetDataEstadosFinancieros()
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonDataSetDBComplete); // Desearealización del dataset de la bd completa
            DataTable datatable = dataSet.Tables["plan"]; // instancia de la tabla PLAN
            DataTable dataTableCompleteActivos  = mergeTables.GetTableByFilters(datatable, "a", 3, "c", 1, "d", true); // Tabla activos, el último parámetro booleano es para indicar que se busque estrictamente todos los filtros
            DataTable dataTableCompletePasivos  = mergeTables.GetTableByFilters(datatable, "a", 3, "c", 2, "d", true); // Tabla Pasivos
            DataTable tableProcessedActivos     = GetTotalByCuentasInUniqueRubro(dataTableCompleteActivos, true);
            DataTable tableProcessedPasivos     = GetTotalByCuentasInUniqueRubro(dataTableCompletePasivos, false);
            tableProcessedActivos.Merge(tableProcessedPasivos);
            DataTable tableFiltroRubros         = tableProcessedActivos.DefaultView.ToTable(true, "Rubro");
            DataTable tableWithTotalByRubros    = SumBasedInListNames(tableFiltroRubros, tableProcessedActivos, "Rubro");
            return  tableWithTotalByRubros;
        }
        public DataTable GetTotalByCuentasInUniqueRubro(DataTable dataTableForProcess, bool reportActivo)
        {
            DataTable finalDataTable = new DataTable();
            decimal[] totalPorMes = new decimal[14];
            string[] ndebe, nhaber;

            #region Declaración de columnas
            DataColumn column;
            DataRow row;
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Cuenta"
            };
            finalDataTable.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.Decimal"),
                ColumnName = "Total"
            };
            finalDataTable.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Rubro"
            };
            finalDataTable.Columns.Add(column);
            #endregion

            if (tipoMoneda) // soles
            {
                ndebe = new string[16] { "i", "k", "m", "o", "q", "s", "u", "w", "y", "aa", "ac", "ae", "ag", "ai", "ak", "am" };
                nhaber = new string[16] { "j", "l", "n", "p", "r", "t", "v", "x", "z", "ab", "ad", "af", "ah", "aj", "al", "an" };
            }
            else            // Dólares
            {
                ndebe = new string[16] { "aq", "as", "au", "aw", "ay", "ba", "bc", "be", "bg", "bi", "bk", "bm", "bo", "bq", "bs", "bu" };
                nhaber = new string[16] { "ar", "at", "av", "ax", "az", "bb", "bd", "bf", "bh", "bj", "bl", "bn", "bp", "br", "bt", "bv" };
            }
            #region Resta del debe y haber totalizado HASTA el mes de proceso
            if (dataTableForProcess.Rows.Count > 0)
            {
                for (int i = 0; i < dataTableForProcess.Rows.Count; i++) // Rows[i][1] i se refiere al número de fila, 1 es la posición de la columna
                {
                    row = finalDataTable.NewRow();
                    row["Cuenta"] = dataTableForProcess.Rows[i]["a"].ToString();
                    if (reportActivo) // Sí es TRUE, entonces es ACTIVO { Resta del debe menos el haber, este proceso se realiza mes tras mes hasta el mes de proceso }
                    { // Se hace todos los cálculos en base a sólo los activos
                        try
                        {
                            totalPorMes[0] = Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[0]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[0]].ToString());
                        }
                        catch
                        { totalPorMes[0] = 0; }

                        for (int j = 0; j < mesProceso; j++) // Sí ocurre problemas con el mes cero aquí esta el problema mi estimado
                        {
                            try
                            {
                                totalPorMes[j + 1] = totalPorMes[j] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[j + 1]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[j + 1]].ToString());
                            }
                            catch
                            { totalPorMes[j + 1] = 0; }
                        }
                        if (mesProceso == 12) // ya que en el mes 12 se toma los datos del mes 13 tambien, entonces hacemos el calculo del monto por separado, pero sólo en caso de que el usuario lo haya solicitado
                        {
                            try
                            {
                                totalPorMes[12] = totalPorMes[11] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[12]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[12]].ToString());
                                totalPorMes[13] = Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[13]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[13]].ToString());
                                totalPorMes[12] = totalPorMes[12] + totalPorMes[13];
                            }
                            catch
                            { totalPorMes[12] = 0; }
                        }
                    }
                    else // Sino, entonces es PASIVO como tú comprenderas
                    {
                        try
                        {
                            totalPorMes[0] = Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[0]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[0]].ToString());
                        }
                        catch
                        { totalPorMes[0] = 0; }

                        for (int j = 0; j < mesProceso; j++) // Sí ocurre problemas con el mes cero aquí esta el problema mi estimado
                        {
                            try
                            {
                                totalPorMes[j + 1] = totalPorMes[j] + Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[j + 1]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[j + 1]].ToString());
                            }
                            catch
                            { totalPorMes[j + 1] = 0; }
                        }

                        if (mesProceso == 12)
                        {
                            try
                            {
                                totalPorMes[12] = totalPorMes[11] + Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[12]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[12]].ToString());
                                totalPorMes[13] = Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[13]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[13]].ToString());
                                totalPorMes[12] = totalPorMes[12] + totalPorMes[13];
                            }
                            catch
                            { totalPorMes[12] = 0; }
                        }
                    }
                    if (totalPorMes[mesProceso] > 0) // Significa que salió positivo entonces se añade a los activos sin problemas
                    {
                        row["Total"] = totalPorMes[mesProceso];
                        row["Rubro"] = dataTableForProcess.Rows[i]["bx"].ToString();
                    }
                    else // Aca tenemos que el resultado para ésta cuenta es negativo, entonces hacemos las validaciones para en que rubro se queda
                    {
                        if (dataTableForProcess.Rows[i]["by"].ToString().Trim() == "") // Aquí hacemos las validaciones; buscamos en { by = ccod_baln2 } sí esta vacío entonces se pone lo que haya en { bx = ccod_bal2 }
                        {
                            row["Total"] = totalPorMes[mesProceso];
                            row["Rubro"] = dataTableForProcess.Rows[i]["bx"].ToString(); // Aquí se tiene que acumular en base al rubro. En este caso el monto de la cuenta se queda en bx porque by esta en blanco
                        }
                        else // Aquí se tiene que acumular en base al rubro. En este caso el monto de la cuenta se va a by porque by esta tiene un rubro en caso de monto negativo
                        {
                            row["Total"] = totalPorMes[mesProceso] * -1;
                            row["Rubro"] = dataTableForProcess.Rows[i]["by"].ToString();
                        }
                    }
                    finalDataTable.Rows.Add(row);
                    row.ClearErrors();
                }
            }
            #endregion
            return finalDataTable;
        }
        // Aquí se almacena un tabla con totales por cada rubro
        public DataTable SumBasedInListNames(DataTable tableNamesFiltered, DataTable tableComplete, string columnName)
        {
            DataTable finalDataTable = new DataTable();
            DataTable tableTemporal;
            decimal totalTemporal;
            #region Declaración de columnas
            DataColumn column;
            DataRow row;
            column = new DataColumn
            {
                DataType = Type.GetType("System.Decimal"),
                ColumnName = "Total"
            };
            finalDataTable.Columns.Add(column);
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Rubro"
            };
            finalDataTable.Columns.Add(column);
            #endregion
            for (int i = 0; i < tableNamesFiltered.Rows.Count; i++) // Hacer una sobrecarga, reemplazar esto y pasar como parámetro el id de rubro
            {
                tableTemporal = new DataTable();
                tableTemporal = mergeTables.GetTableByFilters(tableComplete, tableNamesFiltered.Rows[i][columnName].ToString(), columnName); // dataTable.Rows[row][column]
                totalTemporal = new decimal();
                foreach (DataRow item in tableTemporal.Rows)
                {
                    totalTemporal += decimal.Parse(item["Total"].ToString());
                }
                row = finalDataTable.NewRow();
                row["Total"] = totalTemporal;
                row["Rubro"] = tableNamesFiltered.Rows[i][columnName].ToString();
                finalDataTable.Rows.Add(row);
                row.ClearErrors();
                totalTemporal = 0;
            }
            return finalDataTable;
        }
        public DataTable AddColumn(DataTable finalDataTable, string type, string columnName) {
            DataColumn column;
            column = new DataColumn
            {
                DataType = Type.GetType("System." + type),
                ColumnName = columnName
            };
            finalDataTable.Columns.Add(column);
            return finalDataTable;
        }
        public DataTable AddColumnWithValues(DataTable dataTable, DataTable tableCompare, string type, string columnName1, string columnName2) { // columnName = total
            DataColumn column;
            decimal total = 0;
            try
            {
                if (dataTable.Rows.Count > 0 && !DBNull.Value.Equals(0))
                {
                    column = new DataColumn
                    {
                        DataType = Type.GetType("System." + type),
                        ColumnName = columnName1
                    };
                    dataTable.Columns.Add(column);
                    dataTable.Columns[0].ColumnName = columnName2;
                    dataTable.Columns[1].ColumnName = "Descripción";
                    foreach (DataRow item in dataTable.Rows)
                    {
                        try
                        {   // tabla, rubro, idRubro, total
                            item[columnName1] = mergeTables.GetDecimalByIdInDataTable(tableCompare, columnName2, item[columnName2].ToString(), columnName1);
                        }
                        catch
                        {
                            item[columnName1] = 0;
                        }
                    }
                    foreach (DataRow item in dataTable.Rows)
                    {
                        if (item[columnName2].ToString().Trim().Substring(2, 2) != "99")
                        {
                            total += decimal.Parse(item[columnName1].ToString());
                        }
                    }
                    if (dataTable.Rows[dataTable.Rows.Count - 1][columnName2].ToString().Trim().Substring(2, 2) == "99") // El "a" representa la columna de los ricos rubros mi estimado
                    {
                        dataTable.Rows[dataTable.Rows.Count - 1][columnName1] = total;
                    }
                    else // agregar row
                    {
                        DataRow row = dataTable.NewRow();
                        row["Rubro"] = dataTable.Rows[dataTable.Rows.Count - 1][columnName2].ToString().Trim().Substring(0, 2) + "99";
                        row[columnName1] = total;
                        dataTable.Rows.Add(row);
                    }
                }
            }
            catch (Exception)
            {
               
            }
            return dataTable;
        }
        //Agregar separadores de miles y símbolo
        public DataTable AddFormatToTable(DataTable table, String ColumnName1, String ColumnName2) {
            NumberFormatInfo nfi;
            if (tipoMoneda)
                nfi = new CultureInfo("es-PE", false).NumberFormat;
            else
                nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 2;
            nfi.NumberGroupSeparator = " ";
            foreach (DataRow item in table.Rows)
            {
                item[ColumnName1] = item[ColumnName1].ToString();
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][ColumnName1].ToString() == "")
                    table.Rows[i][ColumnName1] = "0";
                if (table.Rows[i][ColumnName2].ToString() == "")
                    table.Rows[i][ColumnName2] = "0";
                table.Rows[i][ColumnName1] = decimal.Parse(table.Rows[i][ColumnName1].ToString()).ToString("C", nfi);
                table.Rows[i][ColumnName2] = decimal.Parse(table.Rows[i][ColumnName2].ToString()).ToString("C", nfi);
            }
            return table;
        }
        public string GetOnlyOneResult(int indexFormato, string nameRubro) {
            DataSet dataSetRubros = JsonConvert.DeserializeObject<DataSet>(jsonDataSetRubrosByFormatos); // Desearealización del dataset que contiene las listas de activo, pasivo y patrominio
            DataTable[] listRubrosActivo = new DataTable[10];
            listRubrosActivo[indexFormato] = dataSetRubros.Tables["listNamesActivo" + indexFormato.ToString()]; // Tabla con los rubros y sus descripciones
            DataTable[] listRubrosActivoFinalFlash = new DataTable[10];
            listRubrosActivoFinalFlash[indexFormato]   = AddColumnWithValues(listRubrosActivo[indexFormato], GetDataEstadosFinancieros(), "Decimal", "Total", "Rubro");
            string valor = "";

            foreach (DataRow item in listRubrosActivoFinalFlash[indexFormato].Rows)
            {
                if (item["Rubro"].ToString().Trim() == nameRubro)
                    return item["Total"].ToString();
                else
                    valor = "0";
            }
            return valor;
        }
    }
}
