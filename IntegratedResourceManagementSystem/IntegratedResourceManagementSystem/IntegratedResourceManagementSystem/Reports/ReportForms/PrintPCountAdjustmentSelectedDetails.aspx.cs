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
    public partial class PrintPCountAdjustmentSelectedDetails : System.Web.UI.Page
    {
        AdjustmentMemoManager AdjusmentMemoManager = new AdjustmentMemoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintPreview();
        }
        private void PrintPreview()
        {
            long RecordNumber = long.Parse(Request.QueryString["IdNumber"]);
            string CompanyName = Request.QueryString["Customer"];
          AdjustmentMemo memo_detail = AdjusmentMemoManager.GetAdjustmentMemoByKey(RecordNumber);

          lblCostPrice.Text = memo_detail.CostPrice.ToString("###,###.00");
          lblCurrentPrice.Text = memo_detail.CurrentPrice.ToString("###,###.00");
          lblDate.Text = memo_detail.MemoDate.ToString("MMMM dd, yyyy");
          lblPeriodFrom.Text = memo_detail.PeriodFrom.ToString("MMMM dd, yyyy");
          lblPeriodTo.Text = memo_detail.PeriodTo.ToString("MMMM dd, yyyy");
          lblQuantity.Text = memo_detail.Quantity.ToString();
          lblReferenceNumber.Text = memo_detail.ReferenceNumber.ToString();
          lblTransaction.Text = memo_detail.ParticularTransaction;
          lblOutlet.Text = CompanyName;
        }

    }
}