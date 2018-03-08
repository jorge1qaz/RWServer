using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class QueriesCompleteDatabase
    {
        public bool reportActivo { get; set; }
        public Int16 identificacionReporte { get; set; } // 1 = Estado de situación financiera, 2 = ...
        public string jsonDataSetDBComplete { get; set; }
        public bool tipoMoneda { get; set; }
        public int mesProceso { get; set; }
        public string jsonDataSetRubrosByFormatos { get; set; }
        public decimal GetTotalByTablePlan()
        {
            DataSet dataSet     = JsonConvert.DeserializeObject<DataSet>(jsonDataSetDBComplete); // Desearealización del dataset de la bd completa
            DataTable datatable = dataSet.Tables["plan"]; // instancia de la tabla PLAN
            DataTable dataTableListCuentas = new DataTable(); // Instancia de la tabla que contendrá sólo las cuentas de la tabla
            string[] ndebe;
            string[] nhaber;
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
            DataSet dataSetRubros = JsonConvert.DeserializeObject<DataSet>(jsonDataSetRubrosByFormatos); // Desearealización del dataset
            DataTable listCompare = new DataTable();
            DataTable listNamesPasivo       = dataSet.Tables["listNamesPasivo"]; // instancia de la tabla
            DataTable listNamesPatrimonio   = dataSet.Tables["listNamesPatrimonio"]; // instancia de la tabla
            DataTable listNamesActivo = dataSet.Tables["listNamesActivo"];
            switch (identificacionReporte)
            {
                case 1:
                    if (reportActivo)
                    {
                        listNamesPasivo.Merge(listNamesPatrimonio);
                        listCompare.Merge(listNamesPasivo);
                    }
                    else
                    {
                        listCompare.Merge(listNamesActivo);
                    }
                    break;
            }

            if (datatable.Rows.Count > 0)
            {
                dataTableListCuentas = datatable.DefaultView.ToTable(false, "a");
                decimal[] totalByCuenta = new decimal[dataTableListCuentas.Rows.Count]; // Total por cada fila
                decimal[] totalPorMes   = new decimal[12]; // Total por mes
                for (int i = 0; i < dataTableListCuentas.Rows.Count; i++) // Rows[i][1] i se refiere al número de fila, 1 es la posición de la columna
                {
                    #region Resta del debe y haber totalizado HASTA el mes de proceso
                    try
                    {
                        totalPorMes[0] = Convert.ToDecimal(datatable.Rows[i][ndebe[0]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[0]].ToString());
                    }
                    catch
                    { totalPorMes[0] = 0; }
                    try
                    {
                        totalPorMes[1] = totalPorMes[0] + Convert.ToDecimal(datatable.Rows[i][ndebe[1]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[1]].ToString());
                    }
                    catch
                    { totalPorMes[1] = 0; }
                    try
                    {
                        totalPorMes[2] = totalPorMes[1] + Convert.ToDecimal(datatable.Rows[i][ndebe[2]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[2]].ToString());
                    }
                    catch
                    { totalPorMes[2] = 0; }
                    try
                    {
                        totalPorMes[3] = totalPorMes[2] + Convert.ToDecimal(datatable.Rows[i][ndebe[3]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[3]].ToString());
                    }
                    catch
                    { totalPorMes[3] = 0; }
                    try
                    {
                        totalPorMes[4] = totalPorMes[3] + Convert.ToDecimal(datatable.Rows[i][ndebe[4]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[4]].ToString());
                    }
                    catch
                    { totalPorMes[4] = 0; }
                    try
                    {
                        totalPorMes[5] = totalPorMes[4] + Convert.ToDecimal(datatable.Rows[i][ndebe[5]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[5]].ToString());
                    }
                    catch
                    { totalPorMes[5] = 0; }
                    try
                    {
                        totalPorMes[6] = totalPorMes[5] + Convert.ToDecimal(datatable.Rows[i][ndebe[6]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[6]].ToString());
                    }
                    catch
                    { totalPorMes[6] = 0; }
                    try
                    {
                        totalPorMes[7] = totalPorMes[6] + Convert.ToDecimal(datatable.Rows[i][ndebe[7]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[7]].ToString());
                    }
                    catch
                    { totalPorMes[7] = 0; }
                    try
                    {
                        totalPorMes[8] = totalPorMes[7] + Convert.ToDecimal(datatable.Rows[i][ndebe[8]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[8]].ToString());
                    }
                    catch
                    { totalPorMes[8] = 0; }
                    try
                    {
                        totalPorMes[9] = totalPorMes[8] + Convert.ToDecimal(datatable.Rows[i][ndebe[9]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[9]].ToString());
                    }
                    catch
                    { totalPorMes[9] = 0; }
                    try
                    {
                        totalPorMes[10] = totalPorMes[9] + Convert.ToDecimal(datatable.Rows[i][ndebe[10]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[10]].ToString());
                    }
                    catch
                    { totalPorMes[10] = 0; }
                    try
                    {
                        totalPorMes[11] = totalPorMes[10] + Convert.ToDecimal(datatable.Rows[i][ndebe[11]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[11]].ToString());
                    }
                    catch
                    { totalPorMes[11] = 0; }
                    try
                    {
                        totalPorMes[12] = totalPorMes[11] + Convert.ToDecimal(datatable.Rows[i][ndebe[12]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[12]].ToString());
                    }
                    catch
                    { totalPorMes[12] = 0; }
                    try
                    {
                        totalPorMes[13] = totalPorMes[12] + Convert.ToDecimal(datatable.Rows[i][ndebe[13]].ToString()) - Convert.ToDecimal(datatable.Rows[i][nhaber[13]].ToString());
                    }
                    catch
                    { totalPorMes[13] = 0; }
                    #endregion 

                    if (reportActivo) // Sí es TRUE, entonces es Activo
                    {
                        if (ComprobarEstadoFinancieroCuenta(datatable.Rows[i][0].ToString())) // Sí es TRUE se excluye en caso de ser negativo
                        {
                            if (totalByCuenta[i] < 0)
                                totalByCuenta[i] = 0;
                        }
                    }
                    else // Sino es PASIVO como tú comprenderas
                    {
                        if (ComprobarEstadoFinancieroCuenta(datatable.Rows[i][0].ToString())) // Sí es TRUE se excluye en caso de ser negativo
                        {
                            if (totalByCuenta[i] > 0)
                                totalByCuenta[i] = 0;
                        }
                    }
                }
                for (int i = 1; i < totalByCuenta.Length; i++)
                {
                    totalByCuenta[0] += totalByCuenta[i];

                }
                return totalByCuenta[0];
            }
            return 0;
        }
        /*Sí la cuenta existe en la lista devuelve TRUE, en caso contrario devuelve FALSE*/
        public bool ComprobarEstadoFinancieroCuenta(string cuenta, DataTable listCompare)
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
    }
}
