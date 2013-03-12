using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using IRMS.Entities;
using System.Web.UI.WebControls;
using IRMS.ObjectModel.Views;

namespace IRMS.BusinessLogic.Manager
{
    public class PhysicalInventoryManager
    {

        #region Accessor
        PhysicalInventoryAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PhysicalInventoryAccessor.CreateInstance(); }
        }
        #endregion

        public List<PhysicalInventoryView> PhysicalInventory()
        {
            return Accessor.PhysicalInventoryRecord();
        }

        public List<PhysicalInventoryReportView> LoadReportPhysicalInventoryPerBrand(int ValYear, string brand, string Cat)
        {
            try
            {

                List<PhysicalInventoryView> Query = new List<PhysicalInventoryView>();
                Query.Clear();

                List<PhysicalInventoryReportView> Result = new List<PhysicalInventoryReportView>();
                Result.Clear();

                if (Cat == "ALL")
                {

                    Query = (from Phy in PhysicalInventory()
                              where Phy.Year.Equals(ValYear) && Phy.BrandName.Equals(brand)
                             select Phy).ToList();

                    Result = (from Views in Query
                              select new PhysicalInventoryReportView
                              {
                                 Year = Views.Year.ToString(),
                                 StyleNo = Views.StyleNo.ToString(),
                                 Brand = Views.BrandName.ToString(),
                                 SrpQty = Views.SRPQty.ToString("###,##0"),
                                 SrpPrice = Views.SRPPrice.ToString("###,###,##0.00"),
                                 SrpAmount = Views.SRPAmt.ToString("###,###,##0.00"),
                                 MrdQty = Views.MDQty.ToString("###,##0"),
                                 MrdPrice = Views.MDPrice.ToString("###,###,##0.00"),
                                 MrdAmount = Views.MDAmt.ToString("###,###,##0.00"),
                                 TotalQty = (Views.SRPQty + Views.MDQty).ToString("###,##0"),
                                 TotalAmount = (Views.SRPAmt + Views.MDAmt).ToString("###,###,##0.00"),
                              }).ToList();

                }
                else
                {
                    Query = (from Phy in PhysicalInventory()
                              where Phy.Year.Equals(ValYear) && Phy.BrandName.Equals(brand) && Phy.Category.Equals(Cat)
                             select Phy).ToList();

                    Result = (from Views in Query
                              select new PhysicalInventoryReportView
                              {
                                  Year = Views.Year.ToString(),
                                  StyleNo = Views.StyleNo.ToString(),
                                  Brand = Views.BrandName.ToString(),
                                  SrpQty = Views.SRPQty.ToString("###,###,###,##0"),
                                  SrpPrice = Views.SRPPrice.ToString("###,###,##0.00"),
                                  SrpAmount = Views.SRPAmt.ToString("###,###,##0.00"),
                                  MrdQty = Views.MDQty.ToString("###,###,###,##0"),
                                  MrdPrice = Views.MDPrice.ToString("###,###,##0.00"),
                                  MrdAmount = Views.MDAmt.ToString("###,###,###,###,##0.00"),
                                  TotalQty = (Views.SRPQty + Views.MDQty).ToString("###,###,###,##0"),
                                  TotalAmount = (Views.SRPAmt + Views.MDAmt).ToString("###,###,##0.00")
                              }).ToList();
                }
               

                return Result;
            }
            catch
            {
                throw;
            }
        }

        public List<PhysicalInventoryReportView> LoadReportPhysicalInventory(int ValYear, string Cat)
        { 

            try
            {
        
                List<PhysicalInventoryView> Query = new List<PhysicalInventoryView>();
                Query.Clear();

                List<PhysicalInventoryReportView> Result = new List<PhysicalInventoryReportView>();
                Result.Clear();

                if (Cat == "ALL")
                {
                    Query = (from Phy in PhysicalInventory()
                             where Phy.Year.Equals(ValYear)
                             select Phy).ToList();

                    Result = (from Views in Query
                              select new PhysicalInventoryReportView
                              {
                                 Year = Views.Year.ToString(),
                                 StyleNo = Views.StyleNo.ToString(),
                                 Brand = Views.BrandName.ToString(),
                                 SrpQty = Views.SRPQty.ToString("###,##0"),
                                 SrpPrice = Views.SRPPrice.ToString("###,###,##0.00"),
                                 SrpAmount = Views.SRPAmt.ToString("###,###,##0.00"),
                                 MrdQty = Views.MDQty.ToString("###,##0"),
                                 MrdPrice = Views.MDPrice.ToString("###,###,##0.00"),
                                 MrdAmount = Views.MDAmt.ToString("###,###,##0.00"),
                                 TotalQty = (Views.SRPQty + Views.MDQty).ToString("###,##0"),
                                 TotalAmount = (Views.SRPAmt + Views.MDAmt).ToString("###,###,##0.00"),
                              }).ToList();

                }
                else
                {
                    Query = (from Phy in PhysicalInventory()
                              where Phy.Year.Equals(ValYear) && Phy.Category.Equals(Cat)
                             select Phy).ToList();

                  
                    Result = (from Views in Query
                                select new PhysicalInventoryReportView
                                {
                                    Year = Views.Year.ToString(),
                                    StyleNo = Views.StyleNo.ToString(),
                                    Brand = Views.BrandName.ToString(),
                                    SrpQty = Views.SRPQty.ToString("###,##0"),
                                    SrpPrice = Views.SRPPrice.ToString("###,###,##0.00"),
                                    SrpAmount = Views.SRPAmt.ToString("###,###,##0.00"),
                                    MrdQty = Views.MDQty.ToString("###,##0"),
                                    MrdPrice = Views.MDPrice.ToString("###,###,##0.00"),
                                    MrdAmount = Views.MDAmt.ToString("###,###,##0.00"),
                                    TotalQty = (Views.SRPQty + Views.MDQty).ToString("###,##0"),
                                    TotalAmount = (Views.SRPAmt + Views.MDAmt).ToString("###,###,##0.00")
                                }).ToList();
                    
                }
               

                return Result;
            }
            catch
            {
                throw;
            }
        }



    }
}
