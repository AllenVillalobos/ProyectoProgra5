<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liquidacion.aspx.cs" Inherits="Proyecto.Paginas.Liquidacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label runat="server">Fecha de Despido</asp:Label>
                <br />
                <asp:Calendar runat="server"></asp:Calendar>
                <br />
                <br />
                <asp:TextBox runat="server">Monto por Cesantia</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server">Monto por Preaviso</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server">Aguinaldo Proporcional</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server">Total por Vacacciones</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server">Años Trabajados</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server">Salario Diario</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox runat="server">Total Por la Liquidacion</asp:TextBox>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Button Text="Calcular Liquidacion" runat="server"/>
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
            </div>
        </div>
    </form>
</body>
</html>
