using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;
using System.Data.SqlClient;
using System.Configuration;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class MonthlyPullOutSummaryPerBrandReport : System.Web.UI.Page
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
            ReportDocument PullOutSummaryPerBrand = new ReportDocument();
            switch(Request.QueryString["CustomerType"])
            {
                case "PROVINCIAL":
                    PullOutSummaryPerBrand = new PullOutSummaryPerBrandPROVRpt();
                    break;
                case "BOUTIQUE":
                    PullOutSummaryPerBrand = new PullOutSummaryPerBrandBTQRpt();
                    break;
                case "DEPARTMENT STORE":
                    PullOutSummaryPerBrand = new PullOutSummaryPerBrandDEPTSTORERpt();
                    break;
            }

            DataBaseLogIn(PullOutSummaryPerBrand);

            ParameterField prmBrand = new ParameterField();
            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmBrand.ParameterFieldName = "brand";
            prmDateFrom.ParameterFieldName = "date_from";
            prmDateTo.ParameterFieldName = "date_to";

            ParameterDiscreteValue prmBrandValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();

            prmBrandValue.Value = Request.QueryString["Brand"];
            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];

            prmBrand.CurrentValues.Add(prmBrandValue);
            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);

            prmList.Add(prmBrand);
            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            this.crViewerPullOutSummaryPerBrand.ParameterFieldInfo = prmList;
            crViewerPullOutSummaryPerBrand.ReportSource = PullOutSummaryPerBrand;
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