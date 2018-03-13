using BusinessLayer;
using System;
using System.Web.UI;
using System.Web.Services;
using System.Web;

namespace AppWebReportes
{
    public partial class prueba3 : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        static bool[] states = new bool[2];
        public static String rootPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["initialPage"] = 1;
            rootPath = Server.MapPath("~");
            if (!Page.IsPostBack)
            {
                if ((string)Session["IdUser"]   != null)
                    Session.Remove("IdUser");
                if (Session["RegisterSuccess"]  != null)
                    blockRegisterSuccess.Visible = true;
                else
                    blockRegisterSuccess.Visible = false;
            }
        }
        //public void ComprobarUsuarioClick()
        //{
        //    Cliente cliente = new Cliente()
        //    { IdCliente = txtCorreo.Text.ToString() };
        //    if (cliente.IdParameterUser("RW_Security_Check_User"))
        //    {
        //        blockContrasenia.Visible = true;
        //        btnAcceder.Visible = true;
        //        btnLinkCambiarContrasenia.Visible = true;
        //        blockCorreo.Visible = false;
        //        btnComprobarUsuario.Visible = false;
        //        Session["IdUser"] = txtCorreo.Text.ToString();
        //        HttpContext.Current.Session["initialPage"] = 0; // 0 = Indica que no es la primera vez que se accede a la página
        //    }
        //    else
        //        lblDoesNotExistUser.Text = "No pudimos encontrar su cuenta de SmartReport";
        //    if (Session["RegisterSuccess"] != null)
        //        blockRegisterSuccess.Visible = false;
        //    Session.Remove("RegisterSuccess");
        //}
        [WebMethod(EnableSession = true)]
        public static bool ComprobarUsuarioKey(string paramIdCliente) {
            bool resultado = false; // {comprobar existencia de cuenta}
            Cliente cliente = new Cliente()
            { IdCliente = paramIdCliente };
            if (cliente.IdParameterUser("RW_Security_Check_User"))
            {
                resultado                                   = true;
                HttpContext.Current.Session["IdUser"]       = paramIdCliente;
                HttpContext.Current.Session["initialPage"]  = 0; // 0 = Indica que no es la primera vez que se accede a la página
            }
            else
                resultado = false;
            HttpContext.Current.Session.Remove("RegisterSuccess");
            return resultado;
        }
        //public void AccederClick()
        //{
        //    Cliente cliente = new Cliente()
        //    {
        //        IdCliente = txtCorreo.Text.ToString(),
        //        Contrasenia = txtContrasenia.Text.ToString()
        //    };
        //    states = cliente.TwoParametersUserArray("RW_Security_authenticate_User");
        //    if (states[0])
        //    {
        //        if (states[1])
        //        {
        //            lblErrorPassword.Text = "";
        //            Response.Redirect("~/Reportes/Dashboard.aspx", false);
        //        }
        //        else
        //            lblErrorPassword.Text = "Tu cuenta no esta activada, por favor revisa tu correo.";
        //    }
        //    else
        //        lblErrorPassword.Text = "La contraseña es incorrecta. Vuelve a intentarlo.";
        //}
        [WebMethod(EnableSession = true)]
        public static string AccederKey(string paramIdCliente, string paramContrasenia) {
            string resultado = ""; //{ "éxito", "comprobación de cuenta activada", "comprobación de contraseña" }
            Cliente cliente = new Cliente()
            {
                IdCliente = paramIdCliente,
                Contrasenia = paramContrasenia
            };
            states = cliente.TwoParametersUserArray("RW_Security_authenticate_User");
            if (states[0])
            {
                if (states[1])
                {
                    resultado                               = "éxito"; // éxito
                    HttpContext.Current.Session["IdUser"]   = paramIdCliente;
                }
                else
                    resultado = "comprobación de cuenta activada";  // comprobación de cuenta activada
            }
            else
                resultado = "comprobación de contraseña";           // comprobación de contraseña
            return resultado;
        }
        protected void btnLinkCambiarContrasenia_Click(object sender, EventArgs e) =>
            Response.Redirect("~/Perfiles/CambioPassword.aspx?IdUser=" + txtCorreo.Text.ToString().Trim().ToLower(), false);
    }
}