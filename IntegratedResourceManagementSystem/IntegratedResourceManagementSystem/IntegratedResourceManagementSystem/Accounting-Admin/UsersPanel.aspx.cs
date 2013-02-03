using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting_Admin
{
    public partial class UsersPanel : System.Web.UI.Page
    {
        UserBrandManager UBM = new UserBrandManager();
        UserBrand UB = new UserBrand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                btnAssignBrand.Text = "ASSIGN BRAND";
            }
        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userId = 0;
            userId = int.Parse(gvUsers.SelectedRow.Cells[1].Text);
             UB = UBM.GetUserBrandByUserId(userId);
            if (UB != null)
            {
                lblAssignedbrand.Text = "CURENT BRAND: "+UB.BrandName;
                checkReAssignBrand.Visible = true;
                ddListBrands.Enabled = false;
                checkAll.Enabled = false;
                hfUserBrandId.Value = UB.RecordNumber.ToString();
            }
            else
            {
                lblAssignedbrand.Text = "NO ASSIGN BRAND";
                checkReAssignBrand.Visible = false;
                ddListBrands.Enabled = true;
                checkAll.Enabled = true;
                hfUserBrandId.Value ="0";
            }
           
           lblUser.Text ="User Name: "+ gvUsers.SelectedRow.Cells[2].Text;
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            UserBrand UserBrand = new UserBrand();
            if (hfUserBrandId.Value != "0")
            {
                UserBrand.RecordNumber = int.Parse(hfUserBrandId.Value);
            }
            if (checkAll.Checked == true)
            {
                UserBrand.BrandName = "ALL";
            }
            else
            {
                UserBrand.BrandName = ddListBrands.SelectedValue;
            }
            UserBrand.UserId = int.Parse(gvUsers.SelectedRow.Cells[1].Text);
            UserBrand.DateRecorded = DateTime.UtcNow;
            UBM.Save(UserBrand);
            lblSuccessSaved_ModalPopupExtender.Show();
        }

        protected void checkReAssignBrand_CheckedChanged(object sender, EventArgs e)
        {
            if (checkReAssignBrand.Checked == true)
            {
                ddListBrands.Enabled = true;
                checkAll.Enabled = true;
            }
            else
            {
                ddListBrands.Enabled = false;
                checkAll.Enabled = false;
            }
            btnAssignBrand_ModalPopupExtender.Show();
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            UBM.SearchUsers(SqlDataSourceUsers, txtSearch.Text);
            gvUsers.DataBind();
        }
    }
}