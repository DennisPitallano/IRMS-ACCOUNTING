using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class SoiReportPage : System.Web.UI.Page
    {
        public UsersClass USER { get { return (UsersClass)Session["USER_ACCOUNT"]; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckParameters()
        {
            DateTime From = new DateTime();
            DateTime To = new DateTime();
            string BrandName = string.Empty;
            string CustomerDesc = string.Empty;
            string CustomerVal = string.Empty;
            string CustomerNumber = string.Empty;
            string Users;
            string Status = string.Empty;

            if (rblist1.SelectedValue == "rptStoreInvSumm")
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
                    else if (Brand_Menu.GetBrand == "- SELECT -")
                    {
                        Validation_Msg.Visible = true;
                        Validation_Msg.SetValue("REQUIRED TO SELECT BRAND NAME");
                    }
                    else if (CutomerType_Menu.GetTypeValue == "0")
                    {
                        Validation_Msg.Visible = true;
                        Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER TYPE");
                    }
                    else
                    {

                        From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                        To = Convert.ToDateTime(Date_Menu.GetDateTo);
                        BrandName = Brand_Menu.GetBrand;
                        CustomerDesc = CutomerType_Menu.GetTypeDesc;
                        CustomerVal = CutomerType_Menu.GetTypeValue;
                        Users = USER.FullName;


                        Session["From"] = From.ToString("yyyy-MM-dd");
                        Session["To"] = To.ToString("yyyy-MM-dd");
                        Session["BrandName"] = BrandName;
                        Session["CustomerDesc"] = CustomerDesc;
                        Session["CustomerVal"] = CustomerVal;

                        Validation_Msg.Visible = false;
                        string url = "../Reports/ReportForms/SummaryStoreInventoryReport.aspx";
                        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                    }
                    
                   
            }
            else if (rblist1.SelectedValue == "rptBrandInvSumm")
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
                else
                {


                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    Users = USER.FullName;

                    Session["From"] = From.ToString("yyyy-MM-dd");
                    Session["To"] = To.ToString("yyyy-MM-dd");
                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/SummaryBrandInventoryReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }

            else if (rblist1.SelectedValue == "rptStockCard")
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
                else if (Cutomers_Menu.GetCustomerNo == "")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }
                else
                {

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    Users = USER.FullName;
                    CustomerNumber = Cutomers_Menu.GetCustomerNo;

                    Session["From"] = From;
                    Session["To"] = To;
                    Session["CustomerNo"] = CustomerNumber;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/SummaryStockCardMonthly.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }

            }

            else if (rblist1.SelectedValue == "rptStockCardQrt")
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
                else if (Cutomers_Menu.GetCustomerNo == null)
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER");
                }

                else
                {

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    Users = USER.FullName;
                    CustomerNumber = Cutomers_Menu.GetCustomerNo;

                    Session["From"] = From;
                    Session["To"] = To;
                    Session["CustomerNo"] = CustomerNumber;

                    Validation_Msg.Visible = false;
                    string url = "../Reports/ReportForms/SummaryStockCardQuarterly.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }

            }

            else if (rblist1.SelectedValue == "rptSummMonthlyInvPerBrand")
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
                else if (CutomerType_Menu.GetTypeValue == "0")
                {
                    Validation_Msg.Visible = true;
                    Validation_Msg.SetValue("REQUIRED TO SELECT CUSTOMER TYPE");
                }
                else
                {

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    BrandName = Brand_Menu.GetBrand;
                    CustomerDesc = CutomerType_Menu.GetTypeDesc;
                    CustomerVal = CutomerType_Menu.GetTypeValue;
                    Users = USER.FullName;

                    Session["DateFrom"] = From;
                    Session["DateTo"] = To;
                    Session["BrandName"] = BrandName;
                    Session["Stat"] = CustomerVal;

                    string url = "../Reports/ReportForms/SummaryMonthlyInventoryPerBrand.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));

                }
            }

            else if (rblist1.SelectedValue == "rptConsoSummMonthlyInvPerBrand")
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
                else
                {

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);

                    Session["DateFrom"] = From;
                    Session["DateTo"] = To;

                    string url = "../Reports/ReportForms/ConsolidatedSummaryMonthlyInventoryPerBrand.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
                }
            }

        }

        protected void rblist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblist1.SelectedValue == "rptBrandInvSumm")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Cutomers_Menu.Visible = false;
                Date_Menu.Visible = true;

                Date_Menu.SetDefault();
                CutomerType_Menu.SetDefault();
                Cutomers_Menu.SetDefault();
                Brand_Menu.SetDefault();

            }
            else if (rblist1.SelectedValue == "rptStoreInvSumm")
            {
                Cutomers_Menu.Visible = false;
                Brand_Menu.Visible = true;
                CutomerType_Menu.Visible = true;
                Date_Menu.Visible = true;

                Date_Menu.SetDefault();
                CutomerType_Menu.SetDefault();
                Cutomers_Menu.SetDefault();
                Brand_Menu.SetDefault();
            }
            else if (rblist1.SelectedValue == "rptStockCard")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Date_Menu.Visible = true;
                Cutomers_Menu.Visible = true;

                Date_Menu.SetDefault();
                CutomerType_Menu.SetDefault();
                Cutomers_Menu.SetDefault();
                Brand_Menu.SetDefault();
            }
            else if (rblist1.SelectedValue == "rptStockCardQrt")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Date_Menu.Visible = true;
                Cutomers_Menu.Visible = true;

                Date_Menu.SetDefault();
                CutomerType_Menu.SetDefault();
                Cutomers_Menu.SetDefault();
                Brand_Menu.SetDefault();
            }

            else if (rblist1.SelectedValue == "rptSummMonthlyInvPerBrand")
            {
                Cutomers_Menu.Visible = false;
                Brand_Menu.Visible = true;
                CutomerType_Menu.Visible = true;
                Date_Menu.Visible = true;

                Date_Menu.SetDefault();
                CutomerType_Menu.SetDefault();
                Cutomers_Menu.SetDefault();
                Brand_Menu.SetDefault();
            }

            else if (rblist1.SelectedValue == "rptConsoSummMonthlyInvPerBrand")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Cutomers_Menu.Visible = false;
                Date_Menu.Visible = true;

                Date_Menu.SetDefault();
                CutomerType_Menu.SetDefault();
                Cutomers_Menu.SetDefault();
                Brand_Menu.SetDefault();
            }
           


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            CheckParameters();
        }

       

        
    }
}