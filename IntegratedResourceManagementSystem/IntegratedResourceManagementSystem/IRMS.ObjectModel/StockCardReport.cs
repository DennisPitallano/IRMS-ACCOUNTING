using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;


namespace IRMS.ObjectModel
{
    [TableName("RptStockCard_new")]
    public class StockCardReport
    {
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }
        [MapField("DATEFROM")]
        public DateTime DateFrom { get; set; }
        [MapField("DATETO")]
        public DateTime DateTo { get; set; }
        [MapField("sDATE")]
        public DateTime TransDate { get; set; }
        [MapField("CUSTNO")]
        public long CustNo { get; set; }
        [MapField("COMPNAME")]
        public string CompName { get; set; }
        [MapField("BRANDNAME")]
        public string BrandName { get; set; }
        [MapField("PARTICULAR")]
        public string Particular { get; set; }
        [MapField("DEBIT_QTY")]
        public long DebitQty { get; set; }
        [MapField("DEBIT_AMT")]
        public decimal DebitAmt { get; set; }
        [MapField("DEBIT_COST")]
        public decimal DebitCost { get; set; }
        [MapField("CREDIT_QTY")]
        public long CreditQty { get; set; }
        [MapField("CREDIT_AMT")]
        public decimal CreditAmt { get; set; }
        [MapField("CREDIT_COST")]
        public decimal CreditCost { get; set; }
        [MapField("BALANCE_QTY")]
        public long BalanceQty { get; set; }
        [MapField("BALANCE_AMT")]
        public decimal BalanceAmt { get; set; }
        [MapField("BALANCE_COST")]
        public decimal BalanceCost { get; set; }
        [MapField("USERNAME")]
        public string UserName { get; set; }
    }
}
