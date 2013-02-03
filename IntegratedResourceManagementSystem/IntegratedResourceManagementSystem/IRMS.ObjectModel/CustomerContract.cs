using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    /// <summary>
    /// CLASS FOR LIST OF PAYABLES OF CUSTOMERS UNDER THEIR CONTRACT
    /// </summary>
    [TableName("CUSTOMER_PAYABLE_TBL")]
    public class CustomerPayableClass
    {
        [MapField("CUSTCODE")]
        public string CustomerCode
        {
            get;
            set;
        }

        [MapField("PAYABLE_CODE")]
        public string PayableCode
        {
            get;
            set;
        }

        [MapField("PAYABLE_AMOUNT")]
        public float PayableAmount
        {
            get;
            set;
        }
    }

    /// <summary>
    ///  CLASS FOR ALL OF COMMISSION RATES PER CUSTOMER 
    ///  EITHER OUTLET OR NON OUTLET
    /// </summary>
    [TableName("CUSTOMER_COMMISSION_TBL")]
    public class CustomerCommissionRate
    {
        [MapField("CUST_CODE")]
        public string CustomerCode { get; set; }

        [MapField("SALES_TYPE")]
        public string SalesType { get; set; }

        [MapField("FIELD_TYPE")]
        public string FieldType { get; set; }

        [MapField("FIELD_VALUE")]
        public float FieldValue { get; set; }
    }
}
