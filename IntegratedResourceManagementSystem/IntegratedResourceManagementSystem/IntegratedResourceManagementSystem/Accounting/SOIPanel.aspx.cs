using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntegratedResourceManagementSystem.Common;
using IRMS.BusinessLogic.Manager;
using IRMS.Components;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class SOIPanel : System.Web.UI.Page
    {
        private StoreOutStandingInventoryManager SOIManager = new StoreOutStandingInventoryManager();

        public long RECORD_NUMBER { get; set; }

        public StoreOutStandingInventory SOI_ { get; set; }
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
                strPermissionNotification.Append(" - Permission to Insert/Add SOI.<br />");
            }

            if (Permission.CanUpdate() == false)
            {
                this.btnUpdateProductCategory.Enabled = false;
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

            #endregion check roles
        }

        #endregion Page_init

        public void GetSoiDetails(StoreOutStandingInventory SOI)
        {
            txtActualAccountAvgCost.Text = SOI.ActualCountAverageCost.ToString("###,###.00");
            txtActualAccountTotalCost.Text = SOI.ActualCostTotalCost.ToString("###,###.00");
            txtActualAccountValue.Text = SOI.ActualCountValue.ToString("###,###.00");
            if (SOI.ActualCountVolume != 0)
            {
                txtActualAccountVolume.Text = SOI.ActualCountVolume.ToString("###,###");
            }
            else
            {
                txtActualAccountVolume.Text = "(0)";
            }

            txtBeginningInventoryAvgCost.Text = SOI.BeginningInventoryAverageCost.ToString("###,###.00");
            txtBeginningInventoryTotalCost.Text = SOI.BeginningInventoryTotalCost.ToString("###,###.00");
            txtBeginningInventoryValue.Text = SOI.BeginningInventoryValue.ToString("###,###.00");
            if (SOI.BeginningInventoryVolume != 0)
            {
                txtBeginningInventoryVolume.Text = SOI.BeginningInventoryVolume.ToString("###,###");
            }
            else
            {
                txtBeginningInventoryVolume.Text = "(0)";
            }
            txtCreditAvgCost.Text = SOI.AdjustmentCreditAverageCost.ToString("(###,###.00)");
            txtCreditTotalCost.Text = SOI.AdjustmentCreditTotalCost.ToString("(###,###.00)");
            txtCreditValue.Text = SOI.AdjustmentCreditValue.ToString("(###,###.00)");
            if (SOI.AdjustmentCreditVolume != 0)
            {
                txtCreditVolume.Text = SOI.AdjustmentCreditVolume.ToString("(###,###)");
            }
            else
            {
                txtCreditVolume.Text = "(0)";
            }

            txtDebitAvgCost.Text = SOI.AdjustmentDebitAverageCost.ToString("###,###.00");
            txtDebitTotalCost.Text = SOI.AdjustmentDebitTotalCost.ToString("###,###.00");
            txtDebitValue.Text = SOI.AdjustmentDebitValue.ToString("###,###.00");
            if (SOI.AdjustmentDebitVolume != 0)
            {
                txtDebitVolume.Text = SOI.AdjustmentDebitVolume.ToString("###,###");
            }
            else
            {
                txtDebitVolume.Text = "0";
            }

            txtDeliveryAvgCost.Text = SOI.DeliveryAverageCost.ToString("###,###.00");
            txtdeliveryTotalCost.Text = SOI.DeliveryTotalCost.ToString("###,###.00");
            txtDeliveryValue.Text = SOI.DeliveryValue.ToString("###,###.00");
            if (SOI.DeliveryVolume != 0)
            {
                txtDeliveryVolume.Text = SOI.DeliveryVolume.ToString("###,###");
            }
            else
            {
                txtDeliveryVolume.Text = "(0)";
            }

            if (SOI.DiscrepancyTotalCost <= 0)
            {
                txtDiscrepancyTotalCost.Text = (-1 * SOI.DiscrepancyTotalCost).ToString("(###,###.00)");
            }
            else
            {
                txtDiscrepancyTotalCost.Text = (SOI.DiscrepancyTotalCost).ToString("###,###.00");
            }
            if (SOI.DiscrepancyVolume <= 0)
            {
                txtDiscrepancyVolume.Text = (-1 * SOI.DiscrepancyVolume).ToString("(###,###)");
            }
            else
            {
                txtDiscrepancyVolume.Text = (SOI.DiscrepancyVolume).ToString("(###,###)");
            }

            if (SOI.DiscrepancyValue <= 0)
            {
                txtDiscrepancyValue.Text = (-1 * SOI.DiscrepancyValue).ToString("(###,###.00)");
            }
            else
            {
                txtDiscrepancyValue.Text = (SOI.DiscrepancyValue).ToString("###,###.00");
            }

            txtEndingInvventoryAvgCost.Text = SOI.EndingInventoryAverageCost.ToString("###,###.00");
            txtEndingInvventoryTotalCost.Text = SOI.EndingInventoryTotalCost.ToString("###,###.00");
            txtEndingInvventoryValue.Text = SOI.EndingInventoryValue.ToString("###,###.00");
            if (SOI.EndingInventoryVolume != 0)
            {
                txtEndingInvventoryVolume.Text = SOI.EndingInventoryVolume.ToString("###,###");
            }
            else
            {
                txtEndingInvventoryVolume.Text = "(0)";
            }

            txtGrossSalesAvgCost.Text = SOI.GrossSalesAverageCost.ToString("(###,###.00)");
            txtGrossSalesTotalCost.Text = SOI.GrossSalesTotalCost.ToString("(###,###.00)");
            txtGrossSalesValue.Text = SOI.GrossSalesValue.ToString("(###,###.00)");
            if (SOI.GrossSalesVolume != 0)
            {
                txtGrossSalesVolume.Text = SOI.GrossSalesVolume.ToString("(###,###)");
            }
            else
            {
                txtGrossSalesVolume.Text = "(0)";
            }
            txtOutletName.Text = SOI.CustomerName;
            txtPeriodFrom.Text = SOI.PeriodFrom.ToString("MMMM dd, yyyy");
            txtPeriodTo.Text = SOI.PeriodTo.ToString("MMMM dd, yyyy");
            txtPullOutAvgCost.Text = SOI.ReturnsAverageCost.ToString("(###,###.00)");
            txtPullOutTotalCost.Text = SOI.ReturnsTotalCost.ToString("(###,###.00)");
            txtPullOutValue.Text = SOI.ReturnsValue.ToString("(###,###.00)");
            if (SOI.ReturnsVolume != 0)
            {
                txtPullOutVolume.Text = SOI.ReturnsVolume.ToString("(###,###)");
            }
            else
            {
                txtPullOutVolume.Text = "(0)";
            }

            txtTransactionDate.Text = SOI.TransactionDate.ToString("MMMM dd, yyyy");
            lblCustomerNameToDelete.Text = "SOI FOR: " + SOI.CustomerName;
            lblDateFromToToDelete.Text = "PERIOD FROM: " + SOI.PeriodFrom.ToString("MMMM dd, yyyy") + " TO " + SOI.PeriodTo.ToString("MMMM dd, yyyy");
        }

        protected void btnPreviewInCrystal_Click(object sender, EventArgs e)
        {
            try
            {
                Image imgSOI = (Image)gvSOI.SelectedRow.FindControl("imgSOI");
                RECORD_NUMBER = long.Parse(imgSOI.AlternateText);
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/SOIPanel.aspx");
            }
        }

        protected void btnPreviewInHtml_Click(object sender, EventArgs e)
        {
            try
            {
                Image imgSOI = (Image)gvSOI.SelectedRow.FindControl("imgSOI");
                RECORD_NUMBER = long.Parse(imgSOI.AlternateText);
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/SOIPanel.aspx");
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                RECORD_NUMBER = long.Parse(gvSOI.SelectedRow.Cells[2].Text);
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/SOIPanel.aspx");
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                Image imgSOI = (Image)gvSOI.SelectedRow.FindControl("imgSOI");
                SOIManager.Delete(SOIManager.GetStoreOutStandingInventoryByRecordNumber(long.Parse(imgSOI.AlternateText)));
                lblDeleted_ModalPopupExtender.Show();
                SqlDataSourceSOI.DataBind();
                gvSOI.DataBind();

                #region log

                SOIManager.Identity = int.Parse(imgSOI.AlternateText);
                SOIManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.DELETE);

                #endregion log
            }
            catch (Exception)
            {
                // throw;
            }
        }

        protected void gvSOI_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);
                Image imgSOI = (Image)gvSOI.SelectedRow.FindControl("imgSOI");
                GetSoiDetails(SOIManager.GetStoreOutStandingInventoryByRecordNumber(long.Parse(imgSOI.AlternateText)));
                hLinkPreviewSoi.NavigateUrl = "~/Reports/ReportForms/PrintSOI.aspx?SOIID=" + imgSOI.AlternateText;
            }
            catch (Exception)
            {
                //  throw;
            }
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SearchSOI();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //gvSOI.DataBind();
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchSOI();
        }

        private void SearchSOI()
        {
            SOIManager.SearchSOIDataSource(SqlDataSourceSOI, txtSearch.Text, HF_BRAND.Value);
            gvSOI.DataBind();
        }
    }
}