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
    public partial class PrintAdjustmentPCount : System.Web.UI.Page
    {
        AdjustmentMemoManager AdjusmentMemoManager = new AdjustmentMemoManager();
        private AdjustmentManager AdjustmentManager = new AdjustmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintPreview();
        }

        public void PrintPreview()
        {
            string AdjustmentCode = Request.QueryString["AdjustmentCode"];
            string Customer = Request.QueryString["Customer"];
            long record_number = long.Parse(Request.QueryString["Id"]);
            lblCompanyName.Text = "OUTLET NAME: "+Customer;
            lblDateNow.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            PreviewAdjustmentMemo(AdjustmentCode,record_number);
        }
        private void PreviewAdjustmentMemo(string adjustment_code, long record_number)
        {
            long debit_quantity = 0;
            long credit_quantity = 0;
            decimal debit_current_price = 0;
            decimal credit_current_price = 0;
            decimal debit_cost_price = 0;
            decimal credit_cost_price = 0;
            List<AdjustmentMemo> AdjustmentMemoDetailsCredit = new List<AdjustmentMemo>();
            List<AdjustmentMemo> AdjustmentMemoDetailsDebit = new List<AdjustmentMemo>();
            foreach (AdjustmentMemo adjmemo in AdjusmentMemoManager.AdjustmentMemosByAdjustmentCode(adjustment_code))
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
            gvCreditMemo.DataSource = AdjustmentMemoDetailsDebit;
            gvCreditMemo.DataBind();
            gvDebitMemo.DataSource = AdjustmentMemoDetailsCredit;
            gvDebitMemo.DataBind();
            Adjustment adjustment = AdjustmentManager.GetAdjustmentByKey(record_number);
            lblInventoryDate.Text = adjustment.InventoryDate.ToString("MMMM dd, yyyy");
            lblCutOff.Text = adjustment.CutOffDate.ToString("MMMM dd, yyyy");
            lblActualPhysicalCountQuantity.Text = adjustment.ActualPhysicalCountQuantity.ToString();
            lblActualPhysicalCountCurrentPrice.Text = adjustment.ActualPhysicalCountCurrentPrice.ToString("###,###.00");
            lblActualPhysicalCountCostPrice.Text = adjustment.ActualPhysicalCountCostPrice.ToString("###,###.00");
            lblTotalQuantity.Text = ((adjustment.ActualPhysicalCountQuantity + debit_quantity) - credit_quantity).ToString();
            lblTotalCurrentPrice.Text = ((adjustment.ActualPhysicalCountCurrentPrice + debit_current_price) - credit_current_price).ToString("###,###.00");
            lblTotalCostPrice.Text = ((adjustment.ActualPhysicalCountCostPrice + debit_cost_price) - credit_cost_price).ToString("###,###.00");
        }
    }
}