using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebReportes.Reportes
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        AccesoDatos dat = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
            try
            {
                DateTime dateUpdate = cliente.ReadParametersUserDateUpdate("RW_Profiles_Read_DateUpdate");
                DateTime lastUpdate = cliente.ReadParametersUserLastUpdate("RW_Profiles_Read_LastUpdate");
                zips.ExtractFile(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip", @rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/temp");
                TimeSpan datediff = lastUpdate.Subtract(dateUpdate);
                lblDateUpdate.Text = dateUpdate.ToString();
                if (Convert.ToDecimal(datediff.TotalMinutes) < 0)
                {
                    blockUpdateData.Visible = true;
                    lblCurrentData.Text = dateUpdate.ToString();
                    lblOutdatedData.Text = lastUpdate.ToString();
                }
                else
                    blockUpdateData.Visible = false;
            }
            catch (Exception)
            {
                blockUpdateData.Visible = false;
                try
                {
                    if (zips.CheckZipExists(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip"))
                        Descomprimir();
                }
                catch (Exception)
                { Response.Redirect("~/Reportes/NoZip.aspx"); }
            }
            if (!Page.IsPostBack)
            {
                try
                { LoadPage(); }
                catch (Exception)
                {
                    Descomprimir();
                    LoadPage();
                }
            }
        }
        public void LoadPage() {
            String rootPath = Server.MapPath("~");
            string generalInfoConta = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/GeneralInfoConta.json").Trim().Replace("\\'", "'");
            string generalInfoStock = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/GeneralInfoStock.json").Trim().Replace("\\'", "'");
            DataSet dataSetGeneralInfoConta = JsonConvert.DeserializeObject<DataSet>(generalInfoConta);
            DataSet dataSetGeneralInfoStock = JsonConvert.DeserializeObject<DataSet>(generalInfoStock);
            DataTable dataTableGeneralInfoConta = dataSetGeneralInfoConta.Tables["data"]; //Declaración de la tabla donde se va a hacer la extracción de datos
            DataTable dataTableGeneralInfoStock = dataSetGeneralInfoStock.Tables["data"];
            dlstCuentasPendientes.DataSource = dataTableGeneralInfoConta;
            dlstCuentasPendientes.DataBind();
            dlstMiNegocioAlDia.DataSource = dataTableGeneralInfoConta;
            dlstMiNegocioAlDia.DataBind();
            dlstMargenDeUtilidad.DataSource = dataTableGeneralInfoStock;
            dlstMargenDeUtilidad.DataBind();
            dlstEstadoResultadoPMS.DataSource = dataTableGeneralInfoConta;
            dlstEstadoResultadoPMS.DataBind();
            dlstEFNT.DataSource = dataTableGeneralInfoConta;
            dlstEFNT.DataBind();
            dlstFCD.DataSource = dataTableGeneralInfoConta;
            dlstFCD.DataBind();
            DataRow[] idCompany = dataTableGeneralInfoConta.Select();
            Session["idCompany"] = idCompany[0][0].ToString();
            #region Estados de resultado
            Session["EDRPMSTipoReporte"] = "naturaleza";
            Session["EDRPMSTipoMoneda"] = "Nuevos soles";
            #endregion
            #region Estados financieros NIFF y Tributario
            Session["TipoReporteEFNT"] = "Estado de situación financiera";
            Session["TipoMonedaEFNT"] = "Nuevos soles";
            #endregion
        }
        protected void btnCloseBlockUpdate_Click(object sender, EventArgs e) => blockUpdateData.Visible = false;
        protected void btnUpdateData_Click(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (zips.CheckZipExists(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip"))
                Descomprimir();
            else
                Response.Redirect("~/Reportes/NoZip.aspx");
        }
        private void Descomprimir()
        {
            String rootPath = Server.MapPath("~");
            Directory.CreateDirectory(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString());
            zips.ExtractDataZip(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip", @rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString());
            DateTime lastUpdate = DateTime.Now;
            Cliente cliente = new Cliente() {
                IdCliente = Session["IdUser"].ToString(),
                LastUpdate = lastUpdate,
            };
            if (cliente.WriteParametersUserLastUpdate("RW_Profiles_Register_LastUpdate"))
                blockUpdateData.Visible = false;
            else
                Response.Write("<script>alert('Ocurrió un error al momento de actualizar.');</script>");
        }
        protected void SelectCompanyByYearRCP(object source, DataListCommandEventArgs e)
        {
            string id = dlstCuentasPendientes.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("~/Reportes/CuentasPendientes.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
        }
        protected void SelectCompanyByYearRMU(object source, DataListCommandEventArgs e)
        {
            string id = dlstMargenDeUtilidad.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("~/Reportes/frmMargenUtilidad.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
        }
        protected void SelectCompanyByYearRMND(object source, DataListCommandEventArgs e)
        {
            string id = dlstMiNegocioAlDia.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("~/Reportes/MiNegocioAlDia.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
        }
        protected void SelectCompanyByYearEDRPMS(object source, DataListCommandEventArgs e)
        {
            string id = dlstEstadoResultadoPMS.DataKeys[e.Item.ItemIndex].ToString();
            if (Session["EDRPMSTipoReporte"].ToString() == "Función")
                Response.Redirect("~/Reportes/EstadoResultadoPMSF.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
            else
                Response.Redirect("~/Reportes/EstadoResultadoPMS.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
        }
        protected void rdbEDRPMSNaturaleza_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoReporte"] = "Naturaleza";
        protected void rdbEDRPMSFuncion_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoReporte"] = "Función";
        protected void rdbEDRPMSSoles_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoMoneda"] = "Nuevos soles";
        protected void rdbEDRPMSDolares_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoMoneda"] = "Dólares";

        protected void SelectCompanyByYearEFNT(object source, DataListCommandEventArgs e)
        {
            string id = dlstMiNegocioAlDia.DataKeys[e.Item.ItemIndex].ToString();
            switch (Session["TipoReporteEFNT"].ToString())
            {
                case "Estado de situación financiera":
                    Response.Redirect("~/Reportes/EFNTEstadoSitucionFinanciera.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Estado de resultado":
                    Response.Redirect("~/Reportes/EFNTEstadoResultado.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Balance general":
                    Response.Redirect("~/Reportes/EFNTBalanceGeneral.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Estado de ganancias y pérdidas":
                    Response.Redirect("~/Reportes/EFNTEstadoGananciasPerdidas.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                default:
                    Response.Redirect("~/Reportes/EFNTEstadoGananciasPerdidas.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
            }
        }
        protected void rdbEFNT1_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Estado de situación financiera";
        protected void rdbEFNT2_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Estado de resultado";
        protected void rdbEFNT3_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Balance general";
        protected void rdbEFNT4_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Estado de ganancias y pérdidas";

        protected void SelectCompanyByYearFCD(object source, DataListCommandEventArgs e)
        {

        }
    }
}