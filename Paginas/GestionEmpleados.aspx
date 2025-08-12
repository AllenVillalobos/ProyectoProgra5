<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionEmpleados.aspx.cs" Inherits="Proyecto.Paginas.GestionEmpleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Botón Atrás  -->
        <div class="back-fixed">
            <a href="MenuPrincipal.aspx"
                class="btn-back fade-in"
                onclick="return goBack('MenuPrincipal.aspx')">Atrás
    </a>
        </div>
        <div>
            <h1>Crear Empleados</h1>
            <div class="form-container">
                <div class="campo">
                    <label for="calFecha">Fecha de Contratacion</label>
                    <asp:Calendar ID="calFecha" runat="server" CssClass="calendar" />
                </div>
                <asp:Label Text="Identificacion del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtIdentificacionC"></asp:TextBox>
                <asp:Label Text="Primer Nombre del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombreC1"></asp:TextBox>
                <asp:Label Text="Segundo Nombre del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombreC2"></asp:TextBox>
                <asp:Label Text="Primer Apellido del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtApellidoC1"></asp:TextBox>
                <asp:Label Text="Segundo Apellido del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtApellidoC2"></asp:TextBox>
                <asp:Label Text="Salario" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtSalarioCr"></asp:TextBox>
                <asp:DropDownList ID="ddlPuestoC" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlDepartamentoC" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlJornadaC" runat="server">
                </asp:DropDownList>
                <asp:Button runat="server" ID="btnCrearEmpleado" Text="Crear" OnClick="btnCrearEmpleadoClick" />

                <h1>Lista de Empleados</h1>
                <section class="lista-wrapper" runat="server" id="stListaEmpleados">
                    <h2 class="section-title">Empleados</h2>
                    <div class="table-container">
                        <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false"
                            EmptyDataText="Empleados No Cargados"
                            DataKeyNames="idEmpleado,primerNombre,segundoNombre,primerApellido,segundoApellido,
                            fechaContratacion,nombreDepartamento,nombrePuesto,salarioBruto,nombreJornada,identificacion"
                            OnSelectedIndexChanged="gvEmpleadosSelectedIndexChanged"
                            AutoGenerateSelectButton="True">
                            <Columns>
                                <asp:BoundField DataField="idEmpleado" HeaderText="ID" />
                                <asp:BoundField DataField="primerNombre" HeaderText="Primer Nombre" />
                                <asp:BoundField DataField="segundoNombre" HeaderText="Segundo Nombre" />
                                <asp:BoundField DataField="primerApellido" HeaderText="Primer Apellido" />
                                <asp:BoundField DataField="segundoApellido" HeaderText="Segundo Apellido" />
                                <asp:BoundField DataField="fechaContratacion" HeaderText="Fecha de Contratación" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="nombreDepartamento" HeaderText="Departamento" />
                                <asp:BoundField DataField="nombrePuesto" HeaderText="Puesto" />
                                <asp:BoundField DataField="salarioBruto" HeaderText="Salario" DataFormatString="{0:C2}" />
                                <asp:BoundField DataField="nombreJornada" HeaderText="Jornada" />
                                <asp:BoundField DataField="identificacion" HeaderText="Identificación" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </section>

                <h1>Editar/Eliminar Empleados</h1>
                <asp:Label Text="ID del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtIdEmpleado"></asp:TextBox>
                <asp:Label Text="Identificacion del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtIdentificacionE"></asp:TextBox>
                <asp:Label Text="Primer Nombre del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombreE1"></asp:TextBox>
                <asp:Label Text="Segundo Nombre del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtNombreE2"></asp:TextBox>
                <asp:Label Text="Primer Apellido del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtApellidoE1"></asp:TextBox>
                <asp:Label Text="Segundo Apellido del Emplado" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtApellidoE2"></asp:TextBox>
                <asp:Label Text="Salario" runat="server"></asp:Label>
                <asp:TextBox runat="server" ID="txtSalarioEd"></asp:TextBox>
                <asp:DropDownList ID="ddlPuestoE" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlDepartamentoE" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlJornadaE" runat="server">
                </asp:DropDownList>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificarClick" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminarClick" />
            </div>
        </div>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
    <script>
        function goBack(fallback) {
            var url = fallback || 'MenuPrincipal.aspx';
            try {
                if (document.referrer && new URL(document.referrer, location.href).host === location.host) {
                    history.back(); return false;
                }
            } catch (e) { }
            location.href = url; return false;
        }
        document.addEventListener('DOMContentLoaded', function () {
            var b = document.querySelector('.btn-back.fade-in');
            if (b) { requestAnimationFrame(function () { b.classList.add('visible'); }); }
        });
</script>
    <script src="/Scripts/main.js" defer></script>
</body>
</html>
