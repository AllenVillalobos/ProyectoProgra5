<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudVacaciones.aspx.cs" Inherits="Proyecto.Paginas.SolicitudVacaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="CrearSolicitud">
                <asp:Label runat="server">Escribe la Razon de la Solicitud</asp:Label>
                <asp:TextBox runat="server" Height="250px" Width="75%"></asp:TextBox>
                <br />
                <br />
                <asp:Button Text="Enviar Solicitud" runat="server" />
            </div>
            <div id="ListaEmpleados">
                <asp:GridView runat="server" AutoGenerateColumns="false" EmptyDataText="Empleados No Cargados">
                    <Columns>
                        <asp:BoundField HeaderText="ID" />
                        <asp:BoundField HeaderText="Nombre" />
                        <asp:BoundField HeaderText="Departamento" />
                        <asp:BoundField HeaderText="Puesto" />
                        <asp:BoundField HeaderText="Salario" />
                        <asp:BoundField HeaderText="Jornada" />
                        <asp:BoundField HeaderText="Identificacion" />
                    </Columns>
                </asp:GridView>
                <div id="ListaSolicitudes">
                    <asp:GridView runat="server" AutoGenerateColumns="false" EmptyDataText="No hay Solicitudes Disponibles">
                        <Columns>
                            <asp:BoundField HeaderText="Nuemero De la Solicitud" />
                            <asp:BoundField HeaderText="Detalle" />
                            <asp:BoundField HeaderText="Estado" />
                            <asp:BoundField HeaderText="Fecha de Creacion" />
                            <asp:BoundField HeaderText="NombreCompleto del Empleado" />
                            <asp:BoundField HeaderText="Revisado Por" />
                            <asp:BoundField HeaderText="Fecha Revision" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="ModificarSolicitud">
                    <asp:Label runat="server">Nuemero De la Solicitud</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">Detalle</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">Estado</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">Fecha de Creacion</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">NombreCompleto del Empleado</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">Revisado Por</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">Fecha Revision</asp:Label>
                    <asp:TextBox ReadOnly="true" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label runat="server">Resolucion</asp:Label>
                    <asp:TextBox runat="server"></asp:TextBox>
                    <br />
                    <asp:Button Text="Enviar Camibios" runat="server" />
                </div>
            </div>
    </form>
</body>
</html>
