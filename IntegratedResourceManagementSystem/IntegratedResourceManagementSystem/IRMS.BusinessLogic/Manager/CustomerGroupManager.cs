using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.ObjectModel;
using IRMS.BusinessLogic.DataAccess;
using BLToolkit.Data;
using IRMS.Entities;

namespace IRMS.BusinessLogic.Manager
{
    public class CustomerGroupManager
    {

        #region Accessor
        CustomerGroupAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return CustomerGroupAccessor.CreateInstance(); }
        }
        #endregion

        public List<CustomerGroup> GetAllCustomerGroup()
        {
            return Accessor.ListGroupOfCustomers();
        }

        public IEnumerable<object> GetCustomerGroupOrderByCustomer()
        {

            var Objects = (from Cust in Accessor.ListGroupOfCustomers()
                           group Cust by Cust.Customer into GroupName
                           select new
                           {
                               Customer = GroupName.Key
                           }).OrderBy(x => x.Customer.First()).ToList();
                            
            return Objects;

           
        }

    }
}
