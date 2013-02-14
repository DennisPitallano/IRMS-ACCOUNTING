using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;
using System.Data.Linq;
using IRMS.Components;

namespace IntegratedResourceManagementSystem.Accounting
    {
    public partial class NewSalesInvoiceLiq : System.Web.UI.Page
        {
        public string custno;
        SalesInvoiceClass SI = new SalesInvoiceClass();
        SalesInvoiceManager SM = new SalesInvoiceManager();
        CustomerManager CM = new CustomerManager();
        protected void Page_Load(object sender, EventArgs e)
            {

            }

        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
            {
            custno = gvOutlets.Rows[gvOutlets.SelectedIndex].Cells[2].Text;
            btnAddSelected_ModalPopupExtender.Show();
            }

        protected void gvOutlets_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
            {
            btnAddSelected_ModalPopupExtender.Show();
            }

        protected void btnSelectOutlet_Click(object sender, EventArgs e)
            {
            if (gvOutlets.SelectedIndex != -1)
                {
                txtPreparedBy.Text = (string)Session["USER_NAME"];
                txtCustNo.Text = gvOutlets.SelectedRow.Cells[2].Text;
                txtSoldTo.Text = gvOutlets.SelectedRow.Cells[3].Text;
                txtAddress.Text = gvOutlets.SelectedRow.Cells[5].Text;
                txtTIN.Text = HttpUtility.HtmlDecode(gvOutlets.SelectedRow.Cells[6].Text.Trim());
                txtCompany.Text = gvOutlets.SelectedRow.Cells[7].Text;
                }
            
            }
        private void cLearal()
        {
        txtAddress.Text = "";
        txtCompany.Text = "";
        txtCustNo.Text = "";
        txtDate.Text = "";
        txtInvoiceNo.Text = "";
        txtPreparedBy.Text = "";
        txtSoldTo.Text = "";
        txtTIN.Text = "";
        txtTotalAmount.Text = "";
        }
        protected void btnCancelTransaction_Click(object sender, EventArgs e)
            {
            cLearal();
            }
        
        protected void btnOK_Click(object sender, EventArgs e)
            {
            if (txtDate.Text != string.Empty && txtDate.Text != string.Empty)
                {
                SI.cust_no = int.Parse(txtCustNo.Text);
                SI.sold_to = txtSoldTo.Text;
                SI.cust_addr = txtAddress.Text;
                SI.prep_by = txtPreparedBy.Text;
                SI.inv_amt = float.Parse(txtTotalAmount.Text);
                SI.si_no = txtInvoiceNo.Text;
                SI.si_date = DateTime.Parse(txtDate.Text);
                SI.company = txtCompany.Text;
                SI.yn_liquidation = 1;
                SI.tin = txtTIN.Text;
                SM.Save(SI);

                cLearal();

                }
            }
        
        protected void btnBack_Click(object sender, EventArgs e)
            {
            Redirector.Redirect("~/Accounting/SalesInvoice.aspx");
            }
        private void Required()
            {
                if (txtInvoiceNo.Text != string.Empty && txtDate.Text != string.Empty)
                {
                btnFinalizeTransaction.Enabled = true;    
                }
                
            }
        protected void txtInvoiceNo_TextChanged(object sender, EventArgs e)
            {
            Required();
            }

        protected void txtDate_TextChanged(object sender, EventArgs e)
            {
            Required();
            }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
            {
            CM.SearchCustomerDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text.Trim());
            gvOutlets.DataBind();
            btnAddSelected_ModalPopupExtender.Show();
            }

        protected void gvOutlets_PageIndexChanged(object sender, EventArgs e)
            {
            gvOutlets.SelectedIndex = -1;
            btnAddSelected_ModalPopupExtender.Show();
            }

        protected void gvOutlets_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
            gvOutlets.SelectedIndex = -1;
            btnAddSelected_ModalPopupExtender.Show();
            }
        }
    }