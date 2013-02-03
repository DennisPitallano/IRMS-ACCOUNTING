<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SOIMenu.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.SOIMenu" %>
 <style type ="text/css" >
   .mnuIcon
    {
        width:115px;
        height:96px;
        background-image:url('../Resources/searchbackground.png');
        background-repeat:no-repeat;
        padding-top: 3px;
        text-align:center;
         opacity:0.7;
        filter:alpha(opacity=70); 
    }
     .mnuIcon:hover
    {
        background-image:url('../Resources/searchbackgroundh.png');
        background-repeat:no-repeat;
        padding-left:2px;
        color: Gray;
         opacity:1.0;
    filter:alpha(opacity=100); 
    }
      .lblMenu
    {
        text-decoration:none;
        color:#666666;
        cursor:pointer;
        text-align:center;
    }
    .lblMenu:hover
    {
        color:#376F00;
        border-bottom:1px;
        border-bottom-style: dashed;
    }
</style>
<div style ="margin-bottom:10px;">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" 
        Height="22px" ImageAlign="AbsMiddle" />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" 
        Font-Size="12px" ForeColor="#CC6600" Text="TRANSACTIONS"></asp:Label>
</div>
<div style ="float:left; width: 115px; margin-right:5px;">
  <div class ="mnuIcon">
    <asp:ImageButton ID="imgBtnStoreOutStandingInventosry" runat="server" 
                     ImageUrl="~/Resources/invoice.png" Height="48px" 
                     ToolTip="Manage Store OutStanding Inventory" 
                     PostBackUrl="~/Accounting/SOIPanel.aspx" />
    <br />
    <asp:LinkButton ID="lnkStoreOutStandingInventory" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="11px" 
                    ToolTip="Manage Store OutStanding Inventory" Font-Bold="True"
                    PostBackUrl="~/Accounting/SOIPanel.aspx" 
          ForeColor="#666666">
      MANAGE SOI
    </asp:LinkButton>
  </div>
  <div class ="mnuIcon">
    <asp:ImageButton ID="ImageButton1" runat="server" 
                     ImageUrl="~/Resources/invoice.png" Height="46px" 
                     ToolTip="Manage Store OutStanding Inventory" 
                     PostBackUrl="~/Accounting/MonthlySOIPanel.aspx" />
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="11px" 
                    ToolTip="Manage Store OutStanding Inventory" Font-Bold="True"
                    PostBackUrl="~/Accounting/MonthlySOIPanel.aspx" 
          ForeColor="#666666">
      MANAGE MONTHLY SOI
    </asp:LinkButton>
  </div>

  <div class ="mnuIcon">
    <asp:ImageButton ID="ImageButton2" runat="server" 
                     ImageUrl="~/Resources/product_brand.png" Height="36px" 
                     ToolTip="Manage Customer Inventory Grouping" 
                     
          PostBackUrl="~/Accounting/InventoryGroupingManagementPanel.aspx" />
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="9px" 
                    ToolTip="Manage Customer Inventory Grouping" Font-Bold="True"
                    PostBackUrl="~/Accounting/InventoryGroupingManagementPanel.aspx" 
          ForeColor="#666666">
     CUSTOMER INVENTORY GROUPING
    </asp:LinkButton>
  </div>
</div>
<div style ="float:left; width: 115px; margin-right:5px;">
  <div class ="mnuIcon">
    <asp:ImageButton ID="imgBtnAdjustmentMemo" runat="server" 
                     ImageUrl="~/Resources/adjustment.png" Height="44px" 
                     ToolTip="Manage Physical Count Adjusment Memo" 
                     PostBackUrl="~/Accounting/Debit-CreditMemoPanel.aspx" 
          Width="42px" />
    <br />
    <asp:LinkButton ID="lnkAdjustmentMemo" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Physical Count Adjusment Memo" Font-Bold="True"
                    PostBackUrl="~/Accounting/Debit-CreditMemoPanel.aspx" 
          ForeColor="#666666">
      PCOUNT ADJUSTMENTS
    </asp:LinkButton>
  </div>
  <div class ="mnuIcon">
    <asp:ImageButton ID="ibtnMonthlySoiReport" runat="server" 
                     ImageUrl="~/Resources/adjustment.png" Height="44px" 
                     ToolTip="Monthly SOI Reports" 
                     PostBackUrl="~/Accounting/MonthlySOIReportsPanel.aspx" 
          Width="42px" />
    <br />
    <asp:LinkButton ID="lnkBtnMonthlySOIReports" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Monthly SOI Reports" Font-Bold="True"
                    PostBackUrl="~/Accounting/MonthlySOIReportsPanel.aspx" 
          ForeColor="#666666">
      MONLTHY SOI REPORTS
    </asp:LinkButton>
  </div>
</div>
<div style ="float:left; width: 115px; margin-right:5px;">
  <div class ="mnuIcon">
    <asp:ImageButton ID="imgBookAdjustment" runat="server" 
                     ImageUrl="~/Resources/adjustment.png" Height="44px" 
                     ToolTip="Manage Book Adjusment Memo" 
                     PostBackUrl="~/Accounting/BookAdjustmentPanel.aspx" 
          Width="42px" />
    <br />
    <asp:LinkButton ID="lnkBtnBookAdjustment" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Book Adjusment Memo" Font-Bold="True"
                    PostBackUrl="~/Accounting/BookAdjustmentPanel.aspx" 
          ForeColor="#666666">
      BOOK ADJUSTMENTS
    </asp:LinkButton>
  </div>
</div>
