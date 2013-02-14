<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
	CodeBehind="InventoryGroupingManagementPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.InventoryGroupingManagementPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
	<link href="../Styles/monthly-soi-report-panel.css" rel="stylesheet" type="text/css" />
	<link href="../Styles/inventory-groups.css" rel="stylesheet" type="text/css" />
	<link href="../Styles/permission-note.css" rel="stylesheet" type="text/css" />
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
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
	<irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<div class="titlePanel">
		<img src="../Resources/invoice.png" height="22px" align="top" />
		Outlet/Customer Inventory Grouping Management Panel
	</div>
	<div style="min-height: 475px;">
		<asp:UpdatePanel ID="upnlInventoryGroup" runat="server">
			<ContentTemplate>
				<div style="height: 26px; margin-bottom: 1px;" class="modalDrag">
					<div class="SearchTextContainer">
						SEARCH:
						<asp:TextBox ID="txtSearch" runat="server" CssClass="modalText" AutoPostBack="True"
							autofocus="true" placeholder="Search Inventory Group" Height="16px" Font-Size="10px"
							Width="150px" ToolTip="Search Adjustment" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
						<asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Resources/search.png"
							ToolTip="SEARCH" OnClick="imgBtnSearch_Click" />
					</div>
					<div style="float: left;">
						<div style="float: left; margin-right: 2px;">
							<a style="text-decoration: none;" href="NewInventoryGroup.aspx" title="NEW INVENTORY GROUP">
								<input id="btnNewInventoryGroup" class="btnNew" type="button" value="NEW" />
							</a>
						</div>
						<div style="float: left; margin-right: 2px;">
							<asp:Button ID="btnUpdateBookAdjustment" runat="server" Text="UPDATE" CssClass="btnUpdate" />
							<asp:ModalPopupExtender ID="btnUpdateBookAdjustment_ModalPopupExtender" runat="server"
								CancelControlID="btnCancelUpdate" DynamicServicePath="" Enabled="True" PopupControlID="pnlUpdateGroupModal"
								PopupDragHandleControlID="pnlUpdateGroupModalDrag" TargetControlID="btnUpdateBookAdjustment">
								<Animations>
									<OnShown>
										<FadeIn Duration=".2" />
									</OnShown>
								</Animations>
							</asp:ModalPopupExtender>
						</div>
						<div style="float: left; margin-right: 2px;">
							<asp:Button ID="btnDelete" runat="server" Text="DELETE" ToolTip="Delete Selected Group"
								CssClass="btnDelete" />
							<asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" CancelControlID="btnDeleteGroupNo"
								DynamicServicePath="" Enabled="True" PopupControlID="pnlDeleteGroupModal" PopupDragHandleControlID="pnlDeleteGroupModalDrag"
								TargetControlID="btnDelete">
								<Animations>
								<OnShown>
									<FadeIn Duration=".2" />
								</OnShown>
								</Animations>
							</asp:ModalPopupExtender>
						</div>
						<div style="float: left; margin-right: 2px;">
							<asp:HyperLink ID="hpLinkPrint" Target="_blank" Height="18px" CssClass="btnPrint"
								runat="server">PRINT</asp:HyperLink>
						</div>
					</div>
					<asp:UpdateProgress ID="uprogressAdjustmentMemo" runat="server" AssociatedUpdatePanelID="upnlInventoryGroup">
						<ProgressTemplate>
							<asp:PlaceHolder ID="plHldrLoader" runat="server">
								<UC:LOADER ID="uprogLoader" runat="server" />
							</asp:PlaceHolder>
						</ProgressTemplate>
					</asp:UpdateProgress>
				</div>
				<div style="float: left;">
					<div class="titleList">
						<img src="../Resources/panels.png" align="top" />
						CUSTOMER INVENTORY GROUP LIST
					</div>
					<asp:GridView ID="gvInventoryGroups" runat="server" AllowPaging="True" AllowSorting="True"
						AutoGenerateColumns="False" CellPadding="4" DataKeyNames="INVENTORY_GROUP_ID"
						DataSourceID="SqlDataSourceInventoryGroups" CssClass="table_grid" GridLines="None"
						OnSelectedIndexChanged="gvInventoryGroups_SelectedIndexChanged">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:TemplateField>
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/panels.png" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:CommandField ShowSelectButton="True" />
							<asp:BoundField DataField="INVENTORY_GROUP_ID" HeaderText="GROUP#" InsertVisible="False"
								ReadOnly="True" SortExpression="INVENTORY_GROUP_ID">
								<ItemStyle Font-Bold="True" HorizontalAlign="Left" />
							</asp:BoundField>
							<asp:BoundField DataField="GROUP_NAME" HeaderText="GROUP NAME" SortExpression="GROUP_NAME" />
						</Columns>
						<EditRowStyle BackColor="#7C6F57" />
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
					<asp:SqlDataSource ID="SqlDataSourceInventoryGroups" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
						SelectCommand="SELECT * FROM [INVENTORY_GROUPS] order by INVENTORY_GROUP_ID DESC">
					</asp:SqlDataSource>
				</div>
				<div style="float: left; margin-left: 5px;">
					<div class="modalDrag">
						<div class="sizeLogo">
							LIST OF CUSTOMERS</div>
						<div style="float: right; margin-left: 5px;">
							<asp:Button ID="btnReloadCustomerList" Height="24px" runat="server" CssClass="btnReload"
								Text="Reload" OnClick="btnReloadCustomerList_Click" />
							<asp:HyperLink ID="hpLinkAddCustomer" runat="server">
						<input id="btnAddCustomer" title="Add new Customer to Group" class="btnAddRemoveCustomer" type="button" value="+" />
							</asp:HyperLink>
							<asp:Button ID="btnDeleteFromGroup" title="Delete Selected Customer from the Group"
								CssClass="btnAddRemoveCustomer" runat="server" Text="-" />
							<asp:ModalPopupExtender ID="btnDeleteFromGroup_ModalPopupExtender" runat="server"
								CancelControlID="btnDeleteCustomerCancel" DynamicServicePath="" Enabled="True"
								PopupControlID="pnlDeleteCustomerFromGroupModal" PopupDragHandleControlID="pnlDeleteCustomerFromGroupModalDrag"
								TargetControlID="btnDeleteFromGroup">
								<Animations>
									<OnShown>
										<FadeIn Duration=".2" />
									</OnShown>
								</Animations>
							</asp:ModalPopupExtender>
							<asp:Button ID="btnChangeGroup" title="Change Group" CssClass="btnAddRemoveCustomer"
								runat="server" Text="Change Group" />
							<asp:ModalPopupExtender ID="btnChangeGroup_ModalPopupExtender" runat="server" CancelControlID="btnCancelGroupChange"
								DynamicServicePath="" Enabled="True" PopupControlID="pnlChangeGroupModal" PopupDragHandleControlID="pnlChangeGroupModalDrag"
								TargetControlID="btnChangeGroup">
								<Animations>
									<OnShown>
										<FadeIn Duration=".2" />
									</OnShown>
								</Animations>
							</asp:ModalPopupExtender>
							<asp:Button ID="btnSearch" title="Search Customer" CssClass="btnSearch" runat="server"
								Text="SEARCH" />
							<asp:ModalPopupExtender ID="btnSearch_ModalPopupExtender" runat="server" DynamicServicePath=""
								Enabled="True" TargetControlID="btnSearch" CancelControlID="imgBtnClosepnlSearchModal"
								PopupControlID="pnlSearchModal" PopupDragHandleControlID="pnlSearchModalDrag">
								<Animations>
									<OnShown>
										<FadeIn Duration=".2" />
									</OnShown>
								</Animations>
							</asp:ModalPopupExtender>
						</div>
					</div>
					<asp:GridView ID="gvCustomerList" runat="server" AllowPaging="True" AllowSorting="True"
						AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSourceCustomerInventoryGroups"
						CssClass="table_grid" GridLines="None" OnPageIndexChanging="gvCustomerList_PageIndexChanging"
						OnSorting="gvCustomerList_Sorting" PageSize="13">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:TemplateField>
								<EditItemTemplate>
									<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
								</EditItemTemplate>
								<ItemTemplate>
									<asp:Image ID="imgCustomer" AlternateText='<%#Eval("ID") %>' ToolTip='<%#Eval("ACCOUNT_NAME")+"-"+ Eval("BRANCH_NAME") %>'
										runat="server" ImageUrl="~/Resources/panels.png" Height="16px" />
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="ID">
								<EditItemTemplate>
									<asp:CheckBox ID="CheckBox1" runat="server" />
								</EditItemTemplate>
								<HeaderTemplate>
									<asp:CheckBox ID="chkAll" runat="server" ClientIDMode="Static" onclick="SelectAll('MainContent_gvCustomerList','chkAll')" />
								</HeaderTemplate>
								<ItemTemplate>
									<asp:CheckBox ID="chkItems" runat="server" />
								</ItemTemplate>
								<ItemStyle Font-Size="11px" />
							</asp:TemplateField>
							<asp:BoundField DataField="CUSTOMER_NUMBER" HeaderText="CUSTOMER#" SortExpression="CUSTOMER_NUMBER">
								<ItemStyle Font-Bold="True" HorizontalAlign="Center" />
							</asp:BoundField>
							<asp:BoundField DataField="CUSTOMER_NAME" HeaderText="CUSTOMER_NAME" SortExpression="CUSTOMER_NAME"
								HtmlEncode="False" />
							<asp:BoundField DataField="BRAND_NAME" HeaderText="BRAND_NAME" SortExpression="BRAND_NAME"
								HtmlEncode="False" />
						</Columns>
						<EditRowStyle BackColor="#7C6F57" />
						<EmptyDataTemplate>
							<img src="../Resources/unhappy.png" align="middle" />
							DATA NOT FOUND!
						</EmptyDataTemplate>
						<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<PagerSettings Mode="NumericFirstLast" />
						<PagerStyle CssClass="pager" />
						<RowStyle BackColor="#E3EAEB" />
						<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
						<SortedAscendingCellStyle CssClass="asc_cell_style" />
						<SortedAscendingHeaderStyle CssClass="asc_cell_style_h" />
						<SortedDescendingCellStyle CssClass="desc_cell_style" />
						<SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
					</asp:GridView>
					<asp:SqlDataSource ID="SqlDataSourceCustomerInventoryGroups" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
						SelectCommand="SELECT [ID], [CUSTOMER_NUMBER], [CUSTOMER_NAME], [BRAND_NAME],[ACCOUNT_NAME],[BRANCH_NAME] FROM [CUSTOMER_INVENTORY_GROUPS] WHERE ([INVENTORY_GROUP_ID] =@INVENTORY_GROUP_ID)">
						<SelectParameters>
							<asp:ControlParameter ControlID="gvInventoryGroups" Name="INVENTORY_GROUP_ID" PropertyName="SelectedValue"
								Type="Int64" />
						</SelectParameters>
					</asp:SqlDataSource>
				</div>
				<%--Search Customer Modal Start--%>
				<asp:Panel ID="pnlSearchModal" runat="server" CssClass="modal">
					<asp:Panel ID="pnlSearchModalDrag" runat="server" CssClass="modalDrag">
						<div class="sizeLogo">
							<img src="../Resources/advance_search.png" align="top" />
							Search Customer
						</div>
						<div class="close_btn">
							<asp:ImageButton ID="imgBtnClosepnlSearchModal" runat="server" CssClass="btnClose"
								ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
						</div>
					</asp:Panel>
					<div style="padding: 5px;">
						<label class="modalLabel" for="MainContent_txtSearcCustomer">
							SEARCH:</label>
						<asp:TextBox ID="txtSearchCustomer" CssClass="modalText" Height="18px" runat="server"></asp:TextBox>
					</div>
					<div style="padding-bottom: 5px; text-align: center;">
						<asp:Button ID="btnSearchCustomer" CssClass="btnSearch" runat="server" Text="GO"
							OnClick="btnSearchCustomer_Click" />
					</div>
				</asp:Panel>
				<%--Search Customer Modal End--%>
				<%--Change Group Modal Start--%>
				<asp:Panel ID="pnlChangeGroupModal" runat="server" CssClass="modal">
					<asp:Panel ID="pnlChangeGroupModalDrag" CssClass="modalDrag" runat="server">
						<div class="sizeLogo">
							<img src="../Resources/panels.png" height="16px" align="top" />
							Change Group
						</div>
					</asp:Panel>
					<div style="padding: 5px;">
						<label class="modalLabel">
							FROM GROUP:</label>
						<asp:TextBox ID="txtFromGroup" CssClass="modalText" ReadOnly="true" Height="18px"
							runat="server"></asp:TextBox>
					</div>
					<div style="padding-left: 23px; padding-right: 5px; padding-bottom: 5px;">
						<label class="modalLabel">
							TO GROUP:</label>
						<asp:DropDownList ID="DDLInvventoryGroups" CssClass="modalText" Height="20px" runat="server">
						</asp:DropDownList>
					</div>
					<div style="text-align: center; margin: 5px;">
						<asp:Button ID="btnChangeGroupSave" CssClass="btnSave" runat="server" Width="120px"
							Text="SAVE CHANGES" OnClick="btnChangeGroupSave_Click" />
						<asp:Button ID="btnCancelGroupChange" CssClass="btnCancel" runat="server" Text="CANCEL" />
					</div>
				</asp:Panel>
				<%--Change Group Modal Start--%>
				<%--Delete Customer Modal Start--%>
				<asp:Panel ID="pnlDeleteCustomerFromGroupModal" CssClass="modal" runat="server">
					<asp:Panel CssClass="modalDrag" ID="pnlDeleteCustomerFromGroupModalDrag" runat="server">
						<div class="sizeLogo">
							<img src="../Resources/warning.png" align="top" height="18px" />
							CONFIRMATION!
						</div>
					</asp:Panel>
					<div class="modalLabel" style="text-align: center; margin: 5px; font-size: 12px;">
						Are you sure you want to delete
						<br />
						selected Customer to the group?
					</div>
					<div style="margin: 5px; text-align: center;">
						<asp:Button ID="btnDeleteCustomer" CssClass="modalWarningButtonYes" runat="server"
							Text="YES" OnClick="btnDeleteCustomer_Click" />
						<asp:Button ID="btnDeleteCustomerCancel" CssClass="modalWarningButtonNo" runat="server"
							Text="NO" />
					</div>
				</asp:Panel>
				<%--Delete Customer Modal End--%>
				<%--Delete Group Modal Start--%>
				<asp:Panel ID="pnlDeleteGroupModal" CssClass="modal" runat="server">
					<asp:Panel CssClass="modalDrag" ID="pnlDeleteGroupModalDrag" runat="server">
						<div class="sizeLogo">
							<img src="../Resources/warning.png" align="top" height="18px" />
							CONFIRMATION!
						</div>
					</asp:Panel>
					<div class="modalLabel table_grid" style="text-align: center; margin: 5px; font-size: 12px;">
						Are you sure you want to
						<br />
						delete selected group?
					</div>
					<div style="margin: 5px; text-align: center;">
						<asp:Button ID="btnDeleteGroupYes" CssClass="modalWarningButtonYes" runat="server"
							Text="YES" OnClick="btnDeleteGroupYes_Click" />
						<asp:Button ID="btnDeleteGroupNo" CssClass="modalWarningButtonNo" runat="server"
							Text="NO" />
					</div>
				</asp:Panel>
				<%--Delete Group Modal End--%>
				<%--Update Group Modal Start--%>
				<asp:Panel ID="pnlUpdateGroupModal" runat="server" CssClass="modal">
					<asp:Panel ID="pnlUpdateGroupModalDrag" CssClass="modalDrag" runat="server">
						<div class="sizeLogo">
							<img src="../Resources/panels.png" height="16px" align="top" />
							Update Group
						</div>
					</asp:Panel>
					<div style="padding: 5px;">
						<label class="modalLabel">
							GROUP NAME:</label>
						<asp:HiddenField ID="hfGroupIdToUpdate" runat="server" />
						<asp:TextBox ID="txtGroupToUpdate" CssClass="modalText" Height="18px" runat="server"></asp:TextBox>
					</div>
					<div style="text-align: center; margin: 5px;">
						<asp:Button ID="btnSaveUpdate" CssClass="btnSave" runat="server" Text="SAVE" OnClick="btnSaveUpdate_Click" />
						<asp:Button ID="btnCancelUpdate" CssClass="btnCancel" runat="server" Text="CANCEL" />
					</div>
				</asp:Panel>
				<%--Update Group Modal Start--%>
				<asp:Panel CssClass="permission-container" ID="pnlNotification" Visible="false" runat="server">
					<asp:CollapsiblePanelExtender ID="CollapsiblePaneItemMaster" runat="server" CollapseControlID="lblNoteCollapsHandler"
						CollapsedText="dennis" ExpandedText="pitallano" TargetControlID="pnlPermissionNotification"
						ExpandControlID="lblNoteCollapsHandler" Collapsed="True">
					</asp:CollapsiblePanelExtender>
					<div class="collaps-link">
						<asp:Label CssClass="collaps-text" ID="lblNoteCollapsHandler" Height="48px" runat="server"
							Text="NOTE" ToolTip="Show/Hide Notification"></asp:Label>
					</div>
					<asp:Panel CssClass="note-container" ID="pnlPermissionNotification" runat="server">
						<asp:Label ID="lblPermissionNotifications" runat="server" Text="Label"></asp:Label>
					</asp:Panel>
				</asp:Panel>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
</asp:Content>
