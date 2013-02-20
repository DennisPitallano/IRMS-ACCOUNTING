using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IRMS.Components;

namespace IntegratedResourceManagementSystem.Accounting
    {
    
    public partial class SalesInvoice : System.Web.UI.Page
        {
        SalesInvoiceClass SIclass = new SalesInvoiceClass();
        SalesInvoiceManager SM = new SalesInvoiceManager();
        protected void Page_Load(object sender, EventArgs e)
            {
            hpLinkPrint.Enabled = false;
            }

        protected void btnUnposted_Click(object sender, EventArgs e)
            {
            SM.FilterSalesInvoice(SqlDataSourceSalesInvoice, "unposted");
            GridViewSalesInvoice.SelectedIndex = -1;
            divtittle.InnerText = "SALES INVOICE FOR LIQUIDATION - UNPOSTED RECORD(S)";
            }

        protected void btnPosted_Click(object sender, EventArgs e)
            {
            SM.FilterSalesInvoice(SqlDataSourceSalesInvoice, "posted");
            GridViewSalesInvoice.SelectedIndex = -1;
            divtittle.InnerText = "SALES INVOICE FOR LIQUIDATION - POSTED RECORD(S)";
            }

        protected void btnCancelled_Click(object sender, EventArgs e)
            {
            SM.FilterSalesInvoice(SqlDataSourceSalesInvoice, "cancelled");
            GridViewSalesInvoice.SelectedIndex = -1;
            divtittle.InnerText = "SALES INVOICE FOR LIQUIDATION - CANCELLED RECORD(S)";
            }

        protected void GridViewSalesInvoice_SelectedIndexChanged(object sender, EventArgs e)
            {

            Image imgSI = (Image)GridViewSalesInvoice.SelectedRow.FindControl("imgDetails");
                hpLinkPrint.Enabled = true;
                Session["Sales_Invoice"] = SM.GetSIById(long.Parse(imgSI.AlternateText));
               hpLinkPrint.NavigateUrl = "~/Reports/ReportForms/PrintSILiquidation.aspx";
            }

        protected void btnUpdateBookAdjustment_Click(object sender, EventArgs e)
            {
                if(GridViewSalesInvoice.SelectedIndex != -1)
                Redirector.Redirect("~/Accounting/SalesInvoiceLiqUpdate.aspx");
            }

        protected void btnOK_Click(object sender, EventArgs e)
            {
                SIclass = (SalesInvoiceClass)Session["Sales_Invoice"];
                SM.Delete(SIclass);
                GridViewSalesInvoice.DataBind();
            }

        protected void btnDelete_Click(object sender, EventArgs e)
            {
            if (GridViewSalesInvoice.SelectedIndex == -1)
                {
                divFinTrab.InnerText = "Warning!!";
                lblFinalize.InnerText = "No Sales Invoice has been selected..";
                btnOK.Visible = false;
                btnNo.Text = "OK";
                btnDelete_ModalPopupExtender.Show();
                }
            else
                {
                lblFinalize.InnerText = "Delete Sales Invoice : " + GridViewSalesInvoice.SelectedRow.Cells[2].Text;
                btnOK.Visible = true;
                btnNo.Text = "NO";
                btnDelete_ModalPopupExtender.Show();
                }
            
            }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
            {
            SM.SearchSalesInvoice(SqlDataSourceSalesInvoice, txtSearch.Text);
            }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
            {
            SM.SearchSalesInvoice(SqlDataSourceSalesInvoice, txtSearch.Text);
            }

        protected void GridViewSalesInvoice_PageIndexChanged(object sender, EventArgs e)
            {
            GridViewSalesInvoice.SelectedIndex = -1;
            hpLinkPrint.Enabled = false;
            }
        }
    }