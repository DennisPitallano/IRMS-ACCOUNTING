using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
   public class GarmentManager
   {
       #region Accessor
       GarmentAccessor Accessor
       {
           [System.Diagnostics.DebuggerStepThrough]
           get { return GarmentAccessor.CreateInstance(); }
       }
       #endregion

       public Garment GetGarmentByKey(long id)
       {
           return Accessor.Query.SelectByKey<Garment>(id) ?? new Garment();
       }

       public List<Garment> Garments()
       {
           return Accessor.Garments();
       }

       public void Save(Garment garment)
       {
           using (DbManager db = new DbManager())
           {
               if (garment.RecordNo != 0)
               {
                   Accessor.Query.Update(db, garment);
               }
               else
               {
                   Accessor.Query.Insert(db, garment);
               }
           }
       }

       public void Delete(Garment garment)
       {
           using (DbManager db = new DbManager())
           {
               Accessor.Query.Delete(db, garment);
           }
       }

       public List<Garment> SearchGarments(string[] search_parameter)
       {
           string[] columns = new string[2];
           columns[0] = "GARMENT_CODE";
           columns[1] = "GARMENT_DESCRIPTION";
           return Accessor.Query.SelectByKeyWords<Garment>(search_parameter, columns);
       }
    }
}
