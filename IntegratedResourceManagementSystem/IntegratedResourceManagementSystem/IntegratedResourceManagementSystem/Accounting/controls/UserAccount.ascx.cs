using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using IRMS.BusinessLogic.Manager;
using IRMS.Components;
using IRMS.ObjectModel;
using IntegratedResourceManagementSystem.Common;

namespace IntegratedResourceManagementSystem.Accounting.controls
{
    public partial class UserAccount : System.Web.UI.UserControl
    {
        #region variables
        MessageManager MSGManager = new MessageManager();
        UserManager UserManager = new UserManager();
        #endregion
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["USER_ACCOUNT"] != null)
            {
                UsersClass userAccount = (UsersClass)Session["USER_ACCOUNT"];
                Permission.PERMITTED_USER = userAccount;
                if (!Permission.IsAdmin())
                {
                    hpLinkAdmin.Visible = false;
                }
                if (string.IsNullOrEmpty(userAccount.FullName))
                {
                    lblName.Text = userAccount.Username;
                }
                else
                {
                    lblName.Text = userAccount.FullName;
                }
                if (string.IsNullOrEmpty(userAccount.Avatar))
                {
                    if (userAccount.Gender != "Male")
                    {
                        imgAvatar.ImageUrl = "~/Accounting-Admin/Images/femaleicon.png";
                    }
                    else
                    {
                        imgAvatar.ImageUrl = "~/Accounting-Admin/Images/maleicon.png";
                    }
                }
                else
                {
                    imgAvatar.ImageUrl = "~/Accounting-Admin/Images/" + userAccount.Avatar;
                }
                List<Message> Messages = MSGManager.GetMessagesToday(DateTime.Today, userAccount.ID);
                if (Messages.Count > 0)
                {
                    msgNotification.Visible = true;
                    int msg_count = Messages.Count;
                    if (msg_count > 1)
                    {
                        hpLinkNewMessage.Visible = true;
                        hpLinkNewMessage.Text = Messages.Count + "New Messages";
                        btnNewMessage.Visible = false;
                    }
                    else
                    {

                        btnNewMessage.Visible = true;
                        Message message = new Message();
                        message = Messages.FirstOrDefault();
                        UsersClass fromUser = UserManager.GetUserAccountByKey(message.FromUserId);
                        LiteralControl objPanelText = pnlMsgContent.Controls[0] as LiteralControl;
                        if (!string.IsNullOrEmpty(fromUser.FullName))
                        {
                            objPanelText.Text = "FROM:" + fromUser.FullName + "<br />" + message.MessageContent;
                        }
                        else
                        {
                            objPanelText.Text = "FROM:" + fromUser.Username + "<br />" + message.MessageContent;
                        }
                        hpLinkNewMessage.Visible = false;
                    }
                    Session["MESSAGES"] = Messages;
                    hpLinkNewMessage.NavigateUrl = "~/Accounting/ViewMessage.aspx";
                }
                else
                {
                    msgNotification.Visible = false;
                }
            }
            else
            {
                Redirector.Redirect("~/Accounting/SessionExpired.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewMessage_Click(object sender, EventArgs e)
        {
            HiddenField1_ModalPopupExtender.Show();
        }

        protected void btnOMessageOK_Click(object sender, EventArgs e)
        {
            try
            {
                UsersClass userAccount = (UsersClass)Session["USER_ACCOUNT"];
                Message message = new Message();
                List<Message> Messages = MSGManager.GetMessagesToday(DateTime.Today, userAccount.ID);
                message = Messages.FirstOrDefault();
                message.Status = "READ";
                MSGManager.Save(message);
                btnNewMessage.Visible = false;
            }
            catch (Exception)
            {
                Redirector.Redirect("~/Accounting/DashBoardPanel.aspx");
            }
        }
    }
}