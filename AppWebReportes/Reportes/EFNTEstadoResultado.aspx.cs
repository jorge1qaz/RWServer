using BusinessLayer;
using System;

namespace AppWebReportes.Reportes
{
    public partial class EFNTEstadoResultado : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" };
        string JsonDatasetN005 = "", JsonDatasetN010 = "", JsonDatasetN015 = "", JsonDatasetN103 = "", JsonDatasetN105 = "", JsonDatasetN110 = "", JsonDatasetN205 = "", JsonDatasetN210 = "", JsonDatasetN215 = "", JsonDatasetN220 = "",
                JsonDatasetN225 = "", JsonDatasetN230 = "", JsonDatasetN235 = "", JsonDatasetN305 = "", JsonDatasetN310 = "", JsonDatasetN315 = "", JsonDatasetN405 = "", JsonDatasetN410 = "", JsonDatasetN415 = "", JsonDatasetN420 = "",
                JsonDatasetN425 = "", JsonDatasetN430 = "", JsonDatasetN505 = "", JsonDatasetN510 = "", JsonDatasetN515 = "", JsonDatasetN520 = "", JsonDatasetN525 = "", JsonDatasetN805 = "", JsonDatasetN810;
        decimal totalN005 = 0, totalN010 = 0, totalN015 = 0, totalN099 = 0, totalN103 = 0, totalN105 = 0, totalN110 = 0, totalN199 = 0, totalN205 = 0, totalN299 = 0, totalN210 = 0, totalN215 = 0, totalN220 = 0, totalN225 = 0, totalN230 = 0, totalN235 = 0, totalN305 = 0, totalN310 = 0,
                totalN315 = 0, totalN405 = 0, totalN410 = 0, totalN415 = 0, totalN420 = 0, totalN425 = 0, totalN430 = 0, totalN505 = 0, totalN510 = 0, totalN515 = 0, totalN520 = 0, totalN525 = 0, totalN805 = 0, totalN810 = 0, totalN399 = 0, totalN499 = 0, totalN599 = 0, totalN999 = 0;
        string simboloMoneda = "", JsonDatasetF005 = "", JsonDatasetF105 = "", JsonDatasetF206 = "", JsonDatasetF211 = "", JsonDatasetF212 = "", JsonDatasetF213 = "", JsonDatasetF214 = "",
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
        //Jorge Luis|26/12/2017|RW-103
        /*Método para */
        public void GetReport(bool moneda, int mesProceso)
        {
            lblMesProceso.Text = meses[mesProceso];
            //Naturaleza
            JsonDatasetN005 = GetPathFile("N005"); JsonDatasetN010 = GetPathFile("N010"); JsonDatasetN015 = GetPathFile("N015"); JsonDatasetN103 = GetPathFile("N103"); JsonDatasetN105 = GetPathFile("N105"); JsonDatasetN110 = GetPathFile("N110");
            JsonDatasetN205 = GetPathFile("N205"); JsonDatasetN210 = GetPathFile("N210"); JsonDatasetN215 = GetPathFile("N215"); JsonDatasetN220 = GetPathFile("N220"); JsonDatasetN225 = GetPathFile("N225"); JsonDatasetN230 = GetPathFile("N230");
            JsonDatasetN235 = GetPathFile("N235"); JsonDatasetN305 = GetPathFile("N305"); JsonDatasetN310 = GetPathFile("N310"); JsonDatasetN315 = GetPathFile("N315"); JsonDatasetN405 = GetPathFile("N405"); JsonDatasetN410 = GetPathFile("N410");
            JsonDatasetN415 = GetPathFile("N415"); JsonDatasetN420 = GetPathFile("N420"); JsonDatasetN425 = GetPathFile("N425"); JsonDatasetN430 = GetPathFile("N430"); JsonDatasetN505 = GetPathFile("N505"); JsonDatasetN510 = GetPathFile("N510");
            JsonDatasetN515 = GetPathFile("N515"); JsonDatasetN520 = GetPathFile("N520"); JsonDatasetN525 = GetPathFile("N525"); JsonDatasetN805 = GetPathFile("N805"); JsonDatasetN810 = GetPathFile("N810");

            totalN005 = mergeTables.GeTotalByTablePlan(JsonDatasetN005, moneda, mesProceso, false); totalN010 = mergeTables.GeTotalByTablePlan(JsonDatasetN010, moneda, mesProceso, false); totalN015 = mergeTables.GeTotalByTablePlan(JsonDatasetN015, moneda, mesProceso, false);
            totalN099 = totalN005 + totalN010 + totalN015;

            totalN103 = mergeTables.GeTotalByTablePlan(JsonDatasetN103, moneda, mesProceso, false); totalN105 = mergeTables.GeTotalByTablePlan(JsonDatasetN105, moneda, mesProceso, false); totalN110 = mergeTables.GeTotalByTablePlan(JsonDatasetN110, moneda, mesProceso, false);
            totalN199 = totalN103 + totalN105 + totalN110 + totalN099;

            totalN205 = mergeTables.GeTotalByTablePlan(JsonDatasetN205, moneda, mesProceso, false); totalN210 = mergeTables.GeTotalByTablePlan(JsonDatasetN210, moneda, mesProceso, false); totalN215 = mergeTables.GeTotalByTablePlan(JsonDatasetN215, moneda, mesProceso, false);
            totalN220 = mergeTables.GeTotalByTablePlan(JsonDatasetN220, moneda, mesProceso, false); totalN225 = mergeTables.GeTotalByTablePlan(JsonDatasetN225, moneda, mesProceso, false); totalN230 = mergeTables.GeTotalByTablePlan(JsonDatasetN230, moneda, mesProceso, false);
            totalN235 = mergeTables.GeTotalByTablePlan(JsonDatasetN235, moneda, mesProceso, false); totalN299 = totalN205 + totalN210 + totalN215 + totalN220 + totalN225 + totalN230 + totalN235 + totalN199;

            totalN305 = mergeTables.GeTotalByTablePlan(JsonDatasetN305, moneda, mesProceso, false); totalN310 = mergeTables.GeTotalByTablePlan(JsonDatasetN310, moneda, mesProceso, false); totalN315 = mergeTables.GeTotalByTablePlan(JsonDatasetN315, moneda, mesProceso, false);
            totalN399 = totalN305 + totalN310 + totalN315 + totalN299;

            totalN405 = mergeTables.GeTotalByTablePlan(JsonDatasetN405, moneda, mesProceso, false); totalN410 = mergeTables.GeTotalByTablePlan(JsonDatasetN410, moneda, mesProceso, false); totalN415 = mergeTables.GeTotalByTablePlan(JsonDatasetN415, moneda, mesProceso, false);
            totalN420 = mergeTables.GeTotalByTablePlan(JsonDatasetN420, moneda, mesProceso, false); totalN425 = mergeTables.GeTotalByTablePlan(JsonDatasetN425, moneda, mesProceso, false); totalN430 = mergeTables.GeTotalByTablePlan(JsonDatasetN430, moneda, mesProceso, false);
            totalN499 = totalN405 + totalN410 + totalN415 + totalN420 + totalN425 + totalN430 + totalN399;

            totalN505 = mergeTables.GeTotalByTablePlan(JsonDatasetN505, moneda, mesProceso, false); totalN510 = mergeTables.GeTotalByTablePlan(JsonDatasetN510, moneda, mesProceso, false); totalN515 = mergeTables.GeTotalByTablePlan(JsonDatasetN515, moneda, mesProceso, false);
            totalN520 = mergeTables.GeTotalByTablePlan(JsonDatasetN520, moneda, mesProceso, false); totalN525 = mergeTables.GeTotalByTablePlan(JsonDatasetN525, moneda, mesProceso, false); totalN599 = totalN505 + totalN510 + totalN515 + totalN520 + totalN525 + totalN499;

            totalN805 = mergeTables.GeTotalByTablePlan(JsonDatasetN805, moneda, mesProceso, false); totalN810 = mergeTables.GeTotalByTablePlan(JsonDatasetN810, moneda, mesProceso, false); totalN999 = totalN805 + totalN810 + totalN599;

            if (moneda)
            { simboloMoneda = "S/ "; lblTipoMoneda.Text = "Nuevos soles"; }
            else
            { simboloMoneda = "$ "; lblTipoMoneda.Text = "Dólares"; }
            lblN005.Text = simboloMoneda + totalN005.ToString(); lblN010.Text = simboloMoneda + totalN010.ToString(); lblN015.Text = simboloMoneda + totalN015.ToString(); lblN099.Text = simboloMoneda + totalN099.ToString(); lblN103.Text = simboloMoneda + totalN103.ToString();
            lblN105.Text = simboloMoneda + totalN105.ToString(); lblN110.Text = simboloMoneda + totalN110.ToString(); lblN199.Text = simboloMoneda + totalN199.ToString(); lblN205.Text = simboloMoneda + totalN205.ToString(); lblN210.Text = simboloMoneda + totalN210.ToString();
            lblN215.Text = simboloMoneda + totalN215.ToString(); lblN220.Text = simboloMoneda + totalN220.ToString(); lblN225.Text = simboloMoneda + totalN225.ToString(); lblN230.Text = simboloMoneda + totalN230.ToString(); lblN235.Text = simboloMoneda + totalN235.ToString();
            lblN299.Text = simboloMoneda + totalN299.ToString(); lblN305.Text = simboloMoneda + totalN305.ToString(); lblN310.Text = simboloMoneda + totalN310.ToString(); lblN315.Text = simboloMoneda + totalN315.ToString(); lblN399.Text = simboloMoneda + totalN399.ToString();
            lblN405.Text = simboloMoneda + totalN405.ToString(); lblN410.Text = simboloMoneda + totalN410.ToString(); lblN415.Text = simboloMoneda + totalN415.ToString(); lblN420.Text = simboloMoneda + totalN420.ToString(); lblN425.Text = simboloMoneda + totalN425.ToString();
            lblN430.Text = simboloMoneda + totalN430.ToString(); lblN499.Text = simboloMoneda + totalN499.ToString(); lblN505.Text = simboloMoneda + totalN505.ToString(); lblN510.Text = simboloMoneda + totalN510.ToString(); lblN515.Text = simboloMoneda + totalN515.ToString();
            lblN520.Text = simboloMoneda + totalN520.ToString(); lblN525.Text = simboloMoneda + totalN525.ToString(); lblN599.Text = simboloMoneda + totalN599.ToString(); lblN805.Text = simboloMoneda + totalN805.ToString(); lblN810.Text = simboloMoneda + totalN810.ToString();
            lblN999.Text = simboloMoneda + totalN999.ToString();

            //Función
            JsonDatasetF005 = GetPathFile("F005"); JsonDatasetF105 = GetPathFile("F105"); JsonDatasetF206 = GetPathFile("F206"); JsonDatasetF211 = GetPathFile("F211"); JsonDatasetF212 = GetPathFile("F212"); JsonDatasetF213 = GetPathFile("F213");
            JsonDatasetF214 = GetPathFile("F214"); JsonDatasetF215 = GetPathFile("F215"); JsonDatasetF320 = GetPathFile("F320"); JsonDatasetF350 = GetPathFile("F350"); JsonDatasetF380 = GetPathFile("F380"); JsonDatasetF403 = GetPathFile("F403");
            JsonDatasetF405 = GetPathFile("F405"); JsonDatasetF415 = GetPathFile("F415"); JsonDatasetF710 = GetPathFile("F710"); JsonDatasetF805 = GetPathFile("F805");

            totalF005 = mergeTables.GeTotalByTablePlan(JsonDatasetF005, moneda, mesProceso, false); totalF105 = mergeTables.GeTotalByTablePlan(JsonDatasetF105, moneda, mesProceso, false); totalF199 = totalF005 + totalF105;

            totalF206 = mergeTables.GeTotalByTablePlan(JsonDatasetF206, moneda, mesProceso, false); totalF211 = mergeTables.GeTotalByTablePlan(JsonDatasetF211, moneda, mesProceso, false); totalF212 = mergeTables.GeTotalByTablePlan(JsonDatasetF212, moneda, mesProceso, false);
            totalF213 = mergeTables.GeTotalByTablePlan(JsonDatasetF213, moneda, mesProceso, false); totalF214 = mergeTables.GeTotalByTablePlan(JsonDatasetF214, moneda, mesProceso, false); totalF215 = mergeTables.GeTotalByTablePlan(JsonDatasetF215, moneda, mesProceso, false);
            totalF299 = totalF206 + totalF211 + totalF212 + totalF213 + totalF214 + totalF215 + totalF199;

            totalF320 = mergeTables.GeTotalByTablePlan(JsonDatasetF320, moneda, mesProceso, false); totalF350 = mergeTables.GeTotalByTablePlan(JsonDatasetF350, moneda, mesProceso, false); totalF380 = mergeTables.GeTotalByTablePlan(JsonDatasetF380, moneda, mesProceso, false);
            totalF403 = mergeTables.GeTotalByTablePlan(JsonDatasetF403, moneda, mesProceso, false); totalF405 = mergeTables.GeTotalByTablePlan(JsonDatasetF405, moneda, mesProceso, false); totalF415 = mergeTables.GeTotalByTablePlan(JsonDatasetF415, moneda, mesProceso, false);
            totalF699 = totalF320 + totalF350 + totalF380 + totalF403 + totalF405 + totalF415 + totalF299;

            totalF710 = mergeTables.GeTotalByTablePlan(JsonDatasetF710, moneda, mesProceso, false); totalF799 = totalF710 + totalF699;
            totalF805 = mergeTables.GeTotalByTablePlan(JsonDatasetF805, moneda, mesProceso, false); totalF999 = totalF805 + totalF799;

            lblF199.Text = simboloMoneda + totalF199.ToString(); lblF005.Text = simboloMoneda + totalF005.ToString(); lblF105.Text = simboloMoneda + totalF105.ToString(); lblF299.Text = simboloMoneda + totalF299.ToString(); lblF206.Text = simboloMoneda + totalF206.ToString();
            lblF211.Text = simboloMoneda + totalF211.ToString(); lblF212.Text = simboloMoneda + totalF212.ToString(); lblF213.Text = simboloMoneda + totalF213.ToString(); lblF214.Text = simboloMoneda + totalF214.ToString(); lblF215.Text = simboloMoneda + totalF215.ToString();
            lblF699.Text = simboloMoneda + totalF699.ToString(); lblF320.Text = simboloMoneda + totalF320.ToString(); lblF350.Text = simboloMoneda + totalF350.ToString(); lblF380.Text = simboloMoneda + totalF380.ToString(); lblF403.Text = simboloMoneda + totalF403.ToString();
            lblF405.Text = simboloMoneda + totalF405.ToString(); lblF415.Text = simboloMoneda + totalF415.ToString(); lblF799.Text = simboloMoneda + totalF799.ToString(); lblF710.Text = simboloMoneda + totalF710.ToString(); lblF999.Text = simboloMoneda + totalF999.ToString();
            lblF805.Text = simboloMoneda + totalF805.ToString();
        }
        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
                GetReport(true, int.Parse(lstMes.SelectedValue));
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
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdPmS/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}