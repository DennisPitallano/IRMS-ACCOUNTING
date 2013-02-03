using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IRMS.ObjectModel;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class AdjustmentAccessor : AccessorBase<AdjustmentAccessor.DB, AdjustmentAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT ADJUSTMENT_CODE FROM ADJUSTMENTS WHERE RECORD_NO=@RECORD_NO")]
        public abstract Adjustment GetAdjustmentMemoByCode(long RECORD_NO);

        [SqlQuery(@"SELECT * FROM ADJUSTMENTS WHERE OUTLET_NAME=@OUTLET AND INVENTORY_DATE=@FROM AND CUT_OFF_DATE=@TO")]
        public abstract Adjustment GetAdjustmentMemoByOutletAndDateRange(string OUTLET,DateTime FROM,DateTime TO);
    }
}
