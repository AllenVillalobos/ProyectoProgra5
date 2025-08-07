<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de Sesión</title>
    <link href="/Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-login fade-in">
            <div class="login-box">
                <h1>Inicio de Sesión</h1>

                <div class="campo">
                    <label for="txtUsuario">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="input-field" />
                </div>

                <div class="campo">
                    <label for="txtPassword">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" />
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn-login" OnClick="btnLoginClick"/>
                <asp:Label ID="lblMensaje" runat="server" CssClass=""></asp:Label>
            </div>
        </div>
    </form>
    <script src="/Scripts/main.js" defer></script>
</body>
</html>
