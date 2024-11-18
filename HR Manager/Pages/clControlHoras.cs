using HR_Manager.App_code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HR_Manager.Pages
{
    public class clControlHoras
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        /// <summary>
        /// Este método agrega un nuevo dueño utilizando el procedimiento almacenado sp_CrearDueño.
        /// </summary>

        public static bool AgregarControlHoras(int empleadoID, DateTime fecha, TimeSpan horaEntrada)
        {
            try
            {
                string query = "sp_CrearControlHoras";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoID },
                new SqlParameter("@Fecha", SqlDbType.Date) { Value = fecha },
                new SqlParameter("@HoraEntrada", SqlDbType.Time) { Value = horaEntrada }
                };

                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                dh.LogError(ex);
                return false;
            }
        }

        public static bool ActualizarControlHoras(int controlHorasID, TimeSpan horaSalida)
        {
            try
            {
                string query = "sp_ActualizarControlHoras";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@ControlHorasID", SqlDbType.Int) { Value = controlHorasID },
                new SqlParameter("@HoraSalida", SqlDbType.Time) { Value = horaSalida }
                };

                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                dh.LogError(ex);
                return false;
            }
        }

        public static bool EliminarControlHoras(int controlHorasID)
        {
            try
            {
                string query = "sp_EliminarControlHoras";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@ControlHorasID", SqlDbType.Int) { Value = controlHorasID }
                };

                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                dh.LogError(ex);
                return false;
            }
        }
    }
}
