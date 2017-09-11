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
using WebClientApplication.ApplicationModule.Views;

namespace WebApplication.ApplicationModule
{

    public partial class WarrantElectionView :WebApplication.ApplicationModule.ApplicationChildBasePage<WarrantRstViewPresenter>,IwarrantElectionView
    {
        

       
        private BTIABLL.ApplicationEvent oEvent = null;
        private int eventnumber = 0;
        protected override void RegisterKey(Hashtable htKey)
        {
            base.RegisterKey(htKey);
            htKey.Add("acc_num", "");
            htKey.Add("event_type", "");
            htKey.Add("reset_date", "");
            htKey.Add("avail_qty", "");
            htKey.Add("event_num", "");
            htKey.Add("event_date", "");
           
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            this.ExceptionDetails.Value = "";
            this.ShowScript.Text = "";
            string showScript = "<script>alert(document.all('" + this.ExceptionDetails.UniqueID + "').value);</script>";
            this.FormHeader1.Title = "Election - " + Presenter.GetEventType();
            if (!IsPostBack)
            {
                if (Presenter.GetEventType().Equals("RollOver"))
                {
                    DataTable dt = new DataTable();
                    FormView fv = ElectionPlaceHolder.Controls[0].FindControl("FormView1") as FormView;
                    DropDownList ddl = (DropDownList)fv.FindControl("ddlRollOverAccNum");
                    SuperWebControl.DateControl dc = (SuperWebControl.DateControl)fv.FindControl("txtElectionDate");
                    if (string.IsNullOrEmpty(oEvent.EventDate))
                    {
                        dt = this.Presenter.GetRollOverAccNum(wfs.Utility.Util.DateToString(DateTime.Today));
                    }
                    else
                    {
                        dt = this.Presenter.GetRollOverAccNum(oEvent.EventDate);
                    }
                    RadioButton rbSame = (RadioButton)fv.FindControl("rbSameUnits");
                    RadioButton rbAdjust = (RadioButton)fv.FindControl("rbAdjustUnits");
                    TextBox txtStrikeRate = (TextBox)fv.FindControl("txtStrikerate");
                    TextBox txtPlacementFee = (TextBox)fv.FindControl("txtPlannerFee");
                    TextBox txtShareClientReceives = (TextBox)fv.FindControl("txtShareClientReceives");
                    TextBox txtValNewWarrants = (TextBox)fv.FindControl("txtValNewWarrants");
                    TextBox txtRolloverPrice = (TextBox)fv.FindControl("txtRolloverPrice");
                    TextBox ClientPaysReceivesTextBox = (TextBox)fv.FindControl("txtClientPaysReceives");

                    if (dt!= null && dt.Rows.Count > 0)
                    {
                        ddl.DataSource = dt;
                        ddl.DataValueField = "ROLLOVER_ACC_NUM";
                        ddl.DataTextField = "ROLLOVER_ACC_NUM";
                        ddl.DataBind();
                        if (!string.IsNullOrEmpty(oEvent.NewAccNum))
                        {
                            ddl.SelectedValue = oEvent.NewAccNum;
                            txtStrikeRate.Text = Presenter.GetStrikeRate(ddl.SelectedValue);
                                                        
                        }

                    }
                    else
                    {
                        this.ExceptionDetails.Value = "Rollover warrant codes not available for the selected warrant code";
                        this.ShowScript.Text = showScript;
                    }

                    string strPlanner = Presenter.GetPlannerByPortfAppNum();
                    if (Presenter.GetEventNumber() != 0)
                    {
                        BTIABLL.WarrantElection oWarrantElection = Presenter.GetWarrantEvent();
                        if (oWarrantElection != null)
                        {
                            decimal placementFee = Convert.ToDecimal(oWarrantElection.PlacementFee);
                            txtPlacementFee.Text = placementFee.ToString("N2");
                            txtRolloverPrice.Text = Convert.ToString(oEvent.UnitPrice + Convert.ToDecimal(txtPlacementFee.Text));
                        }

                        
                        if (!string.IsNullOrEmpty(oEvent.NewAccNum))
                        {
                            string TotalValueNewWarrants = "";
                            string strRollOverAccNum = oEvent.NewAccNum;
                            if (!string.IsNullOrEmpty(strRollOverAccNum))
                            {
                                strRollOverAccNum = strRollOverAccNum.Remove(3, 1);
                                strRollOverAccNum = strRollOverAccNum.Insert(3, "D");
                                TotalValueNewWarrants = Presenter.GetTotalValueNewWarrants(Convert.ToInt32(oEvent.UnitQty), strRollOverAccNum, Presenter.GetResetDate());
                                txtValNewWarrants.Text = TotalValueNewWarrants;
                            }
                        }

                        if (strPlanner != "")
                        {
                            lblPlanner.Visible = true;
                            lblPlannerText.Visible = true;
                            lblPlannerText.Text = strPlanner;
                        }
                        if (!string.IsNullOrEmpty(oEvent.RolloverType))
                        {
                            if (oEvent.RolloverType.Equals("ReceivePayment") || oEvent.RolloverType.Equals("RemitAmount"))
                            {
                                rbSame.Checked = true;
                                txtShareClientReceives.Text = Convert.ToString(Convert.ToInt32(oEvent.NewUnitQty));
                                decimal PlannerFee = 0.00m;
                                if(!string.IsNullOrEmpty(txtRolloverPrice.Text))
                                {
                                    if(!string.IsNullOrEmpty(txtPlacementFee.Text))
                                    {
                                        PlannerFee = Convert.ToDecimal(txtPlacementFee.Text);
                                    }
                                    decimal ClientPaysReceives = (Convert.ToDecimal(txtRolloverPrice.Text) - PlannerFee) * Convert.ToDecimal(oEvent.UnitQty);
                                    ClientPaysReceivesTextBox.Text = ClientPaysReceives.ToString("N2");

                                }
                            }
                            if (oEvent.RolloverType.Equals("Increased Units") || oEvent.RolloverType.Equals("Decreased Units"))
                            {
                                rbAdjust.Checked = true;
                                int shareClientReceives = Convert.ToInt32(oEvent.NewUnitQty);
                                txtShareClientReceives.Text = shareClientReceives.ToString();
                            }
                        }


                    }
                }

                if (Presenter.GetEventType().Equals("SecondPayment"))
                {
                    FormView fv = ElectionPlaceHolder.Controls[0].FindControl("FormView1") as FormView;
                    TextBox SecondpaymentTextBox = (TextBox)fv.FindControl("txtSecondpayment");
                    decimal SP = Convert.ToDecimal(oEvent.UnitPrice * oEvent.UnitQty);
                    SecondpaymentTextBox.Text = SP.ToString("N2");

                }

                if (Presenter.GetEventNumber() > 0)
                {
                    btnVerify.Visible = true;
                    btnundoVerify.Visible = true;
                    btnPushToWias.Visible = true;
                }
                else
                {
                    btnVerify.Visible = false;
                    btnundoVerify.Visible = false;
                    btnPushToWias.Visible = false;
                }

            }
        }
        protected void GetOldAccPriceDetails()
        {
            //DataTable dtOldAccPriceDetails = Presenter.GetOldAccPriceDetails();
            //txtOldWarrantCode.Text = dtOldAccPriceDetails.Rows[0].ItemArray[5].ToString();
            //txtOldQuantity.Text = dtOldAccPriceDetails.Rows[0].ItemArray[6].ToString();
            //txtOldWarrantPrice.Text = dtOldAccPriceDetails.Rows[0].ItemArray[7].ToString();
            
        }

        public void onLoaded()
        {
           
            string eventType = Presenter.GetEventType();
            

            if (Presenter.GetEventNumber() == 0)
            {
                oEvent = BTIABLL.ApplicationEvent.NewApplicationEvent();
                oEvent.EventDate = DateTime.Today.ToString("dd/MM/yyyy");
                oEvent.UnitQty = (decimal)this.Presenter.GetAvailableQty();

                oEvent.UnitPrice = Presenter.GetWarrantPrice();
            }
            else
                oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(this.ApplicationKey.PortfolioNumber.Value, this.ApplicationKey.ProductType.ToString(), this.ApplicationKey.ApplicationNumber.ToString(), wfs.Utility.Util.DateToString(this.ApplicationKey.ApplicationReceivedDate.Value), Presenter.GetEventDate(), Presenter.GetEventNumber(), Presenter.GetDbConnectionString());
            oEvent.UnitQty = Convert.ToDecimal(Convert.ToInt32(oEvent.UnitQty));
            //oEvent.EventDate = wfs.Utility.Util.DateToString(wfs.Utility.Util.GetDateFromString(oEvent.EventDate));
            //By Ragav
                //oEvent.NewUnitQty = (decimal)this.Presenter.GetAvailableQty();

            if (eventType.Equals("SecondPayment"))
            {
                LoadWarrantControl("uscSecondPayment", oEvent, this.ElectionPlaceHolder);
            }
            else if (eventType.Equals("Cash"))

                LoadWarrantControl("uscCash", oEvent, this.ElectionPlaceHolder);

            else if (eventType.Equals("RollOver"))

                LoadWarrantControl("uscRollOver", oEvent, this.ElectionPlaceHolder);



            //Load Portfolio Info.

            this.PortfolioNumberLabel.Text = Convert.ToString(this.ApplicationKey.PortfolioNumber);
            this.PortfolioNameLabel.Text = Presenter.GetClientnameByPortfNum();
            this.WarrantCodeLabel.Text = Presenter.GetWarrantCode();
            this.ApplicationNumberLabel.Text = this.ApplicationKey.ApplicationNumber;
            DateTime AppReceivedDate = (DateTime)this.ApplicationKey.ApplicationReceivedDate;
            this.AppReceivedDateLabel.Text = AppReceivedDate.ToString("dd/MM/yyyy");
            this.ResetDateLabel.Text = Presenter.GetResetDate();
            this.AvailableQtyLabel.Text = Presenter.GetAvailableQty().ToString();
            this.HiddenField2.Value = Presenter.GetAvailableQty().ToString();

        }

        protected void GetWarrantResetDetails()
        {
            //DataTable dtElectionDetails = Presenter.GetWarrantResetDetailsAcc();
            //if (dtElectionDetails != null && dtElectionDetails.Rows.Count > 0)
            //{
            //    ddlWarrantResetType.SelectedValue = dtElectionDetails.Rows[0].ItemArray[0].ToString();
            //    txtOldWarrantCode.Text = dtElectionDetails.Rows[0].ItemArray[1].ToString();
            //    txtOldQuantity.Text = dtElectionDetails.Rows[0].ItemArray[2].ToString();
            //    ddlNewWarrantCode.SelectedValue = dtElectionDetails.Rows[0].ItemArray[3].ToString();
            //    txtNewQuantity.Text = dtElectionDetails.Rows[0].ItemArray[5].ToString();
            //    txtOldWarrantPrice.Text = dtElectionDetails.Rows[0].ItemArray[6].ToString();
            //    txtNewWarrantPrice.Text = dtElectionDetails.Rows[0].ItemArray[7].ToString();
            //    txtOldSpot.Text = dtElectionDetails.Rows[0].ItemArray[8].ToString();
            //    txtOldStrike.Text = dtElectionDetails.Rows[0].ItemArray[9].ToString();
            //    txtNewSpot.Text = dtElectionDetails.Rows[0].ItemArray[10].ToString();
            //    txtNewStrike.Text = dtElectionDetails.Rows[0].ItemArray[11].ToString(); 
            //    txtCapital.Text = dtElectionDetails.Rows[0].ItemArray[12].ToString(); 
            //    txtPrepaidInterest.Text = dtElectionDetails.Rows[0].ItemArray[13].ToString(); 
            //    txtPutCost.Text = dtElectionDetails.Rows[0].ItemArray[14].ToString();
            //    txtBorrowPrice.Text = dtElectionDetails.Rows[0].ItemArray[15].ToString();

            //}


        }



        #region IApplicationChildView Members


        //public override string ErrorMsg
        //{
        //    set { this.ErrorMsgField.Text = value; }
        //}


        #endregion
        private void LoadWarrantControl(string controlName, BTIABLL.ApplicationEvent oEvent, PlaceHolder oPlaceHolder)
        {
            //string controlPath = "./";

            //if (PartyType == "I")
            //{
            //    controlPath = "./individual/";
            //}
            //else
            //{
            //    controlPath = "./org/";
            //}


            //Load general detail tab
            WarrantCommon.Warrantbase generalUC = null;
            generalUC = LoadControl(controlName + ".ascx") as WarrantCommon.Warrantbase; //as UserControl; //
            generalUC.Container = this;
            generalUC.ElectionPresenter = Presenter;
            generalUC.EventObject = oEvent;
            generalUC.AccountNumber = Presenter.GetWarrantCode();
            generalUC.ResetDate = Presenter.GetResetDate();

            //this.Controls.Add(generalUC);
            oPlaceHolder.Controls.Add(generalUC);
            generalUC.ResetDate = Presenter.GetResetDate();


        }
        private void EnableChildControls(Control ParentControl, bool isReadOnly)
        // ***************************************
        //  Author: Sridhar.V
        //  Date Created: 03-June-08
        //  Purpose: To enable and make readonly property false for the controls  
        // ***************************************
        {
            TextBox ChildTextBox;
            CheckBox ChildCheckBox;
            SuperWebControl.DateControl ChildDateControl;
            RadioButtonList ChildRadioButtonList;
            DropDownList ChildDropDownList;

            foreach (Control ChildControl in ParentControl.Controls)
            {
                if (ChildControl.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
                {
                    ChildTextBox = ChildControl as TextBox;
                    ChildTextBox.ReadOnly = isReadOnly;
                    ChildTextBox.Enabled = !isReadOnly;
                }
                else if (ChildControl.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                {
                    ChildCheckBox = ChildControl as CheckBox;
                    ChildCheckBox.Enabled = !isReadOnly;
                }
                else if (ChildControl.GetType().ToString().Equals("SuperWebControl.DateControl"))
                {
                    ChildDateControl = ChildControl as SuperWebControl.DateControl;
                    ChildDateControl.Enabled = !isReadOnly;
                    ChildDateControl.ReadOnly = isReadOnly;
                }
                else if (ChildControl.GetType().ToString().Equals("System.Web.UI.WebControls.RadioButtonList"))
                {
                    ChildRadioButtonList = ChildControl as RadioButtonList;
                    ChildRadioButtonList.Enabled = !isReadOnly;
                }

                else if (ChildControl.GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                {
                    ChildDropDownList = ChildControl as DropDownList;
                    ChildDropDownList.Enabled = !isReadOnly;
                }
                if (ChildControl.Controls.Count > 0)
                {
                    EnableChildControls(ChildControl, isReadOnly);
                }
            }
        }

        private void GetDataFromWarrantControl(BTIABLL.ApplicationEvent oEvent, PlaceHolder oPlaceHolder)
        {
            WarrantCommon.Warrantbase oBase = oPlaceHolder.Controls[0] as WarrantCommon.Warrantbase;
            oBase.EventObject = oEvent;

            FormView fv = oPlaceHolder.Controls[0].FindControl("FormView1") as FormView;
            TextBox txtReinvestAmount = fv.FindControl("txtClientPaysReceives") as TextBox;
            DropDownList ddlRollOverAccNum = fv.FindControl("ddlRollOverAccNum") as DropDownList;
            fv.UpdateItem(true);
            if (txtReinvestAmount != null && txtReinvestAmount.Text != "")
            {
                oEvent.ReinvestAmt = Convert.ToDecimal(txtReinvestAmount.Text);
            }

            if (ddlRollOverAccNum != null && ddlRollOverAccNum.SelectedValue != "")
            {
                oEvent.NewAccNum = ddlRollOverAccNum.SelectedValue;
            }

        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {


            if (hdnRetvalue.Value == "false")
            {
                return;
            }
            FormView FormView1 = ElectionPlaceHolder.Controls[0].FindControl("FormView1") as FormView;
            TextBox txtElectedQuantity = (TextBox)FormView1.FindControl("txtElectedQuantity");
            RadioButton rbSame1 = (RadioButton)FormView1.FindControl("rbSameUnits");
            RadioButton rbAdjust1 = (RadioButton)FormView1.FindControl("rbAdjustUnits");
            if (Presenter.GetEventType().Equals("RollOver"))
            {
                if (rbSame1.Checked == false && rbAdjust1.Checked == false)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "Update", "alert('Please Select Either Same or Adjust Units');", true);
                    return;
                   
                }
            }

            Presenter.UserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
           
            GetDataFromWarrantControl(oEvent, this.ElectionPlaceHolder);

            if (!string.IsNullOrEmpty(oEvent.VerifiedByUserId))
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "EventVerifiedAlredy", "alert('Changes cannot be saved because this event is already verified. Please do undoverify to edit the record.');", true);
                return;
            }

            if (Presenter.GetEventNumber() == 0)
            {
                if (Presenter.GetEventType().Equals("RollOver"))
                {
                    FormView fv = ElectionPlaceHolder.Controls[0].FindControl("FormView1") as FormView;
                    TextBox txtFinalRolloverPrice = (TextBox)fv.FindControl("txtFinalRolloverPrice");
                    HiddenField RolloverType = (HiddenField)fv.FindControl("RollOverType");
                    HiddenField ShareReceived = (HiddenField)fv.FindControl("ShareReceived");
                    HiddenField ResidualAmount = (HiddenField)fv.FindControl("ResidualAmount");
                    RadioButton rbSame = (RadioButton)fv.FindControl("rbSameUnits");
                    RadioButton rbAdjust = (RadioButton)fv.FindControl("rbAdjustUnits");
                    TextBox ElectedQty = (TextBox)fv.FindControl("txtElectedQuantity");
                    TextBox txtPlacementFee = (TextBox)fv.FindControl("txtPlannerFee");
                                        
                    if (ResidualAmount.Value != "")
                    {
                        oEvent.Residual = Convert.ToDecimal(ResidualAmount.Value);
                    }
                    if (rbAdjust.Checked)
                    {
                        if (ShareReceived.Value != "" && rbAdjust.Checked)
                        {
                            oEvent.NewUnitQty = Convert.ToDecimal(ShareReceived.Value);
                        }
                        else
                        {
                            oEvent.NewUnitQty = Convert.ToDecimal(ElectedQty.Text);
                        }
                    }
                    if (rbSame.Checked)
                    {
                        if (ShareReceived.Value != "" && rbSame.Checked)
                        {
                            oEvent.NewUnitQty = Convert.ToDecimal(ShareReceived.Value);
                        }
                        else
                        {
                            oEvent.NewUnitQty = Convert.ToDecimal(ElectedQty.Text);
                        }
                    }
                    if (RolloverType.Value != null)
                    {
                        oEvent.RolloverType = RolloverType.Value;
                    }
                    
                    if (txtFinalRolloverPrice.Text != "")
                    {
                        oEvent.UnitPrice = Convert.ToDecimal(txtFinalRolloverPrice.Text);
                    }
                    if (!string.IsNullOrEmpty(txtPlacementFee.Text))
                    {
                        Presenter.PlacementFee = txtPlacementFee.Text;
                    }

                }

                this.Presenter.OnEventSaving(oEvent, true,false,false);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Save", "alert('Information saved successfully.Click Ok to return to the Application screen');", true);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.returnValue = 0;window.close();", true);

            }
            else
            {
                if (Presenter.GetEventType().Equals("RollOver"))
                {
                    FormView fv = ElectionPlaceHolder.Controls[0].FindControl("FormView1") as FormView;
                    TextBox txtPlacementFee = (TextBox)fv.FindControl("txtPlannerFee");
                    if (!string.IsNullOrEmpty(txtPlacementFee.Text))
                    {
                        Presenter.PlacementFee = txtPlacementFee.Text;
                    }

                }
                this.Presenter.OnEventSaving(oEvent, false,false,false);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Update", "alert('Information saved successfully.Click Ok to return to the Application screen');", true);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Notify", "window.returnValue = 0;window.close();", true);

            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            Presenter.UserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
            if (!string.IsNullOrEmpty(oEvent.VerifiedByUserId))
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "AlreadyVerify", "alert('The application has been verified already.');", true);
                return;
            }
            if (oEvent.UpdatedByUserId == Presenter.UserName)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "Verify", "alert('You are the last person who saved the event. So you can not verify it');", true);
                return;
            }
          

            if (Presenter.GetEventType().Equals("SecondPayment") || (Presenter.GetEventType().Equals("RollOver") && (oEvent.RolloverType.Equals("ReceivePayment") || oEvent.RolloverType.Equals("RemitAmount"))))
            {
                if (oEvent.PaymentNum != null)
                {
                    decimal evntamt = Presenter.GetApplicationEventAmount(Convert.ToDecimal(oEvent.PaymentNum));
                    decimal Pmtamt = Presenter.GetApplicationPaymentAmount(Convert.ToDecimal(oEvent.PaymentNum));
                    //bool isAmountEqual = Presenter.CheckPaymentAgainstEventRecords();
                    if (evntamt == Pmtamt)
                    {
                        BTIABLL.ApplicationEventList oApplicationEventList = Presenter.GetApplicationEventList();
                        foreach (BTIABLL.ApplicationEvent oApplicationEvent in oApplicationEventList)
                        {
                            if (oApplicationEvent.EventType.Equals("SecondPayment") || (oApplicationEvent.EventType.Equals("RollOver") && (oApplicationEvent.RolloverType.Equals("ReceivePayment") || oApplicationEvent.RolloverType.Equals("RemitAmount"))))
                            {
                                oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(oApplicationEvent.PortfNum, oApplicationEvent.ProductType, oApplicationEvent.ApplicationNum, oApplicationEvent.ApplReceivedDate, oApplicationEvent.EventDate, oApplicationEvent.EventNum, Presenter.GetDbConnectionString());
                                oEvent.VerifiedByUserId = Presenter.UserName;
                                oEvent.VerifiedDatetime = wfs.Utility.Util.DateToString(DateTime.Now, true);
                                oEvent.UpdatedByUserId = Presenter.UserName;
                                oEvent.UpdatedDatetime = wfs.Utility.Util.DateToString(DateTime.Now, true);
                                oEvent.Status = "VALID";
                                oEvent.AmendLogProcessname = BTIABLL.Helper.GetProcessName("AM-DM", Presenter.GetDbConnectionString());
                                oEvent.Function = "AM-DM";
                                oEvent.ProcessName = "APPLICATION";
                                oEvent.Save();
                                Page.ClientScript.RegisterStartupScript(typeof(Page), "VerifySuccess1", "alert('Event Verified Successfully');", true);
                            }
                        }

                    }
                    else
                    {
                        string Eamt = evntamt.ToString();
                        string Pamt = Pmtamt.ToString();
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "NotEqual", "alert('Cannot complete verification because one of the following reasons. 1)There is no Corresponding payment for this event. 2)Payment is created but not linked to the events. 3)Payment amount " + Pamt + " does Not tally to total events amount " + Eamt + "');", true);
                        return;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "NotPaymentCreated", "alert('Cannot complete verification because one of the following reasons. 1)There is no Corresponding payment for this event. 2)Payment is created but not linked to the events.');", true);
                    return;
                }
                
            }
            else
            {
                oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(this.ApplicationKey.PortfolioNumber.Value, this.ApplicationKey.ProductType.ToString(), this.ApplicationKey.ApplicationNumber.ToString(), wfs.Utility.Util.DateToString(this.ApplicationKey.ApplicationReceivedDate.Value), Presenter.GetEventDate(), Presenter.GetEventNumber(), Presenter.GetDbConnectionString());
                this.Presenter.OnEventSaving(oEvent, false, true, false);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "VerifySuccess2", "alert('Event Verified Successfully');", true);

            }
            Page.ClientScript.RegisterStartupScript(typeof(Page), "VerifyNotify", "window.returnValue = 0;window.close();", true);

        }

        protected void btnundoVerify_Click(object sender, EventArgs e)
        {
            Presenter.UserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
           
            if (string.IsNullOrEmpty(oEvent.VerifiedByUserId))
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "UndoVerify1", "alert('The application event has not been verified yet.');", true);
                return;
            }
            if (!string.IsNullOrEmpty(oEvent.VerifiedByUserId) && Presenter.UserName == oEvent.EnteredByUserId)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "UndoVerify2", "alert('You are the person who saved the event. So you can not undo verify it.');", true);
                return;
            }
            if (Presenter.GetEventType().Equals("SecondPayment") || (Presenter.GetEventType().Equals("RollOver") && (oEvent.RolloverType.Equals("ReceivePayment") || oEvent.RolloverType.Equals("RemitAmount"))))
            {
                BTIABLL.ApplicationEventList oApplicationEventList = Presenter.GetApplicationEventList();
                foreach (BTIABLL.ApplicationEvent oApplicationEvent in oApplicationEventList)
                {
                    if (oApplicationEvent.EventType.Equals("SecondPayment") || (oApplicationEvent.EventType.Equals("RollOver") && (oApplicationEvent.RolloverType.Equals("ReceivePayment") || oApplicationEvent.RolloverType.Equals("RemitAmount"))))
                    {
                        oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(oApplicationEvent.PortfNum, oApplicationEvent.ProductType, oApplicationEvent.ApplicationNum, oApplicationEvent.ApplReceivedDate, oApplicationEvent.EventDate, oApplicationEvent.EventNum, Presenter.GetDbConnectionString());
                        oEvent.VerifiedByUserId = null;
                        oEvent.VerifiedDatetime = null;
                        oEvent.UpdatedByUserId = Presenter.UserName;
                        oEvent.UpdatedDatetime = wfs.Utility.Util.DateToString(DateTime.Now, true);
                        oEvent.Status = "PENDING";
                        oEvent.AmendLogProcessname = BTIABLL.Helper.GetProcessName("AM-DM", Presenter.GetDbConnectionString());
                        oEvent.Function = "AM-DM";
                        oEvent.ProcessName = "APPLICATION";
                        oEvent.Save();
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "UndoVerifySuccess", "alert('Event UndoVerified Successfully');", true);
                    }
                }
            }

            else
            {
                oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(this.ApplicationKey.PortfolioNumber.Value, this.ApplicationKey.ProductType.ToString(), this.ApplicationKey.ApplicationNumber.ToString(), wfs.Utility.Util.DateToString(this.ApplicationKey.ApplicationReceivedDate.Value), Presenter.GetEventDate(), Presenter.GetEventNumber(), Presenter.GetDbConnectionString());
                Presenter.UserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
                this.Presenter.OnEventSaving(oEvent, false, false, false);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "UndoVerifySuccess1", "alert('Event UndoVerified Successfully');", true);
            }

            Page.ClientScript.RegisterStartupScript(typeof(Page), "UndoVerifyNotify", "window.returnValue = 0;window.close();", true);
           
        }

        protected void btnPushToWias_Click(object sender, EventArgs e)
        {
            Presenter.UserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
            if (!oEvent.Status.Equals("VALID"))
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "NOTVALID", "alert('The application event can not be Pushed To Wias (either has not been verified or has been pushed to Wias already).');", true);
                return;
            }
            if (Presenter.GetEventType().Equals("SecondPayment") || (Presenter.GetEventType().Equals("RollOver") && (oEvent.RolloverType.Equals("ReceivePayment") || oEvent.RolloverType.Equals("RemitAmount"))))
            {
                BTIABLL.ApplicationEventList oApplicationEventList = Presenter.GetApplicationEventList();
                foreach (BTIABLL.ApplicationEvent oApplicationEvent in oApplicationEventList)
                {
                    if (oApplicationEvent.EventType.Equals("SecondPayment") || (oApplicationEvent.EventType.Equals("RollOver") && (oApplicationEvent.RolloverType.Equals("ReceivePayment") || oApplicationEvent.RolloverType.Equals("RemitAmount"))))
                    {
                        oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(oApplicationEvent.PortfNum, oApplicationEvent.ProductType, oApplicationEvent.ApplicationNum, oApplicationEvent.ApplReceivedDate, oApplicationEvent.EventDate, oApplicationEvent.EventNum, Presenter.GetDbConnectionString());
                        oEvent.Status = "PRICED";
                        oEvent.AmendLogProcessname = BTIABLL.Helper.GetProcessName("AM-DM", Presenter.GetDbConnectionString());
                        oEvent.Function = "AM-DM";
                        oEvent.ProcessName = "APPLICATION";
                        oEvent.Save();
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "PushToWias1", "alert('The application has been successfully pushed to wias.');", true);

                    }
                }
            }
            else
            {

                oEvent = BTIABLL.ApplicationEvent.GetApplicationEvent(this.ApplicationKey.PortfolioNumber.Value, this.ApplicationKey.ProductType.ToString(), this.ApplicationKey.ApplicationNumber.ToString(), wfs.Utility.Util.DateToString(this.ApplicationKey.ApplicationReceivedDate.Value), Presenter.GetEventDate(), Presenter.GetEventNumber(), Presenter.GetDbConnectionString());
                Presenter.UserName = wfs.Utility.Util.GetNetworkLogon(Page.User.Identity.Name);
                this.Presenter.OnEventSaving(oEvent, false, false, true);
                Page.ClientScript.RegisterStartupScript(typeof(Page), "PushToWias", "alert('The application has been successfully pushed to wias.');", true);
            }

            Page.ClientScript.RegisterStartupScript(typeof(Page), "PushToWiasNotify", "window.returnValue = 0;window.close();", true);
        }
            
            
     
    }
}
