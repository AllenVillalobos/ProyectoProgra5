<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Paginas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="login">
                <h1>Inicio de Sesión</h1>
                <asp:Label runat="server">Ingresa un Nombre De Usuario</asp:Label>
                <br />
                <asp:TextBox runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server">Ingresa una Contraseña</asp:Label>
                <br />
                <asp:TextBox runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button Text="Ingreso" runat="server"/>
            </div>
        </div>
    </form>
</body>
</html>
