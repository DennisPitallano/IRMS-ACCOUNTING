<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.UserAccount" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<link href="../Styles/account.css" rel="stylesheet" type="text/css" />
<link href="../Styles/modal-controls.css" rel="stylesheet" type="text/css" />
<div class="account-wrapper">
 <div class="account-details">
     <asp:HiddenField ID="HiddenField1" runat="server" />
     <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" 
         DynamicServicePath="" Enabled="True" TargetControlID="HiddenField1" 
         PopupControlID="pnlModalMessage" PopupDragHandleControlID="pnlModalMessageDrag">
     </asp:ModalPopupExtender>
        <asp:Panel ID="pnlModalMessage" CssClass="modal" runat="server" >
            <asp:Panel ID="pnlModalMessageDrag" CssClass="modalDrag"  runat="server" >
                <div class="sizeLogo">
                    <img src="../Resources/mail_read.png" align="top" /> MESSAGE BOX
                </div>
            </asp:Panel>
            <div style=" min-width:100px; margin:5px; border-radius:5px; color: #6B5F14; text-shadow: 1px 1px 0px #E0E0E0; border:3px Solid #c6bc83; background-color:#ffffff;">
            <asp:Panel ID="pnlMsgContent" runat="server" >
                
            </asp:Panel>
            </div>
            <div style="margin:5px;">
            <asp:Button CssClass="modalWarningButtonYes" ID="btnOMessageOK" runat="server" 
                    Text="OK" onclick="btnOMessageOK_Click" />
            </div>
       </asp:Panel>
    <asp:Panel ID="msgPanel" runat ="server" >
        <asp:Button CssClass="btnNewMessage" ID="btnNewMessage" Visible="false"  runat="server" Text="NEW MESSAGE" 
            onclick="btnNewMessage_Click" />
    </asp:Panel>
    <asp:Panel ID="msgNotification" Visible="false"  runat="server" >
        <asp:HyperLink ID="hpLinkNewMessage" CssClass="btnNewMessage" Height="18px" runat="server" >[hpLinkNewMessage]</asp:HyperLink>
    </asp:Panel>
     <asp:Label ID="lblName" CssClass="account-label" runat="server" Text="ADMINISTRATOR">
     </asp:Label>
     <asp:HoverMenuExtender ID="lblName_HoverMenuExtender" runat="server" 
         DynamicServicePath="" Enabled="True" TargetControlID="lblName" 
         PopupControlID="pnlMenu" PopupPosition="Left"></asp:HoverMenuExtender>
    </div>
    <div class="avatar">
        <asp:Image ID="imgAvatar" runat="server" Height="32px" Width="32px" ImageUrl="~/Marketing/Marketing-Admin/user-images/maleicon.png" />
    </div>
    <asp:Panel ID="pnlMenu" CssClass="account-menu-hover" runat="server" >
    <div class="menu-link-account">
        <a title="Go to My Account Settings" style="height:18px; text-decoration:none; color: #6B5F14;"  href="MyAccount.aspx">MY ACCOUNT</a>
    </div>
     <div class="menu-link"> 
     <a title="Logout to System" style="text-decoration:none; height:18px; color: #6B5F14;" href="Login.aspx?action=logout">LOG OUT</a>
     </div>
     <asp:Panel CssClass ="menu-link-admin" ID="pnlAdmin" runat="server">
         <asp:HyperLink ID="hpLinkAdmin" Height="18px" runat="server" 
             ForeColor="#6B5F14" NavigateUrl="~/Marketing/Marketing-Admin/">ADMIN-PANEL</asp:HyperLink>
     <%--  <a title="Go to Admin Panel" style="height:18px; text-decoration:none; color: #6B5F14;"  href="../Marketing/Marketing-Admin/">ADMIN-PANEL</a>--%>
    </asp:Panel>
    </asp:Panel>
</div>