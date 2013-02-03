using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using IRMS.ObjectModel;

namespace IRMS.BusinessLogic.DataAccess
{
    public abstract class ProductAccessor : AccessorBase< ProductAccessor .DB,ProductAccessor >
    {
         public class DB : DbManager { public DB() : base("IRMSConnectionString") { } }

       [SqlQuery(@"SELECT  DISTINCT STYLE_NO,DESCRIPTION,ITEM_CODE FROM PRODUCTS WHERE IS_ACTIVE ='Yes'")]
       //[SqlQuery("SELECT * FROM PRODUCTS WHERE IS_ACTIVE ='Yes'")]
       public abstract  List<Product> Products();

       [SqlQuery(@"SELECT * FROM PRODUCTS WHERE IS_ACTIVE ='Yes' AND STYLE_NO=@StyleNumber")]
       public abstract List<Product> GetProductsByStyleNumber(string StyleNumber);

        [SqlQuery (@"SELECT SKU_BARCODE FROM PRODUCTS ORDER BY DATE_RECORDED DESC ")]
       public abstract string GetLastSKUCode();
    }
}
