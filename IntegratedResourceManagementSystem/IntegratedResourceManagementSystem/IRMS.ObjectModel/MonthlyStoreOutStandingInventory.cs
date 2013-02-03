using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("MONTHLY_SOI")]
    public class MonthlyStoreOutStandingInventory
    {
        [MapField("RECORD_NO"),PrimaryKey, NonUpdatable]
        public long RecordNumber {get;set;}
        [MapField("SOI_CODE")]
        public string SOICode { get; set; }
        [MapField("CUSTOMER_NO")]
        public int CustomerNumber{get;set;}
        [MapField("CUSTOMER")]
        public string CustomerName{get;set;}
        [MapField("PERIOD_FROM")]
        public DateTime PeriodFrom {get;set;}
        [MapField("PERIOD_TO")]
        public DateTime PeriodTo {get;set;}
        [MapField("INVENTORY_DATE")]
        public DateTime InventoryDate {get;set;}
        [MapField("ACTUAL_PCOUNT")]
        public long ActualPhysicalCount {get;set;}
        [MapField("DELIVERIES_FROM")]
        public long DeliveryQtyFrom {get;set;}
        [MapField("DELIVERIES_MIDDLE")]
        public long DeliveriesMiddle { get; set; }
        [MapField("DELIVERIES_TO")]
        public long DeliveryQtyTo {get;set;}
        [MapField("SALES_FROM")]
        public long SalesQtyFrom {get;set;}
        [MapField("SALES_MIDDLE")]
        public long SalesMiddle { get; set; }
        [MapField("SALES_TO")]
        public long SalesQtyTo {get;set;}
        [MapField("PULL_OUT")]    
        public long PullOut {get;set;}
        [MapField("ADJUSTMENT_ADD")]
        public long AdjustmentAdd { get; set; }
        [MapField("ADJUSTMENT_LESS")]
        public long AdjustmentLess { get; set; }
        [MapField("ENDING_INVENTORY")]
        public long EndingInventory {get;set;}
        [MapField("PCOUNT")]
        public long PhysicalCount {get;set;}
        [MapField("OVER_LACKING")]
        public long OverLacking{get;set;}
        [MapField("DATE_RECORDED")]
        public DateTime DateRecorded { get; set; }
    }
}
