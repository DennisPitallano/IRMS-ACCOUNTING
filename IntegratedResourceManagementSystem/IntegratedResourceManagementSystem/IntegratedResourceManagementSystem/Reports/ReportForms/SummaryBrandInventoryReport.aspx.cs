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
using IRMS.BusinessLogic.Manager;
using System.Data;
using System.Globalization;
using IRMS.ObjectModel.Views;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class SummaryBrandInventoryReport  : System.Web.UI.Page
    {

        public UsersClass USER { get { return (UsersClass)Session["USER_ACCOUNT"]; } }

        

        #region "Book Qty"

        public double TotalBookQty;
        
        public double GrandTotalBookQty;

        public double GetBookQty(double Qty)
        {
            TotalBookQty += Qty;
            return Qty;
        }

        public double GetTotalBookQty()
        {
            return TotalBookQty;
        }

        

        #endregion

        #region "Actual Pcount Qty"

        public double TotalPcountQty;

        public double GrandTotalPcountQty;

        public double GetPcountQty(double Qty)
        {
            TotalPcountQty += Qty;
            return Qty;
        }

        public double GetTotalPcountQty()
        {
            return TotalPcountQty;
        }

         

        #endregion

        #region "Qty (LKG / OVER)"

        public double GetTotalQtyLkgOver()
        {
            return TotalPcountQty - TotalBookQty;
        }

        public string GetTotalQtyLkgOverFormatted()
        {
            // return TotalPcountQty - TotalBookQty;
            double Result = 0;
            string ReturnResult = string.Empty;

            Result = TotalPcountQty - TotalBookQty;

            if (Result < 0)
            {
                Result = Result * (-1);

                ReturnResult = "(" + Result.ToString("0,000") + ")";
            }
            else
            {
                ReturnResult = Result.ToString("0,000");
            }

            return ReturnResult;
        }

        #endregion

        #region "Percent Book Qty"

        public double GetTotalPrecentBookQty()
        {
            return (GetTotalQtyLkgOver() / GetTotalBookQty()) * 100;
        }

        public string GetTotalPrecentBookQtyFormatted()
        {
            double Result = 0;
            string ReturnResult = string.Empty;

            Result = (GetTotalQtyLkgOver() / GetTotalBookQty()) * 100;

            if (Result < 0)
            {
                Result = Result * (-1);

                ReturnResult = "(" + Result.ToString("###,##0.00") + ")";
            }
            else
            {
                ReturnResult = Result.ToString("###,##0.00");
            }

            return ReturnResult;
        }

        #endregion

        //#region "Ending Invty Prevailing"

        //public double TotalEndingInvtPrevailing;

        //public double GetEndingInvtPrevailing(double Price)
        //{
        //    TotalEndingInvtPrevailing += Price;
        //    return Price;
        //}

        //public double GetTotalEndingInvtPrevailing()
        //{
        //    return TotalEndingInvtPrevailing;
        //}

        //#endregion

        //#region "Actual Physical Count Prevailing"

        //public double TotalActualPcountPrevailing;

        //public double GetActualPcountPrevailing(double Price)
        //{
        //    TotalActualPcountPrevailing += Price;
        //    return Price;
        //}

        //public double GetTotalActualPcountPrevailing()
        //{
        //    return TotalActualPcountPrevailing;
        //}

        //#endregion

        //#region "Variance (Lkg/Over)"

        //public double GetTotalVariancePrevailing()
        //{
        //    return GetTotalActualPcountPrevailing() - GetTotalEndingInvtPrevailing();
        //}

        //#endregion

        #region "Ending Invty Cost"

        public double TotalEndingInvtCost;

        public double GrandTotalEndingInvCost;

        public double GetEndingInvtCost(double Price)
        {
            TotalEndingInvtCost += Price;
            return Price;
        }

        public double GetTotalEndingInvtCost()
        {
            return TotalEndingInvtCost;
        }

        #endregion

        #region "Actual Physical Count Cost"

        public double TotalActualPcountCost;

        public double GrandTotalPcountCost;

        public double GetActualPcountCost(double Price)
        {
            TotalActualPcountCost += Price;
            return Price;
        }

        public double GetTotalActualPcountCost()
        {
            return TotalActualPcountCost;
        }

        #endregion

        #region "Variance Cost"

        public double GetTotalVarianceCost()
        {
            return GetTotalActualPcountCost() - GetTotalEndingInvtCost();
        }

        public string GetTotalVarianceCostFormatted()
        {
             
            double Result = 0;
            string ReturnResult = string.Empty;

            Result = GetTotalActualPcountCost() - GetTotalEndingInvtCost();

            if (Result < 0)
            {
                Result = Result * (-1);

                ReturnResult = "(" + Result.ToString("###,###.###") + ")";
            }
            else
            {
                ReturnResult = Result.ToString("###,###.###");
            }

            return ReturnResult;
        }

        #endregion

        #region "Average Per Pcount Cost"

        public double GetTotalAveragePerPcount()
        {
            return GetTotalActualPcountCost() / GetTotalBookQty();
        }

        #endregion

        #region "Percent Cost Lkg"

        public double GetTotalPercentCostLkg()
        {
            return (GetTotalVarianceCost() / GetTotalEndingInvtCost()) * 100;
        }
       
        public string GetTotalPercentCostLkgFormatted()
        {

            double Result = 0;
            string ReturnResult = string.Empty;

            Result = (GetTotalVarianceCost() / GetTotalEndingInvtCost()) * 100;

            if (Result < 0)
            {
                Result = Result * (-1);

                ReturnResult = "(" + Result.ToString("###,##0.000") + ")";
            }
            else
            {
                ReturnResult = Result.ToString("###,##0.000");
            }

            return ReturnResult;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            LoadGridView();
            
        }

        protected void LoadGridView()
        {

            string Date = string.Empty;
            DateTime From;
            DateTime To;

            Date = Session["From"].ToString() + " TO " + Session["To"].ToString();
            From = DateTime.Parse(Session["From"].ToString()).Date;
            To = DateTime.Parse(Session["To"].ToString()).Date;          
            lblDate.Text = Date;
          
            StoreOutStandingInventoryManager SOI = new StoreOutStandingInventoryManager();
           

            #region "MMDS Report"

            TotalBookQty = 0;
            TotalPcountQty = 0;
            TotalEndingInvtCost = 0;
            TotalActualPcountCost = 0;


            List<ConsolidatedSoiPerArea> MMDSResults = SOI.GetSoiByBrandMMDS(From, To);
            List<ConsolidatedSoiPerAreaFormatted> MMDSFormatedView = new List<ConsolidatedSoiPerAreaFormatted>();
            foreach (var item in MMDSResults)
            {
                string FormatBookQty = string.Empty;
                string FormatPercentLkgOvr = string.Empty;
                string FormatEndingInv = string.Empty;
                string formatLackingOver = string.Empty;
                string formatVarianceCost = string.Empty;
                string formatPercentOfCostLacking = string.Empty;


                if (item.BookQuantity < 0)
                {
                    item.BookQuantity = item.BookQuantity * -1;
                    FormatBookQty = item.BookQuantity.ToString("(###,##0)");
                    GetBookQty(item.BookQuantity);
                }
                else
                {
                    FormatBookQty = item.BookQuantity.ToString("###,##0");
                    GetBookQty(item.BookQuantity);
                }

                if (item.LackingOver < 0)
                {
                    item.LackingOver = item.LackingOver * -1;
                    formatLackingOver = item.LackingOver.ToString("(###,##0)");
                }
                else
                {
                    formatLackingOver = item.LackingOver.ToString("###,##0");
                }

                if (item.PercentOfBookOverQty < 0)
                {
                    item.PercentOfBookOverQty = item.PercentOfBookOverQty * -1;
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("(###,##0.00)");
                }
                else
                {
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("###,##0.00");
                }

                if (item.EndingInventory < 0)
                {
                    item.EndingInventory = item.EndingInventory * -1;
                    FormatEndingInv = item.EndingInventory.ToString("(###,##0.00)");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                else
                {
                    FormatEndingInv = item.EndingInventory.ToString("###,##0.00");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                if (item.VarianceCost < 0)
                {
                    item.VarianceCost = item.VarianceCost * -1;
                    formatVarianceCost = item.VarianceCost.ToString("(###,##0.00)");
                }
                else
	            {
	                formatVarianceCost = item.VarianceCost.ToString("###,##0.00");
	            }

                if (item.PercentOfCostLacking < 0)
                {
                    item.PercentOfCostLacking = item.PercentOfCostLacking * -1;
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("(###,##0.00)");
                }
                else
	            {
                     formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("###,##0.00");
	            }

                ConsolidatedSoiPerAreaFormatted rvf = new ConsolidatedSoiPerAreaFormatted
                {                  
                    Brand = item.Brand,
                    BookQuantity = FormatBookQty,
                    ActualPCount = item.ActualPCount,

                    LackingOver = formatLackingOver,
                    PercentOfBookOverQty = FormatPercentLkgOvr,
                    EndingInventory = FormatEndingInv,

                    ActualPCountCost = item.ActualPCountCost.ToString(),
                    VarianceCost = formatVarianceCost,
                    AvePerCost = item.AvePerCost.ToString("###,##0.00"),
                    PercentOfCostLacking = formatPercentOfCostLacking

                };
                MMDSFormatedView.Add(rvf);
            }

            GridView1.DataSource = MMDSFormatedView;
            GridView1.DataBind();

            GrandTotalBookQty = GetTotalBookQty();
            GrandTotalPcountQty = GetTotalPcountQty();
            GrandTotalEndingInvCost = GetTotalEndingInvtCost();
            GrandTotalPcountCost = GetTotalActualPcountCost();

            #endregion


            
 
            #region "Luzon Report"

            TotalBookQty = 0;
            TotalPcountQty = 0;
            TotalEndingInvtCost = 0;
            TotalActualPcountCost = 0;


            List<ConsolidatedSoiPerArea> LuzonResults = SOI.GetSoiByBrandLuzon(From, To);
            List<ConsolidatedSoiPerAreaFormatted> LuzonFormatedView = new List<ConsolidatedSoiPerAreaFormatted>();
            foreach (var item in LuzonResults)
            {
                string FormatBookQty = string.Empty;
                string FormatPercentLkgOvr = string.Empty;
                string FormatEndingInv = string.Empty;
                string formatLackingOver = string.Empty;
                string formatVarianceCost = string.Empty;
                string formatPercentOfCostLacking = string.Empty;

                if (item.BookQuantity < 0)
                {
                    item.BookQuantity = item.BookQuantity * -1;
                    FormatBookQty = item.BookQuantity.ToString("(###,##0)");
                    GetBookQty(item.BookQuantity);
                }
                else
                {
                    FormatBookQty = item.BookQuantity.ToString("###,##0");
                    GetBookQty(item.BookQuantity);
                }

                if (item.LackingOver < 0)
                {
                    item.LackingOver = item.LackingOver * -1;
                    formatLackingOver = item.LackingOver.ToString("(###,##0)");
                }
                else
                {
                    formatLackingOver = item.LackingOver.ToString("###,##0");
                }

                if (item.PercentOfBookOverQty < 0)
                {
                    item.PercentOfBookOverQty = item.PercentOfBookOverQty * -1;
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("(###,##0.00)");
                }
                else
                {
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("###,##0.00");
                }

                if (item.EndingInventory < 0)
                {
                    item.EndingInventory = item.EndingInventory * -1;
                    FormatEndingInv = item.EndingInventory.ToString("(###,##0.00)");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                else
                {
                    FormatEndingInv = item.EndingInventory.ToString("###,##0.00");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                if (item.VarianceCost < 0)
                {
                    item.VarianceCost = item.VarianceCost * -1;
                    formatVarianceCost = item.VarianceCost.ToString("(###,##0.00)");
                }
                else
                {
                    formatVarianceCost = item.VarianceCost.ToString("###,##0.00");
                }

                if (item.PercentOfCostLacking < 0)
                {
                    item.PercentOfCostLacking = item.PercentOfCostLacking * -1;
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("(###,##0.00)");
                }
                else
                {
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("###,##0.00");
                }

                ConsolidatedSoiPerAreaFormatted rvf = new ConsolidatedSoiPerAreaFormatted
                {
                    Brand = item.Brand,
                    BookQuantity = FormatBookQty,
                    ActualPCount = item.ActualPCount,

                    LackingOver = formatLackingOver,
                    PercentOfBookOverQty = FormatPercentLkgOvr,
                    EndingInventory = FormatEndingInv,

                    ActualPCountCost = item.ActualPCountCost.ToString(),
                    VarianceCost = formatVarianceCost,
                    AvePerCost = item.AvePerCost.ToString("###,##0.00"),
                    PercentOfCostLacking = formatPercentOfCostLacking

                };
                LuzonFormatedView.Add(rvf);
            }

            GridView2.DataSource = LuzonFormatedView;
            GridView2.DataBind();

            GrandTotalBookQty += GetTotalBookQty();
            GrandTotalPcountQty += GetTotalPcountQty();
            GrandTotalEndingInvCost += GetTotalEndingInvtCost();
            GrandTotalPcountCost += GetTotalActualPcountCost();

            #endregion


            #region "Visayas Report"

            TotalBookQty = 0;
            TotalPcountQty = 0;
            TotalEndingInvtCost = 0;
            TotalActualPcountCost = 0;


            List<ConsolidatedSoiPerArea> VisayasResults = SOI.GetSoiByBrandVisayas(From, To);
            List<ConsolidatedSoiPerAreaFormatted> VisayasFormatedView = new List<ConsolidatedSoiPerAreaFormatted>();
            foreach (var item in VisayasResults)
            {
                string FormatBookQty = string.Empty;
                string FormatPercentLkgOvr = string.Empty;
                string formatLackingOver = string.Empty;
                string FormatEndingInv = string.Empty;
                string formatVarianceCost = string.Empty;
                string formatPercentOfCostLacking = string.Empty;

                if (item.BookQuantity < 0)
                {
                    item.BookQuantity = item.BookQuantity * -1;
                    FormatBookQty = item.BookQuantity.ToString("(###,##0)");
                    GetBookQty(item.BookQuantity);
                }
                else
                {
                    FormatBookQty = item.BookQuantity.ToString("###,##0");
                    GetBookQty(item.BookQuantity);
                }

                if (item.LackingOver < 0)
                {
                    item.LackingOver = item.LackingOver * -1;
                    formatLackingOver = item.LackingOver.ToString("(###,##0)");
                }
                else
                {
                    formatLackingOver = item.LackingOver.ToString("###,##0");
                }

                if (item.PercentOfBookOverQty < 0)
                {
                    item.PercentOfBookOverQty = item.PercentOfBookOverQty * -1;
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("(###,##0.00)");
                }
                else
                {
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("###,##0.00");
                }

                if (item.EndingInventory < 0)
                {
                    item.EndingInventory = item.EndingInventory * -1;
                    FormatEndingInv = item.EndingInventory.ToString("(###,##0.00)");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                else
                {
                    FormatEndingInv = item.EndingInventory.ToString("###,##0.00");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                if (item.VarianceCost < 0)
                {
                    item.VarianceCost = item.VarianceCost * -1;
                    formatVarianceCost = item.VarianceCost.ToString("(###,##0.00)");
                }
                else
                {
                    formatVarianceCost = item.VarianceCost.ToString("###,##0.00");
                }

                if (item.PercentOfCostLacking < 0)
                {
                    item.PercentOfCostLacking = item.PercentOfCostLacking * -1;
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("(###,##0.00)");
                }
                else
                {
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("###,##0.00");
                }

                ConsolidatedSoiPerAreaFormatted rvf = new ConsolidatedSoiPerAreaFormatted
                {
                    Brand = item.Brand,
                    BookQuantity = FormatBookQty,
                    ActualPCount = item.ActualPCount,

                    LackingOver = formatLackingOver,
                    PercentOfBookOverQty = FormatPercentLkgOvr,
                    EndingInventory = FormatEndingInv,

                    ActualPCountCost = item.ActualPCountCost.ToString(),
                    VarianceCost = formatVarianceCost,
                    AvePerCost = item.AvePerCost.ToString("###,##0.00"),
                    PercentOfCostLacking = formatPercentOfCostLacking

                };
                VisayasFormatedView.Add(rvf);
            }

            GridView3.DataSource = VisayasFormatedView;
            GridView3.DataBind();

            GrandTotalBookQty += GetTotalBookQty();
            GrandTotalPcountQty += GetTotalPcountQty();
            GrandTotalEndingInvCost += GetTotalEndingInvtCost();
            GrandTotalPcountCost += GetTotalActualPcountCost();

            #endregion
            
            #region "Mindanao Report"

            TotalBookQty = 0;
            TotalPcountQty = 0;
            TotalEndingInvtCost = 0;
            TotalActualPcountCost = 0;


            List<ConsolidatedSoiPerArea> MindanaoResults = SOI.GetSoiByBrandMindanao(From, To);
            List<ConsolidatedSoiPerAreaFormatted> MindanaoFormatedView = new List<ConsolidatedSoiPerAreaFormatted>();
            foreach (var item in MindanaoResults)
            {
                string FormatBookQty = string.Empty;
                string FormatPercentLkgOvr = string.Empty;
                string formatLackingOver = string.Empty;
                string FormatEndingInv = string.Empty;
                string formatVarianceCost = string.Empty;
                string formatPercentOfCostLacking = string.Empty;

                if (item.BookQuantity < 0)
                {
                    item.BookQuantity = item.BookQuantity * -1;
                    FormatBookQty = item.BookQuantity.ToString("(###,##0)");
                    GetBookQty(item.BookQuantity);
                }
                else
                {
                    FormatBookQty = item.BookQuantity.ToString("###,##0");
                    GetBookQty(item.BookQuantity);
                }

                if (item.LackingOver < 0)
                {
                    item.LackingOver = item.LackingOver * -1;
                    formatLackingOver = item.LackingOver.ToString("(###,##0)");
                }
                else
                {
                    formatLackingOver = item.LackingOver.ToString("###,##0");
                }

                if (item.PercentOfBookOverQty < 0)
                {
                    item.PercentOfBookOverQty = item.PercentOfBookOverQty * -1;
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("(###,##0.00)");
                }
                else
                {
                    FormatPercentLkgOvr = item.PercentOfBookOverQty.ToString("###,##0.00");
                }

                if (item.EndingInventory < 0)
                {
                    item.EndingInventory = item.EndingInventory * -1;
                    FormatEndingInv = item.EndingInventory.ToString("(###,##0.00)");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                else
                {
                    FormatEndingInv = item.EndingInventory.ToString("###,##0.00");
                    GetEndingInvtCost(double.Parse(item.EndingInventory.ToString()));
                }
                if (item.VarianceCost < 0)
                {
                    item.VarianceCost = item.VarianceCost * -1;
                    formatVarianceCost = item.VarianceCost.ToString("(###,##0.00)");
                }
                else
                {
                    formatVarianceCost = item.VarianceCost.ToString("###,##0.00");
                }

                if (item.PercentOfCostLacking < 0)
                {
                    item.PercentOfCostLacking = item.PercentOfCostLacking * -1;
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("(###,##0.00)");
                }
                else
                {
                    formatPercentOfCostLacking = item.PercentOfCostLacking.ToString("###,##0.00");
                }

                ConsolidatedSoiPerAreaFormatted rvf = new ConsolidatedSoiPerAreaFormatted
                {
                    Brand = item.Brand,
                    BookQuantity = FormatBookQty,
                    ActualPCount = item.ActualPCount,

                    LackingOver = formatLackingOver,
                    PercentOfBookOverQty = FormatPercentLkgOvr,
                    EndingInventory = FormatEndingInv,

                    ActualPCountCost = item.ActualPCountCost.ToString(),
                    VarianceCost = formatVarianceCost,
                    AvePerCost = item.AvePerCost.ToString("###,##0.00"),
                    PercentOfCostLacking = formatPercentOfCostLacking

                };
                MindanaoFormatedView.Add(rvf);
            }

            GridView4.DataSource = MindanaoFormatedView;
            GridView4.DataBind();

            GrandTotalBookQty += GetTotalBookQty();
            GrandTotalPcountQty += GetTotalPcountQty();
            GrandTotalEndingInvCost += GetTotalEndingInvtCost();
            GrandTotalPcountCost += GetTotalActualPcountCost();

            #endregion

         

            lblQtyGrandtotal.Text = GrandTotalBookQty.ToString("###,###,##0");
            lblPcountGrandTotal.Text = GrandTotalPcountQty.ToString("###,###,##0");
            lblEndingInvGrandTotal.Text = GrandTotalEndingInvCost.ToString("###,###,##0.00");
            lblPcountCostGrandTotal.Text = GrandTotalPcountCost.ToString("###,###,##0.00");



            double QtyLkgOverGrandTotal = Convert.ToDouble(GrandTotalPcountQty - GrandTotalBookQty);
            if (QtyLkgOverGrandTotal < 0)
            {
                QtyLkgOverGrandTotal = QtyLkgOverGrandTotal * -1;
                lblQtyLkgOverGrandTotal.Text = "(" + QtyLkgOverGrandTotal.ToString("###,###,##0") + ")";
            }
            else
            {
                lblQtyLkgOverGrandTotal.Text = QtyLkgOverGrandTotal.ToString("###,###,##0");
            }


            double PercentLkgOverGrandTotal = Convert.ToDouble(QtyLkgOverGrandTotal / GrandTotalBookQty * 100);
            if (PercentLkgOverGrandTotal < 0)
            {
                PercentLkgOverGrandTotal = PercentLkgOverGrandTotal * -1;
                lblPercentLkgOverGrandTotal.Text = "(" + PercentLkgOverGrandTotal.ToString("###,###,##0.00") + ")";
            }
            else
            {
                lblPercentLkgOverGrandTotal.Text = PercentLkgOverGrandTotal.ToString("###,###,##0.00");
            }

            double VarianceGrandTotal = Convert.ToDouble(GrandTotalPcountCost - GrandTotalEndingInvCost);
            if (VarianceGrandTotal < 0)
            {
                VarianceGrandTotal = VarianceGrandTotal * -1;
                lblVarianceGrandTotal.Text = "(" + VarianceGrandTotal.ToString("###,###,##0.00") + ")";
            }
            else
            {
                lblVarianceGrandTotal.Text = VarianceGrandTotal.ToString("###,###,##0.00");
            }


            double AvgGrandTotal = Convert.ToDouble(GrandTotalPcountCost / GrandTotalBookQty);
            if (AvgGrandTotal < 0)
            {
                AvgGrandTotal = AvgGrandTotal * -1;
                lblAvgGrandTotal.Text = "(" + AvgGrandTotal.ToString("###,###,##0.00") + ")";
            }
            else
            {
                lblAvgGrandTotal.Text = AvgGrandTotal.ToString("###,###,##0.00");
            }

            double PercentCostLkgGrandTotal = Convert.ToDouble(VarianceGrandTotal / GrandTotalEndingInvCost * 100);
            if (PercentCostLkgGrandTotal < 0)
            {
                PercentCostLkgGrandTotal = PercentCostLkgGrandTotal * -1;
                lblPercentCostLkgGrandTotal.Text = "(" + PercentCostLkgGrandTotal.ToString("###,###,##0.00") + ")";
            }
            else
            {
                lblPercentCostLkgGrandTotal.Text = PercentCostLkgGrandTotal.ToString("###,###,##0.00");
            }
          

          

        }

      
    }
}