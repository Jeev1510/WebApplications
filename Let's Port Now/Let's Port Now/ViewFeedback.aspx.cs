using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class ViewFeedback : System.Web.UI.Page
{
    DataView dvFeedbacks;
    DataTable dtFeedbacks;
    ServiceProviderBL spObj = new ServiceProviderBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //not allowing Customer or Admin to access
            if (Session["Role"].ToString() != "S")
            {
                Response.Redirect("AccessDenied.aspx");
            }
            Logger.Write("ViewFeedback page loaded successfully");
            dtFeedbacks = new DataTable();
            dtFeedbacks = spObj.ViewFeedbacks(Session["ServiceproviderId"].ToString());
            dvFeedbacks = new DataView(dtFeedbacks);
            gvFeedback.DataSource = dvFeedbacks;
            gvFeedback.DataBind();

        }
        catch (NullReferenceException)
        {

            Response.Redirect("AccessDenied.aspx");
        }

    }
    protected void sorting_event(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (e.SortExpression.Equals("CustomerName"))
            {
                if (Session["sort"] == null)
                {
                    //first time sort
                    dvFeedbacks.Sort = e.SortExpression + " " + "ASC";
                    //storing DESC in Session
                    Session["sort"] = "DESC";
                }
                //Checks session
                else if (Session["sort"].ToString().Equals("ASC"))
                {
                    //Sort in ASC
                    dvFeedbacks.Sort = e.SortExpression + " " + "ASC";
                    //storing DESC in Session
                    Session["sort"] = "DESC";
                }
                //Checks Session
                else if (Session["sort"].ToString().Equals("DESC"))
                {
                    //Sort in ASC
                    dvFeedbacks.Sort = e.SortExpression + " " + "DESC";
                    //storing ASC in Session
                    Session["sort"] = "ASC";
                }

            }
            if (e.SortExpression.Equals("FeedbackDate"))
            {
                if (Session["sort"] == null)
                {
                    //first time sort
                    dvFeedbacks.Sort = e.SortExpression + " " + "DESC";
                    //storing ASC in Session
                    Session["sort"] = "ASC";
                }
                //Checks Session
                else if (Session["sort"].ToString().Equals("ASC"))
                {
                    //ASC sort
                    dvFeedbacks.Sort = e.SortExpression + " " + "ASC";
                    //storing DESC in Session
                    Session["sort"] = "DESC";
                }
                    //Checks Session
                else if (Session["sort"].ToString().Equals("DESC"))
                {
                    //DESC sort
                    dvFeedbacks.Sort = e.SortExpression + " " + "DESC";
                    //storing ASC in Session
                    Session["sort"] = "ASC";
                }

            }
            gvFeedback.DataSource = dvFeedbacks;
            gvFeedback.DataBind();
        }
        catch (InvalidOperationException)
        {

            Logger.Write("View Feedback Page sort was not successful");
            Response.Redirect("Error.aspx");
        }
    }
    protected void Paging_event(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvFeedback.PageIndex = e.NewPageIndex;
            gvFeedback.DataBind();
        }
        catch (InvalidOperationException)
        {

            Logger.Write("View Feedback Page Paging event failed");
            Response.Redirect("Error.aspx");
        }
    }
    protected void grvFeedback_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
