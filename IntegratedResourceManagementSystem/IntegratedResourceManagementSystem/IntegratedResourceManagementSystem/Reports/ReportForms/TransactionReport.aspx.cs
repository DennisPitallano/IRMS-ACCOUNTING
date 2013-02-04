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
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{

            //}
            //else
            //{
            if (Request.QueryString["dept"] == "Accounting")
            {//rptNameSOI
                if (Request.QueryString["rptnameSOI"] != "" & Request.QueryString["rptnameCust"] == "")
                {
                    if (Request.QueryString["rptnameSOI"] == "rptStockCard")
                    {
                        Acc_StockCard();
                    }
                    else if (Request.QueryString["rptnameSOI"] == "rptStockCardQrt")
                    {
                        Acc_StockCardQrt();
                    }
                    else if (Request.QueryString["rptnameSOI"] == "rptSummMonthlyInvPerBrand" || Request.QueryString["rptnameSOI"] == "rptStoreInvSumm")
                    {
                        Acc_SummaryofStoreInventoryAndSummaryofMonthlyInvPerBrand();
                    }
                    else
                    {
                        Acc_SummaryofBrandInventoryandConsolidatedMonthlyInv();
                    }
                }
                else
                {
                    Acc_Customer();
                }
            }
            else
            {
                Redirector.Redirect("~/Accounting/ReportsPanel.aspx");
            }
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString["dept"] == "Accounting")
            //{
            //    if (Request.QueryString["rptnameSOI"] != "" & Request.QueryString["rptnameCust"] == "")
            //    {
            //        if (Request.QueryString["rptnameSOI"] == "rptStockCard")
            //        {
            //            Acc_StockCard();
            //        }
            //        else if (Request.QueryString["rptnameSOI"] == "rptStockCardQrt")
            //        {
            //            Acc_StockCardQrt();
            //        }
            //        else if (Request.QueryString["rptnameSOI"] == "rptSummMonthlyInvPerBrand" || Request.QueryString["rptnameSOI"] == "rptStoreInvSumm")
            //        {
            //            Acc_SummaryofStoreInventoryAndSummaryofMonthlyInvPerBrand();
            //        }
            //        else
            //        {
            //            Acc_SummaryofBrandInventoryandConsolidatedMonthlyInv();
            //        }
            //    }
            //    else
            //    {
            //        Acc_Customer();
            //    }
            //}
            //else
            //{
            //    Redirector.Redirect("~/Accounting/ReportsPanel.aspx");
            //}
        }

        #region Accounring Reports
        private void Acc_Customer()
        {
            ReportDocument rpt;
            string rptDocCachedKey = null;
            if (Request.QueryString["rptnameCust"] == "rptCustSIDtl")
            {
                rptDocCachedKey = "rptCustSIDtl";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (CustSI)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new CustSI();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                
            }
            else if (Request.QueryString["rptnameCust"] == "rptCustSIIten")
            {
                rptDocCachedKey = "rptCustSIIten";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (CustSIIten)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new CustSIIten();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                
            }
            else if (Request.QueryString["rptnameCust"] == "rptCustDRDtl")
            {
                rptDocCachedKey = "rptCustDRDtl";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (CustDR)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new CustDR();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                
            }
            else if (Request.QueryString["rptnameCust"] == "rptCustDRIten")
            {
                rptDocCachedKey = "rptCustDRIten";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (CustDRIten)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new CustDRIten();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                
            }
            else if (Request.QueryString["rptnameCust"] == "rptCustCRSDtl")
            {
                rptDocCachedKey = "rptCustCRSDtl";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (CustCRS)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new CustCRS();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
            }
            else
            {
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
               
            }

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

            prmCustNoValue.Value = Request.QueryString["custno"];
            prmDateFromValue.Value = Request.QueryString["datefrom"];
            prmDateToValue.Value = Request.QueryString["dateto"];

            prmCustomer.CurrentValues.Add(prmCustNoValue);
            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);

            prmList.Add(prmCustomer);
            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);

            crvDailyReport.ParameterFieldInfo = prmList;
            crvDailyReport.ReportSource = rpt;
        }

        private void Acc_SummaryofBrandInventoryandConsolidatedMonthlyInv()
        {
            ReportDocument rpt;
            string rptDocCachedKey = null;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IRMSConnectionString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand();

            if (Request.QueryString["rptnameSOI"] == "rptBrandInvSumm")
            {
                rptDocCachedKey = "rptBrandInvSumm";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (RptSummBrandInventory)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new RptSummBrandInventory();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                cmd.Connection = conn;
                cmd.CommandTimeout = 3000;
                cmd.CommandText = "GenRptBrandSummInventory '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "', '" + Session["USER_NAME"] + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
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
                cmd.CommandText = "GenRptSummConsoOfMonthlyInvPerBrand '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Session["USER_NAME"] + "'";
                cmd.ExecuteNonQuery();
            }

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

            prmUserNameValue.Value = Session["USER_NAME"];
            prmDateFromValue.Value = Request.QueryString["datefrom"];
            prmDateToValue.Value = Request.QueryString["dateto"];

            prmUserName.CurrentValues.Add(prmUserNameValue);
            prmDateFrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);

            prmList.Add(prmUserName);
            prmList.Add(prmDateFrom);
            prmList.Add(prmDateTo);

            crvDailyReport.ParameterFieldInfo = prmList;
            crvDailyReport.ReportSource = rpt;
        }

        private void Acc_SummaryofStoreInventoryAndSummaryofMonthlyInvPerBrand()
        {
            ReportDocument rpt;
            string rptDocCachedKey = null;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IRMSConnectionString"].ConnectionString);

            conn.Open();

            SqlCommand cmd = new SqlCommand();

            if (Request.QueryString["rptnameSOI"] == "rptSummMonthlyInvPerBrand")
            {
                rptDocCachedKey = "rptSummMonthlyInvPerBrand";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (RptSummaryofMonthlyInvPerBrand)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new RptSummaryofMonthlyInvPerBrand();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                if (Request.QueryString["customertype"] == "PROVINCIAL")
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 3000;
                    cmd.CommandText = "GenRptSummaryofMonthlyInvPerBrandProv '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Request.QueryString["brand"] + "', '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
                else if (Request.QueryString["customertype"] == "DEPT. STORE")
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 3000;
                    cmd.CommandText = "GenRptSummaryofMonthlyInvPerBrandDept '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Request.QueryString["brand"] + "', '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 3000;
                    cmd.CommandText = "GenRptSummaryofMonthlyInvPerBrandBoutique '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Request.QueryString["brand"] + "', '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                rptDocCachedKey = "RptSummStoreInventory";
                if (Cache[rptDocCachedKey] != null)
                {
                    rpt = (RptSummStoreInventory)Cache[rptDocCachedKey];
                }
                else
                {
                    rpt = new RptSummStoreInventory();
                    Cache.Insert(rptDocCachedKey, rpt);
                }
                
                if (Request.QueryString["customertype"] == "PROVINCIAL")
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 3000;
                    cmd.CommandText = "GenRptStoreSummInvProv '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Request.QueryString["brand"] + "', '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
                else if (Request.QueryString["customertype"] == "DEPT. STORE")
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 3000;
                    cmd.CommandText = "GenRptStoreSummInvDept '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Request.QueryString["brand"] + "', '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 3000;
                    cmd.CommandText = "GenRptStoreSummInvBoutique '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "','" + Request.QueryString["brand"] + "', '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
            }

            DataBaseLogIn(rpt);

            ParameterField prmUserName = new ParameterField();
            ParameterField prmCustType = new ParameterField();
            ParameterField prmBrandName = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            prmUserName.ParameterFieldName = "username";
            prmBrandName.ParameterFieldName = "brandname";
            prmCustType.ParameterFieldName = "custtype";

            ParameterDiscreteValue prmUserNameValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmBrandNameValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmCustTypeValue = new ParameterDiscreteValue();

            prmUserNameValue.Value = Session["USER_NAME"];
            prmBrandNameValue.Value = Request.QueryString["brand"];
            prmCustTypeValue.Value = Request.QueryString["customertype"];

            prmUserName.CurrentValues.Add(prmUserNameValue);
            prmBrandName.CurrentValues.Add(prmBrandNameValue);
            prmCustType.CurrentValues.Add(prmCustTypeValue);

            prmList.Add(prmUserName);
            prmList.Add(prmBrandName);
            prmList.Add(prmCustType);

            crvDailyReport.ParameterFieldInfo = prmList;
            crvDailyReport.ReportSource = rpt;
        }

        private void Acc_StockCard()
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

            long CustNo = long.Parse(Request.QueryString["custno"]);
            DateTime PrevDate = DateTime.Parse(Request.QueryString["datefrom"]).AddDays(-1);

            DateTime DateFrom = DateTime.Parse(Request.QueryString["datefrom"]);
            DateTime DateTo = DateTime.Parse(Request.QueryString["dateto"]);

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
            
            StockCardReport SCR = SCRManager.IsHasRecord(CustNo,PrevDate);
            if (SCRManager.HasRecord(CustNo, PrevDate) == true)
            {
                cmd.CommandTimeout = 300;
                cmd.CommandText = "GenRptStockCard_Beg_StockCard '" + DateFrom + "', '" + DateTo + "', '" + PrevDate + "', " + CustNo + ", '" + Session["USER_NAME"] + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                StoreOutStandingInventory SOIBeginning = SCRManager.IsHasRecordOnSOI(CustNo, PrevDate);
                if (SOIBeginning != null)
                {
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = "GenRptStockCard_Beg_SOI '" + DateFrom + "', '" + DateTo + "', '" + PrevDate + "', " + CustNo + ", '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = "GenRptStockCard_Beg_Pcount '" + DateFrom + "', '" + DateTo + "', " + CustNo + ", '" + Session["USER_NAME"] + "'";
                    cmd.ExecuteNonQuery();
                }
            }
            //cmd.Connection = conn;
            cmd.CommandTimeout = 3000;
            cmd.CommandText = "genrptstockcard_new '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "'," + Request.QueryString["custno"] + ", '" + Session["USER_NAME"] + "'";
            cmd.ExecuteNonQuery();

            DataTable ResultSet = new DataTable();
            cmd.CommandText = "genrptstockcardsales '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "'," + Request.QueryString["custno"] + ", '" + Session["USER_NAME"] + "'";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select * from rptstockcard_new where custno = " + Request.QueryString["custno"] + " and datefrom= '" + Request.QueryString["datefrom"] + "' and dateto='" + Request.QueryString["dateto"] + "'";
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

                    cmd.CommandText = "update rptstockcard_new set balance_qty = " + Balqty + ", balance_amt = " + Balamt + ", balance_cost= " + Balcost + " where id = " + (long)row[0] + " and custno = " + (int)row[4] + " and username = '" + Session["USER_NAME"] + "' and datefrom = '" + DateFrom + "' and dateto = '" + DateTo + "'";
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

            prmDateFromValue.Value = Request.QueryString["datefrom"];
            prmDateToValue.Value = Request.QueryString["dateto"];
            prmCustnoValue.Value = Request.QueryString["custno"];

            prmDatefrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);
            prmCustno.CurrentValues.Add(prmCustnoValue);

            prmList.Add(prmDatefrom);
            prmList.Add(prmDateTo);
            prmList.Add(prmCustno);

            crvDailyReport.ParameterFieldInfo = prmList;
            crvDailyReport.ReportSource = rpt;

        }

        private void Acc_StockCardQrt()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IRMSConnectionString"].ConnectionString);
            ReportDocument rpt;

            string rptDocCachedKey = null;
            rptDocCachedKey = "rptStockCardQrt";
            if (Cache[rptDocCachedKey] != null)
            {
                rpt = (StockCardRptQuarterly)Cache[rptDocCachedKey];
            }
            else
            {
                rpt = new StockCardRptQuarterly();
                Cache.Insert(rptDocCachedKey, rpt);
            }

            long CustNo = long.Parse(Request.QueryString["custno"]);
            DateTime PrevDate = DateTime.Parse(Request.QueryString["datefrom"]).AddDays(-1);

            DateTime DateFrom = DateTime.Parse(Request.QueryString["datefrom"]);
            DateTime DateTo = DateTime.Parse(Request.QueryString["dateto"]);

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
            cmd.CommandText = "delete from RptStockCardQrt where username='" + Session["USER_NAME"] + "'";
            cmd.ExecuteNonQuery();

            StockCardReportManager SCRManager = new StockCardReportManager();
            StoreOutStandingInventory SOIBeginning = SCRManager.IsHasRecordOnSOI(CustNo, PrevDate);

            if (SOIBeginning != null)
            {
                cmd.CommandTimeout = 300;
                cmd.CommandText = "GenRptStockCard_Beg_SOI_Qrt '" + DateFrom + "', '" + DateTo + "', '" + PrevDate + "', " + CustNo + ", '" + Session["USER_NAME"] + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandTimeout = 300;
                cmd.CommandText = "GenRptStockCard_Beg_Pcount_Qrt '" + DateFrom + "', '" + DateTo + "', " + CustNo + ", '" + Session["USER_NAME"] + "'";
                cmd.ExecuteNonQuery();
            }
            //cmd.Connection = conn;
            cmd.CommandTimeout = 3000;
            cmd.CommandText = "genrptstockcardqrt '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "'," + Request.QueryString["custno"] + ", '" + Session["USER_NAME"] + "'";
            cmd.ExecuteNonQuery();

            DataTable ResultSet = new DataTable();
            cmd.CommandText = "genrptstockcardqrtsales '" + Request.QueryString["datefrom"] + "','" + Request.QueryString["dateto"] + "'," + Request.QueryString["custno"] + ", '" + Session["USER_NAME"] + "'";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select * from RptStockCardQrt where custno = " + Request.QueryString["custno"] + " and datefrom= '" + Request.QueryString["datefrom"] + "' and dateto='" + Request.QueryString["dateto"] + "'";
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(ResultSet);
            }

            foreach (DataRow row in ResultSet.Rows)
            {
                if (Firstrec == true)
                {
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

                    cmd.CommandText = "update RptStockCardQrt set balance_qty = " + Balqty + ", balance_amt = " + Balamt + ", balance_cost= " + Balcost + " where id = " + (long)row[0] + " and custno = " + (int)row[4] + " and username = '" + Session["USER_NAME"] + "' and datefrom = '" + DateFrom + "' and dateto = '" + DateTo + "'";
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

            prmDateFromValue.Value = Request.QueryString["datefrom"];
            prmDateToValue.Value = Request.QueryString["dateto"];
            prmCustnoValue.Value = Request.QueryString["custno"];

            prmDatefrom.CurrentValues.Add(prmDateFromValue);
            prmDateTo.CurrentValues.Add(prmDateToValue);
            prmCustno.CurrentValues.Add(prmCustnoValue);

            prmList.Add(prmDatefrom);
            prmList.Add(prmDateTo);
            prmList.Add(prmCustno);

            crvDailyReport.ParameterFieldInfo = prmList;
            crvDailyReport.ReportSource = rpt;

        }
        #endregion

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

        private Decimal ConvertDataToDecimal(object data)
        {
            Decimal dResult = 0;

            try
            {
                dResult = Convert.ToDecimal(data);
            }
            catch (Exception except)
            {
                dResult = 0;
            }
            return dResult;
        }
        //protected void btnBack_Click(object sender, EventArgs e)
        //{
        //    Redirector.Redirect("~/Accounting/ReportsPanel.aspx");
        //}


     
    }
}