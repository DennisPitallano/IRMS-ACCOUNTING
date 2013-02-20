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
    public partial class CustomerReturnItineraryReport : System.Web.UI.Page
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

                ReportDocument rpt;
                string rptDocCachedKey = null;

                rptDocCachedKey = "CustCRSIten";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (CustCRSIten)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new CustCRSIten();
                    Cache.Insert(rptDocCachedKey, rpt);
                }

                long CustNo = long.Parse(Session["CustomerNo"].ToString());
                DateTime DateFrom = DateTime.Parse(Session["From"].ToString());
                DateTime DateTo = DateTime.Parse(Session["To"].ToString());


                DataBaseLogIn(rpt);

                ParameterField prmCustomer = new ParameterField();
                ParameterField prmDateFrom = new ParameterField();
                ParameterField prmDateTo = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                prmCustomer.ParameterFieldName = "custno";
                prmDateFrom.ParameterFieldName = "datefrom";
                prmDateTo.ParameterFieldName = "dateto";

                ParameterDiscreteValue prmCustNoValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();

                prmCustNoValue.Value = CustNo;
                prmDateFromValue.Value = DateFrom;
                prmDateToValue.Value = DateTo;

                prmCustomer.CurrentValues.Add(prmCustNoValue);
                prmDateFrom.CurrentValues.Add(prmDateFromValue);
                prmDateTo.CurrentValues.Add(prmDateToValue);

                prmList.Add(prmCustomer);
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