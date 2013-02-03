using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("BOOK_ADJUSTMENTS")]
    public class BookAdjustment
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }
        [MapField("ADJUSTMENT_CODE")]
        public string AdjustmentCode { get; set; }
        [MapField("INVENTORY_DATE")]
        public DateTime InventoryDate { get; set; }
        [MapField("CUT_OFF_DATE")]
        public DateTime CutOffDate { get; set; }
        [MapField("OUTLET_NUMBER")]
        public int OutletNumber { get; set; }
        [MapField("OUTLET_NAME")]
        public string OutletName { get; set; }
        [MapField("DATE_RECORDED")]
        public DateTime DateRecorded { get; set; }
    }
}
