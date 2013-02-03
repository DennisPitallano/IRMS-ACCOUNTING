<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="NewSOI.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.NewSOI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/soi-form.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titlePanel">
        <img src="../Resources/invoice.png" height="24px" alt="" align="top" />
        SOI Form
    </div>
    <asp:UpdatePanel ID="upnlSOI" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HF_BRAND" runat="server" />
            <div class="titleForm" style="margin-top: 10px; height: 8px; width:750px;">
            </div>
            <div class="form" style="font-family: Verdana; width:749px;">
                <asp:Panel ID="pnlSOI" runat="server" DefaultButton="btnSaveSOI">
                    <table>
                        <tr>
                            <td class="modalLabel">
                                Transaction Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtTransactionDate" runat="server" Font-Names="Verdana" Font-Size="12px"
                                    Height="18px" BackColor="#FFFFCC" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="modalLabel">
                                Outlet Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtOutletName" runat="server" Font-Names="Verdana" Font-Size="11px"
                                    Height="20px" Width="250px" CssClass="modalText" ReadOnly="True"></asp:TextBox>
                                <asp:Button ID="btnBrowse" CssClass="btnBrowseCustomer" runat="server" Text="browse..." />
                                <asp:ModalPopupExtender ID="btnBrowse_ModalPopupExtender" runat="server" CancelControlID="imgBtnCloseOutlets"
                                    DynamicServicePath="" Enabled="True" PopupControlID="pnlOutlets" PopupDragHandleControlID="pnlOutletsDrag"
                                    TargetControlID="btnBrowse" BackgroundCssClass="bgModal">
                                    <Animations>
									  <OnShown>
										 <FadeIn Duration=".2" />
									  </OnShown>
                                    </Animations>
                                </asp:ModalPopupExtender>
                            </td>
                            <td rowspan="6">
                                <asp:Label ID="lblHasSOITriggerEvent" runat="server" Text=""></asp:Label>
                                <asp:ModalPopupExtender ID="lblHasSOITriggerEvent_ModalPopupExtender" runat="server"
                                    CancelControlID="btnNo" DynamicServicePath="" Enabled="True" PopupControlID="pnlIsAlreadyHasSOIMessagePanel"
                                    PopupDragHandleControlID="pnlIsAlreadyHasSOIMessagePanelDrag" TargetControlID="lblHasSOITriggerEvent">
                                </asp:ModalPopupExtender>
                                <asp:UpdateProgress ID="uProgressSOI" runat="server" AssociatedUpdatePanelID="upnlSOI">
                                    <ProgressTemplate>
                                        <asp:PlaceHolder ID="plHldrLoader" runat="server">
                                            <UC:LOADER ID="uprogLoader" runat="server" />
                                        </asp:PlaceHolder>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:HiddenField ID="hfPCountVolume" runat="server" />
                                <asp:HiddenField ID="hfPCountValue" runat="server" />
                                <asp:HiddenField ID="hfPCountAveCost" runat="server" />
                                <asp:HiddenField ID="hfPcountTotalCost" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="modalLabel">
                                Period From:
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeriodFrom" runat="server" CssClass="modalText" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtPeriodFrom_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtPeriodFrom" Format="MMMM dd, yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="modalLabel">
                                To:
                            </td>
                            <td>
                                <asp:TextBox CssClass="modalText" ID="txtPeriodTo" runat="server" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtPeriodTo_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtPeriodTo" Format="MMMM dd, yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnGenerateSOI" runat="server" Text="GENERATE SOI" Height="26px"
                                    OnClick="btnGenerateSOI_Click" Font-Bold="True" Font-Names="Verdana" Font-Size="10px"
                                    ForeColor="#996600" ToolTip="Click to Generate Store OutStanding Inventory" />
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblSpeed" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div style="padding: 3px 5px 5px 5px;">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <th>
                                </th>
                                <th>
                                    Volume
                                </th>
                                <th>
                                    Value
                                </th>
                                <th>
                                    Total Cost
                                </th>
                                <th>
                                    Avg. Cost
                                </th>
                            </tr>
                            <tr>
                                <td class="title_label">
                                    <asp:Label ID="lblBeginningInventory" runat="server" Text="Beginning Inventory" ToolTip="View Beginning Inventory Break Down"
                                        CssClass="adjustment_label"></asp:Label>
                                    <asp:ModalPopupExtender ID="lblBeginningInventory_ModalPopupExtender" runat="server"
                                        DynamicServicePath="" Enabled="True" TargetControlID="lblBeginningInventory"
                                        CancelControlID="imgBtnBIBreakDownClose" PopupControlID="pnlBIBreakDown" PopupDragHandleControlID="pnlBIBreakDownDrag">
                                        <Animations>
											<OnShown>
												<FadeIn Duration=".2" />
											</OnShown>
                                        </Animations>
                                    </asp:ModalPopupExtender>
                                </td>
                                <td>
                                    <asp:TextBox class="modalText txt" ID="txtBeginningInventoryVolume" runat="server" 
                                         AutoPostBack="True" ReadOnly="True">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox class="modalText txt" ID="txtBeginningInventoryValue" runat="server" 
                                        ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBeginningInventoryTotalCost" runat="server" 
                                   class="modalText txt" ReadOnly="True" AutoPostBack="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBeginningInventoryAvgCost" runat="server"
                                        ReadOnly="True" class="modalText txt">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="title_sub_label">
                                    &nbsp;&nbsp; Plus:
                                </td>
                                <td>
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
                                <td>
                                    &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblDelivery" runat="server" Text="Delivery"
                                        CssClass="adjustment_label" ToolTip="View Delivery Receipts BreakDown"></asp:Label>
                                    <asp:ModalPopupExtender ID="lblDelivery_ModalPopupExtender" runat="server" DynamicServicePath=""
                                        Enabled="True" PopupControlID="pnlDeliveryReceiptsDetails" PopupDragHandleControlID="pnlDeliveryReceiptsDetailsDrag"
                                        TargetControlID="lblDelivery" CancelControlID="ibtnClosepnlDeliveryReceiptsDetails">
                                        <Animations>
											<OnShown>
												<FadeIn Duration=".2" />
											</OnShown>
                                        </Animations>
                                    </asp:ModalPopupExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeliveryVolume" runat="server" class="modalText txt"
                                         AutoPostBack="True" ReadOnly="true">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeliveryValue" runat="server" class="modalText txt"
                                       AutoPostBack="True" ReadOnly="true">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdeliveryTotalCost" runat="server" AutoPostBack="True"  ReadOnly="true" class="modalText txt">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeliveryAvgCost" runat="server" class="modalText txt" ReadOnly="true">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="title_sub_label">
                                    &nbsp;&nbsp; Less:
                                </td>
                                <td>
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
                                <td>
                                    &nbsp;&nbsp; &nbsp;&nbsp;PullOuts/Returns
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPullOutVolume" runat="server" AutoPostBack="True" class="modalText txt" ReadOnly="True">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPullOutValue" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPullOutTotalCost" runat="server" AutoPostBack="True" ReadOnly="True" class="modalText txt">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPullOutAvgCost" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblGrossSales" runat="server" Text="Gross Sales"
                                        CssClass="adjustment_label" ToolTip="View Gross Sales BreakDown"></asp:Label>
                                    <asp:ModalPopupExtender ID="lblGrossSales_ModalPopupExtender" runat="server" CancelControlID="imgBtnCloseGrosssalesbreakDownModal"
                                        DynamicServicePath="" Enabled="True" PopupControlID="pnlGrosssalesbreakDownModal"
                                        PopupDragHandleControlID="pnlGrosssalesbreakDownModalDrag" TargetControlID="lblGrossSales">
                                        <Animations>
											<OnShown>
												<FadeIn Duration=".2" />
											</OnShown>
                                        </Animations>
                                    </asp:ModalPopupExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGrossSalesVolume" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="True">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGrossSalesValue" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGrossSalesTotalCost" runat="server" AutoPostBack="True" ReadOnly="True" class="modalText txt">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtGrossSalesAvgCost" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="title_label">
                                    &nbsp;&nbsp;<asp:Label ID="lblAdjustment" runat="server" Text="Book Adjustment"></asp:Label>
                                    <asp:ImageButton ID="ibtnLoadBookAdjustment" runat="server" Height="18px" ImageAlign="AbsMiddle"
                                        ImageUrl="~/Resources/reload.png" ToolTip="Get Book Adjustment." OnClick="ibtnLoadBookAdjustment_Click" />
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp; &nbsp;&nbsp;Debit(+)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDebitVolume" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="true">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDebitValue" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="true">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDebitTotalCost" runat="server" ReadOnly="true"
                                        class="modalText txt" AutoPostBack="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDebitAvgCost" runat="server"
                                        ReadOnly="true" class="modalText txt">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp; &nbsp;&nbsp;Credit(-)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreditVolume" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="true" Height="20px">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreditValue" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="true">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreditTotalCost" runat="server" AutoPostBack="True" ReadOnly="true" class="modalText txt">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreditAvgCost" runat="server" ReadOnly="true"
                                        class="modalText txt">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="title_label">
                                    Ending Inventory
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndingInvventoryVolume" runat="server" class="modalText txt" ReadOnly="True">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndingInvventoryValue" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndingInvventoryTotalCost" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndingInvventoryAvgCost" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="title_label">
                                    Adjusted P. Count
                                    <asp:ImageButton ID="ibtnGetPhysicalCountAdjustment" runat="server" Height="18px"
                                        ImageUrl="~/Resources/reload.png" ToolTip="Get Book Adjustment." ImageAlign="AbsMiddle"
                                        OnClick="ibtnGetPhysicalCountAdjustment_Click" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActualAccountVolume" runat="server" class="modalText txt"
                                        AutoPostBack="True" ReadOnly="True">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActualAccountValue" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActualAccountTotalCost" runat="server" AutoPostBack="True" ReadOnly="True" class="modalText txt">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActualAccountAvgCost" runat="server" class="modalText txt" AutoPostBack="True" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="title_label">
                                    Discrepancy
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscrepancyVolume" runat="server" class="modalText txt" ReadOnly="True">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscrepancyValue" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscrepancyTotalCost" runat="server" class="modalText txt" ReadOnly="True">0.00</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDiscrepancyAvgCost" runat="server" 
                                        ReadOnly="True" class="modalText txt">0.00</asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-left: 270px; margin-top: 20px;">
                        <asp:Button ID="btnSaveSOI" runat="server" Text="SAVE" CssClass="btnSave" OnClick="btnSaveSOI_Click" />
                        <asp:ModalPopupExtender ID="btnSaveSOI_ModalPopupExtender" runat="server" DynamicServicePath=""
                            Enabled="True" TargetControlID="btnSaveSOI" PopupControlID="pnlConfirmSaving"
                            PopupDragHandleControlID="pnlConfirmSavingDrag" BackgroundCssClass="bgModal"
                            CancelControlID="btnNoSOI">
                        </asp:ModalPopupExtender>
                        <a href="SOIPanel.aspx" title="Cancel SOI">
                            <input id="btnCancel" type="button" class="btnCancel" value="CANCEL" />
                        </a>
                    </div>
                </asp:Panel>
            </div>
            <%-- confiramtion modal--%>
            <asp:Panel ID="pnlConfirmSaving" runat="server" CssClass="modal">
                <asp:Panel ID="pnlConfirmSavingDrag" runat="server" CssClass="modalDrag">
                    <div class="sizeLogo">
                         <img src="../Resources/usermode.png" height="16px" alt="" align="top" />
                        CONFIRMATION
                    </div>
                </asp:Panel>
                <div class="modalLabel" style="text-align: center; font-size: 13px; margin: 5px 10px;">
                    Are you sure you want to save this data?
                </div>
                <div style="margin: 10px 0px 5px 0px; text-align: center;">
                    <asp:Button ID="btnOKSaveSOI" runat="server" Text="YES" CssClass="modalWarningButtonYes"
                        OnClick="btnOKSaveSOI_Click" />
                    <asp:Button ID="btnNoSOI" runat="server" Text="NO" CssClass="modalWarningButtonNo" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlOutlets" runat="server" CssClass="modal">
                <asp:Panel ID="pnlOutletsDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="imgBtnCloseOutlets" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                            ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <img src="../Resources/usermode.png" height="16px" alt="" align="top" />
                        OUTLETS LIST
                    </div>
                </asp:Panel>
                <div style="margin-left: 5px; margin-top: 3px; height: 28px;">
                    <div class="SearchTextContainer">
                        <label for="MainContent_txtSearchOutlet">
                            SEARCH:</label>
                        <asp:TextBox ID="txtSearchOutlet" runat="server" CssClass="modalText" autofocus="true"
                            placeholder="Search Outlet" Height="16px" Font-Size="10px" Width="150px" ToolTip="Search Outlet"></asp:TextBox>
                        <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
                            OnClick="imgBtnSearchOutlet_Click" ToolTip="SEARCH" />
                    </div>
                </div>
                <asp:Panel ID="outlets_container" runat="server" ScrollBars="Auto">
                    <div style="margin: 2px 2px;">
                        <asp:GridView ID="gvOutlets" runat="server" BackColor="White" BorderColor="#CCCCCC"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Verdana" Font-Size="11px"
                            ForeColor="Black" GridLines="Horizontal" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CustNo" DataSourceID="SqlDataSourceCustomers"
                            OnSelectedIndexChanged="gvOutlets_SelectedIndexChanged" EnablePersistedSelection="True"
                            OnPageIndexChanged="gvOutlets_PageIndexChanged" OnSorted="gvOutlets_Sorted" OnPageIndexChanging="gvOutlets_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgOutlet" runat="server" Height="12px" ImageUrl="~/Resources/invoice.png"
                                            AlternateText='<%# Eval("CustNo").ToString() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="CompName" HeaderText="COMPANY NAME" SortExpression="CompName"
                                    HtmlEncode="False">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustCode" HeaderText="CUSTOMER CODE" SortExpression="CustCode">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="brand" HeaderText="BRAND" HtmlEncode="False" SortExpression="brand" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                                    line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                                    <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                    DATA NOT FOUND!!!
                                </div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerSettings FirstPageImageUrl="~/Resources/first.png" LastPageImageUrl="~/Resources/last.png"
                                Mode="NumericFirstLast" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [CustNo], [CompName], [CustCode],[brand] FROM [CustInfo]"
                            EnableCaching="True"></asp:SqlDataSource>
                    </div>
                </asp:Panel>
                <div style="text-align: center; margin: 5px;">
                    <asp:Button ID="btnSelectOutlet" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        OnClick="btnSelectOutlet_Click" />
                </div>
            </asp:Panel>
            <%--Delivery Receipts Details By Period and Customer.--%>
            <asp:Panel ID="pnlDeliveryReceiptsDetails" runat="server" CssClass="modal">
                <asp:Panel ID="pnlDeliveryReceiptsDetailsDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="ibtnClosepnlDeliveryReceiptsDetails" runat="server" CssClass="btnClose"
                            ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                         <img src="../Resources/panels.png" alt="" align="left" height="16px" />
                        DELIVERY RECEIPTS DETAILS
                    </div>
                </asp:Panel>
                <div style="margin: 5px 5px;">
                    <asp:Panel ID="pnlDeliveryReceiptsDetailsContainer" runat="server" Height="250px"
                        ScrollBars="Auto">
                        <div style="font-family: Verdana; font-size: 11px; text-align: center;
                            padding: 2px 0px; font-weight: bold;">
                            DR BREAKDOWN DETAILS
                        </div>
                        <asp:GridView ID="gvDeliveryReceiptDetails" CssClass="table_grid" runat="server" Font-Names="Verdana" Font-Size="10px"
                            AutoGenerateColumns="False" DataSourceID="SqlDataSourceDRDetailsBreakDown" ForeColor="#FFFFCC"
                            EnableViewState="False">
                            <Columns>
                                <asp:BoundField DataField="DR_NUMBER" HeaderText="DR NUMBER">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CUSTOMER" HeaderText="CUSTOMER">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DR_DATE" HeaderText="DR DATE" DataFormatString="{0:MMMM dd, yyyy}">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:###,###.00}">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TOTAL_QUANTITY" HeaderText="QTY">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceDRDetailsBreakDown" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [ID], [DRNo] AS DR_NUMBER, [DeliveredTo] AS CUSTOMER, [DRDate] AS DR_DATE, [TotalAmt] AS TOTAL_AMOUNT,
				 [TotalQty] AS TOTAL_QUANTITY FROM [DR] WHERE (([CustNo] = @CustNo) AND ([DRDate] BETWEEN @DRDate1 AND @DRDate2))"
                            DataSourceMode="DataReader">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfCustomerRecordNumber" Name="CustNo" PropertyName="Value"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="txtPeriodFrom" Name="DRDate1" PropertyName="Text"
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="txtPeriodTo" Name="DRDate2" PropertyName="Text"
                                    Type="DateTime" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </asp:Panel>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hfAdjustmentRecordNumber" runat="server" />
            <asp:HiddenField ID="hfCustomerRecordNumber" runat="server" />
            <asp:Panel ID="pnlGrosssalesbreakDownModal" runat="server" CssClass="modal">
                <asp:Panel ID="pnlGrosssalesbreakDownModalDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="imgBtnCloseGrosssalesbreakDownModal" runat="server" CssClass="btnClose"
                            ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <img src="../Resources/panels.png" alt="" align="left" height="16px" />
                        GROSS SALES BREAK DOWN
                    </div>
                </asp:Panel>
                <div style="margin: 10px 10px; font-family: Verdana; font-size: 11px;">
                    FORM BRIGE TABLE
                    <asp:GridView ID="gvGrossSalesBreakDown" CssClass="table_grid" runat="server" 
                        Font-Names="Verdana" Font-Size="11px"
                        ForeColor="#333333" AutoGenerateColumns="False" EnableViewState="False" 
                        CellPadding="4" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="GROSS_AMOUNT" DataFormatString="{0:###,###.00}" HeaderText="GROSS AMOUNT" />
                            <asp:BoundField DataField="GROSS_QUANTITY" HeaderText="QUANTITY" />
                            <asp:BoundField DataField="GROSS_MONTH" HeaderText="MONTH" />
                            <asp:BoundField DataField="GROSS_YEAR" HeaderText="YEAR" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </div>
                  <div style="text-align:center; margin:5px;">
                    <a href="../Reports/ReportForms/SOIGrossSalesPrintPreview.aspx" target="_blank" >
                    <input id="btnPrint" type="button" class="btnPrint" value="PRINT" /></a>
                </div>
            </asp:Panel>
            <asp:Label ID="lblSaved" runat="server" Text=""></asp:Label>
            <asp:ModalPopupExtender ID="lblSaved_ModalPopupExtender" runat="server" DynamicServicePath=""
                Enabled="True" PopupControlID="pnlSaved" PopupDragHandleControlID="pnlSavedDrag"
                TargetControlID="lblSaved" BackgroundCssClass="bgModal">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlSaved" runat="server" CssClass="modal">
                <asp:Panel ID="pnlSavedDrag" runat="server" CssClass="modalDrag">
                    <div class="sizeLogo" style="line-height:16px;">
                        <img src="../Resources/product.png" alt="" height="16px" align="left" />
                        New SOI
                    </div>
                </asp:Panel>
                <div style="text-align: center; padding: 5px 30px;">
                    <asp:Label ID="Label2" CssClass="modalLabel" runat="server" Text="Item Successfully Saved!" Font-Names="Verdana"
                        Font-Size="12px"></asp:Label>
                </div>
                <div style="text-align: center; margin: 5px 0px;">
                    <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        OnClick="btnOk_Click" />
                  
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlBIBreakDown" runat="server" CssClass="modal">
                <asp:Panel ID="pnlBIBreakDownDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="imgBtnBIBreakDownClose" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                            ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                           <img src="../Resources/panels.png" alt="" align="left" height="16px" />
                        GROSS SALES BREAK DOWN
                    </div>
                </asp:Panel>
                <div style="text-align: center;">
                    <asp:Label ID="lblBIFrom" runat="server" CssClass="modalLabel" ></asp:Label>
                </div>
                <div style="margin: 5px 5px;">
                    <asp:GridView ID="gvSOIBI" CssClass="table_grid" runat="server" Font-Names="Verdana" Font-Size="11px" ForeColor="#FFFFCC">
                    </asp:GridView>
                </div>
              
            </asp:Panel>
            <asp:Panel ID="pnlIsAlreadyHasSOIMessagePanel" runat="server" CssClass="modal">
                <asp:Panel ID="pnlIsAlreadyHasSOIMessagePanelDrag" runat="server" CssClass="modalDrag">
                    <div class="sizeLogo">
                        <img src="../Resources/product.png" alt="" height="16px" align="left" />
                        CONFIRMATION!!!
                    </div>
                </asp:Panel>
                <div class="modalWarningText">
                    <div style="margin: 1px 20px; border: 1px solid #FFCC66; height: 90px; line-height: 25px;
                        width: 350px; background-color: #FFFFCC; color: #C46200; text-align: center;
                        padding: 5px 5px;">
                        <asp:Image ID="imgWarningDelete" runat="server" ImageUrl="~/Resources/warning.png"
                            ImageAlign="AbsMiddle" />
                        <asp:Label ID="lblIsAlreadyHasSOIMessage" runat="server" Text="Label" Font-Names="Verdana"
                            Font-Size="10px"></asp:Label>
                    </div>
                    <div style="margin: 2px 2px; text-align: center;">
                        <asp:Label ID="lblCustomerNameToDelete" runat="server"  Font-Size="11px"
                            Text="Please check input data and try again."></asp:Label>
                        <br />
                    </div>
                </div>
                <div style="text-align: center; margin-top: 12px; margin-bottom: 5px;">
                    <asp:Button ID="btnNo" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        ToolTip="Cancel" />
                   
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
