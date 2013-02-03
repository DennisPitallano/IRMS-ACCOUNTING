using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Marketing
{
    public partial class FabricManagementPanel : System.Web.UI.Page
    {
        FabricManager FM = new FabricManager();
        Fabric fabric = new Fabric();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllFabrics();
            }
        }

        private void LoadAllFabrics(string[] search_parameter=null )
        {
            if (search_parameter != null)
            {
                gvFabricList.DataSource = FM.SearchFabrics(search_parameter);
                gvFabricList.DataBind();
            }
            else
            {
                gvFabricList.DataSource = FM.Fabrics();
                gvFabricList.DataBind();
            }
        }

        private void Search()
        {
            string[] search_parameter = new string[1];
            search_parameter[0] =txtSearch.Text;
            LoadAllFabrics(search_parameter);
        }

        protected void gvGarmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            fabric = FM.GetFabricByKey(long.Parse(gvFabricList.SelectedRow.Cells[2].Text));
            txtFabricCodeUpdate.Text = fabric.FabricCode;
            txtFabricDescriptionUpdate.Text = fabric.FabricDescription;
            if (fabric.TopOrBottom == 'T')
            {
                rdioTopOrBottomUpdate.SelectedIndex = 0;
            }
            else
            {
                rdioTopOrBottomUpdate.SelectedIndex = 1;
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            fabric = FM.GetFabricByKey(long.Parse(gvFabricList.SelectedRow.Cells[2].Text));
            FM.Delete(fabric);
            LoadAllFabrics();
        }

        protected void btnSaveFabric_Click(object sender, EventArgs e)
        {
            var fabric = new Fabric
            {
                FabricCode = txtFabricCode.Text.ToUpper(),
                FabricDescription = txtFabricDescription.Text.ToUpper(),
                TopOrBottom = char.Parse(rdioTopOrBottom.SelectedValue),
                DateCreated = DateTimeOffset.Now,
                IsActive = "Yes"
            };
            FM.Save(fabric);
            txtFabricCode.Text = null;
            txtFabricDescription.Text = null;
            LoadAllFabrics();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            fabric = FM.GetFabricByKey(long.Parse(gvFabricList.SelectedRow.Cells[2].Text));
            fabric.FabricCode = txtFabricCodeUpdate.Text.ToUpper();
            fabric.FabricDescription = txtFabricDescriptionUpdate.Text.ToUpper();
            fabric.TopOrBottom = char .Parse(rdioTopOrBottomUpdate.SelectedValue);
            FM.Save(fabric);
            LoadAllFabrics();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}