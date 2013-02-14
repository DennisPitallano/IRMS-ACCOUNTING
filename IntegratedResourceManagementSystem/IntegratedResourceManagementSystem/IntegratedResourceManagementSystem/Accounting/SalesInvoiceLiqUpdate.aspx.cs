using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using IRMS.Components;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Accounting
    {
    public partial class SalesInvoiceLiqUpdate : System.Web.UI.Page
        {

        SalesInvoiceClass SIClass = new SalesInvoiceClass();
        SalesInvoiceManager SM =new SalesInvoiceManager();
        CustomerManager CM = new CustomerManager();
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!this.IsPostBack)
                {
                
                SIClass = (SalesInvoiceClass)Session["Sales_Invoice"];
                txtCustNo.Text = SIClass.cust_no.ToString();
                txtSoldTo.Text = SIClass.sold_to;
                txtAddress.Text = SIClass.cust_addr;
                txtPreparedBy.Text = SIClass.prep_by;
                txtAmount.Text = SIClass.inv_amt.ToString();
                txtInvoiceNo.Text = SIClass.si_no;
                txtDate.Text = SIClass.si_date.ToString("M/d/yyyy");
                txtTIN.Text = SIClass.tin;
                txtCompany.Text = SIClass.company;
                Session["id"] = SIClass.id;
                }
            }
        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
            {
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
            else
                {
                btnFinalizeTransaction.Enabled = false;
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

        protected void btnOK_Click(object sender, EventArgs e)
            {
            if (txtDate.Text != string.Empty && txtInvoiceNo.Text != string.Empty)
                {
                SIClass.id = (long)Session["id"];
                SIClass.cust_no = int.Parse(txtCustNo.Text);
                SIClass.sold_to = txtSoldTo.Text;
                SIClass.cust_addr = txtAddress.Text;
                SIClass.prep_by = txtPreparedBy.Text;
                SIClass.inv_amt = float.Parse(txtAmount.Text);
                SIClass.si_no = txtInvoiceNo.Text;
                SIClass.si_date = DateTime.Parse(txtDate.Text);
                SIClass.company = txtCompany.Text;
                SIClass.yn_liquidation = 1;
                SIClass.tin = txtTIN.Text;
                SM.Save(SIClass);

                Redirector.Redirect("~/Accounting/SalesInvoice.aspx");
                }
            }

        protected void imgBtnSearchCustomer_Click(object sender, ImageClickEventArgs e)
            {
            CM.SearchCustomerDataSource(SqlDataSourceCustomers, txtSearchCustomer.Text);
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