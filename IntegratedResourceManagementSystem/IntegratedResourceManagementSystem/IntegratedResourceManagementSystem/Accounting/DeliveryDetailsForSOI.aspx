<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
    CodeBehind="DeliveryDetailsForSOI.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.DeliveryDetailsForSOI" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/soi-form.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/grid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div style="float:right; cursor:pointer;">
    <img alt="" src="../Resources/cancel_gray.png" title="Close window" onclick="window.close()" />
</div>
    <div style="float: left; margin-bottom:10px;">
        <div class="titleForm">
            CUSTOMER/OUTLET INFO.
            <div style="float:right;">
                <asp:HyperLink Visible="false" CssClass="btnPrint" Height="17px" ID="hpLinnkPrint" style="padding-right:3px;" runat="server">PRINT</asp:HyperLink>
            </div>
        </div>
        <div class="form">
            <table style="">
                <tr>
                    <td class="modalLabel">
                        DR DATE FROM:
                    </td>
                    <td>
                        <asp:Label CssClass="modalText" Style="padding: 1px 2px 1px 2px; font-style: italic;"
                            ID="txtDateFrom" runat="server" Text="Label"></asp:Label>
                        <span style="padding: 0px 5px;" class="modalLabel">TO</span>
                        <asp:Label CssClass="modalText" Style="padding: 1px 2px 1px 2px; font-style: italic;"
                            ID="txtDateTo" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="modalLabel">
                        CUSTOMER/OUTLET:
                    </td>
                    <td>
                        <asp:Label CssClass="modalText" Style="padding: 1px 2px 1px 2px; font-weight: bold;"
                            ID="lblCustomer" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="modalLabel">
                        BRAND:
                    </td>
                    <td>
                      <asp:Label CssClass="modalText" Style="padding: 1px 2px 1px 2px; font-weight: bold;"
                            ID="lblBrand" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <div class="titleForm" style="margin-top: 10px; height: 10px; min-width: 300px;">
            DR DETAILS
        </div>
        <div class="form" style="min-width: 300px;">
            <asp:GridView ID="gvDeliveryReceiptDetails" CssClass="table_grid" runat="server"
                Font-Names="Verdana" Font-Size="10px" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDRDetailsBreakDown"
                ForeColor="#333333" EnableViewState="False" AllowPaging="True" CellPadding="4"
                GridLines="None" PageSize="50" AllowSorting="True">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl="~/Resources/invoice.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DR_DATE" HeaderText="DR DATE" DataFormatString="{0:MMMM dd, yyyy}"
                        SortExpression="DR_DATE">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DR_NUMBER" HeaderText="DR NUMBER" SortExpression="DR_NUMBER">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUSTOMER" HeaderText="CUSTOMER" SortExpression="CUSTOMER">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="AMOUNT" DataFormatString="{0:###,###.00}"
                        SortExpression="TOTAL_AMOUNT">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" ForeColor="#CC0000" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL_QUANTITY" HeaderText="QTY" SortExpression="TOTAL_QUANTITY">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" Font-Bold="True" HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceDRDetailsBreakDown" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                SelectCommand="SELECT [ID], [DRNo] AS DR_NUMBER, [DeliveredTo] AS CUSTOMER, [DRDate] AS DR_DATE, [TotalAmt] AS TOTAL_AMOUNT,
				 [TotalQty] AS TOTAL_QUANTITY FROM [DR] WHERE (([CustNo] = @CustNo) AND ([DRDate] BETWEEN @DRDate1 AND @DRDate2))"
                EnableCaching="True" EnableViewState="False">
                <SelectParameters>
                    <asp:QueryStringParameter Name="CustNo" QueryStringField="CustomerNumber" Type="Int32" />
                    <asp:QueryStringParameter Name="DRDate1" QueryStringField="FromDate" Type="DateTime" />
                    <asp:QueryStringParameter Name="DRDate2" QueryStringField="ToDate" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>
