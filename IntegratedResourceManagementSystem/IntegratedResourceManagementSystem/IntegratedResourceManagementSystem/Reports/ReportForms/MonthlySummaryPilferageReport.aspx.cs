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
    public partial class MonthlySummaryPilferageReport : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            bool PerLocation = bool.Parse(Request.QueryString["PerLocation"]);
            bool IsGroup = bool.Parse(Request.QueryString["IsGroup"]);
            if (!PerLocation)
            {
                InitializeReport();
            }
            else
            {
                if (!IsGroup)
                {
                    InitializeReportPerLocationWithOutGrouping();
                }
                else
                {
                    InitializeReportPerLocation();
                }
            }
        }
        private void InitializeReport()
        {

            ReportDocument REPORT_DOC = new ReportDocument();
            REPORT_DOC = new RptSummaryOfMonthlyPilferage();
            DataBaseLogIn(REPORT_DOC);

            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterField prmBrand = new ParameterField();
            ParameterField prmInventoryGroupNumber = new ParameterField();
            ParameterField prmInventoryGroupName = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmDateFrom.ParameterFieldName = "@DATE_FROM";
            prmDateTo.ParameterFieldName = "@DATE_TO";
            prmBrand.ParameterFieldName = "@BRAND_NAME";
            prmInventoryGroupNumber.ParameterFieldName = "@INVENTORY_GROUP";
            prmInventoryGroupName.ParameterFieldName = "group_name";


            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmBrandValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmInventoryGroupNumberValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmInventoryGroupNameValue = new ParameterDiscreteValue();


            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];
            prmBrandValue.Value = Request.QueryString["Brand"];
            prmInventoryGroupNumberValue.Value = Request.QueryString["InventoryGroupNumber"];
            prmInventoryGroupNameValue.Value = Request.QueryString["InventoryGroupName"];

            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);
            prmBrand.CurrentValues.Add(prmBrandValue);
            prmInventoryGroupNumber.CurrentValues.Add(prmInventoryGroupNumberValue);
            prmInventoryGroupName.CurrentValues.Add(prmInventoryGroupNameValue);

            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            prmList.Add(prmBrand);
            prmList.Add(prmInventoryGroupName);
            prmList.Add(prmInventoryGroupNumber);

            this.SummaryOfMonthlyPilferage.ParameterFieldInfo = prmList;
            SummaryOfMonthlyPilferage.ReportSource = REPORT_DOC;
        }

        private void InitializeReportPerLocation()
        {

            ReportDocument REPORT_DOC = new ReportDocument();
            REPORT_DOC = new RptSummaryMonthlySOIPilferageByLocation();
            DataBaseLogIn(REPORT_DOC);

            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterField prmInventoryGroupNumber = new ParameterField();
            ParameterField prmInventoryGroupName = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmDateFrom.ParameterFieldName = "@DateFrom";
            prmDateTo.ParameterFieldName = "@DateTo";
            prmInventoryGroupNumber.ParameterFieldName = "@InventoryGroup";
            prmInventoryGroupName.ParameterFieldName = "group_name";


            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmInventoryGroupNumberValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmInventoryGroupNameValue = new ParameterDiscreteValue();


            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];
            prmInventoryGroupNumberValue.Value = Request.QueryString["InventoryGroupNumber"];
            prmInventoryGroupNameValue.Value = Request.QueryString["InventoryGroupName"];

            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);
            prmInventoryGroupNumber.CurrentValues.Add(prmInventoryGroupNumberValue);
            prmInventoryGroupName.CurrentValues.Add(prmInventoryGroupNameValue);

            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            prmList.Add(prmInventoryGroupName);
            prmList.Add(prmInventoryGroupNumber);

            this.SummaryOfMonthlyPilferage.ParameterFieldInfo = prmList;
            SummaryOfMonthlyPilferage.ReportSource = REPORT_DOC;
        }

        private void InitializeReportPerLocationWithOutGrouping()
        {

            ReportDocument REPORT_DOC = new ReportDocument();
            REPORT_DOC = new RptSummaryMonthlySOIPilferageByLocationWOGroup();
            DataBaseLogIn(REPORT_DOC);

            ParameterField prmDateFrom = new ParameterField();
            ParameterField prmDateTo = new ParameterField();
            ParameterField prmInventoryGroupNumber = new ParameterField();
            ParameterField prmInventoryGroupName = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmDateFrom.ParameterFieldName = "@DateFrom";
            prmDateTo.ParameterFieldName = "@DateTo";
            prmInventoryGroupNumber.ParameterFieldName = "@InventoryGroup";
            prmInventoryGroupName.ParameterFieldName = "group_name";


            ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmInventoryGroupNumberValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmInventoryGroupNameValue = new ParameterDiscreteValue();


            prmDateFromValue.Value = Request.QueryString["DateFrom"];
            prmDateToValue.Value = Request.QueryString["DateTo"];
            prmInventoryGroupNumberValue.Value = Request.QueryString["InventoryGroupNumber"];
            prmInventoryGroupNameValue.Value = Request.QueryString["InventoryGroupName"];

            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);
            prmInventoryGroupNumber.CurrentValues.Add(prmInventoryGroupNumberValue);
            prmInventoryGroupName.CurrentValues.Add(prmInventoryGroupNameValue);

            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);
            prmList.Add(prmInventoryGroupName);
            prmList.Add(prmInventoryGroupNumber);

            this.SummaryOfMonthlyPilferage.ParameterFieldInfo = prmList;
            SummaryOfMonthlyPilferage.ReportSource = REPORT_DOC;
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