using BusinessLayer;
using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace AppWebReportes
{
    /// <summary>
    /// Summary description for WSasmx
    /// </summary>
    [WebService(Namespace = "http://licenciacontasis.net/reportweb/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
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
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public bool ComprobarUsuarioKey(string paramIdCliente)
        {
            bool resultado = false; // {comprobar existencia de cuenta}
            Cliente cliente = new Cliente()
            { IdCliente = paramIdCliente };
            if (cliente.IdParameterUser("RW_Security_Check_User"))
                resultado = true;
            else
                resultado = false;
            return resultado;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public bool ComprobarUsuarioLicenciador(string paramIdCliente)
        {
            // 0 = init; 
            // 1 = 'El usuario NO pertenece al licenciador';
            // 2 = 'El usuario SI pertenece al licenciador';
            bool resultado                                  = false; // {comprobar existencia de cuenta}
            string resultadoWS                              = string.Empty;
            Licenciador.wsC0nsultCSoapPortClient dataClient = new Licenciador.wsC0nsultCSoapPortClient();
            resultadoWS                                     = dataClient.Execute(paramIdCliente, out resultadoWS);

            if (resultadoWS == "-1") // Sí es TRUE no pertenece al Licenciador
                resultado = false; // El usuario NO pertenece al licenciador
            else
                resultado = true; // El usuario SI pertenece al licenciador (Usuario normal del SmartReport)
            return resultado;
        }
    }
}
