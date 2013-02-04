using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class ReportsPanel : System.Web.UI.Page
    {
        CustomerManager CustomerManager = new CustomerManager();
        BrandManager BrandManager = new BrandManager();

        protected void Page_Init(object sender, EventArgs e)
        {
            dlBrandName.Items.Clear();
            dlBrandName.Items.Add(new ListItem("- SELECT -", ""));
            foreach (var brand in BrandManager.Brands())
            {
                dlBrandName.Items.Add(new ListItem(brand.BrandDescription, brand.BrandDescription));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            // VERSION 1.01 (s) CTS
            if (System.Configuration.ConfigurationManager.AppSettings["Integration"] == "YES")
            {
                if (Session.Count == 0)
                {
                    Response.Redirect("~/Accounting/Login.aspx");
                    return;
                }
            }
            // VERSION 1.01 (e) CTS
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {

            if (rblist.SelectedValue != null)
            {
                if (DateFrom.Text == string.Empty || DateTo.Text == string.Empty)
                {
                    lblError.Text = "DATE RANGE REQUIRED!!!";
                    pnlError.Visible = true;
                    return;
                }
                else
                {

                    if (rblist2.SelectedValue == "rptSummMonthlyInvPerBrand")
                    {

                        int Stat = 0;

                        if (dlCustomerType.SelectedValue == "PROVINCIAL")
                        {
                            Stat = 1;
                        }
                        else if (dlCustomerType.SelectedValue == "DEPT. STORE")
                        {
                            Stat = 2;
                        }
                        else if (dlCustomerType.SelectedValue == "BOUTIQUE")
                        {
                            Stat = 3;
                        }

                        pnlError.Visible = false;
                        Response.Redirect("~/Reports/ReportForms/SummaryOfMonthlyInventoryPerBrand.aspx?DateFrom=" +
                                                                                                                     DateFrom.Text +
                                                                                                        "&DateTo=" +
                                                                                                                     DateTo.Text +
                                                                                                        "&BrandName=" +
                                                                                                                     dlBrandName.SelectedValue +
                                                                                                        "&Stat=" +
                                                                                                                     Stat);
                    }
                    else
                    {
                        pnlError.Visible = false;
                        Response.Redirect("~/Reports/ReportForms/TransactionReport.aspx?dept=Accounting&custno=" + txtCustno.Text + "&datefrom=" + DateFrom.Text + "&dateto=" + DateTo.Text + "&rptnameCust=" + rblist.SelectedValue + "&rptNameSOI=" + rblist2.SelectedValue + "&customertype=" + dlCustomerType.SelectedValue + "&brand=" + dlBrandName.SelectedValue);
                    }
                }
            }
            else
            {
                pnlError.Visible = true;
                return;
            }

            if (rblist2.SelectedValue == "rptStockCard")
            {
                if (DateFrom.Text == string.Empty || DateTo.Text == string.Empty || txtCustno.Text == string.Empty)
                {
                    lblError.Text = "KINDLY COMPLETE PARAMETER!!!";
                    pnlError.Visible = true;
                    return;
                }
                else
                {
                    pnlError.Visible = false;
                    Response.Redirect("~/Reports/ReportForms/TransactionReport.aspx?dept=Accounting&custno=" + txtCustno.Text + "&datefrom=" + DateFrom.Text + "&dateto=" + DateTo.Text + "&rptnameCust=" + rblist.SelectedValue + "&rptNameSOI=" + rblist2.SelectedValue + "&customertype=" + dlCustomerType.SelectedValue + "&brand=" + dlBrandName.SelectedValue);
                }
            }
            else if (rblist2.SelectedValue == "rptConsoSummMonthlyInvPerBrand" || rblist2.SelectedValue == "rptBrandInvSumm")
            {
                if (DateFrom.Text == string.Empty || DateTo.Text == string.Empty)
                {
                    lblError.Text = "KINDLY COMPLETE PARAMETER!!!";
                    pnlError.Visible = true;
                    return;
                }
                else
                {
                    pnlError.Visible = false;
                    Response.Redirect("~/Reports/ReportForms/TransactionReport.aspx?dept=Accounting&custno=" + txtCustno.Text + "&datefrom=" + DateFrom.Text + "&dateto=" + DateTo.Text + "&rptnameCust=" + rblist.SelectedValue + "&rptNameSOI=" + rblist2.SelectedValue + "&customertype=" + dlCustomerType.SelectedValue + "&brand=" + dlBrandName.SelectedValue);
                }
            }
            else if (rblist2.SelectedValue == "rptStoreInvSumm" || rblist2.SelectedValue == "rptSummMonthlyInvPerBrand")
            {
                if (DateFrom.Text == string.Empty || DateTo.Text == string.Empty || dlCustomerType.SelectedValue == string.Empty || dlBrandName.SelectedValue == string.Empty)
                {
                    lblError.Text = "KINDLY COMPLETE PARAMETER!!!";
                    pnlError.Visible = true;
                    return;
                }
                else
                {


                    pnlError.Visible = false;
                    Response.Redirect("~/Reports/ReportForms/TransactionReport.aspx?dept=Accounting&custno=" + txtCustno.Text + "&datefrom=" + DateFrom.Text + "&dateto=" + DateTo.Text + "&rptnameCust=" + rblist.SelectedValue + "&rptNameSOI=" + rblist2.SelectedValue + "&customertype=" + dlCustomerType.SelectedValue + "&brand=" + dlBrandName.SelectedValue);

                }
            }
            else
            {
                pnlError.Visible = true;
                return;
            }

        }

        protected void rblist_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblist2.SelectedIndex = -1;
        }

        protected void rblist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rblist.SelectedIndex = -1;
        }

        protected void gvOutlets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanged(object sender, EventArgs e)
        {
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_Sorted(object sender, EventArgs e)
        {
            if (txtSearchOutlet.Text != string.Empty)
            {
                //if (HF_BRAND.Value != "ALL")
                //{
                CustomerManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                //}
                //else
                //{
                //    CustomerManager.SearchOutletDataSource(SqlDataSourceAllCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                //}
                gvOutlets.DataBind();
            }
            else
            {

            }
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void btnSelectOutlet_Click(object sender, EventArgs e)
        {
            txtCompName.Text = gvOutlets.SelectedRow.Cells[3].Text;
            txtCustno.Text = gvOutlets.SelectedRow.Cells[2].Text;
            Image image_outlet = new Image();
            image_outlet = (Image)gvOutlets.SelectedRow.FindControl("imgOutlet");
        }

        protected void imgBtnSearchOutlet_Click(object sender, ImageClickEventArgs e)
        {
            if (txtSearchOutlet.Text != string.Empty)
            {
                //if (HF_BRAND.Value != "ALL")
                //{
                CustomerManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                //}
                //else
                //{
                //    CustomerManager.SearchOutletDataSource(SqlDataSourceAllCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                //}
                gvOutlets.DataBind();
            }
            else
            {

            }
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void gvOutlets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (txtSearchOutlet.Text != string.Empty)
            {
                //if (HF_BRAND.Value != "ALL")
                //{
                CustomerManager.SearchOutletDataSource(SqlDataSourceCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                //}
                //else
                //{
                //    CustomerManager.SearchOutletDataSource(SqlDataSourceAllCustomers, txtSearchOutlet.Text, HF_BRAND.Value);
                //}
                gvOutlets.DataBind();
            }
            else
            {

            }
            btnBrowse_ModalPopupExtender.Show();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> window.open('~/Reports/ReportForms/WebForm1.aspx','_newtab','window','HEIGHT=600,WIDTH=820,top=50,left=50,toolbar=yes,scrollbars=yes,resizable=yes');</script>");

            //string url = "~/Reports/ReportForms/WebForm1.aspx";
            //ClientScript.RegisterStartUpScript(Page.GetType(), null, "window.open('page.html', '_newtab')", true);
        }

    }
}