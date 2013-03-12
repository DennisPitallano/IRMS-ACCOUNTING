<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryStoreInventoryReport.aspx.cs"
    Inherits="IntegratedResourceManagementSystem.Reports.ReportForms.SummaryStoreInventoryReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SUMMARY OF SOI PER BRAND</title>
     <link href="../../Styles/toolbar-controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: small;
        }
        .style2
        {
            font-weight: bold;
            font-family: Verdana;
            font-size: small;
            color: #000000;
        }
        .table
        {
            font-family:Arial;
             font-size:12px;
           
        }
        #GridView1 th, #GridView2 th ,#GridView3 th,#GridView4 th
        {
            padding:2px 4px;
            font-size:13px;
            font-weight:bold;
            font-family:Arial;
        }
        #GridView1 tr td, #GridView2 tr td, #GridView3 tr td, #GridView4 tr td
        {
            padding:2px 4px;
        }
    </style>
     <style type="text/css" media="print" >
        #btnPrint
        {
            visibility:hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:Label ID="Label1" runat="server" Text="SUMMARY OF SOI PER BRAND" Style="font-weight: 700;
                font-family: Verdana"></asp:Label>
        </center>
    </div>
    <div>
        <center>
            <asp:Label ID="Label2" runat="server" Text="AS OF " CssClass="style1"></asp:Label>
            <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
        </center>
    </div>
    <div> 
        <center>
        <asp:Label ID="lblCustomer" runat="server" Text="Label" Font-Bold="True" 
                Font-Overline="False" Font-Underline="True"></asp:Label>
        </center>
    </div>
    <div style="text-align: left">
        <asp:Label ID="Label4" runat="server" Text="BRAND :" CssClass="style2"></asp:Label>
        <asp:Label ID="lblBrand" runat="server" Text="Label"></asp:Label>
    </div>
    <br />
    <div>
        <asp:Label ID="lblMmds" runat="server" Text="MMDS" Style="font-family: Verdana; font-size: small;
            font-weight: 700; color: #990000; text-decoration: underline"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="CustomerNames" HeaderText="OUTLET">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="DateRecorded" DataFormatString="{0:yyyy-MM-dd}" 
                    HeaderText="INVTY DATE">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label34" runat="server" 
                            Text='<%# GetBookQty(int.Parse(Eval("BookQuantity").ToString())).ToString("#,##0") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualPCount").ToString())).ToString("#,##0")%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty0" runat="server" Text='<%# Eval("LackingOver") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty0" runat="server" 
                            Text='<%# Eval("PercentOfBookOverQty") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost0" runat="server" 
                            Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventory").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT COST">
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server" Text='<%# GetActualPcountCost(double.Parse(Eval("ActualPCountCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost0" runat="server" 
                            Text='<%# Eval("VarianceCost","{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("AvePerCost","{0:0,000.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                      
                         <%# GetTotalAveragePerPcount().ToString("#,###.##")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook0" runat="server" 
                            Text='<%# Eval("PercentOfCostLacking","{0:0,000.00}") %>'></asp:Label>
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
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="CustomerNames" HeaderText="OUTLET">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="DateRecorded" DataFormatString="{0:yyyy-MM-dd}" 
                    HeaderText="INVTY DATE">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label35" runat="server" 
                            Text='<%# GetBookQty(int.Parse(Eval("BookQuantity").ToString())).ToString("#,##0") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualPCount").ToString())).ToString("#,##0")%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty1" runat="server" Text='<%# Eval("LackingOver") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty1" runat="server" 
                            Text='<%# Eval("PercentOfBookOverQty") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost1" runat="server" 
                            Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventory").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT COST">
                    <ItemTemplate>
                        <asp:Label ID="Label36" runat="server" 
                            Text='<%# GetActualPcountCost(double.Parse(Eval("ActualPCountCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost1" runat="server" 
                            Text='<%# Eval("VarianceCost","{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label37" runat="server" 
                            Text='<%# Bind("AvePerCost","{0:0,000.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
 
                         <%# GetTotalAveragePerPcount().ToString("#,###.##")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook1" runat="server" 
                            Text='<%# Eval("PercentOfCostLacking","{0:0,000.00}") %>'></asp:Label>
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
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="CustomerNames" HeaderText="OUTLET">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="DateRecorded" DataFormatString="{0:yyyy-MM-dd}" 
                    HeaderText="INVTY DATE">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label38" runat="server" 
                            Text='<%# GetBookQty(int.Parse(Eval("BookQuantity").ToString())).ToString("#,##0") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualPCount").ToString())).ToString("#,##0")%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty2" runat="server" Text='<%# Eval("LackingOver") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty2" runat="server" 
                            Text='<%# Eval("PercentOfBookOverQty") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost2" runat="server" 
                            Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventory").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT COST">
                    <ItemTemplate>
                        <asp:Label ID="Label39" runat="server" 
                            Text='<%# GetActualPcountCost(double.Parse(Eval("ActualPCountCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost2" runat="server" 
                            Text='<%# Eval("VarianceCost","{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label40" runat="server" 
                            Text='<%# Bind("AvePerCost","{0:0,000.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                  
                         <%# GetTotalAveragePerPcount().ToString("#,###.##")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook2" runat="server" 
                            Text='<%# Eval("PercentOfCostLacking","{0:0,000.00}") %>'></asp:Label>
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
        <asp:Label ID="Label8" runat="server" Text="MINDANAO" Style="font-family: Verdana;
            font-size: small; font-weight: 700; color: #990000; text-decoration: underline"></asp:Label>
    </div>
    <div>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="table"
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="CustomerNames" HeaderText="OUTLET">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="DateRecorded" DataFormatString="{0:yyyy-MM-dd}" 
                    HeaderText="INVTY DATE">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BOOK QTY">
                    <ItemTemplate>
                        <asp:Label ID="Label41" runat="server" 
                            Text='<%# GetBookQty(int.Parse(Eval("BookQuantity").ToString())).ToString("#,##0") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalBookQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT QTY">
                    <ItemTemplate>
                        <%# GetPcountQty(double.Parse(Eval("ActualPCount").ToString())).ToString("#,##0")%>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPcountQty().ToString("0,000")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblLkgOverQty3" runat="server" Text='<%# Eval("LackingOver") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalQtyLkgOverFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF BOOK QTY (LKG / OVER)">
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageQty3" runat="server" 
                            Text='<%# Eval("PercentOfBookOverQty") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalPrecentBookQtyFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ENDING INVTY">
                    <ItemTemplate>
                        <asp:Label ID="lblEndingCost3" runat="server" 
                            Text='<%# GetEndingInvtCost(double.Parse(Eval("EndingInventory").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalEndingInvtCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ACTUAL P.COUNT COST">
                    <ItemTemplate>
                        <asp:Label ID="Label42" runat="server" 
                            Text='<%# GetActualPcountCost(double.Parse(Eval("ActualPCountCost").ToString())).ToString("0,000.00") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalActualPcountCost().ToString("0,000.00")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VARIANCE COST">
                    <ItemTemplate>
                        <asp:Label ID="lblVarianceCost3" runat="server" 
                            Text='<%# Eval("VarianceCost","{0:0,000}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <%# GetTotalVarianceCostFormatted().ToString()%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AVE.PER COST">
                    <ItemTemplate>
                        <asp:Label ID="Label43" runat="server" 
                            Text='<%# Bind("AvePerCost","{0:0,000.00}") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                       
                         <%# GetTotalAveragePerPcount().ToString("#,###.##")%>
                    </FooterTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% OF COST LKG. (LKG / BOOK)">
                    <ItemTemplate>
                        <asp:Label ID="lblCostLkgBook3" runat="server" 
                            Text='<%# Eval("PercentOfCostLacking","{0:0,000.00}") %>'></asp:Label>
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

      <div style="text-align:center; margin-top:10px;">
        <input id="btnPrint" type="button" class="btnPrint" value="PRINT" onclick="window.print()" />
    </div>

    </form>
</body>
</html>
