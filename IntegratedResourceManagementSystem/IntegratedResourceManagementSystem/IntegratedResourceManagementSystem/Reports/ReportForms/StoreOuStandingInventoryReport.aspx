<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="StoreOuStandingInventoryReport.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.StoreOuStandingInventoryReport" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ PreviousPageType VirtualPath ="~/Accounting/SOIPanel.aspx" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:UpdatePanel ID ="upnlSOIReport" runat ="server" >
     <ContentTemplate >
         <asp:HiddenField ID="hfRecordNumber" runat="server" />
     <CR:CrystalReportViewer ID="crViewerSOI" runat="server" EnableDatabaseLogonPrompt="False" 
                              EnableParameterPrompt="False" 
            GroupTreeImagesFolderUrl="" Height="50px" 
                              ToolbarImagesFolderUrl="" 
                              ToolPanelWidth="" Width="350px" 
            HasCrystalLogo="False" AutoDataBind="True" ToolPanelView="None" 
    PrintMode="Pdf" />
     </ContentTemplate>
</asp:UpdatePanel>
    
</asp:Content>
