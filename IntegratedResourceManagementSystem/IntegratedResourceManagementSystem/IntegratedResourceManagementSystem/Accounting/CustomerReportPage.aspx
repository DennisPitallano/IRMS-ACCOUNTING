<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="CustomerReportPage.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.CustomerReportPage" %>

<%@ Register Src="~/Accounting/controls/DateRange.ascx" TagName="Date_Menu" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/Customers.ascx" TagName="Cutomers_Menu" TagPrefix="irms" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/CustomerReportSyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" ImageAlign="AbsMiddle" />
        <asp:Label ID="Label5" runat="server" Text="CUSTOMER REPORTS " Font-Size="Medium"
            Style="font-weight: 700"></asp:Label>
    </div>
    <hr />
    <br />
    <div class="titleList">
        <img src="../Resources/invoice.png" height="16px" align="top">
        <asp:Label ID="Label6" runat="server" Text="CATEGORY" Style="font-style: italic"></asp:Label>
    </div>
    <div class="form">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:RadioButtonList ID="rblist" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                    Font-Names="Verdana" Font-Size="12px" AutoPostBack="True" OnSelectedIndexChanged="rblist_SelectedIndexChanged"
                    Style="text-align: left" Width="507px">
                    <asp:ListItem Value="rptCustSIDtl">Customer Invoice Detailed Report
                    </asp:ListItem>
                    <asp:ListItem Value="rptCustSIIten">Customer Invoice Itinerary Report
                    </asp:ListItem>
                    <asp:ListItem Value="rptCustDRDtl">Customer Delivery Detailed Report
                    </asp:ListItem>
                    <asp:ListItem Value="rptCustDRIten">Customer Delivery Itinerary Report
                    </asp:ListItem>
                    <asp:ListItem Value="rptCustCRSDtl">Customer Return Detailed Report
                    </asp:ListItem>
                    <asp:ListItem Value="rptCustCRSIten">Customer Return Itinerary Report
                    </asp:ListItem>
                </asp:RadioButtonList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <irms:Date_Menu ID="Date_Menu" runat="server" />
            <irms:Cutomers_Menu ID="Customer_Menu" runat="server" />

              </ContentTemplate>
    </asp:UpdatePanel>
            <br />
            <div>
                <asp:Button ID="cmdView" runat="server" Text="PRINT PREVIEW" CssClass="btnPrint"
                    Height="31px" Width="138px" OnClick="cmdView_Click" />
            </div>
            <br />
            <br />
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <div style="text-align: center; background-color: #FFFFCC; border: 1px Solid #FFCC66;
                    height: 50px;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/warning.png" ImageAlign="AbsMiddle" />
                    <asp:Label ID="lblError" runat="server" Text="PLEASE SELECT REQUIRED PARAMETER!!"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="12px" ForeColor="#CC6600" />
                </div>
            </asp:Panel>
      
</asp:Content>
