using System;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class EstadoResultadoPMSF : System.Web.UI.Page
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
                GetEstadoResultadoFuncion(true);
            else
                GetEstadoResultadoFuncion(false);
        }
        //Jorge Luis|08/01/2017|RW-103
        /*Método para */
        public void GetEstadoResultadoFuncion(bool moneda)
        {
            string simboloMoneda = "S/ ";
            string JsonDatasetF005 = GetPathFile("F005");       string JsonDatasetF105 = GetPathFile("F105");
            string JsonDatasetF206 = GetPathFile("F206");       string JsonDatasetF211 = GetPathFile("F211");
            string JsonDatasetF212 = GetPathFile("F212");       string JsonDatasetF213 = GetPathFile("F213");
            string JsonDatasetF214 = GetPathFile("F214");       string JsonDatasetF215 = GetPathFile("F215");
            string JsonDatasetF320 = GetPathFile("F320");       string JsonDatasetF350 = GetPathFile("F350");
            string JsonDatasetF380 = GetPathFile("F380");       string JsonDatasetF403 = GetPathFile("F403");
            string JsonDatasetF405 = GetPathFile("F405");       string JsonDatasetF415 = GetPathFile("F415");
            string JsonDatasetF710 = GetPathFile("F710");       string JsonDatasetF805 = GetPathFile("F805");

            decimal[] sumF005 = new decimal[12];                decimal[] sumF105 = new decimal[12];
            decimal[] sumF199 = new decimal[12];                decimal[] sumF206 = new decimal[12];
            decimal[] sumF211 = new decimal[12];                decimal[] sumF212 = new decimal[12];
            decimal[] sumF213 = new decimal[12];                decimal[] sumF214 = new decimal[12];
            decimal[] sumF215 = new decimal[12];                decimal[] sumF299 = new decimal[12];
            decimal[] sumF320 = new decimal[12];                decimal[] sumF350 = new decimal[12];
            decimal[] sumF380 = new decimal[12];                decimal[] sumF403 = new decimal[12];
            decimal[] sumF405 = new decimal[12];                decimal[] sumF415 = new decimal[12];
            decimal[] sumF699 = new decimal[12];                decimal[] sumF710 = new decimal[12];
            decimal[] sumF799 = new decimal[12];                decimal[] sumF805 = new decimal[12];
            decimal[] sumF999 = new decimal[12];

            if (!moneda)                    // Moneda: Dólares
            { simboloMoneda = "$ "; }

            sumF005 = mergeTables.GeTotalByTablePlan(JsonDatasetF005, moneda);
            F005lbl0.Text = simboloMoneda + sumF005[0].ToString(); F005lbl1.Text = simboloMoneda + sumF005[1].ToString(); F005lbl2.Text = simboloMoneda + sumF005[2].ToString();
            F005lbl3.Text = simboloMoneda + sumF005[3].ToString(); F005lbl4.Text = simboloMoneda + sumF005[4].ToString(); F005lbl5.Text = simboloMoneda + sumF005[5].ToString();
            F005lbl6.Text = simboloMoneda + sumF005[6].ToString(); F005lbl7.Text = simboloMoneda + sumF005[7].ToString(); F005lbl8.Text = simboloMoneda + sumF005[8].ToString();
            F005lbl9.Text = simboloMoneda + sumF005[9].ToString(); F005lbl10.Text = simboloMoneda + sumF005[10].ToString(); F005lbl11.Text = simboloMoneda + sumF005[11].ToString();

            sumF105 = mergeTables.GeTotalByTablePlan(JsonDatasetF105, moneda);
            F105lbl0.Text = simboloMoneda + sumF105[0].ToString(); F105lbl1.Text = simboloMoneda + sumF105[1].ToString(); F105lbl2.Text = simboloMoneda + sumF105[2].ToString();
            F105lbl3.Text = simboloMoneda + sumF105[3].ToString(); F105lbl4.Text = simboloMoneda + sumF105[4].ToString(); F105lbl5.Text = simboloMoneda + sumF105[5].ToString();
            F105lbl6.Text = simboloMoneda + sumF105[6].ToString(); F105lbl7.Text = simboloMoneda + sumF105[7].ToString(); F105lbl8.Text = simboloMoneda + sumF105[8].ToString();
            F105lbl9.Text = simboloMoneda + sumF105[9].ToString(); F105lbl10.Text = simboloMoneda + sumF105[10].ToString(); F105lbl11.Text = simboloMoneda + sumF105[11].ToString();

            sumF199[0] = sumF005[0] + sumF105[0]; sumF199[1] = sumF005[1] + sumF105[1];
            sumF199[2] = sumF005[2] + sumF105[2]; sumF199[3] = sumF005[3] + sumF105[3];
            sumF199[4] = sumF005[4] + sumF105[4]; sumF199[5] = sumF005[5] + sumF105[5];
            sumF199[6] = sumF005[6] + sumF105[6]; sumF199[7] = sumF005[7] + sumF105[7];
            sumF199[8] = sumF005[8] + sumF105[8]; sumF199[9] = sumF005[9] + sumF105[9];
            sumF199[10] = sumF005[10] + sumF105[10]; sumF199[11] = sumF005[11] + sumF105[11];
            F199lbl0.Text = simboloMoneda + sumF199[0].ToString(); F199lbl1.Text = simboloMoneda + sumF199[1].ToString(); F199lbl2.Text = simboloMoneda + sumF199[2].ToString();
            F199lbl3.Text = simboloMoneda + sumF199[3].ToString(); F199lbl4.Text = simboloMoneda + sumF199[4].ToString(); F199lbl5.Text = simboloMoneda + sumF199[5].ToString();
            F199lbl6.Text = simboloMoneda + sumF199[6].ToString(); F199lbl7.Text = simboloMoneda + sumF199[7].ToString(); F199lbl8.Text = simboloMoneda + sumF199[8].ToString();
            F199lbl9.Text = simboloMoneda + sumF199[9].ToString(); F199lbl10.Text = simboloMoneda + sumF199[10].ToString(); F199lbl11.Text = simboloMoneda + sumF199[11].ToString();

            sumF206 = mergeTables.GeTotalByTablePlan(JsonDatasetF206, moneda);
            F206lbl0.Text = simboloMoneda + sumF206[0].ToString(); F206lbl1.Text = simboloMoneda + sumF206[1].ToString(); F206lbl2.Text = simboloMoneda + sumF206[2].ToString();
            F206lbl3.Text = simboloMoneda + sumF206[3].ToString(); F206lbl4.Text = simboloMoneda + sumF206[4].ToString(); F206lbl5.Text = simboloMoneda + sumF206[5].ToString();
            F206lbl6.Text = simboloMoneda + sumF206[6].ToString(); F206lbl7.Text = simboloMoneda + sumF206[7].ToString(); F206lbl8.Text = simboloMoneda + sumF206[8].ToString();
            F206lbl9.Text = simboloMoneda + sumF206[9].ToString(); F206lbl10.Text = simboloMoneda + sumF206[10].ToString(); F206lbl11.Text = simboloMoneda + sumF206[11].ToString();

            sumF211 = mergeTables.GeTotalByTablePlan(JsonDatasetF211, moneda);
            F211lbl0.Text = simboloMoneda + sumF211[0].ToString(); F211lbl1.Text = simboloMoneda + sumF211[1].ToString(); F211lbl2.Text = simboloMoneda + sumF211[2].ToString();
            F211lbl3.Text = simboloMoneda + sumF211[3].ToString(); F211lbl4.Text = simboloMoneda + sumF211[4].ToString(); F211lbl5.Text = simboloMoneda + sumF211[5].ToString();
            F211lbl6.Text = simboloMoneda + sumF211[6].ToString(); F211lbl7.Text = simboloMoneda + sumF211[7].ToString(); F211lbl8.Text = simboloMoneda + sumF211[8].ToString();
            F211lbl9.Text = simboloMoneda + sumF211[9].ToString(); F211lbl10.Text = simboloMoneda + sumF211[10].ToString(); F211lbl11.Text = simboloMoneda + sumF211[11].ToString();

            sumF212 = mergeTables.GeTotalByTablePlan(JsonDatasetF212, moneda);
            F212lbl0.Text = simboloMoneda + sumF212[0].ToString(); F212lbl1.Text = simboloMoneda + sumF212[1].ToString(); F212lbl2.Text = simboloMoneda + sumF212[2].ToString();
            F212lbl3.Text = simboloMoneda + sumF212[3].ToString(); F212lbl4.Text = simboloMoneda + sumF212[4].ToString(); F212lbl5.Text = simboloMoneda + sumF212[5].ToString();
            F212lbl6.Text = simboloMoneda + sumF212[6].ToString(); F212lbl7.Text = simboloMoneda + sumF212[7].ToString(); F212lbl8.Text = simboloMoneda + sumF212[8].ToString();
            F212lbl9.Text = simboloMoneda + sumF212[9].ToString(); F212lbl10.Text = simboloMoneda + sumF212[10].ToString(); F212lbl11.Text = simboloMoneda + sumF212[11].ToString();

            sumF213 = mergeTables.GeTotalByTablePlan(JsonDatasetF213, moneda);
            F213lbl0.Text = simboloMoneda + sumF213[0].ToString(); F213lbl1.Text = simboloMoneda + sumF213[1].ToString(); F213lbl2.Text = simboloMoneda + sumF213[2].ToString();
            F213lbl3.Text = simboloMoneda + sumF213[3].ToString(); F213lbl4.Text = simboloMoneda + sumF213[4].ToString(); F213lbl5.Text = simboloMoneda + sumF213[5].ToString();
            F213lbl6.Text = simboloMoneda + sumF213[6].ToString(); F213lbl7.Text = simboloMoneda + sumF213[7].ToString(); F213lbl8.Text = simboloMoneda + sumF213[8].ToString();
            F213lbl9.Text = simboloMoneda + sumF213[9].ToString(); F213lbl10.Text = simboloMoneda + sumF213[10].ToString(); F213lbl11.Text = simboloMoneda + sumF213[11].ToString();

            sumF214 = mergeTables.GeTotalByTablePlan(JsonDatasetF214, moneda);
            F214lbl0.Text = simboloMoneda + sumF214[0].ToString(); F214lbl1.Text = simboloMoneda + sumF214[1].ToString(); F214lbl2.Text = simboloMoneda + sumF214[2].ToString();
            F214lbl3.Text = simboloMoneda + sumF214[3].ToString(); F214lbl4.Text = simboloMoneda + sumF214[4].ToString(); F214lbl5.Text = simboloMoneda + sumF214[5].ToString();
            F214lbl6.Text = simboloMoneda + sumF214[6].ToString(); F214lbl7.Text = simboloMoneda + sumF214[7].ToString(); F214lbl8.Text = simboloMoneda + sumF214[8].ToString();
            F214lbl9.Text = simboloMoneda + sumF214[9].ToString(); F214lbl10.Text = simboloMoneda + sumF214[10].ToString(); F214lbl11.Text = simboloMoneda + sumF214[11].ToString();

            sumF215 = mergeTables.GeTotalByTablePlan(JsonDatasetF215, moneda);
            F215lbl0.Text = simboloMoneda + sumF215[0].ToString(); F215lbl1.Text = simboloMoneda + sumF215[1].ToString(); F215lbl2.Text = simboloMoneda + sumF215[2].ToString();
            F215lbl3.Text = simboloMoneda + sumF215[3].ToString(); F215lbl4.Text = simboloMoneda + sumF215[4].ToString(); F215lbl5.Text = simboloMoneda + sumF215[5].ToString();
            F215lbl6.Text = simboloMoneda + sumF215[6].ToString(); F215lbl7.Text = simboloMoneda + sumF215[7].ToString(); F215lbl8.Text = simboloMoneda + sumF215[8].ToString();
            F215lbl9.Text = simboloMoneda + sumF215[9].ToString(); F215lbl10.Text = simboloMoneda + sumF215[10].ToString(); F215lbl11.Text = simboloMoneda + sumF215[11].ToString();

            sumF299[0] = sumF206[0] + sumF211[0] + sumF212[0] + sumF213[0] + sumF214[0] + sumF215[0] + sumF199[0]; sumF299[1] = sumF206[1] + sumF211[1] + sumF212[1] + sumF213[1] + sumF214[1] + sumF215[1] + sumF199[1];
            sumF299[2] = sumF206[2] + sumF211[2] + sumF212[2] + sumF213[2] + sumF214[2] + sumF215[2] + sumF199[2]; sumF299[3] = sumF206[3] + sumF211[3] + sumF212[3] + sumF213[3] + sumF214[3] + sumF215[3] + sumF199[3];
            sumF299[4] = sumF206[4] + sumF211[4] + sumF212[4] + sumF213[4] + sumF214[4] + sumF215[4] + sumF199[4]; sumF299[5] = sumF206[5] + sumF211[5] + sumF212[5] + sumF213[5] + sumF214[5] + sumF215[5] + sumF199[5];
            sumF299[6] = sumF206[6] + sumF211[6] + sumF212[6] + sumF213[6] + sumF214[6] + sumF215[6] + sumF199[6]; sumF299[7] = sumF206[7] + sumF211[7] + sumF212[7] + sumF213[7] + sumF214[7] + sumF215[7] + sumF199[7];
            sumF299[8] = sumF206[8] + sumF211[8] + sumF212[8] + sumF213[8] + sumF214[8] + sumF215[8] + sumF199[8]; sumF299[9] = sumF206[9] + sumF211[9] + sumF212[9] + sumF213[9] + sumF214[9] + sumF215[9] + sumF199[9];
            sumF299[10] = sumF206[10] + sumF211[10] + sumF212[10] + sumF213[10] + sumF214[10] + sumF215[10] + sumF199[10]; sumF299[11] = sumF206[11] + sumF211[11] + sumF212[11] + sumF213[11] + sumF214[11] + sumF215[11] + sumF199[11];
            F299lbl0.Text = simboloMoneda + sumF299[0].ToString(); F299lbl1.Text = simboloMoneda + sumF299[1].ToString(); F299lbl2.Text = simboloMoneda + sumF299[2].ToString();
            F299lbl3.Text = simboloMoneda + sumF299[3].ToString(); F299lbl4.Text = simboloMoneda + sumF299[4].ToString(); F299lbl5.Text = simboloMoneda + sumF299[5].ToString();
            F299lbl6.Text = simboloMoneda + sumF299[6].ToString(); F299lbl7.Text = simboloMoneda + sumF299[7].ToString(); F299lbl8.Text = simboloMoneda + sumF299[8].ToString();
            F299lbl9.Text = simboloMoneda + sumF299[9].ToString(); F299lbl10.Text = simboloMoneda + sumF299[10].ToString(); F299lbl11.Text = simboloMoneda + sumF299[11].ToString();

            sumF320 = mergeTables.GeTotalByTablePlan(JsonDatasetF320, moneda);
            F320lbl0.Text = simboloMoneda + sumF320[0].ToString(); F320lbl1.Text = simboloMoneda + sumF320[1].ToString(); F320lbl2.Text = simboloMoneda + sumF320[2].ToString();
            F320lbl3.Text = simboloMoneda + sumF320[3].ToString(); F320lbl4.Text = simboloMoneda + sumF320[4].ToString(); F320lbl5.Text = simboloMoneda + sumF320[5].ToString();
            F320lbl6.Text = simboloMoneda + sumF320[6].ToString(); F320lbl7.Text = simboloMoneda + sumF320[7].ToString(); F320lbl8.Text = simboloMoneda + sumF320[8].ToString();
            F320lbl9.Text = simboloMoneda + sumF320[9].ToString(); F320lbl10.Text = simboloMoneda + sumF320[10].ToString(); F320lbl11.Text = simboloMoneda + sumF320[11].ToString();

            sumF350 = mergeTables.GeTotalByTablePlan(JsonDatasetF350, moneda);
            F350lbl0.Text = simboloMoneda + sumF350[0].ToString(); F350lbl1.Text = simboloMoneda + sumF350[1].ToString(); F350lbl2.Text = simboloMoneda + sumF350[2].ToString();
            F350lbl3.Text = simboloMoneda + sumF350[3].ToString(); F350lbl4.Text = simboloMoneda + sumF350[4].ToString(); F350lbl5.Text = simboloMoneda + sumF350[5].ToString();
            F350lbl6.Text = simboloMoneda + sumF350[6].ToString(); F350lbl7.Text = simboloMoneda + sumF350[7].ToString(); F350lbl8.Text = simboloMoneda + sumF350[8].ToString();
            F350lbl9.Text = simboloMoneda + sumF350[9].ToString(); F350lbl10.Text = simboloMoneda + sumF350[10].ToString(); F350lbl11.Text = simboloMoneda + sumF350[11].ToString();

            sumF380 = mergeTables.GeTotalByTablePlan(JsonDatasetF380, moneda);
            F380lbl0.Text = simboloMoneda + sumF380[0].ToString(); F380lbl1.Text = simboloMoneda + sumF380[1].ToString(); F380lbl2.Text = simboloMoneda + sumF380[2].ToString();
            F380lbl3.Text = simboloMoneda + sumF380[3].ToString(); F380lbl4.Text = simboloMoneda + sumF380[4].ToString(); F380lbl5.Text = simboloMoneda + sumF380[5].ToString();
            F380lbl6.Text = simboloMoneda + sumF380[6].ToString(); F380lbl7.Text = simboloMoneda + sumF380[7].ToString(); F380lbl8.Text = simboloMoneda + sumF380[8].ToString();
            F380lbl9.Text = simboloMoneda + sumF380[9].ToString(); F380lbl10.Text = simboloMoneda + sumF380[10].ToString(); F380lbl11.Text = simboloMoneda + sumF380[11].ToString();

            sumF403 = mergeTables.GeTotalByTablePlan(JsonDatasetF403, moneda);
            F403lbl0.Text = simboloMoneda + sumF403[0].ToString(); F403lbl1.Text = simboloMoneda + sumF403[1].ToString(); F403lbl2.Text = simboloMoneda + sumF403[2].ToString();
            F403lbl3.Text = simboloMoneda + sumF403[3].ToString(); F403lbl4.Text = simboloMoneda + sumF403[4].ToString(); F403lbl5.Text = simboloMoneda + sumF403[5].ToString();
            F403lbl6.Text = simboloMoneda + sumF403[6].ToString(); F403lbl7.Text = simboloMoneda + sumF403[7].ToString(); F403lbl8.Text = simboloMoneda + sumF403[8].ToString();
            F403lbl9.Text = simboloMoneda + sumF403[9].ToString(); F403lbl10.Text = simboloMoneda + sumF403[10].ToString(); F403lbl11.Text = simboloMoneda + sumF403[11].ToString();

            sumF405 = mergeTables.GeTotalByTablePlan(JsonDatasetF405, moneda);
            F405lbl0.Text = simboloMoneda + sumF405[0].ToString(); F405lbl1.Text = simboloMoneda + sumF405[1].ToString(); F405lbl2.Text = simboloMoneda + sumF405[2].ToString();
            F405lbl3.Text = simboloMoneda + sumF405[3].ToString(); F405lbl4.Text = simboloMoneda + sumF405[4].ToString(); F405lbl5.Text = simboloMoneda + sumF405[5].ToString();
            F405lbl6.Text = simboloMoneda + sumF405[6].ToString(); F405lbl7.Text = simboloMoneda + sumF405[7].ToString(); F405lbl8.Text = simboloMoneda + sumF405[8].ToString();
            F405lbl9.Text = simboloMoneda + sumF405[9].ToString(); F405lbl10.Text = simboloMoneda + sumF405[10].ToString(); F405lbl11.Text = simboloMoneda + sumF405[11].ToString();

            sumF415 = mergeTables.GeTotalByTablePlan(JsonDatasetF415, moneda);
            F415lbl0.Text = simboloMoneda + sumF415[0].ToString(); F415lbl1.Text = simboloMoneda + sumF415[1].ToString(); F415lbl2.Text = simboloMoneda + sumF415[2].ToString();
            F415lbl3.Text = simboloMoneda + sumF415[3].ToString(); F415lbl4.Text = simboloMoneda + sumF415[4].ToString(); F415lbl5.Text = simboloMoneda + sumF415[5].ToString();
            F415lbl6.Text = simboloMoneda + sumF415[6].ToString(); F415lbl7.Text = simboloMoneda + sumF415[7].ToString(); F415lbl8.Text = simboloMoneda + sumF415[8].ToString();
            F415lbl9.Text = simboloMoneda + sumF415[9].ToString(); F415lbl10.Text = simboloMoneda + sumF415[10].ToString(); F415lbl11.Text = simboloMoneda + sumF415[11].ToString();

            sumF699[0] = sumF320[0] + sumF350[0] + sumF380[0] + sumF403[0] + sumF405[0] + sumF415[0] + sumF299[0]; sumF699[1] = sumF320[1] + sumF350[1] + sumF380[1] + sumF403[1] + sumF405[1] + sumF415[1] + sumF299[1];
            sumF699[2] = sumF320[2] + sumF350[2] + sumF380[2] + sumF403[2] + sumF405[2] + sumF415[2] + sumF299[2]; sumF699[3] = sumF320[3] + sumF350[3] + sumF380[3] + sumF403[3] + sumF405[3] + sumF415[3] + sumF299[3];
            sumF699[4] = sumF320[4] + sumF350[4] + sumF380[4] + sumF403[4] + sumF405[4] + sumF415[4] + sumF299[4]; sumF699[5] = sumF320[5] + sumF350[5] + sumF380[5] + sumF403[5] + sumF405[5] + sumF415[5] + sumF299[5];
            sumF699[6] = sumF320[6] + sumF350[6] + sumF380[6] + sumF403[6] + sumF405[6] + sumF415[6] + sumF299[6]; sumF699[7] = sumF320[7] + sumF350[7] + sumF380[7] + sumF403[7] + sumF405[7] + sumF415[7] + sumF299[7];
            sumF699[8] = sumF320[8] + sumF350[8] + sumF380[8] + sumF403[8] + sumF405[8] + sumF415[8] + sumF299[8]; sumF699[9] = sumF320[9] + sumF350[9] + sumF380[9] + sumF403[9] + sumF405[9] + sumF415[9] + sumF299[9];
            sumF699[10] = sumF320[10] + sumF350[10] + sumF380[10] + sumF403[10] + sumF405[10] + sumF415[10] + sumF299[10]; sumF699[11] = sumF320[11] + sumF350[11] + sumF380[11] + sumF403[11] + sumF405[11] + sumF415[11] + sumF299[11];
            F699lbl0.Text = simboloMoneda + sumF699[0].ToString(); F699lbl1.Text = simboloMoneda + sumF699[1].ToString(); F699lbl2.Text = simboloMoneda + sumF699[2].ToString();
            F699lbl3.Text = simboloMoneda + sumF699[3].ToString(); F699lbl4.Text = simboloMoneda + sumF699[4].ToString(); F699lbl5.Text = simboloMoneda + sumF699[5].ToString();
            F699lbl6.Text = simboloMoneda + sumF699[6].ToString(); F699lbl7.Text = simboloMoneda + sumF699[7].ToString(); F699lbl8.Text = simboloMoneda + sumF699[8].ToString();
            F699lbl9.Text = simboloMoneda + sumF699[9].ToString(); F699lbl10.Text = simboloMoneda + sumF699[10].ToString(); F699lbl11.Text = simboloMoneda + sumF699[11].ToString();

            sumF710 = mergeTables.GeTotalByTablePlan(JsonDatasetF710, moneda);
            F710lbl0.Text = simboloMoneda + sumF710[0].ToString(); F710lbl1.Text = simboloMoneda + sumF710[1].ToString(); F710lbl2.Text = simboloMoneda + sumF710[2].ToString();
            F710lbl3.Text = simboloMoneda + sumF710[3].ToString(); F710lbl4.Text = simboloMoneda + sumF710[4].ToString(); F710lbl5.Text = simboloMoneda + sumF710[5].ToString();
            F710lbl6.Text = simboloMoneda + sumF710[6].ToString(); F710lbl7.Text = simboloMoneda + sumF710[7].ToString(); F710lbl8.Text = simboloMoneda + sumF710[8].ToString();
            F710lbl9.Text = simboloMoneda + sumF710[9].ToString(); F710lbl10.Text = simboloMoneda + sumF710[10].ToString(); F710lbl11.Text = simboloMoneda + sumF710[11].ToString();

            sumF799[0] = sumF710[0] + sumF699[0]; sumF799[1] = sumF710[1] + sumF699[1];
            sumF799[2] = sumF710[2] + sumF699[2]; sumF799[3] = sumF710[3] + sumF699[3];
            sumF799[4] = sumF710[4] + sumF699[4]; sumF799[5] = sumF710[5] + sumF699[5];
            sumF799[6] = sumF710[6] + sumF699[6]; sumF799[7] = sumF710[7] + sumF699[7];
            sumF799[8] = sumF710[8] + sumF699[8]; sumF799[9] = sumF710[9] + sumF699[9];
            sumF799[10] = sumF710[10] + sumF699[10]; sumF799[11] = sumF710[11] + sumF699[11];
            F799lbl0.Text = simboloMoneda + sumF799[0].ToString(); F799lbl1.Text = simboloMoneda + sumF799[1].ToString(); F799lbl2.Text = simboloMoneda + sumF799[2].ToString();
            F799lbl3.Text = simboloMoneda + sumF799[3].ToString(); F799lbl4.Text = simboloMoneda + sumF799[4].ToString(); F799lbl5.Text = simboloMoneda + sumF799[5].ToString();
            F799lbl6.Text = simboloMoneda + sumF799[6].ToString(); F799lbl7.Text = simboloMoneda + sumF799[7].ToString(); F799lbl8.Text = simboloMoneda + sumF799[8].ToString();
            F799lbl9.Text = simboloMoneda + sumF799[9].ToString(); F799lbl10.Text = simboloMoneda + sumF799[10].ToString(); F799lbl11.Text = simboloMoneda + sumF799[11].ToString();

            sumF805 = mergeTables.GeTotalByTablePlan(JsonDatasetF805, moneda);
            F805lbl0.Text = simboloMoneda + sumF805[0].ToString(); F805lbl1.Text = simboloMoneda + sumF805[1].ToString(); F805lbl2.Text = simboloMoneda + sumF805[2].ToString();
            F805lbl3.Text = simboloMoneda + sumF805[3].ToString(); F805lbl4.Text = simboloMoneda + sumF805[4].ToString(); F805lbl5.Text = simboloMoneda + sumF805[5].ToString();
            F805lbl6.Text = simboloMoneda + sumF805[6].ToString(); F805lbl7.Text = simboloMoneda + sumF805[7].ToString(); F805lbl8.Text = simboloMoneda + sumF805[8].ToString();
            F805lbl9.Text = simboloMoneda + sumF805[9].ToString(); F805lbl10.Text = simboloMoneda + sumF805[10].ToString(); F805lbl11.Text = simboloMoneda + sumF805[11].ToString();

            sumF999[0] = sumF805[0] + sumF799[0]; sumF999[1] = sumF805[1] + sumF799[1];
            sumF999[2] = sumF805[2] + sumF799[2]; sumF999[3] = sumF805[3] + sumF799[3];
            sumF999[4] = sumF805[4] + sumF799[4]; sumF999[5] = sumF805[5] + sumF799[5];
            sumF999[6] = sumF805[6] + sumF799[6]; sumF999[7] = sumF805[7] + sumF799[7];
            sumF999[8] = sumF805[8] + sumF799[8]; sumF999[9] = sumF805[9] + sumF799[9];
            sumF999[10] = sumF805[10] + sumF799[10]; sumF999[11] = sumF805[11] + sumF799[11];
            F999lbl0.Text = simboloMoneda + sumF999[0].ToString(); F999lbl1.Text = simboloMoneda + sumF999[1].ToString(); F999lbl2.Text = simboloMoneda + sumF999[2].ToString();
            F999lbl3.Text = simboloMoneda + sumF999[3].ToString(); F999lbl4.Text = simboloMoneda + sumF999[4].ToString(); F999lbl5.Text = simboloMoneda + sumF999[5].ToString();
            F999lbl6.Text = simboloMoneda + sumF999[6].ToString(); F999lbl7.Text = simboloMoneda + sumF999[7].ToString(); F999lbl8.Text = simboloMoneda + sumF999[8].ToString();
            F999lbl9.Text = simboloMoneda + sumF999[9].ToString(); F999lbl10.Text = simboloMoneda + sumF999[10].ToString(); F999lbl11.Text = simboloMoneda + sumF999[11].ToString();
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