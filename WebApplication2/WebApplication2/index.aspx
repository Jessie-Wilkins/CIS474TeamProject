<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 237px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID = "hfUserID" runat ="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="First Name" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtFirstName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Last Name" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtLastName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Contact" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtContact" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Email" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:Label Text="Credit Card" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtCreditCard" runat="server" />
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Address" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="User Name" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtUserName" runat="server" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" /> 
                     </td>
                    <td colspan="2" class="auto-style1">
                        <asp:Label Text="" ID="lbluserNameExist" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Password" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                        <asp:Label Text="*" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Confirm Password" runat="server" />
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2" class="auto-style1">
                        <asp:Button Text="Submit" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Width="64px" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2" class="auto-style1">
                        <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2" class="auto-style1">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td colspan ="3">
                        <hr />
                    </td>
                </tr>
                 <tr>
                    <td>
                        
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:Button Text="Go To Log In Page" ID="btngoLogin" runat="server" OnClick="btn_go_login" Width="254px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
