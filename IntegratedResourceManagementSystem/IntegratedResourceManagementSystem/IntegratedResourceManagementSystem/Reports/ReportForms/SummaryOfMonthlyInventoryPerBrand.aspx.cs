using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Data;
using IRMS.Components;
using System.Data.SqlClient;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;
using IntegratedResourceManagementSystem.Reports.ReportDataSet;
using IRMS.ObjectModel.Views;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class SummaryOf_MonthlyInventoryPerBrand : System.Web.UI.Page
    {

        private StockCardReportManager SRM = new StockCardReportManager();
        public UsersClass USER { get { return (UsersClass)Session["USER_ACCOUNT"]; } }
        protected void Page_Init(object sender, EventArgs e)
        {
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
            else
            {
                LoadReport();
            }
        }

        protected void LoadReport()
        {
            try
            {

                DateTime dFrom = Convert.ToDateTime(Session["DateFrom"].ToString());
                DateTime dTo = Convert.ToDateTime(Session["DateTo"].ToString());
                string brand = Session["BrandName"].ToString();
                string users = USER.FullName;
                int Stat = int.Parse(Session["Stat"].ToString());

                ReportDocument objRpt = new ReportDocument();
                SummaryOfMonthlyInventoryPerBrandDataSet SMPB = new SummaryOfMonthlyInventoryPerBrandDataSet();
                DataTable t = SMPB.Tables.Add("Reports");


                t.Columns.Add("DATE_FROM", Type.GetType("System.DateTime"));
                t.Columns.Add("DATE_TO", Type.GetType("System.DateTime"));
                t.Columns.Add("CUSTOMER", Type.GetType("System.String"));
                t.Columns.Add("BRAND_NAME", Type.GetType("System.String"));
                t.Columns.Add("CUSTOMER_TYPE", Type.GetType("System.String"));

                t.Columns.Add("BALANCE_QTY", Type.GetType("System.Int32"));
                t.Columns.Add("BALANCE_AMT", Type.GetType("System.Double"));
                t.Columns.Add("BALANCE_COST", Type.GetType("System.Double"));

                t.Columns.Add("DR_QTY", Type.GetType("System.Int32"));
                t.Columns.Add("DR_AMT", Type.GetType("System.Double"));
                t.Columns.Add("DR_COST", Type.GetType("System.Double"));

                t.Columns.Add("RETURN_QTY", Type.GetType("System.Int32"));
                t.Columns.Add("RETURN_AMT", Type.GetType("System.Double"));
                t.Columns.Add("RETURN_COST", Type.GetType("System.Double"));

                t.Columns.Add("SALES_QTY", Type.GetType("System.Int32"));
                t.Columns.Add("SALES_AMT", Type.GetType("System.Double"));
                t.Columns.Add("SALES_COST", Type.GetType("System.Double"));

                t.Columns.Add("ADJ_QTY", Type.GetType("System.Int32"));
                t.Columns.Add("ADJ_AMT", Type.GetType("System.Double"));
                t.Columns.Add("ADJ_COST", Type.GetType("System.Double"));

                t.Columns.Add("USERNAME", Type.GetType("System.String"));


                DataRow rows;
                foreach (ViewSummaryOfMonthlyInventoryPerBrand item in SRM.GetSummaryOfMonthlyInventoryPerBrand(dFrom, dTo, brand, users, Stat))
                {
                    rows = t.NewRow();

                    rows["DATE_FROM"] = item.DateFrom;
                    rows["DATE_TO"] = item.DateTo;
                    rows["CUSTOMER"] = item.Customer;
                    rows["BRAND_NAME"] = item.BrandName;
                    rows["CUSTOMER_TYPE"] = item.CustomerType;

                    rows["BALANCE_QTY"] = item.BalQuantity;
                    rows["BALANCE_AMT"] = item.BalanceAmount;
                    rows["BALANCE_COST"] = item.BalanceCost;

                    rows["DR_QTY"] = item.DrQuantity;
                    rows["DR_AMT"] = item.DrAmount;
                    rows["DR_COST"] = item.DrCost;

                    rows["RETURN_QTY"] = item.ReturnQuantoty;
                    rows["RETURN_AMT"] = item.ReturnAmount;
                    rows["RETURN_COST"] = item.ReturnCost;

                    rows["SALES_QTY"] = item.SaleQuantity;
                    rows["SALES_AMT"] = item.SaleAmount;
                    rows["SALES_COST"] = item.SaleCost;

                    rows["ADJ_QTY"] = item.AdjQuantity;
                    rows["ADJ_AMT"] = item.AdjAmount;
                    rows["ADJ_COST"] = item.AdjCost;

                    rows["USERNAME"] = item.UserName;

                    t.Rows.Add(rows);

                }

              

                objRpt.Load(MapPath("~/Reports/ReportDocuments/RptSummaryMonthlyInvPerBrand.rpt"));
                objRpt.SetDataSource(SMPB.Tables["Reports"]);
                CrystalReportViewer1.ReportSource = objRpt;
                CrystalReportViewer1.DataBind();
            }
            catch
            {
                throw;
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Accounting/ReportsPanel.aspx");
        }
    }
}