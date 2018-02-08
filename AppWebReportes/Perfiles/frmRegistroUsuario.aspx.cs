using BusinessLayer;
using System;
using System.IO;
using System.Web.UI;

namespace AppWebReportes.Perfiles
{
    public partial class frmRegistroUsuario : System.Web.UI.Page
    {
        AccesoDatos dat = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Session.Remove("IdUser");

                lstRol.DataSource = dat.Extrae("RW_Profiles_List_roles");
                lstRol.DataTextField = "Descripcion";
                lstRol.DataValueField = "IdRol";
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
                IdCliente = txtConfirmarEmail.Text.ToString(),
                Contrasenia = txtConfirmarPassword.Text.ToString(),
                Nombre = txtNombre.Text.ToString(),
                Apellidos = txtApellidos.Text.ToString(),
                RUC = txtRUC.Text.ToString(),
                ImagenEmpresa = imgCompany,
                ImagenPerfil = imgProfile,
                IdRol = lstRol.SelectedValue.ToString(),
            };
            if (cliente.AllParametersUser("RW_Security_Create_User"))
            {
                Session["RegisterSuccess"] = "success";
                Response.Redirect("~/Acceso.aspx");
            }
            else
            {
                Cliente confirmarCorreo = new Cliente() {
                    IdCliente = txtConfirmarEmail.Text.ToString()
                };
                if (confirmarCorreo.IdParameterUser("RW_Security_Check_User"))
                    Response.Write("Este correo electrónico ya existe, por favor intente con otro.");
                else
                    Response.Write("Algo falló, intentalo mas tarde.");
            }
        }
    }
}