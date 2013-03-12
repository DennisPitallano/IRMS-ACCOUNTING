using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
namespace IRMS.ObjectModel.Views
{
    [TableName("PIRpt")]
    public class PhysicalInventoryView
    {
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public long PiID { get; set; }

        [MapField("PIYear")]
        public int Year { get; set; }

        [MapField("StyleNo")]
        public string StyleNo { get; set; }

        [MapField("BrandName")]
        public string BrandName { get; set; }

        [MapField("UnitPrice")]
        public Decimal UnitPrice { get; set; }

        [MapField("SumQty")]
        public Int64 SumQty { get; set; }

        [MapField("SumAmt")]
        public Decimal SumAmount { get; set; }

        [MapField("CostQty")]
        public Int64 CostQty { get; set; }

        [MapField("CostPrice")]
        public Decimal CostPrice { get; set; }

        [MapField("CostAmt")]
        public Decimal CostAmt { get; set; }

        [MapField("SRPQty")]
        public Int64 SRPQty { get; set; }

        [MapField("SRPPrice")]
        public Decimal SRPPrice { get; set; }

        [MapField("SRPAmt")]
        public Decimal SRPAmt { get; set; }

        [MapField("MDQty")]
        public Int64 MDQty { get; set; }

        [MapField("MDPrice")]
        public Decimal MDPrice { get; set; }

        [MapField("MDAmt")]
        public Decimal MDAmt { get; set; }

        [MapField("CatCode")]
        public string Category { get; set; }
        
    }

    public class PhysicalInventoryReportView
    {

        public string Year { get; set; }
        public string StyleNo { get; set; }
        public string Brand { get; set; }
        public string CostQty { get; set; }
        public string CostPrice { get; set; }
        public string CostAmount { get; set; }
        public string SrpQty { get; set; }
        public string SrpPrice { get; set; }
        public string SrpAmount { get; set; }
        public string MrdQty { get; set; }
        public string MrdPrice { get; set; }
        public string MrdAmount { get; set; }
       
        public string TotalQty { get; set; }
        public string TotalAmount { get; set; }

        public string TotalCostQty { get; set; }
        public string TotalCostAmount { get; set; }

        public string TotalSrpQty { get; set; }
        public string TotalSrpAmount { get; set; }

        public string TotalMrdQty { get; set; }
        public string TotalMrdAmount { get; set; }

        public string GrandTotalQty { get; set; }
        public string GrandTotalAmount { get; set; }

    }
}
