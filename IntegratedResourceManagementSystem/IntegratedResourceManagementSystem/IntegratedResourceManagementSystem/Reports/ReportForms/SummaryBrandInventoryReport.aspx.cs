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
    public partial class SummaryBrandInventoryReport  : System.Web.UI.Page
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
                DateTime From = Convert.ToDateTime(Session["From"].ToString());
                DateTime To = Convert.ToDateTime(Session["To"].ToString());

                ReportDocument REPORT_DOC = new ReportDocument();
                string reportCacheSummaryBrandInventory = string.Concat("SummaryBrandInventory", USER.FullName, From, To);               
                
                ParameterField prmUser = new ParameterField();
                ParameterField prmFrom = new ParameterField();
                ParameterField prmTo = new ParameterField();

                ParameterFields prmList = new ParameterFields();

                prmUser.ParameterFieldName = "username";
                prmFrom.ParameterFieldName = "datefrom";
                prmTo.ParameterFieldName = "dateto";

                ParameterDiscreteValue prmUserValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmFromValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmToValue = new ParameterDiscreteValue();
                
                prmUserValue.Value = USER.FullName;
                prmFromValue.Value = From;
                prmToValue.Value = To;

                prmUser.CurrentValues.Add(prmUserValue);
                prmFrom.CurrentValues.Add(prmFromValue);
                prmTo.CurrentValues.Add(prmToValue);

              
                prmList.Add(prmUser);
                prmList.Add(prmFrom);
                prmList.Add(prmTo);

                //if (Status == 0)
                //{
                    REPORT_DOC = new RptSummBrandInventory();
                    Cache.Insert(reportCacheSummaryBrandInventory, REPORT_DOC);
                //}
              
                DataBaseLogIn(REPORT_DOC);
                this.CrystalReportViewer1.ParameterFieldInfo = prmList;
                CrystalReportViewer1.ReportSource = REPORT_DOC;

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