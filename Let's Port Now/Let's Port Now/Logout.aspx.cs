using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
  
    {
        Session.RemoveAll();
    }
   
    protected void lbtnClickHere_Click1(object sender, EventArgs e)
    {
        Response.Redirect("LoginPage.aspx");
        Session.RemoveAll();
    }
}