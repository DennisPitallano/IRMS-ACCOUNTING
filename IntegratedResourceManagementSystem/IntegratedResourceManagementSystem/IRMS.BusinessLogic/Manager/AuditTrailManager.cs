using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.Entities;
using BLToolkit.Data;
using IRMS.BusinessLogic.DataAccess;
using System.Web.UI.WebControls;

namespace IRMS.BusinessLogic.Manager
{
    public  class AuditTrailManager : IBaseManager<AuditTrail>
    {
        
        #region Accessor
        AuditTrailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return AuditTrailAccessor.CreateInstance(); }
        }
        #endregion

        public void Save(AuditTrail model)
        {
            using (DbManager dbm = new DbManager())
            {
                if (model.Id > 0)
                {
                    Accessor.Query.Update(dbm, model);
                }
                else
                {
                    Accessor.Query.Insert(dbm, model);
                }
            }
        }

        public void Delete(AuditTrail model)
        {
            using (DbManager dbm = new DbManager())
            {
                Accessor.Query.Delete(dbm,model);
            }
        }

        public List<AuditTrail> FetchAll()
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<AuditTrail>(dbm);
            }
        }

        public List<AuditTrail> FetchAllByUserId(string userName)
        {
            var auditTrail = from audit_t in FetchAll()
                             where audit_t.UserName == userName
                             select audit_t;
            return auditTrail.ToList<AuditTrail>();
        }

        public AuditTrail FetchById(int key)
        {
            var auditTrail = from audit_t in FetchAll()
                             where audit_t.Id == key
                             select audit_t;
            return auditTrail.FirstOrDefault();
        }

        public void Delete(List<AuditTrail> collection)
        {
            foreach (var audit in collection)
            {
                Delete(audit);
            }
        }

        #region Filter Users
        public void SearchUserAccounts(SqlDataSource userAccountDataSource, string searchParameter)
        {
            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT [ID], [FullName], [UserName], [image],[ContactNumber] FROM [Users] ");

            if (!string.IsNullOrEmpty(searchParameter))
            {
                strCommand.Append(" Where Users.UserName like '%" + searchParameter + "%' or Users.FullName like '%" + searchParameter + "%' ");
            }

            userAccountDataSource.SelectCommand = strCommand.ToString();
            userAccountDataSource.DataBind();
            
        }
        #endregion
        #region filter audit trails
         public void FilterAuditLogs(SqlDataSource logDataSource, DateTime from, DateTime to, string UserName="")
        {
            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT [ActionTaken], [DTStamp] FROM [AuditTrail] where DTStamp between '"+from.ToString()+"' and '"+to.ToString()+"' ");
            if (!string.IsNullOrEmpty(UserName))
            {
                strCommand.Append(" and UserName='"+UserName+"'");
            }
            strCommand.Append(" ORDER BY [DTStamp] DESC ");
            logDataSource.SelectCommand = strCommand.ToString();
            logDataSource.DataBind();
        }
        #endregion
    }
}
