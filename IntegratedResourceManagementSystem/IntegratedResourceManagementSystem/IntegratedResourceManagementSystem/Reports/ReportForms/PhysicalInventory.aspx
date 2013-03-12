<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicalInventory.aspx.cs"
    Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.PhysicalInventory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PHYSICAL INVENTORY REPORT </title>
    <link href="../../Styles/toolbar-controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .table
        {
            font-family: Arial;
            font-size: 12px;
        }
        #GridView1 th
        {
            padding: 2px 4px;
            font-size: 13px;
            font-weight: bold;
            font-family: Arial;
        }
        #GridView1 tr td
        {
            padding: 2px 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:Label ID="Label1" runat="server" Text="PHYSICAL INVENTORY" Font-Bold="True"
                Font-Names="Verdana" Font-Size="Large"></asp:Label>
        </center>
    </div>
    <div>
        <center>
            <asp:Label ID="lblYear" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label>
        </center>
    </div>
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" Text="BRAND NAME :" Font-Bold="True" Font-Names="Verdana"
            Font-Size="Small"></asp:Label>
        <asp:Label ID="lblBrand" runat="server" Font-Names="Verdana" Font-Size="Small"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="APPAREL TYPE :" Font-Bold="True" Font-Names="Verdana"
            Font-Size="Small"></asp:Label>
        <asp:Label ID="lblCategory" runat="server" Font-Names="Verdana" Font-Size="Small"></asp:Label>
    </div>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="STYLE NO #">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("StyleNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("StyleNo") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalTitle" runat="server" Text='TOTAL' Font-Bold="True"></asp:Label>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:BoundField DataField="SRPQty" HeaderText="SRP QUANTITY">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="SRPPrice" HeaderText="SRP PRICE">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="SrpAmount" HeaderText="SRP AMOUNT">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="MrdQty" HeaderText="MARK DOWN QUANTITY">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="MrdPrice" HeaderText="MARK DOWN PRICE">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="MrdAmount" HeaderText="MARK DOWN AMOUNT">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalQty" HeaderText="TOTAL QUANTITY">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalAmount" HeaderText="TOTAL AMOUNT">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/unhappy.png" />
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="LabelTitle" Text="NO RECORDS FOUND !!!"></asp:Label>
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <FooterStyle Font-Bold="True" />
        </asp:GridView>
    </div>
    <br />
    <div style="text-align: center; margin-top: 10px;">
        <input id="btnPrint" type="button" class="btnPrint" value="PRINT" onclick="window.print()" />
    </div>
    </form>
</body>
</html>
