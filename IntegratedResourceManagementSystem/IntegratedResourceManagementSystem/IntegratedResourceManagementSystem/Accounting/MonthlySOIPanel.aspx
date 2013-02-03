<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="MonthlySOIPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.MonthlySOIPanel" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/monthly-soi.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/permission-note.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titlePanel">
        <img src="../Resources/invoice.png" height="22px" align="top" />
        Monthly Store OutStanding Inventory Management Panel.
    </div>
    <asp:UpdatePanel ID="upnlProducts" runat="server">
        <ContentTemplate>
            <div style="height: 26px; margin-bottom: 1px;" class="modalDrag">
                <div class="SearchTextContainer">
                    SEARCH:
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="modalText" AutoPostBack="True"
                        autofocus="true" placeholder="Search SOI" Height="16px" Font-Size="10px"
                        Width="150px" ToolTip="Search SOI" 
                        ontextchanged="txtSearch_TextChanged"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
                        ToolTip="SEARCH" onclick="imgBtnSearch_Click" />
                </div>
                <div style="float: left;">
                    <div style="float: left; margin-right: 2px;">
                        <a style="text-decoration: none;" href="NewMonthlySOI.aspx" title="NEW SOI">
                            <input id="btnNewBookAdjustment" class="btnNew" type="button" value="NEW" />
                        </a>
                    </div>
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnUpdateBookAdjustment" runat="server" Text="UPDATE" CssClass="btnUpdate"
                            Visible="False" />
                    </div>
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnDelete" runat="server" Text="DELETE" ToolTip="Delete Selected SOI"
                            CssClass="btnDelete" />
                        <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" CancelControlID="btnNo"
                            DynamicServicePath="" Enabled="True" PopupControlID="pnlConfirmDeleteModal" PopupDragHandleControlID="pnlConfirmDeleteModalDrag"
                            TargetControlID="btnDelete" BackgroundCssClass="bgModal">
                        </asp:ModalPopupExtender>
                    </div>
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btnPrint" />
                        <asp:HoverMenuExtender ID="btnPrint_HoverMenuExtender" runat="server" DynamicServicePath=""
                            Enabled="True" PopupControlID="pnlPrintOption" TargetControlID="btnPrint" PopupPosition="Bottom">
                        </asp:HoverMenuExtender>
                    </div>
                    <asp:Panel ID="pnlPrintOption" runat="server">
                        <div class="hover-menu-arrow">
                        </div>
                        <div class="hover-menu">
                            <div class="print-link">
                                <asp:HyperLink ID="hLinkPreview" runat="server" CssClass="PrintOptionBtn" Target="_blank"
                                    ToolTip="Preview Book Adjustment Memo">PREVIEW SOI</asp:HyperLink>
                            </div>
                            <%--<div class="print-link">
                                <asp:HyperLink ID="hLinkPreviewAdjustmentMemo" runat="server" CssClass="PrintOptionBtn"
                                        Target="_blank" ToolTip="Preview Adjustments">PREVIEW ADJUSTMENTS</asp:HyperLink>
                            </div>--%>
                        </div>
                    </asp:Panel>
                </div>
                <asp:UpdateProgress ID="uprogressAdjustmentMemo" runat="server" AssociatedUpdatePanelID="upnlProducts">
                    <ProgressTemplate>
                        <asp:PlaceHolder ID="plHldrLoader" runat="server">
                            <UC:LOADER ID="uprogLoader" runat="server" />
                        </asp:PlaceHolder>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="min-height: 450px;">
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
                <div style="float:left;">
                    <div class="titleList">
                        <img src="../Resources/invoice.png" height="16px" align="top" alt="" />
                        LIST OF MONTHLY STORE OUTSTANDING INVENTORY
                    </div>
                      
                    <div>
                        <asp:GridView ID="gvMOnthlySOI" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RECORD_NO,SOI_CODE"
                            DataSourceID="SqlDataSourceMonthlySOI" CssClass="table_grid" GridLines="None"
                            PageSize="15" OnSelectedIndexChanged="gvMOnthlySOI_SelectedIndexChanged" 
                            onpageindexchanging="gvMOnthlySOI_PageIndexChanging" 
                            onselectedindexchanging="gvMOnthlySOI_SelectedIndexChanging" 
                            onsorting="gvMOnthlySOI_Sorting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl="~/Resources/invoice.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="RECORD_NO" HeaderText="RECORD #" InsertVisible="False"
                                    ReadOnly="True" SortExpression="RECORD_NO">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CUSTOMER" HeaderText="CUSTOMER" SortExpression="CUSTOMER" />
                                <asp:BoundField DataField="PERIOD_FROM" HeaderText="PERIOD_FROM" SortExpression="PERIOD_FROM"
                                    DataFormatString="{0:MMMM dd, yyyy}">
                                    <ItemStyle Font-Bold="True" ForeColor="#663300" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PERIOD_TO" HeaderText="PERIOD_TO" SortExpression="PERIOD_TO"
                                    DataFormatString="{0:MMMM dd, yyyy}">
                                    <ItemStyle Font-Bold="True" ForeColor="#663300" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <EmptyDataTemplate>
                                <img src="../Resources/unhappy.png" align="middle" />
                                EMPTY DATA!!!<br />
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle CssClass="pager" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle CssClass="asc_cell_style" />
                            <SortedAscendingHeaderStyle CssClass="asc_cell_style_h" />
                            <SortedDescendingCellStyle CssClass="desc_cell_style" />
                            <SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceMonthlySOI" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [RECORD_NO], [CUSTOMER], [PERIOD_FROM], [PERIOD_TO],[SOI_CODE] FROM [MONTHLY_SOI] ORDER BY RECORD_NO DESC" 
                            CacheDuration="15" EnableCaching="True">
                        </asp:SqlDataSource>
                    </div>
                 
                </div>
            </div>
            <asp:Panel ID="pnlConfirmDeleteModal" CssClass="modal" runat="server">
                <asp:Panel ID="pnlConfirmDeleteModalDrag" CssClass="modalDrag" runat="server">
                    <div class="sizeLogo">
                        <img src="../Resources/warning.png" alt="NEW" align="top" height="16px" />CONFIRMATION!!!
                    </div>
                </asp:Panel>
                <div class="input-form-label" style="text-align: center; font-size: 11px; padding: 5px;
                    margin: 5px;">
                    <img src="../Resources/warning.png" align="middle" alt="" />
                    <asp:Label ID="lblDeleteMessage" runat="server" Text="No Selected data to delete."></asp:Label>
                </div>
                <div style="text-align: center; margin-bottom: 5px;">
                    <asp:Button ID="btnYes" CssClass="modalWarningButtonYes" runat="server" Text="YES"
                        OnClick="btnYes_Click" Enabled="false" />
                    <asp:Button ID="btnNo" CssClass="modalWarningButtonNo" runat="server" Text="NO" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
