using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
   public class MemoManager
    {
        #region Accessor
        MemoAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MemoAccessor.CreateInstance(); }
        }
        #endregion

        public Memo GetMemoByKey(long id)
        {
            return Accessor.Query.SelectByKey<Memo>(id) ?? new Memo();
        }

        public List<Memo > Memos()
        {
            return Accessor.Query.SelectAll<Memo>();
        }

        public void Save(Memo memo)
        {
            using (DbManager db = new DbManager())
            {
                if (memo.RecordNo != 0)
                {
                    Accessor.Query.Update(db, memo);
                }
                else
                {
                    Accessor.Query.Insert(db, memo);
                }
            }
        }

        public void Delete(Memo memo)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, memo);
            }
        }

        public List<Memo> SearchMemo(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "FABRIC_CODE";
            columns[1] = "FABRIC_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Memo>(search_parameter, columns);
        }
    }
}
