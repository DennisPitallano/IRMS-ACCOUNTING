using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class MonthlySummaryPilferagePerLocation : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeReport();
        }
        private void InitializeReport()
        {

            ReportDocument REPORT_DOC = new ReportDocument();
            REPORT_DOC = new RptSummaryMonthlySOIPilferageByLocation();
            DataBaseLogIn(REPORT_DOC);

            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmDateFrom.ParameterFieldName = "@DateFrom";
            prmDateTo.ParameterFieldName = "@DateTo";

            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();

            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];

            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);

            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            this.SummaryOfMonthlyPilferageByLocation.ParameterFieldInfo = prmList;
            SummaryOfMonthlyPilferageByLocation.ReportSource = REPORT_DOC;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}