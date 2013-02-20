using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class DateRange : System.Web.UI.UserControl
    {

        private string From;
        private string To;

      

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetDateFrom
        {           
            get
            {
                   
                return txtDateFrom.Text;    
            }
            set
            {
                From = value;
            }
      
        }
        public string GetDateTo
        {
            get
            {
                return txtDateTo.Text;
               
            }
            set
            {
                To = value;
            }
        }

        public void SetDefault()
        {
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
        }
    }
}