using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("BOOK_ADJUSTMENT_MEMOS")]
    public class BookAdjustmentMemo
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }
        [MapField("ADJUSTMENT_CODE")]
        public string AdjustmentCode { get; set; }
        [MapField("MEMO_TYPE")]
        public string MemoType { get; set; }
        [MapField("REFERENCE_NUMBER")]
        public long ReferenceNumber { get; set; }
        [MapField("MEMO_DATE")]
        public DateTime MemoDate { get; set; }
        [MapField("PERIOD_FROM")]
        public DateTime PeriodFrom { get; set; }
        [MapField("PERIOD_TO")]
        public DateTime PeriodTo { get; set; }
        [MapField("PARTICULAR_TRANSACTION")]
        public string ParticularTransaction { get; set; }
        [MapField("QUANTITY")]
        public long Quantity { get; set; }
        [MapField("CURRENT_PRICE")]
        public decimal CurrentPrice { get; set; }
        [MapField("COST_PRICE")]
        public decimal CostPrice { get; set; }
        [MapField("DATE_RECORDED")]
        public DateTime DateRecorded { get; set; }
    }
}
