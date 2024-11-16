using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Manager.Pages
{
    public partial class PagEstadoLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si la página está cargando por primera vez, no hacemos nada adicional
        }

        // Método para manejar el evento de agregar estado laboral
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int empleadoID = int.Parse(txtEmpleadoID.Value);
                string estado = txtEstado.Value;
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Value);
                DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Value) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Value);
                string adicionadoPor = txtAdicionadoPor.Value;

                bool resultado = clEstadoLab.AgregarEstadoLaboral(empleadoID, estado, fechaInicio, fechaFin, adicionadoPor);

                MostrarMensaje(resultado ? "Estado laboral agregado correctamente." : "Hubo un error al agregar el estado laboral.", resultado ? "alert-success" : "alert-danger");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "alert-danger");
            }
        }

        // Método para manejar el evento de actualizar estado laboral
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int estadoLaboralID = int.Parse(txtEstadoLaboralID.Value);
                int empleadoID = int.Parse(txtEmpleadoIDActualizar.Value);
                string estado = txtEstadoActualizar.Value;
                DateTime fechaInicio = DateTime.Parse(txtFechaInicioActualizar.Value);
                DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFinActualizar.Value) ? (DateTime?)null : DateTime.Parse(txtFechaFinActualizar.Value);
                string modificadoPor = txtModificadoPor.Value;

                bool resultado = clEstadoLab.ActualizarEstadoLaboral(estadoLaboralID, empleadoID, estado, fechaInicio, fechaFin, modificadoPor);

                MostrarMensaje(resultado ? "Estado laboral actualizado correctamente." : "Hubo un error al actualizar el estado laboral.", resultado ? "alert-success" : "alert-danger");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "alert-danger");
            }
        }

        // Método para manejar el evento de eliminar estado laboral
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int estadoLaboralID = int.Parse(txtEstadoLaboralIDEliminar.Value);

                bool resultado = clEstadoLab.EliminarEstadoLaboral(estadoLaboralID);

                MostrarMensaje(resultado ? "Estado laboral eliminado correctamente." : "Hubo un error al eliminar el estado laboral.", resultado ? "alert-success" : "alert-danger");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "alert-danger");
            }
        }

        // Redirigir a la página de gestión de empleados
        protected void btnPagEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagEmpleado.aspx");
        }

        // Método para mostrar mensajes en la página
        private void MostrarMensaje(string mensaje, string tipo)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}