using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.Entities;
using IRMS.Components;
using IntegratedResourceManagementSystem.Common;
using System.Text;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class BookAdjustmentPanel : System.Web.UI.Page
    {
        BookAdjustmentManager BookAdjustmentManager = new BookAdjustmentManager();

        CustomerManager CustomerManager = new CustomerManager();

        public Customer OUTLET_ { get; set; }
        public DateTime PERIOD_FROM_ { get; set; }
        public DateTime PERIOD_TO_ { get; set; }
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
                this.btnNewBookAdjustment.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.Append(" - Permission to Insert/Add Adjustment.<br />");
            }

            if (Permission.CanUpdate() == false)
            {
                this.btnUpdateBookAdjustment.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Update/Edit Adjustment.<br />");
            }

            if (Permission.CanDelete() == false)
            {
                btnDelete.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Delete Adjustment.<br />");
            }
            lblPermissionNotifications.Text = strPermissionNotification.ToString();
            #endregion
        }
        #endregion

        public void GetBookAdjustmentsbyAdjustmentCode(string ADJUSTMENT_CODE)
        {
            gvMemoDetails.DataSource = BookAdjustmentManager.GetBookAdjustmentMemosByAdjustmentCode(ADJUSTMENT_CODE);
            gvMemoDetails.DataBind();
        }

        public void LoadAllBookAdjustments()
        {
            gvAdjustmentMemos.DataBind();
            gvMemoDetails.DataBind();
        }

        protected void btncontinueAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                Image imgCustomer = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                OUTLET_ = CustomerManager.GetCustomerByKey(long.Parse(imgCustomer.AlternateText));
                PERIOD_FROM_ = DateTime.Parse(txtDateFrom.Text);
                PERIOD_TO_ = DateTime.Parse(txtPeriodTo.Text);
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/BookAdjustmentPanel.aspx");
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            BookAdjustmentManager.Delete(BookAdjustmentManager.GetBookAdjustmentByKey(long.Parse(gvAdjustmentMemos.SelectedRow.Cells[2].Text)));
            #region log
            BookAdjustmentManager.Identity = int.Parse(gvAdjustmentMemos.SelectedRow.Cells[2].Text);
            BookAdjustmentManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.DELETE);
            #endregion log

            lblDeleted_ModalPopupExtender.Show();
            LoadAllBookAdjustments();
        }

        protected void gvAdjustmentMemos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image imgAdjustmentCode = new Image();
            imgAdjustmentCode = (Image)gvAdjustmentMemos.SelectedRow.FindControl("imgAdjustmentCode");
            GetBookAdjustmentsbyAdjustmentCode(imgAdjustmentCode.AlternateText);
            hLinkPreviewSummary.NavigateUrl = "~/Reports/ReportForms/PrintBookAdjustmentSummary.aspx?AdjustmentCode=" + imgAdjustmentCode.AlternateText + "&Outlet=" + gvAdjustmentMemos.SelectedRow.Cells[3].Text;
            hLinkPreviewAdjustmentMemo.NavigateUrl = "~/Reports/ReportForms/PrintBookAdjustment.aspx?AdjustmentCode=" + imgAdjustmentCode.AlternateText + "&Outlet=" + gvAdjustmentMemos.SelectedRow.Cells[3].Text;
            lblCustomerNameToDelete.Text = "ADJUSTMENT FOR: " + gvAdjustmentMemos.SelectedRow.Cells[3].Text;
            lblDateFromToToDelete.Text = "PERIOD FROM: " +
                gvAdjustmentMemos.SelectedRow.Cells[4].Text + " TO "
                + gvAdjustmentMemos.SelectedRow.Cells[5].Text;
        }

        protected void gvMemoDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Image imgAdjustmentDetailsID = (Image)gvMemoDetails.SelectedRow.FindControl("imgTransaction");
                hLinkPrintAdjustmentDetails.NavigateUrl = "~/Reports/ReportForms/PrintBookAdjustmentSelectedDetails.aspx?ID=" + imgAdjustmentDetailsID.AlternateText + "&Outlet=" + Server.UrlEncode(gvAdjustmentMemos.SelectedRow.Cells[5].Text);
            }
            catch (Exception)
            {

                // throw;
            }
        }

        protected void gvOutlets_PageIndexChanged(object sender, EventArgs e)
        {
            btnUpdateBookAdjustment_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateBookAdjustment_ModalPopupExtender.Show();
        }

        protected void gvOutlets_Sorted(object sender, EventArgs e)
        {
            btnUpdateBookAdjustment_ModalPopupExtender.Show();
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchAdjustment();

        }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomerManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                gvOutlets.DataBind();
                btnUpdateBookAdjustment_ModalPopupExtender.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
               
             
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchAdjustment();
        }

        private void SearchAdjustment()
        {
                BookAdjustmentManager.SearchBookAdjustments(SqlDataSourceBookAdjustments, txtSearch.Text,HF_BRAND.Value);
            //}
            gvAdjustmentMemos.DataBind();
            gvMemoDetails.DataBind();
        }
    }
}