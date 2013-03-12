using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.WareHouse.controls
{
    public partial class CategoryMenu : System.Web.UI.UserControl
    {

        protected List<object> Rec = new List<object>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                RadioList.SelectedValue = "ALL";
            }
        }

        
        public string GetValue
        {
            get
            {
                return RadioList.SelectedValue;
            }
        }
    }
}