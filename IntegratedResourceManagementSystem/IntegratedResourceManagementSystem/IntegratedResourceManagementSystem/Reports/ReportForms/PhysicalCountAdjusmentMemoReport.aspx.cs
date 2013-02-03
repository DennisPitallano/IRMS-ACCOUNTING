using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IRMS.BusinessLogic.Manager;
using CrystalDecisions.CrystalReports.Engine;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class PhysicalCountAdjusmentMemoReport : System.Web.UI.Page
    {
        AdjustmentMemoManager AdjustmentMemoManager = new AdjustmentMemoManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeReportPreview();
        }
        private void InitializeReportPreview()
        {
            DataTable adjustment_memo = new DataTable();
            adjustment_memo =AdjustmentMemoManager.GetAllPhysicalCountAdjustmentMemos();
           // adjustment_memo.WriteXmlSchema("D:\\physical_count_adjustment_memo.xsd");
           ReportDocument rptDoc = new ReportDocuments.rptPhysicalCountAdjustmentMemo ();
           rptDoc.SetDataSource(adjustment_memo);
            this.crViewerAdjustmentMemo.ReportSource = rptDoc;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}