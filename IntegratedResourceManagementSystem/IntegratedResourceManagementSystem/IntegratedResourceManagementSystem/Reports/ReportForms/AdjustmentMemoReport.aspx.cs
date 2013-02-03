using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using IRMS.BusinessLogic.Manager;
using System.Data;
using IRMS.ObjectModel;
using IRMS.Components;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class AdjustmentMemoReport : System.Web.UI.Page
    {
        private AdjustmentManager AdjustmentManager = new AdjustmentManager();
        AdjustmentMemoManager AdjustmentMemoManager = new AdjustmentMemoManager();
        Adjustment ADJUSTMENT_ = new Adjustment();
        AdjustmentMemo ADJUSTMENT_MEMO = new AdjustmentMemo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    hfReportType.Value = PreviousPage.REPORT_MODE;
                    ADJUSTMENT_ = PreviousPage.ADJUSTMENT;
                    ADJUSTMENT_MEMO = PreviousPage.ADJUSTMENT_MEMO;
                    hfAdjustmentRecordNo.Value = PreviousPage.ADJUSTMENT.RecordNo.ToString();
                    hfAdjustmentCode.Value = PreviousPage.ADJUSTMENT.AdjustmentCode;
                    hfAdjustmentMemoRecordNo.Value = PreviousPage.ADJUSTMENT_MEMO.RecordNo.ToString();
                   
                }
                catch (Exception)
                {
                    
                   // throw;
                }
            } 
            switch (hfReportType.Value)
                {
                    case "ADJUSTMENT DETAILS":
                        InitializeTransactionDetailsReportPreview(long.Parse(hfAdjustmentMemoRecordNo.Value));
                        break;
                    case "ADJUSTMENT SUMMARY":
                        InitializedReportPreview(hfAdjustmentCode.Value);
                        break;
                    case "ADJUSTMENT MEMO":
                        InitializeAdjustmentMemoReportPreview(hfAdjustmentCode.Value, long .Parse(hfAdjustmentRecordNo.Value));
                        break;
                }
        }

        private void InitializeAdjustmentMemoReportPreview(string AdjustmentCode,long adjustment_recordNo)
        {
            Adjustment adjustment = AdjustmentManager.GetAdjustmentByKey(adjustment_recordNo);
            DataTable tbl = new DataTable();
            tbl = AdjustmentMemoManager.FetchAllAdjustmentMemosByAdjustmentCode(AdjustmentCode);
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramTotalQuantity = new ParameterField();
            ParameterDiscreteValue paramQuantityValue = new ParameterDiscreteValue();
            paramTotalQuantity.ParameterFieldName = "TotalQuantity";
            ParameterField paramTotalCurrentPrice = new ParameterField();
            ParameterDiscreteValue paramTotalCurrentPriceValue = new ParameterDiscreteValue();
            paramTotalCurrentPrice.ParameterFieldName = "TotalCurrentPrice";
            ParameterField paramTotalCostPrice = new ParameterField();
            ParameterDiscreteValue paramTotalCostPriceValue = new ParameterDiscreteValue();
            paramTotalCostPrice.ParameterFieldName = "TotalCostPrice";
            ParameterField paramInventoryDate = new ParameterField();
            ParameterDiscreteValue paramInventoryDateValue = new ParameterDiscreteValue();
            paramInventoryDate.ParameterFieldName = "InventoryDate";
            ParameterField paramCutOffDate = new ParameterField();
            ParameterDiscreteValue paramCutOffDateValue = new ParameterDiscreteValue();
            paramCutOffDate.ParameterFieldName = "CutOffDate";
            ParameterField paramAdjustmentPhysicalCountQuantity = new ParameterField();
            ParameterDiscreteValue paramAdjustmentPhysicalCountQuantityValue = new ParameterDiscreteValue();
            paramAdjustmentPhysicalCountQuantity.ParameterFieldName = "AdjustedPhysicalCountQuantity";
            ParameterField paramAdjustmentPhysicalCountCurrentPrice = new ParameterField();
            ParameterDiscreteValue paramAdjustmentPhysicalCountCurrentPriceValue = new ParameterDiscreteValue();
            paramAdjustmentPhysicalCountCurrentPrice.ParameterFieldName = "AdjustedPhysicalCountCurrentPrice";
            ParameterField paramAdjustmentPhysicalCountCostPrice = new ParameterField();
            ParameterDiscreteValue paramAdjustmentPhysicalCountCostPriceValue = new ParameterDiscreteValue();
            paramAdjustmentPhysicalCountCostPrice.ParameterFieldName = "AdjustmentPhysicalCountCostPrice";
            ParameterField paramOutletName = new ParameterField();
            ParameterDiscreteValue paramOutletNamevalue = new ParameterDiscreteValue();
            paramOutletName.ParameterFieldName = "OutletName";

            paramQuantityValue.Value =long.Parse(LoadTransactionSummary(AdjustmentCode)[0])+adjustment.ActualPhysicalCountQuantity;
            paramTotalCurrentPriceValue.Value = decimal.Parse(LoadTransactionSummary(AdjustmentCode)[1].Replace("Php",""))+adjustment.ActualPhysicalCountCurrentPrice;
            paramTotalCostPriceValue.Value =decimal.Parse(LoadTransactionSummary(AdjustmentCode)[2].Replace("Php",""))+adjustment.ActualPhysicalCountCostPrice;
            paramInventoryDateValue.Value = adjustment.InventoryDate;
            paramCutOffDateValue.Value = adjustment.CutOffDate;
            paramAdjustmentPhysicalCountQuantityValue.Value = adjustment.ActualPhysicalCountQuantity;
            paramAdjustmentPhysicalCountCurrentPriceValue.Value = adjustment.ActualPhysicalCountCurrentPrice;
            paramAdjustmentPhysicalCountCostPriceValue.Value = adjustment.ActualPhysicalCountCostPrice;
            paramOutletNamevalue.Value = adjustment.OutletName;

            paramTotalQuantity.CurrentValues.Add(paramQuantityValue);
            paramTotalCurrentPrice.CurrentValues.Add(paramTotalCurrentPriceValue);
            paramTotalCostPrice.CurrentValues.Add(paramTotalCostPriceValue);
            paramInventoryDate.CurrentValues.Add(paramInventoryDateValue);
            paramCutOffDate.CurrentValues.Add(paramCutOffDateValue);
            paramAdjustmentPhysicalCountQuantity.CurrentValues.Add(paramAdjustmentPhysicalCountQuantityValue);
            paramAdjustmentPhysicalCountCurrentPrice.CurrentValues.Add(paramAdjustmentPhysicalCountCurrentPriceValue);
            paramAdjustmentPhysicalCountCostPrice.CurrentValues.Add(paramAdjustmentPhysicalCountCostPriceValue);
            paramOutletName.CurrentValues.Add(paramOutletNamevalue);

            paramFields.Add(paramTotalQuantity);
            paramFields.Add(paramTotalCurrentPrice);
            paramFields.Add(paramTotalCostPrice);
            paramFields.Add(paramInventoryDate);
            paramFields.Add(paramCutOffDate);
            paramFields.Add(paramAdjustmentPhysicalCountQuantity);
            paramFields.Add(paramAdjustmentPhysicalCountCurrentPrice);
            paramFields.Add(paramAdjustmentPhysicalCountCostPrice);
            paramFields.Add(paramOutletName);

            ReportDocument rptDoc = new ReportDocuments.RptAdjustmentMemo();
            rptDoc.SetDataSource(tbl);
            crViewerAdjustmentMemo.ParameterFieldInfo = paramFields;
            this.crViewerAdjustmentMemo.ReportSource = rptDoc; 
        }

        private void InitializeTransactionDetailsReportPreview(long RECORD_NO)
        {
            DataTable adjustment_memo = new DataTable();
            adjustment_memo = AdjustmentMemoManager.FetchAdjustmentMemoByKey(RECORD_NO);
            ReportDocument rptDoc = new ReportDocuments.RptTransactionDetails();
            rptDoc.SetDataSource(adjustment_memo);
            this.crViewerAdjustmentMemo.ReportSource = rptDoc; 
        }

        private void InitializedReportPreview(string AdjustmentCode)
        {
            DataTable tbl = new DataTable();
            tbl = AdjustmentMemoManager.FetchAllAdjustmentMemosByAdjustmentCode(AdjustmentCode);
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramTotalQuantity = new ParameterField();
            ParameterDiscreteValue paramRegistrarValue = new ParameterDiscreteValue();
            paramTotalQuantity.ParameterFieldName = "TotalQuantity";
            ParameterField paramTotalCurrentPrice = new ParameterField();
            ParameterDiscreteValue paramTotalCurrentPriceValue = new ParameterDiscreteValue();
            paramTotalCurrentPrice.ParameterFieldName = "TotalCurrentPrice";
            ParameterField paramTotalCostPrice = new ParameterField();
            ParameterDiscreteValue paramTotalCostPriceValue = new ParameterDiscreteValue();
            paramTotalCostPrice.ParameterFieldName = "TotalCostPrice";
            
            paramRegistrarValue.Value = LoadTransactionSummary(AdjustmentCode)[0];
            paramTotalCurrentPriceValue.Value = LoadTransactionSummary(AdjustmentCode)[1];
            paramTotalCostPriceValue.Value = LoadTransactionSummary(AdjustmentCode)[2];

            paramTotalQuantity.CurrentValues.Add(paramRegistrarValue);
            paramTotalCurrentPrice.CurrentValues.Add(paramTotalCurrentPriceValue);
            paramTotalCostPrice.CurrentValues.Add(paramTotalCostPriceValue);
            paramFields.Add(paramTotalQuantity);
            paramFields.Add(paramTotalCurrentPrice);
            paramFields.Add(paramTotalCostPrice);
            ReportDocument rptDoc = new ReportDocuments.RptAdjustmentMemoSummary();
            rptDoc.SetDataSource(tbl);
            crViewerAdjustmentMemo.ParameterFieldInfo = paramFields;
           this.crViewerAdjustmentMemo.ReportSource = rptDoc; 
        }

        private string[] LoadTransactionSummary(string AdjustmentCode)
        {
            string[] results = new string[3];
            long debit_quantity = 0;
            long credit_quantity = 0;
            decimal debit_current_price = 0;
            decimal credit_current_price = 0;
            decimal debit_cost_price = 0;
            decimal credit_cost_price = 0;
            List<AdjustmentMemo> AdjustmentMemoDetailsCredit = new List<AdjustmentMemo>();
            List<AdjustmentMemo> AdjustmentMemoDetailsDebit = new List<AdjustmentMemo>();
            foreach (AdjustmentMemo adjmemo in AdjustmentMemoManager.AdjustmentMemosByAdjustmentCode(AdjustmentCode))
            {
                if (adjmemo.MemoType == "CREDIT")
                {
                    AdjustmentMemoDetailsCredit.Add(adjmemo);
                    credit_quantity = credit_quantity + adjmemo.Quantity;
                    credit_current_price = credit_current_price + adjmemo.CurrentPrice;
                    credit_cost_price = credit_cost_price + adjmemo.CostPrice;
                }
                else
                {
                    AdjustmentMemoDetailsDebit.Add(adjmemo);
                    debit_quantity = debit_quantity + adjmemo.Quantity;
                    debit_current_price = debit_current_price + adjmemo.CurrentPrice;
                    debit_cost_price = debit_cost_price + adjmemo.CostPrice;
                }
            }
            results[0] = ((debit_quantity) - (credit_quantity)).ToString();
            results[1] = ((debit_current_price) - credit_current_price).ToString();
            results[2] = ((debit_cost_price) - credit_cost_price).ToString();
           return results;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Redirector.Redirect("~/Accounting/Debit-CreditMemoPanel.aspx");
        }
    }
}