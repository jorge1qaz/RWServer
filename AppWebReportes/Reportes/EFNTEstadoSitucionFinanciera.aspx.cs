using System;
using System.Globalization;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class EstadosFinancieros : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string simboloMoneda = "S/ ";
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" };
        string JsonDatasetA105 = "", JsonDatasetA110 = "", JsonDatasetA115 = "", JsonDatasetA120 = "", JsonDatasetA125 = "", JsonDatasetA128 = "", JsonDatasetA130 = "", JsonDatasetA131 = "", JsonDatasetA133 = "",
                JsonDatasetA140 = "", JsonDatasetA210 = "", JsonDatasetA220 = "", JsonDatasetA510 = "", JsonDatasetA513 = "", JsonDatasetA515 = "", JsonDatasetA517 = "", JsonDatasetA520 = "", JsonDatasetA525 = "",
                JsonDatasetA530 = "", JsonDatasetA540 = "", JsonDatasetA550 = "", JsonDatasetA560 = "", JsonDatasetA570 = "", JsonDatasetA575 = "", JsonDatasetA580 = "";

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
            {
                GetReport(true, int.Parse(lstMes.SelectedValue));
            }
            else
                GetReport(false, int.Parse(lstMes.SelectedValue));
        }
        decimal totalA105, totalA110, totalA115, totalA120, totalA125, totalA128, totalA130, totalA131, totalA133, totalA140, totalA210, totalA220, totalA510, totalA513,
                totalA515, totalA517, totalA520, totalA525, totalA530, totalA540, totalA550, totalA560, totalA570, totalA575, totalA580, totalA199, totalA399, totalA599, totalA999;
        string JsonDatasetP105 = "", JsonDatasetP110 = "", JsonDatasetP120 = "", JsonDatasetP121 = "", JsonDatasetP123 = "", JsonDatasetP125 = "", JsonDatasetP130 = "", JsonDatasetP135 = "", JsonDatasetP137 = "",
                JsonDatasetP210 = "", JsonDatasetP410 = "", JsonDatasetP415 = "", JsonDatasetP420 = "", JsonDatasetP425 = "", JsonDatasetP430 = "", JsonDatasetP435 = "", JsonDatasetP440 = "", JsonDatasetP445 = "",
                JsonDatasetP450 = "", JsonDatasetP805 = "", JsonDatasetP810 = "", JsonDatasetP815 = "", JsonDatasetP820 = "", JsonDatasetP830 = "", JsonDatasetP835 = "", JsonDatasetP840 = "";
        decimal totalP105, totalP110, totalP120, totalP121, totalP123, totalP125, totalP130, totalP135, totalP137, totalP210, totalP410, totalP415, totalP420, totalP425, totalP430,
                totalP435, totalP440, totalP445, totalP450, totalP699, totalP805, totalP810, totalP815, totalP820, totalP830, totalP835, totalP840, totalP199, totalP399, totalP499, totalP899, totalP999;
        string JsonDatasetF005 = "", JsonDatasetF105 = "", JsonDatasetF206 = "", JsonDatasetF211 = "", JsonDatasetF212 = "", JsonDatasetF213 = "", JsonDatasetF214 = "",
               JsonDatasetF215 = "", JsonDatasetF320 = "", JsonDatasetF350 = "", JsonDatasetF380 = "", JsonDatasetF403 = "", JsonDatasetF405 = "", JsonDatasetF415 = "", JsonDatasetF710 = "", JsonDatasetF805 = "";
        decimal totalF005 = 0, totalF105 = 0, totalF199 = 0, totalF206 = 0, totalF211 = 0, totalF212 = 0, totalF213 = 0, totalF214 = 0, totalF215 = 0, totalF299 = 0, totalF320 = 0, totalF350 = 0, totalF380 = 0, totalF403 = 0, totalF405 = 0, totalF415 = 0, totalF699 = 0, totalF710 = 0, totalF799 = 0, totalF805 = 0, totalF999 = 0;
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
        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
            {
                GetReport(true, int.Parse(lstMes.SelectedValue));
            }
            else
                GetReport(false, int.Parse(lstMes.SelectedValue));
        }
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
        //Jorge Luis|26/12/2017|RW-103
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
            JsonDatasetF005 = GetPathFile2("F005"); JsonDatasetF105 = GetPathFile2("F105"); JsonDatasetF206 = GetPathFile2("F206"); JsonDatasetF211 = GetPathFile2("F211"); JsonDatasetF212 = GetPathFile2("F212"); JsonDatasetF213 = GetPathFile2("F213");
            JsonDatasetF214 = GetPathFile2("F214"); JsonDatasetF215 = GetPathFile2("F215"); JsonDatasetF320 = GetPathFile2("F320"); JsonDatasetF350 = GetPathFile2("F350"); JsonDatasetF380 = GetPathFile2("F380"); JsonDatasetF403 = GetPathFile2("F403");
            JsonDatasetF405 = GetPathFile2("F405"); JsonDatasetF415 = GetPathFile2("F415"); JsonDatasetF710 = GetPathFile2("F710"); JsonDatasetF805 = GetPathFile2("F805");

            totalF005 = mergeTables.GeTotalByTablePlan(JsonDatasetF005, moneda, mesProceso, false); totalF105 = mergeTables.GeTotalByTablePlan(JsonDatasetF105, moneda, mesProceso, false); totalF199 = totalF005 + totalF105;

            totalF206 = mergeTables.GeTotalByTablePlan(JsonDatasetF206, moneda, mesProceso, false); totalF211 = mergeTables.GeTotalByTablePlan(JsonDatasetF211, moneda, mesProceso, false); totalF212 = mergeTables.GeTotalByTablePlan(JsonDatasetF212, moneda, mesProceso, false);
            totalF213 = mergeTables.GeTotalByTablePlan(JsonDatasetF213, moneda, mesProceso, false); totalF214 = mergeTables.GeTotalByTablePlan(JsonDatasetF214, moneda, mesProceso, false); totalF215 = mergeTables.GeTotalByTablePlan(JsonDatasetF215, moneda, mesProceso, false);
            totalF299 = totalF206 + totalF211 + totalF212 + totalF213 + totalF214 + totalF215 + totalF199;

            totalF320 = mergeTables.GeTotalByTablePlan(JsonDatasetF320, moneda, mesProceso, false); totalF350 = mergeTables.GeTotalByTablePlan(JsonDatasetF350, moneda, mesProceso, false); totalF380 = mergeTables.GeTotalByTablePlan(JsonDatasetF380, moneda, mesProceso, false);
            totalF403 = mergeTables.GeTotalByTablePlan(JsonDatasetF403, moneda, mesProceso, false); totalF405 = mergeTables.GeTotalByTablePlan(JsonDatasetF405, moneda, mesProceso, false); totalF415 = mergeTables.GeTotalByTablePlan(JsonDatasetF415, moneda, mesProceso, false);
            totalF699 = totalF320 + totalF350 + totalF380 + totalF403 + totalF405 + totalF415 + totalF299;

            totalF710 = mergeTables.GeTotalByTablePlan(JsonDatasetF710, moneda, mesProceso, false); totalF799 = totalF710 + totalF699;
            totalF805 = mergeTables.GeTotalByTablePlan(JsonDatasetF805, moneda, mesProceso, false); totalF999 = totalF805 + totalF799; // totalF999 Es el total que se busca para el resultado
            //Fin estado de resultado

            lblMesProceso.Text = meses[mesProceso];
            JsonDatasetA105 = GetPathFile("A105"); JsonDatasetA110 = GetPathFile("A110"); JsonDatasetA115 = GetPathFile("A115"); JsonDatasetA120 = GetPathFile("A120"); JsonDatasetA125 = GetPathFile("A125"); JsonDatasetA128 = GetPathFile("A128");
            JsonDatasetA130 = GetPathFile("A130"); JsonDatasetA131 = GetPathFile("A131"); JsonDatasetA133 = GetPathFile("A133"); JsonDatasetA140 = GetPathFile("A140"); JsonDatasetA210 = GetPathFile("A210"); JsonDatasetA220 = GetPathFile("A220");
            JsonDatasetA510 = GetPathFile("A510"); JsonDatasetA513 = GetPathFile("A513"); JsonDatasetA515 = GetPathFile("A515"); JsonDatasetA517 = GetPathFile("A517"); JsonDatasetA520 = GetPathFile("A520"); JsonDatasetA525 = GetPathFile("A525");
            JsonDatasetA530 = GetPathFile("A530"); JsonDatasetA540 = GetPathFile("A540"); JsonDatasetA550 = GetPathFile("A550"); JsonDatasetA560 = GetPathFile("A560"); JsonDatasetA570 = GetPathFile("A570"); JsonDatasetA575 = GetPathFile("A575");
            JsonDatasetA580 = GetPathFile("A580"); JsonDatasetP835 = GetPathFile("P835"); JsonDatasetP840 = GetPathFile("P840"); JsonDatasetP815 = GetPathFile("P815"); JsonDatasetP820 = GetPathFile("P820"); JsonDatasetP830 = GetPathFile("P830");
            JsonDatasetP105 = GetPathFile("P105"); JsonDatasetP110 = GetPathFile("P110"); JsonDatasetP120 = GetPathFile("P120"); JsonDatasetP121 = GetPathFile("P121"); JsonDatasetP123 = GetPathFile("P123"); JsonDatasetP125 = GetPathFile("P125");
            JsonDatasetP130 = GetPathFile("P130"); JsonDatasetP135 = GetPathFile("P135"); JsonDatasetP137 = GetPathFile("P137"); JsonDatasetP210 = GetPathFile("P210"); JsonDatasetP410 = GetPathFile("P410"); JsonDatasetP415 = GetPathFile("P415");
            JsonDatasetP420 = GetPathFile("P420"); JsonDatasetP425 = GetPathFile("P425"); JsonDatasetP430 = GetPathFile("P430"); JsonDatasetP435 = GetPathFile("P435"); JsonDatasetP440 = GetPathFile("P440"); JsonDatasetP445 = GetPathFile("P445");
            JsonDatasetP450 = GetPathFile("P450"); JsonDatasetP805 = GetPathFile("P805"); JsonDatasetP810 = GetPathFile("P810");

            totalA105 = mergeTables.GeTotalByTablePlan(JsonDatasetA105, moneda, mesProceso, true); totalA110 = mergeTables.GeTotalByTablePlan(JsonDatasetA110, moneda, mesProceso, true); totalA115 = mergeTables.GeTotalByTablePlan(JsonDatasetA115, moneda, mesProceso, true);
            totalA120 = mergeTables.GeTotalByTablePlan(JsonDatasetA120, moneda, mesProceso, true); totalA125 = mergeTables.GeTotalByTablePlan(JsonDatasetA125, moneda, mesProceso, true); totalA128 = mergeTables.GeTotalByTablePlan(JsonDatasetA128, moneda, mesProceso, true);
            totalA130 = mergeTables.GeTotalByTablePlan(JsonDatasetA130, moneda, mesProceso, true); totalA131 = mergeTables.GeTotalByTablePlan(JsonDatasetA131, moneda, mesProceso, true); totalA133 = mergeTables.GeTotalByTablePlan(JsonDatasetA133, moneda, mesProceso, true);
            totalA140 = mergeTables.GeTotalByTablePlan(JsonDatasetA140, moneda, mesProceso, true); totalA210 = mergeTables.GeTotalByTablePlan(JsonDatasetA210, moneda, mesProceso, true); totalA220 = mergeTables.GeTotalByTablePlan(JsonDatasetA220, moneda, mesProceso, true);
            totalA510 = mergeTables.GeTotalByTablePlan(JsonDatasetA510, moneda, mesProceso, true); totalA513 = mergeTables.GeTotalByTablePlan(JsonDatasetA513, moneda, mesProceso, true); totalA515 = mergeTables.GeTotalByTablePlan(JsonDatasetA515, moneda, mesProceso, true);
            totalA517 = mergeTables.GeTotalByTablePlan(JsonDatasetA517, moneda, mesProceso, true); totalA520 = mergeTables.GeTotalByTablePlan(JsonDatasetA520, moneda, mesProceso, true); totalA525 = mergeTables.GeTotalByTablePlan(JsonDatasetA525, moneda, mesProceso, true);
            totalA530 = mergeTables.GeTotalByTablePlan(JsonDatasetA530, moneda, mesProceso, true); totalA540 = mergeTables.GeTotalByTablePlan(JsonDatasetA540, moneda, mesProceso, true); totalA550 = mergeTables.GeTotalByTablePlan(JsonDatasetA550, moneda, mesProceso, true);
            totalA560 = mergeTables.GeTotalByTablePlan(JsonDatasetA560, moneda, mesProceso, true); totalA570 = mergeTables.GeTotalByTablePlan(JsonDatasetA570, moneda, mesProceso, true); totalA575 = mergeTables.GeTotalByTablePlan(JsonDatasetA575, moneda, mesProceso, true);
            totalA580 = mergeTables.GeTotalByTablePlan(JsonDatasetA580, moneda, mesProceso, true);
            totalP105 = mergeTables.GeTotalByTablePlan(JsonDatasetP105, moneda, mesProceso, true); totalP110 = mergeTables.GeTotalByTablePlan(JsonDatasetP110, moneda, mesProceso, true); totalP120 = mergeTables.GeTotalByTablePlan(JsonDatasetP120, moneda, mesProceso, true);
            totalP121 = mergeTables.GeTotalByTablePlan(JsonDatasetP121, moneda, mesProceso, true); totalP123 = mergeTables.GeTotalByTablePlan(JsonDatasetP123, moneda, mesProceso, true); totalP125 = mergeTables.GeTotalByTablePlan(JsonDatasetP125, moneda, mesProceso, true);
            totalP130 = mergeTables.GeTotalByTablePlan(JsonDatasetP130, moneda, mesProceso, true); totalP135 = mergeTables.GeTotalByTablePlan(JsonDatasetP135, moneda, mesProceso, true); totalP137 = mergeTables.GeTotalByTablePlan(JsonDatasetP137, moneda, mesProceso, true);
            totalP210 = mergeTables.GeTotalByTablePlan(JsonDatasetP210, moneda, mesProceso, true); totalP410 = mergeTables.GeTotalByTablePlan(JsonDatasetP410, moneda, mesProceso, true); totalP415 = mergeTables.GeTotalByTablePlan(JsonDatasetP415, moneda, mesProceso, true);
            totalP420 = mergeTables.GeTotalByTablePlan(JsonDatasetP420, moneda, mesProceso, true); totalP425 = mergeTables.GeTotalByTablePlan(JsonDatasetP425, moneda, mesProceso, true); totalP430 = mergeTables.GeTotalByTablePlan(JsonDatasetP430, moneda, mesProceso, true);
            totalP435 = mergeTables.GeTotalByTablePlan(JsonDatasetP435, moneda, mesProceso, true); totalP440 = mergeTables.GeTotalByTablePlan(JsonDatasetP440, moneda, mesProceso, true); totalP445 = mergeTables.GeTotalByTablePlan(JsonDatasetP445, moneda, mesProceso, true);
            totalP450 = mergeTables.GeTotalByTablePlan(JsonDatasetP450, moneda, mesProceso, true); totalP805 = mergeTables.GeTotalByTablePlan(JsonDatasetP805, moneda, mesProceso, true); totalP810 = mergeTables.GeTotalByTablePlan(JsonDatasetP810, moneda, mesProceso, true);
            totalP815 = mergeTables.GeTotalByTablePlan(JsonDatasetP815, moneda, mesProceso, true); totalP820 = mergeTables.GeTotalByTablePlan(JsonDatasetP820, moneda, mesProceso, true); totalP830 = mergeTables.GeTotalByTablePlan(JsonDatasetP830, moneda, mesProceso, true);
            totalP835 = totalF999; totalP840 = mergeTables.GeTotalByTablePlan(JsonDatasetP840, moneda, mesProceso, true);

            lblA105.Text = totalA105.ToString("C", nfi); lblA110.Text = totalA110.ToString("C", nfi); lblA115.Text = totalA115.ToString("C", nfi); lblA120.Text = totalA120.ToString("C", nfi);
            lblA125.Text = totalA125.ToString("C", nfi); lblA128.Text = totalA128.ToString("C", nfi); lblA580.Text = totalA580.ToString("C", nfi); lblA130.Text = totalA130.ToString("C", nfi);
            lblA131.Text = totalA131.ToString("C", nfi); lblA133.Text = totalA133.ToString("C", nfi); lblA140.Text = totalA140.ToString("C", nfi); lblA210.Text = totalA210.ToString("C", nfi);
            lblA220.Text = totalA220.ToString("C", nfi); lblA510.Text = totalA510.ToString("C", nfi); lblA513.Text = totalA513.ToString("C", nfi); lblA515.Text = totalA515.ToString("C", nfi);
            lblA517.Text = totalA517.ToString("C", nfi); lblA520.Text = totalA520.ToString("C", nfi); lblA525.Text = totalA525.ToString("C", nfi); lblA530.Text = totalA530.ToString("C", nfi);
            lblA540.Text = totalA540.ToString("C", nfi); lblA550.Text = totalA550.ToString("C", nfi); lblA560.Text = totalA560.ToString("C", nfi); lblA570.Text = totalA570.ToString("C", nfi);
            lblA575.Text = totalA575.ToString("C", nfi);

            totalA199 = totalA105 + totalA110 + totalA115 + totalA120 + totalA125 + totalA128 + totalA130 + totalA131 + totalA133 + totalA140; totalA399 = totalA210 + totalA220 + totalA199;
            totalA599 = totalA510 + totalA513 + totalA515 + totalA517 + totalA520 + totalA525 + totalA530 + totalA540 + totalA550 + totalA560 + totalA570 + totalA575 + totalA580 + totalA399; totalA999 = totalA599;
            lblA199.Text = totalA199.ToString("C", nfi); lblA399.Text = totalA399.ToString("C", nfi); lblA599.Text = totalA599.ToString("C", nfi); lblA999.Text = totalA999.ToString("C", nfi);

            lblP105.Text = totalP105.ToString("C", nfi); lblP110.Text = totalP110.ToString("C", nfi); lblP120.Text = totalP120.ToString("C", nfi); lblP121.Text = totalP121.ToString("C", nfi);
            lblP123.Text = totalP123.ToString("C", nfi); lblP125.Text = totalP125.ToString("C", nfi); lblP130.Text = totalP130.ToString("C", nfi); lblP135.Text = totalP135.ToString("C", nfi);
            lblP137.Text = totalP137.ToString("C", nfi); lblP210.Text = totalP210.ToString("C", nfi); lblP410.Text = totalP410.ToString("C", nfi); lblP415.Text = totalP415.ToString("C", nfi);
            lblP420.Text = totalP420.ToString("C", nfi); lblP425.Text = totalP425.ToString("C", nfi); lblP430.Text = totalP430.ToString("C", nfi); lblP435.Text = totalP435.ToString("C", nfi);
            lblP440.Text = totalP440.ToString("C", nfi); lblP445.Text = totalP445.ToString("C", nfi); lblP450.Text = totalP450.ToString("C", nfi); lblP805.Text = totalP805.ToString("C", nfi);
            lblP810.Text = totalP810.ToString("C", nfi); lblP815.Text = totalP815.ToString("C", nfi); lblP820.Text = totalP820.ToString("C", nfi); lblP830.Text = totalP830.ToString("C", nfi);
            lblP835.Text = totalP835.ToString("C", nfi); lblP840.Text = totalP840.ToString("C", nfi);

            //Labels finales
            totalP199 = totalP105 + totalP110 + totalP120 + totalP121 + totalP123 + totalP125 + totalP130 + totalP135 + totalP137; totalP399 = totalP210 + totalP199; totalP699 = totalP499 + totalP399;
            totalP499 = totalP410 + totalP415 + totalP420 + totalP425 + totalP430 + totalP435 + totalP440 + totalP445 + totalP450; totalP899 = totalP805 + totalP810 + totalP815 + totalP820 + totalP830 + totalP835 + totalP840;
            totalP999 = totalP899 + totalP399;
            lblP199.Text = totalP199.ToString("C", nfi); lblP399.Text = totalP399.ToString("C", nfi); lblP499.Text = totalP499.ToString("C", nfi); lblP899.Text = totalP899.ToString("C", nfi);
            lblP999.Text = totalP999.ToString("C", nfi); lblP699.Text = totalP699.ToString("C", nfi);
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdFncr/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + "1" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile2(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdPmS/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}