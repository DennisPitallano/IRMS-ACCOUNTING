using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.Entities;
using IRMS.ObjectModel;
using IRMS.Components;
using System.Text;
using System.Data;
using IntegratedResourceManagementSystem.Common;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class NewBookAdjustment : System.Web.UI.Page
    {
        const long START_REFERENCE_NUMBER = 10000;
        BrandManager BM = new BrandManager();
        ProductManager PM = new ProductManager();
        List<MemoParticular> MemoParticularList = new List<MemoParticular>();
        List<MemoParticular> CreditParticularList = new List<MemoParticular>();
        BookAdjustmentManager BookAdjustmentManager = new BookAdjustmentManager();
        BookAdjustmentMemoManager BookAdjustmentMemoManager = new BookAdjustmentMemoManager();
        CustomerManager CustomerManager = new CustomerManager();
        long LAST_REFERENCE_NUMBER = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            Permission.PERMITTED_USER = (UsersClass)Session["USER_ACCOUNT"];
            Permission.ROLES = (List<UserRole>)Session["USER_ROLES"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeData();
            }
        }

        public void InitializeData()
        {

            hfOutletName.Value = PreviousPage.OUTLET_.CompanyName;
            txtDebitMemoOutlet.Text = hfOutletName.Value;
            txtCreditMemoOutlet.Text = hfOutletName.Value;
            hfOutletNumber.Value = PreviousPage.OUTLET_.CustomerNumber.ToString();
            txtCreditBrand.Text = PreviousPage.OUTLET_.Brand;
            txtDebitBrand.Text = PreviousPage.OUTLET_.Brand;
            txtDatePeriodFrom.Text = PreviousPage.PERIOD_FROM_.ToString("MMMM dd,yyyy");
            txtDatePeriodTo.Text = PreviousPage.PERIOD_TO_.ToString("MMMM dd,yyyy");
            txtDateCreditfrom.Text = PreviousPage.PERIOD_FROM_.ToString("MMMM dd,yyyy");
            txtDateCreditTo.Text = PreviousPage.PERIOD_TO_.ToString("MMMM dd,yyyy");
            txtInventoryDate.Text = PreviousPage.PERIOD_FROM_.ToString("MMMM dd,yyyy");
            txtCutOffDate.Text = PreviousPage.PERIOD_TO_.ToString("MMMM dd,yyyy");
            txtDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            txtDateCredit.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            LAST_REFERENCE_NUMBER = BookAdjustmentMemoManager.GetLastMemoreferenceNumber();
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

        protected void dlItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlItems.SelectedIndex == 0)
            {
                lblErrorCredit.Text = "WARNING: PLEASE SELECT FROM LIST.";
                btnAddCreditMemo.Enabled = false;
            }
            else
            {
                lblErrorCredit.Text = "";
                btnAddCreditMemo.Enabled = true;
            }
            if (IsTransactionExisted(dlItems.SelectedValue, gvCreditParticulars) == true)
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

        protected void dlParticulars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlParticulars.SelectedIndex == 0)
            {
                lblError.Text = "WARNING: PLEASE SELECT FROM LIST.";
                btnAddParticular.Enabled = false;
            }
            else
            {
                lblError.Text = "";
                btnAddParticular.Enabled = true;
            }
            if (IsTransactionExisted(dlParticulars.SelectedItem.Text, gvParticulars) == true)
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
        private bool IsTransactionExisted(string transaction,GridView gv)
        {
            bool result = false;
            foreach (TableRow row in gv.Rows)
            {
                if (transaction == "OTHERS")
                {
                    result = false;
                }
                if (row.Cells[0].Text == transaction && transaction !="OTHERS")
                {
                    result = true;
                    break;
                }
            }
            return result;
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
            memo_particular.Particular = dlItems.SelectedValue;
            memo_particular.Quantity = long.Parse(this.txtCreditQuantity.Text);
            memo_particular.CurrentPrice = decimal.Parse(this.txtCreditCurrentPrice.Text);
            memo_particular.CostPrice = decimal.Parse(this.txtCreditCostPrice.Text);
            CreditParticularList.Add(memo_particular);
            gvCreditParticulars.DataSource = this.CreditParticularList;
            gvCreditParticulars.DataBind();
            CreditMemoSummary();
            OutputCreditSummary(dlItems.SelectedItem.Text);

            dlItems.SelectedIndex = 0;
            txtCreditQuantity.Text = string.Empty;
            txtCreditCurrentPrice.Text = string.Empty;
            txtCreditCostPrice.Text = string.Empty;
        }
        private void OutputCreditSummary(string transaction_type)
        {
            switch (transaction_type)
            {
                case "SALES":
                    txtTotalSalesQuantity.Text = (long.Parse(txtTotalSalesQuantity.Text)
                                                  + long.Parse(this.txtCreditQuantity.Text)).ToString();
                    txtTotalSalesCurrentPrice.Text = (decimal.Parse(this.txtTotalSalesCurrentPrice.Text.Replace("Php", ""))
                                                      + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalSalesCostPrice.Text = (decimal.Parse(this.txtTotalSalesCostPrice.Text.Replace("Php", ""))
                                                   + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
                case "RETURNS":
                    this.txtTotalReturnsQuantity.Text = (long.Parse(txtTotalReturnsQuantity.Text)
                                                         + long.Parse(txtCreditQuantity.Text)).ToString();
                    txtTotalReturnsCurrentPrice.Text = (decimal.Parse(this.txtTotalReturnsCurrentPrice.Text.Replace("Php", ""))
                                                        + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalReturnsCostPrice.Text = (decimal.Parse(this.txtTotalReturnsCostPrice.Text.Replace("Php", ""))
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
                    txtTotalOthersQuantity.Text = (long.Parse(txtTotalOthersQuantity.Text)
                                                   + long.Parse(txtCreditQuantity.Text)).ToString();
                    txtTotalOthersCurrentPrice.Text = (decimal.Parse(this.txtTotalOthersCurrentPrice.Text.Replace("Php", ""))
                                                       + decimal.Parse(this.txtCreditCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalOthersCostPrice.Text = (decimal.Parse(this.txtTotalOthersCostPrice.Text.Replace("Php", ""))
                                                    + decimal.Parse(this.txtCreditCostPrice.Text)).ToString("Php###,###.00");
                    break;
            }
            ComputeSummary();
        }
        private void CreditMemoSummary()
        {
            txtCreditTotalQuantity.Text = GetTotalCreditQuantity().ToString();
            txtCreditTotalCurrentPrice.Text = GetTotalCreditCurrentPrice().ToString("Php###,###.00");
            txtCreditTotalCostPrice.Text = GetTotalCreditCostPrice().ToString("Php###,###.00");
        }
        private void ComputeSummary()
        {
            txtTotalCreditQuantity.Text = txtDebitTotalQuantity.Text;
            txtTotalCreditCurrentPrice.Text = txtDebitTotalCurrentPrice.Text;
            txtTotalCreditCostPrice.Text = txtDebitTotalCostPrice.Text;

            txtTotalDebitQuantity.Text = txtCreditTotalQuantity.Text;
            txtTotalDebitCurrentPrice.Text = txtCreditTotalCurrentPrice.Text;
            txtTotalDebitCostPrice.Text = txtCreditTotalCostPrice.Text; 
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


        protected void btnAddParticular_Click(object sender, EventArgs e)
        {
            foreach (TableRow row in this.gvParticulars.Rows)
            {
                MemoParticular memo_p = new MemoParticular();
                memo_p.Particular = row.Cells[0].Text;
                memo_p.Quantity = long.Parse(row.Cells[1].Text);
                memo_p.CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", ""));
                memo_p.CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", ""));
                MemoParticularList.Add(memo_p);
            }
            MemoParticular memo_particular = new MemoParticular();
            memo_particular.Particular = dlParticulars.SelectedItem.Text;
            memo_particular.Quantity = long.Parse(txtParticularQuantity.Text);
            memo_particular.CurrentPrice = decimal.Parse(txtCurrentPrice.Text);
            memo_particular.CostPrice = decimal.Parse(txtCostPrice.Text);
            MemoParticularList.Add(memo_particular);
            gvParticulars.DataSource = MemoParticularList;
            gvParticulars.DataBind();
            DebitMemoSummary();
            OutputDebitSummary(this.dlParticulars.SelectedValue);
            dlParticulars.SelectedIndex = 0;
            txtParticularQuantity.Text = string.Empty;
            txtCurrentPrice.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
        }

        #region "DEBIT"
        private void DebitMemoSummary()
        {
            txtDebitTotalQuantity.Text = GetTotalDebitQuantity().ToString();
            txtDebitTotalCurrentPrice.Text = GetTotalDebitCurrrentPrice().ToString("Php###,###.00");
            txtDebitTotalCostPrice.Text = GetTotalDebitCostPrice().ToString("Php###,###.00");
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
        #endregion
        #region "Debit Output Preview"
        private void OutputDebitSummary(string transaction_type)
        {
            switch (transaction_type)
            {
                case "DELIVERIES":
                    txtTotalDeliveriesQuantitySummary.Text = (long.Parse(txtTotalDeliveriesQuantitySummary.Text)
                                                              + long.Parse(this.txtParticularQuantity.Text)).ToString();
                    txtTotalDeliveriesCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalDeliveriesCurrentPriceSummary.Text.Replace("Php", ""))
                                                                  + decimal.Parse(this.txtCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalDeliveriesCostPriceSummary.Text = (decimal.Parse(this.txtTotalDeliveriesCostPriceSummary.Text.Replace("Php", ""))
                                                               + decimal.Parse(this.txtCostPrice.Text)).ToString("Php###,###.00");
                    break;
              
                case "OTHERS":
                    txtTotalOthersCreditSummary.Text = (long.Parse(txtTotalOthersCreditSummary.Text)
                                                        + long.Parse(this.txtParticularQuantity.Text)).ToString();
                    txtTotalOthersCreditCurrentPriceSummary.Text = (decimal.Parse(this.txtTotalOthersCreditCurrentPriceSummary.Text.Replace("Php", ""))
                                                                    + decimal.Parse(this.txtCurrentPrice.Text)).ToString("Php###,###.00");
                    txtTotalOthersCreditCostPriceSummary.Text = (decimal.Parse(this.txtTotalOthersCreditCostPriceSummary.Text.Replace("Php", ""))
                                                                 + decimal.Parse(this.txtCostPrice.Text)).ToString("Php###,###.00");
                    break;
            }
            ComputeSummary();
        }

        #endregion

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
                var BookAdjustment = new BookAdjustment
                {
                    AdjustmentCode = CreateCode(15),
                    InventoryDate = DateTime.Parse(txtInventoryDate.Text),
                    CutOffDate = DateTime.Parse(txtCutOffDate.Text),
                     OutletNumber = int.Parse(hfOutletNumber.Value) ,
                     OutletName =  hfOutletName.Value,
                    DateRecorded = DateTime.Now
                };
                BookAdjustmentManager.Save(BookAdjustment);
                #region log
                BookAdjustmentManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.INSERT);
                #endregion

                if (gvCreditParticulars.Rows.Count>0)
                {
                    foreach (TableRow row in this.gvCreditParticulars.Rows)
                    {
                        var BookAdjustmentCreditMemo = new BookAdjustmentMemo
                        {
                            AdjustmentCode = BookAdjustment.AdjustmentCode,
                            CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", "")),
                            CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", "")),
                            MemoDate = DateTime.Parse(txtDateCredit.Text),
                            MemoType = "CREDIT",
                            ParticularTransaction = row.Cells[0].Text,
                            PeriodFrom = DateTime.Parse(txtDateCreditfrom.Text),
                            PeriodTo = DateTime.Parse(txtDateCreditTo.Text),
                            Quantity = long.Parse(row.Cells[1].Text),
                            ReferenceNumber = long.Parse(txtCreditReferenceNumber.Text),
                            DateRecorded = DateTime.Now
                        };
                        BookAdjustmentMemoManager.Save(BookAdjustmentCreditMemo);
                    }
                }

                if (gvParticulars.Rows.Count >0)
                {
                    foreach (TableRow row in this.gvParticulars.Rows)
                    {
                        var BookAdjustmentDebitMemo = new BookAdjustmentMemo
                        {
                            AdjustmentCode = BookAdjustment.AdjustmentCode,
                            CostPrice = decimal.Parse(row.Cells[3].Text.Replace("Php", "")),
                            CurrentPrice = decimal.Parse(row.Cells[2].Text.Replace("Php", "")),
                            MemoDate = DateTime.Parse(txtDate.Text),
                            MemoType = "DEBIT",
                            ParticularTransaction = row.Cells[0].Text,
                            PeriodFrom = DateTime.Parse(txtDatePeriodFrom.Text),
                            PeriodTo = DateTime.Parse(txtDatePeriodTo.Text),
                            Quantity = long.Parse(row.Cells[1].Text),
                            ReferenceNumber = long.Parse(txtReferenceNumber.Text),
                            DateRecorded = DateTime.Now
                        };
                        BookAdjustmentMemoManager.Save(BookAdjustmentDebitMemo);
                    }
              
                }
                
                lblSaved_ModalPopupExtender.Show();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btnOKSaveMEMO_Click(object sender, EventArgs e)
        {
            btnSaveMemo_Click(sender, e);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Redirector.Redirect("~/Accounting/BookAdjustmentPanel.aspx");
        }

    }
}