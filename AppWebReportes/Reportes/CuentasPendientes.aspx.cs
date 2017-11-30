using BusinessLayer;
using System;
using System.Collections.Generic;

namespace AppWebReportes.CP_Reportes
{
    public partial class RW_004 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (Session["IdUser"] == null)
                Response.Redirect("~/Acceso");
            List<string> listYears = new List<string>();
            if (!Page.IsPostBack)
            {
                List<string> listIdCompanies = new List<string>();
                listIdCompanies = dirs.ListarDirectorios(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString(), paths.pathNameRPC);
                lstEmpresas.DataSource = listIdCompanies;
                lstEmpresas.DataBind();
                listYears = dirs.ListarDirectorios(@rootPath +  paths.pathDatosZipExtract + Session["IdUser"].ToString() + paths.pathNameRPC, listIdCompanies[0].ToString());
                lstAnios.DataSource = listYears;
                lstAnios.DataBind();
                Session["idCompany"] = listIdCompanies[0].ToString();
            }
            else
            {
                listYears = dirs.ListarDirectorios(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + paths.pathNameRPC, lstEmpresas.SelectedValue.ToString());
                lstAnios.DataSource = listYears;
                lstAnios.DataBind();
            }
        }
        Directorios dirs = new Directorios();
        Paths paths = new Paths();
        Zips zips = new Zips();

        protected void lstEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idCompany"] = lstEmpresas.SelectedValue.ToString();
        }
    }
}