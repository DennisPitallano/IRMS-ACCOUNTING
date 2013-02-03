<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="PhysicalCountAdjusmentMemoReport.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PhysicalCountAdjusmentMemoReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ PreviousPageType VirtualPath ="~/Accounting/Debit-CreditMemoPanel.aspx" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style type ="text/css" >
    .backBtn
    {
        background :url('../../Resources/reply.png');
        background-repeat:no-repeat;
        font-family:Verdana;
        font-size:12px;
        height:25px;
        color:#FFFFCC;
        font-weight:bold;
        padding-left:20px;
        cursor:pointer;
    }
</style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
 <div style ="text-align:center;">
 <div style ="margin-bottom:10px;">
    <asp:Button ID="btnBack" runat="server" Text="Back to Physical Count Adjustment Manager" 
        onclick="btnBack_Click" CssClass ="backBtn" BackColor="Silver" 
         PostBackUrl="~/Accounting/Debit-CreditMemoPanel.aspx" />
    <asp:RoundedCornersExtender ID="btnBack_RoundedCornersExtender" runat="server" 
        BorderColor="YellowGreen" Enabled="True" TargetControlID="btnBack">
    </asp:RoundedCornersExtender>
    </div>
     <asp:HiddenField ID="hfReportType" runat="server" />
     <asp:HiddenField ID="hfAdjustmentCode" runat="server" />
      <asp:HiddenField ID="hfAdjustmentMemoRecordNo" runat="server" />
     <asp:HiddenField ID="hfAdjustmentRecordNo" runat="server" />
    <CR:CrystalReportViewer ID="crViewerAdjustmentMemo" runat="server" EnableDatabaseLogonPrompt="False" 
                              EnableParameterPrompt="False" 
            GroupTreeImagesFolderUrl="" Height="50px" 
                              ToolbarImagesFolderUrl="" 
                              ToolPanelWidth="" Width="350px" 
            HasCrystalLogo="False" AutoDataBind="True" ToolPanelView="None" 
         PrintMode="Pdf" />
 </div>
</asp:Content>