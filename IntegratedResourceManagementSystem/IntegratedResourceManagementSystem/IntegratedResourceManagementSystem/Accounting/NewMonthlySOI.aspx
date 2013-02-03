<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="NewMonthlySOI.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.NewMonthlySOI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/monthly-soi-form.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.textchange.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="min-height: 515px;">
        <div class="titleList">
            <img src="../Resources/invoice.png" height="16px" align="top" />
            MONTHLY SOI FORM
        </div>
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
                <div class="form">
                    <div>
                        <table style="">
                            <tr>
                                <td class="input-form-label">
                                    CUSTOMER:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustomer" Width="270px" ReadOnly="true" Font-Size="10px" CssClass="modalText"
                                        Height="18px" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnBrowse" Height="20px" runat="server" Text="browse..." CssClass="btnBrowse" />
                                    <asp:ModalPopupExtender ID="btnBrowse_ModalPopupExtender" runat="server" DynamicServicePath=""
                                        Enabled="True" TargetControlID="btnBrowse" CancelControlID="ibtnClosepnlCustomerModal"
                                        PopupControlID="pnlCustomerModal" PopupDragHandleControlID="pnlCustomerModalDrag">
                                        <Animations>
                                <OnShown>
                                    <FadeIn Duration=".2" />
                                </OnShown>
                                        </Animations>
                                    </asp:ModalPopupExtender>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="input-form-label">
                                    INVENTORY FOR THE PERIOD OF
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateFrom" Width="100px" CssClass="modalText" Height="18px" runat="server"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtDateFrom">
                                    </asp:CalendarExtender>
                                    -
                                    <asp:TextBox CssClass="modalText" Width="100px" Height="18px" ID="txtDateTo" runat="server"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtDateTo">
                                    </asp:CalendarExtender>
                                    <asp:Button ID="btnGetDR" CssClass="btnFilter" runat="server" Text="GO" OnClick="btnGetDR_Click" />
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="input-form-label">
                                    INVENTORY DATE:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInventoryDate" Width="100px" Height="18px" CssClass="modalText"
                                        runat="server" Font-Bold="True"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtInventoryDate_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtInventoryDate">
                                    </asp:CalendarExtender>
                                    <asp:HiddenField ID="hfCustomerNumber" runat="server" />
                                    <asp:ModalPopupExtender ID="hfCustomerNumber_ModalPopupExtender" runat="server" DynamicServicePath=""
                                        Enabled="True" TargetControlID="hfCustomerNumber" CancelControlID="iBtnClosepnlMessageBoxModal"
                                        PopupControlID="pnlMessageBoxModal" PopupDragHandleControlID="pnlMessageBoxModalDrag">
                                    </asp:ModalPopupExtender>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="pnlInputForm" Visible="false" runat="server">
                        <div style="margin-top: 20px;">
                            <table style="">
                                <tr>
                                    <td style="text-align: left; font-size: 11px;" class="input-form-label">
                                        <asp:Label ID="lblActulaPCountAsOf" runat="server" Text="ACTUAL P.COUNT as of"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                     &nbsp;
                                        <asp:TextBox ID="txtActualPCountAsOf" Width="100px" runat="server" CssClass="modalText"
                                            Height="18px" placeholder="0" OnTextChanged="txtActualPCountAsOf_TextChanged"
                                            AutoPostBack="True" Font-Bold="True" ForeColor="#CC3300">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label" style="text-align: left; padding-right: 20px; font-size: 11px;">
                                        ADD:&nbsp;&nbsp;&nbsp;&nbsp; DELIVERIES
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:HyperLink ID="lblDateDeliveriesFrom" title="Preview Deliveries" Target="_blank"
                                            Font-Size="10px" runat="server" Text="May 7-31, 2012"></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateDeliveriesFrom" Width="100px" placeholder="0" CssClass="modalText"
                                            Height="18px" runat="server" ReadOnly="True">0</asp:TextBox>
                                    </td>
                                    <td rowspan="3" valign="bottom" >
                                        &nbsp;
                                        <asp:TextBox ID="txtDeliveryTotal" runat="server" CssClass="modalText" 
                                            Font-Bold="True" ForeColor="#CC3300" Height="18px" placeholder="0" 
                                            ReadOnly="True" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                    <asp:HyperLink ID="lblMiddleDate" title="Preview Deliveries" Target="_blank"
                                            Font-Size="10px" runat="server" Text="June 1-21, 2012" Visible="False"></asp:HyperLink>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtMiddleDateDeliveryTotal" Width="100px" placeholder="0" CssClass="modalText"
                                            Height="18px" runat="server" ReadOnly="True" Visible="False">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:HyperLink ID="lblDateDeliveriesTo" title="Preview Deliveries" Target="_blank"
                                            Font-Size="10px" runat="server" Text="June 1-21, 2012"></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDateDeliveriesTo" Width="100px" placeholder="0" CssClass="modalText"
                                            Height="18px" runat="server" ReadOnly="True">0</asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label" style="text-align: left; padding-right: 20px; font-size: 11px;">
                                        LESS:&nbsp;&nbsp;&nbsp;&nbsp; SALES
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:Label ID="lblSalesFrom" Font-Size="10px" runat="server" Text="May 7-31, 2012"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalesFrom" Width="100px" placeholder="0" CssClass="modalText"
                                            Height="18px" runat="server" AutoPostBack="True" OnTextChanged="txtSalesFrom_TextChanged">0</asp:TextBox>
                                    </td>
                                    <td rowspan="3" valign="bottom" >
                                         <asp:Label ID="Label6" runat="server" Text="(" Font-Size="22px" 
                                             ForeColor="#CC0000"></asp:Label>
                                        <asp:TextBox ID="txtTotalSales" runat="server" CssClass="modalText" 
                                            Font-Bold="True" ForeColor="#CC3300" Height="18px" placeholder="0" 
                                            ReadOnly="True" Width="90px" BorderStyle="None">0</asp:TextBox>
                                             <asp:Label ID="Label7" runat="server" Text=")" Font-Size="22px" 
                                             ForeColor="#CC0000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:Label ID="lblMiddleDateSales" Visible="false" Font-Size="10px" runat="server" Text="May 7-31, 2012"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMiddleDateSales" Visible="false"  Width="100px" placeholder="0" CssClass="modalText"
                                            Height="18px" runat="server" AutoPostBack="True" OnTextChanged="txtSalesFrom_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:Label ID="lblSalesTo" Font-Size="10px" runat="server" Text="June 1-21, 2012"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalesTo" Width="100px" placeholder="0" CssClass="modalText" Height="18px"
                                            runat="server" AutoPostBack="True" OnTextChanged="txtSalesTo_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 20px; text-align: left; font-size: 11px;" class="input-form-label">
                                        PULL-OUT
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="(" Font-Size="22px" 
                                            ForeColor="#CC0000"></asp:Label>
                                        <asp:TextBox ID="txtPullOut" runat="server" Width="90px" CssClass="modalText" Height="18px"
                                            placeholder="0" AutoPostBack="True" Font-Bold="True" ForeColor="#CC3300" 
                                            OnTextChanged="txtPullOut_TextChanged" BorderStyle="None">0</asp:TextBox>
                                             <asp:Label ID="Label4" runat="server" Text=")" Font-Size="22px" 
                                            ForeColor="#CC0000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-right: 10px; text-align: left; font-size: 11px;" class="input-form-label">
                                        ADJUSTMENTS:
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top"  style="text-align:right; padding-right:20px; font-size: 11px;" class="input-form-label">
                                        <asp:Label ID="Label1" runat="server" Text="ADD:"></asp:Label>
                                    </td>
                                    <td valign="top" style="padding-right:10px; padding-bottom:5px;">
                                        <asp:GridView ID="gvAdjustmentAdd" runat="server" AutoGenerateColumns="False" 
                                            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                            CellPadding="2" ForeColor="Black" CssClass="table_grid" GridLines="None" 
                                            Font-Size="9px" Visible="False">
                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                            <Columns>
                                                <asp:BoundField DataField="Type" HeaderText="TYPE" />
                                                <asp:BoundField DataField="Quantity" HeaderText="QTY" >
                                                <ItemStyle Font-Bold="True" ForeColor="#CC3300" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="Tan" />
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                        </asp:GridView>
                                       
                                        <div class="form" style=" width:100px; padding-right:20px;">
                                            <table >
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       DELIVERIES:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentAddDeliveries" Text="0" runat="server" Font-Bold="True" 
                                                            ReadOnly="True"></asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentAddDeliveries_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentAddDeliveries" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentAddDeliveries" >
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset Deliveries Adjustment" 
                                                        ID="btnResetAdjustmentAddDeliveries" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentAddDeliveries_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       PULL-OUT:
                                                    </td>
                                                    <td>
                                                       <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentAddPullOut" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                         <asp:HoverMenuExtender ID="txtAdjustmentAddPullOut_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True"  
                                                            PopupControlID="btnResetAdjustmentAddPullOut" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentAddPullOut">
                                                        </asp:HoverMenuExtender>
                                                         <asp:Button Text="RESET" title="Reset PullOut Adjustment" 
                                                        ID="btnResetAdjustmentAddPullOut" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentAddPullOut_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       SALES:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentAddSales" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                         <asp:HoverMenuExtender ID="txtAdjustmentAddSales_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentAddSales" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentAddSales">
                                                        </asp:HoverMenuExtender>
                                                         <asp:Button Text="RESET" title="Reset Sales Adjustment" 
                                                        ID="btnResetAdjustmentAddSales" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentAddSales_Click" />
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       SHOPLIFT:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentAddShoplift" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentAddShoplift_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentAddShoplift" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentAddShoplift">
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset ShopLift Adjustment" 
                                                        ID="btnResetAdjustmentAddShoplift" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentAddShoplift_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       OTHERS:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentAddOthers" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentAddOthers_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True"  
                                                            PopupControlID="btnResetAdjustmentAddOthers" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentAddOthers">
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset Other Adjustment" 
                                                        ID="btnResetAdjustmentAddOthers" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentAddOthers_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </div>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAdjustmentAdd" Width="100px" runat="server" CssClass="modalText"
                                            Height="18px" placeholder="0" Font-Bold="True" ForeColor="#CC3300">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnNewAdjustmentAdd" title="Add Adjustment" CssClass="btnNewAdjustment" runat="server" Text="ADD" />
                                        <asp:ModalPopupExtender ID="btnNewAdjustmentAdd_ModalPopupExtender" runat="server"
                                            CancelControlID="btnCancelSaveAdjustmentAdd" DynamicServicePath="" Enabled="True"
                                            PopupControlID="pnlNewAdjustmentAdd" PopupDragHandleControlID="pnlNewAdjustmentAddDrag"
                                            TargetControlID="btnNewAdjustmentAdd">
                                        </asp:ModalPopupExtender>
                                        <asp:Panel ID="pnlNewAdjustmentAdd" CssClass="modal" runat="server">
                                            <asp:Panel ID="pnlNewAdjustmentAddDrag" CssClass="modalDrag" runat="server">
                                                <div class="sizeLogo">
                                                    <img src="../Resources/news_group.png" alt="NEW" align="top" height="16px" />NEW
                                                    ADJUSTMENT ADD
                                                </div>
                                            </asp:Panel>
                                            <div>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="input-form-label">
                                                            TYPE:
                                                            <td>
                                                                <asp:DropDownList ID="dlAddParticulars" runat="server" CssClass="modalText" ForeColor="#CC6600"
                                                                    Height="22px">
                                                                    <asp:ListItem>DELIVERIES</asp:ListItem>
                                                                    <asp:ListItem>SALES</asp:ListItem>
                                                                    <asp:ListItem>PULL-OUT</asp:ListItem>
                                                                    <asp:ListItem>SHOPLIFT</asp:ListItem>
                                                                    <asp:ListItem>OTHERS</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="input-form-label">
                                                            QUANTITY:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtQuantityAdd" Height="18px" Font-Size="12px" Width="100px" CssClass="input-form-label"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="margin: 10px 5px 5px 5px; text-align: center;">
                                                <asp:Button ID="btnSaveAdjustmentAdd" CssClass="btnSave" runat="server" 
                                                    Text="SAVE" onclick="btnSaveAdjustmentAdd_Click" />
                                                <asp:Button ID="btnCancelSaveAdjustmentAdd" CssClass="btnCancel" runat="server" Text="CANCEL" />
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="text-align: right; padding-right: 20px; font-size: 11px;" class="input-form-label">
                                        <asp:Label ID="Label2" runat="server" Text="LESS:"></asp:Label>
                                    </td>
                                    <td valign="top" style="padding-right:10px; padding-bottom:5px;">
                                       <asp:GridView ID="gvAdjustmentLess" runat="server" AutoGenerateColumns="False" 
                                            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                            CellPadding="2" ForeColor="Black" CssClass="table_grid" GridLines="None" 
                                            Font-Size="9px" Visible="False">
                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                            <Columns>
                                                <asp:BoundField DataField="Type" HeaderText="TYPE" />
                                                <asp:BoundField DataField="Quantity" HeaderText="QTY" >
                                                <ItemStyle Font-Bold="True" ForeColor="#CC3300" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="Tan" />
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                                HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                        </asp:GridView>
                                        <div class="form" style=" width:100px; padding-right:20px;">
                                            <table >
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       DELIVERIES:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentLessDeliveries" runat="server" Font-Bold="True" 
                                                            ReadOnly="True">0</asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentLessDeliveries_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentLessDeliveries" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentLessDeliveries">
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset Deliveries Adjustment" 
                                                        ID="btnResetAdjustmentLessDeliveries" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentLessDeliveries_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       PULL-OUT:
                                                    </td>
                                                    <td>
                                                       <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentLessPullOut" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentLessPullOut_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentLessPullOut" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentLessPullOut">
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset PullOut Adjustment" 
                                                        ID="btnResetAdjustmentLessPullOut" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentLessPullOut_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       SALES:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentLessSales" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentLessSales_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentLessSales" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentLessSales">
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset Sales Adjustment" 
                                                        ID="btnResetAdjustmentLessSales" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentLessSales_Click" />
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       SHOPLIFT:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentLessShopLift" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                        <asp:HoverMenuExtender ID="txtAdjustmentLessShopLift_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentLessShopLift" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentLessShopLift">
                                                        </asp:HoverMenuExtender>
                                                        <asp:Button Text="RESET" title="Reset ShopLift Adjustment" 
                                                        ID="btnResetAdjustmentLessShopLift" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentLessShopLift_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size:10px; font-style:italic;" class="modalLabel">
                                                       OTHERS:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox Width="35px" Font-Size="10px" CssClass="modalText" 
                                                        ID="txtAdjustmentLessOthers" runat="server" Font-Bold="True" ReadOnly="True">0</asp:TextBox>
                                                         <asp:HoverMenuExtender ID="txtAdjustmentLessOthers_HoverMenuExtender" 
                                                            runat="server" DynamicServicePath="" Enabled="True" 
                                                            PopupControlID="btnResetAdjustmentLessOthers" PopupPosition="Left" 
                                                            TargetControlID="txtAdjustmentLessOthers">
                                                        </asp:HoverMenuExtender>
                                                         <asp:Button Text="RESET" title="Reset Others Adjustment" 
                                                        ID="btnResetAdjustmentLessOthers" runat="server"  CssClass="btnReset" 
                                                            onclick="btnResetAdjustmentLessOthers_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </div>
                                    </td>
                                    <td>
                                     <asp:Label ID="Label8" runat="server" Text="(" Font-Size="22px" 
                                            ForeColor="#CC0000"></asp:Label>
                                        <asp:TextBox ID="txtAdjustmentLess" Width="90px" runat="server" CssClass="modalText"
                                            Height="18px" placeholder="0" Font-Bold="True" ForeColor="#CC3300" 
                                            BorderStyle="None">0</asp:TextBox>
                                         <asp:Label ID="Label9" runat="server" Text=")" Font-Size="22px" 
                                            ForeColor="#CC0000"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnNewAdjustmentLess" title="Add Adjustment" CssClass="btnNewAdjustment" runat="server"
                                            Text="ADD" />
                                        <asp:ModalPopupExtender ID="btnNewAdjustmentLess_ModalPopupExtender" 
                                            runat="server" DynamicServicePath="" Enabled="True" 
                                            TargetControlID="btnNewAdjustmentLess"
                                             PopupControlID="pnlAdjustmentLessModal" 
                                             PopupDragHandleControlID="pnlAdjustmentLessModalDrag" 
                                             CancelControlID="btnCancelAdjustmentLess">
                                        </asp:ModalPopupExtender>
                                         <asp:Panel ID="pnlAdjustmentLessModal" CssClass="modal" runat="server">
                                            <asp:Panel ID="pnlAdjustmentLessModalDrag" CssClass="modalDrag" runat="server">
                                                <div class="sizeLogo">
                                                    <img src="../Resources/news_group.png" alt="NEW" align="top" height="16px" />NEW
                                                    ADJUSTMENT LESS
                                                </div>
                                            </asp:Panel>
                                            <div>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class="input-form-label">
                                                            TYPE:
                                                            <td>
                                                              <asp:DropDownList ID="DDLParticularsLess" runat="server" CssClass="modalText" ForeColor="#CC6600">
                                                                    <asp:ListItem>DELIVERIES</asp:ListItem>
                                                                    <asp:ListItem>SALES</asp:ListItem>
                                                                    <asp:ListItem>PULL-OUT</asp:ListItem>
                                                                    <asp:ListItem>SHOPLIFT</asp:ListItem>
                                                                    <asp:ListItem>OTHERS</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="input-form-label">
                                                            QUANTITY:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtQuantityLess" Height="18px" Font-Size="12px" Width="100px" CssClass="input-form-label"
                                                                runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="margin: 10px 5px 5px 5px; text-align: center;">
                                                <asp:Button ID="btnSaveAdjustmentLess" CssClass="btnSave" runat="server" 
                                                    Text="SAVE" onclick="btnSaveAdjustmentLess_Click" />
                                                <asp:Button ID="btnCancelAdjustmentLess" CssClass="btnCancel" runat="server" Text="CANCEL" />
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:Label ID="lblEndingInventoryAsOf" Font-Size="11px" runat="server" Text="ENDING INVENTORY as of"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndingInventoryAsOf" Width="100px" runat="server" CssClass="modalText"
                                            Height="18px" placeholder="0" Font-Bold="True" ForeColor="#CC3300" ReadOnly="True">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:Label ID="lblPhysicalCountAsOf" Font-Size="11px" runat="server" Text="PHYSICAL COUNT as of"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhysicalCountAsOf" Width="100px" runat="server" CssClass="modalText"
                                            Height="18px" placeholder="0" AutoPostBack="True" Font-Bold="True" ForeColor="#CC3300"
                                            OnTextChanged="txtPhysicalCountAsOf_TextChanged">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-form-label">
                                        <asp:Label ID="Label5" Font-Size="11px" runat="server" Text="OVER/(LACKING)"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOverLacking" Width="100px" runat="server" CssClass="modalText"
                                            Height="18px" placeholder="0" Font-Bold="True" ForeColor="#CC3300">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                    <div style="text-align: center; margin: 15px 10px 2px 10px;">
                        <asp:Button CssClass="btnSaveDisable" ID="btnSaveSOI" Enabled="false" runat="server"
                            Text="SAVE" />
                        <asp:ModalPopupExtender ID="btnSaveSOI_ModalPopupExtender" runat="server" CancelControlID="btnNo"
                            DynamicServicePath="" Enabled="True" PopupControlID="pnlConfirmSaveModal" PopupDragHandleControlID="pnlConfirmSaveModalDrag"
                            TargetControlID="btnSaveSOI" BackgroundCssClass="bgModal">
                        </asp:ModalPopupExtender>
                        <a href="MonthlySOIPanel.aspx" title="Cancel SOI" style="text-decoration: none;">
                            <input id="btnCancel" type="button" value="CANCEL" class="btnCancel" />
                        </a>
                    </div>
                </div>
                <asp:Panel ID="pnlCustomerModal" CssClass="modal" runat="server">
                    <asp:Panel ID="pnlCustomerModalDrag" CssClass="modalDrag" runat="server">
                        <div class="close_btn">
                            <asp:ImageButton ID="ibtnClosepnlCustomerModal" runat="server" CssClass="btnClose"
                                ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                        </div>
                        <div class="sizeLogo">
                            <img src="../Resources/usermode.png" alt="NEW" align="top" height="16px" />OUTLET
                            LIST
                        </div>
                    </asp:Panel>
                    <div style="min-height: 280px; margin: 3px 5px 5px 3px;">
                        <div style="margin-left: 5px; height: 28px; margin-bottom: 2px; text-align: right;
                            line-height: 24px;">
                            <div class="input-form-label" style="float: left;">
                                BRAND:
                                <asp:DropDownList ID="DDLBrands" Height="22px" CssClass="input-form-label" runat="server"
                                    OnSelectedIndexChanged="DDLBrands_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                            <div class="SearchTextContainer" style="height: 22px;">
                                SEARCH:<asp:TextBox ID="txtSearchOutlet" runat="server" CssClass="modalText" Font-Names="Verdana"
                                    Height="16px" placeholder="Search Csustomer" Font-Size="10px"></asp:TextBox>
                                <asp:ImageButton ID="imgBtnSearchOutlet" runat="server" ImageUrl="~/Resources/search.png"
                                    ImageAlign="AbsMiddle" ToolTip="SEARCH" OnClick="imgBtnSearchOutlet_Click" />
                            </div>
                        </div>
                        <asp:GridView ID="gvOutlets" runat="server" CssClass="table_grid" CellPadding="4"
                            Font-Names="Verdana" GridLines="None" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CustNo,CompName" DataSourceID="SqlDataSourceCustomers"
                            EnablePersistedSelection="True" ForeColor="#333333" OnSelectedIndexChanging="gvOutlets_SelectedIndexChanging"
                            OnPageIndexChanging="gvOutlets_PageIndexChanging" OnSorting="gvOutlets_Sorting"
                            OnSelectedIndexChanged="gvOutlets_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgOutlet" runat="server" Height="16px" ImageUrl="~/Resources/users.png"
                                            AlternateText='<%# Eval("CustNo").ToString() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="CompName" HeaderText="COMPANY NAME" SortExpression="CompName">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="brand" HeaderText="BRAND" SortExpression="brand">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <EmptyDataTemplate>
                                <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                                    line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                                    <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                    DATA NOT FOUND!!!
                                </div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle CssClass="pager" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle CssClass="asc_cell_style" BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle CssClass="asc_cell_style_h" BackColor="#246B61" />
                            <SortedDescendingCellStyle CssClass="desc_cell_style" BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle CssClass="desc_cell_style_h" BackColor="#15524A" />
                        </asp:GridView>
                    </div>
                    <asp:SqlDataSource ID="SqlDataSourceCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                        SelectCommand="SELECT [CustNo], [CompName], [brand] FROM [CustInfoEx] Where MainCustNo is not null" EnableCaching="True">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSourceCustomersByBrand" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                        SelectCommand="SELECT [CustNo], [CompName], [brand] FROM [CustInfoEx] WHERE  MainCustNo is not null and brand=@BRAND"
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DDLBrands" PropertyName="SelectedValue" Name="BRAND" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <div style="text-align: center; margin-top: 10px; margin-bottom: 5px;">
                        <asp:Button ID="btnSelectOutlet" runat="server" Enabled="false" Text="OK" CssClass="modalWarningButtonYes"
                            ToolTip="Select Outlet" OnClick="btnSelectOutlet_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlMessageBoxModal" CssClass="modal" runat="server">
                    <asp:Panel ID="pnlMessageBoxModalDrag" CssClass="modalDrag" runat="server">
                        <div class="close_btn">
                            <asp:ImageButton ID="iBtnClosepnlMessageBoxModal" runat="server" CssClass="btnClose"
                                ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                        </div>
                        <div class="sizeLogo">
                            <img src="../Resources/warning.png" alt="NEW" align="top" height="16px" />WARNING!!!
                        </div>
                    </asp:Panel>
                    <div class="errorMessageContainer">
                        <asp:Label ID="lblErrorText" CssClass="error-text" Height="35px" runat="server" Text=""
                            ViewStateMode="Disabled"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlConfirmSaveModal" CssClass="modal" runat="server">
                    <asp:Panel ID="pnlConfirmSaveModalDrag" CssClass="modalDrag" runat="server">
                        <div class="sizeLogo">
                            <img src="../Resources/question.png" alt="NEW" align="top" height="16px" />CONFIRMATION!!!
                        </div>
                    </asp:Panel>
                    <div class="input-form-label" style="text-align: center; font-size: 11px; padding: 5px;
                        margin: 5px;">
                        <img src="../Resources/question.png" align="middle" />
                        Are you sure you want to save this data?
                    </div>
                    <div style="text-align: center; margin-bottom: 5px;">
                        <asp:Button ID="btnYes" CssClass="modalWarningButtonYes" runat="server" Text="YES"
                            OnClick="btnYes_Click" />
                        <asp:Button ID="btnNo" CssClass="modalWarningButtonNo" runat="server" Text="NO" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
