using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.DataAccess;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.DataAccess
{
   using ObjectModel;
   public abstract class SizeAccessor: AccessorBase <SizeAccessor.DB,SizeAccessor>
    {
       public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

    }
}
