using HRManager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HRManager.Pages
{
    public class UsuarioDAO
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        public static DataRow IniciarSesion(string Usuario, string contraseña)
        {
            try
            {
                string query = "sp_IniciarSesion";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Usuario", SqlDbType.NVarChar, 255) { Value = Usuario },
                    new SqlParameter("@Contraseña", SqlDbType.NVarChar, 255) { Value = contraseña },
                };

                DataTable resultado = dh.ExecuteSelectQuery(query, sqlParameters);


                if (resultado.Rows.Count > 0)
                {
                    return resultado.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                dh.LogError(ex);
                throw new Exception("Error al iniciar sesión: ");
            }
        }
    }
}




