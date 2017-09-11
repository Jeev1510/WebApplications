using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ServiceProviderBL
/// </summary>
 [DataObject(true)]
public class ServiceProviderBL
{
    //This is an object of ServiceProviderDAL
    ServiceProviderDAL spObj = new ServiceProviderDAL();
	public ServiceProviderBL()
	{
		//
		// TODO: Add constructor logic here
		//
	} 
  
  /// <summary>
  /// TRAINEE:5
  /// To get the Customer Details
  /// </summary>
  /// <param name="serviceProviderId"></param>
  /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
     public int GetNoOfCustomersPortedTo(string serviceProviderId)
    {
        int NoOfCustomersPortedTo=0;
        try
        {
            NoOfCustomersPortedTo = spObj.GetNoOfCustomersPortedTo(serviceProviderId);
            
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return NoOfCustomersPortedTo;
    }


    
    /// <summary>
    /// TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage2-Method to get the number of Customers ported away from the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
     public int GetNoOfCustomersPortedOut(string serviceProviderId)
    {
        int NoOfCustomersPortedOut = 0;
        try
        {
             NoOfCustomersPortedOut = spObj.GetNoOfCustomersPortedOut(serviceProviderId);
            
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
        }
        return NoOfCustomersPortedOut;
    }


    /// <summary>
    /// TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the two recent feedbacks for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns>DataTable</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]  
     public DataTable GetFeedback(string serviceProviderId)
    {
        DataTable dtFeedback = new DataTable();

        try
        {
            dtFeedback = spObj.GetFeedback(serviceProviderId);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
        return dtFeedback;
    }


    /// <summary>
     /// TRAINEE:5
     /// Created On: 19-Jan-2012
    /// SpHomepage4-Method to get the Pending Payment Details for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
     /// <returns>DataTable</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPendingPaymentDetails(string serviceProviderId)
       {
           DataTable dtPendingPayments = new DataTable();
           try
           {
               dtPendingPayments = spObj.GetPendingPaymentDetails(serviceProviderId);
           }
           catch (Exception ex)
           {
               Console.Write(ex.Message);
           }
           return dtPendingPayments;
       }


     /// <summary>
     /// TRAINEE:5
     /// Created On: 19-Jan-2012
     /// SpHomepage5-Method to get Most Popular Prepaid Plan for the logged in service provider
     /// </summary>
     /// <param name="serviceProviderId"></param>
     /// <returns>DataTable</returns>
      [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetMostPopularPrepaidPlan(string serviceProviderId)
     {
         try
         {
             DataTable dtPrepaidPlan = new DataTable();
             dtPrepaidPlan = spObj.GetMostPopularPrepaidPlan(serviceProviderId);
             return dtPrepaidPlan;
         }
         catch (Exception ex)
         {

             throw ex;
         }
     }



     /// <summary>
      /// TRAINEE:5
      /// Created On: 19-Jan-2012
     /// SpHomepage6-Method to get Most Popular Postpaid Plan for the logged in service provider
     /// </summary>
     /// <param name="serviceProviderId"></param>
     /// <returns>Datatable</returns>
      [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetMostPopularPostpaidPlan(string serviceProviderId)
     {
         try
         {
             DataTable dtPostpaidPlan = new DataTable();
             dtPostpaidPlan = spObj.GetMostPopularPostpaidPlan(serviceProviderId);
             return dtPostpaidPlan;
         }
         catch (Exception ex)
         {

             throw ex;
         }
     }

     /// <summary>
      /// TRAINEE:5
      /// Created On: 19-Jan-2012
     /// SpHomepage7-Method to Update the profile of the logged in service provider in database
     /// </summary>
     /// <param name="serviceProviderId"></param>
     /// <param name="newContactNumber"></param>
     /// <param name="newPortingCharge"></param>
     /// <param name="newAddress"></param>
     /// <returns>integer value returned from procedure</returns>
      
     public int UpdateProfile(string serviceProviderId, string newContactNumber, double newPortingCharge, string newAddress)
       {
             
            int Ret = spObj.UpdateProfile(serviceProviderId, newContactNumber, newPortingCharge, newAddress);
           
          
           return Ret;
       }


       /// <summary>
        /// TRAINEE:5
       /// Created On: 19-Jan-2012
       /// SpHomepage8-Method to get Details specific to logged in service provider
       /// Pls note that it is different to method in common BL which is fetching details for all service providers
       /// </summary>
     /// <returns>DataTable</returns>
       [DataObjectMethod(DataObjectMethodType.Select)]
       public DataTable GetServiceProviderDetails(string serviceProviderId)
            
       {
           DataTable dtSpDetails = new DataTable();
           try
           {
              
               dtSpDetails = spObj.GetServiceProviderDetails(serviceProviderId);
           }
           catch (Exception ex)
           {

               throw ex;
           } 

           return dtSpDetails;
       }

    //Here start the methods for Service Provider 'Launch','Modify','Activate','Deactivate' methods;
       /// <summary>
       /// Created By:Trainee 4
       /// Created On:23-01-2012
       /// SPLMADeOffer-Method to get Offers by OfferId
    /// </summary>
    /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetOffersByOfferId(string OfferId)
    {
        DataTable dt = spObj.GetOffersByOfferId(OfferId);
        return dt;
    }


   

    //Here start the methods for Service Provider 'Launch','Modify','Activate','Deactivate' methods;
    /// <summary>
    /// Created By:Trainee 4
    /// Created On:23-01-2012
    /// SPLMADeOffer-Method to get Offers by Status
    /// </summary>
    /// <returns>DataTable</returns>
    public DataTable GetOffersByStatus(char Status)
    {
         DataTable dt = spObj.GetOffersByStatus(Status);
        return dt;
    }


     
     /// <summary>
     /// Created By:Trainee 4
     /// Created On:23-01-2012
     /// SPLMADeOffer-Method to Launch a new offer
     /// </summary>
     /// <param name="OfferName"></param>
     /// <param name="ServiceProviderId"></param>
     /// <param name="State"></param>
     /// <param name="Amount"></param>
     /// <param name="Duration"></param>
     /// <param name="Status"></param>
     /// <param name="Description"></param>
     /// <param name="OfferId"></param>
     /// <returns></returns>
    public int LaunchOffer(string OfferName, string ServiceProviderId, string State, double Amount,int Duration, char Status, string Description,out string OfferId)
    {
        int ret = spObj.LaunchOffer(OfferName,ServiceProviderId,State,Amount,Duration, Status,Description,out OfferId);
        return ret;
    }


    public int RegisterServiceProvider(string Password, char Role, string SecurityQuestion, string SecurityAnswer, string ServiceProviderName, string ContactNumber, double PortingCharge, string Address, string LicenseNumber, out string ServiceProviderId)
    {
        int ret;
        ServiceProviderDAL sdal = new ServiceProviderDAL();
        ret = sdal.RegisterServiceProvider(Password, Role, SecurityQuestion, SecurityAnswer, ServiceProviderName, ContactNumber, PortingCharge, Address, LicenseNumber, out ServiceProviderId);
        return ret;
    }

     /// <summary>
     /// trainee-6
     /// to get all prepaid plan values
     /// </summary>
     /// <param name="PlanId"></param>
     /// <param name="planName"></param>
     /// <param name="PlanType"></param>
     /// <param name="Duration"></param>
     /// <param name="ProcessingFee"></param>
     /// <param name="ServiceTax"></param>
     /// <param name="CallRate"></param>
     /// <param name="SmsRate"></param>
    public void GetPrepaidPlanValues(string PlanId, out string planName, out char PlanType, out int Duration, out decimal ProcessingFee, out decimal ServiceTax, out string CallRate, out string SmsRate)
    {
        try
        {
            spObj.GetPrepaidPlanValues(PlanId, out planName, out  PlanType, out  Duration, out ProcessingFee, out ServiceTax, out CallRate, out SmsRate);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// trainee-6
     /// to modify the prepaid plan
     /// </summary>
     /// <param name="PlanId"></param>
     /// <param name="planname"></param>
     /// <param name="plantype"></param>
     /// <param name="duration"></param>
     /// <param name="processingfee"></param>
     /// <param name="callrate"></param>
     /// <param name="smsrate"></param>
     /// <returns>integer</returns>
    public int ModifyPrepaidPlan(string PlanId,string planname, char plantype, int duration, decimal processingfee, string callrate, string smsrate)
    {

        try
        {
            int returnvalue = spObj.ModifyPrepaidPlan(PlanId, planname, plantype, duration, processingfee, callrate, smsrate);

            return returnvalue;
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    /// <summary>
    /// To get PlanDetail
    /// </summary>
    /// <param name="planid"></param>
    /// <param name="securityAmount"></param>
    /// <param name="processingFee"></param>
    /// <param name="serviceTax"></param>
    /// <param name="callRate"></param>
    /// <param name="smsRate"></param>
    public void GetPostPaidPlanDetail(string planid, out double securityAmount, out double processingFee, out double serviceTax, out string callRate, out string smsRate)
    {
        double sAmt = 0.00;
        double pFee = 0.00;
        double sTax = 0.00;
        string cRate = "";
        string sRate = "";
        spObj.GetPostPaidPlanDetail(planid, out sAmt, out pFee, out sTax, out cRate, out sRate);
        securityAmount = sAmt;
        processingFee = pFee;
        serviceTax = sTax;
        callRate = cRate;
        smsRate = sRate;
    }
    public int ModifyPostpaidPlan(string PlanID, string newPlanName, double newSecurityAmt, double newProcessingFee, string newCallRate, string newSmsRate)
    {
        int returned = spObj.ModifyPostpaidPlan(PlanID, newPlanName, newSecurityAmt, newProcessingFee, newCallRate, newSmsRate);
        return returned;
    }

   
    /// <summary>
    /// To Launch NewPostPaid Plan
    /// </summary>
    /// <param name="planname"></param>
    /// <param name="serviceproviderid"></param>
    /// <param name="securityamount"></param>
    /// <param name="processingfee"></param>
    /// <param name="servicetax"></param>
    /// <param name="callrate"></param>
    /// <param name="smsrate"></param>
    /// <param name="state"></param>
    /// <param name="planid"></param>
    /// <returns>Integer</returns>
    public int LaunchPostpaidPlan(string planname, string serviceproviderid, double securityamount, double processingfee, double servicetax, string callrate, string smsrate, string state, out string planid)
    {
        string Plan = "";
        try
        {
            int returnvalue = spObj.LaunchPostpaidPlan(planname, serviceproviderid, securityamount, processingfee, servicetax, callrate, smsrate, state, out Plan);
            planid = Plan;
            return returnvalue;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    /// <summary>
    /// trainee-6
    /// to launch new prepaid plan
    /// </summary>
    /// <param name="planname"></param>
    /// <param name="serviceproviderid"></param>
    /// <param name="plantype"></param>
    /// <param name="duration"></param>
    /// <param name="processingfee"></param>
    /// <param name="servicetax"></param>
    /// <param name="callrate"></param>
    /// <param name="smsrate"></param>
    /// <param name="state"></param>
    /// <param name="planid"></param>
    /// <returns>integer</returns>
    public int LaunchPrepaidPlan(string planname, string serviceproviderid, char plantype, int duration, double processingfee, double servicetax, string callrate, string smsrate, string state, out string planid)
    {
        string Plan = "";
        try
        {
            int returnvalue = spObj.LaunchPrepaidPlan(planname, serviceproviderid, plantype, duration, processingfee, servicetax, callrate, smsrate, state, out Plan);
            planid = Plan;
            return returnvalue;
        }
        catch (Exception)
        {
            
            throw;
        }
    }




    /// <summary>
    /// to get ServiceProviderID
    /// </summary>
    /// <param name="Userid"></param>
    /// <returns>String</returns>
    public string GetServiceProviderId(string Userid)
    {
        string spID = spObj.GetServiceProviderId(Userid);
        return spID;
    }
      /// <summary>
     /// TRAINEE:3
     /// Created On:23-Jan-2012
     /// This method is to view the feedbacks provided by the customer
     /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <returns></returns>
     public DataTable ViewFeedbacks(string serviceProviderId)
    {
        DataTable dt = new DataTable();
        dt = spObj.ViewFeedbacks(serviceProviderId);
        return dt;
    }
     ///<summary>
     ///Created By:Trainee 4
     /// Created On:23-01-2012
     /// SPLMADeOffer-Method to get Offers by Status--to modify offer details
     /// </summary>
     /// <param name="OfferId"></param>
     /// <param name="NewOfferName"></param>
     /// <param name="NewAmount"></param>
     /// <param name="NewDuration"></param>
     /// <param name="NewDescription"></param>
     /// <returns></returns>
    public int ModifyOffer(string OfferId, string NewOfferName, double NewAmount, int NewDuration, string NewDescription)
    {
        int ret;
        ret = spObj.ModifyOffer( OfferId,NewOfferName,NewAmount,NewDuration,NewDescription);
        return ret;
    }
     /// <summary>
     ///Created By:Trainee 4
     /// Created On:23-01-2012
     /// SPLMADeOffer Page--to deactivate Offer
     /// </summary>
     /// <param name="idType"></param>
     /// <param name="ID"></param>
     /// <returns>int</returns>
    public int DeactivatePlanOrOffer(string idType, string ID)
    {
        int ret;
        ret = spObj.DeactivatePlanOrOffer(idType, ID);
        return ret;
    }

     /// <summary>
     ///Created By:Trainee 4
     /// Created On:23-01-2012
     /// SPLMADeOffer--to activate Offer
     /// </summary>
     /// <param name="idType"></param>
     /// <param name="ID"></param>
     /// <returns>int</returns>
    public int ActivatePlanOrOffer(string idType, string ID)
    {
        int ret;
        ret = spObj.ActivatePlanOrOffer(idType, ID);
        return ret;
    }
     /// <summary>
     /// trainee-6
     /// to get active prepaid plan values
     /// </summary>
     /// <param name="PlanId"></param>
     /// <param name="planName"></param>
     /// <param name="PlanType"></param>
     /// <param name="Duration"></param>
     /// <param name="ProcessingFee"></param>
     /// <param name="ServiceTax"></param>
     /// <param name="CallRate"></param>
     /// <param name="SmsRate"></param>
     /// <param name="state"></param>
    public void GetActivePrepaidPlanValues(string PlanId, out string planName, out char PlanType, out int Duration, out decimal ProcessingFee, out decimal ServiceTax, out string CallRate, out string SmsRate, out string state)
    {
        try
        {
            spObj.GetActivePrepaidPlanValues(PlanId, out planName, out  PlanType, out  Duration, out ProcessingFee, out ServiceTax, out CallRate, out SmsRate, out state);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// trainee-6
     /// to get inactive prepaid plan values
     /// </summary>
     /// <param name="PlanId"></param>
     /// <param name="planName"></param>
     /// <param name="PlanType"></param>
     /// <param name="Duration"></param>
     /// <param name="ProcessingFee"></param>
     /// <param name="ServiceTax"></param>
     /// <param name="CallRate"></param>
     /// <param name="SmsRate"></param>
     /// <param name="state"></param>
    public void GetInactivePrepaidPlanValues(string PlanId, out string planName, out char PlanType, out int Duration, out decimal ProcessingFee, out decimal ServiceTax, out string CallRate, out string SmsRate, out string state)
    {
        try
        {
            spObj.GetInactivePrepaidPlanValues(PlanId, out planName, out  PlanType, out  Duration, out ProcessingFee, out ServiceTax, out CallRate, out SmsRate, out state);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// trainee-6
     /// to activate prepaid plan
     /// </summary>
     /// <param name="idType"></param>
     /// <param name="ID"></param>
     /// <returns>int</returns>
    public int ActivatePrepaidPlan(string idType, string ID)
    {
        int ret;
        try
        {
            ret = spObj.ActivatePrepaidPlan(idType, ID);
            return ret;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// trainee-6
     /// to deactivate prepaid plan
     /// </summary>
     /// <param name="idType"></param>
     /// <param name="ID"></param>
     /// <returns>int</returns>
    public int DeactivatePrepaidPlan(string idType, string ID)
    {
        int ret;
        try
        {
            ret = spObj.DeactivatePrepaidPlan(idType, ID);
            return ret;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// trainee-6
     /// get all active prepaid plans
     /// </summary>
     /// <returns>datatable</returns>
    public DataTable GetActivePrepaidPlans(string spid)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = spObj.GetActivePrepaidPlans(spid);
            return dt;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// trainee-6
     /// get all deactive prepaid plans
     /// </summary>
     /// <returns>datatable</returns>
    public DataTable GetInactivePrepaidPlans(string spid)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = spObj.GetInactivePrepaidPlans(spid);
            return dt;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
     /// <summary>
     /// TO fetch plans for State and ServiceProviderId
     /// </summary>
     /// <param name="State"></param>
     /// <param name="PlanType"></param>
     /// <param name="ServiceProviderId"></param>
     /// <returns>datatable</returns>

    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetPlan(string State, string PlanType, string ServiceProviderId)
    {
        ServiceProviderDAL sdal= new ServiceProviderDAL();
        DataTable dt = new DataTable();
        dt = sdal.GetPlan(State, PlanType, ServiceProviderId);
        return dt;
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetProviderId(string PlanType)
    {
        ServiceProviderDAL sdal = new ServiceProviderDAL();
        DataTable dt = new DataTable();
        dt = sdal.GetProviderId(PlanType);
        return dt;
    }
 
     /// <summary>
     /// To Fetch InactivePostPaidPlans from DAL
     /// </summary>
     /// <returns>DataTable</returns>
    public DataTable GetInactivePlans(string ServiceID)
    {
        DataTable dt=spObj.GetInactivePlans(ServiceID);
        return dt;
    }
     /// <summary>
     /// To Fetch ActivePostPaidPlans from DAL
     /// </summary>
     /// <returns>DataTable</returns>
    public DataTable GetActivePlans(string ServiceID)
    {
        DataTable dt = spObj.GetActivePlans(ServiceID);
        return dt;
    }
     /// <summary>
     /// To Fetch Top5 Postpaid and Prepaid Plans from DAL
     /// </summary>
     /// <param name="spID"></param>
     /// <returns>DataTable</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetTopFivePlans(string spID)
    {
        DataTable dt=spObj.GetTopFivePlans(spID);
        return dt;
 
    }
     /// <summary>
     /// To fetch Recipient Service Provider reports 
     /// </summary>
     /// <param name="Status"></param>
     /// <param name="Fromdate"></param>
     /// <param name="Todate"></param>
     /// <param name="rSPid"></param>
     /// <returns>DataTable</returns>
     public DataTable SPreportsAsaRecipient(char Status, DateTime Fromdate, DateTime Todate, string rSPid)
     {
         DataTable dt = spObj.SPreportsAsaRecipient(Status, Fromdate, Todate, rSPid);
         return dt;
     }
     /// <summary>
     /// To fetch Donor Service Provider reports
     /// </summary>
     /// <param name="Fromdate"></param>
     /// <param name="Todate"></param>
     /// <param name="dSPid"></param>
     /// <returns>DataTable</returns>
     public DataTable SPreportsAsaDonor(DateTime Fromdate, DateTime Todate, string dSPid)
     {
         DataTable dt = spObj.SPreportsAsaDonor(Fromdate, Todate, dSPid);
         return dt;
     }
    

     /// <summary>
     ///To fetch Donor Plan details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     /// 

     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPlan()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetActivePlan();
        
         return dtObj;
     }
     /// <summary>
     /// To fetch Donor Plan details
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPrepPlans(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepPlans(State);
         return dtObj;
     }
     /// <summary>
     /// To fetch Donor Plan details
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     public DataTable GetPostPlans(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostPlans(State);
         return dtObj;
     }

    /// <summary>
    /// To get status
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
     public DataTable GetPrepStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepStatus(Status);
         return dtObj;
     }

     /// <summary>
     /// To get status
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPostStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostStatus(Status);
         return dtObj;
     }
    /// <summary>
     ///To get Offer status
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
     public DataTable GetOffersStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetOffersStatus(Status);
         return dtObj;
     }

     /// <summary>
     ///To get Offers
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     public DataTable GetOffersState(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetOffersState(State);
         return dtObj;
     }
     /// <summary>
     /// To get Customer Details
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPrepCustState(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepCustState(State);
         return dtObj;
     }
    /// <summary>
     /// To get Customer Details
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
     public DataTable GetPrepCustStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepCustStatus(Status);
         return dtObj;
     }
     /// <summary>
     /// To get Customer Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPostCustState(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostCustState(State);
         return dtObj;
     }
     /// <summary>
     /// To get Customer Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPostCustStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostCustStatus(Status);
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPrepProState(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepProState(State);
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPrepProStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepProStatus(Status);
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     public DataTable GetPostProState(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostProState(State);
         return dtObj;
     }
     /// <summary>
     /// To get Postpaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPostProStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostProStatus(Status);
         return dtObj;
     }

     /// <summary>
     /// To get Postpaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPost()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPost();
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPrepPlans()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepPlans();
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPrepfees()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepfees();
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPrepCusts()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepCusts();
         return dtObj;
     }
     /// <summary>
     /// To get Postpaid plans  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPostfees()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostfees();
         return dtObj;
     }
     /// <summary>
     /// To get Customer  Details
     /// </summary>
     /// <param name="Status"></param>
     /// <returns></returns>
     public DataTable GetPostCusts()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostCusts();
         return dtObj;
     }
    /// <summary>
     /// To get Postpaid plans  Details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
     public DataTable GetPostStates(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostStates(State);
         return dtObj;
     }
   /// <summary>
     /// To get Postpaid plans  Details
   /// </summary>
   /// <param name="Status"></param>
   /// <returns></returns>
     public DataTable GetPostpaidStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPostpaidStatus(Status);
         return dtObj;
     }
    /// <summary>
     /// To get Prepaid plans  Details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
     public DataTable GetPrepStates(string State)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepStates(State);
         return dtObj;
     }
     /// <summary>
     /// To get Prepaid plans  Details
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     public DataTable GetPrepaidStatus(string Status)
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.GetPrepStatus(Status);
         return dtObj;
     }
     /// <summary>
     /// To get Offer  Details
     /// </summary>
     /// <param name="State"></param>
     /// <returns></returns>
     public DataTable Getoffers()
     {
         ServiceProviderDAL seviceDal = new ServiceProviderDAL();
         DataTable dtObj = seviceDal.Getoffers();
         return dtObj;
     }
     /// <summary>
     /// TRAINEE:1
     /// Date:20/1/2012
     /// Method Name:DonorServiceProviderGridViewBL
     /// This method is used to populate the DonorServiceProvider GridView
     ///<returns>DataTAble containing the values</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable DonorServiceProviderGridViewBL()
     {
         DataTable dataTableDonorObj = new DataTable();
         //dataTableDonorObj = spObj.DonorServiceProviderPanel();
         try
         {
             dataTableDonorObj = spObj.DonorServiceProviderGridView();
         }
         catch (Exception ex)
         {
             throw ex;
         }
         return dataTableDonorObj;
     }


     /// TRAINEE:1
     /// Date:20/1/2012
     /// Method Name:RecipientServiceProviderGridViewBL
     /// This method is used to populate the RecipientServiceProvider GridView
     ///<returns>DataTAble containing the values</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable RecipientServiceProviderGridViewBL()
     {
         //creating datatable object
         DataTable dataTableRecipientObj = new DataTable();
         //try block
         try
         {
             dataTableRecipientObj = spObj.RecipientServiceProviderGridView();
         }
             //catch block
         catch (Exception ex)
         {
             throw ex;
         }
         //returns datatable
         return dataTableRecipientObj;
     }
     /// TRAINEE:1
     /// Date:20/1/2012
     /// Method Name:DonorServiceProviderDetailsViewBL
     /// This method is used to populate the DonorServiceProvider DetailsView
     ///<returns>DataTAble containing the values</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable DonorServiceProviderDetailsViewBL(string portingId)
     {
         //creating datatable object
         DataTable dataTableDonorObj = new DataTable();
         //try block
         try
         {
             dataTableDonorObj = spObj.DonorServiceProviderDetailsViewDAL(portingId);
         }
             //catch block
         catch (Exception ex)
         {
             throw ex;
         }
         //returns datatable
         return dataTableDonorObj;
     }
     /// TRAINEE:1
     /// Date:20/1/2012
     /// Method Name:RecipientServiceProviderDetailsViewBL
     /// This method is used to populate the RecipientServiceProviderDetailsView
     ///<returns>DataTAble containing the values</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable RecipientServiceProviderDetailsViewBL(string portingId)
     {
         DataTable dataTableRecipientObj = new DataTable();
         //try
         try
         {
             dataTableRecipientObj = spObj.RecipientServiceProviderDetailsViewDAL(portingId);
         }
             //catch block
         catch (Exception ex)
         {
             throw ex;
         }
         //returns datable object
         return dataTableRecipientObj;
     }
     /// TRAINEE:1
     /// Date:20/1/2012
     /// Method Name:GetStatusBL
     /// This method is used to get status
     ///<returns>character containing status value</returns>
     public char GetStatusBL(string portingId)
     {
         char retStatus;
         //try block
         try
         {
             retStatus = spObj.GetStatusDAL(portingId);
         }
             //catch block
         catch (Exception ex)
         {
             throw ex;
         }
         //return status
         return retStatus;
     }

     /// TRAINEE:1
     /// Date:20/1/2012
     /// Method Name:updatePortStatusBL
     /// This method is used to get status
     ///<returns>character containing status value</returns>
     public int updatePortStatusBL(string PortingId, string Role, string Activity, string Comments)
     {
         int retStatus;
         //try block
         try
         {
             //method call
             retStatus = spObj.updatePortStatusDAL(PortingId, Role, Activity, Comments);
         }
             //catch block
         catch (Exception ex)
         {
             throw ex;
         }
         //returns status
         return retStatus;
     }


}




