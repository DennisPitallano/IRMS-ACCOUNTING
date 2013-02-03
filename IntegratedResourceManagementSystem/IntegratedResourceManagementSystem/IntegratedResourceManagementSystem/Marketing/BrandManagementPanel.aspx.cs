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
    public partial class BrandManagementPanel : System.Web.UI.Page
    {
        BrandManager BM = new BrandManager();
        Brand brand = new Brand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllBrands();
            }
        }

        private void LoadAllBrands(string[] search_parameter=null)
        {
            if (search_parameter != null)
            {
                gvBrandList.DataSource = BM.SearchBrands(search_parameter);
                gvBrandList.DataBind();
            }
            else
            {
                gvBrandList.DataSource = BM.Brands();
                gvBrandList.DataBind();
            }
        }

        private void Search()
        {
            string[] search_parmeter = new string[1];
            search_parmeter[0] = txtSearch.Text;
            LoadAllBrands(search_parmeter);
        }

        protected void gvGarmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            brand = BM.GetBrandByKey(long.Parse(gvBrandList.SelectedRow.Cells[2].Text));
            txtBrandCodeUpdate.Text = brand.BrandCode;
            txtBranDescriptionUpdate.Text = brand.BrandDescription;
        }

        protected void btnSaveBrand_Click(object sender, EventArgs e)
        {
            var brand = new Brand{
                BrandCode = txtBrandCode.Text.ToUpper(),
                BrandDescription = txtBrandDescription.Text.ToUpper(),
                DateCreated = DateTimeOffset.Now ,
                IsActive = "Yes"
            };
            BM.Save(brand);
            txtBrandCode.Text = null;
            txtBrandDescription.Text = null;
            LoadAllBrands();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            brand = BM.GetBrandByKey(long.Parse(gvBrandList.SelectedRow.Cells[2].Text));
            brand.BrandCode = txtBrandCodeUpdate.Text.ToUpper();
            brand.BrandDescription = txtBranDescriptionUpdate.Text.ToUpper();
            BM.Save(brand);
            LoadAllBrands();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            BM.Delete(BM.GetBrandByKey(long.Parse(gvBrandList.SelectedRow.Cells[2].Text)));
            LoadAllBrands();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}