using System;
using System.Collections.Generic;
using System.Data;
using BusinessLayer;
using Newtonsoft.Json;

namespace AppWebReportes.Foro
{
    public partial class CrearItem : System.Web.UI.Page
    {
        AccesoDatos datos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> listaTags = datos.ExtraeList("[foro].[FORO_List_Tags]");
            string json = JsonConvert.SerializeObject(listaTags, Formatting.None);
            Response.Write(json);
            if (!Page.IsPostBack)
            {
                lstProductos.DataSource     = datos.Extrae("[foro].[FORO_List_Productos]");
                lstProductos.DataTextField  = "NombreProducto";
                lstProductos.DataValueField = "IdProducto";
                lstProductos.DataBind();
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            ForoForosClass foroForos = new ForoForosClass()
            {
                Codigo = txtCodigo.Text.ToString(),
                Titulo = txtTitulo.Text.ToString(),
                Descripcion = txtDescripcion.Value.ToString(),
                FechaCreacion = DateTime.Now,
                Respondido = bool.Parse(chbMarcadaComoRespuesta.Checked.ToString()),
                VotosUtiles = 0, // se le asigna cero, ya que apenas se esta creando el ítem
                IdProducto = Int16.Parse(lstProductos.SelectedValue.ToString())
            };
            foroForos.CreateItem("[foro].[FORO_Create_New_Item]", 1);
        }
    }
}