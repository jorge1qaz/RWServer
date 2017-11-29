using System;
using BusinessLayer;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace AppWebReportes.Reportes
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        double totalUnidades;
        double totalPuVentas;
        double totalPuCosto;
        decimal PuVentas;
        decimal PuCosto;
        decimal muUnitario;
        decimal mu;
        decimal montoVentas;
        decimal montoCosto;
        decimal margenUtil;
        string descripcion;
        string medida;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUser"] == null)
                Response.Redirect("~/Acceso");
        }
        
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string JsonCadena = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/" + lstReportes.SelectedValue.ToString() + "/" + "fulltable1.json").Trim().Replace("\\'", "'");
            string JsonProductsByMonth = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/" + lstReportes.SelectedValue.ToString() + "/" + "products1.json").Trim().Replace("\\'", "'");
            string JsonQuerys = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/" + lstReportes.SelectedValue.ToString() + "/" + "Querys.json").Trim().Replace("\\'", "'");

            //string productsByMonth = paths.readFile(@paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/" + lstReportes.SelectedValue.ToString() + "/" + "products" + lstMes.SelectedValue.ToString() + ".json").Trim().Replace("\\'", "'");

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(JsonCadena);
            DataTable dataTable = dataSet.Tables["data"];

            DataSet dataSetProducts = JsonConvert.DeserializeObject<DataSet>(JsonProductsByMonth);
            DataTable dataTableProducts = dataSetProducts.Tables["data"];

            DataSet dataSetQuerys = JsonConvert.DeserializeObject<DataSet>(JsonQuerys);
            DataTable datatableQuerys0 = dataSetQuerys.Tables["data0"];
            DataTable datatableQuerys1 = dataSetProducts.Tables["data1"];
            DataTable datatableQuerys2 = dataSetProducts.Tables["data2"];
            DataTable datatableQuerys3 = dataSetProducts.Tables["data3"];
            DataTable datatableQuerys4 = dataSetProducts.Tables["data4"];
            DataTable datatableQuerys5 = dataSetProducts.Tables["data5"];

            DataTable tablaReporte = new DataTable();
            DataColumn column;
            #region DeclaracionColumnas
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "C";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "D";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "M";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "U";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "PC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MUU";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MV";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MC";
            tablaReporte.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "MU";
            tablaReporte.Columns.Add(column);
            #endregion
            DataSet dsReporte = new DataSet();
            dsReporte.Tables.Add(tablaReporte);
            dsReporte.Tables[0].TableName = "data";

            foreach (DataRow row in dataTableProducts.Rows)
            {
                Procesardatos(row["c"].ToString().Trim(), tablaReporte, dataTable);
            }
            //Ordenar por las diversas consultas
            foreach (DataRow row in datatableQuerys0.Rows)
            {
                Response.Write(row["ccod_alma"].ToString() +  " - ");
            }
            grdPruebas.DataSource = dsReporte;
            grdPruebas.DataBind();
        }
        
        public void Procesardatos(string idProduct, DataTable tableContent, DataTable tableData) {

            #region CalculosMatematicos
            descripcion = tableData.AsEnumerable().Where(x => x.Field<string>("cp").Trim() == idProduct).Select(x => x.Field<string>("cd")).FirstOrDefault();
            medida = tableData.AsEnumerable().Where(x => x.Field<string>("cp").Trim() == idProduct).Select(x => x.Field<string>("cm")).FirstOrDefault();
            try
            {
                totalUnidades = tableData.AsEnumerable().Where(x => x.Field<string>("cp").Trim() == idProduct).Select(x => x.Field<double>("u")).Sum();
            }
            catch (Exception)
            {
                totalUnidades = 0;
            }
            try
            {
                totalPuVentas = tableData.AsEnumerable().Where(x => x.Field<string>("cp").Trim() == idProduct).Select(
                    (x => x.Field<double>("u")*(x.Field<double>("np")/(1 + (x.Field<double>("ni")/100))))).Sum();
            }
            catch (Exception)
            {
                totalPuVentas = 0;
            }
            try
            {
                totalPuCosto = tableData.AsEnumerable().Where(x => x.Field<string>("cp").Trim() == idProduct).Select(
                    (x => x.Field<double>("nc") * x.Field<double>("u"))).Sum();
            }
            catch (Exception)
            {
                totalPuCosto = 0;
            }
            Convert.ToDecimal(totalUnidades);
            Convert.ToDecimal(totalPuVentas);
            Convert.ToDecimal(totalPuCosto);
            if (totalUnidades != 0)
            {
                PuVentas = Convert.ToDecimal(totalPuVentas) / Convert.ToDecimal(totalUnidades);
                PuCosto = Convert.ToDecimal(totalPuCosto) / Convert.ToDecimal(totalUnidades);
            }
            else
            {
                PuVentas = 0;
                PuCosto = 0;
            }
            muUnitario = PuVentas - PuCosto;
            if (PuCosto != 0)
                mu = (muUnitario / PuCosto) * 100;
            else
                mu = 0;
            montoVentas = PuVentas * Convert.ToDecimal(totalUnidades);
            montoCosto = PuCosto * Convert.ToDecimal(totalUnidades);
            margenUtil = montoVentas - montoCosto;
            /*Response.Write( idProduct.ToString() + ": " + totalUnidades.ToString() + " pvu: " +
                totalPuVentas.ToString() + "pcosto: " + totalPuCosto.ToString() +
                "montoVentas: " + montoVentas + "montoCosto" + montoCosto + "margenUtil" + margenUtil
                + "; ");*/

            #endregion
            DataRow row;
            row = tableContent.NewRow();
            row["C"] = idProduct.Trim();
            row["D"] = Convert.ToString(descripcion);
            row["M"] = Convert.ToString(medida);
            row["U"] = Math.Round(Convert.ToDecimal(totalUnidades), 2);
            row["PV"] = Math.Round(Convert.ToDecimal(PuVentas), 4);
            row["PC"] = Math.Round(Convert.ToDecimal(PuCosto), 4);
            row["MUU"] = Math.Round(Convert.ToDecimal(muUnitario), 4);
            row["MV"] = Math.Round(Convert.ToDecimal(montoVentas), 4);
            row["MC"] = Math.Round(Convert.ToDecimal(montoCosto), 4);
            row["MU"] = Math.Round(Convert.ToDecimal(margenUtil), 4);
            tableContent.Rows.Add(row);
        }
    }
}