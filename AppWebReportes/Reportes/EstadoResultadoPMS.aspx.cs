using BusinessLayer;
using System;

namespace AppWebReportes.Reportes
{
    public partial class EstadoResultadoPMS : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
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
            string simboloMoneda = "S/ ";
            string JsonDatasetN005 = GetPathFile("N005"); string JsonDatasetN010 = GetPathFile("N010");
            string JsonDatasetN015 = GetPathFile("N015"); string JsonDatasetN103 = GetPathFile("N103");
            string JsonDatasetN105 = GetPathFile("N105"); string JsonDatasetN110 = GetPathFile("N110");
            string JsonDatasetN205 = GetPathFile("N205"); string JsonDatasetN210 = GetPathFile("N210");
            string JsonDatasetN215 = GetPathFile("N215"); string JsonDatasetN220 = GetPathFile("N220");
            string JsonDatasetN225 = GetPathFile("N225"); string JsonDatasetN230 = GetPathFile("N230");
            string JsonDatasetN235 = GetPathFile("N235"); string JsonDatasetN305 = GetPathFile("N305");
            string JsonDatasetN310 = GetPathFile("N310"); string JsonDatasetN315 = GetPathFile("N315");
            string JsonDatasetN405 = GetPathFile("N405"); string JsonDatasetN410 = GetPathFile("N410");
            string JsonDatasetN415 = GetPathFile("N415"); string JsonDatasetN420 = GetPathFile("N420");
            string JsonDatasetN425 = GetPathFile("N425"); string JsonDatasetN430 = GetPathFile("N430");
            string JsonDatasetN505 = GetPathFile("N505"); string JsonDatasetN510 = GetPathFile("N510");
            string JsonDatasetN515 = GetPathFile("N515"); string JsonDatasetN520 = GetPathFile("N520");
            string JsonDatasetN525 = GetPathFile("N525"); string JsonDatasetN805 = GetPathFile("N805");
            string JsonDatasetN810 = GetPathFile("N810");

            decimal[] sumN005 = new decimal[12];    decimal[] sumN010 = new decimal[12];
            decimal[] sumN015 = new decimal[12];    decimal[] sumN099 = new decimal[12];
            decimal[] sumN103 = new decimal[12];    decimal[] sumN105 = new decimal[12];
            decimal[] sumN110 = new decimal[12];    decimal[] sumN199 = new decimal[12];
            decimal[] sumN205 = new decimal[12];    decimal[] sumN299 = new decimal[12];
            decimal[] sumN210 = new decimal[12];    decimal[] sumN215 = new decimal[12];
            decimal[] sumN220 = new decimal[12];    decimal[] sumN225 = new decimal[12];
            decimal[] sumN230 = new decimal[12];    decimal[] sumN235 = new decimal[12];
            decimal[] sumN305 = new decimal[12];    decimal[] sumN310 = new decimal[12];
            decimal[] sumN315 = new decimal[12];    decimal[] sumN405 = new decimal[12];
            decimal[] sumN410 = new decimal[12];    decimal[] sumN415 = new decimal[12];
            decimal[] sumN420 = new decimal[12];    decimal[] sumN425 = new decimal[12];
            decimal[] sumN430 = new decimal[12];    decimal[] sumN505 = new decimal[12];
            decimal[] sumN510 = new decimal[12];    decimal[] sumN515 = new decimal[12];
            decimal[] sumN520 = new decimal[12];    decimal[] sumN525 = new decimal[12];
            decimal[] sumN805 = new decimal[12];    decimal[] sumN810 = new decimal[12];
            decimal[] sumN399 = new decimal[12];    decimal[] sumN499 = new decimal[12];
            decimal[] sumN599 = new decimal[12];    decimal[] sumN999 = new decimal[12];
            if (!moneda)                    // Moneda: Dólares
            { simboloMoneda = "$ "; }
            sumN005 = mergeTables.GeTotalByTablePlan(JsonDatasetN005, moneda, false);
            N005lbl0.Text = simboloMoneda + sumN005[0].ToString(); N005lbl1.Text = simboloMoneda + sumN005[1].ToString(); N005lbl2.Text = simboloMoneda + sumN005[2].ToString();
            N005lbl3.Text = simboloMoneda + sumN005[3].ToString(); N005lbl4.Text = simboloMoneda + sumN005[4].ToString(); N005lbl5.Text = simboloMoneda + sumN005[5].ToString();
            N005lbl6.Text = simboloMoneda + sumN005[6].ToString(); N005lbl7.Text = simboloMoneda + sumN005[7].ToString(); N005lbl8.Text = simboloMoneda + sumN005[8].ToString();
            N005lbl9.Text = simboloMoneda + sumN005[9].ToString(); N005lbl10.Text = simboloMoneda + sumN005[10].ToString(); N005lbl11.Text = simboloMoneda + sumN005[11].ToString();

            sumN010 = mergeTables.GeTotalByTablePlan(JsonDatasetN010, moneda, false);
            N010lbl0.Text = simboloMoneda + sumN010[0].ToString(); N010lbl1.Text = simboloMoneda + sumN010[1].ToString(); N010lbl2.Text = simboloMoneda + sumN010[2].ToString();
            N010lbl3.Text = simboloMoneda + sumN010[3].ToString(); N010lbl4.Text = simboloMoneda + sumN010[4].ToString(); N010lbl5.Text = simboloMoneda + sumN010[5].ToString();
            N010lbl6.Text = simboloMoneda + sumN010[6].ToString(); N010lbl7.Text = simboloMoneda + sumN010[7].ToString(); N010lbl8.Text = simboloMoneda + sumN010[8].ToString();
            N010lbl9.Text = simboloMoneda + sumN010[9].ToString(); N010lbl10.Text = simboloMoneda + sumN010[10].ToString(); N010lbl11.Text = simboloMoneda + sumN010[11].ToString();

            sumN015 = mergeTables.GeTotalByTablePlan(JsonDatasetN015, moneda, false);
            N015lbl0.Text = simboloMoneda + sumN015[0].ToString(); N015lbl1.Text = simboloMoneda + sumN015[1].ToString(); N015lbl2.Text = simboloMoneda + sumN015[2].ToString();
            N015lbl3.Text = simboloMoneda + sumN015[3].ToString(); N015lbl4.Text = simboloMoneda + sumN015[4].ToString(); N015lbl5.Text = simboloMoneda + sumN015[5].ToString();
            N015lbl6.Text = simboloMoneda + sumN015[6].ToString(); N015lbl7.Text = simboloMoneda + sumN015[7].ToString(); N015lbl8.Text = simboloMoneda + sumN015[8].ToString();
            N015lbl9.Text = simboloMoneda + sumN015[9].ToString(); N015lbl10.Text = simboloMoneda + sumN015[10].ToString(); N015lbl11.Text = simboloMoneda + sumN015[11].ToString();

            sumN099[0] = sumN005[0] + sumN010[0] + sumN015[0]; sumN099[1] = sumN005[1] + sumN010[1] + sumN015[1];
            sumN099[2] = sumN005[2] + sumN010[2] + sumN015[2]; sumN099[3] = sumN005[3] + sumN010[3] + sumN015[3];
            sumN099[4] = sumN005[4] + sumN010[4] + sumN015[4]; sumN099[5] = sumN005[5] + sumN010[5] + sumN015[5];
            sumN099[6] = sumN005[6] + sumN010[6] + sumN015[6]; sumN099[7] = sumN005[7] + sumN010[7] + sumN015[7];
            sumN099[8] = sumN005[8] + sumN010[8] + sumN015[8]; sumN099[9] = sumN005[9] + sumN010[9] + sumN015[9];
            sumN099[10] = sumN005[10] + sumN010[10] + sumN015[10]; sumN099[11] = sumN005[11] + sumN010[11] + sumN015[11];
            N099lbl0.Text = simboloMoneda + sumN099[0].ToString(); N099lbl1.Text = simboloMoneda + sumN099[1].ToString(); N099lbl2.Text = simboloMoneda + sumN099[2].ToString();
            N099lbl3.Text = simboloMoneda + sumN099[3].ToString(); N099lbl4.Text = simboloMoneda + sumN099[4].ToString(); N099lbl5.Text = simboloMoneda + sumN099[5].ToString();
            N099lbl6.Text = simboloMoneda + sumN099[6].ToString(); N099lbl7.Text = simboloMoneda + sumN099[7].ToString(); N099lbl8.Text = simboloMoneda + sumN099[8].ToString();
            N099lbl9.Text = simboloMoneda + sumN099[9].ToString(); N099lbl10.Text = simboloMoneda + sumN099[10].ToString(); N099lbl11.Text = simboloMoneda + sumN099[11].ToString();

            sumN103 = mergeTables.GeTotalByTablePlan(JsonDatasetN103, moneda, false);
            N103lbl0.Text = simboloMoneda + sumN103[0].ToString(); N103lbl1.Text = simboloMoneda + sumN103[1].ToString(); N103lbl2.Text = simboloMoneda + sumN103[2].ToString();
            N103lbl3.Text = simboloMoneda + sumN103[3].ToString(); N103lbl4.Text = simboloMoneda + sumN103[4].ToString(); N103lbl5.Text = simboloMoneda + sumN103[5].ToString();
            N103lbl6.Text = simboloMoneda + sumN103[6].ToString(); N103lbl7.Text = simboloMoneda + sumN103[7].ToString(); N103lbl8.Text = simboloMoneda + sumN103[8].ToString();
            N103lbl9.Text = simboloMoneda + sumN103[9].ToString(); N103lbl10.Text = simboloMoneda + sumN103[10].ToString(); N103lbl11.Text = simboloMoneda + sumN103[11].ToString();

            sumN105 = mergeTables.GeTotalByTablePlan(JsonDatasetN105, moneda, false);
            N105lbl0.Text = simboloMoneda + sumN105[0].ToString(); N105lbl1.Text = simboloMoneda + sumN105[1].ToString(); N105lbl2.Text = simboloMoneda + sumN105[2].ToString();
            N105lbl3.Text = simboloMoneda + sumN105[3].ToString(); N105lbl4.Text = simboloMoneda + sumN105[4].ToString(); N105lbl5.Text = simboloMoneda + sumN105[5].ToString();
            N105lbl6.Text = simboloMoneda + sumN105[6].ToString(); N105lbl7.Text = simboloMoneda + sumN105[7].ToString(); N105lbl8.Text = simboloMoneda + sumN105[8].ToString();
            N105lbl9.Text = simboloMoneda + sumN105[9].ToString(); N105lbl10.Text = simboloMoneda + sumN105[10].ToString(); N105lbl11.Text = simboloMoneda + sumN105[11].ToString();

            sumN110 = mergeTables.GeTotalByTablePlan(JsonDatasetN110, moneda, false);
            N110lbl0.Text = simboloMoneda + sumN110[0].ToString(); N110lbl1.Text = simboloMoneda + sumN110[1].ToString(); N110lbl2.Text = simboloMoneda + sumN110[2].ToString();
            N110lbl3.Text = simboloMoneda + sumN110[3].ToString(); N110lbl4.Text = simboloMoneda + sumN110[4].ToString(); N110lbl5.Text = simboloMoneda + sumN110[5].ToString();
            N110lbl6.Text = simboloMoneda + sumN110[6].ToString(); N110lbl7.Text = simboloMoneda + sumN110[7].ToString(); N110lbl8.Text = simboloMoneda + sumN110[8].ToString();
            N110lbl9.Text = simboloMoneda + sumN110[9].ToString(); N110lbl10.Text = simboloMoneda + sumN110[10].ToString(); N110lbl11.Text = simboloMoneda + sumN110[11].ToString();

            sumN199[0] = sumN103[0] + sumN105[0] + sumN110[0] + sumN099[0]; sumN199[1] = sumN103[1] + sumN105[1] + sumN110[1] + sumN099[1];
            sumN199[2] = sumN103[2] + sumN105[2] + sumN110[2] + sumN099[2]; sumN199[3] = sumN103[3] + sumN105[3] + sumN110[3] + sumN099[3];
            sumN199[4] = sumN103[4] + sumN105[4] + sumN110[4] + sumN099[4]; sumN199[5] = sumN103[5] + sumN105[5] + sumN110[5] + sumN099[5];
            sumN199[6] = sumN103[6] + sumN105[6] + sumN110[6] + sumN099[6]; sumN199[7] = sumN103[7] + sumN105[7] + sumN110[7] + sumN099[7];
            sumN199[8] = sumN103[8] + sumN105[8] + sumN110[8] + sumN099[8]; sumN199[9] = sumN103[9] + sumN105[9] + sumN110[9] + sumN099[9];
            sumN199[10] = sumN103[10] + sumN105[10] + sumN110[10] + sumN099[10]; sumN199[11] = sumN103[11] + sumN105[11] + sumN110[11] + sumN099[11];
            N199lbl0.Text = simboloMoneda + sumN199[0].ToString(); N199lbl1.Text = simboloMoneda + sumN199[1].ToString(); N199lbl2.Text = simboloMoneda + sumN199[2].ToString();
            N199lbl3.Text = simboloMoneda + sumN199[3].ToString(); N199lbl4.Text = simboloMoneda + sumN199[4].ToString(); N199lbl5.Text = simboloMoneda + sumN199[5].ToString();
            N199lbl6.Text = simboloMoneda + sumN199[6].ToString(); N199lbl7.Text = simboloMoneda + sumN199[7].ToString(); N199lbl8.Text = simboloMoneda + sumN199[8].ToString();
            N199lbl9.Text = simboloMoneda + sumN199[9].ToString(); N199lbl10.Text = simboloMoneda + sumN199[10].ToString(); N199lbl11.Text = simboloMoneda + sumN199[11].ToString();

            sumN205 = mergeTables.GeTotalByTablePlan(JsonDatasetN205, moneda, false);
            N205lbl0.Text = simboloMoneda + sumN205[0].ToString(); N205lbl1.Text = simboloMoneda + sumN205[1].ToString(); N205lbl2.Text = simboloMoneda + sumN205[2].ToString();
            N205lbl3.Text = simboloMoneda + sumN205[3].ToString(); N205lbl4.Text = simboloMoneda + sumN205[4].ToString(); N205lbl5.Text = simboloMoneda + sumN205[5].ToString();
            N205lbl6.Text = simboloMoneda + sumN205[6].ToString(); N205lbl7.Text = simboloMoneda + sumN205[7].ToString(); N205lbl8.Text = simboloMoneda + sumN205[8].ToString();

            N205lbl9.Text = simboloMoneda + sumN205[9].ToString(); N205lbl10.Text = simboloMoneda + sumN205[10].ToString(); N205lbl11.Text = simboloMoneda + sumN205[11].ToString();
            sumN210 = mergeTables.GeTotalByTablePlan(JsonDatasetN210, moneda, false);
            N210lbl0.Text = simboloMoneda + sumN210[0].ToString(); N210lbl1.Text = simboloMoneda + sumN210[1].ToString(); N210lbl2.Text = simboloMoneda + sumN210[2].ToString();
            N210lbl3.Text = simboloMoneda + sumN210[3].ToString(); N210lbl4.Text = simboloMoneda + sumN210[4].ToString(); N210lbl5.Text = simboloMoneda + sumN210[5].ToString();
            N210lbl6.Text = simboloMoneda + sumN210[6].ToString(); N210lbl7.Text = simboloMoneda + sumN210[7].ToString(); N210lbl8.Text = simboloMoneda + sumN210[8].ToString();
            N210lbl9.Text = simboloMoneda + sumN210[9].ToString(); N210lbl10.Text = simboloMoneda + sumN210[10].ToString(); N210lbl11.Text = simboloMoneda + sumN210[11].ToString();

            sumN215 = mergeTables.GeTotalByTablePlan(JsonDatasetN215, moneda, false);
            N215lbl0.Text = simboloMoneda + sumN215[0].ToString(); N215lbl1.Text = simboloMoneda + sumN215[1].ToString(); N215lbl2.Text = simboloMoneda + sumN215[2].ToString();
            N215lbl3.Text = simboloMoneda + sumN215[3].ToString(); N215lbl4.Text = simboloMoneda + sumN215[4].ToString(); N215lbl5.Text = simboloMoneda + sumN215[5].ToString();
            N215lbl6.Text = simboloMoneda + sumN215[6].ToString(); N215lbl7.Text = simboloMoneda + sumN215[7].ToString(); N215lbl8.Text = simboloMoneda + sumN215[8].ToString();
            N215lbl9.Text = simboloMoneda + sumN215[9].ToString(); N215lbl10.Text = simboloMoneda + sumN215[10].ToString(); N215lbl11.Text = simboloMoneda + sumN215[11].ToString();

            sumN220 = mergeTables.GeTotalByTablePlan(JsonDatasetN220, moneda, false);
            N220lbl0.Text = simboloMoneda + sumN220[0].ToString(); N220lbl1.Text = simboloMoneda + sumN220[1].ToString(); N220lbl2.Text = simboloMoneda + sumN220[2].ToString();
            N220lbl3.Text = simboloMoneda + sumN220[3].ToString(); N220lbl4.Text = simboloMoneda + sumN220[4].ToString(); N220lbl5.Text = simboloMoneda + sumN220[5].ToString();
            N220lbl6.Text = simboloMoneda + sumN220[6].ToString(); N220lbl7.Text = simboloMoneda + sumN220[7].ToString(); N220lbl8.Text = simboloMoneda + sumN220[8].ToString();
            N220lbl9.Text = simboloMoneda + sumN220[9].ToString(); N220lbl10.Text = simboloMoneda + sumN220[10].ToString(); N220lbl11.Text = simboloMoneda + sumN220[11].ToString();

            sumN225 = mergeTables.GeTotalByTablePlan(JsonDatasetN225, moneda, false);
            N225lbl0.Text = simboloMoneda + sumN225[0].ToString(); N225lbl1.Text = simboloMoneda + sumN225[1].ToString(); N225lbl2.Text = simboloMoneda + sumN225[2].ToString();
            N225lbl3.Text = simboloMoneda + sumN225[3].ToString(); N225lbl4.Text = simboloMoneda + sumN225[4].ToString(); N225lbl5.Text = simboloMoneda + sumN225[5].ToString();
            N225lbl6.Text = simboloMoneda + sumN225[6].ToString(); N225lbl7.Text = simboloMoneda + sumN225[7].ToString(); N225lbl8.Text = simboloMoneda + sumN225[8].ToString();
            N225lbl9.Text = simboloMoneda + sumN225[9].ToString(); N225lbl10.Text = simboloMoneda + sumN225[10].ToString(); N225lbl11.Text = simboloMoneda + sumN225[11].ToString();

            sumN230 = mergeTables.GeTotalByTablePlan(JsonDatasetN230, moneda, false);
            N230lbl0.Text = simboloMoneda + sumN230[0].ToString(); N230lbl1.Text = simboloMoneda + sumN230[1].ToString(); N230lbl2.Text = simboloMoneda + sumN230[2].ToString();
            N230lbl3.Text = simboloMoneda + sumN230[3].ToString(); N230lbl4.Text = simboloMoneda + sumN230[4].ToString(); N230lbl5.Text = simboloMoneda + sumN230[5].ToString();
            N230lbl6.Text = simboloMoneda + sumN230[6].ToString(); N230lbl7.Text = simboloMoneda + sumN230[7].ToString(); N230lbl8.Text = simboloMoneda + sumN230[8].ToString();
            N230lbl9.Text = simboloMoneda + sumN230[9].ToString(); N230lbl10.Text = simboloMoneda + sumN230[10].ToString(); N230lbl11.Text = simboloMoneda + sumN230[11].ToString();

            sumN235 = mergeTables.GeTotalByTablePlan(JsonDatasetN235, moneda, false);
            N235lbl0.Text = simboloMoneda + sumN235[0].ToString(); N235lbl1.Text = simboloMoneda + sumN235[1].ToString(); N235lbl2.Text = simboloMoneda + sumN235[2].ToString();
            N235lbl3.Text = simboloMoneda + sumN235[3].ToString(); N235lbl4.Text = simboloMoneda + sumN235[4].ToString(); N235lbl5.Text = simboloMoneda + sumN235[5].ToString();
            N235lbl6.Text = simboloMoneda + sumN235[6].ToString(); N235lbl7.Text = simboloMoneda + sumN235[7].ToString(); N235lbl8.Text = simboloMoneda + sumN235[8].ToString();
            N235lbl9.Text = simboloMoneda + sumN235[9].ToString(); N235lbl10.Text = simboloMoneda + sumN235[10].ToString(); N235lbl11.Text = simboloMoneda + sumN235[11].ToString();

            sumN299[0] = sumN205[0] + sumN210[0] + sumN215[0] + sumN220[0] + sumN225[0] + sumN230[0] + sumN235[0] + sumN199[0]; sumN299[1] = sumN205[1] + sumN210[1] + sumN215[1] + sumN220[1] + sumN225[1] + sumN230[1] + sumN235[1] + sumN199[1];
            sumN299[2] = sumN205[2] + sumN210[2] + sumN215[2] + sumN220[2] + sumN225[2] + sumN230[2] + sumN235[2] + sumN199[2]; sumN299[3] = sumN205[3] + sumN210[3] + sumN215[3] + sumN220[3] + sumN225[3] + sumN230[3] + sumN235[3] + sumN199[3];
            sumN299[4] = sumN205[4] + sumN210[4] + sumN215[4] + sumN220[4] + sumN225[4] + sumN230[4] + sumN235[4] + sumN199[4]; sumN299[5] = sumN205[5] + sumN210[5] + sumN215[5] + sumN220[5] + sumN225[5] + sumN230[5] + sumN235[5] + sumN199[5];
            sumN299[6] = sumN205[6] + sumN210[6] + sumN215[6] + sumN220[6] + sumN225[6] + sumN230[6] + sumN235[6] + sumN199[6]; sumN299[7] = sumN205[7] + sumN210[7] + sumN215[7] + sumN220[7] + sumN225[7] + sumN230[7] + sumN235[7] + sumN199[7];
            sumN299[8] = sumN205[8] + sumN210[8] + sumN215[8] + sumN220[8] + sumN225[8] + sumN230[8] + sumN235[8] + sumN199[8]; sumN299[9] = sumN205[9] + sumN210[9] + sumN215[9] + sumN220[9] + sumN225[9] + sumN230[9] + sumN235[9] + sumN199[9];
            sumN299[10] = sumN205[10] + sumN210[10] + sumN215[10] + sumN220[10] + sumN225[10] + sumN230[10] + sumN235[10] + sumN199[10]; sumN299[11] = sumN205[11] + sumN210[11] + sumN215[11] + sumN220[11] + sumN225[11] + sumN230[11] + sumN235[11] + sumN199[11];

            N299lbl0.Text = simboloMoneda + sumN299[0].ToString(); N299lbl1.Text = simboloMoneda + sumN299[1].ToString(); N299lbl2.Text = simboloMoneda + sumN299[2].ToString();
            N299lbl3.Text = simboloMoneda + sumN299[3].ToString(); N299lbl4.Text = simboloMoneda + sumN299[4].ToString(); N299lbl5.Text = simboloMoneda + sumN299[5].ToString();
            N299lbl6.Text = simboloMoneda + sumN299[6].ToString(); N299lbl7.Text = simboloMoneda + sumN299[7].ToString(); N299lbl8.Text = simboloMoneda + sumN299[8].ToString();
            N299lbl9.Text = simboloMoneda + sumN299[9].ToString(); N299lbl10.Text = simboloMoneda + sumN299[10].ToString(); N299lbl11.Text = simboloMoneda + sumN299[11].ToString();

            sumN305 = mergeTables.GeTotalByTablePlan(JsonDatasetN305, moneda, false);
            N305lbl0.Text = simboloMoneda + sumN305[0].ToString(); N305lbl1.Text = simboloMoneda + sumN305[1].ToString(); N305lbl2.Text = simboloMoneda + sumN305[2].ToString();
            N305lbl3.Text = simboloMoneda + sumN305[3].ToString(); N305lbl4.Text = simboloMoneda + sumN305[4].ToString(); N305lbl5.Text = simboloMoneda + sumN305[5].ToString();
            N305lbl6.Text = simboloMoneda + sumN305[6].ToString(); N305lbl7.Text = simboloMoneda + sumN305[7].ToString(); N305lbl8.Text = simboloMoneda + sumN305[8].ToString();
            N305lbl9.Text = simboloMoneda + sumN305[9].ToString(); N305lbl10.Text = simboloMoneda + sumN305[10].ToString(); N305lbl11.Text = simboloMoneda + sumN305[11].ToString();
            sumN310 = mergeTables.GeTotalByTablePlan(JsonDatasetN310, moneda, false);
            N310lbl0.Text = simboloMoneda + sumN310[0].ToString(); N310lbl1.Text = simboloMoneda + sumN310[1].ToString(); N310lbl2.Text = simboloMoneda + sumN310[2].ToString();
            N310lbl3.Text = simboloMoneda + sumN310[3].ToString(); N310lbl4.Text = simboloMoneda + sumN310[4].ToString(); N310lbl5.Text = simboloMoneda + sumN310[5].ToString();
            N310lbl6.Text = simboloMoneda + sumN310[6].ToString(); N310lbl7.Text = simboloMoneda + sumN310[7].ToString(); N310lbl8.Text = simboloMoneda + sumN310[8].ToString();
            N310lbl9.Text = simboloMoneda + sumN310[9].ToString(); N310lbl10.Text = simboloMoneda + sumN310[10].ToString(); N310lbl11.Text = simboloMoneda + sumN310[11].ToString();
            sumN315 = mergeTables.GeTotalByTablePlan(JsonDatasetN315, moneda, false);
            N315lbl0.Text = simboloMoneda + sumN315[0].ToString(); N315lbl1.Text = simboloMoneda + sumN315[1].ToString(); N315lbl2.Text = simboloMoneda + sumN315[2].ToString();
            N315lbl3.Text = simboloMoneda + sumN315[3].ToString(); N315lbl4.Text = simboloMoneda + sumN315[4].ToString(); N315lbl5.Text = simboloMoneda + sumN315[5].ToString();
            N315lbl6.Text = simboloMoneda + sumN315[6].ToString(); N315lbl7.Text = simboloMoneda + sumN315[7].ToString(); N315lbl8.Text = simboloMoneda + sumN315[8].ToString();
            N315lbl9.Text = simboloMoneda + sumN315[9].ToString(); N315lbl10.Text = simboloMoneda + sumN315[10].ToString(); N315lbl11.Text = simboloMoneda + sumN315[11].ToString();

            sumN399[0] = sumN305[0] + sumN310[0] + sumN315[0] + sumN299[0]; sumN399[1] = sumN305[1] + sumN310[1] + sumN315[1] + sumN299[1];
            sumN399[2] = sumN305[2] + sumN310[2] + sumN315[2] + sumN299[2]; sumN399[3] = sumN305[3] + sumN310[3] + sumN315[3] + sumN299[3];
            sumN399[4] = sumN305[4] + sumN310[4] + sumN315[4] + sumN299[4]; sumN399[5] = sumN305[5] + sumN310[5] + sumN315[5] + sumN299[5];
            sumN399[6] = sumN305[6] + sumN310[6] + sumN315[6] + sumN299[6]; sumN399[7] = sumN305[7] + sumN310[7] + sumN315[7] + sumN299[7];
            sumN399[8] = sumN305[8] + sumN310[8] + sumN315[8] + sumN299[8]; sumN399[9] = sumN305[9] + sumN310[9] + sumN315[9] + sumN299[9];
            sumN399[10] = sumN305[10] + sumN310[10] + sumN315[10] + sumN299[10]; sumN399[11] = sumN305[11] + sumN310[11] + sumN315[11] + sumN299[11];
            N399lbl0.Text = simboloMoneda + sumN399[0].ToString(); N399lbl1.Text = simboloMoneda + sumN399[1].ToString(); N399lbl2.Text = simboloMoneda + sumN399[2].ToString();
            N399lbl3.Text = simboloMoneda + sumN399[3].ToString(); N399lbl4.Text = simboloMoneda + sumN399[4].ToString(); N399lbl5.Text = simboloMoneda + sumN399[5].ToString();
            N399lbl6.Text = simboloMoneda + sumN399[6].ToString(); N399lbl7.Text = simboloMoneda + sumN399[7].ToString(); N399lbl8.Text = simboloMoneda + sumN399[8].ToString();
            N399lbl9.Text = simboloMoneda + sumN399[9].ToString(); N399lbl10.Text = simboloMoneda + sumN399[10].ToString(); N399lbl11.Text = simboloMoneda + sumN399[11].ToString();

            sumN405 = mergeTables.GeTotalByTablePlan(JsonDatasetN405, moneda, false);
            N405lbl0.Text = simboloMoneda + sumN405[0].ToString(); N405lbl1.Text = simboloMoneda + sumN405[1].ToString(); N405lbl2.Text = simboloMoneda + sumN405[2].ToString();
            N405lbl3.Text = simboloMoneda + sumN405[3].ToString(); N405lbl4.Text = simboloMoneda + sumN405[4].ToString(); N405lbl5.Text = simboloMoneda + sumN405[5].ToString();
            N405lbl6.Text = simboloMoneda + sumN405[6].ToString(); N405lbl7.Text = simboloMoneda + sumN405[7].ToString(); N405lbl8.Text = simboloMoneda + sumN405[8].ToString();
            N405lbl9.Text = simboloMoneda + sumN405[9].ToString(); N405lbl10.Text = simboloMoneda + sumN405[10].ToString(); N405lbl11.Text = simboloMoneda + sumN405[11].ToString();
            sumN410 = mergeTables.GeTotalByTablePlan(JsonDatasetN410, moneda, false);
            N410lbl0.Text = simboloMoneda + sumN410[0].ToString(); N410lbl1.Text = simboloMoneda + sumN410[1].ToString(); N410lbl2.Text = simboloMoneda + sumN410[2].ToString();
            N410lbl3.Text = simboloMoneda + sumN410[3].ToString(); N410lbl4.Text = simboloMoneda + sumN410[4].ToString(); N410lbl5.Text = simboloMoneda + sumN410[5].ToString();
            N410lbl6.Text = simboloMoneda + sumN410[6].ToString(); N410lbl7.Text = simboloMoneda + sumN410[7].ToString(); N410lbl8.Text = simboloMoneda + sumN410[8].ToString();
            N410lbl9.Text = simboloMoneda + sumN410[9].ToString(); N410lbl10.Text = simboloMoneda + sumN410[10].ToString(); N410lbl11.Text = simboloMoneda + sumN410[11].ToString();
            sumN415 = mergeTables.GeTotalByTablePlan(JsonDatasetN415, moneda, false);
            N415lbl0.Text = simboloMoneda + sumN415[0].ToString(); N415lbl1.Text = simboloMoneda + sumN415[1].ToString(); N415lbl2.Text = simboloMoneda + sumN415[2].ToString();
            N415lbl3.Text = simboloMoneda + sumN415[3].ToString(); N415lbl4.Text = simboloMoneda + sumN415[4].ToString(); N415lbl5.Text = simboloMoneda + sumN415[5].ToString();
            N415lbl6.Text = simboloMoneda + sumN415[6].ToString(); N415lbl7.Text = simboloMoneda + sumN415[7].ToString(); N415lbl8.Text = simboloMoneda + sumN415[8].ToString();
            N415lbl9.Text = simboloMoneda + sumN415[9].ToString(); N415lbl10.Text = simboloMoneda + sumN415[10].ToString(); N415lbl11.Text = simboloMoneda + sumN415[11].ToString();
            sumN420 = mergeTables.GeTotalByTablePlan(JsonDatasetN420, moneda, false);
            N420lbl0.Text = simboloMoneda + sumN420[0].ToString(); N420lbl1.Text = simboloMoneda + sumN420[1].ToString(); N420lbl2.Text = simboloMoneda + sumN420[2].ToString();
            N420lbl3.Text = simboloMoneda + sumN420[3].ToString(); N420lbl4.Text = simboloMoneda + sumN420[4].ToString(); N420lbl5.Text = simboloMoneda + sumN420[5].ToString();
            N420lbl6.Text = simboloMoneda + sumN420[6].ToString(); N420lbl7.Text = simboloMoneda + sumN420[7].ToString(); N420lbl8.Text = simboloMoneda + sumN420[8].ToString();
            N420lbl9.Text = simboloMoneda + sumN420[9].ToString(); N420lbl10.Text = simboloMoneda + sumN420[10].ToString(); N420lbl11.Text = simboloMoneda + sumN420[11].ToString();
            sumN425 = mergeTables.GeTotalByTablePlan(JsonDatasetN425, moneda, false);
            N425lbl0.Text = simboloMoneda + sumN425[0].ToString(); N425lbl1.Text = simboloMoneda + sumN425[1].ToString(); N425lbl2.Text = simboloMoneda + sumN425[2].ToString();
            N425lbl3.Text = simboloMoneda + sumN425[3].ToString(); N425lbl4.Text = simboloMoneda + sumN425[4].ToString(); N425lbl5.Text = simboloMoneda + sumN425[5].ToString();
            N425lbl6.Text = simboloMoneda + sumN425[6].ToString(); N425lbl7.Text = simboloMoneda + sumN425[7].ToString(); N425lbl8.Text = simboloMoneda + sumN425[8].ToString();
            N425lbl9.Text = simboloMoneda + sumN425[9].ToString(); N425lbl10.Text = simboloMoneda + sumN425[10].ToString(); N425lbl11.Text = simboloMoneda + sumN425[11].ToString();
            sumN430 = mergeTables.GeTotalByTablePlan(JsonDatasetN430, moneda, false);
            N430lbl0.Text = simboloMoneda + sumN430[0].ToString(); N430lbl1.Text = simboloMoneda + sumN430[1].ToString(); N430lbl2.Text = simboloMoneda + sumN430[2].ToString();
            N430lbl3.Text = simboloMoneda + sumN430[3].ToString(); N430lbl4.Text = simboloMoneda + sumN430[4].ToString(); N430lbl5.Text = simboloMoneda + sumN430[5].ToString();
            N430lbl6.Text = simboloMoneda + sumN430[6].ToString(); N430lbl7.Text = simboloMoneda + sumN430[7].ToString(); N430lbl8.Text = simboloMoneda + sumN430[8].ToString();
            N430lbl9.Text = simboloMoneda + sumN430[9].ToString(); N430lbl10.Text = simboloMoneda + sumN430[10].ToString(); N430lbl11.Text = simboloMoneda + sumN430[11].ToString();

            sumN499[0] = sumN405[0] + sumN410[0] + sumN415[0] + sumN420[0] + sumN425[0] + sumN430[0] + sumN399[0]; sumN499[1] = sumN405[1] + sumN410[1] + sumN415[1] + sumN420[1] + sumN425[1] + sumN430[1] + sumN399[1];
            sumN499[2] = sumN405[2] + sumN410[2] + sumN415[2] + sumN420[2] + sumN425[2] + sumN430[2] + sumN399[2]; sumN499[3] = sumN405[3] + sumN410[3] + sumN415[3] + sumN420[3] + sumN425[3] + sumN430[3] + sumN399[3];
            sumN499[4] = sumN405[4] + sumN410[4] + sumN415[4] + sumN420[4] + sumN425[4] + sumN430[4] + sumN399[4]; sumN499[5] = sumN405[5] + sumN410[5] + sumN415[5] + sumN420[5] + sumN425[5] + sumN430[5] + sumN399[5];
            sumN499[6] = sumN405[6] + sumN410[6] + sumN415[6] + sumN420[6] + sumN425[6] + sumN430[6] + sumN399[6]; sumN499[7] = sumN405[7] + sumN410[7] + sumN415[7] + sumN420[7] + sumN425[7] + sumN430[7] + sumN399[7];
            sumN499[8] = sumN405[8] + sumN410[8] + sumN415[8] + sumN420[8] + sumN425[8] + sumN430[8] + sumN399[8]; sumN499[9] = sumN405[9] + sumN410[9] + sumN415[9] + sumN420[9] + sumN425[9] + sumN430[9] + sumN399[9];
            sumN499[10] = sumN405[10] + sumN410[10] + sumN415[10] + sumN420[10] + sumN425[10] + sumN430[10] + sumN399[10]; sumN499[11] = sumN405[11] + sumN410[11] + sumN415[11] + sumN420[11] + sumN425[11] + sumN430[11] + sumN399[11];

            N499lbl0.Text = simboloMoneda + sumN499[0].ToString(); N499lbl1.Text = simboloMoneda + sumN499[1].ToString(); N499lbl2.Text = simboloMoneda + sumN499[2].ToString();
            N499lbl3.Text = simboloMoneda + sumN499[3].ToString(); N499lbl4.Text = simboloMoneda + sumN499[4].ToString(); N499lbl5.Text = simboloMoneda + sumN499[5].ToString();
            N499lbl6.Text = simboloMoneda + sumN499[6].ToString(); N499lbl7.Text = simboloMoneda + sumN499[7].ToString(); N499lbl8.Text = simboloMoneda + sumN499[8].ToString();
            N499lbl9.Text = simboloMoneda + sumN499[9].ToString(); N499lbl10.Text = simboloMoneda + sumN499[10].ToString(); N499lbl11.Text = simboloMoneda + sumN499[11].ToString();

            sumN505 = mergeTables.GeTotalByTablePlan(JsonDatasetN505, moneda, false);
            N505lbl0.Text = simboloMoneda + sumN505[0].ToString(); N505lbl1.Text = simboloMoneda + sumN505[1].ToString(); N505lbl2.Text = simboloMoneda + sumN505[2].ToString();
            N505lbl3.Text = simboloMoneda + sumN505[3].ToString(); N505lbl4.Text = simboloMoneda + sumN505[4].ToString(); N505lbl5.Text = simboloMoneda + sumN505[5].ToString();
            N505lbl6.Text = simboloMoneda + sumN505[6].ToString(); N505lbl7.Text = simboloMoneda + sumN505[7].ToString(); N505lbl8.Text = simboloMoneda + sumN505[8].ToString();
            N505lbl9.Text = simboloMoneda + sumN505[9].ToString(); N505lbl10.Text = simboloMoneda + sumN505[10].ToString(); N505lbl11.Text = simboloMoneda + sumN505[11].ToString();
            sumN510 = mergeTables.GeTotalByTablePlan(JsonDatasetN510, moneda, false);
            N510lbl0.Text = simboloMoneda + sumN510[0].ToString(); N510lbl1.Text = simboloMoneda + sumN510[1].ToString(); N510lbl2.Text = simboloMoneda + sumN510[2].ToString();
            N510lbl3.Text = simboloMoneda + sumN510[3].ToString(); N510lbl4.Text = simboloMoneda + sumN510[4].ToString(); N510lbl5.Text = simboloMoneda + sumN510[5].ToString();
            N510lbl6.Text = simboloMoneda + sumN510[6].ToString(); N510lbl7.Text = simboloMoneda + sumN510[7].ToString(); N510lbl8.Text = simboloMoneda + sumN510[8].ToString();
            N510lbl9.Text = simboloMoneda + sumN510[9].ToString(); N510lbl10.Text = simboloMoneda + sumN510[10].ToString(); N510lbl11.Text = simboloMoneda + sumN510[11].ToString();
            sumN515 = mergeTables.GeTotalByTablePlan(JsonDatasetN515, moneda, false);
            N515lbl0.Text = simboloMoneda + sumN515[0].ToString(); N515lbl1.Text = simboloMoneda + sumN515[1].ToString(); N515lbl2.Text = simboloMoneda + sumN515[2].ToString();
            N515lbl3.Text = simboloMoneda + sumN515[3].ToString(); N515lbl4.Text = simboloMoneda + sumN515[4].ToString(); N515lbl5.Text = simboloMoneda + sumN515[5].ToString();
            N515lbl6.Text = simboloMoneda + sumN515[6].ToString(); N515lbl7.Text = simboloMoneda + sumN515[7].ToString(); N515lbl8.Text = simboloMoneda + sumN515[8].ToString();
            N515lbl9.Text = simboloMoneda + sumN515[9].ToString(); N515lbl10.Text = simboloMoneda + sumN515[10].ToString(); N515lbl11.Text = simboloMoneda + sumN515[11].ToString();
            sumN520 = mergeTables.GeTotalByTablePlan(JsonDatasetN520, moneda, false);
            N520lbl0.Text = simboloMoneda + sumN520[0].ToString(); N520lbl1.Text = simboloMoneda + sumN520[1].ToString(); N520lbl2.Text = simboloMoneda + sumN520[2].ToString();
            N520lbl3.Text = simboloMoneda + sumN520[3].ToString(); N520lbl4.Text = simboloMoneda + sumN520[4].ToString(); N520lbl5.Text = simboloMoneda + sumN520[5].ToString();
            N520lbl6.Text = simboloMoneda + sumN520[6].ToString(); N520lbl7.Text = simboloMoneda + sumN520[7].ToString(); N520lbl8.Text = simboloMoneda + sumN520[8].ToString();
            N520lbl9.Text = simboloMoneda + sumN520[9].ToString(); N520lbl10.Text = simboloMoneda + sumN520[10].ToString(); N520lbl11.Text = simboloMoneda + sumN520[11].ToString();
            sumN525 = mergeTables.GeTotalByTablePlan(JsonDatasetN525, moneda, false);
            N525lbl0.Text = simboloMoneda + sumN525[0].ToString(); N525lbl1.Text = simboloMoneda + sumN525[1].ToString(); N525lbl2.Text = simboloMoneda + sumN525[2].ToString();
            N525lbl3.Text = simboloMoneda + sumN525[3].ToString(); N525lbl4.Text = simboloMoneda + sumN525[4].ToString(); N525lbl5.Text = simboloMoneda + sumN525[5].ToString();
            N525lbl6.Text = simboloMoneda + sumN525[6].ToString(); N525lbl7.Text = simboloMoneda + sumN525[7].ToString(); N525lbl8.Text = simboloMoneda + sumN525[8].ToString();
            N525lbl9.Text = simboloMoneda + sumN525[9].ToString(); N525lbl10.Text = simboloMoneda + sumN525[10].ToString(); N525lbl11.Text = simboloMoneda + sumN525[11].ToString();

            sumN599[0] = sumN505[0] + sumN510[0] + sumN515[0] + sumN520[0] + sumN525[0] + sumN499[0]; sumN599[1] = sumN505[1] + sumN510[1] + sumN515[1] + sumN520[1] + sumN525[1] + sumN499[1];
            sumN599[2] = sumN505[2] + sumN510[2] + sumN515[2] + sumN520[2] + sumN525[2] + sumN499[2]; sumN599[3] = sumN505[3] + sumN510[3] + sumN515[3] + sumN520[3] + sumN525[3] + sumN499[3];
            sumN599[4] = sumN505[4] + sumN510[4] + sumN515[4] + sumN520[4] + sumN525[4] + sumN499[4]; sumN599[5] = sumN505[5] + sumN510[5] + sumN515[5] + sumN520[5] + sumN525[5] + sumN499[5];
            sumN599[6] = sumN505[6] + sumN510[6] + sumN515[6] + sumN520[6] + sumN525[6] + sumN499[6]; sumN599[7] = sumN505[7] + sumN510[7] + sumN515[7] + sumN520[7] + sumN525[7] + sumN499[7];
            sumN599[8] = sumN505[8] + sumN510[8] + sumN515[8] + sumN520[8] + sumN525[8] + sumN499[8]; sumN599[9] = sumN505[9] + sumN510[9] + sumN515[9] + sumN520[9] + sumN525[9] + sumN499[9];
            sumN599[10] = sumN505[10] + sumN510[10] + sumN515[10] + sumN520[10] + sumN525[10] + sumN499[10]; sumN599[11] = sumN505[11] + sumN510[11] + sumN515[11] + sumN520[11] + sumN525[11] + sumN499[11];

            N599lbl0.Text = simboloMoneda + sumN599[0].ToString(); N599lbl1.Text = simboloMoneda + sumN599[1].ToString(); N599lbl2.Text = simboloMoneda + sumN599[2].ToString();
            N599lbl3.Text = simboloMoneda + sumN599[3].ToString(); N599lbl4.Text = simboloMoneda + sumN599[4].ToString(); N599lbl5.Text = simboloMoneda + sumN599[5].ToString();
            N599lbl6.Text = simboloMoneda + sumN599[6].ToString(); N599lbl7.Text = simboloMoneda + sumN599[7].ToString(); N599lbl8.Text = simboloMoneda + sumN599[8].ToString();
            N599lbl9.Text = simboloMoneda + sumN599[9].ToString(); N599lbl10.Text = simboloMoneda + sumN599[10].ToString(); N599lbl11.Text = simboloMoneda + sumN599[11].ToString();
            
            sumN805 = mergeTables.GeTotalByTablePlan(JsonDatasetN805, moneda, false);
            N805lbl0.Text = simboloMoneda + sumN805[0].ToString(); N805lbl1.Text = simboloMoneda + sumN805[1].ToString(); N805lbl2.Text = simboloMoneda + sumN805[2].ToString();
            N805lbl3.Text = simboloMoneda + sumN805[3].ToString(); N805lbl4.Text = simboloMoneda + sumN805[4].ToString(); N805lbl5.Text = simboloMoneda + sumN805[5].ToString();
            N805lbl6.Text = simboloMoneda + sumN805[6].ToString(); N805lbl7.Text = simboloMoneda + sumN805[7].ToString(); N805lbl8.Text = simboloMoneda + sumN805[8].ToString();
            N805lbl9.Text = simboloMoneda + sumN805[9].ToString(); N805lbl10.Text = simboloMoneda + sumN805[10].ToString(); N805lbl11.Text = simboloMoneda + sumN805[11].ToString();

            sumN810 = mergeTables.GeTotalByTablePlan(JsonDatasetN810, moneda, false);
            N810lbl0.Text = simboloMoneda + sumN810[0].ToString(); N810lbl1.Text = simboloMoneda + sumN810[1].ToString(); N810lbl2.Text = simboloMoneda + sumN810[2].ToString();
            N810lbl3.Text = simboloMoneda + sumN810[3].ToString(); N810lbl4.Text = simboloMoneda + sumN810[4].ToString(); N810lbl5.Text = simboloMoneda + sumN810[5].ToString();
            N810lbl6.Text = simboloMoneda + sumN810[6].ToString(); N810lbl7.Text = simboloMoneda + sumN810[7].ToString(); N810lbl8.Text = simboloMoneda + sumN810[8].ToString();
            N810lbl9.Text = simboloMoneda + sumN810[9].ToString(); N810lbl10.Text = simboloMoneda + sumN810[10].ToString(); N810lbl11.Text = simboloMoneda + sumN810[11].ToString();

            sumN999[0] = sumN805[0] + sumN810[0] + sumN599[0]; sumN999[1] = sumN805[1] + sumN810[1] + sumN599[1];
            sumN999[2] = sumN805[2] + sumN810[2] + sumN599[2]; sumN999[3] = sumN805[3] + sumN810[3] + sumN599[3];
            sumN999[4] = sumN805[4] + sumN810[4] + sumN599[4]; sumN999[5] = sumN805[5] + sumN810[5] + sumN599[5];
            sumN999[6] = sumN805[6] + sumN810[6] + sumN599[6]; sumN999[7] = sumN805[7] + sumN810[7] + sumN599[7];
            sumN999[8] = sumN805[8] + sumN810[8] + sumN599[8]; sumN999[9] = sumN805[9] + sumN810[9] + sumN599[9];
            sumN999[10] = sumN805[10] + sumN810[10] + sumN599[10]; sumN999[11] = sumN805[11] + sumN810[11] + sumN599[11];
            N999lbl0.Text = simboloMoneda + sumN999[0].ToString(); N999lbl1.Text = simboloMoneda + sumN999[1].ToString(); N999lbl2.Text = simboloMoneda + sumN999[2].ToString();
            N999lbl3.Text = simboloMoneda + sumN999[3].ToString(); N999lbl4.Text = simboloMoneda + sumN999[4].ToString(); N999lbl5.Text = simboloMoneda + sumN999[5].ToString();
            N999lbl6.Text = simboloMoneda + sumN999[6].ToString(); N999lbl7.Text = simboloMoneda + sumN999[7].ToString(); N999lbl8.Text = simboloMoneda + sumN999[8].ToString();
            N999lbl9.Text = simboloMoneda + sumN999[9].ToString(); N999lbl10.Text = simboloMoneda + sumN999[10].ToString(); N999lbl11.Text = simboloMoneda + sumN999[11].ToString();
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