using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HR_Manager.Pages
{
    public partial class PagEmpleado : Page
    {
        // Cadena de conexión a la base de datos (ajusta según tu configuración)
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HRManager"].ConnectionString;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        CargarCargos();
        //    }
        //}

        //private void CargarCargos()
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT CargoID, CargoNombre FROM Cargos"; // Ajusta según tu tabla
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            ddlCargo.DataSource = reader;
        //            ddlCargo.DataTextField = "CargoNombre";
        //            ddlCargo.DataValueField = "CargoID";
        //            ddlCargo.DataBind();

        //            ddlCargo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Seleccionar Cargo--", ""));
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert('Error al cargar cargos: " + ex.Message + "');</script>");
        //        }
        //    }
        //}

        //private void CargarCargos()
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT CargoID, NombreCargo FROM Cargos"; // Ajusta según la estructura de tu tabla.
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            ddlCargo.DataSource = reader;
        //            ddlCargo.DataTextField = "NombreCargo"; // Campo que se mostrará en la lista.
        //            ddlCargo.DataValueField = "CargoID"; // Valor del campo (ID).
        //            ddlCargo.DataBind();

        //            ddlCargo.Items.Insert(0, new ListItem("-- Seleccione un cargo --", "0"));
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("<script>alert('Error al cargar cargos: " + ex.Message + "');</script>");
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreCompleto"] != null)
            {
                lblWelcome.Text = "Bienvenido, " + Session["NombreCompleto"].ToString();
            }
            else
            {
                Response.Redirect("Loginform.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Value;
            string direccion = txtDireccion.Value;
            string contacto = txtContacto.Value;
            string fechaIngreso = txtFechaIngreso.Value;
            string cargo = ddlCargo.SelectedValue;
            string departamento = txtDepartamento.Value;
            decimal salario = decimal.Parse(txtSalario.Value);
            string adicionadoPor = txtAdicionadoPor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_CrearEmpleado @Nombre, @Direccion, @Contacto, @FechaIngreso, @Cargo, @Departamento, @Salario, @AdicionadoPor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Contacto", contacto);
                    cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    cmd.Parameters.AddWithValue("@Cargo", cargo);
                    cmd.Parameters.AddWithValue("@Departamento", departamento);
                    cmd.Parameters.AddWithValue("@Salario", salario);
                    cmd.Parameters.AddWithValue("@AdicionadoPor", adicionadoPor);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Empleado agregado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoIDActualizar.Value;
            string nombre = txtNombreActualizar.Value;
            string direccion = txtDireccionActualizar.Value;
            string contacto = txtContactoActualizar.Value;
            string fechaIngreso = txtFechaIngresoActualizar.Value;
            string cargo = txtCargoActualizar.Value;
            string departamento = txtDepartamentoActualizar.Value;
            decimal salario = decimal.Parse(txtSalarioActualizar.Value);
            string modificadoPor = txtModificadoPor.Value;
            DateTime fechaModificacion = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_ActualizarEmpleado @EmpleadoID, @Nombre, @Direccion, @Contacto, @FechaIngreso, @Cargo, @Departamento, @Salario, @ModificadoPor";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Direccion", direccion);
                    cmd.Parameters.AddWithValue("@Contacto", contacto);
                    cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    cmd.Parameters.AddWithValue("@Cargo", cargo);
                    cmd.Parameters.AddWithValue("@Departamento", departamento);
                    cmd.Parameters.AddWithValue("@Salario", salario);
                    cmd.Parameters.AddWithValue("@ModificadoPor", modificadoPor);
                    cmd.Parameters.AddWithValue("@FechaModificacion", fechaModificacion);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Empleado actualizado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string empleadoID = txtEmpleadoIDEliminar.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "EXEC sp_EliminarEmpleado @EmpleadoID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Empleado eliminado exitosamente');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        protected void btnPagEstadoLab_Click(object sender, EventArgs e)
        {
            Response.Redirect("PagEstadoLab.aspx");
        }
    }
}
