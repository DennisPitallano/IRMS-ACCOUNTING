using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using System.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class AdjustmentMemoManager : LogManager<AdjustmentMemo>
    {
        #region Accessor
        AdjustmentMemoAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return AdjustmentMemoAccessor.CreateInstance(); }
        }
        #endregion

        /// <summary>
        /// Get Adjustment Memo by Key
        /// </summary>
        /// <param name="id">Adjustment memo Key</param>
        /// <returns></returns>
        public AdjustmentMemo GetAdjustmentMemoByKey(long id)
        {
            return Accessor.Query.SelectByKey<AdjustmentMemo>(id) ?? new AdjustmentMemo();
        }

        /// <summary>
        /// Fetch all adjustment memo
        /// </summary>
        /// <returns>Adjustment Memo Collection</returns>
        public List<AdjustmentMemo> AdjustmentMemos()
        {
            return Accessor.Query.SelectAll < AdjustmentMemo>();
        }

        /// <summary>
        /// Get Adjustment Memo by adjustment code
        /// </summary>
        /// <param name="ADJUSTMENT_CODE">Adjustment Code</param>
        /// <returns>Adjustment Memo Collection</returns>
        public List<AdjustmentMemo> AdjustmentMemosByAdjustmentCode(string ADJUSTMENT_CODE)
        {
            return Accessor.GetAdjusmentMemosByAdjustmentCode(ADJUSTMENT_CODE);
        }

        /// <summary>
        /// Save or Update Adjustment Memo
        /// </summary>
        /// <param name="AdjustmentMemo">Adjustment Memo</param>
        public void Save(AdjustmentMemo AdjustmentMemo)
        {
            using (DbManager db = new DbManager())
            {
                if (AdjustmentMemo.RecordNo != 0)
                {
                    Accessor.Query.Update(db, AdjustmentMemo);
                }
                else
                {
                  Identity= Accessor.Query.InsertAndGetIdentity(db, AdjustmentMemo);
                }
            }
        }

        /// <summary>
        /// Delete Adjustment Memo
        /// </summary>
        /// <param name="AdjustmentMemo">Adjustment Memo Object</param>
        public void Delete(AdjustmentMemo AdjustmentMemo)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, AdjustmentMemo);
            }
        }

        /// <summary>
        /// Get all Adjustment Memo by adjustment Code
        /// </summary>
        /// <param name="AdjustmentCode">Adjustment Code</param>
        /// <returns>Adjustment Memo Data Table</returns>
        public DataTable FetchAllAdjustmentMemosByAdjustmentCode(string AdjustmentCode)
        {
            return Accessor.FetchAdjusmentMemosByAdjustmentCode(AdjustmentCode); 
        }

        /// <summary>
        /// Get Adjustment Memo by Key
        /// </summary>
        /// <param name="RECORD_NO">Key</param>
        /// <returns>Adjustment Data Table</returns>
        public DataTable FetchAdjustmentMemoByKey(long RECORD_NO)
        {
            return Accessor.FetchAdjustmentMemoByKey(RECORD_NO);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search_parameter"></param>
        /// <returns></returns>
        public List<AdjustmentMemo> SearchAdjustmentMemos(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "BRAND_CODE";
            columns[1] = "BRAND_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<AdjustmentMemo>(search_parameter, columns);
        }

        public long GetLastMemoreferenceNumber()
        {
            return Accessor.GetLastMemoReferenceNumber();
        }

        #region "report"
        public DataTable GetAllPhysicalCountAdjustmentMemos()
        {
           return  Accessor.GetAllPhysicalCountAdjustments();
        }
        #endregion
    }
}
