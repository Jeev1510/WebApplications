using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // window.opener.focus();

        string s = "window.focus()";
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "script", s, true);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //string url = "http://sparsh/departments/psd/hmm/default.aspx";

        string url = "http://sparshv2/portals/LnD/Documents/HMM/index.html";

        //string url = "http://iscls4apps/ITMS/Dashboard/LearnerDashboard";
        Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");

        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "open_window",
        //  string.Format("void(window.open('{0}', 'child_window'));", "https://is.ad.infosys.com/irj/portal/lsomgmt"), true);
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string url = "http://sparsh/departments/psd/hmm/doc/learning_credit_point_system.pdf";

        Response.Clear();
        Response.ContentType = "application/pdf";
        //Response.ContentType = "application/octet-stream";
      // Response.AddHeader("content-disposition", "filename=learning_credit_point_system.pdf");
       Response.AddHeader("content-disposition", "attachment;filename=learning_credit_point_system.pdf");
        //Response.AddHeader("content-disposition", "inline;filename=learning_credit_point_system.pdf");
        Response.Redirect("http://sparsh/departments/psd/hmm/doc/learning_credit_point_system.pdf");
       // Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
        Response.End();

    }

}