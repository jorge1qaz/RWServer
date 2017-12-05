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
        }
        Directorios dirs = new Directorios();
        Paths paths = new Paths();
        Zips zips = new Zips();

    }
}