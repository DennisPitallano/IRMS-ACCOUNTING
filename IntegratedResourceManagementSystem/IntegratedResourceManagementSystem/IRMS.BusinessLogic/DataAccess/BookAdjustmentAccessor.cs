using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class BookAdjustmentAccessor : AccessorBase<BookAdjustmentAccessor.DB, BookAdjustmentAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery(@"SELECT * FROM BOOK_ADJUSTMENT_MEMOS WHERE ADJUSTMENT_CODE=@ADJUSTMENT_CODE")]
        public abstract List<BookAdjustmentMemo> GetBookAdjustmentMemoByCode(string ADJUSTMENT_CODE);

        [SqlQuery(@"SELECT * FROM BOOK_ADJUSTMENTS WHERE OUTLET_NAME =@OUTLET_NAME AND INVENTORY_DATE=@INVENTORY_DATE AND CUT_OFF_DATE=@CUT_OFF_DATE")]
        public abstract List<BookAdjustment> GetBookAdjustmentByOutletNameAndDateRange(string OUTLET_NAME, DateTime INVENTORY_DATE, DateTime CUT_OFF_DATE);

    }
  
}
