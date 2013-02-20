<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="ReportPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.ReportPanel" %>

<%@ Register Src="~/Accounting/controls/ReportsMenu.ascx" TagName="rep_menu" TagPrefix="dc" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
 <irms:MAIN_MENU ID="main_menu" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

 <div  >
    <asp:PlaceHolder ID ="phlderMarkReturnAndTransferMenu" runat ="server">
        <dc:rep_menu ID ="returnAndTransferMenu" runat="server" />
    </asp:PlaceHolder>
</div>

   <%-- <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" 
                    ImageAlign="AbsMiddle" />
        <asp:Label ID="Label5" runat="server" Text="ACCOUNTING REPORTS " Font-Size="Medium"
                    Style="font-weight: 700"></asp:Label>
    </div>
--%>


</asp:Content>
