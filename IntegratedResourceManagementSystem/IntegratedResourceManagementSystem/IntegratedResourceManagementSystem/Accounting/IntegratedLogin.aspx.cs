using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using System.Data;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class IntegratedLogin : System.Web.UI.Page
    {
        private UserManager UM = new UserManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (!this.IsPostBack)
            {
                //Session.Abandon();
                //Response.Write("<script> document.getElementById('Hyperlink1').click(); </script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "showwindow", "window.open('" + slink + "');", true);
                //Response.Write("<script> window.open('DashBoardPanel.aspx','_new'); </script>");

                //if (Session.IsNewSession == false)
                //{
                //    if (Session["USERNAME"] == null)
                //        lblErrorMessage.Text = Session["SessionMessage"].ToString();
                //}
            }
        }
        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsersClass user = new UsersClass();
            lblErrorMessage.Text = string.Empty;
            user = UM.FindUser(txtUserName.Text);
            if (user == null)
            {
                lblErrorMessage.Text = "ERROR : USER NAME DOESN'T EXIST!";
                return;
            }

            if (UM.ConfirmPassword(txtPassword.Text) == false)
            {
                lblErrorMessage.Text = "ERROR : EMPTY OR WRONG PASSWORD!";
                return;
            }

            Session["USER_ID"] = txtUserName.Text;
            Session["CURRENT_DATE"] = DateTime.Now;
            Session["NET_SESSION_ID"] = Session.SessionID;
            Session["CLASSIC_SESSION_ID"] = "";
            Session["SHOW_CLASSIC_WINDOW"] = "FALSE";
            Session.Timeout = 30;

          //  SendToBridge(ref user);
        }

        private void SendToBridge(ref UsersClass user)
        {
            string sBridgeLocation = ConfigurationManager.AppSettings["BridgeLocation"];
            string sDefaultPage = ConfigurationManager.AppSettings["DefaultPage"];

            //string sLocation = ConfigurationManager.AppSettings["BridgeLocation"];
            //Response.Write("<form name='bridge' action='http://irms-svr:82/irmsbridge.asp' method='POST' Target='_blank'>");
            Response.Write("<form name='bridge' action='" + sBridgeLocation + "' method='POST'>");
            Response.Write("<input type=hidden name='sessionid' value='" + Session.SessionID + "' >");
            Response.Write("<input type=hidden name='unameid' value='" + txtUserName.Text + "' >");
            Response.Write("<input type=hidden name='ulevelid' value='" + user.UserLevelID + "' >");
            Response.Write("<input type=hidden name='udeptid' value='" + user.DeptID + "' >");
            Response.Write("<input type=hidden name='defaultpage' value='" + sDefaultPage + "' >");
            Response.Write("</form>");
            Response.Write("<script>window.document.bridge.submit();</script>");
            Response.End();
        }

        private void ResponseMessage(string sMess)
        {
            //this.Response.Write("<script language=\"javascript\">alert('" + sMess + "');</script>");         
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + sMess + "');", true);
        }
    }
}