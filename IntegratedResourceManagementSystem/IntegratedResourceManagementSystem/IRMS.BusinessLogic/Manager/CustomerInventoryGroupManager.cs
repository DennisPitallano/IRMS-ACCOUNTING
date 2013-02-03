using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class CustomerInventoryGroupManager :LogManager<CustomerInventoryGroup>
    {
        #region Accessor
        InventoryGroupAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return InventoryGroupAccessor.CreateInstance(); }
        }
        #endregion

        public List<CustomerInventoryGroup> CustomersInventoryGroup()
        {
            using (DbManager dbm = new DbManager())
            {
                return this.Accessor.Query.SelectAll<CustomerInventoryGroup>(dbm) ?? new List<CustomerInventoryGroup>();
            }
        }

        public CustomerInventoryGroup GetCustomerInventoryGroupByKeyAndInventoryGroup(long key, InventoryGroup inventoryGroup)
        {
            var result = (from customer in CustomersInventoryGroup()
                          where
                              customer.CustomerNumber == key && customer.InventoryGroupId == inventoryGroup.InventoryGroupId
                          select customer).FirstOrDefault();
            return result ?? new CustomerInventoryGroup();
        }

        public bool IsCustomerAlreadyExistInGroup(long key, InventoryGroup inventoryGroup)
        {
            var customer = GetCustomerInventoryGroupByKeyAndInventoryGroup(key, inventoryGroup);
            if (customer.RecordNumber >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save(CustomerInventoryGroup customerInventoryGroup)
        {
            using (DbManager dbm = new DbManager())
            {
                if (customerInventoryGroup.RecordNumber>0)
                {
                    Accessor.Query.Update(dbm,customerInventoryGroup);
                }
                else
                {
                   Identity=Accessor.Query.InsertAndGetIdentity(dbm, customerInventoryGroup);
                }
            }
        }

        public void Save(List<CustomerInventoryGroup> customerInventoryGroups)
        {
            foreach (var cig in customerInventoryGroups)
            {
                Save(cig);
            }
        }


        public void Delete(CustomerInventoryGroup customerInventoryGroup)
        {
            using (DbManager dbm = new DbManager())
            {
                Accessor.Query.Delete(dbm, customerInventoryGroup);
            }
        }

        public void Delete(List<CustomerInventoryGroup> customerInventoryGroups)
        {
            foreach (var cig in customerInventoryGroups)
            {
                Delete(cig);
            }
        }

        public CustomerReferenceLink GetCustomerLinkByCustCode(string custCode)
        {
            var result = (from crl in CustomerReferenceLinks()
                          where crl.CustomerCode == custCode
                          select crl).FirstOrDefault();
            return result ?? new CustomerReferenceLink();
        } 

        public List<CustomerReferenceLink> CustomerReferenceLinks()
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<CustomerReferenceLink>() ?? new List<CustomerReferenceLink>();
            }
        }
    }
}
