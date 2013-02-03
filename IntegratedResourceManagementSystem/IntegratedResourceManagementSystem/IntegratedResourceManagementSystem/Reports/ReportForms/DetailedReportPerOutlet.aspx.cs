using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.Configuration;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class DetailedReportPerOutlet : System.Web.UI.Page
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
            ReportDocument DetailedReportperOutlet;
            DetailedReportperOutlet = new PullOutDetailedPerOutletRpt();
            int CustomerNumber = int.Parse(Request.QueryString["CustomerNumber"]);
            DateTime DateFrom = DateTime.Parse(Request.QueryString["DateFrom"]);
            DateTime DateTo = DateTime.Parse(Request.QueryString["DateTo"]);

            DataBaseLogIn(DetailedReportperOutlet);

            ParameterField prmCustomerNumber = new ParameterField();
            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmCustomerNumber.ParameterFieldName = "customer_number";
            prmDateFrom.ParameterFieldName = "date_from";
            prmDateTo.ParameterFieldName = "date_to";

            ParameterDiscreteValue prmCustNoValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();

            prmCustNoValue.Value = Request.QueryString["CustomerNumber"];
            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];

            prmCustomerNumber.CurrentValues.Add(prmCustNoValue);
            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);

            prmList.Add(prmCustomerNumber);
            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            crViewerDetailedReportPerOutlet.ParameterFieldInfo = prmList;
            crViewerDetailedReportPerOutlet.ReportSource = DetailedReportperOutlet;
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