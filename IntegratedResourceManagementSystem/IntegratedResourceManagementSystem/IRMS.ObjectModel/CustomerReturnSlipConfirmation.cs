using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IRMS.ObjectModel
{
    [TableName("CRS_CONFIRMATIONS")]
    public class CustomerReturnSlipConfirmation
    {
        [MapField("RECORD_NUMBER"),PrimaryKey, NonUpdatable]
        public long RecordNumber { get; set; }
        [MapField("CRS_NUMBER")]
        public string CRSNumber { get; set; }
        [MapField("FORWARDER")]
        public string Forwarder { get; set; }
        [MapField("DESTINATION")]
        public string Destination { get; set; }
        [MapField("DATE_TRANSFER")]
        public DateTime DateTransfer { get; set; }
    }
}
