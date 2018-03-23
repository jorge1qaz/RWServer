using System;
using System.Globalization;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class EstadosFinancieros : System.Web.UI.Page
    {
        Paths paths = new Paths();
        MergeTables mergeTables = new MergeTables();
        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (Session["TipoMonedaEFNT"].ToString() == "Nuevos soles")
            {
                GetReport(true, int.Parse(lstMes.SelectedValue));
            }
            else
                GetReport(false, int.Parse(lstMes.SelectedValue));
        }
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
            String rootPath             = Server.MapPath("~"); //Ruta física
            string nameReport           = "rptStdFncr";
            string dbCompletePlan       = paths.GetStringByFileJson("DataBaseConta", rootPath, Session["IdUser"].ToString(), nameReport, Request.QueryString["idCompany"].ToString(), Request.QueryString["year"].ToString());
            string rubrosCompletePlan   = paths.GetStringByFileJson("listNamesRubros", rootPath, Session["IdUser"].ToString(), nameReport, Request.QueryString["idCompany"].ToString(), Request.QueryString["year"].ToString());
            QueriesCompleteDatabase queriesCompleteDatabase = new QueriesCompleteDatabase()
            {
                identificacionReporte       = 1,
                jsonDataSetDBComplete       = dbCompletePlan,
                jsonDataSetRubrosByFormatos = rubrosCompletePlan,
                tipoMoneda                  = moneda,
                mesProceso                  = mesProceso,
            };

            tableReport.DataSource = queriesCompleteDatabase.GenerateReportEstadosFinancieros();
            tableReport.DataBind();
            tableReport.UseAccessibleHeader = true;
            tableReport.HeaderRow.TableSection = TableRowSection.TableHeader;
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