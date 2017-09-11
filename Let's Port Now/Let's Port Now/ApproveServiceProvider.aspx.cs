using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class ApproveServiceProvider_Admin_ : System.Web.UI.Page
{
    AdminBL aObj = new AdminBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("Approve Service Provider page loaded successfully");
            //on page load 
            if (!IsPostBack)
            {

                //Population of grid view
                gvServiceProvider.DataSourceID = "odsServiceProvider";
                gvServiceProvider.DataBind();
                char roles;
                roles = Convert.ToChar(Session["Role"].ToString());

                if (roles != 'A')
                {
                    //redirect to the error page if the user is not admin
                    Response.Redirect("AccessDenied.aspx");
                }
                if (gvServiceProvider.Rows.Count == 0)
                {
                    //If there is no row in the grid view
                    btnApprove.Enabled = false;
                    btnReject.Enabled = false;
                }
            }
        }
        catch (NullReferenceException)
        {
            //redirect to the error page 
             Response.Redirect("Error.aspx");
        }
        
    }

   
    protected void gvServiceProvider_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string currentCommand = e.CommandName;
        //a row command to verify the service provider
        try
        {

            if (currentCommand == "gv_btnVerify")
            {
                int currentRowIndex = Convert.ToInt32(e.CommandArgument);
                string ServiceProviderName = gvServiceProvider.Rows[currentRowIndex].Cells[1].Text;
                string LicenseNumber = gvServiceProvider.Rows[currentRowIndex].Cells[3].Text;
                //call the method in the adminBL
                int ret = aObj.VerifyServiceProvider(ServiceProviderName, LicenseNumber);
                if (ret == 0)
                {
                    //to display the success message 
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = ServiceProviderName + " is licensed";
                    lblMessage.Visible = true;
                }
                else if (ret == -1)
                {
                    //to display the failure message 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = ServiceProviderName + " is not licensed";
                    lblMessage.Visible = true;
                }
            }
        }
        catch (InvalidOperationException)
        {
            //redirection to error page
           Response.Redirect("Error.aspx");
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        //On click of button approval
        string ServiceProviderName=" ";
        string name = " ";
        char  action='A';
        int flag = 0;
        int f = 0;
        int ret = 0;
        int flag2= 0;
        try
        {
            for (int i = 0; i < gvServiceProvider.Rows.Count; i++)
            {
                //To check each check box
                GridViewRow row = gvServiceProvider.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("ChkSelect")).Checked;
                if (isChecked)
                {
                    ServiceProviderName = gvServiceProvider.Rows[i].Cells[1].Text;
                    //call the method in the adminBL
                    string id = aObj.GetServiceProviderIdByName(ServiceProviderName);
                    //call the method in the adminBL
                    ret = aObj.ApproveOrRejectServiceProvider(id, action);
                    if (ret == 0)
                    {
                        flag2 += 1;
                    }
                    else if (ret == -1)
                    {

                        f = 1;
                        name = ServiceProviderName;
                        break;
                    }
                    else
                    {

                        f = 2;
                        break;
                    }

                    flag += 1;
                }

            }

            if (flag == 0)
            {
                //If no check box is checked
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Atleast one check box should be selected";
                lblMessage.Visible = true;
            }
            else
            {

                if (flag != 0 && flag == flag2)
                {
                    //to display the success message 
                    gvServiceProvider.DataSourceID = "odsServiceProvider2";
                    gvServiceProvider.DataBind();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Approval done successfully";
                    gvServiceProvider.DataBind();
                    lblMessage.Visible = true;
                }
                else if (f == 1 && flag2 < flag)
                {
                    //to display the failure message 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid Service Provider";
                    lblMessage.Visible = true;

                }
                else if (f == 2 && flag2 < flag)
                {
                    //to display the failure message with the service provider name
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error Occured during Approval of Service Provider " + name;
                    lblMessage.Visible = true;

                }
                else
                {
                    //to display the failure message 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error Occured during Approval";
                    lblMessage.Visible = true;

                }
            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("ApproveServiceProvider-Approving Unsuccessful");
            //redirect to the error page 
           Response.Redirect("Error.aspx");
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {

        string ServiceProviderName = " ";
        string name = " ";
        char action = 'R';
        int flag = 0;
        int f = 0;
        int ret = 0;
        int flag2 = 0;
        try
        {
            
            for (int i = 0; i < gvServiceProvider.Rows.Count; i++)
            {

                GridViewRow row = gvServiceProvider.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("ChkSelect")).Checked;
                if (isChecked)
                {
                    ServiceProviderName = gvServiceProvider.Rows[i].Cells[1].Text;
                    //call the method in the adminBL
                    string id = aObj.GetServiceProviderIdByName(ServiceProviderName);
                    //call the method in the adminBL
                    ret = aObj.ApproveOrRejectServiceProvider(id, action);
                    if (ret == 0)
                    {
                        flag2 += 1;

                    }
                    else if (ret == -1)
                    {

                        f = 1;
                        name = ServiceProviderName;
                        break;
                    }
                    else
                    {

                        f = 2;
                        break;
                    }
                    flag += 1;
                }

            }

            if (flag == 0)
            {
                //If no check box is checked
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Atleast one check box should be selected";
                lblMessage.Visible = true;
            }
            else
            {

                if (flag != 0 && flag == flag2)
                {
                    gvServiceProvider.DataSourceID = "odsServiceProvider2";
                    gvServiceProvider.DataBind();
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    //to display the success message 
                    lblMessage.Text = "Rejection done successfully";
                    lblMessage.Visible = true;
                }
                else if (f == 1 && flag2 < flag)
                {
                    //to display the failure message 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid Service Provider";
                    lblMessage.Visible = true;

                }
                else if (f == 2 && flag2 < flag)
                {
                    //to display the failure message with service provider name
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error Occured during Approval of Service Provider " + name;
                    lblMessage.Visible = true;

                }
                else
                {
                    //to display the failure message 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error Occured during Rejection";
                    lblMessage.Visible = true;

                }
            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("ApproveServiceProvider-Rejection Unsuccessful");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }
}