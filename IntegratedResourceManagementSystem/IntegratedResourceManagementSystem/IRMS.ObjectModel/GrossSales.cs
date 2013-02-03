using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("bridge_GrossSales")]
    public class GrossSales 
    {
        [MapField("ID")]
        public long RecordNumber { get; set; }
        [MapField("Custno")]
        public long CustomerNnumber { get; set; }
        [MapField("GrossMonth")]
        public int GrossMonth { get; set; }
        [MapField("GrossYear")]
        public int GrossYear { get; set; }
        [MapField("GrossAmt")]
        public decimal GrossAmount { get; set; }
        [MapField("GrossQty")]
        public long GrossQuantity { get; set; }
    }
}
