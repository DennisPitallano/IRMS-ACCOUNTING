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
        protected List<Brand> BrandList;
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

        public Brand SelectedBrand
        {
            get
            {
                return BrandList[cboBrand.SelectedIndex];
            }
             
        }

        protected void LoadBrand()
        {
            try
            {
                cboBrand.Items.Clear();
                cboBrand.Items.Add(new ListItem("- SELECT -", "0"));
                BrandManager BM = new BrandManager();
                foreach (Brand item in BM.Brands())
                {
                    cboBrand.Items.Add(new ListItem(item.BrandDescription, item.BrandCode));
                }
            }
            catch
            {
                throw;
            }
        }

        public void SetDefault()
        {
            cboBrand.SelectedIndex = 0;
        }

    }
}