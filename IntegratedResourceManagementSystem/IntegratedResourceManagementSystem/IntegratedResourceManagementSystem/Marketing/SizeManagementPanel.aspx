<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="SizeManagementPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Marketing.SizeManagementPanel" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
  <link href="../Styles/marketing-item-master.css" rel="stylesheet" type="text/css" />
    <style type ="text/css">
    .titleList
     {
          background-color: #C9C9C9;
          background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
        height : 20px;
        width : 595px;
        color : White;
     }
</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID ="upnlNewSize" runat ="server" >
    <ContentTemplate >
      <div style ="width: 100%; height: 30px;">
       <div  style ="float:right; ">
          <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
          <asp:TextBoxWatermarkExtender ID="txtSearch_TextBoxWatermarkExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtSearch" 
                                        WatermarkCssClass="watermark" WatermarkText="search">
          </asp:TextBoxWatermarkExtender>
          <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" 
                           ImageUrl="~/Resources/search.png" ToolTip="SEARCH" 
                onclick="imgBtnSearch_Click" />
        </div> 
        <div  style ="float:left; ">
          <div style="float:left; margin-right:5px;">
            <asp:Button ID="btnNewSize" runat="server" CssClass="btnNew" 
                        Font-Names="Verdana" Text="NEW" />
            <asp:ModalPopupExtender ID="btnNewSize_ModalPopupExtender" runat="server" 
                                    BackgroundCssClass="bgModal" CancelControlID="imgBtnCloseNewSizeModal" 
                                    DynamicServicePath="" Enabled="True" PopupControlID="pnlNewSizeModal" 
                                    PopupDragHandleControlID="pnlNewSizeModalDrag" TargetControlID="btnNewSize">
            </asp:ModalPopupExtender>
            <asp:RoundedCornersExtender ID="btnNewSize_RoundedCornersExtender" 
                                        runat="server" BorderColor="YellowGreen" Enabled="True" Radius="3" 
                                        TargetControlID="btnNewSize">
            </asp:RoundedCornersExtender>
          </div>
          <div style="float:left; margin-right:5px;">
            <asp:Button ID="btnUpdateSize" runat="server" CssClass="btnUpdate" 
                        Font-Names="Verdana" Text="UPDATE" />
            <asp:ModalPopupExtender ID="btnUpdateSize_ModalPopupExtender" runat="server" 
                                    BackgroundCssClass="bgModal" CancelControlID="imgBtnCloseUpdateSizeModal" 
                                    DynamicServicePath="" Enabled="True" PopupControlID="pnlUpdateSizeModal" 
                                    PopupDragHandleControlID="pnlUpdateSizeModalDrag" 
                                    TargetControlID="btnUpdateSize">
            </asp:ModalPopupExtender>
            <asp:RoundedCornersExtender ID="btnUpdateSize_RoundedCornersExtender" 
                                        runat="server" BorderColor="YellowGreen" Enabled="True" Radius="3" 
                                        TargetControlID="btnUpdateSize">
            </asp:RoundedCornersExtender>
          </div>
          <div style="float:left; margin-right:5px;">
            <asp:Button ID="btnDelete" runat="server" CssClass="btnDelete" 
                        Font-Names="Verdana" Text="DELETE" />
              <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" 
                  DynamicServicePath="" Enabled="True" PopupControlID="pnlDeleteModal" 
                  PopupDragHandleControlID="pnlDeleteModalDrag" TargetControlID="btnDelete" 
                  CancelControlID="btnNo" BackgroundCssClass="bgModal">
              </asp:ModalPopupExtender>
            <asp:RoundedCornersExtender ID="btnDelete_RoundedCornersExtender" 
                                        runat="server" BorderColor="YellowGreen" Enabled="True" Radius="3" 
                                        TargetControlID="btnDelete">
            </asp:RoundedCornersExtender>
          </div>
          <div style="float:left; margin-right:5px;">
            <asp:Button ID="btnPrint" runat="server" CssClass="btnPrint" 
                        Font-Names="Verdana" Text="PRINT" />
            <asp:RoundedCornersExtender ID="btnPrint_RoundedCornersExtender" runat="server" 
                                        BorderColor="YellowGreen" Enabled="True" Radius="3" TargetControlID="btnPrint">
            </asp:RoundedCornersExtender>
          </div>
        </div>
       
      </div>
      <div class="titleList">
        <asp:Image ID="imgList" runat="server" Height="16px" ImageAlign="AbsBottom" 
                   ImageUrl="~/Resources/size.png" />
        LIST OF SIZES
  
      </div>

      <div class ="listContent" >
        <asp:Panel ID ="pnlSizesList" runat ="server" Width ="595px"  Height ="370px" ScrollBars ="Auto"  >
          <asp:GridView ID="gvSizesList" runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" AutoGenerateColumns="False" Font-Names="Verdana" 
                        Font-Size="11px" 
                onselectedindexchanged="gvSizesList_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="16px" 
                            ImageUrl="~/Resources/size.png" />
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:CommandField ShowSelectButton="True" />
              <asp:BoundField DataField="RecordNo" HeaderText="RECORD #">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="SizeCode" HeaderText="SIZE CODE">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="SizeDescription" HeaderText="SIZE DESCRIPTION">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
              </asp:BoundField>
              <asp:BoundField DataField="DateCreated" HeaderText="DATE RECORDED">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
              </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
              <EmptyDataTemplate>
                  NULL DATA!!
              </EmptyDataTemplate>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" 
                              Font-Names="Verdana" Font-Size="11px" Font-Italic="True" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
          </asp:GridView>
        </asp:Panel>
      </div>  
 
 <%--New Size Modal--%>
      <asp:Panel ID ="pnlNewSizeModal" runat ="server" CssClass ="modal" 
            Height="150px" Width ="320px" >
        <asp:Panel ID ="pnlNewSizeModalDrag" runat ="server" CssClass="modalDrag" >
          <div class ="close_btn">
            <asp:ImageButton ID="imgBtnCloseNewSizeModal" runat="server" 
                             CssClass ="btnClose" ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE"/>
          </div> 
          <div class ="sizeLogo">
            <asp:Image ID="imgSizeLogo" runat="server" Height="16px" ImageAlign="AbsBottom" 
                       ImageUrl="~/Resources/size.png" />
            NEW SIZE
          </div>
        </asp:Panel>
        <table style="width: 100%;">
          <tr>
            <td class ="modalLabel">
              SIZE CODE:
            </td>
            <td>
              <asp:TextBox ID="txtSizeCode" runat="server" Height="22px" Font-Names="Verdana" 
                           ForeColor="#333333"></asp:TextBox>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td class ="modalLabel">
              SIZE DESCRIPTION:
            </td>
            <td>
              <asp:TextBox ID="txtSizeDescription" runat="server" Height="40px" 
                           TextMode="MultiLine" Font-Names="Verdana" ForeColor="#333333"></asp:TextBox>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
            </td>
            <td>
              <asp:Button ID="btnSaveSize" runat="server" Text="SAVE" CssClass ="btnSave" 
                          ToolTip="Save New Size" onclick="btnSaveSize_Click" />
              <asp:RoundedCornersExtender ID="btnSaveSize_RoundedCornersExtender" 
                                          runat="server" Enabled="True" TargetControlID="btnSaveSize">
              </asp:RoundedCornersExtender>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
        </table>
      </asp:Panel>
      <asp:RoundedCornersExtender ID="pnlNewSizeModal_RoundedCornersExtender" 
                                  runat="server" Enabled="True" TargetControlID="pnlNewSizeModal">
      </asp:RoundedCornersExtender>
      <asp:DropShadowExtender ID="pnlNewSizeModal_DropShadowExtender" runat="server" 
                              Enabled="True" Opacity="0.5" Rounded="True" TargetControlID="pnlNewSizeModal">
      </asp:DropShadowExtender>

 <%--Update Modal--%>
      <asp:Panel ID ="pnlUpdateSizeModal" runat ="server" CssClass ="modal"  Height="150px" Width ="320px">
        <asp:Panel ID ="pnlUpdateSizeModalDrag" runat ="server" CssClass="modalDrag" >
          <div class ="close_btn">
            <asp:ImageButton ID="imgBtnCloseUpdateSizeModal" runat="server" 
                             CssClass ="btnClose" ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE"/>
          </div> 
          <div class ="sizeLogo">
            <asp:Image ID="imgUpdateLogo" runat="server" Height="16px" ImageAlign="AbsBottom" 
                       ImageUrl="~/Resources/size.png" />
            UPDATE SIZE
          </div>
        </asp:Panel>
        <table style="width: 100%;">
          <tr>
            <td class ="modalLabel">
              SIZE CODE:
            </td>
            <td>
              <asp:TextBox ID="txtSizeCodeUpdate" runat="server" Height="22px" Font-Names="Verdana" 
                           ForeColor="#333333"></asp:TextBox>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td class ="modalLabel">
              SIZE DESCRIPTION:
            </td>
            <td>
              <asp:TextBox ID="txtSizeDescriptionUpdate" runat="server" Height="40px" 
                           TextMode="MultiLine" Font-Names="Verdana" ForeColor="#333333"></asp:TextBox>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
            </td><asp:Button ID="btnSaveUpdate" runat="server" Text="SAVE" CssClass ="btnSave" 
                          ToolTip="Update Size" onclick="btnSaveUpdate_Click" />
            <td>
              
              <asp:RoundedCornersExtender ID="btnSaveUpdate_RoundedCornersExtender" 
                                          runat="server" Enabled="True" TargetControlID="btnSaveUpdate">
              </asp:RoundedCornersExtender>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
        </table>
      </asp:Panel>
      <asp:RoundedCornersExtender ID="pnlUpdateSizeModal_RoundedCornersExtender" 
                                  runat="server" Enabled="True" TargetControlID="pnlUpdateSizeModal">
      </asp:RoundedCornersExtender>
      <asp:DropShadowExtender ID="pnlUpdateSizeModal_DropShadowExtender" runat="server" 
                              Enabled="True" Opacity="0.5" Rounded="True" TargetControlID="pnlUpdateSizeModal">
      </asp:DropShadowExtender>

 <%--Delete Modal--%>
      <asp:Panel ID ="pnlDeleteModal" runat ="server" CssClass ="deleteModal" >
        <asp:Panel ID= "pnlDeleteModalDrag" runat ="server" CssClass ="modalDrag">
          <div class ="sizeLogo">
            <asp:Image ID="Image1" runat="server" Height="16px" ImageAlign="AbsBottom" 
                       ImageUrl="~/Resources/size.png" />
            CONFIRMATION!!!
          </div>
        </asp:Panel>
        <div class ="modalWarningText">
            Are you sure you want to Delete this Data?
        </div>
        <div style ="margin-left:80px; margin-top: 12px;">
            <asp:Button ID="btnYes" runat="server" Text="YES" 
                CssClass ="modalWarningButtonYes" ToolTip="Delete" 
                onclick="btnYes_Click" />
            <asp:RoundedCornersExtender ID="btnYes_RoundedCornersExtender" runat="server" 
                Enabled="True" TargetControlID="btnYes">
            </asp:RoundedCornersExtender>
            <asp:Button ID="btnNo" runat="server" Text="NO" 
                CssClass ="modalWarningButtonNo" ToolTip="Cancel"  />
            <asp:RoundedCornersExtender ID="btnNo_RoundedCornersExtender" runat="server" 
                Enabled="True" TargetControlID="btnNo">
            </asp:RoundedCornersExtender>
        </div>
      </asp:Panel>
      <asp:DropShadowExtender ID="pnlDeleteModal_DropShadowExtender" runat="server" 
            Enabled="True" Opacity="0.5" Rounded="True" TargetControlID="pnlDeleteModal">
        </asp:DropShadowExtender>
      <asp:RoundedCornersExtender ID="pnlDeleteModal_RoundedCornersExtender" 
            runat="server" Enabled="True" TargetControlID="pnlDeleteModal">
        </asp:RoundedCornersExtender>
    </ContentTemplate>
  </asp:UpdatePanel>
  

</asp:Content>
