using System;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class PagGestionAusencias : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
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
                Response.Write("<script>alert('Ausencia agregada exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al agregar la ausencia');</script>");
            }
        }

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
                Response.Write("<script>alert('Ausencia actualizada exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al actualizar la ausencia');</script>");
            }
        }

        protected void btnEliminarAusencia_Click(object sender, EventArgs e)
        {
            int ausenciaID = Convert.ToInt32(txtEliminarAusenciaID.Value);

            bool success = clGestionAusencias.EliminarAusencia(ausenciaID);

            if (success)
            {
                Response.Write("<script>alert('Ausencia eliminada exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al eliminar la ausencia');</script>");
            }
        }
        protected void btnPagReportePuntualidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagReportePuntualidad.aspx");
        }

        //private void MostrarMensaje(string mensaje, string tipo)
        //{
        //    // Puedes agregar un contenedor para mostrar el mensaje en la página.
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        //}
    }
}