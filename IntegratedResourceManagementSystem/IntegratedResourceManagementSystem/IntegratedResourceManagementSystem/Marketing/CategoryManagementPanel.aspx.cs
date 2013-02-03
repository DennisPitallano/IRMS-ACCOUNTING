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
    public partial class CategoryManagementPanel : System.Web.UI.Page
    {
        CategoryManager CM = new CategoryManager();
        Category category = new Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllCategories();
            }
        }

        private void LoadAllCategories(string[] search_parameter= null)
        {
            if (search_parameter != null)
            {
                gvProductCategoryList.DataSource = CM.SearchCategories(search_parameter);
                gvProductCategoryList.DataBind();
            }
            else
            {
                gvProductCategoryList.DataSource = CM.Categories();
                gvProductCategoryList.DataBind();
            }
        }

        protected void btnSaveProductCategory_Click(object sender, EventArgs e)
        {
            var category = new Category
            {
              CategoryCode = txtCategoryCode.Text.ToUpper(),
              CategoryDescription = txtCategoryDescription.Text.ToUpper(),
              DateCreated = DateTimeOffset.Now ,
              IsActive = "Yes"
            };
            CM.Save(category);
            txtCategoryCode.Text = null;
            txtCategoryDescription.Text = null;
            LoadAllCategories();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            category = CM.GetCategoryByKey(long.Parse(gvProductCategoryList.SelectedRow.Cells[2].Text));
            category.CategoryCode  = txtCategoryUpdate.Text.ToUpper();
            category.CategoryDescription = txtCategoryDescriptionUpdate.Text.ToUpper();
            CM.Save(category);
            LoadAllCategories();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
          CM.Delete(CM.GetCategoryByKey(long.Parse(gvProductCategoryList.SelectedRow.Cells[2].Text)));
          LoadAllCategories();
        }

        protected void gvProductCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            category = CM.GetCategoryByKey(long.Parse(gvProductCategoryList.SelectedRow.Cells[2].Text));
            txtCategoryUpdate.Text = category.CategoryCode;
            txtCategoryDescriptionUpdate.Text = category.CategoryDescription;
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string[] search_parameter = new string[1];
            search_parameter[0] = txtSearch.Text;
            LoadAllCategories(search_parameter);
        }
       
    }
}