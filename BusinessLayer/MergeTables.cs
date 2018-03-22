using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            try
            {
                DataTable dtNew = new DataTable();
                DataTable distincts = table.DefaultView.ToTable(true, NameColumn);
                foreach (DataColumn dcName in table.Columns)
                    dtNew.Columns.Add(new DataColumn(dcName.Caption, dcName.DataType));
                foreach (DataRow drRow in distincts.Rows)
                    dtNew.ImportRow(table.Select(NameColumn + " = '" + drRow[0] + "'")[0]);
                return distincts;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public decimal GetTotalByTable(DataTable tableData, DataTable tableList, string idColumn, string NameColumn1, string NameColumn2, bool discriminative, bool negativeValue) {
            DataTable tableSumByCount = new DataTable(); // Instancia de tabla para las cuentas en específico
            DataColumn column = new DataColumn();
            DataRow row;
            double total1;
            double total2;
            decimal amount;
            #region Declaración de columnas
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Cuenta";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "Total";
            tableSumByCount.Columns.Add(column);
            #endregion
            foreach (DataRow item in tableList.Rows) // Lista de cuentas con los cuales se obtienen los totales 
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
                row["Cuenta"]   = item.ToString();
                row["Total"]    = amount;  
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
        //Jorge Luis|19/01/2018|RW-93
        /*Método eeeesteeeee*/
        public DataTable GetTotalByTable(DataTable tableData, DataTable tableList, string idColumn, string nameColumn1, string nameColumn2, string nameFirstColumn, bool moneda)
        {                                                                                   //a             //c                     //d             //
            DataTable tableSumByCount = new DataTable(); // Instancia de tabla para las cuentas en específico
            DataColumn column = new DataColumn();
            DataRow row;
            double total1;
            double total2;
            decimal amount;
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
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "Vencidos";
            tableSumByCount.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = nameFirstColumn;
            tableSumByCount.Columns.Add(column);
            #endregion
            if (!moneda)
            {
                nameColumn1 = nameColumn1 + "d"; nameColumn2 = nameColumn2 + "d";
            }
            foreach (DataRow item in tableList.Rows) // Lista de cuentas con los cuales se obtienen los totales 
            {
                try
                {
                    total1 = tableData.AsEnumerable().Where(x => x.Field<string>(idColumn) == item[0].ToString()).Select(x => x.Field<double>(nameColumn1)).Sum();
                }
                catch (Exception)
                { total1 = 0; }
                try
                {
                    total2 = tableData.AsEnumerable().Where(x => x.Field<string>(idColumn) == item[0].ToString()).Select(x => x.Field<double>(nameColumn2)).Sum();
                }
                catch (Exception)
                { total2 = 0; }
                amount = Convert.ToDecimal(total1) - Convert.ToDecimal(total2);
                if (amount != 0)
                {
                    row = tableSumByCount.NewRow();
                    row["Cuenta"] = item[0].ToString();
                    row[nameFirstColumn] = Math.Round(amount, 2);
                    tableSumByCount.Rows.Add(row);
                }
            }
            return tableSumByCount;
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
                tabla       = GetAccumulatedTables(jsonTable, mes); // Fusiona las tablas según el mes que se le pase
                totalTable  = GetTotalByTable(tabla, columnName);
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
        public decimal[] GeTotalByTablePlan(string jsonDataSet, bool tipoMoneda)
        {
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonDataSet);
            DataTable datatable = dataSet.Tables["data"];
            string moneda = "";
            decimal aTotal = 0, bTotal = 0, cTotal = 0, dTotal = 0, eTotal = 0, fTotal = 0, gTotal = 0, hTotal = 0, iTotal = 0, jTotal = 0, kTotal = 0, lTotal = 0, mTotal = 0, nTotal = 0, oTotal = 0;
            decimal[] listValues = new decimal[12];
            if (!tipoMoneda)
                moneda = "d";
            #region Asignación columnas
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
            #endregion
            listValues[0] = aTotal + bTotal;
            listValues[1] = listValues[0] + cTotal;
            listValues[2] = listValues[1] + dTotal;
            listValues[3] = listValues[2] + eTotal;
            listValues[4] = listValues[3] + fTotal;
            listValues[5] = listValues[4] + gTotal;
            listValues[6] = listValues[5] + hTotal;
            listValues[7] = listValues[6] + iTotal;
            listValues[8] = listValues[7] + jTotal;
            listValues[9] = listValues[8] + kTotal;
            listValues[10] = listValues[9] + lTotal;
            listValues[11] = listValues[10] + mTotal + nTotal /*+ oTotal*/;
            return listValues;
        }
        //balance general
        public decimal GeTotalByTablePlan(string jsonDataSet, bool tipoMoneda, int mesProceso, bool limitarMeses)
        {
            //decimal totalTable;
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonDataSet);
            DataTable datatable = dataSet.Tables["data"];
            string moneda = "";
            decimal aTotal = 0, bTotal = 0, cTotal = 0, dTotal = 0, eTotal = 0, fTotal = 0, gTotal = 0, hTotal = 0, iTotal = 0, jTotal = 0, kTotal = 0, lTotal = 0, mTotal = 0, nTotal = 0, oTotal = 0;
            decimal[] listValues = new decimal[12];
            if (!tipoMoneda)
                moneda = "d";
            #region Asignación columnas
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
            #endregion
            if (limitarMeses == true)
            {
                listValues[0] = KeepPositive(aTotal, bTotal);
                listValues[1] = KeepPositive(aTotal + bTotal, cTotal);
                listValues[2] = KeepPositive(aTotal + bTotal + cTotal, dTotal);
                listValues[3] = KeepPositive(aTotal + bTotal + cTotal + dTotal, eTotal);
                listValues[4] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal, fTotal);
                listValues[5] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal, gTotal);
                listValues[6] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal, hTotal);
                listValues[7] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal, iTotal);
                listValues[8] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal, jTotal);
                listValues[9] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal, kTotal);
                listValues[10] = KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal, lTotal);
                listValues[11] = KeepPositive(KeepPositive(aTotal + bTotal + cTotal + dTotal + eTotal + fTotal + gTotal + hTotal + iTotal + jTotal + kTotal + lTotal, mTotal), nTotal);
            }
            else
            {
                listValues[0] = aTotal + bTotal;
                listValues[1] = listValues[0] + cTotal;
                listValues[2] = listValues[1] + dTotal;
                listValues[3] = listValues[2] + eTotal;
                listValues[4] = listValues[3] + fTotal;
                listValues[5] = listValues[4] + gTotal;
                listValues[6] = listValues[5] + hTotal;
                listValues[7] = listValues[6] + iTotal;
                listValues[8] = listValues[7] + jTotal;
                listValues[9] = listValues[8] + kTotal;
                listValues[10] = listValues[9] + lTotal;
                listValues[11] = listValues[10] + mTotal + nTotal /*+ oTotal*/;
            }
            return listValues[mesProceso];
        }
        public decimal GeTotalByTablePlan(bool reportActivo, string jsonDataSet, bool tipoMoneda, int mesProceso, string listCompareJson)
        {
            DataSet dataSet     = JsonConvert.DeserializeObject<DataSet>(jsonDataSet); // Desearealización del dataset
            DataTable datatable = dataSet.Tables["data"]; // instancia de la tabla
            string moneda       = "s"; 
            if (!tipoMoneda)
                moneda = "d";
            DataTable dataTableListCuentas = new DataTable(); // Instancia de la tabla que contendrá sólo las cuentas de la tabla
            if (datatable.Rows.Count > 0)
            {
                dataTableListCuentas = datatable.DefaultView.ToTable(false, "a");
                decimal[] totalByCuenta = new decimal[dataTableListCuentas.Rows.Count];
                for (int i = 0; i < dataTableListCuentas.Rows.Count; i++)
                {
                    switch (mesProceso + 1)
                    {
                        case 1:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 2:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 3:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 4:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 5:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 6:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 7:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString()) + Convert.ToDecimal(datatable.Rows[i][8].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 8:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString()) + Convert.ToDecimal(datatable.Rows[i][8].ToString()) + Convert.ToDecimal(datatable.Rows[i][9].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 9:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString()) + Convert.ToDecimal(datatable.Rows[i][8].ToString()) + Convert.ToDecimal(datatable.Rows[i][9].ToString()) + Convert.ToDecimal(datatable.Rows[i][10].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;

                        case 10:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString()) + Convert.ToDecimal(datatable.Rows[i][8].ToString()) + Convert.ToDecimal(datatable.Rows[i][9].ToString()) + Convert.ToDecimal(datatable.Rows[i][10].ToString()) + Convert.ToDecimal(datatable.Rows[i][11].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;
                        case 11:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString()) + Convert.ToDecimal(datatable.Rows[i][8].ToString()) + Convert.ToDecimal(datatable.Rows[i][9].ToString()) + Convert.ToDecimal(datatable.Rows[i][10].ToString()) + Convert.ToDecimal(datatable.Rows[i][11].ToString()) + Convert.ToDecimal(datatable.Rows[i][12].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;
                        case 12:
                            try
                            {
                                totalByCuenta[i] = Convert.ToDecimal(datatable.Rows[i][1].ToString()) + Convert.ToDecimal(datatable.Rows[i][2].ToString()) + Convert.ToDecimal(datatable.Rows[i][3].ToString()) + Convert.ToDecimal(datatable.Rows[i][4].ToString()) + Convert.ToDecimal(datatable.Rows[i][5].ToString()) + Convert.ToDecimal(datatable.Rows[i][6].ToString()) + Convert.ToDecimal(datatable.Rows[i][7].ToString()) + Convert.ToDecimal(datatable.Rows[i][8].ToString()) + Convert.ToDecimal(datatable.Rows[i][9].ToString()) + Convert.ToDecimal(datatable.Rows[i][10].ToString()) + Convert.ToDecimal(datatable.Rows[i][11].ToString()) + Convert.ToDecimal(datatable.Rows[i][12].ToString()) + Convert.ToDecimal(datatable.Rows[i][13].ToString()) + Convert.ToDecimal(datatable.Rows[i][14].ToString());
                            }
                            catch { totalByCuenta[i] = 0; }
                            break;
                    }
                    if (reportActivo) // Sí es TRUE, entonces es Activo
                    {
                        if (ComprobarEstadoFinancieroCuenta(datatable.Rows[i][0].ToString(), listCompareJson)) // Sí es TRUE se excluye en caso de ser negativo
                        {
                            if (totalByCuenta[i] < 0)
                                totalByCuenta[i] = 0;
                        }
                    }
                    else
                    {
                        if (ComprobarEstadoFinancieroCuenta(datatable.Rows[i][0].ToString(), listCompareJson)) // Sí es TRUE se excluye en caso de ser negativo
                        {
                            if (totalByCuenta[i] < 0)
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
        public bool ComprobarEstadoFinancieroCuenta(
            string cuenta, 
            string listCompareJson) {
            DataSet dataSet         = JsonConvert.DeserializeObject<DataSet>(listCompareJson);
            DataTable listCompare   = dataSet.Tables["data"];

            string tempString = "";
            bool resultado = false;
            //foreach (DataRow item in listCompare.Rows)
            //{
            //}
                try
                {
                    tempString  = listCompare.AsEnumerable().Where(x => x.Field<string>("a").Trim() == cuenta.Trim())
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
        public decimal KeepPositive(decimal anterior, decimal actual) {
            decimal temp = 0;
            temp = anterior + actual;
            if (temp > 0)
                return temp;
            else
            {
                if (anterior < 0)
                    temp = 0;
                else
                    temp = anterior;
            }
            return temp;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable GetTableByDate(DataTable table, DateTime startDate, DateTime endDate, int columnNumber)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where (DateTime)row[columnNumber] > startDate
                               where (DateTime)row[columnNumber] < endDate select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|29/01/2018|RW-93
        /*Método el cual recibe 4 parámetros, el primero "table" obtiene la tabla completa, "nameColumn1" es la columna donde se analizará el filtro,
         "IdRow" es el ID con el cual se filtrará la FILA BUSCADA, "nameColumn2" es el valor de la columna que se retornará. Sólo devuelve el valor de UNA fila */
        public string GetStringByIdInDataTable(DataTable table, string nameColumn1, string IdRow, string nameColumn2 )
        {
            //DataRow[] foundRow;
            //foundRow = table.Select(nameColumn + " Like '"+ IdRow + "%' ");
            string descripcion = "";
            try
            {
                descripcion     = table.AsEnumerable().Where(x => x.Field<string>(nameColumn1) == IdRow).
                                    Select(x => x.Field< string >(nameColumn2)).FirstOrDefault();
            }
            catch (Exception)
            {
                descripcion = "";
            }
            return descripcion;
        }
        //Jorge Luis|29/01/2018|RW-93
        /*Método para*/
        public decimal GetDecimalByIdInDataTable(DataTable table, string nameColumn1, string IdRow, string nameColumn2)
        {
            //DataRow[] foundRow;
            //foundRow = table.Select(nameColumn + " Like '"+ IdRow + "%' ");
            decimal valor = 0;
            try
            {
                valor   = table.AsEnumerable().Where(x => x.Field<string>(nameColumn1) == IdRow).
                                    Select(x => x.Field<decimal>(nameColumn2)).FirstOrDefault();
            }
            catch (Exception)
            {
                valor   = 0;
            }
            return valor;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para*/
        public DataTable GetTableByFilters(DataTable table, DateTime startDate, DateTime endDate, Int16 columnNumberDate)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where (DateTime)row[columnNumberDate] > startDate
                               where (DateTime)row[columnNumberDate] < endDate
                               select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según un sólo filtro*/
        public DataTable GetTableByFilters(DataTable table, String filterId, String columnNameFilterId)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where row.Field<String>(columnNameFilterId) == filterId
                               select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según un sólo filtro*/
        public DataTable GetTableByFilters(DataTable table, String ColumnNameOrdering, String filterId1, String columnNameFilterId1)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where row.Field<String>(columnNameFilterId1) == filterId1
                               orderby row.Field<String>(ColumnNameOrdering) descending
                               select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según dos filtros string*/
        public DataTable GetTableByFilters(DataTable table, String ColumnNameOrdering, String filterId1, String columnNameFilterId1, String filterId2, String columnNameFilterId2, bool strict)
        {
            if (strict) // Sí es estricto los filtros deben ser para todos (condicional ^ & Y)
            {
                var filteredRows =  from row in table.Rows.OfType<DataRow>()
                                    where row.Field<String>(columnNameFilterId1) == filterId1
                                    && row.Field<String>(columnNameFilterId2) == filterId2
                                    orderby row.Field<String>(ColumnNameOrdering) ascending
                                    select row;
                var filteredTable = table.Clone();
                filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
                return filteredTable;
            } else // Sí no es estricto los filtros no tienen que ser para todos, sólo para los que coincidan (condicional || OR)
            {
                var filteredRows =  from row in table.Rows.OfType<DataRow>()
                                    where row.Field<String>(columnNameFilterId1) == filterId1
                                    || row.Field<String>(columnNameFilterId2) == filterId2
                                    orderby row.Field<String>(ColumnNameOrdering) ascending
                                    select row;
                var filteredTable = table.Clone();
                filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
                return filteredTable;
            }
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según dos filtros*/
        public DataTable GetTableByFilters(DataTable table, String ColumnNameOrdering, Double filterId1, String columnNameFilterId1, Double filterId2, String columnNameFilterId2, bool strict)
        {
            if (strict) // Sí es estricto los filtros deben ser para todos (condicional ^ & Y)
            {
                var filteredRows = from row in table.Rows.OfType<DataRow>()
                                   where row.Field<Double>(columnNameFilterId1) == filterId1
                                   && row.Field<Double>(columnNameFilterId2)   == filterId2
                                   orderby row.Field<String>(ColumnNameOrdering) ascending
                                   select row;
                var filteredTable = table.Clone();
                filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
                return filteredTable;
            }
            else // Sí no es estricto los filtros no tienen que ser para todos, sólo para los que coincidan (condicional || OR)
            {
                var filteredRows = from row in table.Rows.OfType<DataRow>()
                                   where row.Field<int>(columnNameFilterId1) == filterId1
                                   || row.Field<int>(columnNameFilterId2) == filterId2
                                   orderby row.Field<String>(ColumnNameOrdering) ascending
                                   select row;
                var filteredTable = table.Clone();
                filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
                return filteredTable;
            }
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según dos filtros*/
        public DataTable GetTableByFilters(DataTable table, String ColumnNameOrdering, String filterId1, String columnNameFilterId1, String filterId2, String columnNameFilterId2, String filterId3, String columnNameFilterId3)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where row.Field<String>(columnNameFilterId1).Trim() == filterId1.Trim() || row.Field<String>(columnNameFilterId2).Trim() == filterId2.Trim() || row.Field<String>(columnNameFilterId3).Trim() == filterId3.Trim()
                               orderby row.Field<String>(ColumnNameOrdering) ascending
                               select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según dos filtros*/
        public DataTable GetTableByFilters(DataTable table, String ColumnNameOrdering, String filterId1, String columnNameFilterId1, String filterId2, String columnNameFilterId2, String filterId3, String columnNameFilterId3, String filterId4, String columnNameFilterId4)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where row.Field<String>(columnNameFilterId1).Trim() == filterId1.Trim() || row.Field<String>(columnNameFilterId2).Trim() == filterId2.Trim() || row.Field<String>(columnNameFilterId3).Trim() == filterId3.Trim() || row.Field<String>(columnNameFilterId4).Trim() == filterId4.Trim()
                               orderby row.Field<String>(ColumnNameOrdering) ascending
                               select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        //Jorge Luis|19/01/2018|RW-93
        /*Método para clonar una tabla según un sólo filtro*/
        public DataTable GetTableByFilters(DataTable table, DateTime startDate, DateTime endDate, String columnNameDate, String filterId1, String columnNameFilterId1)
        {
            var filteredRows = from row in table.Rows.OfType<DataRow>()
                               where row.Field<DateTime>(columnNameDate) > startDate
                               where row.Field<DateTime>(columnNameDate) < endDate
                               where row.Field<String>(columnNameFilterId1) == filterId1
                               select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
        public DataTable[] GetTablesGroupsByColumn(DataTable table, String columnNameID)
        {
            try
            {
                 DataTable listDistTable = GetListDist(table, columnNameID); // Table, ccod_doc
                List<String> listIdsDist = new List<string>();              // Lista de ccod_doc

                foreach (DataRow item in listDistTable.Rows)
                    listIdsDist.Add(item[0].ToString());                // Agregamos a la lista todos los códigos de forma única (01, 07, ..)

                DataTable[] temporalTable = new DataTable[listIdsDist.Count];
                for (int i = 0; i <= listIdsDist.Count - 1; i++)
                    temporalTable[i] = GetTableByFilters(table, listIdsDist[i].ToString(), columnNameID);   // table, i, "g"
                return temporalTable;
            }
            catch {
                DataTable[] tableEmpty = new DataTable[0];
                return tableEmpty;
            }
        }
        //Devuelve una tabla con una única fila con los resultados esperados
        public DataTable GenerateResultBytable(DataTable table, Int16 columnNameDebe, Int16 columnNameHaber, string columnNameResult) //de tipo datatable
        {                                                               //ccod_doc          //
            try
            {
                decimal resultado = 0, debe = 0, haber = 0;

                foreach (DataRow item in table.Rows)
                {
                    try
                    { debe += decimal.Parse(item[columnNameDebe].ToString()); }
                    catch (Exception)
                    { debe = 0; }
                    try
                    { haber += decimal.Parse(item[columnNameHaber].ToString()); }
                    catch (Exception)
                    { haber = 0; }
                }
                resultado = debe - haber;

                //generar la estructura del reporte, pasarle como parámetro el número de columna al cual debe de enviar el resultado, joder

                DataTable tableSumByCount = new DataTable(); // Instancia de tabla la cual se exportará al reporte
                DataColumn column = new DataColumn();
                DataRow row;
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
                column.ColumnName = "Vencidos";
                tableSumByCount.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.Decimal");
                column.ColumnName = columnNameResult;
                tableSumByCount.Columns.Add(column);
                #endregion

                row = tableSumByCount.NewRow();
                row[columnNameResult] = resultado;
                tableSumByCount.Rows.Add(row);

                return tableSumByCount;
            }
            catch
            {
                DataTable tableEmpty = new DataTable();
                return tableEmpty;
            }
        }
        //Usar este metodo bien chidori, el otro no sirve en tablas dinamicas
        public DataTable GetFullTableByOneFilter(DataTable table, string filterName, string filter) {
            DataTable tableFiltered = new DataTable();
            var filterTable = table.Select(filterName + " = '" + filter + "'");
            DataTable filteredResult = new DataTable();
            if (filterTable.Length != 0)
                filteredResult = filterTable.CopyToDataTable();
            return filteredResult;
        }
        public DataView GetFullTableByOneFilterView(DataTable table, string filterName, string filter)
        {
            DataView view = new DataView(table);
            view.RowFilter = filterName + " = '" + filter + "'";
            return view;
        }
    }
}
