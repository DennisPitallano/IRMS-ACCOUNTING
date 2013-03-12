<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="CustomerGroupReport.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.CustomerGroupReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/report.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .waterMark
        {
            background: url('../Resources/calendar-icon.png');
            background-repeat: no-repeat;
            background-position: right;
        }
        .error
        {
            background: url('../Resources/warning.png');
            background-repeat: no-repeat;
            padding-left: 30px;
            border: 1px Solid #FFCC66;
            background-color: #FFFFCC;
            text-align: center;
            color: Red;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/accounting.png" 
            ImageAlign="AbsMiddle" />
        <asp:Label ID="Label1" runat="server" Text="OUTLET GROUP REPORTS" Font-Size="Medium"></asp:Label>
        <hr />
    </div>
    <br />
    <div class="tlsL">
        <asp:Label ID="Label9" runat="server" Text="REPORT TYPE"></asp:Label>
    </div>
    <div class="tlsF">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:RadioButtonList ID="LstRadio" runat="server" AutoPostBack="True" Width="527px"
                    OnSelectedIndexChanged="LstRadio_SelectedIndexChanged">
                    <asp:ListItem Value="cgrpc">OUTLET GROUP REPORT PER CUSTOMER  </asp:ListItem>
                    <asp:ListItem Value="cgrpb">OUTLET GROUP REPORT PER BRAND   </asp:ListItem>
                    <asp:ListItem Value="cgor">OUTLET GROUP OVERALL REPORT  </asp:ListItem>
                </asp:RadioButtonList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <fieldset>
            <legend>
                <asp:Label ID="Label3" runat="server" Text="DATE RANGE" Font-Bold="True" Font-Names="Verdana"
                    Font-Size="12px" ForeColor="#333333"></asp:Label>
            </legend>
            <asp:Label ID="Label11" runat="server" Text="FROM :" Font-Bold="True" Font-Names="Verdana"
                Font-Size="12px" ForeColor="#333333"></asp:Label>
            <asp:TextBox ID="txtDateF" runat="server" CssClass="waterMark"></asp:TextBox>
            <asp:CalendarExtender ID="txtDateF_CalendarExtender" runat="server" Enabled="True"
                TargetControlID="txtDateF" Format="MMMM dd, yyyy">
            </asp:CalendarExtender>
            &nbsp
            <asp:Label ID="Label12" runat="server" Text="TO :" Font-Bold="True" Font-Names="Verdana"
                Font-Size="12px" ForeColor="#333333"></asp:Label>
            <asp:TextBox ID="txtDateT" runat="server" CssClass="waterMark"></asp:TextBox>
            <asp:CalendarExtender ID="txtDateT_CalendarExtender" runat="server" Enabled="True"
                TargetControlID="txtDateT" Format="MMMM dd, yyyy">
            </asp:CalendarExtender>
        </fieldset>
    </div>
    <div style="margin-top: auto;">
        <asp:UpdatePanel ID="OptionalSearch" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblPost" runat="server" Text="POST STATUS :" Font-Bold="True" Font-Names="Verdana"
                                Font-Size="12px" ForeColor="#333333"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioPosted" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">POSTED</asp:ListItem>
                                <asp:ListItem Value="2">UNPOSTED</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="APPAREL TYPE :" Font-Bold="True" Font-Names="Verdana"
                                Font-Size="12px" ForeColor="#333333"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="lstCategory" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True">
                                <asp:ListItem Value="0">ALL</asp:ListItem>
                                <asp:ListItem Value="1">TOPS</asp:ListItem>
                                <asp:ListItem Value="2">BOTTOMS</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                  <div>
                    <asp:Label ID="Label2" runat="server" Text="INCLUDE PREVIOUS YEAR :" 
                        style="font-family: Verdana; font-weight: 700; color: #333333"></asp:Label>
                    &nbsp
                    <asp:CheckBox ID="ckPrev" runat="server" AutoPostBack="True" />
                </div>
                <div>
                    <asp:Label ID="lblBrand" runat="server" Text="BRAND NAME :" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="12px" ForeColor="#333333"></asp:Label>
                    &nbsp
                    <asp:DropDownList ID="cboBrand" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="lblCustomer" runat="server" Text="CUSTOMER :" Font-Bold="True" Font-Names="Verdana"
                        Font-Size="12px" ForeColor="#333333"></asp:Label>
                    &nbsp
                    <asp:DropDownList ID="cboCustomer" runat="server">
                    </asp:DropDownList>
                </div>

              

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div>
        <%-- <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>--%>
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print Preview"
            CssClass="btnPrint" Width="125px" Height="37px" />
        <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
    </div>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlError" runat="server" Visible="false">
                <div style="text-align: center; background-color: #FFFFCC; border: 1px Solid #FFCC66;
                    height: 25px;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/warning.png" ImageAlign="AbsMiddle" />
                    <asp:Label ID="lblError" runat="server" Text="PLEASE SELECT REQUIRED PARAMETER!!"
                        Font-Bold="True" Font-Names="Verdana" Font-Size="12px" ForeColor="#CC6600" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
