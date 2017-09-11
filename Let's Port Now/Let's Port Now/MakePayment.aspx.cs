using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class Default2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("Make Payment Page Loaded successfully");
            lblResult.Visible = false;
            Common commonbl = new Common();
            char roles;
            roles = commonbl.GetRole(Session["UserId"].ToString());
            //not allowing Admin to access
            if (roles == 'A')
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
    protected void btnCancelTrans_Click(object sender, EventArgs e)
    {
        Common commonbl = new Common();
        char ret;
        ret = commonbl.GetRole(lblUserid.Text);
        //Redirecting the User Accordingly
        if (ret == 'A')
        {
            Response.Redirect("AcessDenied.aspx");
        }

        else if (ret == 'C')
        {
            //Redirecting the User Accordingly
            Response.Redirect("CustomerHome.aspx");
        }

        else if (ret == 'S')
        {
            //Redirecting the User Accordingly
            Response.Redirect("ServiceProviderHome.aspx");
        }

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Reference objects of the classes to call the methods
        LoginBL logbl = new LoginBL();
        Common commonbl = new Common();
        
        // method to validate the account details entered by the user
        int ret;
        ret = logbl.ValidateAccount(txtAccountNumber.Text, txtpassword.Text);

        if (ret == -1)
        {
            lblResult.Visible = true;
            lblResult.Text = "Incorrect Account Number or Password";
        }

        else if (ret == 0)
        {

        //Password is maintained in the Session so further verification
        Session["Password"] = txtpassword.Text;


        string UserId = Session["UserId"].ToString();
        //Assinging the value to the userid to the label 
        lblUserid.Text = UserId;

        
       //Declaring variable to get amount
        double AmountToPay = 0.0;

        //Calling the method to get the role of the user who has entered the page
        char roll;
        roll = commonbl.GetRole(lblUserid.Text);


        double Balance;

        //Calling the function appropaitely according to the Role of the user'
        //C for Customer
        //S for Service Provider

        if (roll == 'C')
        {
            //getting the session variables accordingly to get the value of porting Id
            string CustPortingId = Session["CusPortingId"].ToString();
            AmountToPay = commonbl.CalculateAmount(CustPortingId, 'C');
            
            
        }

        else if (roll == 'S')
        {
            string SerPortingId = Session["SerPortingId"].ToString();//"P0003"
            AmountToPay = commonbl.CalculateAmount(SerPortingId, 'S');
        }


        if (AmountToPay < 0)
        {

            lblResult.Visible = true;
            lblResult.Text = "Amount Already paid,No Dues left";
            btnConfirmTrans.Enabled = false;
            TransactionPanel.Visible = false;
            MakePaymentPanel.Visible = false;
        }

        //On Success Panels are Enabled and Disabled
        else if (AmountToPay >0)
        {
            LoginPanel.Enabled = false;
            TransactionPanel.Enabled = true;

           
            //Account Details are Called in Balance is Retrieved
            logbl.getAccountDetails(Convert.ToInt16(txtAccountNumber.Text), out Balance);

            lblAccountNumber.Text = txtAccountNumber.Text;
            lblBalance.Text = Balance.ToString();

            //these values will Come from Session Variable

            lblAmountPay.Text = AmountToPay.ToString();

            //Storing the value of Amount to pay calculated earlier by calling the function from SQL
            Session["Amounttopay"] = lblAmountPay.Text;
        }
        }
        


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //Reseting the values on Cancel Button

        txtAccountNumber.Text = "";
        txtpassword.Text = "";

        Common commonbl = new Common();


        ///Value of UserId will come from Session variable passed
        string UserId = Session["UserId"].ToString();

        char ret;
        ret = commonbl.GetRole(UserId);

        //Redirecting to the home page according to the role of the user
        if (ret == 'A')
        {
            Response.Redirect("AccessDenied.aspx");
        }

        else if (ret == 'C')
        {
            Response.Redirect("CustomerHome.aspx");
        }

        else if (ret == 'S')
        {
            Response.Redirect("ServiceProviderHome.aspx");
        }
    }
    protected void btnConfirmTrans_Click(object sender, EventArgs e)
    {
        MakePaymentPanel.Enabled = true;
        TransactionPanel.Enabled = false;
        LoginPanel.Enabled = false;
       

    }
    protected void btnCancelMakePayment_Click(object sender, EventArgs e)
    {
        txtComments.Text = "";
        Common commonbl = new Common();
        ///Value of UserId will come from Session variable passed
        string UserId = Session["UserId"].ToString();

        //Calling the method to get the role of the user 
        char ret;
        ret = commonbl.GetRole(UserId);

        //Redirecting to the home page according to the role of the user
        if (ret == 'A')
        {
            Response.Redirect("AccessDenied.aspx");
        }

        else if (ret == 'C')
        {
            Response.Redirect("CustomerHome.aspx");
        }

        else if (ret == 'S')
        {
            Response.Redirect("ServiceProviderHome.aspx");
        }


    }
    //to pay the amount at the end
    protected void btnPay_Click(object sender, EventArgs e)
    {
        try
        {

            Common commonbl = new Common();
            char ret;
            string TransactionId;
            lblTransactionResult.Visible = true;


            string UserId = Session["UserId"].ToString();
            //getting role
            ret = commonbl.GetRole(UserId);
            double AmountToPay = Convert.ToDouble(lblAmountPay.Text);
            string password = Session["Password"].ToString();


            //Admin not Allowed 
            if (ret == 'A')
            {
                Response.Redirect("AccessDenied.aspx");
            }

            else if (ret == 'C')
            {
                //getting the porting ids from the sessions
                string CustPortingId = Session["CusPortingId"].ToString();

                //Calling to method to insert the values and get corrosponding return values
                int getval;
                getval = commonbl.MakePayment(UserId, Convert.ToInt16(txtAccountNumber.Text), password, CustPortingId, AmountToPay, "CUS", txtComments.Text, out TransactionId);

                //On Sucess
                if (getval == 0)
                {
                    lblTransactionResult.Text = "Transacation Successfull";
                    lbGOtoHome.Visible = true;
                }

                //getting the return value and showing corrosponding error message
                if (getval == -1)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Account Credentials are Invalid";

                }
                //getting the return value and showing corrosponding error message
                else if (getval == -2)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Insufficent Balance";
                }
                //getting the return value and showing corrosponding error message
                else if (getval == -3)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Role is Invalid";
                }
                //getting the return value and showing corrosponding error message
                else if (getval == -4)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Some other Error,Try Again Later";
                }


            }

            else if (ret == 'S')
            {
                string SerPortingId = Session["SerPortingId"].ToString();//"P0003"

                int getval1;
                getval1 = commonbl.MakePayment(UserId, Convert.ToInt16(txtAccountNumber.Text), password, SerPortingId, AmountToPay, "RSP", txtComments.Text, out TransactionId);

                if (getval1 == 0)
                {
                    lblTransactionResult.Text = "Transacation Successfull";
                    lbGOtoHome.Visible = true;
                }
                //getting the return value and showing corrosponding error message
                if (getval1 == -1)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Account Credentials are Invalid";

                }
                //getting the return value and showing corrosponding error message
                else if (getval1 == -2)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Insufficent Balance";
                }
                //getting the return value and showing corrosponding error message
                else if (getval1 == -3)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Role is Invalid";
                }
                //getting the return value and showing corrosponding error message
                else if (getval1 == -4)
                {
                    lblTransactionResult.ForeColor = System.Drawing.Color.Red;
                    lblTransactionResult.Text = "Some other Error,Try Again Later";
                }

                MakePaymentPanel.Visible = false;



            }
        }
        catch (InvalidOperationException)
        {
            Logger.Write("Pay event failed in Make Payment Page");
            Response.Redirect("Error.aspx");
        }


    }
    protected void lbGOtoHome_Click(object sender, EventArgs e)
    {
        //Redirecting the USer according to his role
        Common commonbl = new Common();
        char ret;
        string UserId = Session["UserId"].ToString();
        ret = commonbl.GetRole(UserId);
        if (ret == 'C')
        {
            Response.Redirect("CustomerHome.aspx");
        }

        else if (ret == 'S')
        {
            Response.Redirect("ServiceProviderHome.aspx");
        }


    }
}