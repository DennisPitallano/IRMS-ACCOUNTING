using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.ObjectModel;
using BLToolkit;
using BLToolkit.Data;
using IRMS.BusinessLogic.DataAccess;

namespace IRMS.BusinessLogic.Manager
{
    public class SizeManager
    {
        #region Accessor
        SizeAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return SizeAccessor.CreateInstance();
            }
        }

        #endregion

        public Size GetSizeByKey(long id)
        {
            return Accessor.Query.SelectByKey<Size>(id) ?? new Size();
        }

        public List<Size> Sizes()
        {
            return Accessor.Query.SelectAll<Size>();
        }

        public void Save(Size size)
        {
            using (DbManager db = new DbManager())
            {
                if (size.RecordNo != 0)
                {
                    Accessor.Query.Update(db, size); 
                }
                else
                {
                    Accessor.Query.Insert(db, size); 
                }
            }
        }

        public void Delete(Size size)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, size);
            }
        }

        public List<Size> SearchSizes(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "SIZE_CODE";
            columns[1] = "SIZE_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Size>(search_parameter, columns);
        }
    }
}
