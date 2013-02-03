using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class BookAdjustmentMemoManager :LogManager<BookAdjustmentMemo>
    {
        #region Accessor
        BookAdjustmentMemoAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return BookAdjustmentMemoAccessor.CreateInstance(); }
        }
        #endregion

        public BookAdjustmentMemo GetBookAdjustmentMemoByKey(long id)
        {
            return Accessor.Query.SelectByKey<BookAdjustmentMemo>(id) ?? new BookAdjustmentMemo();
        }

        public List<BookAdjustmentMemo> BookAdjustmentMemos()
        {
            return Accessor.Query.SelectAll<BookAdjustmentMemo>();
        }

       
        public void Save(BookAdjustmentMemo BookAdjustmentMemo)
        {
            using (DbManager db = new DbManager())
            {
                if (BookAdjustmentMemo.RecordNo != 0)
                {
                    Accessor.Query.Update(db, BookAdjustmentMemo);
                }
                else
                {
                    Accessor.Query.Insert(db, BookAdjustmentMemo);
                }
            }
        }

        public void Delete(BookAdjustmentMemo BookAdjustmentMemo)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, BookAdjustmentMemo);
            }
        }

        public long GetLastMemoreferenceNumber()
        {
            return Accessor.GetLastMemoReferenceNumber();
        }

    }
}
