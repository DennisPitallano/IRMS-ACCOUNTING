using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using System.Web.UI.WebControls;
using System.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class DeliveryReceiptManager :LogManager<DeliveryReceipt>
    {
        #region Accessor
        DeliveryReceiptAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get
            {
                return DeliveryReceiptAccessor.CreateInstance();
            }
        }

        #endregion

        public DeliveryReceipt GetDeliveryReceiptByKey(long id)
        {
            return Accessor.Query.SelectByKey<DeliveryReceipt>(id) ?? new DeliveryReceipt();
        }
     
        public List<DeliveryReceipt> DeliveryReceipts()
        {
            return Accessor.DeliveryReceipts();
        }

        public void Save(DeliveryReceipt DeliveryReceipt)
        {
            using (DbManager db = new DbManager())
            {
                if (DeliveryReceipt.RecordNo != 0)
                {
                    Accessor.Query.Update(db, DeliveryReceipt);
                }
                else
                {
                    Accessor.Query.Insert(db, DeliveryReceipt);
                }
            }
        }

        public void Delete(DeliveryReceipt DeliveryReceipt)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, DeliveryReceipt);
            }
        }

        public void UpdateDeliveryRecieptCancelledStatus(List<DeliveryReceipt> list)
        {
            foreach (DeliveryReceipt dr in list)
            {
                Accessor.UpdateDeliveryReceiptCancelledStatus(dr.RecordNo);
            }
        }

        /// <summary>
        /// Confirmed DR with Forwarder and WaybillNumber as parameter
        /// </summary>
        /// <param name="list"></param>
        /// <param name="WayBillNumber"></param>
        /// <param name="Forwarder"></param>
        /// <param name="ConfirmationDate"></param>
        public void ConfirmDeliveryReceipts(List<DeliveryReceipt> list, string WayBillNumber, string Forwarder, DateTime ConfirmationDate)
        {
            foreach (DeliveryReceipt dr in list)
            {
                Accessor.ConfirmDeliveryReceipt(dr.RecordNo, WayBillNumber, Forwarder, ConfirmationDate);
            }
        }

        public void ConfirmDeliveryReceipts(List<DeliveryReceipt> list, DateTime ConfirmationDate)
        {
            foreach (DeliveryReceipt dr in list)
            {
                Accessor.ConfirmDeliveryReceipt(dr.RecordNo, ConfirmationDate);
            }
        }

        public List<DeliveryReceipt> SearchDeliveryReceipts(string[] search_parameter)
        {
            string[] columns = new string[2];
            columns[0] = "DRNo";
            columns[1] = "FABRIC_DESCRIPTION";
            return Accessor.Query.SelectByKeyWords<DeliveryReceipt>(search_parameter, columns);
        }

        #region "report"

        public DataTable GetAllTransitDeliveryReceiptsByOutlet(string Status,string Outletname)
        {
         
                return Accessor.GetAllTransitDeliveryReceiptByOutlet(Status, Outletname);
                      
        }
        public DataTable GetAllTransitDeliveryReceiptsByOutletWithDateRange(string Status, string Outletname,DateTime from,DateTime to)
        {

            return Accessor.GetAllTransitDeliveryReceiptByOutletWithDateRange(Status, Outletname,from,to);

        }
        public DataTable GetAllInTransitDeliveryReceipts(string Status,string Brand="")
        {
            if (Brand != "")
            {
                return Accessor.GetAllIntransitDeliveryReceiptByBrand(Status,Brand);
            }
            else
            {
                return Accessor.GetAllIntransitDeliveryReceipt(Status);
            }
        }

        public DataTable GetAllDeliveryReceiptsWithDetails(string Status,string Brand="")
        {
            if (Brand != "")
            {
                return Accessor.GetAllDeliveryReceiptsWithDetailsByBrand(Status, Brand);
            }
            else
            {
                return Accessor.GetAllDeliveryReceiptsWithDetails(Status);
            }
        }

        public DataTable GetAllTransitDeliveryReceiptsByBrandWithDateRange(string Status,DateTime from, DateTime to, string Brand = "")
        {
            if (Brand != "")
            {
                if (Status == "In Transit")
                {
                    return Accessor.GetAllInTransitDeliveryReceiptsByBrandWithDateRange(Status, from, to, Brand);
                }
                else
                {
                    return Accessor.GetAllConfirmedDeliveryReceiptsByBrandWithDateRange(Status, from, to, Brand);
                }
            }
            else
            {
                return Accessor.GetAllTransitDeliveryReceiptsWithDateRange(Status,from ,to);
            }
        }

        #endregion

        #region "Command Text"
       
        public void FilterDeliveryReceiptList(SqlDataSource datasource, string filter_field_type, string Brand)
        {
            StringBuilder CommandText = new StringBuilder();
            if (filter_field_type == "ALL")
            {
                CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],[ConfirmedDate],WayBillNo,Forwarder FROM [DR]  BrandName='" + Brand + "'  ORDER BY DRDate DESC ");
                datasource.SelectCommand = CommandText.ToString();
                datasource.DataBind();
            }
            else
            {
                //if (Brand == "ALL")
                //{
                    CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],ConfirmedDate,WayBillNo,Forwarder FROM [DR] where  ");
                    if (filter_field_type == "In Transit")
                    {
                        CommandText.Append("  ynPosted=1 and ConfirmedDate is null or TransitStatus='In Transit'");
                    }
                    else
                    {
                        CommandText.Append("  ConfirmedDate is not null  ");
                    }
                //}
                //else
                //{
                //    CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],ConfirmedDate,WayBillNo,Forwarder FROM [DR] where BrandName='" + Brand + "' ");
                //    if (filter_field_type == "In Transit")
                //    {
                //        CommandText.Append(" AND ynPosted=1 and ConfirmedDate is null or TransitStatus='In Transit'");
                //    }
                //    else
                //    {
                //        CommandText.Append(" AND ConfirmedDate is not null  ");
                //    }
                //}
               
                CommandText.Append(" ORDER BY DRDate DESC ");
                datasource.SelectCommand = CommandText.ToString();
                datasource.DataBind();
            }
        }

        public void SearchDeliveryReceiptList(SqlDataSource datasource, string search_parameter, string TransitStatus, string searchBy, string Brand)
        {
            datasource.SelectCommand = SearchCommand(search_parameter, TransitStatus, searchBy, Brand);
            datasource.DataBind();
        }

        private static string SearchCommand(string search_parameter, string TransitStatus, string searchBy, string Brand)
        {
            StringBuilder CommandText = new StringBuilder();
            //if (Brand != "ALL")
            //{
            //    CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],[ConfirmedDate],WayBillNo,Forwarder FROM [DR] WHERE  BrandName='" + Brand + "' ");
            //    if (search_parameter != string.Empty)
            //    {
            //        if (searchBy != "DR")
            //        {
            //            CommandText.Append(" AND DeliveredTo LIKE '%" + search_parameter + "%' ");

            //            if (TransitStatus == "In Transit")
            //            {
            //                CommandText.Append(" and ConfirmedDate is null ");
            //            }
            //            else
            //            {
            //                CommandText.Append(" and ConfirmedDate is not null ");
            //            }
            //        }
            //        else
            //        {
            //            if (TransitStatus == "In Transit")
            //            {
            //                CommandText.Append(" AND ynPosted =1 and ");
            //                CommandText.Append(" DRNo LIKE '%" + search_parameter + "%' ");
            //                CommandText.Append(" and ConfirmedDate is null ");
            //            }
            //            else
            //            {
            //                CommandText.Append(" AND DRNo LIKE '%" + search_parameter + "%' ");
            //                CommandText.Append(" and ConfirmedDate is not null ");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (TransitStatus == "In Transit")
            //        {
            //            CommandText.Append(" AND ynPosted =1 and ");
            //            CommandText.Append(" ConfirmedDate is null  or TransitStatus='In Transit' ");
            //        }
            //        else
            //        {
            //            CommandText.Append(" AND ConfirmedDate is not null ");
            //        }
            //    }
            //}
            //else
            //{
                CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],[ConfirmedDate],WayBillNo,Forwarder FROM [DR] WHERE  ");
                if (search_parameter != string.Empty)
                {
                    if (searchBy != "DR")
                    {
                        CommandText.Append("  DeliveredTo LIKE '%" + search_parameter + "%' ");

                        if (TransitStatus == "In Transit")
                        {
                            CommandText.Append(" and ConfirmedDate is null ");
                        }
                        else
                        {
                            CommandText.Append(" and ConfirmedDate is not null ");
                        }
                    }
                    else
                    {
                        if (TransitStatus == "In Transit")
                        {
                            CommandText.Append("  ynPosted =1 and ");
                            CommandText.Append(" DRNo LIKE '%" + search_parameter + "%' ");
                            CommandText.Append(" and ConfirmedDate is null ");
                        }
                        else
                        {
                            CommandText.Append("  DRNo LIKE '%" + search_parameter + "%' ");
                            CommandText.Append(" and ConfirmedDate is not null ");
                        }
                    }
                }
                else
                {
                    if (TransitStatus == "In Transit")
                    {
                        CommandText.Append("  ynPosted =1 and ");
                        CommandText.Append(" ConfirmedDate is null  or TransitStatus='In Transit' ");
                    }
                    else
                    {
                        CommandText.Append("  ConfirmedDate is not null ");
                    }
                }
            //}
                CommandText.Append(" ORDER BY DRDate DESC ");

            return CommandText.ToString();
        }

        public void AdvanceSearch(SqlDataSource datasource, string search_parameter, string filter_type, DateTime date_from, DateTime date_to, string searchBy, string Brand)
        {
              datasource.SelectCommand = AdvanceSearchCommand(search_parameter, filter_type, date_from, date_to, searchBy, Brand);
              datasource.DataBind();
        }

        private static string AdvanceSearchCommand(string search_parameter, string StatusType, DateTime date_from, DateTime date_to, string searchBy, string Brand)
        {
            StringBuilder CommandText = new StringBuilder();

            //if (Brand != "ALL")
            //{
            //    CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],[ConfirmedDate],WayBillNo ,Forwarder FROM [DR] WHERE  BrandName='" + Brand + "' ");

            //    if (StatusType == "In Transit")
            //    {
            //        CommandText.Append(" AND ynPosted=1 and ");
            //        CommandText.Append(" ConfirmedDate is null ");
            //    }
            //    else
            //    {
            //        CommandText.Append(" AND ConfirmedDate is not null ");
            //    }

            //    if (search_parameter != string.Empty)
            //    {
            //        if (searchBy != "DR")
            //        {
            //            CommandText.Append(" AND DeliveredTo LIKE '%" + search_parameter + "%' ");
            //        }
            //        else
            //        {
            //            CommandText.Append(" AND DRNo LIKE '%" + search_parameter + "%' ");
            //        }
            //    }
            //}
            //else
            //{
                CommandText.Append("SELECT [ID], [DRNo], [DRDate], [PLNo], [CustNo], [DeliveredTo], [TotalQty], [TotalAmt], [ItemStatus],[ConfirmedDate],WayBillNo ,Forwarder FROM [DR] WHERE ");

                if (StatusType == "In Transit")
                {
                    CommandText.Append("  ynPosted=1 and ");
                    CommandText.Append(" ConfirmedDate is null ");
                }
                else
                {
                    CommandText.Append("  ConfirmedDate is not null ");
                }

                if (search_parameter != string.Empty)
                {
                    if (searchBy != "DR")
                    {
                        CommandText.Append(" AND DeliveredTo LIKE '%" + search_parameter + "%' ");
                    }
                    else
                    {
                        CommandText.Append(" AND DRNo LIKE '%" + search_parameter + "%' ");
                    }
                }

            //}
            CommandText.Append(" AND DRDate BETWEEN '" + date_from + "' AND '" + date_to + "'");
            CommandText.Append(" ORDER BY DRDate DESC ");
            return CommandText.ToString();
        }
        #endregion
    }
}
