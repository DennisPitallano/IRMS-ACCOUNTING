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
            string CustomerType = string.Empty;
            int CustomerNumber = 0;
            int Type = 0;
            string Users;
            string Status = string.Empty;

            if (rblist1.SelectedValue == "rptStoreInvSumm")
            {
                    if (CutomerType_Menu.GetType == "PROVINCIAL")
                    {
                        Type = 1;
                    }
                    else if (CutomerType_Menu.GetType == "DEPARTMENT STORE")
                    {
                        Type = 2;
                    }
                    else if (CutomerType_Menu.GetType == "BOUTIQUE")
                    {
                        Type = 3;
                    }                  

                    From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                    To = Convert.ToDateTime(Date_Menu.GetDateTo);
                    BrandName = Brand_Menu.GetBrand;
                    CustomerType = CutomerType_Menu.GetType;
                    Users = USER.FullName;

                    StoredProcedureManager SPM = new StoredProcedureManager();
                    SPM.ExecuteGenSummaryStoreInventory(From, To, BrandName, Users, Type);
                    Session["Brand"] = BrandName;
                    Session["Type"] = CutomerType_Menu.GetType;

                    string url = "../Reports/ReportForms/SummaryStoreInventoryReport.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));          
            }
            else if (rblist1.SelectedValue == "rptBrandInvSumm")
            {
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                Users = USER.FullName;

                StoredProcedureManager SPM = new StoredProcedureManager();
                SPM.ExecuteGenSummaryBrandInventory(Users, From, To);
                Session["From"] = From;
                Session["To"] = To;
              
                string url = "../Reports/ReportForms/SummaryBrandInventoryReport.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
            }

            else if (rblist1.SelectedValue == "rptStockCard")
            {            
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                Users = USER.FullName;
                CustomerNumber = Cutomers_Menu.GetCustomerNo;

                Session["From"] = From;
                Session["To"] = To;
                Session["CustomerNo"] = CustomerNumber;


                string url = "../Reports/ReportForms/SummaryStockCardMonthly.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
            }

            else if (rblist1.SelectedValue == "rptStockCardQrt")
            {
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                Users = USER.FullName;
                CustomerNumber = Cutomers_Menu.GetCustomerNo;

                Session["From"] = From;
                Session["To"] = To;
                Session["CustomerNo"] = CustomerNumber;


                string url = "../Reports/ReportForms/SummaryStockCardQuarterly.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
            }

            else if (rblist1.SelectedValue == "rptSummMonthlyInvPerBrand")
            {

                if (CutomerType_Menu.GetType == "PROVINCIAL")
                {
                    Type = 1;
                }
                else if (CutomerType_Menu.GetType == "DEPARTMENT STORE")
                {
                    Type = 2;
                }
                else if (CutomerType_Menu.GetType == "BOUTIQUE")
                {
                    Type = 3;
                }

                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);
                BrandName = Brand_Menu.GetBrand;
                CustomerType = CutomerType_Menu.GetType;
                Users = USER.FullName;

                Session["DateFrom"] = From;
                Session["DateTo"] = To;
                Session["BrandName"] = BrandName;
                Session["Stat"] = Type;

                string url = "../Reports/ReportForms/SummaryMonthlyInventoryPerBrand.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));

            }

            else if (rblist1.SelectedValue == "rptConsoSummMonthlyInvPerBrand")
            {
                From = Convert.ToDateTime(Date_Menu.GetDateFrom);
                To = Convert.ToDateTime(Date_Menu.GetDateTo);

                Session["DateFrom"] = From;
                Session["DateTo"] = To;

                string url = "../Reports/ReportForms/ConsolidatedSummaryMonthlyInventoryPerBrand.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
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
            }
            else if (rblist1.SelectedValue == "rptStoreInvSumm")
            {
                Cutomers_Menu.Visible = false;
                Brand_Menu.Visible = true;
                CutomerType_Menu.Visible = true;
                Date_Menu.Visible = true;
            }
            else if (rblist1.SelectedValue == "rptStockCard")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Date_Menu.Visible = true;
                Cutomers_Menu.Visible = true;
            }
            else if (rblist1.SelectedValue == "rptStockCardQrt")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Date_Menu.Visible = true;
                Cutomers_Menu.Visible = true;
            }

            else if (rblist1.SelectedValue == "rptSummMonthlyInvPerBrand")
            {
                Cutomers_Menu.Visible = false;
                Brand_Menu.Visible = true;
                CutomerType_Menu.Visible = true;
                Date_Menu.Visible = true;
            }

            else if (rblist1.SelectedValue == "rptConsoSummMonthlyInvPerBrand")
            {
                Brand_Menu.Visible = false;
                CutomerType_Menu.Visible = false;
                Cutomers_Menu.Visible = false;
                Date_Menu.Visible = true;
            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            CheckParameters();
        }

       

        
    }
}