<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlySOIPrintPreview.aspx.cs"
    Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.MonthlySOIPrintPreview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Monthly Store OutStanding Inventory</title>
    <style type="text/css">
        .adjustment-border
        {
            border-bottom: 1px Solid Black;
        }
        #gvAdjustmentAdd th
        {
            padding-left: 3px;
            padding-right: 3px;
        }
        #gvAdjustmentAdd tr td
        {
            padding-left: 3px;
            padding-right: 3px;
        }
        #gvAdjustmentLess th
        {
            padding-left: 3px;
            padding-right: 3px;
        }
        #gvAdjustmentLess tr td
        {
            padding-left: 3px;
            padding-right: 3px;
        }
        .btnPrint
{
    font-family:Verdana ;
    font-weight :bold;
    font-size: 11px;
    height : 25px;
    text-align :right;
    background: rgb(252,234,187); /* Old browsers */
    /* IE9 SVG, needs conditional override of 'filter' to 'none' */
    background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2ZjZWFiYiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjUwJSIgc3RvcC1jb2xvcj0iI2ZjY2Q0ZCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjUxJSIgc3RvcC1jb2xvcj0iI2Y4YjUwMCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNmYmRmOTMiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
    background:url('../../Resources/print_gray.png'),  -moz-linear-gradient(top,  rgba(252,234,187,1) 0%, rgba(252,205,77,1) 50%, rgba(248,181,0,1) 51%, rgba(251,223,147,1) 100%); /* FF3.6+ */
    background:url('../../Resources/print_gray.png'),  -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(252,234,187,1)), color-stop(50%,rgba(252,205,77,1)), color-stop(51%,rgba(248,181,0,1)), color-stop(100%,rgba(251,223,147,1))); /* Chrome,Safari4+ */
    background: url('../../Resources/print_gray.png'), -webkit-linear-gradient(top,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* Chrome10+,Safari5.1+ */
    background: url('../../Resources/print_gray.png'), -o-linear-gradient(top,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* Opera 11.10+ */
    background: -ms-linear-gradient(top,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* IE10+ */
    background: linear-gradient(to bottom,  rgba(252,234,187,1) 0%,rgba(252,205,77,1) 50%,rgba(248,181,0,1) 51%,rgba(251,223,147,1) 100%); /* W3C */
    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#fceabb', endColorstr='#fbdf93',GradientType=0 ); /* IE6-8 */

    background-repeat:no-repeat;
    background-position:left;
    color:#775c16;
    padding-left:20px;      
    cursor:pointer;
    text-shadow: 1px 1px 1px #E0E0E0;
    border-radius:5px 3px 5px 3px;
    border:1px Solid #7F921C;
}

.btnPrint:hover
{
    margin-top:1px;
    background: rgb(249,198,103); /* Old browsers */
    /* IE9 SVG, needs conditional override of 'filter' to 'none' */
    background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2Y5YzY2NyIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNmNzk2MjEiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
    background:url('../../Resources/print_normal.png'),  -moz-linear-gradient(top,  rgba(249,198,103,1) 0%, rgba(247,150,33,1) 100%); /* FF3.6+ */
    background:url('../../Resources/print_normal.png'),  -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(249,198,103,1)), color-stop(100%,rgba(247,150,33,1))); /* Chrome,Safari4+ */
    background:url('../../Resources/print_normal.png'),  -webkit-linear-gradient(top,  rgba(249,198,103,1) 0%,rgba(247,150,33,1) 100%); /* Chrome10+,Safari5.1+ */
    background:url('../../Resources/print_normal.png'),  -o-linear-gradient(top,  rgba(249,198,103,1) 0%,rgba(247,150,33,1) 100%); /* Opera 11.10+ */
    background: -ms-linear-gradient(top,  rgba(249,198,103,1) 0%,rgba(247,150,33,1) 100%); /* IE10+ */
    background: linear-gradient(to bottom,  rgba(249,198,103,1) 0%,rgba(247,150,33,1) 100%); /* W3C */
    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f9c667', endColorstr='#f79621',GradientType=0 ); /* IE6-8 */
     
    background-repeat :no-repeat;
    background-position:left;
}
    </style>
    <style type="text/css" media="print">
        .adjustment-border
        {
            border-bottom: 1px Solid Black;
        }
        #btnPrint
        {
            visibility: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:UpdatePanel ID="upnlNewMonthlySOI" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="uprogressNewMonthlySOI" runat="server" AssociatedUpdatePanelID="upnlNewMonthlySOI"
                    DisplayAfter="200">
                    <ProgressTemplate>
                        <asp:PlaceHolder ID="plHldrLoader" runat="server">
                            <UC:LOADER ID="uprogLoader" runat="server" />
                        </asp:PlaceHolder>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div style="font-family:Times New Roman;">
                    <div>
                        <table>
                            <tr>
                                <td style="font-weight: bold; font-size: 18px;" colspan="2">
                                    <asp:Label ID="lblCustomer" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 18px;">
                                    INVENTORY FOR THE PERIOD OF
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 18px; font-weight: bold;">
                                    <asp:Label ID="lblDateFrom" runat="server" Text="Label"></asp:Label>
                                    -<asp:Label ID="lblDateTo" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div style="font-size: 18px; border-top: 3px Solid Black; margin-top: 10px; padding-top: 3px;
                            font-weight: bold;">
                            INVENTORY DATE:
                            <asp:Label ID="lblInventoryDate" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div style="margin-top: 20px;">
                        <table>
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    <asp:Label ID="lblActulaPCountAsOf" runat="server" Text="ACTUAL P.COUNT as of"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblActualPCount" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    ADD:&nbsp;&nbsp;&nbsp;&nbsp; DELIVERIES
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width:170px;">
                                   
                                </td>
                                <td style="text-align:left;">
                                     <asp:HyperLink ID="lblDateDeliveriesFrom" title="Preview Deliveries" Target="_blank"
                                        runat="server" Text="May 7-31, 2012"></asp:HyperLink></td>
                                <td style="text-align: right; width: 100px;">
                                    <asp:Label ID="lblDateDeliveriesFromQty" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td rowspan="3" valign="bottom" style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblTotalDeliveries" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                
                                </td>
                                <td style="text-align:left;">
                                       <asp:HyperLink ID="hpLinkMiddleDateDelivery" Visible ="false" title="Preview Deliveries" Target="_blank"
                                        runat="server" Text="May 7-31, 2012"></asp:HyperLink></td>
                                <td style="text-align: right; width: 120px;">
                                    <asp:Label ID="lblMiddleDateDeliveryQty" Visible="false"  runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                   
                                </td>
                                <td style="text-align:left;">
                                     <asp:HyperLink ID="lblDateDeliveriesTo" title="Preview Deliveries" Target="_blank"
                                        runat="server" Text="June 1-21, 2012"></asp:HyperLink></td>
                                <td style="text-align: right; width: 110px; padding-left: 10px;">
                                    <asp:Label ID="lblDateDeliveriesToQty" runat="server" Text=""></asp:Label>
                                  <div style="border-bottom: 1px Solid Black;">
                                    </div>
                                    <div style="border-bottom: 1px Solid Black;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td valign="top">
                               
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    LESS:&nbsp;&nbsp;&nbsp; SALES
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    
                                </td>
                                <td style="text-align:left;">
                                   <asp:Label ID="lblSalesFrom" runat="server" Text="May 7-31, 2012"></asp:Label></td>
                                <td style="text-align: right; width: 120px;">
                                    <asp:Label ID="lblSalesFromQty" runat="server" Text=""></asp:Label>
                                </td>
                                <td valign="bottom" rowspan="3" style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblTotalSales" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td style="text-align: right;">
                                    
                                </td>
                                 <td style="text-align:left;">
                                     <asp:Label ID="lblMiddleDateSales" Visible="false"  runat="server" Text="May 7-31, 2012"></asp:Label></td>
                                <td style="text-align: right; width: 120px;">
                                    <asp:Label ID="lblMiddleDateSalesQty" Visible="false"  runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    
                                </td>
                                <td style="text-align:left;">
                                    <asp:Label ID="lblSalesTo" runat="server" Text="June 1-21, 2012"></asp:Label></td>
                                <td style="text-align: right; width: 110px; padding-left: 10px;">
                                    <asp:Label ID="lblSalesToQty" runat="server" Text=""></asp:Label>
                                    <div style="border-bottom: 1px Solid Black;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; padding-left:63px;" colspan="2">
                                    PULL-OUT
                                </td>
                                <td>
                                </td>
                                <td style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblPullOut" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    ADJUSTMENTS:
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style=" text-align:right; font-size: 13px; font-weight: bold;" 
                                    colspan="3">
                                   <div style=" text-align:left; margin-left:175px;"> ADD:</div>
                                    <div style="display:inline-block; text-align:right; margin-left:20px; margin-top:10px;">
                                        <asp:GridView ID="gvAdjustmentAdd" runat="server" AutoGenerateColumns="False" 
                                            Font-Size="11px" GridLines="None" ShowHeader="False">
                                            <Columns>
                                                <asp:BoundField DataField="Particular" HeaderText="PARTICULAR" />
                                                <asp:BoundField DataField="Quantity" HeaderText="QTY">
                                                <ItemStyle Font-Bold="True" HorizontalAlign="Right" Width="70px" Wrap="False" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Panel ID="pnlADDAdjustment" runat="server" CssClass="adjustment-border">
                                        </asp:Panel>
                                    </div>
                                </td>
                                <td valign="bottom" style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblAdjustmentAdd" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="text-align: right; font-size: 13px; font-weight: bold;" 
                                    colspan="3">
                                   <div style=" text-align:left; margin-left:175px;"> LESS:</div>
                                    <div style="display:inline-block; text-align:right; margin-left:20px; margin-top:10px;">
                                    <asp:GridView ID="gvAdjustmentLess" runat="server" AutoGenerateColumns="False" 
                                        Font-Size="11px" GridLines="None" ShowHeader="False">
                                        <Columns>
                                            <asp:BoundField DataField="Particular" HeaderText="PARTICULAR" />
                                            <asp:BoundField DataField="Quantity" HeaderText="QTY">
                                            <ItemStyle Font-Bold="True" HorizontalAlign="Right" Width="70px" Wrap="False" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Panel ID="pnlLESSAdjustment" runat="server" CssClass="adjustment-border">
                                    </asp:Panel>
                                    </div>
                                </td>
                                <td valign="bottom" style="text-align: right; border-bottom:1px Solid #000000; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblAdjustmentLess" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                          
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    <asp:Label ID="lblEndingInventoryAsOf" runat="server" Text="ENDING INVENTORY as of"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblEndingInventoryAsOfQty" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    <asp:Label ID="lblPhysicalCountAsOf" runat="server" Text="PHYSICAL COUNT as of"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: right; width: 120px; font-weight: bold;">
                                    <asp:Label ID="lblPhysicalCountAsOfQty" runat="server" Text=""></asp:Label>
                                       <div style="border-bottom: 1px Solid Black;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold;" colspan="2">
                                    <asp:Label ID="Label5" runat="server" Text="OVER/(LACKING)"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="text-align: right; width: 120px; font-weight: bold; ">
                                    <asp:Label ID="lblOverLacking" runat="server" Text=""></asp:Label>
                                    <div style="border-bottom: 1px Solid Black;">
                                    </div>
                                    <div style="border-bottom: 1px Solid Black; margin-bottom: 2px;">
                                    </div>
                                    <div style="border-bottom: 1px Solid Black;">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div style="border-top: 3px Solid Black; margin-top: 10px; padding-top:205px;">
                            Prepared By: 
                            <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                            <br />
                            Checked By: MS. OLIVIA CAMPOS
                        </div>
                    </div>
                    <div style="text-align: center; margin: 15px 10px 2px 10px;">
                        <input id="btnPrint" type="button" class="btnPrint" value="PRINT" onclick="window.print()" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
