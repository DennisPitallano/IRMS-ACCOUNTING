using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("ACCOUNT_TBL")]
    public class AccountClass
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("ACCT_CODE")]
        public string AccountCode { get; set; }

        [MapField("ACCT_NAME")]
        public string AccountName { get; set; }


    }
}
