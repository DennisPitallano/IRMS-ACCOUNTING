using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Mapping;
using BLToolkit.DataAccess;


namespace IRMS.ObjectModel
{
    [TableName("CUSTINFO")]
    public class OutletClass : CustomerInfo
    {
    }


    //[TableName("CUSTCONTRACT")]
    //public class OutletContract : CustomerContract
    //{      
    //}

    [TableName("CUSTOMER_REF_TBL")]
    public class OutletReferenceLink : CustomerReferenceLink
    {
    }

}