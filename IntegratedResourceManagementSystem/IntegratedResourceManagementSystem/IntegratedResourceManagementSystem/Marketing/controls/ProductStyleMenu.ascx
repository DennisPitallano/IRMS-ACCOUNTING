<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductStyleMenu.ascx.cs" 
Inherits="IntegratedResourceManagementSystem.Marketing.controls.ProductStyleMenu" %>
 <style type ="text/css" >
   .mnuIcon
    {
        width:80px;
        height:75px;
        background-image:url('/Resources/submenu.png');
        background-repeat:no-repeat;
        padding-left: 15px;
        padding-top: 3px;
    }
     .mnuIcon:hover
    {
        background-image:url('/Resources/submenuh.png');
        background-repeat:no-repeat;
        padding-left: 17px;
        color: Gray;
    }
     .lblMenu
    {
        cursor:pointer;
        text-align:center;
    }
    .lblMenu:hover
    {
        cursor:pointer;
    }
</style>
 <div style ="float:left; width: 100px; margin-right:5px;">
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnProductCategories" runat="server" 
                    ImageUrl="~/Resources/product.png" Height="32px" Width="38px" 
                    ToolTip="Manage Item" 
                    PostBackUrl="~/Marketing/ProductManagementPanel.aspx" />
                    <br />
                <asp:Label ID="lblProductCategories" runat="server" Text="MANAGE ITEMS" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Items" Font-Bold="True"></asp:Label>
            </div>
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnBrand" runat="server" 
                    ImageUrl="~/Resources/product_brand.png" Height="34px" Width="47px" ToolTip="Manage Brands" 
                    PostBackUrl="~/Marketing/BrandManagementPanel.aspx" />
                    <br />
                <asp:Label ID="lblProductBrand" runat="server" Text="MANAGE BRANDS" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Brands" Font-Bold="True"></asp:Label>
            </div>
              <div class ="mnuIcon">
                <asp:ImageButton ID="ibtnCategories" runat="server" 
                    ImageUrl="~/Resources/category.png" Height="42px"  ToolTip="Manage Categories" 
                    PostBackUrl="~/Marketing/CategoryManagementPanel.aspx" />
                    <br />
                <asp:Label ID="lblCategories" runat="server" Text="Categories" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Product Brands" Font-Bold="True"></asp:Label>
            </div>
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnFabricCategories" runat="server" 
                    ImageUrl="~/Resources/knits_.png" Height="39px" Width="60px" 
                    ToolTip="Manage Fabric Categories" 
                    PostBackUrl="~/Marketing/FabricManagementPanel.aspx" />
                    <br />
                <asp:Label ID="lblFabricCategories" runat="server" Text="FABRICS" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Fabric Categories" Font-Bold="True"></asp:Label>
            </div>
        </div>
        <div style ="float:left; width: 100px; margin-right:5px;">
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnGarmets" runat="server" 
                    ImageUrl="~/Resources/garments.png" Height="46px" Width="51px" 
                    ToolTip="Manage Garments" 
                    PostBackUrl="~/Marketing/GarmentManagementPanel.aspx" />
                    <br />
                <asp:Label ID="lblGarments" runat="server" Text="GARMENTS" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Garments" Font-Bold="True"></asp:Label>
            </div>
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnColors" runat="server" 
                    ImageUrl="~/Resources/color.png" Height="46px" Width="49px"  
                    ToolTip="Manage Product Colors" 
                    PostBackUrl="~/Marketing/ColorManagementPanel.aspx" />
                    <br />
                <asp:Label ID="Label2" runat="server" Text="COLORS" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Product Colors" Font-Bold="True"></asp:Label>
            </div>
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnSize" runat="server" 
                    ImageUrl="~/Resources/size.png" Height="32px" Width="32px" 
                    ToolTip="Manage Product Sizes" 
                    PostBackUrl="~/Marketing/SizeManagementPanel.aspx" />
                    <br />
                <asp:Label ID="Label3" runat="server" Text=" MANAGE SIZES" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage Product Sizes" Font-Bold="True"></asp:Label>
            </div>
        </div>
        <div style ="float:left; width: 100px; margin-right:5px;">
            <div class ="mnuIcon">
                <asp:ImageButton ID="imgBtnSKUBarcode" runat="server" 
                    ImageUrl="~/Resources/Barcode.png" Height="34px" Width="52px" 
                    ToolTip="Manage SKU Barcode" 
                    PostBackUrl="~/Marketing/SkuBarcodeManagementPanel.aspx" />
                    <br />
                <asp:Label ID="Label1" runat="server" Text=" SKU's  Barcode" 
                    CssClass ="lblMenu" Font-Names="Verdana" Font-Size="10px" 
                    ToolTip="Manage SKU Barcode" Font-Bold="True"></asp:Label>
            </div>
        </div>
