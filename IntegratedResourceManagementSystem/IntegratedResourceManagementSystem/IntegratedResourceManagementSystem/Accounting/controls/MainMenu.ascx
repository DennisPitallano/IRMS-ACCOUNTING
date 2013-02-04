<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.MainMenu" %>
<asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false"
    IncludeStyleBlock="false" Orientation="Horizontal">
    <Items>
        <asp:MenuItem NavigateUrl="~/Accounting/DashBoardPanel.aspx" Text="ACCOUNTING DASHBOARD" />
        <asp:MenuItem NavigateUrl="~/Accounting/StoreOutStandingInventoryMenu.aspx" Text="STORE OUTSTANDING INVENTORY"
            ToolTip="Manage Store OutStanding Inventory" Value="STORE OUTSTANDING INVENTORY" />
        <asp:MenuItem NavigateUrl="~/Accounting/DeliveryReceiptMenu.aspx" Text="DELIVERY RECEIPT"
            Value="DELIVERY RECEIPT"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Accounting/ReportsPanel.aspx" Text="REPORTS" ToolTip="Reports"
            Value="REPORTS"></asp:MenuItem>
<asp:MenuItem NavigateUrl="~/Accounting/ReportPanel.aspx" Text="REPORTS NEW" ToolTip="Reports"
            Value="REPORTS"></asp:MenuItem>
    </Items>
</asp:Menu>
