<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerGroupPerCustomer.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.CustomerGroupPerCustomer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>BRAND DELIVERY / RETURN COMPARATIVE REPORT PER CUSTOMERS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <center>
    


        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" />
    


    </center>

    
    </div>
    </form>
</body>
</html>
