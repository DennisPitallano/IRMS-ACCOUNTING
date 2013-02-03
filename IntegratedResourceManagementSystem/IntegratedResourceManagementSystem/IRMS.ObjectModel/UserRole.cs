using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("USER_ROLES")]
    public class UserRole
    {
        [MapField("RECORD_NUMBER"),PrimaryKey,NonUpdatable]
        public virtual int RecordNumber { get; set; }
        [MapField("USER_ID")]
        public virtual int UserId { get; set; }
        [MapField("USER_ROLE")]
        public virtual string Role { get; set; }
        [MapField("DATE_RECORDED")]
        public virtual DateTime DateRecorded { get; set; }
    }
}
