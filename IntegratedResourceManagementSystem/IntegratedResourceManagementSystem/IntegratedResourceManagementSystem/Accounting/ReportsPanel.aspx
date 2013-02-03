<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="ReportsPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.ReportsPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .error
        {
            background: url('../../Resources/warning.png');
            background-repeat: no-repeat;
            padding-left: 30px;
            border: 1px Solid #FFCC66;
            background-color: #FFFFCC;
            text-align: center;
            color: Red;
        }
    </style>
    <link href="../Styles/toolbar-controls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/modal-controls.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upnlReporst" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HF_BRAND" runat="server" />
            <br />
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" ImageAlign="AbsMiddle" />
            <asp:Label ID="Label5" runat="server" Text="Accounting Reports:" Font-Size="Medium"></asp:Label>
            <div style="width: 600px; margin-bottom: 20px;">
                <hr />
            </div>
            <asp:Label ID="Label4" runat="server" Text="Customer ReportsType:"></asp:Label>
            &nbsp;
            <asp:Label ID="Label9" runat="server" Text="(Select Date Range and Customer)" ForeColor="#33CC33"></asp:Label>
            <asp:RadioButtonList ID="rblist" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                BackColor="#FFFFCC" BorderColor="#FFCC66" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="12px" ForeColor="#CC6600" AutoPostBack="True"
                OnSelectedIndexChanged="rblist_SelectedIndexChanged">
                <asp:ListItem Value="rptCustSIDtl">
                  Customer Invoice Detailed Report
                </asp:ListItem>
                <asp:ListItem Value="rptCustSIIten">
                  Customer Invoice Itinerary Report
                </asp:ListItem>
                <asp:ListItem Value="rptCustDRDtl">
                  Customer Delivery Detailed Report
                </asp:ListItem>
                <asp:ListItem Value="rptCustDRIten">
                  Customer Delivery Itinerary Report
                </asp:ListItem>
                <asp:ListItem Value="rptCustCRSDtl">
                  Customer Return Detailed Report
                </asp:ListItem>
                <asp:ListItem Value="rptCustCRSIten">
                  Customer Return Itinerary Report
                </asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="SOI Reports:"></asp:Label>
            <%--&nbsp;
              <asp:Label ID="Label8" runat="server" Text="(Select Date Range, Customer)" 
                         ForeColor="#33CC33"></asp:Label>--%>
            <br />
            <asp:RadioButtonList ID="rblist2" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                BackColor="#FFFFCC" BorderColor="#FFCC66" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="12px" ForeColor="#CC6600" AutoPostBack="True"
                OnSelectedIndexChanged="rblist2_SelectedIndexChanged">
                <asp:ListItem Value="rptStockCard">
                  Inventory Stock Card Monthly&nbsp<font color = "green">(Select Date Range, Customer)</font>
                </asp:ListItem>
                <asp:ListItem Value="rptStockCardQrt">
                  Inventory Stock Card Quarterly&nbsp<font color = "green">(Select Date Range, Customer)</font>
                </asp:ListItem>
                <asp:ListItem Value="rptStoreInvSumm">
                  Summary of Store Inventory Report&nbsp<font color = "green">(Select Date Range, Customer Type, Brand)</font>
                </asp:ListItem>
                <asp:ListItem Value="rptBrandInvSumm">
                  Summary of Brand Inventory Report&nbsp<font color = "green">(Select Date Range)</font>
                </asp:ListItem>
                <asp:ListItem Value="rptSummMonthlyInvPerBrand">
                  Summary of Monthly Inventory per Brand Report&nbsp<font color = "green">(Select Date Range, Customer Type, Brand)</font>
                </asp:ListItem>
                <asp:ListItem Value="rptConsoSummMonthlyInvPerBrand">
                  Consolidated Summary of Monthly Inventory per Brand Report&nbsp<font color = "green">(Select Date Range)</font>
                </asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            &nbsp;
            <asp:Label ID="Label7" CssClass="modalLabel" runat="server" Text="PERIOD FROM:"></asp:Label>
            &nbsp; &nbsp;
            <asp:TextBox ID="DateFrom" runat="server" Font-Names="Verdana" Font-Size="12px" ForeColor="#336699"
                Height="22px"></asp:TextBox>
            <asp:CalendarExtender ID="DateFrom_CalendarExtender" runat="server" Enabled="True"
                TargetControlID="DateFrom" Format="MMMM dd, yyyy">
            </asp:CalendarExtender>
            &nbsp;
            <asp:Label ID="Label2" runat="server" Text="TO"></asp:Label>
            &nbsp;
            <asp:TextBox ID="DateTo" runat="server" Font-Names="Verdana" Font-Size="12px" ForeColor="#336699"
                Height="22px"></asp:TextBox>
            <asp:CalendarExtender ID="DateTo_CalendarExtender" runat="server" Enabled="True"
                TargetControlID="DateTo" Format="MMMM dd, yyyy">
            </asp:CalendarExtender>
            <br />
            <br />
            &nbsp;
            <asp:Label ID="Label10" CssClass="modalLabel" runat="server" Text="CUSTOMER TYPE:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="dlCustomerType" runat="server">
                <asp:ListItem>---------</asp:ListItem>
                <asp:ListItem Value="PROVINCIAL">PROVINCIAL</asp:ListItem>
                <asp:ListItem Value="DEPT. STORE">DEPT. STORE</asp:ListItem>
                <asp:ListItem Value="BOUTIQUE">BOUTIQUE</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label11" runat="server" CssClass="modalLabel" Text="BRAND NAME:"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="dlBrandName" runat="server">
            </asp:DropDownList>
            <asp:ListSearchExtender ID="dlBrandName_ListSearchExtender" runat="server" Enabled="True"
                TargetControlID="dlBrandName" PromptPosition="Bottom">
            </asp:ListSearchExtender>
            <br />
            <div style="margin-top: 20px; height: 50px; float: left;">
                &nbsp;
                <asp:Label ID="Label1" CssClass="modalLabel" runat="server" Text="Customer:"></asp:Label>
                <asp:TextBox ID="txtCompName" runat="server" Font-Names="Verdana" Font-Size="12px"
                    ForeColor="#336699" Height="22px" Width="300px"></asp:TextBox>
                <asp:TextBox ID="txtCustno" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnBrowse" runat="server" Text="..." />
                <asp:ModalPopupExtender ID="btnBrowse_ModalPopupExtender" runat="server" BackgroundCssClass="bgModal"
                    CancelControlID="imgBtnCloseOutlets" DynamicServicePath="" Enabled="True" PopupControlID="pnlOutlets"
                    PopupDragHandleControlID="pnlOutletsDrag" TargetControlID="btnBrowse">
                </asp:ModalPopupExtender>
            </div>
            <div style="margin-left: 5px; margin-top: 20px; height: 110px; float: left; text-align: center;">
                <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print Preview"
                    CssClass="btnPrint" Target="_blank" />
            </div>
            <div style="text-align: center; margin-top: 90px;">
                <%--  <asp:RequiredFieldValidator ID="rdValidatorReportType" 
                                runat="server" ControlToValidate="rblist" 
          ErrorMessage="WARNING: PLEASE SELECT REPORT TYPE!" CssClass ="error" 
          Height="25px"></asp:RequiredFieldValidator>--%>
            </div>
            <asp:Panel ID="pnlOutlets" runat="server" CssClass="modal">
                <asp:Panel ID="pnlOutletsDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="imgBtnCloseOutlets" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                            ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <asp:Image ID="Image3" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/usermode.png" />
                        OUTLETS LIST
                    </div>
                </asp:Panel>
                <div style="margin-left: 5px; height:30px;">
                      <div class="SearchTextContainer">
                       SEARCH:  <asp:TextBox ID="txtSearchOutlet" runat="server" CssClass="modalText" Height="16px"></asp:TextBox>
                        <asp:ImageButton ID="imgBtnSearchOutlet" runat="server"  ImageUrl="~/Resources/search.png"
                            ImageAlign="AbsMiddle" OnClick="imgBtnSearchOutlet_Click" ToolTip="SEARCH" />
                    </div>
                </div>
                <asp:Panel ID="outlets_container" runat="server" ScrollBars="Auto">
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
                            <asp:BoundField DataField="CustNo" HeaderText="CUSTOMER#" SortExpression="CompName"
                                HtmlEncode="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompName" HeaderText="COMPANY NAME" SortExpression="CompName"
                                HtmlEncode="False">
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
                        SelectCommand="SELECT [CustNo], [CompName],[brand] FROM [CustInfo]" EnableCaching="true">
                    </asp:SqlDataSource>
                </asp:Panel>
                <div style="text-align: center; margin: 3px 0px 3px 0px;">
                    <asp:Button ID="btnSelectOutlet" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        OnClick="btnSelectOutlet_Click" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <div style="text-align: center; background-color: #FFFFCC; border: 1px Solid #FFCC66;
                    height:50px;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/warning.png" ImageAlign="AbsMiddle" />
                    <asp:Label ID="lblError" runat="server" Text="PLEASE SELECT REQUIRED PARAMETER!!"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="12px" ForeColor="#CC6600" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
