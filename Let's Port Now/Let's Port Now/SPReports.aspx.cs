using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Logging;
public partial class Reports_for_Service_Providers_ : System.Web.UI.Page
{
    ServiceProviderBL spBlobj = new ServiceProviderBL();
    Common cBlobj = new Common();
    
 
    protected void Page_Load(object sender, EventArgs e)
    {

     
            string userID = Session["UserId"].ToString();
            char Role = cBlobj.GetRole(userID);
            if (Role == 'A' || Role == 'C')
            {
                Response.Redirect("AccessDenied.aspx");

            }
       
        try
        {
            
            string spID = spBlobj.GetServiceProviderId(userID);
            Session["ServiceProviderId"] = spID;
        }
        catch (Exception ex)
        {
            lblerrorMsg.Visible = true;
            lblerrorMsg.Text = ex.Message;
        }
        if (rblDonorRecipient.SelectedValue == "As a Donor")
        {
            lblPortStatus.Visible = false;
            ddlpStatus.Visible = false;
            rfvStatus.Visible = false;
        }
        
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtToDate.Text = "";
        txtFromDate.Text = "";
        dgvGenerated.Visible = false;
        if (rblDonorRecipient.SelectedValue == "As a Recipient")
        {
            lblPortStatus.Visible = true;
            ddlpStatus.Visible = true;
            rfvStatus.Visible = true;
            
        }
    }
    protected void btnFromdate_Click(object sender, EventArgs e)
    {

        dgvGenerated.Visible = false; 
        calFromDate.Visible = true;
        calTodate.Visible = false;
       
       
    }

    protected void btnTodate_Click(object sender, EventArgs e)
    {

        dgvGenerated.Visible = false; 
        calTodate.Visible = true;
        calFromDate.Visible = false;
     
    }
    protected void calFromDate_SelectionChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = calFromDate.SelectedDate.ToString("dd-MMM-yyyy");
        calFromDate.Visible = false;
    }
    protected void calTodate_SelectionChanged(object sender, EventArgs e)
    {
        txtToDate.Text = calTodate.SelectedDate.ToString("dd-MMM-yyyy");
        calTodate.Visible = false;
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {

        dgvGenerated.Visible = true;
        
        if (rblDonorRecipient.SelectedValue == "As a Recipient")
        {
            try
            {

                string spID = Session["ServiceProviderId"].ToString();
                DataTable dt = spBlobj.SPreportsAsaRecipient(Convert.ToChar(ddlpStatus.SelectedValue), Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Session["ServiceProviderId"].ToString());
                dgvGenerated.DataSource = dt;
                dgvGenerated.DataBind();
                rfvStatus.Visible = true;
            }
            catch (Exception)
            {
                
                lblerrorMsg.Visible = true;
                lblerrorMsg.Text = "Error in Page";
                Logger.Write("Unable to generate (As a Recipient)");
            }
        }
        else if(rblDonorRecipient.SelectedValue == "As a Donor")
        {
            try
            {
                
                DataTable dt = spBlobj.SPreportsAsaDonor(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), Session["ServiceProviderId"].ToString());
                dgvGenerated.DataSource = dt;

                dgvGenerated.DataBind();
               
            }
            catch (Exception )
            {
                lblerrorMsg.Visible = true;
                lblerrorMsg.Text = "Error in Page";
                Logger.Write("Unable to generate (As a Recipient)");
            }
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime ToDate =Convert.ToDateTime(args.Value);
        DateTime FromDate =Convert.ToDateTime(txtFromDate.Text);
        
        if (ToDate > FromDate)
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    protected void ddlpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        dgvGenerated.Visible = false;
    }
}