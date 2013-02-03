using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IRMS.BusinessLogic.Manager
{
    public class MonthlySOIAdjustmentManager
    {
        #region Accessor
        MonthlyStoreOutStandingInventoryAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MonthlyStoreOutStandingInventoryAccessor.CreateInstance(); }
        }
        #endregion
        public List<MonthlySOIAdjustment> MonthlySOIAdjustments()
        {
            
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<MonthlySOIAdjustment>(dbm);
            }
        }

        public List<MonthlySOIAdjustment>[] GetMonthlySOIAdjustmentByCode(string SOICode)
        {
            List<MonthlySOIAdjustment>[] adjustments = new List<MonthlySOIAdjustment>[2];
            List<MonthlySOIAdjustment> AdjustmentAdd= new List<MonthlySOIAdjustment> ();
            List<MonthlySOIAdjustment> AdjustmentLess = new List<MonthlySOIAdjustment>();
             List<MonthlySOIAdjustment> results = (from m_soi_adj in MonthlySOIAdjustments()
                                                 where m_soi_adj.SOICode == SOICode 
                                        select  m_soi_adj).ToList();

             foreach (MonthlySOIAdjustment soi_adj in results)
             {
                 if (soi_adj.Type == "ADD")
                 {
                    AdjustmentAdd.Add(soi_adj);
                 }
                 else
                 {
                     AdjustmentLess.Add(soi_adj);
                 }
             }
             var add_adjustment_group = (from add_soi in AdjustmentAdd
                       group add_soi by add_soi.Particular into _soi
                       select new MonthlySOIAdjustment
                       {
                          Particular = _soi.Key ,
                           Quantity = _soi.Sum(p => p.Quantity)
                       }).ToList<MonthlySOIAdjustment>();

             var less_adjustment_group = (from less_soi in AdjustmentLess
                                          group less_soi by less_soi.Particular into _soi
                                         select new MonthlySOIAdjustment
                                         {
                                             Particular = _soi.Key,
                                             Quantity = _soi.Sum(p => p.Quantity)
                                         }).ToList<MonthlySOIAdjustment>();

             adjustments[0] = add_adjustment_group;
             adjustments[1] = less_adjustment_group;
             return adjustments;
        }

        public void Save(MonthlySOIAdjustment Adjustment)
        {
            using (DbManager db = new DbManager())
            {
                if (Adjustment.RecordNumber != 0)
                {
                    Accessor.Query.Update(db, Adjustment);
                }
                else
                {
                    Accessor.Query.Insert(db, Adjustment);
                }
            }
        }

        public void Save(List<MonthlySOIAdjustment> Adjustments)
        {
            foreach (MonthlySOIAdjustment adj in Adjustments)
            {
                Save(adj);
            }
        }

        public void Delete(MonthlySOIAdjustment Adjustment)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, Adjustment);
            }
        }
    }
}
