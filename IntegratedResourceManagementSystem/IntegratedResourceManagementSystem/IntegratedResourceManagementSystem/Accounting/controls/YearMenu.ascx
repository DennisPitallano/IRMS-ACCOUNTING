<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YearMenu.ascx.cs" Inherits="IntegratedResourceManagementSystem.WareHouse.controls.YearMenu" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

 <style type="text/css">
        
       
        .Dates
        {
            background: url('../../Resources/calendar-icon.png');
            background-repeat: no-repeat;
            background-position:right;
        }
    </style>


<div>

    <asp:Label ID="Label1" runat="server" Text="YEAR :"></asp:Label>
    <asp:TextBox ID="txtYear" runat="server" CssClass = "Dates"></asp:TextBox>

    <asp:CalendarExtender ID="txtYear_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtYear">
    </asp:CalendarExtender>

</div>
