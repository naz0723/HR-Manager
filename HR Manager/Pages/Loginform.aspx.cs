using System;
using System.Data;
using System.Diagnostics;
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
            string usuario = username.Value;
            string contraseña = password.Value;

            try
            {
                // Intentar autenticar al usuario con el DAO
                DataRow usuarioID = UsuarioDAO.IniciarSesion(usuario, contraseña);

                if (usuario != null)
                {
                    // Inicio de sesión exitoso, redirigir a la página del menú
                    Response.Redirect("PagEmpleado.aspx");
                }
                else
                {
                    // Mostrar un mensaje de error en lblMessage
                    lblMessage.Text = "Usuario o contraseña incorrectos.";
                    lblMessage.Visible = true; // lblMessage debe tener runat="server"
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


