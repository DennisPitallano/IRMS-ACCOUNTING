using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class InventoryGroupPrintPreview : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            lblGroupName.Text = Request.QueryString["GroupName"];
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotal.Text = "TOTAL " + lblGroupName.Text +": "+ gvCustomers.Rows.Count.ToString();
        }
    }
}