<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryBrandInventoryReport.aspx.cs"
    Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.SummaryBrandInventoryReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SUMMARY OF BRAND INVENTORY REPORT </title>
      <link href="../../Styles/toolbar-controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .table
        {
            font-family: Arial;
            font-size: 10px;
        }
        #GridView1 th, #GridView2 th, #GridView3 th, #GridView4 th
        {
            padding: 2px 4px;
            font-size: 12px;
            font-weight: bold;
        }
        #GridView1 tr td, #GridView2 tr td, #GridView3 tr td, #GridView4 tr td
        {
            padding: 2px 4px;
        }
    </style>
    <style type="text/css" media="print">
        #btnPrint
        {
            visibility: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        </center>
    </div>
    <div>
        <center>
            <asp:Label ID="Label1" runat="server" Text="SUMMARY OF STORE INVENTORY REPORT" Style="font-weight: 700;
                font-family: Verdana"></asp:Label>
        </center>
    </div>
    <div>
        <center>
            <asp:Label ID="Label2" runat="server" Text="AS OF " CssClass="style1" Font-Bold="True"
                Font-Names="Verdana" Font-Size="Medium"></asp:Label>
            <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
        </center>
    </div>
    <br />
    <div>
        <asp:Label ID="Label5" runat="server" Text="MMDS" Style="font-family: Verdana; font-size: small;
            font-weight: 700; color: #990000; text-decoration: underline"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True" OnRowDataBound="GridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BrandName" HeaderText="BRAND NAME">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetBookQty(int.Parse(Eval("EndingInventoryVolume").ToString())).ToString("0,000") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualCountVolume").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty" runat="server" Text='<%# Eval("LkgOverQty") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG/ OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty" runat="server" Text='<%# Eval("PercentageQty","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost" runat="server" Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventoryCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT">
                    <ItemTemplate>
                        <%# GetActualPcountCost(double.Parse(Eval("ActualCountCost").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost" runat="server" Text='<%# Eval("VarianceCost") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("AveragePerPc") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalAveragePerPcount().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook" runat="server" Text='<%# Eval("PercentCostLkgBook","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPercentCostLkgFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle Font-Size="XX-Small" />
            <EmptyDataTemplate>
                <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                    line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                    <img src="../../Resources/unhappy.png" alt="WEEE" align="middle" />
                    DATA NOT FOUND!!!
                </div>
            </EmptyDataTemplate>
            <FooterStyle BorderStyle="Solid" Wrap="False" />
            <HeaderStyle Font-Size="Medium" Font-Underline="False" />
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:Label ID="Label6" runat="server" Text="LUZON" Style="font-family: Verdana; font-size: small;
            font-weight: 700; color: #990000; text-decoration: underline"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True" OnRowDataBound="GridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BrandName" HeaderText="BRAND NAME">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetBookQty(int.Parse(Eval("EndingInventoryVolume").ToString())).ToString("0,000") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualCountVolume").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty" runat="server" Text='<%# Eval("LkgOverQty") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG/ OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty" runat="server" Text='<%# Eval("PercentageQty","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost" runat="server" Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventoryCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT">
                    <ItemTemplate>
                        <%# GetActualPcountCost(double.Parse(Eval("ActualCountCost").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost" runat="server" Text='<%# Eval("VarianceCost") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("AveragePerPc") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalAveragePerPcount().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook" runat="server" Text='<%# Eval("PercentCostLkgBook","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPercentCostLkgFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle Font-Size="XX-Small" />
            <EmptyDataTemplate>
                <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                    line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                    <img src="../../Resources/unhappy.png" alt="WEEE" align="middle" />
                    DATA NOT FOUND!!!
                </div>
            </EmptyDataTemplate>
            <FooterStyle BorderStyle="Solid" Wrap="False" />
            <HeaderStyle Font-Size="Medium" Font-Underline="False" />
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:Label ID="Label7" runat="server" Text="VISAYAS" Style="font-family: Verdana;
            font-size: small; font-weight: 700; color: #990000; text-decoration: underline"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True" OnRowDataBound="GridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BrandName" HeaderText="BRAND NAME">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# GetBookQty(int.Parse(Eval("EndingInventoryVolume").ToString())).ToString("0,000") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualCountVolume").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty" runat="server" Text='<%# Eval("LkgOverQty","{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG/ OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty" runat="server" Text='<%# Eval("PercentageQty","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost" runat="server" Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventoryCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT">
                    <ItemTemplate>
                        <%# GetActualPcountCost(double.Parse(Eval("ActualCountCost").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost" runat="server" Text='<%# Eval("VarianceCost","{0:0,000.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("AveragePerPc") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalAveragePerPcount().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook" runat="server" Text='<%# Eval("PercentCostLkgBook","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPercentCostLkgFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle />
            <EmptyDataTemplate>
                <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                    line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                    <img src="../../Resources/unhappy.png" alt="WEEE" align="middle" />
                    DATA NOT FOUND!!!
                </div>
            </EmptyDataTemplate>
            <FooterStyle BorderStyle="Solid" Wrap="False" />
            <HeaderStyle Font-Size="Medium" Font-Underline="False" />
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:Label ID="Label8" runat="server" Text="MINDANAO" Style="font-family: Verdana;
            font-size: small; font-weight: 700; color: #990000; text-decoration: underline"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True" OnRowDataBound="GridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BrandName" HeaderText="BRAND NAME">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# GetBookQty(int.Parse(Eval("EndingInventoryVolume").ToString())).ToString("0,000") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualCountVolume").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty" runat="server" Text='<%# Eval("LkgOverQty","{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG/ OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty" runat="server" Text='<%# Eval("PercentageQty","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost2" runat="server" Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventoryCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT">
                    <ItemTemplate>
                        <%# GetActualPcountCost(double.Parse(Eval("ActualCountCost").ToString()))%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost" runat="server" Text='<%# Eval("VarianceCost","{0:0,000.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("AveragePerPc") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalAveragePerPcount().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook" runat="server" Text='<%# Eval("PercentCostLkgBook","{0:0}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPercentCostLkgFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle />
            <EmptyDataTemplate>
                <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                    line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                    <img src="../../Resources/unhappy.png" alt="WEEE" align="middle" />
                    DATA NOT FOUND!!!
                </div>
            </EmptyDataTemplate>
            <FooterStyle BorderStyle="Solid" Wrap="False" />
            <HeaderStyle Font-Size="Medium" Font-Underline="False" />
        </asp:GridView>
    </div>

    <br />

     <div style="text-align:center; margin-top:10px;">
        <input id="btnPrint" type="button" class="btnPrint" value="PRINT" onclick="window.print()" />
    </div>

    </form>
</body>
</html>
