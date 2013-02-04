<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerType.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.CustomerType" %>

<div>

    <asp:Label ID="Label1" runat="server" Text="CUSTOMER TYPE :" 
        style="font-family: Verdana; font-size: small"></asp:Label> &nbsp
    <asp:DropDownList ID="cboType" runat="server" 
        style="font-family: Verdana; font-size: small">
        <asp:ListItem Value="0">- SELECT -</asp:ListItem>
        <asp:ListItem>PROVINCIAL</asp:ListItem>
        <asp:ListItem>DEPARTMENT STORE</asp:ListItem>
        <asp:ListItem Value="BOUTIQUE">BOUTIQUE</asp:ListItem>
    </asp:DropDownList>


</div>
