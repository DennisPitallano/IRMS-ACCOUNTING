<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.MyAcoount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/my-user-account.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #MainContent_gvUserLogs tr td
        {
            padding-left: 5px;
            padding-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="min-height: 450px;">
        <%--  <asp:UpdatePanel ID="upnlInfo" runat="server">
            <ContentTemplate>--%>
        <asp:HiddenField ID="hfUserId" runat="server" />
        <div style="float: left; margin-right: 20px;">
            <div class="info-container">
                <div style="height: 14px; font-size: 10px; color: #4E5913; text-shadow: 1px 1px 0px #A0B051;
                    text-align: left;" class="modalDrag">
                    BASIC INFORMATION
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="info-avatar">
                                <asp:Image ID="imgAvatar" runat="server" />
                            </div>
                        </td>
                        <td>
                            <div style="text-align: right; height: 27px;">
                                <asp:Button ID="btnDoneEditing" CssClass="btnDone" Visible="false" runat="server"
                                    Text="Done Editing" OnClick="btnDoneEditing_Click" />
                                <asp:Button ID="btnCancel" CssClass="btnDone" Visible="false" runat="server" Text="Cancel"
                                    OnClick="btnCancel_Click" />
                                <asp:Button ID="btnUpdate" CssClass="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            </div>
                            <div style="margin-bottom: 5px;">
                                <table style="width: 100%; height: 26px;">
                                    <tr>
                                        <td>
                                            <label for="MainContent_txtFullName" class="modalLabel">
                                                NAME
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="modalText" ReadOnly="true" Height="20px" Width="250px" ID="txtFullName"
                                                runat="server">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel ID="pnlLogInfo" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="modalLabel">
                                            <label for="MainContent_txtUserName">
                                                USER NAME:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true" CssClass="modalText"
                                                Height="20px" Width="150px">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="modalLabel">
                                            <label for="MainContent_txtPassWord">
                                                PASSWORD:
                                            </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassWord" runat="server" ReadOnly="true" CssClass="modalText"
                                                Height="20px" Width="150px">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:HoverMenuExtender ID="pnlLogInfo_HoverMenuExtender" runat="server" DynamicServicePath=""
                                Enabled="True" TargetControlID="pnlLogInfo" OffsetX="-40" PopupControlID="pnlUpdatePasswordMenu"
                                PopupPosition="Right">
                            </asp:HoverMenuExtender>
                            <asp:Panel ID="pnlUpdatePasswordMenu" runat="server">
                                <asp:Button CssClass="btnReset" ID="btnResetPassword" runat="server" Text="Reset Password" />
                                <asp:ModalPopupExtender ID="btnResetPassword_ModalPopupExtender" runat="server" BackgroundCssClass="bgModal"
                                    CancelControlID="btnCancelResetPassword" DynamicServicePath="" Enabled="True"
                                    PopupControlID="pnlUpdatePasswordModal" PopupDragHandleControlID="pnlUpdatePasswordModalDrag"
                                    TargetControlID="btnResetPassword">
                                </asp:ModalPopupExtender>
                            </asp:Panel>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlUploadAvatar" Visible="false" runat="server">
                                <asp:FileUpload ID="fileUploadAvatar" CssClass="btnBrowse" runat="server" />
                                <br />
                                <div style="margin-top: 2px; text-align: center;">
                                    <asp:Button ID="btnUpload" CssClass="btnUpload" runat="server" Text="upload" OnClick="btnUpload_Click" />
                                    <br />
                                    <asp:Label ID="label" runat="server" Text=""></asp:Label>
                                    <asp:HiddenField ID="hfAvatarFileName" runat="server" />
                                </div>
                            </asp:Panel>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="modalLabel">
                            ACCOUNT LEVEL:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAccountLevel" ReadOnly="true" CssClass="modalText" Height="20px"
                                Width="200px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="modalLabel">
                            DEPARTMENT:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDepartment" ReadOnly="true" CssClass="modalText" Height="20px"
                                Width="200px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="info-container">
                <div style="height: 14px; font-size: 10px; color: #4E5913; text-shadow: 1px 1px 0px #A0B051;
                    text-align: left;" class="modalDrag">
                    CONTACT INFORMATION
                </div>
                <table style="width: 100%;">
                    <tr>
                        <td class="modalLabel">
                            EMAIL-ADDRESS:
                        </td>
                        <td>
                            <asp:TextBox CssClass="modalText" ReadOnly="true" Height="20px" Width="250px" ID="txtEmailAddress"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="modalLabel">
                            CONTACT #:
                        </td>
                        <td>
                            <asp:TextBox CssClass="modalText" ReadOnly="true" Height="20px" Width="200px" ID="txtContactNumber"
                                runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="pnlUpdatePasswordModal" CssClass="modal" runat="server">
                <asp:Panel ID="pnlUpdatePasswordModalDrag" CssClass="modalDrag" runat="server">
                    <div class="sizeLogo">
                        <img alt="" src="../Resources/account-icon.png" height="16px" align="top" />
                        Reset Password
                    </div>
                </asp:Panel>
                <div style="margin: 5px;">
                    <table>
                        <tr>
                            <td class="modalLabel">
                                CURRENT PASSWORD:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCurrentPassword" CssClass="modalText" Height="20px" TextMode="Password"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="modalLabel">
                                NEW PASSWORD:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" Height="20px" TextMode="Password" CssClass="modalText"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="modalLabel">
                                RETYPE-NEW PASSWORD:
                            </td>
                            <td>
                                <asp:TextBox ID="txtRetypePassword" CssClass="modalText" Height="20px" TextMode="Password"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin: 5px; text-align: center;">
                    <asp:Button CssClass="btnSave" ID="btnResetPasswordSave" runat="server" Text="UPDATE PASSWORD"
                        Width="147px" OnClick="btnResetPasswordSave_Click" />
                    <asp:Button ID="btnCancelResetPassword" CssClass="btnCancel" runat="server" Text="CANCEL" />
                </div>
            </asp:Panel>
        </div>
        <div style="float: left;">
            <div class="info-container">
                <div style="height: 14px; font-size: 10px; color: #4E5913; text-shadow: 1px 1px 0px #A0B051;
                    text-align: left;" class="modalDrag">
                    MY LOGS 
                    <div style="float:right;">
                        <asp:Button ID="btnReload" runat="server" Text="REFRESH LOG LIST" CssClass="btnReload" 
                            onclick="btnReload_Click" />
                    </div>
                </div>
                <div style="margin: 5px;">
                    <asp:GridView ID="gvUserLogs" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSourceUserLogs"
                        PageSize="20">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                                SortExpression="ID" />
                            <asp:BoundField DataField="DTStamp" HeaderText="DATE RECORDED" SortExpression="DTStamp"
                                DataFormatString="{0:MMMM dd, yyyy hh:mm:s}">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ActionTaken" HeaderText="ACTION TAKEN" SortExpression="ActionTaken" />
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSourceUserLogs" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                    SelectCommand="SELECT ID, DTStamp, ActionTaken FROM AuditTrail WHERE (UserName = @UserName)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtUserName" Name="UserName" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
        <asp:HiddenField ID="hfResetPasswordMessageHandler" runat="server" />
        <asp:ModalPopupExtender ID="hfResetPasswordMessageHandler_ModalPopupExtender" runat="server"
            CancelControlID="btnOk" DynamicServicePath="" Enabled="True" PopupControlID="pnlPasswordResetSucessfulModal"
            PopupDragHandleControlID="pnlPasswordResetSucessfulModalDrag" TargetControlID="hfResetPasswordMessageHandler">
            <Animations>
                <OnShown>
                    <FadeIn Duration=".2" />
                </OnShown>
            </Animations>
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlPasswordResetSucessfulModal" Width="320px" CssClass="modal" runat="server">
            <asp:Panel CssClass="modalDrag" ID="pnlPasswordResetSucessfulModalDrag" runat="server">
                <div class="sizeLogo">
                    <img alt="" src="../Resources/account-icon.png" height="16px" align="top" />
                    Password Reset Successful!!!
                </div>
            </asp:Panel>
            <img src="../Resources/info.png" alt="" align="left" />
            <div class="modalLabel" style="padding: 5px; text-align: center; font-size: 12px;">
                Password successfully reset.
                <br />
                Use your new password next time you Login.
            </div>
            <div style="text-align: center; margin: 5px;">
                <asp:Button ID="btnOk" CssClass="modalWarningButtonYes" runat="server" Text="OK" />
            </div>
        </asp:Panel>
        <%--      </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
</asp:Content>