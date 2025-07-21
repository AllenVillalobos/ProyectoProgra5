<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstanciaSalarial.aspx.cs" Inherits="Proyecto.Paginas.ConstanciaSalarial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Constancia Salarial</title>
    <link href="/Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-constanciasalarial fade-in">



            <!-- Bloque de campos de constancia -->
            <div id="Constancia">
                <label>Identificación</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtIdentificacion" /><br />

                <label>Nombre Completo</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtNombreCompleto" /><br />

                <label>Salario</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtSalario" /><br />

                <label>Fecha de Contratación</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtFechaContrato" /><br />

                <label>Departamento</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtDepartamento" /><br />

                <label>Puesto</label>
                <asp:TextBox runat="server" ReadOnly="true" ID="txtPuesto" /><br />

                <label>Constancia Salarial</label>
                <asp:TextBox
                    runat="server"
                    ID="txtConstancia"
                    TextMode="MultiLine"
                    Height="250px"
                    Width="100%" />
            </div>

            <!-- Wrapper para lista con estilo  -->
            <div class="lista-wrapper">
                <div id="ListaEmpleados" class="table-container">
                    <asp:GridView
                        runat="server"
                        AutoGenerateColumns="false"
                        EmptyDataText="Empleados No Cargados"
                        ID="gvEmpleados">
                        <Columns>
                            <asp:BoundField DataField="EmpleadoID" HeaderText="ID" />
                            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
                            <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                            <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                            <asp:BoundField
                                DataField="Salario"
                                HeaderText="Salario"
                                DataFormatString="{0:C2}" />
                            <asp:BoundField DataField="Jornada" HeaderText="Jornada" />
                            <asp:BoundField DataField="Identificacion" HeaderText="Identificación" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <!--  Acciones: Imprimir / Descargar PDF -->
            <div class="constancia-actions">
                <button type="button" class="btn-action">Descargar PDF</button>

            </div>
        </div>
    </form>

    <!-- JS global -->
    <script src="/Scripts/main.js" defer></script>
</body>
</html>

