<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintSOI.aspx.cs" Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PrintSOI" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Styles/marketing-item-master.css" rel="stylesheet" type="text/css" />
    <title>Store OutStanding Inventory</title>
    <script type ="text/javascript" >
        function close_window() {
            if (confirm("Leave this page?")) {
                close();
            }
        }
  </script>
    <style  type ="text/css" media ="print" >
        
        .btn
        {
            visibility:hidden;
        }
       
        .theader
        {
             border-bottom:1px Solid Gray;
            font-family :Verdana;
           font-size:12px;
            text-align:center;
            font-weight:bold;
        }
        .titleLabel
        {
            font-family :Verdana;
            text-align:left;
            font-size:12px;
            font-weight:bold;
        }
        .titleSubLabel
        {
            font-family :Verdana;
            text-align:left;
            font-size:12px;
            margin-left:20px;
        }
        .lblResultLabel
        {
            border-width: 1px 0px 0px 0px; 
            border-top-style: solid; 
            border-top-color: #000000;  
            font-family :Verdana; 
            text-align:left; font-weight:bold;
        }
          .lblResultData
        {
            border-width: 1px 0px 0px 0px; 
            border-top-style: solid; 
            border-top-color: #000000;  
            font-family :Verdana; 
            text-align:right; font-weight:bold;
        }
           .lblResultLabel1
        {
             border-width: 0px 0px 1px 0px ; 
            border-bottom-style: solid; 
            border-bottom-color: #000000; 
            font-size:12px; 
            font-family :Verdana; 
            text-align:left; font-weight:bold;
        }
             .lblResultData1
        {
             border-width: 0px 0px 1px 0px ; 
            border-bottom-style: solid; 
            border-bottom-color: #000000;  
            font-family :Verdana;
            font-size:12px; 
            text-align:right; font-weight:bold;
        }
             .lblResultData2
        {
            font-family :Verdana;  
            font-size:12px;
            text-align:right; font-weight:bold;
        }
              .lblResultData3
        {
            border-bottom-color: #000000;  
            font-family :Verdana; 
            text-align:right; font-weight:bold;
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
     .lblData 
        {
              font-family :Verdana;
            font-size:12px;
            text-align:right;
        }
        #lblDateNow
        {
            font-family:Verdana;
            font-size:9px;
        }
    </style>
    <style type="text/css" media ="screen">
         #btnClose
        {
            font-weight:bold;
             height:25px;
              color:#620D0E;
        }
        #btnPrint
        {
            font-weight:bold;
             height:25px;
              color:#620D0E;
        }
        .btn
        {
            text-align:center;
            margin: 350px 0px 5px 0px;
            font-family:Verdana;
            font-size:12px;
            font-weight:bold;
        }
        .lblData 
        {
              font-family :Verdana;
            font-size:12px;
            text-align:right;
        }
        .theader
        {
            border-bottom:1px Solid Gray;
            font-family :Verdana;
            font-size:12px;
            text-align:center;
            font-weight:bold;
        }
        .titleLabel
        {
             font-family :Verdana;
            font-size:12px;
            text-align:left;
            font-weight:bold;
        }
        .titleSubLabel
        {
            font-family :Verdana;
            font-size:12px;
            text-align:left;
            margin-left:20px;
        }
        .lblResultLabel
        {
            border-width: 2px 0px 0px 0px; 
            border-top-style: solid; 
            border-top-color: #000000;  
            font-family :Verdana;
            text-align:left; font-weight:bold;
        }
          .lblResultData
        {
            border-width: 1px 0px 0px 0px; 
            border-top-style: solid; 
            border-top-color: #000000;  
            font-family :Verdana; 
            text-align:right; font-weight:bold;
        }
           .lblResultLabel1
        {
             border-width: 0px 0px 2px 0px ; 
            border-bottom-style: solid; 
            border-bottom-color: #000000;  
             font-size:12px;
            font-family :Verdana; 
            text-align:left; font-weight:bold;
        }
             .lblResultData1
        {
             border-width: 0px 0px 2px 0px ; 
            border-bottom-style: solid; 
            border-bottom-color: #000000;  
            font-size:12px;
            font-family :Verdana; 
            text-align:right; font-weight:bold;
        }
             .lblResultData2
        {
            font-family :Verdana; 
            font-size:12px;
            text-align:right; font-weight:bold;
        }
              .lblResultData3
        {
            border-bottom-color: #000000;  
            font-family :Verdana;
            text-align:right; font-weight:bold;
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
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
     <asp:HiddenField ID="hfSOI_ID" runat="server" />
     <div style="border:1px Solid black;">
        
     </div>
    <div style =" margin:15px 10px 0px 10px;">
    <div style ="text-align:right; font-size:10px; font-family:Verdana;">
        <asp:Label ID="lblDateNow" runat="server" Text="Label" Font-Names="Verdana" 
            Font-Size="10px"></asp:Label>
    </div>
    
    <div>
        <asp:Label ID="Label1" runat="server" Text="STORE OUTSTANDING INVENTORY" Font-Bold="true" Font-Names="Verdana" Font-Size="13px"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblCustomer" runat="server" Text="Customer" Font-Bold="True" 
            Font-Names="Verdana" Font-Size="13px"></asp:Label>
            <br />
            <br />
        <asp:Label ID="lblDatePeriodFrom" runat="server" Text="PERIOD FROM" Font-Names="Verdana" Font-Size="12px" Font-Bold="true"></asp:Label>
      <div style ="margin-left:70px;">
        <asp:Label ID="lblDatePerioTo" runat="server" Text="PERIOD To" Font-Names="Verdana" Font-Size="12px" Font-Bold="true"></asp:Label>
      </div>
      <br />
    </div>
        <table style="width: 100%;" Cellspacing="0">
            <tr>
                <td class="theader">
                    &nbsp;
                </td>
                <td class="theader">
                    
                    VOLUME</td>
                <td class="theader">
                    VALUE</td>
                <td class="theader">
                    TOTAL COST</td>
                <td class="theader">AVG. COST</td>
            </tr>
            <tr>
                <td colspan="5">
                <br />
                </td>
            </tr>
            <tr>
                <td class ="titleLabel">
                    Beginning Inventory</td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblBIVolume" runat="server" Text="BIVolume"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    <asp:Label ID="lblBIValue" runat="server" Text="BIValue"></asp:Label>
                </td>
                <td class ="lblData">
                    <asp:Label ID="lblBITotalCost" runat="server" Text="BITotalCost"></asp:Label>
                </td>
                <td class ="lblData">
                    <asp:Label ID="lblBIAverageCost" runat="server" Text="BIAvgCost"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class ="titleLabel">
                    Add:</td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                <div class ="titleSubLabel">
                    Delivery
                    </div>
                 </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDeliveryVolume" runat="server" Text="DeliveryVolume"></asp:Label>
                    
                </td>
                <td class ="lblData"> 
                    
                    <asp:Label ID="lblDeliveryValue" runat="server" Text="DeliveryValue"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDeliveryTotalCost" runat="server" Text="DeliveryTotalCost"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDeliveryAvgCost" runat="server" Text="DeliveryAvgCost"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class ="titleLabel">
                    Less:</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                 <div class ="titleSubLabel">
                    Pull Out
                 </div>
                 </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblPullOutVolume" runat="server" Text="PullOutVolume"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblPullOutValue" runat="server" Text="PullOutValue"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblPullOutTotalCost" runat="server" Text="PullOutTotalCost"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblPullOutAvgCost" runat="server" Text="PullOutAvgCost"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td>
                 <div class ="titleSubLabel">
                    Gross Sales
                    </div> 
                 </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblGrossSalesVolume" runat="server" Text="GrossSalesVolume"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblGrossSalesValue" runat="server" Text="GrossSalesValue"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblGrossSalesTotalCost" runat="server" Text="GrossSalesTotalCost"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblGrossSalesAvgCost" runat="server" 
                        Text="GrossSalesAvgCost"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class ="titleLabel">
                    Adjustment:</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                 <div class ="titleSubLabel">
                    Debit(+)
                    </div> 
                    </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDebitVolume" runat="server" Text="DebitVolume"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDebitValue" runat="server" Text="DebitValue"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDebitTotalCost" runat="server" Text="DebitTotalCost"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblDebitAvgCost" runat="server" Text="DebitAvgCost"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td>
                 <div class ="titleSubLabel">
                    Credit(-)
                    </div> 
                    </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblCreditVolume" runat="server" Text="CreditVolume"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblCreditValue" runat="server" Text="CreditValue"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblCreditTotalCost" runat="server" Text="CreditTotalCost"></asp:Label>
                    
                </td>
                <td class ="lblData">
                    
                    <asp:Label ID="lblCreditAvgCost" runat="server" Text="CreditAvgCost"></asp:Label>
                    
                </td>
            </tr>
             <tr>
               <td class ="lblResultLabel" colspan="5">
                 <div style="height:9px;"></div>
               </td>
               
            </tr>
            <tr >
                <td style="font-weight: bold; font-family:Verdana; font-size:12px;" >
                    Ending Inventory</td>
                <td class="lblResultData2" >
                    <asp:Label ID="lblEIVolume" runat="server" Text="EIVolume"></asp:Label>
                </td>
                <td class="lblResultData2">
                    <asp:Label ID="lblEIValue" runat="server" Text="EIValue"></asp:Label>
                </td>
                <td class="lblResultData2" >
                    <asp:Label ID="lblEITotalCost" runat="server" Text="EITotalCost"></asp:Label>
                </td>
                <td class="lblResultData2">
                    <asp:Label ID="lblEIAvgCost" runat="server" Text="EIAvgCost"></asp:Label>
                </td>
            </tr>
           
            <tr >
                <td class ="lblResultLabel1">
                    Actual Physical Count</td>
                <td class ="lblResultData1">
                    <asp:Label ID="lblAPCVolume" runat="server" Text="APCVolume"></asp:Label>
                </td>
                <td class ="lblResultData1">
                    <asp:Label ID="lblAPCValue" runat="server" Text="APCValue"></asp:Label>
                </td>
                <td class ="lblResultData1">
                    <asp:Label ID="lblAPCTotalCost" runat="server" Text="APCTotalCost"></asp:Label>
                </td>
                <td class ="lblResultData1">
                    <asp:Label ID="lblAPCAvgCost" runat="server" Text="APCAvgCost"></asp:Label>
                </td>
            </tr>
            <tr >
                <td style ="font-family :Verdana; font-size:12px;  text-align:left; font-weight:bold;">
                    Discrepancy</td>
                <td class ="lblResultData2">
                   <asp:Label ID="lblDiscrepancyVolume" runat="server" Text="DiscrepancyVolume"></asp:Label></td>
                <td class ="lblResultData2">
                   <asp:Label ID="lblDiscrepancyValue" runat="server" Text="DiscrepancyValue"></asp:Label></td>
                <td class ="lblResultData2">
                    <asp:Label ID="lblDiscrepancyTotalCost" runat="server" Text="DiscrepancyTotalCost"></asp:Label></td>
                <td class ="lblResultData2">
                    &nbsp;</td>
            </tr>
            <tr >
                <td style =" font-size:12px;  font-family :Verdana; text-align:left; font-weight:bold;">
                    Over(Lacking)</td>
                <td class ="lblResultData2">
                    &nbsp;</td>
                <td class ="lblResultData2">
                    &nbsp;</td>
                <td class ="lblResultData2">
                    &nbsp;</td>
                <td class ="lblResultData2">
                    &nbsp;</td>
            </tr>
        </table>
        <div style ="text-align:right; float:left; margin:300px 0px 15px 15px;">
           Prepared by: <asp:Label ID="lblPreparedBy" runat="server" Text="Prepared By"></asp:Label>
        </div>
        <div style ="text-align:right; float:left; margin:300px 0px 15px 150px;">
           Checked by:_________________________
        </div>
        <div style="border:1px Solid black; margin-top:450px;">
            
        </div>
      <div class ="btn">
          <input id="btnPrint" type="button" value="PRINT" onclick="window.print()" />&nbsp;
           <input id="btnClose" type="button" value="CLOSE" onclick="close_window()" />&nbsp;
      </div> 
    </div>
    </form>
</body>
</html>
