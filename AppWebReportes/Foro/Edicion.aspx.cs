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
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            
            
            //lstTipos.DataSource = dat.extrae("SP_ListarTipos");
            //lstTipos.DataTextField = "NomTIpo";
            //lstTipos.DataValueField = "IdTipo";
            //lstTipos.DataBind();
            //lstTipos.SelectedIndex = lstTipos.Items.IndexOf(lstTipos.Items.FindByValue(elemento.IdTipo.ToString()));


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session["IdUser"].ToString() != null)
            {
                Foro_Foros foro_Foros = new Foro_Foros() {
                    Codigo = txtCodigo.Text.ToString(),
                    Titulo = txtTitulo.Text.ToString(),
                    Descripcion = txtTitulo.Text.ToString(),
                    Respondido = chbMarcadaComoRespuesta.Checked,
                    IdProducto = Int16.Parse(lstProductos.SelectedValue.ToString()),
                    IdForo = Request.QueryString["idForo"],
                    IdCliente = Session["IdUser"].ToString(),
                    DetalleEdicion = txtDetalleEdicion.InnerText.ToString()
                };
                if (foro_Foros.EditItem("[foro].[FORO_Edit_Item]", 1))
                    Response.Redirect("~/Perfiles/MensajeExito?tipoReporte=5", false);
                else
                    Response.Redirect("~/Perfiles/MensajeError", false);

            }
            else
            {

            }

        }
    }
}