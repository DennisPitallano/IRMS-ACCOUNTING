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
    public class SalesInvoiceManager
        {
        #region Accessor
        SalesInvoiceAccessor Accessor
            {
            [System.Diagnostics.DebuggerStepThrough]
            get { return SalesInvoiceAccessor.CreateInstance(); }
            }
        #endregion

        public SalesInvoiceClass GetSIById(long id)
            {
            return Accessor.Query.SelectByKey<SalesInvoiceClass>(id) ?? new SalesInvoiceClass();
            }

        public SalesInvoiceClass getSI(string SINo)
        {

        return Accessor.SIBySINo(SINo);
           }

        public void Save(SalesInvoiceClass sales_invoice)
            {
            using (DbManager db = new DbManager())
                {
                if (sales_invoice.id != 0)
                    {
                    Accessor.Query.Update(db, sales_invoice);
                    }
                else
                    {
                    Accessor.Query.Insert(db, sales_invoice);
                    }
                }
            }

        public void Delete(SalesInvoiceClass sales_invoice)
            {
            using (DbManager db = new DbManager())
                {
                Accessor.Query.Delete(db, sales_invoice);
                }
            }

         public SqlDataSource FilterSalesInvoice(SqlDataSource sql_data_source, string search_parameter)
            {
           if (search_parameter != string.Empty)
                {
                if (search_parameter == "unposted")
                    {
                    sql_data_source.SelectCommand = "SELECT [ID], [SINo], [SIDate], [SoldTo] FROM [SI] WHERE ([ynLiquidation] = '1') and ([ynPosted] = 'FALSE')  ORDER BY [SIDate] DESC, [ID] DESC";
                    }
                else if (search_parameter == "posted")
                    {
                    sql_data_source.SelectCommand = "SELECT [ID], [SINo], [SIDate], [SoldTo] FROM [SI] WHERE ([ynLiquidation] = '1') and ([ynPosted] = 'TRUE')  ORDER BY [SIDate] DESC, [ID] DESC";
                    }
                else if (search_parameter == "cancelled")
                    {
                    sql_data_source.SelectCommand = "SELECT [ID], [SINo], [SIDate], [SoldTo] FROM [SI] WHERE ([ynLiquidation] = '1') and ([ynCancelled] = 'TRUE')  ORDER BY [SIDate] DESC, [ID] DESC";
                    }
                }
           
            //}
            sql_data_source.DataBind();
            return sql_data_source;
            }

         public SqlDataSource SearchSalesInvoice(SqlDataSource sql_data_source, string search_parameter)
             {

             if (search_parameter != string.Empty)
                 {
                 sql_data_source.SelectCommand = "SELECT [ID], [SINo], [SIDate], [SoldTo] FROM [SI] WHERE ([ynLiquidation] = '1') and ([SINo] = '" + search_parameter + "' or [SoldTo] like '%" + search_parameter + "%')  ORDER BY [SIDate] DESC, [ID] DESC";
                 }
             else
                {
                sql_data_source.SelectCommand = "SELECT [ID], [SINo], [SIDate], [SoldTo] FROM [SI] WHERE ([ynLiquidation] = '1') and ([ynPosted] = 'FALSE')  ORDER BY [SIDate] DESC, [ID] DESC";
                 }

             sql_data_source.DataBind();
             return sql_data_source;
             }
        }
    }
