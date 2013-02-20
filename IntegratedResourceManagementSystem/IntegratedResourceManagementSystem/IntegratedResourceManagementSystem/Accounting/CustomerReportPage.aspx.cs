using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class CustomerReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Validation_Msg.Visible = false;
            }

        }

        protected void cmdView_Click(object sender, EventArgs e)
        {       
           CheckParameters();            
        }

        protected void CheckParameters()
        {

            DateTime From = new DateTime();
            DateTime To = new DateTime();
            string CustomerNumber = string.Empty;

            if(rblist.SelectedValue == "")
            {
                Validation_Msg.Visible = true;
                Validation_Msg.SetValue("REQUIRED TO SELECT CATEGORY!!!");
            }
            else if (rblist.SelectedValue == "rptCustSIDtl")
            {
               
                if (Date_Menu.GetDateFrom == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE FROM");
                }
                else if (Date_Menu.GetDateTo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE TO");
                    
                }
                else if (Customers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    CustomerNumber = Customers_Menu.GetCustomerNo;
                    Session["CustomerNo"] = CustomerNumber;
                    Session["From"] = From;
                    Session["To"] = To;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/CustomerInvoiceDetailedReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }

            else if (rblist.SelectedValue == "rptCustSIIten")
            {

                if (Date_Menu.GetDateFrom == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE FROM");
                }
                else if (Date_Menu.GetDateTo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE TO");

                }
                else if (Customers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {


                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    CustomerNumber = Customers_Menu.GetCustomerNo;
                    Session["CustomerNo"] = CustomerNumber;
                    Session["From"] = From;
                    Session["To"] = To;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/CustomerInvoiceItineraryReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }
            else if (rblist.SelectedValue == "rptCustDRDtl")
            {

                if (Date_Menu.GetDateFrom == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE FROM");
                }
                else if (Date_Menu.GetDateTo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE TO");

                }
                else if (Customers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    CustomerNumber = Customers_Menu.GetCustomerNo;
                    Session["CustomerNo"] = CustomerNumber;
                    Session["From"] = From;
                    Session["To"] = To;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/CustomerDeliveryDetailedReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }
            else if (rblist.SelectedValue == "rptCustDRIten")
            {
                if (Date_Menu.GetDateFrom == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE FROM");
                }
                else if (Date_Menu.GetDateTo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE TO");

                }
                else if (Customers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {
                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    CustomerNumber = Customers_Menu.GetCustomerNo;
                    Session["CustomerNo"] = CustomerNumber;
                    Session["From"] = From;
                    Session["To"] = To;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/CustomerDeliveryItineraryReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }
            else if (rblist.SelectedValue == "rptCustCRSDtl")
            {
                if (Date_Menu.GetDateFrom == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE FROM");
                }
                else if (Date_Menu.GetDateTo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE TO");
                    
                }
                else if (Customers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {
                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    CustomerNumber = Customers_Menu.GetCustomerNo;
                    Session["CustomerNo"] = CustomerNumber;
                    Session["From"] = From;
                    Session["To"] = To;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/CustomerReturnDetailedReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }
            else if (rblist.SelectedValue == "rptCustCRSIten")
            {
                if (Date_Menu.GetDateFrom == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE FROM");
                }
                else if (Date_Menu.GetDateTo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO DATE TO");

                }
                else if (Customers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {
                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    CustomerNumber = Customers_Menu.GetCustomerNo;
                    Session["CustomerNo"] = CustomerNumber;
                    Session["From"] = From;
                    Session["To"] = To;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/CustomerReturnItineraryReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }
            
        }

        protected void rblist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblist.SelectedValue != null)
            {
                Validation_Msg.Visible = false;
            }
            
        }
    }
}