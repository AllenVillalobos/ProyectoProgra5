<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudVacaciones.aspx.cs" Inherits="Proyecto.Paginas.SolicitudVacaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Solicitud de Vacaciones</title>
    <link href="/Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-solicitudvacaciones fade-in">

            <!-- 1) Formulario de nueva solicitud -->
            <section class="form-container">
                <h2>Crear Solicitud de Vacaciones</h2>
                <div class="campo">
                    <label for="txtDetalle">Razón de la Solicitud</label>
                    <asp:TextBox ID="txtDetalle" runat="server" TextMode="MultiLine" CssClass="input-field" Height="150px" />
                </div>
                <asp:Button ID="btnEnviarSolicitud" runat="server" Text="Enviar Solicitud" CssClass="btn-action" />
            </section>

            <!-- 2) Lista de empleados -->
            <section class="lista-wrapper">
                <h2 class="section-title">Empleados</h2>
                <div class="table-container">
                    <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false" EmptyDataText="Empleados No Cargados">
                        <Columns>
                            <asp:BoundField DataField="EmpleadoID" HeaderText="ID" />
                            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
                            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                            <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                            <asp:BoundField DataField="Salario" HeaderText="Salario" DataFormatString="{0:C2}" />
                            <asp:BoundField DataField="Jornada" HeaderText="Jornada" />
                            <asp:BoundField DataField="Identificacion" HeaderText="Identificación" />
                        </Columns>
                    </asp:GridView>
                </div>
            </section>

            <!-- 3) Lista de solicitudes -->
            <section class="lista-wrapper">
                <h2 class="section-title">Solicitudes Existentes</h2>
                <div class="table-container">
                    <asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay Solicitudes Disponibles">
                        <Columns>
                            <asp:BoundField DataField="SolicitudID" HeaderText="Nº Solicitud" />
                            <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="NombreCompleto" HeaderText="Empleado" />
                            <asp:BoundField DataField="RevisadoPor" HeaderText="Revisado Por" />
                            <asp:BoundField DataField="FechaRevision" HeaderText="Fecha Revisión" DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </section>

            <!-- 4) Modificar solicitud -->
            <section class="form-container">
                <h2>Modificar Solicitud</h2>
                <div class="campo">
                    <label for="txtSolID">Nº de Solicitud</label>
                    <asp:TextBox ID="txtSolID" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label for="txtSolDet">Detalle</label>
                    <asp:TextBox ID="txtSolDet" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label for="txtSolEstado">Estado</label>
                    <asp:TextBox ID="txtSolEstado" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label for="txtSolFecha">Fecha de Creación</label>
                    <asp:TextBox ID="txtSolFecha" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label for="txtSolEmpleado">Empleado</label>
                    <asp:TextBox ID="txtSolEmpleado" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label for="txtSolRevisor">Revisado Por</label>
                    <asp:TextBox ID="txtSolRevisor" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label for="txtSolRes">Resolución</label>
                    <asp:TextBox ID="txtSolRes" runat="server" CssClass="input-field" />
                </div>
                <asp:Button ID="btnModificarSolicitud" runat="server" Text="Enviar Cambios" CssClass="btn-action" />
            </section>

        </div>
    </form>
    <script src="/Scripts/main.js" defer></script>
</body>
</html>
