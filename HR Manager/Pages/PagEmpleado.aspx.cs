using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Manager.Pages
{
    public partial class PagEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si la página está cargando por primera vez, no hacemos nada adicional
        }

        // Método para manejar el evento de agregar empleado
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Value;
                string direccion = txtDireccion.Value;
                string contacto = txtContacto.Value;
                DateTime fechaIngreso = DateTime.Parse(txtFechaIngreso.Value);
                string cargo = txtCargo.Value;
                string departamento = txtDepartamento.Value;
                decimal salario = decimal.Parse(txtSalario.Value);
                string adicionadoPor = txtAdicionadoPor.Value;

                bool resultado = clEmpleado.AgregarEmpleado(nombre, direccion, contacto, fechaIngreso, cargo, departamento, salario, adicionadoPor);

                MostrarMensaje(resultado ? "Empleado agregado correctamente." : "Hubo un error al agregar el empleado.", resultado ? "alert-success" : "alert-danger");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "alert-danger");
            }
        }

        // Método para manejar el evento de actualizar empleado
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int empleadoID = int.Parse(txtEmpleadoIDActualizar.Value); // Obtener ID de empleado
                string nombre = txtNombreActualizar.Value;
                string direccion = txtDireccionActualizar.Value;
                string contacto = txtContactoActualizar.Value;
                DateTime fechaIngreso = DateTime.Parse(txtFechaIngresoActualizar.Value);
                string cargo = txtCargoActualizar.Value;
                string departamento = txtDepartamentoActualizar.Value;
                decimal salario = decimal.Parse(txtSalarioActualizar.Value);
                string modificadoPor = txtModificadoPor.Value;

                bool resultado = clEmpleado.ActualizarEmpleado(empleadoID, nombre, direccion, contacto, fechaIngreso, cargo, departamento, salario, modificadoPor);

                MostrarMensaje(resultado ? "Empleado actualizado correctamente." : "Hubo un error al actualizar el empleado.", resultado ? "alert-success" : "alert-danger");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "alert-danger");
            }
        }

        // Método para manejar el evento de eliminar empleado
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int empleadoID = int.Parse(txtEmpleadoIDEliminar.Value); // Obtener ID de empleado

                bool resultado = clEmpleado.EliminarEmpleado(empleadoID);

                MostrarMensaje(resultado ? "Empleado eliminado correctamente." : "Hubo un error al eliminar el empleado.", resultado ? "alert-success" : "alert-danger");
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error: " + ex.Message, "alert-danger");
            }
        }

        // Redirigir a la página de gestión de estado laboral
        protected void btnPagEstadoLab_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagEstadoLab.aspx");
        }

        // Método para mostrar mensajes en la página
        private void MostrarMensaje(string mensaje, string tipo)
        {
            // Puedes agregar un contenedor para mostrar el mensaje en la página.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}