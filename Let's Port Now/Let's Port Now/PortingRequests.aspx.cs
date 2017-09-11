//Declaring namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class PortingRequests : System.Web.UI.Page
{
    //creating ServiceProviderBL object
    ServiceProviderBL serviceBLObj = new ServiceProviderBL();
    //method to validate function on page load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("Porting Request page loaded successfully");


            if (Convert.ToChar(Session["Role"].ToString()) != 'S')
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
        //validating controls
        btnApproveDonor.Visible = false;
        btnApproveRecipient.Visible = false;
        btnMakePayment.Visible = false;
        btnRejectDonor.Visible = false;
        btnRejectRecipient.Visible = false;
        txtDonorCommentText.Visible = false;
        txtRecipientCommentText.Visible = false;

    }
    //method to validate click of accept donor button
    protected void btnAcceptDonor_Click(object sender, EventArgs e)
    {
        //try block
        try
        {
            //creating session variable
            string portingId = Session["PortingId"].ToString();
            string role = "DSP";
            string activity = "Approve";
            string comment = txtDonorCommentText.Text.ToString();
            int status;
            //calling method
            status = serviceBLObj.updatePortStatusBL(portingId, role, activity, comment);
            if (status == 0)
            {
                lblDonor.Visible = true;
                lblDonor.ForeColor = System.Drawing.Color.Green;
                lblDonor.Text = "Approval Done Successfully ";
            }
            else
            {
                lblDonor.Visible = true;
                lblDonor.ForeColor = System.Drawing.Color.Red;
                lblDonor.Text = "Sorry! Not Approved due to some UnExpected errors";
            }
        }
            //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Porting Request page -accept donor event was not successfully");
            //redirect to Error page
            Response.Redirect("Error.aspx");
        }
    }
    //validate click of reject donor button
    protected void btnRejectDonor_Click(object sender, EventArgs e)
    {
        //try block
        try
        {

            string portingId = Session["PortingId"].ToString();
            string role = "DSP";
            string activity = "Reject";
            string comment = txtDonorCommentText.Text.ToString();
            int status;
            //call method
            status = serviceBLObj.updatePortStatusBL(portingId, role, activity, comment);
            if (status == 0)
            {
                lblDonor.Visible = true;
                lblDonor.ForeColor = System.Drawing.Color.Green;
                lblDonor.Text = "Rejection Done Successfully ";
            }
            else
            {
                lblDonor.Visible = true;
                lblDonor.ForeColor = System.Drawing.Color.Red;
                lblDonor.Text = "Sorry! Not Rejected by Donor due to some UnExpected errors";
            }
        }
            //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Porting Request page -Reject donor event was not successfully");
            //redirect to error page
            Response.Redirect("Error.aspx");
        }
    }

    //validate selectted index change
    protected void gvDonorGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try block
        try
        {
            lblDonor.Visible = false;
            pnlPanel1.Visible = true;
            pnlPanel2.Visible = false;
            btnApproveDonor.Visible = true;
            btnRejectDonor.Visible = true;
            txtDonorCommentText.Visible = true;
            string portingId = gvDonorGridView.SelectedValue.ToString();
            Session["PortingId"] = portingId;

        }
            //catch block
        catch (InvalidOperationException)
        {
            //redirect to error page
            Response.Redirect("Error.aspx");
        }
        
    }
    //validating selected index change
    protected void gvRecipientGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        lblRecipient.Visible = false;
        pnlPanel2.Visible = true;
        pnlPanel1.Visible = false;
        string portingId = gvRecipientGridView.SelectedValue.ToString();
        Session["PortingId"] = portingId;
        //try block
        try
        {
            char getStatus = serviceBLObj.GetStatusBL(portingId);
        
        if (getStatus == 'F')
        {
            btnApproveRecipient.Visible = true;
            txtRecipientCommentText.Visible = true;
            btnRejectRecipient.Visible = true;
            btnMakePayment.Visible = false;
            
        }
        else
        {
            btnApproveRecipient.Visible = false;
            txtRecipientCommentText.Visible = false;
            btnRejectRecipient.Visible = false;
            btnMakePayment.Visible = true;
        }

        }
            //catch block
        catch (InvalidOperationException)
        {
            //redirect to error page
            Response.Redirect("Error.aspx");
        }
   
    }

    //validating make payment button click
    protected void btnMakePayment_Click(object sender, EventArgs e)
    {
        //redirect to MakePayment page
        Response.Redirect("MakePayment.aspx");
    }
    //validating button click
    protected void btnAcceptRecipient_Click1(object sender, EventArgs e)
    {
        //try block
        try
        {
            string portingId = Session["PortingId"].ToString();
            string role = "RSP";
            string activity = "Approve";
            string comment = txtDonorCommentText.Text.ToString();
            int status;
            //method call
            status = serviceBLObj.updatePortStatusBL(portingId, role, activity, comment);
            if (status == 0)
            {
                lblRecipient.Visible = true;
                lblRecipient.ForeColor = System.Drawing.Color.Green;
                lblRecipient.Text = "Approval Done by Recipient Successfully ";
                btnMakePayment.Visible = true;

            }
            else
            {
                lblRecipient.Visible = true;
                lblRecipient.ForeColor = System.Drawing.Color.Red;
                lblRecipient.Text = "Sorry! Not Approved by Recipient due to some UnExpected errors";
            }
        }
            //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Porting Request page -accept recipient event was not successfully");
            //redirect to error page
            Response.Redirect("Error.aspx");
        }
    }
    //validating button click
    protected void btnRejectRecipient_Click1(object sender, EventArgs e)
    {
        ///try block
        try
        {
            string portingId = Session["PortingId"].ToString();
            string role = "RSP";
            string activity = "Reject";
            string comment = txtDonorCommentText.Text.ToString();
            int status;
            //method call
            status = serviceBLObj.updatePortStatusBL(portingId, role, activity, comment);
            if (status == 0)
            {
                lblRecipient.Visible = true;
                lblRecipient.ForeColor = System.Drawing.Color.Green;
                lblRecipient.Text = "Rejection Done Successfully ";

            }
            else
            {
                lblRecipient.Visible = true;
                lblRecipient.ForeColor = System.Drawing.Color.Green;
                lblRecipient.Text = "Sorry!Rejection not done due to some error ";
            }
        }
            //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Porting Request page -accept donor event was not successfully");
            //redirect to error page
            Response.Redirect("Error.aspx");
        }
    }
    //validating button click
    protected void btnMakePayment_Click1(object sender, EventArgs e)
    {
        //redirect to error page
        Response.Redirect("MakePayment.aspx");
    }
    protected void txtRecipientCommandText_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtDonorCommentText_TextChanged(object sender, EventArgs e)
    {

    }
}
    
