using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class ForgotPassword : System.Web.UI.Page
{
    LoginBL objLogin = new LoginBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Logger.Write("Forgot Password Page Loaded successfully");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

        try
        {
            if (objLogin.ValidateUser(txtUserId.Text) > 0)
            {
                txtUserId.Enabled = false;
                btnNext.Enabled = false;
                lblQuestion.Visible = true;
                lblAnswer.Visible = true;
                txtAnswer.Visible = true;
                string Question = objLogin.GetSecurityQuestion(txtUserId.Text);
                lblQuesText.Text = Question;
                lblQuesText.Visible = true;
                btnRecoverPassword.Visible = true;
                btnRecoverPassword.Enabled = true;
                txtAnswer.Enabled = true;
                btnCancel.Visible = true;
                lblPasswordLine.Visible = false;
            }
            else
            {
                lblPasswordLine.Visible = true;
                lblPasswordLine.Text = "Invalid UserID";
            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("Next event failed in Forgot Password Page");
            Response.Redirect("Error.aspx");
        }
     
    }
    protected void btnRecoverPassword_Click(object sender, EventArgs e)
    {
        try
        {
            rfvAnswer.Visible = true;
            string password = objLogin.RecoverPassword(txtUserId.Text, txtAnswer.Text);
            if (password == "NA")
            {
                lblPasswordLine.Visible = true;
                lblPassword.Visible = false;
                lblPasswordLine.Text = "Invalid Answer";

            }
            else
            {
                btnRecoverPassword.Enabled = false;
                txtAnswer.Enabled = false;
                lblPasswordLine.Visible = true;
                lblPasswordLine.Text = "Your password is ";
                lblPassword.Visible = true;
                lblPassword.Text = password;
                lbtnLogin.Visible = true;
            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("RecoverPassword event failed in Forgot Password Page");
            Response.Redirect("Error.aspx");
        }
    
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtUserId.Text = "";
        txtAnswer.Text = "";
        rfvAnswer.Visible = false;
        txtUserId.Enabled = true;
        btnNext.Enabled = true;
        lblQuestion.Visible = false;
        lblAnswer.Visible = false;
        txtAnswer.Visible = false;
        lblQuesText.Visible = false;
        btnRecoverPassword.Visible = false;
        btnCancel.Visible = false;
        lblPasswordLine.Visible = false;
        lblPassword.Visible = false;
        lbtnLogin.Visible = false;
    }
    protected void lbtnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("LoginPage.aspx");
    }
    protected void lbtnGotoLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("LoginPage.aspx");
    }
}
