using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.Components;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class CustomerGroupReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Brands();
                CustomerGroup();

                RadioPosted.SelectedIndex = 0;
                lstCategory.SelectedIndex = 0;
            }
        }

        protected void Brands()
        {
            BrandManager BM = new BrandManager();

            foreach (Brand item in BM.Brands())
            { 
                cboBrand.Items.Add(new ListItem(item.BrandDescription,item.BrandCode));
            }
            cboBrand.Items.Insert(0, new ListItem("- SELECT -"));
            cboBrand.SelectedIndex = 0;


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (LstRadio.SelectedValue == "")
                {
                    pnlError.Visible = true;               
                    return;
                }
                else
                {
                    pnlError.Visible = false;
                    if (LstRadio.SelectedValue == "cgrpc")
                    {
                        if (txtDateF.Text == string.Empty)
                        {
                            lblError.Text = "DATE REQUIRED!!!";
                            pnlError.Visible = true;
                            txtDateF.Focus();
                            return;
                        }
                        else if (txtDateT.Text == string.Empty)
                        {
                            lblError.Text = "DATE REQUIRED!!!";
                            pnlError.Visible = true;
                            txtDateT.Focus();
                            return;
                        }
                        else if (RadioPosted.SelectedValue == "")
                        {
                            lblError.Text = "POST REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else if (cboCustomer.SelectedIndex == 0)
                        {
                            lblError.Text = "CUSTOMER REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else if (lstCategory.SelectedValue == "")
                        {
                            lblError.Text = "CATEGORY REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else
                        {
                            CheckParaMeterValues();
                            string url = "../Reports/ReportForms/CustomerGroupPerCustomer.aspx";
                            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                        }
                    }
                    else if (LstRadio.SelectedValue == "cgrpb")
                    {

                        if (txtDateF.Text == string.Empty)
                        {
                            lblError.Text = "DATE REQUIRED!!!";
                            pnlError.Visible = true;
                            txtDateF.Focus();
                            return;
                        }
                        else if (txtDateT.Text == string.Empty)
                        {
                            lblError.Text = "DATE REQUIRED!!!";
                            pnlError.Visible = true;
                            txtDateT.Focus();
                            return;
                        }
                        else if (RadioPosted.SelectedValue == "")
                        {
                            lblError.Text = "POST REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else if (cboBrand.SelectedIndex == 0)
                        {
                            lblError.Text = "BRAND NAME REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else if (lstCategory.SelectedValue == "")
                        {
                            lblError.Text = "CATEGORY REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else
                        {
                            CheckParaMeterValues();
                            string url = "../Reports/ReportForms/CustomerGroupPerBrand.aspx";
                            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                        }
                    }
                    else if (LstRadio.SelectedValue == "cgor")
                    {

                        if (txtDateF.Text == string.Empty)
                        {
                            lblError.Text = "DATE REQUIRED!!!";
                            pnlError.Visible = true;
                            txtDateF.Focus();
                            return;
                        }
                        else if (txtDateT.Text == string.Empty)
                        {
                            lblError.Text = "DATE REQUIRED!!!";
                            pnlError.Visible = true;
                            txtDateT.Focus();
                            return;
                        }
                        else if (RadioPosted.SelectedValue == "")
                        {
                            lblError.Text = "POST REQUIRED!!!";
                            pnlError.Visible = true;
                            return;
                        }
                        else
                        {

                            CheckParaMeterValues();
                            string url = "../Reports/ReportForms/CustomerGroupOverall.aspx";
                            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
   
        
                        }
                    }

                   
                }
            }
            catch
            {
               // throw;
            }


        }
   
        protected void CheckParaMeterValues()
        {

            DateTime DateFrom = new DateTime();
            DateTime DateTo = new DateTime();
            string Post;
            string BrandName;
            string UserName = Session["USER_ID"].ToString();
            string Customer;
            int Category;
            try
            {


                if (LstRadio.SelectedValue == "cgrpb")
                {

                        DateFrom = Convert.ToDateTime(txtDateF.Text);
                        DateTo = Convert.ToDateTime(txtDateT.Text);
                        Post = RadioPosted.SelectedValue;
                        BrandName = cboBrand.SelectedItem.Text;
                        Category = int.Parse(lstCategory.SelectedValue);

                        pnlError.Visible = false;
                        Session["UserName"] = UserName;
                        Session["Post"] = Post;
                        Session["Category"] = Category;
                        StoredProcedureManager SPM = new StoredProcedureManager();

                        if (ckPrev.Checked == false)
                        {
                            Session["Status"] = 0;
                            SPM.ExecuteGenCustGroupBrand(UserName, DateFrom, DateTo, BrandName, Post, Category);
                        }
                        else
                        {
                            Session["Status"] = 1;
                            SPM.ExecuteGenCustGroupBrandWithPrev(UserName, DateFrom, DateTo, BrandName, Post, Category);
                        }

                      
                       
                        

                }
                else if(LstRadio.SelectedValue == "cgor")
                {


                    DateFrom = Convert.ToDateTime(txtDateF.Text);
                    DateTo = Convert.ToDateTime(txtDateT.Text);
                    Post = RadioPosted.SelectedValue;
                    Category = int.Parse(lstCategory.SelectedValue);

                    pnlError.Visible = false;
                    Session["UserName"] = UserName;
                    Session["Post"] = Post;
                    Session["Category"] = Category;
                    

                    StoredProcedureManager SPM = new StoredProcedureManager();

                    if (ckPrev.Checked == false)
                    {
                        Session["Status"] = 0;
                        SPM.ExecuteGenCustGroupOverAll(UserName, DateFrom, DateTo, Post, Category);
                    }
                    else
                    {
                        Session["Status"] = 1;
                        SPM.ExecuteGenCustGroupOverAllWithPrev(UserName, DateFrom, DateTo, Post, Category);
                    }

                    
                   

                }
                else if (LstRadio.SelectedValue == "cgrpc")
                {
                    DateFrom = Convert.ToDateTime(txtDateF.Text);
                    DateTo = Convert.ToDateTime(txtDateT.Text);
                    Post = RadioPosted.SelectedValue;
                    Customer = cboCustomer.SelectedItem.Text;
                    Category = int.Parse(lstCategory.SelectedValue);

                    pnlError.Visible = false;
                    Session["UserName"] = UserName;
                    Session["Post"] = Post;
                    Session["Category"] = Category; 
                    StoredProcedureManager SPM = new StoredProcedureManager();

                    if (ckPrev.Checked == false)
                    {
                        Session["Status"] = 0;
                        SPM.ExecuteGenCustGroupCustomer(UserName, DateFrom, DateTo, Customer, Post, Category);
                    }
                    else
                    {
                        Session["Status"] = 1;
                        SPM.ExecuteGenCustGroupCustomerWithPrev(UserName, DateFrom, DateTo, Customer, Post, Category);
                    }

                }

            }
            catch
            {
               // throw;
            }
        }

        protected void LstRadio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LstRadio.SelectedValue == "cgor")
            {
                lblPost.Visible = true;
                RadioPosted.Visible = true;
                lblBrand.Visible = false;
                cboBrand.Visible = false;
                lblCustomer.Visible = false;
                cboCustomer.Visible = false;
                
            }
            else if (LstRadio.SelectedValue == "cgrpb")
            {
                lblPost.Visible = true;
                RadioPosted.Visible = true;
                lblBrand.Visible = true;
                cboBrand.Visible = true;
                lblCustomer.Visible = false;
                cboCustomer.Visible = false;
            }
            else if (LstRadio.SelectedValue == "cgrpc")
            {
                lblPost.Visible = true;
                RadioPosted.Visible = true;

                lblCustomer.Visible = true;
                cboCustomer.Visible = true;
                
                lblBrand.Visible = false;
                cboBrand.Visible = false;
            }
        }

        protected void CustomerGroup()
        {
            try
            {

                CustomerGroupManager CGM = new CustomerGroupManager();
                cboCustomer.DataSource = CGM.GetCustomerGroupOrderByCustomer();
                cboCustomer.DataTextField = "Customer";
                cboCustomer.DataValueField = "Customer";
                cboCustomer.DataBind();

                cboCustomer.Items.Insert(0, new ListItem("- SELECT -", "0"));
                cboCustomer.SelectedIndex = 0;
            }
            catch
            {
                throw;
            }
        }
    }
}