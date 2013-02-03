using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class DeliveryDetailsPreview : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            lblDeliveredTo.Text = Request.QueryString["Customer"];
            lblDeliveryDate.Text = Request.QueryString["DRDate"];
            lblDRNumber.Text = Request.QueryString["DRNumber"];
            lblPLNumber.Text = Request.QueryString["PLNumber"];
            lblStatus.Text = Request.QueryString["Status"];

           
            lblForwarder.Text = Request.QueryString["Forwarder"];
            lblWayBillNumber.Text = Request.QueryString["WayBillNumber"];
            if (lblStatus.Text == "Confirmed")
            {
                pnlConfirmedDetails.Visible = true;
                lblConfirmationDate.Text = DateTime.Parse(Request.QueryString["ConfirmedDate"]).ToString("MMMM dd, yyyy");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdioDetailsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdioDetailsView.SelectedIndex == 1)
            {
                mvIew.SetActiveView(vDetails);
            }
            else 
            {
                mvIew.SetActiveView(vSummary);
            }
        }
    }
}