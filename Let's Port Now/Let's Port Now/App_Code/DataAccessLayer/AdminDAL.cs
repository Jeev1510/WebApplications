using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Logging;

/// <summary>
/// Summary description for AdminDAL
/// </summary>
public class AdminDAL
{
    SqlConnection con;
    public AdminDAL()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// TRAINEE:4
    /// To get ServiceProvider to Approve
    /// </summary>
    /// <returns></returns>
    public DataTable GetServiceProviderToApprove()
    {
        // This code is to get the state names from the database

        DataTable dt = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter("SELECT ServiceProviderName,ContactNumber,LicenseNumber,RegDate FROM tbl_ServiceProvider WHERE RegStatus='I'", con);

        try
        {
            adap.Fill(dt);

        }
        catch (SqlException ex)
        {

            throw ex;
        }

        // Note: DataReader implements IEnumarable interface
        return dt;
    }

    /// <summary>
    /// TRAINEE:4
    /// TO verify ServiceProvider
    /// </summary>
    /// <param name="ServiceProviderName"></param>
    /// <param name="LicenseNumber"></param>
    /// <returns></returns>
    public int VerifyServiceProvider(string ServiceProviderName, string LicenseNumber)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "ufn_VerifyServiceProvider";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ServiceProviderName", ServiceProviderName);
        cmd.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);


        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(prmReturn);

        try
        {

            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }

        return Convert.ToInt32(prmReturn.Value);
    }

    /// <summary>
    /// TRAINEE:4
    /// TO approve or Reject
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="Action"></param>
    /// <returns></returns>
    public int ApproveOrRejectServiceProvider(string ServiceProviderId, char Action)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_ApproveOrRejectServiceProvider";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderId);
        cmd.Parameters.AddWithValue("@Action", Action);


        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(prmReturn);

        try
        {

            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch (SqlException ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }

        return Convert.ToInt32(prmReturn.Value);
    }

    /// <summary>
    /// TRAINEE:4
    /// TO get ServiceProvider Id By name
    /// </summary>
    /// <param name="ServiceProviderName"></param>
    /// <returns></returns>
    public string GetServiceProviderIdByName(string ServiceProviderName)
    {
        // This code is to get the state names from the database
        string Id;
        SqlCommand command1 = new SqlCommand("SELECT ServiceProviderId FROM tbl_ServiceProvider WHERE ServiceProviderName='" + ServiceProviderName + "'", con);

        try
        {
            con.Open();
            Id = Convert.ToString(command1.ExecuteScalar());
        }
        catch (SqlException ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }


        return Id;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="radiobutton"></param>
    /// <returns></returns>
    public DataTable GetServiceProvider(string radiobutton)
    {
        SqlCommand cm;
        DataTable dt = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter();

        if (radiobutton.Equals("Service Provider"))
        {
            // This code is to get the serviceprovider names from the database
            cm = new SqlCommand("SELECT ServiceProviderName,ServiceProviderId FROM tbl_ServiceProvider WHERE ServiceProviderId=@ServiceProviderId", con);
            adap.SelectCommand = cm;
        }
        else if (radiobutton.Equals("Port Status"))
        {
            cm = new SqlCommand("SELECT PortingId,PortStatus FROM tbl_Porting WHERE DonorSpId=@DonorSpId", con);
            adap.SelectCommand = cm;
        }
        //cm.Parameters.AddWithValue("@ServiceProviderId", serviceProviderId);


        try
        {
            adap.Fill(dt);
        }
        catch (SqlException ex)
        {

            throw ex;
        }

        // Note: DataReader implements IEnumarable interface
        return dt;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfCustomersDAL
    /// This method is used calculate the number of customers registered
    /// </summary>
    /// <returns>Number of customers registered in integer value</returns>
    public int NumberOfCustomersDAL()
    {
        //declaring and initialising a variable
        int noOfCustomer = 0 ;
        //creating object for command 
        SqlCommand cmdNumberOfCustomersDAL = new SqlCommand("select count(*) from tbl_Customer", con);
        //try block
        try
        {
            //opening connection
            con.Open();
            noOfCustomer = Convert.ToInt32(cmdNumberOfCustomersDAL.ExecuteScalar());
        }
        //catch block to catch any errors
        catch (SqlException ex)
        {
            throw ex;
        }
        //closing the connection in finally block
        finally
        {
            con.Close();
        }
        //returning number of Customer
        return noOfCustomer;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfServiceProvidersDAL
    /// This method is used calculate the number of Service providers registered
    /// </summary>
    /// <returns>Number of Service Providers registered in integer value</returns>
    public int NumberOfServiceProvidersDAL()
    {
        //declaring and initialising a variable
        int noOfServiceProviders=0;
        //creating object for command 
        SqlCommand cmdNumberOfServiceProvidersDAL = new SqlCommand("select count(*) from tbl_ServiceProvider", con);
        //try block
        try
        {
            //opening connection
            con.Open();
            noOfServiceProviders = Convert.ToInt32(cmdNumberOfServiceProvidersDAL.ExecuteScalar());
        }
        //catch block to catch any errors
        catch (SqlException ex)
        {
            throw ex;
        }
        //closing the connection in finally block
        finally
        {
            con.Close();
        }
        //returning number of ServiceProviders
        return noOfServiceProviders;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfPortingRequestsRaisedDAL
    /// This method is used calculate the number of porting requests raised
    /// </summary>
    /// <returns>Number of Porting Requests Raised in integer value</returns>
    public int NumberOfPortingRequestsRaisedDAL()
    {
        //declaring and initialising a variable
        int NoOfRequestsRaised=0;
        //creating object for command 
        SqlCommand cmdNumberOfPortingRequestsRaisedDAL = new SqlCommand("select count(*) from tbl_Porting", con);
        //try block
        try
        {
            //opening connection
            con.Open();
            NoOfRequestsRaised = Convert.ToInt32(cmdNumberOfPortingRequestsRaisedDAL.ExecuteScalar());
        }
        //catch block to catch any errors
        catch (SqlException ex)
        {
            throw ex;
        }
        //closing the connection in finally block
        finally
        {
            con.Close();
        }
        //returning number of Requests Raised
        return NoOfRequestsRaised;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfPortingRequestsServedDAL
    /// This method is used calculate the number of porting requests served
    ///<returns>Number of Porting Requests Served in integer value</returns>
    public int NumberOfPortingRequestsServedDAL()
    {
        //declaring and initialising a variable
        int NoOfRequestsServed=0;
        //creating object for command 
        SqlCommand cmdNumberOfPortingRequestsServedDAL = new SqlCommand("select count(*) from tbl_Porting where PortStatus IN ('X')", con);
        //try block
        try
        {
            //opening connection
            con.Open();
            NoOfRequestsServed = Convert.ToInt32(cmdNumberOfPortingRequestsServedDAL.ExecuteScalar());
        }
        //catch block to catch any errors
        catch (SqlException ex)
        {
            throw ex;
        }
        //closing the connection in finally block
        finally
        {
            con.Close();
        }
        //returning number of Requests Served
        return NoOfRequestsServed;
    }

    /// <summary>
    ///TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfPendingServiceProvidersApprovalDAL
    /// This method is used calculate the number of pending service provider approval
    ///<returns>Number of Porting Service Provider Requests in integer value</returns>
    public int NumberOfPendingServiceProvidersApprovalDAL()
    {
        //declaring and initialising a variable
        int NoOfPendingServiceProvidersApproval=0;
        //creating object for command 
        SqlCommand cmdNumberOfPendingServiceProvidersApprovalDAL = new SqlCommand("select count(*) from tbl_ServiceProvider where RegStatus='I'", con);
        //try block
        try
        {
            //opening connection
            con.Open();
            NoOfPendingServiceProvidersApproval = Convert.ToInt32(cmdNumberOfPendingServiceProvidersApprovalDAL.ExecuteScalar());
        }
        //catch block to catch any errors
        catch (SqlException ex)
        {
            throw ex;
        }
        //closing the connection in finally block
        finally
        {
            con.Close();
        }
        //returning number of Pending ServiceProviders Approval
        return NoOfPendingServiceProvidersApproval;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:PopulatingPendingPaymentsGridviewDAL
    /// This method is used to populate the pending payments grid view
    ///<returns>DataTAble containing the pending payments</returns>
    public DataTable PopulatingPendingPaymentsGridviewDAL()
    {
        //creating a datatable object
        DataTable dtPopulatingPendingPaymentsGridviewDAL = new DataTable();
        //creating a dataadaptor object
        SqlDataAdapter dataAdaptorObj = new SqlDataAdapter("SELECT tp.PortingId,c.CustomerName,tsp.ServiceProviderName,tsp1.ServiceProviderName,PortStatus FROM tbl_Porting tp join tbl_ServiceProvider tsp on tp.DonorSpId=tsp.ServiceProviderId join tbl_ServiceProvider tsp1 on tp.RecipientSpId=tsp1.ServiceProviderId join tbl_Customer c on c.CustomerId=tp.CustomerId WHERE PortStatus IN('A','P')", con);
        //try block
        try
        {
            //filling the datatable object with dataadaptorobject value
            dataAdaptorObj.Fill(dtPopulatingPendingPaymentsGridviewDAL);
        }
        //catch block to catch any errors
        catch (SqlException ex)
        {
            throw ex;
        }
        //returning DataTAble containing the pending payments
        return dtPopulatingPendingPaymentsGridviewDAL;
    }




    /// <summary>
    /// TRAINEE:2
    /// Created on:23-Jan-2012
    /// To populate the dropdownlist with service provider names
    /// </summary>
    /// <param></param>
    /// <returns>Datatable</returns>
    public DataTable GetServicePBroviderById()
    {
        Logger.Write(" Entered into method GetServicePBroviderById");
        DataTable dtServiceProvider = new DataTable();
        //Declaration of DataAdapter object and associating with database query
        SqlDataAdapter daServiceProvider = new SqlDataAdapter("SELECT sp.ServiceProviderName,sp.ServiceProviderId FROM tbl_ServiceProvider sp INNER JOIN tbl_LicensedServiceProvider lsp ON(sp.ServiceProviderName=lsp.ServiceProviderName) WHERE ExpiryDate>GETDATE()", con);
        //try block
        try
        {
            daServiceProvider.Fill(dtServiceProvider);
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
        return dtServiceProvider;
    }


    /// <summary>
    /// TRAINEE:2
    /// Created on:23-Jan-2012
    /// To display details of selected service provider name from the dropdownlist
    /// </summary>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <param name="serviceProviderId"></param>
    /// <returns>DataTable</returns>
    public DataTable GetServiceProviderDetails(DateTime fromDate, DateTime toDate, string serviceProviderId)
    {

        DataTable dtServiceProvider = new DataTable();
        //try block
        try
        {
            //Declaration of DataReader object
            SqlDataReader drServiceProvider;
            SqlCommand cmdServiceProvider = new SqlCommand();
            cmdServiceProvider.Connection = con;
            cmdServiceProvider.CommandText = @"SELECT p.PortingId as PortingId,p.UniquePortingCode as UniquePortingCode,
                                             dsp.ServiceProviderName as Donor,rsp.ServiceProviderName as Recipient, 
                                             ApplicationDate ,ActivationDate , PortStatus  
                                             FROM tbl_Porting p INNER JOIN tbl_ServiceProvider dsp 
                                             ON p.DonorSpId=dsp.ServiceProviderId  INNER JOIN tbl_ServiceProvider rsp 
                                             ON p.RecipientSpId=rsp.ServiceProviderId 
                                             WHERE ApplicationDate BETWEEN @FromDate AND @ToDate 
                                             AND (DonorSpId=@serviceProviderId OR RecipientSpId=@serviceProviderId)";

            cmdServiceProvider.Parameters.AddWithValue("@FromDate", fromDate);
            cmdServiceProvider.Parameters.AddWithValue("@ToDate", toDate);
            cmdServiceProvider.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);

            con.Open();
            drServiceProvider = cmdServiceProvider.ExecuteReader();
            dtServiceProvider.Load(drServiceProvider);
            con.Close();
        }
        //catch block
        catch (SqlException ex)
        {
            dtServiceProvider = null;
            throw ex;
        }
        //Finally block
        finally
        {
            con.Close();
        }
        return dtServiceProvider;
    }

    /// <summary>
    /// TRAINEE:2
    /// Created on:23-Jan-2012
    /// To display details of selected port status from the dropdownlist
    /// </summary>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <param name="portStatus"></param>
    /// <returns></returns>
    public DataTable GetPortStatusDetails(DateTime fromDate, DateTime toDate, string portStatus)
    {
        //Declaration of DataTable object
        DataTable dtPortStatus = new DataTable();
        //try block
        try
        {
            //Declaration of DataReader object
            SqlDataReader drPortStatus;
            SqlCommand cmdPortStatus = new SqlCommand();
            cmdPortStatus.Connection = con;
            cmdPortStatus.CommandText = @"SELECT p.PortingId as PortingId,p.UniquePortingCode as UniquePortingCode,
                                       s.ServiceProviderName as Donor,r.ServiceProviderName as Recipient,
                                       ApplicationDate,ActivationDate,PortStatus FROM tbl_Porting p 
                                       INNER JOIN tbl_ServiceProvider s ON p.DonorSpId=s.ServiceProviderId  
                                       INNER JOIN tbl_ServiceProvider r ON p.RecipientSpId=r.ServiceProviderId 
                                       WHERE ApplicationDate BETWEEN @FromDate and @ToDate 
                                       AND PortStatus=@PortStatus";

            cmdPortStatus.Parameters.AddWithValue("@FromDate", fromDate);
            cmdPortStatus.Parameters.AddWithValue("@ToDate", toDate);
            cmdPortStatus.Parameters.AddWithValue("@PortStatus", portStatus);

            con.Open();
            drPortStatus = cmdPortStatus.ExecuteReader();
            dtPortStatus.Load(drPortStatus);
            con.Close();
        }
        //catch block
        catch (SqlException ex)
        {
            dtPortStatus = null;
            throw ex;
        }
        //finally block
        finally
        {
            con.Close();
        }
        return dtPortStatus;
    }
}
