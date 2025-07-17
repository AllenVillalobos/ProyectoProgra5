<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Proyecto.Paginas.MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menú Principal</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="clima">

            </div>
            <div id="accesos">
                <asp:Button Text="Solicitud De Vacaciones" runat="server" />
                <asp:Button Text="Crear Constancia Salarial" runat="server" />
                <asp:Button Text="Crear Liquidacion" runat="server" />
                <asp:Button Text="Ingreso" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
