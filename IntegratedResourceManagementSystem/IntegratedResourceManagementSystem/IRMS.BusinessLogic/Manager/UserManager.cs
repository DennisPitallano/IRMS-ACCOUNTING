using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.ObjectModel;
using BLToolkit;
using BLToolkit.Data;
using IRMS.BusinessLogic.DataAccess;
using Microsoft.VisualBasic;
using IRMS.Components;
using System.Web.UI.WebControls;
namespace IRMS.BusinessLogic.Manager
{
    public class UserManager:LogManager<UsersClass>
    {
        Security Security = new Security();
        #region Accessor
        UserClassAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UserClassAccessor.CreateInstance(); }
        }
        #endregion

        public UsersClass GetUserAccountByKey(long id)
        {
            return Accessor.Query.SelectByKey<UsersClass>(id) ?? new UsersClass();
        }

        public List<UsersClass> Users()
        {
            using (DbManager dbm = new DbManager())
            {
                return Accessor.Query.SelectAll<UsersClass>();
            }
        }

        public void Save(UsersClass User)
        {
            using (DbManager db = new DbManager())
            {
                if (User.ID != 0)
                {
                    Accessor.Query.Update(db, User);
                }
                else
                {
                 Identity=  Accessor.Query.InsertAndGetIdentity(db, User);
                }
            }
        }

        public int SaveaAndGetIdentity(UsersClass User)
        {
            using (DbManager db = new DbManager())
            {
                 return  Accessor.Query.InsertAndGetIdentity(db, User);
            }
        }

        public void Delete(UsersClass User)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, User);
            }
        }

        public UsersClass CheckUserAccount(string UserName, string Password)
        {
            UsersClass user = new UsersClass();
            string EncryptPassword = Security.EncryptStringAES(Password, Security.SECURITY_PASSWORD);
            try
            {
                 user = (from user_ in Users()
                         where user_.Username == UserName && user_.UserPass == EncryptPassword
                            select user_).FirstOrDefault();
            }
            catch (Exception)
            {
               // user = new UsersClass();
            }
            return user;
        }

        public void UpdateOnlineStatus(long UserId,bool OnlineStatus)
        {
            Accessor.UpdateOnlineStatus(UserId,OnlineStatus);
        }

        private UsersClass systemuser = new UsersClass();

        public UsersClass FindUser(string UserName)
        {
            systemuser = Accessor.FindUser(UserName);
            return systemuser;
        }
        public bool ConfirmPassword(string Password)
        {
            bool bResult = false;

            try
            {
                if (string.IsNullOrEmpty(systemuser.Username))
                    return bResult;

                if (systemuser.UserPass == EncryptPassword(Password))
                    bResult = true;
            }
            catch (Exception)
            { 
            }
            return bResult; 
        }

        public string EncryptPassword(string sText)
        {
            StringBuilder sbValue = new StringBuilder();
            for (int i = 1; i <= sText.Length; i++)
            {
                sbValue.Append(Strings.Chr(Strings.Asc(sText.Substring(i-1,1)) + i * 2));
            }

            return sbValue.ToString();
        }

        #region Search UserAccounts
        public void SearchUserAccounts(SqlDataSource userAccountDataSource, string SearchParameter, string DepartmentId)
        {
            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT  Users.ID, Users.FullName, Users.UserName, lstDept.ListDesc AS Department, lstUserLevel.ListDesc AS UserLevel, Users.Email,Users.ContactNumber, Users.image,Users.IsActive FROM Users INNER JOIN lstDept ON Users.DeptID = lstDept.ID INNER JOIN lstUserLevel ON Users.UserLevelID =lstUserLevel.ID WHERE ");
           
            if (!string.IsNullOrEmpty(SearchParameter))
            {
                strCommand.Append(" Users.UserName like '%"+ SearchParameter +"%' or Users.FullName like '%"+SearchParameter+"%' ");
            }
            if (DepartmentId != "0")
            {
                strCommand.Append(" and Users.DeptID=" + DepartmentId + " ");
            }
          
            strCommand.Append(" order by ID DESC");
            userAccountDataSource.SelectCommand = strCommand.ToString();
            userAccountDataSource.DataBind();
        }

        public void SearchOnlineUserAccounts(SqlDataSource userAccountDataSource, string SearchParameter)
        {
            StringBuilder strCommand = new StringBuilder();
            strCommand.Append("SELECT  Users.ID, Users.FullName, Users.UserName, lstDept.ListDesc AS Department, lstUserLevel.ListDesc AS UserLevel, Users.Email,Users.ContactNumber,Users.image,Users.IsActive FROM Users INNER JOIN lstDept ON Users.DeptID = lstDept.ID INNER JOIN lstUserLevel ON Users.UserLevelID = lstUserLevel.ID where Users.IsOnline=1 ");

            if (!string.IsNullOrEmpty(SearchParameter))
            {
                strCommand.Append(" and Users.UserName like '%" + SearchParameter + "%' or Users.FullName like '%" + SearchParameter + "%' ");
            }
          
            strCommand.Append(" order by ID DESC");
            userAccountDataSource.SelectCommand = strCommand.ToString();
            userAccountDataSource.DataBind();
        }
        #endregion
    }
}
