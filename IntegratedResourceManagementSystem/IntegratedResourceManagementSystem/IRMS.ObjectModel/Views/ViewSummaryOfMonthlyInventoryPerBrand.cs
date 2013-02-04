using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
namespace IRMS.ObjectModel.Views
{
    public class ViewSummaryOfMonthlyInventoryPerBrand
    {

        [MapField("DATE_FROM")]
        public DateTime DateFrom { get; set; }
        [MapField("DATE_TO")]
        public DateTime DateTo { get; set; }

        [MapField("CUSTOMER")]
        public string Customer { get; set; }
        [MapField("BRAND_NAME")]
        public string BrandName { get; set; }
        [MapField("CUSTOMER_TYPE")]
        public string CustomerType { get; set; }

        [MapField("BALANCE_QTY")]
        public int BalQuantity { get; set; }
        [MapField("BALANCE_AMT")]
        public Decimal BalanceAmount { get; set; }
        [MapField("BALANCE_COST")]
        public Decimal BalanceCost { get; set; }

        [MapField("DR_QTY")]
        public int DrQuantity { get; set; }
        [MapField("DR_AMT")]
        public Decimal DrAmount { get; set; }
        [MapField("DR_COST")]
        public Decimal DrCost { get; set; }

        [MapField("RETURN_QTY")]
        public int ReturnQuantoty { get; set; }
        [MapField("RETURN_AMT")]
        public Decimal ReturnAmount { get; set; }
        [MapField("RETURN_COST")]
        public Decimal ReturnCost { get; set; }

        [MapField("SALES_QTY")]
        public int SaleQuantity { get; set; }
        [MapField("SALES_AMT")]
        public Decimal SaleAmount { get; set; }
        [MapField("SALES_COST")]
        public Decimal SaleCost { get; set; }

        [MapField("ADJ_QTY")]
        public int AdjQuantity { get; set; }
        [MapField("ADJ_AMT")]
        public Decimal AdjAmount { get; set; }
        [MapField("ADJ_COST")]
        public Decimal AdjCost { get; set; }

        [MapField("USERNAME")]
        public string UserName { get; set; }
 

    }
}
