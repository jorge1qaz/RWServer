using BusinessLayer;
using System;
using System.IO;
using System.Web.UI;

namespace AppWebReportes.Perfiles
{
    public partial class frmRegistroUsuario : System.Web.UI.Page
    {
        AccesoDatos dat                     = new AccesoDatos();
        CorreoElectronico correoElectronico = new CorreoElectronico();
        Seguridad seguridad                 = new Seguridad();
        static string idEncryped = "", bodyHTML = "", email = "";
        private string keyDecrypt = "QYAkRujflBQzKLxAiD";
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                Session.Remove("IdUser");

                lstRol.DataSource       = dat.Extrae("RW_Profiles_List_roles");
                lstRol.DataTextField    = "Descripcion";
                lstRol.DataValueField   = "IdRol";
                lstRol.DataBind();
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            String rootPath = Server.MapPath("~");
            string imgProfile = "";
            string imgCompany = "";
            if (fileImagenPerfil.HasFile)
            {
                //string archivoPerfil = fileImagenEmpresa.FileName;
                //fileImagenEmpresa.SaveAs(MapPath(rootPath + "/Images/FotoPerfil/" + txtConfirmarEmail.Text.ToString().Replace(".", "") + ".jpg"));
                //imgProfile = rootPath + "/Images/FotoPerfil/" + txtConfirmarEmail.Text.ToString().Replace(".", "") + ".jpg";
                string archivoPerfil = Path.Combine(Server.MapPath("~/Images/FotoPerfil"), fileImagenEmpresa.FileName);
                fileImagenPerfil.SaveAs(archivoPerfil);
                imgProfile = archivoPerfil;
            }
            else
                imgProfile = rootPath + "/Images/FotoPerfil/" + "nopic.jpg";
            if (fileImagenEmpresa.HasFile)
            {
                //string archivoPerfil = fileImagenEmpresa.FileName;
                //fileImagenEmpresa.SaveAs(MapPath(rootPath + "/Images/FotoEmpresa/" + txtConfirmarEmail.Text.ToString().Replace(".", "") + ".jpg"));
                //imgCompany = rootPath + "/Images/FotoEmpresa/" + txtConfirmarEmail.Text.ToString().Replace(".", "") + ".jpg";
                string archivoPerfilEmpresa = Path.Combine(Server.MapPath("~/Images/FotoEmpresa"), fileImagenEmpresa.FileName);
                fileImagenPerfil.SaveAs(archivoPerfilEmpresa);
                imgProfile = archivoPerfilEmpresa;
            }
            else
                imgCompany = rootPath + "/Images/FotoEmpresa/" + "nopic.jpg";
            Cliente cliente = new Cliente()
            {
                IdCliente       = txtConfirmarEmail.Text.ToString().ToLower().Trim(),
                Contrasenia     = txtConfirmarPassword.Text.ToString(),
                Nombre          = txtNombre.Text.ToString().Trim(),
                Apellidos       = txtApellidos.Text.ToString().Trim(),
                RUC             = txtRUC.Text.ToString().Trim(),
                ImagenEmpresa   = imgCompany,
                ImagenPerfil    = imgProfile,
                IdRol           = lstRol.SelectedValue.ToString(),
                ActivacionCuenta= false
            };
            try
            {
                if (cliente.AllParametersUser("RW_Security_Create_User")) // Error
                {
                    email       = txtConfirmarEmail.Text.ToString().Trim().ToLower();
                    idEncryped  = seguridad.Encrypt(txtConfirmarEmail.Text.ToString().Trim().ToLower(), keyDecrypt);
                    bodyHTML    = correoElectronico.messageToEmail(idEncryped, "", txtNombre.Text.ToString().Trim(), 2);
                    correoElectronico.SendEmail(bodyHTML, email, "Activación de cuenta");
                    Response.Redirect("~/Perfiles/MensajeExito.aspx?tipoReporte=3", false);
                }
                else
                {
                    Cliente confirmarCorreo = new Cliente() {
                        IdCliente = txtConfirmarEmail.Text.ToString()
                    };
                    if (confirmarCorreo.IdParameterUser("RW_Security_Check_User"))
                        Response.Write("<script>alert('Ya existe una cuenta con este correo electrónico, por favor intente con otro.')</script>");
                    else
                        Response.Write("Algo falló, intentalo mas tarde.");
                }
            }
            catch (Exception error)
            {
                Response.Redirect("~/Perfiles/MensajeError.aspx?tipoReporte=3");
            }
        }
    }
}