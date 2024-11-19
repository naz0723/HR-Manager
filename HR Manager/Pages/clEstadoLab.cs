using HR_Manager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HR_Manager.Pages
{
    public class clEstadoLab
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        

        public static bool AgregarEstadoLaboral(int empleadoID, string estado, DateTime fechaInicio, DateTime? fechaFin, string adicionadoPor)
        {
            try
            {
                
                string query = "sp_CrearEstadoLaboral";

                
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@Empleadold", SqlDbType.Int) { Value = empleadoID },
            new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = estado },
            new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio },
            new SqlParameter("@FechaFin", SqlDbType.Date) { Value = (object)fechaFin ?? DBNull.Value },
            new SqlParameter("@AdicionadoPor", SqlDbType.NVarChar, 50) { Value = adicionadoPor }
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
        public static bool ActualizarEstadoLaboral(int estadoLaboralID, int empleadoID, string estado, DateTime fechaInicio, DateTime? fechaFin, string modificadoPor)
        {
            try
            {
                
                string query = "sp_ActualizarEstadoLaboral";

                
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EstadoLaboralID", SqlDbType.Int) { Value = estadoLaboralID },
            new SqlParameter("@Empleadold", SqlDbType.Int) { Value = empleadoID },
            new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = estado },
            new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio },
            new SqlParameter("@FechaFin", SqlDbType.Date) { Value = (object)fechaFin ?? DBNull.Value },
            new SqlParameter("@ModificadoPor", SqlDbType.NVarChar, 50) { Value = modificadoPor }
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
        public static bool EliminarEstadoLaboral(int estadoLaboralID)
        {
            try
            {
                
                string query = "sp_EliminarEstadoLaboral";

                
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EstadoLaboralID", SqlDbType.Int) { Value = estadoLaboralID }
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
