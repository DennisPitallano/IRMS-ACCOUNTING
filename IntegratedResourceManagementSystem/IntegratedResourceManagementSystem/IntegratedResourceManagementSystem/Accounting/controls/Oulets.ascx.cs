using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.Entities;
using IRMS.BusinessLogic.Manager;
namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class Oulets : System.Web.UI.UserControl
    {
        CustomerManager CustomerManager = new CustomerManager();

        //Customer CUSTOMER
        //{
        //    get
        //    {
        //        new  Customer {
        //             CustomerNumber = 0,
        //        }
        //    }
         
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllCustomers();
        }
        
        private void LoadAllCustomers()
        {
            gvOutlets.DataSource = CustomerManager.AllCustomers();
            gvOutlets.DataBind();
        }
    }
}