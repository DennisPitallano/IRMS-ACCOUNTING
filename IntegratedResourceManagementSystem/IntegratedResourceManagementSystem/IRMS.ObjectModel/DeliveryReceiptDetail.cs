using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("DRDtl")]
    public class DeliveryReceiptDetail
    {
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }
        [MapField("DRID")]
        public int DR_ID { get; set; }
        [MapField("SKU")]
        public string SKUCode { get; set; }
        [MapField("StyleNo")]
        public string StyleNumber { get; set; }
        [MapField("BrandName")]
        public string BrandName { get; set; }
        [MapField("Articles")]
        public string Articles { get; set; }
        [MapField("Quantity")]
        public int Quantity { get; set; }
        [MapField("Unit")]
        public string Unit { get; set; }
        [MapField("UnitPrice")]
        public double UnitPrice { get; set; }
        [MapField("Amount")]
        public double Amount { get; set; }
    }
}
