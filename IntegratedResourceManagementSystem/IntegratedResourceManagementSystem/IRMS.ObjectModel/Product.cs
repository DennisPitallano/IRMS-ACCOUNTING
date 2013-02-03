using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("PRODUCTS")]
    public class Product
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("STYLE_NO")]
        public string StyleNumber { get; set; }

        [MapField("DESCRIPTION")]
        public string Description { get; set; }

        [MapField("ITEM_CODE")]
        public string ItemCode { get; set; }

        [MapField("SKU_BARCODE")]
        public string SKUBarcode { get; set; }

        [MapField("DATE_RECORDED")]
        public DateTime DateCreated { get; set; }

        [MapField("IS_ACTIVE")]
        public string IsActive { get; set; }
    }
}
