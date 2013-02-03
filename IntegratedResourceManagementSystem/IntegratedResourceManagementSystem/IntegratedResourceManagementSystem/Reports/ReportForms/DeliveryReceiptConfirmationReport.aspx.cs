using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using IRMS.Components;
using System.Web.Caching;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{//SQLNCLI10
    public partial class DeliveryReceiptConfiamationReport : System.Web.UI.Page
    {
        DeliveryReceiptManager DManager = new DeliveryReceiptManager();

        protected void Page_Init( object sender, EventArgs e)
        {
                hfBrand.Value = Session["BRAND_NAME"].ToString();
                hfTransitStatus.Value = Session["TRANSIT_STATUS"].ToString();
                hfIncludeDateRange.Value = Session["INCLUDE_DATE_RANGE"].ToString();

                hfOutletName.Value = Session["OUTLET_NAME"].ToString();
            if (hfIncludeDateRange.Value == "TRUE")
            {
                hfDateFrom.Value = Session["DR_DATE_FROM"].ToString();
                hfDateTo.Value = Session["DR_DATE_TO"].ToString();
                if (hfOutletName.Value != "")
                {
                    InitializeReportByOutletWithDateRange(hfTransitStatus.Value);
                }
                else
                {
                    InitializeReportWithDateRange();
                }
            }
            else
            {
                if (hfOutletName.Value != "")
                {
                    InitializeReportByOutlet(hfTransitStatus.Value);
                }
                else
                {
                    InitializeReport(hfTransitStatus.Value);
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        public void InitializeReportWithDateRange()
        {
            DataTable DeliveryReceipts = new DataTable();
            
            ReportDocument rptDoc;
            if (hfBrand.Value !="ALL")
            {
                ParameterField paramReportTitle = new ParameterField();
                ParameterField prmDateRange = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                paramReportTitle.ParameterFieldName = "ReportTitle";
                prmDateRange.ParameterFieldName = "DateRange";

                ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();
               
                prmDateRangeValue.Value ="DATE FROM: " + DateTime.Parse(hfDateFrom.Value).ToString("MMMM dd, yyyy") + " TO " + 
                    DateTime.Parse(hfDateTo.Value).ToString("MMMM dd, yyyy");

                paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                prmDateRange.CurrentValues.Add(prmDateRangeValue);

                prmList.Add(paramReportTitle);
                prmList.Add(prmDateRange);

                
                if (hfTransitStatus.Value == "In Transit")
                {
                    prmReportTitleValue.Value = "In-Transit Delivery Receipts by Brand";
                    string reportCacheKey = string.Concat("DeliveryReceiptsByBrand",hfDateFrom.Value,hfDateTo.Value,hfTransitStatus.Value);
                    if (Cache[reportCacheKey] != null)
                    {
                        rptDoc = (ReportDocuments.InTransitDeliveryReceiptsByBrand)Cache[reportCacheKey];
                    }
                    else
                    {
                        rptDoc = new ReportDocuments.InTransitDeliveryReceiptsByBrand();
                        Cache.Insert(reportCacheKey, rptDoc);
                    }
                    DeliveryReceipts = DManager.GetAllTransitDeliveryReceiptsByBrandWithDateRange(hfTransitStatus.Value,
                        DateTime.Parse(hfDateFrom.Value), DateTime.Parse(hfDateTo.Value), hfBrand.Value);
                }
                else
                {
                    prmReportTitleValue.Value = "Confirmed Delivery Receipts by Brand";
                    string reportCacheKey = string.Concat("DeliveryReceiptsByBrand", hfDateFrom.Value, hfDateTo.Value, hfTransitStatus.Value);
                    if (Cache[reportCacheKey] != null)
                   {
                       rptDoc = (ReportDocuments.RptConfirmedDeliveryReceiptsByBrand)Cache[reportCacheKey];
                    }
                    else
                    {
                        rptDoc = new ReportDocuments.RptConfirmedDeliveryReceiptsByBrand();
                        Cache.Insert(reportCacheKey, rptDoc);
                    }
                   
                }
              
                //string datasetCacheKey = string.Concat(hfTransitStatus.Value, hfBrand.Value,hfDateFrom.Value,hfDateTo.Value);

                //if (Cache[datasetCacheKey] != null)
                //{
                //    DeliveryReceipts = (DataTable)Cache[datasetCacheKey];
                //}
                //else
                //{
                    // perform query and fill dataset 
                    DeliveryReceipts = DManager.GetAllTransitDeliveryReceiptsByBrandWithDateRange(hfTransitStatus.Value, 
                        DateTime.Parse(hfDateFrom.Value), DateTime.Parse(hfDateTo.Value), hfBrand.Value);
                    //insert  the dataset into the cache
                //    Cache.Insert(datasetCacheKey, DeliveryReceipts);
                //}

                rptDoc.SetDataSource(DeliveryReceipts);
                crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                crViewerAdjustmentMemo.ReportSource = rptDoc;
                
            }
            else
            {
                ParameterField paramReportTitle = new ParameterField();
                ParameterField prmDateRange = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                paramReportTitle.ParameterFieldName = "ReportTitle";
                prmDateRange.ParameterFieldName = "DateRange";

                ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

              
                prmDateRangeValue.Value = "DATE FROM: " + DateTime.Parse(hfDateFrom.Value).ToString("MMMM dd, yyyy") + " TO " +
                    DateTime.Parse(hfDateTo.Value).ToString("MMMM dd, yyyy");

             
                DeliveryReceipts = DManager.GetAllTransitDeliveryReceiptsByBrandWithDateRange(hfTransitStatus.Value, DateTime.Parse(hfDateFrom.Value), DateTime.Parse(hfDateTo.Value));

                if (hfTransitStatus.Value == "In Transit")
                {
                    prmReportTitleValue.Value = "In-Transit Delivery Receipts";
                    rptDoc = new ReportDocuments.TransitDeliveryReceipts();
                }
                else
                {
                    prmReportTitleValue.Value = "Confirmed Delivery Receipts";
                    rptDoc = new ReportDocuments.RptConfirmedDeliveryReceipts();
                }
                paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                prmDateRange.CurrentValues.Add(prmDateRangeValue);

                prmList.Add(paramReportTitle);
                prmList.Add(prmDateRange);
                rptDoc.SetDataSource(DeliveryReceipts);
                crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                crViewerAdjustmentMemo.ReportSource = rptDoc;
                
            }
        }

        public void InitializeReport(string TransitStatus)
        {
            DataTable TransitDeliveryReceipts = new DataTable();

            if (hfBrand.Value != "ALL")
            {
                ReportDocument rptDoc;
                
                if (hfTransitStatus.Value == "In Transit")
                {
                    ParameterField paramReportTitle = new ParameterField();
                    ParameterField prmDateRange = new ParameterField();
                    ParameterFields prmList = new ParameterFields();

                    paramReportTitle.ParameterFieldName = "ReportTitle";
                    prmDateRange.ParameterFieldName = "DateRange";

                    ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

                    prmReportTitleValue.Value = "In-Transit Delivery Receipts by Brand";
                    prmDateRangeValue.Value = "As of " + DateTime.Now.ToString("dddd,MMMM dd, yyyy");

                    paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                    prmDateRange.CurrentValues.Add(prmDateRangeValue);

                    prmList.Add(paramReportTitle);
                    prmList.Add(prmDateRange);

                    string reportCacheKey = "InTransitDeliveryReceiptsByBrand.rpt";

                    if (Cache[reportCacheKey] != null)
                    {
                        rptDoc = (ReportDocuments.InTransitDeliveryReceiptsByBrand)Cache[reportCacheKey];
                    }
                    else
                    {
                        rptDoc = new ReportDocuments.InTransitDeliveryReceiptsByBrand();
                        Cache.Insert(reportCacheKey, rptDoc);
                    }
                    
                    string datasetCacheKey = string.Concat(hfTransitStatus.Value, hfBrand.Value);

                    if (Cache[datasetCacheKey] != null)
                    {
                        TransitDeliveryReceipts = (DataTable)Cache[datasetCacheKey];
                    }
                    else
                    {
                        // perform query and fill dataset 
                        TransitDeliveryReceipts = DManager.GetAllInTransitDeliveryReceipts(hfTransitStatus.Value, hfBrand.Value);
                        //insert  the dataset into the cache
                        Cache.Insert(datasetCacheKey, TransitDeliveryReceipts);
                    }

                    rptDoc.Database.Tables[0].SetDataSource(TransitDeliveryReceipts);
                    crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                    crViewerAdjustmentMemo.ReportSource = rptDoc;
                }
                else
                {
                    ParameterField paramReportTitle = new ParameterField();
                    ParameterField prmDateRange = new ParameterField();
                    ParameterFields prmList = new ParameterFields();

                    paramReportTitle.ParameterFieldName = "ReportTitle";
                    prmDateRange.ParameterFieldName = "DateRange";

                    ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

                    prmReportTitleValue.Value = "Confirmed Delivery Receipts by Brand";
                    prmDateRangeValue.Value = "As of " + DateTime.Now.ToString("dddd,MMMM dd, yyyy");

                    paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                    prmDateRange.CurrentValues.Add(prmDateRangeValue);

                    prmList.Add(paramReportTitle);
                    prmList.Add(prmDateRange);

                    string reportCacheKey = "RptConfirmedDeliveryReceiptsByBrand.rpt";
                    if (Cache[reportCacheKey] != null)
                    {
                        rptDoc = (ReportDocuments.RptConfirmedDeliveryReceiptsByBrand)Cache[reportCacheKey];
                    }
                    else
                    {
                        rptDoc = new ReportDocuments.RptConfirmedDeliveryReceiptsByBrand();
                        Cache.Insert(reportCacheKey, rptDoc);
                    }

                    string datasetCacheKey = string.Concat(hfTransitStatus.Value,hfBrand.Value);
                    if (Cache[datasetCacheKey] != null)
                    {
                        TransitDeliveryReceipts = (DataTable)Cache[datasetCacheKey];
                    }
                    else
                    {
                        // perform query and fill dataset
                        TransitDeliveryReceipts = DManager.GetAllInTransitDeliveryReceipts(hfTransitStatus.Value, hfBrand.Value);
                        // insert the dataset into the cache 
                        Cache.Insert(datasetCacheKey, TransitDeliveryReceipts); 
                    }
                   
                    rptDoc.Database.Tables[0].SetDataSource(TransitDeliveryReceipts);
                    crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                    crViewerAdjustmentMemo.ReportSource = rptDoc;
                }
            }
            else
            {
                TransitDeliveryReceipts = DManager.GetAllInTransitDeliveryReceipts(hfTransitStatus.Value);
                if (hfTransitStatus.Value == "In Transit")
                {
                    ParameterField paramReportTitle = new ParameterField();
                    ParameterField prmDateRange = new ParameterField();
                    ParameterFields prmList = new ParameterFields();

                    paramReportTitle.ParameterFieldName = "ReportTitle";
                    prmDateRange.ParameterFieldName = "DateRange";

                    ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

                    prmReportTitleValue.Value = "In-Transit Delivery Receipts";
                    prmDateRangeValue.Value = "As of " + DateTime.Now.ToString("dddd,MMMM dd, yyyy");

                    paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                    prmDateRange.CurrentValues.Add(prmDateRangeValue);

                    prmList.Add(paramReportTitle);
                    prmList.Add(prmDateRange);
                    ReportDocument rptDoc = new ReportDocuments.TransitDeliveryReceipts();
                    rptDoc.SetDataSource(TransitDeliveryReceipts);
                    crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                    crViewerAdjustmentMemo.ReportSource = rptDoc;
                }
                else
                {
                    ParameterField paramReportTitle = new ParameterField();
                    ParameterField prmDateRange = new ParameterField();
                    ParameterFields prmList = new ParameterFields();

                    paramReportTitle.ParameterFieldName = "ReportTitle";
                    prmDateRange.ParameterFieldName = "DateRange";

                    ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

                    prmReportTitleValue.Value = "Confirmed Delivery Receipts";
                    prmDateRangeValue.Value = "As of " + DateTime.Now.ToString("dddd,MMMM dd, yyyy");

                    paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                    prmDateRange.CurrentValues.Add(prmDateRangeValue);

                    prmList.Add(paramReportTitle);
                    prmList.Add(prmDateRange);
                    ReportDocument rptDoc = new ReportDocuments.RptConfirmedDeliveryReceipts();
                    rptDoc.SetDataSource(TransitDeliveryReceipts);
                    crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                    crViewerAdjustmentMemo.ReportSource = rptDoc;
                }
            }
        }

        public  void InitializeReportByOutlet(string TransitStatus)
        {
            DataTable DeliveryReceiptsByOutLet = new DataTable();
            ReportDocument rptDoc;
                ParameterField paramReportTitle = new ParameterField();
                ParameterField prmDateRange = new ParameterField();
                ParameterFields prmList = new ParameterFields();

                paramReportTitle.ParameterFieldName = "ReportTitle";
                prmDateRange.ParameterFieldName = "DateRange";

                ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
                ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

                prmDateRangeValue.Value = "";

                DeliveryReceiptsByOutLet = DManager.GetAllTransitDeliveryReceiptsByOutlet(hfTransitStatus.Value, hfOutletName.Value);
                if (hfTransitStatus.Value == "In Transit")
                {
                    prmReportTitleValue.Value = "In-Transit Delivery Receipts by Outlet";
                    rptDoc = new ReportDocuments.InTransitDeliveryReceiptsByBrand();
                }
                else
                {
                    prmReportTitleValue.Value = "Confirmed Delivery Receipts by Outlet";
                    rptDoc = new ReportDocuments.RptTransitDeliveryReceiptsByOutlet();
                }

                paramReportTitle.CurrentValues.Add(prmReportTitleValue);
                prmDateRange.CurrentValues.Add(prmDateRangeValue);

                prmList.Add(paramReportTitle);
                prmList.Add(prmDateRange);
                rptDoc.SetDataSource(DeliveryReceiptsByOutLet);
                crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
                crViewerAdjustmentMemo.ReportSource = rptDoc;
        }

        public void InitializeReportByOutletWithDateRange(string TransitStatus)
        {
            DataTable DeliveryReceiptsByOutLet = new DataTable();
            ReportDocument rptDoc;
            ParameterField paramReportTitle = new ParameterField();
            ParameterField prmDateRange = new ParameterField();
            ParameterFields prmList = new ParameterFields();

            paramReportTitle.ParameterFieldName = "ReportTitle";
            prmDateRange.ParameterFieldName = "DateRange";

            ParameterDiscreteValue prmReportTitleValue = new ParameterDiscreteValue();
            ParameterDiscreteValue prmDateRangeValue = new ParameterDiscreteValue();

            prmDateRangeValue.Value = "DATE FROM: " + DateTime.Parse(hfDateFrom.Value).ToString("MMMM dd, yyyy") + " TO " +
                    DateTime.Parse(hfDateTo.Value).ToString("MMMM dd, yyyy");

            DeliveryReceiptsByOutLet = DManager.GetAllTransitDeliveryReceiptsByOutletWithDateRange(hfTransitStatus.Value, hfOutletName.Value, DateTime.Parse(hfDateFrom.Value), DateTime.Parse(hfDateTo.Value));
            if (hfTransitStatus.Value == "In Transit")
            {
                prmReportTitleValue.Value = "In-Transit Delivery Receipts by Outlet";
                rptDoc = new ReportDocuments.InTransitDeliveryReceiptsByBrand();
            }
            else
            {
                prmReportTitleValue.Value = "Confirmed Delivery Receipts by Outlet";
                rptDoc = new ReportDocuments.RptTransitDeliveryReceiptsByOutlet();
            }

            paramReportTitle.CurrentValues.Add(prmReportTitleValue);
            prmDateRange.CurrentValues.Add(prmDateRangeValue);

            prmList.Add(paramReportTitle);
            prmList.Add(prmDateRange);
            rptDoc.SetDataSource(DeliveryReceiptsByOutLet);
            crViewerAdjustmentMemo.ParameterFieldInfo = prmList;
            crViewerAdjustmentMemo.ReportSource = rptDoc;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session.Remove("BRAND_NAME");
            Session.Remove("TRANSIT_STATUS");
            Session.Remove("INCLUDE_DATE_RANGE");
            Session.Remove("OUTLET_NAME");
            Session.Remove("DR_DATE_FROM");
            Session.Remove("DR_DATE_TO");
            Redirector.Redirect("~/Accounting/DeliveryReceiptConfirmationPanel.aspx");
        }
    }
}