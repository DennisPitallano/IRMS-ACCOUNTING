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
    public partial class ColorManagementPanel : System.Web.UI.Page
    {
        ColorManager CM = new ColorManager();
        Color color = new Color();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllColors();
            }
        }

        private void LoadAllColors(string[] search_parameters=null)
        {
            if (search_parameters != null)
            {
                gvColorsList.DataSource = CM.SearchColors(search_parameters);
                gvColorsList.DataBind();
            }
            else
            {
                gvColorsList.DataSource = CM.Colors();
                gvColorsList.DataBind();
            }
        }

        protected void btnSaveColor_Click(object sender, EventArgs e)
        {
            var color = new Color
            {
                ColorCode = txtColorCode.Text.ToUpper(),
                ColorDescription = txtColorDescription.Text.ToUpper(),
                DateCreated = DateTimeOffset.Now,
                IsActive ="Yes"
            };
            CM.Save(color);
            txtColorCode.Text = null;
            txtColorDescription.Text = null;
            LoadAllColors();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            color = CM.GetColorByKey(long.Parse(gvColorsList.SelectedRow.Cells[2].Text));
            color.ColorCode = txtColorCodeUpdate.Text;
            color.ColorDescription = txtColorDescriptionUpdate.Text;
            CM.Save(color);
            LoadAllColors();
        }

        protected void gvColorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            color = CM.GetColorByKey(long.Parse(gvColorsList.SelectedRow.Cells[2].Text));
            txtColorCodeUpdate.Text = color.ColorCode;
            txtColorDescriptionUpdate.Text = color.ColorDescription;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            color = CM.GetColorByKey(long.Parse(gvColorsList.SelectedRow.Cells[2].Text));
            CM.Delete(color);
            LoadAllColors();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

       private void Search()
        {
            string[] search_param = new string[1];
            search_param[0] = txtSearch.Text;
            LoadAllColors(search_param);
        }
    }
}