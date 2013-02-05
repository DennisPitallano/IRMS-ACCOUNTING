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
    public partial class SummaryStoreInventoryReport : System.Web.UI.Page
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
                
                string Brand = Session["Brand"].ToString();
                string CustType = Session["Type"].ToString();

                ReportDocument REPORT_DOC = new ReportDocument();
                string reportCacheSummaryStoreInventory = string.Concat("SummaryStoreInventory", USER.FullName, Brand, CustType);

                ParameterField prmUser = new ParameterField();
                ParameterField prmbrand = new ParameterField();
                ParameterField prmType = new ParameterField();

                ParameterFields prmList = new ParameterFields();

                prmUser.ParameterFieldName = "username";
                prmbrand.ParameterFieldName = "brandname";
                prmType.ParameterFieldName = "custtype";

                ParameterDiscreteValue prmUserValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmbrandValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmTypeValue = new ParameterDiscreteValue();

                prmUserValue.Value = USER.FullName;
                prmbrandValue.Value = Brand;
                prmTypeValue.Value = CustType;

                prmUser.CurrentValues.Add(prmUserValue);
                prmbrand.CurrentValues.Add(prmbrandValue);
                prmType.CurrentValues.Add(prmTypeValue);


                prmList.Add(prmUser);
                prmList.Add(prmbrand);
                prmList.Add(prmType);


                //if (reportCacheSummaryStoreInventory != null)
                //{

                //    REPORT_DOC = (RptSummStoreInventory)Cache[reportCacheSummaryStoreInventory];
                //    DataBaseLogIn(REPORT_DOC);
                //    CrystalReportViewer1.ReportSource = REPORT_DOC;
                //}
                //else
                //{
                    REPORT_DOC = new RptSummStoreInventory();
                    Cache.Insert(reportCacheSummaryStoreInventory, REPORT_DOC);

                    DataBaseLogIn(REPORT_DOC);
                    this.CrystalReportViewer1.ParameterFieldInfo = prmList;
                    CrystalReportViewer1.ReportSource = REPORT_DOC;
              //  }
                 

                

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