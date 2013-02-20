<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Years.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.Years" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<div>
    
     <asp:Label ID="Label1" runat="server" Text="YEAR :" style = "font-size:x-small; font-family:Verdana;"></asp:Label>
    <asp:TextBox ID="txtYear" runat="server" CssClass = "dates" ></asp:TextBox>
     
     <asp:CalendarExtender ID="txtYear_CalendarExtender" runat="server" 
         DaysModeTitleFormat="yyyy" Enabled="True" Format="yyyy" 
         TargetControlID="txtYear" TodaysDateFormat="yyyy">
     </asp:CalendarExtender>
     
</div>