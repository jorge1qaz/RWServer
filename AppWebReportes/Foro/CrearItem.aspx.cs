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

            //if (Request.Cookies["idUserCookie"] != null)
            //{
            //    var value = Request.Cookies["idUserCookie"].Value;
            //    Response.Write(value);
            //}

            //Response.Cookies.Add(Response.Cookies["idUserCookie"]);

            if (Session["IdUser"] == null) //Compruebo que el usuario se haya logeado
            {
                linkSesion.InnerText = "Iniciar sesión";
            }
            else
            {
                Response.Cookies["idUserCookie"].Value   = Session["idUser"].ToString();
                Response.Cookies["idUserCookie"].Expires = DateTime.Now.AddYears(1);
                Cliente cliente = new Cliente() // Instancio el objeto CLIENTE
                { IdCliente = Session["IdUser"].ToString() }; // Guardo en la variable IdCliente el ID del cliente
                lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user"); // Traigo desde la base de datos, el nombre del cliente
                linkSesion.InnerText = "Cerrar sesión";
            }

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
            string valor = Request.Cookies["idUserCookie"].Value;
            Response.Write(valor);
            //if (Session["IdUser"].ToString() != null)
            //{
            //    Foro_Foros foroForos = new Foro_Foros()
            //    {
            //        Codigo = txtCodigo.Text.ToString(),
            //        Titulo = txtTitulo.Text.ToString(),
            //        Descripcion = txtDescripcion.Value.ToString(),
            //        FechaCreacion = DateTime.Now,
            //        Respondido = bool.Parse(chbMarcadaComoRespuesta.Checked.ToString()),
            //        VotosUtiles = 0, // se le asigna cero, ya que apenas se esta creando el ítem
            //        IdProducto = Int16.Parse(lstProductos.SelectedValue.ToString())
            //    };
            //    if (foroForos.CreateItem("[foro].[FORO_Create_New_Item]", 1))
            //        Response.Redirect("~/Perfiles/MensajeExito?tipoReporte=5", false);
            //    else
            //        Response.Redirect("~/Perfiles/MensajeError", false);
            //}
            //else
            //{

            //}
        }
    }
}