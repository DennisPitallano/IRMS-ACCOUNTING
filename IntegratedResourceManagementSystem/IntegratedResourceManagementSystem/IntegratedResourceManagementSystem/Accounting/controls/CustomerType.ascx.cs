using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class CustomerType : System.Web.UI.UserControl
    {
        private string Type;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            { 
            
            }
        }

        public string GetType
        {

            get
            {
                return cboType.SelectedValue;
            }
            set
            {
                Type = value;
            }

        }

        


    }
}