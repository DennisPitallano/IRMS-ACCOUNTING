<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPCountSummary.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PrintPCountSummary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Phisical Count Adjustment Summary</title>
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
           <div align="center" style ="margin:50px 5px 0px 15px;">
           <div style ="text-align: right; width:594px;">
               <asp:Label ID="lblDateNow" runat="server" Text="Label" Font-Names="Times New Roman" 
                   Font-Size="11px"></asp:Label>
           </div>
           <div style =" margin-bottom: 10px; text-align:left; width: 594px;">
               <asp:Label ID="lblTitle" runat="server" Text="Physical Count Adjustment Summary" Font-Names="Times New Roman" 
                   Font-Size="12px" Font-Bold="true"></asp:Label>
           </div>
           <div style ="border-left:1px Solid #000000; border-right:1px Solid #000000; 
               border-top: 1px Solid #000000; font-family:Times New Roman; font-size:11px; width: 594px;">
            <table style="width: 100%; font-family:Times New Roman; ">
              <tr>
                <td>
                  OUTLET:
                </td>
                <td>
                  <asp:Label ID="lblTransactionSummaryOutlet" runat="server" Text="Label" 
                             Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
                </td>
                <td>
                  DATE:
                </td>
                <td>
                  <asp:Label ID="lblTransactionDateSummary" runat="server" Text="Label" 
                             Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
                </td>
              </tr>
              <tr>
                <td>
                  PERIOD:
                </td>
                <td>
                  FROM&nbsp;<asp:Label ID="lblTransactioSummaryPeriodFrom" runat="server" 
                                       Text="Label" Font-Italic="True" Font-Names="Times New Roman" Font-Size="11px"></asp:Label>&nbsp;TO&nbsp;<asp:Label
                    ID="lblTransactioSummaryPeriodTo" runat="server" Text="Label" 
                    Font-Italic="True" Font-Size="11px"></asp:Label>
                </td>
                <td>
                  REFERENCE #:
                </td>
                <td>
                  <asp:Label ID="lblReferenceNumberSumamry" runat="server" Text="Label" 
                             Font-Names="Times New Roman" Font-Size="11px"></asp:Label>
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
            </table>
          </div>
          <table CellSpacing="0" style ="font-family:Times New Roman; text-align :center; font-size:11px;border-top:1px Solid #000000; border-left:1px Solid #000000;">
            <tr>
              <td style ="width:80px; border-right:1px Solid #000000;  ">
                MEMO TYPE
              </td>
                         
              <td style ="width:130px; border-right:1px Solid #000000; ">
                PARTICULARS
              </td>
              <td style ="width:90px;border-right:1px Solid #000000; ">
                QUANTITY
              </td>
              <td colspan ="2" style ="width:283px; height:30px; border-right:1px Solid #000000; ">
                <div style ="text-align:center;border-bottom:1px Solid #000000; ">PRICE</div>
                <div style="width:140px; float:left; text-align :center; border-right:1px Solid #000000; ">CURRENT</div>
                <div style="width:141px; float:right; text-align :center;">COST</div>
              </td>
            </tr>
          </table>
          <div style ="  text-align :left; border-left:1px Solid #000000; border-right:1px Solid #000000;
               border-top: 1px Solid #000000; font-family:Times New Roman; font-size:11px; width: 594px;">DEBIT</div>
          <asp:GridView ID="gvCreditSummary" runat="server" AutoGenerateColumns="False" 
                        ShowHeader="False" Font-Names="Times New Roman" Font-Size="11px" 
                   BorderColor="Black">
            <Columns>
              <asp:BoundField>
                <ItemStyle Width="80px" />
              </asp:BoundField>
              <asp:BoundField DataField="MemoDate" HeaderText="DATE" 
                              DataFormatString="{0:MMMM dd, yyyy}" Visible="False" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="120px" Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="ReferenceNumber" HeaderText="REFERENCE#" 
                              Visible="False" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="80px" Wrap="False" />
              </asp:BoundField>
           
              <asp:BoundField DataField="ParticularTransaction" HeaderText="PARTICULARS" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="130px" Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="90px" Wrap="False" HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CurrentPrice" HeaderText="CURRENT" 
                              DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="140px" Wrap="False" HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CostPrice" HeaderText="COST" 
                              DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" HorizontalAlign="Right" />
                <ItemStyle Width="140px" Wrap="False" HorizontalAlign="Right" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
          <div style =" text-align :left; border-left:1px Solid #000000; border-right:1px Solid #000000; font-family:Times New Roman; font-size:11px; width: 594px;">CREDIT</div>
          <asp:GridView ID="gvDebitSummary" runat="server" AutoGenerateColumns="False" 
                        ShowHeader="False" Font-Names="Times New Roman" Font-Size="11px" 
                   BorderColor="Black">
            <Columns>
              <asp:BoundField>
                <ItemStyle Width="80px" />
              </asp:BoundField>
              <asp:BoundField DataField="MemoDate" HeaderText="DATE" 
                              DataFormatString="{0:MMMM dd, yyyy}" Visible="False" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="120px" Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="ReferenceNumber" HeaderText="REFERENCE#" 
                              Visible="False" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="80px" Wrap="False" />
              </asp:BoundField>
            
              <asp:BoundField DataField="ParticularTransaction" HeaderText="PARTICULARS" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="130px" Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="90px" Wrap="False" HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CurrentPrice" HeaderText="CURRENT" 
                              DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="140px" Wrap="False" HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CostPrice" HeaderText="COST" 
                              DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Width="140px" Wrap="False" HorizontalAlign="Right" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
          <table CellSpacing="0" style ="font-family:Times New Roman; font-size:11px;border-bottom:1px Solid #000000; border-left:1px Solid #000000;">
            <tr>
              <td style ="width:80px; border-right:1px Solid #000000;  ">
                TOTAL
              </td>
                              
              <td style ="width:130px; border-right:1px Solid #000000; ">
              </td>
              <td style ="width:90px;border-right:1px Solid #010101; text-align :right; font-weight:bold; ">
                <asp:Label ID="lblTransactionSummaryTotalQuantity" runat="server" Text="Label"></asp:Label>
              </td>
              <td  style ="width:140px; height:20px; border-right:1px Solid #000000; text-align :right;font-weight:bold; ">
                <asp:Label ID="lblTransactionSummaryTotalCurrentPrice" runat="server" Text="Label"></asp:Label>
              </td>
              <td style ="width:140px;border-right:1px Solid #000000; text-align :right; font-weight:bold;">
                <asp:Label ID="lblTransactionSummaryTotalCostPrice" runat="server" Text="Label"></asp:Label>
              </td>
            </tr>
          </table>
           <div style ="padding-left:10px; padding-top: 15px;">
        <input id="btnPrint" type="button" value="PRINT" onclick="window.print()" 
                style="font-family: verdana; font-size: 12px; font-weight: bold; height: 25px;" />
       <input id="btnClose" type="button" value="CLOSE FORM" onclick="close_window()" style="font-family: verdana; font-size: 12px; font-weight: bold; height: 25px;" />
       </div>
        </div>
       
    </form>
</body>
</html>
