using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class MemoAccessor : AccessorBase<MemoAccessor.DB,MemoAccessor>
    {
          public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

    }
}
