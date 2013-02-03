using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using System.Web.UI.WebControls;

namespace IRMS.BusinessLogic.Manager
{
    public class AdjustmentManager : LogManager<Adjustment>
    {
        #region Accessor
        AdjustmentAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return AdjustmentAccessor.CreateInstance(); }
        }
        #endregion

        /// <summary>
        /// Get Adjustment By Key
        /// </summary>
        /// <param name="id">Identification Key</param>
        /// <returns>Adjustment Oblect</returns>
        public Adjustment GetAdjustmentByKey(long id)
        {
            return Accessor.Query.SelectByKey<Adjustment>(id) ?? new Adjustment();
        }

        /// <summary>
        /// Fetch all Adjustments
        /// </summary>
        /// <returns>Adjustment Collection</returns>
        public List<Adjustment> Adjustments()
        {
            return Accessor.Query.SelectAll<Adjustment>();
        }

        /// <summary>
        /// Save or Update Adjustment
        /// </summary>
        /// <param name="Adjustment">Adjustment Object</param>
        public void Save(Adjustment Adjustment)
        {
            using (DbManager db = new DbManager())
            {
                if (Adjustment.RecordNo != 0)
                {
                    Accessor.Query.Update(db, Adjustment);
                }
                else
                {
                  Identity= Accessor.Query.InsertAndGetIdentity(db, Adjustment);
                }
            }
        }

        /// <summary>
        /// Get Adjustment by Outlet/Customer and date range.
        /// </summary>
        /// <param name="OUTLET">Outlet/Customer name</param>
        /// <param name="FROM">From date</param>
        /// <param name="TO">To date</param>
        /// <returns>Adjustment Object</returns>
        public Adjustment GetAdjustmentByOutletAndDateRange(string OUTLET, DateTime FROM, DateTime TO)
        {
            return Accessor.GetAdjustmentMemoByOutletAndDateRange(OUTLET, FROM, TO);
        }

        /// <summary>
        /// Delete Adjustment
        /// </summary>
        /// <param name="Adjustment">Adjustment Object</param>
        public void Delete(Adjustment Adjustment)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, Adjustment);
            }
        }

        /// <summary>
        /// Search Adjustment
        /// </summary>
        /// <param name="search_parameter">array of search parameter</param>
        /// <returns></returns>
        public List<Adjustment> SearchAdjustments(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "BRAND_CODE";
            columns[1] = "BRAND_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Adjustment>(search_parameter, columns);
        }

        #region search adjustment
        public SqlDataSource SearchPCountAdjustmentDataSource(SqlDataSource adjusment_data_source, string search_parameter, string Brand)
        {
            string search_query = string.Empty;
                search_query = "SELECT [RECORD_NO], [INVENTORY_DATE], [CUT_OFF_DATE], [OUTLET_NAME], [DATE_RECORDED],[ADJUSTMENT_CODE] FROM [ADJUSTMENTS] INNER JOIN CustInfo ON ADJUSTMENTS.OUTLET_NUMBER = CustInfo.CustNo  ";
                if (search_parameter != string.Empty)
                {
                    search_query += " WHERE [OUTLET_NAME] LIKE '%" + search_parameter + "%' ";
                }
          
            search_query += "ORDER BY RECORD_NO DESC";
            adjusment_data_source.SelectCommand = search_query;
            adjusment_data_source.DataBind();
            return adjusment_data_source;
        }
            
        #endregion
    }
}
