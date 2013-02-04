using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class BrandName : System.Web.UI.UserControl
    {

        private string Brands;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadBrand();
            }
        }

        public string GetBrand
        {
            get
            {
                return cboBrand.SelectedItem.Text;
            }
            set
            {
                Brands = value;
            }
        }

        protected void LoadBrand()
        {
            try
            {
                cboBrand.Items.Clear();
                cboBrand.Items.Add(new ListItem("- SELECT -", ""));
                BrandManager BM = new BrandManager();
                foreach(Brand item in BM.Brands())
                {
                    cboBrand.Items.Add(new ListItem(item.BrandDescription, item.BrandCode));
                }
               
            }
            catch
            {
                throw;
            }
        }

    }
}