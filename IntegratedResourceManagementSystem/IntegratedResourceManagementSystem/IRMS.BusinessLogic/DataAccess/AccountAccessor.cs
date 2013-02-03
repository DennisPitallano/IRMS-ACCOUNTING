using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class AccountsAccessor : AccessorBase<AccountsAccessor.DB, AccountsAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM ACCOUNT_TBL")]
        public abstract List<AccountClass> Accounts();

        [SqlQuery("SELECT * FROM ACCOUNT_TBL where ACCT_CODE = @AccountCode and ACCT_NAME = @AccountName")]
        public abstract List<AccountClass> AccountsByAccountName(string AccountCode, string AccountName);

        [SqlQuery("SELECT * FROM ACCOUNT_TBL where ACCT_CODE = @AccountCode")]
        public abstract List<AccountClass> AccountsByAccountCode(string AccountCode);
    }
}
