using System;
using System.Web.Security;
using BusinessLayer;

namespace AppWebReportes.Reportes
{
    public partial class FlujoCajaSimpleSoles : System.Web.UI.Page
    {
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad = new Seguridad();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string bodyEmail = "<h1>Este Email se enviará a mi estimado goge luish</h1><br /><a href='http://licenciacontasis.net/ReportWeb/Acceso'>Ricolino link</a>";
            //correoElectronico.SendEmail(bodyEmail, "jorgealcantara5a@gmail.com", "Cambio de contraseña");

        }
    }
}