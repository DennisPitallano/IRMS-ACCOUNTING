using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
   public class MemoParticularManager
    {
        #region Accessor
        MemoParticularAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MemoParticularAccessor.CreateInstance(); }
        }
        #endregion

        public MemoParticular GetMemoParticularByKey(long id)
        {
            return Accessor.Query.SelectByKey<MemoParticular>(id) ?? new MemoParticular();
        }

        public List<MemoParticular> MemoParticulars()
        {
            return Accessor.Query.SelectAll<MemoParticular>();
        }

        public void Save(MemoParticular memo_particular)
        {
            using (DbManager db = new DbManager())
            {
                if (memo_particular.RecordNo != 0)
                {
                    Accessor.Query.Update(db, memo_particular);
                }
                else
                {
                    Accessor.Query.Insert(db, memo_particular);
                }
            }
        }

        public void Delete(MemoParticular memo_particular)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, memo_particular);
            }
        }

        public List<MemoParticular> SearchMemoParticulars(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "FABRIC_CODE";
            columns[1] = "FABRIC_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<MemoParticular>(search_parameter, columns);
        }
    }
}
