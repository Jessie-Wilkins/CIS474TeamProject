<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="WebApplication2.menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="content/site.css" type="text/css" />
</head>
<body>
    
    <form id="form1" runat="server">
        <div id="Div1" runat="server">
        </div>

        <asp:Button ID="TransactionButton" runat="server" style="float:right" onCommand="GoToCart" Text="Go to cart" />

        <asp:ScriptManager ID="asm" runat="server" />
<asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <tr>  
                    <th>  
                       Ordered Items 
                    </th>  
                </tr>  
                <br />
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Container.DataItem %></td>
                </tr>
                <asp:Button id="Button2"
                    Text="Remove"
                    onCommand="Remove_Item"
                    CommandArgument='<%# Container.DataItem %>'
                    runat="server"/>
                 <asp:Button id="Button3"
                    Text="Customize"
                    onCommand="Customize_Item"
                    CommandArgument='<%# Container.DataItem %>'
                    runat="server"/>
                <br />
                <br />
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td><%# Container.DataItem %></td>
                </tr>
                <asp:Button id="Button2"
                    Text="Remove"
                    onCommand="Remove_Item"
                    CommandArgument='<%# Container.DataItem%>'
                    runat="server"/>
                <asp:Button id="Button3"
                    Text="Customize"
                    onCommand="Customize_Item"
                    CommandArgument='<%# Container.DataItem %>'
                    runat="server"/>
                <br />
                <br />
            </AlternatingItemTemplate>
       
        </asp:Repeater>

         <asp:Label ID="lblHidden" runat="server" Text=""></asp:Label>
                <ajaxToolkit:ModalPopupExtender ID="PopUp" runat="server" TargetControlID="lblHidden" PopupControlID="ModalPanel" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>


         <asp:Panel ID="ModalPanel" runat="server" Width="500px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                    <asp:CheckBoxList ID="CheckBoxList1" AutoPostBack = "true" runat="server" DataSourceID="SqlDataSource2" DataTextField="OptName" DataValueField="OptName">
                
                    </asp:CheckBoxList>
                 </ContentTemplate>
            </asp:UpdatePanel>
                <asp:Button ID="OKButton" onCommand ="CheckedAction" runat="server" Text="Apply" />
                <asp:Button ID="CancelButton" onCommand ="HideOptions" runat="server" Text="Cancel" />
            <br />
            
        </asp:Panel>
        

        <asp:Label ID="Label1" runat="server" Text="Total: "></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cis474TeamProjectConnectionString %>" SelectCommand="SELECT * from [team_project475].[menu]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cis474TeamProjectConnectionString %>" SelectCommand="SELECT * FROM [team_project475].[options]"></asp:SqlDataSource>

        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
            <AlternatingItemTemplate>
                <li style="background-color: #FAFAD2;color: #284775;">ItemName:
                    <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' />
                    <br />
                    BasePrice:
                    <asp:Label ID="BasePriceLabel" runat="server" Text='<%# Eval("BasePrice") %>' />
                    <br />
                    Description:
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    <br />
                    <asp:Button id="Button1"
                    Text="Add"
                    onCommand="Add_Item"
                    CommandArgument='<%# String.Format("{0} ${1}", Eval("ItemName"), Eval("BasePrice")) %>'
                    runat="server"/>
                    
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #FFCC66;color: #000080;">ItemName:
                    <asp:TextBox ID="ItemNameTextBox" runat="server" Text='<%# Bind("ItemName") %>' />
                    <br />
                    BasePrice:
                    <asp:TextBox ID="BasePriceTextBox" runat="server" Text='<%# Bind("BasePrice") %>' />
                    <br />
                    Description:
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">ItemName:
                    <asp:TextBox ID="ItemNameTextBox" runat="server" Text='<%# Bind("ItemName") %>' />
                    <br />BasePrice:
                    <asp:TextBox ID="BasePriceTextBox" runat="server" Text='<%# Bind("BasePrice") %>' />
                    <br />Description:
                    <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
<br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #FFFBD6;color: #333333;">ItemName:
                    <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' />
                    <br />
                    BasePrice:
                    <asp:Label ID="BasePriceLabel" runat="server" Text='<%# Eval("BasePrice") %>' />
                    <br />
                    Description:
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    <br />
                    <asp:Button id="Button1"
                    Text="Add"
                    onCommand="Add_Item"
                    CommandArgument='<%# String.Format("{0} ${1}", Eval("ItemName"), Eval("BasePrice")) %>'
                    runat="server"/>
                    
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #FFCC66;font-weight: bold;color: #000080;">ItemName:
                    <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ItemName") %>' />
                    <br />
                    BasePrice:
                    <asp:Label ID="BasePriceLabel" runat="server" Text='<%# Eval("BasePrice") %>' />
                    <br />
                    Description:
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    <br />
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
    </form>
</body>
</html>
