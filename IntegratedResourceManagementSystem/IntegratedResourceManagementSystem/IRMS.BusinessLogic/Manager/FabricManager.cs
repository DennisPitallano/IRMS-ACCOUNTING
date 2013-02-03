using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class FabricManager 
    {
        #region Accessor
        FabricAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return FabricAccessor.CreateInstance(); }
        }
        #endregion

        public Fabric GetFabricByKey(long id)
        {
            return Accessor.Query.SelectByKey<Fabric >(id) ?? new Fabric();
        }

        public List<Fabric> Fabrics()
        {
            return Accessor.Fabrics();
        }

        public void Save(Fabric fabric)
        {
            using (DbManager db = new DbManager())
            {
                if (fabric.RecordNo != 0)
                {
                    Accessor.Query.Update(db, fabric);
                }
                else
                {
                    Accessor.Query.Insert(db, fabric);
                }
            }
        }

        public void Delete(Fabric fabric)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, fabric);
            }
        }

        public List<Fabric> SearchFabrics(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "FABRIC_CODE";
            columns[1] = "FABRIC_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Fabric>(search_parameter, columns);
        }
    }
}
