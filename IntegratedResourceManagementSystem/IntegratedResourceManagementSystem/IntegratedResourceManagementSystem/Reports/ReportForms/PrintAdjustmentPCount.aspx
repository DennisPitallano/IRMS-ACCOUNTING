﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintAdjustmentPCount.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PrintAdjustmentPCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Phisical Count Adjustment</title>
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
    <style type="text/css" media="screen">
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
    <form id="form1" runat="server">
         <div align="center"  style =" margin:50px 5px 0px 15px;">
         <div   style ="text-align :left ; width: 580px;">
             <asp:Label ID="Label5" runat="server" Text="PHYSICAL COUNT ADJUSTMENT" Font-Names="Times New Roman" 
                      Font-Size="11px" Font-Bold="true" ></asp:Label>
         </div>
         <div style=" text-align:right; width: 580px;">
             <asp:Label ID="lblDateNow" runat="server" Text="DateNow" Font-Names="Times New Roman" 
                      Font-Size="11px"></asp:Label>
         </div>
         <div style ="text-align :left ; width: 580px;">
             <asp:Label ID="lblCompanyName" runat="server" Text="OUTLET NAME:" Font-Names="Times New Roman" 
                      Font-Size="11px" Font-Bold="true" ></asp:Label>
         </div>
          <table style="">
            <tr>
              <td style ="text-align:right;">
              <asp:Label ID="Label14" runat="server" Text="INVENTORY DATE:" Font-Names="Times New Roman" 
                      Font-Size="11px"></asp:Label>
                
              </td>
              <td style ="width:200px;">
                <asp:Label ID="lblInventoryDate" runat="server" Text="Label" Font-Bold="True" 
                      Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
              </td>
              <td style ="text-align:right;">
               <asp:Label ID="Label15" runat="server" Text="CUT OFF:" Font-Names="Times New Roman" 
                      Font-Size="11px"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblCutOff" runat="server" Text="Label" Font-Bold="True" 
                      Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
              </td>
            </tr>
                
          </table>

          <div>
            <asp:Label ID="Label2" runat="server" Text="Adjusted Physical Count" 
                       Width="150px" Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
            <asp:Label ID="lblActualPhysicalCountQuantity" runat="server" Width="100px" 
                       Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
            <asp:Label ID="lblActualPhysicalCountCurrentPrice" runat="server" Width="150px" 
                       Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
            <asp:Label ID="lblActualPhysicalCountCostPrice" runat="server" Width="150px" 
                       Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
          </div>
          <div style="text-align:left; width:563px;">
           <asp:Label ID="Label3" runat="server" Text="Add:" Font-Names="Times New Roman" 
                      Font-Size="12px"></asp:Label>
            </div>
          <asp:GridView ID="gvCreditMemo" runat="server" ShowHeader="False" 
                        AutoGenerateColumns="False" Font-Names="Times New Roman" Font-Size="11px">
            <Columns>
              <asp:BoundField DataField="ParticularTransaction">
                <ItemStyle Width="150px" />
              </asp:BoundField>
              <asp:BoundField DataField="Quantity">
                <ItemStyle Width="100px" />
              </asp:BoundField>
              <asp:BoundField DataField="CurrentPrice" DataFormatString="{0:###,###.00}">
                <ItemStyle Width="150px" />
              </asp:BoundField>
              <asp:BoundField DataField="CostPrice" DataFormatString="{0:###,###.00}">
                <ItemStyle Width="150px" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
          <div style="text-align:left; width:565px;">
          <asp:Label ID="Label4" runat="server" Text="Less:" Font-Names="Times New Roman" 
                      Font-Size="12px"></asp:Label>
          </div>
          <asp:GridView ID="gvDebitMemo" runat="server" ShowHeader="False" 
                        AutoGenerateColumns="False" Font-Names="Times New Roman" Font-Size="11px">
            <Columns>
              <asp:BoundField DataField="ParticularTransaction">
                <ItemStyle Width="150px" />
              </asp:BoundField>
              <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                <ItemStyle Width="100px" />
              </asp:BoundField>
              <asp:BoundField DataField="CurrentPrice" DataFormatString="{0:###,###.00}">
                <ItemStyle Width="150px" />
              </asp:BoundField>
              <asp:BoundField DataField="CostPrice" DataFormatString="{0:###,###.00}">
                <ItemStyle Width="150px" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
          <div style ="width:563px;">
             <hr />
             </div>
          <div style ="text-align :left; width: 580px;">
            <asp:Label ID="Label1" runat="server" Text="Adjusted Physical Count" 
                       Width="150px" Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
            <asp:Label ID="lblTotalQuantity" runat="server" Width="100px" Font-Bold="True" 
                       Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
            <asp:Label ID="lblTotalCurrentPrice" runat="server" Width="150px" 
                       Font-Bold="True" Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
            <asp:Label ID="lblTotalCostPrice" runat="server" Width="150px" Font-Bold="True" 
                       Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
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
