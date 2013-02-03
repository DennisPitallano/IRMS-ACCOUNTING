using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;
using System.Data;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class AdjustmentMemoAccessor : AccessorBase<AdjustmentMemoAccessor.DB, AdjustmentMemoAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM ADJUSTMENT_MEMOS WHERE ADJUSTMENT_CODE=@ADJUSTMENT_CODE")]
        public abstract List<AdjustmentMemo> GetAdjusmentMemosByAdjustmentCode(string ADJUSTMENT_CODE);

        [SqlQuery("SELECT * FROM ADJUSTMENT_MEMOS WHERE ADJUSTMENT_CODE=@ADJUSTMENT_CODE"),DataSetTable("ADJMEMO")]
        public abstract DataTable FetchAdjusmentMemosByAdjustmentCode(string ADJUSTMENT_CODE);

        [SqlQuery("SELECT * FROM ADJUSTMENT_MEMOS WHERE RECORD_NO=@RECORD_NO"),DataSetTable("ADJUSTMENT_MEMO")]
        public abstract DataTable FetchAdjustmentMemoByKey(long RECORD_NO);

        [SqlQuery(@"SELECT     ADJUSTMENT_MEMOS.MEMO_TYPE, ADJUSTMENT_MEMOS.MEMO_DATE, ADJUSTMENT_MEMOS.REFERENCE_NUMBER, ADJUSTMENTS.OUTLET_NAME, 
                      ADJUSTMENT_MEMOS.PERIOD_FROM, ADJUSTMENT_MEMOS.PERIOD_TO, ADJUSTMENT_MEMOS.PARTICULAR_TRANSACTION, ADJUSTMENT_MEMOS.QUANTITY, 
                      ADJUSTMENT_MEMOS.CURRENT_PRICE, ADJUSTMENT_MEMOS.COST_PRICE
FROM         ADJUSTMENT_MEMOS INNER JOIN
                      ADJUSTMENTS ON ADJUSTMENT_MEMOS.ADJUSTMENT_CODE = ADJUSTMENTS.ADJUSTMENT_CODE"),DataSetTable("PhysicalCountAdjustment")]
        public abstract DataTable GetAllPhysicalCountAdjustments();

        [SqlQuery(@"select max(REFERENCE_NUMBER) as LAST_REFERENCE_NUMBER from ADJUSTMENT_MEMOS")]
        public abstract long GetLastMemoReferenceNumber();
    }
}
