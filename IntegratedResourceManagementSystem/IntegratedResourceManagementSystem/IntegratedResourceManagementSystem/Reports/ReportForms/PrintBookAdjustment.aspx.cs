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
    public partial class PrintBookAdjustment : System.Web.UI.Page
    {
        BookAdjustmentManager BookAdjustmentManager = new BookAdjustmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Preview();
        }
        public void Preview()
        {
            string AdjustmentCode = Request.QueryString["AdjustmentCode"];
            string Outlet = Request.QueryString["Outlet"];
            PreviewAdjustmentMemo(AdjustmentCode, Outlet);
        }
        private void PreviewAdjustmentMemo(string adjustment_code, string Outlet)
        {
            long debit_quantity = 0;
            long credit_quantity = 0;
            decimal debit_current_price = 0;
            decimal credit_current_price = 0;
            decimal debit_cost_price = 0;
            decimal credit_cost_price = 0;
            List<BookAdjustmentMemo> AdjustmentMemoDetailsCredit = new List<BookAdjustmentMemo>();
            List<BookAdjustmentMemo> AdjustmentMemoDetailsDebit = new List<BookAdjustmentMemo>();
            foreach (BookAdjustmentMemo adjmemo in BookAdjustmentManager.GetBookAdjustmentMemosByAdjustmentCode(adjustment_code))
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
                lblInventoryDate.Text = adjmemo.PeriodFrom.ToString("MMMM dd, yyyy");
                lblCutOff.Text = adjmemo.PeriodTo.ToString("MMMM dd, yyyy"); ;
            }
            gvCreditMemo.DataSource = AdjustmentMemoDetailsDebit;
            gvCreditMemo.DataBind();
            gvDebitMemo.DataSource = AdjustmentMemoDetailsCredit;
            gvDebitMemo.DataBind();
            lblOutletPreview.Text = Outlet;
        }
    }
}