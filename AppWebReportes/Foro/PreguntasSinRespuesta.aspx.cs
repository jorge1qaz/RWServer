﻿using System;
using System.Web.UI;
using BusinessLayer;

namespace AppWebReportes.Foro
{
    public partial class PreguntasSinRespuesta : Page
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        public string IdUser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Control de la sesión
            linkSesion.Visible = false;
            linkCerrarSesion.Visible = false;
            try
            {
                if (Request.Cookies["mantenerSesion"].Value.ToString() == "1") // Sí el usuario decidió mantener iniciada la sesión, entonces se empleará la cookie
                {
                    try
                    {
                        IdUser = Request.Cookies["idUserCookie"].Value;
                        if (IdUser == "" || IdUser == null) // Se supone que se perdió la cookie
                        {
                            linkSesion.Visible = true;
                            linkCerrarSesion.Visible = false;
                        }
                        else // Aquí se tiene al usuario logeado
                        {
                            linkSesion.Visible = false;
                            linkCerrarSesion.Visible = true;
                            Cliente cliente = new Cliente() // Instancio el objeto CLIENTE
                            { IdCliente = IdUser }; // Guardo en la variable IdCliente el ID del cliente
                            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user"); // Traigo desde la base de datos, el nombre del cliente
                            linkCerrarSesion.Visible = true;
                            linkSesion.Visible = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception) // Si entra al catch es porque no decidió mantener iniciada la sesión
            {
                if (Session["IdUser"] != null)
                {
                    IdUser = Session["IdUser"].ToString();
                    Cliente cliente = new Cliente() // Instancio el objeto CLIENTE
                    { IdCliente = IdUser }; // Guardo en la variable IdCliente el ID del cliente
                    lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user"); // Traigo desde la base de datos, el nombre del cliente
                    linkCerrarSesion.Visible = true;
                    linkSesion.Visible = false;
                }
                else
                {
                    linkSesion.Visible = true;
                    linkCerrarSesion.Visible = false;
                }
            }
            Cliente clienteModerador = new Cliente()
            {
                IdCliente = IdUser
            };
            if (clienteModerador.IdParameterUser("[foro].[FORO_Profiles_Comprobar_Moderador]")) // Sí es true entonces es moderador
            {
                linkCrearItem.Visible = true;
                linkItemsSinRespuesta.Visible = true;
            }
            else
            {
                linkCrearItem.Visible = false;
                linkItemsSinRespuesta.Visible = false;
            }
            #endregion
            if (!Page.IsPostBack)
            {
                dtlListaPreguntasSinRespuesta.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Preguntas_Sin_Responder]");
                dtlListaPreguntasSinRespuesta.DataBind();
            }
        }

        protected void dtlListaPreguntasSinRespuesta_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            string id = dtlListaPreguntasSinRespuesta.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("~/Foro/Edicion.aspx?idForo=" + id);
        }
    }
}