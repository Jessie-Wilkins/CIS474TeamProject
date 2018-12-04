<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="WebApplication2.Transaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Div1" runat="server">
            Values: 
        </div>
        <br />
        <table>
            <tr>
                <td><asp:GridView ID="GridView1" runat="server"></asp:GridView></td>
                <td><asp:GridView ID="GridView2" runat="server"></asp:GridView></td>
            </tr>
        </table>
        <asp:Label ID="Label2" runat="server" Text="Total: "></asp:Label>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
         <asp:Button ID="Button3" runat="server" OnCommand="GoBack" Text="Back" />
        <asp:Button ID="Button2" runat="server" OnCommand="CompleteTransaction" Text="Confirm Purchase" />
       
    </form>
</body>
</html>
