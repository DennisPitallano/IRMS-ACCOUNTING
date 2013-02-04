<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportsMenu.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.ReportsMenu" %>
<link href="../Styles/reports-menu-div.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .mnuIcon
    {
        width: 120px;
        height: 150px;
        background-image: url('../Resources/submenu.png');
        background-size: 150px 120px;
        background-repeat: no-repeat;
        padding-left: 13px;
        padding-top: 3px;
    }
    .mnuIcon:hover
    {
        background-image: url('../Resources/submenuh.png');
        background-repeat: no-repeat;
        padding-left: 17px;
        color: Gray;
    }
    .lblMenu
    {
        text-decoration: none;
        color: #666666;
        cursor: pointer;
        text-align: center;
    }
    .lblMenu:hover
    {
        color: #376F00;
        border-bottom: 1px;
        border-bottom-style: dashed;
    }
</style>
<div style="margin-bottom: 10px; color: #CC6600; font-family: Verdana; font-size: 16px;
    font-weight: bold; line-height: 22px; text-shadow: 1px 1px 0px white; font-variant: small-caps;">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/Accounting.png" Height="22px"
        ImageAlign="Top" />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="16px"
        ForeColor="#CC6600" Text="REPORT MENU"></asp:Label>
</div>

<div class="OneCol">
    <div style="width: 120px; margin-right: 5px;">
        <div class="MenuIcon">
            <asp:ImageButton ID="imgBtnGarmets" runat="server" ImageUrl="~/Resources/customerreturn.png"
                Height="42px" ToolTip="MANAGE CUSTOMER GROUP" PostBackUrl="~/Accounting/CustomerReportPage.aspx" />
            <br />
            <asp:LinkButton ID="lnkDeliveries" runat="server" CssClass="lblMenu" Font-Names="Verdana"
                Font-Size="9px" ToolTip="MANAGE CUSTOMER GROUP" Font-Bold="True" PostBackUrl="~/Accounting/CustomerReportPage.aspx"
                ForeColor="#666666">
	  CUSTOMER
      
     
            </asp:LinkButton>
        </div>
    </div>
   
</div>
<div class="woCol">
    <div style="width: 120px; margin-right: 5px;">
        <div class="MenuIcon">
            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Resources/accounting.png"
                Height="42px" ToolTip="MANAGE STORE OUTSTANDING INVENTORIES" PostBackUrl="~/Accounting/SoiReportPage.aspx" />
            <br />
            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="lblMenu" Font-Names="Verdana"
                Font-Size="9px" ToolTip="MANAGE STORE OUTSTANDING INVENTORIES" Font-Bold="True" PostBackUrl="~/Accounting/SoiReportPage.aspx"
                ForeColor="#666666">
	  
     SOI
       
       
            </asp:LinkButton>
        </div>
    </div>
</div>
