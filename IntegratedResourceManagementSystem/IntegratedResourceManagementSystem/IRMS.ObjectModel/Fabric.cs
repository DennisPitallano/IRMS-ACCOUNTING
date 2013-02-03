using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("FABRICS")]
    public class Fabric
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("FABRIC_CODE")]
        public string FabricCode { get; set; }

        [MapField("FABRIC_DESCRIPTION")]
        public string FabricDescription { get; set; }

        [MapField("TOP_OR_BOTTOM")]
        public char TopOrBottom { get; set; }

        [MapField("DATE_RECORDED")]
        public DateTime DateCreated { get; set; }

        [MapField("IS_ACTIVE")]
        public string IsActive { get; set; }
    }
}
