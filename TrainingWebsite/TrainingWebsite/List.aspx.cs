using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

    public partial class List : System.Web.UI.Page
    {
       // DataTable dtProgram = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                OleDbConnection oconn = null;

                string FilePath = "D:\\jeevitha\\Integrated_Project\\TrainingWebsite\\TrainingWebsite\\Program.xlsx";
                
                oconn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");

                DataTable dtProgram = new DataTable();
                oconn.Open();
                dtProgram = oconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                oconn.Close();

                List<ListItem> lstCategories = new List<ListItem>();

                string sheetName = string.Empty;
                foreach (DataRow dr in dtProgram.Rows)
                {
                    sheetName = dr["TABLE_NAME"].ToString();
                    if (!sheetName.Contains("Sheet"))
                        lstCategories.Add(new ListItem(sheetName.Replace("$", "")));
                }
                ddlCategories.DataSource = lstCategories;
                ddlCategories.DataBind();

                //Populating the Grid view with the default value

                DataTable dtProducts = new DataTable();
                dtProducts.Columns.Add("ProgramID");
                dtProducts.Columns.Add("Date");
                dtProducts.Columns.Add("Program");
                dtProducts.Columns.Add("Day");
                dtProducts.Columns.Add("Type");
                dtProducts.Columns.Add("Unit");
                dtProducts.Columns.Add("Location");
                dtProducts.Columns.Add("JobLevel");
                dtProducts.Columns.Add("Duration");
                dtProducts.Columns.Add("Time");

              
                oconn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");
                OleDbCommand ocmd = new OleDbCommand("select * from [" + ddlCategories.SelectedItem.Value + "$]", oconn);

                oconn.Open();
                OleDbDataReader odr = ocmd.ExecuteReader();

                while (odr.Read())
                {
                    DataRow drProducts = dtProducts.NewRow();
                    drProducts["ProgramID"] = HandleNull(odr.GetValue(0));
                    drProducts["Date"] = HandleNull(Convert.ToDateTime(odr.GetValue(1)).ToString("MM/dd/yyyy"));
                    drProducts["Program"] = HandleNull(odr.GetValue(2));
                    drProducts["Day"] = HandleNull(odr.GetValue(3));
                    drProducts["Type"] = HandleNull(odr.GetValue(4));
                    drProducts["Unit"] = HandleNull(odr.GetValue(5));
                    drProducts["Location"] = HandleNull(odr.GetValue(6));
                    drProducts["JobLevel"] = HandleNull(odr.GetValue(7));
                    drProducts["Duration"] = HandleNull(odr.GetValue(8));
                    //drProducts["Time"] = HandleNull(Convert.ToDateTime(odr.GetValue(9)).ToString("H:mm:ss"));
                    drProducts["Time"] = HandleNull(odr.GetValue(9));
                    dtProducts.Rows.Add(drProducts);
                }

                oconn.Close();

                gvProducts.DataSource = dtProducts;
                gvProducts.DataBind();


            }
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtProducts = new DataTable();
            dtProducts.Columns.Add("ProgramID");
            dtProducts.Columns.Add("Date");
            dtProducts.Columns.Add("Program");
            dtProducts.Columns.Add("Day");
            dtProducts.Columns.Add("Type");
            dtProducts.Columns.Add("Unit");
            dtProducts.Columns.Add("Location");
            dtProducts.Columns.Add("JobLevel");
            dtProducts.Columns.Add("Duration");
            dtProducts.Columns.Add("Time");

            OleDbConnection oconn = null;
            string FilePath = "D:\\jeevitha\\Integrated_Project\\TrainingWebsite\\TrainingWebsite\\Program.xlsx";

            oconn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");
            OleDbCommand ocmd = new OleDbCommand("select * from [" + ddlCategories.SelectedItem.Value + "$]", oconn);

            oconn.Open();
            OleDbDataReader odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                DataRow drProducts = dtProducts.NewRow();
                drProducts["ProgramID"] = HandleNull(odr.GetValue(0));
                drProducts["Date"] = HandleNull(Convert.ToDateTime(odr.GetValue(1)).ToString("MM/dd/yyyy"));
                drProducts["Program"] = HandleNull(odr.GetValue(2));
                drProducts["Day"] = HandleNull(odr.GetValue(3));
                drProducts["Type"] = HandleNull(odr.GetValue(4));
                drProducts["Unit"] = HandleNull(odr.GetValue(5));
                drProducts["Location"] = HandleNull(odr.GetValue(6));
                drProducts["JobLevel"] = HandleNull(odr.GetValue(7));
                drProducts["Duration"] = HandleNull(odr.GetValue(8));
                //drProducts["Time"] = HandleNull(Convert.ToDateTime(odr.GetValue(9)).ToString("H:mm:ss"));
                drProducts["Time"] = HandleNull(odr.GetValue(9));
                dtProducts.Rows.Add(drProducts);  
            }

            oconn.Close();

            gvProducts.DataSource = dtProducts;
            gvProducts.DataBind();  
        }

        private string HandleNull(object val)
        {
            if (val == null)
                return string.Empty;

            return val.ToString(); 
        }
        protected void gvProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Width = Unit.Pixel(75);
            e.Row.Cells[1].Width = Unit.Pixel(100);
            e.Row.Cells[2].Width = Unit.Pixel(250);
            e.Row.Cells[3].Width = Unit.Pixel(100);
            e.Row.Cells[4].Width = Unit.Pixel(150);
            e.Row.Cells[5].Width = Unit.Pixel(75);
            e.Row.Cells[6].Width = Unit.Pixel(125);
            e.Row.Cells[7].Width = Unit.Pixel(75);
            e.Row.Cells[8].Width = Unit.Pixel(60);
            e.Row.Cells[9].Width = Unit.Pixel(125);
  
            }


        
        
        protected void lbtnreg_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open_window",
            //string.Format("void(window.open('{0}', 'child_window'));", "https://is.ad.infosys.com/irj/portal/lsomgmt"), true);
            string.Format("void(window.open('{0}', 'child_window'));", "http://iscls4apps/ITMS/Dashboard/LearnerDashboard"), true);

        }
        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    //pup.ShowPopupWindow();
        //    //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}' , 'mywin', 'left=25, top=25, width=500, height=500');</script>", "/TrainingWebsite/Default.aspx"));
        //    //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", "<script>window.open('{0}', '', 'top=100,left=300,menubar=no,toolbar=no,location=no,resizable=no,height=750,width=850,status=no,scrollbars=no,,maximize=null,resizable=0,titlebar=no');</script>");
        //}
        //protected void MycloseWindow(object sender, EventArgs e)
        //{
        //    pup.HidePopupWindow();
        //}

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    string url = "PopUp.aspx";

        //    string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";

        //    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        //}
        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string url = "Pop.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=650,height=300,left=50,top=10,resizable=no,scrollbars=yes');";
            ScriptManager.RegisterStartupScript(Page,this.GetType(), "script", s, true);
        }
        protected void gvProducts_Sorting(object sender, GridViewSortEventArgs e)
        {

                      DataTable dtProducts = new DataTable();
            dtProducts.Columns.Add("ProgramID");
            dtProducts.Columns.Add("Date");
            dtProducts.Columns.Add("Program");
            dtProducts.Columns.Add("Day");
            dtProducts.Columns.Add("Type");
            dtProducts.Columns.Add("Unit");
            dtProducts.Columns.Add("Location");
            dtProducts.Columns.Add("JobLevel");
            dtProducts.Columns.Add("Duration");
            dtProducts.Columns.Add("Time");

            OleDbConnection oconn = null;
            string FilePath = "D:\\jeevitha\\Integrated_Project\\TrainingWebsite\\TrainingWebsite\\Program.xlsx";

            oconn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0");
            OleDbCommand ocmd = new OleDbCommand("select * from [" + ddlCategories.SelectedItem.Value + "$]", oconn);

            oconn.Open();
            OleDbDataReader odr = ocmd.ExecuteReader();

            while (odr.Read())
            {
                DataRow drProducts = dtProducts.NewRow();
                drProducts["ProgramID"] = HandleNull(odr.GetValue(0));
                drProducts["Date"] = HandleNull(Convert.ToDateTime(odr.GetValue(1)).ToString("MM/dd/yyyy"));
                drProducts["Program"] = HandleNull(odr.GetValue(2));
                drProducts["Day"] = HandleNull(odr.GetValue(3));
                drProducts["Type"] = HandleNull(odr.GetValue(4));
                drProducts["Unit"] = HandleNull(odr.GetValue(5));
                drProducts["Location"] = HandleNull(odr.GetValue(6));
                drProducts["JobLevel"] = HandleNull(odr.GetValue(7));
                drProducts["Duration"] = HandleNull(odr.GetValue(8));
                //drProducts["Time"] = HandleNull(Convert.ToDateTime(odr.GetValue(9)).ToString("H:mm:ss"));
                drProducts["Time"] = HandleNull(odr.GetValue(9));
                dtProducts.Rows.Add(drProducts);
            }

            oconn.Close();

            gvProducts.DataSource = dtProducts;
            gvProducts.DataBind();

            //********************************
            if (dtProducts != null)
            {
                DataView dvSortedView = new DataView(dtProducts);
                dvSortedView.Sort = e.SortExpression + " " + getSortDirectionString();
                ViewState["sortExpression"] = e.SortExpression;
                gvProducts.DataSource = dvSortedView;
                gvProducts.DataBind();
            }
            
           // upnlList.Update();

        }

        private string getSortDirectionString()
        {
            if (ViewState["sortDirection"] == null)
            {
                ViewState["sortDirection"] = "ASC";
            }
            else
            {
                if (ViewState["sortDirection"].ToString() == "ASC")
                {
                    ViewState["sortDirection"] = "DESC";
                    return ViewState["sortDirection"].ToString();
                }
                if (ViewState["sortDirection"].ToString() == "DESC")
                {
                    ViewState["sortDirection"] = "ASC";
                    return ViewState["sortDirection"].ToString();
                }
            }
            return ViewState["sortDirection"].ToString();
        }
        protected void lbtnElearning_Click(object sender, EventArgs e)
        {
           //Response.Redirect("http://tal");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open_window",
            string.Format("void(window.open('{0}', 'child_window'));", "http://tal"), true);

           // ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('MyPage.aspx?Param=" + Param1.ToString() + "');", true);
           string pageurl = "http://tal";

          // Response.Write("<script> window.open( '" + pageurl + "','_blank' ); </script>");

           //Response.End();

            ScriptManager.RegisterStartupScript(upnlList, upnlList.GetType(),"OpenWindow", "window.open( '" + pageurl + "','_blank');", true);

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            string pageurl = "http://tal";

            ScriptManager.RegisterStartupScript(upnlList, upnlList.GetType(), "OpenWindow", "window.open( '" + pageurl + "','_blank');", true);
        }
}
