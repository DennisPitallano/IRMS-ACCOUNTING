using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using BLToolkit.Data;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.Manager
{
    public class ForwarderManager
    {
        #region Accessor
        ForwarderAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ForwarderAccessor.CreateInstance(); }
        }
        #endregion

        public List<Forwarder> Forwarders()
        {
            return Accessor.Query.SelectAll<Forwarder>();
        }

        public void Save(Forwarder Forwader)
        {
            using (DbManager db = new DbManager())
            {
                if (Forwader.RecordNumber > 0)
                {
                    Accessor.Query.Update(db, Forwader);
                }
                else
                {
                    Accessor.Query.Insert(db, Forwader);
                }
            }
        }
        public Forwarder GetForwarderByKey(long id)
        {
            return Accessor.Query.SelectByKey<Forwarder>(id) ?? new Forwarder();
        }

        public void Delete(Forwarder FORWARDER)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, FORWARDER);
            }
        }
    }
}
