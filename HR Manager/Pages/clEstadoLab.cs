using HR_Manager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HR_Manager.Pages
{
    public class clEstadoLab
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        /// <summary>
        /// Este método agrega un nuevo dueño utilizando el procedimiento almacenado sp_CrearDueño.
        /// </summary>

        public static bool AgregarEstadoLaboral(int empleadoID, string estado, DateTime fechaInicio, DateTime? fechaFin, string adicionadoPor)
        {
            try
            {
                // Nombre del procedimiento almacenado
                string query = "sp_CrearEstadoLaboral";

                // Parámetros necesarios para el procedimiento almacenado
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@Empleadold", SqlDbType.Int) { Value = empleadoID },
            new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = estado },
            new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio },
            new SqlParameter("@FechaFin", SqlDbType.Date) { Value = (object)fechaFin ?? DBNull.Value },
            new SqlParameter("@AdicionadoPor", SqlDbType.NVarChar, 50) { Value = adicionadoPor }
                };

                // Ejecutar el procedimiento almacenado y obtener las filas afectadas
                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);

                // Retornar true si el estado laboral fue agregado correctamente
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Registrar el error
                dh.LogError(ex);
                return false;
            }
        }
        public static bool ActualizarEstadoLaboral(int estadoLaboralID, int empleadoID, string estado, DateTime fechaInicio, DateTime? fechaFin, string modificadoPor)
        {
            try
            {
                // Nombre del procedimiento almacenado
                string query = "sp_ActualizarEstadoLaboral";

                // Parámetros necesarios para el procedimiento almacenado
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EstadoLaboralID", SqlDbType.Int) { Value = estadoLaboralID },
            new SqlParameter("@Empleadold", SqlDbType.Int) { Value = empleadoID },
            new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = estado },
            new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio },
            new SqlParameter("@FechaFin", SqlDbType.Date) { Value = (object)fechaFin ?? DBNull.Value },
            new SqlParameter("@ModificadoPor", SqlDbType.NVarChar, 50) { Value = modificadoPor }
                };

                // Ejecutar el procedimiento almacenado y obtener las filas afectadas
                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);

                // Retornar true si el estado laboral fue actualizado correctamente
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Registrar el error
                dh.LogError(ex);
                return false;
            }
        }
        public static bool EliminarEstadoLaboral(int estadoLaboralID)
        {
            try
            {
                // Nombre del procedimiento almacenado
                string query = "sp_EliminarEstadoLaboral";

                // Parámetros necesarios para el procedimiento almacenado
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EstadoLaboralID", SqlDbType.Int) { Value = estadoLaboralID }
                };

                // Ejecutar el procedimiento almacenado y obtener las filas afectadas
                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);

                // Retornar true si el estado laboral fue eliminado correctamente
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Registrar el error
                dh.LogError(ex);
                return false;
            }
        }

    }
}
