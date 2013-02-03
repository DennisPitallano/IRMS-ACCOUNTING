using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Marketing.controls
{
    public partial class StyleSummary : System.Web.UI.UserControl
    {
        ProductManager PM = new ProductManager();
        GarmentManager GM = new GarmentManager();
        BrandManager BM = new BrandManager();
        CategoryManager CM = new CategoryManager();
        ColorManager ColorM = new ColorManager();
        SizeManager SM = new SizeManager();
        FabricManager FM = new FabricManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSummaries();
        }

        private void LoadSummaries()
        {
            lblTotalProductCategories.Text ="Total Products: "+ GetAllProducts().ToString();
            lblTotalProductBrand.Text = "Total Brands: " + GetAllBrands().ToString();
            lblFabricCategories.Text = "Total Fabrics: " + GetAllFabrics().ToString();
            lblGarments.Text = "Total Garments: " + GetAllGarments().ToString();
            lblTotalColors.Text = "Total Colors: " + GetAllColors().ToString();
            lblTotalSize.Text = "Total Sizes: " + GetAllSizes();
        }

        private long GetAllProducts()
        {
           return PM.ProductCategories().Count;
        }

        private long GetAllGarments()
        {
            return GM.Garments().Count;
        }

        private long GetAllBrands()
        {
            return BM.Brands().Count;
        }

        private long GetAllCategories()
        {
            return CM.Categories().Count;
        }

        private long GetAllColors()
        {
            return ColorM.Colors().Count;
        }

        private long GetAllSizes()
        {
            return SM.Sizes().Count;
        }

        private long GetAllFabrics()
        {
            return FM.Fabrics().Count;
        }
    }
}