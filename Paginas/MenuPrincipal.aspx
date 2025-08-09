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
                <asp:Button CssClass="btn-menu" Text="Solicitud De Vacaciones" runat="server" PostBackUrl="~/Paginas/SolicitudVacacionesPagina.aspx" />
                <asp:Button CssClass="btn-menu" Text="Crear Constancia Salarial" runat="server" PostBackUrl="~/Paginas/ConstanciaSalarialPagina.aspx" />
                <asp:Button ID="btnLiquidacion" CssClass="btn-menu" Text="Crear Liquidación" runat="server" PostBackUrl="~/Paginas/LiquidacionPagina.aspx" />
                <asp:Button ID="btnEmpleados" CssClass="btn-menu" Text="Gestion de Empleados" runat="server" PostBackUrl="~/Paginas/GestionEmpleados.aspx" />
                <asp:Button ID="btnSalir" CssClass="btn-menu" Text="Salir" runat="server" PostBackUrl="~/Paginas/Login.aspx" OnClick="btnSalirClick" />
            </div>
        </div>
    </form>
    <script src="/Scripts/main.js" defer></script>
</body>
</html>
