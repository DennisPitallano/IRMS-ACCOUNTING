using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using IRMS.Entities;
using System.Web.UI.WebControls;
using BLToolkit.DataAccess;
using IRMS.ObjectModel.Views;
namespace IRMS.BusinessLogic.DataAccess 
{
    public abstract class PhysicalInventoryAccessor : AccessorBase<PhysicalInventoryAccessor.DB, PhysicalInventoryAccessor>
    {

        public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

        [SqlQuery("SELECT * FROM PIRpt")]
        public abstract List<PhysicalInventoryView> PhysicalInventoryRecord();

    }
}
