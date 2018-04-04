using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace AppWebReportes.Foro
{
    public partial class Resultados : System.Web.UI.Page
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string query = HttpUtility.UrlEncode(Request.QueryString["query"]);
                    if (query == "")
                    {
                        Response.Redirect("~/Foro/Buscador.aspx", false);
                    }
                    dtlListaResultados.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Items_Cliente]", query.Replace("+", "%"), "@consulta");
                    dtlListaResultados.DataBind();
                    lblQuery.Text = query.Replace("+", " ");
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