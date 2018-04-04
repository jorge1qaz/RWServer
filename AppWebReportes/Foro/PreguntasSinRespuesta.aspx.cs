using System;
using System.Web.UI;
using BusinessLayer;

namespace AppWebReportes.Foro
{
    public partial class PreguntasSinRespuesta : Page
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                dtlListaPreguntasSinRespuesta.DataSource = accesoDatos.Extrae("[foro].[FORO_List_Preguntas_Sin_Responder]");
                dtlListaPreguntasSinRespuesta.DataBind();
            }
        }

        protected void dtlListaPreguntasSinRespuesta_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
        {
            string id = dtlListaPreguntasSinRespuesta.DataKeys[e.Item.ItemIndex].ToString();
            Response.Redirect("~/Foro/Edicion.aspx?idForo=" + id);
        }
    }
}