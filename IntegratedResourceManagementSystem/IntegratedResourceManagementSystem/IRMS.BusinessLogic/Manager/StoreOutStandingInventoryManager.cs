using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using BLToolkit.Data;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.Manager
{
    public class StoreOutStandingInventoryManager : LogManager<StoreOutStandingInventory>
    {
        #region Accessor

        private StoreOutStandingInventoryAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return StoreOutStandingInventoryAccessor.CreateInstance(); }
        }

        #endregion Accessor

        public DataTable CustomerReturnSlipDetailsForSOIByCustomerNumberAndByPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo)
        {
            return Accessor.CustomerReturnSlipDetailsForSOIByCustomerNumberAndByPeriod(customerNumber, periodFrom, periodTo);
        }

        public DataTable CustomerReturnSlipDetailsForSOIReturnQuantityAndAmount(long CRSID)
        {
            return Accessor.CustomerReturnSlipDetailsForSOIReturnQuantityAndAmount(CRSID);
        }

        public void Delete(StoreOutStandingInventory SOI)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, SOI);
            }
        }

        public List<StoreOutStandingInventory> FetchAllStoreOutStandingInventory()
        {
            using (DbManager db = new DbManager())
            {
                return Accessor.Query.SelectAll<StoreOutStandingInventory>();
            }
        }

        /// <summary>
        /// Get Customer Return Slip by Customer and Period.
        /// </summary>
        /// <param name="customerNumber">Customer Number</param>
        /// <param name="periodFrom">Period From</param>
        /// <param name="periodTo">Period To</param>
        /// <returns>DataTable</returns>
        public decimal GetCustomerReturnSlipByCustomerAndPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo)
        {
            DataTable details = Accessor.CustomerReturnSlipForSOIByCustomerNumberAndByPeriod(customerNumber, periodFrom, periodTo);
            decimal results = 0;
            foreach (DataRow row in details.Rows)
            {
                results = decimal.Parse(row[0].ToString());
            }
            return results;
        }

        public DataTable GetDataTableStoreOutStandingInventoryByRecordNumber(long RecordNumber)
        {
            return Accessor.GetDataTableStoreOutStandingInventoryByRecordNumber(RecordNumber);
        }

        public DataTable GetDataTableStoreOutStandingInventoryGrossSalesBreakDown(long CustomerNumber, int Moth1, int Moth2, int Year1, int Year2)
        {
            return Accessor.GetDataTableStoreOutStandingInventoryBreakDownGrossSalesSummaryByCustomerNumberAndPeriod(CustomerNumber,
                Moth1, Moth2, Year1, Year2);
        }

        public DataTable GetDataTableStoreOutStandingInventoryGrossSalesSummary(long CustomerNumber, int Moth1, int Moth2, int Year1, int Year2)
        {
            return Accessor.GetDataTableStoreOutStandingInventoryGrossSalesSummaryByCustomerNumberAndPeriod(CustomerNumber,
                Moth1, Moth2, Year1, Year2);
        }

        public DataTable GetDataTableStoreOutStandingInventoryPhysicalCountBreakdown(long CustomerNumber, DateTime DateYear)
        {
            return Accessor.GetDataTableStoreOutStandingInventoryPhysicalCountBreakdownByCustomerNumberAndByPeriod(CustomerNumber,
                DateYear.Year);
        }

        public DataTable GetDataTableStoreOutStandingInventoryPhysiclCountSummary(long CustomerNumber, DateTime DateFrom, DateTime DateTo)
        {
            return Accessor.GetDataTableStoreOutStandingInventoryPhysicalCountSummaryByCustomerNumberAndByPeriod(CustomerNumber,
                DateFrom, DateTo);
        }

        public DataTable GetDataTableStoreOutStandingInventoryPhysiclCountSummary1(long CustomerNumber, DateTime DateFrom, DateTime DateTo)
        {
            return Accessor.GetDataTableStoreOutStandingInventoryPhysicalCountSummaryByCustomerNumberAndByPeriod1(CustomerNumber,
                DateFrom, DateTo);
        }

        /// <summary>
        /// Get DR total cost and quantity
        /// </summary>
        /// <param name="GetDeliveryReceiptDetailsByCustomerAndPeriod"></param>
        /// <returns></returns>
        public decimal[] GetDeliveryDetailsTotalQuantityAndTotalCost(DataTable GetDeliveryReceiptDetailsByCustomerAndPeriod)
        {
            decimal[] results = new decimal[2];
            results[0] = 0;
            results[1] = 0;

            foreach (DataRow row in GetDeliveryReceiptDetailsByCustomerAndPeriod.Rows)
            {
                decimal[] result = GetDeliveryDetailsTotalQuantityAndTotalCost(long.Parse(row[0].ToString()));
                results[0] += result[0];
                results[1] += result[1];
            }
            return results;
        }

        //CTS 2012-04-13
        public decimal[] GetDeliveryDetailsTotalQuantityAndTotalCost(long customerNumber, DateTime periodFrom, DateTime periodTo)
        {
            //DataTable dTable = Accessor.GetDRTotalQuantityAndCost(customerNumber, periodFrom, periodTo);
            DataTable dTable = Accessor.GetDRTotalQuantityAndCost_SP(customerNumber, periodFrom, periodTo);
            decimal[] results = new decimal[2];
            results[0] = 0;
            results[1] = 0;

            foreach (DataRow row in dTable.Rows)
            {
                results[0] = decimal.Parse(row[0].ToString());
                results[1] = decimal.Parse(row[1].ToString());
            }

            return results;
        }

        public DataTable GetDeliveryReceiptDetailsByCustomerAndPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo)
        {
            return Accessor.DeliveryReceiptDetailsForSOIByCustomerNumberAndByPeriod_SP(customerNumber, periodFrom, periodTo);
        }

        public decimal[] GetDeliveryVolumeAndAmountByCustomerAndPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo)
        {
            DataTable details = Accessor.DeliveryForSOIByCustomerNumberAndByPeriod_SP(customerNumber, periodFrom, periodTo);
            decimal[] results = new decimal[2];
            foreach (DataRow row in details.Rows)
            {
                results[0] = decimal.Parse(row[0].ToString());
                results[1] = decimal.Parse(row[1].ToString());
            }
            return results;
        }

        /// <summary>
        /// get crs total quantity and amount
        /// </summary>
        /// <param name="CRSByCustumerAndPeriod"></param>
        /// <returns></returns>
        public decimal[] GetReturnsQuantityAndAmountDetailsForSOI(DataTable CRSByCustumerAndPeriod)
        {
            decimal[] results = new decimal[2];
            try
            {
                foreach (DataRow row in CRSByCustumerAndPeriod.Rows)
                {
                    results[0] += GetReturnsTotalQuantityAndTotalAmountForSOI(long.Parse(row[0].ToString()))[0];
                    results[1] += GetReturnsTotalQuantityAndTotalAmountForSOI(long.Parse(row[0].ToString()))[1];
                }
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
            }
            return results;
        }

        public decimal[] GetReturnsTotalCosAmountDetailsForSOI(DataTable CRSByCustumerAndPeriod)
        {
            decimal[] results = new decimal[2];
            try
            {
                foreach (DataRow row in CRSByCustumerAndPeriod.Rows)
                {
                    results[0] += GetReturnsTotalCostAmountForSOI(long.Parse(row[0].ToString()))[0];
                    results[1] += GetReturnsTotalCostAmountForSOI(long.Parse(row[0].ToString()))[1];
                }
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
            }
            return results;
        }

        //CTS 2012-04-16
        public decimal[] GetReturnsTotalCostAmountDetailsForSOI(long customerNumber, DateTime periodFrom, DateTime periodTo)
        {
            DataTable dTable = Accessor.GetCRSTotalQuantityAndCost_SP(customerNumber, periodFrom, periodTo);
            decimal[] results = new decimal[2];
            results[0] = 0;
            results[1] = 0;

            foreach (DataRow row in dTable.Rows)
            {
                results[0] = decimal.Parse(row[0].ToString());
                results[1] = decimal.Parse(row[1].ToString());
            }

            return results;
        }

        public StoreOutStandingInventory GetStoreOutStandingInventoryBeginningInventory(long CustomerNumber, DateTime DateTo)
        {
            StoreOutStandingInventory soi = new StoreOutStandingInventory();
            var soi_ = (from _soi in StoreOutStandingInventories()
                        where _soi.CustomerNumber == CustomerNumber && _soi.PeriodTo.Month == DateTo.AddMonths(-1).Month && _soi.PeriodTo.Year == DateTo.Year
                        select _soi).ToList<StoreOutStandingInventory>();
            foreach (StoreOutStandingInventory _soi_ in soi_)
            {
                soi = _soi_;
            }
            return soi;
        }

        public StoreOutStandingInventory GetStoreOutStandingInventoryByRecordNumber(long RecordNumber)
        {
            return Accessor.GetStoreOutStandingInventoryByRecordNumber(RecordNumber);
        }

        public StoreOutStandingInventory GetStoreOutStandingInventoryForBeginningInventory(long CustomerNumber)
        {
            return Accessor.GetStoreOutStandingInventoryForBeginningInventory(CustomerNumber);
        }

        public bool IsAlreadyGenerated(long CustomerNumber, DateTime PeriodFrom, DateTime PeriodTo)
        {
            bool result = false;
            var count = (from soi in FetchAllStoreOutStandingInventory()
                         where soi.CustomerNumber == CustomerNumber && soi.PeriodFrom == PeriodFrom && soi.PeriodTo == PeriodTo
                         select soi).ToList().Count;
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        //CTS 2012-04-13

        public StoreOutStandingInventory IsHasSOIRecord(long CustomerNumber)
        {
            StoreOutStandingInventory SOI = new StoreOutStandingInventory();

            try
            {
                SOI = GetStoreOutStandingInventoryForBeginningInventory(CustomerNumber);
            }
            catch (Exception)
            {
                SOI = new StoreOutStandingInventory();

                //  ..throw;
            }
            return SOI;
        }

        public void Save(StoreOutStandingInventory SOI)
        {
            using (DbManager db = new DbManager())
            {
                Identity = Accessor.Query.InsertAndGetIdentity(db, SOI);
            }
        }

        ///Transactions Methods
        ///
        public List<StoreOutStandingInventory> StoreOutStandingInventories()
        {
            return Accessor.Query.SelectAll<StoreOutStandingInventory>();
        }

        private decimal[] GetDeliveryDetailsTotalQuantityAndTotalCost(long DRID)
        {
            DataTable details = Accessor.DeliveryReceiptDetailsTotalQuantityAndCost_SP(DRID);
            decimal[] results = new decimal[2];

            try
            {
                foreach (DataRow row in details.Rows)
                {
                    results[0] = decimal.Parse(row[0].ToString());
                    results[1] = decimal.Parse(row[1].ToString());
                }
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
                //throw;
            }
            return results;
        }

        private decimal[] GetReturnsTotalCostAmountForSOI(long CRSID)
        {
            DataTable details = Accessor.CustomerReturnSlipDetailsTotalQuantityAndCost(CRSID);
            decimal[] results = new decimal[2];
            try
            {
                foreach (DataRow row in details.Rows)
                {
                    results[0] = decimal.Parse(row[0].ToString());
                    results[1] = decimal.Parse(row[1].ToString());
                }
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
                //throw;
            }
            return results;
        }

        private decimal[] GetReturnsTotalQuantityAndTotalAmountForSOI(long CRSID)
        {
            DataTable details = Accessor.CustomerReturnSlipDetailsForSOIReturnTotalQuantityAndTotalAmount(CRSID);
            decimal[] results = new decimal[2];
            try
            {
                foreach (DataRow row in details.Rows)
                {
                    results[0] = decimal.Parse(row[0].ToString());
                    results[1] = decimal.Parse(row[1].ToString());
                }
            }
            catch (Exception)
            {
                results[0] = 0;
                results[1] = 0;
                //throw;
            }
            return results;
        }

        //CTS 2012-04-16

        #region "search_outlets"

        public SqlDataSource SearchOutletDataSource(SqlDataSource sql_data_source, string search_parameter, string Brand)
        {
            string search_query = string.Empty;

            //if (Brand != "ALL")
            //{
            //    search_query = "SELECT [CustNo], [CompName], [CustCode], [CustType], [brand], [BrandNameNo], [ArrangeType], [Addr1] FROM [CustInfo] where Brand='"+
            //        Brand +"'";
            //    if (search_parameter != string.Empty)
            //    {
            //        search_query += " AND CompName Like '%" + search_parameter + "%' ";
            //    }
            //}
            //else
            //{
            search_query = "SELECT [CustNo], [CompName], [CustCode], [CustType], [brand], [BrandNameNo], [ArrangeType], [Addr1] FROM [CustInfo] ";
            if (search_parameter != string.Empty)
            {
                search_query += " where CompName Like '%" + search_parameter + "%' ";
            }

            //}
            sql_data_source.SelectCommand = search_query;
            sql_data_source.DataBind();
            return sql_data_source;
        }

        #endregion "search_outlets"

        #region search soi

        public SqlDataSource SearchSOIDataSource(SqlDataSource soi_data_source, string search_parameter, string Brand)
        {
            string search_query = string.Empty;

            //if (Brand != "ALL")
            //{
            //    search_query = "SELECT [RECORD_NO],[CUSTOMER],[PERIOD_FROM],[PERIOD_TO],[DATE_RECORDED] FROM [STORE_OUTSTANDING_INVENTORIES] inner join CustInfo on STORE_OUTSTANDING_INVENTORIES.Customer_no=CustInfo.CustNo  where CustInfo.Brand='"+ Brand +"'";
            //    if (search_parameter != string.Empty)
            //    {
            //        search_query += " AND [CUSTOMER] LIKE '%" + search_parameter + "%' ";
            //    }
            //}
            //else
            //{
            search_query = "SELECT [RECORD_NO],[CUSTOMER],[PERIOD_FROM],[PERIOD_TO],[DATE_RECORDED] FROM [STORE_OUTSTANDING_INVENTORIES] ";
            if (search_parameter != string.Empty)
            {
                search_query += " where [CUSTOMER] LIKE '%" + search_parameter + "%' ";
            }

            //}

            search_query += " ORDER BY DATE_RECORDED DESC";
            soi_data_source.SelectCommand = search_query;
            soi_data_source.DataBind();
            return soi_data_source;
        }

        #endregion search soi

        #region "SUMMARY OF STORE INVENTORY REPORT"

        public IEnumerable<object> GetSoiByStoreMMDS(string BrandName, int CustType, DateTime From, DateTime To)
        {

            CustomerManager CI = new CustomerManager();
            CustomerInventoryGroupManager CIG = new CustomerInventoryGroupManager();
            InventoryGroupManager IGM = new InventoryGroupManager();

            var Results = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber

                           join CusGrp in CIG.CustomersInventoryGroup()
                           on Cus.CustomerNumber equals CusGrp.CustomerNumber

                           join InvGrp in IGM.InventoryGroups()
                           on CusGrp.InventoryGroupId equals InvGrp.InventoryGroupId


                           where InvGrp.InventoryGroupId.Equals(CustType) && Soi.Brand.Equals(BrandName) && Cus.AGNumber.Equals(1)
                           && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date

                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               LkgOverQty = Soi.ActualCountVolume - Soi.EndingInventoryVolume,
                               PercentageQty = (//Soi.EndingInventoryVolume == 0 ? 0 :
                                   //Soi.ActualCountVolume == 0 ? 0 :
                                               (Soi.ActualCountVolume - Soi.EndingInventoryVolume) / Soi.EndingInventoryVolume
                                               ),
                               //EndingInventoryValue = Soi.EndingInventoryValue,
                               //ActualCountValue = Soi.ActualCountValue,
                               //VarianceValue = Soi.ActualCountValue - Soi.EndingInventoryValue,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost,
                               VarianceCost = Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost,
                               AveragePerPc = (Soi.ActualCostTotalCost == 0 ? 0 :
                                               Soi.ActualCountVolume == 0 ? 0 :
                                               Soi.ActualCostTotalCost / Soi.ActualCountVolume),
                               PercentCostLkgBook = ( // Soi.ActualCostTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryValue == 0 ? 0 :
                                                       (Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost) / Soi.EndingInventoryTotalCost)
                           }).ToList();

            return Results;
        }

        public IEnumerable<object> GetSoiByStoreLuzon(string BrandName, int CustType, DateTime From, DateTime To)
        {

            CustomerManager CI = new CustomerManager();
            CustomerInventoryGroupManager CIG = new CustomerInventoryGroupManager();
            InventoryGroupManager IGM = new InventoryGroupManager();

            var Results = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber

                           join CusGrp in CIG.CustomersInventoryGroup()
                           on Cus.CustomerNumber equals CusGrp.CustomerNumber

                           join InvGrp in IGM.InventoryGroups()
                           on CusGrp.InventoryGroupId equals InvGrp.InventoryGroupId


                           where InvGrp.InventoryGroupId.Equals(CustType) && Soi.Brand.Equals(BrandName) && (Cus.AGNumber.Equals(2) || Cus.AGNumber.Equals(3))
                           && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date

                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               LkgOverQty = Soi.ActualCountVolume - Soi.EndingInventoryVolume,
                               PercentageQty = (//Soi.EndingInventoryVolume == 0 ? 0 :
                                   //Soi.ActualCountVolume == 0 ? 0 :
                                               (Soi.ActualCountVolume - Soi.EndingInventoryVolume) / Soi.EndingInventoryVolume
                                               ),
                               //EndingInventoryValue = Soi.EndingInventoryValue,
                               //ActualCountValue = Soi.ActualCountValue,
                               //VarianceValue = Soi.ActualCountValue - Soi.EndingInventoryValue,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost,
                               VarianceCost = Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost,
                               AveragePerPc = (Soi.ActualCostTotalCost == 0 ? 0 :
                                               Soi.ActualCountVolume == 0 ? 0 :
                                               Soi.ActualCostTotalCost / Soi.ActualCountVolume),
                               PercentCostLkgBook = ( // Soi.ActualCostTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryValue == 0 ? 0 :
                                                       (Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost) / Soi.EndingInventoryTotalCost)
                           }).ToList();

            return Results;
        }

        public IEnumerable<object> GetSoiByStoreVisayas(string BrandName, int CustType, DateTime From, DateTime To)
        {

            CustomerManager CI = new CustomerManager();
            CustomerInventoryGroupManager CIG = new CustomerInventoryGroupManager();
            InventoryGroupManager IGM = new InventoryGroupManager();

            var Results = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber

                           join CusGrp in CIG.CustomersInventoryGroup()
                           on Cus.CustomerNumber equals CusGrp.CustomerNumber

                           join InvGrp in IGM.InventoryGroups()
                           on CusGrp.InventoryGroupId equals InvGrp.InventoryGroupId


                           where InvGrp.InventoryGroupId.Equals(CustType) && Soi.Brand.Equals(BrandName) && Cus.AGNumber.Equals(4)
                           && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date

                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               LkgOverQty = Soi.ActualCountVolume - Soi.EndingInventoryVolume,
                               PercentageQty = (//Soi.EndingInventoryVolume == 0 ? 0 :
                                   //Soi.ActualCountVolume == 0 ? 0 :
                                               (Soi.ActualCountVolume - Soi.EndingInventoryVolume) / Soi.EndingInventoryVolume
                                               ),
                               //EndingInventoryValue = Soi.EndingInventoryValue,
                               //ActualCountValue = Soi.ActualCountValue,
                               //VarianceValue = Soi.ActualCountValue - Soi.EndingInventoryValue,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost,
                               VarianceCost = Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost,
                               AveragePerPc = (Soi.ActualCostTotalCost == 0 ? 0 :
                                               Soi.ActualCountVolume == 0 ? 0 :
                                               Soi.ActualCostTotalCost / Soi.ActualCountVolume),
                               PercentCostLkgBook = ( // Soi.ActualCostTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryValue == 0 ? 0 :
                                                       (Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost) / Soi.EndingInventoryTotalCost)
                           }).ToList();

            return Results;
        }

        public IEnumerable<object> GetSoiByStoreMindanao(string BrandName, int CustType, DateTime From, DateTime To)
        {

            CustomerManager CI = new CustomerManager();
            CustomerInventoryGroupManager CIG = new CustomerInventoryGroupManager();
            InventoryGroupManager IGM = new InventoryGroupManager();

            var Results = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber

                           join CusGrp in CIG.CustomersInventoryGroup()
                           on Cus.CustomerNumber equals CusGrp.CustomerNumber

                           join InvGrp in IGM.InventoryGroups()
                           on CusGrp.InventoryGroupId equals InvGrp.InventoryGroupId


                           where InvGrp.InventoryGroupId.Equals(CustType) && Soi.Brand.Equals(BrandName) && Cus.AGNumber.Equals(5)
                           && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date

                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               LkgOverQty = Soi.ActualCountVolume - Soi.EndingInventoryVolume,
                               PercentageQty = (//Soi.EndingInventoryVolume == 0 ? 0 :
                                   //Soi.ActualCountVolume == 0 ? 0 :
                                               (Soi.ActualCountVolume - Soi.EndingInventoryVolume) / Soi.EndingInventoryVolume
                                               ),
                               EndingInventoryValue = Soi.EndingInventoryValue,
                               ActualCountValue = Soi.ActualCountValue,
                               VarianceValue = Soi.ActualCountValue - Soi.EndingInventoryValue,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost,
                               VarianceCost = Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost,
                               AveragePerPc = (Soi.ActualCostTotalCost == 0 ? 0 :
                                               Soi.ActualCountVolume == 0 ? 0 :
                                               Soi.ActualCostTotalCost / Soi.ActualCountVolume),
                               PercentCostLkgBook = ( // Soi.ActualCostTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryTotalCost == 0 ? 0 :
                                   //Soi.EndingInventoryValue == 0 ? 0 :
                                                       (Soi.ActualCostTotalCost - Soi.EndingInventoryTotalCost) / Soi.EndingInventoryTotalCost)
                           }).ToList();

            return Results;
        }


        #endregion

        #region "CONSOLIDATED OF SOI REPORT"

        public IEnumerable<object> GetSoiByBrandMMDS(DateTime From, DateTime To)
        {
            
            BrandManager BM = new BrandManager();
            CustomerManager CI = new CustomerManager();

            var Queries = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber
                           where Cus.AGNumber.Equals(1)
                                 && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date
                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost

                           }).ToList();


             var Results = (from X in BM.Brands()
                          select new
                          {
                              BrandName = X.BrandDescription,
                              EndingInventoryVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),

                              ActualCountVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume),
                              LkgOverQty = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume)
                                           -
                                           Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),                                         
                              PercentageQty = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                               -
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)) == 0 ? 0:

                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume)) 
                                               -
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume))
                                              /
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)),
                              EndingInventoryCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                              ActualCountCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost),                                                           
                              VarianceCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost)
                                             -
                                             Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),                              
                              AveragePerPc = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(A => A.ActualCountCost)) == 0 ? 0:
                                             (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(V => V.ActualCountVolume)) == 0 ? 0:
                                             (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost)) 
                                              /
                                             (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(O => O.ActualCountVolume)),
                              PercentCostLkgBook = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                   -
                                                   (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost)) == 0 ? 0:                                                 
                                                   (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost)) 
                                                    -
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))
                                                    /
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))

                          }).ToList();

            return Results;         
        }

        public IEnumerable<object> GetSoiByBrandLuzon(DateTime From, DateTime To)
        {
            BrandManager BM = new BrandManager();
            CustomerManager CI = new CustomerManager();

            var Queries = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber
                           where (Cus.AGNumber.Equals(2) || Cus.AGNumber.Equals(3))
                                 && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date
                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost

                           }).ToList();


            var Results = (from X in BM.Brands()
                           select new
                           {
                               BrandName = X.BrandDescription,
                               EndingInventoryVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),
                               ActualCountVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume),
                               LkgOverQty = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume)
                                            -
                                            Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),
                               PercentageQty = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                                -
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)) == 0 ? 0 :

                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                                -
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume))
                                               /
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)),
                               EndingInventoryCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                               ActualCountCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost),
                               VarianceCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost)
                                              -
                                              Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                               AveragePerPc = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(A => A.ActualCountCost)) == 0 ? 0 :
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(V => V.ActualCountVolume)) == 0 ? 0 :
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                               /
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(O => O.ActualCountVolume)),
                               PercentCostLkgBook = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                    -
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost)) == 0 ? 0 :
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                     -
                                                     (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))
                                                     /
                                                     (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))

                           }).ToList();

            return Results;         
 
        }

        public IEnumerable<object> GetSoiByBrandVisayas(DateTime From, DateTime To)
        {
            BrandManager BM = new BrandManager();
            CustomerManager CI = new CustomerManager();

            var Queries = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber
                           where Cus.AGNumber.Equals(4)
                                 && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date
                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost

                           }).ToList();


            var Results = (from X in BM.Brands()
                           select new
                           {
                               BrandName = X.BrandDescription,
                               EndingInventoryVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),
                               ActualCountVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume),
                               LkgOverQty = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume)
                                            -
                                            Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),
                               PercentageQty = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                                -
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)) == 0 ? 0 :

                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                                -
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume))
                                               /
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)),
                               EndingInventoryCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                               ActualCountCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost),
                               VarianceCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost)
                                              -
                                              Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                               AveragePerPc = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(A => A.ActualCountCost)) == 0 ? 0 :
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(V => V.ActualCountVolume)) == 0 ? 0 :
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                               /
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(O => O.ActualCountVolume)),
                               PercentCostLkgBook = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                    -
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost)) == 0 ? 0 :
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                     -
                                                     (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))
                                                     /
                                                     (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))
                           }).ToList();

            return Results;     

        }

        public IEnumerable<object> GetSoiByBrandMindanao(DateTime From, DateTime To)
        {
            BrandManager BM = new BrandManager();
            CustomerManager CI = new CustomerManager();

            var Queries = (from Soi in FetchAllStoreOutStandingInventory()

                           join Cus in CI.AllCustomers()
                           on Soi.CustomerNumber equals Cus.CustomerNumber
                           where Cus.AGNumber.Equals(5)
                                 && Soi.PeriodTo >= From.Date && Soi.PeriodTo <= To.Date
                           select new
                           {
                               CustomerNames = Soi.CustomerName,
                               Brand = Soi.Brand,
                               DateRecorded = Soi.DateRecorded,
                               EndingInventoryVolume = Soi.EndingInventoryVolume,
                               ActualCountVolume = Soi.ActualCountVolume,
                               EndingInventoryCost = Soi.EndingInventoryTotalCost,
                               ActualCountCost = Soi.ActualCostTotalCost

                           }).ToList();


            var Results = (from X in BM.Brands()
                           select new
                           {
                               BrandName = X.BrandDescription,
                               EndingInventoryVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),
                               ActualCountVolume = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume),
                               LkgOverQty = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume)
                                            -
                                            Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume),
                               PercentageQty = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                                -
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)) == 0 ? 0 :

                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountVolume))
                                                -
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume))
                                               /
                                               (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryVolume)),
                               EndingInventoryCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                               ActualCountCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost),
                               VarianceCost = Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost)
                                              -
                                              Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost),
                               AveragePerPc = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(A => A.ActualCountCost)) == 0 ? 0 :
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(V => V.ActualCountVolume)) == 0 ? 0 :
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                               /
                                              (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(O => O.ActualCountVolume)),
                               PercentCostLkgBook = (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                    -
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost)) == 0 ? 0 :
                                                    (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.ActualCountCost))
                                                     -
                                                     (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))
                                                     /
                                                     (Queries.Where(Z => Z.Brand.Equals(X.BrandDescription)).Sum(Y => Y.EndingInventoryCost))
                           }).ToList();

            return Results;     
        }

        #endregion
    }
}