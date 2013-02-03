<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="DetailedReportPerOutlet.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.DetailedReportPerOutlet" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <CR:CrystalReportViewer ID="crViewerDetailedReportPerOutlet" runat="server" 
        AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" 
        ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" HasCrystalLogo="False" />
   
</asp:Content>
