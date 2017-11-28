﻿using BusinessLayer;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.UI;

namespace AppWebReportes
{
    public partial class prueba3 : System.Web.UI.Page
    {
        Paths paths = new Paths();
        Zips zips = new Zips();
        Directorios dirs = new Directorios();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IdUser"] = "";
            if (!Page.IsPostBack)
            {
                blockContrasenia.Visible = false;
                btnAcceder.Visible = false;
                btnLinkCambiarContrasenia.Visible = false;
            }
        }
        protected void btnComprobarUsuario_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = txtCorreo.Text.ToString()
            };
            if (cliente.IdParameterUser("RW_Security_Check_User"))
            {
                blockContrasenia.Visible = true;
                btnAcceder.Visible = true;
                btnLinkCambiarContrasenia.Visible = true;
                blockCorreo.Visible = false;
                btnComprobarUsuario.Visible = false;
                Session["IdUser"] = txtCorreo.Text.ToString();
            }
            else
                lblDoesNotExistUser.Text = "No pudimos encontrar tu cuenta de Contasis";
        }
        protected async void btnAcceder_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                IdCliente = txtCorreo.Text.ToString(),
                Contrasenia = txtContrasenia.Text.ToString()
            };
            if (cliente.TwoParametersUser("RW_Security_authenticate_User"))
            {
                Session["IdUser"] = txtCorreo.Text.ToString();
                btnAcceder.Enabled = false;
                txtContrasenia.Enabled = false;
                btnAcceder.Visible = false;
                lblErrorPassword.Text = "";
                Task t2 = new Task(Descomprimir);
                t2.Start();
                Task t3 = new Task(() =>
                {
                    while (t2.Status != TaskStatus.RanToCompletion)
                    {
                    }
                    Response.Redirect("~/Reportes/CuentasPendientes.aspx");
                });
                t3.Start();
                await t3;
            }
            else
                lblErrorPassword.Text = "La contraseña es incorrecta. Vuelve a intentarlo.";
        }
        private void Descomprimir()
        {
            Directory.CreateDirectory(paths.pathDatosZipExtract + Session["IdUser"].ToString());
            Zips.ExtractDataZip(paths.pathDatosZip + Session["IdUser"].ToString() + ".zip", paths.pathDatosZipExtract + Session["IdUser"].ToString());
        }
    }
}