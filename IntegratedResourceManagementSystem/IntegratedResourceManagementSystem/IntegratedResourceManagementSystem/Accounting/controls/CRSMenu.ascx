<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CRSMenu.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.CRSMenu" %>
<style type ="text/css" >
   .mnuIcon
    {
        width:115px;
        height:96px;
        background-image:url('../Resources/searchbackground.png');
        background-repeat:no-repeat;
        padding-left: 10px;
        padding-top: 3px;
    }
     .mnuIcon:hover
    {
        background-image:url('../Resources/searchbackgroundh.png');
        background-repeat:no-repeat;
        padding-left: 12px;
        color: Gray;
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
<div style ="float:left; width: 150px; margin-right:5px;">
  <div class ="mnuIcon">
    <asp:ImageButton ID="imgBtnDeliveryReceiptConfirmation" runat="server" 
                     ImageUrl="~/Resources/invoice.png" Height="36px" 
                     ToolTip="Delivery Receipt Confirmation" 
                     
          PostBackUrl="~/Accounting/CustomerReturnSlipConfirmationPanel.aspx" 
          ImageAlign="AbsMiddle" />
    <br />
    <asp:LinkButton ID="lnkDeliveryReceiptConfirmation" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Delivery Receipt Confirmation" Font-Bold="True"
                    PostBackUrl="~/Accounting/CustomerReturnSlipConfirmationPanel.aspx" 
          ForeColor="#666666" EnableViewState="False">
     CUSTOMER &nbsp; &nbsp; RETURN SLIP CONFIRMATION
    </asp:LinkButton> 
  </div>
</div>
<%--<div style ="float:left; width: 100px; margin-right:5px;">
  <div class ="mnuIcon">
    <asp:ImageButton ID="imgBtnAdjustmentMemo" runat="server" 
                     ImageUrl="~/Resources/adjustment.png" Height="34px" 
                     ToolTip="Manage Physical Count Adjusment Memo" 
                     PostBackUrl="~/Accounting/Debit-CreditMemoPanel.aspx" 
          Width="42px" />
    <br />
    <asp:LinkButton ID="lnkAdjustmentMemo" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="8px" 
                    ToolTip="Manage Physical Count Adjusment Memo" Font-Bold="True"
                    PostBackUrl="~/Accounting/Debit-CreditMemoPanel.aspx" 
          ForeColor="#666666">
      PCOUNT ADJUSTMENTS
    </asp:LinkButton>
  </div>
</div>
<div style ="float:left; width: 100px; margin-right:5px;">
  <div class ="mnuIcon">
    <asp:ImageButton ID="imgBookAdjustment" runat="server" 
                     ImageUrl="~/Resources/adjustment.png" Height="34px" 
                     ToolTip="Manage Book Adjusment Memo" 
                     PostBackUrl="~/Accounting/BookAdjustmentPanel.aspx" 
          Width="42px" />
    <br />
    <asp:LinkButton ID="lnkBtnBookAdjustment" runat="server" CssClass ="lblMenu" 
                    Font-Names="Verdana" Font-Size="8px" 
                    ToolTip="Manage Book Adjusment Memo" Font-Bold="True"
                    PostBackUrl="~/Accounting/BookAdjustmentPanel.aspx" 
          ForeColor="#666666">
      BOOK ADJUSTMENTS
    </asp:LinkButton>
  </div>
</div>--%>
