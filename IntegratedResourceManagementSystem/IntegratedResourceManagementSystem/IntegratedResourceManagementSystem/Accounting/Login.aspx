<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Styles/login.css" rel="stylesheet" type="text/css" />
    <title>LOG IN</title>
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="frmLogIn" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div class="logInWrapper">
        <h1>
            <span>LOG-IN</span></h1>
        <div class="login_form">
            <asp:UpdatePanel ID="upnlLogIn" runat="server">
                <ContentTemplate>
                    <div class="username">
                        <div class="login_icon_username">
                            Username:</div>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="input_username"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvUsername" runat="server" ErrorMessage="Username Required"
                            ControlToValidate="txtUsername" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rvUsername_ValidatorCalloutExtender" runat="server"
                            Enabled="True" TargetControlID="rvUsername">
                        </asp:ValidatorCalloutExtender>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="username">
                <div class="login_icon_password">
                    Password:</div>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="input_password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rvPassword" runat="server" ErrorMessage="Please input Password!"
                    ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="rvPassword_ValidatorCalloutExtender" runat="server"
                    Enabled="True" TargetControlID="rvPassword">
                </asp:ValidatorCalloutExtender>
            </div>
            <div>
                <asp:Button ID="btnLogIn" runat="server" Text="LOG-IN" CssClass="btnLogIn" OnClick="btnLogIn_Click" />
            </div>
            <asp:Panel ID="pnlError" runat="server" CssClass="error_message" Visible="false">
                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
            </asp:Panel>
        </div>
    </div>
    <div>
    </div>
    </form>
</body>
</html>
