using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class MonthlyPullOutSummaryPerCustomer : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeReport();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void InitializeReport()
        {
            ReportDocument PullOutSummaryPerCustomer;

            PullOutSummaryPerCustomer = new PullOutSummaryPerOutletRpt();
          

            DataBaseLogIn(PullOutSummaryPerCustomer);

            ParameterField prmCustomerNumber = new ParameterField();
            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmCustomerNumber.ParameterFieldName = "customer_number";
            prmDateFrom.ParameterFieldName = "date_from";
            prmDateTo.ParameterFieldName = "date_to";

            ParameterDiscreteValue prmCustomerNumberValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();

            prmCustomerNumberValue.Value = Request.QueryString["CustomerNumber"];
            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];

            prmCustomerNumber.CurrentValues.Add(prmCustomerNumberValue);
            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);

            prmList.Add(prmCustomerNumber);
            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            this.crViewerMonthlyPullOutSummaryPerCustomer.ParameterFieldInfo = prmList;
            crViewerMonthlyPullOutSummaryPerCustomer.ReportSource = PullOutSummaryPerCustomer;
        }

        private static SqlConnectionStringBuilder Connection()
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["IRMSConnectionString"].ConnectionString;
            return con;
        }

        private static void DataBaseLogIn(ReportDocument rpt)
        {
            ConnectionInfo con_info = new ConnectionInfo();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            Tables crTables;

            con_info.ServerName = Connection().DataSource;
            con_info.DatabaseName = Connection().InitialCatalog;
            con_info.UserID = Connection().UserID;
            con_info.Password = Connection().Password;

            crTables = rpt.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
            {
                crtableLogoninfo = crTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = con_info;
                crTable.ApplyLogOnInfo(crtableLogoninfo);
            }
        }
    }
}