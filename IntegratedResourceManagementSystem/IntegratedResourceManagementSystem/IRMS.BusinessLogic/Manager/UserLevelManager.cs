using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.Entities;
using BLToolkit.Data;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.DataAccess;

namespace IRMS.BusinessLogic.Manager
{
    /// <summary>
    /// Dennis Pitallano 
    /// July 19, 2012 11:49 AM
    /// </summary>
    public class UserLevelManager:LogManager<UserLevel>
    {
        #region Accessor
        /// <summary>
        /// 
        /// </summary>
        UserLevelAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UserLevelAccessor.CreateInstance(); }
        }
        #endregion

        public UserLevel GetUserLevelByKey(int id)
        {
            return Accessor.Query.SelectByKey<UserLevel>(id) ?? new UserLevel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<UserLevel> UserLevels()
        {
            return Accessor.Query.SelectAll<UserLevel>();
        }

      
        public void Save(UserLevel UserLevel)
        {
            using (DbManager db = new DbManager())
            {
                if (UserLevel.UserLevelId != 0)
                {
                    Accessor.Query.Update(db, UserLevel);
                }
                else
                {
                   Identity=Accessor.Query.InsertAndGetIdentity(db, UserLevel);
                }
            }
        }

       
        public void Delete(UserLevel UserLevel)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, UserLevel);
            }
        }


        public void LoadUserLevels(SqlDataSource UserLevelDataSource, string search_parameter = "")
        {
            string CommandText = "SELECT [ID], [ListDesc] FROM [lstUserLevel] ";
            if (search_parameter != "")
            {
                CommandText += " WHERE ListDesc LIKE '%" + search_parameter + "%' ";
            }
            CommandText += " ORDER BY [ID] DESC";
            UserLevelDataSource.SelectCommand = CommandText;
            UserLevelDataSource.DataBind();
        }
    }
}
