using System;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class PagControlHoras : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnAgregarControlHoras_Click(object sender, EventArgs e)
        {
            int empleadoID = Convert.ToInt32(txtEmpleadoID.Value);
            DateTime fecha = Convert.ToDateTime(txtFecha.Value);
            TimeSpan horaEntrada = TimeSpan.Parse(txtHoraEntrada.Value);

            bool success = clControlHoras.AgregarControlHoras(empleadoID, fecha, horaEntrada);

            if (success)
            {
                Response.Write("<script>alert('Control de horas agregado exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al agregar el control de horas');</script>");
            }
        }

        protected void btnActualizarControlHoras_Click(object sender, EventArgs e)
        {
            int controlHorasID = Convert.ToInt32(txtControlHorasID.Value);
            TimeSpan horaSalida = TimeSpan.Parse(txtHoraSalida.Value);

            bool success = clControlHoras.ActualizarControlHoras(controlHorasID, horaSalida);

            if (success)
            {
                Response.Write("<script>alert('Control de horas actualizado exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al actualizar el control de horas');</script>");
            }
        }

        protected void btnEliminarControlHoras_Click(object sender, EventArgs e)
        {
            int controlHorasID = Convert.ToInt32(txtEliminarControlHorasID.Value);

            bool success = clControlHoras.EliminarControlHoras(controlHorasID);

            if (success)
            {
                Response.Write("<script>alert('Control de horas eliminado exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al eliminar el control de horas');</script>");
            }
        }

        protected void btnPagGestionAusencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagGestionAusencias.aspx");
        }


        //private void MostrarMensaje(string mensaje, string tipo)
        //{
        //    // Puedes agregar un contenedor para mostrar el mensaje en la página.
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        //}
    }
}