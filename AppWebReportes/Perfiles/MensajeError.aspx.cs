using System;

namespace AppWebReportes.Perfiles
{
    public partial class MensajeError : System.Web.UI.Page
    {
        static string bodySolicitudCambioPassword   = "La información brindada no es correcta, has escrito mal tu correo electrónico o tu número de RUC. ¿Deseas volver a intentarlo? ";
        static string headerSolicitudCambioPassword = "Información incorrecta";
        static string bodyCambiarDePassword         = "Ha ocurrido un error al cambiar tu contraseña, por favor vuelve a intentarlo.";
        static string headerCambiarDePassword       = "Error al cambiar la contraseña";
        static string bodyRegistroUsuario           = "Tenemos un problema para registrar sus datos, por favor inténtalo nuevamente.";
        static string headerRegistroUsuario         = "Error al registrar sus datos";
        static string bodyActivacionCuenta          = "Tenemos problemas para activar tu cuenta, por favor inténtalo de nuevo o contacta con nosotros.";
        static string headerActivacionCuenta        = "¡Ha ocurrido un error al activar tu cuenta!";
        static string bodyGeneral                   = "Error inesperado, por favor contacta con nosotros.";
        static string headerGeneral                 = "¡Ha ocurrido un error desconocido!";
        static int tipoMensaje                      = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            tipoMensaje = Convert.ToInt32(Request.QueryString["tipoReporte"]);
            linkCambiarPassword.Visible         = false;
            linkRegistroUsuario.Visible         = false;
            switch (tipoMensaje)
            {
                case 1: // Cuando se trata de una solicitud de cambio de password
                    lblHeader.Text              = headerSolicitudCambioPassword;
                    lblMensajePrincipal.Text    = bodySolicitudCambioPassword;
                    linkCambiarPassword.Visible = true;
                    break;
                case 2: // Cuando se trata de cambiar de password
                    lblHeader.Text              = headerCambiarDePassword;
                    lblMensajePrincipal.Text    = bodyCambiarDePassword;
                    linkCambiarPassword.Visible = true;
                    break;
                case 3: // Cuando se trata de un error al registrar el usuario
                    lblHeader.Text              = headerRegistroUsuario;
                    lblMensajePrincipal.Text    = bodyRegistroUsuario;
                    linkRegistroUsuario.Visible = true;
                    break;
                case 4: // Cuando se trata de un error al activar la cuenta del usuario
                    lblHeader.Text              = headerActivacionCuenta;
                    lblMensajePrincipal.Text    = bodyActivacionCuenta;
                    break;
                default:
                    lblHeader.Text              = headerGeneral;
                    lblMensajePrincipal.Text    = bodyGeneral;
                    break;
            }
        }
    }
}