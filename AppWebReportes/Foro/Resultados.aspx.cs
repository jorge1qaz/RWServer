using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace AppWebReportes.Foro
{
    public partial class Resultados : System.Web.UI.Page
    {
        public string IdUser = "";
        AccesoDatos accesoDatos = new AccesoDatos();
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
                    linkCrearItem.Visible = false;
                    linkItemsSinRespuesta.Visible = false;
                }
                #endregion
                try
                {
                    string query = HttpUtility.UrlEncode(Request.QueryString["query"]);
                    if (query == "")
                    {
                        Response.Redirect("~/Foro/Buscador.aspx", false);
                    }
                    DataTable dataTable = new DataTable();
                    dataTable = accesoDatos.Extrae("[foro].[FORO_List_Items_Cliente]", query.Replace("+", "%"), "@consulta");
                    if (dataTable.Rows.Count > 0)
                    {
                        dtlListaResultados.DataSource = dataTable;
                        dtlListaResultados.DataBind();
                        lblMensajeCeroResultados.Visible = false;
                    }
                    else
                    {
                        lblMensajeCeroResultados.Visible = true;
                    }
                    lblQuery.Text = HttpUtility.UrlDecode(query);
                }
                catch (Exception)
                {
                    Response.Redirect("~/Foro/Buscador.aspx", false);
                }
            }
        }
        protected void dtlListaResultados_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string id = dtlListaResultados.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("~/Foro/Detalle.aspx?idForo=" + id);
        }
    }
}