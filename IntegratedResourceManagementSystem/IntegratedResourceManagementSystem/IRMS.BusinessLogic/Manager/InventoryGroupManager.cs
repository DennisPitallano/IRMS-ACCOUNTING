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
    public class InventoryGroupManager: LogManager<InventoryGroup>
    {
        #region Accessor
        InventoryGroupAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return InventoryGroupAccessor.CreateInstance(); }
        }
        #endregion

        /// <summary>
        /// Save Inventory Group
        /// </summary>
        /// <param name="inventoryGroup">Inventory Group Model</param>
        public void Save(InventoryGroup inventoryGroup)
        {
            using (DbManager dbm = new DbManager())
            {
                if (inventoryGroup.InventoryGroupId > 0)
                {
                    Accessor.Query.Update(dbm, inventoryGroup);
                }
                else
                {
                  Identity= Accessor.Query.InsertAndGetIdentity(dbm, inventoryGroup);
                }
            }
        }

        /// <summary>
        /// Delete Inventory Group
        /// </summary>
        /// <param name="inventoryGroup">Inventory Group Model</param>
        public void Delete(InventoryGroup inventoryGroup)
        {
            using (DbManager dbm = new DbManager()) 
            {
                Accessor.Query.Delete(dbm,inventoryGroup);
            }
        }

        /// <summary>
        /// List of Inventory Group
        /// </summary>
        /// <returns>Inventory Group Collection</returns>
        public List<InventoryGroup> InventoryGroups()
        {
            using (DbManager dbm = new DbManager())
            {
               return Accessor.Query.SelectAll<InventoryGroup>(dbm) ?? new List<InventoryGroup>();
            }
        }

        /// <summary>
        /// Get Inventory Group by Key
        /// </summary>
        /// <param name="key">Primary Key</param>
        /// <returns>Inventory Group Model</returns>
        public InventoryGroup GetInventoryGroupByKey(long key)
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectByKey<InventoryGroup>(key) ?? new InventoryGroup();
            }
        }

        #region SearchCustomer/Outlets
        public void SearchCustomer(SqlDataSource customerDataSource, string searchParameter,string brandName="")
        {
            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT [CustNo], [CompName], [brand],[MainCustNo] FROM [CustInfoEx] WHERE [MainCustNo] is not null ");
            if (!string.IsNullOrEmpty(searchParameter))
            {
                strCommand.Append(" AND CompName LIKE '%" + searchParameter + "%'");
            }

            if (brandName!="")
            {
                strCommand.Append(" and brand='"+brandName+"' ");
            }

            customerDataSource.SelectCommand = strCommand.ToString();
            customerDataSource.DataBind();
        }

        public void SearchCustomer(SqlDataSource customerDataSource, string searchParameter,long groupNumber, string brandName = "")
        {
            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT CustInfoEx.CustNo, CustInfoEx.CompName, CustInfoEx.brand,CustInfoEx.MainCustNo FROM CustInfoEx where  CustInfoEx.MainCustNo is not null and CustNo NOT IN(SELECT CUSTOMER_INVENTORY_GROUPS.CUSTOMER_NUMBER from CUSTOMER_INVENTORY_GROUPS Where CUSTOMER_INVENTORY_GROUPS.INVENTORY_GROUP_ID=" + groupNumber + ") ");
            if (!string.IsNullOrEmpty(searchParameter))
            {
                strCommand.Append(" AND CustInfoEx.CompName LIKE '%" + searchParameter + "%'");
            }

            if (brandName != "")
            {
                strCommand.Append(" and CustInfoEx.brand='" + brandName + "' ");
            }

            customerDataSource.SelectCommand = strCommand.ToString();
            customerDataSource.DataBind();
        }

        public void SearchInventoryGroup(SqlDataSource inventoryGroupDataSource, string searchParameter)
        {
            StringBuilder strCmd = new StringBuilder();
            strCmd.Append("SELECT * FROM [INVENTORY_GROUPS] ");
            if (!string.IsNullOrEmpty(searchParameter))
            {
                strCmd.Append(" WHERE GROUP_NAME LIKE '%"+searchParameter+"%' ");
            }
            strCmd.Append(" order by INVENTORY_GROUP_ID DESC");
            inventoryGroupDataSource.SelectCommand = strCmd.ToString();
            inventoryGroupDataSource.DataBind();
        }

        public void SearchCustomerInventoryGroup(SqlDataSource inventoryCustomerGroupDataSource,long inventoryGroup, string searchParameter)
        {
            StringBuilder strCmd = new StringBuilder();
            strCmd.Append("SELECT [ID], [CUSTOMER_NUMBER], [CUSTOMER_NAME], [BRAND_NAME],[ACCOUNT_NAME],[BRANCH_NAME] FROM [CUSTOMER_INVENTORY_GROUPS] WHERE [INVENTORY_GROUP_ID] =" + inventoryGroup + "");
            if (!string.IsNullOrEmpty(searchParameter))
            {
                strCmd.Append(" AND CUSTOMER_NAME LIKE '%"+searchParameter+"%' ");
            }
            inventoryCustomerGroupDataSource.SelectCommand = strCmd.ToString();
            inventoryCustomerGroupDataSource.DataBind();
        }
        #endregion
    }
}
