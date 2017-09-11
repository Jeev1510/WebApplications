using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.Sql;
using System.Data;


/// <summary>
/// Summary description for LoginBL
/// </summary>
public class LoginBL
{
	//object for LoginDAL created
    LoginDAL objLoginDAL = new LoginDAL();
    public LoginBL()
	{
		//
		// TODO: Add constructor logic here
		//
        
      
	}
    /// <summary>
    /// To Get Security Question for the specific UserId 
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public string GetSecurityQuestion(string UserId)
    {
        string Sques = objLoginDAL.GetSecurityQuestion(UserId);
        return Sques;
    }
    /// <summary>
    /// TO Validate UserID
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public int ValidateUser(string UserId)
    {
        int returned = objLoginDAL.ValidateUser(UserId);
        return returned;
    }
    /// <summary>
    /// TRAINEE:8
    /// TO recover Password
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="Answer"></param>
    /// <returns></returns>
    public string RecoverPassword(string UserID, string Answer)
    {
        string pass = objLoginDAL.RecoverPassword(UserID, Answer);
        return pass;
    }
    /// <summary>
    ///TRAINEE:3
    /// Created On:22-Jan-2012
    /// This method is uset to change the Password for the Current User.This calls ChangePassword method in LoginDAL Class
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    public int ChangePassword(string userId, string currentPassword, string newPassword)
    {
        int pass = objLoginDAL.ChangePassword(userId, currentPassword, newPassword);
        return pass;
    }
    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:AuthenticateUserBL
    /// This method is used to Authenticate the userId and password of the user
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <returns>Type of user logged in as a Character value</returns>
    public char AuthenticateUserBL(string userId, string password)
    {
        char authenticateUserBL = objLoginDAL.AuthenticateUserDAL(userId, password);
        return authenticateUserBL;
    }


    public int ValidateAccount(string AccountNumber, string Password)
    {
        LoginDAL logdal= new LoginDAL();
        int ret;
        ret = logdal.ValidateAccount(AccountNumber, Password);
        return ret;
    }

    public void getAccountDetails(int AccountNumber, out double Balance)
    {
        LoginDAL logdal = new LoginDAL();
        logdal.getAccountDetails(AccountNumber, out Balance);
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:GetServiceProviderDetailsBL
    /// This method is used to get the Id and Name of the Service Provider
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Service Provider's Id and Name in a DataTable</returns>
    public DataTable GetServiceProviderDetailsBL(string userId)
    {
        //creating a datatable object
        DataTable dtGetServiceProviderDetailsBL = new DataTable();
        //creating object of LoginDAL class
        LoginDAL logdal = new LoginDAL();
        //try block
        try
        {
            //calling the GetServiceProviderDetailsDAL method
            dtGetServiceProviderDetailsBL = logdal.GetServiceProviderDetailsDAL(userId);
        }
        //catch bolck to catch any exception
        catch(Exception ex)
        {
            throw ex;
        }
        //returns Service Provider's Id and Name in a DataTable
        return dtGetServiceProviderDetailsBL;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:GetCustomerDetailsBL
    /// This method is used to get the Id and Name of the Customer
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Customer's Id and Name in a DataTable</returns>
    public DataTable GetCustomerDetailsBL(string userId)
    {
        //creating a datatable object
        DataTable dtGetCustomerDetailsBL = new DataTable();
        //creating object of LoginDAL class
        LoginDAL logdal = new LoginDAL();
        //try block
        try
        {
            //calling the GetCustomerDetailsDAL method
            dtGetCustomerDetailsBL = logdal.GetCustomerDetailsDAL(userId);
        }
        //catch bolck to catch any exception
        catch (Exception ex)
        {
            throw ex;
        }
        //returns Customer's Id and Name in a DataTable
        return dtGetCustomerDetailsBL;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:ValidateStatusBL
    /// This method is used to Validate the status of the Service Provider
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Status of the Service Provider as a Character value</returns>
    public char ValidateStatusBL(string UserId)
    {
        //declaring a variable
        char status;
        //creating object of LoginDAL class
        LoginDAL logdal = new LoginDAL();
        //try block
        try
        {//calling the ValidateStatusDAL method
            status = logdal.ValidateStatusDAL(UserId);
        }
        //catch bolck to catch any exception
        catch (Exception ex)
        {
            throw ex;
        }
        //returns Status of the Service Provider as a Character value
        return status;
    }



}
