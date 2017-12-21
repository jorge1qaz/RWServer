<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pruebas.aspx.cs" Inherits="AppWebReportes.pruebas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="txtPruebas" runat="server"></asp:TextBox>
        <asp:Button ID="btnPruebas" runat="server" OnClick="btnPruebas_Click" Text="Button" />
        <asp:Label ID="lblPruebas" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
