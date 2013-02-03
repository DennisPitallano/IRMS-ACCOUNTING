using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("INVENTORY_GROUPS")]
    public class InventoryGroup
    {
        [MapField("INVENTORY_GROUP_ID"),PrimaryKey,NonUpdatable]
        public long InventoryGroupId { get; set; }
        [MapField("GROUP_NAME")]
        public string GroupName { get; set; }
    }
}
