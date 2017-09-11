using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

/// <summary>
/// Summary description for AdminBL
/// </summary>
[DataObject(true)]
public class AdminBL
{
    AdminDAL aObj = new AdminDAL();
    public AdminBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// TRAINEE:4
    /// This method returns the datatable of service providers to approve by the admin
    /// </summary>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetServiceProviderToApprove()
    {
        DataTable dt;
        try
        {
            dt = aObj.GetServiceProviderToApprove();
        }
        catch (InvalidOperationException ex)
        {

            throw ex;
        }
        return dt;
    }


    /// <summary>
    /// TRAINEE:4
    /// This method is for verifying the service provider
    /// </summary>
    /// <param name="ServiceProviderName"></param>
    /// <param name="LicenseNumber"></param>
    /// <returns></returns>
    public int VerifyServiceProvider(string ServiceProviderName, string LicenseNumber)
    {
        int ret;
        try
        {
            ret = aObj.VerifyServiceProvider(ServiceProviderName, LicenseNumber);
        }
        catch (InvalidOperationException ex)
        {

            throw ex;
        }
        return ret;
    }

    /// <summary>
    /// TRAINEE:4
    /// This method is for approving or rejecting the service providers 
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="Action"></param>
    /// <returns></returns>
    public int ApproveOrRejectServiceProvider(string ServiceProviderId, char Action)
    {
        int ret;
        try
        {
            ret = aObj.ApproveOrRejectServiceProvider(ServiceProviderId, Action);
        }
        catch (InvalidOperationException ex)
        {

            throw ex;
        }
        return ret;
    }

    /// <summary>
    /// TRAINEE:4
    /// This method is for fetching the serviceproviderid giving their name
    /// </summary>
    /// <param name="ServiceProviderName"></param>
    /// <returns></returns>
    public string GetServiceProviderIdByName(string ServiceProviderName)
    {
        string id;
        try
        {
            id = aObj.GetServiceProviderIdByName(ServiceProviderName);
        }
        catch (InvalidOperationException ex)
        {

            throw ex;
        }
        return id;
    }
    /// <summary>
    /// TRAINEE
    /// </summary>
    /// <param name="radiobutton"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetServiceProvider(string radiobutton)
    {
        DataTable dt = new DataTable();
        dt = aObj.GetServiceProvider(radiobutton);
        return dt;
    }


    
    
    /// <summary> 
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// For service provider dropdownlist 
    /// </summary>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetServiceProviderById()
    {
        //try block
        try
        {
            //Declaration of DataTable object
            DataTable dtServiceProvider = new DataTable();
            dtServiceProvider = aObj.GetServicePBroviderById();
            return dtServiceProvider;
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// For service provider gridview
    /// </summary>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetServiceProviderDetails(DateTime fromDate, DateTime toDate, string serviceProviderId)
    {
        //try block
        try
        {
            //Declaration of DataTable object
            DataTable dtServiceProvider = new DataTable();
            dtServiceProvider = aObj.GetServiceProviderDetails(fromDate, toDate, serviceProviderId);
            return dtServiceProvider;
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// For portstatus gridview
    /// </summary>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <param name="portStatus"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetPortStatusDetails(DateTime fromDate, DateTime toDate, string portStatus)
    {
        DataTable dtPortStatus = new DataTable();
        //try block
        try
        {
            //Declaration of DataTable object
           
            dtPortStatus = aObj.GetPortStatusDetails(fromDate, toDate, portStatus);
          
        }
        //catch block
        catch (Exception ex)
        {
            throw ex;
        }
        return dtPortStatus;
    }



    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfCustomersBL
    /// This method is used calculate the number of customers registered
    /// </summary>
    /// <returns>Number of customers registered in integer value</returns>
    public int NumberOfCustomersBL()
       
    {   
        //declaring and initialising a variable
        int NoOfCustomers = 0;
        //try block
        try
        {
            //calling the NumberOfCustomersDAL from DAL layer
            NoOfCustomers = aObj.NumberOfCustomersDAL();
        }
        //catch block to catch any errors
        catch(Exception ex)
        {
            throw ex;
        }
        //returns Number of Customers
        return NoOfCustomers;
       
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfServiceProvidersBL
    /// This method is used calculate the number of Service providers registered
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <returns>Number of Service Providers registered in integer value</returns>
    public int NumberOfServiceProvidersBL()
    {
        //declaring and initialising a variable
        int NoOfServiceProviders = 0;
        //try block
        try
        {
            //calling the NumberOfServiceProvidersDAL from DAL layer
            NoOfServiceProviders = aObj.NumberOfServiceProvidersDAL();
        }
        //catch block to catch any errors
        catch (Exception ex)
        {
            throw ex;
        }
        //returns Number of ServiceProviders
        return NoOfServiceProviders;
    }

    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfPortingRequestsRaisedBL
    /// This method is used calculate the number of porting requests raised
    /// </summary>
    /// <returns>Number of Porting Requests Raised in integer value</returns>
    public int NumberOfPortingRequestsRaisedBL()
    { 
        //declaring and initialising a variable
        int NoOfPortingRequestsRaised = 0;
        //try block 
        try
        {
            //calling the NumberOfPortingRequestsRaisedDAL from DAL layer
            NoOfPortingRequestsRaised = aObj.NumberOfPortingRequestsRaisedDAL();
        }
        //catch block to catch any errors
        catch (Exception ex)
        {
            throw ex;
        }
        //returns Number of Porting Requests Raised
        return NoOfPortingRequestsRaised;
    }
    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfPortingRequestsServedBL
    /// This method is used calculate the number of porting requests served
    /// </summary>
    ///<returns>Number of Porting Requests Served in integer value</returns>
    public int NumberOfPortingRequestsServedBL()
    {
        //declaring and initialising a variable
        int NoOfRequestsServed = 0;
        //try block 
        try
        {
            //calling the NumberOfPortingRequestsServedDAL from DAL layer
            NoOfRequestsServed = aObj.NumberOfPortingRequestsServedDAL();
        }
        //catch block to catch any errors
        catch (Exception ex)
        {
            throw ex;
        }
        //returns Number of Porting Requests Served
        return NoOfRequestsServed;
    }
    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:NumberOfPendingServiceProvidersApprovalBL
    /// This method is used calculate the number of pending service provider approval
    /// </summary>
    ///<returns>Number of Porting Service Provider Requests in integer value</returns>
    public int NumberOfPendingServiceProvidersApprovalBL()
    {
        //declaring and initialising a variable
        int NoOfPendingServiceProvidersApproval = 0;
        //try block 
        try
        {
            //calling the NumberOfPendingServiceProvidersApprovalDAL from DAL layer
            NoOfPendingServiceProvidersApproval = aObj.NumberOfPendingServiceProvidersApprovalDAL();
        }
        //catch block to catch any errors
        catch (Exception ex)
        {
            throw ex;
        }
        //returns Number of Pending ServiceProviders' Approval
        return NoOfPendingServiceProvidersApproval;
    }
    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:PopulatingPendingPaymentsGridviewBL
    /// This method is used to populate the pending payments grid view
    /// </summary>
    ///<returns>DataTAble containing the pending payments</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable PopulatingPendingPaymentsGridviewBL()
    {
        //creating datable object
        DataTable dataTableObj = new DataTable();
        //try block 
        try
        {
            //calling the PopulatingPendingPaymentsGridviewDAL from DAL layer
            dataTableObj = aObj.PopulatingPendingPaymentsGridviewDAL();
        }
        //catch block to catch any errors
        catch (Exception ex)
        {
            throw ex;
        }
        //returns DataTAble containing the pending payments
        return dataTableObj;
    }
}
