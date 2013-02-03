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
    /// <summary>
    /// Author: Dennis Pitallano
    /// Date Created: December 2011
    /// Company: iServe
    /// Class Description: Brand Data Accessor Manager Class
    /// </summary>
    public class BrandManager:LogManager<Brand>
    {
        #region Accessor
        /// <summary>
        /// 
        /// </summary>
        
        BrandAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return BrandAccessor.CreateInstance();
            }
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brand GetBrandByKey(long id)
        {
            return Accessor.Query.SelectByKey<Brand>(id) ?? new Brand();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public Brand GetBrandByCode(string Code)
        {
            Brand brand = new Brand();
            foreach (Brand brnd in Accessor.Brands())
            {
                if (brnd.BrandCode == Code)
                {
                    brand = brnd;
                    break;
                }
            }
            return brand;
        }

        public Brand GetBrandByBrandName(string BrandName)
        {
            try
            {
                var brand_ = (from _brand in Accessor.Brands()
                              where _brand.BrandDescription == BrandName
                              select _brand).FirstOrDefault();
                return brand_;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Brand GetBrandByBrandCode(string BrandCode)
        {
            string[] paramKey = new string[1];
            paramKey[0] = BrandCode;
            string[] paramColumn = new string[1];
            paramColumn[0] = "BRAND_CODE";

            return Accessor.Query.SelectByKeyWords<Brand>(paramKey, paramColumn)[0] ?? new Brand();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Brand> Brands()
        {
            return Accessor.Brands();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        public void Save(Brand brand)
        {
            using (DbManager db = new DbManager())
            {
                try
                {
                    db.BeginTransaction();
                    if (brand.RecordNo != 0)
                    {
                        Accessor.Query.Update(db, brand);
                    }
                    else
                    {
                     Identity= Accessor.Query.InsertAndGetIdentity(db, brand);
                    }
                    db.CommitTransaction();
                }
                catch (Exception ex)
                {
                    db.RollbackTransaction();
                    throw ex ;
                }
                
            }
        }

        /// <summary>
        /// Delete Brand
        /// </summary>
        /// <param name="brand">Brand Object</param>
        public void Delete(Brand brand)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, brand);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search_parameter"></param>
        /// <returns></returns>
        public List<Brand> SearchBrands(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "BRAND_CODE";
            columns[1] = "BRAND_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<Brand>(search_parameter, columns);
        }

        #region filter_query
        public void LoadBrands(SqlDataSource BrandDataSource, string search_parameter="")
        {
            string CommandText = "SELECT [RECORD_NO], [BRAND_CODE], [BRAND_DESCRIPTION], [START_SERIES], [DATE_RECORDED] FROM [BRANDS] ";
            if (search_parameter != "")
            {
                CommandText += " WHERE BRAND_CODE LIKE '%" + search_parameter + "%' OR BRAND_DESCRIPTION LIKE '%"+search_parameter+"%'";
            }
            CommandText += " ORDER BY [RECORD_NO] DESC";
            BrandDataSource.SelectCommand = CommandText;
            BrandDataSource.DataBind();
        }
        #endregion

    }
}
