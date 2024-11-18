using HR_Manager.App_code;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HR_Manager.Pages
{
    public class clEmpleado
    {
        public static DatabaseHelper dh = new DatabaseHelper();

        /// <summary>
        /// Este método agrega un nuevo dueño utilizando el procedimiento almacenado sp_CrearDueño.
        /// </summary>

        public static bool AgregarEmpleado(string nombre, string direccion, string contacto, DateTime fechaIngreso, string cargo, string departamento, decimal salario, string adicionadoPor)
        {
            try
            {
                // Nombre del procedimiento almacenado
                string query = "sp_CrearEmpleado";

                // Parámetros necesarios para el procedimiento almacenado
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = nombre },
            new SqlParameter("@Direccion", SqlDbType.NVarChar, 255) { Value = direccion },
            new SqlParameter("@Contacto", SqlDbType.NVarChar, 50) { Value = contacto },
            new SqlParameter("@FechaIngreso", SqlDbType.Date) { Value = fechaIngreso },
            new SqlParameter("@Cargo", SqlDbType.NVarChar, 100) { Value = cargo },
            new SqlParameter("@Departamento", SqlDbType.NVarChar, 100) { Value = departamento },
            new SqlParameter("@Salario", SqlDbType.Decimal) { Value = salario },
            new SqlParameter("@AdicionadoPor", SqlDbType.NVarChar, 50) { Value = adicionadoPor }
                };

                // Ejecutar el procedimiento almacenado y obtener las filas afectadas
                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);

                // Retornar true si el empleado fue agregado correctamente
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Registrar el error
                dh.LogError(ex);
                return false;
            }
        }
        public static bool ActualizarEmpleado(int empleadoID, string nombre, string direccion, string contacto, DateTime fechaIngreso, string cargo, string departamento, decimal salario, string modificadoPor)
        {
            try
            {
                // Nombre del procedimiento almacenado
                string query = "sp_ActualizarEmpleado";

                // Parámetros necesarios para el procedimiento almacenado
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoID },
            new SqlParameter("@Nombre", SqlDbType.NVarChar, 100) { Value = nombre },
            new SqlParameter("@Direccion", SqlDbType.NVarChar, 255) { Value = direccion },
            new SqlParameter("@Contacto", SqlDbType.NVarChar, 50) { Value = contacto },
            new SqlParameter("@FechaIngreso", SqlDbType.Date) { Value = fechaIngreso },
            new SqlParameter("@Cargo", SqlDbType.NVarChar, 100) { Value = cargo },
            new SqlParameter("@Departamento", SqlDbType.NVarChar, 100) { Value = departamento },
            new SqlParameter("@Salario", SqlDbType.Decimal) { Value = salario },
            new SqlParameter("@ModificadoPor", SqlDbType.NVarChar, 50) { Value = modificadoPor }
                };

                // Ejecutar el procedimiento almacenado y obtener las filas afectadas
                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);

                // Retornar true si el empleado fue actualizado correctamente
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Registrar el error
                dh.LogError(ex);
                return false;
            }
        }

        public static bool EliminarEmpleado(int empleadoID)
        {
            try
            {
                // Nombre del procedimiento almacenado
                string query = "sp_EliminarEmpleado";

                // Parámetros necesarios para el procedimiento almacenado
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
            new SqlParameter("@EmpleadoID", SqlDbType.Int) { Value = empleadoID }
                };

                // Ejecutar el procedimiento almacenado y obtener las filas afectadas
                int rowsAffected = dh.ExecuteNonQuery(query, sqlParameters);

                // Retornar true si el empleado fue eliminado correctamente
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
