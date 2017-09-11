using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebClientApplication.WarrantModule.Views;

namespace WebApplication.ApplicationModule.WarrantModule.Invoice
{
    public partial class InvoicingDetails : CompositeWeb.Extensions.BasePage<PlannerInvoiceViewPresenter>, IPlannerInvoiceView
    {
        SuperWebControl.DateControl CommInvoicedate = null;
        SuperWebControl.SuperGridview gridView = null;
        DataTable objectDataSource = null;        
        DateTime trxstartdate;
        DateTime trxenddate;
        DateTime comminvoicedate; 
        DataTable pagedTable = null;
        int currIndex = 0;
        Label disMsg = null;
        

        public void onLoaded()
        {
            InitiateControls();

            loadGrid();
        }

        private void InitiateControls()
        {
            CommInvoicedate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "InvoiceDate");
            gridView = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "InvoiceSuperGridView");
            gridView.PageIndexChanging += new GridViewPageEventHandler(gridView_PageIndexChanging);
            disMsg = (Label)FindControlRecursive(this.Master, "DisplayNumberLabel");
        }

        private void loadGrid()
        {
            
                objectDataSource = this.Presenter.GetInvoice();
                
            if (!Page.IsPostBack)
            {
                gridView.DataSource = objectDataSource;
                gridView.DataBind();
                disMsg.Text = objectDataSource.Rows.Count.ToString();
                CommInvoicedate.Text = wfs.Utility.Util.DateToString(DateTime.Now);
            }
          }
        
        
        public void Show_Click(object sender, EventArgs e)
        {
            if (Master.m_TaskList.IndexOf(Constant.Task_ViewInvoice) < 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "NoAccess", "alert('Sorry,you do not have access to do this operation');", true);
                return;
            }

            loadGrid();
            disMsg.Text = objectDataSource.Rows.Count.ToString();

            pagedTable = objectDataSource.Clone();

            if (objectDataSource.Rows.Count > 15)
            {
                for (int i = 0; i < 12 && i < objectDataSource.Rows.Count; i++)
                {
                    //add the rows 
                    pagedTable.ImportRow(objectDataSource.Rows[i]);
                    currIndex = i;
                }
                ViewState["CurrentIndex"] = currIndex;
                gridView.DataSource = pagedTable;
            }
            else
            {
                gridView.DataSource = objectDataSource;
            }
            gridView.DataBind();
        }


        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["CurrentIndex"] != null)
            {
                pagedTable = objectDataSource.Clone();

                int startIndex = (int)ViewState["CurrentIndex"] + 1;

                for (int i = startIndex; i < startIndex + 12 && i < objectDataSource.Rows.Count; i++)
                {
                    //add the rows 
                    pagedTable.ImportRow(objectDataSource.Rows[i]);
                    currIndex = i;
                }
                ViewState["CurrentIndex"] = currIndex;
                gridView.DataSource = pagedTable;
            }
            else
            {
                gridView.DataSource = objectDataSource;
            }  
            gridView.DataBind();
           }
        

        public void btnSave_Click(object sender, EventArgs e)
        {
            int? result = 0;

            if (Master.m_TaskList.IndexOf(Constant.Task_GenerateInvoice) < 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "NoAccess", "alert('Sorry,you do not have access to do this operation');", true);
                return;
            }
            
            comminvoicedate = wfs.Utility.Util.GetDateFromString(CommInvoicedate.Text.ToString());

            int res = this.Presenter.SaveInvoiceDetails(comminvoicedate, Master.UserName, ref result);
            dispSaveMsg(res);            
        }

        private void dispSaveMsg(int validSave)
        {            
            if (validSave == 1)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "AlreadySaved", "alert('Invoice has been already generated for the given period');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "SaveSuccess", "alert('Invoice Details Saved successfully.');", true);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "refreshscreen", "window.location.href = window.location.href;", true);                 
            }
        }

        public static Control FindControlRecursive(Control Root, string Id)
        {

            if (Root.ID == Id)

                return Root;

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);

                if (FoundCtl != null)

                    return FoundCtl;
            }
            return null;
        }

        #region ObjectDataSource Methods

        public DataView GetInvoice(int StartRow, int PageSize)
        {
            //this method Returns the Paged Data

            return GetData(StartRow, PageSize);
        }

        private DataView GetData(int StartRow, int PageSize)
        {
            DataTable PagedProductsTable = null;

            if (objectDataSource != null)
            {
                //create new empty table to hold the resultant rows 
                PagedProductsTable = objectDataSource.Clone();
                //DataRow ProductsRow;

                //   i = NewPageIndex*PageSize gives us the starting row of new page
                for (int i = StartRow; i < StartRow + PageSize && i < objectDataSource.Rows.Count; i++)
                {
                    //add the rows 
                    PagedProductsTable.ImportRow(objectDataSource.Rows[i]);
                }
            }
            return PagedProductsTable.DefaultView;
        }

        public int GetRowsCount()
        {
            //this method returns the total number of rows in the Data table

            if (objectDataSource != null)
            {
                return objectDataSource.Rows.Count;
            }
            return 0;
        }
        #endregion

    }        
    
  }
    

