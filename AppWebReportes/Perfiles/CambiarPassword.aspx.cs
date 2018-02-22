using System;
using System.Web;
using BusinessLayer;

namespace AppWebReportes.Perfiles
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        static string idEncrypted   = "";
        static string rucEncrypted  = "";
        static string idDecrypted   = "";
        Seguridad seguridad = new Seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            //idEncrypted     = HttpUtility.UrlEncode(Request.QueryString["G89MbwRigyI7hulrDTK"]).Replace("%2f", "/");
            try
            {
                idEncrypted     = Request.QueryString["G89MbwRigyI7hulrDTK"].Replace(" ", "+");
                rucEncrypted    = Convert.ToString(Request.QueryString["rdUczXSO0TR4ivfTogsgKLyXT"].Replace(" ", "").ToString());
            }
            catch (Exception)
            {
                Response.Redirect("~/Acceso");
            }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                idDecrypted = seguridad.Decrypt(idEncrypted, rucEncrypted);
                Cliente cliente = new Cliente()
                {
                    IdCliente = idDecrypted.ToString(),
                    Contrasenia = txtConfirmarPassword.Text.ToString()
                };
                if (cliente.TwoParametersUser("RW_Profiles_Update_Password", 1))
                    Response.Redirect("~/Perfiles/MensajeExito?tipoReporte=2", false);
                else
                    Response.Redirect("~/Perfiles/MensajeError?tipoReporte=2", false);
            }
            catch (Exception)
            {
                Response.Redirect("~/Perfiles/MensajeError?tipoReporte=2", false);
            }
        }
    }
}