using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IRMS.ObjectModel;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class FabricAccessor : AccessorBase<FabricAccessor.DB,FabricAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM FABRICS WHERE IS_ACTIVE='Yes'")]
        public abstract List<Fabric> Fabrics();
    }
}
