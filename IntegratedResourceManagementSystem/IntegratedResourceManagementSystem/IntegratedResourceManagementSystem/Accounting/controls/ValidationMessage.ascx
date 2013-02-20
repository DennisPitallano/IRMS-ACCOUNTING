<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ValidationMessage.ascx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.controls.ValidationMessage" %>
    <asp:Panel ID="pnlError" runat="server">
                <div style="text-align: center; background-color: #FFFFCC; border: 1px Solid #FFCC66;
                    height:50px;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/warning.png" ImageAlign="AbsMiddle" />
                    <asp:Label ID="lblError" runat="server" Text="PLEASE SELECT REQUIRED PARAMETER!!"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="12px" ForeColor="#CC6600" />
                </div>
            </asp:Panel>
