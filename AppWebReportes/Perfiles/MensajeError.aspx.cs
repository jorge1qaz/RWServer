﻿using BusinessLayer;
using System;
using System.Web.Services;

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
        static string headerValidacionAccesos1      = "Validación de acceso en tu misma red";
        static string bodyValidacionAccesos1        = "Estimado usuario, ya antes has accedido desde otro dispositivo diferente en tu misma red, o  tal vez el DHCP te ha cambiado la IP, si deseas iniciar sesión con este medio debes cerrar la anterior sesión.";
        static string headerValidacionAccesos2      = "Validación de acceso";
        static string bodyValidacionAccesos2        = "Estimado usuario, ya antes has accedido desde otro dispositivo diferente, si deseas iniciar sesión con este medio debes cerrar la anterior sesión.";
        static string headerCierreSesion            = "Cierre de sesión";
        static string bodyCierreSesion              = "Estimado usuario, has pasado mucho tiempo sin actividad y tu sesión se ha cerrado para proteger tus datos. Si deseas continuar inicia sesión nuevamente.";

        static string bodyGeneral                   = "Error inesperado, por favor contacta con nosotros.";
        static string headerGeneral                 = "¡Ha ocurrido un error desconocido!";
        static int tipoMensaje                      = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            tipoMensaje = Convert.ToInt32(Request.QueryString["tipoReporte"]);
            linkCambiarPassword.Visible         = false;
            linkRegistroUsuario.Visible         = false;
            btnCerrarSesion.Visible             = false;
            linkAcceso.Visible                  = false;
            switch (tipoMensaje)
            {
                case 1: // Cuando se trata de una solicitud de cambio de password
                    lblHeader.Text              = headerSolicitudCambioPassword;
                    lblMensajePrincipal.Text    = bodySolicitudCambioPassword;
                    linkCambiarPassword.Visible = true;
                    if (Session["IdUser"] != null)
                        Session.Remove("IdUser");
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
                case 5: // Cuando el cliente esta accediendo desde otra IP dentro de su misma red
                    if (Session["IdUser"] == null || Session["privateIP"] == null || Session["publicIP"] == null) //Compruebo que el usuario se haya logeado
                        Response.Redirect("~/Acceso"); //En caso de que no, lo redireciono a la pagina "Acceso"
                    else
                    {
                        lblHeader.Text              = headerValidacionAccesos1;
                        lblMensajePrincipal.Text    = bodyValidacionAccesos1;
                        btnCerrarSesion.Visible     = true;
                    }
                    break;
                case 6: // Cuando se trata de un error al activar la cuenta del usuario
                    if (Session["IdUser"] == null || Session["privateIP"] == null || Session["publicIP"] == null) //Compruebo que el usuario se haya logeado
                        Response.Redirect("~/Acceso"); //En caso de que no, lo redireciono a la pagina "Acceso"
                    else
                    {
                        lblHeader.Text              = headerValidacionAccesos2;
                        lblMensajePrincipal.Text    = bodyValidacionAccesos2;
                        btnCerrarSesion.Visible     = true;
                    }
                    break;
                case 7: // Cuando ha caducado la variable de sesión
                    lblHeader.Text              = headerCierreSesion;
                    lblMensajePrincipal.Text    = bodyCierreSesion;
                    linkAcceso.Visible          = true;
                    break;
                case 8: // Cuando el cliente esta accediendo desde otra IP dentro de su misma red, respuesta para el otro dispositivo
                    if (Session["IdUser"] == null || Session["privateIP"] == null || Session["publicIP"] == null) //Compruebo que el usuario se haya logeado
                        Response.Redirect("~/Acceso"); //En caso de que no, lo redireciono a la pagina "Acceso"
                    else
                    {
                        lblHeader.Text              = headerValidacionAccesos1;
                        lblMensajePrincipal.Text    = bodyValidacionAccesos1;
                        linkAcceso.Visible          = true;
                    }
                    break;
                case 9: // Cuando se trata de un error al activar la cuenta del usuario, respuesta para el otro dispositivo
                    if (Session["IdUser"] == null || Session["privateIP"] == null || Session["publicIP"] == null) //Compruebo que el usuario se haya logeado
                        Response.Redirect("~/Acceso"); //En caso de que no, lo redireciono a la pagina "Acceso"
                    else
                    {
                        lblHeader.Text              = headerValidacionAccesos2;
                        lblMensajePrincipal.Text    = bodyValidacionAccesos2;
                        linkAcceso.Visible          = true;
                    }
                    break;
                default:
                    lblHeader.Text              = headerGeneral;
                    lblMensajePrincipal.Text    = bodyGeneral;
                    break;
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e) => UpdateSesion();
        public void UpdateSesion() {
            string idUser = Session["IdUser"].ToString();
            Cliente cliente = new Cliente()
            {
                IdCliente   = idUser,
                PrivateIP   = Session["privateIP"].ToString(),
                PublicIP    = Session["publicIP"].ToString()
            };
            if (cliente.ParametersUserOneOutPut("RW_Profiles_Update_Sesion_IPs", 1))
            {
                Session["IdUser"] = idUser;
                Response.Redirect("~/Reportes/Dashboard.aspx", false);
            }
            else
                Response.Redirect("~/Perfiles/MensajeError", false);
        }
    }
}