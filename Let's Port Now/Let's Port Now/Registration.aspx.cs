using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Logging;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Admins are not Suppose to enter the page as they are assumed to be Registered before


        Logger.Write("Registration Page Loaded Successfully");

        //if user Selects to be a Service Provider
        if (rblRegister.SelectedValue == "Service Provider")
        {
            //enabling and disabling controls accordingly
            PanelCustomer.Enabled = false;
            PanelCustomer.Visible = false;
            PanelServiceProvider.Enabled = true;
            PanelServiceProvider.Visible = true;
            lblCusResult.Visible = false;
            lblResult.Visible = false;

            if (ddlSecurityQuestion.SelectedValue == "Add my own Question")
            {
                txtSecurityq.Visible = true;
            }
            else
            {
                txtSecurityq.Visible = false;
            }

        }

            //If User Selects to be a Customer
        else if (rblRegister.SelectedValue == "Customer")
        {
            //enabling and disabling controls accordingly
            PanelServiceProvider.Enabled = false;
            PanelServiceProvider.Visible = false;
            PanelCustomer.Enabled = true;
            PanelCustomer.Visible = true;

            if (ddlCusSecurityQues.SelectedValue == "Add my own Question")
            {
                txtCusSecurityQuestion.Visible = true;
            }
            else
            {
                txtCusSecurityQuestion.Visible = false;
            }

        }

    }

    protected void rblPlantype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Clearing the values to prevent auto appending
        ddlCurrentPlan.Items.Clear();
        ddlCurrentPlan.Items.Add("--Select--");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //Reseting all the values to empty fields
        txtName.Text = "";
        txtMobileNumber.Text = "";
        txtPortingCharges.Text = "";
        txtAddress.Text = "";
        txtLicenceNumber.Text = "";
        ddlSecurityQuestion.ClearSelection();
        txtSecurityAnswer.Text = "";
    }
    protected void btnResertC_Click(object sender, EventArgs e)
    {
        //Reseting all the values to empty fields
        txtCusName.Text = "";
        txtCusAdd1.Text = "";
        txtCusAdd2.Text = "";
        ddlCusState.ClearSelection();
        txtCzipcode.Text = "";
        txtMobileNumber.Text = "";
        rblPlantype.ClearSelection();
        ddlServiceProvider.ClearSelection();
        ddlCurrentPlan.ClearSelection();
        ddlCusSecurityQues.ClearSelection();
        txtCusSecurityAnswer.Text = "";
        txtCusSecurityQuestion.Text = "";

    }

    protected void btnRegisterCustomer_Click(object sender, EventArgs e)
    {
        CustomerBL custbl = new CustomerBL();
        string CustomerId;
        int ret = 5;
        lblCusResult.Visible = true;



        if (ddlCusSecurityQues.SelectedValue == "Add my own Question")
        {
            //Calling the method in Bl to register with the input values passed
            ret = custbl.RegisterCustomer(txtCusPassword.Text, 'A', txtCusSecurityQuestion.Text, txtCusSecurityAnswer.Text, txtCusName.Text, txtCusAdd1.Text, txtCusAdd2.Text, ddlCusState.SelectedValue.ToString(), (txtCzipcode.Text), (txtCusMobileNumber.Text), ddlCurrentPlan.SelectedValue.ToString(), out CustomerId);
            lblCusResult.Text = "Your Id is " + CustomerId;
            lbLogin.Visible = true;
        }


        else if (ddlCusSecurityQues.SelectedValue != "Add my own Question")
        {
            //Calling the method in Bl to register with the input values passed
            ret = custbl.RegisterCustomer(txtCusPassword.Text, 'A', ddlCusSecurityQues.SelectedValue.ToString(), txtCusSecurityAnswer.Text, txtCusName.Text, txtCusAdd1.Text, txtCusAdd2.Text, ddlCusState.SelectedValue.ToString(), (txtCzipcode.Text), (txtCusMobileNumber.Text), ddlCurrentPlan.SelectedValue.ToString(), out CustomerId);
            lbLogin.Visible = true;
            lblCusResult.Text = "Your Id is " + CustomerId;
        }

        if (ret == 0)
        {
            //Reseting the values on successfull registration

            btnRegisterCustomer.Enabled = false;
            txtCusName.Text = "";
            txtCusAdd1.Text = "";
            txtCusAdd2.Text = "";
            ddlCusState.ClearSelection();
            txtCzipcode.Text = "";
            txtCusMobileNumber.Text = "";
            rblPlantype.ClearSelection();
            ddlCurrentPlan.ClearSelection();
            ddlServiceProvider.ClearSelection();
            ddlCusSecurityQues.ClearSelection();
            txtCusSecurityQuestion.Text = "";
            txtCusSecurityAnswer.Text = "";
        }


        if (ret == -1)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblCusResult.ForeColor = System.Drawing.Color.Red;
            lblCusResult.Text = "This Mobile Number is already Registered for other user";
        }

        else if (ret == -2)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblCusResult.ForeColor = System.Drawing.Color.Red;
            lblCusResult.Text = "Incorrect PlanId";
        }
        else if (ret == -3)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblCusResult.ForeColor = System.Drawing.Color.Red;
            lblCusResult.Text = "State Your Entered Doesnot have any Subscriber";
        }
        else if (ret == -4)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblCusResult.ForeColor = System.Drawing.Color.Red;
            lblCusResult.Text = "UserId and Password are Same,Please choose another Password";
        }
        else if (ret == -5)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblCusResult.ForeColor = System.Drawing.Color.Red;
            lblCusResult.Text = "Some Other Error,Please Try Again with Valid Values";
        }

    }

    //Register the Service Provider by this Click
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        ServiceProviderBL servicebl = new ServiceProviderBL();
        string ServiceProviderId;
        int ret = 10;
        lblResult.Visible = true;

        //Calling the method in Bl to register with the input values passed
        ret = servicebl.RegisterServiceProvider(txtPassword.Text, 'S', ddlSecurityQuestion.SelectedValue.ToString(), txtSecurityAnswer.Text, txtName.Text, txtMobileNumber.Text, Convert.ToDouble(txtPortingCharges.Text), txtAddress.Text, txtLicenceNumber.Text, out ServiceProviderId);
        lblResult.Text = "Your Id is " + ServiceProviderId;
        if (ret == 0)
        {
            //Reseting the values on successfull registration
            lbLogin.Visible = true;
            btnRegister.Enabled = false;
            txtName.Text = "";
            txtMobileNumber.Text = "";
            txtPortingCharges.Text = "";
            txtAddress.Text = "";
            txtLicenceNumber.Text = "";
            ddlSecurityQuestion.ClearSelection();
            txtSecurityq.Text = "";
            txtSecurityAnswer.Text = "";
            
        }
        if (ret == -1)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Service Provider Already Registered";


            lbLogin.Visible = false;
        }

        else if (ret == -2)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Licence Verification Fails";
            lbLogin.Visible = false;
        }

        else if (ret == -3)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "UserId and Password are same,Choose some other Password";
            lbLogin.Visible = false;
        }

        else if (ret == -4)
        {
            //Warning message shown on unsuccessfull registration with corrosponding value returned
            lblResult.ForeColor = System.Drawing.Color.Red;
            lblResult.Text = "Some Other Error,Please try Again Later";
            lbLogin.Visible = false;
        }

    }


    protected void rblPlantype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //clearing the values to prevent auto append
        ddlServiceProvider.Items.Clear();
        ddlServiceProvider.Items.Add("--Select--");
        ddlCurrentPlan.Items.Clear();
        ddlCurrentPlan.Items.Add("--Select--");
    }
    protected void lbLogin_Click(object sender, EventArgs e)
    {
        //Redirecting the user to his/her login page 
        Response.Redirect("LoginPage.aspx");
    }
    protected void lbGohome_Click(object sender, EventArgs e)
    {
        Response.Redirect("LoginPage.aspx");
    }
}
