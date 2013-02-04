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

        private DateTime From;
        private DateTime To;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DateTime GetDateFrom
        {
            get
            {             
                return DateTime.Parse(txtDateFrom.Text);
            }
            set
            {
                From = value;
            }
        }

        public DateTime GetDateTo
        {
            get
            {
                return  DateTime.Parse(txtDateTo.Text);
            }
            set
            {
                To = value;
            }
        }
    }
}