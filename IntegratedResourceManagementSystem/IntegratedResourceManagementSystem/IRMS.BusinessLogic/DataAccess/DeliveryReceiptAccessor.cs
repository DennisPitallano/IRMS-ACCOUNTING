using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using System.Web.UI.WebControls;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;
using System.Data;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class DeliveryReceiptAccessor : AccessorBase<DeliveryReceiptAccessor.DB, DeliveryReceiptAccessor>
    {
        public class DB : DbManager
        {
            public DB() : base("IRMSConnectionString")
            {
            }
        }
        [SqlQuery("UPDATE DR SET ynCancelled=1 WHERE ID=@RecordNo")]
        public abstract void UpdateDeliveryReceiptCancelledStatus(long RecordNo);

        [SqlQuery(@"select ID,ynCancelled,ynPosted from DR ")]
        public abstract List<DeliveryReceipt> DeliveryReceipts();

        [SqlQuery(@"UPDATE DR SET WayBillNo=@WayBillNumber,Forwarder=@Forwarder,ConfirmedDate=@DateConfirmed,TransitStatus='Confirmed' where ID=@RecordNo")]
        public abstract void ConfirmDeliveryReceipt(long RecordNo,string WayBillNumber,string Forwarder, DateTime DateConfirmed);

        [SqlQuery(@"UPDATE DR SET ConfirmedDate=@DateConfirmed,TransitStatus='Confirmed' where ID=@RecordNo")]
        public abstract void ConfirmDeliveryReceipt(long RecordNo,DateTime DateConfirmed);

        [SqlQuery(@"SELECT * FROM DR where TransitStatus=@Status  order by DR.BrandName ASC "), 
        DataSetTable("InTransitDeliveryReceipts")]
        public abstract DataTable GetAllIntransitDeliveryReceipt(string Status);

        [SqlQuery(@"SELECT * FROM DR where TransitStatus=@Status and DR.DRDate BETWEEN @from and @to order by DR.BrandName ASC "), 
        DataSetTable("InTransitDeliveryReceipts")]
        public abstract DataTable GetAllTransitDeliveryReceiptsWithDateRange(string Status, DateTime from, DateTime to);

        [SqlQuery(@"SELECT c.*,(select SUM((a.quantity * b.cost)) from DRSUMM a, STYLE b where a.DRID = c.ID 
and a.STYLENO = b.STYLENO) as TotalCost FROM DR c where c.ConfirmedDate is null and c.BrandName=@Brand and c.DRDate  BETWEEN @from and @to order by c.BrandName ASC "),
        DataSetTable("InTransitDeliveryReceipts")]
        public abstract DataTable GetAllInTransitDeliveryReceiptsByBrandWithDateRange(string Status, DateTime from, DateTime to, String Brand);


        [SqlQuery(@"SELECT c.*, (select SUM((a.quantity * b.cost)) from DRSUMM a, STYLE b where a.DRID = c.ID 
and a.STYLENO = b.STYLENO) as TotalCost FROM DR c where c.ConfirmedDate is not null and c.BrandName=@Brand and c.DRDate  BETWEEN @from and @to order by c.BrandName ASC "),
        DataSetTable("InTransitDeliveryReceipts")]
        public abstract DataTable GetAllConfirmedDeliveryReceiptsByBrandWithDateRange(string Status, DateTime from, DateTime to, String Brand);

        [SqlQuery(@"SELECT * FROM DR where DR.TransitStatus=@Status and DR.CustNo=@OutletName order by DR.BrandName ASC"), 
        DataSetTable("InTransitDeliveryReceiptsByBrand")]
        public abstract DataTable GetAllTransitDeliveryReceiptByOutlet(string Status,string OutletName);

        [SqlQuery(@"SELECT * FROM DR where DR.TransitStatus=@Status and DR.CustNo=@OutletName and DR.DRDate  BETWEEN @from and @to order by DR.BrandName ASC"),
      DataSetTable("InTransitDeliveryReceiptsByBrand")]
        public abstract DataTable GetAllTransitDeliveryReceiptByOutletWithDateRange(string Status, string OutletName, DateTime from, DateTime to);

        [SqlQuery(@"SELECT * FROM DR where TransitStatus=@Status and BrandName=@Brand order by DR.BrandName ASC"),
        DataSetTable("InTransitDeliveryReceiptsByBrand")]
        public abstract DataTable GetAllIntransitDeliveryReceiptByBrand(string Status, string Brand);

        [SqlQuery(@"SELECT DR.DRNo, DR.DRDate, DR.DeliveredTo, DR.TotalQty, DR.TotalAmt, DR.BrandName, DRDtl.SKU, DRDtl.StyleNo, DRDtl.BrandName AS
                    DetailsBrand,DRDtl.Articles,DRDtl.Quantity, DRDtl.Unit, DRDtl.UnitPrice, DRDtl.Amount FROM DR INNER JOIN DRDtl ON DR.ID = DRDtl.DRID and
                DR.TransitStatus=@Status"),DataSetTable("drwithdetails")]
        public abstract DataTable GetAllDeliveryReceiptsWithDetails(string Status);

        [SqlQuery(@"SELECT DR.DRNo, DR.DRDate, DR.DeliveredTo, DR.TotalQty, DR.TotalAmt, DR.BrandName, DRDtl.SKU, DRDtl.StyleNo, DRDtl.BrandName AS
                    DetailsBrand,DRDtl.Articles,DRDtl.Quantity, DRDtl.Unit, DRDtl.UnitPrice, DRDtl.Amount FROM DR INNER JOIN DRDtl ON DR.ID = DRDtl.DRID and
                DR.TransitStatus=@Status and DR.BrandName=@Brand"), DataSetTable("drwithdetails")]
        public abstract DataTable GetAllDeliveryReceiptsWithDetailsByBrand(string Status,string Brand);
    }
}
