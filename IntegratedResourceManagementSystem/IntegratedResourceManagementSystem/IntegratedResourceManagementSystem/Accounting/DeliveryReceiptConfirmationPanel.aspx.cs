using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IRMS.Components;
using System.Web.Caching;
using System.Data.SqlClient;
using System.Text;
using IntegratedResourceManagementSystem.Common;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class DeliveryReceiptConfirmationPanel : System.Web.UI.Page
    {
        DeliveryReceiptDetailManager DRDetailManager = new DeliveryReceiptDetailManager();
        DeliveryReceiptManager DRManager = new DeliveryReceiptManager();
        BrandManager BManager = new BrandManager();
        ForwarderManager ForwarderManager = new ForwarderManager();

        protected void Page_Init( object sender, EventArgs e)
        {
            #region check roles
            Permission.PERMITTED_USER = (UsersClass)Session["USER_ACCOUNT"];

            Permission.ROLES = (List<UserRole>)Session["USER_ROLES"];
            StringBuilder strPermissionNotification = new StringBuilder();
            strPermissionNotification.Append("Your Account do not have: <br />");

            if (Permission.CanUpdate() == false)
            {
                this.btnConfirmedDR.Enabled = false;
                pnlNotification.Visible = true;
                strPermissionNotification.AppendLine(" - Permission to Update/Edit DR.<br />");
            }

            lblPermissionNotifications.Text = strPermissionNotification.ToString();
            #endregion
            lblSetDisplay.Text = "Set\nDisplay Size:";
            btnConfirmedDR.Text = "CONFIRM\nDR";
            txtConfirmationDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            LoadAllBrands();
            LoadAllForwarders();
            //HF_BRAND.Value = Session["USER_BRAND"].ToString();
            //if (HF_BRAND.Value == "ALL")
            //{
            //    gvDeliveryReceipts.DataSourceID = "SqlDataSourceDRAll";
                
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
               
                ClearSessionVariables();
               //CheckedCachedData();
            }
            
        }

        private void LoadAllBrands()
        {
            dlBrands.Items.Clear();
            dlConfirmedBrands.Items.Clear();
            dlBrands.Items.Add(new ListItem("ALL","ALL"));
            this.dlConfirmedBrands.Items.Add(new ListItem("ALL", "ALL"));
            foreach (Brand brand in BManager.Brands())
            {
                dlBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
                this.dlConfirmedBrands.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
            }

        }

        private void LoadAllForwarders()
        {
            dlForwarders.Items.Clear();
            foreach(Forwarder forwarder in ForwarderManager.Forwarders())
            {
                dlForwarders.Items.Add(new ListItem(forwarder.ForwarderName, forwarder.ForwarderName));
            }
        }

        protected void gvDeliveryReceipts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
                if (this.hfIsAdvanceSearch.Value=="YES")
                {
                    //if (HF_BRAND.Value != "ALL")
                    //{
                        DRManager.AdvanceSearch(SqlDataSourceDeliveryReceipt, txtSearchDR.Text, rdioFilterView.SelectedValue,
                                              DateTime.Parse(txtDateSeachFrom.Text), DateTime.Parse(txtDateSeachTo.Text), rdioSearchBy.SelectedValue, HF_BRAND.Value);
                    //}
                    //else
                    //{
                    //    DRManager.AdvanceSearch(SqlDataSourceDRAll, txtSearchDR.Text, rdioFilterView.SelectedValue,
                    //  DateTime.Parse(txtDateSeachFrom.Text), DateTime.Parse(txtDateSeachTo.Text), rdioSearchBy.SelectedValue, HF_BRAND.Value);
                    //}
                    gvDeliveryReceipts.DataBind();
                }
                else
                {
                    DRManager.SearchDeliveryReceiptList(SqlDataSourceDeliveryReceipt, txtSearchDR.Text, rdioFilterView.SelectedValue,rdioSearchBy.SelectedValue,HF_BRAND.Value);
                    gvDeliveryReceipts.DataBind();
                }
        }

        protected void gvDeliveryReceipts_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox ck = ((CheckBox)gvDeliveryReceipts.SelectedRow.FindControl("chkID"));
            Image imgDR = (Image)gvDeliveryReceipts.SelectedRow.FindControl("imgDetails");

            hpLinkPreviewDetails.NavigateUrl = "DeliveryDetailsPreview.aspx?DRID=" + gvDeliveryReceipts.SelectedValue.ToString() + "&DRNumber=" + gvDeliveryReceipts.SelectedRow.Cells[3].Text + "&PLNumber=" + HttpUtility.HtmlDecode(gvDeliveryReceipts.SelectedRow.Cells[10].Text) + "&DRDate=" + gvDeliveryReceipts.SelectedRow.Cells[4].Text + "&Customer=" + HttpUtility.HtmlDecode(gvDeliveryReceipts.SelectedRow.Cells[6].Text
                + "&WayBillNumber=" + gvDeliveryReceipts.SelectedDataKey[1].ToString() + "&Forwarder=" + gvDeliveryReceipts.SelectedDataKey[2].ToString()
                + "&ConfirmedDate=" + gvDeliveryReceipts.SelectedDataKey[3].ToString()+"&Status="+HttpUtility.HtmlDecode(rdioFilterView.SelectedValue));
        }
     
        protected void imgBtnSearchDR_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                hfIsAdvanceSearch.Value = "NO";
                DRManager.SearchDeliveryReceiptList(SqlDataSourceDeliveryReceipt, txtSearchDR.Text, rdioFilterView.SelectedValue, rdioSearchBy.SelectedValue, HF_BRAND.Value);
                gvDeliveryReceipts.DataBind();
            }
            catch (Exception)
            {
                //throw;
            }
        }


        protected void btnCancelSelectedDR_Click(object sender, EventArgs e)
        {
            btnCancelSelectedDR_ModalPopupExtender_Load(sender, e);
            this.btnPreviewSelectedDRForcancel_ModalPopupExtender.Show();
        }

        protected void chkEnableCompanySearch_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdvanceSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelSelectedDR_ModalPopupExtender_Load(object sender, EventArgs e)
        {
            List<DeliveryReceipt> list = GetSelectedDeliveryReceipts();
            this.gvPreviewSelectedDR.DataSource = list;
            this.gvPreviewSelectedDR.DataBind();
        }
        private List<DeliveryReceipt> GetSelectedDeliveryReceipts()
        {
            List<DeliveryReceipt> list = new List<DeliveryReceipt>();
            foreach (GridViewRow row in this.gvDeliveryReceipts.Rows)
            {
                CheckBox ck = ((CheckBox)row.FindControl("chkID"));
                Image imgDR = (Image)row.FindControl("imgDetails");
                if (ck.Checked)
                {
                    DeliveryReceipt dr = new DeliveryReceipt();
                    dr.RecordNo = int.Parse(imgDR.ToolTip);  
                    dr.PLNumber = row.Cells[10].Text ;
                    dr.DeliveredTo = row.Cells[6].Text;
                    dr.DRDate = DateTime.Parse(row.Cells[4].Text);
                    dr.DeliveryReceiptNumber = row.Cells[3].Text;
                    dr.Forwarder = imgDR.AlternateText.Split('-')[0];
                    dr.WayBillNumber = imgDR.AlternateText.Split('-')[1];
                    list.Add(dr);
                }
                else
                {
                    //Code if it is not checked ......may not be required
                }
            }
            return list;
        }

        private List<DeliveryReceipt> GetSelectedDeliveryReceiptsToBeCancelled()
        {
            List<DeliveryReceipt> list = new List<DeliveryReceipt>();
            foreach (GridViewRow row in this.gvPreviewSelectedDR.Rows)
            {
                CheckBox ck = ((CheckBox)row.FindControl("chkSelectedDRTCancelled"));

                if (ck.Checked)
                {
                    DeliveryReceipt dr = new DeliveryReceipt();
                    dr.RecordNo = int.Parse(ck.ToolTip);  // DRManager.GetDeliveryReceiptByKey(int.Parse(ck.ToolTip));
                    list.Add(dr);
                }
                else
                {
                    //Code if it is not checked ......may not be required
                }
            }
            return list;
        }

        protected void btnContinueDRConfirmation_Click(object sender, EventArgs e)
        {
            try
            {
                List<DeliveryReceipt> list = GetSelectedDeliveryReceiptsToBeCancelled();
                if (chkCustomForwarderWayBillNumber.Checked)
                {
                    DRManager.ConfirmDeliveryReceipts(list, txtWayBillNumber.Text, dlForwarders.SelectedValue, DateTime.Parse(txtConfirmationDate.Text));
                }
                else
                {
                    DRManager.ConfirmDeliveryReceipts(list, DateTime.Parse(txtConfirmationDate.Text));
                }

                foreach (var item in list)
                {
                     #region log
                    DRManager.Identity = (int)item.RecordNo;
                    DRManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.CONFIRMED);
                    #endregion log
                }
            }
            catch (Exception)
            {
                // throw;
            }
            lblSaved_ModalPopupExtender.Show();
        }

        protected void btnGgenerateReportByBrand_Click(object sender, EventArgs e)
        {
            ClearSessionVariables();
            if (dlBrands.SelectedValue == "ALL")
            {
                Session.Add("BRAND_NAME","");
                Session.Add("TRANSIT_STATUS","In Transit");
                Session.Add("OUTLET_NAME","");
                if (this.chkIntransitDRIncludeDateRange.Checked == true)
                {
                    Session.Add("INCLUDE_DATE_RANGE","TRUE");
                    if (this.txtInTransitDateRangeTo.Text != string.Empty || this.txtInTransitDateRangeFrom.Text != string.Empty)
                    {
                        Session.Add("DR_DATE_FROM",DateTime.Parse(txtInTransitDateRangeFrom.Text));
                        Session.Add("DR_DATE_TO",DateTime.Parse(txtInTransitDateRangeTo.Text));
                        Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");
                    }
                    else
                    {
                        Redirector.Redirect("~/Accounting/DeliveryReceiptConfirmationPanel.aspx");
                    }
                }
                else
                {
                    Session.Add("INCLUDE_DATE_RANGE","FALSE");
                    Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");
                }
            }
            else
            {
                Session.Add("BRAND_NAME",dlBrands.SelectedValue);
                Session.Add("TRANSIT_STATUS","In Transit");
                Session.Add("OUTLET_NAME","");
                if (this.chkIntransitDRIncludeDateRange.Checked == true)
                {
                    Session.Add("INCLUDE_DATE_RANGE","TRUE");
                    if (this.txtInTransitDateRangeTo.Text != string.Empty || this.txtInTransitDateRangeFrom.Text != string.Empty)
                    {
                        Session.Add("DR_DATE_FROM",DateTime.Parse(txtInTransitDateRangeFrom.Text));
                        Session.Add("DR_DATE_TO",DateTime.Parse(txtInTransitDateRangeTo.Text));
                        Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");
                    }
                    else
                    {
                        Redirector.Redirect("~/Accounting/DeliveryReceiptConfirmationPanel.aspx");
                    }
                }
                else
                {
                    Session.Add("INCLUDE_DATE_RANGE","FALSE");
                    Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");
                }
            }
        }

        protected void btnPrintByBrand_Click(object sender, EventArgs e)
        {
            ClearSessionVariables();
            if (dlConfirmedBrands.SelectedValue == "ALL")
            {
                Session.Add("BRAND_NAME","ALL");
                Session.Add("TRANSIT_STATUS","Confirmed");
                Session.Add("OUTLET_NAME","");
                if (chkConfirmedDREnableDateRange.Checked == true)
                {
                     Session.Add("INCLUDE_DATE_RANGE","TRUE");
                    if (txtConfirmedDateRangeTo.Text != string.Empty || txtConfirmedDateRangeFrom.Text != string.Empty)
                    {
                         Session.Add("DR_DATE_FROM",DateTime.Parse(txtConfirmedDateRangeFrom.Text));
                        Session.Add("DR_DATE_TO",DateTime.Parse(txtConfirmedDateRangeTo.Text));
                        Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");
                        
                    }
                    else
                    {
                        Redirector.Redirect("~/Accounting/DeliveryReceiptConfirmationPanel.aspx");
                    }
                }
                else
                {
                    Session.Add("INCLUDE_DATE_RANGE","FALSE");
                    Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");

                }
            }
            else
            {
                 Session.Add("BRAND_NAME",dlConfirmedBrands.SelectedValue);
                 Session.Add("TRANSIT_STATUS","Confirmed");
                 Session.Add("OUTLET_NAME","");
                if (chkConfirmedDREnableDateRange.Checked == true)
                {
                     Session.Add("INCLUDE_DATE_RANGE","TRUE");
                    if (txtConfirmedDateRangeTo.Text != string.Empty || txtConfirmedDateRangeFrom.Text != string.Empty)
                    {
                         Session.Add("DR_DATE_FROM",DateTime.Parse(txtConfirmedDateRangeFrom.Text));
                         Session.Add("DR_DATE_TO", DateTime.Parse(txtConfirmedDateRangeTo.Text));
                         Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");

                    }
                    else
                    {
                        Redirector.Redirect("~/Accounting/DeliveryReceiptConfirmationPanel.aspx");
                    }
                }
                else
                {
                    Session.Add("INCLUDE_DATE_RANGE","FALSE");
                    Redirector.Redirect("~/Reports/ReportForms/DeliveryReceiptConfirmationReport.aspx");

                }
            }
        }

        protected void txtDateSeachFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hfIsAdvanceSearch.Value = "YES";
                DRManager.AdvanceSearch(SqlDataSourceDeliveryReceipt, txtSearchDR.Text ,rdioFilterView.SelectedValue,DateTime.Parse(txtDateSeachFrom.Text),DateTime.Parse(txtDateSeachTo.Text),rdioSearchBy.SelectedValue,HF_BRAND.Value);
                gvDeliveryReceipts.DataBind();
            }
            catch (Exception)
            {
                //throw;
            }
            ibtnEnableDate_ModalPopupExtender.Show();
        }

        protected void txtDateSeachTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hfIsAdvanceSearch.Value = "YES";
                DRManager.AdvanceSearch(SqlDataSourceDeliveryReceipt, txtSearchDR.Text, rdioFilterView.SelectedValue, DateTime.Parse(txtDateSeachFrom.Text), DateTime.Parse(txtDateSeachTo.Text),rdioSearchBy.SelectedValue,HF_BRAND.Value);
                gvDeliveryReceipts.DataBind();
            }
            catch (Exception)
            {
                //throw;
            }
            ibtnEnableDate_ModalPopupExtender.Show();
        }

        protected void dlPageDisplaySize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDisplayPage(int.Parse(dlPageDisplaySize.SelectedValue));
        }

        private void SetDisplayPage(int DisplayPage)
        {
            gvDeliveryReceipts.PageSize = DisplayPage;
            gvDeliveryReceipts.DataBind();
        }

        protected void chkConfirmedDREnableDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConfirmedDREnableDateRange.Checked == true)
            {
                txtConfirmedDateRangeTo.Enabled  = true ;
                txtConfirmedDateRangeFrom.Enabled  = true ;
            }
            else
            {
                txtConfirmedDateRangeTo.Enabled  = false ;
                txtConfirmedDateRangeFrom.Enabled = false ;
            }
            btnPrint_ModalPopupExtender.Show();
        }

        protected void chkIntransitDRIncludeDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIntransitDRIncludeDateRange.Checked == true)
            {
                txtInTransitDateRangeFrom.Enabled = true;
                txtInTransitDateRangeTo.Enabled = true;
            }
            else
            {
                txtInTransitDateRangeFrom.Enabled = false ;
                txtInTransitDateRangeTo.Enabled = false;
            }
            btnPrint_ModalPopupExtender.Show();
        }

        protected void rdioLstPritnOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdioLstPritnOption.SelectedIndex == 0)
            {
                mvPrintOption.ActiveViewIndex = 1;
            }
            else
            {
                mvPrintOption.ActiveViewIndex = 0;
            }
            btnPrint_ModalPopupExtender.Show();
        }

        #region "session"
        public void ClearSessionVariables()
        {
            Session.Remove("BRAND_NAME");
            Session.Remove("TRANSIT_STATUS");
            Session.Remove("INCLUDE_DATE_RANGE");
            Session.Remove("OUTLET_NAME");
            Session.Remove("DR_DATE_FROM");
            Session.Remove("DR_DATE_TO");
        }
        #endregion

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                hfIsAdvanceSearch.Value = "YES";
                //if (HF_BRAND.Value != "ALL")
                //{
                    DRManager.AdvanceSearch(SqlDataSourceDeliveryReceipt, txtSearchDR.Text, rdioFilterView.SelectedValue, DateTime.Parse(txtDateSeachFrom.Text), DateTime.Parse(txtDateSeachTo.Text), rdioSearchBy.SelectedValue, HF_BRAND.Value);
                //}
                //else
                //{
                //    DRManager.AdvanceSearch(SqlDataSourceDRAll, txtSearchDR.Text, rdioFilterView.SelectedValue, DateTime.Parse(txtDateSeachFrom.Text), DateTime.Parse(txtDateSeachTo.Text), rdioSearchBy.SelectedValue, HF_BRAND.Value);
                //}
              
                gvDeliveryReceipts.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
            gvDeliveryReceipts.DataBind();
            ibtnEnableDate_ModalPopupExtender.Show();

        }

        protected void rdioFilterView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdioFilterView.SelectedIndex == 0)
            {
                btnConfirmedDR.Enabled = true;
            }
            else
            {
                btnConfirmedDR.Enabled = false;
            }
            //if (HF_BRAND.Value != "ALL")
            //{
            DRManager.FilterDeliveryReceiptList(SqlDataSourceDeliveryReceipt, (rdioFilterView.SelectedValue), HF_BRAND.Value);

            //}
            //else
            //{
            //    DRManager.FilterDeliveryReceiptList(SqlDataSourceDRAll, (rdioFilterView.SelectedValue), HF_BRAND.Value);

            //}
            gvDeliveryReceipts.DataBind();
        }

        protected void chkCustomForwarderWayBillNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomForwarderWayBillNumber.Checked)
            {
                pnlForwarderWayBill.Visible = true;
                chkCustomForwarderWayBillNumber.Text = "Uncheck to disable form.";
            }
            else
            {
                pnlForwarderWayBill.Visible = false;
                chkCustomForwarderWayBillNumber.Text = "Check to customize Forwarder & WayBill Number";
            }
            this.btnPreviewSelectedDRForcancel_ModalPopupExtender.Show();
        }
    }
}