using BusinessLayer;
using System;
using System.Web.UI;
using System.Web.Services;
using System.Web;
using System.ComponentModel;

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
            try
            {
                if (Request.Cookies["mantenerSesion"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("mantenerSesion");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
                if (Request.Cookies["idUserCookie"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("idUserCookie");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
            }
            catch
            {
            }
            blockMantenerSesion.Visible = false;
            try
            {
                if (Request.QueryString["tipo"].ToString() == "foro")
                {
                    blockMantenerSesion.Visible = true;
                    Session["tipoRegistro"] = "foro";
                }
            }
            catch
            {
            }
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
                HttpCookie MyCookie = new HttpCookie("idUserCookie");
                MyCookie.Value = paramIdCliente;
                MyCookie.Expires = DateTime.Now.AddDays(365);
                HttpContext.Current.Response.Cookies.Add(MyCookie);
            }
            else
                resultado = false;
            HttpContext.Current.Session.Remove("RegisterSuccess");
            return resultado;
        }
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

        [WebMethod(EnableSession = true)]
        public static int ValidateAccess(string idCliente, string privateIP, string publicIP)
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = idCliente,
                PrivateIP = privateIP,
                PublicIP = publicIP
            };
            bool[] states       = new bool[5];
            states              = cliente.ParametersUser("RW_Security_Register_Access", 1);
            bool[] statesAccess = { states[1], states[2], states[3], states[4] }; // 0 = ok, 1 = IpPrivate...
            int stateFinal      = Array.FindIndex(statesAccess, x => x == true);
            HttpContext.Current.Session["IdUser"]       = idCliente;
            HttpContext.Current.Session["privateIP"]    = privateIP;
            HttpContext.Current.Session["publicIP"]     = publicIP;
            return stateFinal;
        }
        [WebMethod(EnableSession = true)]
        public static int ValidateAsynchronousAccess(string idCliente, string privateIP, string publicIP)
        {
            bool[] states = new bool[5];
            int stateFinal = 0;
            if (HttpContext.Current.Session["IdUser"] != null)
            {
                Cliente cliente = new Cliente()
                {
                    IdCliente   = idCliente,
                    PrivateIP   = privateIP,
                    PublicIP    = publicIP
                };
                states              = cliente.ParametersUserAsynchronous("RW_Security_Asynchronous_Validate_Access");
                bool[] statesAccess = { states[1], states[2], states[3], states[4] }; // 0 = ok, 1 = IpPrivate...
                stateFinal = Array.FindIndex(statesAccess, x => x == true);
            }
            else
                stateFinal = 4; // Sí es 4 es porque ha caducado la variable de sesión, avisar el asuario que lleva mucho tiempo con inactividad y se cerró su sesión
            return stateFinal;
        }

        protected void chbMantenerSesion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMantenerSesion.Checked == true)
            {
                Response.Cookies["mantenerSesion"].Value = "1";
                Response.Cookies["mantenerSesion"].Expires = DateTime.Now.AddYears(1);
            }
        }
    } 
}