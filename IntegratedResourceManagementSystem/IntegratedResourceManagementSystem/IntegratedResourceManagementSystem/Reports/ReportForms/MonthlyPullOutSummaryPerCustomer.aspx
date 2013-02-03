<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="MonthlyPullOutSummaryPerCustomer.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.MonthlyPullOutSummaryPerCustomer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <CR:CrystalReportViewer ID="crViewerMonthlyPullOutSummaryPerCustomer" 
        runat="server" AutoDataBind="true" HasCrystalLogo="False" />
</asp:Content>
