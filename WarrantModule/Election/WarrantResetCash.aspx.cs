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
    public partial class WarrantResetCash : CompositeWeb.Extensions.BasePage<CashElectionPresenter>, ICashElectionView
    {

        private void ShowResetdates()
        {
            if (!IsPostBack)
            {
                DropDownList ddl = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
                ddl.DataSource = this.Presenter.GetResetDates();
                ddl.DataValueField = "Effective_Date";
                ddl.DataTextField = "Effective_Date";

                ddl.DataBind();
                ddl.SelectedIndex = 0;
            }
        }

        private void SetCashElectionDataSource(DateTime ResetDate, string UserID, DateTime ElectionDate,string ExecutionOption)
        {
            DataTable CashElectionDataTable = null;
            SuperWebControl.SuperGridview grid = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "CashElectionSuperGridView");
            Label DisplayNumberLaabel = (Label)FindControlRecursive(this.Master, "DisplayNumberLaabel");
            CashElectionDataTable = this.Presenter.GetWarrantResetCash(ResetDate, UserID, ElectionDate, ExecutionOption);
            grid.DataSource = CashElectionDataTable;
            grid.DataBind();
            //grid.Height = 400;
            DisplayNumberLaabel.Text = CashElectionDataTable.Rows.Count.ToString();
        }

        public void SetCashElection()
        {
            string ResetDate = "";
            string UserID = "";
            string ElectionDate = "";

            DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");

            ResetDate = ResetSWCDate.Text.ToString();
            UserID = wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name);
            ElectionDate = this.EventDate.Text.ToString();

            if (ElectionDate.Length != 0)
            {
                SetCashElectionDataSource(wfs.Utility.Util.GetDateFromString(ResetDate),  UserID, wfs.Utility.Util.GetDateFromString(ElectionDate),"Select");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "ElectionDate", "alert('Please select the event date');", true);
            }
        }
        protected void ResetDateDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCashElection();
        }
        public void WarrantResetCashButton_Click(object sender, EventArgs e)
        {
            Execute(sender, e);
        }
        public void Execute(object sender, EventArgs e)
        {
            string ResetDate = "";
            string UserID = "";
            string ElectionDate = "";

            DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");

            ResetDate = ResetSWCDate.Text.ToString();
            UserID = wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name);
            ElectionDate = this.EventDate.Text.ToString();

            SetCashElectionDataSource(wfs.Utility.Util.GetDateFromString(ResetDate), UserID, wfs.Utility.Util.GetDateFromString(ElectionDate), "Update");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ResetCashSuccess", "alert('Information saved successfully');", true);
            SetCashElectionDataSource(wfs.Utility.Util.GetDateFromString(ResetDate), UserID, wfs.Utility.Util.GetDateFromString(ElectionDate), "Select");

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Master.m_TaskList.IndexOf(Constant.Task_WarrantResetCash) < 0)
            {
                //Master.ShowNoAccess();
                //return;
                Response.Redirect("../AccessDenied.aspx");
            }
        }
        #region IRelatedPartyContainer Members
        public void onLoaded()
        {
            string ResetDate = "";

            SuperWebControl.FormHeader CashElectionHeader = (SuperWebControl.FormHeader)FindControlRecursive(this.Master, "CashElectionHeader");
            this.CashElectionHeader.Title = "Warrant Reset - Cash";
            SuperWebControl.SuperGridview WarrantResetSummaryGridView = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "CashElectionSuperGridView");


            //WarrantResetSummaryGridView.Menu.AddButton("Print To Excel", "doPrint()", "", " Print to excel", "btn1printtoEXCEL");


            if (!IsPostBack)
            {
                SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");

                EventDate.Text = DateTime.Today.ToString();
                ShowResetdates();
                DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
                ResetDate = ResetSWCDate.Text.ToString();
                SetCashElection();
            }
        }

        #endregion
        /// <summary>

        /// Finds a Control recursively. Note finds the first match and exists

        /// </summary>

        /// <param name="ContainerCtl"></param>

        /// <param name="IdToFind"></param>

        /// <returns></returns>

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
