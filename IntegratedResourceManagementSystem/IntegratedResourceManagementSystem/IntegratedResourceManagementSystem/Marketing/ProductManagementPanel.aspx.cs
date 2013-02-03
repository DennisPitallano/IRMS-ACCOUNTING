using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Marketing
{
    public partial class ProductCategoryManagementPanel : System.Web.UI.Page
    {
        BrandManager BM = new BrandManager();
        FabricManager FM = new FabricManager();
        GarmentManager GM = new GarmentManager();
        SizeManager SM = new SizeManager();
        ColorManager CM = new ColorManager();
        ProductManager PM = new ProductManager();
        CategoryManager CatM = new CategoryManager();

        Product product = new Product();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllBrands();
                LoadAllColors();
                LoadAllSizes();
                LoadAllCategories();
                LoadAllProducts();
            }
        }

        private void LoadAllProducts(string[] search_parameter= null)
        {
            if (search_parameter != null)
            {
                gvProductList.DataSource = PM.SearchProducts(search_parameter);
                gvProductList.DataBind();
            }
            else
            {
                gvProductList.DataSource = PM.ProductCategories().Distinct();
                gvProductList.DataBind();
            }
            txtSKUBarcode.Text = PM.GetLastSKUCode();
            if (txtSKUBarcode.Text == "")
            {
                txtSKUBarcode.Text = "100000000000";
            }
        }

        public void LoadAllBrands()
        {
            dlBrands.Items.Clear();
            dlBrandUpdate.Items.Clear();
            foreach (Brand brand in BM.Brands())
            {
                dlBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandCode));
                dlBrandUpdate.Items.Add(new ListItem(brand.BrandDescription, brand.BrandCode));
            }
        }

        public void LoadAllCategories()
        {
            dlCategory.Items.Clear();
            dlCategoryUpdate.Items.Clear();
            foreach (Category category in CatM.Categories())
            {
                dlCategory.Items.Add(new ListItem(category.CategoryDescription, category.CategoryCode));
                dlCategoryUpdate.Items.Add(new ListItem(category.CategoryDescription, category.CategoryCode));
            }
        }
        
        private void LoadAllGarments(string TopOrBottom)
        {
            dlGarments.Items.Clear();
            dlGarmentUpdate.Items.Clear();
            var garments = from garment in GM.Garments()
                           where garment.TopOrBottom == char.Parse(TopOrBottom)
                           select garment;

            foreach (Garment garment_ in garments)
            {
                dlGarments.Items.Add(new ListItem(garment_.GarmentDescription, garment_.GarmentCode));
                dlGarmentUpdate.Items.Add(new ListItem(garment_.GarmentDescription, garment_.GarmentCode));
            }
        }

        private void LoadAllSizes()
        {
            dlSizes.Items.Clear();
            dlSizeUpdate.Items.Clear();
            foreach (Size size in SM.Sizes())
            {
                dlSizes.Items.Add(new ListItem(size.SizeDescription, size.SizeCode));
                dlSizeUpdate.Items.Add(new ListItem(size.SizeDescription, size.SizeCode));
            }
        }

        private void LoadAllColors()
        {
            dlColors.Items.Clear();
            dlColorUpdate.Items.Clear();
            foreach (Color color in CM.Colors())
            {
                dlColors.Items.Add(new ListItem(color.ColorDescription, color.ColorCode));
                dlColorUpdate.Items.Add(new ListItem(color.ColorDescription, color.ColorCode));
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            PM.Delete(PM.GetProductByKey(long.Parse(gvProductList.SelectedRow.Cells[2].Text)));
            LoadAllProducts();
        }

        protected void btnSaveProductCategory_Click(object sender, EventArgs e)
        {
            string StyleNumber,Description,ItemCode;
            StyleNumber = string.Concat(dlBrands.SelectedValue, "-", dlSex.SelectedValue, "-", this.rdioTopOrBottom.SelectedValue,
                                        "-", dlGarments.SelectedValue, "-", txtSKUBarcode.Text);
            Description = string.Concat(dlBrands.SelectedValue, "-", dlCategory.Text, "-", dlGarments.SelectedValue);
            ItemCode = string.Concat(StyleNumber, "-", dlColors.SelectedValue, "-", dlSizes.SelectedValue);
            
            for(int i =1; i<=int.Parse(txtItems.Text); i++)
            {
                var product_category = new Product
                {
                    StyleNumber = StyleNumber,
                    Description = Description,
                    ItemCode = ItemCode,
                    DateCreated = DateTimeOffset.Now,
                    IsActive = "Yes",
                    SKUBarcode =(long.Parse(txtSKUBarcode.Text)+i).ToString()
                };
                PM.Save(product_category);
            }
            LoadAllProducts();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            product = PM.GetProductByKey(long.Parse(gvProductList.SelectedRow.Cells[2].Text));
            string StyleNumber, Description, ItemCode;
            StyleNumber = string.Concat(dlBrandUpdate.SelectedValue, "-", dlSexUpdate.SelectedValue, "-", this.rdioTopOrBottomUpdate.SelectedValue,
                                        "-", dlGarments.SelectedValue, "-", txtSKUBarcodeUpdate.Text);
            Description = string.Concat(dlBrandUpdate.SelectedValue, "-", dlCategoryUpdate.Text, "-", dlGarmentUpdate.SelectedValue);
            ItemCode = string.Concat(StyleNumber, "-", dlColorUpdate.SelectedValue, "-", dlSizeUpdate.SelectedValue);
            product.StyleNumber = StyleNumber;
            product.Description = Description;
            product.ItemCode = ItemCode;
            product.SKUBarcode = txtSKUBarcodeUpdate.Text;
            PM.Save(product);
            LoadAllProducts();
        }

        protected void gvProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStyleNumber.Text = gvProductList.SelectedRow.Cells[3].Text;
            this.gvSKUDetails.DataSource = PM.GetProductByStyleNumber(gvProductList.SelectedRow.Cells[3].Text);
            this.gvSKUDetails.DataBind();
            //product = PM.GetProductByKey(long.Parse(gvProductList.SelectedRow.Cells[2].Text));
            //string[] StyleNumber = product.StyleNumber.Split('-');
            //dlBrandUpdate.SelectedValue = StyleNumber[0];
            //dlSexUpdate.SelectedValue = StyleNumber[1];
            //rdioTopOrBottomUpdate.SelectedValue = StyleNumber[2];
            //LoadAllGarments(StyleNumber[2]);
            //dlGarmentUpdate.SelectedValue = StyleNumber[3];
            //txtSKUBarcodeUpdate.Text = StyleNumber[4];
            //rdioTopOrBottomUpdate_SelectedIndexChanged(sender, e);
        }

        protected void dlSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdioTopOrBottom_SelectedIndexChanged(sender, e);
        }

        protected void rdioTopOrBottomUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdioTopOrBottomUpdate.SelectedIndex == 0)
            {
                if (dlSexUpdate.SelectedValue == "M")
                {
                    imgTopOrBottomUpdate.ImageUrl = "~/Resources/unisex_polo_.png";
                }
                else
                {
                    imgTopOrBottomUpdate.ImageUrl = "~/Resources/Dress_.png";
                }
            }
            else
            {
                if (dlSexUpdate.SelectedValue == "M")
                {
                    imgTopOrBottomUpdate.ImageUrl = "~/Resources/unisex_pants1_.png";
                }
                else
                {
                    imgTopOrBottomUpdate.ImageUrl = "~/Resources/skirts_.png";
                }
            }
            btnUpdateProductCategory_ModalPopupExtender.Show();
        }

        protected void rdioTopOrBottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllGarments(rdioTopOrBottom.SelectedValue);
            if (rdioTopOrBottom.SelectedIndex == 0)
            {
                if (dlSex.SelectedValue == "M")
                {
                    imgTopOrBottom.ImageUrl = "~/Resources/unisex_polo_.png";
                }
                else
                {
                    imgTopOrBottom.ImageUrl = "~/Resources/Dress_.png";
                }
            }
            else
            {
                if (dlSex.SelectedValue == "M")
                {
                    imgTopOrBottom.ImageUrl = "~/Resources/unisex_pants1_.png";
                }
                else
                {
                    imgTopOrBottom.ImageUrl = "~/Resources/skirts_.png";
                }
            }
            btnNewProductCategory_ModalPopupExtender.Show();
        }

        protected void dlSexUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdioTopOrBottom_SelectedIndexChanged(sender, e);
        }
    }
}