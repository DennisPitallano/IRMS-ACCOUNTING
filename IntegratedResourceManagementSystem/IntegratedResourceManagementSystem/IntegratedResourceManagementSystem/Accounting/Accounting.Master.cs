using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class Accounting : System.Web.UI.MasterPage
    {
        // VERSION 1.01 (s) CTS
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblVersion.Text = ConfigurationManager.AppSettings["version"].ToString();
            //if (!this.IsPostBack)
            //{
            //    if (Session.Count == 0)
            //    {
            //        lblUser.Text = "NONE";
            //        lnkbtnLogin.Text = "Log In";
            //    }
            //    else
            //    {
            //        lblUser.Text = Session["USER_ID"].ToString().ToUpper();
            //        //lblBrand.Text = Session["USER_BRAND"].ToString().ToUpper();
            //        lnkbtnLogin.Text = "Log Out";
            //    }
            //}
        }

        protected void lnkbtnLogin_Click(object sender, EventArgs e)
        {
            //if (lnkbtnLogin.Text == "Log Out")
            //{
            //    Session.Abandon();
            //    lblUser.Text = "NONE";
            //    lnkbtnLogin.Text = "Log In";
            //    Response.Redirect("~/Accounting/Login.aspx");
            //}
        }
        // VERSION 1.01 (e) CTS
    }
}