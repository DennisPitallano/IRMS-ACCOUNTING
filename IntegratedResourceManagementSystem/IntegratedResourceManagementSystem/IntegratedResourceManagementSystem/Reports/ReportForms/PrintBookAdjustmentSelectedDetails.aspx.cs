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
    public partial class PrintBookAdjustmentSelectedDetails : System.Web.UI.Page
    {
        BookAdjustmentMemoManager BAM = new BookAdjustmentMemoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PreviewSelectedTransaction();
        }
        private void PreviewSelectedTransaction()
        {
            long RecordNumber = long.Parse(Request.QueryString["ID"]);
            string Outlet = Request.QueryString["Outlet"];
            BookAdjustmentMemo adjustment_memo = BAM.GetBookAdjustmentMemoByKey(RecordNumber);
            lblPeriodFrom.Text = adjustment_memo.PeriodFrom.ToString("MMMM dd, yyyy");
            lblPeriodTo.Text = adjustment_memo.PeriodTo.ToString("MMMM dd, yyyy");
            lblReferenceNumber.Text = adjustment_memo.ReferenceNumber.ToString() ;
            lblDate.Text = adjustment_memo.MemoDate.ToString("MMMM dd, yyyy");
            lblOutlet.Text = Outlet;
            lblTransaction.Text = adjustment_memo.ParticularTransaction;
            lblQuantity.Text = adjustment_memo.Quantity.ToString();
            lblCurrentPrice.Text = adjustment_memo.CurrentPrice.ToString("###,###.00");
            lblCostPrice.Text = adjustment_memo.CostPrice.ToString("###,###.00");

        }
    }
}