using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IRMS.ObjectModel;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class DeliveryReceiptDetailAccessor : AccessorBase<DeliveryReceiptDetailAccessor.DB, DeliveryReceiptDetailAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM DRDtl WHERE DRID=@DRNUMBER")]
        public abstract List<DeliveryReceiptDetail> GetDeliveryReceiptDetailsByDRNumber(int DRNUMBER);
    }
}
