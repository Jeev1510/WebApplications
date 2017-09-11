using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    ServiceProviderBL serviceBl = new ServiceProviderBL();
    DataTable datatab = new DataTable();



    protected void Page_Load(object sender, EventArgs e)
    {
        //Since the page is visible only to the Service Provider so making it Unaccessible to the Customer and Admin

        Common commonbl = new Common();
        char roles;
        roles = commonbl.GetRole(Session["UserId"].ToString());

        if (roles == 'A' || roles == 'C')
        {
            Response.Redirect("AccessDenied.aspx");
        }

        //Making All the Panels invisible Except the Main panel to the the user to select an option

        PlanPanel.Visible = false;
        OffersPanel.Visible = false;
        ddlStates.Visible = false;
        ddlStatus.Visible = false;
        ddlStatesOffers.Visible = false;
        ddlStatusOffers.Visible = false;
        lblStatePlans.Visible = false;
        lblStatusPlans.Visible = false;
        grdviewData.Visible = false;




        if (rblLikeToSee.SelectedValue == "Plans")
        {
            //Making the Plan panel Visible and Making other plan invisible 
            //According to the Selected value
            PlanPanel.Visible = true;
            OffersPanel.Visible = false;

        }
        else if (rblLikeToSee.SelectedValue == "Offers")
        {
            //Making the offers panel Visible and Making other plan invisible 
            //According to the Selected value
            PlanPanel.Visible = false;
            OffersPanel.Visible = true;

        }


    }

    //THis provides option to Filter the Search Options
    protected void rblFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Enabling the labels and Drop down list according to the User Selected Values
        if (rblFilter.SelectedValue == "State")
        {
            ddlStates.Visible = true;
            ddlStatus.Visible = false;
            lblStatePlans.Visible = true;
            lblStatusPlans.Visible = false;
        }
        else if (rblFilter.SelectedValue == "Status")
        {
            ddlStates.Visible = false;
            ddlStatus.Visible = true;
            lblStatePlans.Visible = false;
            lblStatusPlans.Visible = true;
        }
        else if (rblFilter.SelectedValue == "None")
        {
            ddlStates.Visible = false;
            ddlStatus.Visible = false;
            lblStatePlans.Visible = false;
            lblStatusPlans.Visible = false;
        }
    }

    //THis will called if the User Select the Offers as Main Option then the options to filter 
    //will be provided accordingly
    protected void rblFilterOffers_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdviewData.Visible = false;

        if (rblFilterOffers.SelectedValue == "State")
        {
            //Enabling the Corrosponding labels and Drop down list Accordingly
            lblStateOffers.Visible = true;
            ddlStatusOffers.Visible = false;
            ddlStatesOffers.Visible = true;
            lblStatusOffers.Visible = false;
        }
        else if (rblFilterOffers.SelectedValue == "Status")
        {
            //Enabling the Corrosponding labels and Drop down list Accordingly
            lblStateOffers.Visible = false;
            ddlStatusOffers.Visible = true;
            ddlStatesOffers.Visible = false;
            lblStatusOffers.Visible = true;

        }
        else if (rblFilterOffers.SelectedValue == "None")
        {
            //Enabling the Corrosponding labels and Drop down list Accordingly
            lblStateOffers.Visible = false;
            ddlStatusOffers.Visible = false;
            ddlStatesOffers.Visible = false;
            lblStatusOffers.Visible = false;
        }
    }


    protected void btnViewRecords_Click(object sender, EventArgs e)
    {
        grdviewData.Visible = true;
        //View the Data According to the Values Selected by the User
        if (rblLikeToSee.SelectedValue == "Plans")
        {
            if (rblPlantype.SelectedValue == "Prepaid")
            {
                if (rblSort.SelectedValue == "Processing Fee")
                {
                    if (rblFilter.SelectedValue == "State")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = true;
                        ddlStates.Visible = true;
                        ddlStatus.Visible = false;
                        lblStatusPlans.Visible = false;
                        lblStatePlans.Visible = true;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepProState(ddlStates.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }

                    else if (rblFilter.SelectedValue == "Status")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = true;
                        rfvStatePlans.Visible = false;
                        ddlStates.Visible = false;
                        ddlStatus.Visible = true;
                        lblStatusPlans.Visible = true;
                        lblStatePlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepProStatus(ddlStatus.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }
                    else if (rblFilter.SelectedValue == "None")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        ddlStates.Visible = false;
                        ddlStatus.Visible = false;
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        lblStatusPlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepfees();
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }
                }
                else if (rblSort.SelectedValue.Equals("No Of Customers"))
                {
                    if (rblFilter.SelectedValue == "State")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = true;
                        ddlStates.Visible = true;
                        ddlStatus.Visible = false;
                        lblStatusPlans.Visible = false;
                        lblStatePlans.Visible = true;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepCustState(ddlStates.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }

                    else if (rblFilter.SelectedValue == "Status")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = true;
                        rfvStatePlans.Visible = false;
                        ddlStates.Visible = false;
                        ddlStatus.Visible = true;
                        lblStatusPlans.Visible = true;
                        lblStatePlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepCustStatus(ddlStatus.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }

                    else if (rblFilter.SelectedValue == "None")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        ddlStates.Visible = false;
                        ddlStatus.Visible = false;
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        lblStatusPlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepCusts();
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }
                }

                else if (rblSort.SelectedValue.Equals("None"))
                {
                    if (rblFilter.SelectedValue.Equals("State"))
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = true;
                        ddlStates.Visible = true;
                        ddlStatus.Visible = false;
                        lblStatusPlans.Visible = false;
                        lblStatePlans.Visible = true;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepStates(ddlStates.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }
                    else if (rblFilter.SelectedValue.Equals("Status"))
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = true;
                        rfvStatePlans.Visible = false;
                        ddlStates.Visible = false;
                        ddlStatus.Visible = true;
                        lblStatusPlans.Visible = true;
                        lblStatePlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepStatus(ddlStatus.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();

                    }

                    else if (rblFilter.SelectedValue.Equals("None"))
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        ddlStates.Visible = false;
                        ddlStatus.Visible = false;
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        lblStatusPlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPrepPlans();
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                }

            }


            else if (rblPlantype.SelectedValue == "Postpaid")
            {
                if (rblSort.SelectedValue == "Processing Fee")
                {

                    if (rblFilter.SelectedValue == "State")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        rfvStatusPlans.Visible = false;
                        ddlStatus.Visible = false;
                        lblStatusPlans.Visible = false;

                        rfvStatePlans.Visible = true;
                        ddlStates.Visible = true;
                        lblStatePlans.Visible = true;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostProState(ddlStates.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                    else if (rblFilter.SelectedValue == "Status")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        lblStatePlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        ddlStates.Visible = false;

                        ddlStatus.Visible = true;
                        lblStatusPlans.Visible = true;
                        rfvStatusPlans.Visible = true;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostProStatus(ddlStatus.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                    else if (rblFilter.SelectedValue == "None")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        ddlStates.Visible = false;
                        ddlStatus.Visible = false;
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        lblStatusPlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostfees();
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                }

                else if (rblSort.SelectedValue == "No Of Customers")
                {
                    if (rblFilter.SelectedValue == "State")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        lblStatePlans.Visible = true;
                        rfvStatePlans.Visible = true;
                        ddlStates.Visible = true;

                        ddlStatus.Visible = false;
                        lblStatusPlans.Visible = false;
                        rfvStatusPlans.Visible = false;

                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostCustState(ddlStates.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                    else if (rblFilter.SelectedValue == "Status")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        lblStatePlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        ddlStates.Visible = false;

                        ddlStatus.Visible = true;
                        lblStatusPlans.Visible = true;
                        rfvStatusPlans.Visible = true;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostCustStatus(ddlStatus.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                    else if (rblFilter.SelectedValue == "None")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        ddlStates.Visible = false;
                        ddlStatus.Visible = false;
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        lblStatusPlans.Visible = false;

                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostCusts();
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }

                }

                else if (rblSort.SelectedValue == "None")
                {
                    if (rblFilter.SelectedValue == "State")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly
                        lblStatePlans.Visible = true;
                        rfvStatePlans.Visible = true;
                        ddlStates.Visible = true;

                        ddlStatus.Visible = false;
                        lblStatusPlans.Visible = false;
                        rfvStatusPlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostStates(ddlStates.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                    else if (rblFilter.SelectedValue == "Status")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly

                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        ddlStates.Visible = false;

                        ddlStatus.Visible = true;
                        lblStatusPlans.Visible = true;
                        rfvStatusPlans.Visible = true;

                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPostStatus(ddlStatus.SelectedValue.ToString());
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }
                    else if (rblFilter.SelectedValue == "None")
                    {
                        //Enabling the Corrosponding labels and Drop down list Accordingly

                        ddlStates.Visible = false;
                        ddlStatus.Visible = false;
                        rfvStatusPlans.Visible = false;
                        rfvStatePlans.Visible = false;
                        lblStatePlans.Visible = false;
                        lblStatusPlans.Visible = false;
                        //Calling the Appropiate method to populate the Grid
                        datatab = serviceBl.GetPost();
                        grdviewData.DataSource = datatab;
                        grdviewData.DataBind();
                    }

                }

            }

        }


        if (rblLikeToSee.SelectedValue == "Offers")
        {

            if (rblFilterOffers.SelectedValue == "State")
            {
                //Enabling the Corrosponding labels and Drop down list Accordingly
                ddlStatusOffers.Visible = false;
                lblStatusOffers.Visible = false;
                rvfStatusOffers.Visible = false;

                ddlStatesOffers.Visible = true;
                lblStateOffers.Visible = true;
                rfvStatesOffers.Visible = true;

                //Calling the Appropiate method to populate the Grid
                datatab = serviceBl.GetOffersState(ddlStatesOffers.SelectedValue.ToString());
                grdviewData.DataSource = datatab;
                grdviewData.DataBind();
            }

            else if (rblFilterOffers.SelectedValue == "Status")
            {
                //Enabling the Corrosponding labels and Drop down list Accordingly
                ddlStatusOffers.Visible = true;
                lblStatusOffers.Visible = true;
                rvfStatusOffers.Visible = true;

                ddlStatesOffers.Visible = false;
                lblStateOffers.Visible = false;
                rfvStatesOffers.Visible = false;

                //Calling the Appropiate method to populate the Grid
                datatab = serviceBl.GetOffersStatus(ddlStatusOffers.SelectedValue.ToString());
                grdviewData.DataSource = datatab;
                grdviewData.DataBind();
            }
            else if (rblFilterOffers.SelectedValue == "None")
            {
                //Enabling the Corrosponding labels and Drop down list Accordingly
                ddlStatusOffers.Visible = false;
                lblStatusOffers.Visible = false;
                rvfStatusOffers.Visible = false;

                ddlStatesOffers.Visible = false;
                lblStateOffers.Visible = false;
                rfvStatesOffers.Visible = false;

                //Calling the Appropiate method to populate the Grid
                datatab = serviceBl.Getoffers();
                grdviewData.DataSource = datatab;
                grdviewData.DataBind();
            }

        }


    }
}