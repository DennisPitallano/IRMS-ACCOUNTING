using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Mapping;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
    {
    [TableName("SI")]
    public class SalesInvoiceClass
        {

        [MapField("ID"), PrimaryKey, NonUpdatable]
        public long id { get; set; }

        [MapField("SIID")]
        public Nullable<long> siid { get; set; }

        [MapField("SINo")]
        public string si_no { get; set; }

        [MapField("SIDate")]
        public DateTime si_date { get; set; }

        [MapField("CustNo")]
        public long cust_no { get; set; }

        [MapField("SoldTo")]
        public string sold_to { get; set; }

        [MapField("CustAddr")]
        public string cust_addr { get; set; }

        [MapField("TIN")]
        public string tin { get; set; }

        [MapField("ShipToAddr")]
        public string ship_to_addr { get; set; }

         [MapField("PONo")]
        public string po_no { get; set; }

        [MapField("Salesman")]
        public string sales_man { get; set; }
    
        [MapField("SONo")]
        public string so_no { get; set; }

        [MapField("Terms")]
        public string terms { get; set; }

        [MapField("TotalAmt")]
        public Nullable<float> total_amt { get; set; }

        [MapField("TotalQty")]
        public Nullable<long> total_qty { get; set; }

        [MapField("InvoiceVal")]
        public Nullable<float> invoice_val { get; set; }

        [MapField("Via")]
        public string via { get; set; }

        [MapField("BrandName")]
        public string brand_name { get; set; }
        
        [MapField("PLNo")]
        public string pl_no { get; set; }

        [MapField("BoxSackNo")]
        public Nullable<long> boxsack_no { get; set; }

        [MapField("Company")]
        public string company { get; set; }

        [MapField("PreparedBy")]
        public string prep_by { get; set; }

        [MapField("Remarks")]
        public string remarks { get; set; }

         [MapField("ItemStatus")]
        public string item_status { get; set; }

        [MapField("WayBillNo")]
        public string waybill_no { get; set; }

        [MapField("Forwarder")]
        public string forwarder { get; set; }

         [MapField("ConfirmedDate")]
        public Nullable<DateTime> confirmed_date { get; set; }

          [MapField("TransitStatus")]
        public string transit_status { get; set; }

          [MapField("DiscType")]
        public string disc_type { get; set; }

         [MapField("SubTotal")]
        public Nullable<float> sub_total { get; set; }

        [MapField("DiscReg")]
        public Nullable<float> disc_reg { get; set; }

        [MapField("PercReg")]
        public Nullable<int> perc_reg { get; set; }

         [MapField("DiscMD")]
        public Nullable<float> disc_MD { get; set; }

         [MapField("PercMD")]
        public Nullable<int> perc_md { get; set; }

        [MapField("InvoiceAmt")]
        public Nullable<float> inv_amt { get; set; }

        [MapField("ynLiquidation")]
        public int yn_liquidation{ get; set; }

         [MapField("ynPosted")]
        public int yn_posted { get; set; }

          [MapField("ynCancelled")]
        public int yn_cancelled{ get; set; }


        }
    public class SIClass
    {

    [MapField("ID"), PrimaryKey, NonUpdatable]
    public long id { get; set; }
  
    [MapField("SINo")]
    public string si_no { get; set; }

    [MapField("SIDate")]
    public DateTime si_date { get; set; }

    [MapField("CustNo")]
    public long cust_no { get; set; }

    [MapField("SoldTo")]
    public string sold_to { get; set; }

    [MapField("CustAddr")]
    public string cust_addr { get; set; }

    [MapField("TIN")]
    public string tin { get; set; }

    [MapField("TotalAmt")]
    public float total_amt { get; set; }

    [MapField("Company")]
    public string company { get; set; }

    [MapField("PreparedBy")]
    public string prep_by { get; set; }

    [MapField("TransitStatus")]
    public string transit_status { get; set; }

    [MapField("ynLiquidation")]
    public int yn_liquidation { get; set; }

     }
    }
