using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("CUSTGROUP")]
    public class CustomerGroupClass
    {
        [MapField("CUSTTYPE")]
        public string CustomerGroupID { get; set; }

        [MapField("CUSTDESC")]
        public string CustomerDescription { get; set; }
    }

    [TableName("CUSTOMER_TYPE_TBL")]
    public class CustomerTypeClass
    {
        [MapField("CUST_TYPE_ID")]
        public string CustomerTypeID { get; set; }

        [MapField("CUST_TYPE_DESC")]
        public string CustomerTypeDescription { get; set; }
    }
}