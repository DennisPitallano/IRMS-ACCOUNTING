<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="StoreOutStandingInventoryMenu.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.StoreOutStandingInventoryMenu" %>
<%@ Register Src="~/Accounting/controls/SOIMenu.ascx" TagName="menu" TagPrefix ="uc" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
   <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div style ="min-height:525px;"> 

    <asp:PlaceHolder ID="phldrMenu" runat="server">
        <uc:menu ID="soi_menu" runat="server" >
        </uc:menu>
    </asp:PlaceHolder>
    </div>
</asp:Content>
