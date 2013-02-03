<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="DeliveryReceiptMenu.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.DeliveryReceiptMenu" %>
<%@ Register Src ="~/Accounting/controls/DRMenu.ascx" TagName ="drmenu" TagPrefix ="uc" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
   <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<div style ="height:470px;"> 
    <asp:PlaceHolder ID="plHolderMenu" runat="server">
        <uc:drmenu ID="dr_menu" runat="server" />
    </asp:PlaceHolder>
    </div>
</asp:Content>
