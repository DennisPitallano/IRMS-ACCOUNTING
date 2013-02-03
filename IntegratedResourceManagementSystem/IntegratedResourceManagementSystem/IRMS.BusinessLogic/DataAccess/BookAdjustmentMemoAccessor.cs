using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class BookAdjustmentMemoAccessor : AccessorBase<BookAdjustmentMemoAccessor.DB, BookAdjustmentMemoAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery(@"select max(REFERENCE_NUMBER) as LAST_REFERENCE_NUMBER from BOOK_ADJUSTMENT_MEMOS")]
        public abstract long GetLastMemoReferenceNumber();
    }
}
