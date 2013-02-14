<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master"  AutoEventWireup="true"
CodeBehind="NewSalesInvoiceLiq.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.NewSalesInvoiceLiq" %>

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
		    Sales Invoice - New Invoice Liquidation
	    </div>
        <br />
     <div style="height: 260px; class="modalDrag">
			<table style="">
                    <tr>
                    
                        <td>
						</td>
                        <td>
							<label style="font-family: Verdana; font-size: 11px; color: #FF0000; font-weight: bold">
								* Required Fields </label>
						</td>
						<td>
						
						</td>
                        <td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Invoice No.</label>
                            <label style="font-family: Verdana; font-size: 11px; color: #FF0000; font-weight: bold">
								*</label>
						</td>
                  
						<td>
							<asp:TextBox CssClass="modalText" Width="150px" Height="20px" ID="txtInvoiceNo" 
                                runat="server" AutoPostBack="True" ontextchanged="txtInvoiceNo_TextChanged"></asp:TextBox>
						</td>
					</tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
						<td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Cust. No</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="150px" Height="20px" ID="txtCustNo" runat="server"></asp:TextBox>
                            <asp:Button ID="btnBrowse" Width="75PX" Height = "20px" CssClass="btnSalesInvoice" runat="server"
							Text="BROWSE" />
                            <asp:ModalPopupExtender ID="btnAddSelected_ModalPopupExtender" runat="server" BackgroundCssClass="bgModal"
                                CancelControlID="imgBtnCloseOutlets" DynamicServicePath="" Enabled="True" PopupControlID="pnlOutlets"
                                PopupDragHandleControlID="pnlOutletsDrag" TargetControlID="btnBrowse">
                            </asp:ModalPopupExtender>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
						</td>
                        <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</td>
                        <td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Date</label>
                             <label style="font-family: Verdana; font-size: 11px; color: #FF0000; font-weight: bold">
								*</label>
						</td>
                        
						<td>
							<asp:TextBox CssClass="modalText" Width="150px" Height="20px" ID="txtDate" 
                                runat="server" AutoPostBack="True" ontextchanged="txtDate_TextChanged"></asp:TextBox>
						    
						    <asp:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" 
                                TargetControlID="txtDate">
                            </asp:CalendarExtender>
						    
						</td>
					</tr>
                    <tr>
                        <td>
						</td>
                    </tr>
                    <tr>
                             	<td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Sold To</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="250px" Height="20px" ID="txtSoldTo" runat="server"></asp:TextBox>
						</td>
                        <td>
						</td>
						<td class="modalLabel">
							<label for="MainContent_txtGroupName">
								TIN</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="150px" Height="20px" ID="txtTIN" runat="server"></asp:TextBox>
						</td>	
                    </tr>
                    <tr>
                        <td>
						</td>
                    </tr>
                    <tr>
                         <td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Address</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="400px" Height="20px" ID="txtAddress" runat="server"></asp:TextBox>
						</td>
                        					
					</tr>
                      <tr>
                        <td>
						</td>
                    </tr>
                     <tr>
                        <td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Prepared By</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="200px" Height="20px" ID="txtPreparedBy" runat="server"></asp:TextBox>
						</td>
                        <td>
						</td>
						<td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Company</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="150px" Height="20px" ID="txtCompany" runat="server"></asp:TextBox>
						</td>	
                    </tr>
                      <tr>
						<td>
						</td>
						
					</tr>
                    <tr>
						 <td class="modalLabel">
							<label for="MainContent_txtGroupName">
								Total Amount</label>
						</td>
						<td>
							<asp:TextBox CssClass="modalText" Width="200px" Height="20px" ID="txtTotalAmount" runat="server"></asp:TextBox>
						</td>
						
					</tr>
                    <tr>
                    <td>&nbsp;</td></tr>
					<tr>
						<td>
						</td>
						<td>
                         <table style="">
                        <tr>
                            <td> 
                                <asp:Button ID="btnFinalizeTransaction" Width="150PX" Height = "20px" 
                                    CssClass="btnSalesInvoice" runat="server" 
                            Text="FINALIZE TRANSACTION" Enabled="False" />
                            <asp:ModalPopupExtender ID="btnFinalizeTransaction_ModalPopupExtender" 
                                    runat="server" BackgroundCssClass="bgModal"
                                CancelControlID="btnNo" DynamicServicePath="" Enabled="True" PopupControlID="pnlConfirmation"
                                PopupDragHandleControlID="pnlConfirmation" 
                                    TargetControlID="btnFinalizeTransaction" >
                            </asp:ModalPopupExtender>
                            </td>
                            <td align="center">
                             
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                             <asp:Button ID="btnCancelTransaction" Width="150PX" Height = "20px" 
                                    CssClass="btnSalesInvoice" runat="server"
							Text="CANCEL TRANSACTION" onclick="btnCancelTransaction_Click" />
                            
                            </td>
                            
                             <td> <asp:Button ID="btnBack" Width="50PX" Height = "20px" 
                                     CssClass="btnSalesInvoice" runat="server"
							Text="BACK" onclick="btnBack_Click" />
                            </td>
                        </tr>
                </table>
						</td>
						<td>
                         
						</td>
					</tr>
				</table>
        
    </div>
<asp:Panel ID="pnlOutlets" runat="server" CssClass="modal">
                <asp:Panel ID="pnlOutletsDrag" runat="server" CssClass="modalDrag">
                    <div class="close_btn">
                        <asp:ImageButton ID="imgBtnCloseOutlets" runat="server" CssClass="btnClose" ImageUrl="~/Resources/cancel_gray.png"
                            ToolTip="CLOSE" />
                    </div>
                    <div class="sizeLogo">
                        <asp:Image ID="Image3" runat="server" Height="16px" ImageAlign="AbsBottom" ImageUrl="~/Resources/usermode.png" />
                        CUSTOMER LIST
                    </div>
                </asp:Panel>
                <div style="margin-left: 5px; height:30px;">
                      <div class="SearchTextContainer">
                       SEARCH:  <asp:TextBox ID="txtSearchOutlet" runat="server" CssClass="modalText" Height="16px"></asp:TextBox>
                        <asp:ImageButton ID="imgBtnSearchOutlet" runat="server"  ImageUrl="~/Resources/search.png"
                            ImageAlign="AbsMiddle" ToolTip="SEARCH" onclick="imgBtnSearchOutlet_Click" />
                    </div>
                </div>
                <asp:Panel ID="outlets_container" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="gvOutlets" runat="server" BackColor="White" BorderColor="#CCCCCC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Verdana" Font-Size="11px"
                        ForeColor="Black" GridLines="Horizontal" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataKeyNames="CustNo" 
                        DataSourceID="SqlDataSourceCustomers" 
                        onselectedindexchanged="gvOutlets_SelectedIndexChanged" 
                        onselectedindexchanging="gvOutlets_SelectedIndexChanging" 
                        onpageindexchanged="gvOutlets_PageIndexChanged" 
                        onpageindexchanging="gvOutlets_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="imgOutlet" runat="server" Height="12px" ImageUrl="~/Resources/invoice.png"
                                        AlternateText='<%# Eval("CustNo").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="CustNo" HeaderText="CUSTOMER#" SortExpression="CompName"
                                HtmlEncode="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CompName" HeaderText="COMPANY NAME" SortExpression="CompName"
                                HtmlEncode="False">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="brand" HeaderText="BRAND" HtmlEncode="False" SortExpression="brand" />
                            <asp:BoundField DataField="Addr1" HeaderText="" SortExpression="Addr1" 
                                Visible="True" ItemStyle-CssClass="hiddencol" >
                            </asp:BoundField>
                            <asp:BoundField DataField="TIN" HeaderText="" SortExpression="TIN" 
                                Visible="True" ItemStyle-CssClass="hiddencol" >
                            </asp:BoundField>
                            <asp:BoundField DataField="CompName1" HeaderText="" 
                                SortExpression="CompName1" ItemStyle-CssClass="hiddencol"/>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="width: 370px; margin-top: 15px; border: 1px solid #FFCC66; height: 55px;
                                line-height: 55px; background-color: #FFFFCC; color: #C46200; text-align: center;">
                                <img src="../Resources/unhappy.png" alt="WEEE" align="middle" />
                                DATA NOT FOUND!!!
                            </div>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerSettings FirstPageImageUrl="~/Resources/first.png" LastPageImageUrl="~/Resources/last.png"
                            Mode="NumericFirstLast" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceCustomers" runat="server" ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>"
                        
                        SelectCommand="Select [CustNo],a.[CompName],[Brand],[Addr1],[TIN],b.CompName from [CustInfo] a inner join [Company] b on b.CompNo = a.CompNo where ynLiquidation = 1" 
                        EnableCaching="True">
                         
                    </asp:SqlDataSource>
                </asp:Panel>
                <div style="text-align: center; margin: 3px 0px 3px 0px;">
                    <asp:Button ID="btnSelectOutlet" runat="server" Text="OK" 
                        CssClass="modalWarningButtonYes" onclick="btnSelectOutlet_Click" />
                </div>
            </asp:Panel>
	<asp:Panel ID="pnlConfirmation" runat="server" CssClass="modal">
				<asp:Panel ID="pnlSelectedDRPreviewDrag" runat="server" CssClass="modalDrag">
					<div id="divFinTrab" class="sizeLogo" runat="server">
						<img src="../Resources/panels.png" height="16px" alt="" align="top" />
						Finalize Transaction Confirmation.
					</div>
				</asp:Panel>
				<div align="center">
                    <label id ="lblFinalize" runat="server"
                        style="font-family: Verdana; font-weight: bold; color: #FF0000" 
                        accesskey="lblFinalize" >
                        Create New Sales Invoice?
                    </label>
                </div>
                 <div style="text-align: center; margin: 3px 0px 3px 0px;">
                    <asp:Button ID="btnOK" runat="server" Text="YES" 
                        CssClass="modalWarningButtonYes" onclick="btnOK_Click" />
                     <asp:Button ID="btnNo" runat="server" Text="NO" 
                        CssClass="modalWarningButtonYes"/>
                </div>
			</asp:Panel>
</asp:Content>
     