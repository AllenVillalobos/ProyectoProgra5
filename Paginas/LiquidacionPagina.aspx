<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="LiquidacionPagina.aspx.cs" Inherits="Proyecto.Paginas.LiquidacionPagina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Liquidación</title>
    <link href="/Content/style.css" rel="stylesheet" />
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
        <div class="page-liquidacion fade-in">

            <!-- 1) Encabezado -->
            <h2 class="section-title">Calcular Liquidación</h2>

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
                    <asp:TextBox ID="txtAnnios" runat="server" CssClass="input-label" Text="Años Trabajados" />
                    <asp:TextBox ID="txtResAnnios" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Salario Diario</label>
                    <asp:TextBox ID="txtSalarioDiario" runat="server" CssClass="input-label" Text="Salario Diario" />
                    <asp:TextBox ID="txtResSalarioDiario" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>
                <div class="campo">
                    <label>Salario Mensual</label>
                    <asp:TextBox ID="txtSalarioMensual" runat="server" CssClass="input-label" Text="Salario Mensual" />
                    <asp:TextBox ID="txtResSalarioMensual" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <div class="campo">
                    <label>Total de la Liquidación</label>
                    <asp:TextBox ID="txtTotalLiquidacion" runat="server" CssClass="input-readonly" ReadOnly="true" />
                </div>

                <asp:Button ID="btnCalcular" runat="server" Text="Calcular Liquidación" CssClass="btn-action" OnClick="btnCalcularClick" />

            </div>
        </div>
    </form>

    <script src="/Scripts/main.js" defer></script>
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
