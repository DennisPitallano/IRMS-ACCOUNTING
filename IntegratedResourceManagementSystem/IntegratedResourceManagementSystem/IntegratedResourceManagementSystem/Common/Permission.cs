using System.Collections.Generic;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Common
{
    public static class Permission
    {
        #region variables

        private static UserLevelManager UserLevelManger = new UserLevelManager();

        private static UserRoleManager UserRolesManager = new UserRoleManager();

        public static UsersClass PERMITTED_USER { get; set; }

        public static List<UserRole> ROLES { get; set; }

        #endregion variables

        public static bool CanApprove()
        {
            return CheckRole("CAN APPROVE");
        }

        public static bool CanDelete()
        {
            return CheckRole("CAN DELETE");
        }

        public static bool CanInsert()
        {
            return CheckRole("CAN INSERT");
        }

        public static bool CanUpdate()
        {
            return CheckRole("CAN UPDATE");
        }

        public static bool IsAdmin()
        {
            if (GetUserLevel() == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckRole(string role)
        {
            bool result = false;
            foreach (var item in ROLES)
            {
                if (item.Role == role)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private static string GetUserLevel()
        {
            return UserLevelManger.GetUserLevelByKey(PERMITTED_USER.UserLevelID).UserLevelDescription;
        }
    }
}