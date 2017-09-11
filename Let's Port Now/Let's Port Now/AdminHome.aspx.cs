//Declaring Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class AdminHome : System.Web.UI.Page
{
    //Creating AdminBL object
    AdminBL adminBLObj = new AdminBL();
       
    //this method is used when the page is loaded
    protected void Page_Load(object sender, EventArgs e)
    {
       
        char roles;
        roles = Convert.ToChar(Session["Role"].ToString());


        if (roles != 'A')
        {
            Response.Redirect("AccessDenied.aspx");
        }
        //try block
       
        Logger.Write("AdminHome Page loaded Successfully");
        try
        {
            //calling NumberOfCustomersBL method
            lblNoOfCustomers.Text = Convert.ToString(adminBLObj.NumberOfCustomersBL());
            //calling NumberOfPortingRequestsRaisedBL method
            lblNoOfRequestsRaised.Text = Convert.ToString(adminBLObj.NumberOfPortingRequestsRaisedBL());
            //calling NumberOfPortingRequestsServedBL method
            lblNoOfRequestsServed.Text = Convert.ToString(adminBLObj.NumberOfPortingRequestsServedBL());
            //calling NumberOfServiceProvidersBL method
            lblNoOfServiceProviders.Text = Convert.ToString(adminBLObj.NumberOfServiceProvidersBL());
            //calling NumberOfPendingServiceProvidersApprovalBL method
            lnkNoOfPendingApprovals.Text = Convert.ToString(adminBLObj.NumberOfPendingServiceProvidersApprovalBL());
            //enabling the link button deponding upon the required condition using if else block
            if (Convert.ToInt32(lnkNoOfPendingApprovals.Text) <= 0)
            {
                lnkNoOfPendingApprovals.Enabled = false;
            }
            else if (Convert.ToInt32(lnkNoOfPendingApprovals.Text) > 0)
            {
                lnkNoOfPendingApprovals.Enabled = true;
            }
        }
        //catch block to catch any errors
        catch (NullReferenceException)
        {

            Response.Redirect("AccessDenied.aspx");
        }

    }
    //validating the actions done on link buton click
    protected void lnkBtnNoOfPendingApprovals_Click(object sender, EventArgs e)
    {
        //redirecting to ApproveServiceProvider page
        Response.Redirect("ApproveServiceProvider.aspx");
    }
}