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
    public partial class CustomerReturnSlipConfirmationPanel : System.Web.UI.Page
    {
        DeliveryReceiptDetailManager DRDetailManager = new DeliveryReceiptDetailManager();
        DeliveryReceiptManager DRManager = new DeliveryReceiptManager();
        CustomerReturnSlipManager CRSManager = new CustomerReturnSlipManager();
        BrandManager BManager = new BrandManager();
        public string TRANSIT_STATUS { get; set; }
        public string INCLUDE_DATE_RANGE { get; set; }
        public string BRAND_NAME { get; set; }
        public DateTime DR_DATE_FROM { get; set; }
        public DateTime DR_DATE_TO { get; set; }

        ForwarderManager ForwarderManager = new ForwarderManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                txtConfirmationDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
                LoadAllBrands();
                LoadAllForwarders();
                btnPreviewDRDetails.Text = "PREVIEW \n DETAILS";
            }
        }

        private void LoadAllBrands()
        {
           // dlBrands.Items.Clear();
            dlConfirmedBrands.Items.Clear();
            foreach (Brand brand in BManager.Brands())
            {
            //    dlBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
                this.dlConfirmedBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
            }
        }
        private void LoadAllForwarders()
        {
            dlForwarders.Items.Clear();
            foreach (Forwarder forwarder in ForwarderManager.Forwarders())
            {
                dlForwarders.Items.Add(new ListItem(forwarder.ForwarderName, forwarder.ForwarderName));
            }
        }

        protected void gvDeliveryReceipts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            System.Threading.Thread.Sleep(100);

            if (txtDateSeachFrom.Text != string.Empty)
            {
                txtDateSeachFrom_TextChanged(sender, e);
            }
            else
            {
                if (txtSearchDR.Text != string.Empty)
                {
                    CRSManager.SearchCustomerReturnSlip(SqlDataSourceDeliveryReceipt, (rdioFilterView.SelectedValue), txtSearchDR.Text);
                    gvDeliveryReceipts.DataBind();
                }
                else
                {
                    CRSManager.FilterCustomerReturnSlip(SqlDataSourceDeliveryReceipt, (rdioFilterView.SelectedValue));
                    gvDeliveryReceipts.DataBind();
                }
            }
        }

        protected void gvDeliveryReceipts_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            CheckBox chkBox= ((CheckBox)gvDeliveryReceipts.SelectedRow.FindControl("chkID"));
            hfRcordNumber.Value = chkBox.ToolTip;
            txtDRNumberDetails.Text = gvDeliveryReceipts.SelectedRow.Cells[5].Text;
            txtDeliveryReceiptDate.Text = gvDeliveryReceipts.SelectedRow.Cells[6].Text;
            txtPLNumber.Text = HttpUtility.HtmlDecode(gvDeliveryReceipts.SelectedRow.Cells[10].Text);
            txtDeliverTo.Text = gvDeliveryReceipts.SelectedRow.Cells[7].Text;
            gvDRDetails.DataBind();
            lblTotalQuantity.Text = CountTotalDeliveryReceiptDetailsQuanntity().ToString();
            lblTotalAmount.Text = CountTotalDeliveryReceiptDetailsAmount().ToString("Php###,###.00");
        }
        private int CountTotalDeliveryReceiptDetailsQuanntity()
        {
            int count = 0;
            foreach (GridViewRow row in this.gvDRDetails.Rows)
            {
                count = count + int.Parse(row.Cells[3].Text);
            }
            return count;
        }

        private double CountTotalDeliveryReceiptDetailsAmount()
        {
            double amount = 0.0;
            foreach (GridViewRow row in this.gvDRDetails.Rows)
            {
                amount = amount + double.Parse(row.Cells[6].Text);
            }
            return amount;
        }
        protected void imgBtnSearchDR_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CRSManager.SearchCustomerReturnSlip(SqlDataSourceDeliveryReceipt, rdioFilterView.SelectedValue, txtSearchDR.Text);
                gvDeliveryReceipts.DataBind();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void rdioFilterView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdioFilterView.SelectedValue == "CONFIRMED")
            {
                btnConfirmedDR.Enabled = false;
            }else
            {
                btnConfirmedDR.Enabled = true;
            }
            System.Threading.Thread.Sleep(100);
            CRSManager.FilterCustomerReturnSlip(SqlDataSourceDeliveryReceipt, (rdioFilterView.SelectedValue));
            gvDeliveryReceipts.DataBind();
        }

        protected void btnCancelSelectedDR_Click(object sender, EventArgs e)
        {
            btnCancelSelectedDR_ModalPopupExtender_Load(sender, e);
            this.btnPreviewSelectedDRForcancel_ModalPopupExtender.Show();
        }

        
        protected void chkSeleckAll_CheckedChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            if (chkSeleckAll.Checked == true)
            {
                foreach (GridViewRow row in this.gvDeliveryReceipts.Rows)
                {
                    CheckBox ck = ((CheckBox)row.FindControl("chkID"));
                    ck.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow row in this.gvDeliveryReceipts.Rows)
                {
                    CheckBox ck = ((CheckBox)row.FindControl("chkID"));
                    ck.Checked = false;
                }
            }
        }
        protected void btnCancelSelectedDR_ModalPopupExtender_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            List<CustomerReturnSlip> list = GetSelectedCustomerReturnSlips();
            this.gvPreviewSelectedDR.DataSource = list;
            this.gvPreviewSelectedDR.DataBind();
        }
        private List<CustomerReturnSlip> GetSelectedCustomerReturnSlips()
        {
            List<CustomerReturnSlip> list = new List<CustomerReturnSlip>();
            foreach (GridViewRow row in this.gvDeliveryReceipts.Rows)
            {
                CheckBox ck = ((CheckBox)row.FindControl("chkID"));

                if (ck.Checked)
                {
                    CustomerReturnSlip crs = new CustomerReturnSlip();
                    crs.CustomerReturnSlipNumber = row.Cells[5].Text;
                    crs.CustomerReturnSlipDate = DateTime.Parse(row.Cells[6].Text);
                    crs.Customer = row.Cells[7].Text;
                    crs.PkgNo = row.Cells[10].Text;
                    crs.RecordNo = int.Parse(ck.ToolTip);
                    list.Add(crs);
                }
                else
                {
                    //Code if it is not checked ......may not be required
                }
            }
            return list;
        }

        private List<CustomerReturnSlipConfirmation> GetSelectedDeliveryReceiptsToBeCancelled()
        {
            List<CustomerReturnSlipConfirmation> list = new List<CustomerReturnSlipConfirmation>();
            foreach (GridViewRow row in this.gvPreviewSelectedDR.Rows)
            {
                CheckBox ck = ((CheckBox)row.FindControl("chkSelectedDRTCancelled"));

                if (ck.Checked)
                {
                    CustomerReturnSlipConfirmation crs = new CustomerReturnSlipConfirmation();
                    crs.CRSNumber = row.Cells[0].Text;
                    crs.DateTransfer = DateTime.Parse(txtConfirmationDate.Text);
                    crs.Destination = txtDestination.Text;
                    crs.Forwarder = dlForwarders.SelectedValue;
                    list.Add(crs);
                }
                else
                {
                    //Code if it is not checked ......may not be required
                }
            }
            return list;
        }
        protected void btnYesCancelSelectedDR_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);
                List<CustomerReturnSlipConfirmation> list = GetSelectedDeliveryReceiptsToBeCancelled();
               // DRManager.UpdateDeliveryRecieptCancelledStatus(list);
            }
            catch (Exception)
            {
                // throw;
            }
        }

        protected void btnContinueDRConfirmation_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(100);
                List<CustomerReturnSlipConfirmation> list = GetSelectedDeliveryReceiptsToBeCancelled();
                CRSManager.ConfirmCustomerReturnSlip(list);
                rdioFilterView_SelectedIndexChanged(sender, e);
            }
            catch (Exception)
            {
                // throw;
            }
        }

        protected void txtDateSeachFrom_TextChanged(object sender, EventArgs e)
        {
            CRSManager.SearchCustomerReturnSlipWithDateRange(SqlDataSourceDeliveryReceipt, rdioFilterView.SelectedValue, txtSearchDR.Text, DateTime.Parse(this.txtDateSeachFrom.Text), DateTime.Parse(this.txtDateSeachTo.Text));
            gvDeliveryReceipts.DataBind();
            ibtnEnableDate_ModalPopupExtender.Show();
        }

        protected void txtDateSeachTo_TextChanged(object sender, EventArgs e)
        {
            CRSManager.SearchCustomerReturnSlipWithDateRange(SqlDataSourceDeliveryReceipt, rdioFilterView.SelectedValue, txtSearchDR.Text, DateTime.Parse(this.txtDateSeachFrom.Text), DateTime.Parse(this.txtDateSeachTo.Text));
            gvDeliveryReceipts.DataBind();
            ibtnEnableDate_ModalPopupExtender.Show();
        }

        protected void gvDeliveryReceipts_Sorting(object sender, GridViewSortEventArgs e)
        {
            System.Threading.Thread.Sleep(500);

            if (txtDateSeachFrom.Text != string.Empty)
            {
                txtDateSeachFrom_TextChanged(sender, e);
            }
            else
            {
                if (txtSearchDR.Text != string.Empty)
                {
                    CRSManager.SearchCustomerReturnSlip(SqlDataSourceDeliveryReceipt, (rdioFilterView.SelectedValue), txtSearchDR.Text);
                    gvDeliveryReceipts.DataBind();
                }
                else
                {
                    CRSManager.FilterCustomerReturnSlip(SqlDataSourceDeliveryReceipt, (rdioFilterView.SelectedValue));
                    gvDeliveryReceipts.DataBind();
                }
            }
        }

        protected void btnGenerateDetailedReportPerCustomer_Click(object sender, EventArgs e)
        {
            string ResponseURL = string.Empty;
            ResponseURL = "~/Reports/ReportForms/DetailedReportPerOutlet.aspx?";
            ResponseURL += "CustomerNumber=" + dlOutletDetailed.SelectedValue ;
            ResponseURL += "&DateFrom="+ txtPullOutDetailedPerOutletDateFrom.Text;
            ResponseURL += "&DateTo=" + txtPullOutDetailedPerOutletDateTo.Text;
            Redirector.Redirect(ResponseURL);
        }

        protected void btnPrintByBrand_Click(object sender, EventArgs e)
        {
            string ResponseURL = string.Empty;
            ResponseURL = "~/Reports/ReportForms/MonthlyPullOutSummaryPerBrandReport.aspx?";
            ResponseURL += "Brand=" + dlConfirmedBrands.SelectedValue;
            ResponseURL += "&DateFrom=" + txtConfirmedDateRangeFrom.Text;
            ResponseURL += "&DateTo=" + txtConfirmedDateRangeTo.Text;
            ResponseURL += "&CustomerType="+ rdioListCustomerType.SelectedValue;
            Redirector.Redirect(ResponseURL);
        }

        protected void btnGenerateMonthlyPullOutSummaryPerCustomer_Click(object sender, EventArgs e)
        {
            string ResponseURL = string.Empty;
            ResponseURL = "~/Reports/ReportForms/MonthlyPullOutSummaryPerCustomer.aspx?";
            ResponseURL += "CustomerNumber=" + dlCustomerSummary.SelectedValue;
            ResponseURL += "&DateFrom=" + txtDateRangeFromSummaryPerCustomer.Text;
            ResponseURL += "&DateTo=" + txtDateRangeToSummaryPerCustomer.Text;
            Redirector.Redirect(ResponseURL);
        }

        protected void btnPrintConsolidated_Click(object sender, EventArgs e)
        {
            string ResponseURL = string.Empty;
            ResponseURL = "~/Reports/ReportForms/MonthlyConsolidatedReport.aspx?";
            ResponseURL += "&DateFrom=" + txtConsolidatedDateFrom.Text;
            ResponseURL += "&DateTo=" + txtConsolidatedDateTo.Text;
            Redirector.Redirect(ResponseURL);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

        }
    }
}