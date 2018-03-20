using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class QueriesCompleteDatabase
    {
        public int      identificacionReporte       { get; set; } // 1 = Estado de situación financiera, 2 = ...
        public string   jsonDataSetDBComplete       { get; set; }
        public string   jsonDataSetRubrosByFormatos { get; set; } // Se le pasa la tabla que tiene la lista de cuentas según su formato (activo/pasivo)
        public bool     tipoMoneda                  { get; set; }
        public int      mesProceso                  { get; set; }

        MergeTables mergeTables = new MergeTables();
        public decimal GetTotalByTablePlan(bool reportActivo) // Devuelve un total por rubro QUITAR ESTE METODO JODER
        {
            DataSet dataSet     = JsonConvert.DeserializeObject<DataSet>(jsonDataSetDBComplete); // Desearealización del dataset de la bd completa
            DataTable datatable = dataSet.Tables["plan"]; // instancia de la tabla PLAN
            DataTable dataTableListCuentas = new DataTable(); // Instancia de la tabla que contendrá sólo las cuentas de la tabla
            string[] ndebe;
            string[] nhaber;
            decimal[] totalByCuenta;

            if (tipoMoneda)
            {
                 ndebe      = new string[16] { "i", "k", "m", "o", "q", "s", "u", "w", "y", "aa", "ac", "ae", "ag", "ai", "ak", "am" }; 
                 nhaber     = new string[16] { "j", "l", "n", "p", "r", "t", "v", "x", "z", "ab", "ad", "af", "ah", "aj", "al", "an" };
            }
            else
            {
                 ndebe      = new string[16] { "aq", "as", "au", "aw", "ay", "ba", "bc", "be", "bg", "bi", "bk", "bm", "bo", "bq", "bs", "bu" };
                 nhaber     = new string[16] { "ar", "at", "av", "ax", "az", "bb", "bd", "bf", "bh", "bj", "bl", "bn", "bp", "br", "bt", "bv" };
            }
            DataSet dataSetRubros       = JsonConvert.DeserializeObject<DataSet>(jsonDataSetRubrosByFormatos); // Desearealización del dataset que contiene las listas de activo, pasivo y patrominio
            DataTable listRubrosPasivo  = new DataTable();
            DataTable datatableFilteredByCuentasPasivo = new DataTable();
            DataTable listRubrosActivo  = new DataTable();
            DataTable datatableFilteredByCuentasActivo = new DataTable();

            switch (identificacionReporte) // Indica cual es el reporte sobre el cual esta trabajando
            {
                case 1: // 1 = Estado de situación financiera
                    DataTable listNamesPasivo1 = dataSet.Tables["listNamesPasivo1"];
                    DataTable listNamesPasivo2 = dataSet.Tables["listNamesPasivo2"];
                    DataTable listNamesPasivo3 = dataSet.Tables["listNamesPasivo3"];
                    DataTable listNamesPasivo4 = dataSet.Tables["listNamesPasivo4"];
                    DataTable listNamesPasivo5 = dataSet.Tables["listNamesPasivo5"];
                    DataTable listNamesPasivo6 = dataSet.Tables["listNamesPasivo6"];
                    DataTable listNamesPasivo7 = dataSet.Tables["listNamesPasivo7"];
                    DataTable listNamesPasivo8 = dataSet.Tables["listNamesPasivo8"];
                    DataTable listNamesPasivo9 = dataSet.Tables["listNamesPasivo9"];

                    listNamesPasivo8.Merge(listNamesPasivo9);
                    listNamesPasivo7.Merge(listNamesPasivo8);
                    listNamesPasivo6.Merge(listNamesPasivo7);
                    listNamesPasivo5.Merge(listNamesPasivo6);
                    listNamesPasivo4.Merge(listNamesPasivo5);
                    listNamesPasivo3.Merge(listNamesPasivo4);
                    listNamesPasivo2.Merge(listNamesPasivo3);
                    listNamesPasivo1.Merge(listNamesPasivo2);
                    listRubrosPasivo.Merge(listNamesPasivo1); // la tabla listRubros ya tendrá todos los rubros del pasivo
                    datatableFilteredByCuentasPasivo = GetListCuentasByRubro(listRubrosPasivo, false); // Obtiene la tabla plan completa según sus rubros (listado de cuentas)

                    DataTable listNamesActivo1 = dataSet.Tables["listNamesActivo1"];
                    DataTable listNamesActivo2 = dataSet.Tables["listNamesActivo2"];
                    DataTable listNamesActivo3 = dataSet.Tables["listNamesActivo3"];
                    DataTable listNamesActivo4 = dataSet.Tables["listNamesActivo4"];
                    DataTable listNamesActivo5 = dataSet.Tables["listNamesActivo5"];
                    DataTable listNamesActivo6 = dataSet.Tables["listNamesActivo6"];
                    DataTable listNamesActivo7 = dataSet.Tables["listNamesActivo7"];
                    DataTable listNamesActivo8 = dataSet.Tables["listNamesActivo8"];
                    DataTable listNamesActivo9 = dataSet.Tables["listNamesActivo9"];

                    listNamesActivo8.Merge(listNamesActivo9);
                    listNamesActivo7.Merge(listNamesActivo8);
                    listNamesActivo6.Merge(listNamesActivo7);
                    listNamesActivo5.Merge(listNamesActivo6);
                    listNamesActivo4.Merge(listNamesActivo5);
                    listNamesActivo3.Merge(listNamesActivo4);
                    listNamesActivo2.Merge(listNamesActivo3);
                    listNamesActivo1.Merge(listNamesActivo2);
                    listRubrosActivo.Merge(listNamesActivo1); // la tabla listRubros ya tendra todos los rubros del activo
                    datatableFilteredByCuentasActivo = GetListCuentasByRubro(listRubrosActivo, true); // Obtiene la tabla plan completa según sus rubros (listado de cuentas)
                    break;
            }
            
            // Desde aquí estamos mal, coño
            if (datatable.Rows.Count > 0) // Comprueba si hay datos en la tabla
            {
                if (reportActivo)
                    dataTableListCuentas    = datatableFilteredByCuentasActivo.DefaultView.ToTable(true, "a");
                else
                    dataTableListCuentas    = datatableFilteredByCuentasPasivo.DefaultView.ToTable(true, "a");
                totalByCuenta = new decimal[dataTableListCuentas.Rows.Count]; // Total por cada fila, son los totales por cada cuenta
                decimal[] totalPorMes   = new decimal[12];                              // Total por mes
                for (int i = 0; i < dataTableListCuentas.Rows.Count; i++) // Rows[i][1] i se refiere al número de fila, 1 es la posición de la columna
                {
                    #region Resta del debe y haber totalizado HASTA el mes de proceso
                    DataTable dataTableForProcess   = new DataTable();
                    if (reportActivo)
                        dataTableForProcess         = datatableFilteredByCuentasActivo;
                    else
                        dataTableForProcess         = datatableFilteredByCuentasPasivo;

                    try
                    {
                        totalPorMes[0] = Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[0]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[0]].ToString());
                    }
                    catch
                    { totalPorMes[0] = 0; }
                    try
                    {
                        totalPorMes[1] = totalPorMes[0] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[1]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[1]].ToString());
                    }
                    catch
                    { totalPorMes[1] = 0; }
                    try
                    {
                        totalPorMes[2] = totalPorMes[1] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[2]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[2]].ToString());
                    }
                    catch
                    { totalPorMes[2] = 0; }
                    try
                    {
                        totalPorMes[3] = totalPorMes[2] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[3]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[3]].ToString());
                    }
                    catch
                    { totalPorMes[3] = 0; }
                    try
                    {
                        totalPorMes[4] = totalPorMes[3] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[4]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[4]].ToString());
                    }
                    catch
                    { totalPorMes[4] = 0; }
                    try
                    {
                        totalPorMes[5] = totalPorMes[4] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[5]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[5]].ToString());
                    }
                    catch
                    { totalPorMes[5] = 0; }
                    try
                    {
                        totalPorMes[6] = totalPorMes[5] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[6]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[6]].ToString());
                    }
                    catch
                    { totalPorMes[6] = 0; }
                    try
                    {
                        totalPorMes[7] = totalPorMes[6] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[7]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[7]].ToString());
                    }
                    catch
                    { totalPorMes[7] = 0; }
                    try
                    {
                        totalPorMes[8] = totalPorMes[7] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[8]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[8]].ToString());
                    }
                    catch
                    { totalPorMes[8] = 0; }
                    try
                    {
                        totalPorMes[9] = totalPorMes[8] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[9]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[9]].ToString());
                    }
                    catch
                    { totalPorMes[9] = 0; }
                    try
                    {
                        totalPorMes[10] = totalPorMes[9] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[10]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[10]].ToString());
                    }
                    catch
                    { totalPorMes[10] = 0; }
                    try
                    {
                        totalPorMes[11] = totalPorMes[10] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[11]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[11]].ToString());
                    }
                    catch
                    { totalPorMes[11] = 0; }
                    try
                    {
                        totalPorMes[12] = totalPorMes[11] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[12]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[12]].ToString());
                    }
                    catch
                    { totalPorMes[12] = 0; }
                    try
                    {
                        totalPorMes[13] = totalPorMes[12] + Convert.ToDecimal(dataTableForProcess.Rows[i][ndebe[13]].ToString()) - Convert.ToDecimal(dataTableForProcess.Rows[i][nhaber[13]].ToString());
                    }
                    catch
                    { totalPorMes[13] = 0; }
                    #endregion 

                    if (reportActivo) // Sí es TRUE, entonces es ACTIVO
                    {       // Analizar
                        if (VerifyAccountInAnotherList(datatable.Rows[i][0].ToString(), datatableFilteredByCuentasPasivo)) // Sí es TRUE se excluye en caso de ser negativo
                        {
                            if (totalPorMes[mesProceso] < 0)
                                totalPorMes[mesProceso] = 0;
                        }
                    }
                    else    // Sino, entonces es PASIVO como tú comprenderas
                    {
                        if (VerifyAccountInAnotherList(datatable.Rows[i][0].ToString(), datatableFilteredByCuentasActivo)) // Sí es TRUE se excluye en caso de ser negativo
                        {
                            if (totalPorMes[mesProceso] > 0)
                                totalPorMes[mesProceso] = 0;
                        }
                    }
                }
                for (int i = 1; i < totalByCuenta.Length; i++)
                    totalByCuenta[0] += totalByCuenta[i]; // Analiza y suma el total por cada cuenta
                return totalByCuenta[0]; // Almacena el total por cada por un solo RUBRO
            }
            return 0;
        }
        /*Sí la cuenta existe en la otra lista devuelve TRUE, en caso contrario devuelve FALSE*/
        public bool VerifyAccountInAnotherList(string cuenta, DataTable listCompare)
        {
            string tempString = "";
            bool resultado = false;
            try
            {
                tempString = listCompare.AsEnumerable().Where(x => x.Field<string>("a").Trim() == cuenta.Trim())
                                .Select(x => x.Field<string>("a")).FirstOrDefault();
            }
            catch (Exception)
            {
                tempString = "";
            }
            if (tempString != null)
                return true;
            return resultado;
        }
        struct CuentasPorRubro
        {
            public DataTable _table;
            public string _ColumnNameOrdering;
            public string _filterId1;
            public string _columnNameFilterId1;
            public string _filterId2;
            public string _columnNameFilterId2;
            public string _filterId3;
            public string _columnNameFilterId3;
            public string _filterId4;
            public string _columnNameFilterId4;
            public DataTable GetFilterTable3Parameters() {
                MergeTables mergeTables = new MergeTables();
                DataTable dataTableStruct = mergeTables.GetTableByFilters(_table, _ColumnNameOrdering, _filterId1, _columnNameFilterId1, _filterId2, _columnNameFilterId2, _filterId3, _columnNameFilterId3);
                return dataTableStruct;
            }
            public DataTable GetFilterTable4Parameters()
            {
                MergeTables mergeTables = new MergeTables();
                DataTable dataTableStruct = mergeTables.GetTableByFilters(_table, _ColumnNameOrdering, _filterId1, _columnNameFilterId1, _filterId2, _columnNameFilterId2, _filterId3, _columnNameFilterId3, _filterId4, _columnNameFilterId4);
                return dataTableStruct;
            }
        }
        public DataTable GetListCuentasByRubro(DataTable listRubros, bool reportActivo) {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonDataSetDBComplete); // Desearealización del dataset de la bd completa
            DataTable datatable     = dataSet.Tables["plan"]; // instancia de la tabla PLAN
            DataTable[] datatableFiltered = new DataTable[listRubros.Rows.Count]; // Tabla con la lista de rubros
            for (int i = 0; i <= listRubros.Rows.Count; i++) // hasta la cantidad de rubros que exista en la lista
            {
                switch (identificacionReporte)
                {
                    case 1: // 1 = Estado de situación financiera
                        CuentasPorRubro cuentasPorRubro;
                        if (reportActivo) // Activo, entonces buscar las cuentas del pasivo
                        {
                            cuentasPorRubro = new CuentasPorRubro() { // Esta carga con el struct se emplea para definir los atributos a emplear para la consulta
                                _table                  = datatable, // Tabla completa de plan
                                _ColumnNameOrdering     = "a",
                                _filterId1              = listRubros.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la lista de cuentas el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                                _columnNameFilterId1    = "bx", // ccod_bal2 as bx, es la columna "ccod_bal2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                                _filterId2              = listRubros.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la lista de cuentas el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                                _columnNameFilterId2    = "f",  // ccod_bal as f, es la columna "ccod_bal2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                                _filterId3              = listRubros.Rows[i][0].ToString(), // Obtiene el rubro para filtrarse en la columna ccod_bal
                                _columnNameFilterId3    = "a"   // Columna ccod_bal
                            };
                        }
                        else            // Pasivo, entonces buscar las cuentas del activo
                        {
                            cuentasPorRubro = new CuentasPorRubro() {
                                _table                  = datatable, // Tabla completa de plan
                                _ColumnNameOrdering     = "a",
                                _filterId1              = listRubros.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la lista de cuentas el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                                _columnNameFilterId1    = "bx", // ccod_bal2 as bx, es la columna "ccod_bal2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                                _filterId2              = listRubros.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la lista de cuentas el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                                _columnNameFilterId2    = "by", // ccod_baln2 as by, es la columna "ccod_baln2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                                _filterId3              = listRubros.Rows[i][0].ToString(), // Obtiene el rubro para filtrarse en la columna ccod_bal
                                _columnNameFilterId3    = "a"   // Columna ccod_bal
                            };
                        }
                        datatableFiltered[i] = cuentasPorRubro.GetFilterTable3Parameters();
                        break;
                } // Fin del switch, entonces ya tiene construida la tabla para UN RUBRO
                datatableFiltered[0].Merge(datatableFiltered[i]);   // Esto ocurre al final para fusionar cada tabla de resultado a el elemento del array listCuentas[0]
            }
            return datatableFiltered[0]; // Retorna todas un listado con todas las cuentas que se tenga
        }
        public DataTable[] TotalesByRubros() {
            DataTable[] dataTableTotales = new DataTable[2];
            DataSet dataSet     = JsonConvert.DeserializeObject<DataSet>(jsonDataSetDBComplete); // Desearealización del dataset de la bd completa
            DataTable datatable = dataSet.Tables["plan"]; // instancia de la tabla PLAN
            DataSet dataSetRubros = JsonConvert.DeserializeObject<DataSet>(jsonDataSetRubrosByFormatos); // Desearealización del dataset que contiene las listas de activo, pasivo y patrominio
            DataTable listRubrosPasivo = new DataTable();
            DataTable datatableFilteredByCuentasPasivo = new DataTable();
            DataTable listRubrosActivo = new DataTable();
            DataTable datatableFilteredByCuentasActivo = new DataTable();

            #region Obtención de los rubros del ACTIVO y PASIVO
            DataTable listNamesPasivo1 = dataSetRubros.Tables["listNamesPasivo1"];
            DataTable listNamesPasivo2 = dataSetRubros.Tables["listNamesPasivo2"];
            DataTable listNamesPasivo3 = dataSetRubros.Tables["listNamesPasivo3"];
            DataTable listNamesPasivo4 = dataSetRubros.Tables["listNamesPasivo4"];
            DataTable listNamesPasivo5 = dataSetRubros.Tables["listNamesPasivo5"];
            DataTable listNamesPasivo6 = dataSetRubros.Tables["listNamesPasivo6"];
            DataTable listNamesPasivo7 = dataSetRubros.Tables["listNamesPasivo7"];
            DataTable listNamesPasivo8 = dataSetRubros.Tables["listNamesPasivo8"];
            DataTable listNamesPasivo9 = dataSetRubros.Tables["listNamesPasivo9"];

            listNamesPasivo8.Merge(listNamesPasivo9);
            listNamesPasivo7.Merge(listNamesPasivo8);
            listNamesPasivo6.Merge(listNamesPasivo7);
            listNamesPasivo5.Merge(listNamesPasivo6);
            listNamesPasivo4.Merge(listNamesPasivo5);
            listNamesPasivo3.Merge(listNamesPasivo4);
            listNamesPasivo2.Merge(listNamesPasivo3);
            listNamesPasivo1.Merge(listNamesPasivo2);
            listRubrosPasivo.Merge(listNamesPasivo1); // la tabla listRubros ya tendrá todos los rubros del pasivo

            DataTable listNamesActivo1 = dataSetRubros.Tables["listNamesActivo1"];
            DataTable listNamesActivo2 = dataSetRubros.Tables["listNamesActivo2"];
            DataTable listNamesActivo3 = dataSetRubros.Tables["listNamesActivo3"];
            DataTable listNamesActivo4 = dataSetRubros.Tables["listNamesActivo4"];
            DataTable listNamesActivo5 = dataSetRubros.Tables["listNamesActivo5"];
            DataTable listNamesActivo6 = dataSetRubros.Tables["listNamesActivo6"];
            DataTable listNamesActivo7 = dataSetRubros.Tables["listNamesActivo7"];
            DataTable listNamesActivo8 = dataSetRubros.Tables["listNamesActivo8"];
            DataTable listNamesActivo9 = dataSetRubros.Tables["listNamesActivo9"];

            listNamesActivo8.Merge(listNamesActivo9);
            listNamesActivo7.Merge(listNamesActivo8);
            listNamesActivo6.Merge(listNamesActivo7);
            listNamesActivo5.Merge(listNamesActivo6);
            listNamesActivo4.Merge(listNamesActivo5);
            listNamesActivo3.Merge(listNamesActivo4);
            listNamesActivo2.Merge(listNamesActivo3);
            listNamesActivo1.Merge(listNamesActivo2);
            listRubrosActivo.Merge(listNamesActivo1); // la tabla listRubros ya tendra todos los rubros del activo
            #endregion

            #region Obtine las tablas principales que sirven para generar totales, hasta aquí todavía no se realiza los cálculos
            // Obtener un tabla con el filtro de rubro, para los activos
            DataTable[] dataTableActivosFilteredByRubro = new DataTable[listRubrosActivo.Rows.Count];
            for (int i = 0; i < listRubrosActivo.Rows.Count - 1; i++) // va a recorrer cada uno de los rubros
            {
                CuentasPorRubro cuentasPorRubro = new CuentasPorRubro() {
                    _table = datatable, // Tabla completa de plan
                    _ColumnNameOrdering = "a",
                    _filterId1 = listRubrosActivo.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la tabla el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                    _columnNameFilterId1 = "bx", // ccod_bal2 as bx, es la columna "ccod_bal2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                    _filterId2 = listRubrosActivo.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la tabla el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                    _columnNameFilterId2 = "by", // ccod_baln2 as by, es la columna "ccod_baln2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                    _filterId3 = listRubrosActivo.Rows[i][0].ToString(), // Obtiene el rubro para filtrarse en la columna ccod_bal
                    _columnNameFilterId3 = "a"   // Columna ccod_bal
                };
                dataTableActivosFilteredByRubro[i]  = cuentasPorRubro.GetFilterTable3Parameters();
            } // hasta aquí ya se tiene un array de tablas, cada elemento del array tiene un tabla filtrada en base al rubro
            DataTable ActivosFilteredByRubroUnion = FusionArrayOfTables(dataTableActivosFilteredByRubro).DefaultView.ToTable(true, "a"); // Almacena en una única tabla todo el conjunto de elementos del array de tablas
            // Obtener un tabla con el filtro de rubro, para los activos
            DataTable[] dataTablePasivosFilteredByRubro = new DataTable[listRubrosPasivo.Rows.Count];
            for (int i = 0; i < listRubrosPasivo.Rows.Count - 1; i++) // va a recorrer cada uno de los rubros
            {
                CuentasPorRubro cuentasPorRubro = new CuentasPorRubro()
                {
                    _table                  = datatable, // Tabla completa de plan
                    _ColumnNameOrdering     = "a",
                    _filterId1              = listRubrosPasivo.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la lista de cuentas el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                    _columnNameFilterId1    = "bx", // ccod_bal2 as bx, es la columna "ccod_bal2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                    _filterId2              = listRubrosPasivo.Rows[i][0].ToString(), // Ejemplo Rows[i][0] i = 0, buscará en la lista de cuentas el rubro en la posició (0, 0) y encontrará un rubro parecido a este "A110"
                    //_columnNameFilterId2    = "f",  // ccod_bal as f, es la columna "ccod_bal2" en la tabla completa "datatable" que contiene los datos de la tabla dbf PLAN
                    _columnNameFilterId2    = "by",
                    _filterId3              = listRubrosPasivo.Rows[i][0].ToString(), // Obtiene el rubro para filtrarse en la columna ccod_bal
                    _columnNameFilterId3    = "a",   // Columna ccod_bal
                    //_filterId4              = listRubrosPasivo.Rows[i][0].ToString(), // Obtiene el rubro para filtrarse en la columna ccod_bal
                    //_columnNameFilterId4    = "by"   // Columna ccod_baln2
                };
                //dataTablePasivosFilteredByRubro[i]  = cuentasPorRubro.GetFilterTable4Parameters();
                dataTablePasivosFilteredByRubro[i] = cuentasPorRubro.GetFilterTable3Parameters();
            } // hasta aquí ya se tiene un array de tablas, cada elemento del array tiene un tabla filtrada en base al rubro
            DataTable PasivosFilteredByRubroUnion   = FusionArrayOfTables(dataTablePasivosFilteredByRubro).DefaultView.ToTable(true, "a"); // Almacena en una única tabla todo el conjunto de elementos del array de tablas
            #endregion

            // armar activos
            // ActivosFilteredByRubroUnion
            decimal[] decimalActivosTotales = new decimal[listRubrosActivo.Rows.Count];
            for (int i = 0; i < dataTableActivosFilteredByRubro.Length; i++) // Hasta aquí tengo la cantidad de rubros en un array, y cada rubro es un DataTable con con sus respectivas cuentas 
                decimalActivosTotales[i] = GetTotalByRubro(dataTableActivosFilteredByRubro[i], true, PasivosFilteredByRubroUnion);

            decimal[] decimalPasivosTotales = new decimal[listRubrosPasivo.Rows.Count];
            for (int i = 0; i < dataTablePasivosFilteredByRubro.Length; i++) // Hasta aquí tengo la cantidad de rubros en un array, y cada rubro es un DataTable con con sus respectivas cuentas 
                decimalPasivosTotales[i] = GetTotalByRubro(dataTablePasivosFilteredByRubro[i], false, ActivosFilteredByRubroUnion);
            GetTotalByRubro(GetFilterTablePLAN(), true);
            return dataTableTotales;
        }
        // Se le pasa la tabla filtrada para que calcular sus montos, la especificación si es de activo  o pasivo, y la lista de cuentas para verificar su existencia y validar sus datos
        public decimal GetTotalByRubro(DataTable dataTableForProcess, bool reportActivo, DataTable ListForSearch) {
            decimal[]   totalPorMes     = new decimal[14];
            string[]    ndebe, nhaber;
            decimal[]   totalPorCuenta;
            decimal     totalFinalFlash = 0;

            if (tipoMoneda)
            {
                ndebe   = new string[16] { "i", "k", "m", "o", "q", "s", "u", "w", "y", "aa", "ac", "ae", "ag", "ai", "ak", "am" };
                nhaber  = new string[16] { "j", "l", "n", "p", "r", "t", "v", "x", "z", "ab", "ad", "af", "ah", "aj", "al", "an" };
            }
            else
            {
                ndebe   = new string[16] { "aq", "as", "au", "aw", "ay", "ba", "bc", "be", "bg", "bi", "bk", "bm", "bo", "bq", "bs", "bu" };
                nhaber  = new string[16] { "ar", "at", "av", "ax", "az", "bb", "bd", "bf", "bh", "bj", "bl", "bn", "bp", "br", "bt", "bv" };
            }
            #region Resta del debe y haber totalizado HASTA el mes de proceso
            try
            {
                if (dataTableForProcess.Rows.Count > 0)
                {
                    totalPorCuenta = new decimal[dataTableForProcess.Rows.Count];
                    for (int i = 0; i < dataTableForProcess.Rows.Count; i++) // Rows[i][1] i se refiere al número de fila, 1 es la posición de la columna
                    {
                        if (reportActivo) // Sí es TRUE, entonces es ACTIVO
                        {
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

                            if (mesProceso == 12)
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
                        // Se le pasa la cuenta y la lista donde se debe de buscar
                        if (VerifyAccountInAnotherList(dataTableForProcess.Rows[i][0].ToString(), ListForSearch)) // Sí es TRUE se excluye en caso de ser negativo
                        {
                                if (totalPorMes[mesProceso] < 0)
                                    totalPorMes[mesProceso] = 0;
                        }
                        totalPorCuenta[i] = totalPorMes[mesProceso]; // totalPorMes[mesProceso] es el resultado actual de la cuenta según el mes de proceso, a su vez totalPorCuenta[i] almacena en la misma posición  el valor del total(totalPorMes[mesProceso])
                        // Agregar método para sumar en un array
                    }
                    totalFinalFlash = SumarElementosDeArray(totalPorCuenta);
                }
                else
                    totalFinalFlash = 0;
            }
            catch
            {
                totalFinalFlash = 0;
            }
            #endregion
            return totalFinalFlash;
        }
        public decimal GetTotalByRubro(DataTable dataTableForProcess, bool reportActivo)
        {
            decimal[] totalPorMes = new decimal[14];
            string[] ndebe, nhaber;
            decimal[] totalPorCuenta;
            decimal totalFinalFlash = 0;

            if (tipoMoneda)
            {
                ndebe = new string[16] { "i", "k", "m", "o", "q", "s", "u", "w", "y", "aa", "ac", "ae", "ag", "ai", "ak", "am" };
                nhaber = new string[16] { "j", "l", "n", "p", "r", "t", "v", "x", "z", "ab", "ad", "af", "ah", "aj", "al", "an" };
            }
            else
            {
                ndebe = new string[16] { "aq", "as", "au", "aw", "ay", "ba", "bc", "be", "bg", "bi", "bk", "bm", "bo", "bq", "bs", "bu" };
                nhaber = new string[16] { "ar", "at", "av", "ax", "az", "bb", "bd", "bf", "bh", "bj", "bl", "bn", "bp", "br", "bt", "bv" };
            }
            #region Resta del debe y haber totalizado HASTA el mes de proceso
            try
            {
                if (dataTableForProcess.Rows.Count > 0)
                {
                    totalPorCuenta = new decimal[dataTableForProcess.Rows.Count];
                    for (int i = 0; i < dataTableForProcess.Rows.Count; i++) // Rows[i][1] i se refiere al número de fila, 1 es la posición de la columna
                    {
                        if (reportActivo) // Sí es TRUE, entonces es ACTIVO
                        {
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

                            if (mesProceso == 12)
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
                            if (dataTableForProcess.Rows[i]["by"].ToString().Trim() == "".Trim())
                            {
                                dataTableForProcess.Rows[i]["by"].ToString(); // Aquí se tiene que acumular en base al rubro 
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
                    }
                    totalFinalFlash = SumarElementosDeArray(totalPorCuenta);
                }
                else
                    totalFinalFlash = 0;
            }
            catch
            {
                totalFinalFlash = 0;
            }
            #endregion
            return totalFinalFlash;
        }
        public DataTable FusionArrayOfTables(DataTable[] dataTable) {
            DataTable dataTableUnion = new DataTable();
            for (int i = 0; i < dataTable.Length; i++)
                try
                {
                    dataTableUnion.Merge(dataTable[i]);
                }
                catch
                {
                    
                }
            return dataTableUnion;
        }
        public decimal SumarElementosDeArray(decimal[] array) {
            decimal total = 0;
            try
            {
                for (int i = 0; i < array.Length; i++)
                    total += array[i];
            }
            catch (Exception)
            {
                total = 0;
            }
            return total;
        }
        //Método para filtra la tabla PLAN
        public DataTable GetFilterTablePLAN() {
            DataSet dataSet     = JsonConvert.DeserializeObject<DataSet>(jsonDataSetDBComplete); // Desearealización del dataset de la bd completa
            DataTable datatable = dataSet.Tables["plan"]; // instancia de la tabla PLAN
            DataTable dataTableListActivos = mergeTables.GetTableByFilters(datatable, "a", 3, "c", 1, "d", true); // Tabla activos
            return dataTableListActivos;
        }
        public void VerificarRubro()
        {
            DataTable prueba = new DataTable();
            prueba = GetFilterTablePLAN();
        }
    }
}
