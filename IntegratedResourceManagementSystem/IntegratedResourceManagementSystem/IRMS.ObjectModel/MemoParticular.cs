using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
   [TableName("MEMO_PARTICULARS")]
   public class MemoParticular
    {
       [MapField("RECORD_NO"),PrimaryKey,NonUpdatable]
       public long RecordNo { get; set; }

       [MapField("PARTICULAR")]
       public string Particular { get; set; } // note: particular == style number of item.

       [MapField("QUANTITY")]
       public long Quantity { get; set; }

       [MapField("CURRENT_PRICE")]
       public decimal CurrentPrice { get; set; }

       [MapField("COST_PRICE")]
       public decimal CostPrice { get; set; }
    }
}
