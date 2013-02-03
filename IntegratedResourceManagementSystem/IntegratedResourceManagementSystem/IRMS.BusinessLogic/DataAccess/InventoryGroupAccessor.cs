using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class InventoryGroupAccessor : AccessorBase<InventoryGroupAccessor.DB, InventoryGroupAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }
    }
}
