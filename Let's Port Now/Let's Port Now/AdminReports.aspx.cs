using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class ReportsAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("Reports admin page loaded");
            //Not allowing ServiceProvider or Customer to access
            if (Convert.ToChar(Session["Role"].ToString()) != 'A')
            {
                //Redirecting user to accessdenied page in case of Customer or Service Provider
                Response.Redirect("AccessDenied.aspx");
            }

            if (!IsPostBack)
            {
                //Making controls invisible during page load
                gvDetails.Visible = false;
                CalFrom.Visible = false;
                CalTo.Visible = false;
                ddlServiceProvider.Visible = false;
                ddlPortStatus.Visible = false;
                lblServiceProvider.Visible = false;
                lblPortStatus.Visible = false;
                rfvServiceProvider.Visible = false;
                rfvPortStatus.Visible = false;
            }
        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }


    protected void btnFromDate_Click(object sender, EventArgs e)
    {
        //Making calender visible during button click event
        CalFrom.Visible = true;
    }

    protected void CalFrom_SelectionChanged(object sender, EventArgs e)
    {
        //Inserting selected date into textbox from calender
        txtFromDate.Text = CalFrom.SelectedDate.ToString("dd-MMM-yyyy");
        txtFromDate.ReadOnly = true;
        CalFrom.Visible = false;
    }

    protected void btnToDate_Click(object sender, EventArgs e)
    {
        //Making calender visible during button click event
        CalTo.Visible = true;
    }

    protected void CalTo_SelectionChanged(object sender, EventArgs e)
    {
        //Inserting selected date into textbox from calender
        txtToDate.Text = CalTo.SelectedDate.ToString("dd-MMM-yyyy");
        txtToDate.ReadOnly = true;
        CalTo.Visible = false;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //Making gridview visible during button click
        gvDetails.Visible = true;
        //try block
        try
        {
            if (rblFilter.SelectedIndex == 0)
            {
                //Based on selection of service provider radiobuttonlist,choosing service provider object data source
                gvDetails.DataSourceID = "odsServiceProviderGV";
                gvDetails.DataBind();
            }
            else if (rblFilter.SelectedIndex == 1)
            {
                //Based on selection of port status radiobuttonlist,choosing port status object data source
                gvDetails.DataSourceID = "odsPortStatusGV";
                gvDetails.DataBind();
            }
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Admin reports Page Generate event Unsuccessful");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }
    protected void rblFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try block
        try
        {
            if (rblFilter.SelectedValue.Equals("Service Provider"))
            {
                //If selected dropdowmlist value is Select,make required field validator visible
                if (ddlServiceProvider.SelectedValue.Equals("--Select--"))
                {
                    gvDetails.Visible = false;
                    rfvServiceProvider.Visible = true;
                    rfvPortStatus.Visible = false;
                }

                ddlServiceProvider.Visible = true;
                lblServiceProvider.Text = rblFilter.SelectedValue;
                lblServiceProvider.Visible = true;
                gvDetails.Visible = true;

                ddlPortStatus.Visible = false;
                lblPortStatus.Visible = false;

            }
            else if (rblFilter.SelectedValue.Equals("Port Status"))
            {
                //If selected dropdowmlist value is Select,make required field validator visible
                if (ddlPortStatus.SelectedValue.Equals("--Select--"))
                {
                    gvDetails.Visible = false;
                    rfvServiceProvider.Visible = false;
                    rfvPortStatus.Visible = true;
                }

                ddlPortStatus.Visible = true;
                lblPortStatus.Text = rblFilter.SelectedValue;
                lblPortStatus.Visible = true;
                gvDetails.Visible = true;

                lblServiceProvider.Visible = false;
                ddlServiceProvider.Visible = false;

            }
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Admin reports Page Filter event Unsuccessful");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }

    protected void cusVToDate_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Verifying FromDate and ToDate for custom validator 
        DateTime Date1 = Convert.ToDateTime(txtFromDate.Text);
        DateTime Date2 = Convert.ToDateTime(txtToDate.Text);
        if (Date2.Date > Date1.Date)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }

    }

}


