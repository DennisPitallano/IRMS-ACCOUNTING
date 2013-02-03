using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("CRSDtl")]
    public class CustomerReturnSlipDetail
    {
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public int RecordNo { get; set; }
        [MapField("CRSID")]
        public int CustomerReturnSlipID { get; set; }
        [MapField("SKU")]
        public string SKUCode { get; set; }
        [MapField("StyleNo")]
        public string StyleNumber { get; set; }
        [MapField("BrandName")]
        public string BrandName { get; set; }
        [MapField("Quantity")]
        public int Quantity { get; set; }
        [MapField("Articles")]
        public string Articles { get; set; }
        [MapField("UnitPrice")]
        public double UnitPrice { get; set; }
        [MapField("Amount")]
        public double Amount { get; set; }
        [MapField("StyleColor")]
        public string StyleColor { get; set; }
        [MapField("StyleSize")]
        public string StyleSize { get; set; }
    }
}
