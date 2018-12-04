<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionComplete.aspx.cs" Inherits="WebApplication2.TransactionComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/TransactionComplete.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 

        <div id="Div1">
            Transaction Complete!
        </div>
        <div id="Div2" runat="server">

        </div>
        <asp:Button ID="GoBack" runat="server" style = "float:right" Text="Log Out" OnClick="Logout" />
    </form>
</body>
</html>
