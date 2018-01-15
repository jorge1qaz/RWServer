using System;
using System.Globalization;
using System.Threading;
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
            Session.Remove("TipoMonedaEFNT");
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
            totalF805 = mergeTables.GeTotalByTablePlan(JsonDatasetF805, moneda, mesProceso, false); totalF999 = totalF805 + totalF799;
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

            if (moneda)
            { simboloMoneda = "S/ "; lblTipoMoneda.Text = "Nuevos soles"; }
            else
            { simboloMoneda = "$ "; lblTipoMoneda.Text = "Dólares"; }

            lblA105.Text = simboloMoneda + totalA105.ToString(); lblA110.Text = simboloMoneda + totalA110.ToString(); lblA115.Text = simboloMoneda + totalA115.ToString(); lblA120.Text = simboloMoneda + totalA120.ToString();
            lblA125.Text = simboloMoneda + totalA125.ToString(); lblA128.Text = simboloMoneda + totalA128.ToString(); lblA580.Text = simboloMoneda + totalA580.ToString(); lblA130.Text = simboloMoneda + totalA130.ToString();
            lblA131.Text = simboloMoneda + totalA131.ToString(); lblA133.Text = simboloMoneda + totalA133.ToString(); lblA140.Text = simboloMoneda + totalA140.ToString(); lblA210.Text = simboloMoneda + totalA210.ToString();
            lblA220.Text = simboloMoneda + totalA220.ToString(); lblA510.Text = simboloMoneda + totalA510.ToString(); lblA513.Text = simboloMoneda + totalA513.ToString(); lblA515.Text = simboloMoneda + totalA515.ToString();
            lblA517.Text = simboloMoneda + totalA517.ToString(); lblA520.Text = simboloMoneda + totalA520.ToString(); lblA525.Text = simboloMoneda + totalA525.ToString(); lblA530.Text = simboloMoneda + totalA530.ToString();
            lblA540.Text = simboloMoneda + totalA540.ToString(); lblA550.Text = simboloMoneda + totalA550.ToString(); lblA560.Text = simboloMoneda + totalA560.ToString(); lblA570.Text = simboloMoneda + totalA570.ToString();
            lblA575.Text = simboloMoneda + totalA575.ToString();

            totalA199 = totalA105 + totalA110 + totalA115 + totalA120 + totalA125 + totalA128 + totalA130 + totalA131 + totalA133 + totalA140; totalA399 = totalA210 + totalA220 + totalA199;
            totalA599 = totalA510 + totalA513 + totalA515 + totalA517 + totalA520 + totalA525 + totalA530 + totalA540 + totalA550 + totalA560 + totalA570 + totalA575 + totalA580 + totalA399; totalA999 = totalA599;
            lblA199.Text = simboloMoneda + totalA199.ToString(); lblA399.Text = simboloMoneda + totalA399.ToString(); lblA599.Text = simboloMoneda + totalA599.ToString(); lblA999.Text = simboloMoneda + totalA999.ToString();

            lblP105.Text = simboloMoneda + totalP105.ToString(); lblP110.Text = simboloMoneda + totalP110.ToString(); lblP120.Text = simboloMoneda + totalP120.ToString(); lblP121.Text = simboloMoneda + totalP121.ToString();
            lblP123.Text = simboloMoneda + totalP123.ToString(); lblP125.Text = simboloMoneda + totalP125.ToString(); lblP130.Text = simboloMoneda + totalP130.ToString(); lblP135.Text = simboloMoneda + totalP135.ToString();
            lblP137.Text = simboloMoneda + totalP137.ToString(); lblP210.Text = simboloMoneda + totalP210.ToString(); lblP410.Text = simboloMoneda + totalP410.ToString(); lblP415.Text = simboloMoneda + totalP415.ToString();
            lblP420.Text = simboloMoneda + totalP420.ToString(); lblP425.Text = simboloMoneda + totalP425.ToString(); lblP430.Text = simboloMoneda + totalP430.ToString(); lblP435.Text = simboloMoneda + totalP435.ToString();
            lblP440.Text = simboloMoneda + totalP440.ToString(); lblP445.Text = simboloMoneda + totalP445.ToString(); lblP450.Text = simboloMoneda + totalP450.ToString(); lblP805.Text = simboloMoneda + totalP805.ToString();
            lblP810.Text = simboloMoneda + totalP810.ToString(); lblP815.Text = simboloMoneda + totalP815.ToString(); lblP820.Text = simboloMoneda + totalP820.ToString(); lblP830.Text = simboloMoneda + totalP830.ToString();
            lblP835.Text = simboloMoneda + totalP835.ToString(); lblP840.Text = simboloMoneda + totalP840.ToString();
            
            //Labels finales
            totalP199 = totalP105 + totalP110 + totalP120 + totalP121 + totalP123 + totalP125 + totalP130 + totalP135 + totalP137; totalP399 = totalP210 + totalP199; totalP699 = totalP499 + totalP399;
            totalP499 = totalP410 + totalP415 + totalP420 + totalP425 + totalP430 + totalP435 + totalP440 + totalP445 + totalP450; totalP899 = totalP805 + totalP810 + totalP815 + totalP820 + totalP830 + totalP835 + totalP840;
            totalP999 = totalP899 + totalP399;
            lblP199.Text = simboloMoneda + totalP199.ToString(); lblP399.Text = simboloMoneda + totalP399.ToString(); lblP499.Text = simboloMoneda + totalP499.ToString(); lblP899.Text = simboloMoneda + totalP899.ToString();
            lblP999.Text = simboloMoneda + totalP999.ToString(); lblP699.Text = simboloMoneda + totalP699.ToString();
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdFncr/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
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