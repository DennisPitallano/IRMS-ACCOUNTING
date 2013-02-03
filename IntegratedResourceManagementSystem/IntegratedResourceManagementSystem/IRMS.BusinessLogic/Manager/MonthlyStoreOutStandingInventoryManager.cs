using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using System.Data;
using System.Web.UI.WebControls;
using BLToolkit.Data;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.Manager
{
    /// <summary>
    /// Author: Dennis Pitallano
    /// Date Created: September 07, 2012
    /// </summary>
    public  class MonthlyStoreOutStandingInventoryManager :LogManager<MonthlyStoreOutStandingInventory>
    {
        #region Accessor
         MonthlyStoreOutStandingInventoryAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MonthlyStoreOutStandingInventoryAccessor.CreateInstance(); }
        }
        #endregion

        public List<MonthlyStoreOutStandingInventory> MonthlySOIList()
        {
             return Accessor.Query.SelectAll<MonthlyStoreOutStandingInventory>() ?? new List<MonthlyStoreOutStandingInventory>();
        }

        public bool IsAlreadyCreated(DateTime DateFrom, DateTime DateTo,int CustomerNumber)
        {
            bool result = true;
            var soi = (from soi_ in MonthlySOIList()
                      where soi_.PeriodFrom == DateFrom && soi_.PeriodTo == DateTo && soi_.CustomerNumber == CustomerNumber
                      select soi_).FirstOrDefault();
            if (soi == null)
            {
                result = false;
            }
           
            return result;
        }

        public long GetEndingInventory(long CustomerNumber)
        {
            long EndingInventory = 0;
            var soi = (from soi_ in MonthlySOIList()
                       where soi_.CustomerNumber == CustomerNumber
                       orderby soi_.InventoryDate descending
                       select soi_).FirstOrDefault();
            if (soi != null)
            {
                EndingInventory = soi.EndingInventory;
            }

            return EndingInventory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerNumber"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
         public DataTable GetDeliveriesByCustomerAndDateRange(int CustomerNumber, DateTime DateFrom, DateTime DateTo)
         {
             return Accessor.GetMonthlySOIDeliveries(CustomerNumber, DateFrom, DateTo); 
         }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         public long DeliveriesFrom(int CustomerNumber, DateTime DateFrom, DateTime DateTo)
         {
             long result = 0;
             DataTable Deliveries = GetDeliveriesByCustomerAndDateRange(CustomerNumber, DateFrom, DateTo);
             try
             {
                 foreach (DataRow row in Deliveries.Rows)
                 {
                     result= long.Parse(row[1].ToString());
                 }
             }
             catch (Exception)
             {
                 result=0;
             }
             return result;
         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerNumber"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
         public long DeliveriesTo(int CustomerNumber, DateTime DateFrom, DateTime DateTo)
         {
             long result = 0;
             DataTable Deliveries = GetDeliveriesByCustomerAndDateRange(CustomerNumber, DateFrom, DateTo);
             try
             {
                 foreach (DataRow row in Deliveries.Rows)
                 {
                     result = long.Parse(row[1].ToString());
                 }
             }
             catch (Exception)
             {

                 result = 0;
             }
             return result;
         }

         public MonthlyStoreOutStandingInventory GetMonthlySOIByKey(long id)
         {
             return Accessor.Query.SelectByKey<MonthlyStoreOutStandingInventory>(id) ?? new MonthlyStoreOutStandingInventory();
         }

         public List<MonthlyStoreOutStandingInventory> MothlySOIList()
         {
             return Accessor.Query.SelectAll<MonthlyStoreOutStandingInventory>();
         }

         public void Save(MonthlyStoreOutStandingInventory SOI)
         {
             using (DbManager db = new DbManager())
             {
                 if (SOI.RecordNumber != 0)
                 {
                     Accessor.Query.Update(db, SOI);
                 }
                 else
                 {
                  Identity=Accessor.Query.InsertAndGetIdentity(db, SOI);
                 }
             }
         }

         public void Delete(MonthlyStoreOutStandingInventory SOI)
         {
             using (DbManager db = new DbManager())
             {
                 Accessor.Query.Delete(db, SOI);
             }
         }

        #region Filter

         public void SearchMonthlySOI(SqlDataSource soiSqlDataSource, string searchParameter)
         {
             StringBuilder strCmd = new StringBuilder();
             strCmd.Append("SELECT [RECORD_NO], [CUSTOMER], [PERIOD_FROM], [PERIOD_TO],[SOI_CODE] FROM [MONTHLY_SOI] ");
             if (!string.IsNullOrEmpty(searchParameter) || !string.IsNullOrWhiteSpace(searchParameter))
             {
                 strCmd.Append(" WHERE CUSTOMER LIKE '%" + searchParameter + "%' ");
             }
             strCmd.Append(" ORDER BY RECORD_NO DESC");
             soiSqlDataSource.SelectCommand = strCmd.ToString();
             soiSqlDataSource.DataBind();
         }

         public void FilterCustomer(SqlDataSource CustomerSqldataSource, string search_parameter,string BrandName="")
         {
             StringBuilder command = new StringBuilder();
             command.Append("SELECT [CustNo], [CompName], [brand] FROM [CustInfoEx]  ");
             if (BrandName != "")
             {
                 if (search_parameter != string.Empty)
                 {
                     command.Append(" WHERE MainCustNo is not null and brand='"+BrandName+"' and CompName LIKE '%" + search_parameter + "%' ");
                 }
             }
             else
             {
                 if (search_parameter != string.Empty)
                 {
                     command.Append(" WHERE MainCustNo is not null and CompName LIKE '%" + search_parameter + "%' ");
                 }
             }
            
             CustomerSqldataSource.SelectCommand = command.ToString();
             CustomerSqldataSource.DataBind();
         }
        #endregion
    }
}
