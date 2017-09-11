using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class View_Plans_and_Offers_for_Customers_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Logger.Write("Customer View Plan Page Loaded successfully");
            if (Session["Role"].ToString() != "C")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            gvPrepaid.Visible = false;
            gvPostpaid.Visible = false;
        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
        
    }
    
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnView.Visible = true;
        Panel2.Visible = true;
    }
    protected void rblIst_SelectedIndexChanged(object sender, EventArgs e)
    {
 

        if (rblIst.SelectedValue.Equals("Plans"))
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
       
        }
        if (rblIst.SelectedValue.Equals("Offers"))
        {
            Panel3.Visible = true;
            Panel2.Visible = false;
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            if (rblPlan.SelectedValue.Equals("Prepaid"))
            {

                string serviceprovider = ddlService.SelectedValue;
                string state = ddlState.SelectedValue;
                //Panel2.Visible = true;
                //Panel3.Visible = false;
                CustomerBL customerbl = new CustomerBL();
                customerbl.GetPrepaidPlanDetails(serviceprovider, state);
                gvOffers.Visible = false;
                gvPrepaid.Visible = true;
                gvPostpaid.Visible = false;

            }
            else if (rblPlan.SelectedValue.Equals("Postpaid"))
            {
                string serviceprovider = ddlService.SelectedValue;
                string state = ddlState.SelectedValue;
                CustomerBL customerbl = new CustomerBL();
                customerbl.GetPostpaidPlanDetails(serviceprovider, state);
                gvOffers.Visible = false;
                gvPrepaid.Visible = false;
                gvPostpaid.Visible = true;

            }
            if (rblIst.SelectedValue.Equals("Offers"))
            {
                string service = dddlservicep.SelectedValue;
                string state = ddlStat.SelectedItem.ToString(); ;
                CustomerBL custobj = new CustomerBL();
                custobj.GetOfferDetails(state, service);
                gvPrepaid.Visible = false;
                gvPostpaid.Visible = false;
                gvOffers.Visible = true;
            }
        }
        catch (InvalidOperationException)
        {
            
            lblStatus.Visible = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Server is down try after some time";
            Logger.Write("Customer View Plan - View event failed");
            Response.Redirect("Error.aspx");
        }
    }
    protected void ddlStat_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnView.Visible = true;
    }
    protected void rblPlan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnView.Visible = true;
        Panel2.Visible = true;
    }
}
