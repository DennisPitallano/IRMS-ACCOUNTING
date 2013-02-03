<%@ Page Title="" Language="C#" MasterPageFile="~/Marketing/Marketing.Master" AutoEventWireup="true" CodeBehind="ProductManagementPanel.aspx.cs" Inherits="IntegratedResourceManagementSystem.Marketing.ProductCategoryManagementPanel" %>
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
        width : 560px;
        color : White;
     }
      .titleListDetails
     {
         /*09301212163*/
          background-color: #C9C9C9;
          background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
        height : 20px;
        width : 600px;
        color : White;
        font-family: Verdana;
        font-size: 11px;
     }
        .modalProductCategory
    {
        width : 350px;
        height :305px;
        background-color: #999999;
    }
    .modalProductCategoryDrag 
    {
        background-color: #C9C9C9;
        background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
        width: 350px;
        height : 25px;
        cursor :pointer;
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID ="upnlProducts" runat ="server" >
        <ContentTemplate>
  <div style ="width: 100%; height :30px;">
     <div style ="float:right;">
      <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
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

   <div style ="float:left; margin-right">
   <div class ="listContent" >
  <div class ="titleList"> 
      <asp:Image ID="imgList" runat="server" Height="16px" Width ="20px"
          ImageUrl="~/Resources/product.png" ImageAlign="AbsBottom" /> LIST OF ITEM</div>
  
  <asp:Panel ID ="pnlSizesList" runat ="server" Width ="560px" Height="380px" ScrollBars ="Auto"  >
      <asp:GridView ID="gvProductList" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" AutoGenerateColumns="False" Font-Names="Verdana" 
                    Font-Size="11px" 
                    
          onselectedindexchanged="gvProductList_SelectedIndexChanged" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
          <asp:TemplateField>
            <EditItemTemplate>
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:Image ID="Image1" runat="server" Height="16px" 
                         ImageUrl="~/Resources/product.png" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:CommandField ShowSelectButton="True" />
          <asp:BoundField DataField="RecordNo" HeaderText="RECORD #" Visible="False">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="StyleNumber" HeaderText="STYLE NUMBER">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
          </asp:BoundField>
          <asp:BoundField DataField="Description" HeaderText="DESCRIPTION">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
          </asp:BoundField>
            <asp:BoundField DataField="ItemCode" HeaderText="ITEM CODE">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="SKUBarcode" HeaderText="SKU BARCODE" Visible="False">
            <HeaderStyle Wrap="False" />
            <ItemStyle Wrap="False" />
            </asp:BoundField>
          <asp:BoundField DataField="DateCreated" HeaderText="DATE RECORDED" 
                Visible="False">
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
  </div>
 
 <div style ="float: left; border: 1px Solid Gray;">
   <div class ="titleListDetails"> 
      <asp:Image ID="Image3" runat="server" Height="20px" Width ="22px"
          ImageUrl="~/Resources/Barcode.png" ImageAlign="AbsMiddle" /> 
       &nbsp;LIST OF SKU&#39;s BY STYLE NUMBER:  <asp:Label ID="lblStyleNumber" 
           runat="server" Font-Bold="True" ForeColor="#993300" Font-Names="Verdana" 
           Font-Size="11px"></asp:Label></div>
    <asp:Panel ID ="pnlSKUDetails" runat ="server" Height ="380px" ScrollBars ="Auto"  >
        <asp:GridView ID="gvSKUDetails" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateColumns="False" Font-Names="Verdana" 
            Font-Size="11px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="16px" 
                            ImageUrl="~/Resources/Barcode.png" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="RecordNo" HeaderText="RECORD#" />
                <asp:BoundField DataField="SKUBarcode" HeaderText="SKU Barcode" />
                <asp:BoundField DataField="DateCreated" HeaderText="DATE CREATED" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <EmptyDataTemplate>
                NO SELECTED ITEM!!
            </EmptyDataTemplate>
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
             ImageUrl="~/Resources/product.png" />
             NEW ITEM
     </div>
    </asp:Panel>
      <table style="width: 100%;">
          <tr>
              <td class ="modalLabel">
                  BRAND:
              </td>
              <td>
                  <asp:DropDownList ID="dlBrands" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px">
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
          <tr>
              <td class ="modalLabel">
                  SEX:
              </td>
              <td>
                  <asp:DropDownList ID="dlSex" runat="server" Font-Names="Verdana" 
                      Height="22px" AutoPostBack="True" 
                      onselectedindexchanged="dlSex_SelectedIndexChanged" >
                      <asp:ListItem Value="M">MALE</asp:ListItem>
                      <asp:ListItem Value="F">FEMALE</asp:ListItem>
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  TOP OR BOTTOM?</td>
              <td>
             <%-- <asp:UpdatePanel ID ="upnlTopOrBottom" runat ="server" >
                <ContentTemplate>--%>
               <%-- </ContentTemplate>
              </asp:UpdatePanel>--%>
                  
                  <asp:RadioButtonList ID="rdioTopOrBottom" runat="server" 
                      AutoPostBack="True" Font-Bold="True" Font-Names="Verdana" Font-Size="11px" 
                      ForeColor="#CCFFCC" 
                      RepeatDirection="Horizontal" 
                      onselectedindexchanged="rdioTopOrBottom_SelectedIndexChanged">
                      <asp:ListItem Value="T">TOP</asp:ListItem>
                      <asp:ListItem Value="B">BOTTOM</asp:ListItem>
                  </asp:RadioButtonList>
                  
              </td>
              <td rowspan="5" valign ="Top">
                  <asp:Image ID="imgTopOrBottom" runat="server" />
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  GARMENT:</td>
              <td>
                  <asp:DropDownList ID="dlGarments" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px" ForeColor="#CC6600">
                  </asp:DropDownList>
              </td>
          </tr>
           <tr>
              <td class="modalLabel">
                  CATEGORY:</td>
              <td>
                  <asp:DropDownList ID="dlCategory" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px" ForeColor="#CC6600">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  SIZE:</td>
              <td>
                  <asp:DropDownList ID="dlSizes" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px" ForeColor="#CC6600">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  COLOR:</td>
              <td>
                  <asp:DropDownList ID="dlColors" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px" ForeColor="#CC6600">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  SKU FOR BARCODE:</td>
              <td>
                  <asp:TextBox ID="txtSKUBarcode" runat="server" Width="170px" Font-Bold="True" 
                      Font-Names="Verdana" Font-Size="11px" ForeColor="#003300"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="modalLabel">
                  NUMBER OF ITEM:</td>
              <td>
                  <asp:TextBox ID="txtItems" runat="server" Width="100px" Font-Bold="True" 
                      Font-Names="Verdana" ForeColor="#CC3300">0</asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td>
                  &nbsp;
              </td>
              <td>
                  <asp:Button ID="btnSaveProductCategory" runat="server" Text="GENERATE" CssClass ="btnGenerate" 
                      ToolTip="Generate" 
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
             ImageUrl="~/Resources/product.png" />
             NEW PRODUCT CATEGORY
     </div>
    </asp:Panel>
    <table style="width: 100%;">
          <tr>
              <td class ="modalLabel">
                  BRAND:
              </td>
              <td>
                  <asp:DropDownList ID="dlBrandUpdate" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px">
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
          <tr>
              <td class ="modalLabel">
                  SEX:
              </td>
              <td>
                  <asp:DropDownList ID="dlSexUpdate" runat="server" Font-Names="Verdana" 
                      Height="22px" AutoPostBack="True" 
                      onselectedindexchanged="dlSexUpdate_SelectedIndexChanged" >
                      <asp:ListItem Value="M">MALE</asp:ListItem>
                      <asp:ListItem Value="F">FEMALE</asp:ListItem>
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  TOP OR BOTTOM?</td>
              <td>
                  <asp:RadioButtonList ID="rdioTopOrBottomUpdate" runat="server" Font-Bold="True" 
                      Font-Names="Verdana" Font-Size="11px" ForeColor="#CCFFCC" 
                      RepeatDirection="Horizontal" AutoPostBack="True" 
                      onselectedindexchanged="rdioTopOrBottomUpdate_SelectedIndexChanged" >
                      <asp:ListItem Value="T">TOP</asp:ListItem>
                      <asp:ListItem Value="B">BOTTOM</asp:ListItem>
                  </asp:RadioButtonList>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="modalLabel">
                  GARMENT:</td>
              <td>
                  <asp:DropDownList ID="dlGarmentUpdate" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px">
                  </asp:DropDownList>
              </td>
              <td rowspan="6" valign ="Top">
                  <asp:Image ID="imgTopOrBottomUpdate" runat="server" />
              </td>
          </tr>
           <tr>
              <td class="modalLabel">
                  CATEGORY:</td>
              <td>
                  <asp:DropDownList ID="dlCategoryUpdate" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  SIZE:</td>
              <td>
                  <asp:DropDownList ID="dlSizeUpdate" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  COLOR:</td>
              <td>
                  <asp:DropDownList ID="dlColorUpdate" runat="server" Font-Names="Verdana" 
                      Height="22px" Width="170px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  SKU FOR BARCODE:</td>
              <td>
                  <asp:TextBox ID="txtSKUBarcodeUpdate" runat="server" Width="170px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="modalLabel">
                  ITTEM/S:</td>
              <td>
                  <asp:TextBox ID="txtItemsUpdate" runat="server" Width="100px">0</asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  &nbsp;
              </td>
              <td>
                  <asp:Button ID="btnSaveUpdate" runat="server" Text="SAVE" CssClass ="btnSave" 
                      ToolTip="Update Product Category" onclick="btnSaveUpdate_Click" />
                  <asp:RoundedCornersExtender ID="RoundedCornersExtender1" 
                      runat="server" Enabled="True" TargetControlID="btnSaveUpdate">
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
