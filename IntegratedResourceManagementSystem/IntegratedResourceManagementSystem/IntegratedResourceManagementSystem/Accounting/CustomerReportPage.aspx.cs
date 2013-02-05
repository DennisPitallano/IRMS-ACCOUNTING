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
           
        }

        protected void rblist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmdView_Click(object sender, EventArgs e)
        {       
           CheckParameters();            
        }

        protected void CheckParameters()
        {

            DateTime From = new DateTime();
            DateTime To = new DateTime();
            int CustomerNumber = 0;

            if (rblist.SelectedValue == "rptCustSIDtl")
            {
                pnlError.Visible = false; 
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                CustomerNumber = Customer_Menu.GetCustomerNo;
                Session["CustomerNo"] = CustomerNumber;
                Session["From"] = From;
                Session["To"] = To;
                

                string url = "../Reports/ReportForms/CustomerInvoiceDetailedReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));          
            }

            else if (rblist.SelectedValue == "rptCustSIIten")
            {
                pnlError.Visible = false; 
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                CustomerNumber = Customer_Menu.GetCustomerNo;
                Session["CustomerNo"] = CustomerNumber;
                Session["From"] = From;
                Session["To"] = To;


                string url = "../Reports/ReportForms/CustomerInvoiceItineraryReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));          
            }
            else if (rblist.SelectedValue == "rptCustDRDtl")
            {
                pnlError.Visible = false; 
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                CustomerNumber = Customer_Menu.GetCustomerNo;
                Session["CustomerNo"] = CustomerNumber;
                Session["From"] = From;
                Session["To"] = To;


                string url = "../Reports/ReportForms/CustomerDeliveryDetailedReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));          
            }
            else if (rblist.SelectedValue == "rptCustDRIten")
            {
                pnlError.Visible = false; 
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                CustomerNumber = Customer_Menu.GetCustomerNo;
                Session["CustomerNo"] = CustomerNumber;
                Session["From"] = From;
                Session["To"] = To;

                string url = "../Reports/ReportForms/CustomerDeliveryItineraryReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));          
            }
            else if (rblist.SelectedValue == "rptCustCRSDtl")
            {
                pnlError.Visible = false; 
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                CustomerNumber = Customer_Menu.GetCustomerNo;
                Session["CustomerNo"] = CustomerNumber;
                Session["From"] = From;
                Session["To"] = To;

                string url = "../Reports/ReportForms/CustomerReturnDetailedReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));          

            }
            else if (rblist.SelectedValue == "rptCustCRSIten")
            {
                pnlError.Visible = false; 
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                CustomerNumber = Customer_Menu.GetCustomerNo;
                Session["CustomerNo"] = CustomerNumber;
                Session["From"] = From;
                Session["To"] = To;

                string url = "../Reports/ReportForms/CustomerReturnItineraryReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));

            }

            else
            {
                 pnlError.Visible = true; 
            }


        }
    }
}