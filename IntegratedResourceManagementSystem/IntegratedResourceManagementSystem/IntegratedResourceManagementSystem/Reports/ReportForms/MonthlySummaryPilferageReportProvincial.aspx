<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlySummaryPilferageReportProvincial.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.MonthlySummaryPilferageReportProvincial" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REPORT GENERATOR</title>
     <link href="../ReportsStyles/MothlySOI.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="banner">
            Report Generator  
            <div style="float:right; cursor:pointer; margin-top:14px;">
                <img src="../../Resources/cancel_gray.png" title="CLOSE REPORT" onclick="window.close()" />
            </div>
    </div>
    <div style="text-align:center;">
         <CR:CrystalReportViewer ID="SummaryOfMonthlyPilferageProvincialCustomer" runat="server" 
            AutoDataBind="true" HasCrystalLogo="False" ToolPanelView="None" />
    </div>
    </form>
</body>
</html>
