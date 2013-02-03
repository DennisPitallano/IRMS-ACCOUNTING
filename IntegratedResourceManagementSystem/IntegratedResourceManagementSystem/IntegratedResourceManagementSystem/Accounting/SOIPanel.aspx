<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="SOIPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.SOIPanel" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/grid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/quarterly-soi.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/permission-note.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="min-height: 525px;">
        <div class="titlePanel">
            <div style="float: right;">
                <a href="StoreOutStandingInventoryMenu.aspx" title="Back">
                    <img src="../Resources/reply.png" alt="BACK">
                </a>
            </div>
            <img src="../Resources/invoice.png" height="20px" align="middle" alt="" />
            Manage Store Outstanding Inventory Panel
        </div>
        <%--toolbar menu--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="HF_BRAND" runat="server" />
                <div style="height: 26px; margin-bottom: 1px;" class="modalDrag">
                    <div class="SearchTextContainer">
                        SEARCH:<asp:TextBox ID="txtSearch" runat="server" autofocus placeholder="Search SOI"
                            CssClass="modalText" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"
                            Height="16px" Font-Size="10px" Width="150px" ToolTip="Input Customer Name."></asp:TextBox>
                        <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
                            ToolTip="SEARCH" OnClick="imgBtnSearch_Click" />
                    </div>
                    <div style="float: left;">
                        <div style="float: left; margin-right: 2px;">
                            <asp:Button ID="btnNewProductCategory" runat="server" Text="NEW" CssClass="btnNew"
                                TabIndex="2" PostBackUrl="~/Accounting/NewSOI.aspx" EnableViewState="False" />
                        </div>
                        <div style="float: left; margin-right: 2px;">
                            <asp:Button ID="btnUpdateProductCategory" runat="server" Text="UPDATE" CssClass="btnUpdate"
                                Visible="False" EnableViewState="False" />
                        </div>
                        <div style="float: left; margin-right: 2px;">
                            <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btnDelete" EnableViewState="False" />
                            <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" BackgroundCssClass="bgModal"
                                CancelControlID="btnNo" DynamicServicePath="" Enabled="True" PopupControlID="pnlDeleteModal"
                                PopupDragHandleControlID="pnlDeleteModalDrag" TargetControlID="btnDelete">
                                <Animations>
                                        <OnShown>
                                            <FadeIn Duration=".2" />
                                        </OnShown>
                                </Animations>
                            </asp:ModalPopupExtender>
                        </div>
                        <div style="float: left; margin-right: 2px;">
                            <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btnPrint" OnClick="btnPrint_Click"
                                PostBackUrl="~/Reports/ReportForms/StoreOuStandingInventoryReport.aspx" EnableViewState="False" />
                            <asp:HoverMenuExtender ID="btnPrint_HoverMenuExtender" runat="server" DynamicServicePath=""
                                Enabled="True" PopupControlID="pnlPrinOption" TargetControlID="btnPrint" PopupPosition="Bottom">
                            </asp:HoverMenuExtender>
                        </div>
                        <asp:Panel ID="pnlPrinOption" runat="server">
                            <div class="hover-menu-arrow">
                            </div>
                            <div class="hover-menu">
                                <div class="print-link">
                                    <asp:Button ID="btnPreviewInCrystal" runat="server" Text="Preview in Crystal" CssClass="btnPrint"
                                        Font-Names="Verdana" Font-Size="10px" OnClick="btnPreviewInCrystal_Click" PostBackUrl="~/Reports/ReportForms/StoreOuStandingInventoryReport.aspx" />
                                </div>
                                <div class="print-link">
                                    <asp:HyperLink ID="hLinkPreviewSoi" runat="server" Target="_blank">PREVIEW SOI</asp:HyperLink>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Label ID="lblDeleted" runat="server" Text=""></asp:Label>
                        <asp:ModalPopupExtender ID="lblDeleted_ModalPopupExtender" runat="server" DynamicServicePath=""
                            Enabled="True" PopupControlID="pnlDeleted" PopupDragHandleControlID="pnlDeletedDrag"
                            TargetControlID="lblDeleted" BackgroundCssClass="bgModal" CancelControlID="btnOk">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlDeleted" runat="server" CssClass="modal">
                            <asp:Panel ID="pnlDeletedDrag" runat="server" CssClass="modalDrag">
                                <div class="sizeLogo">
                                    <img src="../Resources/product.png" alt="" height="16px" align="top" />
                                    SOI
                                </div>
                            </asp:Panel>
                            <div style="text-align: center; padding: 5px 30px;" class="modalLabel">
                                Item Successfully Deleted!
                            </div>
                            <div style="text-align: center; margin: 5px 0px;">
                                <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="modalWarningButtonYes" />
                            </div>
                        </asp:Panel>
                        <%--Delete Modal--%>
                        <asp:Panel ID="pnlDeleteModal" runat="server" CssClass="modal">
                            <asp:Panel ID="pnlDeleteModalDrag" runat="server" CssClass="modalDrag">
                                <div class="sizeLogo">
                                    <img src="../Resources/product.png" alt="" height="16px" align="top" />
                                    CONFIRMATION!!!
                                </div>
                            </asp:Panel>
                            <div class="modalWarningText">
                                <div style="margin: 1px 20px; border: 1px solid #FFCC66; height: 50px; line-height: 50px;
                                    background-color: #FFFFCC; color: #C46200; text-align: center;">
                                    <img src="../Resources/warning.png" alt="" align="middle" />
                                    <asp:Label ID="Label14" runat="server" Text="Warning, you cannot undo this action."
                                        Font-Size="11px"></asp:Label>
                                </div>
                                <div style="margin: 2px 2px; text-align: center;">
                                    <br />
                                    <asp:Label ID="Label15" runat="server" Text="Are you sure you want to delete this data?"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblCustomerNameToDelete" runat="server" ForeColor="#FFDF9D" Font-Size="11px"
                                        Text="No selected data to delete!"></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDateFromToToDelete" runat="server" ForeColor="#FFDF9D" Font-Size="11px"
                                        Text=""></asp:Label>
                                </div>
                            </div>
                            <div style="text-align: center; margin-top: 12px; margin-bottom: 5px;">
                                <asp:Button ID="btnYes" runat="server" Text="YES" CssClass="modalWarningButtonYes"
                                    ToolTip="Delete" OnClick="btnYes_Click" />
                                <asp:Button ID="btnNo" runat="server" Text="NO" CssClass="modalWarningButtonNo" ToolTip="Cancel" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upnlSOI" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="table_grid" style="float: left; margin-bottom: 10px; border-radius: 5px 5px 0px 0px;">
                    <div style="width: 380px; margin-right: 1px;">
                        <div class="titleList">
                            <img src="../Resources/usermode.png" height="18px" alt="LIST" align="top" />
                            LIST OF STORE OUTSTANDING INVENTORY
                        </div>
                        <asp:Panel ID="pnlSizesList" runat="server" Width="380px" Height="430px" ScrollBars="Auto">
                            <asp:GridView ID="gvSOI" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                CellPadding="4" DataKeyNames="RECORD_NO" DataSourceID="SqlDataSourceSOI" CssClass="table_grid"
                                GridLines="None" OnSelectedIndexChanged="gvSOI_SelectedIndexChanged" PageSize="15"
                                EnablePersistedSelection="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Image ID="imgSOI" runat="server" ImageUrl="~/Resources/invoice.png" Height="16px"
                                                AlternateText='<%# Eval("RECORD_NO") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="CUSTOMER" HeaderText="CUSTOMER NAME" SortExpression="CUSTOMER">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PERIOD_FROM" HeaderText="PERIOD FROM" SortExpression="PERIOD_FROM"
                                        DataFormatString="{0:MMMM dd, yyyy}">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PERIOD_TO" HeaderText="PERIOD TO" SortExpression="PERIOD_TO"
                                        DataFormatString="{0:MMMM dd, yyyy}">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DATE_RECORDED" HeaderText="DATE RECORDED" SortExpression="DATE_RECORDED">
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
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" Font-Italic="True" />
                                <SortedAscendingCellStyle CssClass="asc_cell_style" />
                                <SortedAscendingHeaderStyle CssClass="asc_cell_style_h" />
                                <SortedDescendingCellStyle CssClass="desc_cell_style" />
                                <SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceSOI" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                SelectCommand="SELECT [RECORD_NO],[CUSTOMER],[PERIOD_FROM],[PERIOD_TO],[DATE_RECORDED] FROM [STORE_OUTSTANDING_INVENTORIES] 
                                    ORDER BY DATE_RECORDED DESC" CacheDuration="10" EnableCaching="True"></asp:SqlDataSource>
                        </asp:Panel>
                    </div>
                </div>
                <div style="float: left; margin-left: 3px;">
                    <asp:Panel ID="pnlSOIDetails" runat="server">
                        <div style="font-family: Verdana;">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="label">
                                        Transaction Date:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTransactionDate" runat="server" Font-Names="Verdana" Font-Size="10px"
                                            Height="18px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Outlet Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOutletName" runat="server" Font-Names="Verdana" Font-Size="10px"
                                            Height="18px" Width="280px" ForeColor="#003366" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                                    </td>
                                    <td rowspan="3">
                                        <asp:UpdateProgress ID="uProgressSOI" runat="server" AssociatedUpdatePanelID="upnlSOI"
                                            DisplayAfter="100">
                                            <ProgressTemplate>
                                                <asp:PlaceHolder ID="plHldrLoader" runat="server">
                                                    <UC:LOADER ID="uprogLoader" runat="server" />
                                                </asp:PlaceHolder>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Period From:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPeriodFrom" runat="server" Font-Names="Verdana" Font-Size="10px"
                                            Height="18px" AutoPostBack="True" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        To:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPeriodTo" runat="server" Font-Names="Verdana" Font-Size="10px"
                                            Height="18px" AutoPostBack="True" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" style="font-family: Verdana; font-size: 10px;">
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
                                        Avg. Cost
                                    </th>
                                    <th>
                                        Total Cost
                                    </th>
                                </tr>
                                <tr>
                                    <td class="title_label">
                                        Beggining Inventory
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBeginningInventoryVolume" runat="server" Font-Names="Verdana"
                                            Font-Size="11px" AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False"
                                            Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBeginningInventoryValue" runat="server" Font-Names="Verdana"
                                            Font-Size="11px" AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False"
                                            Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBeginningInventoryAvgCost" runat="server" Font-Names="Verdana"
                                            Font-Size="11px" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBeginningInventoryTotalCost" runat="server" Font-Names="Verdana"
                                            Font-Size="11px" AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False"
                                            Width="110">0.00</asp:TextBox>
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
                                        &nbsp; &nbsp; &nbsp; &nbsp;
                                        <asp:Label ID="lblDelivery" runat="server" Text="Delivery"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDeliveryVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDeliveryValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDeliveryAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdeliveryTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
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
                                        <asp:TextBox ID="txtPullOutVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPullOutValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPullOutAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPullOutTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp; &nbsp;&nbsp;Gross Sales
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrossSalesVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrossSalesValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrossSalesAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrossSalesTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title_label">
                                        &nbsp; &nbsp;
                                        <asp:Label ID="lblAdjustment" runat="server" Text="Adjustment"></asp:Label>
                                        &nbsp;
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
                                        &nbsp;&nbsp; &nbsp;&nbsp;Debit(+)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDebitVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDebitValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDebitAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDebitTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp; &nbsp;&nbsp;Credit(-)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCreditVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCreditValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCreditAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCreditTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title_label">
                                        Ending Inventory
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndingInvventoryVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndingInvventoryValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndingInvventoryAvgCost" runat="server" Font-Names="Verdana"
                                            Font-Size="11px" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndingInvventoryTotalCost" runat="server" Font-Names="Verdana"
                                            Font-Size="11px" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title_label">
                                        Actual Account
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActualAccountVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActualAccountValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActualAccountAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActualAccountTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            AutoPostBack="True" ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="title_label">
                                        Discrepancy
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscrepancyVolume" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscrepancyValue" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscrepancyAvgCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscrepancyTotalCost" runat="server" Font-Names="Verdana" Font-Size="11px"
                                            ReadOnly="True" Height="18px" EnableViewState="False" Width="110">0.00</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
                <asp:Panel CssClass="permission-container" ID="pnlNotification" Visible="false" runat="server">
                    <asp:CollapsiblePanelExtender ID="CollapsiblePaneItemMaster" runat="server" CollapseControlID="lblNoteCollapsHandler"
                        CollapsedText="dennis" ExpandedText="pitallano" TargetControlID="pnlPermissionNotification"
                        ExpandControlID="lblNoteCollapsHandler" Collapsed="True">
                    </asp:CollapsiblePanelExtender>
                    <div class="collaps-link">
                        <asp:Label CssClass="collaps-text" ID="lblNoteCollapsHandler" Height="48px" runat="server"
                            Text="NOTE" ToolTip="Show/Hide Notification"></asp:Label>
                    </div>
                    <asp:Panel CssClass="note-container" ID="pnlPermissionNotification" runat="server">
                        <asp:Label ID="lblPermissionNotifications" runat="server" Text="Label"></asp:Label>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <%--   <asp:AsyncPostBackTrigger ControlID="imgBtnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txtSearch" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="gvSOI" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="gvSOI" EventName="PageIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="gvSOI" EventName="Sorting" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
