using System;
using BusinessLayer;

namespace AppWebReportes.Perfiles
{
    public partial class EditarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //EditDataUser
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string IdUser = "";
            try
            {
                if (Session["IdUser"] != null)
                {
                    IdUser = Session["IdUser"].ToString();
                }
                else
                {
                    Response.Redirect("~/Perfiles/MensajeError?tipoReporte=2", false);
                }
                Cliente cliente = new Cliente()
                {
                    IdCliente   = IdUser,
                    Nombre      = txtNombre.Text.ToString(),
                    Apellidos   = txtApellidos.Text.ToString(),
                    RUC         = txtRUC.Text.ToString()
                };
                if (cliente.EditDataUser("[dbo].[RW_Profiles_Update_Datos]"))
                    Response.Redirect("~/Reportes/Dashboard.aspx", false);
                else
                    Response.Redirect("~/Perfiles/MensajeError?tipoReporte=2", false);
            }
            catch (Exception)
            {
                Response.Redirect("~/Perfiles/MensajeError?tipoReporte=2", false);
            }
        }
    }
}