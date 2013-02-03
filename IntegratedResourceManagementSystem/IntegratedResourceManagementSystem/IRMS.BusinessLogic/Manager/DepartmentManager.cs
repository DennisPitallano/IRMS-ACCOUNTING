using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.Entities;
using BLToolkit.Data;
using System.Web.UI.WebControls;

namespace IRMS.BusinessLogic.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class DepartmentManager :LogManager<Department>
    {
        #region Accessor
        /// <summary>
        /// 
        /// </summary>
        DepartmentAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DepartmentAccessor.CreateInstance(); }
        }
        #endregion

        public Department GetDepartmentByKey(int id)
        {
            return Accessor.Query.SelectByKey<Department>(id) ?? new Department();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Department> Departments()
        {
            return Accessor.Query.SelectAll<Department>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fabric"></param>
        public void Save(Department Department)
        {
            using (DbManager db = new DbManager())
            {
                if (Department.Id != 0)
                {
                    Accessor.Query.Update(db, Department);
                }
                else
                {
                  Identity= Accessor.Query.InsertAndGetIdentity(db, Department);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fabric"></param>
        public void Delete(Department Department)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, Department);
            }
        }


        public void LoadDepartments(SqlDataSource DepartmentDataSource, string search_parameter = "")
        {
            string CommandText = "SELECT [ID], [ListDesc] FROM [lstDept] ";
            if (search_parameter != "")
            {
                CommandText += " WHERE ListDesc LIKE '%" + search_parameter + "%' ";
            }
            CommandText += " ORDER BY [ID] DESC";
            DepartmentDataSource.SelectCommand = CommandText;
            DepartmentDataSource.DataBind();
        }
    }
}
