<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="MemoForm.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.DebitMemoForm" %>

<%@ PreviousPageType VirtualPath="~/Accounting/Debit-CreditMemoPanel.aspx" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/soi-form.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/pcount-adjustment-form.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });			
    </script>
    <link href="../Styles/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upnlDebitMemo" runat="server">
        <ContentTemplate>
            <div style="width: 100%; min-height: 430px;">
                <div class="modalText" style="text-align: center; margin-bottom: 15px;">
                    <asp:Label ID="lblNewBookAdjustment" runat="server" Text="ADJUSTMENT PHYSICAL COUNT"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="14px"></asp:Label>
                    <asp:HiddenField ID="hfOutletNumber" runat="server" />
                    <asp:HiddenField ID="hfOutletName" runat="server" />
                </div>
                <div style="float: left; margin: 5px 10px 5px 5px;">
                    <div>
                        <asp:Label ID="lblSelectMemo" CssClass="input-form-label" runat="server" Text="SELECT MEMO TYPE"></asp:Label>
                        <asp:RadioButtonList ID="rdioMemoType" CssClass="optionMemoType" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="rdioMemoType_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True">DEBIT MEMO</asp:ListItem>
                            <asp:ListItem>CREDIT MEMO</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <asp:MultiView ID="mvMemoForms" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vDebitMemoForm" runat="server">
                            <asp:Panel ID="pnlDebitMemo" runat="server" CssClass="input-form modal">
                                <div class="modalDrag">
                                    <div class="sizeLogo">
                                        <img src="../Resources/usermode.png" height="16px" align="top" />DEBIT MEMO FORM
                                    </div>
                                </div>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            Reference No.
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtReferenceNumber" runat="server" Font-Size="10px" CssClass="modalText"
                                                Width="120px" Height="19px" AutoPostBack="True" OnTextChanged="txtReferenceNumber_TextChanged"></asp:TextBox>
                                        </td>
                                        <td class="input-form-label">
                                            DATE:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtDate" runat="server" Font-Size="10px" CssClass="modalText" Height="20px"
                                                AutoPostBack="True" OnTextChanged="txtDate_TextChanged" Width="120px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDate" Format="MMMM d, yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            PERIOD FROM:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDatePeriodFrom" runat="server" Font-Size="10px" CssClass="modalText"
                                                Height="20px" Width="120px" AutoPostBack="True" OnTextChanged="txtDatePeriodFrom_TextChanged"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDate0_CalendarExtender" runat="server" Enabled="True"
                                                Format="MMMM d, yyyy" TargetControlID="txtDatePeriodFrom">
                                            </asp:CalendarExtender>
                                            &nbsp;
                                            <asp:Label ID="Label2" runat="server" Text="TO" CssClass="input-form-label"></asp:Label>&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtDatePeriodTo" runat="server" Font-Size="10px" CssClass="modalText"
                                                Height="20px" AutoPostBack="True" OnTextChanged="txtDatePeriodTo_TextChanged"
                                                Width="120px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" Enabled="True"
                                                Format="MMMM d, yyyy" TargetControlID="txtDatePeriodTo">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            OUTLET:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDebitMemoOutlet" runat="server" Font-Size="10px" CssClass="modalText"
                                                Height="20px" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            BRAND:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDebitBrand" runat="server" Font-Size="10px" CssClass="modalText">CRISSA</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="modalLabel">
                                        </td>
                                        <td colspan="2">
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                    <div style="font-family: Verdana; color: White; margin-left: 10px;">
                                        <label class="input-form-label">
                                            PARTICULARS
                                        </label>
                                        <asp:ImageButton ID="ibtnAddParticular0" runat="server" ImageUrl="~/Resources/new.png"
                                            OnClick="ibtnAddParticular_Click" Height="16px" ImageAlign="AbsBottom" />
                                        <asp:ModalPopupExtender ID="ibtnAddParticular0_ModalPopupExtender" runat="server"
                                            DynamicServicePath="" Enabled="True" TargetControlID="ibtnAddParticular0" CancelControlID="ibtnCloseNewParticularModal"
                                            PopupControlID="pnlNewParticularModal" PopupDragHandleControlID="pnlNewParticularModalDrag"
                                            BackgroundCssClass="bgModal">
                                        </asp:ModalPopupExtender>
                                        <asp:ImageButton ID="ibtnDeleteParticular" runat="server" Height="16px" ImageAlign="AbsBottom"
                                            ImageUrl="~/Resources/reload.png" OnClick="ibtnDeleteParticular_Click" ToolTip="RESET" />
                                    </div>
                                    <hr />
                                    <div style="margin-left: 5px; margin-bottom: 10px;">
                                        <asp:Panel ID="pnlParticulars" runat="server" ScrollBars="Auto">
                                            <asp:GridView ID="gvParticulars" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                Font-Names="Verdana" Font-Size="11px" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Particular" HeaderText="PARTICULAR" />
                                                    <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" />
                                                    <asp:BoundField DataField="CurrentPrice" HeaderText="CURRENT PRICE" DataFormatString="Php{0:###,###.00}">
                                                        <ItemStyle ForeColor="Red" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CostPrice" HeaderText="COST PRICE" DataFormatString="Php{0:###,###.00}">
                                                        <ItemStyle ForeColor="Red" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" Font-Italic="True"
                                                    Font-Names="Verdana" Font-Size="11px" />
                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                            </asp:GridView>
                                            <div>
                                                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="preview_lbl">
                                                            <asp:Label ID="Label5" runat="server" Text="TOTAL:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDebitTotalQuantity" runat="server" Font-Size="11px" Font-Names="Verdana"
                                                                ForeColor="#CC3300" Width="112px" ReadOnly="True">0</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDebitTotalCurrentPrice" runat="server" Font-Size="11px" Font-Names="Verdana"
                                                                ForeColor="#CC3300" Width="112px" ReadOnly="True">Php0.00</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDebitTotalCostPrice" runat="server" Font-Size="11px" Font-Names="Verdana"
                                                                ForeColor="#CC3300" Width="112px" ReadOnly="True">Php0.00</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:Panel>
                            <%--new particular modal--%>
                            <asp:Panel ID="pnlNewParticularModal" runat="server" CssClass="modal">
                                <asp:Panel ID="pnlNewParticularModalDrag" runat="server" CssClass="modalDrag">
                                    <div class="close_btn">
                                        <asp:ImageButton ID="ibtnCloseNewParticularModal" runat="server" CssClass="btnClose"
                                            ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                                    </div>
                                    <div class="sizeLogo">
                                        <img src="../Resources/usermode.png" alt="NEW" height="16px" align="top" />
                                        NEW PARTICULAR
                                    </div>
                                </asp:Panel>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="input-form-label">
                                            TRANSACTION TYPE:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dlItems" runat="server" CssClass="modalText" ForeColor="#CC6600"
                                                AutoPostBack="True" OnSelectedIndexChanged="dlItems_SelectedIndexChanged">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem>SALES</asp:ListItem>
                                                <asp:ListItem>RETURNS</asp:ListItem>
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
                                            <asp:TextBox ID="txtParticularQuantity" runat="server" Height="22px" CssClass="modalText"
                                                Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            CURRENT PRICE:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCurrentPrice" runat="server" Height="22px" CssClass="modalText"
                                                Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            COST PRICE:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCostPrice" runat="server" Height="22px" CssClass="modalText"
                                                Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="modalLabel">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <div style="height: 26px;">
                                                <asp:Button ID="btnAddParticular" runat="server" Text="ADD" CssClass="btnNew" OnClick="btnAddParticular_Click"
                                                    Enabled="False" />
                                            </div>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="12px"
                                                ForeColor="#DC570C"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                        <asp:View ID="vCreditMemoForm" runat="server">
                            <asp:Panel ID="pnlNewSizeModal" runat="server" CssClass="input-form modal">
                                <div class="modalDrag">
                                    <div class="sizeLogo">
                                        <img src="../Resources/usermode.png" height="16px" align="top" />
                                        CREDIT MEMO FORM
                                    </div>
                                </div>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            Reference No.
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCreditReferenceNumber" runat="server" Width="120px" CssClass="modalText"
                                                Font-Size="10px" Height="19px" AutoPostBack="True" OnTextChanged="txtCreditReferenceNumber_TextChanged"></asp:TextBox>
                                        </td>
                                        <td class="input-form-label">
                                            DATE:
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtDateCredit" runat="server" CssClass="modalText" Font-Size="10px"
                                                Height="20px" AutoPostBack="True" OnTextChanged="txtDateCredit_TextChanged" Width="120px"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtDateCredit"
                                                Format="MMMM d, yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            PERIOD FROM:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtDateCreditfrom" runat="server" CssClass="modalText" Font-Size="10px"
                                                Height="20px" Width="120px" AutoPostBack="True" OnTextChanged="txtDateCreditfrom_TextChanged"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="MMMM d, yyyy"
                                                TargetControlID="txtDateCreditfrom">
                                            </asp:CalendarExtender>
                                            &nbsp;
                                            <asp:Label ID="Label1" runat="server" Text="TO" class="input-form-label"></asp:Label>&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txtDateCreditTo" runat="server" CssClass="modalText" Font-Size="10px"
                                                Height="20px" AutoPostBack="True" OnTextChanged="txtDateCreditTo_TextChanged"
                                                Width="120px"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="MMMM d, yyyy"
                                                TargetControlID="txtDateCreditTo">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            OUTLET:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtCreditMemoOutlet" runat="server" CssClass="modalText" Font-Size="10px"
                                                Height="20px" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            BRAND:
                                        </td>
                                        <td colspan="4">
                                            <asp:TextBox ID="txtCreditBrand" runat="server" CssClass="modalText" Font-Size="10px">CRISSA</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="modalLabel">
                                        </td>
                                        <td colspan="2">
                                        </td>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                    <div style="font-family: Verdana; color: White; margin-left: 10px;">
                                        <label class="input-form-label">
                                            PARTICULARS</label>
                                        <asp:ImageButton ID="ibtnNewCreditMemo" runat="server" ImageUrl="~/Resources/new.png"
                                            OnClick="ibtnAddParticular_Click" Height="16px" ImageAlign="AbsBottom" />
                                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DynamicServicePath=""
                                            Enabled="True" TargetControlID="ibtnNewCreditMemo" CancelControlID="imgBtnCloseNewCreditMemo"
                                            PopupControlID="pnlNewCreditParticularModal" PopupDragHandleControlID="pnlNewCreditParticularModalDrag"
                                            BackgroundCssClass="bgModal">
                                        </asp:ModalPopupExtender>
                                        <asp:ImageButton ID="ibtnResetCredit" runat="server" Height="16px" ImageAlign="AbsBottom"
                                            ImageUrl="~/Resources/reload.png" ToolTip="RESET" OnClick="ibtnResetCredit_Click" />
                                    </div>
                                    <hr />
                                    <div style="margin-left: 5px; margin-bottom: 10px;">
                                        <asp:Panel ID="pnlNewCreditMemo" runat="server" ScrollBars="Auto">
                                            <asp:GridView ID="gvCreditParticulars" runat="server" AutoGenerateColumns="False"
                                                CellPadding="4" Font-Names="Verdana" Font-Size="11px" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="Particular" HeaderText="PARTICULAR" />
                                                    <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" />
                                                    <asp:BoundField DataField="CurrentPrice" HeaderText="CURRENT PRICE" DataFormatString="Php{0:###,###.00}">
                                                        <ItemStyle ForeColor="Red" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CostPrice" HeaderText="COST PRICE" DataFormatString="Php{0:###,###.00}">
                                                        <ItemStyle ForeColor="Red" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" Font-Italic="True"
                                                    Font-Names="Verdana" Font-Size="11px" />
                                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                            </asp:GridView>
                                            <div>
                                                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="preview_lbl">
                                                            <asp:Label ID="Label4" runat="server" Text="TOTAL:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCreditTotalQuantity" runat="server" Font-Size="11px" Font-Names="Verdana"
                                                                ForeColor="#CC3300" Width="112px" ReadOnly="True">0</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCreditTotalCurrentPrice" runat="server" Font-Size="11px" Font-Names="Verdana"
                                                                ForeColor="#CC3300" Width="112px" ReadOnly="True">Php0.00</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCreditTotalCostPrice" runat="server" Font-Size="11px" Font-Names="Verdana"
                                                                ForeColor="#CC3300" Width="112px" ReadOnly="True">Php0.00</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server" Enabled="True"
                                TargetControlID="pnlNewCreditMemo">
                            </asp:RoundedCornersExtender>
                            <%--new credit particular modal--%>
                            <asp:Panel ID="pnlNewCreditParticularModal" runat="server" CssClass="modal">
                                <asp:Panel ID="pnlNewCreditParticularModalDrag" runat="server" CssClass="modalDrag">
                                    <div class="close_btn">
                                        <asp:ImageButton ID="imgBtnCloseNewCreditMemo" runat="server" CssClass="btnClose"
                                            ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
                                    </div>
                                    <div class="sizeLogo">
                                        <img src="../Resources/usermode.png" alt="NEW" align="top" />
                                        NEW PARTICULAR
                                    </div>
                                </asp:Panel>
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="input-form-label">
                                            TRANSACTION TYPE:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dlParticulars" runat="server" CssClass="modalText" ForeColor="#CC6600"
                                                Height="22px" AutoPostBack="True" OnSelectedIndexChanged="dlParticulars_SelectedIndexChanged">
                                                <asp:ListItem>--SELECT--</asp:ListItem>
                                                <asp:ListItem>DELIVERIES</asp:ListItem>
                                                <asp:ListItem>SHOPLIFT</asp:ListItem>
                                                <asp:ListItem>UNCOLLECTED SALES</asp:ListItem>
                                                <asp:ListItem>PILFERAGE(lacking)</asp:ListItem>
                                                <asp:ListItem>OTHERS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            QUANTITY:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCreditQuantity" runat="server" Height="22px" CssClass="modalText"
                                                Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            CURRENT PRICE:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCreditCurrentPrice" runat="server" Height="22px" CssClass="modalText"
                                                Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="input-form-label">
                                            COST PRICE:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCreditCostPrice" runat="server" Height="22px" CssClass="modalText"
                                                Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="modalLabel">
                                        </td>
                                        <td>
                                            <div style="height: 26px;">
                                                <asp:Button ID="btnAddCreditMemo" runat="server" Text="ADD" CssClass="btnNew" OnClick="btnAddCreditMemo_Click"
                                                    Enabled="False" />
                                            </div>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <asp:Label ID="lblErrorCredit" runat="server" Font-Bold="True" Font-Names="Verdana"
                                                Font-Size="12px" ForeColor="#DC570C"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:View>
                    </asp:MultiView>
                </div>
                <div style="float: left;">
                    <asp:UpdatePanel ID="upnlOutput" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlResultOutput" runat="server">
                                <div class="form-output">
                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="preview_lbl_t">
                                                Inventory Date:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtInventoryDate" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#003366" Height="20px"></asp:TextBox>
                                            </td>
                                            <td class="preview_lbl_t">
                                                Cut-Off:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCutOffDate" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#003366" Height="20px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td class="preview_lbl_">
                                                QUANTITY
                                            </td>
                                            <td class="preview_lbl_">
                                                CURRENT PRICE
                                            </td>
                                            <td class="preview_lbl_">
                                                COST PRICE
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label-h">
                                                <asp:Label ID="lblPCountModalHandler" style="cursor:pointer;" runat="server" Text=" Actual Physical Count"></asp:Label>
                                                <asp:ModalPopupExtender ID="lblPCountModalHandler_ModalPopupExtender" 
                                                    runat="server" DynamicServicePath="" Enabled="True" 
                                                    PopupControlID="pnlInventoryModal" 
                                                    PopupDragHandleControlID="pnlInventoryModalDrag" 
                                                    TargetControlID="lblPCountModalHandler" 
                                                    CancelControlID="btncancelPcountSelect">
                                                </asp:ModalPopupExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtActualPhysicalCountQuantity" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" AutoPostBack="True"
                                                    OnTextChanged="txtActualPhysicalCountQuantity_TextChanged">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtActualPhysicalCountCurrentPrice" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" AutoPostBack="True"
                                                    OnTextChanged="txtActualPhysicalCountCurrentPrice_TextChanged">0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtActualPhysicalPriceCostPrice" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" AutoPostBack="True"
                                                    OnTextChanged="txtActualPhysicalPriceCostPrice_TextChanged">0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label-h">
                                                Add:
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Sales
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalSalesQuantity" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalSalesCurrentPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalSalesCostPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Returns
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalReturnsQuantity" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalReturnsCurrentPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalReturnsCostPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Others
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalOthersQuantity" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalOthersCurrentPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalOthersCostPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                <hr />
                                                TOTAL:
                                                <hr />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDebitQuantity" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDebitCurrentPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDebitCostPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label-h">
                                                Less:
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Deliveries
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDeliveriesQuantitySummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDeliveriesCurrentPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalDeliveriesCostPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="22px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                ShopLift
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalShopLiftQuantitySummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalShopLiftCurrentPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalShopLiftCostPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="22px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Uncollected Sales
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalUncollectedSalesQuantity" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalUncollectedSalesCurrentPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalUncollectedSalesCostPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="22px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Pilferage(lacking)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalPilferageQuantitySummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalPilferageCurrentPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalPilferageCostPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="22px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Others
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalOthersCreditSummary" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalOthersCreditCurrentPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalOthersCreditCostPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="22px" ReadOnly="True">Php0.00</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                <hr />
                                                TOTAL
                                                <hr />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalCreditQuantity" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalCreditCurrentPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="20px">0</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalCreditCostPrice" runat="server" Font-Bold="True" CssClass="modalText"
                                                    Font-Size="10px" ForeColor="#CC3300" Height="22px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="output-label">
                                                Adjusted P. Count
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAdjustmentPCountQuantitySummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAdjustmentPCountCurrentPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAdjustmentPCountCostPriceSummary" runat="server" Font-Bold="True"
                                                    CssClass="modalText" Font-Size="10px" ForeColor="#CC3300" Height="20px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                            </td>
                                            <td class="style1">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="form-output" style="text-align: center; padding-bottom: 5px; padding-top: 5px;
                margin-top: 10px;">
                <asp:Button ID="btnSaveMemo" runat="server" Text="SAVE" CssClass="btnSave" OnClick="btnSaveMemo_Click" />
                <asp:ModalPopupExtender ID="btnSaveMemo_ModalPopupExtender" runat="server" DynamicServicePath=""
                    Enabled="True" PopupControlID="pnlConfirmSaving" PopupDragHandleControlID="pnlConfirmSavingDrag"
                    TargetControlID="btnSaveMemo" CancelControlID="btnNo" BackgroundCssClass="bgModal">
                </asp:ModalPopupExtender>
                <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Text="CANCEL" OnClick="btnCancel_Click" />
            </div>
            <%-- confiramtion modal--%>
            <asp:Panel ID="pnlConfirmSaving" runat="server" CssClass="modal">
                <asp:Panel ID="pnlConfirmSavingDrag" runat="server" CssClass="modalDrag">
                    <div class="sizeLogo">
                        <img src="../Resources/usermode.png" align="top" height="16px" alt="" />
                        CONFIRMATION
                    </div>
                </asp:Panel>
                <div class="input-form-label" style="font-family: Verdana; text-align: center; font-size: 12px;
                    margin: 5px 5px;">
                    <img src="../Resources/warning.png" align="top" alt="" />
                    Are you sure you want to save this data?
                </div>
                <div style="margin: 10px 0px 5px 0px; text-align: center;">
                    <asp:Button ID="btnOKSaveMEMO" runat="server" Text="YES" CssClass="modalWarningButtonYes"
                        OnClick="btnOKSaveMEMO_Click" />
                    <asp:Button ID="btnNo" runat="server" Text="NO" CssClass="modalWarningButtonNo" />
                </div>
            </asp:Panel>
            <asp:Label ID="lblSaved" runat="server" Text=""></asp:Label>
            <asp:ModalPopupExtender ID="lblSaved_ModalPopupExtender" runat="server" DynamicServicePath=""
                Enabled="True" PopupControlID="pnlSaved" PopupDragHandleControlID="pnlSavedDrag"
                TargetControlID="lblSaved" BackgroundCssClass="bgModal">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlSaved" runat="server" CssClass="modal">
                <asp:Panel ID="pnlSavedDrag" runat="server" CssClass="modalDrag">
                    <div class="sizeLogo">
                        <img src="../Resources/product.png" alt="FORM" height="16px" align="top" />
                        Physical Count Adjustment
                    </div>
                </asp:Panel>
                <div style="text-align: center; padding: 5px 30px;">
                    <asp:Label ID="Label3" CssClass="modalLabel" runat="server" Text="Item Successfully Saved!"
                        Font-Names="Verdana" Font-Size="12px"></asp:Label>
                </div>
                <div style="text-align: center; margin: 5px 0px;">
                    <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="modalWarningButtonYes"
                        OnClick="btnOk_Click" />
                </div>
            </asp:Panel>
            <asp:Panel CssClass="modal" ID="pnlInventoryModal" runat="server">
                <asp:Panel ID="pnlInventoryModalDrag" CssClass="modalDrag" runat="server">
                <div class="sizeLogo">
                    LIST OF INVENTORIES
                </div>
                </asp:Panel>
                <div style="margin:5px;">
                    <asp:GridView ID="gvInventories" CssClass="table_grid" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" DataSourceID="SqlDataSourceInventories" ForeColor="#333333" 
                        GridLines="None" 
                        onselectedindexchanged="gvInventories_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="actualQTY" HeaderText="QUANTITY" 
                                SortExpression="actualQTY" />
                            <asp:BoundField DataField="actualAMT" HeaderText="CURRENT PRICE" 
                                SortExpression="actualAMT" />
                            <asp:BoundField DataField="TotalCost" HeaderText="COST PRICE" 
                                SortExpression="TotalCost" />
                            <asp:BoundField DataField="asofDate" DataFormatString="{0:MMMM dd, yyyy}" 
                                HeaderText="AS OF " SortExpression="asofDate" />
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
                    <asp:SqlDataSource ID="SqlDataSourceInventories" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>" 
                        SelectCommand="SELECT [actualQTY], [actualAMT], [TotalCost], [asofDate] FROM [bridge_PCount] WHERE (([asofDate] &gt; @asofDate) AND ([CustNo] = @CustNo))">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtDatePeriodFrom" Name="asofDate" 
                                PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="hfOutletNumber" Name="CustNo" 
                                PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div style="text-align:center; margin:5px;">
                    <asp:Button ID="btnSelectInventory" runat="server" 
                        CssClass="modalWarningButtonYes" Width="120px" Text="USE SELECTED" 
                        onclick="btnSelectInventory_Click" />
                    <asp:Button ID="btncancelPcountSelect" runat="server" CssClass="modalWarningButtonNo" Text="CANCEL" Width="80px" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
