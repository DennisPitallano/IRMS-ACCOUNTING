using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IRMS.Entities;
using BLToolkit.DataAccess;//from old table Design mapping

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class CustomerAccessor : AccessorBase<CustomerAccessor.DB, CustomerAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT CustNo,CompName,brand From CustInfo order by CompName ASC")]
        public abstract List<Customer> Customers();

    }
}
