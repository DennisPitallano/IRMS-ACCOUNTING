using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class StoreOuStandingInventoryReport : System.Web.UI.Page
    {
        StoreOutStandingInventoryManager SOIManager = new StoreOutStandingInventoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                hfRecordNumber.Value = PreviousPage.RECORD_NUMBER.ToString() ;
            }

            InitializeReport(long.Parse(hfRecordNumber.Value));
        }

        private void InitializeReport( long SOI_RECORD_NUMBER)
        {
            DataTable tblSOI = SOIManager.GetDataTableStoreOutStandingInventoryByRecordNumber(SOI_RECORD_NUMBER);

            ReportDocument rptDoc = new ReportDocuments.RptStoreOutStandingInventory();
            rptDoc.SetDataSource(tblSOI);
            this.crViewerSOI.ReportSource = rptDoc; 
        }
    }
}