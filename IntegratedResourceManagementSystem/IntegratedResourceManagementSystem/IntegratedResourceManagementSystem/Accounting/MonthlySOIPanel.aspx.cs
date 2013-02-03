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
    public partial class MonthlySOIPanel : System.Web.UI.Page
    {
        #region variables
        MonthlyStoreOutStandingInventoryManager MonthlySOIManager = new MonthlyStoreOutStandingInventoryManager();
        MonthlyStoreOutStandingInventory SOI_TO_DELETE
        {
            get
            {
                return new MonthlyStoreOutStandingInventory
                {
                     RecordNumber = long.Parse(gvMOnthlySOI.SelectedValue.ToString())
                };
            }
        }
        #endregion

        #region Page_init
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
                strPermissionNotification.Append(" - Permission to Insert/Add SOI.<br />");
            }

            if (Permission.CanUpdate() == false)
            {
                this.btnUpdateBookAdjustment.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Update/Edit SOI.<br />");
            }

            if (Permission.CanDelete() == false)
            {
                btnDelete.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Delete SOI.<br />");
            }
            lblPermissionNotifications.Text = strPermissionNotification.ToString();
            #endregion
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            MonthlySOIManager.Delete(SOI_TO_DELETE);
            #region log
            MonthlySOIManager.Identity =(int)SOI_TO_DELETE.RecordNumber;
            MonthlySOIManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.DELETE);
            #endregion log
            gvMOnthlySOI.DataBind();
        }

        protected void gvMOnthlySOI_SelectedIndexChanged(object sender, EventArgs e)
        {
            hLinkPreview.NavigateUrl = "~/Reports/ReportForms/MonthlySOIPrintPreview.aspx?SOINumber=" + gvMOnthlySOI.SelectedValue;

            btnYes.Enabled = true;
            lblDeleteMessage.Text = "Are you sure you want to delete this data? <br /> SOI FOR: " +
                gvMOnthlySOI.SelectedRow.Cells[3].Text + " <br /> PERIOD FROM: "
                + gvMOnthlySOI.SelectedRow.Cells[4].Text +" TO " + gvMOnthlySOI.SelectedRow.Cells[5].Text;
            
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MonthlySOIManager.SearchMonthlySOI(SqlDataSourceMonthlySOI, txtSearch.Text);
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            MonthlySOIManager.SearchMonthlySOI(SqlDataSourceMonthlySOI, txtSearch.Text);
        }

        protected void gvMOnthlySOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                  MonthlySOIManager.SearchMonthlySOI(SqlDataSourceMonthlySOI, txtSearch.Text);
            }
        }

        protected void gvMOnthlySOI_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                MonthlySOIManager.SearchMonthlySOI(SqlDataSourceMonthlySOI, txtSearch.Text);
            }
        }

        protected void gvMOnthlySOI_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                MonthlySOIManager.SearchMonthlySOI(SqlDataSourceMonthlySOI, txtSearch.Text);
            }
        }
    }
}