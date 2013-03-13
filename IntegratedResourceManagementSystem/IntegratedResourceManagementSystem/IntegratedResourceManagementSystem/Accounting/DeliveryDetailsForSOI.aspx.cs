using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.Entities;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class DeliveryDetailsForSOI : System.Web.UI.Page
    {
        #region variables
        CustomerManager CustInfoManager = new CustomerManager();
        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {
            Customer customer = CustInfoManager.GetCustomerByKey(long.Parse(Request.QueryString["CustomerNumber"]));
            txtDateFrom.Text = Request.QueryString["FromDate"];
            txtDateTo.Text = Request.QueryString["ToDate"];
            lblCustomer.Text = customer.CompanyName;
            lblBrand.Text = customer.Brand;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}