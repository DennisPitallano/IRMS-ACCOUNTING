using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("CRS")]
    public class CustomerReturnSlip
    {
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public int RecordNo { get; set; }
        [MapField("CRSID")]
        public int CustomerReturnSlipID { get; set; }
        [MapField("CRSNo")]
        public string CustomerReturnSlipNumber { get; set; }
        [MapField("CRSDate")]
        public DateTime CustomerReturnSlipDate { get; set; }
        [MapField("CustNo")]
        public int CustomerNumber { get; set; }
        [MapField("Customer")]
        public string Customer { get; set; }
        [MapField("TotalAmt")]
        public double TotalAmount { get; set; }
        [MapField("PUSNo")]
        public string PUSNo { get; set; }
        [MapField("PkgNo")]
        public string PkgNo { get; set; }
        [MapField("PreparedBy")]
        public string PrepredBy { get; set; }
        [MapField("PUBy")]
        public string PUBy { get; set; }
        [MapField("Remarks")]
        public string Remarks { get; set; }
        [MapField("ItemStatus")]
        public string ItemStatus { get; set; }
        [MapField("ynPosted")]
        public bool YesNoPosted { get; set; }
        [MapField("ynCancelled")]
        public bool YesNoCancelled { get; set; }
        [MapField("ynImported")]
        public bool YesNoImported { get; set; }
    }
}
