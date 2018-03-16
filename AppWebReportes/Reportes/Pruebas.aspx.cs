using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web.Security;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class FlujoCajaSimpleSoles : System.Web.UI.Page
    {
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad = new Seguridad();
        QueriesCompleteDatabase queriesCompleteDatabase = new QueriesCompleteDatabase();
        Paths paths         = new Paths();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email    = "jorgealcantara5a@gmail.com";
            string ruc      = "1073580496";
            byte[] dataEncrypted    = seguridad.Encrypt2(email, ruc);
            string temporal         = seguridad.Encrypt(email, ruc);
            //string dataEncode = Convert.ToBase64String(dataEncrypted);
            
            Response.Write("<dataEncrypted>" +dataEncrypted + "</dataEncrypted><dataEncode>" + temporal + "</dataEncode>");
            string tempValor = "C0POfodarqM8W7ozXRRXAjM0qorBPrcPB7HsmWLnmX4iWOQ8FWTVD3LO7zL5ovprE7swW5oQs5EH9W7lJ3vEZTznuJuLioroYDv5sQXuXc/GgwJa7hFgeMm/CQ5FXpYl";
            string dataDecrypted = seguridad.Decrypt(tempValor.Replace(" ", "").ToString(), ruc);
            Response.Write("<dataDecrypted>" + dataDecrypted + "</dataDecrypted>");

            // variables temporales
            string user         = "jricra@contasis.net";
            string nameReport   = "rptStdFncr";
            string idCompany    =  /*"02"*/ /*"01"*/"ff"; ;
            string year         = /*"2015"*/ /*"2015"*/"2017";

            String rootPath             = Server.MapPath("~"); //Ruta física
            string dbCompletePlan       = paths.GetStringByFileJson("DataBaseConta", rootPath, user, nameReport, idCompany, year);
            string rubrosCompletePlan   = paths.GetStringByFileJson("listNamesRubros", rootPath, user, nameReport, idCompany, year);



            QueriesCompleteDatabase queriesCompleteDatabase = new QueriesCompleteDatabase() {
                identificacionReporte       = 1,
                jsonDataSetDBComplete       = dbCompletePlan,
                jsonDataSetRubrosByFormatos = rubrosCompletePlan,
                tipoMoneda                  = true,
                mesProceso                  = 12,
            };
            //queriesCompleteDatabase.TotalesByRubros();
            Response.Write(DateTime.Now);
            
        }

        public static List<string> GetLocalIPAddress()
        {
            List<string> ips = new List<string>();
            // Ciclo por todas las interfaces de red en este dispositivo:
            foreach (var interfaces in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Direcciones de unicast asignadas a la interfaz de red actual:
                foreach (var direccion in interfaces.GetIPProperties().UnicastAddresses)
                {
                    // Valida que se trate de una IPv4:
                    if (direccion.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ips.Add(direccion.Address.ToString());
                        //Console.WriteLine("Dirección IP privada: {0}", direccion.Address.ToString());
                    }
                }
            }

            return ips;
        }
        public static string IpServidor() {
            // muestra la IP privada del servidor
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }

        protected void btnPruebas1_Click(object sender, EventArgs e)
        {
            string sIP = Request.UserHostAddress.ToString();
            Response.Write(" sIP: " + sIP);
        }

        protected void btnPruebas2_Click(object sender, EventArgs e)
        {
            string sIP2 = Request.ServerVariables["REMOTE_ADDR"].ToString();
            Response.Write(" sIP2: " + sIP2);
        }

        protected void btnPruebas3_Click(object sender, EventArgs e)
        {
            string HostName = Dns.GetHostEntry(Request.UserHostAddress).HostName;
            Response.Write("HostName: " + HostName);
        }
    }
}