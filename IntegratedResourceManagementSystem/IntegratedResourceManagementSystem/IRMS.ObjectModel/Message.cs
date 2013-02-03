using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("MESSAGES")]
    public class Message
    {
        [MapField("RECORD_NO"), PrimaryKey ,NonUpdatable ]
        public long RecordNumber { get; set; }
        [MapField("FROM_USER_ID")]
        public long FromUserId { get; set; }
        [MapField("TO_USER_ID")]
        public long ToUserId { get; set; }
        [MapField("SUBJECT")]
        public string Subject { get; set; }
        [MapField("MESSAGE")]
        public string MessageContent { get; set; }
        [MapField("DATE_SENT")]
        public DateTime DateSent { get; set; }
        [MapField("STATUS")]
        public string Status { get; set; }
    }
}
