using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class CategoryManager
    {
        #region Accessor
        CategoryAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CategoryAccessor.CreateInstance(); }
        }
        #endregion

        public Category GetCategoryByKey(long id)
        {
            return Accessor.Query.SelectByKey<Category>(id) ?? new Category();
        }

        public List<Category> Categories()
        {
            return Accessor.Categories();
        }

        public void Save(Category category)
        {
            using (DbManager db = new DbManager())
            {
                if (category.RecordNo != 0)
                {
                    Accessor.Query.Update(db, category);
                }
                else
                {
                    Accessor.Query.Insert(db, category);
                }
            }
        }

        public void Delete(Category category)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, category);
            }
        }

        public List<Category> SearchCategories(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "CATEGORY_CODE";
            columns[1] = "CATEGORY_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Category>(search_parameter, columns);
        }
    }
}
