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
                {
                    Response.Redirect("~/Reportes/NoZip.aspx");
                }
            }
            if (!Page.IsPostBack)
            {
                try
                {
                    string generalInfoConta = paths.readFile(@rootPath + paths.pathDatosZipExtract + 
                        Session["IdUser"].ToString() + "/GeneralInfoConta.json").Trim().Replace("\\'", "'");
                    string generalInfoStock = paths.readFile(@rootPath + paths.pathDatosZipExtract + 
                        Session["IdUser"].ToString() + "/GeneralInfoStock.json").Trim().Replace("\\'", "'");
                    DataSet dataSetGeneralInfoConta = JsonConvert.DeserializeObject<DataSet>(generalInfoConta);
                    DataSet dataSetGeneralInfoStock = JsonConvert.DeserializeObject<DataSet>(generalInfoStock);
                    DataTable dataTableGeneralInfoConta = dataSetGeneralInfoConta.Tables["data"]; //Declaración de la tabla donde se va a hacer la extracción de datos
                    DataTable dataTableGeneralInfoStock = dataSetGeneralInfoStock.Tables["data"];
                    dlstCuentasPendientes.DataSource = dataTableGeneralInfoConta;
                    dlstCuentasPendientes.DataBind();
                    dlstMiNegocioAlDia.DataSource = dataTableGeneralInfoConta;
                    dlstMiNegocioAlDia.DataBind();
                    dlstMargenDeUtilidad.DataSource = dataTableGeneralInfoConta;
                    dlstMargenDeUtilidad.DataBind();
                    dlstEstadoResultadoPMS.DataSource = dataTableGeneralInfoConta;
                    dlstEstadoResultadoPMS.DataBind();
                    DataRow[] idCompany = dataTableGeneralInfoConta.Select();
                    Session["idCompany"] = idCompany[0][0].ToString();
                    Session["EDRPMSTipoReporte"] = "naturaleza";
                    Session["EDRPMSTipoMoneda"] = "soles";
                }
                catch (Exception)
                {
                    Descomprimir();
                    //Tables data company
                    string generalInfoConta = paths.readFile(@rootPath + paths.pathDatosZipExtract + 
                        Session["IdUser"].ToString() + "/GeneralInfoConta.json").Trim().Replace("\\'", "'");
                    string generalInfoStock = paths.readFile(@rootPath + paths.pathDatosZipExtract + 
                        Session["IdUser"].ToString() + "/GeneralInfoStock.json").Trim().Replace("\\'", "'");
                    DataSet dataSetGeneralInfoConta = JsonConvert.DeserializeObject<DataSet>(generalInfoConta);
                    DataSet dataSetGeneralInfoStock = JsonConvert.DeserializeObject<DataSet>(generalInfoStock);
                    DataTable dataTableGeneralInfoConta = dataSetGeneralInfoConta.Tables["data"]; //Declaración de la tabla donde se va a hacer la extracción de datos
                    DataTable dataTableGeneralInfoStock = dataSetGeneralInfoStock.Tables["data"];
                    dlstCuentasPendientes.DataSource = dataTableGeneralInfoConta;
                    dlstCuentasPendientes.DataBind();
                    dlstMiNegocioAlDia.DataSource = dataTableGeneralInfoConta;
                    dlstMiNegocioAlDia.DataBind();
                    dlstMargenDeUtilidad.DataSource = dataTableGeneralInfoConta;
                    dlstMargenDeUtilidad.DataBind();
                    DataRow[] idCompany = dataTableGeneralInfoConta.Select();
                    Session["idCompany"] = idCompany[0][0].ToString();
                    Session["EDRPMSTipoReporte"] = "naturaleza";
                    Session["EDRPMSTipoMoneda"] = "soles";
                }
            }
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
            Response.Redirect("~/Reportes/EstadoResultadoPMS.aspx?idCompany=" + Session["idCompany"].ToString() + "&year=" + id);
        }
        protected void chbEDRPMSNaturaleza_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoReporte"] = "naturaleza";
        protected void chbEDRPMSFuncion_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoReporte"] = "funcion";
        protected void chbchbEDRPMSSoles_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoMoneda"] = "soles";
        protected void chbchbEDRPMSDolares_CheckedChanged(object sender, EventArgs e) => Session["EDRPMSTipoMoneda"] = "dolares";
    }
}