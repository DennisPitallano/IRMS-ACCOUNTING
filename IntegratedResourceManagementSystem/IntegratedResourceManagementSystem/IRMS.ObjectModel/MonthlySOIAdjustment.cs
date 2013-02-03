using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("MONTHLY_SOI_ADJUSTMENTS")]
    public class MonthlySOIAdjustment
    {
        [MapField("RECORD_NO"),PrimaryKey ,NonUpdatable ]
        public long RecordNumber {get;set;}
        [MapField("SOI_CODE")]
        public string SOICode{get;set;}
        [MapField("TYPE")]
        public string Type{get;set;}
        [MapField("PARTICULAR")]
        public string Particular {get;set;}
        [MapField("QUANTITY")]
        public long Quantity {get;set;}
        [MapField("DATE_RECORDED")]
        public DateTime DateRecorded { get; set; }
    }
}
