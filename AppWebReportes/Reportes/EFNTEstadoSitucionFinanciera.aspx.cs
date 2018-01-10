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
        int mesProceso = 0;
        string JsonDatasetA105 = "", JsonDatasetA110 = "", JsonDatasetA115 = "", JsonDatasetA120 = "", JsonDatasetA125 = "", JsonDatasetA128 = "", JsonDatasetA130 = "", JsonDatasetA131 = "", JsonDatasetA133 = "",
                JsonDatasetA140 = "", JsonDatasetA210 = "", JsonDatasetA220 = "", JsonDatasetA510 = "", JsonDatasetA513 = "", JsonDatasetA515 = "", JsonDatasetA517 = "", JsonDatasetA520 = "", JsonDatasetA525 = "",
                JsonDatasetA530 = "", JsonDatasetA540 = "", JsonDatasetA550 = "", JsonDatasetA560 = "", JsonDatasetA570 = "", JsonDatasetA575 = "", JsonDatasetA580 = "";
        decimal totalA105, totalA110, totalA115, totalA120, totalA125, totalA128, totalA130, totalA131, totalA133, totalA140, totalA210, totalA220, totalA510, totalA513,
                totalA515, totalA517, totalA520, totalA525, totalA530, totalA540, totalA550, totalA560, totalA570, totalA575, totalA580;
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null || Request.QueryString["idCompany"] == null || Request.QueryString["year"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
            lblTipoReporte.Text = Session["TipoReporteEFNT"].ToString();
            lblTipoMoneda.Text = Session["TipoMonedaEFNT"].ToString();
            if (Session["EDRPMSTipoMoneda"].ToString() == "Nuevos soles")
                GetReport(true);
            else
                GetReport(false);
            if (Page.IsPostBack)
            {
                lblTipoReporte.Text = Session["TipoReporteEFNT"].ToString();
                lblTipoMoneda.Text = Session["TipoMonedaEFNT"].ToString();
                if (Session["EDRPMSTipoMoneda"].ToString() == "Nuevos soles")
                    GetReport(true);
                else
                    GetReport(false);
            }
            Response.Write("TipoMonedaEFNT: " + Session["TipoMonedaEFNT"].ToString() + " ");
        }
        protected void lstTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("EDRPMSTipoMoneda");
            if (bool.Parse(lstTipoMoneda.SelectedValue) == true)
                Session["EDRPMSTipoMoneda"] = "Nuevos soles";
            else
                Session["EDRPMSTipoMoneda"] = "Dólares";
            Response.Write("TipoMonedaEFNT select:  " + Session["EDRPMSTipoMoneda"].ToString());
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para */
        public void GetReport(bool moneda)
        {
            mesProceso = int.Parse(lstMes.SelectedValue) - 1;
            JsonDatasetA105 = GetPathFile("A105"); JsonDatasetA110 = GetPathFile("A110"); JsonDatasetA115 = GetPathFile("A115"); JsonDatasetA120 = GetPathFile("A120"); JsonDatasetA125 = GetPathFile("A125"); JsonDatasetA128 = GetPathFile("A128");
            JsonDatasetA130 = GetPathFile("A130"); JsonDatasetA131 = GetPathFile("A131"); JsonDatasetA133 = GetPathFile("A133"); JsonDatasetA140 = GetPathFile("A140"); JsonDatasetA210 = GetPathFile("A210"); JsonDatasetA220 = GetPathFile("A220");
            JsonDatasetA510 = GetPathFile("A510"); JsonDatasetA513 = GetPathFile("A513"); JsonDatasetA515 = GetPathFile("A515"); JsonDatasetA517 = GetPathFile("A517"); JsonDatasetA520 = GetPathFile("A520"); JsonDatasetA525 = GetPathFile("A525");
            JsonDatasetA530 = GetPathFile("A530"); JsonDatasetA540 = GetPathFile("A540"); JsonDatasetA550 = GetPathFile("A550"); JsonDatasetA560 = GetPathFile("A560"); JsonDatasetA570 = GetPathFile("A570"); JsonDatasetA575 = GetPathFile("A575");
            JsonDatasetA580 = GetPathFile("A580");

            totalA105 = mergeTables.GeTotalByTablePlan(JsonDatasetA105, moneda, mesProceso); totalA110 = mergeTables.GeTotalByTablePlan(JsonDatasetA110, moneda, mesProceso); totalA115 = mergeTables.GeTotalByTablePlan(JsonDatasetA115, moneda, mesProceso);
            totalA120 = mergeTables.GeTotalByTablePlan(JsonDatasetA120, moneda, mesProceso); totalA125 = mergeTables.GeTotalByTablePlan(JsonDatasetA125, moneda, mesProceso); totalA128 = mergeTables.GeTotalByTablePlan(JsonDatasetA128, moneda, mesProceso);
            totalA130 = mergeTables.GeTotalByTablePlan(JsonDatasetA130, moneda, mesProceso); totalA131 = mergeTables.GeTotalByTablePlan(JsonDatasetA131, moneda, mesProceso); totalA133 = mergeTables.GeTotalByTablePlan(JsonDatasetA133, moneda, mesProceso);
            totalA140 = mergeTables.GeTotalByTablePlan(JsonDatasetA140, moneda, mesProceso); totalA210 = mergeTables.GeTotalByTablePlan(JsonDatasetA210, moneda, mesProceso); totalA220 = mergeTables.GeTotalByTablePlan(JsonDatasetA220, moneda, mesProceso);
            totalA510 = mergeTables.GeTotalByTablePlan(JsonDatasetA510, moneda, mesProceso); totalA513 = mergeTables.GeTotalByTablePlan(JsonDatasetA513, moneda, mesProceso); totalA515 = mergeTables.GeTotalByTablePlan(JsonDatasetA515, moneda, mesProceso);
            totalA517 = mergeTables.GeTotalByTablePlan(JsonDatasetA517, moneda, mesProceso); totalA520 = mergeTables.GeTotalByTablePlan(JsonDatasetA520, moneda, mesProceso); totalA525 = mergeTables.GeTotalByTablePlan(JsonDatasetA525, moneda, mesProceso);
            totalA530 = mergeTables.GeTotalByTablePlan(JsonDatasetA530, moneda, mesProceso); totalA540 = mergeTables.GeTotalByTablePlan(JsonDatasetA540, moneda, mesProceso); totalA550 = mergeTables.GeTotalByTablePlan(JsonDatasetA550, moneda, mesProceso);
            totalA560 = mergeTables.GeTotalByTablePlan(JsonDatasetA560, moneda, mesProceso); totalA570 = mergeTables.GeTotalByTablePlan(JsonDatasetA570, moneda, mesProceso); totalA575 = mergeTables.GeTotalByTablePlan(JsonDatasetA575, moneda, mesProceso);
            totalA580 = mergeTables.GeTotalByTablePlan(JsonDatasetA580, moneda, mesProceso);

            if (moneda)
                simboloMoneda = "S/ ";
            else
                simboloMoneda = "$ ";

            lblA105.Text = simboloMoneda + totalA105.ToString(); lblA110.Text = simboloMoneda + totalA110.ToString(); lblA115.Text = simboloMoneda + totalA115.ToString(); lblA120.Text = simboloMoneda + totalA120.ToString();
            lblA125.Text = simboloMoneda + totalA125.ToString(); lblA128.Text = simboloMoneda + totalA128.ToString(); lblA580.Text = simboloMoneda + totalA580.ToString(); lblA130.Text = simboloMoneda + totalA130.ToString();
            lblA131.Text = simboloMoneda + totalA131.ToString(); lblA133.Text = simboloMoneda + totalA133.ToString(); lblA140.Text = simboloMoneda + totalA140.ToString(); lblA210.Text = simboloMoneda + totalA210.ToString();
            lblA220.Text = simboloMoneda + totalA220.ToString(); lblA510.Text = simboloMoneda + totalA510.ToString(); lblA513.Text = simboloMoneda + totalA513.ToString(); lblA515.Text = simboloMoneda + totalA515.ToString();
            lblA517.Text = simboloMoneda + totalA517.ToString(); lblA520.Text = simboloMoneda + totalA520.ToString(); lblA525.Text = simboloMoneda + totalA525.ToString(); lblA530.Text = simboloMoneda + totalA530.ToString();
            lblA540.Text = simboloMoneda + totalA540.ToString(); lblA550.Text = simboloMoneda + totalA550.ToString(); lblA560.Text = simboloMoneda + totalA560.ToString(); lblA570.Text = simboloMoneda + totalA570.ToString();
            lblA575.Text = simboloMoneda + totalA575.ToString();
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para obtener una dataset json con una ruta absoluta obtenida mediante una petición al mismo servidor, leerlo y retornarlo como un dataset asp*/
        public string GetPathFile(string nameFile)
        {
            String rootPath = Server.MapPath("~");
            string JsonDataset = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/rptStdFncr/" + Request.QueryString["idCompany"].ToString() + "/" + Request.QueryString["year"].ToString() + "/" + nameFile + ".json").Trim().Replace("\\'", "'");
            return JsonDataset;
        }
    }
}