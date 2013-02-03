using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class DashBoardPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // VERSION 1.01 (s) CTS
            if (System.Configuration.ConfigurationManager.AppSettings["Integration"] == "YES")
            {
                if (Session.Count == 0)
                {
                    Response.Redirect("~/Accounting/Login.aspx");
                    return;
                }
                else
                {
                    if ((string)Session["SHOW_CLASSIC_WINDOW"] == "FALSE")
                    {
                        Response.Write("<script> window.open('" + System.Configuration.ConfigurationManager.AppSettings["RemotePage"] + "','_blank',fullscreen='yes'); </script>");
                        Session["SHOW_CLASSIC_WINDOW"] = "TRUE";
                    }
                }
            }
            // VERSION 1.01 (e) CTS
        }
    }
}