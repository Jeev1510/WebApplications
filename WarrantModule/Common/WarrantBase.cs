using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebClientApplication.ApplicationModule;
using WebClientApplication.ApplicationModule.Views;

namespace WebApplication.ApplicationModule.WarrantCommon
{
    public class Warrantbase : System.Web.UI.UserControl
    {
        public Int64 EventNumber = 0;
        public WarrantElectionView Container;
        public WarrantRstViewPresenter ElectionPresenter;
        private string _resetDate = "";
        public string AccountNumber = "";
        public string RollOverT = "";
        public string ShareReceive = "";
        public string strResidualAmount = "";

        public BTIABLL.ApplicationEvent EventObject;
        //public Warrantbase()
        //{

        //}

        protected string DBConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[Session["DBKey"].ToString()].ConnectionString;

            }
        }

        public string ResetDate
        {
            get
            {
                return _resetDate;
            }
            set
            {
                _resetDate = value;
            }
        }

        


        protected void WarantEventDS_SelectObject(object sender, Csla.Web.SelectObjectArgs e)
        {
            e.BusinessObject = EventObject;
        }
        protected void WarantEventDS_UpdateObject(object sender, Csla.Web.UpdateObjectArgs e)
        {
            PreDataMapping();
            Csla.Data.DataMapper.Map(e.Values, EventObject, true);
            PostDataMapping();
        }

        protected virtual void PreDataMapping() { }
        protected virtual void PostDataMapping() { }
        public void GetTotalValueNewWarrants()
        {
            FormView fv = (FormView)this.FindControl("FormView1");
            TextBox ElectedQtyTextBox = (TextBox)fv.FindControl("txtElectedQuantity");
            TextBox TotalValueWarrantsTextBox = (TextBox)fv.FindControl("txtValNewWarrants");
            DropDownList ddl = fv.FindControl("ddlRollOverAccNum") as DropDownList;
            string strRollOverAccNum = ddl.SelectedValue;
            string TotalValueNewWarrants = "";


            strRollOverAccNum = strRollOverAccNum.Remove(3, 1);
            strRollOverAccNum = strRollOverAccNum.Insert(3, "D");
            TotalValueNewWarrants = ElectionPresenter.GetTotalValueNewWarrants(Convert.ToInt32(ElectedQtyTextBox.Text), strRollOverAccNum, ElectionPresenter.GetResetDate());
            TotalValueWarrantsTextBox.Text = TotalValueNewWarrants;
            GetClientReceivesOrPays();

        }
        public void GetClientReceivesOrPays()
        {
            int ElectedQty=0;
            decimal RolloverPrice = 0.00m;
            decimal PlannerFee = 0.00m;
            decimal ClientReceivesPays = 0.00m;
            FormView fv = (FormView)this.FindControl("FormView1");
            TextBox EventDateTextBox = (TextBox)fv.FindControl("txtElectionDate");
            TextBox ElectedQtyTextBox = (TextBox)fv.FindControl("txtElectedQuantity");
            TextBox PlannerFeeTextBox = (TextBox)fv.FindControl("txtPlannerFee");
            TextBox DeferredPriceTextBox = (TextBox)fv.FindControl("txtDeferedOverPrice");
            TextBox ClientPaysReceivesTextBox = (TextBox)fv.FindControl("txtClientPaysReceives");
            DropDownList ddl = fv.FindControl("ddlRollOverAccNum") as DropDownList;
            Label ClientPaysReceivesLabel = (Label)fv.FindControl("lblClientPaysReceives");
            string strRollOverAccNum = ddl.SelectedValue;
            if (EventDateTextBox.Text != "")
                 RolloverPrice = Convert.ToDecimal(ElectionPresenter.GetRollOverPrice(strRollOverAccNum, EventDateTextBox.Text));
            if (PlannerFeeTextBox.Text != "")
            {
                PlannerFee = Convert.ToDecimal(PlannerFeeTextBox.Text);
            }
            if (ElectedQtyTextBox.Text != "")
            {
                ElectedQty = Convert.ToInt32(ElectedQtyTextBox.Text);
            }

            //if (DeferredPriceTextBox.Text != "")
            //{
                decimal DeferredPrice = Convert.ToDecimal(DeferredPriceTextBox.Text);
            //}
            
            
            RadioButton ElectionSameOptionRadioButton = (RadioButton)fv.FindControl("rbSameUnits");
            RadioButton ElectionAdjustOptionRadioButton = (RadioButton)fv.FindControl("rbAdjustUnits");
            TextBox ShareClientReceivesTextBox = (TextBox)fv.FindControl("txtShareClientReceives");

            if (ElectionSameOptionRadioButton.Checked == true)
            {
                ClientReceivesPays = Math.Round((RolloverPrice - PlannerFee) * ElectedQty, 2);
                ClientPaysReceivesTextBox.Text = ClientReceivesPays.ToString();
                ShareClientReceivesTextBox.Text = ElectedQtyTextBox.Text;
                ElectionPresenter.ShareReceive = ShareClientReceivesTextBox.Text;
                ShareReceive = ShareClientReceivesTextBox.Text;
                if (Math.Sign(ClientReceivesPays) == 1)
                {
                    ClientPaysReceivesLabel.Text = "Client receives($)";
                    ClientPaysReceivesTextBox.ForeColor = System.Drawing.Color.Green;
                    RollOverT = "RemitAmount";

                }
                else
                {
                    ClientPaysReceivesLabel.Text = "Client pays($)";
                    ClientPaysReceivesTextBox.ForeColor = System.Drawing.Color.Red;
                    RollOverT = "ReceivePayment";
                }



            }
            else
            {

                ClientPaysReceivesTextBox.Text = ClientReceivesPays.ToString();
                decimal AdditionalUnits = (decimal)((ElectedQty * (RolloverPrice - PlannerFee) / (DeferredPrice + PlannerFee)));
                int Availqty = ElectionPresenter.GetAvailableQty();
                decimal NewPrice = 0.00m;
                // New Price
                if (PlannerFeeTextBox.Text != "")
                {
                    NewPrice = Convert.ToDecimal(PlannerFeeTextBox.Text) + Convert.ToDecimal(DeferredPriceTextBox.Text);
                }
                else
                {
                    NewPrice = Convert.ToDecimal(DeferredPriceTextBox.Text);
                }


                if (AdditionalUnits < 0)
                {
                    RollOverT = "Decreased Units";
                    AdditionalUnits = Math.Ceiling(AdditionalUnits * -1) * -1;
                                       
                }
                else
                {
                    RollOverT = "Increased Units";
                    AdditionalUnits = Math.Floor(AdditionalUnits);

                }

                decimal ResidualAmount = Convert.ToDecimal(((ElectedQty * (RolloverPrice - PlannerFee) / (DeferredPrice + PlannerFee)) - AdditionalUnits) * NewPrice);

                int NewUnitQty = Convert.ToInt32(AdditionalUnits) + ElectedQty;
                ShareClientReceivesTextBox.Text = Convert.ToString(Convert.ToInt32(NewUnitQty));
                ShareReceive = ShareClientReceivesTextBox.Text;
                strResidualAmount = ResidualAmount.ToString("N2");

            }

           

        }
    }
}