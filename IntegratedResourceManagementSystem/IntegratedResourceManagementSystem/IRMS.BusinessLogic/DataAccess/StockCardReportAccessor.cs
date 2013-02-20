using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using System.Data;
using IRMS.ObjectModel.Views;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class StockCardReportAccessor : AccessorBase<StockCardReportAccessor.DB, StockCardReportAccessor>
    {
        public class DB : DbManager
        {
            public DB()
                : base("IRMSConnectionString")
            {
            }
        }



        [SqlQuery(@"select top 1 balance_qty, balance_amt, balance_cost 
                    from rptstockcard_new 
                    where dateto=@DatePeriod and custno=CustNo 
                    order by id desc")]
        public abstract StockCardReport GetBeginningOnStockCard(long CustNo, DateTime DatePeriod);

        [SqlQuery(@"select ACTUAL_COUNT_VOLUME, ACTUAL_COUNT_VALUE, ACTUAL_COUNT_TOTAL_COST 
                    from STORE_OUTSTANDING_INVENTORIES
                    where CUSTOMER_NO=@CustNo and PERIOD_TO=@DatePeriod")]
        public abstract StoreOutStandingInventory GetBeginningOnSOI(long CustNo, DateTime DatePeriod);

        [SqlQuery(@"select actualQTY, actualAMT, TotalCost
                    from bridge_PCount
                    where CustNo=@CustNo and asofDate between @DateFrom and @DateTo"), DataSetTable("PCount_Bridge")]
        public abstract DataTable GetBeginningOnPCountBridge(long CustNo, DateTime DateFrom, DateTime DateTo);

        [SprocName("GenRptSummaryofMonthlyInvPerBrandProvNew"), DataSetTable("SummaryOfMonthlyInventoryPerBrandDataSet")]
        public abstract List<ViewSummaryOfMonthlyInventoryPerBrand> SummaryOfMonthlyInventoryPerBrandProvincial(DateTime datefrom, DateTime dateto, string brANDname, string username);

        [SprocName("GenRptSummaryofMonthlyInvPerBrandDeptNew"), DataSetTable("SummaryOfMonthlyInventoryPerBrandDataSet")]
        public abstract List<ViewSummaryOfMonthlyInventoryPerBrand> SummaryOfMonthlyInventoryPerBrandDept(DateTime datefrom, DateTime dateto, string brANDname, string username);

        [SprocName("GenRptSummaryofMonthlyInvPerBrandBoutiqueNew"), DataSetTable("SummaryOfMonthlyInventoryPerBrandDataSet")]
        public abstract List<ViewSummaryOfMonthlyInventoryPerBrand> SummaryOfMonthlyInventoryPerBrandBotique(DateTime datefrom, DateTime dateto, string brANDname, string username);



    }
}
