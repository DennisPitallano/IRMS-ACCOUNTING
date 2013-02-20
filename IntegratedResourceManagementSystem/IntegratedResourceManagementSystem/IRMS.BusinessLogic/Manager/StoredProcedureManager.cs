using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.Entities;
using BLToolkit.Data;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.Manager
{
    public class StoredProcedureManager
    {

        public void ExecuteGenSummaryBrandInventory(string UserName, DateTime DateFrom, DateTime DateTo)
        {

            using (DbManager db = new DbManager())
            {
                db
                  .SetSpCommand("GenRptBrandSummInventory",
                      db.Connection.ConnectionTimeout == 90000,
                      db.Parameter("@UserName", UserName),
                      db.Parameter("@DateFROM", DateFrom),
                      db.Parameter("@DateTo", DateTo))
                  .ExecuteNonQuery();
            }

        }

        public void ExecuteGenSummaryStoreInventory(DateTime DateFrom, DateTime DateTo,string Brand, string UserName,  int CustomerType )
        {

            using (DbManager db = new DbManager())
            {
                db
                  .SetSpCommand("GenRptStoreSummInv",
                      db.Connection.ConnectionTimeout == 90000,
                      db.Parameter("@DateFrom", DateFrom),
                      db.Parameter("@DateTo", DateTo),
                      db.Parameter("@BrandName", Brand),
                      db.Parameter("@UserName", UserName),
                      db.Parameter("@CustType", CustomerType))
                  .ExecuteNonQuery();
            }

            

        }



    }
}
