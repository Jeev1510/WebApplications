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
/// Summary description for Common
/// </summary>
 [DataObject(true)]
public class Common
{
     //Objects for CommonDAl Class
    CommonDAL commondalobj = new CommonDAL();
    DataTable dt = new DataTable();

    public Common()
    {
        //
        // TODO: Add constructor logic here
        //
    }
     /// <summary>
     /// TRAINEE:4
     /// To fetch all state names
     /// </summary>
     /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetStates()
    {
        dt = commondalobj.GetStates();
        return dt;
    }
     /// <summary>
     /// To fetch all ServiceProvider
     /// </summary>
     /// <returns>DataTable</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetServiceProvider()
    {
        dt = commondalobj.GetServiceProvider();
        return dt;
    }


    //Here start the methods for Service Provider 'Launch','Modify','Activate','Deactivate' methods;
    /// <summary>
    /// LMADOffers-Method to get Offers
    /// </summary>
    /// <returns>DataTable</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable GetOffers()
    {
        
        dt = commondalobj.GetOffers();
        return dt;
    }
     /// <summary>
     /// trainee-6
     /// to get all prepaid plans
     /// </summary>
     /// <returns>datatable</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPrepaidPlan(string spid)
     {
         try
         {
             dt = commondalobj.GetPrepaidPlan(spid);
         }
         catch (Exception)
         {
             
             throw;
         }
         return dt;
     }


     /// <summary>
     /// </summary>
     /// <param name="UserId"></param>
     /// <returns></returns>
     public char GetRole(string UserId)
     {
         CommonDAL cdal = new CommonDAL();
         char ret;
         ret = cdal.GetRole(UserId);
         return ret;
     }
     /// <summary>
     /// TRAINEE:7
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
     public int MakePayment(string UserId, int AccountNumber, string Password, string PortingId, double Amount, string Role, string Comments,out string TransactionId)
     {


         CommonDAL cdal = new CommonDAL();
         int ret;
         ret = cdal.MakePayment(UserId, AccountNumber, Password, PortingId, Amount, Role, Comments, out TransactionId);
         return ret; 

     }

     public double CalculateAmount(string PortingId, char Role)
     {
         CommonDAL cdal = new CommonDAL();
         
       double amount=cdal.CalculateAmount(PortingId, Role);
        return amount;
     }

     public DataTable GetPostpaidStatus(string Status)
     {
         
         DataTable dtObj = new DataTable();
         CommonDAL commondal = new CommonDAL();
         dtObj = commondal.GetPostpaidStatus(Status);


         return dtObj;
         
     }
     public DataTable GetPrepaidStatus(string Status)
     {
         
         DataTable dtObj = new DataTable();
         CommonDAL commondal = new CommonDAL();
         dtObj = commondal.GetPrepaidStatus(Status);
         return dtObj;
     }
     /// <summary>
     /// Fetch PostPaidPlans
     /// </summary>
     /// <param name="servicePid"></param>
     /// <returns>DataTable</returns>
     [DataObjectMethod(DataObjectMethodType.Select)]
     public DataTable GetPostPaidPlans(string servicePid)
     {
         DataTable dt = commondalobj.GetPostPaidPlans(servicePid);
         return dt;
     }

}
