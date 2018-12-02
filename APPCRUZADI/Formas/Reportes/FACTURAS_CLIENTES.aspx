<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FACTURAS_CLIENTES.aspx.vb" Inherits="APPCRUZADI.FACTURAS_CLIENTES" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        CLIENTE:&nbsp;
        <asp:TextBox ID="txtcliente" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnshow" runat="server" Text="IR" />
    
    </div>
        <rsweb:ReportViewer ID="rptfactura_cliente" runat="server" Width="882px" Height="704px" ZoomMode="FullPage">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
