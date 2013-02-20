<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs"
    Inherits="IntegratedResourceManagementSystem.Accounting.controls.Categories" %>
<div>
    <div style="double: left;">
        <asp:Label ID="Label1" runat="server" Text="CATEGORY :"></asp:Label>
    </div>
    <div style="double: left;">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="T">TOPS</asp:ListItem>
            <asp:ListItem Value="B">BOTTOMS</asp:ListItem>
            <asp:ListItem Value="D">DAMAGED</asp:ListItem>
            <asp:ListItem Value="A">ACCESSORIES</asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
