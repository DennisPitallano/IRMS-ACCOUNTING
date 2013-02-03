using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;
using IRMS.ObjectModel;
using IntegratedResourceManagementSystem.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using IRMS.Components;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class MyAcoount : System.Web.UI.Page
    {
        #region variables
        DepartmentManager DepartmentManager = new DepartmentManager();
        UserLevelManager UserLevelManager = new UserLevelManager();
        UserManager UserManager = new UserManager();
        UsersClass USER { get { return (UsersClass)Session["USER_ACCOUNT"]; } }
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            GetUserInformation();
        }
        private void GetUserInformation()
        {
            hfUserId.Value = USER.ID.ToString();
            txtFullName.Text = USER.FullName;
            txtContactNumber.Text = USER.ContactNumber;
            txtEmailAddress.Text = USER.Email;
            txtUserName.Text = USER.Username;
            imgAvatar.ImageUrl ="~/Accounting-Admin/Images/" + USER.Avatar;
            txtAccountLevel.Text = UserLevelManager.GetUserLevelByKey(USER.UserLevelID).UserLevelDescription;
            txtDepartment.Text = DepartmentManager.GetDepartmentByKey(USER.DeptID).DepartmentName;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlUploadAvatar.Visible = true;
            btnUpdate.Visible = false;
            btnDoneEditing.Visible = true;
            txtFullName.ReadOnly = false;
            txtEmailAddress.ReadOnly = false;
            txtContactNumber.ReadOnly = false;
            btnCancel.Visible = true;
        }

        protected void btnDoneEditing_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnCancel.Visible = false;
            btnDoneEditing.Visible = false;
            pnlUploadAvatar.Visible = false;
            txtFullName.ReadOnly = true;
            txtEmailAddress.ReadOnly = true;
            txtContactNumber.ReadOnly = true;
            //update user account
            UsersClass UpdatedUserAccount = new UsersClass();
            UpdatedUserAccount.ID = USER.ID;
            UpdatedUserAccount.Username = USER.Username;
            UpdatedUserAccount.UserPass = USER.UserPass;
            UpdatedUserAccount.IsActive = USER.IsActive;
            UpdatedUserAccount.ContactNumber = txtContactNumber.Text;
            UpdatedUserAccount.DeptID = USER.DeptID;
            UpdatedUserAccount.Email = txtEmailAddress.Text;
            UpdatedUserAccount.Gender = USER.Gender;
            UpdatedUserAccount.UserLevelID = USER.UserLevelID;
            if (string.IsNullOrEmpty(hfAvatarFileName.Value))
            {
                UpdatedUserAccount.Avatar = USER.Avatar;
            }
            else
            {
                UpdatedUserAccount.Avatar = hfAvatarFileName.Value;
            }
            UpdatedUserAccount.FullName = txtFullName.Text;
            UserManager.Save(UpdatedUserAccount);

            #region log
            Permission.PERMITTED_USER = USER;
            UserManager.Identity = (int)USER.ID;
            UserManager.SaveTransactionLog(Permission.PERMITTED_USER, TransactionType.UPDATE);
            #endregion
            //reset UserAccount Session
            Session["USER_ACCOUNT"] = UpdatedUserAccount;
        }

        private void ResizeImage(FileUpload fileUpload)
        {
            // First we check to see if the user has selected a file
            if (fileUpload.HasFile)
            {
                // Find the fileUpload control
                string filename = fileUpload.FileName;

                // Check if the directory we want the image uploaded to actually exists or not
                //if (!Directory.Exists(MapPath(@"Marketing-Admin/user-images")))
                //{
                //    // If it doesn't then we just create it before going any further
                //    Directory.CreateDirectory(MapPath(@"user-images"));
                //}
                // Specify the upload directory
                string directory = Server.MapPath(@"..\Accounting-Admin\Images\");

                // Create a bitmap of the content of the fileUpload control in memory
                Bitmap originalBMP = new Bitmap(fileUpload.FileContent);

                // Calculate the new image dimensions
                int origWidth = originalBMP.Width;
                int origHeight = originalBMP.Height;
                int sngRatio = origWidth / origHeight;
                int newWidth = 100;
                if (sngRatio <= 0)
                {
                    sngRatio = 1;
                }
                int newHeight = newWidth / sngRatio;

                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);

                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);
                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                // Save the new graphic file to the server
                newBMP.Save(directory + "user_" + filename);

                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();

                label.Text = "Image uploaded!";

                // Display the image to the user
                imgAvatar.Visible = true;
                imgAvatar.ImageUrl = "~/Accounting-Admin/Images/user_" + filename;
                hfAvatarFileName.Value = "user_" + filename;
            }
            else
            {
                label.Text = "No image uploaded!";
            }
        }
        protected void btnResetPasswordSave_Click(object sender, EventArgs e)
        {
            hfResetPasswordMessageHandler_ModalPopupExtender.Show();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            ResizeImage(fileUploadAvatar);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnDoneEditing.Visible = false;
            btnCancel.Visible = false;
            pnlUploadAvatar.Visible = false;
            txtFullName.ReadOnly = true;
            txtEmailAddress.ReadOnly = true;
            txtContactNumber.ReadOnly = true;
        }
        protected void btnReload_Click(object sender, EventArgs e)
        {
            gvUserLogs.DataBind();
        }
    }
}