using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class PrintSOI : System.Web.UI.Page
    {
        StoreOutStandingInventoryManager SOIManager = new StoreOutStandingInventoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.IsNewSession == false)
            {
                if (Session["USER_NAME"] == null)
                {
                    lblPreparedBy.Text ="Admin";
                }
                else
                {
                    lblPreparedBy.Text = Session["USER_NAME"].ToString();
                }
            }
            if (!this.IsPostBack)
            {
                hfSOI_ID.Value = Request.QueryString["SOIID"];
                PreviewSOI(long.Parse(hfSOI_ID.Value));
            }
        }
        private void PreviewSOI(long RecordNumber)
        {
            StoreOutStandingInventory SOI = SOIManager.GetStoreOutStandingInventoryByRecordNumber(RecordNumber);
            lblDateNow.Text = "TRANSACTION DATE: " + DateTime.UtcNow.ToString("dddd, MMMM dd, yyyy");
            //
            lblCustomer.Text = SOI.CustomerName;
            lblDatePeriodFrom.Text = "PERIOD FROM: " + SOI.PeriodFrom.ToString("MMMM dd, yyyy");
            lblDatePerioTo.Text = "TO: " + SOI.PeriodTo.ToString("MMMM dd, yyyy");
            //BI
            if (SOI.BeginningInventoryVolume != 0)
            {
                lblBIVolume.Text = SOI.BeginningInventoryVolume.ToString("###,###");
            }
            else
            {
                lblBIVolume.Text = "(0)";
            }
            lblBIValue.Text = SOI.BeginningInventoryValue.ToString("###,###.00");
            lblBITotalCost.Text = SOI.BeginningInventoryTotalCost.ToString("###,###.00");
            lblBIAverageCost.Text = SOI.BeginningInventoryAverageCost.ToString("###,###.00");
            //Delivery
            lblDeliveryAvgCost.Text = SOI.DeliveryAverageCost.ToString("###,###.00");
            lblDeliveryTotalCost.Text = SOI.DeliveryTotalCost.ToString("###,###.00");
            lblDeliveryValue.Text = SOI.DeliveryValue.ToString("###,###.00");
            if (SOI.DeliveryVolume != 0)
            {
                lblDeliveryVolume.Text = SOI.DeliveryVolume.ToString("###,###");
            }
            else
            {
                lblDeliveryVolume.Text = "(0)";
            }
            //PullOut
            lblPullOutAvgCost.Text = SOI.ReturnsAverageCost.ToString("(###,###.00)");
            lblPullOutTotalCost.Text = SOI.ReturnsTotalCost.ToString("(###,###.00)");
            lblPullOutValue.Text = SOI.ReturnsValue.ToString("(###,###.00)");
            if (SOI.ReturnsVolume != 0)
            {
                lblPullOutVolume.Text = SOI.ReturnsVolume.ToString("(###,###)");
            }
            else
            {
                lblPullOutVolume.Text = "(0)";
            }

            //grossSdales
            lblGrossSalesAvgCost.Text = SOI.GrossSalesAverageCost.ToString("(###,###.00)");
            lblGrossSalesTotalCost.Text = SOI.GrossSalesTotalCost.ToString("(###,###.00)");
            lblGrossSalesValue.Text = SOI.GrossSalesValue.ToString("(###,###.00)");
            if (SOI.GrossSalesVolume != 0)
            {
                lblGrossSalesVolume.Text = SOI.GrossSalesVolume.ToString("(###,###)");
            }
            else
            {
                lblGrossSalesVolume.Text = "(0)";
            }
            //adjustment
            lblDebitAvgCost.Text = SOI.AdjustmentDebitAverageCost.ToString("###,###.00");
            lblDebitTotalCost.Text = SOI.AdjustmentDebitTotalCost.ToString("###,###.00");
            lblDebitValue.Text = SOI.AdjustmentDebitValue.ToString("###,###.00");
            if (SOI.AdjustmentDebitVolume != 0)
            {
                lblDebitVolume.Text = SOI.AdjustmentDebitVolume.ToString("###,###");
            }
            else
            {
                lblDebitVolume.Text = "0";
            }

            lblCreditAvgCost.Text = SOI.AdjustmentCreditAverageCost.ToString("(###,###.00)");
            lblCreditTotalCost.Text = SOI.AdjustmentCreditTotalCost.ToString("(###,###.00)");
            lblCreditValue.Text = SOI.AdjustmentCreditValue.ToString("(###,###.00)");
            if (SOI.AdjustmentCreditVolume != 0)
            {
                lblCreditVolume.Text = SOI.AdjustmentCreditVolume.ToString("(###,###)");

            }
            else
            {
                lblCreditVolume.Text = "(0)";
            }
            //Ending Inventory
            lblEIAvgCost.Text = SOI.EndingInventoryAverageCost.ToString("###,###.00");
            lblEITotalCost.Text = SOI.EndingInventoryTotalCost.ToString("###,###.00");
            lblEIValue.Text = SOI.EndingInventoryValue.ToString("###,###.00");
            if(SOI.EndingInventoryVolume != 0)
            {
                lblEIVolume.Text = SOI.EndingInventoryVolume.ToString("###,###");
            }else{
                lblEIVolume.Text = "(0)";
            }
            //PCount
            lblAPCAvgCost.Text = SOI.ActualCountAverageCost.ToString("###,###.00");
            lblAPCTotalCost.Text = SOI.ActualCostTotalCost.ToString("###,###.00");
            lblAPCValue.Text = SOI.ActualCountValue.ToString("###,###.00");
            if (SOI.ActualCountVolume != 0)
            {
                lblAPCVolume.Text = SOI.ActualCountVolume.ToString("###,###");
            }
            else
            {
                lblAPCVolume.Text = "(0)";
            }
            if (SOI.DiscrepancyVolume > 0)
            {
                lblDiscrepancyVolume.Text = SOI.DiscrepancyVolume.ToString("###,###");
            }
            else
            {
                lblDiscrepancyVolume.Text = (-1*SOI.DiscrepancyVolume).ToString("(###,###)");
            }

            if (SOI.DiscrepancyValue > 0)
            {
                lblDiscrepancyValue.Text = SOI.DiscrepancyValue.ToString("###,###.00");
            }
            else
            {
                lblDiscrepancyValue.Text = (-1*SOI.DiscrepancyValue).ToString("(###,###.00)");
            }

            if (SOI.DiscrepancyTotalCost > 0)
            {
                lblDiscrepancyTotalCost.Text = (SOI.DiscrepancyTotalCost).ToString("###,###.00");
            }
            else
            {
                lblDiscrepancyTotalCost.Text = (-1*SOI.DiscrepancyTotalCost).ToString("(###,###.00)");
            }
           

        }
    }
}