using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.Entities;
using System.Web.UI.WebControls;

namespace IRMS.BusinessLogic.Manager
{
    public class CustomerManager
    {
        #region Accessor
        CustomerAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CustomerAccessor.CreateInstance(); }
        }
        #endregion
        public Customer GetCustomerByKey(long id)
        {
            return Accessor.Query.SelectByKey<Customer>(id) ?? new Customer();
        }

        public List<Customer> Customers()
        {
            return Accessor.Customers();
        }

        public List<Customer> AllCustomers()
        {
            return Accessor.Query.SelectAll<Customer>();
        }

        #region Adjustment Panel
        public SqlDataSource SearchOutletDataSource(SqlDataSource sql_data_source, string search_parameter, string Brand)
        {
            //if (Brand != "ALL")
            //{
                //if (search_parameter != string.Empty)
            //    {
            //        sql_data_source.SelectCommand = "SELECT [CustNo], [CompName], [brand] FROM [CustInfo] where brand ='"+ Brand +"' and CompName Like '%" + 
            //            search_parameter + "%'";
            //    }
            //    else
            //    {
            //        sql_data_source.SelectCommand = "SELECT [CustNo], [CompName], [brand] FROM [CustInfo] where brand ='" + Brand + "' ";
            //    }
            //}
            //else
            //{
                if (search_parameter != string.Empty)
                {
                    sql_data_source.SelectCommand = "SELECT [CustNo], [CompName], [brand] FROM [CustInfo] where CompName Like '%" +
                        search_parameter + "%'";
                }
                else
                {
                    sql_data_source.SelectCommand = "SELECT [CustNo], [CompName], [brand] FROM [CustInfo] ";
                }
            //}
            sql_data_source.DataBind();
            return sql_data_source;
        }
        #endregion
        public SqlDataSource SearchCustomerDataSource(SqlDataSource sql_data_source, string search_parameter)
            {          
            if (search_parameter != string.Empty)
                {
                sql_data_source.SelectCommand = "Select [CustNo],a.[CompName],[Brand],[Addr1],[TIN],b.CompName from [CustInfo] a inner join [Company] b on b.CompNo = a.CompNo where ynLiquidation = 1 and a.[CompName] like '%" + search_parameter +"%'" ;
                }
            else
                {
                sql_data_source.SelectCommand = "Select [CustNo],a.[CompName],[Brand],[Addr1],[TIN],b.CompName from [CustInfo] a inner join [Company] b on b.CompNo = a.CompNo where ynLiquidation = 1";
                }
            sql_data_source.DataBind();
            return sql_data_source;
            }
    }
}
