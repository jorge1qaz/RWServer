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
        public string jsonListaTags = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> listaTags = datos.ExtraeList("[foro].[FORO_List_Tags]");
            jsonListaTags = JsonConvert.SerializeObject(listaTags, Formatting.None);
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
            if (foroForos.CreateItem("[foro].[FORO_Create_New_Item]", 1))
                Response.Redirect("~/Perfiles/MensajeExito?tipoReporte=5", false);
            else
                Response.Redirect("~/Perfiles/MensajeError", false);
        }
    }
}