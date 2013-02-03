using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using System.Data;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class MonthlyStoreOutStandingInventoryAccessor : AccessorBase<MonthlyStoreOutStandingInventoryAccessor.DB, MonthlyStoreOutStandingInventoryAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SprocName("SP_GET_DR_MONTHLY_SOI"),DataSetTable("MONTHLY_DR_FOR_SOI")]
        public abstract DataTable GetMonthlySOIDeliveries(int CUSTOMER_NO, DateTime DATE_FROM, DateTime DATE_TO);
    }
}
