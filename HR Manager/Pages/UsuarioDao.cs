using HR_Manager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HR_Manager.Pages
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

                // Verificar si se obtuvo algún resultado
                if (resultado.Rows.Count > 0)
                {
                    return resultado.Rows[0];
                }
                else
                {
                    // Las credenciales son incorrectas, mostrar mensaje de error.
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Loggear el error.
                dh.LogError(ex);

                // También podrías considerar lanzar una excepción para que la aplicación gestione el error apropiadamente.
                throw new Exception("Error al iniciar sesión.", ex);
            }
        }
    }
}




