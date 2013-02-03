<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="DeliveryReceiptConfirmationReport.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.DeliveryReceiptConfiamationReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ PreviousPageType VirtualPath ="~/Accounting/DeliveryReceiptConfirmationPanel.aspx"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
<script src="../../Scripts/jquery-1.7.2.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#btnBack").click(function () {
            window.location.href = "../../Accounting/DeliveryReceiptConfirmationPanel.aspx";
        });
    });
</script>
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
<asp:UpdatePanel runat="server">
    <ContentTemplate>
     <div style ="text-align:center;">
 <div style ="margin-bottom:10px;">
    <asp:Button ID="btnBack" runat="server" Text="Back " ClientIDMode="Static" 
        CssClass ="backBtn" BackColor="Silver"/>
    <asp:RoundedCornersExtender ID="btnBack_RoundedCornersExtender" runat="server" 
        BorderColor="YellowGreen" Enabled="True" TargetControlID="btnBack">
    </asp:RoundedCornersExtender>
    </div>
     <asp:HiddenField ID="hfTransitStatus" runat="server" />
      <asp:HiddenField ID="hfBrand" runat="server" />
       <asp:HiddenField ID="hfIncludeDateRange" runat="server" />
       <asp:HiddenField ID="hfDateFrom" runat="server" />
       <asp:HiddenField ID="hfDateTo" runat="server" />
       <asp:HiddenField ID="hfOutletName" runat="server" />
    <CR:CrystalReportViewer ID="crViewerAdjustmentMemo" runat="server" EnableDatabaseLogonPrompt="False" 
                              EnableParameterPrompt="False" 
            GroupTreeImagesFolderUrl="" Height="50px"                               
                              ToolPanelWidth="" Width="350px" 
            HasCrystalLogo="False" AutoDataBind="True" PrintMode="ActiveX" 
         ShowAllPageIds="True" />
 </div>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
