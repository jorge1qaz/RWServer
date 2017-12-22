using Newtonsoft.Json;
using System;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class MergeTables
    {
        //Dos campos campos a = string, b = decimal 
        public DataTable GetAccumulatedTables(string dataSetJson, string mes) {
            #region Declaración de tablas
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(dataSetJson);
            DataTable datatableMes0 = dataSet.Tables["0"];
            DataTable datatableMes1 = dataSet.Tables["1"];
            DataTable datatableMes2 = dataSet.Tables["2"];
            DataTable datatableMes3 = dataSet.Tables["3"];
            DataTable datatableMes4 = dataSet.Tables["4"];
            DataTable datatableMes5 = dataSet.Tables["5"];
            DataTable datatableMes6 = dataSet.Tables["6"];
            DataTable datatableMes7 = dataSet.Tables["7"];
            DataTable datatableMes8 = dataSet.Tables["8"];
            DataTable datatableMes9 = dataSet.Tables["9"];
            DataTable datatableMes10 = dataSet.Tables["10"];
            DataTable datatableMes11 = dataSet.Tables["11"];
            DataTable datatableMes12 = dataSet.Tables["12"];
            #endregion
            #region Fusión de tablas... Fuuuuuu...sión!
            switch (mes.ToString())
            {
                case "1":
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "2":
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "3":
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "4":
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "5":
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "6":
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "7":
                    datatableMes6.Merge(datatableMes7);
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "8":
                    datatableMes7.Merge(datatableMes8);
                    datatableMes6.Merge(datatableMes7);
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "9":
                    datatableMes8.Merge(datatableMes9);
                    datatableMes7.Merge(datatableMes8);
                    datatableMes6.Merge(datatableMes7);
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "10":
                    datatableMes9.Merge(datatableMes10);
                    datatableMes8.Merge(datatableMes9);
                    datatableMes7.Merge(datatableMes8);
                    datatableMes6.Merge(datatableMes7);
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "11":
                    datatableMes10.Merge(datatableMes11);
                    datatableMes9.Merge(datatableMes10);
                    datatableMes8.Merge(datatableMes9);
                    datatableMes7.Merge(datatableMes8);
                    datatableMes6.Merge(datatableMes7);
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
                case "12":
                    datatableMes11.Merge(datatableMes12);
                    datatableMes10.Merge(datatableMes11);
                    datatableMes9.Merge(datatableMes10);
                    datatableMes8.Merge(datatableMes9);
                    datatableMes7.Merge(datatableMes8);
                    datatableMes6.Merge(datatableMes7);
                    datatableMes5.Merge(datatableMes6);
                    datatableMes4.Merge(datatableMes5);
                    datatableMes3.Merge(datatableMes4);
                    datatableMes2.Merge(datatableMes3);
                    datatableMes1.Merge(datatableMes2);
                    datatableMes0.Merge(datatableMes1);
                    break;
            }
            #endregion 
            return datatableMes0;
        }
        public DataTable GetListDist(DataTable table, string NameColumn) {
            DataTable dtNew = new DataTable();
            DataTable distincts = table.DefaultView.ToTable(true, NameColumn);
            foreach (DataColumn dcName in table.Columns)
                dtNew.Columns.Add(new DataColumn(dcName.Caption, dcName.DataType));
            foreach (DataRow drRow in distincts.Rows)
                dtNew.ImportRow(table.Select(NameColumn + " = '" + drRow[0] + "'")[0]);
            return distincts;
        }
        public string GetTotalByTable(DataTable tableData, DataTable tableList, string idColumn, string NameColumn1, string NameColumn2) {
            string total = "";
            DataTable tableSumByCount = new DataTable();
            DataColumn column;
            DataRow row;
            double total1;
            double total2;
            decimal amount;
            #region Declaración de columnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cuenta";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "Total";
            tableSumByCount.Columns.Add(column);
            #endregion
            foreach (DataRow item in tableList.Rows)
            {
                try
                {
                    total1 = tableData.AsEnumerable().Where(x => x.Field<string>(idColumn) == item[0].ToString()).Select(x => x.Field<double>(NameColumn1)).Sum();
                }
                catch (Exception)
                { total1 = 0; }
                try
                {
                    total2 = tableData.AsEnumerable().Where(x => x.Field<string>(idColumn) == item[0].ToString()).Select(x => x.Field<double>(NameColumn2)).Sum();
                }
                catch (Exception)
                { total2 = 0; }
                amount = Convert.ToDecimal(total2) - Convert.ToDecimal(total1);
                row = tableSumByCount.NewRow();
                row["Cuenta"] = item.ToString();
                row["Total"] = amount;
                tableSumByCount.Rows.Add(row);
            }
            decimal value = 0;
            foreach (DataRow item in tableSumByCount.Rows)
                if (decimal.Parse(item[1].ToString()) > 0)
                    value += decimal.Parse(item[1].ToString());
            total = value.ToString();
            return total;
        }
        public decimal GetTotalByTable(DataTable tableData, string NameColumn)
        {
            decimal totalTable;
            try
            {
                totalTable = Convert.ToDecimal(tableData.AsEnumerable().Select(x => x.Field<double>(NameColumn)).Sum());
            }
            catch (Exception)
            { totalTable = 0; }
            return totalTable;
        }
        public string GetSumTotal(string JsonTable, string mes, string columnName)
        {
            string total = "";
            DataTable tabla = new DataTable();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            tabla = GetAccumulatedTables(JsonTable, mes);
            //total = GetTotalByTable(tabla, columnName);
            return total;
        }
    }
}
