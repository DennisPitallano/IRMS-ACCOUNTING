using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class CategoryAccessor : AccessorBase<CategoryAccessor.DB, CategoryAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM CATEGORIES WHERE IS_ACTIVE ='Yes'")]
        public abstract List<Category> Categories();
    }
}
