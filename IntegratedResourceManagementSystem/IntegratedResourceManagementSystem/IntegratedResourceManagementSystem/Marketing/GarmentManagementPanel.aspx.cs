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
    public partial class GarmentManagementPanel : System.Web.UI.Page
    {
        GarmentManager GM = new GarmentManager();
        Garment garment = new Garment();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            LoadAllGarments();
        }

        private void LoadAllGarments(string[] search_paramenter= null)
        {
            if (search_paramenter != null)
            {
                gvGarmentList.DataSource = GM.SearchGarments(search_paramenter);
                gvGarmentList.DataBind();
            }
            else
            {
                gvGarmentList.DataSource = GM.Garments();
                gvGarmentList.DataBind();
            }
        }
        protected void btnSaveGarment_Click(object sender, EventArgs e)
        {
            var garment = new Garment{
                GarmentCode = txtGarmentCode.Text.ToUpper(),
                GarmentDescription = txtGarmentDescription.Text.ToUpper(),
                TopOrBottom = char.Parse(rdioTopOrBottom.SelectedValue),
                IsActive ="Yes",
                DateCreated = DateTimeOffset.Now
             };
            GM.Save(garment);
            txtGarmentCode.Text = null;
            txtGarmentDescription.Text = null;
            LoadAllGarments();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            garment = GM.GetGarmentByKey(long.Parse(gvGarmentList.SelectedRow.Cells[2].Text));
            garment.GarmentCode = txtGarmentCodeUpdate.Text.ToUpper();
            garment.GarmentDescription = txtGarmentDescriptionUpdate.Text.ToUpper();
            garment.TopOrBottom = char.Parse(rdioTopOrBottomUpdate.SelectedValue);
            GM.Save(garment);
            LoadAllGarments();
        }

        protected void gvGarmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            garment = GM.GetGarmentByKey(long.Parse(gvGarmentList.SelectedRow.Cells[2].Text));
            txtGarmentCodeUpdate.Text = garment.GarmentCode;
            txtGarmentDescriptionUpdate.Text = garment.GarmentDescription;
            if (garment.TopOrBottom == 'T')
            {
                rdioTopOrBottomUpdate.SelectedIndex = 0;
            }
            else
            {
                rdioTopOrBottomUpdate.SelectedIndex = 1;
            }
        }

        private void Search()
        {
            string[] search_param = new string[1];
            search_param[0] = txtSearch.Text;
            LoadAllGarments(search_param);
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            garment = GM.GetGarmentByKey(long.Parse(gvGarmentList.SelectedRow.Cells[2].Text));
            GM.Delete(garment);
            LoadAllGarments();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}