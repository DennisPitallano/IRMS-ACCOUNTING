using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class BrandAccessor : AccessorBase<BrandAccessor.DB, BrandAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM BRANDS WHERE IS_ACTIVE='Yes'")]
        public abstract List<Brand> Brands();
    }
}
