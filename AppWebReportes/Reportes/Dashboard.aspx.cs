using BusinessLayer;
using System;
using System.IO;

namespace AppWebReportes.Reportes
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
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
                DateTime lastUpadateBefore = Convert.ToDateTime(zips.ReadFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/" + "LastUpdate.txt"));
                zips.ExtractFile(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip", @rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/temp");
                DateTime lastUpadateNow = Convert.ToDateTime(zips.ReadFile(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString() + "/temp/LastUpdate.txt"));
                TimeSpan datediff = lastUpadateBefore.Subtract(lastUpadateNow);
            
                if (Convert.ToDecimal(datediff.TotalMinutes) != 0)
                {
                    blockUpdateData.Visible = true;
                    lblCurrentData.Text = lastUpadateNow.ToString();
                    lblOutdatedData.Text = lastUpadateBefore.ToString();
                }
                else
                    blockUpdateData.Visible = false;
            }
            catch (Exception)
            {
                blockUpdateData.Visible = false;
                try
                {
                    if (zips.checkZipExists(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip"))
                        Descomprimir();
                }
                catch (Exception)
                {
                    Response.Redirect("~/Reportes/NoZip.aspx");
                }
            }
        }
        protected void btnCloseBlockUpdate_Click(object sender, EventArgs e)
        {
            blockUpdateData.Visible = false;
        }
        protected void btnUpdateData_Click(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            if (zips.checkZipExists(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip"))
                Descomprimir();
            else
                Response.Redirect("~/Reportes/NoZip.aspx");
        }
        private void Descomprimir()
        {
            String rootPath = Server.MapPath("~");
            Directory.CreateDirectory(@rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString());
            zips.ExtractDataZip(@rootPath + paths.pathDatosZip + Session["IdUser"].ToString() + ".zip", @rootPath + paths.pathDatosZipExtract + Session["IdUser"].ToString());
        }
    }
}