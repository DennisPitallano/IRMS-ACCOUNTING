<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Oulets.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.Oulets" %>
<div>
    <asp:Panel ID ="pnlOutlets" runat ="server">
        <asp:GridView ID="gvOutlets" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            Font-Names="Verdana" Font-Size="11px" 
            ForeColor="Black" GridLines="Horizontal">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </asp:Panel>
</div>