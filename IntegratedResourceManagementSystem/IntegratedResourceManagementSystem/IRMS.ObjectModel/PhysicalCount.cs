using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("bridge_PCount")]
    public class PhysicalCount
    {
        [MapField("ID"),PrimaryKey,NonUpdatable]
        public int RecordNumber { get; set; }
        [MapField("CustNo")]
        public long CustomerNumber { get; set; }
        [MapField("asofDate")]
        public DateTime AsOfDate { get; set; }
        [MapField("actualAMT")]
        public decimal ActualAmount { get; set; }
        [MapField("actualQTY")]
        public long ActualQuantity { get; set; }
    }
}
