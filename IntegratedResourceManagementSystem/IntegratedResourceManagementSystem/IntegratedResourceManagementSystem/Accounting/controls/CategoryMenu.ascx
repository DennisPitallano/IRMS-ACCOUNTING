<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryMenu.ascx.cs"
    Inherits="IntegratedResourceManagementSystem.WareHouse.controls.CategoryMenu" %>
<link href="styles/FontsLayout.css" rel="stylesheet" type="text/css" />
<div style="float: left;">
    <asp:Label ID="Label1" runat="server" Text="CATEGORY :" CssClass = "LabelTitle" ></asp:Label>
</div>
<div style="float: left;">
    <asp:RadioButtonList ID="RadioList" runat="server" RepeatDirection="Horizontal" CssClass="table">
        <asp:ListItem>ALL</asp:ListItem>
        <asp:ListItem Value="T">TOPS</asp:ListItem>
        <asp:ListItem Value="B">BOTTOMS</asp:ListItem>
        <asp:ListItem Value="D">DAMAGED</asp:ListItem>
        <asp:ListItem Value="A">ACCESORIES</asp:ListItem>
    </asp:RadioButtonList>
</div>
