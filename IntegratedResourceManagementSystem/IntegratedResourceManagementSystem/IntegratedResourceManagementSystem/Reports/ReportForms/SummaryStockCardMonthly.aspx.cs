using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using IntegratedResourceManagementSystem.Reports.ReportDocuments;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Data;
using IRMS.Components;
using System.Data.SqlClient ;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class SummaryStockCardMonthly : System.Web.UI.Page
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
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IRMSConnectionString"].ConnectionString);
                ReportDocument rpt;

                string rptDocCachedKey = null;
                rptDocCachedKey = "StockCardRpt";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (StockCardRpt)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new StockCardRpt();
                    Cache.Insert(rptDocCachedKey, rpt);
                }

                //long CustNo = long.Parse(Request.QueryString["custno"]);
                //DateTime PrevDate = DateTime.Parse(Request.QueryString["datefrom"]).AddDays(-1);

                //DateTime DateFrom = DateTime.Parse(Request.QueryString["datefrom"]);
                //DateTime DateTo = DateTime.Parse(Request.QueryString["dateto"]);

                long CustNo = long.Parse(Session["CustomerNo"].ToString());
                DateTime PrevDate = DateTime.Parse(Session["From"].ToString()).AddDays(-1);

                DateTime DateFrom = DateTime.Parse(Session["From"].ToString());
                DateTime DateTo = DateTime.Parse(Session["To"].ToString());

                long Balqty = 0;
                decimal Balamt = 0;
                decimal Balcost = 0;
                long Balqty1 = 0;
                decimal Balamt1 = 0;
                decimal Balcost1 = 0;
                long Debitqty = 0;
                decimal Debitamt = 0;
                decimal Debitcost = 0;
                long Creditqty = 0;
                decimal Creditamt = 0;
                decimal Creditcost = 0;
                bool Firstrec = true;

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandTimeout = 300;
                cmd.CommandText = "delete from rptstockcard_new where custno = '" + CustNo + "' and datefrom = '" + DateFrom + "' and dateto = '" + DateTo + "'";
                cmd.ExecuteNonQuery();

                StockCardReportManager SCRManager = new StockCardReportManager();

                StockCardReport SCR = SCRManager.IsHasRecord(CustNo, PrevDate);
                if (SCRManager.HasRecord(CustNo, PrevDate) == true)
                {
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = "GenRptStockCard_Beg_StockCard '" + DateFrom + "', '" + DateTo + "', '" + PrevDate + "', " + CustNo + ", '" + USER.FullName + "'";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    StoreOutStandingInventory SOIBeginning = SCRManager.IsHasRecordOnSOI(CustNo, PrevDate);
                    if (SOIBeginning != null)
                    {
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = "GenRptStockCard_Beg_SOI '" + DateFrom + "', '" + DateTo + "', '" + PrevDate + "', " + CustNo + ", '" + USER.FullName + "'";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = "GenRptStockCard_Beg_Pcount '" + DateFrom + "', '" + DateTo + "', " + CustNo + ", '" + USER.FullName + "'";
                        cmd.ExecuteNonQuery();
                    }
                }
                //cmd.Connection = conn;
                cmd.CommandTimeout = 3000;
                cmd.CommandText = "genrptstockcard_new '" + DateFrom + "','" + DateTo + "'," + CustNo + ", '" + USER.FullName + "'";
                cmd.ExecuteNonQuery();

                DataTable ResultSet = new DataTable();
                cmd.CommandText = "genrptstockcardsales '" + DateFrom + "','" + DateTo + "'," + CustNo + ", '" + USER.FullName + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select * from rptstockcard_new where custno = " + CustNo + " and datefrom= '" + DateFrom + "' and dateto='" + DateTo + "'";
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ResultSet);
                }

                foreach (DataRow row in ResultSet.Rows)
                {
                    if (Firstrec == true)
                    {
                        ////Balqty = (long)row[14];
                        ////Balamt = (decimal)row[15];
                        ////Balcost = (decimal)row[16];

                        Balqty = Convert.ToInt64(row[14]);
                        Balamt = ConvertDataToDecimal(row[15]);
                        Balcost = ConvertDataToDecimal(row[16]);

                        Firstrec = false;

                    }
                    else
                    {
                        Debitqty = Convert.ToInt64(row[8]);
                        Debitamt = ConvertDataToDecimal(row[9]);
                        Debitcost = ConvertDataToDecimal(row[10]);
                        Creditqty = Convert.ToInt64(row[11]);
                        Creditamt = ConvertDataToDecimal(row[12]);
                        Creditcost = ConvertDataToDecimal(row[13]);

                        Balqty1 = Balqty + Debitqty + Creditqty;
                        Balamt1 = Balamt + Debitamt + Creditamt;
                        Balcost1 = Balcost + Debitcost + Creditcost;

                        Balqty = Balqty1;
                        Balamt = Balamt1;
                        Balcost = Balcost1;

                        cmd.CommandText = "update rptstockcard_new set balance_qty = " + Balqty + ", balance_amt = " + Balamt + ", balance_cost= " + Balcost + " where id = " + (long)row[0] + " and custno = " + (int)row[4] + " and username = '" + USER.FullName + "' and datefrom = '" + DateFrom + "' and dateto = '" + DateTo + "'";
                        cmd.ExecuteNonQuery();

                    }
                }

                DataBaseLogIn(rpt);

                ParameterField prmDatefrom = new ParameterField();
                ParameterField prmDateTo = new ParameterField();
                ParameterField prmCustno = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                prmDatefrom.ParameterFieldName = "datefrom";
                prmDateTo.ParameterFieldName = "dateto";
                prmCustno.ParameterFieldName = "custno";

                ParameterDiscreteValue prmDateFromValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateToValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmCustnoValue = new ParameterDiscreteValue();

                prmDateFromValue.Value = DateFrom;
                prmDateToValue.Value = DateTo;
                prmCustnoValue.Value = CustNo;

                prmDatefrom.CurrentValues.Add(prmDateFromValue);
                prmDateTo.CurrentValues.Add(prmDateToValue);
                prmCustno.CurrentValues.Add(prmCustnoValue);

                prmList.Add(prmDatefrom);
                prmList.Add(prmDateTo);
                prmList.Add(prmCustno);

                CrystalReportViewer1.ParameterFieldInfo = prmList;
                CrystalReportViewer1.ReportSource = rpt;
            }
            catch
            {
                throw;
            }
            

        }

        private Decimal ConvertDataToDecimal(object data)
        {
            Decimal dResult = 0;

            try
            {
                dResult = Convert.ToDecimal(data);
            }
            catch  
            {
                dResult = 0;
            }
            return dResult;
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