using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegratedResourceManagementSystem.Accounting.App_Code
{
    public class SOI_BeginningInventory
    {
        public decimal Volume { get; set; }
        public decimal Value { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AverageCost { get; set; }
    }
}