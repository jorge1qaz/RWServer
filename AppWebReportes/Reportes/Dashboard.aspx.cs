using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;

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
            //Tables data company
            string generalInfoConta = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/GeneralInfoConta.json").Trim().Replace("\\'", "'");
            string generalInfoStock = paths.readFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/GeneralInfoStock.json").Trim().Replace("\\'", "'");
            DataSet dataSetGeneralInfoConta = JsonConvert.DeserializeObject<DataSet>(generalInfoConta);
            DataSet dataSetGeneralInfoStock = JsonConvert.DeserializeObject<DataSet>(generalInfoStock);
            DataTable dataTableGeneralInfoConta = dataSetGeneralInfoConta.Tables["data"]; //Declaración de la tabla donde se va a hacer la extracción de datos
            DataTable dataTableGeneralInfoStock = dataSetGeneralInfoStock.Tables["data"];
            grdConta.DataSource = dataTableGeneralInfoConta;
            grdConta.DataBind();
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
    }
}