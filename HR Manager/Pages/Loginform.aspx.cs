using System;
using System.Data;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class Loginform : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña desde los campos de entrada
            string nombreUsuario = username.Value; //   username es un input con runat="server"
            string contrasenna = password.Value; //   password es un input con runat="server"

            // Intentar iniciar sesión utilizando UsuarioDAO
            DataRow usuario = UsuarioDAO.IniciarSesion(nombreUsuario, contrasenna);

            // Verificar si el inicio de sesión fue exitoso
            if (usuario != null)
            {
                // Inicio de sesión exitoso, redirigir a la página del menú
                Response.Redirect("PagEmpleado.aspx");
            }
            else
            {
                // Mostrar un mensaje de error en lblMessage
                lblMessage.InnerText = "Nombre de usuario o contraseña incorrectos."; // lblMessage debe tener runat="server"
            }

        }



    }
}


