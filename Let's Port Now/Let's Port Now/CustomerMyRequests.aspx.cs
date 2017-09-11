using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class MyRequest : System.Web.UI.Page
{
    //Declaration of Customer Business class object
    CustomerBL cObj = new CustomerBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Logger.Write("Customer My Request Page Load Successful");
        try
        {
            char roles;
            roles = Convert.ToChar(Session["Role"].ToString());
            //Redirect to access denied page incase of Admin or service provider logged in
            if (roles != 'C')
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //try block
        try
        {
            //Making panel visible
            pnlPorting.Visible = true;
            string portingId = e.CommandName;
            //Assigning session variable
            Session["PortingId"] = portingId;
            lblPortingId.Text = portingId;
            //Declaration of datatable object
            DataTable dt = cObj.GetPortingDetailsByPortingId(portingId);
            txtComments.Text = dt.Rows[0][10].ToString();
            char status = Convert.ToChar(dt.Rows[0][8].ToString());
            DateTime app = Convert.ToDateTime(dt.Rows[0][6].ToString());
            //Checking for Submitted status
            if (status == 'S')
            {
                DateTime appdate = app.Date;
                TimeSpan t = (DateTime.Now).Date.Subtract(appdate);


                if (t.TotalHours <= 24)
                {
                    btnCancel.Visible = true;
                    btnClose.Visible = true;
                    btnMakePayment.Visible = false;
                }
                else
                {
                    btnClose.Visible = true;
                }

            }
            else if (status == 'C' || status == 'N' || status == 'F' || status == 'R' || status == 'P' || status == 'X')
            {
                btnCancel.Visible = false;
                btnClose.Visible = true;
                btnMakePayment.Visible = false;
            }

            else if (status == 'A')
            {
                btnCancel.Visible = false;
                btnClose.Visible = true;
                btnMakePayment.Visible = true;
            }
            else
            {
                btnCancel.Visible = false;
                btnClose.Visible = true;
                btnMakePayment.Visible = false;
            }
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("There was some error executing the method GetPortingDetailsByPortingId(portingId) under GridView1_RowCommand in CustomerMyRequests.aspx");
            Response.Redirect("Error.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string portingId = Session["PortingId"].ToString();
        int ret = cObj.UpdatePortingStatus(portingId, "CUS", "Cancel", txtComments.Text);
        //try block
        try
        {
            //For successful cancellation
            if (ret == 0)
            {
                lblRet.ForeColor = System.Drawing.Color.Green;
                lblRet.Visible = true;
                lblRet.Text = "Request cancelled successfully";
            }
            //For any other errors
            else if (ret == -1)
            {
                lblRet.ForeColor = System.Drawing.Color.Red;
                lblRet.Visible = true;
                lblRet.Text = "Other Errors";
            }
            //For a invalid role
            else if (ret == -2)
            {
                lblRet.ForeColor = System.Drawing.Color.Red;
                lblRet.Visible = true;
                lblRet.Text = "Not a valid Role";
            }
            //For improper activity
            else if (ret == -3)
            {
                lblRet.ForeColor = System.Drawing.Color.Red;
                lblRet.Visible = true;
                lblRet.Text = "The Cancel activity is not proper";
            }
            //Trying to cancel the request
            else if (ret == -4)
            {
                lblRet.ForeColor = System.Drawing.Color.Green;
                lblRet.Visible = true;
                lblRet.Text = "you cannot cancel the request unless 24 hours from activation";
            }
            //For invalid porting id
            else if (ret == -5)
            {
                lblRet.ForeColor = System.Drawing.Color.Red;
                lblRet.Visible = true;
                lblRet.Text = "PortingId is invalid ";
            }
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("There was some error executing the method btnCancel_Click in CustomerMyRequests.aspx");
            Response.Redirect("Error.aspx");
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        //Making panel invisible
        pnlPorting.Visible = false;
    }
    protected void btnMakePayment_Click(object sender, EventArgs e)
    {
        //Redirecting to make payment page
        Response.Redirect("MakePayment.aspx");
    }
    protected void lbtnUPC_Click(object sender, EventArgs e)
    {
        //Making label visibility true
        lblApplyRet.Visible = true;
        lbtnApply.Visible = true;
        //try block
        try
        {
            string custId = Session["CustomerId"].ToString();
            //Declaring string variable
            string upc;
            int i = cObj.GenerateUpc(custId, out upc);
            Session["UPC"] = upc;
            //On successful generation of UPC
            if (i == 0)
            {
                lblApplyRet.ForeColor = System.Drawing.Color.Green;
                lblApplyRet.Visible = true;
                lblApplyRet.Text = "UPC Generated and the UPC is " + upc;

            }
            //For already existing UPC
            else if (i == -4)
            {
                lblApplyRet.ForeColor = System.Drawing.Color.Green;
                lblApplyRet.Visible = true;
                lblApplyRet.Text = "You already have an unused UPC and the UPC is " + upc;
            }
            //For already opened request
            else if (i == -3)
            {
                lblApplyRet.ForeColor = System.Drawing.Color.Green;
                lblApplyRet.Visible = true;
                lblApplyRet.Text = "You already have an open request .You cannot raise a new request";
            }
            //For invalid porting period
            else if (i == -2)
            {
                lblApplyRet.ForeColor = System.Drawing.Color.Red;
                lblApplyRet.Visible = true;
                lblApplyRet.Text = "Porting period is invalid";
                lbtnApply.Enabled = false;
            }
            //For invalid customer id
            else if (i == -1)
            {

                lblApplyRet.ForeColor = System.Drawing.Color.Red;
                lblApplyRet.Visible = true;
                lblApplyRet.Text = "CustomerId is not an existing one";
                lbtnApply.Enabled = false;
            }
            //For any other errors
            else if (i == -5)
            {
                lblApplyRet.ForeColor = System.Drawing.Color.Red;
                lblApplyRet.Visible = true;
                lblApplyRet.Text = "Other Errors";
                lbtnApply.Enabled = false;
            }
        }
        //catch block
        catch (InvalidOperationException)
        {
            Response.Redirect("Error.aspx");
        }
    }
    //Redirecting to online porting form
    protected void lbtnApply_Click(object sender, EventArgs e)
    {
        Response.Redirect("Online Porting Form.aspx");
    }
    protected void gvPorting_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
