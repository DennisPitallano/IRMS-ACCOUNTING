using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using System.Data;
using BLToolkit.Data;
using System.Web.UI.WebControls;
using IRMS.ObjectModel.Views;

namespace IRMS.BusinessLogic.Manager
{
    public class StockCardReportManager
    {
        #region Accessor
        StockCardReportAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return StockCardReportAccessor.CreateInstance(); }
        }
        #endregion

        public StockCardReport GetBeginningOnStockCard(long CustNo, DateTime PeriodDate)
        {
            
            return Accessor.GetBeginningOnStockCard(CustNo, PeriodDate);
        }

        public bool HasRecord(long CustNo, DateTime PeriodDate)
        {
            DbManager db = new DbManager("IRMSConnectionString");
            bool bResult = false;
            db.SelectCommand.CommandText = string.Format(@"select top 1 balance_qty, balance_amt, balance_cost 
                    from rptstockcard_new 
                    where dateto='{0}' and custno={1} 
                    order by id desc",PeriodDate.ToShortDateString(),CustNo);
            using (IDataReader dbReader = db.ExecuteReader())
            {
                bResult = dbReader.Read();
                dbReader.Close();
            }
            return bResult;
        }

        public List<ViewSummaryOfMonthlyInventoryPerBrand> GetSummaryOfMonthlyInventoryPerBrand(DateTime Dfrom, DateTime Dto, string Bname, string users, int stat)
        {

            List<ViewSummaryOfMonthlyInventoryPerBrand> Rec = new List<ViewSummaryOfMonthlyInventoryPerBrand>();
            Rec.Clear();
           

            if (stat == 1) //Dept
            {
                Rec = Accessor.SummaryOfMonthlyInventoryPerBrandDept(Dfrom, Dto, Bname, users);
               
            }
            else if (stat == 2) // Prov
            {
                Rec = Accessor.SummaryOfMonthlyInventoryPerBrandProvincial(Dfrom, Dto, Bname, users);
            }
            else if (stat == 3) // Botiq
            {
                Rec = Accessor.SummaryOfMonthlyInventoryPerBrandBotique(Dfrom, Dto, Bname, users);
            }
            return Rec;
           
        }

        public StockCardReport IsHasRecord(long CustNo, DateTime PeriodDate)
        {
            StockCardReport SCRpt = new StockCardReport();
            try
            {
                SCRpt = GetBeginningOnStockCard(CustNo, PeriodDate);
            }
            catch(Exception)
            {
                SCRpt = new StockCardReport();
                //SCRpt = null;
            }
            return SCRpt;
        }

        public StoreOutStandingInventory GetBeginningOnSOI(long CustNo, DateTime PeriodDate)
        {
            return Accessor.GetBeginningOnSOI(CustNo, PeriodDate);
        }

        public StoreOutStandingInventory IsHasRecordOnSOI(long CustNo, DateTime PeriodDate)
        {
            StoreOutStandingInventory SOI = new StoreOutStandingInventory();
            try
            {
                SOI = GetBeginningOnSOI(CustNo, PeriodDate);
            }
            catch (Exception)
            {
                SOI = new StoreOutStandingInventory();
                //  ..throw;
            }
            return SOI;
        }

        public DataTable GetBeginningOnPCountBridge(long CustNo, DateTime DateFrom, DateTime DateTo)
        {
            return Accessor.GetBeginningOnPCountBridge(CustNo, DateFrom, DateTo);
        }
    }
}   
