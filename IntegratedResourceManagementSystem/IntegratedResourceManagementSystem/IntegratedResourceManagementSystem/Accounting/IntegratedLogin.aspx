<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="IntegratedLogin.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.IntegratedLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
        }
        #Reset1
        {
            width: 54px;
        }
        #Password1
        {
            width: 229px;
        }
        .style4
        {
            width: 32px;
        }
        .style6
        {
            width: 82px;
        }
        .style8
        {
            width: 1px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="style6">
                </td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    User Name</td>
                <td colspan="2">
                    <asp:TextBox ID="txtUserName" runat="server" Width="224px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Password</td>
                <td colspan="2">
                    <asp:TextBox ID="txtPassword" TextMode="Password" 
                        runat="server" Width="226px"></asp:TextBox>
                    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style8"><asp:Button ID="btnLogin" runat="server" Height="25px" 
                        onclick="btnLogin_Click" Text="Login" Width="85px" />
                </td>
                <td class="style4"><asp:Button ID="btnClear" runat="server" Height="25px" 
                        onclick="btnClear_Click" Text="Clear" Width="85px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="3">
                    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>


    </asp:Panel>
</asp:Content>
