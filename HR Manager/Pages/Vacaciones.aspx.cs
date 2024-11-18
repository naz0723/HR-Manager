using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Manager.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Cadena de conexión a la base de datos (ajusta según tu configuración)
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRManager"].ConnectionString;

        // Método para crear una solicitud de vacaciones
        protected void btnCrearSolicitud_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoID.Value;
            string fechaInicio = txtFechaInicio.Value;
            string fechaFin = txtFechaFin.Value;
            string comentarios = txtComentarios.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_CrearSolicitudVacaciones @EmpleadoID, @FechaInicio, @FechaFin, @Comentarios";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@Comentarios", comentarios);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Solicitud de vacaciones creada exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Método para actualizar una solicitud de vacaciones
        protected void btnActualizarSolicitud_Click(object sender, EventArgs e)
        {
            string solicitudID = txtSolicitudIDActualizar.Value;
            string fechaInicio = txtFechaInicioActualizar.Value;
            string fechaFin = txtFechaFinActualizar.Value;
            string comentarios = txtComentariosActualizar.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_ActualizarSolicitudVacaciones @SolicitudID, @FechaInicio, @FechaFin, @Comentarios";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SolicitudID", solicitudID);
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@Comentarios", comentarios);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Solicitud de vacaciones actualizada exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        // Método para eliminar una solicitud de vacaciones
        protected void btnEliminarSolicitud_Click(object sender, EventArgs e)
        {
            string solicitudID = txtSolicitudIDEliminar.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_EliminarSolicitudVacaciones @SolicitudID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SolicitudID", solicitudID);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Solicitud de vacaciones eliminada exitosamente');</script>");
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