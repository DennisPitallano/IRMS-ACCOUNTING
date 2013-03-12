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

        #region "Customer Group Report"

        public void ExecuteGenCustGroupCustomer(string UserName, DateTime DateFrom, DateTime DateTo, string Customer, string Pos, int Categ)
        {

            using (DbManager db = new DbManager())
            {
                db
                  .SetSpCommand("GenCustomerGroupPerCustomer",
                      db.Connection.ConnectionTimeout == 90000,
                      db.Parameter("@UserName", UserName),
                      db.Parameter("@DateFROM", DateFrom),
                      db.Parameter("@DateTo", DateTo),
                      db.Parameter("@Customer", Customer),
                      db.Parameter("@Posted", Pos),
                      db.Parameter("@Category", Categ))
                  .ExecuteNonQuery();
            }

        }

        public void ExecuteGenCustGroupCustomerWithPrev(string UserName, DateTime DateFrom, DateTime DateTo, string Customer, string Pos, int Categ)
        {

            using (DbManager db = new DbManager())
            {
                db
                  .SetSpCommand("GenCustomerGroupPerCustomerWithPrevious",
                      db.Connection.ConnectionTimeout == 90000,
                      db.Parameter("@UserName", UserName),
                      db.Parameter("@DateFROM", DateFrom),
                      db.Parameter("@DateTo", DateTo),
                      db.Parameter("@Customer", Customer),
                      db.Parameter("@Posted", Pos),
                      db.Parameter("@Category", Categ))
                  .ExecuteNonQuery();
            }

        }

        public void ExecuteGenCustGroupBrand(string UserName, DateTime DateFrom, DateTime DateTo, string BrandName, string Pos, int Categ)
        {
            try
            {

                using (DbManager db = new DbManager())
                {
                    db
                      .SetSpCommand("GenCustomerGroupPerBrand",
                          db.Connection.ConnectionTimeout == 90000,
                          db.Parameter("@UserName", UserName),
                          db.Parameter("@DateFROM", DateFrom),
                          db.Parameter("@DateTo", DateTo),
                          db.Parameter("@BrAND", BrandName),
                          db.Parameter("@Posted", Pos),
                          db.Parameter("@Category", Categ))
                      .ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }

        }

        public void ExecuteGenCustGroupBrandWithPrev(string UserName, DateTime DateFrom, DateTime DateTo, string BrandName, string Pos, int Categ)
        {
            try
            {

                using (DbManager db = new DbManager())
                {
                    db
                      .SetSpCommand("GenCustomerGroupPerBrandWithPrevious",
                          db.Connection.ConnectionTimeout == 90000,
                          db.Parameter("@UserName", UserName),
                          db.Parameter("@DateFROM", DateFrom),
                          db.Parameter("@DateTo", DateTo),
                          db.Parameter("@BrAND", BrandName),
                          db.Parameter("@Posted", Pos),
                          db.Parameter("@Category", Categ))
                      .ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }

        }

        public void ExecuteGenCustGroupOverAll(string UserName, DateTime DateFrom, DateTime DateTo, string Pos, int Categ)
        {
            try
            {
                using (DbManager db = new DbManager())
                {
                    db
                       .SetSpCommand("GenCustomerGroupOverAll",
                           db.Connection.ConnectionTimeout == 90000,
                           db.Parameter("@UserName", UserName),
                           db.Parameter("@DateFROM", DateFrom),
                           db.Parameter("@DateTo", DateTo),
                           db.Parameter("@Post", Pos),
                           db.Parameter("@Category", Categ))
                       .ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }

        }

        public void ExecuteGenCustGroupOverAllWithPrev(string UserName, DateTime DateFrom, DateTime DateTo, string Pos, int Categ)
        {
            try
            {
                using (DbManager db = new DbManager())
                {
                    db
                       .SetSpCommand("GenCustomerGroupOverAllWithPrevious",
                           db.Connection.ConnectionTimeout == 90000,
                           db.Parameter("@UserName", UserName),
                           db.Parameter("@DateFROM", DateFrom),
                           db.Parameter("@DateTo", DateTo),
                           db.Parameter("@Post", Pos),
                           db.Parameter("@Category", Categ))
                       .ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }

        }

        #endregion

    }
}
