using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class ChangePassword : System.Web.UI.Page
{
    LoginBL objLogin = new LoginBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("Change password Page loaded Successfully");
            
            //Gets Session Value from Login Page
            lblUserId.Text = Session["UserId"].ToString();
            lblStatus.Visible = false;
      
         }
        catch (NullReferenceException)
        {

            Response.Redirect("AccessDenied.aspx");
        }

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        //Calls method in LoginBL
        int ret = objLogin.ChangePassword(lblUserId.Text, txtCurrentPasswd.Text, txtNewPwd.Text);
        try
        {
            //return status 
            if (ret == 0)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                //for correct condition
                lblStatus.Text = "Password Changed Successfully";
            }
            else if (ret == -1)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //invalid UserId
                lblStatus.Text = "UserId is not an existing one";
            }
            else if (ret == -2)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //Unmatched Password and UserId
                lblStatus.Text = "UserId and Current Password do not match";
            }
            else if (ret == -3)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //Unmatched Current and New Password 
                lblStatus.Text = "New Password and Current Password cannot be same";
            }
            else if (ret == -4)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //New Password and UserId cannot be same
                lblStatus.Text = "New Password and UserId cannot be same";

            }
            else if (ret == -5)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //Other Errors
                lblStatus.Text = "Password unchanged due to some errors";
            }
        }
        catch (InvalidOperationException )
        {
            Logger.Write("ChangePassword Page loading was not Successful");
            Response.Redirect("Error.aspx");
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            //Making all the fields empty
            txtCurrentPasswd.Text = string.Empty;
            txtNewPwd.Text = string.Empty;
            txtConfirmPwd.Text = string.Empty;
        }
        catch (InvalidOperationException)
        {
            Logger.Write("Cancel was not Successful");
            Response.Redirect("Error.aspx");
        }
    }
}





