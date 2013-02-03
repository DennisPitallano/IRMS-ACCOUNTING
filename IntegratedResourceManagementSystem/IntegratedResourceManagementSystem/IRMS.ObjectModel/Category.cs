using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("CATEGORIES")]
    public class Category
    {
        [MapField("RECORD_NO"), PrimaryKey ,NonUpdatable]
        public Int64 RecordNo { get; set; }

        [MapField("CATEGORY_CODE")]
        public string CategoryCode { get; set; }

        [MapField("CATEGORY_DESCRIPTION")]
        public string CategoryDescription { get; set; }

        [MapField("DATE_RECORDED")]
        public DateTime DateCreated { get; set; }

        [MapField ("IS_ACTIVE")]
        public string IsActive { get; set; }
    }
}
