using HR_Manager.App_code;
using System;
using System.Data;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class Loginform : Page
    {
        private DatabaseHelper dh = new DatabaseHelper(); 

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
          
            string Usuario = username.Value;
            string contraseña = password.Value;

            
            DataRow usuario = UsuarioDAO.IniciarSesion(Usuario, contraseña);

            
            if (Usuario != null)
            {
                
                Response.Redirect("PagEmpleado.aspx", false);
            }
            else
            {
                
                lblMessage.InnerText = "Nombre de usuario o contraseña incorrectos.";
            }
        }
    }
}




