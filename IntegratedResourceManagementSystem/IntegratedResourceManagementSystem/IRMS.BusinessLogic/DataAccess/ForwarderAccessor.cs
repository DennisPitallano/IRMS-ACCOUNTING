using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class ForwarderAccessor : AccessorBase<ForwarderAccessor.DB, ForwarderAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        //[SqlQuery("UPDATE CRS SET ynCancelled=1 WHERE ID=@RecordNo")]
        //public abstract void UpdateCustomerReturnSlipCancelledStatus(long RecordNo);

        //[SqlQuery(@"select ID,ynCancelled,ynPosted from CRS")]
        //public abstract List<Forwarder> CustomerReturnSlipSummary();
    }
}
