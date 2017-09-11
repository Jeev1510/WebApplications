using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class LMADOffers : System.Web.UI.Page
{
    ServiceProviderBL slObj = new ServiceProviderBL();
    /// <summary>
    /// Page Load 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Logger.Write("LaunchModifyActivatedeactivateoffers(LMADOffers) page loaded successfully");


            if (Convert.ToChar(Session["Role"].ToString()) != 'S')
            {
                Response.Redirect("AccessDenied.aspx");
            }
        }
        catch (NullReferenceException)
        {
            
           Response.Redirect("AccessDenied.aspx");
        }
      
    }
    /// <summary>
    /// On click of link button 'Launch'
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnLaunch_Click1(object sender, EventArgs e)
    {
        pnl3.Visible = false;
        pnl4.Visible = false;
        pnlLaunchModify.Visible = true;
        pnlLaunch.Visible = true;
        pnlModify.Visible = false;
    }
    /// <summary>
    /// On click of link button 'Modify'
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnModify_Click1(object sender, EventArgs e)
    {
        pnl3.Visible = false;
        pnl4.Visible = false;
        pnlLaunchModify.Visible = true;
        pnlModify.Visible = true;
        pnlLaunch.Visible =false;
    }
    /// <summary>
    /// On click of link button 'Activate'
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnActivate_Click1(object sender, EventArgs e)
    {
        pnlLaunchModify.Visible = false;
        pnl3.Visible = true;
        lblActDeact.Text = "Inactive Offers";
        btnActDeact.Text = "Activate";
        //Creating a session for Status
        Session["Status"] = 'I';
        pnl4.Visible = false;
        lblRetActDeact.Visible = false;
        //To add items in the drop down list
        ddlActDeact.Items.Clear();
        ddlActDeact.Items.Add("--Select--");
        ddlActDeact.DataSourceID = "odsActDeact";
        ddlActDeact.DataTextField = "OfferName";
        ddlActDeact.DataValueField = "OfferId";
        ddlActDeact.DataBind();
       
    }
    /// <summary>
    /// On click of link button 'Deactivate'
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnDeactivate_Click(object sender, EventArgs e)
    {
        pnlLaunchModify.Visible = false;
        pnl3.Visible = true;
        lblActDeact.Text = "Active Offers";
        btnActDeact.Text = "Deactivate";
        //Creating a session for Status
        Session["Status"] = 'A';
        pnl4.Visible = false;
        //To add items in the drop down list
        lblRetActDeact.Visible = false;
        ddlActDeact.Items.Clear();
        ddlActDeact.Items.Add("--Select--");
        ddlActDeact.DataSourceID = "odsActDeact";
        ddlActDeact.DataTextField = "OfferName";
        ddlActDeact.DataValueField = "OfferId";
        ddlActDeact.DataBind();
        
    }
    /// <summary>
    /// On selecting the items in the drop down list ddlActDeact
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlActDeact_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string offerId = ddlActDeact.SelectedValue.ToString();
            //To check if '--Select--' is selected
            if (!(offerId.Equals("--Select--")))
            {
                lblRetActDeact.Visible = false;
                if (Session["Status"].ToString().Equals("I"))
                {
                    //Fetching the values from the data table
                    DataTable dt = slObj.GetOffersByOfferId(offerId);
                    lblAmtActDeact.Text = dt.Rows[0][4].ToString();
                    lblDurActDeact.Text = dt.Rows[0][5].ToString();
                    lblDesActDeact.Text = dt.Rows[0][7].ToString();
                    pnl4.Visible = true;
                }
                else if (Session["Status"].ToString().Equals("A"))
                {
                    //Fetching the values from the data table
                    DataTable dt = slObj.GetOffersByOfferId(offerId);
                    lblAmtActDeact.Text = dt.Rows[0][4].ToString();
                    lblDurActDeact.Text = dt.Rows[0][5].ToString();
                    lblDesActDeact.Text = dt.Rows[0][7].ToString();
                    pnl4.Visible = true;
                }
            }
            else
            {
                lblRetActDeact.ForeColor = System.Drawing.Color.Red;
                lblRetActDeact.Text = "Select a valid Offer";
                lblRetActDeact.Visible = true;
                pnl4.Visible = false;
            }
        }
        catch (InvalidOperationException)
        {
            
           Logger.Write("SPLMADeOffers Page Activate Deactivate drop down list method has error");
           Response.Redirect("Error.aspx");
        }
    }
    /// <summary>
    /// On click of Launch button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLaunch_Click(object sender, EventArgs e)
    {
        try
        {
            string State = ddlState.SelectedValue.ToString();
            //To check if '--Select--' is selected
            if (!(State.Equals("--Select--")))
            {
                string OfferId;
                //Fetching datas from text boxes
                string OfferName = txtOfferName.Text;
                double Amount = Convert.ToDouble(txtAmount.Text);
                int Duration = Convert.ToInt32(txtDuration.Text);
                string Description = txtDescription.Text;

                char Status = 'A';
                string ServiceProviderId = Session["ServiceproviderId"].ToString();
                //To Launch a new offer
                int ret = slObj.LaunchOffer(OfferName, ServiceProviderId, State, Amount, Duration, Status, Description, out OfferId);

                if (ret == 0)
                {
                    //To give success message -"Offer Launched "
                    lblReturn.ForeColor = System.Drawing.Color.Green;
                    lblReturn.Text = "Offer Launched ,OfferId-" + OfferId;
                    lblReturn.Visible = true;
                }
                else if (ret == -1)
                {
                    //To give failure message -"Cannot Launch for the given state"
                    lblReturn.ForeColor = System.Drawing.Color.Red;
                    lblReturn.Text = "Cannot Launch for the given state";
                    lblReturn.Visible = true;
                }
                else if (ret == -2)
                {
                    //To give failure message - "Duration shud be between 30 and 365 days"
                    lblReturn.ForeColor = System.Drawing.Color.Red;
                    lblReturn.Text = "Duration shud be between 30 and 365 days";
                    lblReturn.Visible = true;
                }
                else if (ret == -3)
                {
                    //To give failure message -"Error occured during Launch"
                    lblReturn.ForeColor = System.Drawing.Color.Red;
                    lblReturn.Text = "Error occured during Launch";
                    lblReturn.Visible = true;
                }
            }
            else
            {
                //error message
                lblReturn.ForeColor = System.Drawing.Color.Red;
                lblReturn.Text = "Select a valid State";
                lblReturn.Visible = true;

            }
        }
        catch (InvalidOperationException)
        {
            //To record the exception in Logger File
            Logger.Write("SPLMADeOffers Page Launch method was unsuccessful");
            Response.Redirect("Error.aspx");
        }
    }
    /// <summary>
    /// On Click of button Cancel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtOfferName.Text=" ";
        txtAmount.Text=" ";
        txtDuration.Text=" ";
        txtDescription.Text = " ";
        pnlLaunch.Visible = false;
        lblReturn.Visible = false;
      
    }
    /// <summary>
    /// On Click of button 'Cancel' in modify panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelModify_Click(object sender, EventArgs e)
    {
        pnlModify.Visible = false;
        txtModOfferName.Text=" ";
        txtModNewAmt.Text= " ";
        txtModNewDuration.Text=" ";
        txtModNewDescription.Text = " ";
        lblRetMod.Visible = false;
    }
    /// <summary>
    ///  On selecting the items in the drop down list ddlOffer
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlOffer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string offerId = ddlOffer.SelectedValue;
            //To check if '--Select--' is selected
            if (!(offerId.Equals("--Select--")))
            {
                lblRetMod.Visible = false;
                DataTable dt = slObj.GetOffersByOfferId(offerId);
                lblAmtDis.Text = dt.Rows[0][4].ToString();
                lblDurationDis.Text = dt.Rows[0][5].ToString();
                lblDescriptionDis.Text = dt.Rows[0][7].ToString();
            }
            else
            {
                //To give error message 
                lblRetMod.ForeColor = System.Drawing.Color.Red;
                lblRetMod.Text = "Select a valid Offer Name";
                lblRetMod.Visible = true;
            }
        }
        catch (InvalidOperationException)
        {
            
            Response.Redirect("Error.aspx");
        }
    }
    /// <summary>
    ///  On Click of button 'Modify' in modify panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModify_Click(object sender, EventArgs e)
    {
        try
        {
            string offerId = ddlOffer.SelectedValue;
            string newOfferName = txtModOfferName.Text;
            double newAmount = Convert.ToDouble(txtModNewAmt.Text);
            int newDuration = Convert.ToInt16(txtModNewDuration.Text);
            string newDescription = txtModNewDescription.Text;
            //To modify an existing Offer
            int ret = slObj.ModifyOffer(offerId, newOfferName, newAmount, newDuration, newDescription);
            if (ret == 0)
            {
                //To give success message -"Offer Successfully Modified"
                lblRetMod.ForeColor = System.Drawing.Color.Green;
                lblRetMod.Text = "Offer Successfully Modified";
                lblRetMod.Visible = true;
            }
            else if (ret == -1)
            {
                //To give failure message - "Invalid OfferId"
                lblRetMod.ForeColor = System.Drawing.Color.Red;
                lblRetMod.Text = "Invalid OfferId";
                lblRetMod.Visible = true;

            }
            else if (ret == -2)
            {
                //To give failure message -"Duration should be between 30 and 365"
                lblRetMod.ForeColor = System.Drawing.Color.Red;
                lblRetMod.Text = "Duration should be between 30 and 365";
                lblRetMod.Visible = true;
            }

            else if (ret == -3)
            {
                //To give failure message -"Error ocurred during updation"
                lblRetMod.ForeColor = System.Drawing.Color.Red;
                lblRetMod.Text = "Error ocurred during updation";
                lblRetMod.Visible = true;
            }
        }
        catch (InvalidOperationException)
        {
            
            Logger.Write("SPLMADeOffers Page modify method was unsuccessful");
            Response.Redirect("Error.aspx");
        }
    }
    /// <summary>
    ///  On Click of button 'Activate/Deactivate'
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActDeact_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Status"].ToString().Equals("I"))
            {
                string idType = "O";
                string offerid = ddlActDeact.SelectedValue.ToString();
                //To activate a Offer
                int ret = slObj.ActivatePlanOrOffer(idType, offerid);

                if (ret == 0)
                {
                    //To give success message - "Offer Activated Successfully "
                    lblRetActDeact.ForeColor = System.Drawing.Color.Green;
                    lblRetActDeact.Text = "Offer Activated Successfully ";
                    lblRetActDeact.Visible = true;
                    pnl4.Visible = false;
                }
                else if (ret == -1)
                {
                    //To give failure message 
                    lblRetActDeact.ForeColor = System.Drawing.Color.Red;
                    lblRetActDeact.Text = "Error ocurred during Activation";
                    lblRetActDeact.Visible = true;
                    pnl4.Visible = false;
                }
                else if (ret == -2)
                {
                    //To give failure message 
                    lblRetActDeact.ForeColor = System.Drawing.Color.Red;
                    lblRetActDeact.Text = "Invalid Id Type error";
                    lblRetActDeact.Visible = true;
                    pnl4.Visible = false;
                }
            }
            else if (Session["Status"].ToString().Equals("A"))
            {
                string idType = "O";
                string offerid = ddlActDeact.SelectedValue.ToString();
                //To Deactivate a Offer
                int ret = slObj.DeactivatePlanOrOffer(idType, offerid);
                if (ret == 0)
                {
                    //To give success message - "Offer Deactivated Successfully "
                    lblRetActDeact.ForeColor = System.Drawing.Color.Green;
                    lblRetActDeact.Text = "Offer Deactivated Successfully ";
                    lblRetActDeact.Visible = true;
                    pnl4.Visible = false;
                }
                else if (ret == -1)
                {
                    //To give failure message 
                    lblRetActDeact.ForeColor = System.Drawing.Color.Red;
                    lblRetActDeact.Text = "Error ocurred during Deactivation";
                    lblRetActDeact.Visible = true;
                    pnl4.Visible = false;
                }
                else if (ret == -2)
                {
                    //To give failure message 
                    lblRetActDeact.ForeColor = System.Drawing.Color.Red;
                    lblRetActDeact.Text = "Invalid Id Type error";
                    lblRetActDeact.Visible = true;
                    pnl4.Visible = false;
                }
            }
        }
        catch (InvalidOperationException)
        {
            //To record the exception in Logger File
            Logger.Write("SPLMADeOffers Page Activaton and Deactivation  method was unsuccessful");
            Response.Redirect("Error.aspx");
        }
        
    }
}