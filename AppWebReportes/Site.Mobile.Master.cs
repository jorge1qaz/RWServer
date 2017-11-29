using BusinessLayer;
using System;

namespace AppWebReportes
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUser"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            {
                IdCliente = Session["IdUser"].ToString()
            };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
        }
    }
}