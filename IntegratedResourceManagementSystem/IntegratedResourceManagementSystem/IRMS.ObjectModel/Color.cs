using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("COLORS")]
    public class Color
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("COLOR_CODE")]
        public string ColorCode { get; set; }

        [MapField("COLOR_DESCRIPTION")]
        public string ColorDescription { get; set; }

        [MapField("DATE_RECORDED")]
        public DateTime DateCreated { get; set; }

        [MapField("IS_ACTIVE")]
        public string IsActive { get; set; }
    }
}
