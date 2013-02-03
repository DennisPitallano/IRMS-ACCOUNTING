using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class CustomerReturnSlipManager
    {
        #region Accessor
        CustomerReturnSlipAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return CustomerReturnSlipAccessor.CreateInstance();
            }
        }

        public void ConfirmCustomerReturnSlip(List<CustomerReturnSlipConfirmation> list_of_crs)
        {
            foreach( CustomerReturnSlipConfirmation crs in list_of_crs)
            {
                ConfirmCustomerReturnSlip(crs);
            }
        }

        public void ConfirmCustomerReturnSlip(CustomerReturnSlipConfirmation crs)
        {
            using (DbManager dbm = new DbManager())
            {
                Accessor.Query.Insert(dbm, crs);
            }
        }

        public int CRSConfirmationCount()
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<CustomerReturnSlipConfirmation>().Count;
            }
        }
        #endregion
        public CustomerReturnSlip GetCustomerReturnSlipByKey(long id)
        {
            return Accessor.Query.SelectByKey<CustomerReturnSlip>(id) ?? new CustomerReturnSlip();
        }

        public List<CustomerReturnSlip> CustomerReturnSlipList()
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<CustomerReturnSlip>(dbm);

            }
        }

        public long GetCRSTotalQtyByCustomerAndDateRange(int CustomerNumber, DateTime DateFrom, DateTime DateTo)
        {
                return Accessor.GetCRSTotalQtyByCustomerAndDateRange(CustomerNumber, DateFrom, DateTo);
        }

        #region SearchQuery
        public void FilterCustomerReturnSlip(SqlDataSource DataSource,string PostedStatus)
        {
            string CommandText = string.Empty;
           
            CommandText = "SELECT [ID], [CRSID], [CRSNo], [CRSDate], [Customer], [PUSNo], [TotalAmt], [PkgNo], [ItemStatus] FROM [CRS] ";
            if (PostedStatus != "CONFIRMED")
            {
                if (PostedStatus == "POSTED")
                {
                    if (CRSConfirmationCount() > 0)
                    {
                        CommandText += " INNER JOIN  CRS_CONFIRMATIONS ON CRS.CRSNo != CRS_CONFIRMATIONS.CRS_NUMBER WHERE ynPosted=1 AND ynCancelled=0 order by CRSDate DESC";
                    }
                    else
                    {
                        CommandText += " WHERE ynPosted=1 AND ynCancelled=0 order by CRSDate DESC";
                    }
                    
                }
                else
                {
                    if (CRSConfirmationCount() > 0)
                    {
                        CommandText += " INNER JOIN  CRS_CONFIRMATIONS ON CRS.CRSNo != CRS_CONFIRMATIONS.CRS_NUMBER WHERE ynPosted=0 AND ynCancelled=0 order by CRSDate DESC";
                    }
                    else
                    {
                        CommandText += " WHERE ynPosted=0 AND ynCancelled=0 order by CRSDate DESC";
                    }
                }
            }
            else
            {
                CommandText = "SELECT [ID], [CRSID], [CRSNo], [CRSDate], [Customer], [PUSNo], [TotalAmt], [PkgNo], [ItemStatus] FROM [CRS] ";
                CommandText += " INNER JOIN  CRS_CONFIRMATIONS ON CRS.CRSNo = CRS_CONFIRMATIONS.CRS_NUMBER order by CRSDate DESC";
            }
            DataSource.SelectCommand = CommandText;
            DataSource.DataBind();
        }
        public void SearchCustomerReturnSlip(SqlDataSource DataSource, string PostedStatus,string search_parameter)
        {
            string CommandText = string.Empty;
            CommandText = "SELECT [ID], [CRSID], [CRSNo], [CRSDate], [Customer], [PUSNo], [TotalAmt], [PkgNo], [ItemStatus] FROM [CRS] ";
            if (PostedStatus != "CONFIRMED")
            {
                if (search_parameter != string.Empty)
                {
                    CommandText += " WHERE  ";
                    if (PostedStatus == "POSTED")
                    {
                        CommandText += " ynPosted=1 AND ynCancelled=0";
                    }
                    else
                    {
                        CommandText += " ynPosted=0 AND ynCancelled=0";
                    }

                    CommandText += " AND CRSNo LIKE '%" + search_parameter + "%' OR  Customer LIKE '%" + search_parameter + "%'";
                }
                else
                {
                    if (PostedStatus == "POSTED")                                                                                                                                             {
                        CommandText += " WHERE ynPosted=1 AND ynCancelled=0";
                    }
                    else
                    {
                        CommandText += " WHERE ynPosted=0 AND ynCancelled=0";
                    }
                }
            }
            else
            {
                if (search_parameter != string.Empty)
                {
                    CommandText += " WHERE CRSNo LIKE '%" + search_parameter + "%' OR  Customer LIKE '%" + search_parameter + "%' ";
                    CommandText += " AND ynCancelled=1";
                }
                else
                {
                    CommandText += " WHERE ynCancelled=1";
                }
            }
            DataSource.SelectCommand = CommandText;
            DataSource.DataBind();
        }
        public void SearchCustomerReturnSlipWithDateRange(SqlDataSource DataSource, string PostedStatus, string search_parameter,DateTime date_from, DateTime date_to)
        {
            string CommandText = string.Empty;
            CommandText = "SELECT [ID], [CRSID], [CRSNo], [CRSDate], [Customer], [PUSNo], [TotalAmt], [PkgNo], [ItemStatus] FROM [CRS] ";
            CommandText += " WHERE CRSDate BETWEEN '" + date_from + "' AND '" + date_to + "' ";
            if (PostedStatus != "CONFIRMED")
            {
                if (search_parameter != string.Empty)
                {
                    CommandText += " AND CRSNo LIKE '%" + search_parameter + "%' OR  Customer LIKE '%" + search_parameter + "%' ";
                    if (PostedStatus == "POSTED")
                    {
                        CommandText += " AND ynPosted=1 AND ynCancelled=0";
                    }
                    else
                    {
                        CommandText += " AND ynPosted=0 AND ynCancelled=0 ";
                    }
                }
                else
                {
                    if (PostedStatus == "POSTED")
                    {
                        CommandText += " AND ynPosted=1 AND ynCancelled=0 ";
                    }
                    else
                    {
                        CommandText += " AND ynPosted=0 AND ynCancelled=0 ";
                    }
                }
            }
            else
            {
                if (search_parameter != string.Empty)
                {
                    CommandText += " AND CRSNo LIKE '%" + search_parameter + "%' OR  Customer LIKE '%" + search_parameter + "%' ";
                    CommandText += " AND ynCancelled=1";
                }
                else
                {
                    CommandText += " AND ynCancelled=1";
                }
            }
            DataSource.SelectCommand = CommandText;
            DataSource.DataBind();
        }
        #endregion
    }
}
