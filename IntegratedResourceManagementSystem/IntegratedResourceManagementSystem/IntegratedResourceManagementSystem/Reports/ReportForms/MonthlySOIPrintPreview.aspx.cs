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
    public partial class MonthlySOIPrintPreview : System.Web.UI.Page
    {
        #region variables
        MonthlyStoreOutStandingInventoryManager MSOIManager = new MonthlyStoreOutStandingInventoryManager();
        MonthlySOIAdjustmentManager MSOIAdjustmentmanger = new MonthlySOIAdjustmentManager();
        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {
          UsersClass User= (UsersClass)Session["USER_ACCOUNT"];
          if (string.IsNullOrEmpty(User.FullName))
          {
              lblUser.Text = User.Username;
          }
          else
          {
              lblUser.Text = User.FullName;
          }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeData();
            }
        }

        private void InitializeData()
        {
            
            MonthlyStoreOutStandingInventory SOI = MSOIManager.GetMonthlySOIByKey(long.Parse(Request.QueryString["SOINumber"]));
            lblCustomer.Text = SOI.CustomerName;
            lblDateFrom.Text = SOI.PeriodFrom.ToString("MMMM dd, yyyy");
            lblDateTo.Text = SOI.PeriodTo.ToString("MMMM dd, yyyy");
            lblInventoryDate.Text = SOI.InventoryDate.ToString("MMMM dd, yyyy");

            lblActualPCount.Text = SOI.ActualPhysicalCount.ToString("###,###");
            lblDateDeliveriesFromQty.Text = SOI.DeliveryQtyFrom.ToString("###,###");
            lblDateDeliveriesToQty.Text = SOI.DeliveryQtyTo.ToString("###,###");
            lblTotalDeliveries.Text = (SOI.DeliveryQtyFrom + SOI.DeliveryQtyTo+SOI.DeliveriesMiddle).ToString("###,###");

            lblSalesFromQty.Text = SOI.SalesQtyFrom.ToString("###,###");
            lblSalesToQty.Text = SOI.SalesQtyTo.ToString("###,###");
            lblTotalSales.Text = (SOI.SalesQtyFrom + SOI.SalesQtyTo+SOI.SalesMiddle).ToString("(###,###)");

            if (SOI.DeliveriesMiddle!=0)
            {
                DateTime date_f = new DateTime(SOI.PeriodFrom.Year,SOI.PeriodFrom.AddMonths(1).Month,1);
                DateTime date_t = new DateTime(date_f.Year ,date_f.Month ,DateTime.DaysInMonth(date_f.Year ,date_f.Month));
                hpLinkMiddleDateDelivery.Text = date_f.ToString("MMMM dd")+"-"+date_t.ToString("dd yyyy");
                lblMiddleDateSales.Text = hpLinkMiddleDateDelivery.Text;
                hpLinkMiddleDateDelivery.Visible = true;
                lblMiddleDateDeliveryQty.Visible = true;

                lblMiddleDateDeliveryQty.Text = SOI.DeliveriesMiddle.ToString();
                lblMiddleDateSalesQty.Text = SOI.SalesMiddle.ToString();
                lblMiddleDateSalesQty.Visible = true;
                lblMiddleDateSales.Visible = true;
            }

          
            lblPullOut.Text = SOI.PullOut.ToString("(###,###)");

            if (lblPullOut.Text=="()")
            {
                lblPullOut.Text = "0";
            }

            lblAdjustmentAdd.Text = SOI.AdjustmentAdd.ToString("###,###");
            lblAdjustmentLess.Text = SOI.AdjustmentLess.ToString("(###,###)");
            if (lblAdjustmentLess.Text=="()")
            {
                lblAdjustmentLess.Text = "0";
                pnlLESSAdjustment.Visible = false;
            }
            lblEndingInventoryAsOfQty.Text = SOI.EndingInventory.ToString("###,###");
            lblPhysicalCountAsOfQty.Text = SOI.PhysicalCount.ToString("###,###");
            lblOverLacking.Text = OverLackingString(SOI.OverLacking);

            if (lblOverLacking.Text == "()")
            {
                lblOverLacking.Text = "0";
            }

            lblEndingInventoryAsOf.Text = "ENDING INVENTORY as of " + lblDateTo.Text;

            lblPhysicalCountAsOf.Text = "PHYSICAL COUNT as of " + lblInventoryDate.Text;


            DateTime PeriodFrom = DateTime.Parse(lblDateFrom.Text);
            DateTime PeriodTo = DateTime.Parse(lblDateTo.Text);

            DateTime PeriodFromParameter_TO = new DateTime(PeriodFrom.Year, PeriodFrom.Month, DateTime.DaysInMonth(PeriodFrom.Year, PeriodFrom.Month));

            DateTime PeriodTo_FROM = new DateTime(PeriodTo.Year, PeriodTo.Month, 1);

            lblActulaPCountAsOf.Text = "ACTUAL P.COUNT as of  " + lblDateFrom.Text;

            if ((SOI.PeriodTo.Month - SOI.PeriodFrom.Month) == 0)
            {
                lblDateDeliveriesFrom.Text = SOI.PeriodFrom.ToString("MMMM dd") + "-" + SOI.PeriodTo.ToString("dd yyyy");
                lblDateDeliveriesTo.Visible = false;
                lblDateDeliveriesToQty.Visible = false;
                lblSalesTo.Visible = false;
                lblSalesToQty.Visible = false;
            }
            else
            {
                lblDateDeliveriesFrom.Text = PeriodFrom.ToString("MMMM dd") + "-" +
              DateTime.DaysInMonth(PeriodFrom.Year, PeriodFrom.Month).ToString()
              + "," + PeriodFrom.Year;
            }
          
            lblSalesFrom.Text = lblDateDeliveriesFrom.Text;

            lblDateDeliveriesTo.Text = new DateTime(PeriodTo.Year, PeriodTo.Month, 1).ToString("MMMM dd") + "-" +
                PeriodTo.Day + "," + PeriodTo.Year;
            lblSalesTo.Text = lblDateDeliveriesTo.Text;

            if (string.IsNullOrEmpty(lblDateDeliveriesToQty.Text))
            {
                lblDateDeliveriesToQty.Text = "0";
            }

            if (string.IsNullOrEmpty(lblDateDeliveriesFromQty.Text))
            {
                lblDateDeliveriesFromQty.Text = "0";
            }

            if (string.IsNullOrEmpty(lblSalesFromQty.Text))
            {
                lblSalesFromQty.Text = "0";
            }
            if (string.IsNullOrEmpty(lblSalesToQty.Text))
            {
                lblSalesToQty.Text = "0";
            }
            if (string.IsNullOrEmpty(lblAdjustmentAdd.Text))
            {
                lblAdjustmentAdd.Text = "0";
                pnlADDAdjustment.Visible = false;
            }
           
            gvAdjustmentAdd.DataSource = MSOIAdjustmentmanger.GetMonthlySOIAdjustmentByCode(SOI.SOICode)[0];
            gvAdjustmentAdd.DataBind();
            gvAdjustmentLess.DataSource = MSOIAdjustmentmanger.GetMonthlySOIAdjustmentByCode(SOI.SOICode)[1];
            gvAdjustmentLess.DataBind();
        }
        private string OverLackingString(long overLacking)
        {
            string result = "";
            long OL = overLacking;
            if (OL < 0)
            {
                result = (-1 * OL).ToString();
                result = string.Concat("(", result, ")");
            }
            else
            {
                result = OL.ToString();
            }
            return result;
        }
    }
}