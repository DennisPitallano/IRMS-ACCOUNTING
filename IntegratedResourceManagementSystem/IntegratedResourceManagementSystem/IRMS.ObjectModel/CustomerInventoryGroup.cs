using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("CUSTOMER_INVENTORY_GROUPS")]
    public class CustomerInventoryGroup
    {
        [MapField("ID"),PrimaryKey,NonUpdatable]
        public long RecordNumber {get;set;}
        [MapField("CUSTOMER_NUMBER")]
        public int CustomerNumber {get;set;}
        [MapField("CUSTOMER_NAME")]
        public string CustomerName {get;set;}
        [MapField("BRAND_NAME")]
        public string BrandName{get;set;}
        [MapField("INVENTORY_GROUP_ID")]
        public long InventoryGroupId { get; set; }
        [MapField("ACCOUNT_NAME")]
        public string AccountName { get; set; }
        [MapField("BRANCH_NAME")]
        public string BranchName { get; set; }
    }
}
