using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("STORE_OUTSTANDING_INVENTORIES")]
    public class StoreOutStandingInventory
    {
        [MapField("RECORD_NO"),PrimaryKey,NonUpdatable]
        public long RecordNumber {get;set;}
        [MapField("CUSTOMER_NO")]
        public int CustomerNumber {get;set;}
        [MapField("CUSTOMER")]
        public string CustomerName {get;set;}
        [MapField("PERIOD_FROM")]
        public DateTime PeriodFrom {get;set;}
        [MapField("PERIOD_TO")]
        public DateTime PeriodTo {get;set;}
        [MapField("BEGINNING_INVENTORY_VOLUME")]
        public decimal BeginningInventoryVolume { get; set; }
        [MapField("BEGINNING_INVENTORY_VALUE")]
        public decimal BeginningInventoryValue {get;set;}
        [MapField("BEGINNING_INVENTORY_AVG_COST")]
        public decimal BeginningInventoryAverageCost {get;set;}
        [MapField("BEGINNING_INVENTORY_TOTAL_COST")]
        public decimal BeginningInventoryTotalCost {get;set;}
        [MapField("DELIVERY_VOLUME")]
        public decimal DeliveryVolume { get; set; }
        [MapField("DELIVERY_VALUE")]
        public decimal DeliveryValue {get;set;}
        [MapField("DELIVERY_AVG_COST")]
        public decimal DeliveryAverageCost {get;set;}
        [MapField("DELIVERY_TOTAL_COST")]
        public decimal DeliveryTotalCost {get;set;}
        [MapField("RETURNS_VOLUME")]
        public decimal ReturnsVolume { get; set; }
        [MapField("RETURNS_VALUE")]
        public decimal ReturnsValue {get;set;}
        [MapField("RETURNS_AVG_COST")]
        public decimal ReturnsAverageCost {get;set;}
        [MapField("RETURNS_TOTAL_COST")]
        public decimal ReturnsTotalCost {get;set;}
        [MapField("GROSS_SALES_VOLUME")]
        public decimal GrossSalesVolume {get;set;}
        [MapField("GROSS_SALES_VALUE")]
        public decimal GrossSalesValue {get;set;}
        [MapField("GROSS_SALES_AVG_COST")]
        public decimal GrossSalesAverageCost {get;set;}
        [MapField("GROSS_SALES_TOTAL_COST")]
        public decimal GrossSalesTotalCost {get;set;}
        [MapField("ADJUSTMENT_RECORD_NO")]
        public long AdjustmentRecordNumber {get;set;}
        [MapField("ADJ_DEBIT_VOLUME")]
        public decimal AdjustmentDebitVolume { get; set; }
        [MapField("ADJ_DEBIT_VALUE")]
        public decimal AdjustmentDebitValue {get;set;} 
        [MapField("ADJ_DEBIT_AVG_COST")]
        public decimal AdjustmentDebitAverageCost {get;set;}
        [MapField("ADJ_DEBIT_TOTAL_COST")]
        public decimal AdjustmentDebitTotalCost {get;set;}
        [MapField("ADJ_CREDIT_VOLUME")]
        public decimal AdjustmentCreditVolume {get;set;}
        [MapField("ADJ_CREDIT_VALUE")]
        public decimal AdjustmentCreditValue {get;set;}
        [MapField("ADJ_CREDIT_AVG_COST")]
        public decimal AdjustmentCreditAverageCost {get;set;}
        [MapField("ADJ_CREDIT_TOTAL_COST")]
        public decimal AdjustmentCreditTotalCost {get;set;}
        [MapField("ENDING_INVENTORY_VOLUME")]
        public decimal EndingInventoryVolume { get; set; }
        [MapField("ENDING_INVENTORY_VALUE")]
        public decimal EndingInventoryValue {get;set;}
        [MapField("ENDING_INVENTORY_AVG_COST")]
        public decimal EndingInventoryAverageCost {get;set;}
        [MapField("ENDING_INVENTORY_TOTAL_COST")]
        public decimal EndingInventoryTotalCost {get;set;}
        [MapField("ACTUAL_COUNT_VOLUME")]
        public decimal ActualCountVolume {get;set;}
        [MapField("ACTUAL_COUNT_VALUE")]
        public decimal ActualCountValue {get;set;}
        [MapField("ACTUAL_COUNT_AVG_COST")]
        public decimal ActualCountAverageCost {get;set;}
        [MapField("ACTUAL_COUNT_TOTAL_COST")]
        public decimal ActualCostTotalCost {get;set;}
        [MapField("DISCREPANCY_VOLUME")]
        public decimal DiscrepancyVolume { get; set; }
        [MapField("DISCREPANCY_VALUE")]
        public decimal DiscrepancyValue {get;set;}
        [MapField("DISCREPANCY_TOTAL_COST")]
        public decimal DiscrepancyTotalCost { get; set; }
        [MapField("TRANSACTION_DATE")]
        public DateTime TransactionDate { get; set; }
        [MapField("BRAND")]
        public string Brand { get; set; }
        [MapField("DATE_RECORDED")]
        public DateTime DateRecorded { get; set; }
    }
}
