using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.DataAccess
{
    /// <summary>
    /// Dennis Pitallano
    /// July 19, 2012 11:50 AM
    /// </summary>
    public abstract class UserLevelAccessor : AccessorBase<UserLevelAccessor.DB,UserLevelAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }
    }
}
