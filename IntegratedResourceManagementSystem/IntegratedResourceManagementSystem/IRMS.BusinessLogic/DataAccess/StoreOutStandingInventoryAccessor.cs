using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using System.Data;


namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class StoreOutStandingInventoryAccessor : AccessorBase<StoreOutStandingInventoryAccessor.DB, StoreOutStandingInventoryAccessor>
    {
        public class DB : DbManager
        {
            public DB() : base("IRMSConnectionString")
            {
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <param name="periodFrom"></param>
        /// <param name="periodTo"></param>
        /// <returns></returns>
        [SqlQuery(@"select sum(TotalAmt) as TOTAL_AMOUNT, sum(TotalQty) as TOTAL_QUANTITY from dr 
                    where custno=@customerNumber and drdate between 
                    @periodFrom and @periodTo "),DataSetTable("DeliveryReceiptForSOI")]
        public abstract DataTable DeliveryForSOIByCustomerNumberAndByPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo);

        [SprocName(@"Delivery_For_SOI_By_Customer_Number_And_By_Period"), DataSetTable("DeliveryReceiptForSOI")]
        public abstract DataTable DeliveryForSOIByCustomerNumberAndByPeriod_SP(long customerNumber, DateTime periodFrom, DateTime periodTo);

        /// <summary>
        /// dr breakdown, reference for  SOI
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <param name="periodFrom"></param>
        /// <param name="periodTo"></param>
        /// <returns></returns>
        [SqlQuery(@"select ID,DRNo as DR_NUMBER,DeliveredTo as CUSTOMER,DRDate as DR_DATE, TotalAmt as TOTAL_AMOUNT,
                    TotalQty as TOTAL_QUANTITY from dr 
                    where custno=@customerNumber and drdate between @periodFrom and @periodTo"),
        DataSetTable("DeliveryReceiptDetailsForSOI")]
        public abstract DataTable DeliveryReceiptDetailsForSOIByCustomerNumberAndByPeriod(long customerNumber, DateTime periodFrom,
                                                                                          DateTime periodTo);


        [SprocName(@"GET_DR_DETAILS_FOR_SOI_BY_CUSTOMER_NUMBER_AND_BY_PERIOD"), DataSetTable("DeliveryReceiptDetailsForSOI")]
        public abstract DataTable DeliveryReceiptDetailsForSOIByCustomerNumberAndByPeriod_SP(long customerNumber, DateTime DateFrom,
                                                                                         DateTime DateTo);

        /// <summary>
        /// Needed for TotalCost
        /// to be use in dr collection result by customer number and period
        /// </summary>
        /// <param name="DRID"></param>
        /// <returns>total quantity and total cost</returns>
        [SqlQuery(@"select sum(DRSumm.Quantity) As TOTAL_QUANTITY,sum((DRSumm.Quantity*cost)) as TOTAL_COST from DRSumm,Style where DRSumm.drid=@DRID 
                and DRSumm.StyleNo = style.StyleNo"), DataSetTable("DRDetailsTotalCostSummary")]
        public abstract DataTable DeliveryReceiptDetailsTotalQuantityAndCost(long DRID);

        [SprocName(@"DR_DETAILS_TOTAL_QUANTITY_AND_COST"), DataSetTable("DRDetailsTotalCostSummary")]
        public abstract DataTable DeliveryReceiptDetailsTotalQuantityAndCost_SP(long DRID);

        
        /// <summary>
        /// Get Customer Return Slip Details for Soi by Customer Number and by Period.
        /// </summary>
        /// <param name="customerNumber">Customer Number</param>
        /// <param name="periodFrom">period from</param>
        /// <param name="periodTo">period to</param>
        /// <returns>Customer Return Slip Details</returns>
        [SqlQuery(@"select ID,CRSNo as CRS_NUMBER,Customer,CRSDate, TotalAmt as TOTAL_AMOUNT from crs 
            where custno=@customerNumber and CRSDate between @periodFrom and @periodTo "),DataSetTable("CRSDetailsforSOI")]
        public abstract DataTable CustomerReturnSlipDetailsForSOIByCustomerNumberAndByPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo);

        /// <summary>
        /// Get Total Summary of Amount from crs by Customer Number and by Period.
        /// </summary>
        /// <param name="customerNumber">CustomerKey</param>
        /// <param name="periodFrom">period from</param>
        /// <param name="periodTo">period to</param>
        /// <returns>Total Amount</returns>
        [SqlQuery(@"select sum(TotalAmt) as TOTAL_AMOUNT from crs 
            where custno=@customerNumber and CRSDate between @periodFrom and @periodTo "),DataSetTable("CRSTotalAmount")]
        public abstract DataTable CustomerReturnSlipForSOIByCustomerNumberAndByPeriod(long customerNumber, DateTime periodFrom, DateTime periodTo);

        /// <summary>
        /// Get Customer Return Slip Details By Customer Return Number.
        /// </summary>
        /// <param name="CRSID"></param>
        /// <returns></returns>
        [SqlQuery(@"Select CRSID,SKU,StyleNo,Quantity,UnitPrice,Amount from crsdtl where CRSID =@CRSID"), DataSetTable("CRSDetails")]
        public abstract DataTable CustomerReturnSlipDetailsForSOIReturnQuantityAndAmount(long CRSID);

        /// <summary>
        /// Get Customer Return Slip Details Total Quantity  and Total Amounts
        /// Needed for Customer Return Slip By Customer Number And Period.
        /// </summary>
        /// <param name="CRSID"></param>
        /// <returns></returns>
        [SqlQuery(@"Select sum(Quantity)as TotalQuantity,sum(Amount)as TotalAmount from crsdtl where CRSID =@CRSID ")]
        public abstract DataTable CustomerReturnSlipDetailsForSOIReturnTotalQuantityAndTotalAmount(long CRSID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CRSID"></param>
        /// <returns></returns>
        [SqlQuery(@"select sum(CRSSumm.Quantity) As TOTAL_QUANTITY,sum((CRSSumm.Quantity*cost)) as TOTAL_COST 
                    from CRSSumm,Style where CRSSumm.crsid=@CRSID and CRSSumm.StyleNo = style.StyleNo"), DataSetTable("CRSDetailsTotalCostSummary")]
        public abstract DataTable CustomerReturnSlipDetailsTotalQuantityAndCost(long CRSID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RecordNumber"></param>
        /// <returns></returns>
        [SqlQuery(@"Select * from STORE_OUTSTANDING_INVENTORIES WHERE RECORD_NO=@RecordNumber")]
        public abstract StoreOutStandingInventory GetStoreOutStandingInventoryByRecordNumber(long RecordNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RecordNumber"></param>
        /// <returns></returns>
        [SqlQuery(@"Select * from STORE_OUTSTANDING_INVENTORIES WHERE RECORD_NO=@RecordNumber"), DataSetTable("StoreOutStandingInventory")]
        public abstract DataTable GetDataTableStoreOutStandingInventoryByRecordNumber(long RecordNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerNumber"></param>
        /// <param name="GrossMonth1"></param>
        /// <param name="GrossMonth2"></param>
        /// <param name="GrossYear1"></param>
        /// <param name="GrossYear2"></param>
        /// <returns></returns>
        [SqlQuery(@"select sum(GrossAmt) as GROSS_AMOUNT, 
                    sum(GrossQty) as GROSS_QUANTITY from bridge_GrossSales 
                    where custno =@CustomerNumber  and GrossMonth between @GrossMonth1 and @GrossMonth2 
                    and GrossYear between @GrossYear1 and @GrossYear2"),DataSetTable("GrossSalesSummary")]
        public abstract DataTable GetDataTableStoreOutStandingInventoryGrossSalesSummaryByCustomerNumberAndPeriod(long CustomerNumber,
                                   int GrossMonth1,int GrossMonth2, int GrossYear1, int GrossYear2);

        [SqlQuery(@"select GrossAmt as GROSS_AMOUNT, 
                    GrossQty as GROSS_QUANTITY,DateName(mm,DATEADD(mm,GrossMonth,-1)) as GROSS_MONTH,GrossYear AS GROSS_YEAR from bridge_GrossSales 
                    where custno =@CustomerNumber  and GrossMonth between @GrossMonth1 and @GrossMonth2 
                    and GrossYear between @GrossYear1 and @GrossYear2"), DataSetTable("GrossSalesSummaryBreakDown")]
        public abstract DataTable GetDataTableStoreOutStandingInventoryBreakDownGrossSalesSummaryByCustomerNumberAndPeriod(long CustomerNumber,
                                   int GrossMonth1, int GrossMonth2, int GrossYear1, int GrossYear2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerNumber"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        [SqlQuery(@"select sum(actualAMT) as ACTUAL_AMOUNT, sum(actualQTY) as ACTUAL_QUANTITY, 
                    sum(TotalCost) as TOTAL_COST from bridge_PCount where custno = @CustomerNumber 
                    and asofDate between @DateFrom and @DateTo"),DataSetTable("PhysicalCountSummary")]
        public abstract DataTable GetDataTableStoreOutStandingInventoryPhysicalCountSummaryByCustomerNumberAndByPeriod(long CustomerNumber,
                                   DateTime DateFrom, DateTime DateTo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerNumber"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        [SqlQuery(@"select actualAMT as ACTUAL_AMOUNT, actualQTY as ACTUAL_QUANTITY, 
                    TotalCost as TOTAL_COST from bridge_PCount where custno = @CustomerNumber 
                    and asofDate >= @DateFrom"), DataSetTable("PhysicalCountSummary")]
        public abstract DataTable GetDataTableStoreOutStandingInventoryPhysicalCountSummaryByCustomerNumberAndByPeriod1(
            long CustomerNumber,DateTime DateFrom, DateTime DateTo);

        [SqlQuery(@"select actualAMT as ACTUAL_AMOUNT, actualQTY as ACTUAL_QUANTITY, 
                    TotalCost as TOTAL_COST, asofDate AS AS_OF_DATE from bridge_PCount where custno = @CustomerNumber 
                    and DATENAME(yyyy,asofDate)= @DATEYEAR order by asofdate asc"), DataSetTable("PhysicalCountSummary")]
        public abstract DataTable GetDataTableStoreOutStandingInventoryPhysicalCountBreakdownByCustomerNumberAndByPeriod(
            long CustomerNumber, int DATEYEAR);

        /// <summary>
        /// Get SOI for Beginning Inventory.
        /// </summary>
        /// <param name="CustomerNumber">Customer Number</param>
        /// <returns>SOI</returns>
        [SqlQuery(@" SELECT * FROM STORE_OUTSTANDING_INVENTORIES WHERE CUSTOMER_NO=@CustomerNumber ORDER BY PERIOD_TO DESC ")]
        public abstract StoreOutStandingInventory GetStoreOutStandingInventoryForBeginningInventory(long CustomerNumber);

        //CTS 2012-04-13
        [SqlQuery(@"select sum(DRSummTemp.Quantity) As TOTAL_QUANTITY,sum((DRSummTemp.Quantity*DRSummTemp.cost)) as TOTAL_COST from DRSummTemp 
where DRSummTemp.drid in (select ID from DRTemp where DRDATE between @DateFrom and @DateTo and CUSTNO = @CustomerNumber)"), DataSetTable("DRDetailsTotalCostSummary")]
        public abstract DataTable GetDRTotalQuantityAndCost(long CustomerNumber, DateTime DateFrom, DateTime DateTo);
        //CTS 2012-04-13


        //CTS 2012-04-16
        [SprocName(@"Get_DRTotalQuantityAndCost_SP"), DataSetTable("DRDetailsTotalCostSummary")]
        public abstract DataTable GetDRTotalQuantityAndCost_SP(long CustomerNumber, DateTime DateFrom, DateTime DateTo);


        [SqlQuery(@"select sum(CRSSummTemp.Quantity) As TOTAL_QUANTITY,sum((CRSSummTemp.Quantity*CRSSummTemp.cost)) as TOTAL_COST 
                    from CRSSummTemp where CRSSummTemp.crsid in (select ID from CRSTemp where CRSDATE between @DateFrom and @DateTo and CUSTNO = @CustomerNumber)"), DataSetTable("CRSDetailsTotalCostSummary")]
        public abstract DataTable GetCRSTotalQuantityAndCost(long CustomerNumber, DateTime DateFrom, DateTime DateTo);

        [SprocName(@"Get_CRSTotalQuantityAndCost_SP"), DataSetTable("CRSDetailsTotalCostSummary")]
        public abstract DataTable GetCRSTotalQuantityAndCost_SP(long CustomerNumber, DateTime DateFrom, DateTime DateTo);      
        //CTS 2012-04-16


    }
}
