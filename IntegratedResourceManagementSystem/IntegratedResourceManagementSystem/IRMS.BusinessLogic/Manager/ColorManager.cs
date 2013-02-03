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
   public class ColorManager
    {
        #region Accessor
        ColorAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ColorAccessor.CreateInstance(); }
        }
        #endregion

        public Color GetColorByKey(long id)
        {
            return Accessor.Query.SelectByKey<Color>(id) ?? new Color();
        }

        public List<Color> Colors()
        {
            return Accessor.Colors();
        }

        public void Save(Color color)
        {
            using (DbManager db = new DbManager())
            {
                if (color.RecordNo != 0)
                {
                    Accessor.Query.Update(db, color);
                }
                else
                {
                    Accessor.Query.Insert(db, color);
                }
            }
        }

        public void Delete(Color color)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, color);
            }
        }

        public List<Color> SearchColors(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "COLOR_CODE";
            columns[1] = "COLOR_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Color>(search_parameter, columns);
        }
    }
}
