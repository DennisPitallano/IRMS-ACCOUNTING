using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class UserClassAccessor : AccessorBase<UserClassAccessor.DB, UserClassAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }
        
        [SqlQuery("@SELECT * FROM USERS where USERNAME = @UserName")]
        public abstract UsersClass FindUser(string UserName);

        [SprocName("SP_UPDATE_ONLINE_STAT")]
        public abstract void UpdateOnlineStatus(long UserId,bool OnlineStatus);
    }
}
