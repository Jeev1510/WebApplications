using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class Default2 : System.Web.UI.Page
{
    ServiceProviderBL spBlObj = new ServiceProviderBL();
    Common cmnBlObj = new Common();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string userID = Session["UserId"].ToString();
        char Role = cmnBlObj.GetRole(userID);
        if (Role == 'A' || Role == 'C')
        {
            Response.Redirect("AccessDenied.aspx");

        }
            lblNoOfCustPortedTo.Text = spBlObj.GetNoOfCustomersPortedTo(Session["ServiceProviderId"].ToString()).ToString();
            lblNoOfCustPortedAway.Text = spBlObj.GetNoOfCustomersPortedOut(Session["ServiceProviderId"].ToString()).ToString();
        
        }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
        string newAddress=txtAddress.Text;
        string newContactNumber=txtContactNumber.Text;
        double newPortingCharge=Convert.ToDouble(txtPortingCharge.Text);
        int ret = spBlObj.UpdateProfile(Session["ServiceProviderId"].ToString(), newContactNumber, newPortingCharge, newAddress);
        if (ret == 0)
        {
            lblUpdateStatus.ForeColor=System.Drawing.Color.Green;
            lblUpdateStatus.Text = "Update Successful";
            lblUpdateStatus.Visible = true;
            lnkClose.Visible = true;
            lnkModify.Visible = true;
            txtAddress.Enabled = false;
            txtContactNumber.Enabled = false;
            txtPortingCharge.Enabled = false;
            Logger.Write(" Service Providers Profile Updated Successfully");
            
        }
        else if (ret == -1)
        {
            lblUpdateStatus.ForeColor = System.Drawing.Color.Red;
            lblUpdateStatus.Text = "Invalid ServiceProviderId.Update Not Successful";
            lblUpdateStatus.Visible = true;
        }
        else if (ret == -2)
        {
            lblUpdateStatus.ForeColor = System.Drawing.Color.Red;
            lblUpdateStatus.Text = "Some Error Occurred.Update Not Successful";
            lblUpdateStatus.Visible = true;
        }
       
        }
        catch (Exception)
        {

            Logger.Write("Some Error occured while Executing btnUpdate_Click() in ServiceProvider home Page");
            Response.Redirect("Error.aspx");
        }
        
    }
    protected void gvPendingPayment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkUpdateMyProfile_Click(object sender, EventArgs e)
    {
        try
        {
            //on click of updateMyProfile Link
        pnlUpdate.Visible = true;
        DataTable dtSpDetails = new DataTable();
        dtSpDetails = spBlObj.GetServiceProviderDetails(Session["ServiceProviderId"].ToString());
        txtAddress.Text = dtSpDetails.Rows[0][0].ToString();
        txtContactNumber.Text = dtSpDetails.Rows[0][1].ToString();
        txtPortingCharge.Text =dtSpDetails.Rows[0][2].ToString();
        lblUpdateStatus.Visible = false;
        lnkClose.Visible = false;
        lnkModify.Visible = false;
        txtAddress.Enabled = true;
        txtContactNumber.Enabled = true;
        txtPortingCharge.Enabled = true;
        }
        catch (Exception)
        {
            Logger.Write("Some Error occured while Executing lnkUpdateMyProfile_Click() in ServiceProvider home Page");
            Response.Redirect("Error.aspx");
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlUpdate.Visible = false;
    }
    protected void lnkViewMore_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewFeedback.aspx");
    }
    protected void lnkClose_Click(object sender, EventArgs e)
    {
        pnlUpdate.Visible = false;
    }
    protected void gvPendingPayment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try{
            //working of Make payment link
        string currentCommand = e.CommandName;
        int currentRowIndex = Convert.ToInt32(e.CommandArgument);
        string portingId = gvPendingPayment.Rows[currentRowIndex].Cells[0].ToString();
        if (currentCommand == "MakePayment")
        {
            Session["SerPortingId"] = portingId;
            Response.Redirect("MakePayment.aspx");
        }
         }
        catch (Exception)
        {

            Logger.Write("Some Error occured while Executing gvPendingPayment_RowCommand() in ServiceProvider home Page");
            Response.Redirect("Error.aspx");
        }
    }
    protected void txtPortingCharge_TextChanged(object sender, EventArgs e)
    {
        lblUpdateStatus.Visible = false;
        lnkClose.Visible = false;
    }
    protected void lnkModify_Click(object sender, EventArgs e)
    {
        txtAddress.Enabled = true;
        txtContactNumber.Enabled = true;
        txtPortingCharge.Enabled = true;
        lblUpdateStatus.Visible = false;
        lnkClose.Visible = false;
        lnkModify.Visible = false;
    }
}