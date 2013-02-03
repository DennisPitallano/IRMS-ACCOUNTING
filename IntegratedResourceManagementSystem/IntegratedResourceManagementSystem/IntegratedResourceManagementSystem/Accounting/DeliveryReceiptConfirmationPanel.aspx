<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true"
	CodeBehind="DeliveryReceiptConfirmationPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.DeliveryReceiptConfirmationPanel" %>

<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Accounting/controls/UCLoader.ascx" TagName="LOADER" TagPrefix="UC" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
	<link href="../Styles/dr-confirmation.css" rel="stylesheet" type="text/css" />
	<script src="../Scripts/jquery-1.7.2.js" type="text/javascript"></script>
	<link href="../Styles/permission-note.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
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
		<img src="../Resources/panels.png" align="top" />
		Manage Delivery Receipt Confirmations
	</div>
	<asp:UpdatePanel ID="upnlDR" runat="server">
		<ContentTemplate>
			<div style="margin-bottom: 1px; height: 32px;" class="modalDrag">
				<asp:Label ID="Label1" runat="server"></asp:Label>
				<asp:ModalPopupExtender ID="btnPreviewSelectedDRForcancel_ModalPopupExtender" runat="server"
					DynamicServicePath="" Enabled="True" TargetControlID="Label1" PopupControlID="pnlSelectedDRPreview"
					PopupDragHandleControlID="pnlSelectedDRPreviewDrag" BackgroundCssClass="bgModal"
					CancelControlID="imgBtnClosepnlSelectedDRPreview">
					<Animations>
						<OnShown>
							<FadeIn Duration=".2" />
						</OnShown>
					</Animations>
				</asp:ModalPopupExtender>
				<div style="float: left; height: 32px; margin-right: 2px;">
					<asp:Button ID="btnConfirmedDR" Height="30px" runat="server" OnClick="btnCancelSelectedDR_Click"
						Text="CONFIRM DR" CssClass="btnCancelDR" Width="85px" />
				</div>
				<div style="float: left; height: 32px;">
					<asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass="btnPrint" Height="30px" />
					<asp:ModalPopupExtender ID="btnPrint_ModalPopupExtender" runat="server" DynamicServicePath=""
						Enabled="True" TargetControlID="btnPrint" CancelControlID="ibtnClosepnlPrintOptionModal"
						PopupControlID="pnlPrintOptionModal" PopupDragHandleControlID="pnlPrintOptionModalDrag"
						BackgroundCssClass="bgModal">
						<Animations>
								<OnShown>
									<FadeIn Duration=".2"/>
								</OnShown>
						</Animations>
					</asp:ModalPopupExtender>
				</div>
				<div style="float: left; height: 32px; margin-left: 2px;">
					<asp:HyperLink ID="hpLinkPreviewDetails" Target="_blank" Height="28px" CssClass="btnPrint"
						runat="server">PREVIEW DETAILS</asp:HyperLink>
				</div>
				<div style="float: left;">
					<div class="SearchTextContainer" style="float: right;">
						<asp:Label ID="lblFiter" runat="server" Text="FILTER:" Font-Names="Verdana" Font-Size="11px"></asp:Label>
						<asp:RadioButtonList ID="rdioFilterView" CssClass="filterOption" runat="server" Font-Names="Verdana"
							Font-Size="11px" ForeColor="#993300" RepeatDirection="Horizontal" RepeatLayout="Flow"
							AutoPostBack="True" OnSelectedIndexChanged="rdioFilterView_SelectedIndexChanged">
							<asp:ListItem Value="In Transit" Selected="True">IN TRANSIT</asp:ListItem>
							<asp:ListItem Value="Confirmed">CONFIRMED</asp:ListItem>
						</asp:RadioButtonList>
						|
						<asp:Label ID="lblSearchByOption" runat="server" Text="Search By:" Font-Names="Verdana"
							Font-Size="11px" CssClass="search_option"></asp:Label>
						<asp:HoverMenuExtender ID="lblSearchByOption_HoverMenuExtender" runat="server" DynamicServicePath=""
							Enabled="True" TargetControlID="lblSearchByOption" PopupControlID="pnlSearchByOption"
							PopupPosition="Bottom">
						</asp:HoverMenuExtender>
						<asp:Panel ID="pnlSearchByOption" runat="server" CssClass="modalDrag">
							<asp:RadioButtonList ID="rdioSearchBy" CssClass="modalLabel" runat="server" RepeatDirection="Horizontal"
								RepeatLayout="Flow" Font-Names="Verdana" Font-Size="11px">
								<asp:ListItem Selected="True" Value="DR">DR#</asp:ListItem>
								<asp:ListItem>CUSTOMER</asp:ListItem>
							</asp:RadioButtonList>
						</asp:Panel>
						<asp:TextBox ID="txtSearchDR" runat="server" CssClass="modalText" Width="140px" Height="18px"></asp:TextBox>
						<asp:ImageButton ID="imgBtnSearchDR" runat="server" ImageAlign="Top" ImageUrl="~/Resources/search.png"
							ToolTip="Search Delivery Receipt" OnClick="imgBtnSearchDR_Click" />
						<asp:ImageButton ID="ibtnEnableDate" runat="server" ImageAlign="Middle" ImageUrl="~/Resources/calendar-icon.png"
							ToolTip="Enable Date Range" Height="16px" />
						<asp:ModalPopupExtender ID="ibtnEnableDate_ModalPopupExtender" runat="server" DynamicServicePath=""
							Enabled="True" TargetControlID="ibtnEnableDate" PopupControlID="pnlAdvanceSearch"
							PopupDragHandleControlID="pnlAdvanceSearchDrag" CancelControlID="ibtnCloseAdvanceSearch">
						</asp:ModalPopupExtender>
						<asp:Panel ID="pnlAdvanceSearch" runat="server" CssClass="modal">
							<asp:Panel ID="pnlAdvanceSearchDrag" runat="server" CssClass="modalDrag">
								<div class="close_btn">
									<asp:ImageButton ID="ibtnCloseAdvanceSearch" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
										ToolTip="CLOSE" />
								</div>
								<div class="sizeLogo" style="-webkit-text-shadow: 1px 1px 1px  gray; -moz-text-shadow: 1px 1px 1px  gray;
									text-shadow: 1px 1px 1px  gray;">
									<img alt="" src="../Resources/panels.png" height="16px" align="top" />
									INCLUDE DATE RANGE SEARCH OPTION!
								</div>
							</asp:Panel>
							<div style="margin: 5px 3px 15px 15px;">
								<asp:Label ID="lblDateRange" runat="server" Text="DATE:" Font-Names="Verdana" ForeColor="#FFCC66"
									Font-Size="12px"></asp:Label>
								<asp:Label ID="lblCompanyFrom" runat="server" Text="FROM" Font-Names="Verdana" ForeColor="#FFFFCC"
									Font-Size="11px"></asp:Label>
								<asp:TextBox ID="txtDateSeachFrom" runat="server" Font-Names="Verdana" Font-Size="11px"
									Height="20px"></asp:TextBox>
								<asp:CalendarExtender ID="txtDateSeachFrom_CalendarExtender" runat="server" Enabled="True"
									TargetControlID="txtDateSeachFrom" Format="MMMM dd, yyyy">
								</asp:CalendarExtender>
								<br />
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
									ID="lblCompany_To" runat="server" Text="TO" Font-Names="Verdana" ForeColor="#FFFFCC"
									Font-Size="11px"></asp:Label>
								<asp:TextBox ID="txtDateSeachTo" runat="server" Font-Names="Verdana" Font-Size="11px"
									Height="20px"></asp:TextBox>
								<asp:CalendarExtender ID="txtDateSeachTo_CalendarExtender" runat="server" Enabled="True"
									TargetControlID="txtDateSeachTo" Format="MMMM dd, yyyy">
								</asp:CalendarExtender>
								<br />
								<br />
								<div style="text-align: center;">
									<asp:Button ID="btnGo" runat="server" Text="GO" OnClick="btnGo_Click" CssClass="modalWarningButtonYes" />
									<asp:RoundedCornersExtender ID="btnGo_RoundedCornersExtender" runat="server" BorderColor="LightGray"
										Enabled="True" TargetControlID="btnGo">
									</asp:RoundedCornersExtender>
								</div>
							</div>
						</asp:Panel>
						<asp:DropShadowExtender ID="pnlAdvanceSearch_DropShadowExtender" runat="server" Enabled="True"
							Opacity="0.75" TargetControlID="pnlAdvanceSearch">
						</asp:DropShadowExtender>
					</div>
				</div>
				<div style="float: left; height: 32px; margin-left: 5px;">
					<asp:UpdateProgress ID="upDeliveryReceiptsSlip" runat="server" AssociatedUpdatePanelID="upnlDR"
						DisplayAfter="100">
						<ProgressTemplate>
							<asp:PlaceHolder ID="plcHldrLoader" runat="server">
								<UC:LOADER ID="loader" runat="server" />
							</asp:PlaceHolder>
						</ProgressTemplate>
					</asp:UpdateProgress>
				</div>
				<div style="float: left; height: 32px; margin-left: 8px;">
					<div style="display: block;">
						<asp:Label ID="lblSetDisplay" runat="server" Font-Names="Verdana" Font-Size="10px"
							Font-Italic="True" ForeColor="#FFFFCC"></asp:Label></div>
					<asp:DropDownList ID="dlPageDisplaySize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlPageDisplaySize_SelectedIndexChanged"
						Font-Names="Verdana" Font-Size="10px" ForeColor="#CC6600" Height="20px">
						<asp:ListItem Value="13">DEFAULT</asp:ListItem>
						<asp:ListItem>20</asp:ListItem>
						<asp:ListItem>25</asp:ListItem>
						<asp:ListItem>50</asp:ListItem>
						<asp:ListItem>75</asp:ListItem>
						<asp:ListItem>100</asp:ListItem>
						<asp:ListItem>150</asp:ListItem>
						<asp:ListItem>250</asp:ListItem>
						<asp:ListItem>500</asp:ListItem>
						<asp:ListItem>1000</asp:ListItem>
					</asp:DropDownList>
				</div>
			</div>
			<div style="">
				<asp:Panel ID="pnlDeliveriesData" runat="server" Width="850px" CssClass="dr_details">
					<div class="titleList">
						<img src="../Resources/invoice.png" height="16px" align="top" />
						LIST OF DR
					</div>
					<asp:Panel ID="pnlDeliveryReceipt" runat="server">
						<asp:GridView ID="gvDeliveryReceipts" runat="server" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID,WayBillNo,Forwarder,ConfirmedDate"
							DataSourceID="SqlDataSourceDeliveryReceipt" CssClass="table_grid" GridLines="Horizontal"
							EnablePersistedSelection="True" OnSelectedIndexChanged="gvDeliveryReceipts_SelectedIndexChanged"
							PageSize="12" OnPageIndexChanging="gvDeliveryReceipts_PageIndexChanging">
							<AlternatingRowStyle BackColor="White" />
							<Columns>
								<asp:TemplateField>
									<EditItemTemplate>
										<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
									</EditItemTemplate>
									<ItemTemplate>
										<asp:Image ID="imgDetails" runat="server" ImageUrl="~/Resources/panels.png" Height="18"
											ToolTip='  <%# Eval("ID")  %>' AlternateText='<%# Eval("Forwarder") +"-"+ Eval("WayBillNo") %>' />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField>
									<EditItemTemplate>
										<asp:CheckBox ID="CheckBox1" runat="server" />
									</EditItemTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="chkID" runat="server" />
									</ItemTemplate>
									<HeaderStyle Wrap="False" />
									<HeaderTemplate>
										<asp:CheckBox ID="chkAll" runat="server" ClientIDMode="Static" onclick="SelectAll('MainContent_gvDeliveryReceipts','chkAll')" />
									</HeaderTemplate>
									<ItemStyle Font-Bold="True" ForeColor="#CC6600" HorizontalAlign="Center" Wrap="False" />
								</asp:TemplateField>
								<asp:CommandField ShowSelectButton="True" />
								<asp:BoundField DataField="DRNo" HeaderText="DR NUMBER" SortExpression="DRNo">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="DRDate" DataFormatString="{0:MMMM dd, yyyy}" HeaderText="DR DATE"
									SortExpression="DRDate">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="CustNo" HeaderText="CUSTOMER #" SortExpression="CustNo"
									Visible="False">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="DeliveredTo" HeaderText="DELIVERED TO" SortExpression="DeliveredTo"
									HtmlEncode="False">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="TotalQty" HeaderText="TOTAL QTY" SortExpression="TotalQty">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="TotalAmt" DataFormatString="{0:Php###,###.00}" HeaderText="TOTAL AMOUNT"
									SortExpression="TotalAmt">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
								<asp:BoundField DataField="ItemStatus" HeaderText="STATUS" SortExpression="ItemStatus" />
								<asp:BoundField DataField="PLNo" HeaderText="PL #" SortExpression="PLNo" HtmlEncode="False"
									HtmlEncodeFormatString="False">
									<HeaderStyle Wrap="False" />
									<ItemStyle Wrap="False" />
								</asp:BoundField>
							</Columns>
							<EditRowStyle BackColor="#7C6F57" />
							<EmptyDataTemplate>
								<div style="width: 700px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
									line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
									<img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
									DATA NOT FOUND!!!
								</div>
							</EmptyDataTemplate>
							<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<PagerSettings PageButtonCount="20" FirstPageImageUrl="~/Resources/first.png" LastPageImageUrl="~/Resources/last.png"
								Mode="NumericFirstLast" />
							<PagerStyle CssClass="pager" />
							<RowStyle BackColor="#E3EAEB" />
							<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
							<SortedAscendingCellStyle CssClass="asc_cell_style" />
							<SortedAscendingHeaderStyle CssClass="asc_cell_style_h" />
							<SortedDescendingCellStyle CssClass="desc_cell_style" />
							<SortedDescendingHeaderStyle CssClass="desc_cell_style_h" />
						</asp:GridView>
						<asp:SqlDataSource ID="SqlDataSourceDeliveryReceipt" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
							SelectCommand="SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],ConfirmedDate,WayBillNo,Forwarder FROM [DR] where  ( ynPosted=1 and ConfirmedDate is null or TransitStatus='In Transit') ORDER BY DRDate DESC"
							CacheDuration="5" EnableCaching="True"></asp:SqlDataSource>
					</asp:Panel>
				</asp:Panel>

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

			</div>
			<asp:Label ID="lblSaved" runat="server" Text=""></asp:Label>
			<asp:ModalPopupExtender ID="lblSaved_ModalPopupExtender" runat="server" DynamicServicePath=""
				Enabled="True" PopupControlID="pnlSaved" PopupDragHandleControlID="pnlSavedDrag"
				TargetControlID="lblSaved" BackgroundCssClass="bgModal">
			</asp:ModalPopupExtender>
			<asp:Panel ID="pnlSaved" runat="server" CssClass="modal" Width="250px">
				<asp:Panel ID="pnlSavedDrag" runat="server" CssClass="modalDrag">
					<div class="sizeLogo">
						<img alt="" src="../Resources/panels.png" height="16px" align="top" />
						Delivery Receipts
					</div>
				</asp:Panel>
				<div class="modalLabel" style=" font-size:12px; text-align: center; padding: 5px 30px;">
					Selected Delivery Receipt/s Successfully Confirmed!
				</div>
				<div style="text-align: center; margin: 5px 0px;">
					<asp:Button ID="btnOk" runat="server" Text="OK" CssClass="modalWarningButtonYes" />
				</div>
			</asp:Panel>
			<asp:Panel ID="pnlSelectedDRPreview" runat="server" CssClass="modal">
				<asp:Panel ID="pnlSelectedDRPreviewDrag" runat="server" CssClass="modalDrag">
					<div class="close_btn">
						<asp:ImageButton ID="imgBtnClosepnlSelectedDRPreview" runat="server" CssClass="btnClose"
							ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
					</div>
					<div class="sizeLogo" style="">
						<img src="../Resources/panels.png" height="16px" alt="" align="top" />
						Preview Delivery Receipt to Confirm.
					</div>
				</asp:Panel>
				<div style="text-align: center; margin: 5px;">
					<label class="modalText" style="font-style: italic;">
						UNCHECK TO EXCLUDE</label>
				</div>
				<div style="margin-left: 10px; margin-right: 10px;">
					<asp:GridView ID="gvPreviewSelectedDR" CssClass="table_grid modalText" runat="server"
						AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="10px">
						<Columns>
							<asp:BoundField DataField="DeliveryReceiptNumber" HeaderText="DR NUMBER">
								<HeaderStyle Wrap="False" />
								<ItemStyle Wrap="False" />
							</asp:BoundField>
							<asp:BoundField DataField="DeliveredTo" HeaderText="CUSTOMER">
								<HeaderStyle Wrap="False" />
								<ItemStyle Wrap="False" />
							</asp:BoundField>
							<asp:BoundField DataField="DRDate" HeaderText="DR DATE" DataFormatString="{0:MMMM dd, yyyy}">
								<HeaderStyle Wrap="False" />
								<ItemStyle Wrap="False" />
							</asp:BoundField>
							<asp:BoundField DataField="PLNumber" HeaderText="PL NUMBER" HtmlEncode="False">
								<HeaderStyle Wrap="False" />
								<ItemStyle Wrap="False" />
							</asp:BoundField>
							<asp:BoundField DataField="Forwarder" HeaderText="FORWARDER" />
							<asp:BoundField DataField="WayBillNumber" HeaderText="WAYBILL#" />
							<asp:TemplateField>
								<EditItemTemplate>
									<asp:CheckBox ID="CheckBox1" runat="server" />
								</EditItemTemplate>
								<ItemTemplate>
									<asp:CheckBox ID="chkSelectedDRTCancelled" runat="server" Checked="true" ToolTip='<%# Eval("RecordNo") %>' />
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</div>
				<div style="margin-left: 10px; margin-top: 10px; margin-right:5px;">
					<div style="margin-bottom: 3px; margin-left: 10px;">
						<asp:CheckBox Height="20px" Font-Size="9px" Font-Bold="true" Font-Italic="true" ID="chkCustomForwarderWayBillNumber"
							CssClass="modalText" Text="Customize Forwarder & WayBill Number" runat="server"
							AutoPostBack="True" OnCheckedChanged="chkCustomForwarderWayBillNumber_CheckedChanged" />
					</div>
					
					<asp:Panel ID="pnlForwarderWayBill" Visible="false" CssClass="form" runat="server">
						<table cellpadding="0">
							<tr>
								<td class="modalLabel">
									WAYBILL#:
								</td>
								<td>
									<asp:TextBox ID="txtWayBillNumber" runat="server" CssClass="modalText" Height="20px"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="modalLabel">
									FORWARDER:
								</td>
								<td>
									<asp:DropDownList ID="dlForwarders" runat="server" Font-Names="Verdana" CssClass="modalText"
										Font-Size="11px" Height="20px">
									</asp:DropDownList>
								</td>
							</tr>
						</table>
					</asp:Panel>
					<div style="margin: 5px; text-align:center;">
						<label class="modalLabel" for="MainContent_txtConfirmationDate">
							CONFIRMATION DATE:</label>
						<asp:TextBox ID="txtConfirmationDate" runat="server" Height="20px" Width="150px"
							CssClass="modalText"></asp:TextBox>
						<asp:CalendarExtender ID="txtConfirmationDate_CalendarExtender" runat="server" Enabled="True"
							Format="MMMM dd, yyyy" TargetControlID="txtConfirmationDate">
						</asp:CalendarExtender>
					</div>
				</div>
				<div style=" text-align:center; margin-top: 5px; margin-bottom: 5px;">
					<asp:Button ID="btnContinueDRConfirmation" runat="server" Text="CONTINUE CONFIRMATION"
						CssClass="modalWarningButtonYes" Font-Names="Verdana" Font-Size="10px" OnClick="btnContinueDRConfirmation_Click"
						Width="180px" />
				</div>
			</asp:Panel>
			<asp:Panel ID="pnlPrintOptionModal" runat="server" CssClass="modal" Width="480px">
				<asp:Panel ID="pnlPrintOptionModalDrag" runat="server" CssClass="modalDrag">
					<div class="close_btn">
						<asp:ImageButton ID="ibtnClosepnlPrintOptionModal" runat="server" CssClass="btnClose"
							ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE" />
					</div>
					<div class="sizeLogo">
						<img src="../Resources/panels.png" alt="dr" align="top" height="16px" />
						Delivery Receipt Print Option.
					</div>
				</asp:Panel>
				<div style="background-color: #FFFFCC; border: 1px solid #FFCC66; padding: 3px 5px 2px 5px;">
					<asp:Label ID="Label11" runat="server" Text="Select DR Status:" Font-Names="Verdana"
						Font-Size="11px"></asp:Label>
					<asp:RadioButtonList ID="rdioLstPritnOption" runat="server" AutoPostBack="True" Font-Names="Verdana"
						Font-Size="11px" OnSelectedIndexChanged="rdioLstPritnOption_SelectedIndexChanged"
						RepeatDirection="Horizontal" RepeatLayout="Flow">
						<asp:ListItem Selected="True">CONFIRMED</asp:ListItem>
						<asp:ListItem>IN-TRANSIT</asp:ListItem>
					</asp:RadioButtonList>
				</div>
				<asp:MultiView ID="mvPrintOption" runat="server" ActiveViewIndex="1">
					<asp:View ID="vprintOptionConfirmed" runat="server">
						<div style="background-color: #ffffff; padding: 5px 5px 5px 10px; margin: 2px 5px 5px 5px 2px;">
							<div style="margin-bottom: 3px;">
								<asp:Panel ID="pnlIntransitDateRange" runat="server">
									<asp:Label ID="Label8" runat="server" Text="DATE FROM:" Font-Names="Verdana" Font-Size="11px"></asp:Label>
									<asp:TextBox ID="txtInTransitDateRangeFrom" runat="server" Font-Names="Verdana" Font-Size="11px"
										Width="120px" Enabled="False"></asp:TextBox>
									<asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtInTransitDateRangeFrom"
										Format="MMMM dd, yyyy">
									</asp:CalendarExtender>
									<asp:Label ID="Label9" runat="server" Text="TO" Font-Names="Verdana" Font-Size="11px"></asp:Label>
									<asp:TextBox ID="txtInTransitDateRangeTo" runat="server" Font-Names="Verdana" Font-Size="11px"
										Width="120px" Enabled="False"></asp:TextBox>
									<asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtInTransitDateRangeTo"
										Format="MMMM dd, yyyy">
									</asp:CalendarExtender>
									<asp:CheckBox ID="chkIntransitDRIncludeDateRange" runat="server" Text="Use Date Range"
										Font-Names="Verdana" Font-Size="9px" AutoPostBack="True" OnCheckedChanged="chkIntransitDRIncludeDateRange_CheckedChanged" />
								</asp:Panel>
							</div>
							<hr />
							<asp:Label ID="Label7" runat="server" Text="Generate Report by Brand" Font-Italic="True"
								Font-Names="Verdana" Font-Size="11px"></asp:Label>
							<br />
							<div style="margin-top: 15px;">
								<asp:Label ID="Label2" runat="server" Text="BRAND:"></asp:Label>
								<asp:DropDownList ID="dlBrands" runat="server" Font-Size="11px" CssClass="modalText"
									Height="20px">
								</asp:DropDownList>
								<asp:ListSearchExtender ID="dlBrands_ListSearchExtender" runat="server" Enabled="True"
									TargetControlID="dlBrands">
								</asp:ListSearchExtender>
							</div>
							<div style="text-align: center; height: 20px; margin-bottom: 10px; margin-top: 5px;">
								<asp:Button ID="btnGgenerateReportByBrand" runat="server" Text="PRINT IN-TRANSIT"
									CssClass="btnPrint" Font-Names="Verdana" Font-Size="11px" Width="150px" OnClick="btnGgenerateReportByBrand_Click" />
							</div>
						</div>
					</asp:View>
					<asp:View ID="vprintOptionInTransit" runat="server">
						<div style="background-color: #ffffff; padding: 5px 5px 5px 10px; margin: 2px 5px 5px 5px 2px;">
							<div style="margin-bottom: 5px;">
								<asp:Panel ID="pnlConfirmedDRDateRange" runat="server">
									<asp:Label ID="Label4" runat="server" Text="DATE FROM:" Font-Names="Verdana" Font-Size="11px"></asp:Label>
									<asp:TextBox ID="txtConfirmedDateRangeFrom" runat="server" Font-Names="Verdana" Font-Size="11px"
										Width="120px" Enabled="False"></asp:TextBox>
									<asp:CalendarExtender ID="txtConfirmedDateRangeFrom_CalendarExtender" runat="server"
										Enabled="True" TargetControlID="txtConfirmedDateRangeFrom" Format="MMMM dd, yyyy">
									</asp:CalendarExtender>
									<asp:Label ID="Label5" runat="server" Text="TO" Font-Names="Verdana" Font-Size="11px"></asp:Label>
									<asp:TextBox ID="txtConfirmedDateRangeTo" runat="server" Font-Names="Verdana" Font-Size="11px"
										Width="120px" Enabled="False"></asp:TextBox>
									<asp:CalendarExtender ID="txtConfirmedDateRangeTo_CalendarExtender" runat="server"
										Enabled="True" TargetControlID="txtConfirmedDateRangeTo" Format="MMMM dd, yyyy">
									</asp:CalendarExtender>
									<asp:CheckBox ID="chkConfirmedDREnableDateRange" runat="server" Text="Use Date Range"
										Font-Names="Verdana" Font-Size="9px" AutoPostBack="True" OnCheckedChanged="chkConfirmedDREnableDateRange_CheckedChanged" />
								</asp:Panel>
							</div>
							<hr />
							<asp:Label ID="Label10" runat="server" Text="Generate Report by Brand" Font-Italic="True"
								Font-Names="Verdana" Font-Size="11px"></asp:Label>
							<br />
							<br />
							<asp:Label ID="Label3" runat="server" Text="BRAND:"></asp:Label>
							<asp:DropDownList ID="dlConfirmedBrands" runat="server" CssClass="modalText" Font-Size="11px"
								Height="20px">
							</asp:DropDownList>
							<asp:ListSearchExtender ID="ListSearchExtender1" runat="server" Enabled="True" TargetControlID="dlConfirmedBrands">
							</asp:ListSearchExtender>
							<div style="text-align: center; height: 20px; margin-bottom: 10px; margin-top: 5px;">
								<asp:Button ID="btnPrintByBrand" runat="server" Text="PRINT CONFIRMED DR" CssClass="btnPrint"
									Font-Names="Verdana" Font-Size="11px" Width="170px" OnClick="btnPrintByBrand_Click" />
							</div>
						</div>
					</asp:View>
				</asp:MultiView>
			</asp:Panel>
			<asp:HiddenField ID="hfIsAdvanceSearch" runat="server" />
			<asp:HiddenField ID="HF_BRAND" runat="server" />
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
