using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LetsPortNowMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            lblDate.Text = DateTime.Now.ToLongDateString();
            if (Convert.ToChar(Session["Role"]) == 'A')
            {
                lblName.Text = "Admin";
                aHome.Visible = true;
                aApprovals.Visible = true;
                aReports.Visible = true;
                sHome.Visible = false;
                sPlans.Visible = false;
                sPortingRequests.Visible = false;
                sPostpaid.Visible = false;
                sPrepaid.Visible = false;
                sOffers.Visible = false;
                sView.Visible = false;
                sFeedback.Visible = false;
                sReports.Visible = false;
                cHome.Visible = false;
                cRequests.Visible = false;
                cView.Visible = false;
                cCompare.Visible = false;
                cFeedback.Visible = false;
            }
            else if (Convert.ToChar(Session["Role"]) == 'S')
            {
                lblName.Text = Session["ServiceProviderName"].ToString();
                aHome.Visible = false;
                aApprovals.Visible = false;
                aReports.Visible = false;
                sHome.Visible = true;
                sPlans.Visible = true;
                sPortingRequests.Visible = true;
                sPostpaid.Visible = true;
                sPrepaid.Visible = true;
                sOffers.Visible = true;
                sView.Visible = true;
                sFeedback.Visible = true;
                sReports.Visible = true;
                cHome.Visible = false;
                cRequests.Visible = false;
                cView.Visible = false;
                cCompare.Visible = false;
                cFeedback.Visible = false;
            }
            else if (Convert.ToChar(Session["Role"]) == 'C')
            {

                lblName.Text = Session["CustomerName"].ToString();
                aHome.Visible = false;
                aApprovals.Visible = false;
                aReports.Visible = false;
                sHome.Visible = false;
                sPlans.Visible = false;
                sPortingRequests.Visible = false;
                sPostpaid.Visible = false;
                sPrepaid.Visible = false;
                sOffers.Visible = false;
                sView.Visible = false;
                sFeedback.Visible = false;
                sReports.Visible = false;
                cHome.Visible = true;
                cRequests.Visible = true;
                cView.Visible = true;
                cCompare.Visible = true;
                cFeedback.Visible = true;
            }
        }
        catch (NullReferenceException)
        {
            
           Response.Redirect("AccessDenied.aspx");
        }

    }
}
