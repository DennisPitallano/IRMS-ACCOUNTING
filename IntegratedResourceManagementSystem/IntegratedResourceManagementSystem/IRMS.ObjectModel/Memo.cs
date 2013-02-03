using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("MEMO")]
    public class Memo
    {
        [MapField("RECORD_NO"),PrimaryKey,NonUpdatable]
        public long RecordNo { get; set; }

        [MapField ("MEMO_TYPE")]
        public string MemoType { get; set; }

        [MapField("REFERENCE_NUMBER")]
        public string ReferenceNumber { get; set; }

        [MapField ("MEMO_DATE")]
        public DateTime MemoDate { get; set; }

        [MapField("OUTLET")]
        public string Outlet { get; set; }

        [MapField("BRAND")]
        public string Brand { get; set; }

        [MapField("DATE_CREATED")]
        public DateTimeOffset DateRecorded { get; set; }

        [MapField("DATE_UPDATED")]
        public DateTimeOffset DateUpdated { get; set; }
    }
}
