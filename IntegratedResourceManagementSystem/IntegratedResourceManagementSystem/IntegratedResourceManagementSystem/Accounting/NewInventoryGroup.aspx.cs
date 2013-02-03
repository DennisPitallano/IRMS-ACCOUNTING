using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IRMS.Components;
using IntegratedResourceManagementSystem.Common;
using System.Text;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class NewInventoryGroup : System.Web.UI.Page
    {
        #region variables
        BrandManager brandManager = new BrandManager();
        List<CustomerInventoryGroup> CUSTOMERS { get { return GetSelectedCustomers(); } }
        InventoryGroupManager InvGroupManager = new InventoryGroupManager();
        CustomerInventoryGroupManager CustInvGroupManager = new CustomerInventoryGroupManager();
        BranchManager BranchManager = new BranchManager();
        AccountsManager AccountManager = new AccountsManager();
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            #region check roles
            Permission.PERMITTED_USER = (UsersClass)Session["USER_ACCOUNT"];
            Permission.ROLES = (List<UserRole>)Session["USER_ROLES"];
            if (Permission.CanInsert() == false)
            {
                Redirector.Redirect("~/Accounting/InventoryGroupingManagementPanel.aspx");
            }
            #endregion
            DDLBrands.Items.Clear();
            foreach (var brand in brandManager.Brands())
            {
                DDLBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddSelected_Click(object sender, EventArgs e)
        {
            gvSelectedOutlets.DataSource = AddSelectedCustomers();
            gvSelectedOutlets.DataBind();
        }

        private List<CustomerInventoryGroup> GetSelectedCustomers()
        {
            List<CustomerInventoryGroup> selectedCustomers = new List<CustomerInventoryGroup>();
            foreach (GridViewRow row_customer in this.gvSelectedOutlets.Rows)
            {
                CheckBox ck = ((CheckBox)row_customer.FindControl("chkSelectedItems"));
                Image imgCustomer = (Image)row_customer.FindControl("imgCustomer");
                CustomerInventoryGroup customer = new CustomerInventoryGroup
                    {
                         CustomerNumber = int.Parse(imgCustomer.AlternateText),
                        CustomerName = row_customer.Cells[2].Text,
                        BrandName = row_customer.Cells[3].Text,
                         AccountName = imgCustomer.ToolTip.Split('-')[0],
                          BranchName =imgCustomer.ToolTip .Split('-')[1]
                    };
                        selectedCustomers.Add(customer);
            }
            return selectedCustomers;
        }

        private List<CustomerInventoryGroup> AddSelectedCustomers()
        {
            List<CustomerInventoryGroup> selectedCustomers = CUSTOMERS;
            foreach (GridViewRow row_customer in gvCustomers.Rows)
            {
                CheckBox ck = ((CheckBox)row_customer.FindControl("chkItems"));
                Image imgCustomer = (Image)row_customer.FindControl("imgCustomer");
                if (ck.Checked)
                {
                    CustomerReferenceLink CRL = CustInvGroupManager.GetCustomerLinkByCustCode(imgCustomer.ToolTip);
                    BranchClass branch = BranchManager.GetBranchByCode(CRL.BranchCode);
                    AccountClass account = AccountManager.GetAccountByCode(branch.AccountCode);
                    string BrandName;
                    if (string.IsNullOrEmpty(HttpUtility.HtmlDecode(row_customer.Cells[3].Text)) || 
                        string.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(row_customer.Cells[3].Text)))
                    {
                        BrandName = brandManager.GetBrandByCode(CRL.BrandCode).BrandDescription;
                    }
                    else
                    {
                        BrandName = row_customer.Cells[3].Text;
                    }

                    CustomerInventoryGroup customer = new CustomerInventoryGroup
                    {
                        CustomerNumber = int.Parse(imgCustomer.AlternateText),
                        CustomerName = row_customer.Cells[2].Text,
                        BrandName = BrandName,
                        AccountName = account.AccountName,
                        BranchName = branch.BranchName
                    };
                    if (!IsAlreadySelected(CUSTOMERS, customer.CustomerNumber))
                    {
                        if (string.IsNullOrEmpty(customer.AccountName) || string.IsNullOrWhiteSpace(customer.AccountName))
                        {
                            hfWarningHandler_ModalPopupExtender.Show();
                        }
                        else
                        {
                            selectedCustomers.Add(customer);
                        }
                    }
                }
            }
            return selectedCustomers;
        }

        private List<CustomerInventoryGroup> RemoveSelectedCustomers()
        {
            List<CustomerInventoryGroup> selectedCustomers = new List<CustomerInventoryGroup>();
            foreach (GridViewRow row_customer in this.gvSelectedOutlets.Rows)
            {
                CheckBox ck = ((CheckBox)row_customer.FindControl("chkSelectedItems"));
                Image imgCustomer = (Image)row_customer.FindControl("imgCustomer");

                if (!ck.Checked)
                {
                    CustomerInventoryGroup customer = new CustomerInventoryGroup
                    {
                        CustomerNumber = int.Parse(imgCustomer.AlternateText),
                        CustomerName = row_customer.Cells[2].Text,
                        BrandName = row_customer.Cells[3].Text,
                        AccountName = imgCustomer.ToolTip.Split('-')[0],
                        BranchName = imgCustomer.ToolTip.Split('-')[1]
                    };
                    selectedCustomers.Add(customer);
                }
            }
            return selectedCustomers;
        }


        private bool IsAlreadySelected(List<CustomerInventoryGroup> selected_items, int CustomerId)
        {
            bool result = false;
            foreach (CustomerInventoryGroup customer in selected_items)
            {
                if (customer.CustomerNumber == CustomerId)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            gvSelectedOutlets.DataSource =RemoveSelectedCustomers();
            gvSelectedOutlets.DataBind();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            SaveInventoryGroup();
            Redirector.Redirect("~/Accounting/InventoryGroupingManagementPanel.aspx");
        }

        private void SaveInventoryGroup()
        {
            if (string.IsNullOrEmpty(txtGroupName.Text))
            {
                return;
            }
            InventoryGroup inventoryGroup = new InventoryGroup
            {
                 GroupName = this.txtGroupName.Text
            };
            InvGroupManager.Save(inventoryGroup);
            int inventoryGroupid = InvGroupManager.Identity;
            List<CustomerInventoryGroup> customerInventoryGroups = new List<CustomerInventoryGroup>();
            foreach (var cust_ in CUSTOMERS)
            {
                cust_.InventoryGroupId =inventoryGroupid;
                customerInventoryGroups.Add(cust_);
            }
            foreach (var cig in customerInventoryGroups)
            {
                CustInvGroupManager.Save(cig);
                #region log
                CustInvGroupManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.INSERT);
                #endregion
            }
          
        }

        protected void btnFilterByBrand_Click(object sender, EventArgs e)
        {
            gvCustomers.DataSourceID = "SqlDataSourceOutletsByBrand";
            hfIsFiltered.Value = "1";
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                    InvGroupManager.SearchCustomer(SqlDataSourceOutletsByBrand, txtSearch.Text, DDLBrands.SelectedValue);
            }
        }

        protected void btnReloadOutletList_Click(object sender, EventArgs e)
        {
            gvCustomers.DataSourceID = "SqlDataSourceOutlets";
            hfIsFiltered.Value = "0";
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                    InvGroupManager.SearchCustomer(SqlDataSourceOutlets, txtSearch.Text);
            }
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (hfIsFiltered.Value!="0")
            {
                InvGroupManager.SearchCustomer(SqlDataSourceOutletsByBrand, txtSearch.Text, DDLBrands.SelectedValue);
            }
            else
            {
                InvGroupManager.SearchCustomer(SqlDataSourceOutlets, txtSearch.Text);
            }
        }

        protected void gvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (hfIsFiltered.Value!="0")
                {
                    InvGroupManager.SearchCustomer(SqlDataSourceOutletsByBrand, txtSearch.Text, DDLBrands.SelectedValue);
                }
                else
                {
                    InvGroupManager.SearchCustomer(SqlDataSourceOutlets, txtSearch.Text);
                }
            }
        }

        protected void gvCustomers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (hfIsFiltered.Value != "0")
                {
                    InvGroupManager.SearchCustomer(SqlDataSourceOutletsByBrand, txtSearch.Text, DDLBrands.SelectedValue);
                }
                else
                {
                    InvGroupManager.SearchCustomer(SqlDataSourceOutlets, txtSearch.Text);
                }
            }
        }

         
    }
}