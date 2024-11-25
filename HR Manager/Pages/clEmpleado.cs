using HR_Manager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HR_Manager.Pages
{
    public class clEmpleado
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        public static bool AgregarEmpleado(string nombre, string direccion, string contacto, DateTime fechaIngreso, string cargo, string departamento, decimal salario, string adicionadoPor)
        {
            try
            {
                
                string query = "sp_CrearEmpleado";

                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = nombre },
            new SqlParameter("@Direccion", SqlDbType.NVarChar, 255) { Value = direccion },
            new SqlParameter("@Contacto", SqlDbType.NVarChar, 50) { Value = contacto },
            new SqlParameter("@FechaIngreso", SqlDbType.Date) { Value = fechaIngreso },
            new SqlParameter("@Cargo", SqlDbType.Int) { Value = cargo },
            new SqlParameter("@Departamento", SqlDbType.NVarChar, 100) { Value = departamento },
            new SqlParameter("@Salario", SqlDbType.Decimal) { Value = salario },
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
        public static bool ActualizarEmpleado(int empleadoID, string nombre, string direccion, string contacto, DateTime fechaIngreso, string cargo, string departamento, decimal salario, string modificadoPor)
        {
            try
            {
                
                string query = "sp_ActualizarEmpleado";

                
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoID },
            new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = nombre },
            new SqlParameter("@Direccion", SqlDbType.NVarChar, 255) { Value = direccion },
            new SqlParameter("@Contacto", SqlDbType.NVarChar, 50) { Value = contacto },
            new SqlParameter("@FechaIngreso", SqlDbType.Date) { Value = fechaIngreso },
            new SqlParameter("@Cargo", SqlDbType.Int) { Value = cargo },
            new SqlParameter("@Departamento", SqlDbType.NVarChar, 100) { Value = departamento },
            new SqlParameter("@Salario", SqlDbType.Decimal) { Value = salario },
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

        public static bool EliminarEmpleado(int empleadoID)
        {
            try
            {
                
                string query = "sp_EliminarEmpleado";

                
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoID }
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
