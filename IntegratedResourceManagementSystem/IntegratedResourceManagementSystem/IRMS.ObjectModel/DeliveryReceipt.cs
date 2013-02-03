using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("DR")]
    public class DeliveryReceipt
    {
        [MapField("ID"),PrimaryKey ,NonUpdatable]
        public virtual long RecordNo { get; set; }
        [MapField("drid")]
        public virtual int DR_ID { get; set; }
        [MapField("DRNo")]
        public virtual string DeliveryReceiptNumber { get; set; }
        [MapField("DRDate")]
        public virtual DateTime DRDate { get; set; }
        [MapField("CustNo")]
        public virtual int CustomerNumber { get; set; }
        [MapField("DeliveredTo")]
        public virtual string DeliveredTo { get; set; }
        [MapField("CustAddr")]
        public virtual string CustomerAddress { get; set; }
        [MapField("Salesman")]
        public virtual string SalesMan { get; set; }
        [MapField("PONo")]
        public virtual string PONumber { get; set; }
        [MapField("Terms")]
        public virtual string Terms { get; set; }
        [MapField("TotalAmt")]
        public virtual double TotalAmount { get; set; }
        [MapField("TotalQty")]
        public virtual int TotalQuantity { get; set; }
        [MapField("Remark")]
        public virtual string Remark { get; set; }
        [MapField("RecdBy")]
        public virtual  string RecordBy { get; set; }
        [MapField("RecdDate")]
        public virtual string RecordDate { get; set; }
        [MapField("BrandName")]
        public virtual string BrandName { get; set; }
        [MapField("PLNo")]
        public virtual string PLNumber { get; set; }
        [MapField("BoxSackNo")]
        public virtual string BoxSackNumber { get; set; }
        [MapField("Company")]
        public virtual string Company { get; set; }
        [MapField("PreparedBy")]
        public virtual string PreparedBy { get; set; }
        [MapField("Remarks")]
        public virtual string Remarks { get; set; }
        [MapField("ItemStatus")]
        public virtual string ItemStatus { get; set; }
        [MapField("WayBillNo")]
        public virtual string WayBillNumber { get; set; }
        [MapField("Forwarder")]
        public virtual string Forwarder { get; set; }
        [MapField("ConfirmedDate")]
        public DateTime ConfirmedDate { get; set; }
        [MapField("TransitStatus")]
        public virtual string TransitStatus { get; set; }
        [MapField("ynLiquidation")]
        public virtual bool YesNoLiquidation { get; set; }
        [MapField("ynPosted")]
        public virtual bool YesNoPosted { get; set; }
        [MapField("ynCancelled")]
        public virtual bool YesNoCancelled { get; set; }
    }
}

