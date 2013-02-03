using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class MessageManager
    {
        #region Accessor
        MessageAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return MessageAccessor.CreateInstance(); }
        }
        #endregion

        public void Save(Message Message)
        {
            using (DbManager db = new DbManager())
            {
                if (Message.RecordNumber != 0)
                {
                    Accessor.Query.Update(db, Message);
                }
                else
                {
                    Accessor.Query.Insert(db, Message);
                }
            }
        }

        public void Delete(Message Message)
        {
            using (DbManager dbm = new DbManager())
            {
                Accessor.Query.Delete(dbm, Message);
            }
        }

        public List<Message> Messages()
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<Message>(dbm);
            }
        }

        public List<Message> GetMessagesToday(DateTime todayDate, long UserId)
        {
            var results = (from message in Messages()
                           where message.DateSent ==  todayDate && message.ToUserId == UserId && message.Status =="UNREAD"
                          select message).ToList();
            return results;
        }

        public Message GetMessage(long MessageId)
        {
            var result = (from message in Messages()
                           where message.RecordNumber == MessageId
                           select message).FirstOrDefault();
            return result;
        }
        public Message GetMessage(long MessageId,List<Message>Messages)
        {
            var result = (from message in Messages
                          where message.RecordNumber == MessageId
                          select message).FirstOrDefault();
            return result;
        }
    }
}
