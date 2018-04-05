using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using BusinessLayer;
using Newtonsoft.Json;

namespace AppWebReportes.Foro
{
    public partial class Edicion : System.Web.UI.Page
    {
        AccesoDatos datos = new AccesoDatos();
        Conexion conexion = new Conexion();
        public string jsonListaTags = "";
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
            if (clienteModerador.IdParameterUser("[foro].[FORO_Profiles_Comprobar_Moderador]")) // Sí es true entonces es moderador, Verifica si el usuario logeado es Moderador o no
            {
                linkCrearItem.Visible = true;
                linkItemsSinRespuesta.Visible = true;
            }
            else
            {
                Response.Redirect("~/Foro/Buscador.aspx", false);
            }
            #endregion
            List<string> listaTags = datos.ExtraeList("[foro].[FORO_List_Tags]");
            jsonListaTags = JsonConvert.SerializeObject(listaTags, Formatting.None);
            if (!Page.IsPostBack)
            {
                SqlCommand cmd          = new SqlCommand();
                Foro_Foros detalleForo  = new Foro_Foros();
                cmd.Connection          = conexion.cadena;
                cmd.CommandType         = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdForo", SqlDbType.Int).Value = Request.QueryString["idForo"];
                cmd.CommandText         = "[foro].[FORO_Details_Foro]";
                SqlDataReader sqlReader;
                conexion.Connect();
                sqlReader               = cmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    detalleForo.Codigo          = sqlReader["Codigo"].ToString();
                    detalleForo.Titulo          = sqlReader["Titulo"].ToString();
                    detalleForo.Descripcion     = sqlReader["Descripcion"].ToString();
                    detalleForo.FechaCreacion   = Convert.ToDateTime(sqlReader["FechaCreacion"]);
                    detalleForo.Respondido      = Convert.ToBoolean(sqlReader["Respondido"]);
                    detalleForo.VotosUtiles     = Convert.ToInt32(sqlReader["VotosUtiles"]);
                    detalleForo.IdProducto      = Convert.ToInt16(sqlReader["IdProducto"]);
                }
                lstProductos.DataSource     = datos.Extrae("[foro].[FORO_List_Productos]");
                lstProductos.DataTextField  = "NombreProducto";
                lstProductos.DataValueField = "IdProducto";
                lstProductos.DataBind();
                lstProductos.SelectedIndex  = lstProductos.Items.IndexOf(lstProductos.Items.FindByValue(detalleForo.IdProducto.ToString()));

                txtCodigo.Text      = detalleForo.Codigo;
                txtTitulo.Text      = detalleForo.Titulo;
                txtDescripcion.InnerText        = detalleForo.Descripcion;
                chbMarcadaComoRespuesta.Checked = detalleForo.Respondido;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (IdUser == "")
            {
                if (Session["IdUser"] != null)
                    IdUser = Session["IdUser"].ToString();
                else
                    Response.Write("<script>alert('Su sesión a caducado, por favor vuelva a iniciar sesión.')</script>");
            }
            Foro_Foros foro_Foros = new Foro_Foros() {
                Codigo = txtCodigo.Text.ToString(),
                Titulo = txtTitulo.Text.ToString(),
                Descripcion = txtDescripcion.InnerText.ToString(),
                Respondido = chbMarcadaComoRespuesta.Checked,
                IdProducto = Int16.Parse(lstProductos.SelectedValue.ToString()),
                IdForo = Request.QueryString["idForo"],
                IdCliente = IdUser,
                DetalleEdicion = txtDetalleEdicion.InnerText.ToString()
            };
            if (foro_Foros.EditItem("[foro].[FORO_Edit_Item]"))
                Response.Redirect("~/Perfiles/MensajeExito?tipoReporte=5", false);
            else
                Response.Redirect("~/Perfiles/MensajeError", false);

        }
    }
}