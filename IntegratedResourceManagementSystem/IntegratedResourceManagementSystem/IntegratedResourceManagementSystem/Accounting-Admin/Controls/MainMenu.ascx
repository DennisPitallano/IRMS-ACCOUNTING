<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting_Admin.Controls.MainMenu" %>
<style type="text/css">
    .mnuIcon
    {
        width: 80px;
        height: 75px;
        background-image: url('../Resources/submenu.png');
        background-repeat: no-repeat;
        background-position:center;
        padding-left: 12px;
        padding-top: 3px;
    }
    .mnuIcon:hover
    {
        background-image: url('../Resources/submenuh.png');
      
        background-repeat: no-repeat;
        padding-left: 14px;
        color: Gray;
    }
    .lblMenu
    {
        text-decoration: none;
        color: #666666;
        cursor: pointer;
        text-align: center;
    }
    .lblMenu:hover
    {
        color: #376F00;
        border-bottom: 1px;
        border-bottom-style: dashed;
    }
    .colapseLabelUser
    {
        background: #eaefb5; /* Old browsers */
        background:url(../../Resources/help.png), -moz-linear-gradient(top,  #eaefb5 0%, #e1e9a0 100%); /* FF3.6+ */
        background:url(../../Resources/help.png), -webkit-gradient(linear, left top, left bottom, color-stop(0%,#eaefb5), color-stop(100%,#e1e9a0)); /* Chrome,Safari4+ */
        background:url(../../Resources/help.png), -webkit-linear-gradient(top,  #eaefb5 0%,#e1e9a0 100%); /* Chrome10+,Safari5.1+ */
        background:url(../../Resources/help.png), -o-linear-gradient(top,  #eaefb5 0%,#e1e9a0 100%); /* Opera 11.10+ */
        background:url(../../Resources/help.png), -ms-linear-gradient(top,  #eaefb5 0%,#e1e9a0 100%); /* IE10+ */
        background:url(../../Resources/help.png), linear-gradient(top,  #eaefb5 0%,#e1e9a0 100%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#eaefb5', endColorstr='#e1e9a0',GradientType=0 ); /* IE6-9 */
        -moz-border-radius:3px;
        -webkit-border-radius:3px;
        border-radius:3px;
        background-repeat:no-repeat;
        height:22px;
        font-family:Verdana;
        color: #008C2E;
        cursor: pointer;
        padding-left:24px;
        padding-top:3px;
        font-weight:bold;
    }
    .colapseLabelUser:hover
    {
        color:Gray;
         border-bottom: 1px;
        border-bottom-style: dashed;
    }
    .content
    {
        background: #feffe8; /* Old browsers */
        background: -moz-linear-gradient(top,  #feffe8 0%, #d6dbbf 100%); /* FF3.6+ */
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#feffe8), color-stop(100%,#d6dbbf)); /* Chrome,Safari4+ */
        background: -webkit-linear-gradient(top,  #feffe8 0%,#d6dbbf 100%); /* Chrome10+,Safari5.1+ */
        background: -o-linear-gradient(top,  #feffe8 0%,#d6dbbf 100%); /* Opera 11.10+ */
        background: -ms-linear-gradient(top,  #feffe8 0%,#d6dbbf 100%); /* IE10+ */
        background: linear-gradient(top,  #feffe8 0%,#d6dbbf 100%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#feffe8', endColorstr='#d6dbbf',GradientType=0 ); /* IE6-9 */
        padding:3px 3px;
         -moz-border-radius:1x;
        -webkit-border-radius:1px;
        border-radius:1px;
    }
</style>
<div style=" float:left; margin-right: 5px;">
    <div class="mnuIcon">
        <asp:ImageButton ID="imgbtnUser" runat="server" 
            ImageUrl="~/Accounting-Admin/Images/users.png" Height="42px"
            ToolTip="Manage Users Account" 
            PostBackUrl="~/Accounting-Admin/UsersPanel.aspx" />
        <br />
        <asp:LinkButton ID="lnkbtnAccountPanel" runat="server" CssClass="lblMenu" Font-Names="Verdana"
            Font-Size="10px" ToolTip="Manage Users Account" Font-Bold="True" PostBackUrl="~/Accounting-Admin/UsersPanel.aspx"
            ForeColor="#666666">USERS</asp:LinkButton>
    </div>
     <div class="mnuIcon">
        <asp:ImageButton ID="ibtnUserRoles" runat="server" 
             ImageUrl="~/Accounting-Admin/Images/user_roles_grant.png" Height="42px"
             ToolTip="Manage User Account Roles" 
              />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="lblMenu" Font-Names="Verdana"
            Font-Size="10px" ToolTip="Manage User Account Roles" Font-Bold="True" 
            ForeColor="#666666">USER ROLES</asp:LinkButton>
    </div>
</div>