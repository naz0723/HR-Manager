<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginform.aspx.cs" Inherits="HR_Manager.Pages.Loginform" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de Sesión</title>
    <link type="text/css" rel="stylesheet" href="../Styles/Estilos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Inicio de Sesión</h2>
            <label for="txtUsername">Usuario</label>
            <input type="text" id="username" name="user" runat="server" required>
            <label for="txtPassword">Contraseña</label>
            <input type="password" id="password" name="pass" runat="server" required>
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="BtnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>

