<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="MonthlySOIReportsPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.MonthlySOIReportsPanel" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/monthly-soi-report-panel.css" rel="stylesheet" type="text/css" />
    <%--   We will remove all other special holidays/celebrations except Birthday, Valentines, Christmas, and New Year.
BIRTHDAY, VALENTINES, XMAS at NEW YEAR na lang.--%>
</asp:Content>
<asp:Content ID="IRMSMenu" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titlePanel">
        <img src="../Resources/invoice.png" height="22px" align="top" />
        Monthly Store OutStanding Inventory Report Generator.
    </div>
    <div style="min-height: 490px;">
        <div class="titleGenerator" style="height: 20px; margin-bottom: 5px;">
            <a href="InventoryGroupingManagementPanel.aspx" title="Customize Customer Group">
                <input id="btnCustomerInventoryGroup" class="btnCustomize" type="button" value="INVENTORY GROUPING" />
            </a>
        </div>
        <asp:UpdatePanel ID="upnlReportsGenerator" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="uprogressAdjustmentMemo" runat="server" AssociatedUpdatePanelID="upnlReportsGenerator">
                    <ProgressTemplate>
                        <asp:PlaceHolder ID="plHldrLoader" runat="server">
                            <UC:LOADER ID="uprogLoader" runat="server" />
                        </asp:PlaceHolder>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="generator-container">
                    <div class="titleGenerator">
                        SUMMARY OF MONTHLY PILFERAGE REPORT
                    </div>
                    <div style="margin: 5px;">
                        <table style="width: 100%;">
                            <tr>
                                <td class="modalLabel">
                                    <label for="MainContent_chkPerLocation">
                                        Per Location:</label>
                                </td>
                                <td >
                                    <asp:CheckBox ID="chkPerLocation" class="modalText" runat="server" Height="20px" AutoPostBack="True" OnCheckedChanged="chkPerLocation_CheckedChanged" />
                                    
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="modalLabel">
                                    <label title="Enable Grouping for Per Location Report" for="MainContent_chkEnableGroup">
                                        Enable Grouping:</label>
                                </td>
                                <td>
                                <asp:CheckBox ID="chkEnableGroup" title="Enable Grouping for Per Location Report" class="modalText" Height="20px" runat="server" 
                                        AutoPostBack="True" Enabled="False" 
                                        oncheckedchanged="chkEnableGroup_CheckedChanged" />
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            <tr>
                                <td class="modalLabel">
                                    <label for="MainContent_txtDateFrom">
                                        DATE FROM:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateFrom" Height="20px" CssClass="modalText" runat="server" AutoPostBack="True"
                                        OnTextChanged="txtDateFrom_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtDateFrom">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="modalLabel">
                                    <label for="MainContent_txtDateTo">
                                        TO:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateTo" Height="20px" CssClass="modalText" runat="server" AutoPostBack="True"
                                        OnTextChanged="txtDateTo_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" Enabled="True"
                                        TargetControlID="txtDateTo">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="modalLabel">
                                    BRAND:
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLBrandsProvincial" Height="22px" CssClass="modalText" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDLBrandsProvincial_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="modalLabel">
                                    INVENTORY GROUP:
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDLInventoryGroups" Height="22px" CssClass="modalText" runat="server"
                                        AutoPostBack="True" OnSelectedIndexChanged="DDLInventoryGroups_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin: 10px; height: 30px; text-align: center;">
                        <asp:HyperLink ID="hpLinkPrintProvincial" Target="_blank" CssClass="btnPrint printBtn"
                            Height="20px" runat="server">GENERATE REPORT</asp:HyperLink>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
