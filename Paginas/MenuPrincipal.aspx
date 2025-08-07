<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Proyecto.Paginas.MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menú Principal</title>
    <link href="/Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-menuprincipal fade-in">

            <div id="clima" class="clima-box">
                <!-- Cargar un widget de clima -->
            </div>

            <!-- Accesos / Botones -->
            <div id="accesos" class="accesos-box">
                <asp:Button CssClass="btn-menu" Text="Solicitud De Vacaciones" runat="server" PostBackUrl="~/Paginas/SolicitudVacaciones.aspx" />
                <asp:Button CssClass="btn-menu" Text="Crear Constancia Salarial" runat="server" PostBackUrl="~/Paginas/ConstanciaSalarial.aspx" />
                <asp:Button ID="btnLiquidacion" CssClass="btn-menu" Text="Crear Liquidación" runat="server" PostBackUrl="~/Paginas/Liquidacion.aspx" />
                <asp:Button CssClass="btn-menu" Text="Salir" runat="server" PostBackUrl="~/Paginas/Login.aspx" />
            </div>
        </div>
    </form>
    <script src="/Scripts/main.js" defer></script>
</body>
</html>
