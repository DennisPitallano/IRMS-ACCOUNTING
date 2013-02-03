<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="CategoryManagementPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Marketing.CategoryManagementPanel" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/marketing-item-master.css" rel="stylesheet" type="text/css" />
      <style type ="text/css">
    .titleList
     {
         /*09301212163*/
          background-color: #C9C9C9;
          background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
        height : 20px;
        width : 650px;
        color : White;
     }
        .modalProductCategory
    {
        width : 370px;
        height :150px;
        background-color: #999999;
    }
    .modalProductCategoryDrag 
    {
        background-color: #C9C9C9;
        background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
        width: 370px;
        height : 25px;
        cursor :pointer;
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:UpdatePanel ID ="upnlCategories" runat ="server" >
    <ContentTemplate>
          <div style ="width: 100%; height :30px;">
     <div style ="float:right;">
      <asp:TextBox ID="txtSearch" runat="server" ontextchanged="txtSearch_TextChanged"></asp:TextBox>
      <asp:TextBoxWatermarkExtender ID="txtSearch_TextBoxWatermarkExtender" 
          runat="server" Enabled="True" TargetControlID="txtSearch" 
          WatermarkText="search" WatermarkCssClass="watermark">
      </asp:TextBoxWatermarkExtender>
      <asp:ImageButton ID="imgBtnSearch" runat="server" ImageAlign="AbsBottom" 
          ImageUrl="~/Resources/search.png" ToolTip="SEARCH" />
  </div>
     <div style ="float:left;">
    <div  style ="float:left; margin-right:5px;">
    <asp:Button ID="btnNewProductCategory" runat="server" Text="NEW" CssClass ="btnNew" 
                Font-Names="Verdana" TabIndex="2" />
        <asp:ModalPopupExtender ID="btnNewProductCategory_ModalPopupExtender" runat="server" 
            DynamicServicePath="" Enabled="True" PopupControlID="pnlNewSizeModal" 
            PopupDragHandleControlID="pnlNewSizeModalDrag" 
            TargetControlID="btnNewProductCategory" BackgroundCssClass="bgModal" 
            CancelControlID="imgBtnCloseNewSizeModal">
        </asp:ModalPopupExtender>
    <asp:RoundedCornersExtender ID="btnNewProductCategory_RoundedCornersExtender" 
                                runat="server" Enabled="True" 
          TargetControlID="btnNewProductCategory" Radius="3" BorderColor="YellowGreen">
    </asp:RoundedCornersExtender>
    </div>
    <div  style ="float:left; margin-right:5px;">
    <asp:Button ID="btnUpdateProductCategory" runat="server" Text="UPDATE" CssClass ="btnUpdate" 
                Font-Names="Verdana"  />
        <asp:ModalPopupExtender ID="btnUpdateProductCategory_ModalPopupExtender" runat="server" 
            CancelControlID="ibtnCloseUpdateModal" DynamicServicePath="" 
            Enabled="True" PopupControlID="pnlUpdateProductCategoryModal" 
            PopupDragHandleControlID="pnlUpdateProductCategoryModalDrag" 
            TargetControlID="btnUpdateProductCategory" BackgroundCssClass="bgModal">
        </asp:ModalPopupExtender>
    <asp:RoundedCornersExtender ID="btnUpdateProductCategory_RoundedCornersExtender" 
                                runat="server" Enabled="True" 
          TargetControlID="btnUpdateProductCategory" Radius="3" BorderColor="YellowGreen">
    </asp:RoundedCornersExtender>
    </div> 
    <div  style ="float:left; margin-right:5px;">
    <asp:Button ID="btnDelete" runat="server" Text="DELETE" CssClass ="btnDelete" 
                Font-Names="Verdana"  />
        <asp:ModalPopupExtender ID="btnDelete_ModalPopupExtender" runat="server" 
            BackgroundCssClass="bgModal" CancelControlID="btnNo" DynamicServicePath="" 
            Enabled="True" PopupControlID="pnlDeleteModal" 
            PopupDragHandleControlID="pnlDeleteModalDrag" TargetControlID="btnDelete">
        </asp:ModalPopupExtender>
    <asp:RoundedCornersExtender ID="btnDelete_RoundedCornersExtender" 
                                runat="server" Enabled="True" 
          TargetControlID="btnDelete" Radius="3" BorderColor="YellowGreen">
    </asp:RoundedCornersExtender>
    </div> 
    <div  style ="float:left; margin-right:5px;">
    <asp:Button ID="btnPrint" runat="server" Text="PRINT" CssClass ="btnPrint" 
                Font-Names="Verdana"  />
    <asp:RoundedCornersExtender ID="btnPrint_RoundedCornersExtender" 
                                runat="server" Enabled="True" 
          TargetControlID="btnPrint" Radius="3" BorderColor="YellowGreen">
    </asp:RoundedCornersExtender>
    </div> 
 </div>
 </div>
  <div class ="titleList"> 
      <asp:Image ID="imgList" runat="server" Height="20px" 
          ImageUrl="~/Resources/category.png" ImageAlign="AbsBottom" /> LIST OF PRODUCT CATEGORY</div>
  <div class ="listContent" >
  <asp:Panel ID ="pnlSizesList" runat ="server" Width ="650px" Height ="370px" ScrollBars ="Auto"  >
      <asp:GridView ID="gvProductCategoryList" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" AutoGenerateColumns="False" Font-Names="Verdana" 
                    Font-Size="11px" 
          onselectedindexchanged="gvProductCategoryList_SelectedIndexChanged" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
          <asp:TemplateField>
            <EditItemTemplate>
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Image ID="Image1" runat="server" Height="16px" 
                         ImageUrl="~/Resources/category.png" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:CommandField ShowSelectButton="True" />
          <asp:BoundField DataField="RecordNo" HeaderText="RECORD #">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="CategoryCode" HeaderText="CATEGORY CODE">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="CategoryDescription" HeaderText="CATEGORY DESCRIPTION">
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
          EMPTY DATA!!!
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

  <asp:Panel ID ="pnlNewSizeModal" runat ="server" CssClass ="modalProductCategory" >
    <asp:Panel ID ="pnlNewSizeModalDrag" runat ="server" CssClass="modalProductCategoryDrag" >
     <div class ="close_btn">
         <asp:ImageButton ID="imgBtnCloseNewSizeModal" runat="server" 
             CssClass ="btnClose" ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE"/>
     </div> 
     <div class ="sizeLogo">
         <asp:Image ID="imgSizeLogo" runat="server" Height="16px" ImageAlign="AbsBottom" 
             ImageUrl="~/Resources/category.png" />
             NEW&nbsp; CATEGORY
     </div>
    </asp:Panel>
      <table style="width: 100%;">
          <tr>
              <td class ="modalLabel">
                  CATEGORY CODE:
              </td>
              <td>
                  <asp:TextBox ID="txtCategoryCode" runat="server" Width ="150px"></asp:TextBox>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
          <tr>
              <td class ="modalLabel">
                  CATEGORY DESCRIPTION:
              </td>
              <td>
                  <asp:TextBox ID="txtCategoryDescription" runat="server" Width="200px" Height ="50px"
                      TextMode="MultiLine"></asp:TextBox>
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
                  <asp:Button ID="btnSaveProductCategory" runat="server" Text="SAVE" CssClass ="btnSave" 
                      ToolTip="Save New Product Category" 
                      onclick="btnSaveProductCategory_Click" />
                  <asp:RoundedCornersExtender ID="btnSaveProductCategory_RoundedCornersExtender" 
                      runat="server" Enabled="True" TargetControlID="btnSaveProductCategory">
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

  <asp:Panel ID ="pnlUpdateProductCategoryModal" runat ="server" CssClass ="modalProductCategory" >
    <asp:Panel ID ="pnlUpdateProductCategoryModalDrag" runat ="server" CssClass="modalProductCategoryDrag" >
     <div class ="close_btn">
         <asp:ImageButton ID="ibtnCloseUpdateModal" runat="server" 
             CssClass ="btnClose" ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE"/>
     </div> 
     <div class ="sizeLogo">
         <asp:Image ID="Image1" runat="server" Height="16px" ImageAlign="AbsBottom" 
             ImageUrl="~/Resources/category.png" />
             UPDATE CATEGORY
     </div>
    </asp:Panel>
  <table style="width: 100%;">
          <tr>
              <td class ="modalLabel">
                  CATEGORY CODE:
              </td>
              <td>
                  <asp:TextBox ID="txtCategoryUpdate" runat="server" Width ="150px"></asp:TextBox>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
          <tr>
              <td class ="modalLabel">
                  CATEGORY DESCRIPTION:
              </td>
              <td>
                  <asp:TextBox ID="txtCategoryDescriptionUpdate" runat="server" Width="200px" Height ="50px"
                      TextMode="MultiLine"></asp:TextBox>
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
                  <asp:Button ID="btnSaveUpdate" runat="server" Text="SAVE" CssClass ="btnSave" 
                      ToolTip="Update Category" onclick="btnSaveUpdate_Click" />
                  <asp:RoundedCornersExtender ID="RoundedCornersExtender1" 
                      runat="server" Enabled="True" TargetControlID="btnSaveProductCategory">
                  </asp:RoundedCornersExtender>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
      </table>
  </asp:Panel>
  <asp:RoundedCornersExtender ID="RoundedCornersExtender2" 
        runat="server" Enabled="True" TargetControlID="pnlUpdateProductCategoryModal">
    </asp:RoundedCornersExtender>
  <asp:DropShadowExtender ID="DropShadowExtender1" runat="server" 
        Enabled="True" Opacity="0.5" Rounded="True" TargetControlID="pnlUpdateProductCategoryModal">
    </asp:DropShadowExtender>
    <%--Delete Modal--%>
  <asp:Panel ID ="pnlDeleteModal" runat ="server" CssClass ="deleteModal" >
    <asp:Panel ID= "pnlDeleteModalDrag" runat ="server" CssClass ="modalDrag">
      <div class ="sizeLogo">
        <asp:Image ID="Image2" runat="server" Height="16px" ImageAlign="AbsBottom" 
                   ImageUrl="~/Resources/product.png" />
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
