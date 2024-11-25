using System;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class Loginform : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsername.Text.Trim();
            string contraseña = txtPassword.Text.Trim();

            try
            {
                // Intentar autenticar al usuario con el DAO
                int? usuarioID = UsuarioDAO.IniciarSesion(usuario, contraseña);

                if (usuarioID.HasValue)
                {
                    // Guardamos el UsuarioID en la sesión
                    Session["UsuarioID"] = usuarioID.Value;

                    // Depuración para verificar la sesión
                    Response.Write("UsuarioID guardado: " + Session["UsuarioID"]);

                    // Redirigir a la página principal
                    Response.Redirect("PagEmpleado.aspx");
                }
                else
                {
                    lblMessage.Text = "Usuario o contraseña incorrectos.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al iniciar sesión: " + ex.Message;
                lblMessage.Visible = true;
            }
        }



    }
}


