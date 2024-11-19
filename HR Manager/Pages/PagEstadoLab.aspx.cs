using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class PagEstadoLab : Page
    {
        
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRManager"].ConnectionString;

        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoID.Value;
            string estado = txtEstado.Value;
            string fechaInicio = txtFechaInicio.Value;
            string fechaFin = txtFechaFin.Value;
            string adicionadoPor = txtAdicionadoPor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_CrearEstadoLaboral @Empleadold, @Estado, @FechaInicio, @FechaFin, @AdicionadoPor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Empleadold", empleadoID);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@AdicionadoPor", adicionadoPor);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Estado Laboral agregado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string estadoLaboralID = txtEstadoLaboralID.Value;
            string empleadoID = txtEmpleadoIDActualizar.Value;
            string estado = txtEstadoActualizar.Value;
            string fechaInicio = txtFechaInicioActualizar.Value;
            string fechaFin = txtFechaFinActualizar.Value;
            string modificadoPor = txtModificadoPor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_ActualizarEstadoLaboral @EstadoLaboralID, @Empleadold, @Estado, @FechaInicio, @FechaFin, @ModificadoPor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EstadoLaboralID", estadoLaboralID);
                    cmd.Parameters.AddWithValue("@Empleadold", empleadoID);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@ModificadoPor", modificadoPor);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Estado Laboral actualizado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string estadoLaboralID = txtEstadoLaboralIDEliminar.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_EliminarEstadoLaboral @EstadoLaboralID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EstadoLaboralID", estadoLaboralID);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Estado Laboral eliminado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        
        protected void btnPagControlHoras_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagControlHoras.aspx");
        }
    }
}
