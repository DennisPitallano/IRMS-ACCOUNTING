using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class Customers : System.Web.UI.UserControl
    {
        protected  string CustNo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadCustomer();
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
        }

        protected void btnSelectOutlet_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedRow == null)
            {
                cboBrowse_ModalPopupExtender.Show();
            }
            else
            {
                txtCustNo.Text =  "";
                txtCustNo.Text = GridView1.SelectedRow.Cells[2].Text;
                txtCustName.Text = "";
                txtCustName.Text = GridView1.SelectedRow.Cells[3].Text;
                GridView1.SelectedIndex = -1;
                LoadCustomer();
                txtSearchOutlet.Text = "";
            }
           
        }

        public string GetCustomerNo
        {
            get
            {

                return txtCustNo.Text;
            }
            set
            {
                CustNo = value;
            }
        }

        public void SetDefault()
        {
            GridView1.SelectedIndex = -1;
            txtCustName.Text = "";
            txtCustNo.Text = "";
            txtSearchOutlet.Text = "";
        }

        protected void LoadCustomer()
        {
            try
            {
                CustomerManager CM = new CustomerManager();
                GridView1.DataSource = CM.Customers();
                GridView1.DataBind();
            }
            catch
            {
                throw;
            }
        }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
        {
            GridView1.SelectedIndex = -1;
            cboBrowse_ModalPopupExtender.Show();
            CustomerManager CM = new CustomerManager();
            GridView1.DataSource = CM.FilterByCompanyName(txtSearchOutlet.Text);
            GridView1.DataBind();

            if (txtSearchOutlet.Text == "")
            {
                LoadCustomer();
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cboBrowse_ModalPopupExtender.Show();
            GridView1.SelectedIndex = -1;

            if (txtSearchOutlet.Text == string.Empty)
            {
                GridView1.PageIndex = e.NewPageIndex;
                LoadCustomer();
            }
            else
            {
                CustomerManager CM = new CustomerManager();
                GridView1.DataSource = CM.FilterByCompanyName(txtSearchOutlet.Text);
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
                 
            }

           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboBrowse_ModalPopupExtender.Show();
        }
    }
}