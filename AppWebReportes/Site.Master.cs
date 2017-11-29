using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using BusinessLayer;
using System.Data;

namespace AppWebReportes
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente() {
                IdCliente = Session["IdUser"].ToString()
            };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
        }
    }

}