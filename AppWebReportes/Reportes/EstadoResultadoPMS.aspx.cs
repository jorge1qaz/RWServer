using BusinessLayer;
using System;

namespace AppWebReportes.Reportes
{
    public partial class EstadoResultadoPMS : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string JsonDatasetN005 = "", JsonDatasetN010 = "", JsonDatasetN015 = "", JsonDatasetN103 = "", JsonDatasetN105 = "", JsonDatasetN110 = "", JsonDatasetN205 = "", JsonDatasetN210 = "", JsonDatasetN215 = "", JsonDatasetN220 = "",
               JsonDatasetN225 = "", JsonDatasetN230 = "", JsonDatasetN235 = "", JsonDatasetN305 = "", JsonDatasetN310 = "", JsonDatasetN315 = "", JsonDatasetN405 = "", JsonDatasetN410 = "", JsonDatasetN415 = "", JsonDatasetN420 = "",
               JsonDatasetN425 = "", JsonDatasetN430 = "", JsonDatasetN505 = "", JsonDatasetN510 = "", JsonDatasetN515 = "", JsonDatasetN520 = "", JsonDatasetN525 = "", JsonDatasetN805 = "", JsonDatasetN810 = "";
        decimal[] totalN005 = new decimal[12], totalN010 = new decimal[12], totalN015 = new decimal[12], totalN099 = new decimal[12], totalN103 = new decimal[12], totalN105 = new decimal[12], totalN110 = new decimal[12], totalN199 = new decimal[12],
        totalN205 = new decimal[12], totalN299 = new decimal[12], totalN210 = new decimal[12], totalN215 = new decimal[12], totalN220 = new decimal[12], totalN225 = new decimal[12], totalN230 = new decimal[12], totalN235 = new decimal[12],
        totalN305 = new decimal[12], totalN310 = new decimal[12], totalN315 = new decimal[12], totalN405 = new decimal[12], totalN410 = new decimal[12], totalN415 = new decimal[12], totalN420 = new decimal[12], totalN425 = new decimal[12],
        totalN430 = new decimal[12], totalN505 = new decimal[12], totalN510 = new decimal[12], totalN515 = new decimal[12], totalN520 = new decimal[12], totalN525 = new decimal[12], totalN805 = new decimal[12], totalN810 = new decimal[12],
        totalN399 = new decimal[12], totalN499 = new decimal[12], totalN599 = new decimal[12], totalN999 = new decimal[12];
        string simboloMoneda = "S/ ";
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null || Request.QueryString["idCompany"] == null || Request.QueryString["year"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
            if (Session["EDRPMSTipoMoneda"].ToString() == "Nuevos soles")
                GetEstadoResultadoNaturaleza(true);
            else
                GetEstadoResultadoNaturaleza(false);
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para */
        public void GetEstadoResultadoNaturaleza(bool moneda)
        {
            if (!moneda)                    // Moneda: Dólares
            { simboloMoneda = "$ "; }
            JsonDatasetN005 = GetPathFile("N005"); JsonDatasetN010 = GetPathFile("N010"); JsonDatasetN015 = GetPathFile("N015"); JsonDatasetN103 = GetPathFile("N103"); JsonDatasetN105 = GetPathFile("N105"); JsonDatasetN110 = GetPathFile("N110"); JsonDatasetN205 = GetPathFile("N205"); JsonDatasetN210 = GetPathFile("N210"); JsonDatasetN215 = GetPathFile("N215"); JsonDatasetN220 = GetPathFile("N220");
            JsonDatasetN225 = GetPathFile("N225"); JsonDatasetN230 = GetPathFile("N230"); JsonDatasetN235 = GetPathFile("N235"); JsonDatasetN305 = GetPathFile("N305"); JsonDatasetN310 = GetPathFile("N310"); JsonDatasetN315 = GetPathFile("N315"); JsonDatasetN405 = GetPathFile("N405"); JsonDatasetN410 = GetPathFile("N410"); JsonDatasetN415 = GetPathFile("N415"); JsonDatasetN420 = GetPathFile("N420");
            JsonDatasetN425 = GetPathFile("N425"); JsonDatasetN430 = GetPathFile("N430"); JsonDatasetN505 = GetPathFile("N505"); JsonDatasetN510 = GetPathFile("N510"); JsonDatasetN515 = GetPathFile("N515"); JsonDatasetN520 = GetPathFile("N520"); JsonDatasetN525 = GetPathFile("N525"); JsonDatasetN805 = GetPathFile("N805"); JsonDatasetN810 = GetPathFile("N810");

            totalN005 = mergeTables.GeTotalByTablePlan(JsonDatasetN005, moneda);
            N005lbl0.Text = simboloMoneda + totalN005[0].ToString(); N005lbl1.Text = simboloMoneda + totalN005[1].ToString(); N005lbl2.Text = simboloMoneda + totalN005[2].ToString();
            N005lbl3.Text = simboloMoneda + totalN005[3].ToString(); N005lbl4.Text = simboloMoneda + totalN005[4].ToString(); N005lbl5.Text = simboloMoneda + totalN005[5].ToString();
            N005lbl6.Text = simboloMoneda + totalN005[6].ToString(); N005lbl7.Text = simboloMoneda + totalN005[7].ToString(); N005lbl8.Text = simboloMoneda + totalN005[8].ToString();
            N005lbl9.Text = simboloMoneda + totalN005[9].ToString(); N005lbl10.Text = simboloMoneda + totalN005[10].ToString(); N005lbl11.Text = simboloMoneda + totalN005[11].ToString();

            totalN010 = mergeTables.GeTotalByTablePlan(JsonDatasetN010, moneda);
            N010lbl0.Text = simboloMoneda + totalN010[0].ToString(); N010lbl1.Text = simboloMoneda + totalN010[1].ToString(); N010lbl2.Text = simboloMoneda + totalN010[2].ToString();
            N010lbl3.Text = simboloMoneda + totalN010[3].ToString(); N010lbl4.Text = simboloMoneda + totalN010[4].ToString(); N010lbl5.Text = simboloMoneda + totalN010[5].ToString();
            N010lbl6.Text = simboloMoneda + totalN010[6].ToString(); N010lbl7.Text = simboloMoneda + totalN010[7].ToString(); N010lbl8.Text = simboloMoneda + totalN010[8].ToString();
            N010lbl9.Text = simboloMoneda + totalN010[9].ToString(); N010lbl10.Text = simboloMoneda + totalN010[10].ToString(); N010lbl11.Text = simboloMoneda + totalN010[11].ToString();

            totalN015 = mergeTables.GeTotalByTablePlan(JsonDatasetN015, moneda);
            N015lbl0.Text = simboloMoneda + totalN015[0].ToString(); N015lbl1.Text = simboloMoneda + totalN015[1].ToString(); N015lbl2.Text = simboloMoneda + totalN015[2].ToString();
            N015lbl3.Text = simboloMoneda + totalN015[3].ToString(); N015lbl4.Text = simboloMoneda + totalN015[4].ToString(); N015lbl5.Text = simboloMoneda + totalN015[5].ToString();
            N015lbl6.Text = simboloMoneda + totalN015[6].ToString(); N015lbl7.Text = simboloMoneda + totalN015[7].ToString(); N015lbl8.Text = simboloMoneda + totalN015[8].ToString();
            N015lbl9.Text = simboloMoneda + totalN015[9].ToString(); N015lbl10.Text = simboloMoneda + totalN015[10].ToString(); N015lbl11.Text = simboloMoneda + totalN015[11].ToString();

            totalN099[0] = totalN005[0] + totalN010[0] + totalN015[0]; totalN099[1] = totalN005[1] + totalN010[1] + totalN015[1];
            totalN099[2] = totalN005[2] + totalN010[2] + totalN015[2]; totalN099[3] = totalN005[3] + totalN010[3] + totalN015[3];
            totalN099[4] = totalN005[4] + totalN010[4] + totalN015[4]; totalN099[5] = totalN005[5] + totalN010[5] + totalN015[5];
            totalN099[6] = totalN005[6] + totalN010[6] + totalN015[6]; totalN099[7] = totalN005[7] + totalN010[7] + totalN015[7];
            totalN099[8] = totalN005[8] + totalN010[8] + totalN015[8]; totalN099[9] = totalN005[9] + totalN010[9] + totalN015[9];
            totalN099[10] = totalN005[10] + totalN010[10] + totalN015[10]; totalN099[11] = totalN005[11] + totalN010[11] + totalN015[11];
            N099lbl0.Text = simboloMoneda + totalN099[0].ToString(); N099lbl1.Text = simboloMoneda + totalN099[1].ToString(); N099lbl2.Text = simboloMoneda + totalN099[2].ToString();
            N099lbl3.Text = simboloMoneda + totalN099[3].ToString(); N099lbl4.Text = simboloMoneda + totalN099[4].ToString(); N099lbl5.Text = simboloMoneda + totalN099[5].ToString();
            N099lbl6.Text = simboloMoneda + totalN099[6].ToString(); N099lbl7.Text = simboloMoneda + totalN099[7].ToString(); N099lbl8.Text = simboloMoneda + totalN099[8].ToString();
            N099lbl9.Text = simboloMoneda + totalN099[9].ToString(); N099lbl10.Text = simboloMoneda + totalN099[10].ToString(); N099lbl11.Text = simboloMoneda + totalN099[11].ToString();

            totalN103 = mergeTables.GeTotalByTablePlan(JsonDatasetN103, moneda);
            N103lbl0.Text = simboloMoneda + totalN103[0].ToString(); N103lbl1.Text = simboloMoneda + totalN103[1].ToString(); N103lbl2.Text = simboloMoneda + totalN103[2].ToString();
            N103lbl3.Text = simboloMoneda + totalN103[3].ToString(); N103lbl4.Text = simboloMoneda + totalN103[4].ToString(); N103lbl5.Text = simboloMoneda + totalN103[5].ToString();
            N103lbl6.Text = simboloMoneda + totalN103[6].ToString(); N103lbl7.Text = simboloMoneda + totalN103[7].ToString(); N103lbl8.Text = simboloMoneda + totalN103[8].ToString();
            N103lbl9.Text = simboloMoneda + totalN103[9].ToString(); N103lbl10.Text = simboloMoneda + totalN103[10].ToString(); N103lbl11.Text = simboloMoneda + totalN103[11].ToString();

            totalN105 = mergeTables.GeTotalByTablePlan(JsonDatasetN105, moneda);
            N105lbl0.Text = simboloMoneda + totalN105[0].ToString(); N105lbl1.Text = simboloMoneda + totalN105[1].ToString(); N105lbl2.Text = simboloMoneda + totalN105[2].ToString();
            N105lbl3.Text = simboloMoneda + totalN105[3].ToString(); N105lbl4.Text = simboloMoneda + totalN105[4].ToString(); N105lbl5.Text = simboloMoneda + totalN105[5].ToString();
            N105lbl6.Text = simboloMoneda + totalN105[6].ToString(); N105lbl7.Text = simboloMoneda + totalN105[7].ToString(); N105lbl8.Text = simboloMoneda + totalN105[8].ToString();
            N105lbl9.Text = simboloMoneda + totalN105[9].ToString(); N105lbl10.Text = simboloMoneda + totalN105[10].ToString(); N105lbl11.Text = simboloMoneda + totalN105[11].ToString();

            totalN110 = mergeTables.GeTotalByTablePlan(JsonDatasetN110, moneda);
            N110lbl0.Text = simboloMoneda + totalN110[0].ToString(); N110lbl1.Text = simboloMoneda + totalN110[1].ToString(); N110lbl2.Text = simboloMoneda + totalN110[2].ToString();
            N110lbl3.Text = simboloMoneda + totalN110[3].ToString(); N110lbl4.Text = simboloMoneda + totalN110[4].ToString(); N110lbl5.Text = simboloMoneda + totalN110[5].ToString();
            N110lbl6.Text = simboloMoneda + totalN110[6].ToString(); N110lbl7.Text = simboloMoneda + totalN110[7].ToString(); N110lbl8.Text = simboloMoneda + totalN110[8].ToString();
            N110lbl9.Text = simboloMoneda + totalN110[9].ToString(); N110lbl10.Text = simboloMoneda + totalN110[10].ToString(); N110lbl11.Text = simboloMoneda + totalN110[11].ToString();

            totalN199[0] = totalN103[0] + totalN105[0] + totalN110[0] + totalN099[0]; totalN199[1] = totalN103[1] + totalN105[1] + totalN110[1] + totalN099[1];
            totalN199[2] = totalN103[2] + totalN105[2] + totalN110[2] + totalN099[2]; totalN199[3] = totalN103[3] + totalN105[3] + totalN110[3] + totalN099[3];
            totalN199[4] = totalN103[4] + totalN105[4] + totalN110[4] + totalN099[4]; totalN199[5] = totalN103[5] + totalN105[5] + totalN110[5] + totalN099[5];
            totalN199[6] = totalN103[6] + totalN105[6] + totalN110[6] + totalN099[6]; totalN199[7] = totalN103[7] + totalN105[7] + totalN110[7] + totalN099[7];
            totalN199[8] = totalN103[8] + totalN105[8] + totalN110[8] + totalN099[8]; totalN199[9] = totalN103[9] + totalN105[9] + totalN110[9] + totalN099[9];
            totalN199[10] = totalN103[10] + totalN105[10] + totalN110[10] + totalN099[10]; totalN199[11] = totalN103[11] + totalN105[11] + totalN110[11] + totalN099[11];
            N199lbl0.Text = simboloMoneda + totalN199[0].ToString(); N199lbl1.Text = simboloMoneda + totalN199[1].ToString(); N199lbl2.Text = simboloMoneda + totalN199[2].ToString();
            N199lbl3.Text = simboloMoneda + totalN199[3].ToString(); N199lbl4.Text = simboloMoneda + totalN199[4].ToString(); N199lbl5.Text = simboloMoneda + totalN199[5].ToString();
            N199lbl6.Text = simboloMoneda + totalN199[6].ToString(); N199lbl7.Text = simboloMoneda + totalN199[7].ToString(); N199lbl8.Text = simboloMoneda + totalN199[8].ToString();
            N199lbl9.Text = simboloMoneda + totalN199[9].ToString(); N199lbl10.Text = simboloMoneda + totalN199[10].ToString(); N199lbl11.Text = simboloMoneda + totalN199[11].ToString();

            totalN205 = mergeTables.GeTotalByTablePlan(JsonDatasetN205, moneda);
            N205lbl0.Text = simboloMoneda + totalN205[0].ToString(); N205lbl1.Text = simboloMoneda + totalN205[1].ToString(); N205lbl2.Text = simboloMoneda + totalN205[2].ToString();
            N205lbl3.Text = simboloMoneda + totalN205[3].ToString(); N205lbl4.Text = simboloMoneda + totalN205[4].ToString(); N205lbl5.Text = simboloMoneda + totalN205[5].ToString();
            N205lbl6.Text = simboloMoneda + totalN205[6].ToString(); N205lbl7.Text = simboloMoneda + totalN205[7].ToString(); N205lbl8.Text = simboloMoneda + totalN205[8].ToString();

            N205lbl9.Text = simboloMoneda + totalN205[9].ToString(); N205lbl10.Text = simboloMoneda + totalN205[10].ToString(); N205lbl11.Text = simboloMoneda + totalN205[11].ToString();
            totalN210 = mergeTables.GeTotalByTablePlan(JsonDatasetN210, moneda);
            N210lbl0.Text = simboloMoneda + totalN210[0].ToString(); N210lbl1.Text = simboloMoneda + totalN210[1].ToString(); N210lbl2.Text = simboloMoneda + totalN210[2].ToString();
            N210lbl3.Text = simboloMoneda + totalN210[3].ToString(); N210lbl4.Text = simboloMoneda + totalN210[4].ToString(); N210lbl5.Text = simboloMoneda + totalN210[5].ToString();
            N210lbl6.Text = simboloMoneda + totalN210[6].ToString(); N210lbl7.Text = simboloMoneda + totalN210[7].ToString(); N210lbl8.Text = simboloMoneda + totalN210[8].ToString();
            N210lbl9.Text = simboloMoneda + totalN210[9].ToString(); N210lbl10.Text = simboloMoneda + totalN210[10].ToString(); N210lbl11.Text = simboloMoneda + totalN210[11].ToString();

            totalN215 = mergeTables.GeTotalByTablePlan(JsonDatasetN215, moneda);
            N215lbl0.Text = simboloMoneda + totalN215[0].ToString(); N215lbl1.Text = simboloMoneda + totalN215[1].ToString(); N215lbl2.Text = simboloMoneda + totalN215[2].ToString();
            N215lbl3.Text = simboloMoneda + totalN215[3].ToString(); N215lbl4.Text = simboloMoneda + totalN215[4].ToString(); N215lbl5.Text = simboloMoneda + totalN215[5].ToString();
            N215lbl6.Text = simboloMoneda + totalN215[6].ToString(); N215lbl7.Text = simboloMoneda + totalN215[7].ToString(); N215lbl8.Text = simboloMoneda + totalN215[8].ToString();
            N215lbl9.Text = simboloMoneda + totalN215[9].ToString(); N215lbl10.Text = simboloMoneda + totalN215[10].ToString(); N215lbl11.Text = simboloMoneda + totalN215[11].ToString();

            totalN220 = mergeTables.GeTotalByTablePlan(JsonDatasetN220, moneda);
            N220lbl0.Text = simboloMoneda + totalN220[0].ToString(); N220lbl1.Text = simboloMoneda + totalN220[1].ToString(); N220lbl2.Text = simboloMoneda + totalN220[2].ToString();
            N220lbl3.Text = simboloMoneda + totalN220[3].ToString(); N220lbl4.Text = simboloMoneda + totalN220[4].ToString(); N220lbl5.Text = simboloMoneda + totalN220[5].ToString();
            N220lbl6.Text = simboloMoneda + totalN220[6].ToString(); N220lbl7.Text = simboloMoneda + totalN220[7].ToString(); N220lbl8.Text = simboloMoneda + totalN220[8].ToString();
            N220lbl9.Text = simboloMoneda + totalN220[9].ToString(); N220lbl10.Text = simboloMoneda + totalN220[10].ToString(); N220lbl11.Text = simboloMoneda + totalN220[11].ToString();

            totalN225 = mergeTables.GeTotalByTablePlan(JsonDatasetN225, moneda);
            N225lbl0.Text = simboloMoneda + totalN225[0].ToString(); N225lbl1.Text = simboloMoneda + totalN225[1].ToString(); N225lbl2.Text = simboloMoneda + totalN225[2].ToString();
            N225lbl3.Text = simboloMoneda + totalN225[3].ToString(); N225lbl4.Text = simboloMoneda + totalN225[4].ToString(); N225lbl5.Text = simboloMoneda + totalN225[5].ToString();
            N225lbl6.Text = simboloMoneda + totalN225[6].ToString(); N225lbl7.Text = simboloMoneda + totalN225[7].ToString(); N225lbl8.Text = simboloMoneda + totalN225[8].ToString();
            N225lbl9.Text = simboloMoneda + totalN225[9].ToString(); N225lbl10.Text = simboloMoneda + totalN225[10].ToString(); N225lbl11.Text = simboloMoneda + totalN225[11].ToString();

            totalN230 = mergeTables.GeTotalByTablePlan(JsonDatasetN230, moneda);
            N230lbl0.Text = simboloMoneda + totalN230[0].ToString(); N230lbl1.Text = simboloMoneda + totalN230[1].ToString(); N230lbl2.Text = simboloMoneda + totalN230[2].ToString();
            N230lbl3.Text = simboloMoneda + totalN230[3].ToString(); N230lbl4.Text = simboloMoneda + totalN230[4].ToString(); N230lbl5.Text = simboloMoneda + totalN230[5].ToString();
            N230lbl6.Text = simboloMoneda + totalN230[6].ToString(); N230lbl7.Text = simboloMoneda + totalN230[7].ToString(); N230lbl8.Text = simboloMoneda + totalN230[8].ToString();
            N230lbl9.Text = simboloMoneda + totalN230[9].ToString(); N230lbl10.Text = simboloMoneda + totalN230[10].ToString(); N230lbl11.Text = simboloMoneda + totalN230[11].ToString();

            totalN235 = mergeTables.GeTotalByTablePlan(JsonDatasetN235, moneda);
            N235lbl0.Text = simboloMoneda + totalN235[0].ToString(); N235lbl1.Text = simboloMoneda + totalN235[1].ToString(); N235lbl2.Text = simboloMoneda + totalN235[2].ToString();
            N235lbl3.Text = simboloMoneda + totalN235[3].ToString(); N235lbl4.Text = simboloMoneda + totalN235[4].ToString(); N235lbl5.Text = simboloMoneda + totalN235[5].ToString();
            N235lbl6.Text = simboloMoneda + totalN235[6].ToString(); N235lbl7.Text = simboloMoneda + totalN235[7].ToString(); N235lbl8.Text = simboloMoneda + totalN235[8].ToString();
            N235lbl9.Text = simboloMoneda + totalN235[9].ToString(); N235lbl10.Text = simboloMoneda + totalN235[10].ToString(); N235lbl11.Text = simboloMoneda + totalN235[11].ToString();

            totalN299[0] = totalN205[0] + totalN210[0] + totalN215[0] + totalN220[0] + totalN225[0] + totalN230[0] + totalN235[0] + totalN199[0]; totalN299[1] = totalN205[1] + totalN210[1] + totalN215[1] + totalN220[1] + totalN225[1] + totalN230[1] + totalN235[1] + totalN199[1];
            totalN299[2] = totalN205[2] + totalN210[2] + totalN215[2] + totalN220[2] + totalN225[2] + totalN230[2] + totalN235[2] + totalN199[2]; totalN299[3] = totalN205[3] + totalN210[3] + totalN215[3] + totalN220[3] + totalN225[3] + totalN230[3] + totalN235[3] + totalN199[3];
            totalN299[4] = totalN205[4] + totalN210[4] + totalN215[4] + totalN220[4] + totalN225[4] + totalN230[4] + totalN235[4] + totalN199[4]; totalN299[5] = totalN205[5] + totalN210[5] + totalN215[5] + totalN220[5] + totalN225[5] + totalN230[5] + totalN235[5] + totalN199[5];
            totalN299[6] = totalN205[6] + totalN210[6] + totalN215[6] + totalN220[6] + totalN225[6] + totalN230[6] + totalN235[6] + totalN199[6]; totalN299[7] = totalN205[7] + totalN210[7] + totalN215[7] + totalN220[7] + totalN225[7] + totalN230[7] + totalN235[7] + totalN199[7];
            totalN299[8] = totalN205[8] + totalN210[8] + totalN215[8] + totalN220[8] + totalN225[8] + totalN230[8] + totalN235[8] + totalN199[8]; totalN299[9] = totalN205[9] + totalN210[9] + totalN215[9] + totalN220[9] + totalN225[9] + totalN230[9] + totalN235[9] + totalN199[9];
            totalN299[10] = totalN205[10] + totalN210[10] + totalN215[10] + totalN220[10] + totalN225[10] + totalN230[10] + totalN235[10] + totalN199[10]; totalN299[11] = totalN205[11] + totalN210[11] + totalN215[11] + totalN220[11] + totalN225[11] + totalN230[11] + totalN235[11] + totalN199[11];

            N299lbl0.Text = simboloMoneda + totalN299[0].ToString(); N299lbl1.Text = simboloMoneda + totalN299[1].ToString(); N299lbl2.Text = simboloMoneda + totalN299[2].ToString();
            N299lbl3.Text = simboloMoneda + totalN299[3].ToString(); N299lbl4.Text = simboloMoneda + totalN299[4].ToString(); N299lbl5.Text = simboloMoneda + totalN299[5].ToString();
            N299lbl6.Text = simboloMoneda + totalN299[6].ToString(); N299lbl7.Text = simboloMoneda + totalN299[7].ToString(); N299lbl8.Text = simboloMoneda + totalN299[8].ToString();
            N299lbl9.Text = simboloMoneda + totalN299[9].ToString(); N299lbl10.Text = simboloMoneda + totalN299[10].ToString(); N299lbl11.Text = simboloMoneda + totalN299[11].ToString();

            totalN305 = mergeTables.GeTotalByTablePlan(JsonDatasetN305, moneda);
            N305lbl0.Text = simboloMoneda + totalN305[0].ToString(); N305lbl1.Text = simboloMoneda + totalN305[1].ToString(); N305lbl2.Text = simboloMoneda + totalN305[2].ToString();
            N305lbl3.Text = simboloMoneda + totalN305[3].ToString(); N305lbl4.Text = simboloMoneda + totalN305[4].ToString(); N305lbl5.Text = simboloMoneda + totalN305[5].ToString();
            N305lbl6.Text = simboloMoneda + totalN305[6].ToString(); N305lbl7.Text = simboloMoneda + totalN305[7].ToString(); N305lbl8.Text = simboloMoneda + totalN305[8].ToString();
            N305lbl9.Text = simboloMoneda + totalN305[9].ToString(); N305lbl10.Text = simboloMoneda + totalN305[10].ToString(); N305lbl11.Text = simboloMoneda + totalN305[11].ToString();
            totalN310 = mergeTables.GeTotalByTablePlan(JsonDatasetN310, moneda);
            N310lbl0.Text = simboloMoneda + totalN310[0].ToString(); N310lbl1.Text = simboloMoneda + totalN310[1].ToString(); N310lbl2.Text = simboloMoneda + totalN310[2].ToString();
            N310lbl3.Text = simboloMoneda + totalN310[3].ToString(); N310lbl4.Text = simboloMoneda + totalN310[4].ToString(); N310lbl5.Text = simboloMoneda + totalN310[5].ToString();
            N310lbl6.Text = simboloMoneda + totalN310[6].ToString(); N310lbl7.Text = simboloMoneda + totalN310[7].ToString(); N310lbl8.Text = simboloMoneda + totalN310[8].ToString();
            N310lbl9.Text = simboloMoneda + totalN310[9].ToString(); N310lbl10.Text = simboloMoneda + totalN310[10].ToString(); N310lbl11.Text = simboloMoneda + totalN310[11].ToString();
            totalN315 = mergeTables.GeTotalByTablePlan(JsonDatasetN315, moneda);
            N315lbl0.Text = simboloMoneda + totalN315[0].ToString(); N315lbl1.Text = simboloMoneda + totalN315[1].ToString(); N315lbl2.Text = simboloMoneda + totalN315[2].ToString();
            N315lbl3.Text = simboloMoneda + totalN315[3].ToString(); N315lbl4.Text = simboloMoneda + totalN315[4].ToString(); N315lbl5.Text = simboloMoneda + totalN315[5].ToString();
            N315lbl6.Text = simboloMoneda + totalN315[6].ToString(); N315lbl7.Text = simboloMoneda + totalN315[7].ToString(); N315lbl8.Text = simboloMoneda + totalN315[8].ToString();
            N315lbl9.Text = simboloMoneda + totalN315[9].ToString(); N315lbl10.Text = simboloMoneda + totalN315[10].ToString(); N315lbl11.Text = simboloMoneda + totalN315[11].ToString();

            totalN399[0] = totalN305[0] + totalN310[0] + totalN315[0] + totalN299[0]; totalN399[1] = totalN305[1] + totalN310[1] + totalN315[1] + totalN299[1];
            totalN399[2] = totalN305[2] + totalN310[2] + totalN315[2] + totalN299[2]; totalN399[3] = totalN305[3] + totalN310[3] + totalN315[3] + totalN299[3];
            totalN399[4] = totalN305[4] + totalN310[4] + totalN315[4] + totalN299[4]; totalN399[5] = totalN305[5] + totalN310[5] + totalN315[5] + totalN299[5];
            totalN399[6] = totalN305[6] + totalN310[6] + totalN315[6] + totalN299[6]; totalN399[7] = totalN305[7] + totalN310[7] + totalN315[7] + totalN299[7];
            totalN399[8] = totalN305[8] + totalN310[8] + totalN315[8] + totalN299[8]; totalN399[9] = totalN305[9] + totalN310[9] + totalN315[9] + totalN299[9];
            totalN399[10] = totalN305[10] + totalN310[10] + totalN315[10] + totalN299[10]; totalN399[11] = totalN305[11] + totalN310[11] + totalN315[11] + totalN299[11];
            N399lbl0.Text = simboloMoneda + totalN399[0].ToString(); N399lbl1.Text = simboloMoneda + totalN399[1].ToString(); N399lbl2.Text = simboloMoneda + totalN399[2].ToString();
            N399lbl3.Text = simboloMoneda + totalN399[3].ToString(); N399lbl4.Text = simboloMoneda + totalN399[4].ToString(); N399lbl5.Text = simboloMoneda + totalN399[5].ToString();
            N399lbl6.Text = simboloMoneda + totalN399[6].ToString(); N399lbl7.Text = simboloMoneda + totalN399[7].ToString(); N399lbl8.Text = simboloMoneda + totalN399[8].ToString();
            N399lbl9.Text = simboloMoneda + totalN399[9].ToString(); N399lbl10.Text = simboloMoneda + totalN399[10].ToString(); N399lbl11.Text = simboloMoneda + totalN399[11].ToString();

            totalN405 = mergeTables.GeTotalByTablePlan(JsonDatasetN405, moneda);
            N405lbl0.Text = simboloMoneda + totalN405[0].ToString(); N405lbl1.Text = simboloMoneda + totalN405[1].ToString(); N405lbl2.Text = simboloMoneda + totalN405[2].ToString();
            N405lbl3.Text = simboloMoneda + totalN405[3].ToString(); N405lbl4.Text = simboloMoneda + totalN405[4].ToString(); N405lbl5.Text = simboloMoneda + totalN405[5].ToString();
            N405lbl6.Text = simboloMoneda + totalN405[6].ToString(); N405lbl7.Text = simboloMoneda + totalN405[7].ToString(); N405lbl8.Text = simboloMoneda + totalN405[8].ToString();
            N405lbl9.Text = simboloMoneda + totalN405[9].ToString(); N405lbl10.Text = simboloMoneda + totalN405[10].ToString(); N405lbl11.Text = simboloMoneda + totalN405[11].ToString();
            totalN410 = mergeTables.GeTotalByTablePlan(JsonDatasetN410, moneda);
            N410lbl0.Text = simboloMoneda + totalN410[0].ToString(); N410lbl1.Text = simboloMoneda + totalN410[1].ToString(); N410lbl2.Text = simboloMoneda + totalN410[2].ToString();
            N410lbl3.Text = simboloMoneda + totalN410[3].ToString(); N410lbl4.Text = simboloMoneda + totalN410[4].ToString(); N410lbl5.Text = simboloMoneda + totalN410[5].ToString();
            N410lbl6.Text = simboloMoneda + totalN410[6].ToString(); N410lbl7.Text = simboloMoneda + totalN410[7].ToString(); N410lbl8.Text = simboloMoneda + totalN410[8].ToString();
            N410lbl9.Text = simboloMoneda + totalN410[9].ToString(); N410lbl10.Text = simboloMoneda + totalN410[10].ToString(); N410lbl11.Text = simboloMoneda + totalN410[11].ToString();
            totalN415 = mergeTables.GeTotalByTablePlan(JsonDatasetN415, moneda);
            N415lbl0.Text = simboloMoneda + totalN415[0].ToString(); N415lbl1.Text = simboloMoneda + totalN415[1].ToString(); N415lbl2.Text = simboloMoneda + totalN415[2].ToString();
            N415lbl3.Text = simboloMoneda + totalN415[3].ToString(); N415lbl4.Text = simboloMoneda + totalN415[4].ToString(); N415lbl5.Text = simboloMoneda + totalN415[5].ToString();
            N415lbl6.Text = simboloMoneda + totalN415[6].ToString(); N415lbl7.Text = simboloMoneda + totalN415[7].ToString(); N415lbl8.Text = simboloMoneda + totalN415[8].ToString();
            N415lbl9.Text = simboloMoneda + totalN415[9].ToString(); N415lbl10.Text = simboloMoneda + totalN415[10].ToString(); N415lbl11.Text = simboloMoneda + totalN415[11].ToString();
            totalN420 = mergeTables.GeTotalByTablePlan(JsonDatasetN420, moneda);
            N420lbl0.Text = simboloMoneda + totalN420[0].ToString(); N420lbl1.Text = simboloMoneda + totalN420[1].ToString(); N420lbl2.Text = simboloMoneda + totalN420[2].ToString();
            N420lbl3.Text = simboloMoneda + totalN420[3].ToString(); N420lbl4.Text = simboloMoneda + totalN420[4].ToString(); N420lbl5.Text = simboloMoneda + totalN420[5].ToString();
            N420lbl6.Text = simboloMoneda + totalN420[6].ToString(); N420lbl7.Text = simboloMoneda + totalN420[7].ToString(); N420lbl8.Text = simboloMoneda + totalN420[8].ToString();
            N420lbl9.Text = simboloMoneda + totalN420[9].ToString(); N420lbl10.Text = simboloMoneda + totalN420[10].ToString(); N420lbl11.Text = simboloMoneda + totalN420[11].ToString();
            totalN425 = mergeTables.GeTotalByTablePlan(JsonDatasetN425, moneda);
            N425lbl0.Text = simboloMoneda + totalN425[0].ToString(); N425lbl1.Text = simboloMoneda + totalN425[1].ToString(); N425lbl2.Text = simboloMoneda + totalN425[2].ToString();
            N425lbl3.Text = simboloMoneda + totalN425[3].ToString(); N425lbl4.Text = simboloMoneda + totalN425[4].ToString(); N425lbl5.Text = simboloMoneda + totalN425[5].ToString();
            N425lbl6.Text = simboloMoneda + totalN425[6].ToString(); N425lbl7.Text = simboloMoneda + totalN425[7].ToString(); N425lbl8.Text = simboloMoneda + totalN425[8].ToString();
            N425lbl9.Text = simboloMoneda + totalN425[9].ToString(); N425lbl10.Text = simboloMoneda + totalN425[10].ToString(); N425lbl11.Text = simboloMoneda + totalN425[11].ToString();
            totalN430 = mergeTables.GeTotalByTablePlan(JsonDatasetN430, moneda);
            N430lbl0.Text = simboloMoneda + totalN430[0].ToString(); N430lbl1.Text = simboloMoneda + totalN430[1].ToString(); N430lbl2.Text = simboloMoneda + totalN430[2].ToString();
            N430lbl3.Text = simboloMoneda + totalN430[3].ToString(); N430lbl4.Text = simboloMoneda + totalN430[4].ToString(); N430lbl5.Text = simboloMoneda + totalN430[5].ToString();
            N430lbl6.Text = simboloMoneda + totalN430[6].ToString(); N430lbl7.Text = simboloMoneda + totalN430[7].ToString(); N430lbl8.Text = simboloMoneda + totalN430[8].ToString();
            N430lbl9.Text = simboloMoneda + totalN430[9].ToString(); N430lbl10.Text = simboloMoneda + totalN430[10].ToString(); N430lbl11.Text = simboloMoneda + totalN430[11].ToString();

            totalN499[0] = totalN405[0] + totalN410[0] + totalN415[0] + totalN420[0] + totalN425[0] + totalN430[0] + totalN399[0]; totalN499[1] = totalN405[1] + totalN410[1] + totalN415[1] + totalN420[1] + totalN425[1] + totalN430[1] + totalN399[1];
            totalN499[2] = totalN405[2] + totalN410[2] + totalN415[2] + totalN420[2] + totalN425[2] + totalN430[2] + totalN399[2]; totalN499[3] = totalN405[3] + totalN410[3] + totalN415[3] + totalN420[3] + totalN425[3] + totalN430[3] + totalN399[3];
            totalN499[4] = totalN405[4] + totalN410[4] + totalN415[4] + totalN420[4] + totalN425[4] + totalN430[4] + totalN399[4]; totalN499[5] = totalN405[5] + totalN410[5] + totalN415[5] + totalN420[5] + totalN425[5] + totalN430[5] + totalN399[5];
            totalN499[6] = totalN405[6] + totalN410[6] + totalN415[6] + totalN420[6] + totalN425[6] + totalN430[6] + totalN399[6]; totalN499[7] = totalN405[7] + totalN410[7] + totalN415[7] + totalN420[7] + totalN425[7] + totalN430[7] + totalN399[7];
            totalN499[8] = totalN405[8] + totalN410[8] + totalN415[8] + totalN420[8] + totalN425[8] + totalN430[8] + totalN399[8]; totalN499[9] = totalN405[9] + totalN410[9] + totalN415[9] + totalN420[9] + totalN425[9] + totalN430[9] + totalN399[9];
            totalN499[10] = totalN405[10] + totalN410[10] + totalN415[10] + totalN420[10] + totalN425[10] + totalN430[10] + totalN399[10]; totalN499[11] = totalN405[11] + totalN410[11] + totalN415[11] + totalN420[11] + totalN425[11] + totalN430[11] + totalN399[11];

            N499lbl0.Text = simboloMoneda + totalN499[0].ToString(); N499lbl1.Text = simboloMoneda + totalN499[1].ToString(); N499lbl2.Text = simboloMoneda + totalN499[2].ToString();
            N499lbl3.Text = simboloMoneda + totalN499[3].ToString(); N499lbl4.Text = simboloMoneda + totalN499[4].ToString(); N499lbl5.Text = simboloMoneda + totalN499[5].ToString();
            N499lbl6.Text = simboloMoneda + totalN499[6].ToString(); N499lbl7.Text = simboloMoneda + totalN499[7].ToString(); N499lbl8.Text = simboloMoneda + totalN499[8].ToString();
            N499lbl9.Text = simboloMoneda + totalN499[9].ToString(); N499lbl10.Text = simboloMoneda + totalN499[10].ToString(); N499lbl11.Text = simboloMoneda + totalN499[11].ToString();

            totalN505 = mergeTables.GeTotalByTablePlan(JsonDatasetN505, moneda);
            N505lbl0.Text = simboloMoneda + totalN505[0].ToString(); N505lbl1.Text = simboloMoneda + totalN505[1].ToString(); N505lbl2.Text = simboloMoneda + totalN505[2].ToString();
            N505lbl3.Text = simboloMoneda + totalN505[3].ToString(); N505lbl4.Text = simboloMoneda + totalN505[4].ToString(); N505lbl5.Text = simboloMoneda + totalN505[5].ToString();
            N505lbl6.Text = simboloMoneda + totalN505[6].ToString(); N505lbl7.Text = simboloMoneda + totalN505[7].ToString(); N505lbl8.Text = simboloMoneda + totalN505[8].ToString();
            N505lbl9.Text = simboloMoneda + totalN505[9].ToString(); N505lbl10.Text = simboloMoneda + totalN505[10].ToString(); N505lbl11.Text = simboloMoneda + totalN505[11].ToString();
            totalN510 = mergeTables.GeTotalByTablePlan(JsonDatasetN510, moneda);
            N510lbl0.Text = simboloMoneda + totalN510[0].ToString(); N510lbl1.Text = simboloMoneda + totalN510[1].ToString(); N510lbl2.Text = simboloMoneda + totalN510[2].ToString();
            N510lbl3.Text = simboloMoneda + totalN510[3].ToString(); N510lbl4.Text = simboloMoneda + totalN510[4].ToString(); N510lbl5.Text = simboloMoneda + totalN510[5].ToString();
            N510lbl6.Text = simboloMoneda + totalN510[6].ToString(); N510lbl7.Text = simboloMoneda + totalN510[7].ToString(); N510lbl8.Text = simboloMoneda + totalN510[8].ToString();
            N510lbl9.Text = simboloMoneda + totalN510[9].ToString(); N510lbl10.Text = simboloMoneda + totalN510[10].ToString(); N510lbl11.Text = simboloMoneda + totalN510[11].ToString();
            totalN515 = mergeTables.GeTotalByTablePlan(JsonDatasetN515, moneda);
            N515lbl0.Text = simboloMoneda + totalN515[0].ToString(); N515lbl1.Text = simboloMoneda + totalN515[1].ToString(); N515lbl2.Text = simboloMoneda + totalN515[2].ToString();
            N515lbl3.Text = simboloMoneda + totalN515[3].ToString(); N515lbl4.Text = simboloMoneda + totalN515[4].ToString(); N515lbl5.Text = simboloMoneda + totalN515[5].ToString();
            N515lbl6.Text = simboloMoneda + totalN515[6].ToString(); N515lbl7.Text = simboloMoneda + totalN515[7].ToString(); N515lbl8.Text = simboloMoneda + totalN515[8].ToString();
            N515lbl9.Text = simboloMoneda + totalN515[9].ToString(); N515lbl10.Text = simboloMoneda + totalN515[10].ToString(); N515lbl11.Text = simboloMoneda + totalN515[11].ToString();
            totalN520 = mergeTables.GeTotalByTablePlan(JsonDatasetN520, moneda);
            N520lbl0.Text = simboloMoneda + totalN520[0].ToString(); N520lbl1.Text = simboloMoneda + totalN520[1].ToString(); N520lbl2.Text = simboloMoneda + totalN520[2].ToString();
            N520lbl3.Text = simboloMoneda + totalN520[3].ToString(); N520lbl4.Text = simboloMoneda + totalN520[4].ToString(); N520lbl5.Text = simboloMoneda + totalN520[5].ToString();
            N520lbl6.Text = simboloMoneda + totalN520[6].ToString(); N520lbl7.Text = simboloMoneda + totalN520[7].ToString(); N520lbl8.Text = simboloMoneda + totalN520[8].ToString();
            N520lbl9.Text = simboloMoneda + totalN520[9].ToString(); N520lbl10.Text = simboloMoneda + totalN520[10].ToString(); N520lbl11.Text = simboloMoneda + totalN520[11].ToString();
            totalN525 = mergeTables.GeTotalByTablePlan(JsonDatasetN525, moneda);
            N525lbl0.Text = simboloMoneda + totalN525[0].ToString(); N525lbl1.Text = simboloMoneda + totalN525[1].ToString(); N525lbl2.Text = simboloMoneda + totalN525[2].ToString();
            N525lbl3.Text = simboloMoneda + totalN525[3].ToString(); N525lbl4.Text = simboloMoneda + totalN525[4].ToString(); N525lbl5.Text = simboloMoneda + totalN525[5].ToString();
            N525lbl6.Text = simboloMoneda + totalN525[6].ToString(); N525lbl7.Text = simboloMoneda + totalN525[7].ToString(); N525lbl8.Text = simboloMoneda + totalN525[8].ToString();
            N525lbl9.Text = simboloMoneda + totalN525[9].ToString(); N525lbl10.Text = simboloMoneda + totalN525[10].ToString(); N525lbl11.Text = simboloMoneda + totalN525[11].ToString();

            totalN599[0] = totalN505[0] + totalN510[0] + totalN515[0] + totalN520[0] + totalN525[0] + totalN499[0]; totalN599[1] = totalN505[1] + totalN510[1] + totalN515[1] + totalN520[1] + totalN525[1] + totalN499[1];
            totalN599[2] = totalN505[2] + totalN510[2] + totalN515[2] + totalN520[2] + totalN525[2] + totalN499[2]; totalN599[3] = totalN505[3] + totalN510[3] + totalN515[3] + totalN520[3] + totalN525[3] + totalN499[3];
            totalN599[4] = totalN505[4] + totalN510[4] + totalN515[4] + totalN520[4] + totalN525[4] + totalN499[4]; totalN599[5] = totalN505[5] + totalN510[5] + totalN515[5] + totalN520[5] + totalN525[5] + totalN499[5];
            totalN599[6] = totalN505[6] + totalN510[6] + totalN515[6] + totalN520[6] + totalN525[6] + totalN499[6]; totalN599[7] = totalN505[7] + totalN510[7] + totalN515[7] + totalN520[7] + totalN525[7] + totalN499[7];
            totalN599[8] = totalN505[8] + totalN510[8] + totalN515[8] + totalN520[8] + totalN525[8] + totalN499[8]; totalN599[9] = totalN505[9] + totalN510[9] + totalN515[9] + totalN520[9] + totalN525[9] + totalN499[9];
            totalN599[10] = totalN505[10] + totalN510[10] + totalN515[10] + totalN520[10] + totalN525[10] + totalN499[10]; totalN599[11] = totalN505[11] + totalN510[11] + totalN515[11] + totalN520[11] + totalN525[11] + totalN499[11];

            N599lbl0.Text = simboloMoneda + totalN599[0].ToString(); N599lbl1.Text = simboloMoneda + totalN599[1].ToString(); N599lbl2.Text = simboloMoneda + totalN599[2].ToString();
            N599lbl3.Text = simboloMoneda + totalN599[3].ToString(); N599lbl4.Text = simboloMoneda + totalN599[4].ToString(); N599lbl5.Text = simboloMoneda + totalN599[5].ToString();
            N599lbl6.Text = simboloMoneda + totalN599[6].ToString(); N599lbl7.Text = simboloMoneda + totalN599[7].ToString(); N599lbl8.Text = simboloMoneda + totalN599[8].ToString();
            N599lbl9.Text = simboloMoneda + totalN599[9].ToString(); N599lbl10.Text = simboloMoneda + totalN599[10].ToString(); N599lbl11.Text = simboloMoneda + totalN599[11].ToString();

            totalN805 = mergeTables.GeTotalByTablePlan(JsonDatasetN805, moneda);
            N805lbl0.Text = simboloMoneda + totalN805[0].ToString(); N805lbl1.Text = simboloMoneda + totalN805[1].ToString(); N805lbl2.Text = simboloMoneda + totalN805[2].ToString();
            N805lbl3.Text = simboloMoneda + totalN805[3].ToString(); N805lbl4.Text = simboloMoneda + totalN805[4].ToString(); N805lbl5.Text = simboloMoneda + totalN805[5].ToString();
            N805lbl6.Text = simboloMoneda + totalN805[6].ToString(); N805lbl7.Text = simboloMoneda + totalN805[7].ToString(); N805lbl8.Text = simboloMoneda + totalN805[8].ToString();
            N805lbl9.Text = simboloMoneda + totalN805[9].ToString(); N805lbl10.Text = simboloMoneda + totalN805[10].ToString(); N805lbl11.Text = simboloMoneda + totalN805[11].ToString();

            totalN810 = mergeTables.GeTotalByTablePlan(JsonDatasetN810, moneda);
            N810lbl0.Text = simboloMoneda + totalN810[0].ToString(); N810lbl1.Text = simboloMoneda + totalN810[1].ToString(); N810lbl2.Text = simboloMoneda + totalN810[2].ToString();
            N810lbl3.Text = simboloMoneda + totalN810[3].ToString(); N810lbl4.Text = simboloMoneda + totalN810[4].ToString(); N810lbl5.Text = simboloMoneda + totalN810[5].ToString();
            N810lbl6.Text = simboloMoneda + totalN810[6].ToString(); N810lbl7.Text = simboloMoneda + totalN810[7].ToString(); N810lbl8.Text = simboloMoneda + totalN810[8].ToString();
            N810lbl9.Text = simboloMoneda + totalN810[9].ToString(); N810lbl10.Text = simboloMoneda + totalN810[10].ToString(); N810lbl11.Text = simboloMoneda + totalN810[11].ToString();

            totalN999[0] = totalN805[0] + totalN810[0] + totalN599[0]; totalN999[1] = totalN805[1] + totalN810[1] + totalN599[1];
            totalN999[2] = totalN805[2] + totalN810[2] + totalN599[2]; totalN999[3] = totalN805[3] + totalN810[3] + totalN599[3];
            totalN999[4] = totalN805[4] + totalN810[4] + totalN599[4]; totalN999[5] = totalN805[5] + totalN810[5] + totalN599[5];
            totalN999[6] = totalN805[6] + totalN810[6] + totalN599[6]; totalN999[7] = totalN805[7] + totalN810[7] + totalN599[7];
            totalN999[8] = totalN805[8] + totalN810[8] + totalN599[8]; totalN999[9] = totalN805[9] + totalN810[9] + totalN599[9];
            totalN999[10] = totalN805[10] + totalN810[10] + totalN599[10]; totalN999[11] = totalN805[11] + totalN810[11] + totalN599[11];
            N999lbl0.Text = simboloMoneda + totalN999[0].ToString(); N999lbl1.Text = simboloMoneda + totalN999[1].ToString(); N999lbl2.Text = simboloMoneda + totalN999[2].ToString();
            N999lbl3.Text = simboloMoneda + totalN999[3].ToString(); N999lbl4.Text = simboloMoneda + totalN999[4].ToString(); N999lbl5.Text = simboloMoneda + totalN999[5].ToString();
            N999lbl6.Text = simboloMoneda + totalN999[6].ToString(); N999lbl7.Text = simboloMoneda + totalN999[7].ToString(); N999lbl8.Text = simboloMoneda + totalN999[8].ToString();
            N999lbl9.Text = simboloMoneda + totalN999[9].ToString(); N999lbl10.Text = simboloMoneda + totalN999[10].ToString(); N999lbl11.Text = simboloMoneda + totalN999[11].ToString();
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