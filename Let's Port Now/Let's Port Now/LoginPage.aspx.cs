//Declaring Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.Sql;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;


public partial class LoginPage : System.Web.UI.Page
{

    //method used during the page load
    protected void Page_Load(object sender, EventArgs e)
    {
        //making visibility of label to false
        lblStatus.Visible = false;
    }
    //method used to validate thge click of  Forgot Password link button
    protected void lnkBtnForgotPassword_Click(object sender, EventArgs e)
    {
        //redirecting to ForgotPassword page
        Response.Redirect("ForgotPassword.aspx");
    }
    //method used to validate thge click of  New User link button
    protected void lnkBtnNewUser_Click(object sender, EventArgs e)
    {
        //redirecting to Registration page
        Response.Redirect("Registration.aspx");
    }
    
    protected void txtUserId_TextChanged(object sender, EventArgs e)
    {

    }
    //method used to validate thge click of  Login button
    protected void btnLogin_Click1(object sender, EventArgs e)
    {
        //cresting object of LoginBL class
        LoginBL objLoginBL = new LoginBL();
        //declaring a variable
        char status;
        //try block
        try
        {
            //calling the ValidateStatusBL method
            status = objLoginBL.ValidateStatusBL(txtUserId.Text);
            //calling the AuthenticateUserBL method 
            char authenticateUser = objLoginBL.AuthenticateUserBL(txtUserId.Text.ToString(), txtPassword.Text.ToString());
            //if else block to redirect the user to the corresponding page
            if (authenticateUser == 'A')
            {
                //creating session variables
                Session["Role"] = authenticateUser.ToString();
                Session["UserId"] = txtUserId.Text;
                //redirecting to AdminHome page
                Response.Redirect("AdminHome.aspx");


            }
            else if (authenticateUser == 'S')
            {
                if (status == 'A')
                {
                    //creating datatable object
                    DataTable dataTableServiceProvider = new DataTable();
                    //creating session variables
                    Session["Role"] = authenticateUser.ToString();
                    Session["UserId"] = txtUserId.Text;
                    //calling the GetServiceProviderDetailsBL method
                    dataTableServiceProvider = objLoginBL.GetServiceProviderDetailsBL(Session["UserId"].ToString());
                    //creating seession variables
                    Session["ServiceproviderId"] = dataTableServiceProvider.Rows[0][0].ToString();
                    Session["ServiceProviderName"] = dataTableServiceProvider.Rows[0][1].ToString();
                    //redirecting to ServiceProviderHome page
                    Response.Redirect("ServiceProviderHome.aspx");

                }
                if (status == 'I')
                {
                    //editing the functionality of the label
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Sorry!Service Provider is Currently Inactive";
                }
                else
                {
                    //editing the functionality of the label
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Sorry!Service Provider Rejected";
                }

            }
            else if (authenticateUser == 'C')
            {
                //creating datatable object
                DataTable dataTableCustomer = new DataTable();
                //creating session variables
                Session["Role"] = authenticateUser.ToString();
                Session["UserId"] = txtUserId.Text;
                //calling the GetCustomerDetailsBL method 
                dataTableCustomer = objLoginBL.GetCustomerDetailsBL(Session["UserId"].ToString());
                //creating session variables
                Session["CustomerId"] = dataTableCustomer.Rows[0][0].ToString();
                Session["CustomerName"] = dataTableCustomer.Rows[0][1].ToString();
                //redirecting to CustomerHome page
                Response.Redirect("CustomerHome.aspx");

            }
            else
            {//editing the functionality of the label
                lblStatus.Visible = true;
                Session["Role"] = 'N';
                lblStatus.Text = "Please enter the valid credentials";

            }
           
       
        }
        //catch block 
        catch (InvalidOperationException)
        {
            //redirecting to error page
            Logger.Write("Error in LoginPage");
            Response.Redirect("Error.aspx");
       
           
        }
    }
    //method to validate click of Reset button
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //editing the functionality of the label
        txtUserId.Text = string.Empty;
        txtPassword.Text = string.Empty;
        //removing all the sessions 
        Session.RemoveAll();
    }


   
}

