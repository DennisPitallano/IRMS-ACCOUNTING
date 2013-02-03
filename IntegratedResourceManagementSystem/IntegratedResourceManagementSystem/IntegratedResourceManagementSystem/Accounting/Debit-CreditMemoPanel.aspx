<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="Debit-CreditMemoPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.Debit_CreditMemoPanel" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/pcount-adjustment.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/permission-note.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
   <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titlePanel">
        <div style="float: right;">
            <a href="StoreOutStandingInventoryMenu.aspx" title="Back">
                <img src="../Resources/reply.png" alt="BACK" />
            </a>
        </div>
        <asp:Image ID="imgManagePCOUNTADJUSTMENT" runat="server" Height="20px" ImageUrl="~/Resources/invoice.png"
            ImageAlign="AbsMiddle" />
            Manage Physical Count Adjustment Panel
       
    </div>
    <asp:UpdatePanel ID="upnlProducts" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HF_BRAND" runat="server" />
            <div style="width: 100%; height: 26px; margin-bottom: 1px;" class="modalDrag">
                <div class="SearchTextContainer">
                  SEARCH: <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" autofocus placeholder="Search PCount Adjustment" CssClass="modalText" OnTextChanged="txtSearch_TextChanged" Height="16px" Font-Size="10px" Width="150px" ToolTip="Search Adjustment"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
                        ToolTip="SEARCH" onclick="imgBtnSearch_Click" />
                </div>
                <div style="float: left;">
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnNewProductCategory" runat="server" Text="NEW MEMO" CssClass="btnNew"
                            TabIndex="2" EnableViewState="False" />
                    </div>
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnUpdateProductCategory" runat="server" Text="UPDATE" CssClass="btnUpdate"
                            Font-Names="Verdana" Visible="False" EnableViewState="False" />
                        <asp:ModalPopupExtender ID="btnUpdateProductCategory_ModalPopupExtender" runat="server"
                            CancelControlID="ibtnCloseUpdateModal" DynamicServicePath="" Enabled="True" PopupControlID="pnlUpdateProductCategoryModal"
                            PopupDragHandleControlID="pnlUpdateProductCategoryModalDrag" TargetControlID="btnNewProductCategory"
                            BackgroundCssClass="bgModal">
                            <Animations>
                                      <OnShown>
                                         <FadeIn Duration=".2" />
                                      </OnShown>
                            </Animations>
                        </asp:ModalPopupExtender>
                    </div>
                    <div style="float: left; margin-right: 2px;">
                        <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass="btnDelete" 
                            EnableViewState="False" />
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
                        <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btnPrint" 
                            Font-Names="Verdana" EnableViewState="False" />
                        <asp:HoverMenuExtender ID="btnPrint_HoverMenuExtender" runat="server" DynamicServicePath=""
                            Enabled="True" PopupControlID="pnlPrintOption" TargetControlID="btnPrint" 
                            PopupPosition="Bottom">
                        </asp:HoverMenuExtender>
                    </div>
                    <asp:Panel ID="pnlPrintOption" runat="server"  >
                    <div class="hover-menu-arrow">
                        </div>
                        <div class="hover-menu">
                            <div class="print-link">
                              <asp:HyperLink ID="hpLinkPreviewSummary" runat="server" Target="_blank" EnableViewState="False">PREVIEW SUMMARY</asp:HyperLink>
                            </div>
                            <div class="print-link">
                                <asp:HyperLink ID="hLinkPreviewAdjustment" runat="server" Target="_blank" EnableViewState="False">PREVIEW ADJUSTMENT</asp:HyperLink>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <asp:UpdateProgress ID="uprogressAdjustmentMemo" runat="server" AssociatedUpdatePanelID="upnlProducts">
                    <ProgressTemplate>
                        <asp:PlaceHolder ID="plHldrLoader" runat="server">
                            <UC:LOADER ID="loader" runat="server" />
                        </asp:PlaceHolder>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="float: left; min-height:470px;">
                <div style="width:400px; margin-right: 1px;  border-radius:5px 5px 0px 0px; -webkit-box-shadow: 0 8px 6px -6px #95A63F;-moz-box-shadow: 0 8px 6px -6px #95A63F;box-shadow: 0 8px 6px -6px #95A63F; border: 1px Solid #C6BE8B;">
                    <div class="titleList">
                     <img src="../Resources/usermode.png" height="18px" alt="LIST" align="top"  />
                        &nbsp;LIST OF ADJUSTMENT MEMO
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlSizesList" runat="server" Width="400px" Height="430px" ScrollBars="Auto">
                                <asp:GridView ID="gvAdjustmentMemos" runat="server" CellPadding="4" 
                                    GridLines="None"  CssClass="table_grid" OnSelectedIndexChanged="gvAdjustmentMemos_SelectedIndexChanged"
                                    AutoGenerateColumns="False" DataKeyNames="RECORD_NO" EnablePersistedSelection="True"
                                    AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSourcePCountAdjustments"
                                    PageSize="13">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Image ID="imgAdjustmentCode" runat="server" Height="16px" ImageUrl="~/Resources/usermode.png"
                                                    ToolTip='<%# "CUSTOMER: " + Eval("OUTLET_NAME") +"\nDATE FROM: "+Eval("INVENTORY_DATE")+"\nTO: "+Eval("CUT_OFF_DATE") %>'
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
                                        <asp:BoundField DataField="INVENTORY_DATE" HeaderText="INVENTORY DATE" SortExpression="INVENTORY_DATE"
                                            DataFormatString="{0:MMMM dd, yyyy}">
                                            <HeaderStyle Wrap="False" />
                                            <ItemStyle Wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CUT_OFF_DATE" HeaderText="CUT OFF DATE" SortExpression="CUT_OFF_DATE"
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
                                        <div style=" width:370px; margin-top:15px; border: 1px solid #FFCC66; height:55px; line-height:55px;
                                            background-color: #FFFFCC; color: #C46200; text-align: center;">
                                            <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                            DATA NOT FOUND!!!
                                        </div>
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle  CssClass="pager"/>
                                    <RowStyle BackColor="#E3EAEB" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" Font-Names="Verdana"
                                        Font-Size="11px" Font-Italic="True" />
                                    <SortedAscendingCellStyle  CssClass="asc_cell_style"/>
                                    <SortedAscendingHeaderStyle  CssClass="asc_cell_style_h"/>
                                    <SortedDescendingCellStyle CssClass="desc_cell_style" />
                                    <SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
                                </asp:GridView>
                             
                                <asp:SqlDataSource ID="SqlDataSourcePCountAdjustments" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                    SelectCommand="SELECT [RECORD_NO], [INVENTORY_DATE], [CUT_OFF_DATE], [OUTLET_NAME], [DATE_RECORDED],[ADJUSTMENT_CODE] FROM [ADJUSTMENTS]  ORDER BY RECORD_NO DESC" 
                                    CacheDuration="10" EnableCaching="True">
                                </asp:SqlDataSource>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="float:left;  border-radius:5px 5px 0px 0px; 
                -webkit-box-shadow: 0 8px 6px -6px #95A63F;-moz-box-shadow: 0 8px 6px -6px #95A63F;
                box-shadow: 0 8px 6px -6px #95A63F; border: 1px Solid #C6BE8B;">
                <div class="titleList">
                    <img src="../Resources/panels.png" height="16px" align="top" />LIST OF TRANSACTIONS
                    <div style="float: right; margin-right: 5px; margin-top: 2px;">
                        <asp:HyperLink ID="hLinkPrintAdjustmentDetails" runat="server" CssClass="hLinkPrintAdjustmentDetails"
                            Target="_blank">PRINT</asp:HyperLink>
                    </div>
                </div>
                <asp:Panel ID="pnlSKUDetails" runat="server" Height="430px" Width="500px" ScrollBars="Auto">
                    <asp:GridView ID="gvMemoDetails" runat="server" CellPadding="4" 
                        GridLines="None"  AutoGenerateColumns="False" CssClass="table_grid"
                        DataKeyNames="RECORD_NO" EnablePersistedSelection="True" OnSelectedIndexChanged="gvMemoDetails_SelectedIndexChanged"
                        AllowSorting="True" DataSourceID="SqlDataSourceAdjustmentsMemoDetails">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="imgTransaction" runat="server" Height="16px" ImageUrl="~/Resources/panels.png"
                                        AlternateText='<%# Eval("RECORD_NO").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="MEMO_TYPE" HeaderText="MEMO TYPE" SortExpression="MEMO_TYPE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REFERENCE_NUMBER" HeaderText="REFERENCE#" SortExpression="REFERENCE_NUMBER">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MEMO_DATE" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="MEMO DATE"
                                SortExpression="MEMO_DATE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PERIOD_FROM" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="PERIOD FROM"
                                SortExpression="PERIOD_FROM">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PERIOD_TO" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="PERIOD TO"
                                SortExpression="PERIOD_TO">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PARTICULAR_TRANSACTION" HeaderText="TRANSACTION" SortExpression="PARTICULAR_TRANSACTION">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" SortExpression="QUANTITY">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CURRENT_PRICE" DataFormatString="{0:Php###,###.00}" HeaderText="CURRENT PRICE"
                                SortExpression="CURRENT_PRICE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COST_PRICE" DataFormatString="{0:Php###,###.00}" HeaderText="COST PRICE"
                                SortExpression="COST_PRICE">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <EmptyDataTemplate>
                          <img src="../Resources/unhappy.png" align="middle" />
                           NO SELECTED ITEM!!
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle  CssClass="asc_cell_style" />
                        <SortedAscendingHeaderStyle CssClass="asc_cell_style_h" />
                        <SortedDescendingCellStyle CssClass ="desc_cell_style" />
                        <SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceAdjustmentsMemoDetails" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                        
                        SelectCommand="SELECT * FROM [ADJUSTMENT_MEMOS] WHERE ([ADJUSTMENT_CODE] = @ADJUSTMENT_CODE)" 
                        CacheDuration="10" EnableCaching="True">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hfAdjustmentCode" Name="ADJUSTMENT_CODE" PropertyName="Value"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
                <asp:HiddenField ID="hfAdjustmentCode" runat="server" />
            </div>
            <asp:Panel ID="pnlUpdateProductCategoryModal" runat="server" CssClass="modal">
                <asp:Panel ID="pnlUpdateProductCategoryModalDrag" runat="server" CssClass="modalDrag">
                    <div class=" close_btn">
                        <asp:ImageButton ID="ibtnCloseUpdateModal" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                            ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <img src="../Resources/usermode.png" height="16px" align="top" />
                        NEW BOOK ADJUSTMENT
                    </div>
                </asp:Panel>
                <div>
                    <div class="modalLabel" style=" font-weight:bold; margin-top: 15px; margin-left: 5px; float: left;">
                       LIST OF OUTLET
                    </div>
                    <div style="margin-left: 5px; height:28px; text-align: right; line-height: 24px;">
                        <div class="SearchTextContainer" style="height:22px;">
                           SEARCH: <asp:TextBox ID="txtSearchOutlet" runat="server" placeholder="Search Customer" CssClass="modalText" Height="16px" Font-Size="10px"></asp:TextBox>
                            <asp:ImageButton ID="imgBtnSearchOutlet" runat="server" ImageUrl="~/Resources/search.png"
                                ImageAlign="AbsMiddle" OnClick="imgBtnSearchOutlet_Click" ToolTip="SEARCH" />
                        </div>
                    </div>
                    <asp:Panel ID="outlets_container" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="gvOutlets" runat="server"  CellPadding="4" CssClass="table_grid" 
                        GridLines="None" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataKeyNames="CustNo" DataSourceID="SqlDataSourceCustomers"
                            OnSelectedIndexChanged="gvOutlets_SelectedIndexChanged" EnablePersistedSelection="True"
                            OnPageIndexChanged="gvOutlets_PageIndexChanged" 
                            OnSorted="gvOutlets_Sorted" 
                            OnPageIndexChanging="gvOutlets_PageIndexChanging" ForeColor="#333333" >
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
                            <PagerSettings
                                Mode="NumericFirstLast" />
                            <PagerStyle CssClass="pager"  />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle CssClass="asc_cell_style" BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle  CssClass="asc_cell_style_h" BackColor="#246B61"/>
                            <SortedDescendingCellStyle CssClass="desc_cell_style" BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle  CssClass="desc_cell_style_h" 
                                BackColor="#15524A" />
                        </asp:GridView>
                             <asp:SqlDataSource ID="SqlDataSourceCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SELECT [CustNo], [CompName], [brand] FROM [CustInfo]" 
                            EnableCaching="True">
                           
                            </asp:SqlDataSource>
                    </asp:Panel>
                </div>
                <div style="margin: 10px 3px 0px 5px;">
                    <asp:Label ID="Label4" runat="server" Font-Names="Verdana"  Font-Size="10px" ForeColor="#FFFFCC">PERIOD FROM: </asp:Label>
                    <asp:TextBox ID="txtDateFrom" CssClass="modalText" Height="18px" ForeColor="#003366" runat="server" Font-Size="10px"
                        Width="120px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" Enabled="True"
                        TargetControlID="txtDateFrom" Format=" MMMM dd, yyyy">
                    </asp:CalendarExtender>
                    <asp:Label ID="Label5" runat="server" Font-Names="Verdana" Font-Size="10px" ForeColor="#FFFFCC"
                        Text=" TO"></asp:Label>
                    <asp:TextBox ID="txtPeriodTo" Height="18px" CssClass="modalText" runat="server" ForeColor="#003366" Font-Size="10px"
                        Width="120px"></asp:TextBox>
                    <asp:CalendarExtender ID="txtPeriodTo_CalendarExtender" runat="server" Enabled="True"
                        Format=" MMMM dd, yyyy" TargetControlID="txtPeriodTo">
                    </asp:CalendarExtender>
                </div>
                <div style="text-align: center; margin-top: 10px; margin-bottom: 5px;">
                    <asp:Button ID="btncontinueAdjustment" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        ToolTip="Select Outlet and continue to adjustment." OnClick="btncontinueAdjustment_Click"
                        PostBackUrl="~/Accounting/MemoForm.aspx" EnableViewState="False" />
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
                        <asp:Image ID="Image4" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/product.png" />
                        Physical Count
                    </div>
                </asp:Panel>
                <div style="text-align: center; padding: 5px 30px;">
                    <asp:Label ID="Label2" runat="server" Text="Item Successfully Deleted!" Font-Names="Verdana"
                        Font-Size="12px" ForeColor="#FFFFCC"></asp:Label>
                </div>
                <div style="text-align: center; margin: 5px 0px;">
                    <asp:Button ID="btnOk" runat="server" Text="OK" 
                        CssClass="modalWarningButtonYes" EnableViewState="False" />
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
                  <div style=" margin:1px 20px; border: 1px solid #FFCC66; height:50px; line-height:25px; background-color: #FFFFCC; color: #C46200; text-align:center;">
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
                <div style="text-align: center; margin-top: 12px; margin-bottom: 5px; margin-right: 10px;
                    margin-left: 5px;">
                    <asp:Button ID="btnYes" runat="server" Text="YES" CssClass="modalWarningButtonYes"
                        ToolTip="Delete" OnClick="btnYes_Click" EnableViewState="False" />
                    <asp:Button ID="btnNo" runat="server" Text="NO" CssClass="modalWarningButtonNo" 
                        ToolTip="Cancel" EnableViewState="False" />
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
