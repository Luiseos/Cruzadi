<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm4.aspx.vb" Inherits="APPCRUZADI.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            left: 563px;
            top: 86px;
        }
    </style>
</head>
<body style="z-index: 1; width: 1125px; height: 140px; position: absolute; top: 127px; left: 20px">
     <form id="form1" runat="server">
         <table class="auto-style1">
             <tr>
                 <td>
                     <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                 </td>
                 <td>
                     <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 </td>
                 <td>
                     <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
             <tr style="position: relative">
                 <td>&nbsp;</td>
                 <td>
                     <asp:Button ID="Button1" runat="server" Height="50px" Text="Button" Width="89px" />
                 </td>
                 <td class="auto-style2">&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
         </table>
         <asp:GridView ID="GridView1" runat="server">
         </asp:GridView>
         <br />
         <br />
         <br />
         <br />
         <asp:FormView ID="FormView1" runat="server">
             <FooterTemplate>
                 <asp:DataPager ID="DataPager1" runat="server">
                     <Fields>
                         <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                     </Fields>
                 </asp:DataPager>
             </FooterTemplate>
             <HeaderTemplate>
                 <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
             </HeaderTemplate>
             <ItemTemplate>
                 <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
                 </asp:DetailsView>
             </ItemTemplate>
         </asp:FormView>
     </form>
  
</body>
</html>
