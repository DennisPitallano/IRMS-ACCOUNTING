using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Mapping;
using BLToolkit.Common;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("Sizes")]
    public class Size 
    {
        [MapField("RECORD_NO"), PrimaryKey , NonUpdatable]
        public virtual long RecordNo { get; set; }
      
        [MapField("SIZE_CODE")]
        public virtual string SizeCode { get; set; }

        [MapField("SIZE_DESCRIPTION")]
        public virtual string SizeDescription { get; set; }

        [MapField("DATE_RECORDED")]
        public virtual DateTime DateCreated { get; set; }
    }
}
