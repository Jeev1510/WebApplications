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
    public partial class WarrantOngoingCommTrx : CompositeWeb.Extensions.BasePage<CashElectionPresenter>, ICashElectionView
    {
        public const string SFIWFunctionSubType = "OngoingComm-SFIW";
        public const string PELFunctionSubType = "OngoingComm-PEL";
        public const string CfdWarrantsFunctionSubType = "UpfrontComm-CFDWrnts";

        public string InvType
        {
            get
            {
                return (ViewState["InvType"] != null ? ViewState["InvType"].ToString() : "");
            }
            set
            {
                ViewState["InvType"] = value;
            }

        }



        public void onLoaded()
        {
            DataTable dtStartDate = null;
            if (!IsPostBack)
            {
                InvType = Request.QueryString["invtype"];
                if (InvType.Equals("SFI"))
                {
                    dtStartDate = Presenter.GetCommissionStartDate(SFIWFunctionSubType);
                }
                else if (InvType.Equals("PEL"))
                {
                    dtStartDate = Presenter.GetCommissionStartDate(PELFunctionSubType);
                }
                else
                {
                    dtStartDate = Presenter.GetCommissionStartDate(CfdWarrantsFunctionSubType);
                }
                if (dtStartDate != null && dtStartDate.Rows.Count > 0)
                {
                    MonthStartDate.Text = wfs.Utility.Util.DateToString(wfs.Utility.Util.GetDateFromString(dtStartDate.Rows[0]["FUNCTION_START_DATE"].ToString()));
                    hdnCommissionStartDate.Value = wfs.Utility.Util.DateToString(wfs.Utility.Util.GetDateFromString(dtStartDate.Rows[0]["FUNCTION_START_DATE"].ToString()));
                    MonthEndDate.Text = wfs.Utility.Util.DateToString(DateTime.Now);
                    hdnCommissionEndDate.Value = wfs.Utility.Util.DateToString(DateTime.Now);
                }
            }
            DataTable dt = GetEmptyDatatable();
            BindGridview(dt);
            
           
        }

        private DataTable GetEmptyDatatable()
        {
            DataTable dtCommision = new DataTable();

            //create columns of data table

            dtCommision.Columns.Add("portf_num");
            dtCommision.Columns.Add("Application_Num");
            dtCommision.Columns.Add("appl_received_date");
            dtCommision.Columns.Add("inv_type");
            dtCommision.Columns.Add("inv_sub_type");
            dtCommision.Columns.Add("acc_num");
            dtCommision.Columns.Add("fpa_member_code");
            dtCommision.Columns.Add("Fpa_Co_Num");
            dtCommision.Columns.Add("strike_pla");
            dtCommision.Columns.Add("Comm_Rate");
            dtCommision.Columns.Add("Gst");
            dtCommision.Columns.Add("Contrib_Amt");
            dtCommision.Columns.Add("Comm_Qty");
            dtCommision.Columns.Add("Amt");
            dtCommision.Columns.Add("Portfolio_Value");
            dtCommision.Columns.Add("CommissionCreation");
            DataRow drCommRow;
            drCommRow = dtCommision.NewRow();
            dtCommision.Rows.Add(drCommRow);
            return dtCommision;
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if(InvType.Equals("SFI"))
            {
                CommissionElectionHeader.Title = "Warrrrant Ongoing-Commission";
                MakeVisible(true);
                
            }
            else if (InvType.Equals("PEL"))
            {
                CommissionElectionHeader.Title = "PEL Ongoing-Commission";
                MakeVisible(true);
            }

            else
            {
                CommissionElectionHeader.Title = "CFD and Warrants Upfront Commission";
                MakeVisible(false);
            }
           
        }


        private void MakeVisible(bool isTrueOrFalse)
        {
            PnlIncluExclusive.Visible = isTrueOrFalse;
            lblAlready.Visible = isTrueOrFalse;
            lblAlreadyCreated.Visible = isTrueOrFalse;
            lblNew.Visible = isTrueOrFalse;
            lblNewlyCreated.Visible = isTrueOrFalse;

        }

        private bool CheckAccess()
        {
            bool isAccessOrValidation = true;
            if (Master.m_TaskList.IndexOf(Constant.Task_ViewOngoingWarrantCommission) < 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "NoAccess", "alert('Sorry,you do not have access to do this operation');", true);
                isAccessOrValidation = false;

            }

            return isAccessOrValidation;

        }

        private bool CheckEmptyDates()
        {
            bool isAccessOrValidation = true;
            if (string.IsNullOrEmpty(MonthStartDate.Text) || string.IsNullOrEmpty(MonthEndDate.Text))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "EmptyDates", "alert('Please select the Date');", true);
                isAccessOrValidation = false;

            }
            return isAccessOrValidation;
        }

        private bool CheckMonthDates()
        {
            bool isAccessOrValidation = true;
            if ((!string.IsNullOrEmpty(MonthStartDate.Text) && !string.IsNullOrEmpty(MonthEndDate.Text)) && (wfs.Utility.Util.GetDateFromString(MonthStartDate.Text) > wfs.Utility.Util.GetDateFromString(MonthEndDate.Text)))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "DateCondition", "alert('Month start date should be less than month end date');", true);
                isAccessOrValidation = false;
            }
            return isAccessOrValidation;
        }


        protected void WarrantCommButton_Click(object sender, EventArgs e)
        {
            if (hdnReturnValue.Value == "false")
            {
                return;
            }
            bool isValid = true;
            DataTable dtCommision = null;
            isValid = CheckAccess();
            if (isValid == false)
            {
                return;
            }
            isValid = CheckEmptyDates();
            if (isValid == false)
            {
                return;
            }
            isValid = CheckMonthDates();
            if (isValid == false)
            {
                return;
            }

            DisplayNumberLabel.Text = "0";
            dtCommision = GetOnCommissionRecords();
            if (dtCommision != null && dtCommision.Rows.Count > 0)
            {
                DisplayNumberLabel.Text = Convert.ToString(dtCommision.Rows.Count);
                BindGridview(dtCommision);
                DataView dvCommission = dtCommision.DefaultView;
                dvCommission.RowFilter = "CommissionCreation = 'Newly Created'";
                if (dvCommission != null)
                    lblNewlyCreated.Text = Convert.ToString(dvCommission.Count);
                dvCommission.RowFilter = "CommissionCreation = 'Already Created'";
                if (dvCommission != null)
                    lblAlreadyCreated.Text = Convert.ToString(dvCommission.Count);
            }
        }

        //ReportButton_Click
        protected void ReportButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            isValid = CheckAccess();
            if (isValid == false)
            {
                return;
            }
            isValid = CheckEmptyDates();
            if (isValid == false)
            {
                return;
            }
            isValid = CheckMonthDates();
            if (isValid == false)
            {
                return;
            }
            if (InvType.Equals("SFI"))
            {
                Response.Redirect("http://audoza552/ReportserverRAUDIAM01?%2fWIAS+Reports%2fOps_warrant_Ongoing_Comm_Trx&MonthStartDate=" + MonthStartDate.Text + "&MonthEndDate=" + MonthEndDate.Text + "&CommTrxAll=" + "All" + "&rs:Command=Render");
            }
            else if (InvType.Equals("PEL"))
            {
                Response.Redirect("http://audoza552/ReportserverRAUDIAM01?%2fWIAS+Reports%2fOps_Pel_Ongoing_Comm_Trx&MonthStartDate=" + MonthStartDate.Text + "&MonthEndDate=" + MonthEndDate.Text + "&CommTrxAll=" + "All" + "&rs:Command=Render");
            }
            else
            {
                Response.Redirect("http://audoza552/ReportserverRAUDIAM01?%2fWIAS+Reports%2fOps_Comm_CFD_N_SFIW_UF_Commision&MonthStartDate=" + MonthStartDate.Text + "&MonthEndDate=" + MonthEndDate.Text + "&CommTrxAll=" + "All" + "&rs:Command=Render");
            }
          
        }

        protected void WarrantGenerateCommBtn_Click(object sender, EventArgs e)
        {
            //if (hdnReturnValue.Value == "false")
            //{
            //    return;
            //}
            string strprocessName = "";
            string strFunction = "";
            int OrgRecords = 0;
            int SavedRecords = 0;
            DataTable dtOnGoingComm = new DataTable();
            string strUserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
            if (Master.m_TaskList.IndexOf(Constant.Task_GenerateOngoingWarrantCommission) < 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "NoAccess", "alert('Sorry,you do not have access to do this operation');", true);
                return;
            }
            dtOnGoingComm = GetOnCommissionRecords();
            if (dtOnGoingComm != null && dtOnGoingComm.Rows.Count > 0)
            {

                //OrgRecords = dtOnGoingComm.Rows.Count;
                if (InvType.Equals("SFI"))
                {
                    strFunction = SFIWFunctionSubType;
                    strprocessName = BTIABLL.Helper.GetProcessName(SFIWFunctionSubType, Presenter.GetDbConnectionString());
                }
                else if (InvType.Equals("PEL"))
                {
                    strFunction = PELFunctionSubType;
                    strprocessName = BTIABLL.Helper.GetProcessName(PELFunctionSubType, Presenter.GetDbConnectionString());
                }

                else
                {
                    strFunction = CfdWarrantsFunctionSubType;
                    strprocessName = BTIABLL.Helper.GetProcessName(CfdWarrantsFunctionSubType, Presenter.GetDbConnectionString());
                }

                Guid LogId = BTIABLL.Helper.MainLogStart(strUserName, strprocessName, strFunction, Presenter.GetDbConnectionString());
                SavedRecords = this.Presenter.OnGoingWarrantCommissionGenerated(dtOnGoingComm, MonthEndDate.Text, wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name), InvType);
                DataView dvCommission = dtOnGoingComm.DefaultView;
                dvCommission.RowFilter = "CommissionCreation = 'Newly Created'";
                OrgRecords = dvCommission.Count;
                if (SavedRecords == OrgRecords)
                {
                    UpdateStartAndEndDate();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "CommisionSuccess", "alert('Information saved successfully in WIAS/Span');", true);
                    BTIABLL.Helper.MainLogFinish(LogId, "Process " + strprocessName + " Completed Successfully.", true, Presenter.GetDbConnectionString());

                }
                else if (SavedRecords == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "CommisionFailure1", "alert('Error in saving data.');", true);
                    BTIABLL.Helper.MainLogFinish(LogId, "Process " + strprocessName + " Not Completed Successfully.", false, Presenter.GetDbConnectionString());

                }
                else if (SavedRecords != 0 && SavedRecords < OrgRecords)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "CommisionFailure2", "alert('Error in saving data. Only partial records are saved');", true);
                    BTIABLL.Helper.MainLogFinish(LogId, "Process " + strprocessName + " Not Completed Successfully.", false, Presenter.GetDbConnectionString());
                }
            }
        }
        
        private DataTable GetOnCommissionRecords()
        {
            DataTable dtCommision = null;
            dtCommision = this.Presenter.GetOnGoingWarrantCommission(wfs.Utility.Util.GetDateFromString(MonthStartDate.Text), wfs.Utility.Util.GetDateFromString(MonthEndDate.Text), CommissionRadioButtonList.SelectedValue,InvType);
            return dtCommision;
        }

        private void BindGridview(DataTable dtCommision)
        {
            WarrantCommSuperGridView.DataSource = dtCommision;
            WarrantCommSuperGridView.DataBind();
        }

        public void UpdateStartAndEndDate()
        {
            DateTime dtStartDate = wfs.Utility.Util.GetDateFromString(MonthEndDate.Text);
            dtStartDate = dtStartDate.AddDays(1);

            if (InvType.Equals("SFI"))
            {
                Presenter.UpdateStartAndEndDate(dtStartDate, wfs.Utility.Util.GetDateFromString(MonthEndDate.Text), SFIWFunctionSubType);
            }
            else if (InvType.Equals("PEL"))
            {
                Presenter.UpdateStartAndEndDate(dtStartDate, wfs.Utility.Util.GetDateFromString(MonthEndDate.Text), PELFunctionSubType);
            }
            else
            {
                Presenter.UpdateStartAndEndDate(dtStartDate,wfs.Utility.Util.GetDateFromString(MonthEndDate.Text),CfdWarrantsFunctionSubType);
            }
            
        }

    }
}
