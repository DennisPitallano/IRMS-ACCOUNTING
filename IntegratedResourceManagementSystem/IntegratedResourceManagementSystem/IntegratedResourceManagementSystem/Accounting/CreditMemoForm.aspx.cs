using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class CreditMemoForm : System.Web.UI.Page
    {
        BrandManager BM = new BrandManager();
        ProductManager PM = new ProductManager();
        List<MemoParticular> MemoParticularList = new List<MemoParticular>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllBrands();
                //LoadAllItems();
            }
        }

        private void LoadAllItems()
        {
            dlItems.Items.Clear();
            foreach (Product product in PM.ProductCategories())
            {
                dlItems.Items.Add(new ListItem(product.StyleNumber, product.StyleNumber));
            }
        }
        private void LoadAllBrands()
        {
            dlBrands.Items.Clear();
            foreach (Brand brand in BM.Brands())
            {
                dlBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandCode));
            }
        }

        protected void ibtnAddParticular_Click(object sender, ImageClickEventArgs e)
        {
            //for (int i = 0; i <= gvParticulars.Columns.Count; i++)
            //{
            //    gvParticulars.SelectedRow.Cells.RemoveAt(i);
            //}
            // gvParticulars.DataBind();
        }

        protected void btnAddParticular_Click(object sender, EventArgs e)
        {
            foreach (TableRow row in gvParticulars.Rows)
            {
                MemoParticular memo_p = new MemoParticular();
                memo_p.Particular = row.Cells[0].Text;
                memo_p.Quantity = long.Parse(row.Cells[1].Text);
                memo_p.CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", ""));
                memo_p.CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", ""));
                MemoParticularList.Add(memo_p);
            }
            MemoParticular memo_particular = new MemoParticular();
            // memo_particular = null;
            memo_particular.Particular = dlItems.SelectedValue;
            memo_particular.Quantity = long.Parse(txtParticularQuantity.Text);
            memo_particular.CurrentPrice = decimal.Parse(txtCurrentPrice.Text);
            memo_particular.CostPrice = decimal.Parse(txtCostPrice.Text);
            MemoParticularList.Add(memo_particular);
            gvParticulars.DataSource = MemoParticularList;
            gvParticulars.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.RedirectLocation = "~/Accounting/Debit-CreditMemoPanel.aspx";
            Response.Redirect(Response.RedirectLocation);
        }
    }
}