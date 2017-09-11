using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class GiveFeedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("Give Feedback page loaded successfully");
            //On Page Load
            lblFeedback.Visible = false;

            char roles;
            //Get session value - Role
            roles = Convert.ToChar(Session["Role"].ToString());

            if (roles != 'C')
            {
                //Redirect to Access denied Page ,if the user is not customer
                Response.Redirect("AccessDenied.aspx");
            }
        }
        catch (NullReferenceException)
        {
            //Redirect to Access denied Page ,if session value is null
            Response.Redirect("AccessDenied.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CustomerBL cObj = new CustomerBL();
        //Get session value-CustomerId
        string CustomerId = Session["CustomerId"].ToString();
        string  ServiceProviderId=ddlServicePro.SelectedValue.ToString();
        string Comments = txtComment.Text;
        int ret = cObj.GiveFeedback(CustomerId, ServiceProviderId, Comments);
        try
        {
            if (ret == 0)
            {
                //To Give success message -"Feedback Given Successfully"
                lblFeedback.ForeColor = System.Drawing.Color.Green;
                lblFeedback.Text = "Feedback Given Successfully";
                lblFeedback.Visible = true;
            }
            else if (ret == -2)
            {
                //To Give failure message - "Invalid Service ProviderId"
                lblFeedback.ForeColor = System.Drawing.Color.Red;
                lblFeedback.Text = "Invalid Service ProviderId";
                lblFeedback.Visible = true;
            }
            else if (ret == -1)
            {
                //To Give failure message -"Invalid CustomerId"
                lblFeedback.ForeColor = System.Drawing.Color.Red;
                lblFeedback.Text = "Invalid CustomerId";
                lblFeedback.Visible = true;
            }
            else if (ret == -3)
            {
                //To Give failure message -"Feedback not given due to some errors"
                lblFeedback.ForeColor = System.Drawing.Color.Red;
                lblFeedback.Text = "Feedback not given due to some errors";
                lblFeedback.Visible = true;
            }
        }
        catch (InvalidOperationException)
        {
            //Record the Exception in Logger File
            Logger.Write("GiveFeedback method was not successful");
            Response.Redirect("Error.aspx");
        }
    }
    protected void ddlServicePro_SelectedIndexChanged(object sender, EventArgs e)
    {

        txtComment.Text = " ";
    }
}
