using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class Online_Portinf_Form : System.Web.UI.Page
{
    CustomerBL CustobjBl = new CustomerBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {
      
        if (Convert.ToChar(Session["Role"].ToString()) != 'C')
        {
            Response.Redirect("AccessDenied.aspx");
        }
        else
        {
            

            DataTable dtobjCustomerDetails = new DataTable();
            DataTable dtobjServicePNameAndCurrentPName = new DataTable();
            DataTable dtAvailableAllPlans = new DataTable();



              //  Session["UserId"] = "C0001";
               // Session["UPC"] = "UPCC0001001";
                int request = 0;
                request = CustobjBl.CheckUpcRequestOfCustomer(Session["CustomerId"].ToString(), Session["UPC"].ToString());
                if (request == 0)
                {
                    Logger.Write("Onlin Porting Form Page Load successful");
                    dtobjCustomerDetails = CustobjBl.GetAllCustomerDetails(Session["CustomerId"].ToString());
                    lblId.Text = dtobjCustomerDetails.Rows[0][0].ToString();
                    lblName.Text = dtobjCustomerDetails.Rows[0][1].ToString();
                    lblAddress1.Text = dtobjCustomerDetails.Rows[0][2].ToString();
                    lblAddress2.Text = dtobjCustomerDetails.Rows[0][3].ToString();
                    lblMobileNumber.Text = dtobjCustomerDetails.Rows[0][4].ToString();
                    lblState.Text = dtobjCustomerDetails.Rows[0][5].ToString();

                    dtobjServicePNameAndCurrentPName = CustobjBl.GetSPNameAndCurrentPlanNameForCustomer(Session["CustomerId"].ToString());

                    lblPlan.Text = dtobjServicePNameAndCurrentPName.Rows[0][0].ToString();
                    lblServiceProvider.Text = dtobjServicePNameAndCurrentPName.Rows[0][1].ToString();


                    lblUPC.Text = Session["UPC"].ToString();


                }
                else if (request > 0)
                {

                    string serviceproviderpName;
                    string planType;
                    string planName;

                    dtobjCustomerDetails = CustobjBl.GetAllCustomerDetails(Session["CustomerId"].ToString());


                    lblId.Text = dtobjCustomerDetails.Rows[0][0].ToString();
                    lblName.Text = dtobjCustomerDetails.Rows[0][1].ToString();
                    lblAddress1.Text = dtobjCustomerDetails.Rows[0][2].ToString();
                    lblAddress2.Text = dtobjCustomerDetails.Rows[0][3].ToString();
                    lblMobileNumber.Text = dtobjCustomerDetails.Rows[0][4].ToString();
                    lblState.Text = dtobjCustomerDetails.Rows[0][5].ToString();

                    dtobjServicePNameAndCurrentPName = CustobjBl.GetSPNameAndCurrentPlanNameForCustomer(Session["CustomerId"].ToString());
                    lblPlan.Text = dtobjServicePNameAndCurrentPName.Rows[0][0].ToString();
                    lblServiceProvider.Text = dtobjServicePNameAndCurrentPName.Rows[0][1].ToString();


                    lblUPC.Text = Session["UPC"].ToString();

                    CustobjBl.GetCustomerDetailsForNotUPC(Session["CustomerId"].ToString(), Session["UPC"].ToString(), out serviceproviderpName, out planName, out planType);
                    ddlServiceProvider.Items.Add(serviceproviderpName);
                    ddlServiceProvider.SelectedIndex = 1;
                    if (planType.Equals("Postpaid"))
                    {
                        rblPlanType.SelectedIndex = 1;
                    }
                    else if (planType.Equals("Prepaid"))
                    {
                        rblPlanType.SelectedIndex = 0;
                    }
                    ddlAvailablePlans.Items.Add(planName);
                    ddlAvailablePlans.SelectedIndex = 1;



                    ddlServiceProvider.Enabled = false;
                    rblPlanType.Enabled = false;
                    ddlAvailablePlans.Enabled = false;
                    btnSubmit.Enabled = false;
                }
            }
          
        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
        catch (InvalidOperationException)
        {

            lblStatus.Visible = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Server is down try after some time";
            
           
        }
    }
    
    protected void ddlServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtobj = new DataTable();
      //Session["UserId"] = "C0001";
        try
        {
            dtobj = CustobjBl.GetSPNameAndCurrentPlanNameForCustomer(Session["CustomerId"].ToString());

            if (ddlServiceProvider.SelectedValue.ToString().Equals(dtobj.Rows[0][1].ToString()))
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "The New Service Provider Cannot be same as the current serviceprovider";
                //Response.Write("<script>alert('The New Service Provider Cannot be same as the current serviceprovider')</script>");
            }
        }
        catch (InvalidOperationException)
        {
            
            
            lblStatus.Visible = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Server is down try after some time";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string portingId = "";
        DataTable dtobjSpId = new DataTable();
        dtobjSpId = CustobjBl.GetSPNameAndCurrentPlanNameForCustomer(Session["CustomerId"].ToString());
        string sid = dtobjSpId.Rows[0][2].ToString();
        try
        {
            int returnval = CustobjBl.AddPortingRequest(lblUPC.Text, lblId.Text, sid, ddlServiceProvider.SelectedValue.ToString(), ddlAvailablePlans.SelectedValue.ToString(), txtReason.Text, out portingId);

            if (returnval == 0)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;

                lblStatus.Text = "Sucessfull!Porting Id is" + portingId;

            }

            else if (returnval == -1)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid CustomerId";

            }

            else if (returnval == -2)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;

                lblStatus.Text = "Invalid Donor SP ID";

            }

            else if (returnval == -3)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;

                lblStatus.Text = "Invalid Recipient SP Id";

            }

            else if (returnval == -4)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Donor Id and Recipient Id Should not be same";
            }

            else if (returnval == -5)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;

                lblStatus.Text = "Exception occured";

            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("Customer oneline porting form loaded");
            Response.Redirect("Error.aspx");
            //lblStatus.Visible = true;
            //lblStatus.ForeColor = System.Drawing.Color.Red;
            //lblStatus.Text = "Server is down try after some time";
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
            Response.Redirect("CustomerMyRequests.aspx");
        
        
    }
    protected void rblPlanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAvailablePlans.Items.Clear();
        ddlAvailablePlans.Items.Add("--Select--");
        DataTable dtAvailablePlans = new DataTable();
        try
        {
            dtAvailablePlans = CustobjBl.AvailableAllPlans(ddlServiceProvider.SelectedValue.ToString(), lblState.Text, rblPlanType.SelectedValue.ToString());
            ddlAvailablePlans.DataSource = dtAvailablePlans;
            ddlAvailablePlans.DataTextField = "PlanName";
            ddlAvailablePlans.DataValueField = "PlanId";
            ddlAvailablePlans.DataBind();
        }
        catch (InvalidOperationException)
        {

            Logger.Write("Customer oneline porting form loaded");
            Response.Redirect("Error.aspx");
            //lblStatus.Visible = true;
            //lblStatus.ForeColor = System.Drawing.Color.Red;
            //lblStatus.Text = "Server is down try after some time";
        }
    }

    protected void cvNewServiceProvider_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (btnSubmit.Enabled == true)
        {
            if (ddlServiceProvider.SelectedValue != lblServiceProvider.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

    }
}
