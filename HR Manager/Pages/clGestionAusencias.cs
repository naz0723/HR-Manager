using HR_Manager.App_code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HR_Manager.Pages
{
    public class clGestionAusencias
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        /// <summary>
        /// Este método agrega un nuevo dueño utilizando el procedimiento almacenado sp_CrearDueño.
        /// </summary>

        public static bool AgregarAusencia(int empleadoID, DateTime fechaInicio, DateTime fechaFin, string tipoAusencia, string motivo)
        {
            try
            {
                string query = "sp_CrearGestionAusencias";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoID },
                new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio },
                new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin },
                new SqlParameter("@TipoAusencia", SqlDbType.NVarChar, 50) { Value = tipoAusencia },
                new SqlParameter("@Motivo", SqlDbType.NVarChar, 255) { Value = motivo }
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

        public static bool ActualizarAusencia(int ausenciaID, DateTime fechaInicio, DateTime fechaFin, string tipoAusencia, string motivo)
        {
            try
            {
                string query = "sp_ActualizarGestionAusencias";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@AusenciaID", SqlDbType.Int) { Value = ausenciaID },
                new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio },
                new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin },
                new SqlParameter("@TipoAusencia", SqlDbType.NVarChar, 50) { Value = tipoAusencia },
                new SqlParameter("@Motivo", SqlDbType.NVarChar, 255) { Value = motivo }
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

        public static bool EliminarAusencia(int ausenciaID)
        {
            try
            {
                string query = "sp_EliminarGestionAusencias";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@AusenciaID", SqlDbType.Int) { Value = ausenciaID }
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