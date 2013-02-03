using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("FORWARDERS")]
    public class Forwarder
    {
        [MapField("RECORD_NUMBER"), PrimaryKey, NonUpdatable]
        public long RecordNumber { get; set; }

        [MapField("FORWARDER_NAME")]
        public string ForwarderName { get; set; }

        [MapField("FORWARDER_ADDRESS")]
        public string ForwarderAddress { get; set; }

        [MapField("FORWARDER_CONTACT")]
        public string ForwarderContact { get; set; }

        [MapField("DATE_RECORDED")]
        public DateTime DateRecorded { get; set; }
    }
}
