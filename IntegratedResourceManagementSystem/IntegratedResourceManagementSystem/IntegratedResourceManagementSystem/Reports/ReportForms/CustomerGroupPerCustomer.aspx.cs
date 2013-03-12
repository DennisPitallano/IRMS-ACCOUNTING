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
    public partial class CustomerGroupPerCustomer : System.Web.UI.Page
    {
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
                string UserName = Session["UserName"].ToString();
                int Post = int.Parse(Session["Post"].ToString());
                int Category = int.Parse(Session["Category"].ToString());
                int Status = int.Parse(Session["Status"].ToString());

                ReportDocument REPORT_DOC = new ReportDocument();
                string reportCacheCustGrpPerCustomer = string.Concat("CustomerGroupPerCustomer", UserName);
                string reportCacheCustGrpPerCustomerWithPrev = string.Concat("CustomerGroupPerCustomerWithPrev", UserName);

                ParameterField prmUser = new ParameterField();
                ParameterField prmPost = new ParameterField();
                ParameterField prmCategory = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                prmUser.ParameterFieldName = "users";
                prmPost.ParameterFieldName = "Post";
                prmCategory.ParameterFieldName = "Category";

                ParameterDiscreteValue prmUserValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmPostValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmCategoryValue = new ParameterDiscreteValue();

                prmUserValue.Value = UserName;
                prmPostValue.Value = Post;
                prmCategoryValue.Value = Category;

                prmPost.CurrentValues.Add(prmPostValue);
                prmUser.CurrentValues.Add(prmUserValue);
                prmCategory.CurrentValues.Add(prmCategoryValue);

                prmList.Add(prmUser);
                prmList.Add(prmCategory);
                prmList.Add(prmPost);

                if (Status == 0)
                {
                    REPORT_DOC = new CusGrupPerCustomer();
                    Cache.Insert(reportCacheCustGrpPerCustomer, REPORT_DOC);
                }
                else
                {
                    REPORT_DOC = new CusGrupPerCustomerWithPrev();
                    Cache.Insert(reportCacheCustGrpPerCustomerWithPrev, REPORT_DOC);
                }

                DataBaseLogIn(REPORT_DOC);
                this.CrystalReportViewer1.ParameterFieldInfo = prmList;
                CrystalReportViewer1.ReportSource = REPORT_DOC;

            }
            catch
            {
                // throw;
            }

        }

        private static SqlConnectionStringBuilder Connection()
        {
            SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
            con.ConnectTimeout = 0;
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