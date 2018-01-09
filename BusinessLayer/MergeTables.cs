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
            DataTable datatableMes13 = dataSet.Tables["13"];
            DataTable datatableMes14 = dataSet.Tables["14"];
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
                    datatableMes13.Merge(datatableMes14);
                    datatableMes12.Merge(datatableMes13);
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
        public decimal GetTotalByTable(DataTable tableData, DataTable tableList, string idColumn, string NameColumn1, string NameColumn2, bool discriminative, bool negativeValue) {
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
            if (discriminative) // True: Sólo toma los positivos
            {
                if (negativeValue) // Sí es verdadero, sólo se toma los valores que sean negativos
                {
                    foreach (DataRow item in tableSumByCount.Rows)
                        if (decimal.Parse(item[1].ToString()) < 0)
                            value += decimal.Parse(item[1].ToString());
                }
                else 
                {
                    foreach (DataRow item in tableSumByCount.Rows)
                        if (decimal.Parse(item[1].ToString()) > 0)
                            value += decimal.Parse(item[1].ToString());
                }
            }
            else
            {
                foreach (DataRow itemDefault in tableSumByCount.Rows)
                    value += decimal.Parse(itemDefault[1].ToString()); // Suma todo 
            }
            return value;
        }
        public decimal GetTotalByTable(DataTable tableData, string columnName)
        {
            decimal totalTable;
            try
            {
                totalTable = Convert.ToDecimal(tableData.AsEnumerable().Select(x => x.Field<double>(columnName)).Sum());
            }
            catch (Exception)
            { totalTable = 0; }
            return totalTable;
        }
        public decimal GeTotalByAccumulatedTables(string jsonTable, string mes, string columnName)
        {
            decimal totalTable;
            DataTable tabla = new DataTable();
            try
            {
                tabla = GetAccumulatedTables(jsonTable, mes);
                totalTable = GetTotalByTable(tabla, columnName);
            }
            catch (Exception)
            {
                totalTable = 0;
            }
            return totalTable;
        }
        public decimal GeTotalByAccumulatedTables(string jsonTable, string mes, string columnName1, string columnName2, string columnName3, bool discriminative, bool negativeValue)
        {
            decimal totalTable;
            DataTable tabla = new DataTable();
            DataTable ListCuentas = new DataTable();
            try
            {
                tabla = GetAccumulatedTables(jsonTable, mes);
                ListCuentas = GetListDist(tabla, columnName1);
                totalTable = GetTotalByTable(tabla, ListCuentas, columnName1, columnName2, columnName3, discriminative, negativeValue);
            }
            catch (Exception)
            {
                totalTable = 0;
            }
            return totalTable;
        }
        public decimal[] GeTotalByTablePlan(string jsonDataSet, bool tipoMoneda, bool limitarMeses)
        {
            //decimal totalTable;
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonDataSet);
            DataTable datatable = dataSet.Tables["data"];
            string moneda = "";
            decimal aTotal = 0, bTotal = 0, cTotal = 0, dTotal = 0, eTotal = 0, fTotal = 0, gTotal = 0, hTotal = 0, iTotal = 0, jTotal = 0, kTotal = 0, lTotal = 0, mTotal = 0, nTotal = 0, oTotal = 0;
            decimal[] listValues = new decimal[12];
            if (!tipoMoneda)
                moneda = "d";
            try
            {
                aTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("a" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            {
                aTotal = 0;
            }
            try
            {
                bTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("b" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { bTotal = 0; }
            try
            {
                cTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("c" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { cTotal = 0; }
            try
            {
                dTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("d" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { dTotal = 0; }
            try
            {
                eTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("e" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { eTotal = 0; }
            try
            {
                fTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("f" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { fTotal = 0; }
            try
            {
                gTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("g" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { gTotal = 0; }
            try
            {
                hTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("h" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { hTotal = 0; }
            try
            {
                iTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("i" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { iTotal = 0; }
            try
            {
                jTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("j" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { jTotal = 0; }
            try
            {
                kTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("k" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { kTotal = 0; }
            try
            {
                lTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("l" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { lTotal = 0; }
            try
            {
                mTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("m" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { mTotal = 0; }
            try
            {
                nTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("n" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { nTotal = 0; }
            try
            {
                oTotal = Convert.ToDecimal(datatable.AsEnumerable().Select(x => x.Field<double>("o" + moneda)).FirstOrDefault());
            }
            catch (Exception)
            { oTotal = 0; }
            if (!limitarMeses)
            {
                listValues[0] = aTotal + bTotal;
                listValues[1] = aTotal + bTotal + cTotal;
                listValues[2] = aTotal + bTotal + cTotal + dTotal;
                listValues[3] = aTotal + bTotal + cTotal + dTotal + eTotal;
                listValues[4] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal;
                listValues[5] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal;
                listValues[6] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal;
                listValues[7] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal;
                listValues[8] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal;
                listValues[9] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal;
                listValues[10] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal + lTotal;
                listValues[11] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal + lTotal + mTotal + nTotal + oTotal;
            }
            else
            {
                listValues[0] = aTotal + bTotal;
                listValues[1] = aTotal + bTotal + cTotal;
                listValues[2] = aTotal + bTotal + cTotal + dTotal;
                listValues[3] = aTotal + bTotal + cTotal + dTotal + eTotal;
                listValues[4] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal;
                listValues[5] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal;
                listValues[6] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal;
                listValues[7] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal;
                listValues[8] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal;
                listValues[9] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal;
                listValues[10] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal + lTotal;
                listValues[11] = aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal + lTotal + mTotal;
            }
            return listValues;
        }
    }
}
