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
                lstProductos.DataSource     = datos.Extrae("[foro].[FORO_List_Productos]");
                lstProductos.DataTextField  = "NombreProducto";
                lstProductos.DataValueField = "IdProducto";
                lstProductos.DataBind();
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (IdUser == "")
            {
                if (Session["IdUser"] != null)
                    IdUser = Session["IdUser"].ToString();
                else
                    Response.Write("<script>alert('Su sesión a caducado, por favor vuelva a iniciar sesión.')</script>");
            }
            Foro_Foros foroForos = new Foro_Foros()
            {
                Codigo = txtCodigo.Text.ToString(),
                Titulo = txtTitulo.Text.ToString(),
                Descripcion = txtDescripcion.Value.ToString(),
                FechaCreacion = DateTime.Now,
                Respondido = bool.Parse(chbMarcadaComoRespuesta.Checked.ToString()),
                IdProducto = Int16.Parse(lstProductos.SelectedValue.ToString()),
                IdCliente = IdUser
            };
            if (foroForos.CreateItem("[foro].[FORO_Create_New_Item]"))
                Response.Redirect("~/Perfiles/MensajeExito?tipoReporte=5", false);
            else
                Response.Redirect("~/Perfiles/MensajeError", false);
        }
    }
}