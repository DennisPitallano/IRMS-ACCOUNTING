using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class SOIGrossSalesPrintPreview : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            DataTable grossSales = (DataTable)Session["GROSS_SALES_BREAKDOWN"];
            gvGrossSales.DataSource = grossSales;
            gvGrossSales.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}