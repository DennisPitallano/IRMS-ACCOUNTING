<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="BookAdjustmentPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.BookAdjustmentPanel" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/book-adjustment.css" rel="stylesheet" type="text/css" />
      <link href="../Styles/permission-note.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
   <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titlePanel">
        <div style="float: right;">
            <a href="StoreOutStandingInventoryMenu.aspx">
                <img src="../Resources/reply.png" alt="" title="BACK" />
                </a>
        </div>
        <img src="../Resources/invoice.png" alt="" align="top" height="20px" />
        Manage Book Adjustment Panel
    </div>
    <asp:UpdatePanel ID="upnlProducts" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HF_BRAND" runat="server" />
            <div style="width: 100%; height: 26px; margin-bottom:1px;" class="modalDrag">
                <div class="SearchTextContainer">
                   SEARCH: <asp:TextBox ID="txtSearch" runat="server" CssClass="modalText" AutoPostBack="True" autofocus="true" placeholder="Search Book Adjustment"
                        ontextchanged="txtSearch_TextChanged" Height="16px" Font-Size="10px" Width="150px" ToolTip="Search Adjustment"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
                        ToolTip="SEARCH" onclick="imgBtnSearch_Click" />
                </div>
                <div style="float: left;">
                    <div style="float: left; margin-right:2px;">
                        <asp:Button ID="btnNewBookAdjustment" runat="server" Text="NEW " CssClass="btnNew" TabIndex="2" />
                    </div>
                    <div style="float: left; margin-right:2px;">
                        <asp:Button ID="btnUpdateBookAdjustment" runat="server" Text="UPDATE" CssClass="btnUpdate" Visible="False" />
                        <asp:ModalPopupExtender ID="btnUpdateBookAdjustment_ModalPopupExtender" runat="server"
                            CancelControlID="ibtnCloseUpdateModal" DynamicServicePath="" Enabled="True" PopupControlID="pnlUpdateProductCategoryModal"
                            PopupDragHandleControlID="pnlUpdateProductCategoryModalDrag" TargetControlID="btnNewBookAdjustment"
                            BackgroundCssClass="bgModal">
                            <Animations>
                                <OnShown>
                                    <FadeIn Duration=".2" />
                                </OnShown>
                            </Animations>
                        </asp:ModalPopupExtender>
                    </div>
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btnDelete" />
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
                    <div style="float: left; margin-right:2px;">
                        <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btnPrint" />
                        <asp:HoverMenuExtender ID="btnPrint_HoverMenuExtender" runat="server" DynamicServicePath=""
                            Enabled="True" PopupControlID="pnlPrintOption" TargetControlID="btnPrint" 
                            PopupPosition="Bottom">
                        </asp:HoverMenuExtender>
                    </div>
                    <asp:Panel ID="pnlPrintOption" runat="server">
                    <div class="hover-menu-arrow">
                        </div>
                        <div class="hover-menu">
                            <div class="print-link">
                               <asp:HyperLink ID="hLinkPreviewSummary" runat="server" CssClass="PrintOptionBtn"
                                        Target="_blank" ToolTip="Preview Book Adjustment Memo">PREVIEW SUMMARY</asp:HyperLink>
                            </div>
                            <div class="print-link">
                                <asp:HyperLink ID="hLinkPreviewAdjustmentMemo" runat="server" CssClass="PrintOptionBtn"
                                        Target="_blank" ToolTip="Preview Book Adjustment Memo">ADJUSTMENT MEMO</asp:HyperLink>
                            </div>
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
            <div style="float: left; min-height:470px;">
                <div  style="width: 400px; margin-right: 1px; -webkit-box-shadow: 0 8px 6px -6px #95A63F;-moz-box-shadow: 0 8px 6px -6px #95A63F;box-shadow: 0 8px 6px -6px #95A63F; border: 1px Solid #C6BE8B;">
                    <div class="titleList">
                      <img src="../Resources/usermode.png" height="16px" align="top" />
                        LIST OF BOOK ADJUSTMENT MEMO
                    </div>
                    <asp:Panel ID="pnlSizesList" runat="server" Width="400px" Height="435px" ScrollBars="Auto">
                        <asp:GridView ID="gvAdjustmentMemos" runat="server" CellPadding="4" 
                            GridLines="None"  CssClass="table_grid" AutoGenerateColumns="False"
                            DataKeyNames="RECORD_NO" EnablePersistedSelection="True" OnSelectedIndexChanged="gvAdjustmentMemos_SelectedIndexChanged"
                            AllowPaging="True" AllowSorting="True" 
                            DataSourceID="SqlDataSourceBookAdjustments" PageSize="15">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgAdjustmentCode" runat="server" Height="16px" ImageUrl="~/Resources/usermode.png"
                                            AlternateText='<%# Eval("ADJUSTMENT_CODE") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="RECORD_NO" HeaderText="RECORD#" InsertVisible="False"
                                    ReadOnly="True" SortExpression="RECORD_NO">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OUTLET_NAME" HeaderText="OUTLET NAME" SortExpression="OUTLET_NAME">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="INVENTORY_DATE" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="INVENTORY DATE"
                                    SortExpression="INVENTORY_DATE">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CUT_OFF_DATE" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="CUT OFF DATE"
                                    SortExpression="CUT_OFF_DATE">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DATE_RECORDED" HeaderText="DATE RECORDED" SortExpression="DATE_RECORDED">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ADJUSTMENT_CODE" HeaderText="ADJUSTMENT_CODE" SortExpression="ADJUSTMENT_CODE"
                                    Visible="False" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <EmptyDataTemplate>
                                <div style=" width:370px; margin-top:15px; border: 1px solid #FFCC66; height:55px; line-height:55px;
                                            background-color: #FFFFCC; color: #C46200; text-align: center;">
                                            <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                            DATA NOT FOUND!!!
                                        </div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pager" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" Font-Names="Verdana"
                                Font-Size="11px" Font-Italic="True" />
                            <SortedAscendingCellStyle  CssClass="asc_cell_style" />
                            <SortedAscendingHeaderStyle  CssClass="asc_cell_style_h" />
                            <SortedDescendingCellStyle CssClass="desc_cell_style" />
                            <SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
                        </asp:GridView>
                        <%--<asp:SqlDataSource ID="SqlDataSourceBookAdjustments" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [RECORD_NO], [INVENTORY_DATE], [CUT_OFF_DATE], [OUTLET_NAME], [DATE_RECORDED], [ADJUSTMENT_CODE] FROM [BOOK_ADJUSTMENTS] INNER JOIN CustInfo ON BOOK_ADJUSTMENTS.OUTLET_NUMBER = CustInfo.CustNo
                      where CustInfo.brand =@BRAND ORDER BY DATE_RECORDED DESC" 
                            CacheDuration="10" EnableCaching="True">
                              <SelectParameters>
                            <asp:ControlParameter ControlID="HF_BRAND" Name="BRAND" PropertyName="Value"
                                Type="String" />
                             </SelectParameters>
                        </asp:SqlDataSource>--%>
                        <asp:SqlDataSource ID="SqlDataSourceBookAdjustments" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [RECORD_NO], [INVENTORY_DATE], [CUT_OFF_DATE], [OUTLET_NAME], [DATE_RECORDED], [ADJUSTMENT_CODE] FROM [BOOK_ADJUSTMENTS] ORDER BY DATE_RECORDED DESC" 
                            CacheDuration="10" EnableCaching="True">
                        </asp:SqlDataSource>
                    </asp:Panel>
                </div>
            </div>
            <div style="float: left; border-radius:5px 5px 0px 0px; -webkit-box-shadow: 0 8px 6px -6px #95A63F;-moz-box-shadow: 0 8px 6px -6px #95A63F;box-shadow: 0 8px 6px -6px #95A63F; border: 1px Solid #C6BE8B;">
                <div class="titleList" >
                  <img src="../Resources/panels.png" height="16px" align="top" />LIST OF TRANSACTIONS
                    <div style="float: right; margin-right: 5px;">
                        <asp:HyperLink ID="hLinkPrintAdjustmentDetails" runat="server" CssClass="hLinkPrintAdjustmentDetails"
                            Target="_blank">PRINT</asp:HyperLink>
                    </div>
                </div>
                <asp:Panel ID="pnlSKUDetails" runat="server" Height="435px" Width="500px" ScrollBars="Auto">
                    <asp:GridView ID="gvMemoDetails" runat="server" CellPadding="4" 
                        GridLines="None" CssClass="table_grid" AutoGenerateColumns="False"
                        DataKeyNames="RecordNo" EnablePersistedSelection="True" 
                        OnSelectedIndexChanged="gvMemoDetails_SelectedIndexChanged" 
                        EmptyDataText="NO SELECTED ADJUSTMENT!">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="imgTransaction" runat="server" Height="16px" ImageUrl="~/Resources/panels.png"
                                        AlternateText='<%# Eval("RecordNo").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="MemoType" HeaderText="MEMO TYPE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReferenceNumber" HeaderText="REFERENCE#">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MemoDate" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="MEMO DATE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PeriodFrom" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="PERIOD FROM">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PeriodTo" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="PERIOD TO">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ParticularTransaction" HeaderText="TRANSACTION">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="QUANTITY">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CurrentPrice" DataFormatString="{0:Php###,###.00}" HeaderText="CURRENT PRICE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CostPrice" DataFormatString="{0:Php###,###.00}" HeaderText="COST PRICE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <EmptyDataTemplate>
                          <img src="../Resources/unhappy.png" align="middle" />
                           ITEM NOT FOUND!!
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle  CssClass="pager" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle  CssClass="asc_cell_style" />
                        <SortedAscendingHeaderStyle CssClass="asc_cell_style_h"/>
                        <SortedDescendingCellStyle  CssClass="desc_cell_style" />
                        <SortedDescendingHeaderStyle  CssClass="desc_cell_style_h" />
                    </asp:GridView>
                </asp:Panel>
            </div>

            <asp:Panel ID="pnlUpdateProductCategoryModal" runat="server" CssClass="modal">
                <asp:Panel ID="pnlUpdateProductCategoryModalDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="ibtnCloseUpdateModal" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                            ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                    <img src="../Resources/usermode.png" alt="NEW" align="top" height="16px" />NEW BOOK ADJUSTMENT
                    </div>
                </asp:Panel>
                <div>
                      <div class="modalLabel" style=" font-weight:bold; margin-top: 15px; margin-left: 5px; float: left;">
                       LIST OF OUTLET
                    </div>
                    <div style="margin-left: 5px; height:28px; text-align: right; line-height: 24px;">
                        <div class="SearchTextContainer" style=" height:22px;">
                          SEARCH:<asp:TextBox ID="txtSearchOutlet" runat="server" CssClass="modalText" Font-Names="Verdana" Height="16px"
                           placeholder="Search Csustomer" Font-Size="10px"></asp:TextBox>
                            <asp:ImageButton ID="imgBtnSearchOutlet" runat="server"  ImageUrl="~/Resources/search.png"
                                ImageAlign="AbsMiddle" OnClick="imgBtnSearchOutlet_Click" ToolTip="SEARCH" />
                        </div>
                    </div>
                    <asp:Panel ID="outlets_container" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="gvOutlets" runat="server" CssClass="table_grid" 
                            CellPadding="4" Font-Names="Verdana" 
                            GridLines="None" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CustNo" DataSourceID="SqlDataSourceCustomers"
                            OnSelectedIndexChanged="gvOutlets_SelectedIndexChanged" EnablePersistedSelection="True"
                            OnPageIndexChanged="gvOutlets_PageIndexChanged" 
                            OnSorted="gvOutlets_Sorted" OnPageIndexChanging="gvOutlets_PageIndexChanging" 
                            ForeColor="#333333">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Image ID="imgOutlet" runat="server" Height="14px" ImageUrl="~/Resources/invoice.png"
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
                                 <div style=" width:370px; margin-top:15px; border: 1px solid #FFCC66; height:55px; line-height:55px;
                                            background-color: #FFFFCC; color: #C46200; text-align: center;">
                                            <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                            DATA NOT FOUND!!!
                                        </div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle  CssClass="pager" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle  CssClass="asc_cell_style" BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle  CssClass="asc_cell_style_h" BackColor="#246B61" />
                            <SortedDescendingCellStyle  CssClass="desc_cell_style" BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle  CssClass="desc_cell_style_h" 
                                BackColor="#15524A" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [CustNo], [CompName], [brand] FROM [CustInfo]" 
                            EnableCaching="True"></asp:SqlDataSource>
                    </asp:Panel>
                </div>
                    <div style="margin:3px 3px 0px 5px;">
                    <asp:Label ID="Label4" runat="server" Font-Names="Verdana" Font-Size="10px" CssClass="input-form-label">PERIOD FROM: </asp:Label>
                    <asp:TextBox ID="txtDateFrom" runat="server" Height="18px" CssClass="modalText" Font-Size="10px"
                        Width="120px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="txtDateFrom" Format=" MMMM dd, yyyy">
                    </asp:CalendarExtender>
                    <asp:Label ID="Label5" runat="server" Font-Size="10px" CssClass="input-form-label"
                        Text=" TO"></asp:Label>
                    <asp:TextBox ID="txtPeriodTo" runat="server" Height="18px" CssClass="modalText" Font-Size="10px"
                        Width="120px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtPeriodTo_CalendarExtender" runat="server" Enabled="True"
                        Format=" MMMM dd, yyyy" TargetControlID="txtPeriodTo">
                    </asp:CalendarExtender>
                </div>
                <div style="text-align: center; margin-top: 10px; margin-bottom: 5px;">
                    <asp:Button ID="btncontinueAdjustment" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        ToolTip="Select Outlet and continue to adjustment." OnClick="btncontinueAdjustment_Click"
                        PostBackUrl="~/Accounting/NewBookAdjustment.aspx" />
                </div>
            </asp:Panel>
             <asp:Label ID="lblDeleted" runat="server" Text=""></asp:Label>
        <asp:ModalPopupExtender ID="lblDeleted_ModalPopupExtender" runat="server" 
            DynamicServicePath="" Enabled="True" PopupControlID="pnlDeleted" 
            PopupDragHandleControlID="pnlDeletedDrag" TargetControlID="lblDeleted" 
            BackgroundCssClass="bgModal" CancelControlID="btnOk">
        </asp:ModalPopupExtender>
        
        <asp:Panel ID ="pnlDeleted" runat ="server" CssClass ="modal" >
         <asp:Panel ID= "pnlDeletedDrag" runat ="server" CssClass ="modalDrag">
          <div class ="sizeLogo">
            <asp:Image ID="Image4" runat="server" Height="16px" ImageAlign="AbsBottom" 
                       ImageUrl="~/Resources/product.png" />
            Book Adjustment!
          </div>
        </asp:Panel>
            <div style ="text-align:center; padding:5px 30px;">
                <asp:Label ID="Label2" runat="server" Text="Item Successfully Deleted!" 
                    Font-Names="Verdana" Font-Size="12px" ForeColor="#FFFFCC"></asp:Label>
            </div>
            <div style ="text-align:center; margin:5px 0px;">
            <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="modalWarningButtonYes" />
            </div>
        </asp:Panel>

        <%--Delete Modal--%>
        <asp:Panel ID="pnlDeleteModal" runat="server" CssClass="modal">
                <asp:Panel ID="pnlDeleteModalDrag" runat="server" CssClass="modalDrag">
                    <div class="sizeLogo">
                        <asp:Image ID="Image2" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/product.png" />
                        CONFIRMATION!!!
                    </div>
                </asp:Panel>
                <div class="modalWarningText">
                   <div style=" margin:1px 20px; border: 1px solid #FFCC66; height:50px; line-height:50px; background-color: #FFFFCC; color: #C46200; text-align:center;">
                        <asp:Image ID="imgWarningDelete" runat="server" 
                            ImageUrl="~/Resources/warning.png" ImageAlign="AbsMiddle" />
                        <asp:Label ID="Label14" runat="server" Text="Warning, you cannot undo this action." Font-Size="11px"></asp:Label>
                    </div>
                    <div style="margin:2px 2px; text-align:center;">
                        <br />
                        <asp:Label ID="Label15" runat="server" Text="Are you sure you want to delete this data?"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblCustomerNameToDelete" runat="server" ForeColor="#FFDF9D" Font-Size="11px" Text="No selected data to delete!" ></asp:Label>
                        <br />
                        <asp:Label ID="lblDateFromToToDelete" runat="server" ForeColor="#FFDF9D" Font-Size="11px" Text="" ></asp:Label>
                    </div>
                </div>
                <div style=" text-align:center; margin-top: 12px; margin-bottom: 5px;">
                    <asp:Button ID="btnYes" runat="server" Text="YES" CssClass="modalWarningButtonYes"
                        ToolTip="Delete" OnClick="btnYes_Click" />
                    <asp:Button ID="btnNo" runat="server" Text="NO" CssClass="modalWarningButtonNo" ToolTip="Cancel" />
                </div>
            </asp:Panel>

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
    </asp:UpdatePanel>
</asp:Content>
