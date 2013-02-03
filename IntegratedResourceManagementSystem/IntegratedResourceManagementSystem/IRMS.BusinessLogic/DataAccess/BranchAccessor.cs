using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class BranchAccessor : AccessorBase<BranchAccessor.DB, BranchAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM BRANCH_TBL order by BRANCH_NAME ASC")]
        public abstract List<BranchClass> Branch();

        [SqlQuery("SELECT * FROM BRANCH_TBL where ACCT_CODE = @AccountCode")]
        public abstract List<BranchClass> BranchByAccountCode(string AccountCode);

        [SqlQuery("SELECT * FROM BRANCH_TBL where ACCT_CODE = @AccountCode and BRANCH_NAME = @BranchName")]
        public abstract List<BranchClass> BranchByBranchName(string AccountCode, string BranchName);

    }
}
