using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Manager.Controllers
{
    [RoutePrefix("api/vacaciones")]
    public class SolicitudVacacionesController : ApiController
    {
        private readonly string connectionString = "YourConnectionStringHere";  // Configura tu cadena de conexión

        // Crear solicitud de vacaciones
        [HttpPost]
        [Route("solicitudes")]
        public IHttpActionResult CrearSolicitudVacaciones([FromBody] SolicitudVacaciones solicitud)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_CrearSolicitudVacaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmpleadoID", solicitud.EmpleadoID);
                        command.Parameters.AddWithValue("@FechaInicio", solicitud.FechaInicio);
                        command.Parameters.AddWithValue("@FechaFin", solicitud.FechaFin);
                        command.Parameters.AddWithValue("@Comentarios", solicitud.Comentarios);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return Ok(new { message = "Solicitud de vacaciones creada con éxito" });
                        else
                            return BadRequest(new { message = "Error al crear la solicitud de vacaciones" });
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Obtener todas las solicitudes de vacaciones
        [HttpGet]
        [Route("solicitudes")]
        public IHttpActionResult ObtenerSolicitudesVacaciones()
        {
            try
            {
                List<SolicitudVacaciones> solicitudes = new List<SolicitudVacaciones>();

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_ObtenerSolicitudesVacaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                solicitudes.Add(new SolicitudVacaciones
                                {
                                    SolicitudID = Convert.ToInt32(reader["SolicitudID"]),
                                    EmpleadoID = Convert.ToInt32(reader["EmpleadoID"]),
                                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"]),
                                    FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    FechaFin = Convert.ToDateTime(reader["FechaFin"]),
                                    TotalDias = Convert.ToInt32(reader["TotalDias"]),
                                    Estado = reader["Estado"].ToString(),
                                    Comentarios = reader["Comentarios"].ToString()
                                });
                            }
                        }
                    }
                }
                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Obtener una solicitud de vacaciones por ID
        [HttpGet]
        [Route("solicitudes/{solicitudID}")]
        public IHttpActionResult ObtenerSolicitudVacaciones(int solicitudID)
        {
            try
            {
                SolicitudVacaciones solicitud = null;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_ObtenerSolicitudVacacionesPorID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SolicitudID", solicitudID);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                solicitud = new SolicitudVacaciones
                                {
                                    SolicitudID = Convert.ToInt32(reader["SolicitudID"]),
                                    EmpleadoID = Convert.ToInt32(reader["EmpleadoID"]),
                                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"]),
                                    FechaInicio = Convert.ToDateTime(reader["FechaInicio"]),
                                    FechaFin = Convert.ToDateTime(reader["FechaFin"]),
                                    TotalDias = Convert.ToInt32(reader["TotalDias"]),
                                    Estado = reader["Estado"].ToString(),
                                    Comentarios = reader["Comentarios"].ToString()
                                };
                            }
                        }
                    }
                }

                if (solicitud == null)
                    return NotFound();

                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Actualizar solicitud de vacaciones
        [HttpPut]
        [Route("solicitudes/{solicitudID}")]
        public IHttpActionResult ActualizarSolicitudVacaciones(int solicitudID, [FromBody] SolicitudVacaciones solicitud)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_ActualizarSolicitudVacaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SolicitudID", solicitudID);
                        command.Parameters.AddWithValue("@FechaInicio", solicitud.FechaInicio);
                        command.Parameters.AddWithValue("@FechaFin", solicitud.FechaFin);
                        command.Parameters.AddWithValue("@Comentarios", solicitud.Comentarios);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return Ok(new { message = "Solicitud de vacaciones actualizada con éxito" });
                        else
                            return BadRequest(new { message = "Error al actualizar la solicitud de vacaciones" });
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Eliminar solicitud de vacaciones
        [HttpDelete]
        [Route("solicitudes/{solicitudID}")]
        public IHttpActionResult EliminarSolicitudVacaciones(int solicitudID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_EliminarSolicitudVacaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SolicitudID", solicitudID);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return Ok(new { message = "Solicitud de vacaciones eliminada con éxito" });
                        else
                            return BadRequest(new { message = "Error al eliminar la solicitud de vacaciones" });
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Aprobar solicitud de vacaciones
        [HttpPost]
        [Route("solicitudes/aprobar")]
        public IHttpActionResult AprobarSolicitudVacaciones([FromBody] AprobacionSolicitud aprobacion)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_AprobarSolicitudVacaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SolicitudID", aprobacion.SolicitudID);
                        command.Parameters.AddWithValue("@Aprobador", aprobacion.Aprobador);
                        command.Parameters.AddWithValue("@Comentarios", aprobacion.Comentarios);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return Ok(new { message = "Solicitud de vacaciones aprobada con éxito" });
                        else
                            return BadRequest(new { message = "Error al aprobar la solicitud de vacaciones" });
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Rechazar solicitud de vacaciones
        [HttpPost]
        [Route("solicitudes/rechazar")]
        public IHttpActionResult RechazarSolicitudVacaciones([FromBody] AprobacionSolicitud aprobacion)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("sp_RechazarSolicitudVacaciones", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SolicitudID", aprobacion.SolicitudID);
                        command.Parameters.AddWithValue("@Aprobador", aprobacion.Aprobador);
                        command.Parameters.AddWithValue("@Comentarios", aprobacion.Comentarios);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return Ok(new { message = "Solicitud de vacaciones rechazada con éxito" });
                        else
                            return BadRequest(new { message = "Error al rechazar la solicitud de vacaciones" });
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

    // Clases de Solicitudes y Aprobaciones
    public class SolicitudVacaciones
    {
        public int SolicitudID { get; set; }
        public int EmpleadoID { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int TotalDias { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }
    }

    public class AprobacionSolicitud
    {
        public int SolicitudID { get; set; }
        public string Aprobador { get; set; }
        public string Comentarios { get; set; }
    }
}
