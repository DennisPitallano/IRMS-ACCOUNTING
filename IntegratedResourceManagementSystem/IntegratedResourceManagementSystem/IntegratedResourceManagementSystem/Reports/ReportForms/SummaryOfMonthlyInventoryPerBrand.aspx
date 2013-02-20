<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="SummaryOfMonthlyInventoryPerBrand.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.SummaryOf_MonthlyInventoryPerBrand" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div align = right width = "100%">
    <asp:ImageButton ID="ImageButton1" runat="server" Height="27px" 
        ImageUrl="~/Resources/reply.png" onclick="ImageButton1_Click" Width="31px" />
</div>
   

<br />

<hr />

<br />


<div>

<center>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" />

        </center>
    
</div>


</asp:Content>
