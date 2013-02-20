using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class CustomerType : System.Web.UI.UserControl
    {
        private string Type;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadCustomerType();
            }
        }

        public string GetTypeValue
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

        public string GetTypeDesc
        {

            get
            {
                return cboType.SelectedItem.Text;
            }
            set
            {
                Type = value;
            }

        }

        protected void LoadCustomerType()
        {
            try
            {
                InventoryGroupManager IGM = new InventoryGroupManager();
                cboType.DataSource = IGM.InventoryGroups();
                cboType.DataTextField = "GroupName";
                cboType.DataValueField = "InventoryGroupId";
                cboType.DataBind();

                cboType.Items.Insert(0, new ListItem("- SELECT -", "0"));
                cboType.SelectedIndex = 0;
            }
            catch
            {
                throw;
            }
        }

        public void SetDefault()
        {
            cboType.SelectedIndex = 0;
        }

        


    }
}