<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="online_burger_order.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:wheat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table style="margin:auto; border: 5px solid white">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode ="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>

                </td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor ="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" OnClick="btngoback_Click" Width="80px" Height="25px"/>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
