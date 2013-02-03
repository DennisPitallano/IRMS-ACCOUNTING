<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPCountAdjustmentSelectedDetails.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PrintPCountAdjustmentSelectedDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Phisical Count Adjustment Details</title>
  <script type ="text/javascript" >
      function close_window() {
          if (confirm("Leave this page?")) {
              close();
          }
      }
  </script>
  <style type ="text/css" media="print" >
    #btnPrint
    {
        display :none;
    }
    #btnClose 
    {
       display:none;
    }
     .title
    {
        display:none;
        height:0px;
    } 
    .header
    {
        height:0px;
    }
    .header h1
    {
        display:none;
    }
    hr 
    {
        display:none;
    }
    #reportcontainer
    {
        margin-top:5px;
    }
  </style>
    <style type ="text/css" media ="screen" >
        .lblPreview 
        {
            text-align :right;
        }
        .title
    {
        margin-left :380px;
        margin-top:10px;
        display: block;
        float: left;
        text-align: left;
        width: 280px;
        background :url('../../Resources/irms.png');
        background-repeat:no-repeat;
    }
    .header
    {
        position: relative;
        margin: 0px;
        padding: 0px;
        width: 100%;
        height: 60px;
        margin-bottom:10px;
    }
    .header h1
    {
        font-weight: 700;
        margin: 0px;
        padding: 0px 0px 0px 20px;
        color:Gray;
        border: none;
        line-height: 2em;
        font-size: 1.8em;
    }
      #reportcontainer
      {
           margin:50px 5px 0px 15px;
      }
    </style>
</head>

<body>
<div class="header">
            <div class="title">
                <div style ="margin-left: 150px; text-shadow: 2px 2px 2px #000; width:400px;">
                 <h1>
                    Accounting Department
                </h1>
                </div> 
            </div>
        </div>
        <hr />
    <form id="form1" runat="server" >
    <div align="center" >
    <div style =" text-align:center; margin-top:5px;  font-size:11px; width: 550px; margin-top:50px; padding:30px 0px 30px 0px; border:1px Solid Black;">
          <table cellspacing="0" style="width: 100%; font-family: Times New Roman;">
            <tr>
              <td class ="lblPreview">
                REFERENCE No.
              </td>
              <td style ="text-align:left;">
                <asp:Label ID="lblReferenceNumber" runat="server" Text="Label" Font-Bold="True"></asp:Label>
              </td>
              <td class ="lblPreview">
                DATE:
              </td>
              <td style ="text-align:left;">
                <asp:Label ID="lblDate" runat="server" Text="Label" Font-Bold="True" 
                           Font-Italic="True"></asp:Label>
              </td>
            </tr>
            <tr>
              <td class ="lblPreview">
                PERIOD:
              </td>
              <td colspan ="3" style ="text-align:left;">
                &nbsp;FROM &nbsp;<asp:Label ID="lblPeriodFrom" runat="server" Text="Label" Font-Bold="True" 
                                            Font-Size="11px"></asp:Label> &nbsp;TO &nbsp;<asp:Label 
                  ID="lblPeriodTo" runat="server" Text="Label" Font-Bold="True" 
                  Font-Size="11px"></asp:Label>
              </td>
            </tr>
            <tr>
              <td class ="lblPreview">
                OUTLET:
              </td>
              <td colspan ="3" style ="text-align :left;">
                <asp:Label ID="lblOutlet" runat="server" Text="Label" Font-Bold="True"></asp:Label>
              </td>
            </tr>
            <tr>
              <td>
                &nbsp;
              </td>
              <td>
                &nbsp;
              </td>
              <td>
                &nbsp;
              </td>
              <td>
                &nbsp;
              </td>
            </tr>
            <tr>
              <td style ="border-top:1px Solid Black;">
                PARTICULARS:
              </td>
              <td style ="border-top:1px Solid Black;">
                QUANTITY
              </td>
              <td style ="border-top:1px Solid Black;">
                CURRENT PRICE
              </td>
              <td style ="border-top:1px Solid Black;">
                COST PRICE
              </td>
            </tr>
            <tr>
              <td style ="border-top:1px Solid Black;">
                <asp:Label ID="lblTransaction" runat="server" Text="Label"></asp:Label>
              </td>
              <td style ="border-top:1px Solid Black;">
                <asp:Label ID="lblQuantity" runat="server" Text="Label" ForeColor="#CC3300"></asp:Label>
              </td>
              <td style ="border-top:1px Solid Black;">
                <asp:Label ID="lblCurrentPrice" runat="server" Text="Label" ForeColor="#CC3300"></asp:Label>
              </td>
              <td style ="border-top:1px Solid Black;">
                <asp:Label ID="lblCostPrice" runat="server" Text="Label" ForeColor="#CC3300"></asp:Label>
              </td>
            </tr>
          </table>
        </div>  
          <div style ="padding-left:10px; padding-top: 15px;">
        <input id="btnPrint" type="button" value="PRINT" onclick="window.print()" 
                style="font-family: verdana; font-size: 12px; font-weight: bold; height: 25px;" />
       <input id="btnClose" type="button" value="CLOSE FORM" onclick="close_window()" style="font-family: verdana; font-size: 12px; font-weight: bold; height: 25px;" />
       </div>
    </div>
     
    </form>
</body>
</html>
