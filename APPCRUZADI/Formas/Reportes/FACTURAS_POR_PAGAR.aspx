<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FACTURAS_POR_PAGAR.aspx.vb" Inherits="APPCRUZADI.FACTURAS_POR_PAGAR" %>

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
    
    </div>
        <rsweb:ReportViewer ID="rptfacturaspagar" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1001px">
            <LocalReport ReportPath="FACTURAS POR PAGAR.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetFACTURAS" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="APPCRUZADI.cruzadiDataSetFACTURASTableAdapters.view_FactuasxPagarTableAdapter"></asp:ObjectDataSource>
    </form>
</body>
</html>
