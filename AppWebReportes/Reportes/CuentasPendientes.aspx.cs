using BusinessLayer;
using System;

namespace AppWebReportes.CP_Reportes
{
    public partial class RW_004 : System.Web.UI.Page
    {
        static string moneda = "", simboloMoneda = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["tipoMonedaRCP"] = null;
                Session["simboloMonedaRCP"] = null;
            }
            if (Session["IdUser"] == null || Request.QueryString["idCompany"] == null || Request.QueryString["year"] == null)
                Response.Redirect("~/Acceso");
            Cliente cliente = new Cliente()
            { IdCliente = Session["IdUser"].ToString() };
            lblNombreUsuario.Text = cliente.IdParameterUserName("RW_header_name_user");
            lblAnio.Text = Request.QueryString["year"].ToString();
            if (Session["tipoMonedaRCP"] == null)
            {
                lblTipoMoneda.Text = "Nuevos soles";
                Session["tipoMonedaRCP"] = "Nuevos soles";
            }
            else
                lblTipoMoneda.Text = Session["tipoMonedaRCP"].ToString();
            if (Session["simboloMonedaRCP"] == null)
                Session["simboloMonedaRCP"] = "S/ ";
            lblMesProceso.Text = lstMes.SelectedItem.ToString();
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para */
        protected void lstTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bool.Parse(lstTipoMoneda.SelectedValue) == true)
            {
                Session["tipoMonedaRCP"] = "Nuevos soles";
                Session["simboloMonedaRCP"] = "S/ ";
            }
            else
            {
                Session["tipoMonedaRCP"] = "Dólares";
                Session["simboloMonedaRCP"] = "$ ";
            }
        }
        //Jorge Luis|17/01/2018|RW-97
        /*Método para */
        protected void lstMes_SelectedIndexChanged(object sender, EventArgs e) => lblMesProceso.Text = lstMes.SelectedItem.ToString();
    }
}