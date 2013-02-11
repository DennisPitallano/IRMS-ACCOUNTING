using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.Entities;
using IRMS.BusinessLogic;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using System.Data;
using IRMS.Components;
using IntegratedResourceManagementSystem.Accounting.App_Code;
using IntegratedResourceManagementSystem.Common;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class NewSOI : System.Web.UI.Page
    {
        CustomerManager CustomerManager = new CustomerManager();
        private AdjustmentManager AdjustmentManager = new AdjustmentManager();
        AdjustmentMemoManager AdjusmentMemoManager = new AdjustmentMemoManager();
        StoreOutStandingInventoryManager SOIManager = new StoreOutStandingInventoryManager();
        BookAdjustmentManager BookAdjustmentManager = new BookAdjustmentManager();
       
        protected void Page_Init(object sender, EventArgs e)
        {
            Permission.PERMITTED_USER = (UsersClass)Session["USER_ACCOUNT"];
            Permission.ROLES = (List<UserRole>)Session["USER_ROLES"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtTransactionDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                btnSaveSOI.Enabled = false ;
                hfAdjustmentRecordNumber.Value = "0";
                
            }
        }

        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanged(object sender, EventArgs e)
        {
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_Sorted(object sender, EventArgs e)
        {
            if (txtSearchOutlet.Text != string.Empty)
            {
                SOIManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text,HF_BRAND.Value);
                gvOutlets.DataBind();
            }
            else
            {

            }
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void btnSelectOutlet_Click(object sender, EventArgs e)
        {
            txtOutletName.Text = gvOutlets.SelectedRow.Cells[2].Text;
            Image image_outlet = new Image();
            image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
            hfCustomerRecordNumber.Value = image_outlet.AlternateText;
        }

        protected void btnSaveSOI_Click(object sender, EventArgs e)
        {
            Image image_outlet = new Image();
            image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
            StoreOutStandingInventory SOI_TO_SAVE = new StoreOutStandingInventory();

            if (string.IsNullOrEmpty(txtActualAccountTotalCost.Text))
            {
                txtActualAccountTotalCost.Text = "0.00";  
            }
            if (string.IsNullOrEmpty(txtActualAccountAvgCost.Text))
            {
                txtActualAccountAvgCost.Text = "0.00";
            }
            if (string.IsNullOrEmpty(txtActualAccountValue.Text))
            {
                txtActualAccountValue.Text = "0.00";
            }
            if (string.IsNullOrEmpty(txtActualAccountVolume.Text))
            {
                txtActualAccountVolume.Text = "0";
            }
                SOI_TO_SAVE.ActualCostTotalCost = decimal.Parse(txtActualAccountTotalCost.Text);
                SOI_TO_SAVE.ActualCountAverageCost = decimal.Parse(txtActualAccountAvgCost.Text);
                SOI_TO_SAVE.ActualCountValue = decimal.Parse(txtActualAccountValue.Text);
                SOI_TO_SAVE.ActualCountVolume = decimal.Parse(txtActualAccountVolume.Text);
                SOI_TO_SAVE.AdjustmentCreditAverageCost = decimal.Parse(txtCreditAvgCost.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.AdjustmentCreditTotalCost = decimal.Parse(txtCreditTotalCost.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.AdjustmentCreditValue = decimal.Parse(txtCreditValue.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.AdjustmentCreditVolume = decimal.Parse(txtCreditVolume.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.AdjustmentDebitAverageCost = decimal.Parse(txtDebitAvgCost.Text);
                SOI_TO_SAVE.AdjustmentDebitTotalCost = decimal.Parse(txtDebitTotalCost.Text);
                SOI_TO_SAVE.AdjustmentDebitValue = decimal.Parse(txtDebitValue.Text);
                SOI_TO_SAVE.AdjustmentDebitVolume = decimal.Parse(txtDebitVolume.Text);
                if (long.Parse(hfAdjustmentRecordNumber.Value) > 0)
                {
                    SOI_TO_SAVE.AdjustmentRecordNumber = long.Parse(hfAdjustmentRecordNumber.Value);
                }
                else
                {
                    SOI_TO_SAVE.AdjustmentRecordNumber = 0;
                }
                SOI_TO_SAVE.BeginningInventoryAverageCost = decimal.Parse(txtBeginningInventoryAvgCost.Text);
                SOI_TO_SAVE.BeginningInventoryTotalCost = decimal .Parse(txtBeginningInventoryTotalCost.Text);
                SOI_TO_SAVE.BeginningInventoryValue = decimal.Parse(txtBeginningInventoryValue.Text);
                SOI_TO_SAVE.BeginningInventoryVolume = decimal.Parse(txtBeginningInventoryVolume.Text);
                SOI_TO_SAVE.CustomerName = txtOutletName.Text ;
                SOI_TO_SAVE.CustomerNumber = int.Parse(image_outlet.AlternateText);
                SOI_TO_SAVE.Brand = gvOutlets.SelectedRow.Cells[4].Text;
                SOI_TO_SAVE.DateRecorded = DateTime.Now;
                SOI_TO_SAVE.DeliveryAverageCost = decimal.Parse(txtDeliveryAvgCost.Text);
                SOI_TO_SAVE.DeliveryTotalCost = decimal.Parse(txtdeliveryTotalCost.Text);
                SOI_TO_SAVE.DeliveryValue = decimal.Parse(txtDeliveryValue.Text);
                SOI_TO_SAVE.DeliveryVolume = decimal.Parse(txtDeliveryVolume.Text);

                if (txtDiscrepancyTotalCost.Text.StartsWith("(") == false)
                {
                    SOI_TO_SAVE.DiscrepancyTotalCost = decimal.Parse(txtDiscrepancyTotalCost.Text);
                }
                else
                {
                    SOI_TO_SAVE.DiscrepancyTotalCost = decimal.Parse(txtDiscrepancyTotalCost.Text.Remove(0, 1).Replace(")", ""));
                }

                if (txtDiscrepancyValue.Text.StartsWith("(") == false)
                {
                    SOI_TO_SAVE.DiscrepancyValue = decimal.Parse(txtDiscrepancyValue.Text);
                }
                else
                {
                    SOI_TO_SAVE.DiscrepancyValue = decimal.Parse(txtDiscrepancyValue.Text.Remove(0, 1).Replace(")", ""));
                }

                if (txtDiscrepancyVolume.Text.StartsWith("(") == false)
                {
                    SOI_TO_SAVE.DiscrepancyVolume = decimal.Parse(txtDiscrepancyVolume.Text);
                }
                else
                {
                    SOI_TO_SAVE.DiscrepancyVolume = decimal.Parse(txtDiscrepancyVolume.Text.Remove(0, 1).Replace(")", ""));
                }
                
                SOI_TO_SAVE.EndingInventoryAverageCost = decimal.Parse(txtEndingInvventoryAvgCost.Text);
                SOI_TO_SAVE.EndingInventoryTotalCost = decimal.Parse(txtEndingInvventoryTotalCost.Text);
                SOI_TO_SAVE.EndingInventoryValue = decimal.Parse(txtEndingInvventoryValue.Text);
                SOI_TO_SAVE.EndingInventoryVolume = decimal.Parse(txtEndingInvventoryVolume.Text);
                SOI_TO_SAVE.GrossSalesAverageCost = decimal.Parse(txtGrossSalesAvgCost.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.GrossSalesTotalCost = decimal.Parse(txtGrossSalesTotalCost.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.GrossSalesValue = decimal.Parse(txtGrossSalesValue.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.GrossSalesVolume = decimal.Parse(txtGrossSalesVolume.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.PeriodFrom = DateTime.Parse(txtPeriodFrom.Text);
                SOI_TO_SAVE.PeriodTo = DateTime.Parse(txtPeriodTo.Text);
                SOI_TO_SAVE.ReturnsAverageCost = decimal.Parse(txtPullOutAvgCost.Text.Remove(0,1).Replace(")",""));
                SOI_TO_SAVE.ReturnsTotalCost = decimal.Parse(txtPullOutTotalCost.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.ReturnsValue = decimal.Parse(txtPullOutValue.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.ReturnsVolume = decimal.Parse(txtPullOutVolume.Text.Remove(0, 1).Replace(")", ""));
                SOI_TO_SAVE.TransactionDate = DateTime.Parse(txtTransactionDate.Text);

            try
            {
                SOIManager.Save(SOI_TO_SAVE);
                #region log
                SOIManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.INSERT);
                #endregion
            }
            catch (Exception)
            {
              // throw;
            }
        }

        #region "dr details for SOI"
     
        private void GetDRDetailsforSOI()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                decimal[] drdetails = SOIManager.GetDeliveryVolumeAndAmountByCustomerAndPeriod(long.Parse(image_outlet.AlternateText),
                                                                                               DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));

                txtDeliveryValue.Text = drdetails[0].ToString("###,###.00");
                txtDeliveryVolume.Text = drdetails[1].ToString();
            }
            catch (Exception)
            {
                txtDeliveryValue.Text = "0.00";
                txtDeliveryVolume.Text = "0";
            }
        }

        private void GetDRTotalCostPrice()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                decimal[] drcostprice = SOIManager.GetDeliveryDetailsTotalQuantityAndTotalCost(long.Parse(image_outlet.AlternateText),
                    DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));
                 txtdeliveryTotalCost.Text = drcostprice[1].ToString("###,###.00");
            }
            catch (Exception)
            {
                txtdeliveryTotalCost.Text = "0.00";
            }
        }

        private void ComputeDeliveryReceiptAverageCost()
        {
            try
            {
                txtDeliveryAvgCost.Text = (decimal.Parse(txtdeliveryTotalCost.Text) / decimal.Parse(txtDeliveryVolume.Text)).ToString("###,###.00");
                txtGrossSalesAvgCost.Text = decimal.Parse(txtDeliveryAvgCost.Text).ToString("(###,###.00)");
            }
            catch (Exception)
            {
                txtDeliveryAvgCost.Text = "0.00";
                txtGrossSalesAvgCost.Text = "(0)";
                // throw;
            }
        }
     
        #endregion

        #region"crs details for SOI"
    
        private void GetCRSQuantityAmountForSOI()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
             
                decimal[] crsDetails = SOIManager.GetReturnsTotalCostAmountDetailsForSOI(long.Parse(image_outlet.AlternateText),
                                                                                                              DateTime.Parse(txtPeriodFrom.Text),
                                                                                                              DateTime.Parse(txtPeriodTo.Text));
                if (crsDetails[0] != 0)
                {
                    txtPullOutVolume.Text = crsDetails[0].ToString("(###,###)");
                }
                else
                {
                    txtPullOutVolume.Text = "(0)";
                }
            }
            catch (Exception)
            {
                txtPullOutVolume.Text = "(0)";
            }
        }

        private void GetCRSCostAmountForSOI()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                decimal[] crsDetails = SOIManager.GetReturnsTotalCostAmountDetailsForSOI(long.Parse(image_outlet.AlternateText),
                                                                                                              DateTime.Parse(txtPeriodFrom.Text), 
                                                                                                              DateTime.Parse(txtPeriodTo.Text));
                txtPullOutTotalCost.Text = crsDetails[1].ToString("(###,###.00)");
            }
            catch (Exception)
            {
                txtPullOutTotalCost.Text = "(0.00)";
            }
        }

        private void GetCRSDetailsforSOI()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                decimal crsAmount = SOIManager.GetCustomerReturnSlipByCustomerAndPeriod(long.Parse(image_outlet.AlternateText),
                                                                                        DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));
                txtPullOutValue.Text = crsAmount.ToString("(###,###.00)");
            }
            catch (Exception)
            {
                txtPullOutValue.Text = "(0.00)";
            }
        }

        private void ComputeCRSAverageCost()
        {
            try
            {
                this.txtPullOutAvgCost.Text = (decimal.Parse(this.txtPullOutTotalCost.Text.Remove(0, 1).Replace(")", "")) / decimal.Parse(this.txtPullOutVolume.Text.Remove(0, 1).Replace(")", ""))).ToString("(###,###.00)");
            }
            catch (Exception)
            {
                txtPullOutAvgCost.Text = "(0.00)";
                // throw;
            }
        }

        #endregion
        #region Computations"
        private void FetchDRDetailsForSOI()
        {
            txtEndingInvventoryAvgCost.Text = ComputeEndingInventory()[2].ToString("###,###.00");
            txtEndingInvventoryVolume.Text = ComputeEndingInventory()[0].ToString();
            txtEndingInvventoryValue.Text = ComputeEndingInventory()[1].ToString("###,###.00");
            txtEndingInvventoryTotalCost.Text = ComputeEndingInventory()[3].ToString("###,###.00");

            if (ComputeDiscrepancy()[0] > 0)
            {
                txtDiscrepancyVolume.Text = "(-" + ComputeDiscrepancy()[0].ToString() + ")";
            }
            else
            {
                txtDiscrepancyVolume.Text = ""+ (ComputeDiscrepancy()[0]*-1).ToString() + "";
            }
            if (ComputeDiscrepancy()[1] > 0)
            {
                txtDiscrepancyValue.Text = "(-" + ComputeDiscrepancy()[1].ToString("###,###.00") + ")";

            }
            else
            {
                txtDiscrepancyValue.Text = "" + (ComputeDiscrepancy()[1]*-1).ToString("###,###.00") + "";

            }
            if (ComputeDiscrepancy()[2] > 0)
            {
                txtDiscrepancyTotalCost.Text = "(-" + ComputeDiscrepancy()[2].ToString("###,###.00") + ")";
            }
            else
            {
                txtDiscrepancyTotalCost.Text = "" + (ComputeDiscrepancy()[2]*-1).ToString("###,###.00") + " ";
            }
        }

        private decimal[] ComputeEndingInventory()
        {
            decimal[] results = new decimal[4];
            try
            {
                
                results[0] = decimal.Parse(txtBeginningInventoryVolume.Text) +
                             decimal.Parse(txtDeliveryVolume.Text) -
                             decimal.Parse(txtPullOutVolume.Text.Remove(0, 1).Replace(")", "")) -
                             decimal.Parse(txtGrossSalesVolume.Text.Remove(0, 1).Replace(")", "")) +
                             decimal.Parse(txtDebitVolume.Text) -
                             decimal.Parse(txtCreditVolume.Text.Remove(0,1).Replace(")",""));// Ending Inventory Volume

                results[1] = decimal.Parse(txtBeginningInventoryValue.Text) +
                             decimal.Parse(txtDeliveryValue.Text) -
                             decimal.Parse(txtPullOutValue.Text.Remove(0, 1).Replace(")", "")) -
                             decimal.Parse(txtGrossSalesValue.Text.Remove(0, 1).Replace(")", "")) +
                             decimal.Parse(txtDebitValue.Text) -
                             decimal.Parse(txtCreditValue.Text.Remove(0,1).Replace(")",""));// Ending Inventory Value

                results[3] = decimal.Parse(txtBeginningInventoryTotalCost.Text) +
                             decimal.Parse(txtdeliveryTotalCost.Text) -
                             decimal.Parse(txtPullOutTotalCost.Text.Remove(0, 1).Replace(")", "")) -
                             decimal.Parse(txtGrossSalesTotalCost.Text.Remove(0, 1).Replace(")", "")) +
                             decimal.Parse(txtDebitTotalCost.Text) -
                             decimal.Parse(txtCreditTotalCost.Text.Remove(0, 1).Replace(")", ""));// Ending Inventory Value

                results[2] = results[3] / results[0];
                // Ending Inventory Average Cost
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
                results[2] = 0;
                results[3] = 0;
            }

            return results;
        }

        private decimal[] ComputeDiscrepancy()
        {
            decimal[] results = new decimal[3];

            try
            {
                    results[0] = decimal.Parse(txtEndingInvventoryVolume.Text) - decimal.Parse(txtActualAccountVolume.Text);
                    results[1] = decimal.Parse(txtEndingInvventoryValue.Text) - decimal.Parse(txtActualAccountValue.Text);
                    results[2] = decimal.Parse(txtEndingInvventoryTotalCost.Text) - decimal.Parse(txtActualAccountTotalCost.Text);
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
                results[2] = 0;
            }
            return results;
        }

        #endregion

        private void GetGrossSalesSummary()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                DataTable gross_sales = SOIManager.GetDataTableStoreOutStandingInventoryGrossSalesSummary(long.Parse(
                        image_outlet.AlternateText),
                        DateTime.Parse(txtPeriodFrom.Text).Month, DateTime.Parse(txtPeriodTo.Text).Month,
                        DateTime.Parse(txtPeriodFrom.Text).Year, DateTime.Parse(txtPeriodTo.Text).Year);
                foreach (DataRow row in gross_sales.Rows)
                {
                    txtGrossSalesValue.Text = decimal.Parse(row[0].ToString()).ToString("(###,###.00)");
                    if (decimal.Parse(row[0].ToString()) != 0)
                    {
                        txtGrossSalesVolume.Text = decimal.Parse(row[1].ToString()).ToString("(###,###)");
                    }
                    else
                    {
                        txtGrossSalesVolume.Text = "(0)";
                    }
                   
                }
                txtGrossSalesTotalCost.Text = (decimal.Parse(txtGrossSalesVolume.Text.Remove(0,1).Replace(")","")) * 
                    decimal.Parse(txtGrossSalesAvgCost.Text.Remove(0,1).Replace(")",""))).ToString("(###,###.00)");
                DataTable gross_sales_breakdown = SOIManager.GetDataTableStoreOutStandingInventoryGrossSalesBreakDown(long.Parse(
                        image_outlet.AlternateText),
                        DateTime.Parse(txtPeriodFrom.Text).Month, DateTime.Parse(txtPeriodTo.Text).Month,
                        DateTime.Parse(txtPeriodFrom.Text).Year, DateTime.Parse(txtPeriodTo.Text).Year);
                gvGrossSalesBreakDown.DataSource = gross_sales_breakdown;
                gvGrossSalesBreakDown.DataBind();
            }
            catch (Exception)
            {
                txtGrossSalesValue.Text = "(0.00)";
                txtGrossSalesVolume.Text = "(0)";
                //throw;
            }
        }

        private void GetPhysicalCountSummary()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");

                // 20120315 CTS
                DateTime dtPeriodFrom = new DateTime(DateTime.Parse(txtPeriodTo.Text).Year, DateTime.Parse(txtPeriodTo.Text).Month, 1);
                DateTime dtPeriodToTemp = DateTime.Parse(txtPeriodTo.Text);
                DateTime dtPeriodTo = new DateTime(dtPeriodToTemp.Year, dtPeriodToTemp.Month, DateTime.DaysInMonth(dtPeriodToTemp.Year, dtPeriodToTemp.Month));

                if (dtPeriodToTemp.Month == 12 && dtPeriodToTemp.Day == 31) // ENDING YEAR 
                {
                    dtPeriodFrom = new DateTime(dtPeriodToTemp.Year + 1, 1, 1);
                    dtPeriodTo = new DateTime(dtPeriodToTemp.Year + 1, 1, DateTime.DaysInMonth(dtPeriodToTemp.Year, 1));
                }

                DataTable physical_count = SOIManager.GetDataTableStoreOutStandingInventoryPhysiclCountSummary(
                        long.Parse(image_outlet.AlternateText), dtPeriodFrom, dtPeriodTo);
                // 20120315 CTS

                foreach (DataRow row  in physical_count.Rows)
                {
                    txtActualAccountValue.Text = decimal.Parse(row[0].ToString()).ToString("###,###.00");
                    txtActualAccountVolume.Text = row[1].ToString();
                    txtActualAccountTotalCost.Text = decimal.Parse(row[2].ToString()).ToString("###,###.00");
                    txtActualAccountAvgCost.Text = (decimal.Parse(txtActualAccountTotalCost.Text) / decimal.Parse(txtActualAccountVolume.Text)).ToString("###,###.00");
                }
            }
            catch (Exception)
            {
                    txtActualAccountValue.Text = "0.00";
                    txtActualAccountVolume.Text = "0";
                    this.txtActualAccountTotalCost.Text ="0.00";
                    txtActualAccountAvgCost.Text = "0.00";
            }
        }

        private void GetBeginningInventorySummary()
        {
             DataTable p_count_result = new DataTable();
            try
            {
                List<SOI_BeginningInventory> SOI_BI;
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                StoreOutStandingInventory SOI = SOIManager.IsHasSOIRecord(long.Parse(image_outlet.AlternateText));
                if (SOI != null)
                {
                    txtBeginningInventoryValue.Text = SOI.ActualCountValue.ToString("###,###.00");
                    txtBeginningInventoryVolume.Text = SOI.ActualCountVolume.ToString();
                    txtBeginningInventoryTotalCost.Text = SOI.ActualCostTotalCost.ToString("###,###.00");
                    txtBeginningInventoryAvgCost.Text = SOI.ActualCountAverageCost.ToString("###,###.00");
                    SOI_BI = new List<SOI_BeginningInventory>();

                    SOI_BeginningInventory SOIBI = new SOI_BeginningInventory
                    {
                        Volume = decimal.Parse(txtBeginningInventoryVolume.Text),
                        Value = decimal.Parse(txtBeginningInventoryValue.Text),
                        AverageCost = decimal.Parse(txtBeginningInventoryAvgCost.Text),
                        TotalCost = decimal.Parse(txtActualAccountTotalCost.Text)
                    };
                    SOI_BI.Add(SOIBI);
                    gvSOIBI.DataSource = SOI_BI;
                    gvSOIBI.DataBind();
                    lblBIFrom.Text = "Beginning Inventory from Previous SOI";
                }
                else
                {
                    List<SOI_BeginningInventory> SOI_PCOUNT= new List<SOI_BeginningInventory>();
                    DateTime dtPeriodFrom = new DateTime(DateTime.Parse(txtPeriodTo.Text).Year,
                        DateTime.Parse(txtPeriodFrom.Text).Month, 1);
                    DateTime dtPeriodToTemp = DateTime.Parse(txtPeriodFrom.Text);
                    DateTime dtPeriodTo = new DateTime(dtPeriodToTemp.Year, dtPeriodToTemp.Month, 
                        DateTime.DaysInMonth(dtPeriodToTemp.Year, dtPeriodToTemp.Month));

                    if (dtPeriodToTemp.Month == 12 && dtPeriodToTemp.Day == 31) // ENDING YEAR 
                    {
                        dtPeriodFrom = new DateTime(dtPeriodToTemp.Year + 1, 1, 1);
                        dtPeriodTo = new DateTime(dtPeriodToTemp.Year + 1, 1, DateTime.DaysInMonth(dtPeriodToTemp.Year, 1));
                    }

                    DataTable physical_count = SOIManager.GetDataTableStoreOutStandingInventoryPhysiclCountSummary1(
                                          long.Parse(image_outlet.AlternateText), dtPeriodFrom, dtPeriodTo);
                   
                    if (physical_count.Rows.Count >0)
                    {
                        p_count_result = physical_count;
                    }
                    else
                    {
                        dtPeriodFrom = new DateTime(dtPeriodFrom.Year - 1, 12, 1);
                        p_count_result = SOIManager.GetDataTableStoreOutStandingInventoryPhysiclCountSummary1(
                                          long.Parse(image_outlet.AlternateText), dtPeriodFrom, dtPeriodTo);
                    }
                    foreach (DataRow row in p_count_result.Rows)
                    {
                        SOI_BeginningInventory PCOUNT = new SOI_BeginningInventory();
                        PCOUNT.Volume = decimal.Parse(row[1].ToString());
                        PCOUNT.Value = decimal.Parse(row[0].ToString());
                        PCOUNT.TotalCost = decimal.Parse(row[2].ToString());
                        PCOUNT.AverageCost = (decimal.Parse(row[2].ToString()) / decimal.Parse(row[1].ToString()));
                        SOI_PCOUNT.Add(PCOUNT);
                    }
                    SOI_BeginningInventory BI = SOI_PCOUNT[0];
                    if (SOI_PCOUNT.Count>1)
                    {
                        SOI_BeginningInventory EI = SOI_PCOUNT[1];
                        hfPCountAveCost.Value = EI.AverageCost.ToString("###,###.00");
                        hfPcountTotalCost.Value = EI.TotalCost.ToString("###,###.00");
                        hfPCountValue.Value = EI.Value.ToString("###,###.00");
                        hfPCountVolume.Value = EI.Volume.ToString();
                    }

                    txtBeginningInventoryValue.Text = BI.Value.ToString("###,###.00");
                    txtBeginningInventoryVolume.Text = BI.Volume.ToString();

                    txtBeginningInventoryTotalCost.Text = BI.TotalCost.ToString("###,###.00");
                    txtBeginningInventoryAvgCost.Text = BI.AverageCost.ToString("###,###.00");


                    DataTable pcount_breakdown = SOIManager.GetDataTableStoreOutStandingInventoryPhysicalCountBreakdown(
                        long.Parse(image_outlet.AlternateText), DateTime.Parse(txtPeriodFrom.Text));
                    gvSOIBI.DataSource = pcount_breakdown;
                    gvSOIBI.DataBind();
                    lblBIFrom.Text = "Beginning Inventory from Bridge Table";
                }
                
            }
            catch (Exception)
            {
                txtBeginningInventoryValue.Text = "0.00";
                txtBeginningInventoryVolume.Text = "0";
                this.txtBeginningInventoryTotalCost.Text = "0.00";
                txtBeginningInventoryAvgCost.Text = "0.00";
            }
        }

        private void GetBeginningInventory()
        {
            try
            {
                Image image_outlet = new Image();
                image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
                StoreOutStandingInventory SOI = SOIManager.IsHasSOIRecord(long.Parse(image_outlet.AlternateText));
                if (SOI.RecordNumber != 0)
                {
                    txtBeginningInventoryValue.Text = SOI.BeginningInventoryValue.ToString("###,###.00");
                    txtBeginningInventoryVolume.Text = SOI.BeginningInventoryVolume.ToString();
                    txtBeginningInventoryTotalCost.Text = SOI.BeginningInventoryTotalCost.ToString("###,###.00");
                    txtBeginningInventoryAvgCost.Text = SOI.BeginningInventoryAverageCost.ToString("###,###.00");
                }
                else
                {
                    txtBeginningInventoryValue.Text = txtActualAccountValue.Text;
                    txtBeginningInventoryAvgCost.Text = txtActualAccountAvgCost.Text;
                    txtBeginningInventoryVolume.Text = txtActualAccountVolume.Text;
                    txtBeginningInventoryTotalCost.Text = txtActualAccountTotalCost.Text;
                }
            }
            catch (Exception)
            {
                  txtBeginningInventoryValue.Text = "0.00";
                    txtBeginningInventoryAvgCost.Text = "0.00";
                    txtBeginningInventoryVolume.Text = "0";
                    txtBeginningInventoryTotalCost.Text ="0.00";
            }
        }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
        {
            //if (HF_BRAND.Value != "ALL")
            //{
                SOIManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
            //}
            //else
            //{
            //    SOIManager.SearchOutletDataSource(SqlDataSourceAllCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
            //}
                gvOutlets.DataBind();
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtSearchOutlet.Text != string.Empty)
            {
                SOIManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text,HF_BRAND.Value);
                gvOutlets.DataBind();
            }
            else
            {

            }
            btnBrowse_ModalPopupExtender.Show();
        }

        private void ReloadFetchAdjustmentsForSOI(string OUTLET_NAME, DateTime DATE_FROM, DateTime DATE_TO)
        {
            try
            {
                var results = AdjustmentManager.GetAdjustmentByOutletAndDateRange(OUTLET_NAME, DATE_FROM, DATE_TO);
                //var results = (from book_adj in this.AdjustmentManager.Adjustments()
                // where book_adj.OutletName == OUTLET_NAME && book_adj.InventoryDate == DATE_FROM
                // && book_adj.CutOffDate == DATE_TO
                // select book_adj).FirstOrDefault();

                if (results.RecordNo != 0)
                {
                    long debit_quantity = 0;
                    long credit_quantity = 0;
                    decimal debit_current_price = 0;
                    decimal credit_current_price = 0;
                    decimal debit_cost_price = 0;
                    decimal credit_cost_price = 0;
                    List<AdjustmentMemo> AdjustmentMemoDetailsCredit = new List<AdjustmentMemo>();
                    List<AdjustmentMemo> AdjustmentMemoDetailsDebit = new List<AdjustmentMemo>();
                    foreach (AdjustmentMemo adjmemo in AdjusmentMemoManager.AdjustmentMemosByAdjustmentCode(results.AdjustmentCode))
                    {
                        if (adjmemo.MemoType == "CREDIT")
                        {
                            AdjustmentMemoDetailsCredit.Add(adjmemo);
                            credit_quantity = credit_quantity + adjmemo.Quantity;
                            credit_current_price = credit_current_price + adjmemo.CurrentPrice;
                            credit_cost_price = credit_cost_price + adjmemo.CostPrice;
                        }
                        else
                        {
                            AdjustmentMemoDetailsDebit.Add(adjmemo);
                            debit_quantity = debit_quantity + adjmemo.Quantity;
                            debit_current_price = debit_current_price + adjmemo.CurrentPrice;
                            debit_cost_price = debit_cost_price + adjmemo.CostPrice;
                        }
                    }
                    txtActualAccountVolume.Text = ((results.ActualPhysicalCountQuantity + debit_quantity) - credit_quantity).ToString();
                    txtActualAccountValue.Text = ((results.ActualPhysicalCountCurrentPrice + debit_current_price) - credit_current_price).ToString("###,###.00");
                    txtActualAccountTotalCost.Text = ((results.ActualPhysicalCountCostPrice + debit_cost_price) - credit_cost_price).ToString("###,###.00");
                    if (decimal.Parse(txtActualAccountVolume.Text) != 0)
                    {
                        txtActualAccountAvgCost.Text = (decimal.Parse(txtActualAccountTotalCost.Text) / decimal.Parse(txtActualAccountVolume.Text)).ToString("###,###.00");
                    }
                    else
                    {
                        txtActualAccountAvgCost.Text = "0.00";
                    }                    
                }
                else
                {
                    txtActualAccountValue.Text = hfPCountValue.Value;
                    txtActualAccountVolume.Text = hfPCountVolume.Value;
                    this.txtActualAccountTotalCost.Text = hfPcountTotalCost.Value;
                    txtActualAccountAvgCost.Text = hfPCountAveCost.Value;
                   // GetPhysicalCountSummary();
                }
                FetchDRDetailsForSOI();
                if (results.RecordNo > 0)
                {
                    hfAdjustmentRecordNumber.Value = results.RecordNo.ToString();
                }
                else
                {
                    hfAdjustmentRecordNumber.Value = "0";
                }               
            }
            catch (Exception)
            {
                txtActualAccountValue.Text = hfPCountValue.Value;
                txtActualAccountVolume.Text = hfPCountVolume.Value;
                this.txtActualAccountTotalCost.Text = hfPcountTotalCost.Value;
                txtActualAccountAvgCost.Text = hfPCountAveCost.Value;
               // GetPhysicalCountSummary();
            }
        }

        private void ReloadFetchBookAdjustmentsForSOI(string OUTLET_NAME, DateTime DATE_FROM, DateTime DATE_TO)
        {
            try
            {
                List <BookAdjustment> results = BookAdjustmentManager.GetBookAdjustmentByOutletNameAndDateRange(OUTLET_NAME, DATE_FROM, DATE_TO);
                //var results = (from book_adj in this.BookAdjustmentManager.BookAdjustments()
                //               where book_adj.OutletName == OUTLET_NAME && book_adj.InventoryDate == DATE_FROM
                //               && book_adj.CutOffDate == DATE_TO
                //               select book_adj).ToList<BookAdjustment>();

                if (results.Count != 0)
                {
                    long debit_quantity = 0;
                    long credit_quantity = 0;
                    decimal debit_current_price = 0;
                    decimal credit_current_price = 0;
                    decimal debit_cost_price = 0;
                    decimal credit_cost_price = 0;
                    List<BookAdjustmentMemo> AdjustmentMemoDetailsCredit = new List<BookAdjustmentMemo>();
                    List<BookAdjustmentMemo> AdjustmentMemoDetailsDebit = new List<BookAdjustmentMemo>();
                    foreach(BookAdjustment book_adj in results)
                    {
                        foreach (BookAdjustmentMemo adjmemo in BookAdjustmentManager.GetBookAdjustmentMemosByAdjustmentCode(book_adj.AdjustmentCode))
                        {
                            if (adjmemo.MemoType == "CREDIT")
                            {
                                AdjustmentMemoDetailsCredit.Add(adjmemo);
                                credit_quantity = credit_quantity + adjmemo.Quantity;
                                credit_current_price = credit_current_price + adjmemo.CurrentPrice;
                                credit_cost_price = credit_cost_price + adjmemo.CostPrice;
                            }
                            else
                            {
                                AdjustmentMemoDetailsDebit.Add(adjmemo);
                                debit_quantity = debit_quantity + adjmemo.Quantity;
                                debit_current_price = debit_current_price + adjmemo.CurrentPrice;
                                debit_cost_price = debit_cost_price + adjmemo.CostPrice;
                            }
                        }
                    }
                    txtDebitVolume.Text = debit_quantity.ToString();
                    txtDebitValue.Text = debit_current_price.ToString("###,###.00");
                    txtDebitTotalCost.Text = debit_cost_price.ToString("###,###.00");
                    if (debit_quantity != 0)
                    {
                        txtDebitAvgCost.Text = (debit_cost_price / debit_quantity).ToString("###,###.00");
                    }
                    else
                    {
                        txtDebitAvgCost.Text = "0.00";
                    }

                    if (credit_quantity != 0)
                    {
                        txtCreditVolume.Text = credit_quantity.ToString("(###,###)");
                    }
                    else
                    {
                        txtCreditVolume.Text = ("(0)");
                    }
                    
                    txtCreditValue.Text = credit_current_price.ToString("(###,###.00)");
                    txtCreditTotalCost.Text = credit_cost_price.ToString("(###,###.00)");
                    if (credit_quantity != 0)
                    {
                        txtCreditAvgCost.Text = (credit_cost_price / credit_quantity).ToString("(###,###.00)");
                    }
                    else
                    {
                        txtCreditAvgCost.Text = decimal.Parse("0.00").ToString("(###,###.00)");
                    }                   
                }
                else
                {
                    txtDebitVolume.Text = "0";
                    txtDebitValue.Text = "0.00";
                    txtDebitTotalCost.Text = "0.00";
                    txtDebitAvgCost.Text = "0.00";

                    txtCreditVolume.Text = "(0)";
                    txtCreditValue.Text = "(0.00)";
                    txtCreditTotalCost.Text = "(0.00)";
                    txtCreditAvgCost.Text = "(0.00)";
                }
                FetchDRDetailsForSOI();
            }
            catch (Exception)
            {
                
               // throw;
            }
        }

        protected void ibtnGetPhysicalCountAdjustment_Click(object sender, ImageClickEventArgs e)
        {
            ReloadFetchAdjustmentsForSOI(txtOutletName.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));
        }

        protected void ibtnLoadBookAdjustment_Click(object sender, ImageClickEventArgs e)
        {
            ReloadFetchBookAdjustmentsForSOI(txtOutletName.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));
        }

        protected void btnOKSaveSOI_Click(object sender, EventArgs e)
        {
            btnSaveSOI_Click(sender, e);
            lblSaved_ModalPopupExtender.Show();
        }

        protected void btnGenerateSOI_Click(object sender, EventArgs e)
        {
            try
            {
                hpLinkDeliveryDetails.NavigateUrl = "~/Accounting/DeliveryDetailsForSOI.aspx?CustomerNumber=" + hfCustomerRecordNumber.Value 
                    + "&FromDate="+txtPeriodFrom.Text+"&ToDate="+txtPeriodTo.Text;
                if (SOIManager.IsAlreadyGenerated(long.Parse(hfCustomerRecordNumber.Value),
                    DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text)) == true)
                {
                    lblIsAlreadyHasSOIMessage.Text = "WARNING: This customer: " + txtOutletName.Text + "\n has already Store Outstanding Inventory \n generated for selected period :" + txtPeriodFrom.Text + " to " + txtPeriodTo.Text;
                    lblHasSOITriggerEvent_ModalPopupExtender.Show();
                    return;
                }
                else
                {

                btnSaveSOI.Enabled = true;
                //dr

              //  StopWatch swatch = new StopWatch();
                GetDRDetailsforSOI();
                             
               // swatch.Start();
                GetDRTotalCostPrice();
               // swatch.Stop();
                //lblSpeed.Text += swatch.GetElapsedTimeSecs().ToString() + " ";

                ComputeDeliveryReceiptAverageCost();
                //crs
                GetCRSDetailsforSOI();
                GetCRSQuantityAmountForSOI();

               // swatch.Start();
                GetCRSCostAmountForSOI();
              //  swatch.Stop();
                //lblSpeed.Text += swatch.GetElapsedTimeSecs().ToString() + " ";

                ComputeCRSAverageCost();
                GetGrossSalesSummary();
                GetBeginningInventorySummary();

                ReloadFetchAdjustmentsForSOI(txtOutletName.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));
                ReloadFetchBookAdjustmentsForSOI(txtOutletName.Text, DateTime.Parse(txtPeriodFrom.Text), DateTime.Parse(txtPeriodTo.Text));
                FetchDRDetailsForSOI();
                }

            }
            catch (Exception)
            {
                FetchDRDetailsForSOI();
            }
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Redirector.Redirect("~/Accounting/SOIPanel.aspx");
        }
    }

    public class StopWatch
    {

        private DateTime startTime;
        private DateTime stopTime;
        private bool running = false;


        public void Start()
        {
            this.startTime = DateTime.Now;
            this.running = true;
        }


        public void Stop()
        {
            this.stopTime = DateTime.Now;
            this.running = false;
        }

        // elaspsed time in milliseconds
        public double GetElapsedTime()
        {
            TimeSpan interval;

            if (running)
                interval = DateTime.Now - startTime;
            else
                interval = stopTime - startTime;

            return interval.TotalMilliseconds;
        }

        // elaspsed time in seconds
        public double GetElapsedTimeSecs()
        {
            TimeSpan interval;

            if (running)
                interval = DateTime.Now - startTime;
            else
                interval = stopTime - startTime;

            return interval.TotalSeconds;
        }
    }
}