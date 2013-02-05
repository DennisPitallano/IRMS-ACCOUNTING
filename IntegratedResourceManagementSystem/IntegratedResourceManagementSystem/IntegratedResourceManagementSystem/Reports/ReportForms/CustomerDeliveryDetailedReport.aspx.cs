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


namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class CustomerDeliveryDetailedReport : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void Page_Init(object sender, EventArgs e)
        {
             InitializeReport();

        }

        protected void InitializeReport()
        {
            try
            {
              

                long CustNo = long.Parse(Session["CustomerNo"].ToString());
                DateTime DateFrom = DateTime.Parse(Session["From"].ToString());
                DateTime DateTo = DateTime.Parse(Session["To"].ToString());

                ReportDocument REPORT_DOC = new ReportDocument();
                string reportCacheCustomerDeliveryDetailed = string.Concat("CustomerDeliveryDetailed", CustNo,DateFrom,DateTo);

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

                if (Cache[reportCacheCustomerDeliveryDetailed] != null)
                {
                    REPORT_DOC = (CustomerDeliveryDetailed)Cache[reportCacheCustomerDeliveryDetailed];
                    DataBaseLogIn(REPORT_DOC);
                    CrystalReportViewer1.ReportSource = REPORT_DOC;
                }
                else
                {
                    REPORT_DOC = new CustomerDeliveryDetailed();
                    Cache.Insert(reportCacheCustomerDeliveryDetailed, REPORT_DOC);

                    DataBaseLogIn(REPORT_DOC);
                    this.CrystalReportViewer1.ParameterFieldInfo = prmList;
                    CrystalReportViewer1.ReportSource = REPORT_DOC;
                }

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