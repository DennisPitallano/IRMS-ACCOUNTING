<%@ Page Title="" Language="C#" MasterPageFile="~/Accounting/Accounting.Master" AutoEventWireup="true" CodeBehind="DeliveryDetailsPreview.aspx.cs" Inherits="IntegratedResourceManagementSystem.Accounting.DeliveryDetailsPreview" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/querystring-0.9.0-min.js" type="text/javascript"></script>
    <link href="../Styles/modal-controls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/my-user-account.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/grid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #MainContent_gvDRSummary th
        {
            padding-left:3px;
            padding-right:3px;
        }
         #MainContent_gvDRSummary tr td
        {
            padding-left:3px;
            padding-right:3px;
        }
          #MainContent_gvDRDetails th
        {
            padding-left:3px;
            padding-right:3px;
        }
         #MainContent_gvDRDetails tr td
        {
            padding-left:3px;
            padding-right:3px;
        }
    </style>
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="info-container" style="width:550px;">
    <div style="height: 14px; font-size: 10px;color: #4E5913;text-shadow: 1px 1px 0px #A0B051;text-align: left;" class ="modalDrag">
        DR DETAILS
    </div>
        <table style="">
            <tr>
                <td class="modalLabel">
                  DR #:
                </td>
                <td>
                    <asp:Label ID="lblDRNumber" CssClass="modalText" Height="18px" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="modalLabel">
                   STATUS:
                </td>
                 <td>
                   <asp:Label CssClass="modalText" Height="18px" ID="lblStatus" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="modalLabel">
                    DELIVERY DATE:
                </td>
                <td>
                    <asp:Label ID="lblDeliveryDate" CssClass="modalText" Height="18px" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="modalLabel">
                    PL #:
                </td>
                 <td>
                   <asp:Label CssClass="modalText" Height="18px" ID="lblPLNumber" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="modalLabel">
                   DELIVERED TO:
                </td>
                <td colspan="3">
                    <asp:Label CssClass="modalText" Height="18px" ID="lblDeliveredTo" runat="server" Text="Label"></asp:Label>
                   
                </td>
            </tr>
        </table>
        <hr />
        <asp:Panel ID="pnlConfirmedDetails" Visible="false" runat="server">       
        
        <table style="">
            <tr>
                <td class="modalLabel">
                  WAYBILL:
                </td>
                <td>
                    <asp:Label CssClass="modalText" Height="18px" ID="lblWayBillNumber" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="modalLabel">
                   FORWARDER:
                </td>
                <td>
                   <asp:Label CssClass="modalText" Height="18px" ID="lblForwarder" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="modalLabel">
                     CONFIRMATION DATE:
                </td>
                <td>
                   <asp:Label CssClass="modalText" Height="18px" ID="lblConfirmationDate" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
   
   <div class="info-container" style="width:700px;">
    <div style=" font-size: 10px;color: #4E5913;text-shadow: 1px 1px 0px #A0B051;text-align: left;" class ="modalDrag">
           VIEW :
        <asp:RadioButtonList CssClass="modalText" Height="22px" Font-Size="11px" 
               ID="rdioDetailsView" runat="server" AutoPostBack="True" 
               RepeatDirection="Horizontal" RepeatLayout="Flow" 
               onselectedindexchanged="rdioDetailsView_SelectedIndexChanged">
            <asp:ListItem Selected="True">SUMMARY</asp:ListItem>
            <asp:ListItem>DETAILS</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div style="margin:10px;">
        <asp:MultiView ID="mvIew" runat="server" ActiveViewIndex="0">
            <asp:View ID="vSummary" runat="server">
               <asp:GridView ID="gvDRSummary" runat="server" 
            AllowSorting="True" CssClass="table_grid" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSourceDRSummary" EnableViewState="False" 
            ViewStateMode="Disabled">
            <Columns>
                <asp:BoundField DataField="DRID" HeaderText="DRID" SortExpression="DRID" 
                    Visible="False" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="StyleNo" HeaderText="STYLE #" 
                    SortExpression="StyleNo" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="BrandName" HeaderText="BRAND" 
                    SortExpression="BrandName" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" 
                    SortExpression="Quantity" >
                <HeaderStyle Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Unit" HeaderText="UNIT" SortExpression="Unit" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitPrice" HeaderText="UNIT PRICE" 
                    SortExpression="UnitPrice" DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="AMOUNT" 
                    SortExpression="Amount" DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceDRSummary" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>" 
            
            SelectCommand="SELECT [DRID], [StyleNo], [BrandName], [Quantity], [Unit], [UnitPrice], [Amount] FROM [DRSumm] WHERE ([DRID] = @DRID)" 
            EnableCaching="True" EnableViewState="False">
            <SelectParameters>
                <asp:QueryStringParameter Name="DRID" QueryStringField="DRID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
            </asp:View>
            <asp:View ID="vDetails" runat="server">   
             <asp:GridView ID="gvDRDetails"  CssClass="table_grid" runat="server" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSourceDRDetails" ViewStateMode="Disabled">
            <Columns>
                <asp:BoundField DataField="SKU" HeaderText="SKU" SortExpression="SKU" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="StyleNo" HeaderText="STYLE #" 
                    SortExpression="StyleNo" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Articles" HeaderText="ARTICLES" 
                    SortExpression="Articles" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="QUANTITY" 
                    SortExpression="Quantity" >
                <HeaderStyle Wrap="False" />
                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Unit" HeaderText="UNIT" SortExpression="Unit" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitPrice" HeaderText="UNIT PRICE" 
                    SortExpression="UnitPrice" DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="AMOUNT" 
                    SortExpression="Amount" DataFormatString="{0:###,###.00}" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceDRDetails" runat="server" 
            ConnectionString="<%$ ConnectionStrings:IRMSConnectionString %>" 
            
            SelectCommand="SELECT [SKU], [StyleNo], [Articles], [Quantity], [Unit], [UnitPrice], [Amount] FROM [DRDtl] WHERE ([DRID] = @DRID)" 
            EnableCaching="True" EnableViewState="False" ViewStateMode="Disabled">
            <SelectParameters>
                <asp:QueryStringParameter Name="DRID" QueryStringField="DRID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
            </asp:View>
        </asp:MultiView>
     
       
       
        </div>
        </div>
 
</asp:Content>
