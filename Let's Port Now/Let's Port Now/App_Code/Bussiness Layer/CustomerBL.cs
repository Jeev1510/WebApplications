using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Collections;

/// <summary>
/// Summary description for CustomerBL
/// </summary>
/// 
[DataObject(true)]
public class CustomerBL
{
    //Object for customer DAL class
    CustomerDAL custdal = new CustomerDAL();
    DataTable custDt = new DataTable();

    public CustomerBL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    /// <summary>
    /// TRAINEE:3
    ///Created On:20-Jan-2012
    ///To get the customer details.This method calls GetCustomerDetails in CustomerDAL Class
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetCustomerDetails(string userId)
    {
        custDt = custdal.GetCustomerDetails(userId);
        return custDt;
    }

    /// <summary>
    /// trainee-6
    /// to get details of prepaid plan
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetPrepaidPlanDetails(string ServiceProviderId, string state)
    {
        try
        {
            custDt = custdal.GetPrepaidPlanDetails(ServiceProviderId, state);
        }
        catch (Exception)
        {

            throw;
        }
        return custDt;
    }
    /// <summary>
    /// trainee-6
    /// to get details of postpaid plan
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="state"></param>
    /// <returns>datatable</returns>

    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetPostpaidPlanDetails(string ServiceProviderId, string state)
    {
        try
        {
            custDt = custdal.GetPostpaidPlanDetails(ServiceProviderId, state);
        }
        catch (Exception)
        {

            throw;
        }
        return custDt;
    }
    /// <summary>
    /// trainee-6
    ///  to get details of offer
    /// </summary>
    /// <param name="State"></param>
    /// <param name="ServiceProviderId"></param>
    /// <returns>datatable</returns>

    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetOfferDetails(string State, string ServiceProviderId)
    {
        try
        {

            custDt = custdal.GetOfferDetails(ServiceProviderId, State);
        }
        catch (Exception)
        {

            throw;
        }
        return custDt;
    }

    /// <summary>
    ///TRAINEE :7
    ///Created On:20-Jan-2012
    ///To get the customer details.This method calls RegisterCustomer in CustomerDAL Class
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Int</returns>
    public int RegisterCustomer(string Password, char Role, string SecurityQuestion, string SecurityAnswer, string CustomerName, string AddressLine1, string AddressLine2, string State, string ZipCode, string MobileNumber, string CurrentPlanId, out string CustomerId)
    {
        int ret;
        ret = custdal.RegisterCustomer(Password, Role, SecurityQuestion, SecurityAnswer, CustomerName, AddressLine1, AddressLine2, State, ZipCode, MobileNumber, CurrentPlanId, out CustomerId);
        return ret;

    }

    /// <summary>
    /// TRAINEE:3
    ///Created on:20-Jan-2012
    ///TO Update the Customer Details.This method calls UpdateCustomerDetails method in CustomerDAL Class
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="newCustomerName"></param>
    /// <param name="newAddressLine1"></param>
    /// <param name="newAddressLine2"></param>
    /// <param name="zipCode"></param>
    /// <returns></returns>
    public int UpdateCustomerDetails(string customerId, string newCustomerName, string newAddressLine1, string newAddressLine2, string zipCode)
    {
        int ret = custdal.UpdateCustomerDetails(customerId, newCustomerName, newAddressLine1, newAddressLine2, zipCode);
        return ret;
    }

    /// <summary>
    /// TRAINEE:4
    /// TO give feedback in CustomerHome Page
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <param name="ServiceProviderId"></param>
    /// <param name="Comments"></param>
    /// <returns></returns>
    public int GiveFeedback(string CustomerId, string ServiceProviderId, string Comments)
    {
        int ret = custdal.GiveFeedback(CustomerId, ServiceProviderId, Comments);
        return ret;
    }


    /// <summary>
    /// TRAINEE:3
    ///Created on:20-Jan-2012
    ///To get the Current ServiceProvider.This method calls CurrentServiceProvider method in CustomerDAL Class
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>

    public string CurrentServiceProvider(string userId)
    {
        string ret = custdal.CurrentServiceProvider(userId);
        return ret;
    }


    /// <summary>
    /// TRAINEE:3
    /// Created On:21-Jan-2012
    /// TO get the Current Plan in a label when the Page is loaded.This method calls CurrentPlan method in CustomerDAL Class
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public string CurrentPlan(string userId)
    {
        string ret = custdal.CurrentPlan(userId);
        return ret;
    }

    /// <summary>
    /// TRAINEE:3
    /// Created On:21-Jan-2012
    /// To populate the data table with the Last Porting Details.This method calls GetLastPortingDetails method in CustomerDAL Class 
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetLastPortingDetails(string CustomerId)
    {
        custDt = custdal.GetLastPortingDetails(CustomerId);
        return custDt;
    }

    /// <summary>
    /// TRAINEE:3
    /// To Populate data table with Pending Payments
    /// </summary>
    /// <param name="customerId"></param>
   /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable PendingPayments(string customerId)
    {
        custDt = custdal.PendingPayments(customerId);
        return custDt;
    }


    //Here start the methods for Compare Plans Page

    /// <summary>
    /// TRAINEE:5
    /// Created On: 21-Jan-2012
    ///ComparePlansPage1- Method to populate the CheckBoxList with ServiceProviderNames based on selected Plan type
    /// </summary>
    /// <param name="PlanType"></param>
    /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetServiceProviderList(string planType)
    {
        try
        {

            DataTable dtServiceProviders = new DataTable();
            dtServiceProviders = custdal.GetServiceProviderList(planType);
            return dtServiceProviders;

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    /// <summary>
    /// TRAINEE:5
    /// Created On: 21-Jan-2012
    /// ComparePlansPage2-Method to populate the Plan1 and Plan2 DropDownLists with PlanNames according to Plan type and
    ///ServiceProviderNames selected by user
    /// </summary>
    /// <param name="planType"></param>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable PopulatePlansddl(string planType, string serviceProviderId)
    {
        DataTable dtPlans = new DataTable();
        try
        {
            dtPlans = custdal.PopulatePlansddl(planType, serviceProviderId);
            return dtPlans;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


    /// <summary>
    /// TRAINEE:5
    /// Created On: 21-Jan-2012
    /// ComparePlansPage3-Method to populate the Comparison Grid with PlanDetails according to Plan type,ServiceProviderNames
    /// and plans selected by user
    /// </summary>
    /// <param name="planType"></param>
    /// <param name="serviceProviderId"></param>
    /// <param name="PlanId"></param>
    /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetComparisonGrid(string planType, string planId1, string planId2)
    {

        DataTable dtComparisonGrid = new DataTable();
        try
        {

            dtComparisonGrid = custdal.GetComparisonGrid(planType, planId1, planId2);
            return dtComparisonGrid;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }



    /// <summary>
    /// trainee-6
    /// to check for online porting request
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="upc"></param>
    /// <returns></returns>
    public int CheckUpcRequestOfCustomer(string customerId, string upc)
    {
        CustomerDAL custDalObj = new CustomerDAL();
        try
        {
            int ret = custDalObj.CheckUpcRequestOfCustomer(customerId, upc);
            return ret;
        }
        catch (Exception)
        {

            throw;
        }

    }
    /// <summary>
    /// trainee-6
    /// to get all customer details according to userid
    /// </summary>
    /// <param name="cutomerId"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetAllCustomerDetails(string cutomerId)
    {
        CustomerDAL custDalObj = new CustomerDAL();
        DataTable dtObj = new DataTable();
        try
        {
            dtObj = custDalObj.GetAllCustomerDetails(cutomerId);
            return dtObj;
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// trainee-6
    /// to get spname and cpname
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public DataTable GetSPNameAndCurrentPlanNameForCustomer(string customerId)
    {
        CustomerDAL custDalObj = new CustomerDAL();
        DataTable dtObj = new DataTable();
        try
        {
            dtObj = custDalObj.GetSPNameAndCurrentPlanNameForCustomer(customerId);
            return dtObj;
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// trainee-6
    /// to get customerdetails for customers have no upc
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="upc"></param>
    /// <param name="serviceProviderName"></param>
    /// <param name="planName"></param>
    /// <param name="planType"></param>
    public void GetCustomerDetailsForNotUPC(string customerId, string upc, out string serviceProviderName, out string planName, out string planType)
    {
        CustomerDAL custDalObj = new CustomerDAL();
        try
        {
            custDalObj.GetCustomerDetailsForNotUPC(customerId, upc, out serviceProviderName, out planName, out planType);
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// trainee-6
    /// to add new porting request
    /// </summary>
    /// <param name="uniquePortingCode"></param>
    /// <param name="customerId"></param>
    /// <param name="donorSpId"></param>
    /// <param name="RecipientSpId"></param>
    /// <param name="planId"></param>
    /// <param name="reason"></param>
    /// <param name="portingId"></param>
    /// <returns></returns>
    public int AddPortingRequest(string uniquePortingCode, string customerId, string donorSpId, string RecipientSpId, string planId, String reason, out string portingId)
    {
        CustomerDAL custDalObj = new CustomerDAL();
        try
        {
            return (custDalObj.AddPortingRequest(uniquePortingCode, customerId, donorSpId, RecipientSpId, planId, reason, out portingId));
        }
        catch (Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// trainee-6
    /// to get all plans according to ServiceProviderId,state,planType
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="state"></param>
    /// <param name="planType"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable AvailableAllPlans(string ServiceProviderId, string state, string planType)
    {
        CustomerDAL custDalObj = new CustomerDAL();
        DataTable dtObj = new DataTable();
        try
        {
            dtObj = custDalObj.AvailableAllPlans(ServiceProviderId, state, planType);
            return dtObj;
        }
        catch (Exception)
        {

            throw;
        }
    }


    //Here start the methods for Compare Plans Page
    //ComparePlansPage1
    /// <summary>
    /// Method to populate the CheckBoxList with ServiceProviderNames based on selected Plan type
    /// </summary>
    /// <param name="PlanType"></param>
    /// <returns></returns>
    //public DataTable GetServiceProviderList(string planType)
    //{
    //    try{

    //            DataTable dtServiceProviders = new DataTable();
    //            dtServiceProviders = custdal.GetServiceProviderList(planType);
    //            return dtServiceProviders;
    //        }

    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}

    /// <summary>
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// To get the porting details 
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetPortingDetails(string customerId)
    {
        //try block
        try
        {
            //Declaration of DataTable object
            DataTable dtPort = custdal.GetPortingDetails(customerId);
            return dtPort;
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
    /// To get the porting details by portingId
    /// </summary>
    /// <param name="PortingId"></param>
    /// <returns></returns>
    public DataTable GetPortingDetailsByPortingId(string portingId)
    {
        //try block
        try
        {
            //Declaration of DataTable object
            DataTable dtPorting = custdal.GetPortingDetailsByPortingId(portingId);
            return dtPorting;
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
    /// To update the porting status
    /// </summary>
    /// <param name="PortingId"></param>
    /// <param name="Role"></param>
    /// <param name="Activity"></param>
    /// <param name="Comments"></param>
    /// <returns></returns>
    public int UpdatePortingStatus(string portingId, string role, string activity, string comments)
    {
        //try block
        try
        {
            int ret = custdal.UpdatePortingStatus(portingId, role, activity, comments);
            return ret;
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
    /// To generate new UPC
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <param name="UniquePortingCode"></param>
    /// <returns></returns>
    public int GenerateUpc(string customerId, out string uniquePortingCode)
    {
        int ret = custdal.GenerateUpc(customerId, out  uniquePortingCode);
        return ret;
    }
}

