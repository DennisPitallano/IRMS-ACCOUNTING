using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class MonthlySOIReportsPanel : System.Web.UI.Page
    {
        #region variables
        BrandManager BrandManager = new BrandManager();
        InventoryGroupManager invGroupManager = new InventoryGroupManager();
        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeBrands();
            InitInventoryGroups();
        }

        private void InitializeBrands()
        {
            DDLBrandsProvincial.Items.Clear();
            DDLBrandsProvincial.Items.Add(new ListItem("--select--", ""));
            var brands = BrandManager.Brands();
            foreach (Brand brand in brands)
            {
                DDLBrandsProvincial.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
            }
        }

        private void InitInventoryGroups()
        {
            DDLInventoryGroups.Items.Clear();
            DDLInventoryGroups.Items.Add(new ListItem("--select--", ""));
            foreach (var item in invGroupManager.InventoryGroups())
            {
                DDLInventoryGroups.Items.Add(new ListItem(item.GroupName, item.InventoryGroupId.ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DDLBrandsProvincial_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReportUrl();
        }

        private void GenerateReportUrl()
        {
            if (string.IsNullOrEmpty(txtDateFrom.Text))
            {
                hpLinkPrintProvincial.NavigateUrl = null;
                return;
            }
            if (string.IsNullOrEmpty(txtDateTo.Text))
            {
                hpLinkPrintProvincial.NavigateUrl = null;
                return;    
            }
          
            if (string.IsNullOrEmpty(DDLInventoryGroups.SelectedValue))
            {
                hpLinkPrintProvincial.NavigateUrl = null;
                return;
            }
            hpLinkPrintProvincial.NavigateUrl = "~/Reports/ReportForms/MonthlySummaryPilferageReport.aspx?DateFrom="
                + txtDateFrom.Text + "&DateTo=" + txtDateTo.Text + "&Brand="
                + DDLBrandsProvincial.SelectedValue + "&InventoryGroupName=" + DDLInventoryGroups.SelectedItem.Text
                 + "&InventoryGroupNumber=" + DDLInventoryGroups.SelectedValue + "&PerLocation=" + chkPerLocation.Checked+"&IsGroup="+chkEnableGroup.Checked;
        }

        protected void chkPerLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPerLocation.Checked)
            {
                this.DDLBrandsProvincial.Enabled = false;
                chkEnableGroup.Enabled = true;
            }
            else
            {
                DDLBrandsProvincial.Enabled = true;
                chkEnableGroup.Enabled = false;
            }
            GenerateReportUrl();
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            GenerateReportUrl();
        }

        protected void DDLInventoryGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReportUrl();
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            GenerateReportUrl();
        }

        protected void chkEnableGroup_CheckedChanged(object sender, EventArgs e)
        {
            GenerateReportUrl();
        }
    }
}