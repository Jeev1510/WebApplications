using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class CustomerHome : System.Web.UI.Page
{

    CustomerBL custBl = new CustomerBL();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //not allowing ServiceProvider or Admin to access
            if (Session["Role"].ToString() != "C")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            
            Logger.Write("CustomerHome Page loaded Successfully");

            if (!IsPostBack)
            {
                pnlUpdate.Visible = false;
                gvLastPorting.Visible = true;
                gvPending.Visible = true;
                //Getting Session values from Login Page
                lblCurrentService.Text = custBl.CurrentServiceProvider(Session["UserId"].ToString());
                lblCurrentPlan.Text = custBl.CurrentPlan(Session["UserId"].ToString());
                lblStatus.Visible = false;


            }
        }
        catch (NullReferenceException)
        {
            
              Response.Redirect("AccessDenied.aspx");
        }


    }
    protected void objLastPorting_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        //try block
        try
        {
            pnlUpdate.Visible = true;
            DataTable dtCust = new DataTable();
            //Getting Session value from Login Page
            dtCust = custBl.GetCustomerDetails(Session["UserId"].ToString());
            //All the field controls gets value from the datatbase
            txtName.Text = dtCust.Rows[0][0].ToString();
            txtAddressLine1.Text = dtCust.Rows[0][1].ToString();
            txtAddressLine2.Text = dtCust.Rows[0][2].ToString();
            txtZipCode.Text = dtCust.Rows[0][3].ToString();
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Customer Home Page- Update link click event failed");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }


    }

    protected void lnkWanttoPort_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerMyRequests.aspx");
    }

    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        //try block
        try
        {
            string customerid = Session["CustomerId"].ToString();
            //Calls method from CustomerBL
            int ret = custBl.UpdateCustomerDetails(customerid, txtName.Text, txtAddressLine1.Text, txtAddressLine2.Text, txtZipCode.Text);

            if (ret == 0)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Updated Successfully";

            }
            else if (ret == -1)
            {

                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid CustomerId";

            }
            else if (ret == -2)
            {
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "not updated due to some other errors";

            }
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Customer Home Page- 'want to port' event failed");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        //try block
        try
        {
            //making all the fields empty on click of cancel
            pnlUpdate.Visible = false;
            txtName.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtZipCode.Text = string.Empty;
        }
        //catch block
        catch (InvalidOperationException)
        {
            Logger.Write("Customer Home Page- Cancel event failed");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }
    }
    protected void grvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string currentCommand = e.CommandName;

        try
        {
            if (currentCommand == "gv_MakePayment")
            {
                int currentRowIndex = Convert.ToInt32(e.CommandArgument);
                string PortingId = gvPending.Rows[currentRowIndex].Cells[0].Text;
                //Sending PortingId in session to Make Payment page
                Session["CusPortingId"] = PortingId;
              
            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("Customer Home Page- Make Payment  event failed");
            //redirect to the error page 
            Response.Redirect("Error.aspx");
        }

        Response.Redirect("MakePayment.aspx");

    }
    protected void grvPending_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int rowindex = grvPending.SelectedIndex;
        //string PortingId = grvPending.Rows[rowindex].Cells[0].Text;
        //Session["CusPortingId"] = PortingId;
        //Response.Redirect("MakePayment.aspx");


    }
}



