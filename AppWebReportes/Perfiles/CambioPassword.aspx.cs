using BusinessLayer;
using System;

namespace AppWebReportes.Perfiles
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad = new Seguridad();
        static string idEncryped = "", bodyHTML = "", email = "", ruc = "", nameCostumer = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["IdUser"] == null) //Comprueba si existe la variable de sesión idUser
                {
                    if (Request.QueryString["IdUser"] != null) //Sí no existe, comprueba si se lo pasaron por URL
                    {
                        txtEmail.Text = Request.QueryString["IdUser"];
                        Session["IdUser"] = txtEmail.Text.ToString();
                    }
                    else
                        txtEmail.Text = ""; // No encontro el correo por ningún medio
                }
                else
                    txtEmail.Text = Session["IdUser"].ToString();
            }
            catch (Exception)
            {
                txtEmail.Text = "";
            }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Cliente getDataCliente = new Cliente() {
                IdCliente = txtEmail.Text.ToString().ToLower()
            };
            nameCostumer = getDataCliente.IdParameterUserName("RW_header_name_user");
            Cliente SendMessagecliente = new Cliente() {
                IdCliente   = txtEmail.Text.ToString().ToLower(),
                RUC         = txtRUC.Text.ToString()
            };
            email = txtEmail.Text.ToString().ToLower().Trim();
            ruc = txtRUC.Text.ToString().Trim();
            if (SendMessagecliente.CheckEmailAndRUC("RW_Security_Check_EmailAndRUC"))
            {
                idEncryped = seguridad.Encrypt(email, ruc);
                bodyHTML = correoElectronico.messageToEmail(idEncryped, ruc, nameCostumer, 1);
                correoElectronico.SendEmail(bodyHTML, email, "Cambio de contraseña");
                Response.Redirect("~/Perfiles/MensajeExito.aspx?tipoReporte=1", false);
            }
            else
                Response.Redirect("~/Perfiles/MensajeError.aspx?tipoReporte=1", false);
        }
    }
}