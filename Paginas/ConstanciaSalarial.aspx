<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConstanciaSalarial.aspx.cs" Inherits="Proyecto.Paginas.ConstanciaSalarial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="Constancia">
                <asp:Label runat="server">Identificacion</asp:Label>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server">Nombre Completo</asp:Label>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server">Salario</asp:Label>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server">Fecha de Contratacion</asp:Label>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server">Departamento</asp:Label>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" >Puesto</asp:Label>
                <br />
                <asp:TextBox runat="server" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server">Constancia Salarial</asp:Label>
                <br />
                <asp:TextBox runat="server" Height="250px" Width="75%"></asp:TextBox>
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
