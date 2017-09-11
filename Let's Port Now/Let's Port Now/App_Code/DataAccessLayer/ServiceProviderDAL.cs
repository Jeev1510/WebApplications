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
/// Summary description for ServiceProviderDAL
/// </summary>
public class ServiceProviderDAL
{
    SqlConnection con;
    public ServiceProviderDAL()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        //
        // TODO: Add constructor logic here
        //
    }


    //Here start the methods for Service Provider Home Page
    //SpHomepage1
    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage1-Method to get the number of Customers ported to the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public int GetNoOfCustomersPortedTo(string serviceProviderId)
    {
        int NoOfCustomersPortedTo = 0;
        SqlCommand cmdCustomersPortedTo = new SqlCommand("Select Count(*) from tbl_Porting WHERE RecipientSpId=@serviceProviderId AND PortStatus='X'", con);
        SqlParameter param = new SqlParameter();
        cmdCustomersPortedTo.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);


        try
        {
            con.Open();
            NoOfCustomersPortedTo = Convert.ToInt32(cmdCustomersPortedTo.ExecuteScalar());

        }
        catch (SqlException ex)
        {
            throw ex;
            //Console.WriteLine("Some Error Occured in method GetNoOfCustomersPortedTo");
        }
        finally
        {
            con.Close();
        }
        return NoOfCustomersPortedTo;

    }



    //SpHomepage2
    /// <summary>
    /// TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage2-Method to get the number of Customers ported away from the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public int GetNoOfCustomersPortedOut(string serviceProviderId)
    {
        int NoOfCustomersPortedOut = 0;
        SqlCommand cmdCustomersPortedOut = new SqlCommand("Select Count(*) from tbl_Porting WHERE DonorSpId=@serviceProviderId AND PortStatus='X'", con);
        SqlParameter param = new SqlParameter();
        cmdCustomersPortedOut.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);


        try
        {
            con.Open();
            NoOfCustomersPortedOut = Convert.ToInt32(cmdCustomersPortedOut.ExecuteScalar());

        }
        catch (SqlException ex)
        {
            throw ex;
            //Console.WriteLine("Some Error Occured in method GetNoOfCustomersPortedOut");
        }
        finally
        {
            con.Close();
        }
        return NoOfCustomersPortedOut;

    }



    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the two recent feedbacks for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetFeedback(string serviceProviderId)
    {
        try
        {
            SqlCommand cmdFeedback = new SqlCommand("SELECT  TOP(2) CustomerName,Comments From tbl_Customer tc inner Join tbl_Feedback tf On tc.CustomerId=tf.CustomerId WHERE tf.ServiceProviderId=@serviceProviderId AND tc.CustomerId IN (Select TOP(2) CustomerId FROM tbl_FeedBack WHERE ServiceProviderId=@serviceProviderId Order By FeedBackDate Desc)", con);
            SqlParameter param = new SqlParameter();
            cmdFeedback.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
            DataTable dtFeedback = new DataTable();
            SqlDataAdapter daFeedback = new SqlDataAdapter(cmdFeedback);


            daFeedback.Fill(dtFeedback);
            return dtFeedback;
        }
        catch (SqlException ex)
        {

            throw ex;
        }
    }


    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage4-Method to get the Pending Payment Details for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetPendingPaymentDetails(string serviceProviderId)
    {
        try
        {
            SqlCommand cmdPendingPayments = new SqlCommand("Select p.PortingId,p.UniquePortingCode,p.ApplicationDate,(Select pr.PlanName from tbl_PrepaidPlans pr WHERE PlanId=p.PlanId UNION Select ps.PlanName from tbl_PostpaidPlans ps WHERE PlanId=p.PlanId) As PlanName from tbl_Porting p WHERE RecipientSpId=@serviceProviderId AND PortStatus='P'", con);
            SqlParameter param = new SqlParameter();
            cmdPendingPayments.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
            DataTable dtPendingPayments = new DataTable();
            SqlDataAdapter daPendingPayments = new SqlDataAdapter(cmdPendingPayments);


            daPendingPayments.Fill(dtPendingPayments);
            return dtPendingPayments;
        }
        catch (SqlException ex)
        {

            throw ex;
        }
    }


    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage5-Method to get Most Popular Prepaid Plan for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetMostPopularPrepaidPlan(string serviceProviderId)
    {
        try
        {
            SqlCommand cmdPrepaidPlan = new SqlCommand("Select PlanName ,PlanType, Duration, CallRate, SmsRate, State from tbl_PrepaidPlans WHERE ServiceProviderId=@serviceProviderId AND PlanId IN (Select TOP(1) WITH TIES CurrentPlanId From tbl_Customer WHERE CurrentPlanId IN (Select PlanId From tbl_PrepaidPlans WHERE ServiceProviderId=@serviceProviderId) Group By CurrentPlanId Order By COUNT(*) Desc)", con);
            SqlParameter param = new SqlParameter();
            cmdPrepaidPlan.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
            DataTable dtPrepaidPlan = new DataTable();
            SqlDataAdapter daPrepaidPlan = new SqlDataAdapter(cmdPrepaidPlan);


            daPrepaidPlan.Fill(dtPrepaidPlan);
            return dtPrepaidPlan;
        }
        catch (SqlException ex)
        {

            throw ex;
        }
    }

    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage6-Method to get Most Popular Postpaid Plan for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetMostPopularPostpaidPlan(string serviceProviderId)
    {
        try
        {
            SqlCommand cmdPostpaidPlan = new SqlCommand("Select PlanName ,CallRate, SmsRate, State from tbl_PostpaidPlans WHERE ServiceProviderId=@serviceProviderId AND PlanId IN (Select TOP(1) WITH TIES CurrentPlanId From tbl_Customer WHERE CurrentPlanId IN (Select PlanId From tbl_PostpaidPlans WHERE ServiceProviderId=@serviceProviderId)  Group By CurrentPlanId Order By COUNT(*) Desc)", con);
            SqlParameter param = new SqlParameter();
            cmdPostpaidPlan.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
            DataTable dtPostpaidPlan = new DataTable();
            SqlDataAdapter daPostpaidPlan = new SqlDataAdapter(cmdPostpaidPlan);


            daPostpaidPlan.Fill(dtPostpaidPlan);
            return dtPostpaidPlan;
        }
        catch (SqlException ex)
        {

            throw ex;
        }
    }



    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage7-Method to Update the profile of the logged in service provider in database
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <param name="newContactNumber"></param>
    /// <param name="newPortingCharge"></param>
    /// <param name="newAddress"></param>
    /// <returns></returns>
    public int UpdateProfile(string serviceProviderId, string newContactNumber, double newPortingCharge, string newAddress)
    {
        int Ret = 0;
        SqlCommand cmd = new SqlCommand("usp_UpdateServiceProviderDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
        cmd.Parameters.AddWithValue("@newContactNumber", newContactNumber);
        cmd.Parameters.AddWithValue("@newPortingCharge", newPortingCharge);
        cmd.Parameters.AddWithValue("@newAddress", newAddress);
        SqlParameter prmreturn = new SqlParameter();
        prmreturn.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(prmreturn);
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
        Ret = Convert.ToInt32(prmreturn.Value);
        con.Close();
        return Ret;
    }



    /// <summary>
    ///  TRAINEE:5
    /// Created On: 19-Jan-2012
    /// SpHomepage8-Method to get Details specific to logged in service provider
    /// Pls note that it is different to method in common DAL which is fetching details for all service providers
    /// </summary>
    /// <returns></returns>
    public DataTable GetServiceProviderDetails(string serviceProviderId)
    {

        DataTable dtSpDetails = new DataTable();
        SqlCommand cmdSpDetails = new SqlCommand("Select Address,ContactNumber,PortingCharge from tbl_ServiceProvider WHERE serviceProviderId=@serviceproviderId", con);
        SqlParameter param = new SqlParameter();
        cmdSpDetails.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
        SqlDataAdapter daEmp = new SqlDataAdapter(cmdSpDetails);
        try
        {
            daEmp.Fill(dtSpDetails);
        }
        catch (SqlException ex)
        {

            dtSpDetails = null;
            Console.WriteLine(ex.Message);
        }
        return dtSpDetails;
    }

    /// <summary>
    ///  TRAINEE:7
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the service provider details from selected plantype
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetProviderId(string PlanType)
    {


        DataTable dtplanDetails = new DataTable();

        if (PlanType == "Prepaid")
        {
            SqlCommand cmdEmp = new SqlCommand("Select distinct sp.ServiceProviderId,sp.ServiceProviderName from tbl_PrepaidPlans pp inner join  tbl_ServiceProvider sp On(pp.ServiceProviderId=sp.ServiceProviderId) where Status='A'", con);

            cmdEmp.Connection = con;

            SqlDataAdapter daEmp = new SqlDataAdapter();
            daEmp.SelectCommand = cmdEmp;
            try
            {
                daEmp.Fill(dtplanDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        else if (PlanType == "Postpaid")
        {
            SqlCommand cmdEmp = new SqlCommand("Select distinct sp.ServiceProviderId,sp.ServiceProviderName from tbl_PostpaidPlans pp inner join  tbl_ServiceProvider sp On(pp.ServiceProviderId=sp.ServiceProviderId) where Status='A'", con);

            cmdEmp.Connection = con;

            SqlDataAdapter daEmp = new SqlDataAdapter();
            daEmp.SelectCommand = cmdEmp;
            try
            {
                daEmp.Fill(dtplanDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        return dtplanDetails;
    }



    /// <summary>
    /// Created By: Trainee 8
    /// Created On: 19-Jan-2012
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
    /// <returns></returns>
    public int LaunchPostpaidPlan(string planname, string serviceproviderid, double securityamount, double processingfee, double servicetax, string callrate, string smsrate, string state, out string planid)
    {
        int returned = 0;
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_AddPostpaidPlan";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter PlanName = new SqlParameter();
        PlanName.ParameterName = "@planname";
        PlanName.SqlDbType = SqlDbType.VarChar;
        PlanName.Size = 20;
        PlanName.Direction = ParameterDirection.Input;
        PlanName.Value = planname;


        SqlParameter ServiceProviderId = new SqlParameter();
        ServiceProviderId.ParameterName = "@ServiceProviderId";
        ServiceProviderId.SqlDbType = SqlDbType.Char;
        ServiceProviderId.Size = 5;
        ServiceProviderId.Direction = ParameterDirection.Input;
        ServiceProviderId.Value = serviceproviderid;


        SqlParameter SecurityAmount = new SqlParameter();
        SecurityAmount.ParameterName = "@securityAmount";
        SecurityAmount.SqlDbType = SqlDbType.SmallMoney;
        SecurityAmount.Direction = ParameterDirection.Input;
        SecurityAmount.Value = securityamount;

        SqlParameter ProcessingFee = new SqlParameter();
        ProcessingFee.ParameterName = "@processingfee";
        ProcessingFee.SqlDbType = SqlDbType.SmallMoney;
        ProcessingFee.Direction = ParameterDirection.Input;
        ProcessingFee.Value = processingfee;


        SqlParameter ServiceTax = new SqlParameter();
        ServiceTax.ParameterName = "@servicetax";
        ServiceTax.SqlDbType = SqlDbType.Decimal;
        ServiceTax.Direction = ParameterDirection.Input;
        ServiceTax.Value = servicetax;

        SqlParameter CallRate = new SqlParameter();
        CallRate.ParameterName = "@callrate";
        CallRate.SqlDbType = SqlDbType.VarChar;
        CallRate.Size = 15;
        CallRate.Direction = ParameterDirection.Input;
        CallRate.Value = callrate;

        SqlParameter SmsRate = new SqlParameter();
        SmsRate.ParameterName = "@smsrate";
        SmsRate.SqlDbType = SqlDbType.VarChar;
        SmsRate.Size = 15;
        SmsRate.Direction = ParameterDirection.Input;
        SmsRate.Value = smsrate;

        SqlParameter State = new SqlParameter();
        State.ParameterName = "@state";
        State.SqlDbType = SqlDbType.VarChar;
        State.Size = 20;
        State.Direction = ParameterDirection.Input;
        State.Value = state;

        SqlParameter PlanId = new SqlParameter();
        PlanId.ParameterName = "@planid";
        PlanId.SqlDbType = SqlDbType.VarChar;
        PlanId.Size = 6;
        PlanId.Direction = ParameterDirection.Output;

        SqlParameter ReturnValue = new SqlParameter();
        ReturnValue.ParameterName = "@Return";
        ReturnValue.SqlDbType = SqlDbType.Int;
        ReturnValue.Direction = ParameterDirection.ReturnValue;

        cmdOne.Parameters.Add(PlanName);
        cmdOne.Parameters.Add(ServiceProviderId);
        cmdOne.Parameters.Add(SecurityAmount);
        cmdOne.Parameters.Add(ProcessingFee);
        cmdOne.Parameters.Add(ServiceTax);
        cmdOne.Parameters.Add(CallRate);
        cmdOne.Parameters.Add(SmsRate);
        cmdOne.Parameters.Add(State);
        cmdOne.Parameters.Add(PlanId);
        cmdOne.Parameters.Add(ReturnValue);

        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            returned = Convert.ToInt32(ReturnValue.Value);

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }
        planid = PlanId.Value.ToString();
        return returned;

    }

    /// <summary>
    /// Created By: Trainee 8
    /// Created On: 19-Jan-2012
    /// </summary>
    /// <param name="Userid"></param>
    /// <returns></returns>
    public string GetServiceProviderId(string Userid)
    {
        string count = "";

        SqlCommand sqlcomm = new SqlCommand();
        sqlcomm.CommandType = CommandType.Text;
        sqlcomm.CommandText = "select @serviceProviderid=ServiceProviderId from tbl_ServiceProvider where userid=@userid;";
        sqlcomm.Connection = con;


        //adding parameters

        SqlParameter UserID = new SqlParameter();
        UserID.ParameterName = "@userid";
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Size = 6;
        UserID.Direction = ParameterDirection.Input;
        UserID.Value = Userid;

        SqlParameter Count = new SqlParameter();
        Count.ParameterName = "@serviceProviderid";
        Count.SqlDbType = SqlDbType.VarChar;
        Count.Size = 6;
        Count.Direction = ParameterDirection.Output;

        sqlcomm.Parameters.Add(UserID);
        sqlcomm.Parameters.Add(Count);
        try
        {
            //executing query
            con.Open();
            sqlcomm.ExecuteNonQuery();



        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }

        count = Count.Value.ToString();
        return count;
    }


    /// <summary>
    /// SpHomepage4-Method to get the Pending Payment Details for the logged in service provider
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    //public DataTable GetPendingPaymentDetails(string serviceProviderId)
    //{
    //    try
    //    {
    //        SqlCommand cmdPendingPayments = new SqlCommand("Select PortingId,UniquePortingCode,ApplicationDate, PlanId from tbl_Porting WHERE RecipientSpId=@serviceProviderId AND PortStatus='P'", con);
    //        SqlParameter param = new SqlParameter();
    //        cmdPendingPayments.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
    //        DataTable dtPendingPayments = new DataTable();
    //        SqlDataAdapter daPendingPayments = new SqlDataAdapter(cmdPendingPayments);


    //        daPendingPayments.Fill(dtPendingPayments);
    //        return dtPendingPayments;
    //    }
    //    catch (SqlException ex)
    //    {

    //        throw ex;
    //    }
    //}  





    /// <summary>
    /// Created By: Trainee 4
    /// Created On: 19-Jan-2012
    /// LMADOffer-Method to get the Offers by passing status
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetOffersByStatus(char Status)
    {
        // This code is to get the state names from the database
        SqlCommand cm = new SqlCommand("SELECT * FROM tbl_Offers WHERE Status=@Status", con);
        cm.Parameters.AddWithValue("@Status", Status);
        DataTable dt = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter();
        adap.SelectCommand = cm;
        try
        {
            adap.Fill(dt);
        }
        catch (Exception ex)
        {

            throw ex;
        }

        // Note: DataReader implements IEnumarable interface
        return dt;

    }

    /// <summary>
    /// Created By: Trainee 4
    /// Created On: 19-Jan-2012
    /// LMADOffer-Method to get the Offers by Id
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetOffersByOfferId(string OfferId)
    {
        // This code is to get the state names from the database
        SqlCommand cm = new SqlCommand("SELECT * FROM tbl_Offers WHERE OfferId=@OfferId", con);
        cm.Parameters.AddWithValue("@OfferId", OfferId);
        DataTable dt = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter();
        adap.SelectCommand = cm;

        try
        {
            adap.Fill(dt);
        }
        catch (Exception ex)
        {

            throw ex;
        }

        // Note: DataReader implements IEnumarable interface
        return dt;
    }

    /// <summary>
    /// Created By: Trainee 4
    /// Created On: 19-Jan-2012
    /// LMADOffer-Method to insert a new offer
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public int LaunchOffer(string OfferName, string ServiceProviderId, string State, double Amount, int Duration, char Status, string Description, out string OfferId)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_AddOffer";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OfferName", OfferName);
        cmd.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderId);
        cmd.Parameters.AddWithValue("@State", State);
        cmd.Parameters.AddWithValue("@Amount", Amount);
        cmd.Parameters.AddWithValue("@Duration", Duration);
        cmd.Parameters.AddWithValue("@Status", Status);
        cmd.Parameters.AddWithValue("@Description", Description);


        SqlParameter Oid = new SqlParameter();
        Oid.ParameterName = "@OfferId";
        Oid.Direction = ParameterDirection.Output;
        Oid.SqlDbType = SqlDbType.VarChar;
        Oid.Size = 30;
        cmd.Parameters.Add(Oid);

        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(prmReturn);

        try
        {

            con.Open();
            cmd.ExecuteNonQuery();
            OfferId = Oid.Value.ToString();
        }
        catch (Exception ex)
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
    /// Created By: Trainee 8
    /// Created On: 20-Jan-2012
    /// </summary>
    /// <param name="PlanID"></param>
    /// <param name="newPlanName"></param>
    /// <param name="newSecurityAmt"></param>
    /// <param name="newProcessingFee"></param>
    /// <param name="newCallRate"></param>
    /// <param name="newSmsRate"></param>
    /// <returns></returns>
    public int ModifyPostpaidPlan(string PlanID, string newPlanName, double newSecurityAmt, double newProcessingFee, string newCallRate, string newSmsRate)
    {
        int returned = 0;
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_UpdatePostpaidPlan";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter PlanId = new SqlParameter();
        PlanId.ParameterName = "@PlanId";
        PlanId.SqlDbType = SqlDbType.VarChar;
        PlanId.Size = 6;
        PlanId.Direction = ParameterDirection.Input;
        PlanId.Value = PlanID;
        SqlParameter NewName = new SqlParameter();
        NewName.ParameterName = "@NewPlanName";
        NewName.SqlDbType = SqlDbType.VarChar;
        NewName.Size = 20;
        NewName.Direction = ParameterDirection.Input;
        NewName.Value = newPlanName;
        SqlParameter NewSAmount = new SqlParameter();
        NewSAmount.ParameterName = "@NewSecurityAmount";
        NewSAmount.SqlDbType = SqlDbType.SmallMoney;
        NewSAmount.Direction = ParameterDirection.Input;
        NewSAmount.Value = newSecurityAmt;
        SqlParameter ProssFee = new SqlParameter();
        ProssFee.ParameterName = "@NewProcessingFee";
        ProssFee.SqlDbType = SqlDbType.SmallMoney;
        ProssFee.Direction = ParameterDirection.Input;
        ProssFee.Value = newProcessingFee;
        SqlParameter NewCrate = new SqlParameter();
        NewCrate.ParameterName = "@NewCallRate";
        NewCrate.SqlDbType = SqlDbType.VarChar;
        NewCrate.Size = 15;
        NewCrate.Direction = ParameterDirection.Input;
        NewCrate.Value = newCallRate;
        SqlParameter NewSrate = new SqlParameter();
        NewSrate.ParameterName = "@NewSmsRate";
        NewSrate.SqlDbType = SqlDbType.VarChar;
        NewSrate.Size = 15;
        NewSrate.Direction = ParameterDirection.Input;
        NewSrate.Value = newSmsRate;
        SqlParameter ReturnValue = new SqlParameter();
        ReturnValue.ParameterName = "@Return";
        ReturnValue.SqlDbType = SqlDbType.Int;
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        cmdOne.Parameters.Add(PlanId);
        cmdOne.Parameters.Add(NewName);
        cmdOne.Parameters.Add(NewSAmount);
        cmdOne.Parameters.Add(ProssFee);

        cmdOne.Parameters.Add(NewCrate);
        cmdOne.Parameters.Add(NewSrate);
        cmdOne.Parameters.Add(ReturnValue);
        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }
        returned = Convert.ToInt32(ReturnValue.Value);
        return returned;

    }
    /// <summary>
    /// Get PlanDetails for the selected Plan
    /// </summary>
    /// <param name="planid"></param>
    /// <param name="securityAmount"></param>
    /// <param name="processingFee"></param>
    /// <param name="serviceTax"></param>
    /// <param name="callRate"></param>
    /// <param name="smsRate"></param>
    public void GetPostPaidPlanDetail(string planid, out double securityAmount, out double processingFee, out double serviceTax, out string callRate, out string smsRate)
    {

        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "select @securityAmt=SecurityAmount,@proFee=ProcessingFee,@serviceTax=ServiceTax,@cRate=CallRate,@sRate=SmsRate from tbl_PostpaidPlans where planid=@planId";
        cmdOne.CommandType = CommandType.Text;
        cmdOne.Connection = con;

        SqlParameter SecurityAmt = new SqlParameter("@securityAmt", SqlDbType.Money);
        SecurityAmt.Direction = ParameterDirection.Output;
        SqlParameter Processing = new SqlParameter("@proFee", SqlDbType.Money);
        Processing.Direction = ParameterDirection.Output;
        SqlParameter sTax = new SqlParameter("@serviceTax", SqlDbType.Money);
        sTax.Direction = ParameterDirection.Output;
        SqlParameter cRate = new SqlParameter("@cRate", SqlDbType.VarChar, 15);
        cRate.Direction = ParameterDirection.Output;
        SqlParameter sRate = new SqlParameter("@sRate", SqlDbType.VarChar, 15);
        sRate.Direction = ParameterDirection.Output;
        SqlParameter PlanID = new SqlParameter("@planId", SqlDbType.Char, 6);
        PlanID.Direction = ParameterDirection.Input;
        PlanID.Value = planid;
        cmdOne.Parameters.Add(SecurityAmt);
        cmdOne.Parameters.Add(Processing);
        cmdOne.Parameters.Add(sTax);
        cmdOne.Parameters.Add(cRate);
        cmdOne.Parameters.Add(sRate);
        cmdOne.Parameters.Add(PlanID);
        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception ex)
        {

            throw ex;
        }

        securityAmount = Convert.ToDouble(SecurityAmt.Value);
        processingFee = Convert.ToDouble(Processing.Value);
        serviceTax = Convert.ToDouble(sTax.Value);
        callRate = cRate.Value.ToString();
        smsRate = sRate.Value.ToString();



    }
    /// <summary>
    ///  TRAINEE:7
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to Register the new  service provider with  details from Web form
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>


    public int RegisterServiceProvider(string Password, char Role, string SecurityQuestion, string SecurityAnswer, string ServiceProviderName, string ContactNumber, double PortingCharge, string Address, string LicenseNumber, out string ServiceProviderId)
    {


        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_AddNewServiceProvider";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter passw = new SqlParameter();
        passw.ParameterName = "@password";
        passw.SqlDbType = SqlDbType.VarChar;
        passw.Size = 20;
        passw.Direction = ParameterDirection.Input;
        passw.Value = Password;


        SqlParameter Rol = new SqlParameter();
        Rol.ParameterName = "@Role";
        Rol.SqlDbType = SqlDbType.Char;
        Rol.Size = 1;
        Rol.Direction = ParameterDirection.Input;
        Rol.Value = Role;


        SqlParameter Ques = new SqlParameter();
        Ques.ParameterName = "@SecurityQuestion";
        Ques.SqlDbType = SqlDbType.VarChar;
        Ques.Size = 50;
        Ques.Direction = ParameterDirection.Input;
        Ques.Value = SecurityQuestion;

        SqlParameter Ans = new SqlParameter();
        Ans.ParameterName = "@SecurityAnswer";
        Ans.SqlDbType = SqlDbType.VarChar;
        Ans.Size = 20;
        Ans.Direction = ParameterDirection.Input;
        Ans.Value = SecurityAnswer;


        SqlParameter name = new SqlParameter();
        name.ParameterName = "@ServiceProviderName";
        name.SqlDbType = SqlDbType.VarChar;
        name.Size = 25;
        name.Direction = ParameterDirection.Input;
        name.Value = ServiceProviderName;



        SqlParameter num1 = new SqlParameter();
        num1.ParameterName = "@ContactNumber";
        num1.SqlDbType = SqlDbType.VarChar;
        num1.Size = 10;
        num1.Direction = ParameterDirection.Input;
        num1.Value = ContactNumber;




        SqlParameter port = new SqlParameter();
        port.ParameterName = "@PortingCharge";
        port.SqlDbType = SqlDbType.SmallMoney;
        port.Direction = ParameterDirection.Input;
        port.Value = PortingCharge;


        SqlParameter add = new SqlParameter();
        add.ParameterName = "@Address";
        add.SqlDbType = SqlDbType.VarChar;
        add.Size = 50;
        add.Direction = ParameterDirection.Input;
        add.Value = Address;


        SqlParameter num = new SqlParameter();
        num.ParameterName = "@LicenseNumber";
        num.SqlDbType = SqlDbType.VarChar;
        num.Size = 10;
        num.Direction = ParameterDirection.Input;
        num.Value = LicenseNumber;

        SqlParameter id = new SqlParameter();
        id.ParameterName = "@ServiceProviderId";
        id.SqlDbType = SqlDbType.VarChar;
        id.Size = 5;
        id.Direction = ParameterDirection.Output;

        SqlParameter ret = new SqlParameter();
        ret.ParameterName = "@ret";
        ret.SqlDbType = SqlDbType.Int;
        ret.Direction = ParameterDirection.ReturnValue;


        cmdOne.Parameters.Add(passw);
        cmdOne.Parameters.Add(Rol);
        cmdOne.Parameters.Add(Ques);
        cmdOne.Parameters.Add(Ans);
        cmdOne.Parameters.Add(name);
        cmdOne.Parameters.Add(num1);
        cmdOne.Parameters.Add(port);
        cmdOne.Parameters.Add(add);
        cmdOne.Parameters.Add(num);
        cmdOne.Parameters.Add(id);
        cmdOne.Parameters.Add(ret);

        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            throw ex;
        }
        con.Close();


        ServiceProviderId = Convert.ToString(id.Value);


        return Convert.ToInt16(ret.Value);
    }
    /// <summary>
    /// trainee-6
    /// to launch new prepid plan
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
        int returned = 0;
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_AddPrepaidPlan";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter PlanName = new SqlParameter();
        PlanName.ParameterName = "@PlanName";
        PlanName.SqlDbType = SqlDbType.VarChar;
        PlanName.Size = 20;
        PlanName.Direction = ParameterDirection.Input;
        PlanName.Value = planname;


        SqlParameter ServiceProviderId = new SqlParameter();
        ServiceProviderId.ParameterName = "@ServiceProviderId";
        ServiceProviderId.SqlDbType = SqlDbType.Char;
        ServiceProviderId.Size = 5;
        ServiceProviderId.Direction = ParameterDirection.Input;
        ServiceProviderId.Value = serviceproviderid;


        SqlParameter PlanType = new SqlParameter();
        PlanType.ParameterName = "@PlanType";
        PlanType.SqlDbType = SqlDbType.Char;
        PlanType.Direction = ParameterDirection.Input;
        PlanType.Value = plantype;

        SqlParameter Duration = new SqlParameter();
        Duration.ParameterName = "@Duration";
        Duration.SqlDbType = SqlDbType.Int;
        Duration.Direction = ParameterDirection.Input;
        Duration.Value = duration;

        SqlParameter ProcessingFee = new SqlParameter();
        ProcessingFee.ParameterName = "@ProcessingFee";
        ProcessingFee.SqlDbType = SqlDbType.SmallMoney;
        ProcessingFee.Direction = ParameterDirection.Input;
        ProcessingFee.Value = processingfee;


        SqlParameter ServiceTax = new SqlParameter();
        ServiceTax.ParameterName = "@ServiceTax";
        ServiceTax.SqlDbType = SqlDbType.Decimal;
        ServiceTax.Direction = ParameterDirection.Input;
        ServiceTax.Value = servicetax;

        SqlParameter CallRate = new SqlParameter();
        CallRate.ParameterName = "@CallRate";
        CallRate.SqlDbType = SqlDbType.VarChar;
        CallRate.Size = 15;
        CallRate.Direction = ParameterDirection.Input;
        CallRate.Value = callrate;

        SqlParameter SmsRate = new SqlParameter();
        SmsRate.ParameterName = "@SmsRate";
        SmsRate.SqlDbType = SqlDbType.VarChar;
        SmsRate.Size = 15;
        SmsRate.Direction = ParameterDirection.Input;
        SmsRate.Value = smsrate;

        SqlParameter State = new SqlParameter();
        State.ParameterName = "@State";
        State.SqlDbType = SqlDbType.VarChar;
        State.Size = 20;
        State.Direction = ParameterDirection.Input;
        State.Value = state;

        SqlParameter PlanId = new SqlParameter();
        PlanId.ParameterName = "@PlanId";
        PlanId.SqlDbType = SqlDbType.VarChar;
        PlanId.Size = 6;
        PlanId.Direction = ParameterDirection.Output;

        SqlParameter ReturnValue = new SqlParameter();
        ReturnValue.ParameterName = "@Return";
        ReturnValue.SqlDbType = SqlDbType.Int;
        ReturnValue.Direction = ParameterDirection.ReturnValue;

        cmdOne.Parameters.Add(PlanName);
        cmdOne.Parameters.Add(ServiceProviderId);
        cmdOne.Parameters.Add(PlanType);
        cmdOne.Parameters.Add(Duration);
        cmdOne.Parameters.Add(ProcessingFee);
        cmdOne.Parameters.Add(ServiceTax);
        cmdOne.Parameters.Add(CallRate);
        cmdOne.Parameters.Add(SmsRate);
        cmdOne.Parameters.Add(State);
        cmdOne.Parameters.Add(PlanId);
        cmdOne.Parameters.Add(ReturnValue);

        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            returned = Convert.ToInt32(ReturnValue.Value);

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }
        planid = PlanId.Value.ToString();
        return returned;

    }
    /// <summary>
    /// trainee-6
    /// to get all details of  selected prepaid plan according to planid
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
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select PlanName,PlanType,Duration, ProcessingFee,ServiceTax,CallRate,SmsRate from tbl_Prepaidplans where PlanId= '" + PlanId + "'", con);
            da.Fill(dt);
            planName = (dt.Rows[0][0]).ToString();
            PlanType = Convert.ToChar(dt.Rows[0][1]);
            Duration = Convert.ToInt32(dt.Rows[0][2]);
            ProcessingFee = Convert.ToDecimal(dt.Rows[0][3]);
            ServiceTax = Convert.ToDecimal(dt.Rows[0][4]);
            CallRate = Convert.ToString(dt.Rows[0][5]);
            SmsRate = Convert.ToString(dt.Rows[0][6]);

        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
    /// <summary>
    /// trainee-6
    /// to modify prepaid plan according to planid
    /// </summary>
    /// <param name="PlanId"></param>
    /// <param name="NewPlanName"></param>
    /// <param name="NewPlanType"></param>
    /// <param name="NewDuration"></param>
    /// <param name="NewProcessingFee"></param>
    /// <param name="NewCallRate"></param>
    /// <param name="NewSmsRate"></param>
    /// <returns>integer</returns>
    public int ModifyPrepaidPlan(string PlanId, string NewPlanName, char NewPlanType, int NewDuration, decimal NewProcessingFee, string NewCallRate, string NewSmsRate)
    {
        int returned = 0;
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_UpdatePrepaidPlan";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter planid = new SqlParameter();
        planid.ParameterName = "@PlanId";
        planid.SqlDbType = SqlDbType.VarChar;
        planid.Size = 6;
        planid.Direction = ParameterDirection.Input;
        planid.Value = PlanId;



        SqlParameter PlanName = new SqlParameter();
        PlanName.ParameterName = "@NewPlanname";
        PlanName.SqlDbType = SqlDbType.VarChar;
        PlanName.Size = 20;
        PlanName.Direction = ParameterDirection.Input;
        PlanName.Value = NewPlanName;


        SqlParameter PlanType = new SqlParameter();
        PlanType.ParameterName = "@NewPlanType";
        PlanType.SqlDbType = SqlDbType.Char;
        PlanType.Size = 1;
        PlanType.Direction = ParameterDirection.Input;
        PlanType.Value = NewPlanType;




        SqlParameter Duration = new SqlParameter();
        Duration.ParameterName = "@NewDuration";
        Duration.SqlDbType = SqlDbType.Int;
        Duration.Direction = ParameterDirection.Input;
        Duration.Value = NewDuration;

        SqlParameter ProcessingFee = new SqlParameter();
        ProcessingFee.ParameterName = "@NewProcessingFee";
        ProcessingFee.SqlDbType = SqlDbType.SmallMoney;
        ProcessingFee.Direction = ParameterDirection.Input;
        ProcessingFee.Value = NewProcessingFee;




        SqlParameter CallRate = new SqlParameter();
        CallRate.ParameterName = "@NewCallRate";
        CallRate.SqlDbType = SqlDbType.VarChar;
        CallRate.Size = 15;
        CallRate.Direction = ParameterDirection.Input;
        CallRate.Value = NewCallRate;

        SqlParameter SmsRate = new SqlParameter();
        SmsRate.ParameterName = "@NewSmsRate";
        SmsRate.SqlDbType = SqlDbType.VarChar;
        SmsRate.Size = 15;
        SmsRate.Direction = ParameterDirection.Input;
        SmsRate.Value = NewSmsRate;





        SqlParameter ReturnValue = new SqlParameter();
        ReturnValue.ParameterName = "@Return";
        ReturnValue.SqlDbType = SqlDbType.Int;
        ReturnValue.Direction = ParameterDirection.ReturnValue;


        cmdOne.Parameters.Add(planid);
        cmdOne.Parameters.Add(PlanName);

        cmdOne.Parameters.Add(PlanType);
        cmdOne.Parameters.Add(Duration);
        cmdOne.Parameters.Add(ProcessingFee);

        cmdOne.Parameters.Add(CallRate);
        cmdOne.Parameters.Add(SmsRate);


        cmdOne.Parameters.Add(ReturnValue);

        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            returned = Convert.ToInt32(ReturnValue.Value);

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            con.Close();
        }

        return returned;


    }
    /// <summary>
    ///  TRAINEE:3
    /// Created On:23-Jan-2012
    /// This method is to view the feedbacks provided by the customer
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <returns></returns>
    public DataTable ViewFeedbacks(string serviceProviderId)
    {
        SqlCommand cmd = new SqlCommand(@"SELECT c.CustomerName,f.Comments,f.FeedbackDate from tbl_Feedback f INNER JOIN tbl_Customer c on c.CustomerId=f.CustomerId WHERE ServiceProviderId=@ServiceProviderId", con);
        cmd.Parameters.AddWithValue("@ServiceProviderId", serviceProviderId);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            da.Fill(dt);
        }
        catch (Exception ex)
        {

            throw ex;
        }
        return dt;
    }
    /// <summary>
    ///Created By: Trainee 4
    /// Created On: 19-Jan-2012
    /// Updating offers
    /// </summary>
    /// <param name="OfferId"></param>
    /// <param name="NewOfferName"></param>
    /// <param name="NewAmount"></param>
    /// <param name="NewDuration"></param>
    /// <param name="NewDescription"></param>
    /// <returns></returns>
    public int ModifyOffer(string OfferId, string NewOfferName, double NewAmount, int NewDuration, string NewDescription)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_UpdateOffer";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OfferId", OfferId);
        cmd.Parameters.AddWithValue("@NewOfferName", NewOfferName);
        cmd.Parameters.AddWithValue("@NewAmount", NewAmount);
        cmd.Parameters.AddWithValue("@NewDuration", NewDuration);
        cmd.Parameters.AddWithValue("@NewDescription", NewDescription);

        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(prmReturn);

        try
        {

            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
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
    /// Created By: Trainee 4
    /// Created On: 20-Jan-2012
    /// For Activating any DeactivePlan
    /// </summary>
    /// <param name="idType"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int ActivatePlanOrOffer(string idType, string ID)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_ActivatePlanOrOffer";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idType", idType);
        cmd.Parameters.AddWithValue("@ID", ID);


        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(prmReturn);

        try
        {

            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
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
    /// Created By: Trainee 4
    /// Created On: 20-Jan-2012
    /// For Deactivating any Active Plan
    /// </summary>
    /// <param name="idType"></param>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int DeactivatePlanOrOffer(string idType, string ID)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_DeactivatePlanOffer";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@idType", idType);
        cmd.Parameters.AddWithValue("@ID", ID);


        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmd.Parameters.Add(prmReturn);

        try
        {

            con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
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
    /// Created By: Trainee 8
    /// Created On: 20-Jan-2012
    /// Fetch Inactive Plans from Database
    /// </summary>
    /// <returns></returns>
    public DataTable GetInactivePlans(string ServiceID)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("Select * from tbl_postpaidplans where status='I' and ServiceProviderId=@serviceproviderId;", con);

        SqlDataAdapter sqladap = new SqlDataAdapter();
        sqladap.SelectCommand = cmd;
        cmd.Parameters.AddWithValue("@serviceproviderId", ServiceID);

        try
        {
            sqladap.Fill(dt);
        }

        catch (Exception ex)
        {

            throw ex;
        }


        return dt;
    }
    /// <summary>
    /// Created By: Trainee 8
    /// Created On: 19-Jan-2012
    /// Fetch ActivePlans from Database
    /// </summary>
    /// <returns></returns>
    public DataTable GetActivePlans(string ServiceID)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("Select * from tbl_postpaidplans where status='A' and ServiceProviderId=@serviceproviderId;", con);

        SqlDataAdapter sqladap = new SqlDataAdapter();
        sqladap.SelectCommand = cmd;
        cmd.Parameters.AddWithValue("@serviceproviderId", ServiceID);
        try
        {
            sqladap.Fill(dt);
        }
        catch (Exception ex)
        {

            throw ex;
        }


        return dt;
    }
    /// <summary>
    /// Created By: Trainee 8
    /// Created On: 19-Jan-2012
    /// To get Top Five Plans(Prepaid and Postpaid)
    /// </summary>
    /// <param name="spID"></param>
    /// <returns></returns>
    public DataTable GetTopFivePlans(string spID)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "Select * from ufn_GetTopFivePlans(@ServiceProviderId)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ServiceProviderId", spID);

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);


        try
        {
            da.Fill(dt);


        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

        }

        return dt;
    }
    /// <summary>
    /// To get Recipient ServiceProvider reports
    /// </summary>
    /// <param name="Status"></param>
    /// <param name="Fromdate"></param>
    /// <param name="Todate"></param>
    /// <param name="rSPid"></param>
    /// <returns></returns>
    public DataTable SPreportsAsaRecipient(char Status, DateTime Fromdate, DateTime Todate, string rSPid)
    {
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "select tc.CustomerName,tp.ApplicationDate,tp.ActivationDate from tbl_Porting tp inner join tbl_Customer tc on tp.CustomerId=tc.CustomerId where tp.PortStatus=@status and tp.ApplicationDate>=@fromDate and tp.ApplicationDate<=@toDate and tp.RecipientSpId=@rSPid ";

        cmdOne.CommandType = CommandType.Text;
        cmdOne.Connection = con;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmdOne;
        SqlParameter status = new SqlParameter();
        status.ParameterName = "@status";
        status.SqlDbType = SqlDbType.Char;
        status.Size = 1;
        status.Direction = ParameterDirection.Input;
        status.Value = Status;

        SqlParameter fromdate = new SqlParameter();
        fromdate.ParameterName = "@fromDate";
        fromdate.SqlDbType = SqlDbType.DateTime;
        fromdate.Direction = ParameterDirection.Input;
        fromdate.Value = Fromdate;

        SqlParameter todate = new SqlParameter();
        todate.ParameterName = "@toDate";
        todate.SqlDbType = SqlDbType.DateTime;
        todate.Direction = ParameterDirection.Input;
        todate.Value = Todate;

        SqlParameter SPid = new SqlParameter();
        SPid.ParameterName = "@rSPid";
        SPid.SqlDbType = SqlDbType.Char;
        SPid.Size = 5;
        SPid.Direction = ParameterDirection.Input;
        SPid.Value = rSPid;

        cmdOne.Parameters.Add(status);
        cmdOne.Parameters.Add(fromdate);
        cmdOne.Parameters.Add(todate);
        cmdOne.Parameters.Add(SPid);
        try
        {
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;

    }
    /// <summary>
    /// For getting Service Provider reports for Donor
    /// </summary>
    /// <param name="Fromdate"></param>
    /// <param name="Todate"></param>
    /// <param name="dSPid"></param>
    /// <returns></returns>
    public DataTable SPreportsAsaDonor(DateTime Fromdate, DateTime Todate, string dSPid)
    {
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "select tc.CustomerName,tp.ApplicationDate,tp.Reason from tbl_Porting tp inner join tbl_Customer tc on tp.CustomerId=tc.CustomerId where tp.ApplicationDate>=@fromDate and tp.ApplicationDate<=@toDate and tp.DonorSpId=@dSPid ";

        cmdOne.CommandType = CommandType.Text;
        cmdOne.Connection = con;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmdOne;

        SqlParameter fromdate = new SqlParameter();
        fromdate.ParameterName = "@fromDate";
        fromdate.SqlDbType = SqlDbType.DateTime;
        fromdate.Direction = ParameterDirection.Input;
        fromdate.Value = Fromdate;

        SqlParameter todate = new SqlParameter();
        todate.ParameterName = "@toDate";
        todate.SqlDbType = SqlDbType.DateTime;
        todate.Direction = ParameterDirection.Input;
        todate.Value = Todate;

        SqlParameter SPid = new SqlParameter();
        SPid.ParameterName = "@dSPid";
        SPid.SqlDbType = SqlDbType.Char;
        SPid.Size = 5;
        SPid.Direction = ParameterDirection.Input;
        SPid.Value = dSPid;


        cmdOne.Parameters.Add(fromdate);
        cmdOne.Parameters.Add(todate);
        cmdOne.Parameters.Add(SPid);
        try
        {
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dt;

    }
    /// <summary>
    /// trainee-6
    /// to get active prepaid plan details
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
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select PlanName,PlanType,Duration, ProcessingFee,ServiceTax,CallRate,SmsRate,State from tbl_Prepaidplans where PlanId= '" + PlanId + "'", con);
            da.Fill(dt);
            planName = (dt.Rows[0][0]).ToString();
            PlanType = Convert.ToChar(dt.Rows[0][1]);
            Duration = Convert.ToInt32(dt.Rows[0][2]);
            ProcessingFee = Convert.ToDecimal(dt.Rows[0][3]);
            ServiceTax = Convert.ToDecimal(dt.Rows[0][4]);
            CallRate = Convert.ToString(dt.Rows[0][5]);
            SmsRate = Convert.ToString(dt.Rows[0][6]);
            state = Convert.ToString(dt.Rows[0][7]);
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    /// <summary>
    /// trainee-6
    /// to activate selected prepaidplan
    /// </summary>
    /// <param name="idtype"></param>
    /// <param name="planid"></param>
    /// <returns>integer</returns>
    public int ActivatePrepaidPlan(string idtype, string planid)
    {
        int returned = 0;
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_ActivatePlanOrOffer";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter itype = new SqlParameter();
        itype.ParameterName = "@idType";
        itype.SqlDbType = SqlDbType.VarChar;
        itype.Size = 2;
        itype.Direction = ParameterDirection.Input;
        itype.Value = idtype;

        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@ID";
        pid.SqlDbType = SqlDbType.VarChar;
        pid.Size = 20;
        pid.Direction = ParameterDirection.Input;
        pid.Value = planid;


        SqlParameter ReturnValue = new SqlParameter();
        ReturnValue.ParameterName = "@Return";
        ReturnValue.SqlDbType = SqlDbType.Int;
        ReturnValue.Direction = ParameterDirection.ReturnValue;

        cmdOne.Parameters.Add(itype);
        cmdOne.Parameters.Add(pid);

        cmdOne.Parameters.Add(ReturnValue);
        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            returned = Convert.ToInt32(ReturnValue.Value);
            con.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return returned;


    }
    /// <summary>
    /// trainee-6
    /// to get details of inactive prepaidplan
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
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("Select PlanName,PlanType,Duration, ProcessingFee,ServiceTax,CallRate,SmsRate,State from tbl_Prepaidplans where PlanId= '" + PlanId + "'", con);
        da.Fill(dt);
        planName = (dt.Rows[0][0]).ToString();
        PlanType = Convert.ToChar(dt.Rows[0][1]);
        Duration = Convert.ToInt32(dt.Rows[0][2]);
        ProcessingFee = Convert.ToDecimal(dt.Rows[0][3]);
        ServiceTax = Convert.ToDecimal(dt.Rows[0][4]);
        CallRate = Convert.ToString(dt.Rows[0][5]);
        SmsRate = Convert.ToString(dt.Rows[0][6]);
        state = Convert.ToString(dt.Rows[0][7]);
    }
    /// <summary>
    /// trainee-6
    /// to deactivate selected prepaid plan
    /// </summary>
    /// <param name="idtype"></param>
    /// <param name="planid"></param>
    /// <returns>integer</returns>
    public int DeactivatePrepaidPlan(string idtype, string planid)
    {
        int returned = 0;
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_DeactivatePlanOffer";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;

        SqlParameter itype = new SqlParameter();
        itype.ParameterName = "@idType";
        itype.SqlDbType = SqlDbType.VarChar;
        itype.Size = 2;
        itype.Direction = ParameterDirection.Input;
        itype.Value = idtype;

        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@ID";
        pid.SqlDbType = SqlDbType.VarChar;
        pid.Size = 20;
        pid.Direction = ParameterDirection.Input;
        pid.Value = planid;


        SqlParameter ReturnValue = new SqlParameter();
        ReturnValue.ParameterName = "@Return";
        ReturnValue.SqlDbType = SqlDbType.Int;
        ReturnValue.Direction = ParameterDirection.ReturnValue;

        cmdOne.Parameters.Add(itype);
        cmdOne.Parameters.Add(pid);

        cmdOne.Parameters.Add(ReturnValue);
        try
        {
            con.Open();
            cmdOne.ExecuteNonQuery();
            returned = Convert.ToInt32(ReturnValue.Value);
            con.Close();
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return returned;


    }
    /// <summary>
    /// trainee-6
    /// to get all inactive prepaid plans
    /// </summary>
    /// <returns>datatable</returns>
    public DataTable GetInactivePrepaidPlans(string spid)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("Select PlanName,PlanId from tbl_prepaidplans where status='I' and ServiceProviderId=@ID", con);
        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@ID";
        pid.SqlDbType = SqlDbType.VarChar;
        pid.Size = 20;
        pid.Direction = ParameterDirection.Input;
        pid.Value = spid;
        cmd.Parameters.Add(pid);
        SqlDataAdapter sqladap = new SqlDataAdapter();
        sqladap.SelectCommand = cmd;
        try
        {
            sqladap.Fill(dt);
        }

        catch (Exception ex)
        {

            throw ex;
        }


        return dt;
    }
    /// <summary>
    /// trainee-6
    /// to get all active prepaid plans
    /// </summary>
    /// <returns>datatable</returns>
    public DataTable GetActivePrepaidPlans(string spid)
    {
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("Select PlanName,PlanId from tbl_prepaidplans where status='A'and ServiceProviderId=@ID", con);
        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@ID";
        pid.SqlDbType = SqlDbType.VarChar;
        pid.Size = 20;
        pid.Direction = ParameterDirection.Input;
        pid.Value = spid;
        cmd.Parameters.Add(pid);
        SqlDataAdapter sqladap = new SqlDataAdapter();
        sqladap.SelectCommand = cmd;
        try
        {
            sqladap.Fill(dt);
        }

        catch (Exception ex)
        {

            throw ex;
        }


        return dt;
    }



    ///<summary>
    ///  TRAINEE:7
    /// this Method is use to get the planId according to state,plantype and providerId
    /// </summary>
    /// <param name="State"></param>
    /// <param name="PlanType"></param>
    /// <param name="ServiceProviderId"></param>
    /// <returns></returns>

    public DataTable GetPlan(string State, string PlanType, string ServiceProviderId)
    {
        DataTable dt = new DataTable();

        if (PlanType == "Postpaid")
        {
            SqlCommand cmdEmp = new SqlCommand("select distinct pp.PlanName,pp.PlanId from tbl_PostpaidPlans pp inner join tbl_ServiceProvider sp On (pp.ServiceProviderId=sp.ServiceProviderId) where State='" + State + "' and pp.ServiceProviderId='" + ServiceProviderId + "'", con);

            cmdEmp.Connection = con;

            SqlDataAdapter daEmp = new SqlDataAdapter();
            daEmp.SelectCommand = cmdEmp;
            try
            {
                daEmp.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex; 
            }

        }

        else if (PlanType == "Prepaid")
        {
            SqlCommand cmdEmp = new SqlCommand("select distinct pp.PlanName,pp.PlanId from tbl_PrepaidPlans pp inner join tbl_ServiceProvider sp On (pp.ServiceProviderId=sp.ServiceProviderId) where State='" + State + "' and pp.ServiceProviderId='" + ServiceProviderId + "'", con);

            cmdEmp.Connection = con;

            SqlDataAdapter daEmp = new SqlDataAdapter();
            daEmp.SelectCommand = cmdEmp;
            try
            {
                daEmp.Fill(dt);
            }
            catch (Exception ex)
            {

                throw ex; 
            }

        }


        return dt;
    }
    /// <summary>
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:DonorServiceProviderGridViewBL
    /// This method is used to populate the DonorServiceProvider GridView
    ///<returns>DataTAble containing the values</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable DonorServiceProviderGridView()
    {
        
        //try block
        try
        {//creating datatable object
            DataTable dataTableDonorObj = new DataTable();
            //command object
            SqlCommand cmdDonorGV = new SqlCommand("SELECT P.PortingId,C.CustomerName,P.Reason FROM tbl_UpcDetails U INNER JOIN tbl_Porting P ON P.UniquePortingCode=U.UniquePortingCode INNER JOIN tbl_Customer C ON C.CustomerId=P.CustomerId WHERE PortStatus='S'", con);
            //dataadaptor object
            SqlDataAdapter sqlAdaptorObj = new SqlDataAdapter(cmdDonorGV);
            //filling datatable
            sqlAdaptorObj.Fill(dataTableDonorObj);
            //return value
            return dataTableDonorObj;
        }
            //catch block
        catch (Exception ex)
        {            
            throw ex;
        }
    }
  
    public DataTable GetActivePlan()
    {
        DataTable dtObj = new DataTable();
        SqlDataAdapter adapObj = new SqlDataAdapter("SELECT * FROM tbl_PostpaidPlans where Status='A'", con);
        try
        {
            adapObj.Fill(dtObj);
        }
        catch (SqlException)
        {
            dtObj = null;

        }
        catch (FormatException)
        {
            dtObj = null;
        }
        catch (Exception)
        {
            dtObj = null;
        }
        return dtObj;
    }

    /// <summary>
    ///  TRAINEE:7
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the prepaid plans details for Prepaid 
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetPrepPlans(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE pr.State='" + State + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ", con);

        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  TRAINEE:7
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the prepaid plans details for Postpaid
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetPostPlans(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE ps.State='" + State + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  TRAINEE:7
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the post plans details for Postpaid when status is selected as mode to filter 
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetPostStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE Status='" + Status + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }
    /// <summary>
    ///  TRAINEE:7
    /// Created On: 19-Jan-2012
    /// SpHomepage3-Method to get the post plans details for Postpaid when status is selected as mode to filter 
    /// </summary>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable GetPrepStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE Status='" + Status + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }

    /// <summary>
    /// To Get Offers
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetOffersState(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT OfferName,State,Amount,Duration,Description,Status From tbl_Offers WHERE State='" + State + "'", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }

    /// <summary>
    /// To get Offers by Status
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetOffersStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT OfferName,State,Amount,Duration,Description,Status From tbl_Offers WHERE Status='" + Status + "'", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }

    /// <summary>
    /// To get Customer Details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPrepCustState(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE pr.State='" + State + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ORDER BY COUNT(CurrentPlanId) DESC", con);

        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;

    }
    /// <summary>
    /// To Get Plan Details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPostCustState(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE ps.State='" + State + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status ORDER BY COUNT(CurrentPlanId) DESC", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    /// To get customer Details
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPrepCustStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE Status='" + Status + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ORDER BY COUNT(CurrentPlanId) DESC ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }

    /// <summary>
    /// To get customer details
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPostCustStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE Status='" + Status + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status ORDER BY COUNT(CurrentPlanId) DESC", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }

    /// <summary>
    ///To get customer details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPrepProState(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE pr.State='" + State + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ORDER BY ProcessingFee DESC", con);

        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }

    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:RecipientServiceProviderGridViewBL
    /// This method is used to populate the RecipientServiceProvider GridView
    ///<returns>DataTAble containing the values</returns>
    [DataObjectMethod(DataObjectMethodType.Select)]
    public DataTable RecipientServiceProviderGridView()
    {
        //try block
        try
        {
            //datatable object
            DataTable dataTableRecipientObj = new DataTable();
            //command object
            SqlCommand cmdRecipientGV = new SqlCommand("select p.PortingId,c.CustomerName,p.Reason,pp.PlanName from tbl_UpcDetails u inner join tbl_Porting p on p.UniquePortingCode=u.UniquePortingCode inner join tbl_Customer c on c.CustomerId=p.CustomerId inner join tbl_PrepaidPlans pp on pp.PlanId=c.CurrentPlanId where PortStatus IN ('P','F') UNION select p.PortingId ,c.CustomerName ,p.Reason,pp.PlanName from tbl_UpcDetails u inner join tbl_Porting p on p.UniquePortingCode=u.UniquePortingCode inner join tbl_Customer c on c.CustomerId=p.CustomerId inner join tbl_PostpaidPlans pp on pp.PlanId=c.CurrentPlanId where PortStatus IN ('P','F') ", con);
            //adaptor object
            SqlDataAdapter sqlAdaptorObj = new SqlDataAdapter(cmdRecipientGV);
            //filling datatable
            sqlAdaptorObj.Fill(dataTableRecipientObj);
            //returns value
            return dataTableRecipientObj;
        }
            //catch block
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:DonorServiceProviderDetailsViewBL
    /// This method is used to populate the DonorServiceProvider DetailsView
    ///<returns>DataTAble containing the values</returns>
    public DataTable DonorServiceProviderDetailsViewDAL(string portingId)
    {
        //try block
        try
        {
            //datatable object
            DataTable dataTableDonorObj = new DataTable();
            //command object
            SqlCommand cmdDonorDV = new SqlCommand("select P.PortingId,C.CustomerName,P.Reason,P.ApplicationDate,P.UniquePortingCode,PP.PlanName,C.MobileNumber FROM tbl_Porting P INNER JOIN tbl_Customer C ON P.CustomerId=C.CustomerId INNER JOIN tbl_PostpaidPlans PP ON P.PlanId=PP.PlanId INNER JOIN tbl_UpcDetails U ON C.CustomerId=U.CustomerId WHERE PortStatus IN ('S') AND PortingId=@PortingId UNION select P.PortingId,C.CustomerName,P.Reason,P.ApplicationDate,P.UniquePortingCode,PP.PlanName,C.MobileNumber FROM tbl_Porting P INNER JOIN tbl_Customer C ON P.CustomerId=C.CustomerId INNER JOIN tbl_PrepaidPlans PP ON P.PlanId=PP.PlanId INNER JOIN tbl_UpcDetails U ON C.CustomerId=U.CustomerId WHERE PortStatus IN ('S') AND PortingId=@PortingId", con);
            cmdDonorDV.Parameters.AddWithValue("@PortingId", portingId);
            //adaptor object
            SqlDataAdapter sqlAdaptorObj = new SqlDataAdapter(cmdDonorDV);
            //filling datatable
            sqlAdaptorObj.Fill(dataTableDonorObj);
            //returns value
            return dataTableDonorObj;
        }
            //catch block
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:RecipientServiceProviderDetailsViewBL
    /// This method is used to populate the RecipientServiceProviderDetailsView
    ///<returns>DataTAble containing the values</returns>
    public DataTable RecipientServiceProviderDetailsViewDAL(string portingId)
    {
        //try block
        try
        {
            //datatable instance
            DataTable dataTableRecipientObj = new DataTable();
            //commmand object
            SqlCommand cmdRecipientDV = new SqlCommand("select p.PortingId,c.customerName,p.reason,p.ApplicationDate,u.UniquePortingCode,pp.PlanName,c.MobileNumber,c.addressline1,c.addressline2,c.state,c.zipcode from tbl_Customer c join tbl_Porting p on p.customerid=c.customerid join tbl_PostpaidPlans pp on pp.PlanId=p.PlanId join tbl_UpcDetails u on u.customerid=c.customerid  where PortStatus in ('P','F') and PortingId =@PortingId UNION select p.PortingId,c.customerName,p.reason,p.ApplicationDate,u.UniquePortingCode,pp.PlanName,c.MobileNumber,c.addressline1,c.addressline2,c.state,c.zipcode from tbl_Customer c join tbl_Porting p on p.customerid=c.customerid join tbl_PrepaidPlans pp on pp.PlanId=p.PlanId join tbl_UpcDetails u on u.customerid=c.customerid  where PortStatus in ('P','F') and PortingId =@PortingId", con);
            cmdRecipientDV.Parameters.AddWithValue("@PortingId", portingId);
            //adaptor object
            SqlDataAdapter sqlAdaptorObj = new SqlDataAdapter(cmdRecipientDV);
            //filling datatable
            sqlAdaptorObj.Fill(dataTableRecipientObj);
            //returns value
            return dataTableRecipientObj;
        }
            //catch block
        catch (Exception ex)
        {            
            throw ex;
        }
    }
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:GetStatusBL
    /// This method is used to get status
    ///<returns>character containing status value</returns>
    public char GetStatusDAL(string portingId)
    {
        char retStatus;
        //command object
        SqlCommand cmdchkStatus = new SqlCommand("Select PortStatus  from tbl_Porting  where PortingId =@PortingId", con);
        cmdchkStatus.Parameters.AddWithValue("@PortingId", portingId);
        //try block
        try
        {
            //open connection
            con.Open();
            retStatus = Convert.ToChar(cmdchkStatus.ExecuteScalar());
        }
            //catch block
        catch (Exception ex)
        {
            throw ex;
        }
            //finally block
        finally
        {
            //close connection
            con.Close();
        }
        //return status
        return retStatus;
    }
    /// TRAINEE:1
    /// Date:20/1/2012
    /// Method Name:updatePortStatusBL
    /// This method is used to get status
    ///<returns>character containing status value</returns>
    public int updatePortStatusDAL(string PortingId, string Role, string Activity, string Comments)
    {
        int ret;
        //command object
        SqlCommand cmdupdatePortStatus = new SqlCommand("usp_UpdatePortingStatus", con);
        cmdupdatePortStatus.CommandType = CommandType.StoredProcedure;
        //new parameter
        SqlParameter prmPortingId = new SqlParameter("@PortingId", SqlDbType.Char, 5);
        prmPortingId.Value = PortingId;
        //new parameter
        SqlParameter prmRole = new SqlParameter("@Role", SqlDbType.Char, 3);
        prmRole.Value = Role;
        //new parameter
        SqlParameter prmActivity = new SqlParameter("@Activity", SqlDbType.VarChar, 10);
        prmActivity.Value = Activity;
        //new parameter
        SqlParameter prmComments = new SqlParameter("@Comments", SqlDbType.VarChar, 100);
        prmComments.Value = Comments;
        //new parameter
        SqlParameter prmReturn = new SqlParameter("@ReturnType", SqlDbType.Int);
        prmReturn.Direction = ParameterDirection.ReturnValue;
        //adding parameters
        cmdupdatePortStatus.Parameters.Add(prmPortingId);
        cmdupdatePortStatus.Parameters.Add(prmRole);
        cmdupdatePortStatus.Parameters.Add(prmActivity);
        cmdupdatePortStatus.Parameters.Add(prmComments);
        cmdupdatePortStatus.Parameters.Add(prmReturn);
        //try block
        try
        {
            //open connection
            con.Open();
            cmdupdatePortStatus.ExecuteNonQuery();
        }
            //catch block
        catch (Exception ex)
        {
            throw ex;
        }
            //finally block
        finally
        {
            //close connection
            con.Close();
        }

        ret = Convert.ToInt32(prmReturn.Value);
        return ret;
    }
    /// <summary>
    /// To Get the Plan details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPostProState(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE ps.State='" + State + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status ORDER BY ProcessingFee DESC", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  To Get the Plan details
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPrepProStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE Status='" + Status + "' GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ORDER BY ProcessingFee DESC ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  To Get the Plan details
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPostProStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  WHERE Status='" + Status + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status ORDER BY ProcessingFee DESC", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  To Get the Plan details
    /// </summary>
    /// <returns></returns>
    public DataTable GetPrepPlans()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;

    }
     /// <summary>
    ///  To Get the Plan details
     /// </summary>
     /// <returns></returns>
    public DataTable GetPost()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  To Get the Customer details
    /// </summary>
    /// <returns></returns>
    public DataTable GetPrepfees()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status ORDER BY ProcessingFee DESC  ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;


    }
    /// <summary>
    /// To Get the Customer details
    /// </summary>
    /// <returns></returns>
    public DataTable GetPostfees()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status ORDER BY ProcessingFee DESC", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  To Get the Customer details
    /// </summary>
    /// <returns></returns>
    public DataTable GetPrepCusts()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status  ORDER BY COUNT(CurrentPlanId) DESC  ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;


    }
    /// <summary>
    ///  To Get the Customer details
    /// </summary>
    /// <returns></returns>
    public DataTable GetPostCusts()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId  GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status ORDER BY COUNT(CurrentPlanId) DESC", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }
    /// <summary>
    ///  To Get the Customer details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPostStates(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId WHERE ps.State='" + State + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return dtObj;
    }

    /// <summary>
    /// To get Postpaid status
    /// </summary>
    /// <param name="Status"></param>
    /// <returns></returns>
    public DataTable GetPostpaidStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId) as'Customer Count', PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status from tbl_PostpaidPlans ps INNER JOIN tbl_Customer c ON c.CurrentPlanId=ps.PlanId WHERE Status='" + Status + "' GROUP BY CurrentPlanId , PlanName,SecurityAmount,ServiceTax,ProcessingFee,CallRate,SmsRate,ps.State,Status", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }
    /// <summary>
    /// To get the PrepaidPlans details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPrepStates(string State)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE pr.State='" + State + "'GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status", con);


        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }
    /// <summary>
    /// To get the PrepaidPlans details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable GetPrepaidStatus(string Status)
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT COUNT(CurrentPlanId)as 'Customer Count',PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status FROM tbl_PrepaidPlans pr  INNER JOIN tbl_Customer c  ON  c.CurrentPlanId=pr.PlanId WHERE pr.Status='" + Status + "'GROUP BY CurrentPlanId,PlanName,PlanType,Duration,ProcessingFee,ServiceTax,CallRate,SmsRate,pr.State,Status", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }
    /// <summary>
    /// To get the Offers details
    /// </summary>
    /// <param name="State"></param>
    /// <returns></returns>
    public DataTable Getoffers()
    {
        SqlDataAdapter daObj = new SqlDataAdapter("SELECT OfferName,State,Amount,Duration,Description,Status From tbl_Offers ", con);
        DataTable dtObj = new DataTable();
        try
        {
            daObj.Fill(dtObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtObj;
    }
}









