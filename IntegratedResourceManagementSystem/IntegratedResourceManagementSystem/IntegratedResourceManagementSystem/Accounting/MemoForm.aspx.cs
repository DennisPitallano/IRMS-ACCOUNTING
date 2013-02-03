using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IRMS.Components;
using System.Text;
using System.Data;
using IntegratedResourceManagementSystem.Accounting.App_Code;
using IntegratedResourceManagementSystem.Common;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class DebitMemoForm : System.Web.UI.Page
    {
        const long START_REFERENCE_NUMBER = 10000;
        BrandManager BM = new BrandManager();
        ProductManager PM = new ProductManager();
        List<MemoParticular> MemoParticularList = new List<MemoParticular>();
        List<MemoParticular> CreditParticularList = new List<MemoParticular>();
        AdjustmentManager AdjustmentManager = new AdjustmentManager();
        AdjustmentMemoManager AdjustmentMemoManager = new AdjustmentMemoManager();
        CustomerManager CustomerManager = new CustomerManager();
        StoreOutStandingInventoryManager SOIManager = new StoreOutStandingInventoryManager();
        long LAST_REFERENCE_NUMBER = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                   
                    hfOutletName.Value = PreviousPage.OUTLET_.CompanyName;
                    hfOutletNumber.Value = PreviousPage.OUTLET_.CustomerNumber.ToString();
                    txtDatePeriodFrom.Text = PreviousPage.DATE_PERIOD_FROM.ToString("MMMM dd, yyyy");
                    txtDatePeriodTo.Text = PreviousPage.DATE_PERIOD_TO.ToString("MMMM dd, yyyy");
                    txtDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                    txtDateCredit.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                    txtDateCredit.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                    txtDateCreditfrom.Text = PreviousPage.DATE_PERIOD_FROM.ToString("MMMM dd, yyyy");
                    txtDateCreditTo.Text = PreviousPage.DATE_PERIOD_TO.ToString("MMMM dd, yyyy");
                    txtInventoryDate.Text = PreviousPage.DATE_PERIOD_FROM.ToString("MMMM dd, yyyy");
                    txtCutOffDate.Text = PreviousPage.DATE_PERIOD_TO.ToString("MMMM dd, yyyy");
                    txtCreditMemoOutlet.Text = PreviousPage.OUTLET_.CompanyName;
                    txtDebitMemoOutlet.Text = PreviousPage.OUTLET_.CompanyName;
                    txtDebitBrand.Text = PreviousPage.OUTLET_.Brand;
                    txtCreditBrand.Text = PreviousPage.OUTLET_.Brand;
                    GetPhysicalCountSummary();

                    LAST_REFERENCE_NUMBER = AdjustmentMemoManager.GetLastMemoreferenceNumber();
                    if (START_REFERENCE_NUMBER <= LAST_REFERENCE_NUMBER)
                    {
                        txtReferenceNumber.Text = (LAST_REFERENCE_NUMBER + 1).ToString();
                        txtCreditReferenceNumber.Text = (LAST_REFERENCE_NUMBER + 1).ToString();
                    }
                    else
                    {
                        txtReferenceNumber.Text = START_REFERENCE_NUMBER.ToString();
                        txtCreditReferenceNumber.Text = START_REFERENCE_NUMBER.ToString();
                    }
                }
                catch (Exception)
                {
                    Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
                  //  throw;
                }
            }
        }


        protected void ibtnAddParticular_Click(object sender, ImageClickEventArgs e)
        {
            foreach (MemoParticular mem_part in MemoParticularList)
            {
                MemoParticularList.Remove(new MemoParticular{ RecordNo = 0, Particular = gvParticulars.SelectedRow.Cells[0].Text, 
                    Quantity = long.Parse(gvParticulars.SelectedRow.Cells[1].Text), 
                    CurrentPrice = decimal.Parse(gvParticulars.SelectedRow.Cells[2].Text),
                    CostPrice = decimal.Parse(gvParticulars.SelectedRow.Cells[3].Text) });
            }
            gvParticulars.DataSource = MemoParticularList;
            gvParticulars.DataBind();
        }
        
        protected void btnAddParticular_Click(object sender, EventArgs e)
        {
            foreach (TableRow row in gvParticulars.Rows)
            {
                MemoParticular memo_p = new MemoParticular();
                memo_p.Particular = row.Cells[0].Text;
                memo_p.Quantity = long.Parse(row.Cells[1].Text);
                memo_p.CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", ""));
                memo_p.CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", ""));
                MemoParticularList.Add(memo_p);
            }
            MemoParticular memo_particular = new MemoParticular();
            memo_particular.Particular = dlItems.SelectedValue;
            memo_particular.Quantity = long.Parse(txtParticularQuantity.Text);
            memo_particular.CurrentPrice = decimal.Parse(txtCurrentPrice.Text);
            memo_particular.CostPrice = decimal.Parse(txtCostPrice.Text);
            MemoParticularList.Add(memo_particular);
            gvParticulars.DataSource = MemoParticularList;
            gvParticulars.DataBind();
            DebitMemoSummary();
            OutputDebitSummary(this.dlItems.Text);

            dlItems.SelectedIndex = 0;
            txtParticularQuantity.Text = string.Empty;
            txtCurrentPrice.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
        }

        protected void rdioMemoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdioMemoType.SelectedIndex == 0)
            {
                mvMemoForms.ActiveViewIndex = 0;
            }
            else
            {
                mvMemoForms.ActiveViewIndex = 1;
            }
        }

        protected void btnAddCreditMemo_Click(object sender, EventArgs e)
        {
            foreach (TableRow row in this.gvCreditParticulars.Rows)
            {
                MemoParticular memo_p = new MemoParticular();
                memo_p.Particular = row.Cells[0].Text;
                memo_p.Quantity = long.Parse(row.Cells[1].Text);
                memo_p.CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", ""));
                memo_p.CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", ""));
                CreditParticularList.Add(memo_p);
            }
            MemoParticular memo_particular = new MemoParticular();
            memo_particular.Particular = dlParticulars.SelectedValue;
            memo_particular.Quantity = long.Parse(this.txtCreditQuantity.Text);
            memo_particular.CurrentPrice = decimal.Parse(this.txtCreditCurrentPrice.Text);
            memo_particular.CostPrice = decimal.Parse(this.txtCreditCostPrice.Text);
            CreditParticularList.Add(memo_particular);
            gvCreditParticulars.DataSource = this.CreditParticularList;
            gvCreditParticulars.DataBind();
            CreditMemoSummary();
            OutputCreditSummary(dlParticulars.SelectedItem.Text);

            dlParticulars.SelectedIndex = 0;
            txtCreditQuantity.Text = string.Empty;
            txtCreditCurrentPrice.Text = string.Empty;
            txtCreditCostPrice.Text = string.Empty;
        }

        #region "Debit Output Preview"
        private void OutputDebitSummary(string transaction_type)
        {
            switch (transaction_type)
            {
                case "SALES":
                    txtTotalSalesQuantity.Text = (long.Parse(txtTotalSalesQuantity.Text) 
                                                  + long.Parse(this.txtParticularQuantity.Text)).ToString();
                    txtTotalSalesCurrentPrice.Text = (decimal.Parse(this.txtTotalSalesCurrentPrice.Text.Replace("Php", ""))
                                                      + decimal.Parse(this.txtCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalSalesCostPrice.Text = (decimal.Parse(this.txtTotalSalesCostPrice.Text.Replace("Php", ""))
                                                   + decimal.Parse(this.txtCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "RETURNS":
                    this.txtTotalReturnsQuantity.Text = (long.Parse(txtTotalReturnsQuantity.Text)
                                                         + long.Parse(txtParticularQuantity.Text)).ToString();
                    txtTotalReturnsCurrentPrice.Text = (decimal.Parse(this.txtTotalReturnsCurrentPrice.Text.Replace("Php", ""))
                                                        + decimal.Parse(this.txtCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalReturnsCostPrice.Text = (decimal.Parse(this.txtTotalReturnsCostPrice.Text.Replace("Php", ""))
                                                     + decimal.Parse(this.txtCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "OTHERS":
                    txtTotalOthersQuantity.Text = (long.Parse(txtTotalOthersQuantity.Text)
                                                   + long.Parse(txtParticularQuantity.Text)).ToString();
                    txtTotalOthersCurrentPrice.Text = (decimal.Parse(this.txtTotalOthersCurrentPrice.Text.Replace("Php", ""))
                                                       + decimal.Parse(this.txtCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalOthersCostPrice.Text = (decimal.Parse(this.txtTotalOthersCostPrice.Text.Replace("Php", ""))
                                                    + decimal.Parse(this.txtCostPrice.Text)).ToString("Php###,###.00");
                    break;
            }
            ComputeSummary();
        }
        
        #endregion
        #region "Credit Output Preview"
        private void OutputCreditSummary(string transaction_type)
        {
            switch (transaction_type)
            {
                case "DELIVERIES":
                    txtTotalDeliveriesQuantitySummary.Text = (long.Parse(txtTotalDeliveriesQuantitySummary.Text)
                                                              + long.Parse(this.txtCreditQuantity.Text)).ToString();
                    txtTotalDeliveriesCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalDeliveriesCurrentPriceSummary.Text.Replace("Php", ""))
                                                                  + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalDeliveriesCostPriceSummary.Text = (decimal.Parse(this.txtTotalDeliveriesCostPriceSummary.Text.Replace("Php", ""))
                                                               + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "SHOPLIFT":
                    txtTotalShopLiftQuantitySummary.Text = (long.Parse(txtTotalShopLiftQuantitySummary.Text)
                                                            + long.Parse(this.txtCreditQuantity.Text)).ToString();
                    txtTotalShopLiftCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalShopLiftCurrentPriceSummary.Text.Replace("Php", ""))
                                                                + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalShopLiftCostPriceSummary.Text = (decimal.Parse(this.txtTotalShopLiftCostPriceSummary.Text.Replace("Php", ""))
                                                             + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "UNCOLLECTED SALES":
                    txtTotalUncollectedSalesQuantity.Text = (long.Parse(txtTotalUncollectedSalesQuantity.Text)
                                                             + long.Parse(this.txtCreditQuantity.Text)).ToString();
                    txtTotalUncollectedSalesCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalUncollectedSalesCurrentPriceSummary.Text.Replace("Php", ""))
                                                                        + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalUncollectedSalesCostPriceSummary.Text = (decimal.Parse(this.txtTotalUncollectedSalesCostPriceSummary.Text.Replace("Php", ""))
                                                                     + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "PILFERAGE(lacking)":
                    txtTotalPilferageQuantitySummary.Text = (long.Parse(txtTotalPilferageQuantitySummary.Text)
                                                             + long.Parse(this.txtCreditQuantity.Text)).ToString();
                    txtTotalPilferageCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalPilferageCurrentPriceSummary.Text.Replace("Php", ""))
                                                                 + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalPilferageCostPriceSummary.Text = (decimal.Parse(this.txtTotalPilferageCostPriceSummary.Text.Replace("Php", ""))
                                                              + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "OTHERS":
                    txtTotalOthersCreditSummary.Text = (long.Parse(txtTotalOthersCreditSummary.Text)
                                                        + long.Parse(this.txtCreditQuantity.Text)).ToString();
                    txtTotalOthersCreditCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalOthersCreditCurrentPriceSummary.Text.Replace("Php", ""))
                                                                    + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalOthersCreditCostPriceSummary.Text = (decimal.Parse(this.txtTotalOthersCreditCostPriceSummary.Text.Replace("Php", ""))
                                                                 + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
            }
            ComputeSummary();
        }

        private void ComputeSummary()
        {
            txtTotalCreditQuantity.Text = txtCreditTotalQuantity.Text;
            txtTotalCreditCurrentPrice.Text = txtCreditTotalCurrentPrice.Text;
            txtTotalCreditCostPrice.Text = txtCreditTotalCostPrice.Text;

            txtTotalDebitQuantity.Text = txtDebitTotalQuantity.Text;
            txtTotalDebitCurrentPrice.Text = txtDebitTotalCurrentPrice.Text;
            txtTotalDebitCostPrice.Text = txtDebitTotalCostPrice.Text;

            txtAdjustmentPCountQuantitySummary.Text = GetTotalAdjustmentPCountQuantity().ToString();
            txtAdjustmentPCountCurrentPriceSummary.Text = GetTotalAdjustmentPCountCurrentPrice().ToString("Php###,###.00");
            txtAdjustmentPCountCostPriceSummary.Text = GetTotalAdjustmentPCountCostPrice().ToString("Php###,###.00");


        }

        #endregion
        private void CreditMemoSummary()
        {
            txtCreditTotalQuantity.Text = GetTotalCreditQuantity().ToString();
            txtCreditTotalCurrentPrice.Text = GetTotalCreditCurrentPrice().ToString("Php###,###.00");
            txtCreditTotalCostPrice.Text = GetTotalCreditCostPrice().ToString("Php###,###.00");
        }

        private void DebitMemoSummary()
        {
            txtDebitTotalQuantity.Text = GetTotalDebitQuantity().ToString();
            txtDebitTotalCurrentPrice.Text = GetTotalDebitCurrrentPrice().ToString("Php###,###.00");
            txtDebitTotalCostPrice.Text = GetTotalDebitCostPrice().ToString("Php###,###.00");
        }

        private long GetTotalCreditQuantity()
        {
            long total = 0;
            foreach (TableRow row in this.gvCreditParticulars.Rows)
            {
                total = total + long.Parse(row.Cells[1].Text);
            }
            return total;
        }

        private decimal GetTotalCreditCurrentPrice()
        {
            decimal total = 0;
            foreach (TableRow row in this.gvCreditParticulars.Rows)
            {
                total = total + decimal.Parse(row.Cells[2].Text.Replace("Php", ""));
            }
            return total;
        }

        private decimal GetTotalCreditCostPrice()
        {
            decimal total = 0;
            foreach (TableRow row in this.gvCreditParticulars.Rows)
            {
                total = total + decimal.Parse(row.Cells[3].Text.Replace("Php", ""));
            }
            return total;
        }

        private long GetTotalDebitQuantity()
        {
            long total = 0;
            foreach (TableRow row in this.gvParticulars.Rows)
            {
                total = total + long.Parse(row.Cells[1].Text);
            }
            return total;
        }

        private decimal GetTotalDebitCurrrentPrice()
        {
            decimal total = 0;
            foreach (TableRow row in this.gvParticulars.Rows)
            {
                total = total + decimal.Parse(row.Cells[2].Text.Replace("Php", ""));
            }
            return total;
        }

        private decimal GetTotalDebitCostPrice()
        {
            decimal total = 0;
            foreach (TableRow row in this.gvParticulars.Rows)
            {
                total = total + decimal.Parse(row.Cells[3].Text.Replace("Php", ""));
            }
            return total;
        }

        private decimal GetTotalAdjustmentPCountQuantity()
        {
            decimal result = 0;
            result = (decimal.Parse(txtActualPhysicalCountQuantity.Text) + decimal.Parse(txtDebitTotalQuantity.Text)) - decimal.Parse(txtCreditTotalQuantity.Text);
            return result;
        }

        private decimal GetTotalAdjustmentPCountCurrentPrice()
        {
            decimal result = 0;
            result = (decimal.Parse(txtActualPhysicalCountCurrentPrice.Text) + decimal.Parse(txtDebitTotalCurrentPrice.Text.Replace("Php", ""))) 
                     - decimal.Parse(txtCreditTotalCurrentPrice.Text.Replace("Php", ""));
            return result;
        }

        private decimal GetTotalAdjustmentPCountCostPrice()
        {
            decimal result = 0;
            result = (decimal.Parse(txtActualPhysicalPriceCostPrice.Text) + decimal.Parse(txtDebitTotalCostPrice.Text.Replace("Php", "")))
                     - decimal.Parse(txtCreditTotalCostPrice.Text.Replace("Php", ""));
            return result;
        }

        private bool IsTransactionExisted(string transaction, GridView gv)
        {
            bool result = false;
            foreach (TableRow row in gv.Rows)
            {
                if (transaction == "OTHERS")
                {
                    result = false;
                }
                if (row.Cells[0].Text == transaction && transaction!= "OTHERS")
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        protected void dlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlItems.SelectedIndex == 0)
            {
                lblError.Text = "WARNING: PLEASE SELECT FROM LIST.";
                btnAddParticular.Enabled = false;
            }
            if (IsTransactionExisted(dlItems.SelectedValue, gvParticulars) == true)
            {
                lblError.Text = "WARNING: TRANSACTION ALREADY EXIST!";
                btnAddParticular.Enabled = false;
            }
            else
            {
                lblError.Text = "";
                btnAddParticular.Enabled = true;
            }
            ibtnAddParticular0_ModalPopupExtender.Show();
        }

        protected void dlParticulars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlParticulars.SelectedIndex == 0)
            {
                lblErrorCredit.Text = "WARNING: PLEASE SELECT FROM LIST.";
                btnAddCreditMemo.Enabled = false;
            }
            if (IsTransactionExisted(dlParticulars.SelectedValue, gvCreditParticulars) == true)
            {
                lblErrorCredit.Text = "WARNING: TRANSACTION ALREADY EXIST!";
                btnAddCreditMemo.Enabled = false;
            }
            else
            {
                lblErrorCredit.Text = "";
                btnAddCreditMemo.Enabled = true;
            }
            ModalPopupExtender1.Show();
        }

        private static Random random = new Random();

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

        protected void btnSaveMemo_Click(object sender, EventArgs e)
        {
            try
            {
                var Adjustment = new Adjustment
                {
                    AdjustmentCode = CreateCode(15),
                    InventoryDate = DateTime.Parse(txtInventoryDate.Text),
                    CutOffDate = DateTime.Parse(txtCutOffDate.Text),
                    ActualPhysicalCountQuantity = long.Parse(txtActualPhysicalCountQuantity.Text),
                    ActualPhysicalCountCostPrice = decimal.Parse(txtActualPhysicalPriceCostPrice.Text),
                    ActualPhysicalCountCurrentPrice = decimal.Parse(txtActualPhysicalCountCurrentPrice.Text),
                     OutletName = hfOutletName.Value ,
                      OutletNumber = int.Parse(hfOutletNumber.Value),
                    DateRecorded = DateTime.Now
                };
                AdjustmentManager.Save(Adjustment);

                if (gvCreditParticulars.Rows.Count >0)
                {
                    foreach (TableRow row in this.gvCreditParticulars.Rows)
                    {
                        var AdjustmentCreditMemo = new AdjustmentMemo
                        {
                            AdjustmentCode = Adjustment.AdjustmentCode,
                            CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", "")),
                            CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", "")),
                            MemoDate = DateTime.Parse(txtDateCredit.Text),
                            MemoType = "CREDIT",
                            //OutLet = dlCreditOutlet.SelectedItem.Text,
                            ParticularTransaction = row.Cells[0].Text,
                            PeriodFrom = DateTime.Parse(txtDateCreditfrom.Text),
                            PeriodTo = DateTime.Parse(txtDateCreditTo.Text),
                            Quantity = long.Parse(row.Cells[1].Text),
                            ReferenceNumber = long.Parse(txtCreditReferenceNumber.Text),
                            DateRecorded = DateTime.Now
                        };
                        AdjustmentMemoManager.Save(AdjustmentCreditMemo);
                    }
                }

                if (this.gvParticulars.Rows.Count > 0)
                {
                    foreach (TableRow row in this.gvParticulars.Rows)
                    {
                        var AdjustmentDebitMemo = new AdjustmentMemo
                        {
                            AdjustmentCode = Adjustment.AdjustmentCode,
                            CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", "")),
                            CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", "")),
                            MemoDate = DateTime.Parse(txtDate.Text),
                            MemoType = "DEBIT",
                            //OutLet = dlOutlets.SelectedItem.Text,
                            ParticularTransaction = row.Cells[0].Text,
                            PeriodFrom = DateTime.Parse(txtDatePeriodFrom.Text),
                            PeriodTo = DateTime.Parse(txtDatePeriodTo.Text),
                            Quantity = long.Parse(row.Cells[1].Text),
                            ReferenceNumber = long.Parse(txtReferenceNumber.Text),
                            DateRecorded = DateTime.Now
                        };
                        AdjustmentMemoManager.Save(AdjustmentDebitMemo);
                    }
                }

                #region log
                AdjustmentManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.INSERT);
                #endregion
                lblSaved_ModalPopupExtender.Show();
            }
            catch (Exception)
            {
                
                //throw;
            }
           
        }

        protected void txtActualPhysicalCountQuantity_TextChanged(object sender, EventArgs e)
        {
            ComputeSummary();
        }

        protected void txtActualPhysicalCountCurrentPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeSummary();
        }

        protected void txtActualPhysicalPriceCostPrice_TextChanged(object sender, EventArgs e)
        {
            ComputeSummary();
        }

        protected void txtReferenceNumber_TextChanged(object sender, EventArgs e)
        {
            txtCreditReferenceNumber.Text = txtReferenceNumber.Text;
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            txtDateCredit.Text = txtDate.Text;
        }

        protected void txtDatePeriodFrom_TextChanged(object sender, EventArgs e)
        {
            txtDateCreditfrom.Text = txtDatePeriodFrom.Text;
        }

        protected void txtDatePeriodTo_TextChanged(object sender, EventArgs e)
        {
            txtDateCreditTo.Text = txtDatePeriodTo.Text;
        }


        protected void txtCreditReferenceNumber_TextChanged(object sender, EventArgs e)
        {
            txtReferenceNumber.Text = txtCreditReferenceNumber.Text;
        }

        protected void txtDateCredit_TextChanged(object sender, EventArgs e)
        {
            txtDate.Text = txtDateCredit.Text;
        }

        protected void txtDateCreditfrom_TextChanged(object sender, EventArgs e)
        {
            txtDatePeriodFrom.Text = txtDateCreditfrom.Text;
        }

        protected void txtDateCreditTo_TextChanged(object sender, EventArgs e)
        {
            txtDatePeriodTo.Text = txtDateCreditTo.Text;
        }

        private string GetBrandByKey(int key)
        {
            return CustomerManager.Customers().Where(c => c.CustomerNumber == key).FirstOrDefault().Brand;
        }

        protected void ibtnDeleteParticular_Click(object sender, ImageClickEventArgs e)
        {
            gvParticulars.DataSource = null;
            gvParticulars.DataBind();
        }

        protected void ibtnResetCredit_Click(object sender, ImageClickEventArgs e)
        {
            gvCreditParticulars.DataSource = null;
            gvCreditParticulars.DataBind();
        }
        private void GetPhysicalCountSummary()
        {
            try
            {
                {
                    List<SOI_BeginningInventory> SOI_PCOUNT = new List<SOI_BeginningInventory>();
                    DateTime dtPeriodFrom = new DateTime(DateTime.Parse(txtCutOffDate.Text).Year,
                     DateTime.Parse(this.txtInventoryDate.Text).Month, 1);
                    DateTime dtPeriodToTemp = DateTime.Parse(txtInventoryDate.Text);
                    DateTime dtPeriodTo = new DateTime(dtPeriodToTemp.Year, dtPeriodToTemp.Month,
                        DateTime.DaysInMonth(dtPeriodToTemp.Year, dtPeriodToTemp.Month));

                    if (dtPeriodToTemp.Month == 12 && dtPeriodToTemp.Day == 31) // ENDING YEAR 
                    {
                        dtPeriodFrom = new DateTime(dtPeriodToTemp.Year + 1, 1, 1);
                        dtPeriodTo = new DateTime(dtPeriodToTemp.Year + 1, 1, DateTime.DaysInMonth(dtPeriodToTemp.Year, 1));
                    }
                    DataTable physical_count = SOIManager.GetDataTableStoreOutStandingInventoryPhysiclCountSummary1(
                                          long.Parse(hfOutletNumber.Value), dtPeriodFrom, dtPeriodTo);
                    foreach (DataRow row in physical_count.Rows)
                    {
                        SOI_BeginningInventory PCOUNT = new SOI_BeginningInventory();
                        PCOUNT.Volume = decimal.Parse(row[1].ToString());
                        PCOUNT.Value = decimal.Parse(row[0].ToString());
                        PCOUNT.TotalCost = decimal.Parse(row[2].ToString());
                        PCOUNT.AverageCost = (decimal.Parse(row[2].ToString()) / decimal.Parse(row[1].ToString()));
                        SOI_PCOUNT.Add(PCOUNT);
                    }
                    SOI_BeginningInventory BI = SOI_PCOUNT[0];
                    SOI_BeginningInventory EI = SOI_PCOUNT[1];

                    txtActualPhysicalPriceCostPrice.Text = EI.TotalCost.ToString("###,###.00");
                    txtActualPhysicalCountCurrentPrice.Text = EI.Value.ToString("###,###.00");
                    txtActualPhysicalCountQuantity.Text = EI.Volume.ToString();
                }

            }
            catch (Exception)
            {
                txtActualPhysicalCountCurrentPrice.Text = "0.00";
                txtActualPhysicalCountQuantity.Text = "0";
                txtActualPhysicalPriceCostPrice.Text = "0.00";
            }
            //try
            //{
            //    // 20120316 CTS
            //    DateTime dtPeriodFrom = new DateTime(DateTime.Parse(txtCutOffDate.Text).Year, DateTime.Parse(txtCutOffDate.Text).Month, 1);
            //    DateTime dtPeriodToTemp = DateTime.Parse(txtCutOffDate.Text);
            //    DateTime dtPeriodTo = new DateTime(dtPeriodToTemp.Year, dtPeriodToTemp.Month, DateTime.DaysInMonth(dtPeriodToTemp.Year, dtPeriodToTemp.Month));


            //    if (dtPeriodToTemp.Month == 12 && dtPeriodToTemp.Day == 31) // ENDING YEAR 
            //    {
            //        dtPeriodFrom = new DateTime(dtPeriodToTemp.Year + 1, 1, 1);
            //        dtPeriodTo = new DateTime(dtPeriodToTemp.Year + 1, 1, DateTime.DaysInMonth(dtPeriodToTemp.Year, 1));
            //    }

            //    //DataTable physical_count = SOIManager.GetDataTableStoreOutStandingInventoryPhysiclCountSummary(long.Parse(hfOutletNumber.Value),DateTime.Parse( txtInventoryDate.Text),DateTime.Parse(txtCutOffDate .Text ));
            //    DataTable physical_count = SOIManager.GetDataTableStoreOutStandingInventoryPhysiclCountSummary(long.Parse(hfOutletNumber.Value), dtPeriodFrom, dtPeriodTo);
            //    // 20120316 CTS
              
            //    foreach (DataRow row in physical_count.Rows)
            //    {
            //        txtActualPhysicalCountCurrentPrice.Text = row[0].ToString();
            //        txtActualPhysicalCountQuantity.Text = row[1].ToString();
            //        txtActualPhysicalPriceCostPrice.Text = row[2].ToString();
            //    }
            //    if (txtActualPhysicalCountCurrentPrice.Text == string.Empty)
            //    {
            //        txtActualPhysicalCountCurrentPrice.Text = "0.00";
            //        txtActualPhysicalCountQuantity.Text = "0";
            //        txtActualPhysicalPriceCostPrice.Text = "0.00";
            //    }
            //}
            //catch (Exception)
            //{
            //    txtActualPhysicalCountCurrentPrice.Text = "0.00";
            //    txtActualPhysicalCountQuantity.Text = "0";
            //    txtActualPhysicalPriceCostPrice.Text = "0.00";
            //}
        }

        protected void btnOKSaveMEMO_Click(object sender, EventArgs e)
        {
            btnSaveMemo_Click(sender, e);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
        }
    }
}