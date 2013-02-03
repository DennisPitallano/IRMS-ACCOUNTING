using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class DeliveryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitializeData();
            }
        }

        private void InitializeData()
        {
            lblCustomer.Text = Request.QueryString["Customer"];
            lblDRDate.Text = Request.QueryString["DRDateRange"];
            lblTotalQuantity.Text = Request.QueryString["TQTY"];
        }
        protected void gvDRList_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfDRDate.Value = gvDRList.SelectedDataKey[1].ToString();
            lblDRNumberDetails.Text = "DR DETAILS BY DR #: " + gvDRList.SelectedDataKey[0];
        }

        protected void btnReloadList_Click(object sender, EventArgs e)
        {

        }

    }
}