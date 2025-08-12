<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ConstanciaSalarialPagina.aspx.cs" Inherits="Proyecto.Paginas.ConstanciaSalarialPagina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Constancia Salarial</title>
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
        <div class="page-constanciasalarial fade-in">

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
        </div>

        <!--  Acciones: Imprimir / Descargar PDF -->
        <div class="constancia-actions">
            <asp:Button runat="server" ID="btnGenerarConstancia" Text="Previsualisacion de la Constancia" CssClass="btn-action" OnClick="btnGenerarConstanciaClick" />
            <asp:Button runat="server" ID="btnDescargar" Text="Descargar PDF" CssClass="btn-action" OnClick="btnDescargarClick" />
        </div>
        </div>
    </form>

    <!-- JS global -->
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

