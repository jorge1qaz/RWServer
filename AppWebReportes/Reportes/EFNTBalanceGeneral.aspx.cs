﻿using BusinessLayer;
using System;
using System.Globalization;

namespace AppWebReportes.Reportes
{
    public partial class EFNTBalanceGeneral : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" };
        string JsonDatasetA105 = "", JsonDatasetA106 = "", JsonDatasetA110 = "", JsonDatasetA111 = "", JsonDatasetA115 = "", JsonDatasetA120 = "", JsonDatasetA121 = "", JsonDatasetA122 = "", JsonDatasetA123 = "",
                JsonDatasetA124 = "", JsonDatasetA125 = "", JsonDatasetA130 = "", JsonDatasetA135 = "", JsonDatasetA140 = "", JsonDatasetA142 = "", JsonDatasetA145 = "", JsonDatasetA151 = "", JsonDatasetA152 = "",
                JsonDatasetA153 = "", JsonDatasetA155 = "", JsonDatasetA157 = "", JsonDatasetA158 = "", JsonDatasetA159 = "", JsonDatasetA160 = "", JsonDatasetA164 = "", JsonDatasetA176 = "", JsonDatasetA177 = "",
                JsonDatasetA178 = "", JsonDatasetA179 = "", JsonDatasetA180 = "", JsonDatasetA185 = "", simboloMoneda = "";

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
                GetReport(true, int.Parse(lstMes.SelectedValue));
            else
                GetReport(false, int.Parse(lstMes.SelectedValue));
        }
        decimal totalA105 = 0, totalA106 = 0, totalA110 = 0, totalA111 = 0, totalA115 = 0, totalA120 = 0, totalA121 = 0, totalA122 = 0, totalA123 = 0, totalA124 = 0, totalA125 = 0, totalA130 = 0, totalA135 = 0,
                totalA140 = 0, totalA142 = 0, totalA145 = 0, totalA151 = 0, totalA152 = 0, totalA153 = 0, totalA155 = 0, totalA157 = 0, totalA158 = 0, totalA159 = 0, totalA160 = 0, totalA164 = 0, totalA176 = 0,
                totalA177 = 0, totalA178 = 0, totalA179 = 0, totalA180 = 0, totalA185 = 0, totalA999 = 0;
        string JsonDatasetP105 = "", JsonDatasetP110 = "", JsonDatasetP115 = "", JsonDatasetP120 = "", JsonDatasetP121 = "", JsonDatasetP122 = "", JsonDatasetP128 = "", JsonDatasetP129 = "", JsonDatasetP133 = "",
                JsonDatasetP135 = "", JsonDatasetP141 = "", JsonDatasetP505 = "", JsonDatasetP507 = "", JsonDatasetP510 = "", JsonDatasetP511 = "", JsonDatasetP515 = "", JsonDatasetP520 = "", JsonDatasetP530 = "",
                JsonDatasetP531 = "", JsonDatasetP540 = "", JsonDatasetP541 = "";
        decimal totalP105 = 0, totalP110 = 0, totalP115 = 0, totalP120 = 0, totalP121 = 0, totalP122 = 0, totalP128 = 0, totalP129 = 0, totalP133 = 0, totalP135 = 0, totalP141 = 0, totalP199 = 0, totalP505 = 0,
                totalP507 = 0, totalP510 = 0, totalP511 = 0, totalP515 = 0, totalP520 = 0, totalP530 = 0, totalP531 = 0, totalP540 = 0, totalP541 = 0, totalP599 = 0, totalP999 = 0;
        //
        string RJsonDatasetF005 = "", RJsonDatasetF105 = "", RJsonDatasetF206 = "", RJsonDatasetF211 = "", RJsonDatasetF212 = "", RJsonDatasetF213 = "", RJsonDatasetF214 = "",
                RJsonDatasetF215 = "", RJsonDatasetF320 = "", RJsonDatasetF350 = "", RJsonDatasetF380 = "", RJsonDatasetF403 = "", RJsonDatasetF405 = "", RJsonDatasetF415 = "", RJsonDatasetF710 = "", RJsonDatasetF805 = "";
        decimal RtotalF005 = 0, RtotalF105 = 0, RtotalF199 = 0, RtotalF206 = 0, RtotalF211 = 0, RtotalF212 = 0, RtotalF213 = 0, RtotalF214 = 0, RtotalF215 = 0, RtotalF299 = 0, RtotalF320 = 0, RtotalF350 = 0,
                RtotalF380 = 0, RtotalF403 = 0, RtotalF405 = 0, RtotalF415 = 0, RtotalF699 = 0, RtotalF710 = 0, RtotalF799 = 0, RtotalF805 = 0, RtotalF999 = 0;

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
            NumberFormatInfo nfi;
            if (moneda)
            {
                nfi = new CultureInfo("es-PE", false).NumberFormat;
                lblTipoMoneda.Text = "Nuevos soles";
            }
            else
            {
                nfi = new CultureInfo("en-US", false).NumberFormat;
                lblTipoMoneda.Text = "Dólares";
            }
            nfi.CurrencyDecimalDigits = 2;

            //Estado de resultado
            RJsonDatasetF005 = GetPathFile2("F005"); RJsonDatasetF105 = GetPathFile2("F105"); RJsonDatasetF206 = GetPathFile2("F206"); RJsonDatasetF211 = GetPathFile2("F211"); RJsonDatasetF212 = GetPathFile2("F212"); RJsonDatasetF213 = GetPathFile2("F213");
            RJsonDatasetF214 = GetPathFile2("F214"); RJsonDatasetF215 = GetPathFile2("F215"); RJsonDatasetF320 = GetPathFile2("F320"); RJsonDatasetF350 = GetPathFile2("F350"); RJsonDatasetF380 = GetPathFile2("F380"); RJsonDatasetF403 = GetPathFile2("F403");
            RJsonDatasetF405 = GetPathFile2("F405"); RJsonDatasetF415 = GetPathFile2("F415"); RJsonDatasetF710 = GetPathFile2("F710"); RJsonDatasetF805 = GetPathFile2("F805");

            RtotalF005 = mergeTables.GeTotalByTablePlan(RJsonDatasetF005, moneda, mesProceso, false); RtotalF105 = mergeTables.GeTotalByTablePlan(RJsonDatasetF105, moneda, mesProceso, false); RtotalF199 = RtotalF005 + RtotalF105;

            RtotalF206 = mergeTables.GeTotalByTablePlan(RJsonDatasetF206, moneda, mesProceso, false); RtotalF211 = mergeTables.GeTotalByTablePlan(RJsonDatasetF211, moneda, mesProceso, false); RtotalF212 = mergeTables.GeTotalByTablePlan(RJsonDatasetF212, moneda, mesProceso, false);
            RtotalF213 = mergeTables.GeTotalByTablePlan(RJsonDatasetF213, moneda, mesProceso, false); RtotalF214 = mergeTables.GeTotalByTablePlan(RJsonDatasetF214, moneda, mesProceso, false); RtotalF215 = mergeTables.GeTotalByTablePlan(RJsonDatasetF215, moneda, mesProceso, false);
            RtotalF299 = RtotalF206 + RtotalF211 + RtotalF212 + RtotalF213 + RtotalF214 + RtotalF215 + RtotalF199;

            RtotalF320 = mergeTables.GeTotalByTablePlan(RJsonDatasetF320, moneda, mesProceso, false); RtotalF350 = mergeTables.GeTotalByTablePlan(RJsonDatasetF350, moneda, mesProceso, false); RtotalF380 = mergeTables.GeTotalByTablePlan(RJsonDatasetF380, moneda, mesProceso, false);
            RtotalF403 = mergeTables.GeTotalByTablePlan(RJsonDatasetF403, moneda, mesProceso, false); RtotalF405 = mergeTables.GeTotalByTablePlan(RJsonDatasetF405, moneda, mesProceso, false); RtotalF415 = mergeTables.GeTotalByTablePlan(RJsonDatasetF415, moneda, mesProceso, false);
            RtotalF699 = RtotalF320 + RtotalF350 + RtotalF380 + RtotalF403 + RtotalF405 + RtotalF415 + RtotalF299;

            RtotalF710 = mergeTables.GeTotalByTablePlan(RJsonDatasetF710, moneda, mesProceso, false); RtotalF799 = RtotalF710 + RtotalF699;
            RtotalF805 = mergeTables.GeTotalByTablePlan(RJsonDatasetF805, moneda, mesProceso, false); RtotalF999 = RtotalF805 + RtotalF799; // RtotalF999 Es el total que se busca para el resultado
            //Fin estado de resultado

            lblMesProceso.Text = meses[mesProceso];
            JsonDatasetA105 = GetPathFile("A105"); JsonDatasetA106 = GetPathFile("A106"); JsonDatasetA110 = GetPathFile("A110"); JsonDatasetA111 = GetPathFile("A111"); JsonDatasetA115 = GetPathFile("A115"); JsonDatasetA120 = GetPathFile("A120");
            JsonDatasetA121 = GetPathFile("A121"); JsonDatasetA122 = GetPathFile("A122"); JsonDatasetA123 = GetPathFile("A123"); JsonDatasetA124 = GetPathFile("A124"); JsonDatasetA125 = GetPathFile("A125"); JsonDatasetA130 = GetPathFile("A130");
            JsonDatasetA135 = GetPathFile("A135"); JsonDatasetA140 = GetPathFile("A140"); JsonDatasetA142 = GetPathFile("A142"); JsonDatasetA145 = GetPathFile("A145"); JsonDatasetA151 = GetPathFile("A151"); JsonDatasetA152 = GetPathFile("A152");
            JsonDatasetA153 = GetPathFile("A153"); JsonDatasetA155 = GetPathFile("A155"); JsonDatasetA157 = GetPathFile("A157"); JsonDatasetA158 = GetPathFile("A158"); JsonDatasetA159 = GetPathFile("A159"); JsonDatasetA160 = GetPathFile("A160");
            JsonDatasetA164 = GetPathFile("A164"); JsonDatasetA176 = GetPathFile("A176"); JsonDatasetA177 = GetPathFile("A177"); JsonDatasetA178 = GetPathFile("A178"); JsonDatasetA179 = GetPathFile("A179"); JsonDatasetA180 = GetPathFile("A180"); JsonDatasetA185 = GetPathFile("A185");

            totalA105 = mergeTables.GeTotalByTablePlan(true, JsonDatasetA105, moneda, mesProceso); totalA106 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA106, moneda, mesProceso);
            totalA110 = mergeTables.GeTotalByTablePlan(true, JsonDatasetA110, moneda, mesProceso);
            totalA111 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA111, moneda, mesProceso); totalA115 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA115, moneda, mesProceso); totalA120 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA120, moneda, mesProceso);
            totalA121 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA121, moneda, mesProceso); totalA122 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA122, moneda, mesProceso); totalA123 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA123, moneda, mesProceso);
            totalA124 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA124, moneda, mesProceso); totalA125 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA125, moneda, mesProceso); totalA130 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA130, moneda, mesProceso);
            totalA135 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA135, moneda, mesProceso); totalA140 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA140, moneda, mesProceso); totalA142 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA142, moneda, mesProceso);
            totalA145 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA145, moneda, mesProceso); totalA151 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA151, moneda, mesProceso); totalA152 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA152, moneda, mesProceso);
            totalA153 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA153, moneda, mesProceso); totalA155 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA155, moneda, mesProceso); totalA157 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA157, moneda, mesProceso);
            totalA158 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA158, moneda, mesProceso); totalA159 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA159, moneda, mesProceso); totalA160 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA160, moneda, mesProceso);
            // 164 lógica anterior
            totalA164 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA164, moneda, mesProceso); totalA176 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA176, moneda, mesProceso); totalA177 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA177, moneda, mesProceso);
            totalA178 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA178, moneda, mesProceso); totalA179 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA179, moneda, mesProceso); totalA180 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA180, moneda, mesProceso);
            totalA185 = mergeTables.GeTotalByTablePlan(false, JsonDatasetA185, moneda, mesProceso); totalA999 = totalA105 + totalA106 + totalA110 + totalA111 + totalA115 + totalA120 + totalA121 + totalA122 + totalA123 + totalA124 + totalA125 + totalA130 + totalA135 + totalA140 +
            totalA142 + totalA145 + totalA151 + totalA152 + totalA153 + totalA155 + totalA157 + totalA158 + totalA159 + totalA160 + totalA164 + totalA176 + totalA177 + totalA178 + totalA179 + totalA180 + totalA185;

            lblA105.Text = totalA105.ToString("C", nfi); lblA106.Text = totalA106.ToString("C", nfi); lblA110.Text = totalA110.ToString("C", nfi); lblA111.Text = totalA111.ToString("C", nfi); lblA115.Text = totalA115.ToString("C", nfi);
            lblA120.Text = totalA120.ToString("C", nfi); lblA121.Text = totalA121.ToString("C", nfi); lblA122.Text = totalA122.ToString("C", nfi); lblA123.Text = totalA123.ToString("C", nfi); lblA124.Text = totalA124.ToString("C", nfi);
            lblA125.Text = totalA125.ToString("C", nfi); lblA130.Text = totalA130.ToString("C", nfi); lblA135.Text = totalA135.ToString("C", nfi); lblA140.Text = totalA140.ToString("C", nfi); lblA142.Text = totalA142.ToString("C", nfi);
            lblA145.Text = totalA145.ToString("C", nfi); lblA151.Text = totalA151.ToString("C", nfi); lblA152.Text = totalA152.ToString("C", nfi); lblA153.Text = totalA153.ToString("C", nfi); lblA155.Text = totalA155.ToString("C", nfi);
            lblA157.Text = totalA157.ToString("C", nfi); lblA158.Text = totalA158.ToString("C", nfi); lblA159.Text = totalA159.ToString("C", nfi); lblA160.Text = totalA160.ToString("C", nfi); lblA164.Text = totalA164.ToString("C", nfi);
            lblA176.Text = totalA176.ToString("C", nfi); lblA177.Text = totalA177.ToString("C", nfi); lblA178.Text = totalA178.ToString("C", nfi); lblA179.Text = totalA179.ToString("C", nfi); lblA180.Text = totalA180.ToString("C", nfi);
            lblA185.Text = totalA185.ToString("C", nfi); lblA999.Text = totalA999.ToString("C", nfi); //Valor del total

            JsonDatasetP105 = GetPathFile("P105"); JsonDatasetP110 = GetPathFile("P110"); JsonDatasetP115 = GetPathFile("P115"); JsonDatasetP120 = GetPathFile("P120"); JsonDatasetP121 = GetPathFile("P121"); JsonDatasetP122 = GetPathFile("P122"); JsonDatasetP128 = GetPathFile("P128");
            JsonDatasetP129 = GetPathFile("P129"); JsonDatasetP133 = GetPathFile("P133"); JsonDatasetP135 = GetPathFile("P135"); JsonDatasetP141 = GetPathFile("P141"); JsonDatasetP505 = GetPathFile("P505"); JsonDatasetP507 = GetPathFile("P507"); JsonDatasetP510 = GetPathFile("P510");
            JsonDatasetP511 = GetPathFile("P511"); JsonDatasetP515 = GetPathFile("P515"); JsonDatasetP520 = GetPathFile("P520"); JsonDatasetP530 = GetPathFile("P530"); JsonDatasetP531 = GetPathFile("P531"); JsonDatasetP540 = GetPathFile("P540"); JsonDatasetP541 = GetPathFile("P541");

            totalP105 = mergeTables.GeTotalByTablePlan(true, JsonDatasetP105, moneda, mesProceso); totalP110 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP110, moneda, mesProceso); totalP115 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP115, moneda, mesProceso);
            totalP120 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP120, moneda, mesProceso); totalP121 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP121, moneda, mesProceso); totalP122 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP122, moneda, mesProceso);
            totalP128 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP128, moneda, mesProceso); totalP129 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP129, moneda, mesProceso); totalP133 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP133, moneda, mesProceso);
            totalP135 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP135, moneda, mesProceso); totalP141 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP141, moneda, mesProceso); totalP505 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP505, moneda, mesProceso);
            totalP507 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP507, moneda, mesProceso); totalP510 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP510, moneda, mesProceso); totalP511 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP511, moneda, mesProceso);
            totalP515 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP515, moneda, mesProceso); totalP520 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP520, moneda, mesProceso); totalP530 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP530, moneda, mesProceso);
            totalP531 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP531, moneda, mesProceso); totalP540 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP540, moneda, mesProceso); totalP541 = mergeTables.GeTotalByTablePlan(false, JsonDatasetP541, moneda, mesProceso);

            totalP199 = totalP105 + totalP110 + totalP115 + totalP120 + totalP121 + totalP122 + totalP128 + totalP129 + totalP133 + totalP135 + totalP141;
            totalP599 = totalP505 + totalP507 + totalP510 + totalP511 + totalP515 + totalP520 + totalP530 + totalP531 + RtotalF999 + totalP540 + totalP541;
            totalP999 = totalP199 + totalP599;

            lblP105.Text = totalP105.ToString("C", nfi); lblP110.Text = totalP110.ToString("C", nfi); lblP115.Text = totalP115.ToString("C", nfi); lblP120.Text = totalP120.ToString("C", nfi); lblP121.Text = totalP121.ToString("C", nfi);
            lblP122.Text = totalP122.ToString("C", nfi); lblP128.Text = totalP128.ToString("C", nfi); lblP129.Text = totalP129.ToString("C", nfi); lblP133.Text = totalP133.ToString("C", nfi); lblP135.Text = totalP135.ToString("C", nfi);
            lblP141.Text = totalP141.ToString("C", nfi); lblP505.Text = totalP505.ToString("C", nfi); lblP507.Text = totalP507.ToString("C", nfi); lblP510.Text = totalP510.ToString("C", nfi); lblP511.Text = totalP511.ToString("C", nfi);
            lblP515.Text = totalP515.ToString("C", nfi); lblP520.Text = totalP520.ToString("C", nfi); lblP530.Text = totalP530.ToString("C", nfi); lblP531.Text = totalP531.ToString("C", nfi); lblP541.Text = totalP541.ToString("C", nfi);

            lblP199.Text = totalP199.ToString("C", nfi);
            lblPResultado.Text = RtotalF999.ToString("C", nfi); // Se añadirá el resultado al P540
            lblP599.Text = totalP599.ToString("C", nfi);
            lblP999.Text = totalP999.ToString("C", nfi);
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
            String rootPath = Server.MapPath("~"); //Ruta física
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdFncr/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "3" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile2(string nameFile)
        {
            String rootPath = Server.MapPath("~"); //Ruta física
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdPmS/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}