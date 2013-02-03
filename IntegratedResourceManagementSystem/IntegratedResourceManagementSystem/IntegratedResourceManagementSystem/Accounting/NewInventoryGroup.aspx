<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
	CodeBehind="NewInventoryGroup.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.NewInventoryGroup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
	<link href="../Styles/new-inventory-group.css" rel="stylesheet" type="text/css" />
	<script language="javascript" type="text/javascript">
		function SelectAll(frmId, id) {
			var frm = document.getElementById(frmId);
			for (i = 1; i < frm.rows.length; i++) {
				var checkbox = frm.rows[i].cells[1].childNodes[1];
				if (checkbox != null)
					checkbox.checked = document.getElementById(id).checked;
			}
		};
	</script>
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="titlePanel">
		<img src="../Resources/invoice.png" height="22px" align="top" />
		Monthly Store OutStanding Inventory Management Panel.
	</div>
	<asp:UpdatePanel ID="upnlInventoryGroup" runat="server">
		<ContentTemplate>
		  <asp:UpdateProgress ID="uprogressAdjustmentMemo" runat="server" AssociatedUpdatePanelID="upnlInventoryGroup">
					<ProgressTemplate>
						<asp:PlaceHolder ID="plHldrLoader" runat="server">
							<UC:LOADER ID="uprogLoader" runat="server" />
						</asp:PlaceHolder>
					</ProgressTemplate>
				</asp:UpdateProgress>
			<div class="items-selected" style="width: 370px; margin-bottom: 10px;">
				<div class="titleList" style="height: 10px;">
					NEW INVENTORY GROUP</div>
				<table style="">
					<tr>
						<td class="modalLabel">
							<label for="MainContent_txtGroupName">
								GROUP NAME:</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="250px" Height="20px" ID="txtGroupName" runat="server"></asp:TextBox>
						</td>
						<td>
							&nbsp;
						</td>
					</tr>
					<tr>
						<td>
						</td>
						<td>
						</td>
						<td>
						</td>
					</tr>
				</table>
			</div>
			<div>
				<div class="titleList" style="margin-bottom:3px;">
					ADD OUTLET/S
				</div>
				<div style="float: left; margin-bottom: 15px;">
					<div class="modalDrag" style="height:28px;">
							<div style="float: left; margin-right:2px;">
								<asp:Label ID="lblFilterLink" CssClass="filter-link" runat="server" Text="FILTER"></asp:Label>
						<asp:HoverMenuExtender ID="lblFilterLink_HoverMenuExtender" runat="server" DynamicServicePath=""
							Enabled="True" PopupControlID="pnlPrintOption" TargetControlID="lblFilterLink" 
							PopupPosition="Bottom">
						</asp:HoverMenuExtender>
					</div>
					<asp:Panel ID="pnlPrintOption" runat="server">
					<div class="hover-menu-arrow">
						</div>
						<div class="hover-menu">
							<div class="print-link">
							 <label for="MainContent_DDLBrands"> BY BRAND:</label>
							  <asp:DropDownList ID="DDLBrands" CssClass="modalText" runat="server">
								</asp:DropDownList>
								<asp:Button ID="btnFilterByBrand" CssClass="btnFilter" runat="server" 
									Text="FILTER" onclick="btnFilterByBrand_Click" />
							</div>
							<div class="print-link" style="text-align:center;">
								<asp:Button ID="btnReloadOutletList" CssClass="btnReload" runat="server" 
									Text="RELOAD OUTLET LIST" onclick="btnReloadOutletList_Click" />
							</div>
						</div>
					</asp:Panel>
							<div class="SearchTextContainer">
				   <label for="MainContent_txtSearch"> SEARCH:</label> 
				   <asp:TextBox ID="txtSearch" runat="server" CssClass="modalText" autofocus="true" placeholder="Search Outlet"
						Height="16px" Font-Size="10px" Width="150px" ToolTip="Search Outlet"></asp:TextBox>
					<asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
						ToolTip="SEARCH" onclick="imgBtnSearch_Click"  />
				</div>
					</div>
					<div style=" min-height:370px;">
					<asp:GridView ID="gvCustomers" runat="server" DataSourceID="SqlDataSourceOutlets"
						AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
						DataKeyNames="CustNo" CssClass="table_grid" GridLines="None" PageSize="15" 
							onpageindexchanging="gvCustomers_PageIndexChanging" 
							onsorting="gvCustomers_Sorting">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:TemplateField>
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Image ID="imgCustomer" AlternateText='<%# Eval("CustNo") %>' ToolTip='<%# Eval("MainCustNo") %>'
										runat="server" ImageUrl="~/Resources/panels.png" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField>
								<EditItemTemplate>
									<asp:CheckBox ID="CheckBox1" runat="server" />
								</EditItemTemplate>
								<HeaderTemplate>
									<asp:CheckBox ID="chkAll" runat="server" ClientIDMode="Static" onclick="SelectAll('MainContent_gvCustomers','chkAll')" />
								</HeaderTemplate>
								<ItemTemplate>
									<asp:CheckBox ID="chkItems" runat="server" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:BoundField DataField="CompName" HeaderText="OUTLET NAME" 
								SortExpression="CompName" HtmlEncode="False" />
							<asp:BoundField DataField="brand" HeaderText="BRAND" SortExpression="brand" 
								HtmlEncode="False" />
						</Columns>
						<EditRowStyle BackColor="#7C6F57" />
						<EmptyDataTemplate>
							<img src="../Resources/unhappy.png" align ="middle" />
							DATA NOT FOUND!
						</EmptyDataTemplate>
						<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<PagerSettings Mode="NumericFirstLast" />
						<PagerStyle CssClass="pager" />
						<RowStyle BackColor="#E3EAEB" />
						<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
						<SortedAscendingCellStyle BackColor="#F8FAFA" />
						<SortedAscendingHeaderStyle BackColor="#246B61" />
						<SortedDescendingCellStyle BackColor="#D4DFE1" />
						<SortedDescendingHeaderStyle BackColor="#15524A" />
					</asp:GridView>
					<asp:SqlDataSource ID="SqlDataSourceOutlets" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
						SelectCommand="SELECT [CustNo], [CompName], [brand],[MainCustNo] FROM [CustInfoEx] where [MainCustNo] is not null"></asp:SqlDataSource>

					<asp:SqlDataSource ID="SqlDataSourceOutletsByBrand" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
						SelectCommand="SELECT [CustNo], [CompName], [brand],[MainCustNo] FROM [CustInfoEx] WHERE ([brand] = @brand) and [MainCustNo] is not null">
						<SelectParameters>
							<asp:ControlParameter ControlID="DDLBrands" Name="brand" 
								PropertyName="SelectedValue" Type="String" />
						</SelectParameters>
					</asp:SqlDataSource>
					<asp:HiddenField ID="hfIsFiltered" Value="0" runat="server" />
					</div>
					<div style="margin-top: 10px; text-align: center;">
						<asp:Button ID="btnSaveGroup" CssClass="btnSave" runat="server" Text="SAVE" />
						<asp:ModalPopupExtender ID="btnSaveGroup_ModalPopupExtender" runat="server" 
							CancelControlID="btnNo" DynamicServicePath="" Enabled="True" 
							PopupControlID="pnlSaveConformationModal" 
							PopupDragHandleControlID="pnlSaveConfirmationModalDrag" 
							TargetControlID="btnSaveGroup">
							 <Animations>
								<OnShown>
									<FadeIn Duration=".2" />
								</OnShown>
							 </Animations>
						</asp:ModalPopupExtender>
						<a style="text-decoration: none;" href="InventoryGroupingManagementPanel.aspx" title="Cancel Creation and back to Group List">
							<input id="btnCance" class="btnCancel" type="button" value="CANCEL" />
						</a>
					</div>
				</div>
				<div style="float: left; padding: 10px; margin-top: 200px;">
					<div class="modal" style="padding: 10px;">
						<asp:Button ID="btnAddSelected" Width="110px" CssClass="btnAddSelectedRight" runat="server"
							Text="ADD SELECTED" OnClick="btnAddSelected_Click" />
						<br />
						<asp:Button ID="btnRemoveSelected" Width="110px" CssClass="btnRemoveSelectedLeft"
							runat="server" Text="REMOVE SELECTED" OnClick="btnRemoveSelected_Click" />
					</div>
				</div>
				<div class="items-selected" style="float: left; min-height: 300px; min-width: 100px;">
					<div class="modalDrag">
						<div class="sizeLogo">
							SELECTED OUTLET/S</div>
					</div>
					<div style="padding-left: 2px; padding-right: 2px; padding-bottom: 15px;">
						<asp:GridView ID="gvSelectedOutlets" runat="server" CellPadding="4" CssClass="table_grid"
							GridLines="None" AutoGenerateColumns="False">
							<AlternatingRowStyle BackColor="White" />
							<Columns>
								<asp:TemplateField>
									<EditItemTemplate>
										<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
									</EditItemTemplate>
									<ItemTemplate>
										<asp:Image ID="imgCustomer" AlternateText='<%# Eval("CustomerNumber") %>' ToolTip='<%# Eval("AccountName")+"-"+Eval("BranchName") %>'
											runat="server" ImageUrl="~/Resources/panels.png" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField>
									<EditItemTemplate>
										<asp:CheckBox ID="CheckBox1" runat="server" />
									</EditItemTemplate>
									<HeaderTemplate>
										<asp:CheckBox ID="chkAllSelected" runat="server" ClientIDMode="Static" onclick="SelectAll('MainContent_gvSelectedOutlets','chkAllSelected')" />
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="chkSelectedItems" runat="server" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="CustomerName" HeaderText="OUTLET NAME" 
									SortExpression="CustomerName" HtmlEncode="False" />
								<asp:BoundField DataField="BrandName" HeaderText="BRAND" 
									SortExpression="BrandName" HtmlEncode="False" />
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
					</div>
				</div>
			</div>

			<asp:HiddenField ID="hfWarningHandler" runat="server" />
			<asp:ModalPopupExtender ID="hfWarningHandler_ModalPopupExtender" runat="server" 
				DynamicServicePath="" Enabled="True" PopupControlID="pnlWarningModal" 
				PopupDragHandleControlID="pnlWarningModalDrag" 
				TargetControlID="hfWarningHandler" CancelControlID="btnOK">
				 <Animations>
					<OnShown>
						<FadeIn Duration=".2" />
					</OnShown>
				 </Animations>
			</asp:ModalPopupExtender>
		   <%--Save Confirmation Modal--%>
		   <asp:Panel ID="pnlSaveConformationModal" runat="server" CssClass="modal">
			   <asp:Panel ID="pnlSaveConfirmationModalDrag" CssClass ="modalDrag" runat="server">
				<div class="sizeLogo">
					 <img src="../Resources/question.png" align="top" height="16px" />
					 CONFIRMATION!
				</div>
			   </asp:Panel>
			   <div class="modalLabel" style="text-align:center; font-size:12px; padding:10px;">
				<img alt="WAHH!" src="../Resources/question.png" align="middle" />
				 Are you sure you want to save this data?
			   </div>
			   <div style="text-align:center; margin:5px;">
				   <asp:Button ID="btnYes" CssClass="modalWarningButtonYes" runat="server" 
					   Text="YES" onclick="btnYes_Click" />
				   <asp:Button ID="btnNo" CssClass="modalWarningButtonNo" runat="server" Text="NO" />
			   </div>
		   </asp:Panel>

			<asp:Panel ID="pnlWarningModal" CssClass="modal" runat="server">
			<asp:Panel ID="pnlWarningModalDrag" CssClass="modalDrag" runat="server">
			<div class="sizeLogo">
					 <img src="../Resources/warning.png" align="top" height="16px" />
					 CONFIRMATION!
				</div>
			</asp:Panel>
			 <div class="modalLabel" style="text-align:center; font-size:12px; padding:10px;">
				<img src="../Resources/warning.png" align="left" />
				 Unable to add from selection!
				 <br />
				 Some Selected Customer is not yet link to Main Account.
			   </div>
			   <div style="text-align:center; margin:5px;">
				   <asp:Button ID="btnOK" CssClass="modalWarningButtonYes" runat="server" Text="OK" />
			   </div>
		   </asp:Panel> 
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
