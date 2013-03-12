using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRMS.ObjectModel.Views
{
    public class SummarySoiPerBrand
    {
        public string CustomerNames {get;set;}
        public string Brand { get; set; }
        public DateTime DateRecorded { get; set; }
        public long BookQuantity { get; set; }
        public long ActualPCount { get; set; }
        public decimal LackingOver { get; set; }
        public decimal PercentOfBookOverQty { get; set; }
        public decimal EndingInventory { get; set; }
        public decimal ActualPCountCost { get; set; }
        public decimal VarianceCost { get; set; }
        public decimal AvePerCost { get; set; }
        public decimal PercentOfCostLacking { get; set; }
    }

    public class SummarySoiPerBrandFormatted
    {
        public string CustomerNames { get; set; }
        public string Brand { get; set; }
        public DateTime DateRecorded { get; set; }
        public string BookQuantity { get; set; }
        public long ActualPCount { get; set; }
        public string LackingOver { get; set; }
        public string PercentOfBookOverQty { get; set; }
        public string EndingInventory { get; set; }
        public string ActualPCountCost { get; set; }
        public string VarianceCost { get; set; }
        public string AvePerCost { get; set; }
        public string PercentOfCostLacking { get; set; }
    }
}
