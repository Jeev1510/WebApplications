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

public partial class ComparePlans : System.Web.UI.Page
{
    CustomerBL custBlObj = new CustomerBL();
    Common commobj = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("On Page Load of Customer Compare Plans");
            string userID = Session["UserId"].ToString();
            char Role = commobj.GetRole(userID);
            if (Role != 'C')
            {
                Response.Redirect("AccessDenied.aspx");

            }
            pnlPlanType.Visible = true;

        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

        ddlPlan1.Items.Clear();
        ddlPlan2.Items.Clear();
        gvComparePlans.Visible = false;
   
        int flag = 0;
        ArrayList arr = new ArrayList();
        try
        {
            for (int i = 0; i < chkListServiceProviders.Items.Count; i++)
            {
                if (chkListServiceProviders.Items[i].Selected == true)
                {
                    flag = flag + 1;
                    arr.Add(chkListServiceProviders.Items[i].Value.ToString());
                }
            }
            //It checks that only two items are selected from the checkbox list
            if (flag == 2)
            {


                pnlPlans.Visible = true;
                lblInvalidSelects.Visible = false;
                string sp1 = arr[0].ToString();
                string sp2 = arr[1].ToString();

                DataTable dtPlan1 = new DataTable();

                dtPlan1 = custBlObj.PopulatePlansddl(rblPlanType.SelectedValue.ToString(), sp1);
                ddlPlan1.DataSource = dtPlan1;
                ddlPlan1.DataTextField = "PlanName";
                ddlPlan1.DataValueField = "PlanId";
                ddlPlan1.Items.Add("--Select--");
                ddlPlan1.DataBind();


                DataTable dtPlan2 = new DataTable();

                dtPlan2 = custBlObj.PopulatePlansddl(rblPlanType.SelectedValue.ToString(), sp2);
                ddlPlan2.DataSource = dtPlan2;
                ddlPlan2.DataTextField = "PlanName";
                ddlPlan2.DataValueField = "PlanId";
                ddlPlan2.Items.Add("--Select--");
                ddlPlan2.DataBind();

            }
            else if (flag > 2)
            {
                pnlPlans.Visible = false;
                lblInvalidSelects.Text = "Select only two Service Providers from the list";
                lblInvalidSelects.ForeColor = System.Drawing.Color.Red;
                lblInvalidSelects.Visible = true;
            }
            else
            {
                pnlPlans.Visible = false;
                lblInvalidSelects.Text = "Select two Service Providers from the list";
                lblInvalidSelects.ForeColor = System.Drawing.Color.Red;
                lblInvalidSelects.Visible = true;
            }
        }
        catch (InvalidOperationException)
        {

            Logger.Write("Some Error occured while Executing btnNext_Click() in CustomerComparePlans Page");
            Response.Redirect("Error.aspx");
        }
    }



    protected void rblPlanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        ddlPlan1.Items.Clear();
        ddlPlan2.Items.Clear();
        chkListServiceProviders.ClearSelection();
        pnlPlans.Visible = false;
            pnlChkServiceProviders.Visible = true;
            custBlObj.GetServiceProviderList(rblPlanType.SelectedValue.ToString());
        }
        catch (InvalidOperationException)
        {
            Logger.Write("Some Error occured while Executing rblPlanType_SelectedIndexChanged in CustomerComparePlans Page");
            Response.Redirect("Error.aspx");

        }
       
    }
    protected void btnCompare_Click(object sender, EventArgs e)
    {
        try
        {
            gvComparePlans.Visible = true;
            custBlObj.GetComparisonGrid(rblPlanType.SelectedValue.ToString(), ddlPlan1.SelectedValue.ToString(), ddlPlan2.SelectedValue.ToString());
        }
        catch (InvalidOperationException)
        {

            Logger.Write("Some Error occured while Executing btnCompare_Click() in CustomerComparePlans Page");
            Response.Redirect("Error.aspx");
        }
    }
    protected void ddlPlan1_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvComparePlans.Visible = false;

    }
}
