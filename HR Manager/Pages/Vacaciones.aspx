<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagVacaciones.aspx.cs" Inherits="HR_Manager.Pages.PagVacaciones" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Gestión de Solicitudes de Vacaciones</title>
</head>
<body>
    <h1>Gestión de Solicitudes de Vacaciones</h1>

    <!-- Crear Solicitud de Vacaciones -->
    <h2>Crear Solicitud de Vacaciones</h2>
    <form id="formCrearSolicitud" runat="server">
        <label for="txtEmpleadoID">Empleado ID:</label>
        <input type="text" id="txtEmpleadoID" runat="server" /><br />
        <label for="txtFechaInicio">Fecha Inicio:</label>
        <input type="date" id="txtFechaInicio" runat="server" /><br />
        <label for="txtFechaFin">Fecha Fin:</label>
        <input type="date" id="txtFechaFin" runat="server" /><br />
        <label for="txtComentarios">Comentarios:</label>
        <textarea id="txtComentarios" runat="server"></textarea><br />
        <button type="button" onclick="btnCrearSolicitud_Click">Crear Solicitud</button>
    </form>

    <!-- Actualizar Solicitud de Vacaciones -->
    <h2>Actualizar Solicitud de Vacaciones</h2>
    <form id="formActualizarSolicitud" runat="server">
        <label for="txtSolicitudIDActualizar">Solicitud ID:</label>
        <input type="text" id="txtSolicitudIDActualizar" runat="server" /><br />
        <label for="txtFechaInicioActualizar">Fecha Inicio:</label>
        <input type="date" id="txtFechaInicioActualizar" runat="server" /><br />
        <label for="txtFechaFinActualizar">Fecha Fin:</label>
        <input type="date" id="txtFechaFinActualizar" runat="server" /><br />
        <label for="txtComentariosActualizar">Comentarios:</label>
        <textarea id="txtComentariosActualizar" runat="server"></textarea><br />
        <button type="button" onclick="btnActualizarSolicitud_Click">Actualizar Solicitud</button>
    </form>

    <!-- Eliminar Solicitud de Vacaciones -->
    <h2>Eliminar Solicitud de Vacaciones</h2>
    <form id="formEliminarSolicitud" runat="server">
        <label for="txtSolicitudIDEliminar">Solicitud ID:</label>
        <input type="text" id="txtSolicitudIDEliminar" runat="server" /><br />
        <button type="button" onclick="btnEliminarSolicitud_Click">Eliminar Solicitud</button>
    </form>

    <!-- Ver Reportes de Vacaciones -->
    <h2>Reportes de Vacaciones</h2>
    <form id="formReportesVacaciones" runat="server">
        <label for="txtMes">Mes:</label>
        <input type="number" id="txtMes" runat="server" min="1" max="12" /><br />
        <label for="txtAño">Año:</label>
        <input type="number" id="txtAño" runat="server" /><br />
        <button type="button" onclick="btnVerReportes_Click">Ver Reportes</button>
    </form>

    <br />
    <button onclick="btnRegresar_Click">Volver</button>
</body>
</html>
