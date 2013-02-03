using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("BRANCH_TBL")]
    public class BranchClass
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("ACCT_CODE")]
        public string AccountCode { get; set; }

        [MapField("BRANCH_CODE")]
        public string BranchCode { get; set; }        

        [MapField("BRANCH_NAME")]
        public string BranchName { get; set; }

        [MapField("ADDRESS_1")]
        public string AddressOne { get; set; }

        [MapField("ADDRESS_2")]
        public string AddressTwo { get; set; }

        [MapField("CONTACT_PERSON")]
        public string ContactPerson { get; set; }

        [MapField("POSITION_DESC")]
        public string PositionDescription { get; set; }

        [MapField("TEL_NO")]
        public string TelephoneNumber { get; set; }

        [MapField("MOBILE_NO")]
        public string MobileNumber { get; set; }

        [MapField("FAX_NO")]
        public string FaxNumber { get; set; }

        [MapField("BILLING_ADD")]
        public string BillingAddress { get; set; }

        [MapField("SHIPPING_ADD")]
        public string ShippingAddress { get; set; }

        [MapField("TIN_ID")]
        public string TIN { get; set; }
    }
}