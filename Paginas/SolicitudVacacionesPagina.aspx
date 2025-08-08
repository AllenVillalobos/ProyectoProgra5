<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="SolicitudVacacionesPagina.aspx.cs" Inherits="Proyecto.Paginas.SolicitudVacacionesPagina" %>

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
                <asp:Button ID="btnEnviarSolicitud" runat="server" Text="Enviar Solicitud" CssClass="btn-action" OnClick="btnEnviarSolicitudClick" />
            <asp:Label runat="server" ID="lblMensaje"></asp:Label>
            </section>

            <!-- 2) Lista de empleados -->
            <section class="lista-wrapper" runat="server" id="stListaEmpleados">
                <h2 class="section-title">Empleados</h2>
                <div class="table-container">
                    <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false" 
                        EmptyDataText="Empleados No Cargados" DataKeyNames="idEmpleado" 
                         OnSelectedIndexChanged="gvEmpleadosSelectedIndexChanged"
                        AutoGenerateSelectButton="True">
                        <Columns>
                            <asp:BoundField DataField="idEmpleado" HeaderText="ID" />
                            <asp:BoundField DataField="nombreCompleto" HeaderText="Nombre" />
                            <asp:BoundField DataField="nombreDepartamento" HeaderText="Departamento" />
                            <asp:BoundField DataField="nombrePuesto" HeaderText="Puesto" />
                            <asp:BoundField DataField="salarioBruto" HeaderText="Salario" DataFormatString="{0:C2}" />
                            <asp:BoundField DataField="nombreJornada" HeaderText="Jornada" />
                            <asp:BoundField DataField="identificacion" HeaderText="Identificación" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnCargarEmpleados" runat="server" Text="CargarEmpleados" CssClass="btn-action" OnClick="btnCargarEmpleadosClick" />
                </div>
            </section>

            <!-- 3) Lista de solicitudes -->
            <section class="lista-wrapper" runat="server" id="stListaSolicitudes">
                <h2 class="section-title">Solicitudes Existentes</h2>
                <div class="table-container">
                    <asp:GridView ID="gvSolicitudes" runat="server" AutoGenerateColumns="false" 
                        EmptyDataText="No hay Solicitudes Disponibles" 
                        DataKeyNames="idSolicitudVacaciones,detalle,estado,fechaAdicion,empleadoNombre,revisadoPor,fechaRevision"
                        OnSelectedIndexChanged="gvSolicitudesSelectedIndexChanged" 
                        AutoGenerateSelectButton="true">
                        <Columns>
                            <asp:BoundField DataField="idSolicitudVacaciones" HeaderText="Nº Solicitud" />
                            <asp:BoundField DataField="detalle" HeaderText="Detalle" />
                            <asp:BoundField DataField="estado" HeaderText="Estado" />
                            <asp:BoundField DataField="fechaAdicion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="empleadoNombre" HeaderText="Empleado" />
                            <asp:BoundField DataField="revisadoPor" HeaderText="Revisado Por" />
                            <asp:BoundField DataField="fechaRevision" HeaderText="Fecha Revisión" DataFormatString="{0:dd/MM/yyyy}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </section>

            <!-- 4) Modificar solicitud -->
            <section class="form-container" runat="server" id="stModificar">
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
                <asp:Button ID="btnModificarSolicitud" runat="server" Text="Enviar Cambios" CssClass="btn-action" OnClick="btnModificarSolicitudClick" />
            </section>
        </div>
    </form>
    <script src="/Scripts/main.js" defer></script>
</body>
</html>
