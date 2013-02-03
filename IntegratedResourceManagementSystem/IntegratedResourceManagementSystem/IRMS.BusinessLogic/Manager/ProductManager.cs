using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class ProductManager
    {
        #region Accessor
        ProductAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ProductAccessor.CreateInstance(); }
        }
        #endregion

        public Product GetProductByKey(long id)
        {
            return Accessor.Query.SelectByKey<Product>(id) ?? new Product();
        }

        public List<Product> GetProductByStyleNumber(string StyleNumber)
        {
            return Accessor.GetProductsByStyleNumber(StyleNumber);
        }
        public List<Product> ProductCategories()
        {
            return Accessor.Products();
        }

        public void Save(Product product)
        {
            using (DbManager db = new DbManager())
            {
                if (product.RecordNo != 0)
                {
                    Accessor.Query.Update(db, product);
                }
                else
                {
                    Accessor.Query.Insert(db, product);
                }
            }
        }

        public void Delete(Product product)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, product);
            }
        }

        public List<Product> SearchProducts(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "STYLE_NUMBER";
            columns[1] = "ITEM_CODE";
            return Accessor.Query.SelectByKeyWords<Product>(search_parameter, columns);
        }

        public string GetLastSKUCode()
        {
            return Accessor.GetLastSKUCode();
        }
    }
}
