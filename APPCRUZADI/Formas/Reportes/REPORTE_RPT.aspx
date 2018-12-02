<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="REPORTE_RPT.aspx.vb" Inherits="APPCRUZADI.REPORTE_RPT" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        DESDE:&nbsp;
        <asp:TextBox ID="txtfechaini" runat="server" Width="193px"></asp:TextBox>
&nbsp; HASTA:&nbsp;
        <asp:TextBox ID="txtfechafin" runat="server" Width="192px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnshow" runat="server" Text="IR" Width="33px" />
&nbsp;<rsweb:ReportViewer ID="rpt_pago" runat="server" Width="979px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
