﻿using BusinessLayer;
using System;

namespace AppWebReportes.Reportes
{
    public partial class EFNTEstadoGananciasPerdidas : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" };
        string simboloMoneda = "", JsonDatasetF005 = "", JsonDatasetF010 = "", JsonDatasetF115 = "", JsonDatasetF205 = "", JsonDatasetF210 = "", JsonDatasetF502 = "", JsonDatasetF505 = "",
                JsonDatasetF510 = "", JsonDatasetF515 = "", JsonDatasetF520 = "", JsonDatasetF525 = "", JsonDatasetF530 = "", JsonDatasetF560 = "", JsonDatasetF605 = "", JsonDatasetF705 = "";
        decimal totalF005 = 0, totalF010 = 0, totalF099 = 0, totalF115 = 0, totalF199 = 0, totalF205 = 0, totalF210 = 0, totalF299 = 0, totalF502 = 0, totalF505 = 0, 
                totalF510 = 0, totalF515 = 0, totalF520 = 0, totalF525 = 0, totalF530 = 0, totalF560 = 0, totalF599 = 0, totalF605 = 0, totalF699 = 0, totalF705 = 0, totalF999 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null || Request.QueryString["idCompany"] == null || Request.QueryString["year"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
            lblTipoReporte.Text = Session["TipoReporteEFNT"].ToString();
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para */
        public void GetReport(bool moneda, int mesProceso)
        {
            if (moneda)
            { simboloMoneda = "S/ "; lblTipoMoneda.Text = "Nuevos soles"; }
            else
            { simboloMoneda = "$ "; lblTipoMoneda.Text = "Dólares"; }
            lblMesProceso.Text = meses[mesProceso];
            JsonDatasetF005 = GetPathFile("F005"); JsonDatasetF010 = GetPathFile("F010"); JsonDatasetF115 = GetPathFile("F115"); JsonDatasetF205 = GetPathFile("F205"); JsonDatasetF210 = GetPathFile("F210");
            JsonDatasetF502 = GetPathFile("F502"); JsonDatasetF505 = GetPathFile("F505"); JsonDatasetF510 = GetPathFile("F510"); JsonDatasetF515 = GetPathFile("F515"); JsonDatasetF520 = GetPathFile("F520");
            JsonDatasetF525 = GetPathFile("F525"); JsonDatasetF530 = GetPathFile("F530"); JsonDatasetF560 = GetPathFile("F560"); JsonDatasetF605 = GetPathFile("F605"); JsonDatasetF705 = GetPathFile("F705");

            totalF005 = mergeTables.GeTotalByTablePlan(JsonDatasetF005, moneda, mesProceso, false)*-1; totalF010 = mergeTables.GeTotalByTablePlan(JsonDatasetF010, moneda, mesProceso, false);
            totalF115 = mergeTables.GeTotalByTablePlan(JsonDatasetF115, moneda, mesProceso, false); totalF205 = mergeTables.GeTotalByTablePlan(JsonDatasetF205, moneda, mesProceso, false);
            totalF210 = mergeTables.GeTotalByTablePlan(JsonDatasetF210, moneda, mesProceso, false); totalF502 = mergeTables.GeTotalByTablePlan(JsonDatasetF502, moneda, mesProceso, false);
            totalF505 = mergeTables.GeTotalByTablePlan(JsonDatasetF505, moneda, mesProceso, false) * -1; totalF510 = mergeTables.GeTotalByTablePlan(JsonDatasetF510, moneda, mesProceso, false) * -1;
            totalF515 = mergeTables.GeTotalByTablePlan(JsonDatasetF515, moneda, mesProceso, false) * -1; totalF520 = mergeTables.GeTotalByTablePlan(JsonDatasetF520, moneda, mesProceso, false) * -1;
            totalF525 = mergeTables.GeTotalByTablePlan(JsonDatasetF525, moneda, mesProceso, false); totalF530 = mergeTables.GeTotalByTablePlan(JsonDatasetF530, moneda, mesProceso, false);
            totalF560 = mergeTables.GeTotalByTablePlan(JsonDatasetF560, moneda, mesProceso, false); totalF605 = mergeTables.GeTotalByTablePlan(JsonDatasetF605, moneda, mesProceso, false);
            totalF705 = mergeTables.GeTotalByTablePlan(JsonDatasetF705, moneda, mesProceso, false);

            totalF099 = totalF005 + totalF010; totalF199 = totalF115 + totalF099; totalF299 = totalF205 + totalF210 + totalF199; totalF599 = totalF502 + totalF505 + totalF510 + totalF515 
            + totalF520 + totalF525 + totalF530 + totalF560 + totalF299; totalF699 = totalF605 + totalF599; totalF999 = totalF705 + totalF699;

            lblF099.Text = simboloMoneda + totalF099.ToString(); lblF005.Text = simboloMoneda + totalF005.ToString(); lblF010.Text = simboloMoneda + totalF010.ToString(); lblF199.Text = simboloMoneda + totalF199.ToString();
            lblF115.Text = simboloMoneda + totalF115.ToString(); lblF299.Text = simboloMoneda + totalF299.ToString(); lblF205.Text = simboloMoneda + totalF205.ToString(); lblF210.Text = simboloMoneda + totalF210.ToString();
            lblF599.Text = simboloMoneda + totalF599.ToString(); lblF502.Text = simboloMoneda + totalF502.ToString(); lblF505.Text = simboloMoneda + totalF505.ToString(); lblF510.Text = simboloMoneda + totalF510.ToString();
            lblF515.Text = simboloMoneda + totalF515.ToString(); lblF520.Text = simboloMoneda + totalF520.ToString(); lblF525.Text = simboloMoneda + totalF525.ToString(); lblF530.Text = simboloMoneda + totalF530.ToString();
            lblF560.Text = simboloMoneda + totalF560.ToString(); lblF699.Text = simboloMoneda + totalF699.ToString(); lblF605.Text = simboloMoneda + totalF605.ToString(); lblF999.Text = simboloMoneda + totalF999.ToString();lblF705.Text = simboloMoneda + totalF705.ToString();
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para */
        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
                GetReport(true, int.Parse(lstMes.SelectedValue));
            else
                GetReport(false, int.Parse(lstMes.SelectedValue));
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para */
        protected void lstTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bool.Parse(lstTipoMoneda.SelectedValue) == true)
            {
                Session["TipoMonedaEFNT"] = "Nuevos soles";
                GetReport(true, int.Parse(lstMes.SelectedValue));
            }
            else
            {
                Session["TipoMonedaEFNT"] = "Dólares";
                GetReport(false, int.Parse(lstMes.SelectedValue));
            }
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdFncr/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "4" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}