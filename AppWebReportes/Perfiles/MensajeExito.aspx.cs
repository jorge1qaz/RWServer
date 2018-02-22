﻿using BusinessLayer;
using System;

namespace AppWebReportes.Perfiles
{
    public partial class MensajeExito : System.Web.UI.Page
    {
        static string bodySolicitudCambioPassword   = "Se ha enviado un mensaje a su correo electrónico, para cambiar su contraseña debe acceder al link que le enviamos. Si no lo encuentra busque en la sección de spam.";
        static string headerSolicitudCambioPassword = "¡Solicitud con éxito!";
        static string bodyCambiarDePassword         = "Felicitaciones se ha actualizado tu contraseña, ¿Deseas iniciar sesión?";
        static string headerCambiarDePassword       = "¡Cambio de contraseña con éxito!";
        static string bodyRegistroUsuario           = "¡Estás a punto de crear tu cuenta en SmartReport! Hemos enviado un mensaje a tu correo electrónico con el cual podrás activar tu cuenta, recuerda que sí no lo encuentras, revisa la sección de spam.";
        static string headerRegistroUsuario         = "Activa tu cuenta";
        static string headerActivacionCuenta        = "¡Cuenta activada con éxito!";
        static int tipoMensaje                      = 0;
        Seguridad seguridad                         = new Seguridad();
        static string nameCostumer                  = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            tipoMensaje                         = Convert.ToInt32(Request.QueryString["tipoReporte"]);
            linkAcceso.Visible                  = false;
            switch (tipoMensaje)
            {
                case 1:
                    lblHeader.Text              = headerSolicitudCambioPassword;
                    lblMensajePrincipal.Text    = bodySolicitudCambioPassword;
                    break;
                case 2:
                    lblHeader.Text              = headerCambiarDePassword;
                    lblMensajePrincipal.Text    = bodyCambiarDePassword;
                    linkAcceso.Visible          = true;
                    break;
                case 3: // Cuando se trata de ..
                    lblHeader.Text              = headerRegistroUsuario;
                    lblMensajePrincipal.Text    = bodyRegistroUsuario;
                    break;
                case 4: // Cuando se trata de la activación de la cuenta
                    try
                    {
                        string idEncrypted  = Request.QueryString["AxRGV7gUfmXD7c2YmF"].Replace(" ", "+");
                        string keyDecrypt   = "QYAkRujflBQzKLxAiD";
                        string idDecrypted  = seguridad.Decrypt(idEncrypted, keyDecrypt);
                        Cliente cliente = new Cliente()
                        {
                            IdCliente = idDecrypted.ToString(),
                            ActivacionCuenta = true
                        };
                        if (cliente.TwoParametersUser("RW_Profiles_Activate_Account", 2))
                        {
                            Cliente getDataCliente = new Cliente()
                            {
                                IdCliente = idDecrypted
                            };
                            nameCostumer = getDataCliente.IdParameterUserName("RW_header_name_user");
                            lblHeader.Text              = headerActivacionCuenta;
                            lblMensajePrincipal.Text    = "Felicidades " + nameCostumer + " haz activado tu cuenta, no olvides que ahora debes acceder a tu módulo de escritorio y ejecutar la actualización de datos.";
                            linkAcceso.Visible          = true;
                            Session["RegisterSuccess"] = "success";
                        }
                        else
                            Response.Redirect("~/Perfiles/MensajeError?tipoReporte=4", false);
                    }
                    catch (Exception)
                    {
                        Response.Redirect("~/Perfiles/MensajeError?tipoReporte=4", false);
                    }
                    break;
                default:
                    Response.Redirect("~/Perfiles/MensajeError");
                    break;
            }
        }
    }
}