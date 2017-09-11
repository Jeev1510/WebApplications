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
/// Summary description for CommonDAL
/// </summary>
public class CommonDAL
{
    //Declaring connection object
    SqlConnection con;
    public CommonDAL()
    {
        //CONSTRUCTOR OF COMMONDAL
        // TODO: Add constructor logic here
        //
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
    }

    /// <summary>
    /// Method to get the role of logged user
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public char GetRole(string UserId)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand("SELECT @Role=Role FROM tbl_Login WHERE UserId='" + UserId + "'", con);
        cmd.CommandType = CommandType.Text;
        //adding parameters
        SqlParameter param = new SqlParameter("@Role", SqlDbType.VarChar);
        param.Size = 5;
        param.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param);
        //try block
        try
        {
            con.Open();
            cmd.ExecuteScalar();
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }
        char role = Convert.ToChar(param.Value);
        return role;
    }


    /// <summary>
    /// Method to Get States from Database
    /// </summary>
    /// <returns>DataTable</returns>

    public DataTable GetStates()
    {
        //Declaration of datatable object
        DataTable dt = new DataTable();
        //Declaration of command object
        SqlCommand cmd = new SqlCommand("Select State from tbl_LetsPortNowFee", con);
        //Declaration of dataadapter object
        SqlDataAdapter sqladap = new SqlDataAdapter();
        sqladap.SelectCommand = cmd;
        //try block
        try
        {
            sqladap.Fill(dt);
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        return dt;
    }

    /// <summary>
    /// Method to get all Postpaid Plans
    /// </summary>
    /// <returns>DataTable</returns>
    public DataTable GetPostPaidPlans(string servicePid)
    {
        //Declaration of datatable object
        DataTable dt = new DataTable();
        //Declaration of command object
        SqlCommand cmd = new SqlCommand("Select Planname,Planid from tbl_postpaidplans where ServiceProviderId=@ServiceId", con);
        cmd.Parameters.AddWithValue("@ServiceId", servicePid);
        //Declaration of dataadapter object
        SqlDataAdapter sqladap = new SqlDataAdapter();
        sqladap.SelectCommand = cmd;
        //try block
        try
        {
            sqladap.Fill(dt);
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        return dt;
    }


    /// <summary>
    /// Method to get details of service provider from database
    /// </summary>
    /// <returns></returns>
    public DataTable GetServiceProvider()
    {
        //Declaration of datatable object
        DataTable dtServiceprovider = new DataTable();
        //Declaration of command object 
        SqlCommand cmdEmp = new SqlCommand("Select * from tbl_ServiceProvider", con);
        //Declaration of dataadapter object
        SqlDataAdapter daEmp = new SqlDataAdapter();
        daEmp.SelectCommand = cmdEmp;
        //try block
        try
        {
            daEmp.Fill(dtServiceprovider);
        }
        //catch block
        catch (SqlException ex)
        {
            dtServiceprovider = null;
            Console.WriteLine(ex.Message);
        }
        return dtServiceprovider;
    }


    /// <summary>
    /// Method to get details about offers from database
    /// </summary>
    /// <returns></returns>
    public DataTable GetOffers()
    {
        //try block
        try
        {
            //Declaration of datatable object
            DataTable dt = new DataTable();
            //Declaration of dataadapter object 
            SqlDataAdapter adap = new SqlDataAdapter("select * from tbl_Offers", con);
            adap.Fill(dt);
            return dt;
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method to get all prepaid plans
    /// </summary>
    /// <returns>datatable</returns>
    public DataTable GetPrepaidPlan(string spid)
    {
        //Declaration of datatable object
        DataTable dtObj = new DataTable();
        //Declaration of command object
        SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_PrepaidPlans where ServiceProviderId=@ID", con);
        //Declaration of dataadapter object
        SqlDataAdapter adapObj = new SqlDataAdapter();
        //adding parameters
        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@ID";
        pid.SqlDbType = SqlDbType.VarChar;
        pid.Size = 20;
        pid.Direction = ParameterDirection.Input;
        pid.Value = spid;
        cmd.Parameters.Add(pid);
        //try block
        try
        {
            adapObj.SelectCommand = cmd;
            adapObj.Fill(dtObj);
        }
        //catch block
        catch (SqlException ex)
        {
            dtObj = null;
            throw ex;
        }
        //catch block
        catch (FormatException ex)
        {
            dtObj = null;
            throw ex;
        }
        //catch block
        catch (Exception ex)
        {
            dtObj = null;
            throw ex;
        }
        return dtObj;
    }

    ///// <summary>
    ///// Method to get all inactiveplans 
    ///// </summary>
    ///// <returns></returns>
    //public DataTable GetInactivePrepaidPlan()
    //{
    //    DataTable dtObj = new DataTable();
    //    SqlDataAdapter adapObj = new SqlDataAdapter("SELECT * FROM tbl_PrepaidPlans where Status='I'", con);
    //    try
    //    {
    //        adapObj.Fill(dtObj);
    //    }
    //    catch (SqlException ex)
    //    {
    //        dtObj = null;
    //        throw ex;
    //    }
    //    catch (FormatException ex)
    //    {
    //        dtObj = null;
    //        throw ex;
    //    }
    //    catch (Exception ex)
    //    {
    //        dtObj = null;
    //        throw ex;
    //    }
    //    return dtObj;
    //}
    ///// <summary>
    ///// trainee-6
    ///// this method is used to get all active prepaid plans
    ///// </summary>
    ///// <returns></returns>
    //public DataTable GetActivePrepaidPlan()
    //{
    //    DataTable dtObj = new DataTable();
    //    SqlDataAdapter adapObj = new SqlDataAdapter("SELECT * FROM tbl_PrepaidPlans where Status='A'", con);
    //    try
    //    {
    //        adapObj.Fill(dtObj);
    //    }
    //    catch (SqlException ex)
    //    {
    //        dtObj = null;
    //        throw ex;
    //    }
    //    catch (FormatException ex)
    //    {
    //        dtObj = null;
    //        throw ex;
    //    }
    //    catch (Exception ex)
    //    {
    //        dtObj = null;
    //        throw ex;
    //    }
    //    return dtObj;
    //}

    /// <summary>
    /// TRAINEE:7
    /// Method used to make transaction
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="AccountNumber"></param>
    /// <param name="Password"></param>
    /// <param name="PortingId"></param>
    /// <param name="Amount"></param>
    /// <param name="Role"></param>
    /// <param name="Comments"></param>
    /// <param name="TransactionId"></param>
    /// <returns></returns>
    public int MakePayment(string UserId, int AccountNumber, string Password, string PortingId, double Amount, string Role, string Comments, out string TransactionId)
    {
        //Declaring variable
        int ReturnValue = 0;
        //Declaration of command object
        SqlCommand cmd = new SqlCommand("usp_MakeTransaction");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@UserId", UserId);
        cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
        cmd.Parameters.AddWithValue("@Password", Password);
        cmd.Parameters.AddWithValue("@PortingId", PortingId);
        cmd.Parameters.AddWithValue("@Amount", Amount);
        cmd.Parameters.AddWithValue("@Role", Role);
        cmd.Parameters.AddWithValue("@PaymentComments", Comments);
        //adding parameters
        SqlParameter param1 = new SqlParameter("@ReturnValue", SqlDbType.Int);
        param1.Direction = ParameterDirection.ReturnValue;
        SqlParameter param2 = new SqlParameter("@TransactionId", SqlDbType.VarChar, 5);
        param2.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        //try block
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }
        TransactionId = Convert.ToString(param2.Value);
        ReturnValue = Convert.ToInt32(param1.Value);
        return ReturnValue;
    }

    /// <summary>
    /// Method used to calculate amount
    /// </summary>
    /// <param name="PortingId"></param>
    /// <param name="Role"></param>
    /// <returns></returns>
    public double CalculateAmount(string PortingId, char Role)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand("ufn_CalculatePaymentAmount");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;
        //adding parameters
        SqlParameter Port = new SqlParameter();
        Port.ParameterName = "@PortingId";
        Port.SqlDbType = SqlDbType.VarChar;
        Port.Size = 5;
        Port.Direction = ParameterDirection.Input;
        Port.Value = PortingId;
        //adding parameters
        SqlParameter rol = new SqlParameter();
        rol.ParameterName = "@Role";
        rol.SqlDbType = SqlDbType.Char;
        rol.Size = 1;
        rol.Direction = ParameterDirection.Input;
        rol.Value = Role;
        //adding parameters
        SqlParameter amount = new SqlParameter();
        amount.ParameterName = "@Amount";
        amount.SqlDbType = SqlDbType.SmallMoney;
        amount.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(Port);
        cmd.Parameters.Add(rol);
        cmd.Parameters.Add(amount);
        //try block
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }
        return Convert.ToDouble(amount.Value);
    }


    /// <summary>
    /// Method used to get status of all the selected plans
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPostpaidStatus(string Status)
    {
        //Declaration of dataadapter object
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE Status='" + Status + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status", con);
        //Declaration of datatable object
        DataTable dtObj = new DataTable();
        //try block
        try
        {
            daObj.Fill(dtObj);
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }

    /// <summary>
    /// Method to get status of prepaid plans
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPrepaidStatus(string Status)
    {
        //Declaration of dataadapter object
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE Status='" + Status + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ", con);
        //Declaration of datatable object
        DataTable dtObj = new DataTable();
        //try block
        try
        {
            daObj.Fill(dtObj);
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }
}










