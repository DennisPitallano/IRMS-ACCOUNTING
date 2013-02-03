using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.Entities;
using IRMS.ObjectModel;
using IRMS.Components;

namespace IRMS.BusinessLogic.Manager
{
    public class LogManager<E> where E: class,new()
    {
        public int Identity { get; set; }
        public void SaveTransactionLog(UsersClass User, TransactionType  transactionType)
        {
            AuditTrail auditTrail= new AuditTrail();
            AuditTrailManager logManager= new AuditTrailManager();
            try
            {
                switch (transactionType)
                {
                    case TransactionType.INSERT:
                        auditTrail = new AuditTrail
                        {
                            ActionTaken = "INSERTED NEW " + new E().GetType().Name + " with an Identity of " + Identity.ToString()+".",
                            DateRecorded = DateTime.Now,
                            UserName = User.Username,
                        };
                        break;
                    case TransactionType.UPDATE:
                        auditTrail = new AuditTrail
                        {
                            ActionTaken = "UPDATED Identity " + Identity.ToString() + " IN " + new E().GetType().Name + " DATABASE.",
                            DateRecorded = DateTime.Now,
                            UserName = User.Username,
                        };
                        break;
                    case TransactionType.DELETE:
                        auditTrail = new AuditTrail
                        {
                            ActionTaken = "DELETED Identity " + Identity.ToString() + " FROM " + new E().GetType().Name + " DATABASE.",
                            DateRecorded = DateTime.Now,
                            UserName = User.Username,
                        };
                        break;
                    case TransactionType.LOGIN:
                        auditTrail = new AuditTrail
                        {
                            UserName = User.Username,
                            ActionTaken = "Log into the System.",
                            DateRecorded = DateTime.Now,
                        };
                        break;
                    case TransactionType.LOGOUT:
                        auditTrail = new AuditTrail
                        {
                            UserName = User.Username,
                            ActionTaken = "Log Out into the System.",
                            DateRecorded = DateTime.Now,
                        };
                        break;
                    case TransactionType.CONFIRMED:
                        auditTrail = new AuditTrail
                        {
                            ActionTaken = "CONFIRMED DR with an Identity " + Identity.ToString() + " FROM " + new E().GetType().Name + " DATABASE.",
                            DateRecorded = DateTime.Now,
                            UserName = User.Username,
                        };
                        break;
                    default:
                        break;
                }
                logManager.Save(auditTrail);
            }
            catch (Exception ex)
            {
              //  throw ex;
            }
        }
    }

}
