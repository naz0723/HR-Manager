using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Manager.Pages
{
    public partial class PagControlHoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Lógica de inicialización si es necesario
        }

        // Maneja la acción de agregar un control de horas
        protected void btnAgregarControlHoras_Click(object sender, EventArgs e)
        {
            int empleadoID = Convert.ToInt32(txtEmpleadoID.Value);
            DateTime fecha = Convert.ToDateTime(txtFecha.Value);
            TimeSpan horaEntrada = TimeSpan.Parse(txtHoraEntrada.Value);

            bool success = clControlHoras.AgregarControlHoras(empleadoID, fecha, horaEntrada);

            if (success)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Control de horas agregado exitosamente');</script>");
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Hubo un error al agregar el control de horas');</script>");
            }
        }

        // Maneja la acción de actualizar un control de horas
        protected void btnActualizarControlHoras_Click(object sender, EventArgs e)
        {
            int controlHorasID = Convert.ToInt32(txtControlHorasID.Value);
            TimeSpan horaSalida = TimeSpan.Parse(txtHoraSalida.Value);

            bool success = clControlHoras.ActualizarControlHoras(controlHorasID, horaSalida);

            if (success)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Control de horas actualizado exitosamente');</script>");
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Hubo un error al actualizar el control de horas');</script>");
            }
        }

        // Maneja la acción de eliminar un control de horas
        protected void btnEliminarControlHoras_Click(object sender, EventArgs e)
        {
            int controlHorasID = Convert.ToInt32(txtEliminarControlHorasID.Value);

            bool success = clControlHoras.EliminarControlHoras(controlHorasID);

            if (success)
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Control de horas eliminado exitosamente');</script>");
            }
            else
            {
                // Mensaje de error
                Response.Write("<script>alert('Hubo un error al eliminar el control de horas');</script>");
            }
        }
        // Redirigir a la página de gestión de estado laboral
        protected void btnPagGestionAusencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagGestionAusenciass.aspx");
        }

        // Método para mostrar mensajes en la página
        private void MostrarMensaje(string mensaje, string tipo)
        {
            // Puedes agregar un contenedor para mostrar el mensaje en la página.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}