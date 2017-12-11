using BusinessLayer;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.UI;

namespace AppWebReportes
{
    public partial class prueba3 : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["IdUser"] != null)
                    Session.Remove("IdUser");
                if (Session["RegisterSuccess"] != null)
                    blockRegisterSuccess.Visible = true;
                else
                    blockRegisterSuccess.Visible = false;
                blockContrasenia.Visible = false;
                btnAcceder.Visible = false;
                btnLinkCambiarContrasenia.Visible = false;
            }
        }
        protected void btnComprobarUsuario_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
                { IdCliente = txtCorreo.Text.ToString() };
            if (cliente.IdParameterUser("RW_Security_Check_User"))
            {
                blockContrasenia.Visible = true;
                btnAcceder.Visible = true;
                btnLinkCambiarContrasenia.Visible = true;
                blockCorreo.Visible = false;
                btnComprobarUsuario.Visible = false;
                Session["IdUser"] = txtCorreo.Text.ToString();
            }
            else
                lblDoesNotExistUser.Text = "No pudimos encontrar tu cuenta de Contasis";
            if (Session["RegisterSuccess"] != null)
                blockRegisterSuccess.Visible = false;
            Session.Remove("RegisterSuccess");
        }
        protected  void btnAcceder_Click(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            Cliente cliente = new Cliente()
            {
                IdCliente = txtCorreo.Text.ToString(),
                Contrasenia = txtContrasenia.Text.ToString()
            };
            if (cliente.TwoParametersUser("RW_Security_authenticate_User"))
            {
                lblErrorPassword.Text = "";
                Response.Redirect("~/Reportes/Dashboard.aspx");
            }
            else
                lblErrorPassword.Text = "La contraseña es incorrecta. Vuelve a intentarlo.";
        }
    }
}