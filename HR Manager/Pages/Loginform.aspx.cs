using HRManager.App_code;
using System;
using System.Data;
using System.Web.UI;

namespace HRManager.Pages
{
    public partial class Loginform : Page
    {
        private DatabaseHelper dh = new DatabaseHelper(); 

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
          
            string Usuario = username.Value;
            string contraseña = password.Value;

            
            DataRow usuario = UsuarioDAO.IniciarSesion(Usuario, contraseña);

            
            if (Usuario != null)
            {
                
                Response.Redirect("PagEmpleado.aspx");
            }
            else
            {
                
                lblMessage.InnerText = "Nombre de usuario o contraseña incorrectos.";
            }
        }
    }
}




