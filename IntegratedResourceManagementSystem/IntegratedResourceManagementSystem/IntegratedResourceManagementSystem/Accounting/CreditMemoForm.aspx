<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="CreditMemoForm.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.CreditMemoForm" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="~/Accounting/controls/MainMenu.ascx" TagName="MAIN_MENU" TagPrefix="irms" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
  <link href="../Styles/marketing-item-master.css" rel="stylesheet" type="text/css" />
      <style type ="text/css">
     .DebitMemoForm
    {
        width : 650px;
        background-color: #999999;
    }
    .DebitMemoFormTitle 
    {
        background-color: #C9C9C9;
   /* background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);*/
        width: 650px;
        height : 25px;
        cursor :move;
    }
     .modalNewParticular
    {
        width : 400px;
        background-color: #999999;
    }
    .modalNewParticularDrag 
    {
        background-color: #C9C9C9;
        background-image: -webkit-gradient(linear, left top, left bottom, from(#c9c9c9), to(#848484), color-stop(0.6, #a1a1a1));
        background-image : -moz-linear-gradient(top, #c9c9c9, #848484, #a1a1a1 90%);
        width: 400px;
        height : 25px;
        cursor :move;
    }
    .btnAdd 
   {
         font-family:Verdana ;
        font-weight :bold;
        font-size: 12px;
        height : 25px;
        text-align :right;
        background:url('/Resources/new.png');
        background-repeat:no-repeat;
        background-position:left;
        background-color: #C9C9C9;
        color:#FCFCFC;
        width: 63px;
        cursor:pointer;
   }
   .btnAdd:hover
     {
        background:url('/Resources/new.png');
        background-repeat:no-repeat;
        background-position:left;
        background-color: #C9C9C9;
     }
      .btnCancel
   {
         font-family:Verdana ;
        font-weight :bold;
        font-size: 12px;
        height : 25px;
        text-align :right;
        background:url('/Resources/cancel_normal.png');
        background-repeat:no-repeat;
        background-position:left;
        background-color: #C9C9C9;
        color:#FCFCFC;
        width: 75px;
        cursor:pointer;
   }
   .btnCancel:hover
     {
        background:url('/Resources/cancel_gray.png');
        background-repeat:no-repeat;
        background-position:left;
        background-color: #C9C9C9;
     }
</style>
</asp:Content>
<asp:Content ID="IRMS_MENU" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
   <irms:MAIN_MENU ID="main_menu" runat="server" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID ="upnlDebitMemo" runat ="server"  >
    <ContentTemplate>
      <asp:Panel ID ="pnlNewSizeModal" runat ="server" CssClass ="DebitMemoForm" >
        <asp:Panel ID ="pnlNewSizeModalDrag" runat ="server" CssClass="DebitMemoFormTitle" >
    
          <div class ="sizeLogo">
            <asp:Image ID="imgSizeLogo" runat="server" Height="16px" ImageAlign="Bottom" 
                       ImageUrl="~/Resources/usermode.png" />
              &nbsp;CREDIT MEMO FORM
          </div>
        </asp:Panel>
        <table style="width: 100%;">
          <tr>
            <td>
              &nbsp;
            </td>
            <td>
              &nbsp;
            </td>
            <td>
              &nbsp;
            </td>
            <td>
              &nbsp;
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
          <tr>
            <td class ="modalLabel">
              Reference No.
            </td>
            <td>
              <asp:TextBox ID="txtReferenceNumber" runat="server" Width ="150px" 
                    Font-Names="Verdana" Font-Size="11px" ForeColor="#003366"></asp:TextBox>
            </td>
            <td class ="modalLabel">
              DATE:
            </td>
            <td colspan="2">
              <asp:TextBox ID="txtDate" runat="server" Font-Names="Verdana" Font-Size="11px" 
                    ForeColor="#003366"></asp:TextBox>
              <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDate" Format="MMMM d, yyyy">
              </asp:CalendarExtender>
            </td>
          </tr>
          <tr>
            <td class="modalLabel">
                PERIOD FROM:</td>
            <td>
                <asp:TextBox ID="txtDatePeriodFrom" runat="server" Font-Names="Verdana" Font-Size="11px" 
                    ForeColor="#003366"></asp:TextBox>
                <asp:CalendarExtender ID="txtDate0_CalendarExtender" runat="server" 
                    Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtDatePeriodFrom">
                </asp:CalendarExtender>
                TO</td>
              <td>
                  <asp:TextBox ID="txtDatePeriodTo" runat="server" Font-Names="Verdana" Font-Size="11px" 
                      ForeColor="#003366"></asp:TextBox>
                  <asp:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" 
                      Enabled="True" Format="MMMM d, yyyy" TargetControlID="txtDatePeriodTo">
                  </asp:CalendarExtender>
              </td>
            <td colspan="2">
              &nbsp;</td>
          </tr>
            <tr>
                <td class="modalLabel">
                    OUTLET:</td>
                <td colspan="2">
                    <asp:DropDownList ID="dlOutlets" runat="server" Font-Names="Verdana" 
                        Font-Size="12px">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
          <tr>
            <td class="modalLabel">
              BRAND:</td>
            <td colspan="2">
              <asp:DropDownList ID="dlBrands" runat="server" Font-Names="Verdana" 
                                Font-Size="12px" Height ="22px">
              </asp:DropDownList>
            </td>
            <td colspan="2">
              &nbsp;
            </td>
          </tr>
          <tr>
            <td class="modalLabel">
            </td>
            <td colspan="2">
              &nbsp;
            </td>
            <td colspan="2">
              &nbsp;
            </td>
          </tr>
        </table>
        <div>
          <div style ="font-family :Verdana; color:White; margin-left: 10px;">
            PARTICULARS
      
            <asp:ImageButton ID="ibtnAddParticular0" runat="server" 
                             ImageUrl="~/Resources/new.png" 
                  onclick="ibtnAddParticular_Click" Height="16px" ImageAlign="AbsBottom" />
      
              <asp:ModalPopupExtender ID="ibtnAddParticular0_ModalPopupExtender" 
                  runat="server" DynamicServicePath="" Enabled="True" 
                  TargetControlID="ibtnAddParticular0" 
                  CancelControlID="ibtnCloseNewParticularModal" 
                  PopupControlID="pnlNewParticularModal" 
                  PopupDragHandleControlID="pnlNewParticularModalDrag" 
                  BackgroundCssClass="bgModal">
              </asp:ModalPopupExtender>
      
              <asp:ImageButton ID="ibtnDeleteParticular" runat="server" Height="16px" 
                  ImageAlign="AbsBottom" ImageUrl="~/Resources/cancel_normal.png" 
                  onclick="ibtnAddParticular_Click" />
      
          </div>
          <hr />
          <div style ="margin-left: 5px; margin-bottom:10px;">
          <asp:Panel ID ="pnlParticulars" runat ="server" ScrollBars ="Auto" >
            <asp:GridView ID="gvParticulars" runat="server" AutoGenerateColumns="False" 
                          CellPadding="4" Font-Names="Verdana" Font-Size="11px" ForeColor="#333333" 
                          GridLines="None">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                <asp:BoundField DataField="Particular" HeaderText="PARTICULAR" />
                <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" />
                <asp:BoundField DataField="CurrentPrice" HeaderText="CURRENT PRICE" 
                      DataFormatString="Php{0:###,###.00}" >
                  <ItemStyle ForeColor="Red" />
                  </asp:BoundField>
                <asp:BoundField DataField="CostPrice" HeaderText="COST PRICE" 
                      DataFormatString="Php{0:###,###.00}" >
                  <ItemStyle ForeColor="Red" />
                  </asp:BoundField>
                  <asp:CommandField ShowSelectButton="True" />
              </Columns>
              <EditRowStyle BackColor="#7C6F57" />
              <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#E3EAEB" />
              <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="False" ForeColor="#333333" 
                    Font-Italic="True" Font-Names="Verdana" Font-Size="11px" />
              <SortedAscendingCellStyle BackColor="#F8FAFA" />
              <SortedAscendingHeaderStyle BackColor="#246B61" />
              <SortedDescendingCellStyle BackColor="#D4DFE1" />
              <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
          </asp:Panel>
          </div>
          <div style ="text-align :center; padding-bottom:10px;">
              <asp:Button ID="btnSaveDebitMemo" runat="server" Text="SAVE" CssClass ="btnSave" />
              <asp:RoundedCornersExtender ID="btnSaveDebitMemo_RoundedCornersExtender" 
                  runat="server" Enabled="True" TargetControlID="btnSaveDebitMemo">
              </asp:RoundedCornersExtender>
              <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" 
                  Text="CANCEL" onclick="btnCancel_Click" />
              <asp:RoundedCornersExtender ID="btnSaveDebitMemo0_RoundedCornersExtender" 
                  runat="server" Enabled="True" TargetControlID="btnCancel">
              </asp:RoundedCornersExtender>
          </div>
        </div>
      </asp:Panel>
      <asp:RoundedCornersExtender ID="pnlNewSizeModal_RoundedCornersExtender" 
                                  runat="server" Enabled="True" TargetControlID="pnlNewSizeModal">
      </asp:RoundedCornersExtender>

      <%--new credit particular modal--%>
   <asp:Panel ID ="pnlNewCreditParticularModal" runat ="server" CssClass ="modalNewParticular" >
    <asp:Panel ID ="pnlNewCreditParticularModalDrag" runat ="server" CssClass="modalNewParticularDrag" >
     <div class ="close_btn">
         <asp:ImageButton ID="ibtnCloseNewParticularModal" runat="server" 
             CssClass ="btnClose" ImageUrl="~/Resources/cancel_gray.png" ToolTip="CLOSE"/>
     </div> 
     <div class ="sizeLogo">
         <asp:Image ID="Image1" runat="server" Height="16px" ImageAlign="AbsBottom" 
             ImageUrl="~/Resources/usermode.png" />
             NEW PARTICULAR
     </div>
    </asp:Panel>
       <table style="width: 100%;">
           <tr>
               <td class ="modalLabel">
                  STYLE NUMBER:</td>
               <td>
                   <asp:DropDownList ID="dlItems" runat="server">
                       <asp:ListItem>DELIVERIES</asp:ListItem>
                       <asp:ListItem>SHOPLIFT</asp:ListItem>
                       <asp:ListItem>UNCOLLECTED SALES</asp:ListItem>
                       <asp:ListItem>PILFERAGE(lacking)</asp:ListItem>
                       <asp:ListItem>OTHERS</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td>
                   &nbsp;
               </td>
           </tr>
           <tr>
               <td class ="modalLabel">
                    QUANTITY:</td>
               <td>
                   <asp:TextBox ID="txtParticularQuantity" runat="server" Height="22px" 
                       Font-Names="Verdana" Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
               </td>
               <td>
                   &nbsp;
               </td>
           </tr>
           <tr>
               <td class ="modalLabel">
                 CURRENT PRICE:</td>
               <td>
                   <asp:TextBox ID="txtCurrentPrice" runat="server" Height="22px" 
                       Font-Names="Verdana" Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
               </td>
               <td>
                   &nbsp;
               </td>
           </tr>
           <tr>
               <td class="modalLabel">
                   COST PRICE:</td>
               <td>
                   <asp:TextBox ID="txtCostPrice" runat="server" Height="22px" 
                       Font-Names="Verdana" Font-Size="12px" ForeColor="#CC3300"></asp:TextBox>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="modalLabel">
                   &nbsp;</td>
               <td>
                   <asp:Button ID="btnAddParticular" runat="server" Text="ADD" CssClass ="btnAdd" 
                       onclick="btnAddParticular_Click" />
                   <asp:RoundedCornersExtender ID="btnAddParticular_RoundedCornersExtender" 
                       runat="server" Enabled="True" TargetControlID="btnAddParticular">
                   </asp:RoundedCornersExtender>
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td class="modalLabel">
                  </td>
               <td>
                  </td>
               <td>
                  </td>
           </tr>
       </table>
  </asp:Panel>
  <asp:RoundedCornersExtender ID="RoundedCornersExtender2" 
        runat="server" Enabled="True" TargetControlID="pnlNewParticularModal">
    </asp:RoundedCornersExtender>
  <asp:DropShadowExtender ID="DropShadowExtender1" runat="server" 
        Enabled="True" Opacity="0.5" Rounded="True" TargetControlID="pnlNewCreditParticularModal">
    </asp:DropShadowExtender>


    </ContentTemplate>
  </asp:UpdatePanel>
 
</asp:Content>
