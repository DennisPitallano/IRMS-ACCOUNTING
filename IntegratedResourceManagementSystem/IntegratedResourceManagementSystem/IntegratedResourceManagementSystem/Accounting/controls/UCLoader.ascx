<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLoader.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.UCLoader" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
 <asp:Panel ID ="pnlProg" runat ="server"> 
                <div style="padding: 5px; background-color: #FFFFCC; border: 1px solid #FF9933;" >
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/29.gif"  ImageAlign="AbsMiddle" />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Please wait..." 
                        Font-Names="Verdana" Font-Size="12px" ForeColor="#003366"></asp:Label>
                        </div>
                </asp:Panel>
                   
                    <asp:DropShadowExtender ID="pnlProg_DropShadowExtender" runat="server" 
                        Enabled="True" TargetControlID="pnlProg" Opacity="0.75">
                    </asp:DropShadowExtender>
                   
                <asp:AlwaysVisibleControlExtender ID="pnlProg_AlwaysVisibleControlExtender" runat="server"
    Enabled="True" HorizontalSide="Center" TargetControlID="pnlProg" VerticalSide="Top"
    UseAnimation="True" VerticalOffset="125">
</asp:AlwaysVisibleControlExtender>