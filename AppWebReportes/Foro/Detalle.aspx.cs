﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BusinessLayer;
using Newtonsoft.Json;

namespace AppWebReportes.Foro
{
    public partial class Detalle : System.Web.UI.Page
    {
        public string IdUser = "";
        AccesoDatos accesoDatos = new AccesoDatos();
        Conexion conexion = new Conexion();
        public static string jsonListaTags = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                Cliente clienteModerador = new Cliente() {
                    IdCliente = IdUser
                };
                if (clienteModerador.IdParameterUser("[foro].[FORO_Profiles_Comprobar_Moderador]")) // Sí es true entonces es moderador, Verifica si el usuario logeado es Moderador o no
                {
                    linkCrearItem.Visible = true;
                    linkItemsSinRespuesta.Visible = true;
                    dtlComentariosModeracion.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Comentarios]", Request.QueryString["idForo"].ToString(), "@IdForo");
                    dtlComentariosModeracion.DataBind();
                }
                else
                {
                    linkCrearItem.Visible = false;
                    linkItemsSinRespuesta.Visible = false;
                    dtlComentarios.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Restricted_Comentarios]", Request.QueryString["idForo"].ToString(), "@IdForo");
                    dtlComentarios.DataBind();
                }
                #endregion
                List<string> listaTags = accesoDatos.ExtraeList("[foro].[FORO_List_Tags]");
                jsonListaTags = JsonConvert.SerializeObject(listaTags, Formatting.None);
                if (!Page.IsPostBack)
                {
                    SqlCommand cmd = new SqlCommand();
                    Foro_Foros detalleForo = new Foro_Foros();
                    cmd.Connection = conexion.cadena;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdForo", SqlDbType.Int).Value = Request.QueryString["idForo"];
                    cmd.CommandText = "[foro].[FORO_Details_Foro]";
                    SqlDataReader sqlReader;
                    conexion.Connect();
                    sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        detalleForo.Codigo = sqlReader["Codigo"].ToString();
                        detalleForo.Titulo = sqlReader["Titulo"].ToString();
                        detalleForo.Descripcion = sqlReader["Descripcion"].ToString();
                        detalleForo.FechaCreacion = Convert.ToDateTime(sqlReader["FechaCreacion"]);
                        detalleForo.Respondido = Convert.ToBoolean(sqlReader["Respondido"]);
                        detalleForo.VotosUtiles = Convert.ToInt32(sqlReader["VotosUtiles"]);
                        //detalleForo.NombreProducto = sqlReader["NombreProducto"].ToString();
                    }
                    lblCodigo.Text = detalleForo.Codigo;
                    lblTitulo.Text = detalleForo.Titulo;
                    lblDescripción.Text = detalleForo.Descripcion;
                    lblFechaCreacion.Text = detalleForo.FechaCreacion.ToString();
                    lblVotosItem.Text = detalleForo.VotosUtiles.ToString();

                    if (IdUser == null || IdUser == "") // Cuando el cliente NO esta logeado
                    {
                        linkIniciarSesionComentarios.Visible = true;
                        btnHacerComentario.Visible = false;
                        blockMarcarVotoUtil.Visible = false;
                        dtlComentarios.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Restricted_Comentarios]", Request.QueryString["idForo"].ToString(), "@IdForo");
                        dtlComentarios.DataBind();
                    }
                    else // Cuando el cliente SI esta logeado
                    {
                        linkIniciarSesionComentarios.Visible = false;
                        btnHacerComentario.Visible = true;
                        blockMarcarVotoUtil.Visible = true;
                    }
                }
                dtlEditores.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Editores]", Request.QueryString["idForo"].ToString(), "@IdForo");
                dtlEditores.DataBind();

                Foro_Puntos foro_Puntos = new Foro_Puntos() {
                    IdForo = int.Parse(Request.QueryString["idForo"].ToString()),
                    IdCliente = IdUser
                };
                if (foro_Puntos.GetValuePuntoItem("[foro].[FORO_Get_Value_Punto_Item_Foro]")) // El cliente ya le asignó un punto a favor
                {
                    chbVotoUtilItem.Checked = true;
                    lblMarcarDesmarcarVoto.InnerText = "Quitar punto  ";
                }
                else
                {
                    chbVotoUtilItem.Checked = false;
                    lblMarcarDesmarcarVoto.InnerText = "Marcar como útil  ";
                }

            }
        }
        protected void dtlComentarios_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
        protected void btnHacerComentario_Click(object sender, EventArgs e)
        {
            if (IdUser == "")
            {
                if (Session["IdUser"] != null)
                    IdUser = Session["IdUser"].ToString();
                else
                    Response.Write("<script>alert('Su sesión a caducado, por favor vuelva a iniciar sesión.')</script>");
            }
            Foro_Comentarios foro_Comentarios = new Foro_Comentarios() {
                Descripcion = txtComentario.InnerText.ToString(),
                IdForo      = int.Parse(Request.QueryString["idForo"].ToString()),
                IdCliente   = IdUser 
            };
            if (txtComentario.InnerText.Length < 10)
                Response.Write("<script>alert('Su comentario de demasiado corto, escriba al menos 10 letras.')</script>");
            else
            {
                if (!foro_Comentarios.CreateComentario("[foro].[FORO_Create_New_Comentario]"))
                    Response.Redirect("~/Perfiles/MensajeError.aspx", false);
                else
                {
                    Response.Redirect("~/Foro/Detalle.aspx?idForo=" + Request.QueryString["idForo"].ToString());
                    txtComentario.InnerText = "";
                }
            }
        }
        protected void dtlEditores_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void dtlComentariosModeracion_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string id = dtlComentariosModeracion.DataKeys[e.Item.ItemIndex].ToString();
            Foro_Comentarios foro_Comentarios = new Foro_Comentarios() {
                IdComentario = id
            };
            if (foro_Comentarios.FuncIdComentario("[foro].[FORO_Edit_Habilitar_Comentario]"))
                Response.Redirect("~/Foro/Detalle.aspx?idForo=" + Request.QueryString["idForo"].ToString());
            else
                Response.Redirect("~/Perfiles/MensajeError", false);
        }

        protected void chbVotoUtilItem_CheckedChanged(object sender, EventArgs e)
        {
            if (IdUser == "")
            {
                if (Session["IdUser"] != null)
                    IdUser = Session["IdUser"].ToString();
                else
                    Response.Write("<script>alert('Su sesión a caducado, por favor vuelva a iniciar sesión.')</script>");
            }
            Foro_Puntos foro_Puntos = new Foro_Puntos() {
                IdForo = int.Parse(Request.QueryString["idForo"].ToString()),
                IdCliente = IdUser,
                Punto = chbVotoUtilItem.Checked
            };
            if (foro_Puntos.CreatePuntoItem("[foro].[FORO_Create_New_Punto_Foro]"))
                Response.Redirect("~/Foro/Detalle.aspx?idForo=" + Request.QueryString["idForo"].ToString());
            else
                Response.Redirect("~/Perfiles/MensajeError", false);
        }
    }
}