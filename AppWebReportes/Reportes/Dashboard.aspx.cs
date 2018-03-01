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
        DateTime dateUpdate = new DateTime();
        DateTime lastUpdate = new DateTime();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(" => " + Request.Browser.Type.ToString() + " <= ");
            //Response.Write(" => " + Request.Browser.Version.ToString() + " <= ");
            //Response.Write(" => " + Request.Browser.MajorVersion.ToString() + " <= ");
            //if (decimal.Parse(Request.Browser.Version) < decimal.Parse(Request.Browser.MajorVersion.ToString()))
            //    Response.Write("<script>alert('Tu navegador no está actualizado, las funcionalidades de la aplicación no serán iguales a menos que tengas actualizado tu navegador.')</script>");

            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null) //Compruebo que el usuario se haya logeado
                Response.Redirect("~/Acceso"); //En caso de que no, lo redireciono a la pagina "Acceso"
            Cliente cliente = new Cliente() // Instancio el objeto CLIENTE
            { IdCliente = Session["IdUser"].ToString() }; // Guardo en la variable IdCliente el ID del cliente
            lblNombreUsuario.Text = "Bienvenido, " + cliente.IdParameterUserName("RW_header_name_user"); // Traigo desde la base de datos, el nombre del cliente
            try // Primer intento, busca la diferencia entre 
            {
                dateUpdate = cliente.ReadParametersUserDateUpdate("RW_Profiles_Read_DateUpdate");
                lastUpdate = cliente.ReadParametersUserLastUpdate("RW_Profiles_Read_LastUpdate");
                TimeSpan datediff = lastUpdate.Subtract(dateUpdate);
                lblDateUpdate.Text = dateUpdate.ToString();
                if (Convert.ToDecimal(datediff.TotalMinutes) < 0)
                {
                    blockUpdateData.Visible = true;
                    lblCurrentData.Text = dateUpdate.ToString();
                    lblOutdatedData.Text = lastUpdate.ToString();
                }
                else
                {
                    blockUpdateData.Visible = false;
                }
            }
            catch (Exception)
            {
                Descomprimir();
                dateUpdate = cliente.ReadParametersUserDateUpdate("RW_Profiles_Read_DateUpdate");
                lastUpdate = cliente.ReadParametersUserLastUpdate("RW_Profiles_Read_LastUpdate");
                TimeSpan datediff = lastUpdate.Subtract(dateUpdate);
                lblDateUpdate.Text = dateUpdate.ToString();
                blockUpdateData.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                txtFrecuenciaPerdiodoFCD.Text = "7";
                txtNumeroPeriodosFCD.Text = "12";
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
            Session["TipoReporteEFNT"] = "Estado de situación financiera NIIF";
            Session["TipoMonedaEFNT"] = "Nuevos soles";
            #endregion
            Session["TipoReporteFCD"] = "Formato simple";
            Session["TipoMonedaFCD"] = "Nuevos soles";
        }
        protected void btnCloseBlockUpdate_Click(object sender, EventArgs e) => blockUpdateData.Visible = false;
        protected void btnUpdateData_Click(object sender, EventArgs e) => Descomprimir();
        private void Descomprimir()
        {
            try
            {
                String rootPath = Server.MapPath("~"); // Obtiene la ruta absoluta del servidor
                if (zips.CheckZipExists(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString().ToLower() + ".zip"))
                {
                    Directory.CreateDirectory(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString().ToLower());
                    zips.ExtractDataZip(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString().ToLower() + ".zip", @rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString().ToLower());
                    DateTime lastUpdate = DateTime.Now;
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = Session["IdUser"].ToString(),
                        LastUpdate = lastUpdate,
                    };
                    if (cliente.WriteParametersUserLastUpdate("RW_Profiles_Register_LastUpdate") == true)
                    {
                        blockUpdateData.Visible = false;
                    }
                    else
                    {
                        Response.Write("<script>alert('Ocurrió un error al momento de actualizar.');</script>");
                    }
                }
                else
                    Response.Redirect("~/Reportes/NoZip.aspx");
            }
            catch (Exception)
            {
                Response.Redirect("~/Reportes/NoZip.aspx");
            }
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
            string valorReporte = Session["TipoReporteEFNT"].ToString();
            switch (valorReporte)
            {
                case "Estado de situación financiera NIIF":
                    Response.Redirect("~/Reportes/EFNTEstadoSitucionFinanciera.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Estado de resultado NIIF: Naturaleza y función":
                    Response.Redirect("~/Reportes/EFNTEstadoResultado.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Balance general tributario":
                    Response.Redirect("~/Reportes/EFNTBalanceGeneral.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Estado de ganancias y pérdidas tributario: Función":
                    Response.Redirect("~/Reportes/EFNTEstadoGananciasPerdidas.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                default:
                    Response.Redirect("~/Reportes/EFNTEstadoGananciasPerdidas.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
            }
        }
        protected void rdbEFNT1_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Estado de situación financiera NIIF";
        protected void rdbEFNT2_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Estado de resultado NIIF: Naturaleza y función";
        protected void rdbEFNT3_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Balance general tributario";
        protected void rdbEFNT4_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteEFNT"] = "Estado de ganancias y pérdidas tributario: Función";

        protected void SelectCompanyByYearFCD(object source, DataListCommandEventArgs e)
        {
            string id = dlstFCD.DataKeys[e.Item.ItemIndex].ToString();
            Session["FCDFechaInicio"] = txtFechaInicio.Text.ToString();
            //Session["FCDFrecuencia"] = lstFrecuenciaPerdiodoFCD.SelectedValue.ToString();
            //Session["FCDPeriodo"] = lstNumeroPeriodosFCD.SelectedValue.ToString();
            Session["FCDFrecuencia"]    = txtFrecuenciaPerdiodoFCD.Text.ToString();
            Session["FCDPeriodo"]       = txtNumeroPeriodosFCD.Text.ToString();
            switch (Session["TipoReporteFCD"].ToString())
            {
                case "Formato simple":
                    if (Session["TipoMonedaFCD"].ToString() == "Nuevos soles")
                        Response.Redirect("~/Reportes/FlujoCajaDetalladoSoles.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    else
                        Response.Redirect("~/Reportes/FlujoCajaDetalladoDolares.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
                case "Formato detallado":
                    if (Session["TipoMonedaFCD"].ToString() == "Nuevos soles")
                        Response.Redirect("~/Reportes/FlujoCajaDetalladoSoles.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    else
                        Response.Redirect("~/Reportes/FlujoCajaDetalladoDolares.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
                    break;
            }
        }
        protected void rdbFCDSimple_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteFCD"] = "Formato simple";
        protected void rdbFCDDetallado_CheckedChanged(object sender, EventArgs e) => Session["TipoReporteFCD"] = "Formato detallado";
        protected void rdbFCDSoles_CheckedChanged(object sender, EventArgs e) => Session["TipoMonedaFCD"] = "Nuevos soles";
        protected void rdbFCDDolares_CheckedChanged(object sender, EventArgs e) => Session["TipoMonedaFCD"] = "Dólares";
    }
}