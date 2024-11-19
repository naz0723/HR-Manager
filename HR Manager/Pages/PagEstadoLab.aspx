<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagEstadoLab.aspx.cs" Inherits="HR_Manager.Pages.PagEstadoLab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title>Gestión de Estados Laborales</title>
    <link rel="stylesheet" type="text/css" href="../Styles/Estilos.css" />
</head>
<body>
    <form id="formEstadoLab" runat="server">
        <div class="container">
            <h2>Gestión de Estados Laborales</h2>

           
            <div class="form-section">
                <h3>Agregar Estado Laboral</h3>
                <label for="txtEmpleadoID">ID del Empleado:</label>
                <input type="text" id="txtEmpleadoID" runat="server" />

                <label for="txtEstado">Estado:</label>
                <input type="text" id="txtEstado" runat="server" />

                <label for="txtFechaInicio">Fecha de Inicio:</label>
                <input type="date" id="txtFechaInicio" runat="server" />

                <label for="txtFechaFin">Fecha de Fin:</label>
                <input type="date" id="txtFechaFin" runat="server" />

                <label for="txtAdicionadoPor">Añadido por:</label>
                <input type="text" id="txtAdicionadoPor" runat="server" />

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Estado" OnClick="btnAgregar_Click" />
            </div>

            
            <div class="form-section">
                <h3>Actualizar Estado Laboral</h3>
                <label for="txtEstadoLaboralID">ID del Estado Laboral:</label>
                <input type="text" id="txtEstadoLaboralID" runat="server" />

                <label for="txtEmpleadoIDActualizar">ID del Empleado:</label>
                <input type="text" id="txtEmpleadoIDActualizar" runat="server" />

                <label for="txtEstadoActualizar">Nuevo Estado:</label>
                <input type="text" id="txtEstadoActualizar" runat="server" />

                <label for="txtFechaInicioActualizar">Nueva Fecha de Inicio:</label>
                <input type="date" id="txtFechaInicioActualizar" runat="server" />

                <label for="txtFechaFinActualizar">Nueva Fecha de Fin:</label>
                <input type="date" id="txtFechaFinActualizar" runat="server" />

                <label for="txtModificadoPor">Modificado por:</label>
                <input type="text" id="txtModificadoPor" runat="server" />

                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Estado" OnClick="btnActualizar_Click" />
            </div>

            
            <div class="form-section">
                <h3>Eliminar Estado Laboral</h3>
                <label for="txtEstadoLaboralIDEliminar">ID del Estado Laboral:</label>
                <input type="text" id="txtEstadoLaboralIDEliminar" runat="server" />

                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Estado" OnClick="btnEliminar_Click" />
            </div>

            
            <div class="form-section">
                <asp:Button ID="btnPagControlHoras" runat="server" Text="Control de Horarios" OnClick="btnPagControlHoras_Click" />
            </div>
        </div>
    </form>
</body>
</html>