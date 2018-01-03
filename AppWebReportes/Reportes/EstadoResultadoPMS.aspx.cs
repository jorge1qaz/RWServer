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
            if (Session["EDRPMSTipoMoneda"].ToString() == "soles")
                if (Session["EDRPMSTipoReporte"].ToString() == "naturaleza")
                    GetEstadoResultadoNaturaleza(true);
                else
                    GetEstadoResultadoFuncion(true);
            else
                if (Session["EDRPMSTipoReporte"].ToString() == "naturaleza")
                    GetEstadoResultadoNaturaleza(false);
                else
                    GetEstadoResultadoFuncion(false);
        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para */
        public void GetEstadoResultadoNaturaleza(bool moneda)
        {
            string valorMoneda1 = "a";
            string valorMoneda2 = "b";
            string valorMoneda3 = "d";
            string simboloMoneda = "S/ ";
            string JsonDatasetN005 = GetPathFile("N005");
            //string JsonDatasetN010 = GetPathFile("N010");
            //string JsonDatasetN015 = GetPathFile("N015");
            //string JsonDatasetN099 = GetPathFile("N099");
            //string JsonDatasetN103 = GetPathFile("N103");
            //string JsonDatasetN105 = GetPathFile("N105");
            //string JsonDatasetN110 = GetPathFile("N110");
            //string JsonDatasetN205 = GetPathFile("N205");
            //string JsonDatasetN210 = GetPathFile("N210");
            //string JsonDatasetN215 = GetPathFile("N215");
            //string JsonDatasetN220 = GetPathFile("N220");
            //string JsonDatasetN225 = GetPathFile("N225");
            //string JsonDatasetN230 = GetPathFile("N230");
            //string JsonDatasetN235 = GetPathFile("N235");
            //string JsonDatasetN305 = GetPathFile("N305");
            //string JsonDatasetN310 = GetPathFile("N310");
            //string JsonDatasetN315 = GetPathFile("N315");
            //string JsonDatasetN405 = GetPathFile("N405");
            //string JsonDatasetN410 = GetPathFile("N410");
            //string JsonDatasetN415 = GetPathFile("N415");
            //string JsonDatasetN420 = GetPathFile("N420");
            //string JsonDatasetN425 = GetPathFile("N425");
            //string JsonDatasetN430 = GetPathFile("N430");
            //string JsonDatasetN505 = GetPathFile("N505");
            //string JsonDatasetN510 = GetPathFile("N510");
            //string JsonDatasetN515 = GetPathFile("N515");
            //string JsonDatasetN520 = GetPathFile("N520");
            //string JsonDatasetN525 = GetPathFile("N525");
            //string JsonDatasetN805 = GetPathFile("N805");
            //string JsonDatasetN810 = GetPathFile("N810");
            
            if (!moneda)                    // Moneda: Dólares 
                valorMoneda1 = "b"; valorMoneda2 = "c"; valorMoneda3 = "e"; simboloMoneda = "$ ";
            for (Int16 i = 1; i <= 12; i++)
            {
                decimal sumN005 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN005, i.ToString(), valorMoneda1));
                //decimal sumN010 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN010, i.ToString(), valorMoneda1));
                //decimal sumN015 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN015, i.ToString(), valorMoneda1));
                //decimal sumN099 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN099, i.ToString(), valorMoneda1));
                //decimal sumN103 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN103, i.ToString(), valorMoneda1));
                //decimal sumN105 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN105, i.ToString(), valorMoneda1));
                //decimal sumN110 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN110, i.ToString(), valorMoneda1));
                //decimal sumN205 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN205, i.ToString(), valorMoneda1));
                //decimal sumN210 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN210, i.ToString(), valorMoneda1));
                //decimal sumN215 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN215, i.ToString(), valorMoneda1));
                //decimal sumN220 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN220, i.ToString(), valorMoneda1));
                //decimal sumN225 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN225, i.ToString(), valorMoneda1));
                //decimal sumN230 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN230, i.ToString(), valorMoneda1));
                //decimal sumN235 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN235, i.ToString(), valorMoneda1));
                //decimal sumN305 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN305, i.ToString(), valorMoneda1));
                //decimal sumN310 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN310, i.ToString(), valorMoneda1));
                //decimal sumN315 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN315, i.ToString(), valorMoneda1));
                //decimal sumN405 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN405, i.ToString(), valorMoneda1));
                //decimal sumN410 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN410, i.ToString(), valorMoneda1));
                //decimal sumN415 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN415, i.ToString(), "a", valorMoneda2, valorMoneda3, false, false));
                //decimal sumN420 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN420, i.ToString(), valorMoneda1));
                //decimal sumN425 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN425, i.ToString(), valorMoneda1));
                //decimal sumN430 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN430, i.ToString(), valorMoneda1));
                //decimal sumN505 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN505, i.ToString(), valorMoneda1));
                //decimal sumN510 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN510, i.ToString(), valorMoneda1));
                //decimal sumN515 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN515, i.ToString(), valorMoneda1));
                //decimal sumN520 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN520, i.ToString(), "a", valorMoneda2, valorMoneda3, false, false));
                //decimal sumN525 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN525, i.ToString(), valorMoneda1));
                //decimal sumN805 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN805, i.ToString(), valorMoneda1));
                //decimal sumN810 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN810, i.ToString(), valorMoneda1));
                switch (i)
                {
                    case 1:
                        N005lbl1.Text = simboloMoneda + sumN005.ToString();
                        break;
                    case 2:
                        N005lbl2.Text = simboloMoneda + sumN005.ToString();
                        break;
                    case 3:
                        N005lbl3.Text = simboloMoneda + sumN005.ToString();
                        break;
                    case 4:
                        N005lbl4.Text = simboloMoneda + sumN005.ToString();
                        break;
                    default:
                        break;
                }
            }

        }
        //Jorge Luis|26/12/2017|RW-103
        /*Método para */
        public void GetEstadoResultadoFuncion(bool moneda)
        {
            string valorMoneda1 = "a";
            string valorMoneda2 = "b";
            string valorMoneda3 = "d";
            string JsonDatasetN005 = GetPathFile("N005");
            string JsonDatasetN010 = GetPathFile("N010");
            string JsonDatasetN015 = GetPathFile("N015");
            string JsonDatasetN099 = GetPathFile("N099");
            string JsonDatasetN103 = GetPathFile("N103");
            string JsonDatasetN105 = GetPathFile("N105");
            string JsonDatasetN110 = GetPathFile("N110");
            string JsonDatasetN205 = GetPathFile("N205");
            string JsonDatasetN210 = GetPathFile("N210");
            string JsonDatasetN215 = GetPathFile("N215");
            string JsonDatasetN220 = GetPathFile("N220");
            string JsonDatasetN225 = GetPathFile("N225");
            string JsonDatasetN230 = GetPathFile("N230");
            string JsonDatasetN235 = GetPathFile("N235");
            string JsonDatasetN305 = GetPathFile("N305");
            string JsonDatasetN310 = GetPathFile("N310");
            string JsonDatasetN315 = GetPathFile("N315");
            string JsonDatasetN405 = GetPathFile("N405");
            string JsonDatasetN410 = GetPathFile("N410");
            string JsonDatasetN415 = GetPathFile("N415");
            string JsonDatasetN420 = GetPathFile("N420");
            string JsonDatasetN425 = GetPathFile("N425");
            string JsonDatasetN430 = GetPathFile("N430");
            string JsonDatasetN505 = GetPathFile("N505");
            string JsonDatasetN510 = GetPathFile("N510");
            string JsonDatasetN515 = GetPathFile("N515");
            string JsonDatasetN520 = GetPathFile("N520");
            string JsonDatasetN525 = GetPathFile("N525");
            string JsonDatasetN805 = GetPathFile("N805");
            string JsonDatasetN810 = GetPathFile("N810");
            if (!moneda)                    // Moneda: Soles 
                valorMoneda1 = "b"; valorMoneda2 = "c"; valorMoneda3 = "e";
            for (Int16 i = 1; i <= 12; i++)
            {
                decimal sumN005 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN005, i.ToString(), valorMoneda1));
                decimal sumN010 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN010, i.ToString(), valorMoneda1));
                decimal sumN015 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN015, i.ToString(), valorMoneda1));
                decimal sumN099 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN099, i.ToString(), valorMoneda1));
                decimal sumN103 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN103, i.ToString(), valorMoneda1));
                decimal sumN105 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN105, i.ToString(), valorMoneda1));
                decimal sumN110 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN110, i.ToString(), valorMoneda1));
                decimal sumN205 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN205, i.ToString(), valorMoneda1));
                decimal sumN210 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN210, i.ToString(), valorMoneda1));
                decimal sumN215 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN215, i.ToString(), valorMoneda1));
                decimal sumN220 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN220, i.ToString(), valorMoneda1));
                decimal sumN225 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN225, i.ToString(), valorMoneda1));
                decimal sumN230 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN230, i.ToString(), valorMoneda1));
                decimal sumN235 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN235, i.ToString(), valorMoneda1));
                decimal sumN305 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN305, i.ToString(), valorMoneda1));
                decimal sumN310 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN310, i.ToString(), valorMoneda1));
                decimal sumN315 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN315, i.ToString(), valorMoneda1));
                decimal sumN405 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN405, i.ToString(), valorMoneda1));
                decimal sumN410 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN410, i.ToString(), valorMoneda1));
                decimal sumN415 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN415, i.ToString(), "a", valorMoneda2, valorMoneda3, false, false));
                decimal sumN420 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN420, i.ToString(), valorMoneda1));
                decimal sumN425 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN425, i.ToString(), valorMoneda1));
                decimal sumN430 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN430, i.ToString(), valorMoneda1));
                decimal sumN505 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN505, i.ToString(), valorMoneda1));
                decimal sumN510 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN510, i.ToString(), valorMoneda1));
                decimal sumN515 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN515, i.ToString(), valorMoneda1));
                decimal sumN520 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN520, i.ToString(), "a", valorMoneda2, valorMoneda3, false, false));
                decimal sumN525 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN525, i.ToString(), valorMoneda1));
                decimal sumN805 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN805, i.ToString(), valorMoneda1));
                decimal sumN810 = Convert.ToDecimal(mergeTables.GeTotalByAccumulatedTables(JsonDatasetN810, i.ToString(), valorMoneda1));
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