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
    public partial class CustomerGroupOverall : System.Web.UI.Page
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
                string reportCacheCustGrpOverAll = string.Concat("CustomerGroupOverAll", UserName);
                string reportCacheCustGrpOverAllWithPrev = string.Concat("CustomerGroupOverAllWithPrev", UserName);

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

                prmUser.CurrentValues.Add(prmUserValue);
                prmPost.CurrentValues.Add(prmPostValue);
                prmCategory.CurrentValues.Add(prmCategoryValue);

                prmList.Add(prmUser);
                prmList.Add(prmPost);
                prmList.Add(prmCategory);

                if (Status == 0)
                {
                    REPORT_DOC = new CusGrupOvrAll();
                    Cache.Insert(reportCacheCustGrpOverAll, REPORT_DOC);
                }
                else
                {
                    REPORT_DOC = new CusGrupOvrAllWithPrev();
                    Cache.Insert(reportCacheCustGrpOverAllWithPrev, REPORT_DOC);
                }

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