using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class UserRoleManager:LogManager<UserRole>
    {
        #region Accessor
        /// <summary>
        /// 
        /// </summary>
        UserRoleAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UserRoleAccessor.CreateInstance(); }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserRole GetUserRoleByKey(int id)
        {
            return Accessor.Query.SelectByKey<UserRole>(id) ?? new UserRole();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public List<UserRole> GetUserRolesByUserId(int user_id)
        {
            var user_roles = (from user_role in GetAllUserRoles()
                              where user_role.UserId == user_id
                              select user_role).ToList();
            if (user_roles == null)
            {
                user_roles = new List<UserRole>();
            }
            return user_roles;
        }

        public List<UserRole> GetAllUserRoles()
        {
            return Accessor.Query.SelectAll<UserRole>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRole"></param>
        public void SaveUserRole(UserRole UserRole)
        {
            using (DbManager db = new DbManager())
            {
                if (UserRole.RecordNumber > 0)
                {
                    Accessor.Query.Update(db,UserRole);
                }
                else
                {
                  Identity =  Accessor.Query.InsertAndGetIdentity(db,UserRole);
                }
            }
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRoles"></param>
        public void SaveUserRoles(List<UserRole> UserRoles)
        {
            foreach(UserRole user_role in UserRoles)
            {
                SaveUserRole(user_role);
            }
        }

        public void DeleteUserRole(UserRole UserRole)
        {
            try
            {
                using (DbManager db = new DbManager())
                {
                    Accessor.Query.Delete(db, UserRole);
                }
            }
            catch (Exception)
            {
                Accessor.Query.RollbackTransaction();
            }
        }

        public void DeleteUserRoles(List<UserRole> UserRoles)
        {
            foreach (UserRole ur in UserRoles)
            {
                DeleteUserRole(ur);
            }
        }
    }
}
