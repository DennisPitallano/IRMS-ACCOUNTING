<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintSILiquidation.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PrintSILiquidation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print Sales Invoice Liquidation</title>
      <script type="text/javascript">
          function close_window() {
              if (confirm("Leave this page?")) {
                  close();
              }
          }
    </script>
        <style type="text/css" media="print">
        #btnPrint
        {
            display: none;
        }
        #btnClose
        {
            display: none;
        }
        .title
        {
            display: none;
            height: 0px;
        }
        .header
        {
            height: 0px;
        }
        .header h1
        {
            display: none;
        }
        hr
        {
            display: none;
        }
        #reportcontainer
        {
            margin-top: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 20px 0px 0px 0px">
    <table>
   
      <tr>
        <td width="200px" >
        </td>
            <td width="650px">
            </td>
            <td align="left">
            <label style="font-family: Verdana; font-size: 15px; font-weight: bold" 
                    runat="server">
            </label>
            </td>
    </tr>
     <tr>
      <td width="200px" >
        </td>
            <td width="650px">
            </td>
            <td align="left">
            <label style="font-family: Verdana; font-size: 13px; font-weight: bold" 
                    runat="server" id="lblSI_No">
                2310708
            </label>
            </td>
       
    </tr>
    <tr>
        <td>
        &nbsp;
        </td>
    </tr>
      <tr>
        <td>
        
        </td>
    </tr>
    <tr>
        <td style="padding: 13px 0px 0px 0px">
        
        </td>
    </tr>
        <tr>
        <td width="250px" >
        </td>
            <td style="padding: 0px 0px 0px 50px" width="650px">
            <label style="font-family: verdana; font-size: 13px; font-weight: bold" 
                    runat="server" id="lblCustomer">
             TCL MERCHANDISE BROKERAGE INC.
            </label>               
            </td>
            <td align="left">
            <label style="font-family: verdana; font-size: 13px; font-weight: bold" 
                    runat="server" id="lblDate">
                01/31/2013
            </label>
            </td>
            
        </tr>
            <tr>
        <td>
        
        </td>
    </tr>
    <tr>
        <td>
        
        </td>
    </tr>     
    </table>
    <table>
    <tr>
         <td width="250px" >
        </td>
         <td style="padding: 0px 0px 0px 50px" width="650px">
         <label style="font-family: verdana; font-size: 11px; font-weight: normal" runat="server" id="lblAddress">
         PORT AREA ZUBITO ST. BRGY. PATING MASBATE CITY
         </label>
                </td>
            
    </tr>
    <tr>
        <td></td>
    </tr>
     <tr>
        <td></td>
    </tr>
    <tr>
        <td width="250px" >
        </td>
         <td style="padding: 0px 0px 0px 50px" width="650px">
         <label style="font-family: verdana; font-size: 12px; font-weight: normal" runat="server" id="lblTIN">
         003-975-825-010
         </label>
                </td>
    </tr>
    <tr>
        <td style="font-family: verdana; padding: 615px 0px 0px 0px" align="right">
        <label id="lblPrepared" runat="server"></label>
        </td>
    </tr>
    <tr>
        <td style="font-family: verdana; padding: 40px 0px 0px 0px" align="right">
        <label id="lblChecked" runat="server">rubby</label>
        </td>
    </tr>
     <tr>
      <td width="250px">
        
        </td>
        <td width="650px">
        
        </td>
        <td style="font-family: verdana; padding: 15px 0px 0px 0px" align="right">
        <label id="lblAmount" runat="server"></label>
        </td>
    </tr>
    </table>
    </div>
    <div style="padding-left: 10px; padding-top: 15px;" align="center">
            <input id="btnPrint" type="button" value="PRINT" onclick="window.print()" style="font-family: verdana;
                font-size: 12px; font-weight: bold; height: 25px;" />
            <input id="btnClose" type="button" value="CLOSE FORM" onclick="close_window()" style="font-family: verdana;
                font-size: 12px; font-weight: bold; height: 25px;" />
        </div>

    </form>
</body>
</html>
