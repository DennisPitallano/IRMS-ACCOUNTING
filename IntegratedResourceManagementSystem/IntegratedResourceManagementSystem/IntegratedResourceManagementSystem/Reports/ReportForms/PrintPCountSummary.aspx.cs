using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class PrintPCountSummary : System.Web.UI.Page
    {
        AdjustmentMemoManager AdjusmentMemoManager = new AdjustmentMemoManager();
        AdjustmentManager AdjManager = new AdjustmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDateNow.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            LoadData();
        }

        public void LoadData()
        {
            string AdjustmentCode = Request.QueryString["AdjustmentCode"];
            string Customer = Request.QueryString["Customer"];
            LoadTransactionSummary(AdjustmentCode,Customer);
            Adjustment adjustment=AdjManager.GetAdjustmentByKey(long.Parse(Request.QueryString["RecordNumber"]));
            lblTransactionSummaryOutlet.Text = HttpUtility.HtmlDecode(adjustment.OutletName);
        }
        private void LoadTransactionSummary(string AdjustmentCode, string Customer)
        {
            long debit_quantity = 0;
            long credit_quantity = 0;
            decimal debit_current_price = 0;
            decimal credit_current_price = 0;
            decimal debit_cost_price = 0;
            decimal credit_cost_price = 0;
            List<AdjustmentMemo> AdjustmentMemoDetailsCredit = new List<AdjustmentMemo>();
            List<AdjustmentMemo> AdjustmentMemoDetailsDebit = new List<AdjustmentMemo>();
            foreach (AdjustmentMemo adjmemo in AdjusmentMemoManager.AdjustmentMemosByAdjustmentCode(AdjustmentCode))
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
                lblTransactioSummaryPeriodFrom.Text = adjmemo.PeriodFrom.ToString("MMMM dd, yyyy");
                lblTransactioSummaryPeriodTo.Text = adjmemo.PeriodTo.ToString("MMMM dd, yyyy");
                lblTransactionDateSummary.Text = adjmemo.MemoDate.ToString("MMMM dd, yyyy");
                lblReferenceNumberSumamry.Text = adjmemo.ReferenceNumber.ToString();
            }
            gvDebitSummary.DataSource = AdjustmentMemoDetailsCredit;
            gvDebitSummary.DataBind();
            gvCreditSummary.DataSource = AdjustmentMemoDetailsDebit;
            gvCreditSummary.DataBind();
            this.lblTransactionSummaryTotalQuantity.Text = ((debit_quantity) - credit_quantity).ToString();
            this.lblTransactionSummaryTotalCurrentPrice.Text = ((debit_current_price) - credit_current_price).ToString("###,###.00");
            this.lblTransactionSummaryTotalCostPrice.Text = ((debit_cost_price) - credit_cost_price).ToString("###,###.00");
        }
    }
}