using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
public partial class SPLaunchModifyActivateDeactivatePrepaid : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"].ToString() != "S")
        {
            Response.Redirect("AccessDenied.aspx");
        }
        ServiceProviderBL spbl = new ServiceProviderBL();
     
        string spID = spbl.GetServiceProviderId(Session["UserId"].ToString());
        Session["serviceproviderid"] = spID;
      
    }
    protected void lbLaunch_Click(object sender, EventArgs e)
    {
       
        lblStatus.Text = "";
        ddlStatePlans.Items.Clear();
        ddlStatePlans.Items.Add("--Select--");
        txtCallRate.Text = "";
        txtPlanName.Text = "";
        txtProcessingFee.Text = "";
        txtServiceTax.Enabled = true;
        txtServiceTax.Text = "";
        txtSmsRate.Text = "";
      
        Common commobj = new Common();
        
            DataTable dt = commobj.GetStates();
            ddlStatePlans.DataSource = dt;

            ddlStatePlans.DataValueField = "State";
            ddlStatePlans.DataTextField = "State";
            ddlStatePlans.DataBind();
            Panel1.Visible = true;
            Panel2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
            lblStatePlan.Text = "State";
            lblPlanName.Visible = true;
            txtPlanName.Visible = true;
            btnLaunchModify.Text = "Launch";
     
  


    }
    protected void btnLaunch_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
       try 
	{	        
		 if (btnLaunchModify.Text == "Launch")
        {
            string spID = Session["serviceproviderid"].ToString();
            ServiceProviderBL spbl = new ServiceProviderBL();
            string PlanID;
            int returnvalue;
            if (rblType.SelectedValue.Equals("TopUp"))
            {
                char plantype = 'T';

                int duration = 0;
                txtDuration.Enabled = false;
                returnvalue = spbl.LaunchPrepaidPlan(txtPlanName.Text, spID, plantype, duration, Convert.ToDouble(txtProcessingFee.Text), Convert.ToDouble(txtServiceTax.Text), txtCallRate.Text, txtSmsRate.Text, ddlStatePlans.SelectedValue.ToString(), out PlanID);
                if (returnvalue == 0)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Plan Successfully Launched with PlanID: " + PlanID;
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -1)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Invalid State";
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -2)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Invalid PlanType ";
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -3)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Invalid Duration";
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -4)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Some Error Occur";
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
            }
            else if (rblType.SelectedValue.Equals("Validity"))
            {
                char plantype = 'V';
                txtDuration.EnableViewState = true;
                int duration = Convert.ToInt32(txtDuration.Text);


                returnvalue = spbl.LaunchPrepaidPlan(txtPlanName.Text, spID, plantype, duration, Convert.ToDouble(txtProcessingFee.Text), Convert.ToDouble(txtServiceTax.Text), txtCallRate.Text, txtSmsRate.Text, ddlStatePlans.SelectedValue.ToString(), out PlanID);

                if (returnvalue == 0)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Plan Successfully Launched with PlanID: " + PlanID ;
            
                    
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -1)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Invalid State";
                   
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -2)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Invalid PlanType ";
                   
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -3)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Invalid Duration";
                   
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
                else if (returnvalue == -4)
                {
                    lblStatus.Visible = true;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Some Error Occur";
                
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
            }
        }
        else if (btnLaunchModify.Text == "Modify")
        {
            ServiceProviderBL spbl = new ServiceProviderBL();
            string name = txtPlanName.Text;
            char plantype = 'a';
            if (rblType.SelectedValue.Equals("TopUp"))
            {
                plantype = 'T';

            }
            else if (rblType.SelectedValue.Equals("Validity"))
            {
                plantype = 'V';
            }
            int duration = Convert.ToInt32(txtDuration.Text);
            decimal processfee = Convert.ToDecimal(txtProcessingFee.Text);
            string callrate = txtCallRate.Text;
            string smsrate = txtSmsRate.Text;
            int returnval;
            string PlanId = ddlStatePlans.SelectedValue.ToString();
            returnval = spbl.ModifyPrepaidPlan(PlanId, name, plantype, duration, processfee, callrate, smsrate);
            if (returnval == 0)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Plan update Successfully ";
            
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else if (returnval == -1)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid dauation for plan type T ";
               
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else if (returnval == -2)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid Duration for plan type V ";
               
               
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else if (returnval == -3)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid PlanId";
           
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else if (returnval == -4)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Some Error Occur";
              
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }
       }
	
	catch (Exception)
       {
           Logger.Write("sp launch modify prepaid plans page loaded");
        Response.Redirect("Error.aspx");
        //lblStatus.Visible = true;
        //lblStatus.ForeColor = System.Drawing.Color.Red;
        //lblStatus.Text = "Server is down try after some time";
	
	}
        }

    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
    }

    protected void lbModify_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        ddlStatePlans.Items.Clear();
        ddlStatePlans.Items.Add("--Select--");
        txtCallRate.Text = "";
        txtPlanName.Text = "";
        txtProcessingFee.Text = "";
        txtServiceTax.Enabled = false;
        txtServiceTax.Text = "";
        txtSmsRate.Text = "";
        try
        {
            Common commobj = new Common();
            string spid = Session["serviceproviderid"].ToString();
            DataTable dt = commobj.GetPrepaidPlan(spid);
            ddlStatePlans.DataSource = dt;

            ddlStatePlans.DataValueField = "Planid";
            ddlStatePlans.DataTextField = "PlanName";
            ddlStatePlans.DataBind();
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            lblStatePlan.Text = "Plan";
            ddlStatePlans.AutoPostBack = true;
            lblPlanName.Visible = false;
            txtPlanName.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = true;
            lblPlanName.Visible = false;
            txtPlanName.Visible = false;
            btnLaunchModify.Text = "Modify";
        }
        catch (Exception)
        {
            Logger.Write("sp launch modify prepaid plans page loaded");
            Response.Redirect("Error.aspx");
            //lblStatus.Visible = true;
            //lblStatus.ForeColor = System.Drawing.Color.Red;
            //lblStatus.Text = "Server is down try after some time";
        }

    }

 


    
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (rblType.SelectedIndex == 0)
        {
         
            txtDuration.Enabled = false;
        }
        else if (rblType.SelectedIndex == 1)
        {
         
            txtDuration.Enabled = true; 
        }
    }

    
    protected void ddlActivateDeactivate_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (lblActivateDeactivate.Text == "Inactive Plans")
        {
            Panel4.Visible = true;
            string PlanId = ddlActivateDeactivate.SelectedValue.ToString();
            string planName;
            char PlanType;
            int Duration;
            decimal ProcessingFee;
            decimal ServiceTax;
            string CallRate;
            string SmsRate;
            string state;
            ServiceProviderBL spobj = new ServiceProviderBL();
            spobj.GetInactivePrepaidPlanValues(PlanId, out planName, out  PlanType, out  Duration, out ProcessingFee, out ServiceTax, out CallRate, out SmsRate, out state);
            //txtInactivePlans.Text = Convert.ToString(planName);
            //txtactiveplans.Visible = false;
            //lblactive.Visible = false;
            if (PlanType == 'T')
            {
                lblPlanType.Text = "TopUp";
            }
            else if (PlanType == 'V')
            {
                lblPlanType.Text = "Validity";
            }
            lblDuration.Text = Convert.ToString(Duration);

            lblProcessingFee.Text = Convert.ToString(ProcessingFee);
            lblTax.Text = Convert.ToString(ServiceTax);
            lblCRate.Text = Convert.ToString(CallRate);
            lblSRate.Text = Convert.ToString(SmsRate);
            lblStat.Text = Convert.ToString(state);
        }
        else if (lblActivateDeactivate.Text == "Active Plans")
        {
            Panel4.Visible = true;
         

            string PlanId = ddlActivateDeactivate.SelectedValue.ToString();
            string planName;
            char PlanType;
            int Duration;
            decimal ProcessingFee;
            decimal ServiceTax;
            string CallRate;
            string SmsRate;
            string state;
            try
            {
                ServiceProviderBL spobj = new ServiceProviderBL();
                spobj.GetActivePrepaidPlanValues(PlanId, out planName, out  PlanType, out  Duration, out ProcessingFee, out ServiceTax, out CallRate, out SmsRate, out state);
                //txtactiveplans.Text = Convert.ToString(planName);
               // txtInactivePlans.Visible = false;
                //lbliiplan.Visible = false;
                if (PlanType == 'T')
                {
                    lblPlanType.Text = "TopUp";
                }
                else if (PlanType == 'V')
                {
                    lblPlanType.Text = "Validity";
                }
                lblDuration.Text = Convert.ToString(Duration);

                lblProcessingFee.Text = Convert.ToString(ProcessingFee);
                lblTax.Text = Convert.ToString(ServiceTax);
                lblCRate.Text = Convert.ToString(CallRate);
                lblSRate.Text = Convert.ToString(SmsRate);
                lblStat.Text = Convert.ToString(state);
            }
            catch (Exception)
            {
                Logger.Write("sp launch modify prepaid plans page loaded");
                Response.Redirect("Error.aspx");
                //lblStatus.Visible = true;
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Server is down try after some time";
            }
        }
    }
    protected void lbtnDeactivate_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        ddlActivateDeactivate.Items.Clear();
        ddlActivateDeactivate.Items.Add("--Select--");
        lblActivateDeactivate.Text = "Active Plans";
        try
        {
            string spid = Session["serviceproviderid"].ToString();
            ServiceProviderBL spBLobj = new ServiceProviderBL();
            DataTable dt = spBLobj.GetActivePrepaidPlans(spid);
            ddlActivateDeactivate.DataSource = dt;
            ddlActivateDeactivate.DataTextField = "PlanName";
            ddlActivateDeactivate.DataValueField = "PlanId";
            ddlActivateDeactivate.DataBind();
            btnActivateDactivate.Text = "Deactivate";
        }
        catch (Exception)
        {
            Logger.Write("sp launch modify prepaid plans page loaded");
            Response.Redirect("Error.aspx");
            //lblStatus.Visible = true;
            //lblStatus.ForeColor = System.Drawing.Color.Red;
            //lblStatus.Text = "Server is down try after some time";
        }
    }

    protected void btnActivateDeactivate_Click(object sender, EventArgs e)
    {
     try 
	{	        
		   if (btnActivateDactivate.Text == "Activate")
        {
            ServiceProviderBL spobj = new ServiceProviderBL();
            string PlanId = ddlActivateDeactivate.SelectedValue.ToString();
            string idtype = "PR";
            int returnval;
            returnval = spobj.ActivatePrepaidPlan(idtype, PlanId);
            if (returnval == 0)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Plan activate Successfully";
                
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
            else if (returnval == -1)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "other error";
                
               
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
            else if (returnval == -2)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "invalid idtype";
                
               
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
        }
        else if (btnActivateDactivate.Text == "Deactivate")
        {
            ServiceProviderBL spobj = new ServiceProviderBL();
            string PlanId = ddlActivateDeactivate.SelectedValue.ToString();
            string idtype = "PR";
            int returnval;
            returnval = spobj.DeactivatePrepaidPlan(idtype, PlanId);
            if (returnval == 0)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Plan deactivate Successfully";
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
            else if (returnval == -1)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "other error";
                
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
            else if (returnval == -2)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "invalid idtype";
                Panel3.Visible = false;
                Panel4.Visible = false;
            }
	}
     }
	catch (Exception)
     {
         Logger.Write("sp launch modify prepaid plans page loaded");
        Response.Redirect("Error.aspx");
        //lblStatus.Visible = true;
        //lblStatus.ForeColor = System.Drawing.Color.Red;
        //lblStatus.Text = "Server is down try after some time";
	}
        }
    
    protected void lbtnActivate_Click1(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        ddlActivateDeactivate.Items.Clear();
        ddlActivateDeactivate.Items.Add("--Select--");
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        lblActivateDeactivate.Text = "Inactive Plans";
        try
        {
            string spid = Session["serviceproviderid"].ToString();
            ServiceProviderBL spBLobj = new ServiceProviderBL();
            DataTable dt = spBLobj.GetInactivePrepaidPlans(spid);
            ddlActivateDeactivate.DataSource = dt;
            ddlActivateDeactivate.DataTextField = "PlanName";
            ddlActivateDeactivate.DataValueField = "PlanId";
            ddlActivateDeactivate.DataBind();
            btnActivateDactivate.Text = "Activate";
        }
        catch (Exception)
        {
            Logger.Write("sp launch modify prepaid plans page loaded");
            Response.Redirect("Error.aspx");
            //lblStatus.Visible = true;
            //lblStatus.ForeColor = System.Drawing.Color.Red;
            //lblStatus.Text = "Server is down try after some time";
        }

    }
    protected void ddlStatePlans_SelectedIndexChanged1(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        Panel2.Visible = true;
        //txtServiceTax.Enabled = false;
        if (lblStatePlan.Text.Equals("Plan"))
        {
            try
            {
                string PlanId = ddlStatePlans.SelectedValue.ToString();
                string planName;
                char PlanType;
                int Duration;
                decimal ProcessingFee;
                decimal ServiceTax;
                string CallRate;
                string SmsRate;
                ServiceProviderBL spobj = new ServiceProviderBL();
                spobj.GetPrepaidPlanValues(PlanId, out planName, out  PlanType, out  Duration, out ProcessingFee, out ServiceTax, out CallRate, out SmsRate);
                txtPlanName.Text = Convert.ToString(planName);
                if (PlanType == 'T')
                {
                    rblType.SelectedIndex = 0;
                    txtDuration.Enabled = false;
                }
                else if (PlanType == 'V')
                {
                    rblType.SelectedIndex = 1;
                    txtDuration.Enabled = true;
                }
                txtDuration.Text = Convert.ToString(Duration);

                txtProcessingFee.Text = Convert.ToString(ProcessingFee);
                txtServiceTax.Text = Convert.ToString(ServiceTax);
                txtCallRate.Text = Convert.ToString(CallRate);
                txtSmsRate.Text = Convert.ToString(SmsRate);
            }
            catch (Exception)
            {
                Logger.Write("sp launch modify prepaid plans page loaded");
                Response.Redirect("Error.aspx");
                //lblStatus.Visible = true;
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Text = "Server is down try after some time";
            }
        }
    }
   
}
    

