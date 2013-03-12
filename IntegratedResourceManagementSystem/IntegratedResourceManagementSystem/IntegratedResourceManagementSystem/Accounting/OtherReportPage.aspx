<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="OtherReportPage.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.OtherReportPage" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/YearMenu.ascx" TagName="Year_MENU" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/BrandName.ascx" TagName="Brand_MENU" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/CategoryMenu.ascx" TagName="Categories_MENU"
    TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/ValidationMessage.ascx" TagName="ValidationMessage"
    TagPrefix="irms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/reports-form.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../Styles/SoiReportStyle.css" />
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" ImageAlign="AbsMiddle" />
        <asp:Label ID="Label5" runat="server" Text="OTHER REPORTS " Font-Size="Medium" Style="font-weight: 700"></asp:Label>
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
                    Font-Names="Verdana" Font-Size="12px" AutoPostBack="True" Style="text-align: left">
                    <asp:ListItem Value="rptStockCard">PHYSICAL INVENTORY 
                    </asp:ListItem>
                </asp:RadioButtonList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <irms:Year_MENU ID="YearMenu" runat="server" />
            <div>
                <%-- <div style="float: left; top:0px;">
            <asp:CheckBox ID="CheckBox1" runat="server" />
        </div>
        <div style = "top:0px;"">
            <Irms:BrandMenu ID="Brand_Menu" runat="server" />
        </div>--%>
                <asp:Label ID="Label3" runat="server" Font-Names="Verdana" Font-Size="Small" Text="BRAND NAME :"></asp:Label>
                <asp:DropDownList ID="cboBrand" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <irms:Categories_MENU ID="CategoryMenu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:Button ID="btnPrint" runat="server" CssClass="btnPrint" Height="37px" OnClick="btnPrint_Click"
        Text="Print Preview" Width="125px" />
    <br />
    <br />
    <irms:ValidationMessage ID="ValMsg" runat="server" Visible="false" />
</asp:Content>
