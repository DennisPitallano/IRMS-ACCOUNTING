using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
    {
    public partial class PrintSILiquidation : System.Web.UI.Page
        {
        SalesInvoiceClass SIclass = new SalesInvoiceClass();
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!this.IsPostBack)
                {
                SIclass = (SalesInvoiceClass)Session["Sales_Invoice"];
                lblSI_No.InnerText = SIclass.si_no;
                lblCustomer.InnerText = SIclass.sold_to;
                lblAddress.InnerText = SIclass.cust_addr;
                lblDate.InnerText = SIclass.si_date.ToString("MM/dd/yyyy");
                lblTIN.InnerText = SIclass.tin;
                lblPrepared.InnerText = SIclass.prep_by;
                lblChecked.InnerText = (string)Session["USER_NAME"];
                lblAmount.InnerText = SIclass.inv_amt.ToString();
                }
            }
        }
    }