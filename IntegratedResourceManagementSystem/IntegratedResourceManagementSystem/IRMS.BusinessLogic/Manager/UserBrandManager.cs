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
    public class UserBrandManager
    {
        #region Accessor
        UserBrandAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UserBrandAccessor.CreateInstance(); }
        }
        #endregion

        public void Save(UserBrand UserBrand)
        {
            using (DbManager db = new DbManager())
            {
                if (UserBrand.RecordNumber > 0)
                {
                    Accessor.Query.Update(db, UserBrand);
                }
                else
                {
                    Accessor.Query.Insert(db, UserBrand);
                }
            }
        }

        public UserBrand GetUserBrandByUserId(int UserID)
        {
            var user_brand = UserBrands().Where(ub => ub.UserId == UserID).SingleOrDefault();
            return user_brand;
        }

        public List<UserBrand> UserBrands()
        {
            return Accessor.Query.SelectAll<UserBrand>();
        }

        #region User
        public SqlDataSource SearchUsers(SqlDataSource UsersDataSource, string search_parameter)
        {
            StringBuilder CommandText = new StringBuilder();
            CommandText.Append("SELECT Users.ID, Users.UserName, Users.FullName, Users.Email, lstDept.ListDesc, lstUserLevel.ListDesc AS UserLevel FROM Users INNER JOIN lstDept ON Users.DeptID = lstDept.ID INNER JOIN lstUserLevel ON Users.UserLevelID = lstUserLevel.ID WHERE (lstDept.ID = 4) ");
            if (search_parameter != "")
            {
                CommandText.Append(" AND Users.UserName LIKE '%" + search_parameter + "%'");
            }
            UsersDataSource.SelectCommand = CommandText.ToString();
            UsersDataSource.DataBind();
            return UsersDataSource;
        }
        #endregion
    }
}
