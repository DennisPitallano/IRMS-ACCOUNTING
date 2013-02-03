using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IRMS.Components;
using IntegratedResourceManagementSystem.Common;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class NewMonthlySOI : System.Web.UI.Page
    {
        #region Variables
        MonthlyStoreOutStandingInventoryManager MonthlySOIManager = new MonthlyStoreOutStandingInventoryManager();
        BrandManager BM = new BrandManager();
        List<MonthlyAdjustment> ADJUSTMENT_ADD = new List<MonthlyAdjustment>();
        List<MonthlyAdjustment> ADJUSTMENT_LESS = new List<MonthlyAdjustment>();
        MonthlySOIAdjustmentManager MonthlySOIAdjustmentManager = new MonthlySOIAdjustmentManager();
        CustomerReturnSlipManager CRSManager = new CustomerReturnSlipManager();
        private static Random random = new Random();

        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {
            #region check roles
            Permission.PERMITTED_USER = (UsersClass)Session["USER_ACCOUNT"];
            Permission.ROLES = (List<UserRole>)Session["USER_ROLES"];
            if (Permission.CanInsert() == false)
            {
                Redirector.Redirect("~/Accounting/MonthlySOIPanel.aspx");
            }

            #endregion
            InitializeBrandList();
        }

        private void InitializeBrandList()
        {
            DDLBrands.Items.Clear();
            DDLBrands.Items.Add(new ListItem("--Select--", ""));
            foreach(Brand brand in BM.Brands())
            {
                DDLBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSelectOutlet_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = gvOutlets.SelectedDataKey[1].ToString();
            hfCustomerNumber.Value = gvOutlets.SelectedDataKey[0].ToString();
            btnSelectOutlet.Enabled = false;
        }

        protected void gvOutlets_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            SearchCustomers();
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_Sorting(object sender, GridViewSortEventArgs e)
        {
            SearchCustomers();
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SearchCustomers();
            btnBrowse_ModalPopupExtender.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SearchCustomers()
        {
            if (DDLBrands.SelectedValue != "")
            {
                MonthlySOIManager.FilterCustomer(SqlDataSourceCustomersByBrand, txtSearchOutlet.Text, DDLBrands.SelectedValue);
            }
            else
            {
                MonthlySOIManager.FilterCustomer(SqlDataSourceCustomers, txtSearchOutlet.Text);
            }
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGetDR_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrEmpty(txtDateFrom.Text))
            {
                lblErrorText.Text = "Invalid Period Date!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }

            if (MonthlySOIManager.IsAlreadyCreated(DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text), int.Parse(hfCustomerNumber.Value)))
            {
                lblErrorText.Text = "Monthly SOI for this Customer is already exist <br />from this range of date:" + txtDateFrom.Text + " to " + txtDateTo.Text;
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }

            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
               lblErrorText.Text="Invalid Customer!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }
           
           
            if (string.IsNullOrEmpty(txtInventoryDate.Text))
            {
                lblErrorText.Text = "Invalid Inventory Date!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }

            DateTime PeriodFrom = DateTime.Parse(txtDateFrom.Text);
            DateTime PeriodTo = DateTime.Parse(txtDateTo.Text);
            long DeliveriesFrom=0;
            long DeliveriesMiddleMonth = 0;
            long DeliveriesTo=0;
            DateTime PeriodFromParameter_TO = new DateTime();
            DateTime PeriodMiddleMonthTo = new DateTime();
            DateTime PeriodMiddleMonthFrom = new DateTime();
            DateTime PeriodTo_FROM= new DateTime();
            int month_diff = MonthCount(PeriodFrom, PeriodTo);

            if (month_diff ==0)
            {
                txtMiddleDateDeliveryTotal.Visible = false;
                txtDateDeliveriesTo.Visible = false;

                txtMiddleDateSales.Visible = false;
                txtSalesTo.Visible = false;

                lblMiddleDate.Visible = false;
                lblDateDeliveriesTo.Visible = false;

                lblMiddleDateSales.Visible = false;
                lblSalesTo.Visible = false;
               // return;
            }

            if (month_diff >= 3)
            {
                lblErrorText.Text = "ERROR: You are trying to create a quarterly SOI!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }
            if (month_diff > 1)
            {
                lblMiddleDate.Visible = true;
                txtMiddleDateDeliveryTotal.Visible = true;

                PeriodFromParameter_TO = new DateTime(PeriodFrom.Year, PeriodFrom.Month, DateTime.DaysInMonth(PeriodFrom.Year, PeriodFrom.Month));
                PeriodMiddleMonthTo = new DateTime(PeriodFromParameter_TO.Year, PeriodFromParameter_TO.Month + 1, DateTime.DaysInMonth(PeriodFromParameter_TO.Year, PeriodFromParameter_TO.Month + 1));
                PeriodMiddleMonthFrom = new DateTime(PeriodMiddleMonthTo.Year, PeriodMiddleMonthTo.Month, 1);
                PeriodTo_FROM = new DateTime(PeriodTo.Year, PeriodTo.Month, 1);
                lblMiddleDate.Text = PeriodMiddleMonthFrom.ToString("MMMM dd")+"-"+PeriodMiddleMonthTo.ToString("dd, yyyy");
                DeliveriesMiddleMonth = MonthlySOIManager.DeliveriesFrom(int.Parse(hfCustomerNumber.Value), PeriodMiddleMonthFrom, PeriodMiddleMonthTo);
                txtMiddleDateDeliveryTotal.Text = DeliveriesMiddleMonth.ToString();
                lblMiddleDateSales.Visible = true;
                txtMiddleDateSales.Visible = true;
                lblMiddleDateSales.Text = lblMiddleDate.Text;
            }
            else if(month_diff == 1)
            {
                txtMiddleDateDeliveryTotal.Text = "0";
                txtMiddleDateSales.Text = "0";
                lblMiddleDate.Visible = false ;
                txtMiddleDateDeliveryTotal.Visible = false ;
                lblMiddleDateSales.Visible = false ;
                txtMiddleDateSales.Visible = false ;

                 PeriodFromParameter_TO = new DateTime(PeriodFrom.Year, PeriodFrom.Month, DateTime.DaysInMonth(PeriodFrom.Year, PeriodFrom.Month));
                 PeriodTo_FROM = new DateTime(PeriodTo.Year, PeriodTo.Month, 1);
            }

            if (month_diff ==0)
            {
                txtPullOut.Text = CRSManager.GetCRSTotalQtyByCustomerAndDateRange(int.Parse(hfCustomerNumber.Value), 
                    DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text)).ToString();
            }
            else
            {
                txtPullOut.Text = CRSManager.GetCRSTotalQtyByCustomerAndDateRange(int.Parse(hfCustomerNumber.Value), PeriodFrom, PeriodTo).ToString();
            }
          

            lblActulaPCountAsOf.Text = "ACTUAL P.COUNT as of  " + txtDateFrom.Text;

            if (month_diff == 0)
            {
                lblDateDeliveriesFrom.Text = DateTime.Parse(txtDateFrom.Text).ToString("MMMM dd")+"-"+DateTime.Parse(txtDateTo.Text).ToString("dd yyyy");
                lblSalesFrom.Text = lblDateDeliveriesFrom.Text;
                DeliveriesFrom = MonthlySOIManager.DeliveriesFrom(int.Parse(hfCustomerNumber.Value), DateTime.Parse(txtDateFrom.Text), DateTime.Parse(txtDateTo.Text));
                if (DeliveriesFrom == 0)
                {
                    lblErrorText.Text = "No Deliveries found from this date " + lblDateDeliveriesFrom.Text + "!";
                    hfCustomerNumber_ModalPopupExtender.Show();
                }
            }
            else
            {
                lblDateDeliveriesFrom.Text = PeriodFrom.ToString("MMMM dd") + "-" +
                    DateTime.DaysInMonth(PeriodFrom.Year, PeriodFrom.Month).ToString()
                    + "," + PeriodFrom.Year;
                lblSalesFrom.Text = lblDateDeliveriesFrom.Text;

                lblDateDeliveriesTo.Text = new DateTime(PeriodTo.Year, PeriodTo.Month, 1).ToString("MMMM dd") + "-" +
                    PeriodTo.Day + "," + PeriodTo.Year;
                lblSalesTo.Text = lblDateDeliveriesTo.Text;

                DeliveriesFrom = MonthlySOIManager.DeliveriesFrom(int.Parse(hfCustomerNumber.Value), PeriodFrom, PeriodFromParameter_TO);
                DeliveriesTo = MonthlySOIManager.DeliveriesTo(int.Parse(hfCustomerNumber.Value), PeriodTo_FROM, PeriodTo);

                if (DeliveriesFrom == 0)
                {
                    lblErrorText.Text = "No Deliveries found from this date " + lblDateDeliveriesFrom.Text + "!";
                    hfCustomerNumber_ModalPopupExtender.Show();
                }

                if (DeliveriesTo == 0)
                {
                    lblErrorText.Text = (lblErrorText.Text + "  No Deliveries found from this date " + lblDateDeliveriesTo.Text + "!");
                    hfCustomerNumber_ModalPopupExtender.Show();
                }
            }

          

            txtDateDeliveriesFrom.Text = DeliveriesFrom.ToString();
            txtDateDeliveriesTo.Text = DeliveriesTo.ToString();

            txtDeliveryTotal.Text = (DeliveriesFrom + DeliveriesMiddleMonth + DeliveriesTo ).ToString();
            txtTotalSales.Text = (long.Parse(txtSalesFrom.Text)+long.Parse(txtSalesTo.Text)+ long.Parse(txtMiddleDateSales.Text)).ToString();

            lblEndingInventoryAsOf.Text = "ENDING INVENTORY as of " + txtDateTo.Text;

            lblPhysicalCountAsOf.Text = "PHYSICAL COUNT as of " + txtInventoryDate.Text;

            pnlInputForm.Visible = true;

            if (month_diff == 0)
            {
                lblDateDeliveriesFrom.NavigateUrl = "~/Accounting/DeliveryDetails.aspx?Customer=" + txtCustomer.Text + "&"
              + "DateFrom=" + DateTime.Parse(txtDateFrom.Text) + "&DateTo="
              + DateTime.Parse(txtDateTo.Text)
              + "&CustomerNumber=" + hfCustomerNumber.Value + "&DRDateRange="
              + lblDateDeliveriesFrom.Text + "&TQTY=" + txtDateDeliveriesFrom.Text;
            }
            else
            {
                lblDateDeliveriesFrom.NavigateUrl = "~/Accounting/DeliveryDetails.aspx?Customer=" + txtCustomer.Text + "&"
              + "DateFrom=" + PeriodFrom.ToString() + "&DateTo="
              + PeriodFromParameter_TO.ToString()
              + "&CustomerNumber=" + hfCustomerNumber.Value + "&DRDateRange="
              + lblDateDeliveriesFrom.Text + "&TQTY=" + txtDateDeliveriesFrom.Text;
            }

          
            lblDateDeliveriesTo.NavigateUrl = "~/Accounting/DeliveryDetails.aspx?Customer=" + txtCustomer.Text + "&"
                + "DateFrom=" + PeriodTo_FROM.ToString() + "&DateTo="
                + PeriodTo.ToString()
                + "&CustomerNumber=" + hfCustomerNumber.Value + "&DRDateRange="
                + lblDateDeliveriesTo.Text + "&TQTY=" + txtDateDeliveriesTo.Text;
            lblMiddleDate.NavigateUrl = "~/Accounting/DeliveryDetails.aspx?Customer=" + txtCustomer.Text + "&"
                + "DateFrom=" + PeriodMiddleMonthFrom.ToString() + "&DateTo="
                + PeriodMiddleMonthTo.ToString()
                + "&CustomerNumber=" + hfCustomerNumber.Value + "&DRDateRange="
                + lblMiddleDate.Text + "&TQTY=" + txtMiddleDateDeliveryTotal.Text;

            txtActualPCountAsOf.Text = MonthlySOIManager.GetEndingInventory(long.Parse(hfCustomerNumber.Value)).ToString();

            txtEndingInventoryAsOf.Text = EndingInventory().ToString();

            btnSaveSOI.CssClass = "btnSave";
            btnSaveSOI.Enabled = true;

        }

        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelectOutlet.Enabled = true;
        }

        protected void txtActualPCountAsOf_TextChanged(object sender, EventArgs e)
        {
            txtEndingInventoryAsOf.Text = EndingInventory().ToString();
        }

        #region FORMULA
        private long EndingInventory()
        {
            long result = 0;
            result = (long.Parse(txtActualPCountAsOf.Text) + long.Parse(txtDeliveryTotal.Text))-long.Parse(txtTotalSales.Text);
            result = result - long.Parse(txtPullOut.Text);
            result = result + long.Parse(txtAdjustmentAdd.Text);
            result = result - long.Parse(txtAdjustmentLess.Text);
            return result;
        }

        private long TotalSales()
        {
            long result = 0;
            result = long.Parse(txtSalesFrom.Text) + long.Parse(txtSalesTo.Text)+ long.Parse(txtMiddleDateSales.Text);
            return result;
        }

        private long OverLacking()
        {
            long result = 0;
            result = long.Parse(txtPhysicalCountAsOf.Text) - long.Parse(txtEndingInventoryAsOf.Text);
            return result;
        }

        private string OverLackingString()
        {
            string result = "";
            long OL = OverLacking();
            if (OL < 0)
            {
                result =(-1 * OL).ToString();
                result = string.Concat("(", result, ")");
            }
            else
            {
                result = OL.ToString();
            }
            return result;
        }

        private int MonthCount(DateTime from, DateTime to)
        {
            int month_from = from.Month;
            int month_to = to.Month;
            int result = month_to - month_from ;
            if (result < 1)
            {
                result = 0;
            }
            return result;
        }
        #endregion


        protected void txtSalesFrom_TextChanged(object sender, EventArgs e)
        {
            txtTotalSales.Text = TotalSales().ToString();
            txtEndingInventoryAsOf.Text = EndingInventory().ToString();
        }

        protected void txtSalesTo_TextChanged(object sender, EventArgs e)
        {
            txtTotalSales.Text = TotalSales().ToString();
            txtEndingInventoryAsOf.Text = EndingInventory().ToString();
        }

        protected void txtPullOut_TextChanged(object sender, EventArgs e)
        {
            txtEndingInventoryAsOf.Text = EndingInventory().ToString();
        }

        protected void txtPhysicalCountAsOf_TextChanged(object sender, EventArgs e)
        {
            this.txtOverLacking.Text =OverLackingString();
        }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
        {
            SearchCustomers();
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void DDLBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLBrands.SelectedValue != "")
            {
                gvOutlets.DataSourceID = "SqlDataSourceCustomersByBrand";
            }
            else
            {
                gvOutlets.DataSourceID = "SqlDataSourceCustomers";
            }
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMiddleDateDeliveryTotal.Text))
            {
                txtMiddleDateDeliveryTotal.Text = "0";
            }

            if (string.IsNullOrEmpty(txtMiddleDateSales.Text))
            {
                txtMiddleDateSales.Text = "0";
            }
            if (string.IsNullOrEmpty(txtSalesFrom.Text))
            {
                txtSalesFrom.Text = "0";
            }
            if (string.IsNullOrEmpty(txtSalesTo.Text))
            {
                txtSalesTo.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPullOut.Text))
            {
                txtPullOut.Text = "0";
            }

            if (string.IsNullOrEmpty(txtAdjustmentAdd.Text))
            {
                txtAdjustmentAdd.Text = "0";
            }
            if (string.IsNullOrEmpty(txtAdjustmentLess.Text))
            {
                txtAdjustmentLess.Text = "0";
            }
            if (string.IsNullOrEmpty(txtPhysicalCountAsOf.Text))
            {
                lblErrorText.Text = "Invalid " + lblPhysicalCountAsOf.Text + "!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }
            MonthlyStoreOutStandingInventory MonthlySOI = new MonthlyStoreOutStandingInventory
            {
               ActualPhysicalCount = long.Parse(txtActualPCountAsOf.Text),
               CustomerName = txtCustomer.Text,
               SOICode = CreateCode(20),
               DeliveryQtyFrom = long.Parse(txtDateDeliveriesFrom.Text),
                DeliveriesMiddle = long.Parse(txtMiddleDateDeliveryTotal.Text),
               DeliveryQtyTo = long.Parse(txtDateDeliveriesTo.Text),
               EndingInventory = long.Parse(txtEndingInventoryAsOf.Text),
               InventoryDate = DateTime.Parse(txtInventoryDate.Text),
               OverLacking = OverLacking(),
               PeriodFrom = DateTime.Parse(txtDateFrom.Text),
               PeriodTo = DateTime.Parse(txtDateTo.Text),
               PhysicalCount = long.Parse(txtPhysicalCountAsOf.Text),
               PullOut = long.Parse(txtPullOut.Text),
               AdjustmentAdd = long.Parse(txtAdjustmentAdd.Text),
                AdjustmentLess = long.Parse(txtAdjustmentLess .Text),
               SalesQtyFrom = long.Parse(txtSalesFrom .Text),
                SalesMiddle = long.Parse(txtMiddleDateSales.Text),
               SalesQtyTo = long .Parse(txtSalesTo.Text),
               CustomerNumber = int.Parse(hfCustomerNumber.Value),
                DateRecorded = DateTime.UtcNow
            };

            MonthlySOIManager.Save(MonthlySOI);

            List<MonthlySOIAdjustment> ADD_ADJUSTMENTS = new List<MonthlySOIAdjustment>();
            List<MonthlySOIAdjustment> LESS_ADJUSTMENTS = new List<MonthlySOIAdjustment>();
            foreach (GridViewRow row in this.gvAdjustmentAdd.Rows)
            {
                MonthlySOIAdjustment adj = new MonthlySOIAdjustment
                {
                    Type = "ADD",
                    Quantity = long.Parse(row.Cells[1].Text),
                     DateRecorded = DateTime.UtcNow,
                      Particular = row.Cells[0].Text,
                     SOICode = MonthlySOI.SOICode                     
                };
                ADD_ADJUSTMENTS.Add(adj);
            }

            foreach (GridViewRow row in this.gvAdjustmentLess.Rows)
            {
                MonthlySOIAdjustment adj = new MonthlySOIAdjustment
                {
                    Type = "LESS",
                    Quantity = long.Parse(row.Cells[1].Text),
                    DateRecorded = DateTime.UtcNow,
                    Particular = row.Cells[0].Text,
                    SOICode = MonthlySOI.SOICode  
                };
                LESS_ADJUSTMENTS.Add(adj);
            }
            MonthlySOIAdjustmentManager.Save(ADD_ADJUSTMENTS);
            MonthlySOIAdjustmentManager.Save(LESS_ADJUSTMENTS);
            #region log
            MonthlySOIManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.INSERT);
            #endregion
            Response.Redirect("~/Accounting/MonthlySOIPanel.aspx");
        }

        protected void btnSaveAdjustmentAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtQuantityAdd.Text) || txtQuantityAdd.Text =="0")
            {
                lblErrorText.Text ="Invalid Quantity value!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }
            MonthlyAdjustment adj;
            foreach (GridViewRow row in this.gvAdjustmentAdd.Rows)
            {
                adj = new MonthlyAdjustment
                {
                    Type = row.Cells[0].Text ,
                     Quantity = long.Parse(row.Cells[1].Text)
                };
                ADJUSTMENT_ADD.Add(adj);
            }
            adj = new MonthlyAdjustment {
                 Type =  dlAddParticulars.SelectedValue,
                  Quantity = long.Parse(txtQuantityAdd.Text)
            };
             ADJUSTMENT_ADD.Add(adj);
             gvAdjustmentAdd.DataSource = ADJUSTMENT_ADD;
             gvAdjustmentAdd.DataBind();

             PreviewAddAdjustments();
             txtAdjustmentAdd.Text = (long.Parse(txtAdjustmentAdd.Text) + long.Parse(txtQuantityAdd.Text)).ToString();
             txtQuantityAdd.Text = "0";
             txtEndingInventoryAsOf.Text = EndingInventory().ToString();
           //adjustment add
        }

        private void PreviewAddAdjustments()
        {
            switch (dlAddParticulars.SelectedValue)
            {
                case "DELIVERIES":
                    txtAdjustmentAddDeliveries.Text = TotalDeliveriesAddAdjustment().ToString();
                    break;
                case "SALES":
                    txtAdjustmentAddSales.Text = TotalSalesAddAdjustment().ToString();
                    break;
                case "PULL-OUT":
                    txtAdjustmentAddPullOut.Text = TotalPullOutAddAdjustment().ToString();
                    break;
                case "SHOPLIFT":
                    txtAdjustmentAddShoplift.Text = TotalShopLiftAddAdjustment().ToString();
                    break;
                case "OTHERS":
                    txtAdjustmentAddOthers.Text = TotalOthersAddAdjustment().ToString();
                    break;
            }
        }

        private void PreviewLessAdjustments()
        {
            switch (this.DDLParticularsLess.SelectedValue)
            {
                case "DELIVERIES":
                    txtAdjustmentLessDeliveries.Text = TotalDeliveriesLessAdjustment().ToString();
                    break;
                case "SALES":
                    txtAdjustmentLessSales.Text = TotalSalesLessAdjustment().ToString();
                    break;
                case "PULL-OUT":
                    txtAdjustmentLessPullOut.Text = TotalPullOutLessAdjustment().ToString();
                    break;
                case "SHOPLIFT":
                    txtAdjustmentLessShopLift.Text = TotalShopLiftLessAdjustment().ToString();
                    break;
                case "OTHERS":
                    txtAdjustmentLessOthers.Text = TotalOthersLessAdjustment().ToString();
                    break;
            }
        }

        #region ADD Adjustments
        /// <summary>
        /// Compute Total deliveries for ADD Adjustment 
        /// </summary>
        /// <returns>Total Deliveries</returns>
        private int TotalDeliveriesAddAdjustment()
        {
            int total_deliveries = 0;
            if (string.IsNullOrEmpty(txtAdjustmentAddDeliveries.Text))
            {
                txtAdjustmentAddDeliveries.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityAdd.Text))
            {
                txtQuantityAdd.Text = "0";
            }
            total_deliveries = int.Parse(txtAdjustmentAddDeliveries.Text) + int.Parse(txtQuantityAdd.Text);
            return total_deliveries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int TotalPullOutAddAdjustment()
        {
            int total_pullout = 0;
            if (string.IsNullOrEmpty(txtAdjustmentAddPullOut.Text))
            {
                txtAdjustmentAddPullOut.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityAdd.Text))
            {
                txtQuantityAdd.Text = "0";
            }
            total_pullout = int.Parse(txtAdjustmentAddPullOut.Text) + int.Parse(txtQuantityAdd.Text);
            return total_pullout;
        }

        private int TotalSalesAddAdjustment()
        {
            int total_sales = 0;
            if (string.IsNullOrEmpty(txtAdjustmentAddSales.Text))
            {
                txtAdjustmentAddSales.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityAdd.Text))
            {
                txtQuantityAdd.Text = "0";
            }
            total_sales = int.Parse(txtAdjustmentAddSales.Text) + int.Parse(txtQuantityAdd.Text);
            return total_sales;
        }

        private int TotalShopLiftAddAdjustment()
        {
            int total_sales = 0;
            if (string.IsNullOrEmpty(txtAdjustmentAddShoplift.Text))
            {
                txtAdjustmentAddShoplift.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityAdd.Text))
            {
                txtQuantityAdd.Text = "0";
            }
            total_sales = int.Parse(txtAdjustmentAddShoplift.Text) + int.Parse(txtQuantityAdd.Text);
            return total_sales;
        }

        private int TotalOthersAddAdjustment()
        {
            int total_sales = 0;
            if (string.IsNullOrEmpty(txtAdjustmentAddOthers.Text))
            {
                txtAdjustmentAddOthers.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityAdd.Text))
            {
                txtQuantityAdd.Text = "0";
            }
            total_sales = int.Parse(txtAdjustmentAddOthers.Text) + int.Parse(txtQuantityAdd.Text);
            return total_sales;
        }
        #endregion

        #region LESS Adjustments
        /// <summary>
        /// Compute Total deliveries for LESS Adjustment 
        /// </summary>
        /// <returns>Total Deliveries</returns>
        private int TotalDeliveriesLessAdjustment()
        {
            int total_deliveries = 0;
            if (string.IsNullOrEmpty(txtAdjustmentLessDeliveries.Text))
            {
                txtAdjustmentLessDeliveries.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityLess.Text))
            {
                txtQuantityLess.Text = "0";
            }
            total_deliveries = int.Parse(txtAdjustmentLessDeliveries.Text) + int.Parse(txtQuantityLess.Text);
            return total_deliveries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int TotalPullOutLessAdjustment()
        {
            int total_pullout = 0;
            if (string.IsNullOrEmpty(txtAdjustmentLessPullOut.Text))
            {
                txtAdjustmentLessPullOut.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityLess.Text))
            {
                txtQuantityLess.Text = "0";
            }
            total_pullout = int.Parse(txtAdjustmentLessPullOut.Text) + int.Parse(txtQuantityLess.Text);
            return total_pullout;
        }

        private int TotalSalesLessAdjustment()
        {
            int total_sales = 0;
            if (string.IsNullOrEmpty(txtAdjustmentLessSales.Text))
            {
                txtAdjustmentLessSales.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityLess.Text))
            {
                txtQuantityLess.Text = "0";
            }
            total_sales = int.Parse(txtAdjustmentLessSales.Text) + int.Parse(txtQuantityLess.Text);
            return total_sales;
        }

        private int TotalShopLiftLessAdjustment()
        {
            int total_sales = 0;
            if (string.IsNullOrEmpty(txtAdjustmentLessShopLift.Text))
            {
                txtAdjustmentLessShopLift.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityLess.Text))
            {
                txtQuantityLess.Text = "0";
            }
            total_sales = int.Parse(txtAdjustmentLessShopLift.Text) + int.Parse(txtQuantityLess.Text);
            return total_sales;
        }

        private int TotalOthersLessAdjustment()
        {
            int total_sales = 0;
            if (string.IsNullOrEmpty(txtAdjustmentLessOthers.Text))
            {
                txtAdjustmentLessOthers.Text = "0";
            }
            if (string.IsNullOrEmpty(txtQuantityLess.Text))
            {
                txtQuantityLess.Text = "0";
            }
            total_sales = int.Parse(txtAdjustmentLessOthers.Text) + int.Parse(txtQuantityLess.Text);
            return total_sales;
        }
        #endregion

        protected void btnSaveAdjustmentLess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantityLess.Text) || txtQuantityLess.Text =="0")
            {
                lblErrorText.Text = "Invalid Quantity value!";
                hfCustomerNumber_ModalPopupExtender.Show();
                return;
            }
            MonthlyAdjustment adj;
            foreach (GridViewRow row in this.gvAdjustmentLess.Rows)
            {
                adj = new MonthlyAdjustment
                {
                    Type = row.Cells[0].Text,
                    Quantity = long.Parse(row.Cells[1].Text)
                };
                ADJUSTMENT_LESS.Add(adj);
            }
            adj = new MonthlyAdjustment
            {
                Type = DDLParticularsLess.SelectedValue,
                Quantity = long.Parse(txtQuantityLess.Text)
            };
            ADJUSTMENT_LESS.Add(adj);
            gvAdjustmentLess.DataSource = ADJUSTMENT_LESS;
            gvAdjustmentLess.DataBind();

            PreviewLessAdjustments();
            txtAdjustmentLess.Text = (long.Parse(txtAdjustmentLess.Text) + long.Parse(txtQuantityLess.Text)).ToString();
            txtQuantityLess.Text = "0";
            txtEndingInventoryAsOf.Text = EndingInventory().ToString();
        }

        private static string CreateCode(int size)
        {
            var pass = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                var binary = random.Next(0, 2);
                switch (binary)
                {
                    case 0:
                        var ch = (Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
                        pass.Append(ch);
                        break;
                    case 1:
                        var num = random.Next(1, 10);
                        pass.Append(num);
                        break;
                }
            }
            return pass.ToString();
        }

        protected void btnResetAdjustmentAddDeliveries_Click(object sender, EventArgs e)
        {
            ResetAddAdjustments("DELIVERIES");
            txtAdjustmentAdd.Text = (int.Parse(txtAdjustmentAdd.Text) - int.Parse(txtAdjustmentAddDeliveries.Text)).ToString();
            txtAdjustmentAddDeliveries.Text = "0";
        }

        /// <summary>
        /// Reset Add Adjustment
        /// </summary>
        /// <param name="Type">Type of Add Adjustment</param>
        private void ResetAddAdjustments(string Type)
        {
            MonthlyAdjustment adj;
            foreach (GridViewRow row in this.gvAdjustmentAdd.Rows)
            {
                if (row.Cells[0].Text != Type)
                {
                    adj = new MonthlyAdjustment
                    {
                        Type = row.Cells[0].Text,
                        Quantity = long.Parse(row.Cells[1].Text)
                    };
                    ADJUSTMENT_ADD.Add(adj);
                }
            }
            gvAdjustmentAdd.DataSource = ADJUSTMENT_ADD;
            gvAdjustmentAdd.DataBind();
        }

        /// <summary>
        /// Reset Less Adjustment
        /// </summary>
        /// <param name="Type">Type Of Less Adjustment</param>
        private void ResetLessAdjustments(string Type)
        {
            MonthlyAdjustment adj;
            foreach (GridViewRow row in this.gvAdjustmentLess.Rows)
            {
                if (row.Cells[0].Text != Type)
                {
                    adj = new MonthlyAdjustment
                    {
                        Type = row.Cells[0].Text,
                        Quantity = long.Parse(row.Cells[1].Text)
                    };
                    ADJUSTMENT_LESS.Add(adj);
                }
            }
            gvAdjustmentLess.DataSource = ADJUSTMENT_LESS;
            gvAdjustmentLess.DataBind();
        }

        protected void btnResetAdjustmentAddPullOut_Click(object sender, EventArgs e)
        {
            ResetAddAdjustments("PULL-OUT");
            txtAdjustmentAdd.Text = (int.Parse(txtAdjustmentAdd.Text) - int.Parse(txtAdjustmentAddPullOut.Text)).ToString();
            txtAdjustmentAddPullOut.Text = "0";
        }

        protected void btnResetAdjustmentAddSales_Click(object sender, EventArgs e)
        {
            ResetAddAdjustments("SALES");
            txtAdjustmentAdd.Text = (int.Parse(txtAdjustmentAdd.Text) - int.Parse(txtAdjustmentAddSales.Text)).ToString();
            txtAdjustmentAddSales.Text = "0";
        }

        protected void btnResetAdjustmentAddShoplift_Click(object sender, EventArgs e)
        {
            ResetAddAdjustments("SHOPLIFT");
            txtAdjustmentAdd.Text = (int.Parse(txtAdjustmentAdd.Text) - int.Parse(txtAdjustmentAddShoplift.Text)).ToString();
            txtAdjustmentAddShoplift.Text = "0";
        }

        protected void btnResetAdjustmentAddOthers_Click(object sender, EventArgs e)
        {
            ResetAddAdjustments("OTHERS");
            txtAdjustmentAdd.Text = (int.Parse(txtAdjustmentAdd.Text) - int.Parse(txtAdjustmentAddOthers.Text)).ToString();
            txtAdjustmentAddOthers.Text = "0";
        }

        protected void btnResetAdjustmentLessDeliveries_Click(object sender, EventArgs e)
        {
            ResetLessAdjustments("DELIVERIES");
            txtAdjustmentLess.Text = (int.Parse(txtAdjustmentLess.Text) - int.Parse(txtAdjustmentLessDeliveries.Text)).ToString();
            txtAdjustmentLessDeliveries.Text = "0";
        }

        protected void btnResetAdjustmentLessPullOut_Click(object sender, EventArgs e)
        {
            ResetLessAdjustments("PULL-OUT");
            txtAdjustmentLess.Text = (int.Parse(txtAdjustmentLess.Text) - int.Parse(txtAdjustmentLessPullOut.Text)).ToString();
            txtAdjustmentLessPullOut.Text = "0";
        }

        protected void btnResetAdjustmentLessSales_Click(object sender, EventArgs e)
        {
            ResetLessAdjustments("SALES");
            txtAdjustmentLess.Text = (int.Parse(txtAdjustmentLess.Text) - int.Parse(txtAdjustmentLessSales.Text)).ToString();
            txtAdjustmentLessSales.Text = "0";
        }

        protected void btnResetAdjustmentLessShopLift_Click(object sender, EventArgs e)
        {
            ResetLessAdjustments("SHOPLIFT");
            txtAdjustmentLess.Text = (int.Parse(txtAdjustmentLess.Text) - int.Parse(txtAdjustmentLessShopLift.Text)).ToString();
            txtAdjustmentLessShopLift.Text = "0";
        }

        protected void btnResetAdjustmentLessOthers_Click(object sender, EventArgs e)
        {
            ResetLessAdjustments("OTHERS");
            txtAdjustmentLess.Text = (int.Parse(txtAdjustmentLess.Text) - int.Parse(txtAdjustmentLessOthers.Text)).ToString();
            txtAdjustmentLessOthers.Text = "0";
        }
    }

    public class MonthlyAdjustment
    {
        public string Type { get; set; }
        public long Quantity { get; set; }
    }
}