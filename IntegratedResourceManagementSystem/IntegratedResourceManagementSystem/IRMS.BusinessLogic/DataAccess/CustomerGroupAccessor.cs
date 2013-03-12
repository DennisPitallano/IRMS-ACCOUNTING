using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;
using IRMS.Entities;

namespace IRMS.BusinessLogic.DataAccess
{
    
    public abstract class CustomerGroupAccessor : AccessorBase <CustomerGroupAccessor.DB, CustomerGroupAccessor>
    {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM LstCustGroup")]
        public abstract List<CustomerGroup> ListGroupOfCustomers();
    }
}
