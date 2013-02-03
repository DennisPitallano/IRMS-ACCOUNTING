using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName ("BRANDS")]
    public class Brand
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("BRAND_CODE")]
        public string BrandCode { get; set; }

        [MapField("BRAND_DESCRIPTION")]
        public string BrandDescription { get; set; }

        [MapField("DATE_RECORDED")]
        public DateTime DateCreated { get; set; }

        [MapField("IS_ACTIVE")]
        public string IsActive { get; set; }
    }
}
