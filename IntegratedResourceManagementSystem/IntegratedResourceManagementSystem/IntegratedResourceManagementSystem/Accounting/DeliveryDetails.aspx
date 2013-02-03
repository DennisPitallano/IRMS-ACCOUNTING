<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="DeliveryDetails.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.DeliveryDetails" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/delivery-details.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <div style="min-height: 490px;">
        <div class="modalDrag" style="height: 20px; margin-bottom: 2px;">
            <div class="sizeLogo">
                <img src="../Resources/accounting.png" height="16px" align="top" />
                DR DETAILS VIEW
            </div>
            <div style="float: right; cursor: pointer;">
                <img title="Close Window" id="imgClose" src="../Resources/cancel_gray.png" alt="CLOSE WINDOW" />
            </div>
        </div>
        <asp:UpdatePanel ID="upnlDRDetails" runat="server">
            <ContentTemplate>
                <div class="dr modal">
                    <div style="text-align: center; margin: 5px 2px 0px 2px; font-weight: bold;" class="modalLabel">
                        <span>CUSTOMER LIST</span>
                    </div>
                    <hr style="color: #BEB57C;" />
                    <table>
                        <tr>
                            <td valign="top" class="label">
                                CUSTOMER:
                            </td>
                            <td class="drdetails">
                                <asp:Label ID="lblCustomer" Font-Size="11px" runat="server" Text="Label" Width="120px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                DR DATE:
                            </td>
                            <td class="drdetails">
                                <asp:Label ID="lblDRDate" Font-Size="11px" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="modalText" colspan="2">
                                <asp:GridView ID="gvDRList" runat="server" DataSourceID="SqlDataSourceDR" AutoGenerateColumns="False"
                                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                    Font-Names="Verdana" Font-Size="11px" ForeColor="Black" GridLines="None"
                                    OnSelectedIndexChanged="gvDRList_SelectedIndexChanged" AllowSorting="True" 
                                    DataKeyNames="DRNo,DRDate">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False" HeaderText="DR #">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                    CommandName="Select" Text='<%#Eval("DRNo") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DRNo" HeaderText="DRNo" SortExpression="DRNo" 
                                            Visible="False" />
                                        <asp:BoundField DataField="DRDate" HeaderText="DR DATE" SortExpression="DRDate" 
                                            DataFormatString="{0:MMMM dd, yyyy}">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotalAmt" HeaderText="TOTAL AMT" 
                                            SortExpression="TotalAmt" DataFormatString="{0:###,###.00}">
                                        <ItemStyle Font-Bold="True" ForeColor="#CC3300" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TotalQty" HeaderText="TOTAL QTY" 
                                            SortExpression="TotalQty" >
                                        <ItemStyle Font-Bold="True" ForeColor="#663300" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSourceDR" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                                    SelectCommand="SELECT [DRNo]
      ,[DRDate]
      ,[TotalAmt]
      ,[TotalQty]
  FROM [IRMS-DB].[dbo].[DR]
  where CustNo=@CustomerNumber  and DRDate Between @DateFrom  and @DateTo">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="CustomerNumber" 
                                            QueryStringField="CustomerNumber" />
                                        <asp:QueryStringParameter Name="DateFrom" QueryStringField="DateFrom" />
                                        <asp:QueryStringParameter Name="DateTo" QueryStringField="DateTo" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:HiddenField ID="hfDRDate" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="label">
                                TOTAL QTY:
                            </td>
                            <td class="drdetails">
                                <asp:Label ID="lblTotalQuantity" runat="server" Text="Label" Font-Size="11px" ForeColor="#CC3300"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
                </div>
                <div style="float: left; margin-right: 5px;">
                    <asp:UpdateProgress ID="upProgress" runat="server" AssociatedUpdatePanelID="upnlDRDetails">
                        <ProgressTemplate>
                            <asp:PlaceHolder ID="plcHLoader" runat="server">
                                <UC:LOADER ID="loader" runat="server" />
                            </asp:PlaceHolder>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <div style="display: inline-block;">
                    <div style="float: left;">
                    <div class="modalDrag">
                   <div  class ="sizeLogo">
                    
                       <asp:Label ID="lblDRNumberDetails" runat="server" Text="DR DETAILS BY DR #:"></asp:Label>
                    </div>
                    </div>
                        <asp:GridView ID="gvDRDetails" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataSourceID="SqlDataSourceDRDetailsByDRNo" CssClass="table-grid-style"
                            PageSize="20" CellPadding="3" GridLines="None" Font-Size="11px">
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <img src="../Resources/adjustment.png" alt="DR" height="16px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DRNo" HeaderText="DR #" SortExpression="DRNo">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" Font-Bold="True" />
                                </asp:BoundField>
                             
                                <asp:BoundField DataField="StyleNo" HeaderText="STYLE #" SortExpression="StyleNo">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" Font-Italic="True" />
                                </asp:BoundField>
                             
                                <asp:BoundField DataField="TOTAL_QTY" HeaderText="QUANTITY" SortExpression="TOTAL_QTY">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TOTAL_PRICE" HeaderText="UNIT PRICE" SortExpression="TOTAL_PRICE"
                                    DataFormatString="{0:###,###.00}">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" ForeColor="#CC0000" Font-Bold="True" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <img src="../Resources/unhappy.png" align="top" />
                                DETAILS NOT FOUND,<br /> PLEASE SELECT FROM THE LIST!
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle CssClass="pager" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle CssClass="asc-cell-style" />
                            <SortedAscendingHeaderStyle CssClass="asc-cell-style-h" />
                            <SortedDescendingCellStyle CssClass="desc-cell-style" />
                            <SortedDescendingHeaderStyle CssClass="desc-cell-style-h" />
                        </asp:GridView>
                       
                        <asp:SqlDataSource ID="SqlDataSourceDRDetailsByDRNo" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                            SelectCommand="SP_GET_CDI_DETAILS_SUMMARY_BY_DRNO" EnableCaching="True" ViewStateMode="Disabled"
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hfDRDate" Name="DRDate" PropertyName="Value" Type="DateTime"  />
                                <asp:QueryStringParameter DefaultValue="" Name="CustomerNumber" QueryStringField="CustomerNumber" />
                                <asp:ControlParameter ControlID="gvDRList" Name="DRNumber" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                 
                    </div>
                    <div class="modalDrag  filter-display">
                    <div style="margin-bottom:5px;">
                        <asp:Button type="reset" CssClass="btnReload" ID="btnReloadList" runat="server" 
                            Text="RELOAD LIST" onclick="btnReloadList_Click" />
                            </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
