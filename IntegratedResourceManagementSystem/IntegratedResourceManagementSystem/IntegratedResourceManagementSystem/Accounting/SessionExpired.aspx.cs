using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.Components;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class LogOut : System.Web.UI.Page
    {
        UserManager UM = new UserManager();
        protected void Page_Init(object sender, EventArgs e)
        {
            UsersClass user = new UsersClass();
            user = (UsersClass)Session["USER_ACCOUNT"];
            if (user != null)
            {
                UM.UpdateOnlineStatus(user.ID, false);
                Session.Clear();
                Session.Abandon();
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                Redirector.Redirect("~/Accounting/Login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}