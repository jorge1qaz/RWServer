using BusinessLayer;
using System;
using System.Web;
using System.Web.Services;

namespace AppWebReportes
{
    /// <summary>
    /// Summary description for WSasmx
    /// </summary>
    [WebService(Namespace = "http://licenciacontasis.net/reportweb/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSasmx : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public static int ValidateAsynchronousAccess(string idCliente, string privateIP, string publicIP)
        {
            bool[] states = new bool[5];
            int stateFinal = 0;
            if (HttpContext.Current.Session["IdUser"] != null)
            {
                Cliente cliente = new Cliente()
                {
                    IdCliente = idCliente,
                    PrivateIP = privateIP,
                    PublicIP = publicIP
                };
                states = cliente.ParametersUser("RW_Security_Asynchronous_Validate_Access", 1);
                bool[] statesAccess = { states[1], states[2], states[3], states[4] }; // 0 = ok, 1 = IpPrivate...
                stateFinal = Array.FindIndex(statesAccess, x => x == true);
            }
            else
                stateFinal = 4; // Sí es 4 es porque ha caducado la variable de sesión, avisar el asuario que lleva mucho tiempo con inactividad y se cerró su sesión
            return stateFinal;
        }
    }
}
