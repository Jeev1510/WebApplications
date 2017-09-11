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

namespace WebApplication.ApplicationModule.WarrantModule.Election
{
    public partial class CommisionTrx : CompositeWeb.Extensions.BasePage<CashElectionPresenter>, ICashElectionView
    {
        DropDownList ddl=null;
        SuperWebControl.DateControl EventDateControl = null;
        SuperWebControl.DateControl ElectionDateControl = null;
        SuperWebControl.SuperGridview grid = null;
        Label DisplayNumberLabelbox = null;
        DateTime ResetDate;
        DateTime CommTrxDate;
        DataTable objDataSourceDataTable = null;
        string UserID = "";
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Master.m_TaskList.IndexOf(Constant.Task_WarrantResetCommission) < 0)
            {
                //Master.ShowNoAccess();
                //return;
                Response.Redirect("../AccessDenied.aspx");
            }
        }
        public void onLoaded()
        {
           GetControlByID();
           UserID = wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name);
           if (!IsPostBack)
           {
               EventDateControl.Text = DateTime.Today.ToString();
               ShowResetdates();
               ShowCommissionTrx();
           }
        }

        private void ShowResetdates()
        {
                ddl.DataSource = this.Presenter.GetResetDates();
                ddl.DataValueField = "Effective_Date";
                ddl.DataTextField = "Effective_Date";

                ddl.DataBind();
                ddl.SelectedIndex = 0;
        }
        private void GetControlByID()
        {
            ddl = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            EventDateControl = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");
            grid = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "WarrantCommSuperGridView");
            DisplayNumberLabelbox = (Label)FindControlRecursive(this.Master, "DisplayNumberLabel");
        }
        private void SetValues()
        {
            ResetDate = wfs.Utility.Util.GetDateFromString(ddl.SelectedValue.ToString());
            CommTrxDate = wfs.Utility.Util.GetDateFromString(EventDate.Text.ToString());
        }
        private void SetDataSource()
        {
            objDataSourceDataTable = this.Presenter.GetWarrantCommission(ResetDate, CommTrxDate);
        }
        private void SetGridDataSource()
        {
            SetDataSource();
            grid.DataSource = objDataSourceDataTable;
            grid.DataBind();
            DisplayNumberLabelbox.Text = objDataSourceDataTable.Rows.Count.ToString();
        }
        private void ShowCommissionTrx()
        {
            SetValues();
            SetGridDataSource();
        }
        protected void ResetDateDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCommissionTrx();
        }
        public void WarrantCommButton_Click(object sender, EventArgs e)
        {
            SetValues();
            GenerateCommission();
        }
        private void GenerateCommission()
        {
            int OrgRecords = 0;
            int SavedRecords = 0;
            DataView dtView;
            SetDataSource();
            if (objDataSourceDataTable.Rows.Count != 0)
            {
                dtView = new DataView(objDataSourceDataTable,"Planner_Code <> 'DIRECT'","Planner_Code ASC",DataViewRowState.CurrentRows);
                OrgRecords = dtView.Count;
                SavedRecords = this.Presenter.CommissionGenerated(objDataSourceDataTable, CommTrxDate, UserID);
                if (SavedRecords == OrgRecords)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventSuccess", "alert('Information saved successfully in WIAS/Span');", true);
                }
                else if (SavedRecords == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventFailure1", "alert('Error in saving data.');", true);
                }
                else if (SavedRecords != 0  && SavedRecords < OrgRecords)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventFailure2", "alert('Error in saving data. Only partial records are saved');", true);
                }
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
    }
}
