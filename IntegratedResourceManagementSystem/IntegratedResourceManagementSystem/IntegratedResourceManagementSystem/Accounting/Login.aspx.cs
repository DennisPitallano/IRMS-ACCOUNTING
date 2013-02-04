using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.ObjectModel;
using System.Configuration;
using IRMS.BusinessLogic.Manager;
using IRMS.Components;
using IRMS.Entities;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class Login : System.Web.UI.Page 
    {
        #region variables
         private UserManager UM = new UserManager();
         AuditTrailManager AuditLog = new AuditTrailManager();
         UserRoleManager UserRoleManager = new UserRoleManager();
        
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["action"];
            if (!this.IsPostBack)
            {
                if (action == "logout")
                {
                    UsersClass user = (UsersClass)Session["USER_ACCOUNT"];
                    if (user != null)
                    {
                        UM.UpdateOnlineStatus(user.ID, false);
                        #region log
                        UM.SaveTransactionLog(user, TransactionType.LOGOUT);
                        #endregion
                    }
                    Session.Clear();
                    Session.Abandon();
                }
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            UsersClass user = new UsersClass();
           

            if (Session["USER_ACCOUNT"] != null)
            {
                Redirector.Redirect("~/Accounting/DashBoardPanel.aspx");
            }
            else
            {
                lblErrorMessage.Text = string.Empty;

                user = UM.CheckUserAccount(txtUsername.Text, txtPassword.Text);

                if (user == null )
                {
                    pnlError.Visible = true;
                    lblErrorMessage.Text = "ERROR : USER ACCOUNT DOESN'T EXIST!";
                    return;
                }

                if (user.IsOnline == true)
                {
                    UM.UpdateOnlineStatus(user.ID, false);
                    //pnlError.Visible = true;
                    //lblErrorMessage.Text = "WARNING : USER ACCOUNT ALREADY ONLINE!";
                    //return;
                }
                Session["USER_ACCOUNT"] = user;
                Session["USER_ID"] = user.ID;
                Session["USER_NAME"] = user.Username;
              
                UM.UpdateOnlineStatus(user.ID, true);
                Session.Timeout = 30;
                Session["USER_ROLES"] = UserRoleManager.GetUserRolesByUserId((int)user.ID);

                #region init log action
                UM.SaveTransactionLog(user,TransactionType.LOGIN);
                #endregion
                Redirector.Redirect("~/Accounting/DashBoardPanel.aspx");
            }
            //Session["CURRENT_DATE"] = DateTime.Now;
            //Session["NET_SESSION_ID"] = Session.SessionID;
            //Session["CLASSIC_SESSION_ID"] = "";
            //Session["SHOW_CLASSIC_WINDOW"] = "FALSE";
         
            //SendToBridge(ref user);
        }

        private void SendToBridge(ref UsersClass user)
        {
            string sBridgeLocation = ConfigurationManager.AppSettings["BridgeLocation"];
            string sDefaultPage = ConfigurationManager.AppSettings["DefaultPage"];

            //string sLocation = ConfigurationManager.AppSettings["BridgeLocation"];
            //Response.Write("<form name='bridge' action='http://irms-svr:82/irmsbridge.asp' method='POST' Target='_blank'>");
            Response.Write("<form name='bridge' action='" + sBridgeLocation + "' method='POST'>");
            Response.Write("<input type=hidden name='sessionid' value='" + Session.SessionID + "' >");
            Response.Write("<input type=hidden name='unameid' value='" +  this.txtUsername.Text + "' >");
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