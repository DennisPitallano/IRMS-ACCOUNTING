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
    public class BookAdjustmentManager : LogManager<BookAdjustment>
    {
        #region Accessor
        BookAdjustmentAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return BookAdjustmentAccessor.CreateInstance(); }
        }
        #endregion

        /// <summary>
        /// Get Book Adjustment By Key
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns>Book Adjustment</returns>
        public BookAdjustment GetBookAdjustmentByKey(long id)
        {
            return Accessor.Query.SelectByKey<BookAdjustment>(id) ?? new BookAdjustment();
        }

        /// <summary>
        /// Fetch all Book Adjustments
        /// </summary>
        /// <returns>Book Adjustments Collection</returns>
        public List<BookAdjustment> BookAdjustments()
        {
            return Accessor.Query.SelectAll<BookAdjustment>();
        }

        /// <summary>
        /// Get Book Adjustments By Outlet and Date range
        /// </summary>
        /// <param name="OUTLET_NAME">OutletName</param>
        /// <param name="INVENTORY_DATE">Inventory Date</param>
        /// <param name="CUT_OFF_DATE">Cut off Date</param>
        /// <returns>Book Adjustment Collection</returns>
        public List<BookAdjustment> GetBookAdjustmentByOutletNameAndDateRange(string OUTLET_NAME, DateTime INVENTORY_DATE, DateTime CUT_OFF_DATE)
        {
            return Accessor.GetBookAdjustmentByOutletNameAndDateRange( OUTLET_NAME,  INVENTORY_DATE,  CUT_OFF_DATE);
        }

        /// <summary>
        /// Save or Update Book Adjustment
        /// </summary>
        /// <param name="BookAdjustment">Book Adjustment</param>
        public void Save(BookAdjustment BookAdjustment)
        {
            using (DbManager db = new DbManager())
            {
                if (BookAdjustment.RecordNo != 0)
                {
                    Accessor.Query.Update(db, BookAdjustment);
                }
                else
                {
                 Identity = Accessor.Query.InsertAndGetIdentity(db, BookAdjustment);
                }
            }
        }

        /// <summary>
        /// Delete Book Adjustment
        /// </summary>
        /// <param name="BookAdjustment">Book Adjustment</param>
        public void Delete(BookAdjustment BookAdjustment)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, BookAdjustment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search_parameter"></param>
        /// <returns></returns>
        public List<Adjustment> SearchBookAdjustments(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "BRAND_CODE";
            columns[1] = "BRAND_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Adjustment>(search_parameter, columns);
        }

        /// <summary>
        /// Get Book Adjustments Memo By Adjustment Code
        /// </summary>
        /// <param name="ADJUSTMENT_CODE">Adjustment Code</param>
        /// <returns>Book adjustment Collection</returns>
        public List<BookAdjustmentMemo> GetBookAdjustmentMemosByAdjustmentCode(string ADJUSTMENT_CODE)
        {
            return Accessor.GetBookAdjustmentMemoByCode(ADJUSTMENT_CODE);
        }

        #region search adjustment
        public SqlDataSource SearchBookAdjustments(SqlDataSource adjustment_data_source, string search_paramenter,string Brand)
        {
            string search_query = string.Empty;
         
                search_query = "SELECT [RECORD_NO], [INVENTORY_DATE], [CUT_OFF_DATE], [OUTLET_NAME], [DATE_RECORDED], [ADJUSTMENT_CODE] FROM [BOOK_ADJUSTMENTS] ";
                if (search_paramenter != string.Empty)
                {
                    search_query += " WHERE OUTLET_NAME LIKE '%" + search_paramenter + "%' ";
                }
            search_query += " ORDER BY DATE_RECORDED DESC";
            adjustment_data_source.SelectCommand = search_query;
            adjustment_data_source.DataBind();
            return adjustment_data_source;
        }
        #endregion
    }
}
