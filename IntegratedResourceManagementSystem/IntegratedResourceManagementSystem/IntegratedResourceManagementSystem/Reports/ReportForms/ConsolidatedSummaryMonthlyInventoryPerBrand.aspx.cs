using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;
using IRMS.ObjectModel;


namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class ConsolidatedSummaryMonthlyInventoryPerBrand : System.Web.UI.Page
    {
        public UsersClass USER { get { return (UsersClass)Session["USER_ACCOUNT"]; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeReport();
        }
        private void InitializeReport()
        {
            try
            {

                DateTime DateFrom = DateTime.Parse(Session["DateFrom"].ToString());
                DateTime DateTo = DateTime.Parse(Session["DateTo"].ToString());

                ReportDocument rpt;
                string rptDocCachedKey = null;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IRMSConnectionString"].ConnectionString);

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                rptDocCachedKey = "GenRptConsoSummaryofMonthlyInvPerBrand";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (RptConsoSummaryofMonthlyInvPerBrand)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new RptConsoSummaryofMonthlyInvPerBrand();
                    Cache.Insert(rptDocCachedKey, rpt);
                }

                cmd.Connection = conn;
                cmd.CommandTimeout = 3000;
                cmd.CommandText = "GenRptSummConsoOfMonthlyInvPerBrand '" + DateFrom + "','" + DateTo + "','" + USER.FullName + "'";
                cmd.ExecuteNonQuery();
                 

                DataBaseLogIn(rpt);

                ParameterField prmUserName = new ParameterField();
                ParameterField prmDateFrom = new ParameterField();
                ParameterField prmDateTo = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                prmUserName.ParameterFieldName = "username";
                prmDateFrom.ParameterFieldName = "datefrom";
                prmDateTo.ParameterFieldName = "dateto";

                ParameterDiscreteValue prmUserNameValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();

                prmUserNameValue.Value = USER.FullName;
                prmDateFromValue.Value = DateFrom;
                prmDateToValue.Value = DateTo;

                prmUserName.CurrentValues.Add(prmUserNameValue);
                prmDateFrom.CurrentValues.Add(prmDateFromValue);
                prmDateTo.CurrentValues.Add(prmDateToValue);

                prmList.Add(prmUserName);
                prmList.Add(prmDateFrom);
                prmList.Add(prmDateTo);

                CrystalReportViewer1.ParameterFieldInfo = prmList;
                CrystalReportViewer1.ReportSource = rpt;

                
            }
            catch
            {
                throw;
            }

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