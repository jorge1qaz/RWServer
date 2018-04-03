using System;
using System.Collections.Generic;
using System.Data;
using BusinessLayer;
using Newtonsoft.Json;

namespace AppWebReportes.Foro
{
    public partial class Buscador : System.Web.UI.Page
    {
        AccesoDatos datos = new AccesoDatos();
        public string IdUser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            linkSesion.Visible = false;
            linkCerrarSesion.Visible = false;

            Response.Write(Request.Cookies["mantenerSesion"].Value.ToString());
            try
            {
                if (Request.Cookies["mantenerSesion"].Value.ToString() != null && Request.Cookies["mantenerSesion"].Value.ToString() == "1") // Comprobamos que el usuario haya permitido el uso de cookies
                {
                    if (Session["IdUser"] != null) //Compruebo que el usuario se haya logeado
                    {
                        Response.Cookies["idUserCookie"].Value = Session["idUser"].ToString();
                        Response.Cookies["idUserCookie"].Expires = DateTime.Now.AddYears(1);
                        IdUser = Response.Cookies["idUserCookie"].Value.ToString();
                    } // despues de esto sí no existe la variable de sesión obviamente esta almacenado en la cookie
                    else
                    {
                        try
                        {
                            IdUser = Response.Cookies["idUserCookie"].Value.ToString();
                        }
                        catch (Exception x)
                        {
                            IdUser = "";
                        }
                    }
                }
                else // Esto quiere decir que la sesión debe durar poco, solo lo que dure la vida de una variable de sesión común 
                {
                    if (Session["IdUser"] != null) // Compruebo que el usuario se haya logeado
                    {
                        IdUser = Session["IdUser"].ToString();
                    }
                    else
                    {
                        linkSesion.InnerText = "Iniciar sesión";
                        linkCerrarSesion.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                if (Session["IdUser"] != null) // Compruebo que el usuario se haya logeado
                {
                    IdUser = Session["IdUser"].ToString();
                }
            }
            
            if (IdUser != "") //Compruebo que el usuario se haya logeado
            {
                Cliente cliente = new Cliente() // Instancio el objeto CLIENTE
                { IdCliente = IdUser }; // Guardo en la variable IdCliente el ID del cliente
                lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user"); // Traigo desde la base de datos, el nombre del cliente
                linkCerrarSesion.Visible = true;
                linkSesion.Visible = false;
            }
            else
            {
                linkCerrarSesion.Visible = false;
                linkSesion.Visible = true;
            }
        }
    }
}