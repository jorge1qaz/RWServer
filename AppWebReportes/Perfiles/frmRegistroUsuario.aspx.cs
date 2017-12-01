using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebReportes.Perfiles
{
    public partial class frmRegistroUsuario : System.Web.UI.Page
    {
        AccesoDatos dat = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Session["IdUser"] = "";

                lstRol.DataSource = dat.Extrae("RW_Profiles_List_roles");
                lstRol.DataTextField = "Descripcion";
                lstRol.DataValueField = "IdRol";
                lstRol.DataBind();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string imgProfile = "";
            string imgCompany = "";
            if (fileImagenPerfil.HasFile)
            {
                string archivoPerfil = fileImagenEmpresa.FileName;
                fileImagenEmpresa.SaveAs(MapPath("~/Images/FotoPerfil/" + txtConfirmarEmail.Text.ToString() + ".jpg"));
                imgProfile = "~/Images/FotoPerfil/" + txtConfirmarEmail.Text.ToString() + ".jpg";
            }
            else
                imgProfile = "~/Images/FotoPerfil/" + "nopic.jpg";
            if (fileImagenEmpresa.HasFile)
            {
                string archivoPerfil = fileImagenEmpresa.FileName;
                fileImagenEmpresa.SaveAs(MapPath("~/Images/FotoEmpresa/" + txtConfirmarEmail.Text.ToString() + ".jpg"));
                imgCompany = "~/Images/FotoEmpresa/" + txtConfirmarEmail.Text.ToString() + ".jpg";
            }
            else
                imgCompany = "~/Images/FotoEmpresa/" + "nopic.jpg";
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