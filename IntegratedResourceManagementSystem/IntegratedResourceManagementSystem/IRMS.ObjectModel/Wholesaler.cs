using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("WHOLESALER_TBL")]
    public class WholesalerClass
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("WHOLESALER_ID")]
        public string WholesalerID { get; set; }

        [MapField("BRAND_CODE")]
        public string BrandCode { get; set; }

        [MapField("LAST_NAME")]
        public string LastName { get; set; }

        [MapField("FIRST_NAME")]
        public string FirstName { get; set; }

        [MapField("MIDDLE_NAME")]
        public string MiddleName { get; set; }

        [MapField("HOME_ADDRESS")]
        public string HomeAddress { get; set; }

        [MapField("BILLING_ADDRESS")]
        public string BillingAddress { get; set; }

        [MapField("COLLECTION_ADDRESS")]
        public string CollectionAddress { get; set; }

        [MapField("SELLER_TYPE")]
        public int SellerType { get; set; }

        [MapField("ARRANGE_TYPE")]
        public int ArrangeType { get; set; }

        [MapField("DATE_START")]
        public DateTime DateStart { get; set; }

        [MapField("CREDIT_LIMIT")]
        public float CreditLimit { get; set; }

        [MapField("TERMS")]
        public string Terms { get; set; }
    }

    [TableName("WHOLESALER_CONTRACT_TBL")]
    public class WholesalerContractClass
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("WHOLESALER_ID")]
        public string WholesalerID { get; set; }

        [MapField("BRAND_CODE")]
        public string BrandCode { get; set; }

        [MapField("PRICEGROUP_REG")]
        public int PriceGroupRegular { get; set; }

        [MapField("PRICEGROUP_MD")]
        public int PriceGroupMarkdown { get; set; }
    }
}