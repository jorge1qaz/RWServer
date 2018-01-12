using System;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class EstadoResultadoPMSF : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        string simboloMoneda = "S/ ", JsonDatasetF005 = "", JsonDatasetF105 = "", JsonDatasetF206 = "", JsonDatasetF211 = "", JsonDatasetF212 = "", JsonDatasetF213 = "", JsonDatasetF214 = "",
                JsonDatasetF215 = "", JsonDatasetF320 = "", JsonDatasetF350 = "", JsonDatasetF380 = "", JsonDatasetF403 = "", JsonDatasetF405 = "", JsonDatasetF415 = "", JsonDatasetF710 = "", JsonDatasetF805 = "";
        decimal[] totalF005 = new decimal[12], totalF105 = new decimal[12], totalF199 = new decimal[12], totalF206 = new decimal[12], totalF211 = new decimal[12], totalF212 = new decimal[12],
                totalF213 = new decimal[12], totalF214 = new decimal[12], totalF215 = new decimal[12], totalF299 = new decimal[12], totalF320 = new decimal[12], totalF350 = new decimal[12],
                totalF380 = new decimal[12], totalF403 = new decimal[12], totalF405 = new decimal[12], totalF415 = new decimal[12], totalF699 = new decimal[12], totalF710 = new decimal[12],
                totalF799 = new decimal[12], totalF805 = new decimal[12], totalF999 = new decimal[12];
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
            if (!moneda)                    // Moneda: Dólares
            { simboloMoneda = "$ "; }

            JsonDatasetF005 = GetPathFile("F005"); JsonDatasetF105 = GetPathFile("F105"); JsonDatasetF206 = GetPathFile("F206"); JsonDatasetF211 = GetPathFile("F211");
            JsonDatasetF212 = GetPathFile("F212"); JsonDatasetF213 = GetPathFile("F213"); JsonDatasetF214 = GetPathFile("F214"); JsonDatasetF215 = GetPathFile("F215");
            JsonDatasetF320 = GetPathFile("F320"); JsonDatasetF350 = GetPathFile("F350"); JsonDatasetF380 = GetPathFile("F380"); JsonDatasetF403 = GetPathFile("F403");
            JsonDatasetF405 = GetPathFile("F405"); JsonDatasetF415 = GetPathFile("F415"); JsonDatasetF710 = GetPathFile("F710"); JsonDatasetF805 = GetPathFile("F805");

            totalF005 = mergeTables.GeTotalByTablePlan(JsonDatasetF005, moneda);
            F005lbl0.Text = simboloMoneda + totalF005[0].ToString(); F005lbl1.Text = simboloMoneda + totalF005[1].ToString(); F005lbl2.Text = simboloMoneda + totalF005[2].ToString();
            F005lbl3.Text = simboloMoneda + totalF005[3].ToString(); F005lbl4.Text = simboloMoneda + totalF005[4].ToString(); F005lbl5.Text = simboloMoneda + totalF005[5].ToString();
            F005lbl6.Text = simboloMoneda + totalF005[6].ToString(); F005lbl7.Text = simboloMoneda + totalF005[7].ToString(); F005lbl8.Text = simboloMoneda + totalF005[8].ToString();
            F005lbl9.Text = simboloMoneda + totalF005[9].ToString(); F005lbl10.Text = simboloMoneda + totalF005[10].ToString(); F005lbl11.Text = simboloMoneda + totalF005[11].ToString();

            totalF105 = mergeTables.GeTotalByTablePlan(JsonDatasetF105, moneda);
            F105lbl0.Text = simboloMoneda + totalF105[0].ToString(); F105lbl1.Text = simboloMoneda + totalF105[1].ToString(); F105lbl2.Text = simboloMoneda + totalF105[2].ToString();
            F105lbl3.Text = simboloMoneda + totalF105[3].ToString(); F105lbl4.Text = simboloMoneda + totalF105[4].ToString(); F105lbl5.Text = simboloMoneda + totalF105[5].ToString();
            F105lbl6.Text = simboloMoneda + totalF105[6].ToString(); F105lbl7.Text = simboloMoneda + totalF105[7].ToString(); F105lbl8.Text = simboloMoneda + totalF105[8].ToString();
            F105lbl9.Text = simboloMoneda + totalF105[9].ToString(); F105lbl10.Text = simboloMoneda + totalF105[10].ToString(); F105lbl11.Text = simboloMoneda + totalF105[11].ToString();

            totalF199[0] = totalF005[0] + totalF105[0]; totalF199[1] = totalF005[1] + totalF105[1];
            totalF199[2] = totalF005[2] + totalF105[2]; totalF199[3] = totalF005[3] + totalF105[3];
            totalF199[4] = totalF005[4] + totalF105[4]; totalF199[5] = totalF005[5] + totalF105[5];
            totalF199[6] = totalF005[6] + totalF105[6]; totalF199[7] = totalF005[7] + totalF105[7];
            totalF199[8] = totalF005[8] + totalF105[8]; totalF199[9] = totalF005[9] + totalF105[9];
            totalF199[10] = totalF005[10] + totalF105[10]; totalF199[11] = totalF005[11] + totalF105[11];
            F199lbl0.Text = simboloMoneda + totalF199[0].ToString(); F199lbl1.Text = simboloMoneda + totalF199[1].ToString(); F199lbl2.Text = simboloMoneda + totalF199[2].ToString();
            F199lbl3.Text = simboloMoneda + totalF199[3].ToString(); F199lbl4.Text = simboloMoneda + totalF199[4].ToString(); F199lbl5.Text = simboloMoneda + totalF199[5].ToString();
            F199lbl6.Text = simboloMoneda + totalF199[6].ToString(); F199lbl7.Text = simboloMoneda + totalF199[7].ToString(); F199lbl8.Text = simboloMoneda + totalF199[8].ToString();
            F199lbl9.Text = simboloMoneda + totalF199[9].ToString(); F199lbl10.Text = simboloMoneda + totalF199[10].ToString(); F199lbl11.Text = simboloMoneda + totalF199[11].ToString();

            totalF206 = mergeTables.GeTotalByTablePlan(JsonDatasetF206, moneda);
            F206lbl0.Text = simboloMoneda + totalF206[0].ToString(); F206lbl1.Text = simboloMoneda + totalF206[1].ToString(); F206lbl2.Text = simboloMoneda + totalF206[2].ToString();
            F206lbl3.Text = simboloMoneda + totalF206[3].ToString(); F206lbl4.Text = simboloMoneda + totalF206[4].ToString(); F206lbl5.Text = simboloMoneda + totalF206[5].ToString();
            F206lbl6.Text = simboloMoneda + totalF206[6].ToString(); F206lbl7.Text = simboloMoneda + totalF206[7].ToString(); F206lbl8.Text = simboloMoneda + totalF206[8].ToString();
            F206lbl9.Text = simboloMoneda + totalF206[9].ToString(); F206lbl10.Text = simboloMoneda + totalF206[10].ToString(); F206lbl11.Text = simboloMoneda + totalF206[11].ToString();

            totalF211 = mergeTables.GeTotalByTablePlan(JsonDatasetF211, moneda);
            F211lbl0.Text = simboloMoneda + totalF211[0].ToString(); F211lbl1.Text = simboloMoneda + totalF211[1].ToString(); F211lbl2.Text = simboloMoneda + totalF211[2].ToString();
            F211lbl3.Text = simboloMoneda + totalF211[3].ToString(); F211lbl4.Text = simboloMoneda + totalF211[4].ToString(); F211lbl5.Text = simboloMoneda + totalF211[5].ToString();
            F211lbl6.Text = simboloMoneda + totalF211[6].ToString(); F211lbl7.Text = simboloMoneda + totalF211[7].ToString(); F211lbl8.Text = simboloMoneda + totalF211[8].ToString();
            F211lbl9.Text = simboloMoneda + totalF211[9].ToString(); F211lbl10.Text = simboloMoneda + totalF211[10].ToString(); F211lbl11.Text = simboloMoneda + totalF211[11].ToString();

            totalF212 = mergeTables.GeTotalByTablePlan(JsonDatasetF212, moneda);
            F212lbl0.Text = simboloMoneda + totalF212[0].ToString(); F212lbl1.Text = simboloMoneda + totalF212[1].ToString(); F212lbl2.Text = simboloMoneda + totalF212[2].ToString();
            F212lbl3.Text = simboloMoneda + totalF212[3].ToString(); F212lbl4.Text = simboloMoneda + totalF212[4].ToString(); F212lbl5.Text = simboloMoneda + totalF212[5].ToString();
            F212lbl6.Text = simboloMoneda + totalF212[6].ToString(); F212lbl7.Text = simboloMoneda + totalF212[7].ToString(); F212lbl8.Text = simboloMoneda + totalF212[8].ToString();
            F212lbl9.Text = simboloMoneda + totalF212[9].ToString(); F212lbl10.Text = simboloMoneda + totalF212[10].ToString(); F212lbl11.Text = simboloMoneda + totalF212[11].ToString();

            totalF213 = mergeTables.GeTotalByTablePlan(JsonDatasetF213, moneda);
            F213lbl0.Text = simboloMoneda + totalF213[0].ToString(); F213lbl1.Text = simboloMoneda + totalF213[1].ToString(); F213lbl2.Text = simboloMoneda + totalF213[2].ToString();
            F213lbl3.Text = simboloMoneda + totalF213[3].ToString(); F213lbl4.Text = simboloMoneda + totalF213[4].ToString(); F213lbl5.Text = simboloMoneda + totalF213[5].ToString();
            F213lbl6.Text = simboloMoneda + totalF213[6].ToString(); F213lbl7.Text = simboloMoneda + totalF213[7].ToString(); F213lbl8.Text = simboloMoneda + totalF213[8].ToString();
            F213lbl9.Text = simboloMoneda + totalF213[9].ToString(); F213lbl10.Text = simboloMoneda + totalF213[10].ToString(); F213lbl11.Text = simboloMoneda + totalF213[11].ToString();

            totalF214 = mergeTables.GeTotalByTablePlan(JsonDatasetF214, moneda);
            F214lbl0.Text = simboloMoneda + totalF214[0].ToString(); F214lbl1.Text = simboloMoneda + totalF214[1].ToString(); F214lbl2.Text = simboloMoneda + totalF214[2].ToString();
            F214lbl3.Text = simboloMoneda + totalF214[3].ToString(); F214lbl4.Text = simboloMoneda + totalF214[4].ToString(); F214lbl5.Text = simboloMoneda + totalF214[5].ToString();
            F214lbl6.Text = simboloMoneda + totalF214[6].ToString(); F214lbl7.Text = simboloMoneda + totalF214[7].ToString(); F214lbl8.Text = simboloMoneda + totalF214[8].ToString();
            F214lbl9.Text = simboloMoneda + totalF214[9].ToString(); F214lbl10.Text = simboloMoneda + totalF214[10].ToString(); F214lbl11.Text = simboloMoneda + totalF214[11].ToString();

            totalF215 = mergeTables.GeTotalByTablePlan(JsonDatasetF215, moneda);
            F215lbl0.Text = simboloMoneda + totalF215[0].ToString(); F215lbl1.Text = simboloMoneda + totalF215[1].ToString(); F215lbl2.Text = simboloMoneda + totalF215[2].ToString();
            F215lbl3.Text = simboloMoneda + totalF215[3].ToString(); F215lbl4.Text = simboloMoneda + totalF215[4].ToString(); F215lbl5.Text = simboloMoneda + totalF215[5].ToString();
            F215lbl6.Text = simboloMoneda + totalF215[6].ToString(); F215lbl7.Text = simboloMoneda + totalF215[7].ToString(); F215lbl8.Text = simboloMoneda + totalF215[8].ToString();
            F215lbl9.Text = simboloMoneda + totalF215[9].ToString(); F215lbl10.Text = simboloMoneda + totalF215[10].ToString(); F215lbl11.Text = simboloMoneda + totalF215[11].ToString();

            totalF299[0] = totalF206[0] + totalF211[0] + totalF212[0] + totalF213[0] + totalF214[0] + totalF215[0] + totalF199[0]; totalF299[1] = totalF206[1] + totalF211[1] + totalF212[1] + totalF213[1] + totalF214[1] + totalF215[1] + totalF199[1];
            totalF299[2] = totalF206[2] + totalF211[2] + totalF212[2] + totalF213[2] + totalF214[2] + totalF215[2] + totalF199[2]; totalF299[3] = totalF206[3] + totalF211[3] + totalF212[3] + totalF213[3] + totalF214[3] + totalF215[3] + totalF199[3];
            totalF299[4] = totalF206[4] + totalF211[4] + totalF212[4] + totalF213[4] + totalF214[4] + totalF215[4] + totalF199[4]; totalF299[5] = totalF206[5] + totalF211[5] + totalF212[5] + totalF213[5] + totalF214[5] + totalF215[5] + totalF199[5];
            totalF299[6] = totalF206[6] + totalF211[6] + totalF212[6] + totalF213[6] + totalF214[6] + totalF215[6] + totalF199[6]; totalF299[7] = totalF206[7] + totalF211[7] + totalF212[7] + totalF213[7] + totalF214[7] + totalF215[7] + totalF199[7];
            totalF299[8] = totalF206[8] + totalF211[8] + totalF212[8] + totalF213[8] + totalF214[8] + totalF215[8] + totalF199[8]; totalF299[9] = totalF206[9] + totalF211[9] + totalF212[9] + totalF213[9] + totalF214[9] + totalF215[9] + totalF199[9];
            totalF299[10] = totalF206[10] + totalF211[10] + totalF212[10] + totalF213[10] + totalF214[10] + totalF215[10] + totalF199[10]; totalF299[11] = totalF206[11] + totalF211[11] + totalF212[11] + totalF213[11] + totalF214[11] + totalF215[11] + totalF199[11];
            F299lbl0.Text = simboloMoneda + totalF299[0].ToString(); F299lbl1.Text = simboloMoneda + totalF299[1].ToString(); F299lbl2.Text = simboloMoneda + totalF299[2].ToString();
            F299lbl3.Text = simboloMoneda + totalF299[3].ToString(); F299lbl4.Text = simboloMoneda + totalF299[4].ToString(); F299lbl5.Text = simboloMoneda + totalF299[5].ToString();
            F299lbl6.Text = simboloMoneda + totalF299[6].ToString(); F299lbl7.Text = simboloMoneda + totalF299[7].ToString(); F299lbl8.Text = simboloMoneda + totalF299[8].ToString();
            F299lbl9.Text = simboloMoneda + totalF299[9].ToString(); F299lbl10.Text = simboloMoneda + totalF299[10].ToString(); F299lbl11.Text = simboloMoneda + totalF299[11].ToString();

            totalF320 = mergeTables.GeTotalByTablePlan(JsonDatasetF320, moneda);
            F320lbl0.Text = simboloMoneda + totalF320[0].ToString(); F320lbl1.Text = simboloMoneda + totalF320[1].ToString(); F320lbl2.Text = simboloMoneda + totalF320[2].ToString();
            F320lbl3.Text = simboloMoneda + totalF320[3].ToString(); F320lbl4.Text = simboloMoneda + totalF320[4].ToString(); F320lbl5.Text = simboloMoneda + totalF320[5].ToString();
            F320lbl6.Text = simboloMoneda + totalF320[6].ToString(); F320lbl7.Text = simboloMoneda + totalF320[7].ToString(); F320lbl8.Text = simboloMoneda + totalF320[8].ToString();
            F320lbl9.Text = simboloMoneda + totalF320[9].ToString(); F320lbl10.Text = simboloMoneda + totalF320[10].ToString(); F320lbl11.Text = simboloMoneda + totalF320[11].ToString();

            totalF350 = mergeTables.GeTotalByTablePlan(JsonDatasetF350, moneda);
            F350lbl0.Text = simboloMoneda + totalF350[0].ToString(); F350lbl1.Text = simboloMoneda + totalF350[1].ToString(); F350lbl2.Text = simboloMoneda + totalF350[2].ToString();
            F350lbl3.Text = simboloMoneda + totalF350[3].ToString(); F350lbl4.Text = simboloMoneda + totalF350[4].ToString(); F350lbl5.Text = simboloMoneda + totalF350[5].ToString();
            F350lbl6.Text = simboloMoneda + totalF350[6].ToString(); F350lbl7.Text = simboloMoneda + totalF350[7].ToString(); F350lbl8.Text = simboloMoneda + totalF350[8].ToString();
            F350lbl9.Text = simboloMoneda + totalF350[9].ToString(); F350lbl10.Text = simboloMoneda + totalF350[10].ToString(); F350lbl11.Text = simboloMoneda + totalF350[11].ToString();

            totalF380 = mergeTables.GeTotalByTablePlan(JsonDatasetF380, moneda);
            F380lbl0.Text = simboloMoneda + totalF380[0].ToString(); F380lbl1.Text = simboloMoneda + totalF380[1].ToString(); F380lbl2.Text = simboloMoneda + totalF380[2].ToString();
            F380lbl3.Text = simboloMoneda + totalF380[3].ToString(); F380lbl4.Text = simboloMoneda + totalF380[4].ToString(); F380lbl5.Text = simboloMoneda + totalF380[5].ToString();
            F380lbl6.Text = simboloMoneda + totalF380[6].ToString(); F380lbl7.Text = simboloMoneda + totalF380[7].ToString(); F380lbl8.Text = simboloMoneda + totalF380[8].ToString();
            F380lbl9.Text = simboloMoneda + totalF380[9].ToString(); F380lbl10.Text = simboloMoneda + totalF380[10].ToString(); F380lbl11.Text = simboloMoneda + totalF380[11].ToString();

            totalF403 = mergeTables.GeTotalByTablePlan(JsonDatasetF403, moneda);
            F403lbl0.Text = simboloMoneda + totalF403[0].ToString(); F403lbl1.Text = simboloMoneda + totalF403[1].ToString(); F403lbl2.Text = simboloMoneda + totalF403[2].ToString();
            F403lbl3.Text = simboloMoneda + totalF403[3].ToString(); F403lbl4.Text = simboloMoneda + totalF403[4].ToString(); F403lbl5.Text = simboloMoneda + totalF403[5].ToString();
            F403lbl6.Text = simboloMoneda + totalF403[6].ToString(); F403lbl7.Text = simboloMoneda + totalF403[7].ToString(); F403lbl8.Text = simboloMoneda + totalF403[8].ToString();
            F403lbl9.Text = simboloMoneda + totalF403[9].ToString(); F403lbl10.Text = simboloMoneda + totalF403[10].ToString(); F403lbl11.Text = simboloMoneda + totalF403[11].ToString();

            totalF405 = mergeTables.GeTotalByTablePlan(JsonDatasetF405, moneda);
            F405lbl0.Text = simboloMoneda + totalF405[0].ToString(); F405lbl1.Text = simboloMoneda + totalF405[1].ToString(); F405lbl2.Text = simboloMoneda + totalF405[2].ToString();
            F405lbl3.Text = simboloMoneda + totalF405[3].ToString(); F405lbl4.Text = simboloMoneda + totalF405[4].ToString(); F405lbl5.Text = simboloMoneda + totalF405[5].ToString();
            F405lbl6.Text = simboloMoneda + totalF405[6].ToString(); F405lbl7.Text = simboloMoneda + totalF405[7].ToString(); F405lbl8.Text = simboloMoneda + totalF405[8].ToString();
            F405lbl9.Text = simboloMoneda + totalF405[9].ToString(); F405lbl10.Text = simboloMoneda + totalF405[10].ToString(); F405lbl11.Text = simboloMoneda + totalF405[11].ToString();

            totalF415 = mergeTables.GeTotalByTablePlan(JsonDatasetF415, moneda);
            F415lbl0.Text = simboloMoneda + totalF415[0].ToString(); F415lbl1.Text = simboloMoneda + totalF415[1].ToString(); F415lbl2.Text = simboloMoneda + totalF415[2].ToString();
            F415lbl3.Text = simboloMoneda + totalF415[3].ToString(); F415lbl4.Text = simboloMoneda + totalF415[4].ToString(); F415lbl5.Text = simboloMoneda + totalF415[5].ToString();
            F415lbl6.Text = simboloMoneda + totalF415[6].ToString(); F415lbl7.Text = simboloMoneda + totalF415[7].ToString(); F415lbl8.Text = simboloMoneda + totalF415[8].ToString();
            F415lbl9.Text = simboloMoneda + totalF415[9].ToString(); F415lbl10.Text = simboloMoneda + totalF415[10].ToString(); F415lbl11.Text = simboloMoneda + totalF415[11].ToString();

            totalF699[0] = totalF320[0] + totalF350[0] + totalF380[0] + totalF403[0] + totalF405[0] + totalF415[0] + totalF299[0]; totalF699[1] = totalF320[1] + totalF350[1] + totalF380[1] + totalF403[1] + totalF405[1] + totalF415[1] + totalF299[1];
            totalF699[2] = totalF320[2] + totalF350[2] + totalF380[2] + totalF403[2] + totalF405[2] + totalF415[2] + totalF299[2]; totalF699[3] = totalF320[3] + totalF350[3] + totalF380[3] + totalF403[3] + totalF405[3] + totalF415[3] + totalF299[3];
            totalF699[4] = totalF320[4] + totalF350[4] + totalF380[4] + totalF403[4] + totalF405[4] + totalF415[4] + totalF299[4]; totalF699[5] = totalF320[5] + totalF350[5] + totalF380[5] + totalF403[5] + totalF405[5] + totalF415[5] + totalF299[5];
            totalF699[6] = totalF320[6] + totalF350[6] + totalF380[6] + totalF403[6] + totalF405[6] + totalF415[6] + totalF299[6]; totalF699[7] = totalF320[7] + totalF350[7] + totalF380[7] + totalF403[7] + totalF405[7] + totalF415[7] + totalF299[7];
            totalF699[8] = totalF320[8] + totalF350[8] + totalF380[8] + totalF403[8] + totalF405[8] + totalF415[8] + totalF299[8]; totalF699[9] = totalF320[9] + totalF350[9] + totalF380[9] + totalF403[9] + totalF405[9] + totalF415[9] + totalF299[9];
            totalF699[10] = totalF320[10] + totalF350[10] + totalF380[10] + totalF403[10] + totalF405[10] + totalF415[10] + totalF299[10]; totalF699[11] = totalF320[11] + totalF350[11] + totalF380[11] + totalF403[11] + totalF405[11] + totalF415[11] + totalF299[11];
            F699lbl0.Text = simboloMoneda + totalF699[0].ToString(); F699lbl1.Text = simboloMoneda + totalF699[1].ToString(); F699lbl2.Text = simboloMoneda + totalF699[2].ToString();
            F699lbl3.Text = simboloMoneda + totalF699[3].ToString(); F699lbl4.Text = simboloMoneda + totalF699[4].ToString(); F699lbl5.Text = simboloMoneda + totalF699[5].ToString();
            F699lbl6.Text = simboloMoneda + totalF699[6].ToString(); F699lbl7.Text = simboloMoneda + totalF699[7].ToString(); F699lbl8.Text = simboloMoneda + totalF699[8].ToString();
            F699lbl9.Text = simboloMoneda + totalF699[9].ToString(); F699lbl10.Text = simboloMoneda + totalF699[10].ToString(); F699lbl11.Text = simboloMoneda + totalF699[11].ToString();

            totalF710 = mergeTables.GeTotalByTablePlan(JsonDatasetF710, moneda);
            F710lbl0.Text = simboloMoneda + totalF710[0].ToString(); F710lbl1.Text = simboloMoneda + totalF710[1].ToString(); F710lbl2.Text = simboloMoneda + totalF710[2].ToString();
            F710lbl3.Text = simboloMoneda + totalF710[3].ToString(); F710lbl4.Text = simboloMoneda + totalF710[4].ToString(); F710lbl5.Text = simboloMoneda + totalF710[5].ToString();
            F710lbl6.Text = simboloMoneda + totalF710[6].ToString(); F710lbl7.Text = simboloMoneda + totalF710[7].ToString(); F710lbl8.Text = simboloMoneda + totalF710[8].ToString();
            F710lbl9.Text = simboloMoneda + totalF710[9].ToString(); F710lbl10.Text = simboloMoneda + totalF710[10].ToString(); F710lbl11.Text = simboloMoneda + totalF710[11].ToString();

            totalF799[0] = totalF710[0] + totalF699[0]; totalF799[1] = totalF710[1] + totalF699[1];
            totalF799[2] = totalF710[2] + totalF699[2]; totalF799[3] = totalF710[3] + totalF699[3];
            totalF799[4] = totalF710[4] + totalF699[4]; totalF799[5] = totalF710[5] + totalF699[5];
            totalF799[6] = totalF710[6] + totalF699[6]; totalF799[7] = totalF710[7] + totalF699[7];
            totalF799[8] = totalF710[8] + totalF699[8]; totalF799[9] = totalF710[9] + totalF699[9];
            totalF799[10] = totalF710[10] + totalF699[10]; totalF799[11] = totalF710[11] + totalF699[11];
            F799lbl0.Text = simboloMoneda + totalF799[0].ToString(); F799lbl1.Text = simboloMoneda + totalF799[1].ToString(); F799lbl2.Text = simboloMoneda + totalF799[2].ToString();
            F799lbl3.Text = simboloMoneda + totalF799[3].ToString(); F799lbl4.Text = simboloMoneda + totalF799[4].ToString(); F799lbl5.Text = simboloMoneda + totalF799[5].ToString();
            F799lbl6.Text = simboloMoneda + totalF799[6].ToString(); F799lbl7.Text = simboloMoneda + totalF799[7].ToString(); F799lbl8.Text = simboloMoneda + totalF799[8].ToString();
            F799lbl9.Text = simboloMoneda + totalF799[9].ToString(); F799lbl10.Text = simboloMoneda + totalF799[10].ToString(); F799lbl11.Text = simboloMoneda + totalF799[11].ToString();

            totalF805 = mergeTables.GeTotalByTablePlan(JsonDatasetF805, moneda);
            F805lbl0.Text = simboloMoneda + totalF805[0].ToString(); F805lbl1.Text = simboloMoneda + totalF805[1].ToString(); F805lbl2.Text = simboloMoneda + totalF805[2].ToString();
            F805lbl3.Text = simboloMoneda + totalF805[3].ToString(); F805lbl4.Text = simboloMoneda + totalF805[4].ToString(); F805lbl5.Text = simboloMoneda + totalF805[5].ToString();
            F805lbl6.Text = simboloMoneda + totalF805[6].ToString(); F805lbl7.Text = simboloMoneda + totalF805[7].ToString(); F805lbl8.Text = simboloMoneda + totalF805[8].ToString();
            F805lbl9.Text = simboloMoneda + totalF805[9].ToString(); F805lbl10.Text = simboloMoneda + totalF805[10].ToString(); F805lbl11.Text = simboloMoneda + totalF805[11].ToString();

            totalF999[0] = totalF805[0] + totalF799[0]; totalF999[1] = totalF805[1] + totalF799[1];
            totalF999[2] = totalF805[2] + totalF799[2]; totalF999[3] = totalF805[3] + totalF799[3];
            totalF999[4] = totalF805[4] + totalF799[4]; totalF999[5] = totalF805[5] + totalF799[5];
            totalF999[6] = totalF805[6] + totalF799[6]; totalF999[7] = totalF805[7] + totalF799[7];
            totalF999[8] = totalF805[8] + totalF799[8]; totalF999[9] = totalF805[9] + totalF799[9];
            totalF999[10] = totalF805[10] + totalF799[10]; totalF999[11] = totalF805[11] + totalF799[11];
            F999lbl0.Text = simboloMoneda + totalF999[0].ToString(); F999lbl1.Text = simboloMoneda + totalF999[1].ToString(); F999lbl2.Text = simboloMoneda + totalF999[2].ToString();
            F999lbl3.Text = simboloMoneda + totalF999[3].ToString(); F999lbl4.Text = simboloMoneda + totalF999[4].ToString(); F999lbl5.Text = simboloMoneda + totalF999[5].ToString();
            F999lbl6.Text = simboloMoneda + totalF999[6].ToString(); F999lbl7.Text = simboloMoneda + totalF999[7].ToString(); F999lbl8.Text = simboloMoneda + totalF999[8].ToString();
            F999lbl9.Text = simboloMoneda + totalF999[9].ToString(); F999lbl10.Text = simboloMoneda + totalF999[10].ToString(); F999lbl11.Text = simboloMoneda + totalF999[11].ToString();
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