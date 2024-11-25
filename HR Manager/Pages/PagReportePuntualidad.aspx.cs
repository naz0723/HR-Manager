using System;
using System.Web.UI;

namespace HR_Manager.Pages
{
    public partial class PagReportePuntualidad : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarReporte_Click(object sender, EventArgs e)
        {
            int empleadoID = Convert.ToInt32(txtEmpleadoID.Value);
            int mes = Convert.ToInt32(txtMes.Value);
            int año = Convert.ToInt32(txtAño.Value);
            int diasTarde = Convert.ToInt32(txtDiasTarde.Value);
            int diasCumplidos = Convert.ToInt32(txtDiasCumplidos.Value);
            float horasExtras = float.Parse(txtHorasExtras.Value);

            bool success = clReportePuntualidad.AgregarReporte(empleadoID, mes, año, diasTarde, diasCumplidos, horasExtras);

            if (success)
            {
                Response.Write("<script>alert('Reporte de puntualidad agregado exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al agregar el reporte de puntualidad');</script>");
            }
        }


        protected void btnActualizarReporte_Click(object sender, EventArgs e)
        {
            int reporteID = Convert.ToInt32(txtReporteID.Value);
            int diasTarde = Convert.ToInt32(txtDiasTardeActualizar.Value);
            int diasCumplidos = Convert.ToInt32(txtDiasCumplidosActualizar.Value);
            float horasExtras = float.Parse(txtHorasExtrasActualizar.Value);

            bool success = clReportePuntualidad.ActualizarReporte(reporteID, diasTarde, diasCumplidos, horasExtras);

            if (success)
            {
                Response.Write("<script>alert('Reporte de puntualidad actualizado exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al actualizar el reporte de puntualidad');</script>");
            }
        }


        protected void btnEliminarReporte_Click(object sender, EventArgs e)
        {
            int reporteID = Convert.ToInt32(txtEliminarReporteID.Value);

            bool success = clReportePuntualidad.EliminarReporte(reporteID);

            if (success)
            {
                Response.Write("<script>alert('Reporte de puntualidad eliminado exitosamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('Hubo un error al eliminar el reporte de puntualidad');</script>");
            }
        }
    }
}