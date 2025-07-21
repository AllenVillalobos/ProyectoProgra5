<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liquidacion.aspx.cs" Inherits="Proyecto.Paginas.Liquidacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Liquidación</title>
    <link href="/Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-liquidacion fade-in">

            <!-- 1) Encabezado -->
            <h2 class="section-title">Calcular Liquidación</h2>

            <!-- 2) Formulario -->
            <div class="form-container">
                <div class="campo">
                    <label for="calFecha">Fecha de Despido</label>
                    <asp:Calendar ID="calFecha" runat="server" CssClass="calendar" />
                </div>

                <div class="campo">
                    <label>Monto por Cesantía</label>
                    <asp:TextBox ID="txtCesantia" runat="server" CssClass="input-label" Text="Monto por Cesantia" />
                    <asp:TextBox ID="txtResCesantia" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Monto por Preaviso</label>
                    <asp:TextBox ID="txtPreaviso" runat="server" CssClass="input-label" Text="Monto por Preaviso" />
                    <asp:TextBox ID="txtResPreaviso" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Aguinaldo Proporcional</label>
                    <asp:TextBox ID="txtAguinaldo" runat="server" CssClass="input-label" Text="Aguinaldo Proporcional" />
                    <asp:TextBox ID="txtResAguinaldo" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Total por Vacaciones</label>
                    <asp:TextBox ID="txtVacaciones" runat="server" CssClass="input-label" Text="Total por Vacaciones" />
                    <asp:TextBox ID="txtResVacaciones" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Años Trabajados</label>
                    <asp:TextBox ID="txtAnos" runat="server" CssClass="input-label" Text="Años Trabajados" />
                    <asp:TextBox ID="txtResAnos" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Salario Diario</label>
                    <asp:TextBox ID="txtSalarioDiario" runat="server" CssClass="input-label" Text="Salario Diario" />
                    <asp:TextBox ID="txtResSalarioDiario" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Total de la Liquidación</label>
                    <asp:TextBox ID="txtTotalLiquidacion" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <asp:Button ID="btnCalcular" runat="server" Text="Calcular Liquidación" CssClass="btn-action" />

            </div>

            <!-- 3) Lista de Empleados -->
            <div class="lista-wrapper">
                <div id="ListaEmpleados" class="table-container">
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
            </div>

        </div>
    </form>

    <script src="/Scripts/main.js" defer></script>
</body>
</html>
