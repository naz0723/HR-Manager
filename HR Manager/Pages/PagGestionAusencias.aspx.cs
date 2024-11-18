using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Manager.Pages
{
    public partial class PagGestionAusencias : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lógica de inicialización si es necesario
        }

        // Maneja la acción de agregar una ausencia
        protected void btnAgregarAusencia_Click(object sender, EventArgs e)
        {
            int empleadoID = Convert.ToInt32(txtEmpleadoID.Value);
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Value);
            DateTime fechaFin = Convert.ToDateTime(txtFechaFin.Value);
            string tipoAusencia = txtTipoAusencia.Value;
            string motivo = txtMotivo.Value;

            bool success = clGestionAusencias.AgregarAusencia(empleadoID, fechaInicio, fechaFin, tipoAusencia, motivo);

            if (success)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Ausencia agregada exitosamente');</script>");
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Hubo un error al agregar la ausencia');</script>");
            }
        }

        // Maneja la acción de actualizar una ausencia
        protected void btnActualizarAusencia_Click(object sender, EventArgs e)
        {
            int ausenciaID = Convert.ToInt32(txtAusenciaID.Value);
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicioActualizar.Value);
            DateTime fechaFin = Convert.ToDateTime(txtFechaFinActualizar.Value);
            string tipoAusencia = txtTipoAusenciaActualizar.Value;
            string motivo = txtMotivoActualizar.Value;

            bool success = clGestionAusencias.ActualizarAusencia(ausenciaID, fechaInicio, fechaFin, tipoAusencia, motivo);

            if (success)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Ausencia actualizada exitosamente');</script>");
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Hubo un error al actualizar la ausencia');</script>");
            }
        }

        // Maneja la acción de eliminar una ausencia
        protected void btnEliminarAusencia_Click(object sender, EventArgs e)
        {
            int ausenciaID = Convert.ToInt32(txtEliminarAusenciaID.Value);

            bool success = clGestionAusencias.EliminarAusencia(ausenciaID);

            if (success)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Ausencia eliminada exitosamente');</script>");
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Hubo un error al eliminar la ausencia');</script>");
            }
        }
        // Redirigir a la página de gestión de estado laboral
        protected void btnPagReportePuntualidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagReportePuntualidad.aspx");
        }

        // Método para mostrar mensajes en la página
        private void MostrarMensaje(string mensaje, string tipo)
        {
            // Puedes agregar un contenedor para mostrar el mensaje en la página.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}