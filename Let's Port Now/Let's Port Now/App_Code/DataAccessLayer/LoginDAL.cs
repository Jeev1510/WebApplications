using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;//adding 
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;
/// <summary>
/// Summary description for LoginDAL
/// </summary>
public class LoginDAL
{
    SqlConnection con;


    public LoginDAL()
    {
        //
        // TODO: Add constructor logic here
        //
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

    }

    /// <summary>
    /// To get security question from user for recovering password
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public string GetSecurityQuestion(string UserId)
    {
        string question = "";
        object Ques;
        //Declaration of command object 
        SqlCommand sqlcomm = new SqlCommand();
        sqlcomm.CommandType = CommandType.Text;
        sqlcomm.CommandText = "select securityquestion from tbl_login where userid=@userid;";
        sqlcomm.Connection = con;


        //adding parameter

        SqlParameter UserID = new SqlParameter();
        UserID.ParameterName = "@userid";
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Size = 6;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = UserId;
        sqlcomm.Parameters.Add(UserID);
        //try block
        try
        {
            //executing query
            con.Open();
            Ques = sqlcomm.ExecuteScalar();
            question = Ques.ToString();
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }

        return question;
    }

    /// <summary>
    /// Method for validating userID
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public int ValidateUser(string UserId)
    {
        //declaring and initialising variable
        int count = 0;
        //Declaration of command object
        SqlCommand sqlcomm = new SqlCommand();
        sqlcomm.CommandType = CommandType.Text;
        sqlcomm.CommandText = "select @Value=count(*) from tbl_login where userid=@userid;";
        sqlcomm.Connection = con;

        //adding parameters

        SqlParameter UserID = new SqlParameter();
        UserID.ParameterName = "@userid";
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Size = 6;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = UserId;

        SqlParameter Count = new SqlParameter();
        Count.ParameterName = "@Value";
        Count.SqlDbType = SqlDbType.Int;
        Count.Direction = ParameterDirection.Output;

        sqlcomm.Parameters.Add(UserID);
        sqlcomm.Parameters.Add(Count);
        //try block
        try
        {
            //executing query
            con.Open();
            sqlcomm.ExecuteNonQuery();
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }

        count = Convert.ToInt32(Count.Value);
        return count;
    }

    /// <summary>
    /// Method for recovering Password
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="Answer"></param>
    /// <returns></returns>
    public string RecoverPassword(string UserID, string Answer)
    {
        //Declaration of command object
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "ufn_RecoverPassword";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;
        //adding parameter
        SqlParameter Userid = new SqlParameter();
        Userid.ParameterName = "@userId";
        Userid.SqlDbType = SqlDbType.Char;
        Userid.Size = 5;
        Userid.Direction = ParameterDirection.Input;
        Userid.Value = UserID;

        //adding parameter
        SqlParameter ANS = new SqlParameter();
        ANS.ParameterName = "@SecurityAns";
        ANS.SqlDbType = SqlDbType.VarChar;
        ANS.Size = 20;
        ANS.Direction = ParameterDirection.Input;
        ANS.Value = Answer;

        //adding parameter
        SqlParameter returned = new SqlParameter();
        returned.ParameterName = "@Return";
        returned.SqlDbType = SqlDbType.VarChar;
        returned.Size = 20;
        returned.Direction = ParameterDirection.ReturnValue;


        cmdOne.Parameters.Add(Userid);
        cmdOne.Parameters.Add(ANS);
        cmdOne.Parameters.Add(returned);
        //try block
        try
        {
            con.Open();
            //executing query
            cmdOne.ExecuteNonQuery();
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }
        string Password = returned.Value.ToString();
        return Password;
    }
    /// <summary>
    ///  TRAINEE:3
    /// Created On:22-Jan-2012
    /// This method is uset to change the Password for the Current User
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns>Integer Value</returns>
    public int ChangePassword(string userId, string currentPassword, string newPassword)
    {
        //Declaration of command object
        SqlCommand cmdPwd = new SqlCommand();
        cmdPwd.CommandText = "usp_ChangePassword";
        cmdPwd.CommandType = CommandType.StoredProcedure;
        cmdPwd.Connection = con;
        cmdPwd.Parameters.AddWithValue("@UserId", userId);
        cmdPwd.Parameters.AddWithValue("@CurrentPassword", currentPassword);
        cmdPwd.Parameters.AddWithValue("@NewPassword", newPassword);
        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;
        cmdPwd.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            cmdPwd.ExecuteNonQuery();
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }

        return Convert.ToInt32(prmReturn.Value);
    }



    /// <summary>
    ///  TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:AuthenticateUserDAL
    /// This method is used to Authenticate the userId and password of the user
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <returns>Type of user logged in as a Character value</returns>
    public char AuthenticateUserDAL(string userId, string password)
    {
        //Declaration of command object
        SqlCommand cmdAuthenticateUserDAL = new SqlCommand();
        cmdAuthenticateUserDAL.CommandText = "ufn_AuthenticateUser";
        cmdAuthenticateUserDAL.Connection = con;
        cmdAuthenticateUserDAL.CommandType = CommandType.StoredProcedure;
        cmdAuthenticateUserDAL.Parameters.AddWithValue("@UserId", userId);
        cmdAuthenticateUserDAL.Parameters.AddWithValue("@Password", password);
        //adding parameters
        SqlParameter prmReturnValue = new SqlParameter();
        prmReturnValue.Direction = ParameterDirection.ReturnValue;
        cmdAuthenticateUserDAL.Parameters.Add(prmReturnValue);
        //try block
        try
        {
            con.Open();
            cmdAuthenticateUserDAL.ExecuteNonQuery();
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }
        return Convert.ToChar(prmReturnValue.Value);
    }


    /// <summary>
    ///  TRAINEE:7
    /// Date:23/1/2012
    /// Method Name:ValidateAccount
    /// This method is used to Authenticate the account
    /// </summary>
    /// <param name="AccountNumber"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public int ValidateAccount(string AccountNumber, string Password)
    {
        //Declaration of command oject
        SqlCommand cmdPwd = new SqlCommand();
        cmdPwd.CommandText = "ufn_VerifyAccount";
        cmdPwd.CommandType = CommandType.StoredProcedure;
        cmdPwd.Connection = con;
        cmdPwd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
        cmdPwd.Parameters.AddWithValue("@Password", Password);
        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;
        cmdPwd.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            cmdPwd.ExecuteNonQuery();
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }

        return Convert.ToInt16(prmReturn.Value);
    }


    /// <summary>
    /// Method to get account details
    /// </summary>
    /// <param name="AccountNumber"></param>
    /// <param name="Balance"></param>
    public void getAccountDetails(int AccountNumber, out double Balance)
    {
        //Declaration of command object
        SqlCommand sqlcomm = new SqlCommand("Select @Balance=Balance from tbl_AccountDetails where AccountNumber=" + AccountNumber, con);
        sqlcomm.CommandType = CommandType.Text;

        //adding parameters
        SqlParameter UserID = new SqlParameter();
        UserID.ParameterName = "@AccountNumber";
        UserID.SqlDbType = SqlDbType.SmallInt;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = AccountNumber;
        //adding parameters
        SqlParameter bal = new SqlParameter();
        bal.ParameterName = "@Balance";
        bal.SqlDbType = SqlDbType.SmallMoney;
        bal.Direction = ParameterDirection.Output;

        //sqlcomm.Parameters.Add(UserID);
        sqlcomm.Parameters.Add(bal);
        //try block
        try
        {
            con.Open();
            sqlcomm.ExecuteNonQuery();
        }
        //catch block
        catch (Exception)
        {

        }
        //finally block
        finally
        {
            con.Close();
        }

        Balance = Convert.ToDouble(bal.Value);

    }


    //public string GetCustomerDetails(string userId)
    //{
    //    SqlCommand cmdCustomer = new SqlCommand("select @customerName=CustomerName,@customerId=CustomerId from tbl_Customer where userId=@UserId", con);
    //    cmdCustomer.Parameters.AddWithValue("@UserId",userId);
    //    SqlParameter prmCustomerId = new SqlParameter();
    //    prmCustomerId.ParameterName="@customerId";
    //    prmCustomerId.Direction = ParameterDirection.Output;
    //    prmCustomerId.SqlDbType = SqlDbType.Char;
    //    prmCustomerId.Size = 5;

    //    SqlParameter prmCustomerName = new SqlParameter();
    //    prmCustomerId.ParameterName = "@customerName";
    //    prmCustomerId.Direction = ParameterDirection.Output;
    //    prmCustomerId.SqlDbType = SqlDbType.VarChar;
    //    prmCustomerId.Size = 25;
    //}


    /// <summary>
    ///  TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:GetServiceProviderDetailsDAL
    /// This method is used to get the Id and Name of the Service Provider
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Service Provider's Id and Name in a DataTable</returns>
    public DataTable GetServiceProviderDetailsDAL(string userId)
    {
        //creation of datatable object
        DataTable dtGetServiceProviderDetailsDAL = new DataTable();
        //creation of command object
        SqlCommand cmdGetServiceProviderDetailsDAL = new SqlCommand("SELECT ServiceProviderId,ServiceProviderName FROM tbl_ServiceProvider WHERE UserId=@userId", con);
        cmdGetServiceProviderDetailsDAL.Parameters.AddWithValue("@userId", userId);
        //try block
        try
        {
            //opening the connection
            con.Open();
            //creating a datareader object
            SqlDataReader drGetServiceProviderDetails = cmdGetServiceProviderDetailsDAL.ExecuteReader();
            //loading the table into datareader object
            dtGetServiceProviderDetailsDAL.Load(drGetServiceProviderDetails);
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block to close the connection
        finally
        {
            con.Close();
        }
        //returns Service Provider's Id and Name in a DataTable
        return dtGetServiceProviderDetailsDAL;
    }


    /// <summary>
    ///  TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:GetCustomerDetailsDAL
    /// This method is used to get the Id and Name of the Customer
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Customer's Id and Name in a DataTable</returns>
    public DataTable GetCustomerDetailsDAL(string userId)
    {
        //creation of datatable object
        DataTable dtGetCustomerDetailsDAL = new DataTable();
        //creation of command object
        SqlCommand cmdGetCustomerDetailsDAL = new SqlCommand("SELECT CustomerId,CustomerName FROM tbl_Customer WHERE UserId=@userId", con);
        //creation of command object
        cmdGetCustomerDetailsDAL.Parameters.AddWithValue("@userId", userId);
        //try block
        try
        {
            //opening the connection
            con.Open();
            //creating datareader object
            SqlDataReader readerObj = cmdGetCustomerDetailsDAL.ExecuteReader();
            //loading datatable into reader objact
            dtGetCustomerDetailsDAL.Load(readerObj);
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        //finally block to close the connection
        finally
        {
            con.Close();
        }
        //returns Customer's Id and Name in a DataTable
        return dtGetCustomerDetailsDAL;
    }

    /// <summary>
    ///  TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:ValidateStatusDAL
    /// This method is used to Validate the status of the Service Provider
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Status of the Service Provider as a Character value</returns>
    public char ValidateStatusDAL(string UserId)
    {
        //Declaring variable
        char returnStatusDAL;
        //Creation of command object
        SqlCommand cmdValidateStatusDAL = new SqlCommand(@"Select RegStatus from tbl_ServiceProvider where UserId =@UserId", con);
        cmdValidateStatusDAL.CommandType = CommandType.Text;
        //adding parameter to command object
        cmdValidateStatusDAL.Parameters.AddWithValue("@UserId", UserId);
        //try block
        try
        {
            con.Open();
            returnStatusDAL = Convert.ToChar(cmdValidateStatusDAL.ExecuteScalar());
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        //finally block to close the connection
        finally
        {
            con.Close();
        }
        //returns Status of the Service Provider as a Character value
        return returnStatusDAL;
    }

}

