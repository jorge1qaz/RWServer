using System;
using System.Web.Security;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class FlujoCajaSimpleSoles : System.Web.UI.Page
    {
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad = new Seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (true)
            {

            }
            string email    = "jorgealcantara5a@gmail.com";
            string ruc      = "1073580496";
            byte[] dataEncrypted    = seguridad.Encrypt2(email, ruc);
            string temporal         = seguridad.Encrypt(email, ruc);
            //string dataEncode = Convert.ToBase64String(dataEncrypted);
            
            Response.Write("<dataEncrypted>" +dataEncrypted + "</dataEncrypted><dataEncode>" + temporal + "</dataEncode>");
            string tempValor = "C0POfodarqM8W7ozXRRXAjM0qorBPrcPB7HsmWLnmX4iWOQ8FWTVD3LO7zL5ovprE7swW5oQs5EH9W7lJ3vEZTznuJuLioroYDv5sQXuXc/GgwJa7hFgeMm/CQ5FXpYl";
            string dataDecrypted = seguridad.Decrypt(tempValor.Replace(" ", "").ToString(), ruc);
            Response.Write("<dataDecrypted>" + dataDecrypted + "</dataDecrypted>");

        }
    }
}