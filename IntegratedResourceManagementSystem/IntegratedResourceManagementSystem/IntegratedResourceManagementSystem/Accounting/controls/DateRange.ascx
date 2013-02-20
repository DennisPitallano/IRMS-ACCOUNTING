<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateRange.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.DateRange" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<fieldset>
    <legend style = "font-size:smaller; font-family:Verdana;"> DATE RANGE </legend>
    <asp:Label ID="Label1" runat="server" Text="FROM :" style = "font-size:x-small; font-family:Verdana;"></asp:Label>
    <asp:TextBox ID="txtDateFrom" runat="server" CssClass = "dates" ></asp:TextBox>
    <asp:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtDateFrom">
    </asp:CalendarExtender>
    &nbsp &nbsp
    <asp:Label ID="Label2" runat="server" Text="TO :" style = "font-size:x-small; font-family:Verdana;"></asp:Label>
    <asp:TextBox ID="txtDateTo" runat="server" CssClass = "dates"></asp:TextBox>
    <asp:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtDateTo">
    </asp:CalendarExtender>
</fieldset>
