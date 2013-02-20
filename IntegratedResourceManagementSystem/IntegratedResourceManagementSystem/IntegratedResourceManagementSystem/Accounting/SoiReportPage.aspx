<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="SoiReportPage.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.SoiReportPage" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/DateRange.ascx" TagName="Date_Menu" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/BrandName.ascx" TagName="Brand_Menu" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/ValidationMessage.ascx" TagName="Validation_Msg"
    TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/CustomerType.ascx" TagName="CutomerType_Menu"
    TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/Customers.ascx" TagName="Cutomers_Menu" TagPrefix="irms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/SoiReportStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <link href="../Styles/reports-form.css" rel="stylesheet" type="text/css" />
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" ImageAlign="AbsMiddle" />
        <asp:Label ID="Label5" runat="server" Text="SOI REPORTS " Font-Size="Medium" Style="font-weight: 700"></asp:Label>
    </div>
    <hr />
    <br />
    <div class="titleLists">
        <img src="../Resources/invoice.png" height="16px" align="top">
        <asp:Label ID="Label6" runat="server" Text="CATEGORY" Style="font-style: italic"></asp:Label>
    </div>
    <div class="forms">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:RadioButtonList ID="rblist1" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                    Font-Names="Verdana" Font-Size="12px" AutoPostBack="True" OnSelectedIndexChanged="rblist1_SelectedIndexChanged"
                    Style="text-align: left">
                    <asp:ListItem Value="rptStockCard">INVENTORY STOCK CARD MONTHLY 
                    </asp:ListItem>
                    <asp:ListItem Value="rptStockCardQrt">INVENTORY STOCK CARD QUARTERLY 
                    </asp:ListItem>
                    <asp:ListItem Value="rptConsoSummMonthlyInvPerBrand">SUMMARY OF MONTHLY STOCK CARD PER BRAND 
                    </asp:ListItem>
                    <asp:ListItem Value="rptSummMonthlyInvPerBrand">CONSOLIDATED OF MONTHLY STOCK CARD PER BRAND 
                    </asp:ListItem>
                    <asp:ListItem Value="rptStoreInvSumm">SUMMARY OF SOI PER BRAND               
                    </asp:ListItem>
                    <asp:ListItem Value="rptBrandInvSumm">CONSOLIDATED OF SOI PER AREA</asp:ListItem>
                </asp:RadioButtonList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div>
                <irms:Date_Menu ID="Date_Menu" runat="server" Visible="False" />
            </div>
            <div>
                <irms:Brand_Menu ID="Brand_Menu" runat="server" Visible="False" />
            </div>
            <div>
                <irms:CutomerType_Menu ID="CutomerType_Menu" runat="server" Visible="False" />
            </div>
            <div>
                <irms:Cutomers_Menu ID="Cutomers_Menu" runat="server" Visible="False" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <div>
        <%--  <asp:UpdatePanel ID="Panel" runat="server">
            <ContentTemplate>--%>
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="PRINT PREVIEW"
            CssClass="btnPrint" />
        <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
    <%--  <div style="double: left">
        <asp:UpdateProgress runat="server" ID="PageUpdateProgress" DisplayAfter="1" AssociatedUpdatePanelID="Panel">
            <ProgressTemplate>
                <img src="../Resources/29.gif" alt="" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>--%>
    <br />
    <br />
    <asp:UpdatePanel ID="ValidationPanel" runat="server">
        <ContentTemplate>
            <div>
                <irms:Validation_Msg ID="Validation_Msg" runat="server" Visible="False" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
