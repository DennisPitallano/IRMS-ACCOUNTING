using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BLToolkit.Mapping;
using BLToolkit.Common;
using BLToolkit.DataAccess;

namespace IRMS.ObjectModel
{
    [TableName("Usersx")]
    public class UsersClass
    {
        [MapField("ID"), PrimaryKey, NonUpdatable]
        public long ID { get; set; }

        [MapField("UserName")]
        public string Username { get; set; }

        [MapField("Password")]
        public string UserPass { get; set; }

        [MapField("DeptID")]
        public int DeptID { get; set; }

        [MapField("UserLevelID")]
        public int UserLevelID { get; set; }

        [MapField("FullName")]
        public string FullName { get; set; }

        [MapField("Gender")]
        public string Gender { get; set; }

        [MapField("Email")]
        public string Email { get; set; }

        [MapField("ContactNumber")]
        public string ContactNumber { get; set; }

        [MapField("image")]
        public string Avatar { get; set; }

        [MapField("IsActive")]
        public bool IsActive { get; set; }

        [MapField("IsOnline")]
        public bool IsOnline { get; set; }
    }
}
