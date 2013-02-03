<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="CustomerReturnSlipConfirmationPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.CustomerReturnSlipConfirmationPanel" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.2.js" type="text/javascript"></script>
    <link href="../Styles/grid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {


        });
    </script>
    <link href="../Styles/soi-form.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .dtlsLabel
        {
            font-family: Verdana;
            font-size: 11px;
            text-align: right;
            color: #FFFFCC;
        }
        .btnCancelDR
        {
            font-family: Verdana;
            font-weight: bold;
            font-size: 10px;
            height: 30px;
            text-align: right;
            background-image: url('../Resources/yes.png'), -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
            background-image: url('../Resources/yes.png'), -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
            background-repeat: no-repeat;
            background-position: left;
            color: #FCFCFC;
            width: 110px;
            height: 30px;
            cursor: pointer;
        }
        .btnCancelDR:hover
        {
            margin-top: 1px;
            color: #FFFFCC;
        }
        .lblModal
        {
            font-family: Verdana;
            color: #FFFFCC;
            text-align: right;
            font-size: 11px;
        }
      
        #MainContent_gvDeliveryReceipts tr:nth-child(n+2):hover
        {
            background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
            background-image: -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
            color: #FFFFCC;
        }
    </style>
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
   <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="imgDRTitle" runat="server" ImageUrl="~/Resources/panels.png" ImageAlign="AbsMiddle" />
        MANAGE CUSTOMER RETURN SLIP CONFIRMATION
        <hr />
    </div>
    <asp:UpdatePanel ID="upnlDeliveryReceipts" runat="server">
        <ContentTemplate>
            <div style="width: 850px; margin-bottom: 1px; height: 30px;" class="modalDrag">
                <div style="float: right;">
                    FILTER:<asp:RadioButtonList ID="rdioFilterView" runat="server" Font-Names="Verdana"
                        Font-Size="10px" ForeColor="#993300" RepeatDirection="Horizontal" RepeatLayout="Flow"
                        AutoPostBack="True" OnSelectedIndexChanged="rdioFilterView_SelectedIndexChanged">
                        <asp:ListItem Selected="True">UNPOSTED</asp:ListItem>
                        <asp:ListItem>POSTED</asp:ListItem>
                        <asp:ListItem Value="CONFIRMED">CONFIRMED</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:TextBox ID="txtSearchDR" runat="server" Font-Names="Verdana" Width="120px"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnSearchDR" runat="server" ImageAlign="Top" ImageUrl="~/Resources/search.png"
                        ToolTip="Search Delivery Receipt" OnClick="imgBtnSearchDR_Click" />
                    <asp:ImageButton ID="ibtnEnableDate" runat="server" ImageAlign="Middle" ImageUrl="~/Resources/calendar-icon.png"
                        ToolTip="Enable Date Range" />
                    <asp:ModalPopupExtender ID="ibtnEnableDate_ModalPopupExtender" runat="server" DynamicServicePath=""
                        Enabled="True" TargetControlID="ibtnEnableDate" PopupControlID="pnlAdvanceSearch"
                        PopupDragHandleControlID="pnlAdvanceSearchDrag" CancelControlID="ibtnCloseAdvanceSearch">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlAdvanceSearch" runat="server" CssClass="modal">
                        <asp:Panel ID="pnlAdvanceSearchDrag" runat="server" CssClass="modalDrag">
                            <div class="close_btn">
                                <asp:ImageButton ID="ibtnCloseAdvanceSearch" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                                    ToolTip="CLOSE" />
                            </div>
                            <div class="sizeLogo">
                                <asp:Image ID="Image3" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/panels.png" />
                                INCLUDE DATE RANGE SEARCH OPTION!
                            </div>
                        </asp:Panel>
                        <div style="margin: 5px 3px 15px 15px;">
                            <asp:Label ID="lblDateRange" runat="server" Text="DATE RANGE:" Font-Names="Verdana"
                                ForeColor="#FFCC66" Font-Size="12px"></asp:Label>
                            <asp:Label ID="lblCompanyFrom" runat="server" Text="FROM" Font-Names="Verdana" ForeColor="#FFFFCC"
                                Font-Size="11px"></asp:Label>
                            <asp:TextBox ID="txtDateSeachFrom" runat="server" Font-Names="Verdana" Font-Size="11px"
                                Height="20px" AutoPostBack="True" OnTextChanged="txtDateSeachFrom_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDateSeachFrom_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtDateSeachFrom" Format="MMMM dd, yyyy">
                            </asp:CalendarExtender>
                            <asp:Label ID="lblCompany_To" runat="server" Text="TO" Font-Names="Verdana" ForeColor="#FFFFCC"
                                Font-Size="11px"></asp:Label>
                            <asp:TextBox ID="txtDateSeachTo" runat="server" Font-Names="Verdana" Font-Size="11px"
                                Height="20px" AutoPostBack="True" OnTextChanged="txtDateSeachTo_TextChanged"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDateSeachTo_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txtDateSeachTo" Format="MMMM dd, yyyy">
                            </asp:CalendarExtender>
                            <br />
                            <asp:Button ID="btnGo" runat="server" Text="GO" onclick="btnGo_Click" />
                        </div>
                    </asp:Panel>
                    <asp:DropShadowExtender ID="pnlAdvanceSearch_DropShadowExtender" runat="server" Enabled="True"
                        Opacity="0.75" TargetControlID="pnlAdvanceSearch">
                    </asp:DropShadowExtender>
                </div>
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <asp:ModalPopupExtender ID="btnPreviewSelectedDRForcancel_ModalPopupExtender" runat="server"
                    DynamicServicePath="" Enabled="True" TargetControlID="Label1" PopupControlID="pnlSelectedDRPreview"
                    PopupDragHandleControlID="pnlSelectedDRPreviewDrag" BackgroundCssClass="bgModal"
                    CancelControlID="imgBtnClosepnlSelectedDRPreview">
                    <Animations>
                            <OnShown>
                                <FadeIn Duration=".2" />
                            </OnShown>
                    </Animations>
                </asp:ModalPopupExtender>
                <div style="float: left; height: 32px; margin-right: 5px;">
                    <asp:Button ID="btnConfirmedDR" runat="server" OnClick="btnCancelSelectedDR_Click"
                        Text="CONFIRM CRS" CssClass="btnCancelDR" />
                    <asp:RoundedCornersExtender ID="btnPreviewSelectedDRForcancel_RoundedCornersExtender"
                        runat="server" Enabled="True" TargetControlID="btnConfirmedDR" BorderColor="LightGray">
                    </asp:RoundedCornersExtender>
                </div>
                <div style="float: left; height: 32px;">
                    <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btnPrint" Height="30px" />
                    <asp:RoundedCornersExtender ID="btnPrint_RoundedCornersExtender" runat="server" BorderColor="LightGray"
                        Enabled="True" TargetControlID="btnPrint">
                    </asp:RoundedCornersExtender>
                    <asp:ModalPopupExtender ID="btnPrint_ModalPopupExtender" runat="server" DynamicServicePath=""
                        Enabled="True" TargetControlID="btnPrint" CancelControlID="ibtnClosepnlPrintOptionModal"
                        PopupControlID="pnlPrintOptionModal" PopupDragHandleControlID="pnlPrintOptionModalDrag">
                        <Animations>
                                <OnShown>
                                    <FadeIn Duration=".2" />
                                </OnShown>
                        </Animations>
                    </asp:ModalPopupExtender>
                </div>
                <div style="float: left; height: 32px; margin-left: 2px;">
                    <asp:Button ID="btnPreviewDRDetails" runat="server" Text="PREVIEW DETAILS" CssClass="btnPrint"
                        Height="30px" Font-Names="Verdana" Font-Size="10px" />
                    <asp:RoundedCornersExtender ID="btnPreviewDRDetails_RoundedCornersExtender" runat="server"
                        BorderColor="LightGray" Enabled="True" TargetControlID="btnPreviewDRDetails">
                    </asp:RoundedCornersExtender>
                    <asp:ModalPopupExtender ID="btnPreviewDRDetails_ModalPopupExtender" runat="server"
                        DynamicServicePath="" Enabled="True" TargetControlID="btnPreviewDRDetails" PopupControlID="pnlDetailsPreview"
                        CancelControlID="ibtnClosepnlDetailsPreview" PopupDragHandleControlID="pnlDetailsPreviewDrag"
                        BackgroundCssClass="bgModal">
                        <Animations>
                                <OnShown>
                                    <FadeIn Duration=".2" />
                                </OnShown>
                        </Animations>
                    </asp:ModalPopupExtender>
                </div>
                <div style="float: left; height: 32px; margin-left: 5px;">
                    <asp:UpdateProgress ID="uProgressLoader" runat="server" AssociatedUpdatePanelID="upnlDeliveryReceipts"
                        DisplayAfter="100">
                        <ProgressTemplate>
                            <asp:PlaceHolder ID="plcHldrLoader" runat="server">
                                <UC:LOADER ID="loader" runat="server" />
                            </asp:PlaceHolder>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
            <div style="float: left; width: 850px; height: 415px; margin-right: 2px;">
                <div style="float: left; position: absolute; margin-left: 30px;">
                    <asp:CheckBox ID="chkSeleckAll" runat="server" AutoPostBack="True" Font-Names="Verdana"
                        Font-Size="10px" OnCheckedChanged="chkSeleckAll_CheckedChanged" ToolTip="CHECK THIS TO SELECT ALL" />
                </div>
                <asp:Panel ID="pnlDeliveryReceipt" runat="server" Height="415px" Width="850px">
                    <asp:GridView ID="gvDeliveryReceipts" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSourceDeliveryReceipt"
                        GridLines="Horizontal" CssClass="table_grid" EnablePersistedSelection="True"
                        OnSelectedIndexChanged="gvDeliveryReceipts_SelectedIndexChanged" PageSize="12"
                        OnPageIndexChanging="gvDeliveryReceipts_PageIndexChanging" OnSorting="gvDeliveryReceipts_Sorting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/panels.png" Height="17"
                                        ToolTip='<%# "CRS #:" + Eval("CRSNo") +"\n" 
                    + "CUSTOMER: " + Eval("Customer") + "\n CRS DATE: " + Eval("CRSDate") + "\n TOTAL AMOUNT: Php " + Eval("TotalAmt") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkID" runat="server" ToolTip='<%# Eval("ID") %>' />
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Font-Bold="True" ForeColor="#CC6600" HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" Visible="False"></asp:BoundField>
                            <asp:BoundField DataField="CRSID" HeaderText="CRSID" SortExpression="CRSID" Visible="False">
                            </asp:BoundField>
                            <asp:BoundField DataField="CRSNo" HeaderText="CRS NUMBER" SortExpression="CRSNo">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CRSDate" HeaderText="CRS DATE" SortExpression="CRSDate"
                                DataFormatString="{0:MMM dd, yyyy}">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Customer" HeaderText="CUSTOMER" SortExpression="Customer">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PUSNo" HeaderText="PUS NUMBER" SortExpression="PUSNo">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalAmt" HeaderText="TOTAL AMOUNT" SortExpression="TotalAmt"
                                DataFormatString="{0:###,###.00} ">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PkgNo" HeaderText="PACKAGE #" SortExpression="PkgNo">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ItemStatus" HeaderText="STATUS" SortExpression="ItemStatus">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <EmptyDataTemplate>
                            <div style=" width:700px; margin-top:15px; border: 1px solid #FFCC66; height:55px; line-height:55px;
                                            background-color: #FFFFCC; color: #C46200; text-align: center;">
                                            <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                            DATA NOT FOUND!!!
                                        </div>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerSettings PageButtonCount="20" FirstPageImageUrl="~/Resources/first.png" LastPageImageUrl="~/Resources/last.png"
                            Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" Font-Bold="True"
                            Font-Names="Verdana" Font-Size="12px" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle CssClass="asc_cell_style" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle CssClass="desc_cell_style"/>
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceDeliveryReceipt" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                        
                        SelectCommand="SELECT [ID], [CRSID], [CRSNo], [CRSDate], [Customer], [PUSNo], [TotalAmt],
                   [PkgNo], [ItemStatus] FROM [CRS] WHERE ynPosted=0 AND ynCancelled=0 order by CRSDate DESC" 
                        CacheDuration="20" EnableCaching="True">
                    </asp:SqlDataSource>
                </asp:Panel>
            </div>
            <div style="float: left;">
                <asp:Panel ID="pnlDetailsPreview" runat="server" CssClass="modal">
                    <asp:Panel ID="pnlDetailsPreviewDrag" runat="server" CssClass="modalDrag">
                        <div class="close_btn">
                            <asp:ImageButton ID="ibtnClosepnlDetailsPreview" runat="server" CssClass="btnClose"
                                ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                        </div>
                        <div class="sizeLogo">
                            <asp:Image ID="ibtnClose" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/panels.png" />
                            CRS Details.
                        </div>
                    </asp:Panel>
                    <div>
                        <table>
                            <tr>
                                <td class="lblModal">
                                    DR #:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDRNumberDetails" runat="server" Height="22px" Font-Names="Verdana"
                                        Font-Size="10px" ForeColor="#003366" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td class="lblModal">
                                    PL #:
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtPLNumber" runat="server" Height="22px" Font-Names="Verdana" Font-Size="10px"
                                        ForeColor="#003366" Width="75px" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td class="style2" rowspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td class="lblModal">
                                    Deliver Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeliveryReceiptDate" runat="server" Height="22px" Font-Names="Verdana"
                                        Font-Size="10px" ForeColor="#003366" Width="170px" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:HiddenField ID="hfRcordNumber" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="lblModal">
                                    Delivered To:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtDeliverTo" runat="server" Height="22px" Width="250px" Font-Names="Verdana"
                                        Font-Size="10px" ForeColor="#003366" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="dtlsLabel">
                                    <asp:Image ID="Image2" runat="server" Height="18px" ImageUrl="~/Resources/panels.png" />
                                    CUSTOMER RETURN SLIP DETAILS
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin: 5px 10px;">
                        <asp:Panel ID="pnlDRDetails" runat="server" ScrollBars="Auto" Height="250px">
                            <asp:GridView ID="gvDRDetails" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None" Font-Names="Verdana" Font-Size="8px" AutoGenerateColumns="False"
                                AllowSorting="True" DataSourceID="SqlDataSourceCRSDetails">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="SKU" HeaderText="SKU" SortExpression="SKU"></asp:BoundField>
                                    <asp:BoundField DataField="StyleNo" HeaderText="StyleNo" SortExpression="StyleNo">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BrandName" HeaderText="BrandName" SortExpression="BrandName">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Articles" HeaderText="Articles" SortExpression="Articles" />
                                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"
                                        DataFormatString="{0:###,###.00}" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" DataFormatString="{0:###,###.00}">
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceCRSDetails" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                
                                SelectCommand="SELECT [SKU], [StyleNo], [BrandName], [Quantity], [Articles], [UnitPrice], [Amount] FROM [CRSDtl] WHERE ([CRSID] = @CRSID)" 
                                EnableCaching="True">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hfRcordNumber" Name="CRSID" PropertyName="Value"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="lblModal">
                                        TOTAL QUANTITY:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalQuantity" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
                                    </td>
                                    <td class="lblModal">
                                        TOTAL AMOUNT:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True" ForeColor="#003366"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:Panel>
                <asp:DropShadowExtender ID="pnlDetailsPreview_DropShadowExtender" runat="server"
                    Enabled="True" Opacity="0.75" TargetControlID="pnlDetailsPreview">
                </asp:DropShadowExtender>
                <asp:RoundedCornersExtender ID="pnlDetailsPreview_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlDetailsPreview">
                </asp:RoundedCornersExtender>
            </div>
            <asp:Panel ID="pnlSelectedDRPreview" runat="server" CssClass="modal" Width="450px"
                BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px">
                <asp:Panel ID="pnlSelectedDRPreviewDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="imgBtnClosepnlSelectedDRPreview" runat="server" CssClass="btnClose"
                            ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <asp:Image ID="imgUpdateLogo" runat="server" Height="16px" ImageAlign="AbsBottom"
                            ImageUrl="~/Resources/panels.png" />
                        Preview Customer Return Slip to Confirm.
                    </div>
                </asp:Panel>
                <div style="text-align: center;">
                    <asp:Label ID="Label6" runat="server" Text="UNCHECK TO EXCLUDE" Font-Bold="False"
                        Font-Italic="True" Font-Names="Verdana" Font-Size="10px" ForeColor="#FFCC66"></asp:Label>
                </div>
                <div style="margin-left: 10px; margin-right: 10px;">
                    <asp:GridView ID="gvPreviewSelectedDR" runat="server" AutoGenerateColumns="False"
                        Font-Names="Verdana" Font-Size="10px" ForeColor="#FFFFCC">
                        <Columns>
                            <asp:BoundField DataField="CustomerReturnSlipNumber" HeaderText="CRS NUMBER" />
                            <asp:BoundField DataField="CustomerReturnSlipDate" HeaderText="CRS DATE" DataFormatString="{0:MMMM dd, yyyy}" />
                            <asp:BoundField DataField="Customer" HeaderText="CUSTOMER" />
                            <asp:BoundField DataField="PkgNo" HeaderText="PL NUMBER" HtmlEncode="False" />
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectedDRTCancelled" runat="server" Checked="true" ToolTip='<%# Eval("RecordNo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <hr />
                <div style="margin-left: 5px; margin-top: 10px;">
                    <table cellpadding="0">
                        <tr>
                            <td class="dtlsLabel">
                                DESTINATION:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDestination" runat="server" Font-Names="Verdana" Font-Size="12px"
                                    Height="20px" ForeColor="#003366" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="dtlsLabel">
                                FORWARDER:
                            </td>
                            <td>
                                <asp:DropDownList ID="dlForwarders" runat="server" Font-Names="Verdana" Font-Size="11px"
                                    Height="20px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="dtlsLabel">
                                CONFIRMATION DATE:
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmationDate" runat="server" Font-Names="Verdana" Font-Size="12px"
                                    Height="20px" Width="150px" ForeColor="#003366"></asp:TextBox>
                                <asp:CalendarExtender ID="txtConfirmationDate_CalendarExtender" runat="server" Enabled="True"
                                    Format="MMMM dd, yyyy" TargetControlID="txtConfirmationDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-left: 150px; margin-top: 5px; margin-bottom: 5px;">
                    <asp:Button ID="btnContinueDRConfirmation" runat="server" Text="CONTINUE CONFIRMATION"
                        CssClass="modalWarningButtonYes" Width="190px" Font-Names="Verdana" Font-Size="10px"
                        OnClick="btnContinueDRConfirmation_Click" />
                    <asp:RoundedCornersExtender ID="btnYesCancelSelectedDR_RoundedCornersExtender" runat="server"
                        Enabled="True" TargetControlID="btnContinueDRConfirmation" BorderColor="LightGray">
                    </asp:RoundedCornersExtender>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlPrintOptionModal" runat="server" CssClass="modal" Width="480px">
                <asp:Panel ID="pnlPrintOptionModalDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="ibtnClosepnlPrintOptionModal" runat="server" CssClass="btnClose"
                            ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <asp:Image ID="Image5" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/panels.png" />
                        CRS/PULL OUT Print Option.
                    </div>
                </asp:Panel>
                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                    <asp:TabPanel ID="tabPnlDetailedReport" runat="server" HeaderText="DETAILED REPORT/CUSTOMER">
                        <ContentTemplate>
                            <asp:Label ID="Label7" runat="server" Text="Generate Detailed Report per Outlet (w/ Forwarder and Destination)"
                                Font-Italic="True" Font-Names="Verdana" Font-Size="11px"></asp:Label><br />
                            <hr />
                            <div style="margin-bottom: 5px;">
                                <asp:Panel ID="pnlIntransitDateRange" runat="server">
                                    <asp:Label ID="Label8" runat="server" Text="DATE FROM:" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtPullOutDetailedPerOutletDateFrom" runat="server" Font-Names="Verdana"
                                        Font-Size="11px" Width="120px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1"
                                            runat="server" Enabled="True" TargetControlID="txtPullOutDetailedPerOutletDateFrom"
                                            Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                    <asp:Label ID="Label9" runat="server" Text="TO" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtPullOutDetailedPerOutletDateTo" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender2" runat="server"
                                            Enabled="True" TargetControlID="txtPullOutDetailedPerOutletDateTo" Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                </asp:Panel>
                            </div>
                            <div style="margin-top: 20px;">
                                <asp:Label ID="Label2" runat="server" Text="OUTLET:"></asp:Label><asp:DropDownList
                                    ID="dlOutletDetailed" runat="server" Font-Names="Verdana" Font-Size="11px" ForeColor="#003366"
                                    Height="20px" DataSourceID="SqlDataSourceOutleDetailed" DataTextField="CompName"
                                    DataValueField="CustNo">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceOutleDetailed" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                    SelectCommand="SELECT [CustNo], [CompName] FROM [CustInfo] ORDER BY CompName ASC">
                                </asp:SqlDataSource>
                                <asp:ListSearchExtender ID="dlOutletDetailed_ListSearchExtender" runat="server" Enabled="True"
                                    TargetControlID="dlOutletDetailed">
                                </asp:ListSearchExtender>
                            </div>
                            <div style="text-align: center; height: 20px; margin-bottom: 10px; margin-top: 5px;">
                                <asp:Button ID="btnGenerateDetailedReportPerCustomer" runat="server" Text="GENERATE REPORT"
                                    CssClass="btnPrint" Font-Names="Verdana" Font-Size="11px" OnClick="btnGenerateDetailedReportPerCustomer_Click" /><asp:RoundedCornersExtender
                                        ID="btnGenerateDetailedReportPerCustomer_RoundedCornersExtender" runat="server"
                                        BorderColor="LightGray" Enabled="True" TargetControlID="btnGenerateDetailedReportPerCustomer">
                                    </asp:RoundedCornersExtender>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="tabPnlMonthlyPullOutBrand" runat="server" HeaderText="MONTHLY SUMMARY/BRAND REPORT">
                        <ContentTemplate>
                            <asp:Label ID="Label11" runat="server" Text="Generate Monthly Pull-Out Summary per Brand"
                                Font-Italic="True" Font-Names="Verdana" Font-Size="11px"></asp:Label><br />
                            <hr />
                            <div style="margin-bottom: 5px;">
                                <asp:Panel ID="pnlConfirmedDRDateRange" runat="server">
                                    <asp:Label ID="Label4" runat="server" Text="DATE FROM:" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtConfirmedDateRangeFrom" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="txtConfirmedDateRangeFrom_CalendarExtender"
                                            runat="server" Enabled="True" TargetControlID="txtConfirmedDateRangeFrom" Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                    <asp:Label ID="Label5" runat="server" Text="TO" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtConfirmedDateRangeTo" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="txtConfirmedDateRangeTo_CalendarExtender"
                                            runat="server" Enabled="True" TargetControlID="txtConfirmedDateRangeTo" Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                </asp:Panel>
                            </div>
                            <div>
                                <asp:Label ID="Label15" runat="server" Text="CUSTOMER TYPE:"></asp:Label><asp:RadioButtonList
                                    ID="rdioListCustomerType" runat="server" Font-Names="Verdana" Font-Size="11px"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="DEPARTMENT STORE">DEPT. STORE</asp:ListItem>
                                    <asp:ListItem>BOUTIQUE</asp:ListItem>
                                    <asp:ListItem>PROVINCIAL</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="BRAND:"></asp:Label><asp:DropDownList
                                ID="dlConfirmedBrands" runat="server" Font-Names="Verdana" Font-Size="11px" ForeColor="#003366"
                                Height="20px">
                            </asp:DropDownList>
                            <asp:ListSearchExtender ID="ListSearchExtender1" runat="server" Enabled="True" TargetControlID="dlConfirmedBrands">
                            </asp:ListSearchExtender>
                            <div style="text-align: center; height: 20px; margin-bottom: 10px; margin-top: 5px;">
                                <asp:Button ID="btnPrintByBrand" runat="server" Text="GENERATE REPORT" CssClass="btnPrint"
                                    Font-Names="Verdana" Font-Size="11px" OnClick="btnPrintByBrand_Click" /><asp:RoundedCornersExtender
                                        ID="btnPrintDRConfirmedByRange_RoundedCornersExtender" runat="server" BorderColor="LightGray"
                                        Enabled="True" TargetControlID="btnPrintByBrand">
                                    </asp:RoundedCornersExtender>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="tabPnlMonthlyPullOutCustomer" runat="server" HeaderText="MONTHLY SUMMARY/CUSTOMER REPORT">
                        <ContentTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Generate Monthly Pull-Out Summary per Customer"
                                Font-Italic="True" Font-Names="Verdana" Font-Size="11px"></asp:Label><br />
                            <hr />
                            <div style="margin-bottom: 5px;">
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:Label ID="Label12" runat="server" Text="DATE FROM:" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtDateRangeFromSummaryPerCustomer" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender_txtDateRangeFromSummaryPerCustomer"
                                            runat="server" Enabled="True" TargetControlID="txtDateRangeFromSummaryPerCustomer"
                                            Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                    <asp:Label ID="Label13" runat="server" Text="TO" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtDateRangeToSummaryPerCustomer" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender_txtDateRangeToSummaryPerCustomer"
                                            runat="server" Enabled="True" TargetControlID="txtDateRangeToSummaryPerCustomer"
                                            Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                </asp:Panel>
                            </div>
                            <div style="margin-top: 20px;">
                                <asp:Label ID="Label14" runat="server" Text="OUTLET:"></asp:Label><asp:DropDownList
                                    ID="dlCustomerSummary" runat="server" Font-Names="Verdana" Font-Size="11px" ForeColor="#003366"
                                    Height="20px" DataSourceID="SqlDataSourceSummaryPerCustomer" DataTextField="CompName"
                                    DataValueField="CustNo">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceSummaryPerCustomer" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                    SelectCommand="SELECT [CustNo], [CompName] FROM [CustInfo] ORDER BY CompName ASC">
                                </asp:SqlDataSource>
                                <asp:ListSearchExtender ID="ListSearchExtender_dlCustomerSummary" runat="server"
                                    Enabled="True" TargetControlID="dlCustomerSummary">
                                </asp:ListSearchExtender>
                            </div>
                            <div style="text-align: center; height: 20px; margin-bottom: 10px; margin-top: 5px;">
                                <asp:Button ID="btnGenerateMonthlyPullOutSummaryPerCustomer" runat="server" Text="GENERATE REPORT"
                                    CssClass="btnPrint" Font-Names="Verdana" Font-Size="11px" OnClick="btnGenerateMonthlyPullOutSummaryPerCustomer_Click" /><asp:RoundedCornersExtender
                                        ID="RoundedCornersExtender1" runat="server" BorderColor="LightGray" Enabled="True"
                                        TargetControlID="btnGenerateMonthlyPullOutSummaryPerCustomer">
                                    </asp:RoundedCornersExtender>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="tabPnlMonthlyConsolidated" runat="server" HeaderText="MONTHLY CONSOLIDATED REPORT">
                        <ContentTemplate>
                            <asp:Label ID="Label16" runat="server" Text="Generate Monthly Pull-Out Consolidated Report"
                                Font-Italic="True" Font-Names="Verdana" Font-Size="11px"></asp:Label><br />
                            <hr />
                            <div style="margin-bottom: 5px;">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:Label ID="Label17" runat="server" Text="DATE FROM:" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtConsolidatedDateFrom" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender_txtConsolidatedDateFrom"
                                            runat="server" Enabled="True" TargetControlID="txtConsolidatedDateFrom" Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                    <asp:Label ID="Label18" runat="server" Text="TO" Font-Names="Verdana" Font-Size="11px"></asp:Label><asp:TextBox
                                        ID="txtConsolidatedDateTo" runat="server" Font-Names="Verdana" Font-Size="11px"
                                        Width="120px"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender_txtConsolidatedDateTo"
                                            runat="server" Enabled="True" TargetControlID="txtConsolidatedDateTo" Format="MMMM dd, yyyy">
                                        </asp:CalendarExtender>
                                </asp:Panel>
                            </div>
                            <div style="text-align: center; height: 20px; margin-bottom: 10px; margin-top: 5px;">
                                <asp:Button ID="btnPrintConsolidated" runat="server" Text="GENERATE REPORT" CssClass="btnPrint"
                                    Font-Names="Verdana" Font-Size="11px" OnClick="btnPrintConsolidated_Click" />
                                <asp:RoundedCornersExtender ID="RoundedCornersExtender_btnPrintConsolidated" runat="server"
                                    BorderColor="LightGray" Enabled="True" TargetControlID="btnPrintConsolidated">
                                </asp:RoundedCornersExtender>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </asp:Panel>
            <asp:HiddenField ID="hfIsAdvanceSearch" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
