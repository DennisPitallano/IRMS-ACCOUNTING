<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
 CodeBehind="SalesInvoice.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.SalesInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/sales-invoice-from.css" rel="stylesheet" type="text/css" />
  
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titlePanel">
		    <img src="../Resources/invoice.png" height="22px" align="top" />
		    Sales Invoice - Liquidation Panel
	    </div>
    <div style="min-height: 475px;">
    <div style="height: 26px; margin-bottom: 1px;" class="modalDrag">
					<div class="SearchTextContainer">
						SEARCH:
						<asp:TextBox ID="txtSearch" runat="server" CssClass="modalText" AutoPostBack="True"
							autofocus="true" placeholder="Search Sales Invoice Number" Height="16px" Font-Size="10px"
							Width="150px" ToolTip="Search Sales Invoice Number" ontextchanged="txtSearch_TextChanged"></asp:TextBox>
						<asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
							ToolTip="SEARCH" onclick="imgBtnSearch_Click" />
					</div>
					<div style="float: left; width: 719px;">
						<div style="float: left; margin-right: 2px;">
							<a style="text-decoration: none;" href="NewSalesInvoiceLiq.aspx" title="New Sales Invoice">
								<input id="btnNewSalesInvoice" class="btnNew" type="button" value="NEW" />
							</a>
						</div>
                       <%-- <div style="float: left; margin-right: 2px;">
							<a style="text-decoration: none;" href="SalesInvoiceLiqUpdate.aspx" title="UPDATE SALES INVOICE">
								<input id="btnUpdateBookAdjustment" class="btnNew" type="button" value="UPDATE" onclick="return btnUpdateBookAdjustment_onclick()" />
							</a>
						</div>--%>
						<div style="float: left; margin-right: 2px;">
							<asp:Button ID="btnUpdateBookAdjustment" runat="server" Text="UPDATE"  ToolTip ="Update Selected Sales Invoice"
                                CssClass="btnUpdate" onclick="btnUpdateBookAdjustment_Click" />
							
						</div>
						<div style="float: left; margin-right: 2px;">
							<asp:Button ID="btnDelete" runat="server" Text="DELETE" ToolTip="Delete Selected Sales Invoice"
								CssClass="btnDelete" onclick="btnDelete_Click" />
							<asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" CancelControlID="btnNo"
								DynamicServicePath="" Enabled="True" PopupControlID="pnlDeleteSI" PopupDragHandleControlID="pnlDeleteSI"
								TargetControlID="HiddenField_btnDelete">
								<Animations>
								<OnShown>
									<FadeIn Duration=".2" />
								</OnShown>
								</Animations>
							</asp:ModalPopupExtender>
						</div>

						<div style="float: left; margin-right: 2px;">
							<asp:HyperLink ID="hpLinkPrint" Target="_blank" Height="18px" CssClass="btnPrint" ToolTip = "Print Selected Sales Invoice"
								runat="server">PRINT</asp:HyperLink>
						</div>
					</div>
                   <asp:HiddenField ID="HiddenField_btnDelete" runat="server" />
				
    </div>
     <div class="titleList">
						<img src="../Resources/panels.png" align="top" />
						SALES INVOICE FOR LIQUIDATION - UNPOSTED RECORD(S)
					</div>
                    	<div style="float: left; width: 719px;">
						<div style="float: left; margin-right: 2px;">
						</div>
                        <br />
                           <table>
                            <tr>
                                 <td style="font-size: medium; font-weight: bold; color: #008000">
                                FILTERS :
                                </td>
                                 <td>
                            <asp:Button ID="btnUnposted" runat="server" CssClass="btnSalesInvoice" 
                                         Text="List Unposted Records" Width="150" Height = 20px 
                                         onclick="btnUnposted_Click" />
                                </td>
                                 <td>
                            <asp:Button ID="btnPosted" runat="server" CssClass="btnSalesInvoice" 
                                         Text="List Posted Records"  Width="150" Height = 20px 
                                         onclick="btnPosted_Click" />
                                </td>
                                 <td>
                            <asp:Button ID="btnCancelled" runat="server" CssClass="btnSalesInvoice" 
                                         Text="List Cancelled Records" Width="150" Height = 20px 
                                         onclick="btnCancelled_Click"/>
                                </td>
                            </tr>
                           </table>
					</div>
                    <br />
                    <br />
                     <br />
<div class="GridView">
<asp:GridView ID="GridViewSalesInvoice" runat="server" AllowPaging="True" AllowSorting="True"
						AutoGenerateColumns="False" CellPadding="4"
                        CssClass="table_grid" GridLines="None" 
            DataSourceID="SqlDataSourceSalesInvoice" PageSize="15" 
        onselectedindexchanged="GridViewSalesInvoice_SelectedIndexChanged" 
        onpageindexchanged="GridViewSalesInvoice_PageIndexChanged" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <Columns>
							<asp:TemplateField>
                            
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Image ID="imgDetails" AlternateText='<%#Eval("ID") %>' tooltip='<%#Eval("ID") %>' runat="server" ImageUrl="~/Resources/panels.png" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:CommandField ShowSelectButton="True" />
							<asp:BoundField DataField="SINo" HeaderText="INVOICE NO." InsertVisible="False"
								ReadOnly="True" SortExpression="SINo">
								<ItemStyle Font-Bold="True" HorizontalAlign="Center" />
							</asp:BoundField>
							<asp:BoundField DataField="SIDate" HeaderText="INVOICE DATE" 
                                SortExpression="SIDate" DataFormatString="{0:d}" />
                            
							<asp:BoundField DataField="SoldTo" HeaderText="SOLD TO" SortExpression="SINo" />
                           
						</Columns>
						<EmptyDataTemplate>
							<img src="../Resources/unhappy.png" align="middle" />
							NO DATA FOUND!
						</EmptyDataTemplate>
						<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<PagerStyle CssClass="pager" />
						<RowStyle BackColor="#E3EAEB" />
						<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
						<SortedAscendingCellStyle CssClass="asc_cell_style" />
						<SortedAscendingHeaderStyle CssClass="asc_cell_style_h" />
						<SortedDescendingCellStyle CssClass="desc_cell_style" />
						<SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
</asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceSalesInvoice" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>" 
            
        SelectCommand="SELECT [ID],[SINo], [SIDate], [SoldTo] FROM [SI] WHERE ([ynLiquidation] = @ynLiquidation) and ([ynPosted] = 'FALSE')  ORDER BY [SIDate] DESC, [ID] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="TRUE" Name="ynLiquidation" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
</div>
	<asp:Panel ID="pnlDeleteSI" runat="server" CssClass="modal">
				<asp:Panel ID="pnlSelectedDRPreviewDrag" runat="server" CssClass="modalDrag">
					<div id="divFinTrab" class="sizeLogo" runat="server">
						<img src="../Resources/panels.png" height="16px" alt="" align="top" />
						Delete Invoice Confirmation.
					</div>
				</asp:Panel>
				<div align="center"><label id ="lblFinalize" runat="server"
                        style="font-family: Verdana; font-weight: bold; color: #FF0000" 
                        accesskey="lblFinalize" >
                        No Sales Invoice has been selected..!
                    </label>
                </div>
                 <div style="text-align: center; margin: 3px 0px 3px 0px;">
                    <asp:Button ID="btnOK" runat="server" Text="YES" 
                        CssClass="modalWarningButtonYes" onclick="btnOK_Click" Visible="False"/>
                     <asp:Button ID="btnNo" runat="server" Text="OK" 
                        CssClass="modalWarningButtonYes"/>
                </div>
			</asp:Panel>

</asp:Content>



