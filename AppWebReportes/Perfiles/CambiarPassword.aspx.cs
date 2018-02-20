using System;
using BusinessLayer;

namespace AppWebReportes.Perfiles
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        static string idEncryted = "";
        static string rucEncryted = "";
        static string idDecrypted = "";
        Seguridad seguridad = new Seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(seguridad.Decrypt("aSQq4xHB8KzJUvG4SeaAn9Mw65/T3AQfqBtP7nZa8ztoofESLAGEkXk18pv28wbo4fxxtHchq8wPN3EJjOVZ4fRSuAi4cMZMxrgoIIrxGF5LokrL/LPCezeSzvViotc", "10735804964"));
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            //TwoParametersUser
            try
            {
                idEncryted = Request.QueryString["G89MbwRigyI7hulrDTK"].Replace(" ", ""); // email
                rucEncryted = Request.QueryString["rdUczXSO0TR4ivfTogsgKLyXT"].Replace(" ", ""); //ruc
                idDecrypted = seguridad.Decrypt(idEncryted, rucEncryted);
                // Instancia de la clase Cliente
                Cliente cliente = new Cliente()
                {
                    IdCliente = idDecrypted.ToString(),
                    Contrasenia = txtConfirmarPassword.Text.ToString().ToLower()
                };
                if (cliente.TwoParametersUser("RW_Profiles_Update_Password"))
                    Response.Write("Funcionó");
                else
                    Response.Write("No Funcionó");
            }
            catch (Exception)
            {
                Response.Write("<script>alert('No hemos podido acceder a tus datos, intentalo nuevamente o contacta con nosotros a soporte.smartreport@gmail.com');</script>");
                Response.Redirect("~/Perfiles/CambioPassword.aspx");
            }
        }
    }
}