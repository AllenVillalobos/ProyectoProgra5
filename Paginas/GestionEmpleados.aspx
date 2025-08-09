<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionEmpleados.aspx.cs" Inherits="Proyecto.Paginas.GestionEmpleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Crear Empleados</h1>
            <asp:Label Text="Primer Nombre del Emplado"></asp:Label>
            <asp:Label Text="Segundo Nombre del Emplado"></asp:Label>
            <asp:Label Text="Primer Apellido del Emplado"></asp:Label>
            <asp:Label Text="Segundo Apellido del Emplado"></asp:Label>
            <asp:Label Text="Salario"></asp:Label>
            <asp:DropDownList ID="ddlPuesto">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDepartamento">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlJornada">
            </asp:DropDownList>
            <asp:Button />
            <h1>Lista de Empleados</h1>
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
                </div>
            </section>

            <h1>Editar/Eliminar Empleados</h1>
            <asp:Label Text="ID del Emplado"></asp:Label>
            <asp:Label Text="Primer Nombre del Emplado"></asp:Label>
            <asp:Label Text="Segundo Nombre del Emplado"></asp:Label>
            <asp:Label Text="Primer Apellido del Emplado"></asp:Label>
            <asp:Label Text="Segundo Apellido del Emplado"></asp:Label>
            <asp:Label Text="Salario"></asp:Label>
            <asp:DropDownList ID="ddlPuesto">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDepartamento">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlJornada">
            </asp:DropDownList>
            <asp:Button ID="btnModificar" />
            <asp:Button ID="btnEliminar"/>
        </div>
    </form>
</body>
</html>
