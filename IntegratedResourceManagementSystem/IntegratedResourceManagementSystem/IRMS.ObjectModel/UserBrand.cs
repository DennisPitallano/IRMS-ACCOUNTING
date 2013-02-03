using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;
namespace IRMS.ObjectModel
{
    [TableName("USER_BRANDS")]
    public  class UserBrand
    {
        [MapField("RECORD_NO"),PrimaryKey,NonUpdatable]
        public virtual int RecordNumber {get;set;}
        [MapField("USER_ID")]
        public virtual int UserId {get;set;}
        [MapField("BRAND")]
        public virtual string BrandName {get;set;}
        [MapField("DATE_RECORDED")]
        public virtual DateTime DateRecorded { get; set; }
    }
}
