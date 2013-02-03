using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Marketing
{
    public partial class SizeManagementPanel : System.Web.UI.Page
    {
        SizeManager SM = new SizeManager();
        Size size = new Size();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSizes();  
                txtSearch.Focus();
                LoadSizes();
            }
        }

        private void LoadSizes(string[] search_parameter= null)
        {
            if (search_parameter != null)
            {
                this.gvSizesList.DataSource = SM.SearchSizes(search_parameter);
                this.gvSizesList.DataBind();
            }
            else
            {
                this.gvSizesList.DataSource = SM.Sizes();
                this.gvSizesList.DataBind();
            }
        }

        protected void btnSaveSize_Click(object sender, EventArgs e)
        {
            size = new Size{
                SizeCode = txtSizeCode.Text.ToUpper(),
                SizeDescription = txtSizeDescription.Text.ToUpper(),
                DateCreated = DateTimeOffset.Now
            };
            SM.Save(size);
            txtSizeCode.Text = null;
            txtSizeDescription.Text = null;
            LoadSizes();
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            size = SM.GetSizeByKey(long.Parse(gvSizesList.SelectedRow.Cells[2].Text));
            size.SizeCode = txtSizeCodeUpdate.Text.ToUpper();
            size.SizeDescription = txtSizeDescriptionUpdate.Text.ToUpper();
            SM.Save(size);
            LoadSizes();
        }

        protected void gvSizesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = SM.GetSizeByKey(long.Parse(gvSizesList.SelectedRow.Cells[2].Text));
            txtSizeCodeUpdate.Text = size.SizeCode;
            txtSizeDescriptionUpdate.Text = size.SizeDescription;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            size = SM.GetSizeByKey(long.Parse(gvSizesList.SelectedRow.Cells[2].Text));
            SM.Delete(size);
            LoadSizes();
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            search();
        }

        private void search()
        {
            string[] parameter = new string[1];
            parameter[0] = txtSearch.Text;
            LoadSizes(parameter);
        }
    }
}