using BusinessLayer;
using System;

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
                JsonDatasetP531 = "", JsonDatasetP541 = "";
        decimal totalP105 = 0, totalP110 = 0, totalP115 = 0, totalP120 = 0, totalP121 = 0, totalP122 = 0, totalP128 = 0, totalP129 = 0, totalP133 = 0, totalP135 = 0, totalP141 = 0, totalP199 = 0, totalP505 = 0,
                totalP507 = 0, totalP510 = 0, totalP511 = 0, totalP515 = 0, totalP520 = 0, totalP530 = 0, totalP531 = 0, totalP541 = 0, totalP599 = 0, totalP999 = 0;
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
            if (moneda)
            { simboloMoneda = "S/ "; lblTipoMoneda.Text = "Nuevos soles"; }
            else
            { simboloMoneda = "$ "; lblTipoMoneda.Text = "Dólares"; }
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

            totalA105 = mergeTables.GeTotalByTablePlan(JsonDatasetA105, moneda, mesProceso, true); totalA106 = mergeTables.GeTotalByTablePlan(JsonDatasetA106, moneda, mesProceso, true); totalA110 = mergeTables.GeTotalByTablePlan(JsonDatasetA110, moneda, mesProceso, true);
            totalA111 = mergeTables.GeTotalByTablePlan(JsonDatasetA111, moneda, mesProceso, true); totalA115 = mergeTables.GeTotalByTablePlan(JsonDatasetA115, moneda, mesProceso, true); totalA120 = mergeTables.GeTotalByTablePlan(JsonDatasetA120, moneda, mesProceso, true);
            totalA121 = mergeTables.GeTotalByTablePlan(JsonDatasetA121, moneda, mesProceso, true); totalA122 = mergeTables.GeTotalByTablePlan(JsonDatasetA122, moneda, mesProceso, true); totalA123 = mergeTables.GeTotalByTablePlan(JsonDatasetA123, moneda, mesProceso, true);
            totalA124 = mergeTables.GeTotalByTablePlan(JsonDatasetA124, moneda, mesProceso, true); totalA125 = mergeTables.GeTotalByTablePlan(JsonDatasetA125, moneda, mesProceso, true); totalA130 = mergeTables.GeTotalByTablePlan(JsonDatasetA130, moneda, mesProceso, true);
            totalA135 = mergeTables.GeTotalByTablePlan(JsonDatasetA135, moneda, mesProceso, true); totalA140 = mergeTables.GeTotalByTablePlan(JsonDatasetA140, moneda, mesProceso, true); totalA142 = mergeTables.GeTotalByTablePlan(JsonDatasetA142, moneda, mesProceso, true);
            totalA145 = mergeTables.GeTotalByTablePlan(JsonDatasetA145, moneda, mesProceso, true); totalA151 = mergeTables.GeTotalByTablePlan(JsonDatasetA151, moneda, mesProceso, true); totalA152 = mergeTables.GeTotalByTablePlan(JsonDatasetA152, moneda, mesProceso, true);
            totalA153 = mergeTables.GeTotalByTablePlan(JsonDatasetA153, moneda, mesProceso, true); totalA155 = mergeTables.GeTotalByTablePlan(JsonDatasetA155, moneda, mesProceso, true); totalA157 = mergeTables.GeTotalByTablePlan(JsonDatasetA157, moneda, mesProceso, true);
            totalA158 = mergeTables.GeTotalByTablePlan(JsonDatasetA158, moneda, mesProceso, true); totalA159 = mergeTables.GeTotalByTablePlan(JsonDatasetA159, moneda, mesProceso, true); totalA160 = mergeTables.GeTotalByTablePlan(JsonDatasetA160, moneda, mesProceso, true);
            totalA164 = mergeTables.GeTotalByTablePlan(JsonDatasetA164, moneda, mesProceso, true); totalA176 = mergeTables.GeTotalByTablePlan(JsonDatasetA176, moneda, mesProceso, true); totalA177 = mergeTables.GeTotalByTablePlan(JsonDatasetA177, moneda, mesProceso, true);
            totalA178 = mergeTables.GeTotalByTablePlan(JsonDatasetA178, moneda, mesProceso, true); totalA179 = mergeTables.GeTotalByTablePlan(JsonDatasetA179, moneda, mesProceso, true); totalA180 = mergeTables.GeTotalByTablePlan(JsonDatasetA180, moneda, mesProceso, true);
            totalA185 = mergeTables.GeTotalByTablePlan(JsonDatasetA185, moneda, mesProceso, true); totalA999 = totalA105 + totalA106 + totalA110 + totalA111 + totalA115 + totalA120 + totalA121 + totalA122 + totalA123 + totalA124 + totalA125 + totalA130 + totalA135 + totalA140 +
            totalA142 + totalA145 + totalA151 + totalA152 + totalA153 + totalA155 + totalA157 + totalA158 + totalA159 + totalA160 + totalA164 + totalA176 + totalA177 + totalA178 + totalA179 + totalA180 + totalA185;

            lblA105.Text = simboloMoneda + totalA105.ToString(); lblA106.Text = simboloMoneda + totalA106.ToString(); lblA110.Text = simboloMoneda + totalA110.ToString(); lblA111.Text = simboloMoneda + totalA111.ToString(); lblA115.Text = simboloMoneda + totalA115.ToString();
            lblA120.Text = simboloMoneda + totalA120.ToString(); lblA121.Text = simboloMoneda + totalA121.ToString(); lblA122.Text = simboloMoneda + totalA122.ToString(); lblA123.Text = simboloMoneda + totalA123.ToString(); lblA124.Text = simboloMoneda + totalA124.ToString();
            lblA125.Text = simboloMoneda + totalA125.ToString(); lblA130.Text = simboloMoneda + totalA130.ToString(); lblA135.Text = simboloMoneda + totalA135.ToString(); lblA140.Text = simboloMoneda + totalA140.ToString(); lblA142.Text = simboloMoneda + totalA142.ToString();
            lblA145.Text = simboloMoneda + totalA145.ToString(); lblA151.Text = simboloMoneda + totalA151.ToString(); lblA152.Text = simboloMoneda + totalA152.ToString(); lblA153.Text = simboloMoneda + totalA153.ToString(); lblA155.Text = simboloMoneda + totalA155.ToString();
            lblA157.Text = simboloMoneda + totalA157.ToString(); lblA158.Text = simboloMoneda + totalA158.ToString(); lblA159.Text = simboloMoneda + totalA159.ToString(); lblA160.Text = simboloMoneda + totalA160.ToString(); lblA164.Text = simboloMoneda + totalA164.ToString();
            lblA176.Text = simboloMoneda + totalA176.ToString(); lblA177.Text = simboloMoneda + totalA177.ToString(); lblA178.Text = simboloMoneda + totalA178.ToString(); lblA179.Text = simboloMoneda + totalA179.ToString(); lblA180.Text = simboloMoneda + totalA180.ToString();
            lblA185.Text = simboloMoneda + totalA185.ToString(); lblA999.Text = simboloMoneda + totalA999.ToString(); //Valor del total

            JsonDatasetP105 = GetPathFile("P105"); JsonDatasetP110 = GetPathFile("P110"); JsonDatasetP115 = GetPathFile("P115"); JsonDatasetP120 = GetPathFile("P120"); JsonDatasetP121 = GetPathFile("P121"); JsonDatasetP122 = GetPathFile("P122"); JsonDatasetP128 = GetPathFile("P128");
            JsonDatasetP129 = GetPathFile("P129"); JsonDatasetP133 = GetPathFile("P133"); JsonDatasetP135 = GetPathFile("P135"); JsonDatasetP141 = GetPathFile("P141"); JsonDatasetP505 = GetPathFile("P505"); JsonDatasetP507 = GetPathFile("P507"); JsonDatasetP510 = GetPathFile("P510");
            JsonDatasetP511 = GetPathFile("P511"); JsonDatasetP515 = GetPathFile("P515"); JsonDatasetP520 = GetPathFile("P520"); JsonDatasetP530 = GetPathFile("P530"); JsonDatasetP531 = GetPathFile("P531"); JsonDatasetP541 = GetPathFile("P541");

            totalP105 = mergeTables.GeTotalByTablePlan(JsonDatasetP105, moneda, mesProceso, true); totalP110 = mergeTables.GeTotalByTablePlan(JsonDatasetP110, moneda, mesProceso, true); totalP115 = mergeTables.GeTotalByTablePlan(JsonDatasetP115, moneda, mesProceso, true);
            totalP120 = mergeTables.GeTotalByTablePlan(JsonDatasetP120, moneda, mesProceso, true); totalP121 = mergeTables.GeTotalByTablePlan(JsonDatasetP121, moneda, mesProceso, true); totalP122 = mergeTables.GeTotalByTablePlan(JsonDatasetP122, moneda, mesProceso, true);
            totalP128 = mergeTables.GeTotalByTablePlan(JsonDatasetP128, moneda, mesProceso, true); totalP129 = mergeTables.GeTotalByTablePlan(JsonDatasetP129, moneda, mesProceso, true); totalP133 = mergeTables.GeTotalByTablePlan(JsonDatasetP133, moneda, mesProceso, true);
            totalP135 = mergeTables.GeTotalByTablePlan(JsonDatasetP135, moneda, mesProceso, true); totalP141 = mergeTables.GeTotalByTablePlan(JsonDatasetP141, moneda, mesProceso, true); totalP505 = mergeTables.GeTotalByTablePlan(JsonDatasetP505, moneda, mesProceso, true);
            totalP507 = mergeTables.GeTotalByTablePlan(JsonDatasetP507, moneda, mesProceso, true); totalP510 = mergeTables.GeTotalByTablePlan(JsonDatasetP510, moneda, mesProceso, true); totalP511 = mergeTables.GeTotalByTablePlan(JsonDatasetP511, moneda, mesProceso, true);
            totalP515 = mergeTables.GeTotalByTablePlan(JsonDatasetP515, moneda, mesProceso, true); totalP520 = mergeTables.GeTotalByTablePlan(JsonDatasetP520, moneda, mesProceso, true); totalP530 = mergeTables.GeTotalByTablePlan(JsonDatasetP530, moneda, mesProceso, true);
            totalP531 = mergeTables.GeTotalByTablePlan(JsonDatasetP531, moneda, mesProceso, true); totalP541 = mergeTables.GeTotalByTablePlan(JsonDatasetP541, moneda, mesProceso, true); totalP199 = totalP105 + totalP110 + totalP115 + totalP120 + totalP121 + totalP122 + totalP128 +
            totalP129 + totalP133 + totalP135 + totalP141; totalP599 = totalP505 + totalP507 + totalP510 + totalP511 + totalP515 + totalP520 + totalP530 + totalP531 + RtotalF999 + totalP541; totalP999 = totalP199 + totalP599;

            lblP105.Text = simboloMoneda + totalP105.ToString(); lblP110.Text = simboloMoneda + totalP110.ToString(); lblP115.Text = simboloMoneda + totalP115.ToString(); lblP120.Text = simboloMoneda + totalP120.ToString(); lblP121.Text = simboloMoneda + totalP121.ToString();
            lblP122.Text = simboloMoneda + totalP122.ToString(); lblP128.Text = simboloMoneda + totalP128.ToString(); lblP129.Text = simboloMoneda + totalP129.ToString(); lblP133.Text = simboloMoneda + totalP133.ToString(); lblP135.Text = simboloMoneda + totalP135.ToString();
            lblP141.Text = simboloMoneda + totalP141.ToString(); lblP505.Text = simboloMoneda + totalP505.ToString(); lblP507.Text = simboloMoneda + totalP507.ToString(); lblP510.Text = simboloMoneda + totalP510.ToString(); lblP511.Text = simboloMoneda + totalP511.ToString();
            lblP515.Text = simboloMoneda + totalP515.ToString(); lblP520.Text = simboloMoneda + totalP520.ToString(); lblP530.Text = simboloMoneda + totalP530.ToString(); lblP531.Text = simboloMoneda + totalP531.ToString(); lblP541.Text = simboloMoneda + totalP541.ToString();
            lblP199.Text = simboloMoneda + totalP199.ToString(); lblPResultado.Text = simboloMoneda + RtotalF999.ToString(); lblP599.Text = simboloMoneda + totalP599.ToString(); lblP999.Text = simboloMoneda + totalP999.ToString();
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