using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
    {
    public abstract class SalesInvoiceAccessor : AccessorBase<SalesInvoiceAccessor.DB, SalesInvoiceAccessor>
        {
        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM SI")]
        public abstract List<SalesInvoiceClass> SI();

        [SqlQuery("SELECT * FROM SI where SINo = @SINo")]
        public abstract SalesInvoiceClass SIBySINo(string SINo);
        }

    }
