using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Mapping;
using BLToolkit.DataAccess;
using BLToolkit.Data;
using System.Data;

namespace IRMS.ObjectModel
{

    public enum LiquidationStatus
    {
        No = 0,
        Yes = 1
    };

    public enum ActiveStatus
    {
        Inactive = 0,
        Active = 1,
        Pending = 2
    };

    [TableName("CUSTINFO")]
    public class CustomerInfo
    {
        [MapField("CustNo"), PrimaryKey, NonUpdatable]
        public int CustomerNo { get; set; }

        [MapField("CompName")]
        public string CompanyName { get; set; }

        [MapField("MainCustNo")]
        public string MainCustomerNo { get; set; }

        [MapField("CustCode")]
        public string CustomerCode { get; set; }

        [MapField("CustType")]
        public string CustomerType { get; set; }

        [MapField("Brand")]
        public string BrandName { get; set; }

        [MapField("CBrand")]
        public string CBrand { get; set; }

        [MapField("Agent")]
        public string AgentName { get; set; }

        [MapField("PGNo")]
        public int PriceGroupNo { get; set; }

        [MapField("PGMDNo")]
        public int PriceGroupMarkdownNo { get; set; }

        [MapField("AGNo")]
        public int AreaGroupNo { get; set; }

        [MapField("SAGNo")]
        public int SubAreaGroupNo { get; set; }

        [MapField("BrandNameNo")]
        public int BrandNameNo { get; set; }

        [MapField("BrandNameNo2")]
        public int BrandNameNo2 { get; set; }

        [MapField("CompNo")]
        public int CompanyNo { get; set; }

        [MapField("ArrangeType")]
        public string ArrangementType { get; set; }

        [MapField("Addr1")]
        public string AddressOne { get; set; }

        [MapField("Addr2")]
        public string AddressTwo { get; set; }

        [MapField("TIN")]
        public string TIN_No { get; set; }

        [MapField("ContactPerson")]
        public string ContactPerson { get; set; }

        [MapField("ContactPosition")]
        public string DesignationPost { get; set; }

        [MapField("TelNo")]
        public string TelephoneNo { get; set; }

        [MapField("MobileNo")]
        public string CellphoneNo { get; set; }

        [MapField("FaxNo")]
        public string FaxNo { get; set; }

        [MapField("BillingAddr")]
        public string BillingAddress { get; set; }

        [MapField("ShipToAddr")]
        public string ShippingAddress { get; set; }

        //FIELD NOT IN USED
        [MapField("OrderedList")]
        public string OrderedList { get; set; }

        [MapField("CreditLimit")]
        public float CreditLimit { get; set; }

        [MapField("Terms")]
        public string Terms { get; set; }

        [MapField("ContractDate")]
        public DateTime ContractDate { get; set; }

        [MapField("Remarks")]
        public string MemoRemarks { get; set; }

        [MapField("Regular")]
        public float CommissionRegular { get; set; }

        [MapField("Markdown")]
        public float CommissionMarkdown { get; set; }

        [MapField("OutletName")]
        public string OutletName { get; set; }

        [MapField("ApprovedBy")]
        public string ApprovedBy { get; set; }

        [MapField("MSNo")]
        public string MSNo { get; set; }

        [MapField("ynHeadOffice")]
        public bool HeadOfficeStatus { get; set; }

        [MapField("ynLiquidation")]
        public int LiquidationStatus { get; set; }

        [MapField("ynApproved")]
        public bool ApprovalStatus { get; set; }

        [MapField("ynActive")]
        public bool ActiveStatus { get; set; }
    }

    //[TableName("CUSTCONTRACT")]
    //public class CustomerContract
    //{
    //    [MapField("CCNo")]
    //    public int CustomerContractNo { get; set; }

    //    [MapField("CustNo")]
    //    public int CustomerNo { get; set; }

    //    [MapField("CompName")]
    //    public string CompanyName { get; set; }

    //    [MapField("MinMargin")]
    //    public float MinimumMargin { get; set; }

    //    [MapField("RentFeeType")]
    //    public string RentFeeType { get; set; }

    //    [MapField("SalesDisc")]
    //    public float SalesDiscount { get; set; }

    //    [MapField("SalesDiscType")]
    //    public string SalesDiscountType { get; set; }

    //    [MapField("AddlDisc")]
    //    public float AdditionalDiscount { get; set; }

    //    [MapField("AddlDiscType")]
    //    public string AdditionalDiscountType { get; set; }

    //    [MapField("UtilFee")]
    //    public float UtilityFee { get; set; }

    //    [MapField("UtilFeeType")]
    //    public string UtilityFeeType { get; set; }

    //    [MapField("StockrmFee")]
    //    public float StockRoomFee { get; set; }

    //    [MapField("StockrmFeeType")]
    //    public string StockRoomFeeType { get; set; }

    //    [MapField("Advertising")]
    //    public float AdvertiseFee { get; set; }

    //    [MapField("AdvertisingType")]
    //    public string AdvertiseType { get; set; }

    //    [MapField("Formula")]
    //    public string Formula { get; set; }

    //    [MapField("WTax")]
    //    public float WithTax { get; set; }

    //    [MapField("PromoFrom")]
    //    public DateTime PromoFrom { get; set; }

    //    [MapField("PromoTo")]
    //    public DateTime PromoTo { get; set; }

    //    [MapField("PromoRate")]
    //    public float PromoRate { get; set; }

    //    [MapField("PromoPersons")]
    //    public int PromoPersons { get; set; }

    //    [MapField("CommRegular")]
    //    public float CommissionRegular { get; set; }

    //    [MapField("CommMarkDown")]
    //    public float CommissionMarkdown { get; set; }

    //    [MapField("CommCharge")]
    //    public float CommissionCharge { get; set; }

    //    [MapField("CommAddl")]
    //    public float CommissionAdditional { get; set; }

    //    [MapField("FiftyMore")]
    //    public float FiftyMore { get; set; }

    //    [MapField("FiftyMoreChrge")]
    //    public float FiftyMoreCharge { get; set; }

    //    [MapField("FiftyLess")]
    //    public float FiftyLess { get; set; }

    //    [MapField("FiftyLessChrg")]
    //    public float FiftyLessCharge { get; set; }

    //    [MapField("Freight")]
    //    public float FreightAmount { get; set; }

    //    [MapField("Others")]
    //    public float OtherAmount { get; set; }

    //    [MapField("OthersType")]
    //    public string OtherType 
    //    { get; set; }
       
    //    [MapField("OutrightReg")]
    //    public float OutrightRegular { get; set; }

    //    [MapField("OutrightMD")]
    //    public float OutrightMarkdown { get; set; }

    //    [MapField("CashRegDisc")]
    //    public int CashRegularDiscount { get; set; }

    //    [MapField("CashMDDisc")]
    //    public int CashMarkdownDiscount { get; set; }

    //    [MapField("ChrgRegDisc")]
    //    public int ChargeRegularDiscount { get; set; }

    //    [MapField("ChrgMDDisc")]
    //    public int ChargeMarkdownDiscount { get; set; }

    //}

    [TableName("CUSTOMER_REF_TBL")]
    public class CustomerReferenceLink
    {
        [MapField("RECORD_NO"), PrimaryKey, NonUpdatable]
        public long RecordNo { get; set; }

        [MapField("ACCT_CODE")]
        public string AccountCode { get; set; }

        [MapField("BRANCH_CODE")]
        public string BranchCode { get; set; }

        [MapField("BRAND_CODE")]
        public string BrandCode { get; set; }

        [MapField("CUSTCODE")]
        public string CustomerCode { get; set; }

        [MapField("COLLECTION_ADDRESS")]
        public string CollectionAddress { get; set; }

        //[MapField("DEPT_CODE")]
        //public string DepartmentCode { get; set; }
    }

    public class CustomerListHandler
    {
        [MapField("ACCT_CODE")]
        public string AccountCode
        {
            get;
            set;
        }
        [MapField("ACCT_NAME")]
        public string AccountName
        {
            get;
            set;
        }
        [MapField("BRANCH_CODE")]
        public string BranchCode
        {
            get;
            set;
        }
        [MapField("BRANCH_NAME")]
        public string BranchName
        {
            get;
            set;
        }

        [MapField("BRAND_CODE")]
        public string BrandCode
        {
            get;
            set;
        }
        [MapField("BRAND_DESCRIPTION")]
        public string BrandName
        {
            get;
            set;
        }
        [MapField("CUSTCODE")]
        public string CustomerCode
        {
            get;
            set;
        }
        [MapField("COMPNAME")]
        public string CustomerName
        {
            get;
            set;
        }
        [MapField("AGNO")]
        public string AreaCode
        {
            get;
            set;
        }
        [MapField("AREANAME")]
        public string AreaName
        {
            get;
            set;
        }
        [MapField("SAGNO")]
        public string SubAreaCode
        {
            get;
            set;
        }
        [MapField("SUBAREANAME")]
        public string SubAreaName
        {
            get;
            set;
        }
        [MapField("CONTRACTDATE")]
        public DateTime DateStart
        {
            get;
            set;
        }
    }


    /// <summary>
    /// CLASS FOR LIST OF COMMISSIONS PER SALES TYPE
    /// * HANDLER OF COMMISSION TYPES IN THE COMMISSION_LIST_TBL 
    /// * USED BY CUSTOMER OBJECTS EITHER OUTLET OR NON OUTLET
    /// * USED IN CUSTOMER CONTRACTS(OUTLET OR NON OUTLET)
    /// </summary>
    [TableName("COMMISSION_LIST_TBL")]
    public class CommissionListClass
    {
        [MapField("SALES_TYPE")]
        public string SalesType { get; set; }

        [MapField("FIELD_TYPE")]
        public string FieldType { get; set; }
    }

    /// <summary>
    /// CLASS FOR LIST OF COMMISSIONS RATES
    /// * HANDLER OF INDICATED RATES IN THE COMMISSION_RATE_TBL IN RELATION TO COMMISSION LIST
    /// * USED IN CUSTOMER CONTRACTS(OUTLET OR NON OUTLET) 
    /// </summary>
    [TableName("COMMISSION_RATE_TBL")]
    public class CommissionRateClass
    {
        [MapField("RATE_DESC")]
        public string RateDescription { get; set; }

        [MapField("RATE_VALUE")]
        public float RateValue { get; set; }
    }

    /// <summary>
    /// CLASS FOR LIST OF PAYABLES OF CUSTOMERS UNDER CONTRACT
    /// </summary>
    [TableName("PAYABLE_LIST_TBL")]
    public class PayableClass
    {
        [MapField("PAYABLE_CODE")]
        public string PayableCode
        {
            get;
            set;
        }

        [MapField("PAYABLE_NAME")]
        public string PayableName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Accessor class of CustomerCommissionRate class
    /// </summary>
    public class CustomerCommissionRateListAccessor
    {
        private List<CustomerCommissionRate> commList = new List<CustomerCommissionRate>();
        public CustomerCommissionRateListAccessor()
        {
        }

        public void AddCommission(CustomerCommissionRate comm)
        {
            commList.Add(comm);
        }
        public List<CustomerCommissionRate> AllCommission
        {
            get { return commList; }
            set { commList = value; }
        }
        public bool FindCommissionListByCustomerCode(string CustomerCode)
        {
            bool bResult = false;

            using (DbManager db = new DbManager())
            {
                try
                {
                    db.Command.CommandText = string.Format(@"select * from CUSTOMER_COMMISSION_TBL 
where CUSTCODE = '{0}'",CustomerCode);

                    using (IDataReader dbReader = (IDataReader)db.ExecuteReader())
                    {
                        CustomerCommissionRate commrate;
                        commList.Clear();
                        while (dbReader.Read())
                        {
                            commrate = new CustomerCommissionRate();
                            commrate.CustomerCode = CustomerCode;
                            commrate.FieldType = dbReader.GetString(dbReader.GetOrdinal("FIELD_TYPE"));
                            commrate.FieldValue = (float)Convert.ToDecimal(dbReader.GetValue(dbReader.GetOrdinal("FIELD_VALUE")));
                            commrate.SalesType = dbReader.GetString(dbReader.GetOrdinal("SALES_TYPE"));

                            commList.Add(commrate);
                            bResult = true;
                        }
                        dbReader.Close();
                    }
                }
                catch (Exception except)
                {
                    throw new Exception("Error in retrieving commission rates!");
                }
            }
            return bResult;
        }
    }

    public class CustomerPayableListAccessor
    {
        private List<CustomerPayableClass> payableList = new List<CustomerPayableClass>();
        public CustomerPayableListAccessor()
        {
        }
        public void AddPayable(CustomerPayableClass payable)
        {
            payableList.Add(payable);
        }
        public List<CustomerPayableClass> AllPayables
        {
            get { return payableList; }
            set { payableList = value; }
        }
        public bool FindPayableListByCustomerCode(string CustomerCode)
        {
            bool bResult = false;

            using (DbManager db = new DbManager())
            {
                try
                {
                    db.Command.CommandText = string.Format(@"select * from CUSTOMER_PAYABLE_TBL 
where CUSTCODE = '{0}'", CustomerCode);

                    using (IDataReader dbReader = (IDataReader)db.ExecuteReader())
                    {
                        CustomerPayableClass commpayable;
                        payableList.Clear();
                        while (dbReader.Read())
                        {
                            commpayable = new CustomerPayableClass();
                            commpayable.CustomerCode = CustomerCode;
                            commpayable.PayableCode = dbReader.GetString(dbReader.GetOrdinal("PAYABLE_CODE"));
                            commpayable.PayableAmount = (float)Convert.ToDecimal(dbReader.GetValue(dbReader.GetOrdinal("PAYABLE_AMOUNT")));

                            payableList.Add(commpayable);
                            bResult = true;
                        }
                        dbReader.Close();
                    }
                }
                catch (Exception except)
                {
                    throw new Exception("Error in retrieving payable obligation!");
                }
            }
            return bResult;
        }
    }


}