using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegratedResourceManagementSystem.Common;
using IRMS.BusinessLogic.Manager;
using IRMS.Components;
using IRMS.Entities;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class Debit_CreditMemoPanel : System.Web.UI.Page
    {
        private AdjustmentMemoManager AdjusmentMemoManager = new AdjustmentMemoManager();

        private AdjustmentManager AdjustmentManager = new AdjustmentManager();

        private CustomerManager CustomerManager = new CustomerManager();

        public Adjustment ADJUSTMENT { get; set; }

        public AdjustmentMemo ADJUSTMENT_MEMO { get; set; }

        public DateTime DATE_PERIOD_FROM { get; set; }

        public DateTime DATE_PERIOD_TO { get; set; }

        public Customer OUTLET_ { get; set; }

        public string REPORT_MODE { get; set; }

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
                this.btnNewProductCategory.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.Append(" - Permission to Insert/Add Memo.<br />");
            }

            if (Permission.CanUpdate() == false)
            {
                this.btnUpdateProductCategory.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Update/Edit Memo.<br />");
            }

            if (Permission.CanDelete() == false)
            {
                btnDelete.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Delete Memo.<br />");
            }
            lblPermissionNotifications.Text = strPermissionNotification.ToString();

            #endregion check roles
        }

        #endregion Page_init

        protected void btncontinueAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                Image imgCustomer = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                OUTLET_ = CustomerManager.GetCustomerByKey(long.Parse(imgCustomer.AlternateText));
                DATE_PERIOD_FROM = DateTime.Parse(txtDateFrom.Text);
                DATE_PERIOD_TO = DateTime.Parse(txtPeriodTo.Text);
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
            }
        }

        protected void btnPrintAdjustmentMemo_Click(object sender, EventArgs e)
        {
            btnPrintPreviewAdjustment_Click(sender, e);
        }

        protected void btnPrintPreviewAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                REPORT_MODE = "ADJUSTMENT MEMO";
                ADJUSTMENT = AdjustmentManager.GetAdjustmentByKey(long.Parse(this.gvAdjustmentMemos.SelectedRow.Cells[2].Text));
                ADJUSTMENT_MEMO = null;
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
            }
        }

        protected void btnPrintTransactionPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Image img_tran = (Image)gvMemoDetails.SelectedRow.FindControl("imgTransaction");
                REPORT_MODE = "ADJUSTMENT DETAILS";
                ADJUSTMENT_MEMO = AdjusmentMemoManager.GetAdjustmentMemoByKey(long.Parse(img_tran.AlternateText));
                ADJUSTMENT = AdjustmentManager.GetAdjustmentByKey(long.Parse(this.gvAdjustmentMemos.SelectedRow.Cells[2].Text));
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
            }
        }

        protected void btnPrintTransactionSummary_Click(object sender, EventArgs e)
        {
            try
            {
                REPORT_MODE = "ADJUSTMENT SUMMARY";
                ADJUSTMENT = AdjustmentManager.GetAdjustmentByKey(long.Parse(this.gvAdjustmentMemos.SelectedRow.Cells[2].Text));
                ADJUSTMENT_MEMO = null;
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            AdjustmentManager.Delete(AdjustmentManager.GetAdjustmentByKey(long.Parse(gvAdjustmentMemos.SelectedRow.Cells[2].Text)));

            #region log
            AdjustmentManager.Identity = int.Parse(gvAdjustmentMemos.SelectedRow.Cells[2].Text);
            AdjustmentManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.DELETE);
            #endregion log

            lblDeleted_ModalPopupExtender.Show();
        }

        protected void gvAdjustmentMemos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image imgAdjustmentCode = (Image)gvAdjustmentMemos.SelectedRow.FindControl("imgAdjustmentCode");
            hfAdjustmentCode.Value = imgAdjustmentCode.AlternateText;
            hpLinkPreviewSummary.NavigateUrl = "~/Reports/ReportForms/PrintPCountSummary.aspx?AdjustmentCode=" + imgAdjustmentCode.AlternateText + "&RecordNumber=" + gvAdjustmentMemos.SelectedValue.ToString();
            hLinkPreviewAdjustment.NavigateUrl = "~/Reports/ReportForms/PrintAdjustmentPCount.aspx?AdjustmentCode=" + imgAdjustmentCode.AlternateText + "&Id=" + gvAdjustmentMemos.SelectedRow.Cells[2].Text + "&RecordNumber=" + gvAdjustmentMemos.SelectedValue.ToString();
            lblCustomerNameToDelete.Text = "ADJUSTMENT FOR: " + gvAdjustmentMemos.SelectedRow.Cells[3].Text;
            lblDateFromToToDelete.Text = "PERIOD FROM: " +
                gvAdjustmentMemos.SelectedRow.Cells[4].Text + " TO "
                + gvAdjustmentMemos.SelectedRow.Cells[5].Text;
        }

        protected void gvMemoDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PreviewSelectedTransaction();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void gvOutlets_PageIndexChanged(object sender, EventArgs e)
        {
            btnUpdateProductCategory_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateProductCategory_ModalPopupExtender.Show();
        }

        protected void gvOutlets_Sorted(object sender, EventArgs e)
        {
            btnUpdateProductCategory_ModalPopupExtender.Show();
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchAdjustmentMemo();
        }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomerManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                gvOutlets.DataBind();
                btnUpdateProductCategory_ModalPopupExtender.Show();
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

        protected void rdioMemoType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchAdjustmentMemo();
        }

        private void CheckMemoTypeToRedirect(string MemoType)
        {
            switch (MemoType)
            {
                case "DEBIT MEMO":
                    Redirector.Redirect("~/Accounting/MemoForm.aspx");
                    break;

                case "CREDIT MEMO":
                    Response.RedirectLocation = "~/Accounting/CreditMemoForm.aspx";
                    Response.Redirect(Response.RedirectLocation);
                    break;

                default:
                    Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
                    break;
            }
        }

        private void LoadAllAdjustmentMemos(string adjustment_code, GridView gview)
        {
            gview.DataSource = AdjusmentMemoManager.AdjustmentMemosByAdjustmentCode(adjustment_code);
            gview.DataBind();
        }

        private void PreviewSelectedTransaction()
        {
            Image imgAdjustmentDetailsID = (Image)gvMemoDetails.SelectedRow.FindControl("imgTransaction");
            hLinkPrintAdjustmentDetails.NavigateUrl = "~/Reports/ReportForms/PrintPCountAdjustmentSelectedDetails.aspx?IdNumber=" + imgAdjustmentDetailsID.AlternateText + "&Customer=" + Server.UrlEncode(gvAdjustmentMemos.SelectedRow.Cells[5].Text);
        }

        private void SearchAdjustmentMemo()
        {
            AdjustmentManager.SearchPCountAdjustmentDataSource(SqlDataSourcePCountAdjustments, txtSearch.Text, HF_BRAND.Value);
            gvAdjustmentMemos.DataBind();
        }
    }
}