using HR_Manager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace HR_Manager.Pages
{
    public class UsuarioDAO
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        public static int? IniciarSesion(string nombreUsuario, string contrasenna)
        {
            dh = new DatabaseHelper();
            try
            {
                string query = "sp_IniciarSesion";

                // Parámetros de la consulta
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@Usuario", SqlDbType.Text) { Value = nombreUsuario },
            new SqlParameter("@Contraseña", SqlDbType.Text) { Value = contrasenna }
                };

                // Ejecuta la consulta
                DataTable resultado = dh.ExecuteSelectQuery(query, sqlParameters);

                // Verificar si la consulta devolvió resultados
                if (resultado.Rows.Count > 0)
                {
                    // Imprime los resultados para verificar
                    Debug.WriteLine("Usuario encontrado: " + resultado.Rows[0]["UsuarioID"]);
                    return (int?)resultado.Rows[0]["UsuarioID"];
                }
                else
                {
                    Debug.WriteLine("Usuario no encontrado.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Maneja el error si algo sale mal
                dh.LogError(ex);
                Debug.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

    }
}


