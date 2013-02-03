using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class DeliveryReceiptDetailManager
    {
        #region Accessor
        DeliveryReceiptDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DeliveryReceiptDetailAccessor.CreateInstance(); }
        }
        #endregion

        public DeliveryReceiptDetail GetDeliveryReceiptDetailByKey(long id)
        {
            return Accessor.Query.SelectByKey<DeliveryReceiptDetail>(id) ?? new DeliveryReceiptDetail();
        }

        public List<DeliveryReceiptDetail> DeliveryReceiptDetails()
        {
            return Accessor.Query.SelectAll<DeliveryReceiptDetail>();
        }
        public List<DeliveryReceiptDetail> DeliveryReceiptDetailsByDRNumber(int DRNUMBER)
        {
            return Accessor.GetDeliveryReceiptDetailsByDRNumber(DRNUMBER);
        }
        public void Save(DeliveryReceiptDetail DeliveryReceiptDetail)
        {
            using (DbManager db = new DbManager())
            {
                if (DeliveryReceiptDetail.RecordNo != 0)
                {
                    Accessor.Query.Update(db, DeliveryReceiptDetail);
                }
                else
                {
                    Accessor.Query.Insert(db, DeliveryReceiptDetail);
                }
            }
        }

        public void Delete(DeliveryReceiptDetail DeliveryReceiptDetail)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, DeliveryReceiptDetail);
            }
        }

        public List<DeliveryReceiptDetail> SearchDeliveryReceiptDetail(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "DRNo";
            columns[1] = "FABRIC_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<DeliveryReceiptDetail>(search_parameter, columns);
        }
    }
}
