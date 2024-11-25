<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagEmpleado.aspx.cs" Inherits="HR_Manager.Pages.PagEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Gestión de Empleados</title>
    <link type="text/css" rel="stylesheet" href="../Styles/Estilos.css" />
</head>
<body>
    <form id="formEmpleados" runat="server">
        <div class="container">
            <h2>Gestión de Empleados</h2>

            <asp:Label ID="lblWelcome" runat="server" CssClass="welcome-message"></asp:Label>

           
            <div class="form-section">
                <h3>Agregar Empleado</h3>
                <label for="txtNombre">Nombre:</label>
                <input type="text" id="txtNombre" runat="server"  />

                <label for="txtDireccion">Dirección:</label>
                <input type="text" id="txtDireccion" runat="server"  />

                <label for="txtContacto">Contacto:</label>
                <input type="text" id="txtContacto" runat="server"  />

                <label for="txtFechaIngreso">Fecha de Ingreso:</label>
                <input type="date" id="txtFechaIngreso" runat="server"  />

                <label for="ddlCargo">Cargo:</label>
                <asp:DropDownList ID="ddlCargo" runat="server">
                </asp:DropDownList>

                <label for="txtDepartamento">Departamento:</label>
                <input type="text" id="txtDepartamento" runat="server"  />

                <label for="txtSalario">Salario:</label>
                <input type="number" id="txtSalario" runat="server"  />

                <label for="txtAdicionadoPor">Añadido por:</label>
                <input type="text" id="txtAdicionadoPor" runat="server"  />

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Empleado" OnClick="btnAgregar_Click" />
            </div>

   
            <div class="form-section">
                <h3>Actualizar Empleado</h3>
                <label for="txtEmpleadoIDActualizar">ID del Empleado:</label>
                <input type="text" id="txtEmpleadoIDActualizar" runat="server"  />

                <label for="txtNombreActualizar">Nuevo Nombre:</label>
                <input type="text" id="txtNombreActualizar" runat="server"  />

                <label for="txtDireccionActualizar">Nueva Dirección:</label>
                <input type="text" id="txtDireccionActualizar" runat="server"  />

                <label for="txtContactoActualizar">Nuevo Contacto:</label>
                <input type="text" id="txtContactoActualizar" runat="server"  />

                <label for="txtFechaIngresoActualizar">Nueva Fecha de Ingreso:</label>
                <input type="date" id="txtFechaIngresoActualizar" runat="server"  />

                <label for="txtCargoActualizar">Nuevo Cargo:</label>
                <input type="text" id="txtCargoActualizar" runat="server"  />

                <label for="txtDepartamentoActualizar">Nuevo Departamento:</label>
                <input type="text" id="txtDepartamentoActualizar" runat="server"  />

                <label for="txtSalarioActualizar">Nuevo Salario:</label>
                <input type="number" id="txtSalarioActualizar" runat="server"  />

                <label for="txtModificadoPor">Modificado por:</label>
                <input type="text" id="txtModificadoPor" runat="server"  />

                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Empleado" OnClick="btnActualizar_Click" />
            </div>

            <div class="form-section">
                <h3>Eliminar Empleado</h3>
                <label for="txtEmpleadoIDEliminar">ID del Empleado:</label>
                <input type="text" id="txtEmpleadoIDEliminar" runat="server"  />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Empleado" OnClick="btnEliminar_Click" />
            </div>


            <div class="form-section">
                <asp:Button ID="btnPagEstadoLab" runat="server" Text="Gestionar Estado Laboral" OnClick="btnPagEstadoLab_Click" />
            </div>
        </div>
    </form>
</body>
</html>
