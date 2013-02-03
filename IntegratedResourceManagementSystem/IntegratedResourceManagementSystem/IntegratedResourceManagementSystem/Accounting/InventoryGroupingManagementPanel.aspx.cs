using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IntegratedResourceManagementSystem.Common;
using System.Text;
using IRMS.Components;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class InventoryGroupingManagementPanel : System.Web.UI.Page
    {
        #region variables
        InventoryGroupManager invGroupManager = new InventoryGroupManager();
        CustomerInventoryGroupManager custInvGroupManager = new CustomerInventoryGroupManager();
        InventoryGroup selectedInventoryGroup
        {
            get
            {
                return new InventoryGroup
                {
                     GroupName = gvInventoryGroups.SelectedRow.Cells[3].Text ,
                      InventoryGroupId = long.Parse(gvInventoryGroups.SelectedValue.ToString())
                };
            }
        }
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            #region check roles
            Permission.PERMITTED_USER = (UsersClass)Session["USER_ACCOUNT"];

            Permission.ROLES = (List<UserRole>)Session["USER_ROLES"];
            StringBuilder strPermissionNotification = new StringBuilder();
            strPermissionNotification.Append("Your Account do not have: <br />");
            if (Permission.CanInsert() == false)
            {
                pnlNotification.Visible = true;
                strPermissionNotification.Append(" - Permission to Insert/Add Grouping.<br />");
            }

            if (Permission.CanUpdate() == false)
            {
                this.btnUpdateBookAdjustment.Enabled = false;
                btnChangeGroup.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Update/Edit Grouping.<br />");
            }

            if (Permission.CanDelete() == false)
            {
                btnDelete.Enabled = false;
                btnDeleteFromGroup.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Delete Grouping.<br />");
            }
            lblPermissionNotifications.Text = strPermissionNotification.ToString();
            #endregion

            DDLInvventoryGroups.Items.Clear();
            foreach (var inv_group in this.invGroupManager.InventoryGroups())
            {
                DDLInvventoryGroups.Items.Add(new ListItem(inv_group.GroupName, inv_group.InventoryGroupId.ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvInventoryGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFromGroup.Text = gvInventoryGroups.SelectedRow.Cells[3].Text;
            txtGroupToUpdate.Text = txtFromGroup.Text;
            hfGroupIdToUpdate.Value = gvInventoryGroups.SelectedRow.Cells[2].Text;
            hpLinkAddCustomer.NavigateUrl="AddNewCustomerToGroup.aspx?GroupNumber="+gvInventoryGroups.SelectedValue.ToString()+"&GroupName="+txtGroupToUpdate.Text;
            hpLinkPrint.NavigateUrl = "~/Reports/ReportForms/InventoryGroupPrintPreview.aspx?GroupNumber="
                + gvInventoryGroups.SelectedValue.ToString() + "&GroupName=" + txtGroupToUpdate.Text;
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            var newGroup = new InventoryGroup
            {
                GroupName = txtGroupToUpdate.Text,
                 InventoryGroupId =selectedInventoryGroup.InventoryGroupId
            };

            invGroupManager.Save(newGroup);
            gvInventoryGroups.DataBind();
        }

        protected void btnDeleteGroupYes_Click(object sender, EventArgs e)
        {
            invGroupManager.Delete(selectedInventoryGroup);
            #region log
            invGroupManager.Identity =(int)selectedInventoryGroup.InventoryGroupId;
            invGroupManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.DELETE);
            #endregion log

            gvInventoryGroups.DataBind();
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchInventoryGroups();
        }

        private void SearchInventoryGroups()
        {
            invGroupManager.SearchInventoryGroup(SqlDataSourceInventoryGroups, txtSearch.Text);
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchInventoryGroups();
        }

        protected void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void SearchCustomer()
        {
            invGroupManager.SearchCustomerInventoryGroup(SqlDataSourceCustomerInventoryGroups, long.Parse(hfGroupIdToUpdate.Value), txtSearchCustomer.Text);
        }

        protected void btnReloadCustomerList_Click(object sender, EventArgs e)
        {
            invGroupManager.SearchCustomerInventoryGroup(SqlDataSourceCustomerInventoryGroups, long.Parse(hfGroupIdToUpdate.Value),"");
        }

        protected void gvCustomerList_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchCustomer.Text))
            {
                SearchCustomer();
            }
        }

        protected void gvCustomerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchCustomer.Text))
            {
                SearchCustomer();
            }
        }

        private List<CustomerInventoryGroup> GetSelectedCustomers()
        {
            List<CustomerInventoryGroup> selectedCustomers = new List<CustomerInventoryGroup>();
            foreach (GridViewRow customer_ in this.gvCustomerList.Rows)
            {
                CheckBox ck = ((CheckBox)customer_.FindControl("chkItems"));
                Image imgCustomer = (Image)customer_.FindControl("imgCustomer");
                if (ck.Checked)
                {
                    CustomerInventoryGroup customer = new CustomerInventoryGroup
                    {
                        RecordNumber = long.Parse(imgCustomer.AlternateText),
                        CustomerNumber = int.Parse(customer_.Cells[2].Text),
                        CustomerName = customer_.Cells[3].Text,
                        BrandName = customer_.Cells[4].Text,
                        InventoryGroupId = long.Parse(hfGroupIdToUpdate.Value),
                        AccountName = imgCustomer.ToolTip.Split('-')[0],
                        BranchName =imgCustomer.ToolTip .Split('-')[1]
                    };
                    selectedCustomers.Add(customer);
                }
            }
            return selectedCustomers;
        }

        protected void btnChangeGroupSave_Click(object sender, EventArgs e)
        {
            var inventoryGroup = new InventoryGroup
            {
                InventoryGroupId = long.Parse(DDLInvventoryGroups.SelectedValue),
                GroupName = DDLInvventoryGroups.SelectedItem.Text
            };
            foreach (var customer in GetSelectedCustomers())
            {
                if (custInvGroupManager.IsCustomerAlreadyExistInGroup(customer.CustomerNumber,inventoryGroup)== false){
                    customer.InventoryGroupId = inventoryGroup.InventoryGroupId;
                    custInvGroupManager.Save(customer);
                    #region log
                    custInvGroupManager.Identity = (int)customer.RecordNumber;
                    custInvGroupManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.UPDATE);
                    #endregion
                }
            }
           
            gvCustomerList.DataBind();
        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            List<CustomerInventoryGroup> customersToDelete = GetSelectedCustomers();
            custInvGroupManager.Delete(customersToDelete);
            #region log
            foreach (var customer in customersToDelete)
            {
                custInvGroupManager.Identity =(int)customer.RecordNumber;
                custInvGroupManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.DELETE);
            }
            #endregion
            gvCustomerList.DataBind();
        }
    }
}