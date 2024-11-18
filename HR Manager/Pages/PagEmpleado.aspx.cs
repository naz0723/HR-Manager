using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class PagEmpleado : Page
    {
        // Cadena de conexión a la base de datos (ajusta según tu configuración)
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRManager"].ConnectionString;

        // Método para agregar un empleado
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string direccion = txtDireccion.Value;
            string contacto = txtContacto.Value;
            string fechaIngreso = txtFechaIngreso.Value;
            string cargo = txtCargo.Value;
            string departamento = txtDepartamento.Value;
            decimal salario = decimal.Parse(txtSalario.Value);
            string adicionadoPor = txtAdicionadoPor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_AgregarEmpleado @Nombre, @Direccion, @Contacto, @FechaIngreso, @Cargo, @Departamento, @Salario, @AdicionadoPor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Contacto", contacto);
                    cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    cmd.Parameters.AddWithValue("@Cargo", cargo);
                    cmd.Parameters.AddWithValue("@Departamento", departamento);
                    cmd.Parameters.AddWithValue("@Salario", salario);
                    cmd.Parameters.AddWithValue("@AdicionadoPor", adicionadoPor);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Empleado agregado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Método para actualizar un empleado
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoIDActualizar.Value;
            string nombre = txtNombreActualizar.Value;
            string direccion = txtDireccionActualizar.Value;
            string contacto = txtContactoActualizar.Value;
            string fechaIngreso = txtFechaIngresoActualizar.Value;
            string cargo = txtCargoActualizar.Value;
            string departamento = txtDepartamentoActualizar.Value;
            decimal salario = decimal.Parse(txtSalarioActualizar.Value);
            string modificadoPor = txtModificadoPor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_ActualizarEmpleado @EmpleadoID, @Nombre, @Direccion, @Contacto, @FechaIngreso, @Cargo, @Departamento, @Salario, @ModificadoPor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Contacto", contacto);
                    cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    cmd.Parameters.AddWithValue("@Cargo", cargo);
                    cmd.Parameters.AddWithValue("@Departamento", departamento);
                    cmd.Parameters.AddWithValue("@Salario", salario);
                    cmd.Parameters.AddWithValue("@ModificadoPor", modificadoPor);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Empleado actualizado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Método para eliminar un empleado
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoIDEliminar.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_EliminarEmpleado @EmpleadoID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Empleado eliminado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Redirige a la página de gestión de estado laboral
        protected void btnPagEstadoLab_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagEstadoLab.aspx");
        }
    }
}
