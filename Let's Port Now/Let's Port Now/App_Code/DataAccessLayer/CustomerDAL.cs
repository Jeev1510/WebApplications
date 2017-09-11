using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
/// <summary>
/// Summary description for CustomerDAL
/// </summary>
public class CustomerDAL
{
    //Declaration of connection object
    SqlConnection con;
    //Default constructor
    public CustomerDAL()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        //
        // TODO: Add constructor logic here
        //
    }




    /// <summary>
    ///  TRAINEE:3
    /// Created On:20-Jan-2012
    ///To get the customer details on the fields when the page is loaded
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>DataTable</returns>
    public DataTable GetCustomerDetails(string userId)
    {
        //Declaration of datatable object
        DataTable CustDt = new DataTable();
        //Declaration of command object
        SqlCommand cmdDa = new SqlCommand(@"SELECT CustomerName,AddressLine1,AddressLine2,ZipCode FROM tbl_Customer where UserId=@userId", con);
        cmdDa.Parameters.AddWithValue("@userId", userId);
        //Declaration of dataadapter
        SqlDataAdapter custDa = new SqlDataAdapter();
        custDa.SelectCommand = cmdDa;
        //try block
        try
        {
            custDa.Fill(CustDt);
        }
        //catch block
        catch (SqlException ex)
        {
            CustDt = null;
            throw ex;
        }

        return CustDt;
    }

    /// <summary>
    /// Trainee-6
    /// get details for prepaid plan 
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="state"></param>
    /// <returns>datatable</returns>
    public DataTable GetPrepaidPlanDetails(string ServiceProviderId, string state)
    {
        //Declaration of datatable 
        DataTable dtplanDetails = new DataTable();
        //Declaration of command object
        SqlCommand cmdEmp = new SqlCommand("Select sp.ServiceProviderName,pp.PlanName,pp.PlanType,pp.Duration,pp.ProcessingFee,pp.ServiceTax,pp.CallRate,pp.SmsRate from tbl_PrepaidPlans pp inner join  tbl_ServiceProvider sp On(pp.ServiceProviderId=sp.ServiceProviderId) where pp.ServiceProviderId=@ServiceProvider and pp.State=@State", con);

        cmdEmp.Connection = con;
        cmdEmp.CommandType = CommandType.Text;
        //adding parameters
        SqlParameter spId = new SqlParameter();
        spId.ParameterName = "@ServiceProvider";
        spId.Value = ServiceProviderId;
        spId.SqlDbType = SqlDbType.VarChar;
        SqlParameter st = new SqlParameter();
        st.ParameterName = "@State";
        st.Value = state;
        st.SqlDbType = SqlDbType.VarChar;
        cmdEmp.Parameters.Add(spId);
        cmdEmp.Parameters.Add(st);
        SqlDataAdapter daEmp = new SqlDataAdapter();
        daEmp.SelectCommand = cmdEmp;
        //try block
        try
        {
            daEmp.Fill(dtplanDetails);
        }
        //catch block
        catch (SqlException ex)
        {

            dtplanDetails = null;
            throw ex;
        }
        return dtplanDetails;
    }
    /// <summary>
    /// Trainee-6
    /// get details for postpaid plan 
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="state"></param>
    /// <returns>datatable</returns>
    public DataTable GetPostpaidPlanDetails(string ServiceProviderId, string state)
    {
        //Declaration of datatable object
        DataTable dtplanDetails = new DataTable();
        //Declaration of command object
        SqlCommand cmdEmp = new SqlCommand("Select sp.ServiceProviderName,pp.PlanName,pp.ProcessingFee,pp.ServiceTax,pp.CallRate,pp.SmsRate from tbl_PostpaidPlans pp inner join  tbl_ServiceProvider sp On(pp.ServiceProviderId=sp.ServiceProviderId) where pp.ServiceProviderId=@ServiceProvider and pp.State=@Stat", con);

        cmdEmp.Connection = con;
        cmdEmp.CommandType = CommandType.Text;
        //adding parameters
        SqlParameter spId = new SqlParameter();
        spId.ParameterName = "@ServiceProvider";
        spId.Value = ServiceProviderId;
        spId.SqlDbType = SqlDbType.VarChar;
        SqlParameter st = new SqlParameter();
        st.ParameterName = "@Stat";
        st.Value = state;
        st.SqlDbType = SqlDbType.VarChar;
        cmdEmp.Parameters.Add(spId);
        cmdEmp.Parameters.Add(st);
        //Declaration of dataadapter object
        SqlDataAdapter daEmp = new SqlDataAdapter();
        daEmp.SelectCommand = cmdEmp;
        //try block
        try
        {
            daEmp.Fill(dtplanDetails);
        }
        //catch block
        catch (SqlException ex)
        {
            dtplanDetails = null;
            throw ex;
        }
        return dtplanDetails;
    }

    /// <summary>
    /// Trainee-6
    /// get details for offers 
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="State"></param>
    /// <returns>datatable</returns>
    public DataTable GetOfferDetails(string ServiceProviderId, string State)
    {
        //Declaration of datatable object
        DataTable dtofferDetails = new DataTable();
        //Declaration of command object
        SqlCommand cmdEmp = new SqlCommand("Select o.OfferName,sp.ServiceProviderName,o.State,o.Amount,o.Duration,o.Description from tbl_Offers o inner join  tbl_ServiceProvider sp On(o.ServiceProviderId=sp.ServiceProviderId) where o.ServiceProviderId=@ServiceProvider and o.State=@State", con);

        cmdEmp.Connection = con;
        cmdEmp.CommandType = CommandType.Text;
        //adding parameters
        SqlParameter spId = new SqlParameter();
        spId.ParameterName = "@ServiceProvider";
        spId.Value = ServiceProviderId;
        spId.SqlDbType = SqlDbType.VarChar;
        SqlParameter st = new SqlParameter();
        st.ParameterName = "@State";
        st.Value = State;
        st.SqlDbType = SqlDbType.VarChar;
        cmdEmp.Parameters.Add(spId);
        cmdEmp.Parameters.Add(st);
        //Declaration of dataadapter object
        SqlDataAdapter daEmp = new SqlDataAdapter();
        daEmp.SelectCommand = cmdEmp;
        //try block
        try
        {
            daEmp.Fill(dtofferDetails);
        }
        //catch block
        catch (SqlException ex)
        {
            dtofferDetails = null;
            throw ex;
        }
        return dtofferDetails;
    }



    //to get the provider names according to plan type
    //public DataTable GetServiceProviderId(string PlanType)
    //{


    //    DataTable dtplanDetails = new DataTable();

    //    SqlCommand cmdEmp = new SqlCommand("Select o.OfferName,sp.ServiceProviderName,o.State,o.Amount,o.Duration,o.Description from tbl_Offers o inner join  tbl_ServiceProvider sp On(o.ServiceProviderId=sp.ServiceProviderId) where o.ServiceProviderId=@ServiceProvider and o.State=@State", con);

    //    cmdEmp.Connection = con;
    //    cmdEmp.CommandType = CommandType.Text;
    //    SqlParameter spId = new SqlParameter();
    //    spId.ParameterName = "@ServiceProvider";
    //    spId.Value = ServiceProviderId;
    //    spId.SqlDbType = SqlDbType.VarChar;
    //    SqlParameter st = new SqlParameter();
    //    st.ParameterName = "@State";
    //    st.Value = State;
    //    st.SqlDbType = SqlDbType.VarChar;
    //    cmdEmp.Parameters.Add(spId);
    //    cmdEmp.Parameters.Add(st);
    //    SqlDataAdapter daEmp = new SqlDataAdapter();
    //    daEmp.SelectCommand = cmdEmp;
    //    try
    //    {
    //        SqlCommand cmdEmp = new SqlCommand("Select sp.ServiceProviderName from tbl_PrepaidPlans pp inner join  tbl_ServiceProvider sp On(pp.ServiceProviderId=sp.ServiceProviderId) where Status='A' ", con);

    //        cmdEmp.Connection = con;

    //        SqlDataAdapter daEmp = new SqlDataAdapter();
    //        daEmp.SelectCommand = cmdEmp;
    //        try
    //        {
    //            daEmp.Fill(dtplanDetails);
    //        }
    //        catch (Exception)
    //        {
    //        }

    //        SqlDataAdapter daCurrent = new SqlDataAdapter();
    //        daCurrent.SelectCommand = cmdCurrentService;
    //        try
    //        {
    //            daCurrent.Fill(dtCurrent);
    //        }
    //        catch (Exception ex)
    //        {

    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }

    //        return Convert.ToInt32(prmReturn.Value);
    //    }
    // }

    /// <summary>
    ///  TRAINEE:3
    /// Created on:20-Jan-2012
    /// To Update Customer Details in the Customer Table
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="newCustomerName"></param>
    /// <param name="newAddressLine1"></param>
    /// <param name="newAddressLine2"></param>
    /// <param name="zipCode"></param>
    /// <returns>Integer value</returns>
    public int UpdateCustomerDetails(string customerId, string newCustomerName, string newAddressLine1, string newAddressLine2, string zipCode)
    {
        //Declaration of command object
        SqlCommand cmdUpdate = new SqlCommand();
        cmdUpdate.Connection = con;

        cmdUpdate.CommandText = "usp_UpdateCustomerDetails";
        cmdUpdate.CommandType = CommandType.StoredProcedure;

        cmdUpdate.Parameters.AddWithValue("@CustomerId", customerId);
        cmdUpdate.Parameters.AddWithValue("@NewCustomerName", newCustomerName);
        cmdUpdate.Parameters.AddWithValue("@NewAddressLine1", newAddressLine1);
        cmdUpdate.Parameters.AddWithValue("@NewAddressLine2", newAddressLine2);
        cmdUpdate.Parameters.AddWithValue("@NewZipCode", zipCode);
        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;
        cmdUpdate.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            cmdUpdate.ExecuteNonQuery();
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
    /// TRAINEE:7
    /// To Register for a new Customer
    /// </summary>
    /// <param name="Password"></param>
    /// <param name="Role"></param>
    /// <param name="SecurityQuestion"></param>
    /// <param name="SecurityAnswer"></param>
    /// <param name="CustomerName"></param>
    /// <param name="AddressLine1"></param>
    /// <param name="AddressLine2"></param>
    /// <param name="State"></param>
    /// <param name="ZipCode"></param>
    /// <param name="MobileNumber"></param>
    /// <param name="CurrentPlanId"></param>
    /// <param name="CustomerId"></param>
    /// <returns></returns>
    public int RegisterCustomer(string Password, char Role, string SecurityQuestion, string SecurityAnswer, string CustomerName, string AddressLine1, string AddressLine2, string State, string ZipCode, string MobileNumber, string CurrentPlanId, out string CustomerId)
    {
        //Declaration of command object
        SqlCommand cmdOne = new SqlCommand();
        cmdOne.CommandText = "usp_AddNewCustomer";
        cmdOne.CommandType = CommandType.StoredProcedure;
        cmdOne.Connection = con;
        //adding parameters
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
        name.ParameterName = "@CustomerName";
        name.SqlDbType = SqlDbType.VarChar;
        name.Size = 25;
        name.Direction = ParameterDirection.Input;
        name.Value = CustomerName;

        SqlParameter add1 = new SqlParameter();
        add1.ParameterName = "@AddressLine1";
        add1.SqlDbType = SqlDbType.VarChar;
        add1.Size = 25;
        add1.Direction = ParameterDirection.Input;
        add1.Value = AddressLine1;

        SqlParameter add2 = new SqlParameter();
        add2.ParameterName = "@AddressLine2";
        add2.SqlDbType = SqlDbType.VarChar;
        add2.Size = 25;
        add2.Direction = ParameterDirection.Input;
        add2.Value = AddressLine2;

        SqlParameter state = new SqlParameter();
        state.ParameterName = "@State";
        state.SqlDbType = SqlDbType.VarChar;
        state.Size = 20;
        state.Direction = ParameterDirection.Input;
        state.Value = State;

        SqlParameter zip = new SqlParameter();
        zip.ParameterName = "@ZipCode";
        zip.SqlDbType = SqlDbType.Char;
        zip.Size = 6;
        zip.Direction = ParameterDirection.Input;
        zip.Value = ZipCode;

        SqlParameter num = new SqlParameter();
        num.ParameterName = "@MobileNumber";
        num.SqlDbType = SqlDbType.Char;
        num.Size = 10;
        num.Direction = ParameterDirection.Input;
        num.Value = MobileNumber;

        SqlParameter id = new SqlParameter();
        id.ParameterName = "@CurrentPlanId";
        id.SqlDbType = SqlDbType.Char;
        id.Size = 6;
        id.Direction = ParameterDirection.Input;
        id.Value = CurrentPlanId;

        SqlParameter cusid = new SqlParameter();
        cusid.ParameterName = "@CustomerId";
        cusid.SqlDbType = SqlDbType.Char;
        cusid.Size = 5;
        cusid.Direction = ParameterDirection.Output;

        SqlParameter ret = new SqlParameter();
        ret.ParameterName = "@ret";
        ret.SqlDbType = SqlDbType.Int;
        ret.Direction = ParameterDirection.ReturnValue;

        cmdOne.Parameters.Add(passw);
        cmdOne.Parameters.Add(Rol);
        cmdOne.Parameters.Add(Ques);
        cmdOne.Parameters.Add(Ans);
        cmdOne.Parameters.Add(name);
        cmdOne.Parameters.Add(add1);
        cmdOne.Parameters.Add(add2);
        cmdOne.Parameters.Add(state);
        cmdOne.Parameters.Add(zip);
        cmdOne.Parameters.Add(num);
        cmdOne.Parameters.Add(id);
        cmdOne.Parameters.Add(cusid);
        cmdOne.Parameters.Add(ret);
        //try block
        try
        {
            con.Open();
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
        CustomerId = cusid.Value.ToString();

        return Convert.ToInt16(ret.Value);
    }



    /// <summary>
    /// TRAINEE:4
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <param name="ServiceProviderId"></param>
    /// <param name="Comments"></param>
    /// <returns></returns>
    public int GiveFeedback(string CustomerId, string ServiceProviderId, string Comments)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_AddFeedback";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
        cmd.Parameters.AddWithValue("@ServiceProviderId", ServiceProviderId);
        cmd.Parameters.AddWithValue("@Comments", Comments);

        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
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
    ///  TRAINEE:3
    /// Created On:21-Jan-2012
    /// TO get the Current ServiceProvider in a label when the Page is loaded
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public string CurrentServiceProvider(string userId)
    {
        //Declaring a string variable
        string currentservice;
        //Declaration of command object
        SqlCommand cmd = new SqlCommand(@"SELECT ServiceProviderName FROM tbl_ServiceProvider WHERE ServiceProviderId IN
         (SELECT ServiceProviderId FROM tbl_PrepaidPlans WHERE PlanId IN (SELECT CurrentPlanId FROM tbl_Customer WHERE UserId=@userId) UNION SELECT ServiceProviderId FROM tbl_PostpaidPlans WHERE PlanId IN (SELECT CurrentPlanId FROM tbl_Customer WHERE UserId=@userId))");
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserId", userId);
        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            currentservice = cmd.ExecuteScalar().ToString();
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

        return currentservice;
    }

    /// <summary>
    ///  TRAINEE:3
    /// Created On:21-Jan-2012
    /// TO get the Current Plan in a label when the Page is loaded
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>String value</returns>
    public string CurrentPlan(string userId)
    {
        //Declaring string variable
        string currentplan;
        //Declaration of command object
        SqlCommand cmd = new SqlCommand(@"SELECT PlanName from tbl_PrepaidPlans where PlanId in (SELECT CurrentPlanId FROM tbl_Customer  WHERE UserId=@userId)
UNION SELECT PlanName from tbl_PostpaidPlans where PlanId in (SELECT CurrentPlanId FROM tbl_Customer  WHERE UserId=@userId)");
        cmd.Connection = con;

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@UserId", userId);
        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            currentplan = cmd.ExecuteScalar().ToString();
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

        return currentplan;
    }
    /// <summary>
    ///  TRAINEE:3
    /// Created On:21-Jan-2012
    /// To populate the data table with the Last Porting Details 
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <returns>DataTable</returns>
    public DataTable GetLastPortingDetails(string customerId)
    {
        //Declaration of datatable object
        DataTable lastDt = new DataTable();
        //Declaration of command object
        SqlCommand cmdLast = new SqlCommand(@"SELECT TOP(1)  p.PortingId,sp1.ServiceProviderName as DonorServiceProvider  ,sp2.ServiceProviderName as RecipientServiceProvider ,p.ApplicationDate,p.ActivationDate from ufn_RetrieveCustomerRequests(@customerId) p INNER JOIN tbl_ServiceProvider sp1 on sp1.ServiceProviderId=p.DonorSpId JOIN tbl_ServiceProvider sp2 on sp2.ServiceProviderId=p.RecipientSpId where PortStatus='X' or PortStatus='P' ORDER BY ActivationDate DESC");
        cmdLast.Connection = con;
        cmdLast.Parameters.AddWithValue("@customerId", customerId);
        //Declaration of dataadapter object
        SqlDataAdapter daLast = new SqlDataAdapter();
        daLast.SelectCommand = cmdLast;
        //try block
        try
        {
            daLast.Fill(lastDt);
        }
        //catch block
        catch (SqlException ex)
        {
            lastDt = null;
            throw ex;
        }
        return lastDt;
    }



    //Here start the methods for Compare Plans Page
    /// <summary>
    ///  TRAINEE:5
    /// Created On: 20-Jan-2012
    /// ComparePlansPage1-Method to populate the CheckBoxList with ServiceProviderNames based on selected Plan type
    /// </summary>
    /// <param name="PlanType"></param>
    /// <returns></returns>
    public DataTable GetServiceProviderList(string planType)
    {
        //Declaration of datatable object
        DataTable dtServiceProviders = new DataTable();
        //try block
        try
        {
            if (planType == "Prepaid")
            {
                //Declaration of command object
                SqlCommand cmdServiceProviders = new SqlCommand("SELECT * From tbl_ServiceProvider WHERE ServiceProviderId IN (Select ServiceProviderId FROM tbl_PrepaidPlans)", con);
                //Declaration of dataadapter object
                SqlDataAdapter daServiceProviders = new SqlDataAdapter(cmdServiceProviders);
                daServiceProviders.Fill(dtServiceProviders);
            }
            else if (planType == "Postpaid")
            {
                SqlCommand cmdServiceProviders = new SqlCommand("SELECT * From tbl_ServiceProvider WHERE ServiceProviderId IN (Select ServiceProviderId FROM tbl_PostpaidPlans)", con);
                SqlDataAdapter daServiceProviders = new SqlDataAdapter(cmdServiceProviders);
                daServiceProviders.Fill(dtServiceProviders);
            }
            return dtServiceProviders;
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
    }


    /// <summary>
    ///  TRAINEE:5
    /// Created On: 20-Jan-2012
    /// ComparePlansPage2-Method to populate the Plan1 and Plan2 DropDownLists with PlanNames according to Plan type and
    ///ServiceProviderNames selected by user
    /// </summary>
    /// <param name="planType"></param>
    /// <param name="serviceProviderId"></param>
    /// <returns></returns>
    public DataTable PopulatePlansddl(string planType, string serviceProviderId)
    {
        //Declaration of datatable object
        DataTable dtPlans = new DataTable();
        //try block
        try
        {
            if (planType == "Prepaid")
            {
                //Declaration of command object
                SqlCommand cmdPlans = new SqlCommand("Select PlanName,PlanId from tbl_PrepaidPlans WHERE ServiceProviderId=@serviceProviderId", con);
                //Declaration of dataadapter object
                SqlDataAdapter daServiceProviders = new SqlDataAdapter(cmdPlans);
                //adding parameters
                SqlParameter param = new SqlParameter();
                cmdPlans.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
                daServiceProviders.Fill(dtPlans);
            }
            else if (planType == "Postpaid")
            {
                //Declaration of command object
                SqlCommand cmdPlans = new SqlCommand("Select PlanName,PlanId from tbl_PostpaidPlans WHERE ServiceProviderId=@serviceProviderId", con);
                //Declaration of dataadapter object
                SqlDataAdapter daServiceProviders = new SqlDataAdapter(cmdPlans);
                //adding parameters
                SqlParameter param = new SqlParameter();
                cmdPlans.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
                daServiceProviders.Fill(dtPlans);
            }
            return dtPlans;
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
    }


    /// <summary>
    ///  TRAINEE:5
    /// Created On: 20-Jan-2012
    /// ComparePlansPage3-Method to populate the Comparison Grid with PlanDetails according to Plan type,ServiceProviderNames
    /// and plans selected by user
    /// </summary>
    /// <param name="planType"></param>
    /// <param name="serviceProviderId"></param>
    /// <param name="PlanId"></param>
    /// <returns>DataTable</returns>
    public DataTable GetComparisonGrid(string planType, string planId1, string planId2)
    {
        //Declaration of datatable object
        DataTable dtComparisonGrid = new DataTable();
        //try block
        try
        {
            if (planType == "Prepaid")
            {
                //declaration of command object
                SqlCommand cmdComparisonGrid = new SqlCommand("Select s.ServiceProviderName,pr.PlanName,pr.PlanType,pr.Duration,pr.ProcessingFee,pr.ServiceTax,pr.CallRate,pr.SmsRate,State From tbl_PrepaidPlans pr INNER JOIN tbl_ServiceProvider s ON pr.ServiceProviderId=s.ServiceProviderId  WHERE PlanId IN (@planId1,@planId2)", con);
                //Declaration of dataadapter object
                SqlDataAdapter daComparisonGrid = new SqlDataAdapter(cmdComparisonGrid);
                //adding parameters
                SqlParameter param = new SqlParameter();
                //cmdComparisonGrid.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
                cmdComparisonGrid.Parameters.AddWithValue("@planId1", planId1);
                cmdComparisonGrid.Parameters.AddWithValue("@planId2", planId2);
                daComparisonGrid.Fill(dtComparisonGrid);
            }
            else if (planType == "Postpaid")
            {
                SqlCommand cmdComparisonGrid = new SqlCommand("Select s.ServiceProviderName,ps.PlanName,ps.ProcessingFee,ps.ServiceTax,ps.SecurityAmount,ps.CallRate,ps.SmsRate,ps.State FROM tbl_PostpaidPlans ps INNER JOIN tbl_ServiceProvider s ON ps.ServiceProviderId=s.ServiceProviderId  WHERE PlanId IN (@planId1,@planId2)", con);
                SqlDataAdapter daComparisonGrid = new SqlDataAdapter(cmdComparisonGrid);
                SqlParameter param = new SqlParameter();
                //cmdComparisonGrid.Parameters.AddWithValue("@serviceProviderId", serviceProviderId);
                cmdComparisonGrid.Parameters.AddWithValue("@planId1", planId1);
                cmdComparisonGrid.Parameters.AddWithValue("@planId2", planId2);
                daComparisonGrid.Fill(dtComparisonGrid);
            }
            return dtComparisonGrid;
        }
        //catch block
        catch (SqlException ex)
        {
            throw ex;
        }
    }



    /// <summary>
    /// TRAINEE:3
    /// Created on:22-Jan-2012
    /// To populate the data table with the Pending Payments 
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    public DataTable PendingPayments(string customerId)
    {
        //Declaration of datatable object
        DataTable lastDt = new DataTable();
        //Declaration of command object
        SqlCommand cmdLast = new SqlCommand(@"SELECT p.PortingId,p.UniquePortingCode,sp1.ServiceProviderName as DonorServiceProvider,sp2.ServiceProviderName as RecipientServiceProvider,p.ApplicationDate,(SELECT PlanName from tbl_PrepaidPlans where PlanId=p.PlanId AND PortStatus='A' UNION SELECT planName from tbl_PostpaidPlans where PlanId=p.PlanId AND PortStatus='A') as PlanName from tbl_Porting p INNER JOIN tbl_ServiceProvider sp1 on sp1.ServiceProviderId=DonorSpId JOIN tbl_ServiceProvider sp2 on sp2.ServiceProviderId=RecipientSpId where CustomerId=@customerId AND PortStatus='A'");
        cmdLast.Connection = con;
        cmdLast.Parameters.AddWithValue("@customerId", customerId);
        //Declaration of dataadapter object
        SqlDataAdapter daLast = new SqlDataAdapter();
        daLast.SelectCommand = cmdLast;
        //try block
        try
        {
            daLast.Fill(lastDt);
        }
        //catch block
        catch (SqlException ex)
        {
            lastDt = null;
            throw ex;
        }
        return lastDt;
    }




    /// <summary>
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// To get the porting details by  customerId
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <returns></returns>
    public DataTable GetPortingDetails(string customerId)
    {
        //Declaration of DataTable object
        DataTable dtPorting = new DataTable();
        SqlCommand cmdPorting = new SqlCommand(@"SELECT  p.PortingId as PortingId,dsp.ServiceProviderName as DonorServiceProvider ,rsp.ServiceProviderName as RecipientServiceProvider ,p.PortStatus as PortStatus from tbl_Porting p INNER JOIN tbl_ServiceProvider dsp ON dsp.ServiceProviderId=p.DonorSpId JOIN tbl_ServiceProvider rsp ON rsp.ServiceProviderId=p.RecipientSpId WHERE CustomerId=@CustomerId ");
        cmdPorting.Connection = con;
        cmdPorting.CommandType = CommandType.Text;
        cmdPorting.Parameters.AddWithValue("@CustomerId", customerId);
        //Declaration of DataAdapter object
        SqlDataAdapter daPorting = new SqlDataAdapter();
        daPorting.SelectCommand = cmdPorting;
        //try block
        try
        {
            daPorting.Fill(dtPorting);
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

        return dtPorting;
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
        //Declaration of DataTable object
        DataTable dtPorting = new DataTable();
        SqlCommand cmdPorting = new SqlCommand(@"SELECT * from tbl_Porting  WHERE PortingId=@PortingId");
        cmdPorting.Connection = con;
        cmdPorting.CommandType = CommandType.Text;
        cmdPorting.Parameters.AddWithValue("@PortingId", portingId);
        //Declaration of DataAdapter object
        SqlDataAdapter daPorting = new SqlDataAdapter();
        daPorting.SelectCommand = cmdPorting;
        //try block
        try
        {
            daPorting.Fill(dtPorting);
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

        return dtPorting;
    }

    /// <summary>
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// To update the porting status in the porting table
    /// </summary>
    /// <param name="PortingId"></param>
    /// <param name="Role"></param>
    /// <param name="Activity"></param>
    /// <param name="Comments"></param>
    /// <returns></returns>
    public int UpdatePortingStatus(string portingId, string role, string activity, string comments)
    {
        //Declaration of command object
        SqlCommand cmdPortStatus = new SqlCommand();
        cmdPortStatus.Connection = con;

        cmdPortStatus.CommandText = "usp_UpdatePortingStatus";
        cmdPortStatus.CommandType = CommandType.StoredProcedure;
        cmdPortStatus.Parameters.AddWithValue("@PortingId", portingId);
        cmdPortStatus.Parameters.AddWithValue("@Role", role);
        cmdPortStatus.Parameters.AddWithValue("@Activity", activity);
        cmdPortStatus.Parameters.AddWithValue("@Comments", comments);
        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        cmdPortStatus.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            cmdPortStatus.ExecuteNonQuery();
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
    /// TRAINEE 2
    /// Created on:23-Jan-2012
    /// To generate new UPC
    /// </summary>
    /// <param name="CustomerId"></param>
    /// <param name="UniquePortingCode"></param>
    /// <returns></returns>
    public int GenerateUpc(string CustomerId, out string UniquePortingCode)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;

        cmd.CommandText = "usp_AddNewUpc";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

        //adding parameters
        SqlParameter prmReturn = new SqlParameter();
        prmReturn.Direction = ParameterDirection.ReturnValue;

        SqlParameter prmOut = new SqlParameter();
        prmOut.ParameterName = "@UniquePortingCode";
        prmOut.Direction = ParameterDirection.Output;
        prmOut.Size = 11;
        prmOut.SqlDbType = SqlDbType.VarChar;

        cmd.Parameters.Add(prmOut);
        cmd.Parameters.Add(prmReturn);
        //try block
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            UniquePortingCode = prmOut.Value.ToString();

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
    /// Trainee-6
    /// To check availability for online porting request
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="upc"></param>
    /// <returns>integer</returns>
    public int CheckUpcRequestOfCustomer(string customerId, string upc)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM tbl_Porting p JOIN  tbl_UpcDetails u ON(u.CustomerId=p.CustomerId) WHERE p.CustomerId='" + customerId + "' AND p.UniquePortingCode='" + upc + "'", con);

        cmd.CommandType = CommandType.Text;
        Object returnval = null;
        //try block
        try
        {
            con.Open();
            returnval = cmd.ExecuteScalar();
        }
        //catch block
        catch (SqlException)
        {
            returnval = null;
        }
        //finally block
        finally
        {
            con.Close();
        }

        return Convert.ToInt32(returnval);
    }
    /// <summary>
    /// Trainee-6
    /// To get details of customer
    /// </summary>
    /// <param name="cutomerId"></param>
    /// <returns>datatable</returns>
    public DataTable GetAllCustomerDetails(string cutomerId)
    {
        //Declaration of datatable object
        DataTable dtObj = new DataTable();
        //Declaration of dataadapter object
        SqlDataAdapter adapObj = new SqlDataAdapter(@"SELECT CustomerId,CustomerName,AddressLine1,AddressLine2,MobileNumber,State FROM tbl_Customer WHERE CustomerId='" + cutomerId + "'", con);
        //try block
        try
        {
            adapObj.Fill(dtObj);
        }
        //catch block
        catch (SqlException)
        {
            dtObj = null;
        }
        return dtObj;
    }

    /// <summary>
    /// Trainee-6
    /// To get serviceprovider name,serviceproviderid and plan name
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns>datatable</returns>
    public DataTable GetSPNameAndCurrentPlanNameForCustomer(string customerId)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM tbl_Customer WHERE CurrentPlanId IN(SELECT PlanId FROM tbl_PostpaidPlans) AND CustomerId='" + customerId + "'", con);
        //Declaration of datatable object
        DataTable dtPname = new DataTable();
        int returnval = 0;
        //try block
        try
        {
            con.Open();
            returnval = Convert.ToInt32(cmd.ExecuteScalar());
        }
        //finally block
        finally
        {
            con.Close();
        }

        if (returnval > 0)
        {
            //Declaration of dataadapter object
            SqlDataAdapter daObj = new SqlDataAdapter(@"SELECT PlanName,ServiceProviderName,p.ServiceProviderId FROM tbl_PostpaidPlans p JOIN tbl_Customer c ON CurrentPlanId=PlanId JOIN tbl_ServiceProvider s ON s.ServiceProviderId=p.ServiceProviderId WHERE CustomerId='" + customerId + "'", con);
            //try block
            try
            {
                daObj.Fill(dtPname);
            }
            //catch block
            catch (SqlException)
            {
                dtPname = null;
            }
        }

        else if (returnval == 0)
        {
            //Declaration of dataadapter object
            SqlDataAdapter daObj = new SqlDataAdapter(@"SELECT PlanName,ServiceProviderName,p.ServiceProviderId FROM tbl_PrepaidPlans p JOIN tbl_Customer c ON CurrentPlanId=PlanId JOIN tbl_ServiceProvider s ON s.ServiceProviderId=p.ServiceProviderId WHERE CustomerId='" + customerId + "'", con);
            //try block
            try
            {
                daObj.Fill(dtPname);
            }
            //catch block
            catch (SqlException)
            {
                dtPname = null;
            }
        }

        return dtPname;
    }

    /// <summary>
    /// Trainee-6
    /// To get details of serviceProviderName,Planname for given customerid
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="upc"></param>
    /// <param name="serviceProviderName"></param>
    /// <param name="planName"></param>
    /// <param name="planType"></param>

    public void GetCustomerDetailsForNotUPC(string customerId, string upc, out string serviceProviderName, out string planName, out string planType)
    {
        //Declaration of command object
        SqlCommand cmdproname = new SqlCommand(@"SELECT ServiceProviderName FROM tbl_Porting p JOIN tbl_ServiceProvider s ON s.ServiceProviderId=p.RecipientSpId WHERE CustomerId='" + customerId + "' AND UniquePortingCode='" + upc + "'", con);

        cmdproname.CommandType = CommandType.Text;
        planName = "";
        planType = "";
        //try block
        try
        {
            con.Open();
            serviceProviderName = cmdproname.ExecuteScalar().ToString();
        }
        //finally block
        finally
        {
            con.Close();
        }

        if (serviceProviderName != null)
        {
            //declaration of command object
            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM tbl_Porting WHERE PlanId IN (SELECT PlanId FROM tbl_PostpaidPlans) AND CustomerId='" + customerId + "' AND UniquePortingCode='" + upc + "'", con);
            int returnval = 0;
            //try block
            try
            {
                con.Open();
                returnval = Convert.ToInt32(cmd.ExecuteScalar());
            }
            //finally block
            finally
            {
                con.Close();
            }

            if (returnval > 0)
            {
                planType = "Postpaid";
                //Declaration of command object
                SqlCommand cplanName = new SqlCommand(@"SELECT PlanName FROM tbl_Porting p JOIN tbl_PostpaidPlans pp ON p.PlanId=pp.PlanId AND CustomerId='" + customerId + "' AND UniquePortingCode='" + upc + "'", con);
                //try block
                try
                {
                    con.Open();
                    planName = Convert.ToString(cplanName.ExecuteScalar());
                }
                //catch block
                catch (SqlException)
                {
                    planName = null;
                }
                //finally block
                finally
                {
                    con.Close();
                }
            }

            else if (Convert.ToInt32(returnval) == 0)
            {
                planType = "Prepaid";
                //Declaration of command object
                SqlCommand cmdPlanName = new SqlCommand(@"SELECT PlanName FROM tbl_Porting p JOIN tbl_PrepaidPlans pp ON p.PlanId=pp.PlanId AND CustomerId='" + customerId + "' AND UniquePortingCode='" + upc + "'", con);
                //try block
                try
                {
                    con.Open();
                    planName = Convert.ToString(cmdPlanName.ExecuteScalar());
                }
                //catch block
                catch (SqlException)
                {
                    planName = null;
                }
            }
        }
    }


    /// <summary>
    /// Trainee-6
    /// to get all plans according to  ServiceProviderId,state,planType
    /// </summary>
    /// <param name="ServiceProviderId"></param>
    /// <param name="state"></param>
    /// <param name="planType"></param>
    /// <returns>datatable</returns>
    public DataTable AvailableAllPlans(string ServiceProviderId, string state, string planType)
    {
        //Declaration of datatable object
        DataTable dtAplans = new DataTable();
        if (planType.Equals("Postpaid"))
        {
            //Declaration of command object
            SqlCommand cmd = new SqlCommand(@"SELECT PlanName,PlanId FROM tbl_PostpaidPlans WHERE ServiceProviderId=@ServiceProviderId AND State=@State", con);
            //adding parameters
            SqlParameter pServiceProviderId = new SqlParameter();
            pServiceProviderId.ParameterName = "@ServiceProviderId";
            pServiceProviderId.SqlDbType = SqlDbType.Char;
            pServiceProviderId.Size = 11;
            pServiceProviderId.Value = ServiceProviderId;

            SqlParameter pState = new SqlParameter();
            pState.ParameterName = "@State";
            pState.SqlDbType = SqlDbType.VarChar;
            pState.Size = 20;
            pState.Value = state;

            cmd.Parameters.Add(pServiceProviderId);
            cmd.Parameters.Add(pState);
            //Declaration of dataadapter object
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //try block
            try
            {
                da.Fill(dtAplans);
            }
            //catch block
            catch (SqlException)
            {
                dtAplans = null;
            }
        }

        else if (planType.Equals("Prepaid"))
        {
            //Declaration of command object
            SqlCommand cmd = new SqlCommand(@"SELECT PlanName,PlanId FROM tbl_PrepaidPlans WHERE ServiceProviderId=@ServiceProviderId AND State=@State", con);
            //adding parameters
            SqlParameter pServiceProviderId = new SqlParameter();
            pServiceProviderId.ParameterName = "@ServiceProviderId";
            pServiceProviderId.SqlDbType = SqlDbType.Char;
            pServiceProviderId.Size = 11;
            pServiceProviderId.Value = ServiceProviderId;

            SqlParameter pState = new SqlParameter();
            pState.ParameterName = "@State";
            pState.SqlDbType = SqlDbType.VarChar;
            pState.Size = 20;
            pState.Value = state;

            cmd.Parameters.Add(pServiceProviderId);
            cmd.Parameters.Add(pState);
            //Declaration of dataadapter object
            SqlDataAdapter daObj = new SqlDataAdapter(cmd);
            //try block
            try
            {
                daObj.Fill(dtAplans);
            }
            //catch block
            catch (SqlException)
            {
                dtAplans = null;
            }
        }

        return dtAplans;
    }
    /// <summary>
    /// Trainee-6
    /// to add new porting request 
    /// </summary>
    /// <param name="uniquePortingCode"></param>
    /// <param name="customerId"></param>
    /// <param name="donorSpId"></param>
    /// <param name="RecipientSpId"></param>
    /// <param name="planId"></param>
    /// <param name="reason"></param>
    /// <param name="portingId"></param>
    /// <returns>Integer</returns>
    public int AddPortingRequest(string uniquePortingCode, string customerId, string donorSpId, string RecipientSpId, string planId, String reason, out string portingId)
    {
        //Declaration of command object
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "usp_AddPortingRequest";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;

        //adding parameters
        SqlParameter pUPC = new SqlParameter();
        cmd.Parameters.AddWithValue("@UniquePortingCode", uniquePortingCode);
        cmd.Parameters.AddWithValue("@CustomerId", customerId);
        cmd.Parameters.AddWithValue("@DonorSpId", donorSpId);
        cmd.Parameters.AddWithValue("@RecipientSpId", RecipientSpId);
        cmd.Parameters.AddWithValue("@PlanId", planId);
        cmd.Parameters.AddWithValue("@Reason", reason);

        SqlParameter pPortingId = new SqlParameter();
        pPortingId.Direction = ParameterDirection.Output;
        pPortingId.ParameterName = "@PortingId";
        pPortingId.SqlDbType = SqlDbType.VarChar;
        pPortingId.Size = 5;

        SqlParameter preturn = new SqlParameter();
        preturn.Direction = ParameterDirection.ReturnValue;
        preturn.SqlDbType = SqlDbType.Int;

        cmd.Parameters.Add(pPortingId);
        cmd.Parameters.Add(preturn);
        //try block
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            portingId = pPortingId.Value.ToString();
        }
        //catch block
        catch (SqlException)
        {
            portingId = null;
        }
        return Convert.ToInt32(preturn.Value);
    }
}





