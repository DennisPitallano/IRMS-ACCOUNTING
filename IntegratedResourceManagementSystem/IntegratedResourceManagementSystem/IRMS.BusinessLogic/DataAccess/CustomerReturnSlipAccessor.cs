using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class CustomerReturnSlipAccessor : AccessorBase<CustomerReturnSlipAccessor.DB, CustomerReturnSlipAccessor>
    {
        public class DB : DbManager
        {
            public DB()
                : base("IRMSConnectionString")
            {
            }
        }

        [SqlQuery(@"select SUM(Quantity) as TOTAL_QTY from dbo.CRS inner join dbo.CRSSumm on CRSSumm.CRSID = CRS.ID where CustNo=@CustomerNumber and CRSDate between @DateFrom and @DateTo")]
        public abstract long GetCRSTotalQtyByCustomerAndDateRange(int CustomerNumber, DateTime DateFrom, DateTime DateTo);
    }
}
