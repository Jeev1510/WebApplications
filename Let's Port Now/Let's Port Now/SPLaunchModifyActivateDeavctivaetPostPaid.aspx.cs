using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Logging;
public partial class Launch_Modify_Activate_DeactivatePostPaidPlans : System.Web.UI.Page
{
    ServiceProviderBL spBLobj = new ServiceProviderBL();
    Common commobj = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string userID = Session["UserId"].ToString();
        char Role = commobj.GetRole(userID);
        if (Role == 'A' || Role == 'C')
        {
            Response.Redirect("AccessDenied.aspx");

        }
        lblErrorMsg.Visible = false;
        lblSuccess.Visible = false;
        string spID = "";
        try
        {
            
            spID = spBLobj.GetServiceProviderId(Session["UserId"].ToString());
            Session["ServiceProviderId"] = spID;
        }
        catch
        {
            Logger.Write("Session not Available");

            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = "Error In Page";
        }
        
    }
    protected void lbtnLaunch_Click(object sender, EventArgs e)
    {
        ddlStatePlans.Items.Clear();
        ddlStatePlans.Items.Add("--Select--");
        txtCallRate.Text = "";
        txtPlanName.Text = "";
        txtProcessingFee.Text = "";
        txtSecurityAmt.Text = "";
        txtServiceTax.Text = "";
        txtSmsRate.Text = "";
        txtSecurityAmt.Enabled = true;
        txtServiceTax.Enabled = true;

        DataTable dt = commobj.GetStates();
        ddlStatePlans.DataSource = dt;
        
        ddlStatePlans.DataValueField= "State";
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
    protected void btnLaunchModify_Click(object sender, EventArgs e)
    {
        if (btnLaunchModify.Text == "Launch")
        {
            string spID = Session["ServiceProviderId"].ToString();
            string PlanID = "";
            int returnvalue = 5;
            try
            {
                returnvalue = spBLobj.LaunchPostpaidPlan(txtPlanName.Text, spID, Convert.ToDouble(txtSecurityAmt.Text), Convert.ToDouble(txtProcessingFee.Text), Convert.ToDouble(txtServiceTax.Text), txtCallRate.Text, txtSmsRate.Text, ddlStatePlans.SelectedValue.ToString(), out PlanID);

            }
            catch (Exception )
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Error In Page";
                Logger.Write("Unable to Launch");
            }
            if (returnvalue == 0)
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Plan Successfully Launched with PlanID: " + PlanID;
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else if (returnvalue == -1)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "State not Present";
                
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Error";
               

            }
        }
        else if (btnLaunchModify.Text == "Modify")
        {
            string planId=ddlStatePlans.SelectedValue.ToString();
            string planName = ddlStatePlans.SelectedItem.Text;
            double sAmount = Convert.ToDouble(txtSecurityAmt.Text);
            double pFee = Convert.ToDouble(txtProcessingFee.Text);

            int returned = 0;
            try
            {
                returned = spBLobj.ModifyPostpaidPlan(planId, planName, Convert.ToDouble(txtSecurityAmt.Text), Convert.ToDouble(txtProcessingFee.Text), txtCallRate.Text, txtSmsRate.Text);
            }
            catch (Exception)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Error In Page";
                Logger.Write("Unable to Modify");
            }
            if (returned == -1)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Plan Not Present";
            }
            else if (returned == -2)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Error In Page";
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Plan Successfully Modified";
                Panel1.Visible = false;
                Panel2.Visible = false;
            }

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
    }
    protected void lbtnModify_Click(object sender, EventArgs e)
    {
        string spID = Session["ServiceProviderId"].ToString();
        ddlStatePlans.Items.Clear();
        ddlStatePlans.Items.Add("--Select--");
        txtCallRate.Text = "";
        txtPlanName.Text = "";
        txtProcessingFee.Text = "";
        txtSecurityAmt.Text = "";
        txtServiceTax.Text = "";
        txtSmsRate.Text = "";
        DataTable dt = commobj.GetPostPaidPlans(spID);
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
    protected void ddlStatePlans_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lblStatePlan.Text == "Plan")
        {
            double SecurityAmt=0.00;
            double ProcessingFee=0.00;
            double ServiceTax=0.00;
            string callRate="";
            string smsRate="";
            spBLobj.GetPostPaidPlanDetail(ddlStatePlans.SelectedValue.ToString(), out SecurityAmt, out ProcessingFee, out ServiceTax, out callRate, out smsRate);
            txtCallRate.Text = callRate;
            txtSmsRate.Text = smsRate;
            txtProcessingFee.Text = ProcessingFee.ToString();
            txtSecurityAmt.Text = SecurityAmt.ToString();
            txtServiceTax.Text = ServiceTax.ToString();
            txtSecurityAmt.Enabled = false;
            txtServiceTax.Enabled = false;
        }
    }
    protected void lbtnActivate_Click(object sender, EventArgs e)
    {
        string spID = Session["ServiceProviderId"].ToString();
        ddlActivateDeactivate.Items.Clear();
        ddlActivateDeactivate.Items.Add("--Select--");
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        lblActivateDeactivate.Text="Inactive Plans";
        DataTable dt = spBLobj.GetInactivePlans(spID);
        ddlActivateDeactivate.DataSource = dt;
        ddlActivateDeactivate.DataTextField = "PlanName";
        ddlActivateDeactivate.DataValueField = "PlanId";
        ddlActivateDeactivate.DataBind();
        btnActivateDactivate.Text = "Activate";
        
    }
    protected void lbtnDeactivate_Click(object sender, EventArgs e)
    {
        string spID = Session["ServiceProviderId"].ToString();
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        ddlActivateDeactivate.Items.Clear();
        ddlActivateDeactivate.Items.Add("--Select--");
        lblActivateDeactivate.Text = "Active Plans";
        DataTable dt = spBLobj.GetActivePlans(spID);
        ddlActivateDeactivate.DataSource = dt;
        ddlActivateDeactivate.DataTextField = "PlanName";
        ddlActivateDeactivate.DataValueField = "PlanId";
        ddlActivateDeactivate.DataBind();
        btnActivateDactivate.Text = "Deactivate";
        
    }
    protected void ddlActivateDeactivate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlActivateDeactivate.SelectedValue == "--Select--")
        {
            Panel4.Visible = false;
        }
        else
        {
            Panel4.Visible = true;
            double SecurityAmt = 0.00;
            double ProcessingFee = 0.00;
            double ServiceTax = 0.00;
            string callRate = "";
            string smsRate = "";
            spBLobj.GetPostPaidPlanDetail(ddlActivateDeactivate.SelectedValue.ToString(), out SecurityAmt, out ProcessingFee, out ServiceTax, out callRate, out smsRate);
            lblCallRate2.Text = callRate;
            lblSmsRate2.Text = smsRate;
            lblProcessingFee2.Text = ProcessingFee.ToString();
            lblSecurityAmt2.Text = SecurityAmt.ToString();
            lblServiceTax2.Text = ServiceTax.ToString();
            lblPlanName2.Text = ddlActivateDeactivate.SelectedItem.ToString();
        }
    }
    protected void btnActivateDactivate_Click(object sender, EventArgs e)
    {
        if (btnActivateDactivate.Text == "Deactivate")
        {
            int returned = spBLobj.DeactivatePlanOrOffer("PS", ddlActivateDeactivate.SelectedValue.ToString());
            if (returned == 0)
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Plan Deactivated";
                Panel4.Visible = false;
                Panel3.Visible = false;
            }
            else if (returned == -1)
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Error In Page";
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Invalid Plan Type";
            }
        }
        else
        {
            int returned = spBLobj.ActivatePlanOrOffer("PS", ddlActivateDeactivate.SelectedValue.ToString());
            if (returned == 0)
            {
                Panel4.Visible = false;
                Panel3.Visible = false;
                lblSuccess.Visible = true;
                lblSuccess.Text = "Plan Activated";
            }
            else if (returned == -1)
            {
                lblErrorMsg.Visible=true;
                lblErrorMsg.Text = "Error in Page";
            }
            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = "Invalid Plan Type";
            }
        }
    }
    protected void cvSecurityAmount_ServerValidate(object source, ServerValidateEventArgs args)
    {
       

        try
        {
            double i = Convert.ToDouble(args.Value);
            args.IsValid = true;
        }
        catch
        {

            args.IsValid = false;
        }
    }
    protected void cvProcessingFee_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            double i = Convert.ToDouble(args.Value);
            args.IsValid = true;
        }
        catch
        {

            args.IsValid = false;
        }
    }
    protected void cvServiceTax_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            double i = Convert.ToDouble(args.Value);
            args.IsValid = true;
        }
        catch
        {

            args.IsValid = false;
        }

    }
}
