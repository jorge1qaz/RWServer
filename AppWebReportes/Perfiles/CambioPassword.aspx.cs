using BusinessLayer;
using System;

namespace AppWebReportes.Perfiles
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad = new Seguridad();
        static string idEncryped = "";
        static string bodyHTML = "";
        static string email = "";
        static string ruc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente() {
                IdCliente   = txtEmail.Text.ToString().ToLower(),
                RUC         = txtRUC.Text.ToString().ToLower() 
            };
            email = txtEmail.Text.ToString().ToLower().Trim();
            ruc = txtRUC.Text.ToString().ToLower().Trim();
            if (cliente.CheckEmailAndRUC("RW_Security_Check_EmailAndRUC"))
            {
                idEncryped = seguridad.Encrypt(email, ruc);
                bodyHTML = correoElectronico.messageChangePassword(idEncryped, ruc);
                correoElectronico.SendEmail(bodyHTML, email, "Cambio de contraseña, prueba2");
            }
            else
                Response.Write("No Funcionó");
        }
    }
}