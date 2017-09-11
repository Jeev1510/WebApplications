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
using BTIADAL;


namespace WebApplication.ApplicationModule
{

     
    public partial class uscRollover : WebApplication.ApplicationModule.WarrantCommon.Warrantbase
    {

        string _dbConnectionString = "";
        string _dbKey = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
           WarrantElectionView objss ;
            
        }

        public string DbKey
        {
            get
            {
                if (string.IsNullOrEmpty(_dbKey))
                {
                    if (!string.IsNullOrEmpty(Request.Params["m_db"]))
                    {
                        _dbKey = Request.Params["m_db"];

                    }
                    else
                    {
                        _dbKey = Session["DbKey"].ToString();
                    }

                }
                return _dbKey;
            }
        }

        public string DbConnectionString
        {
            get
            {

                if (string.IsNullOrEmpty(_dbConnectionString))
                {


                    _dbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[DbKey].ConnectionString;
                }

                return _dbConnectionString;

            }

        }

        


        protected void ddlRollOverAccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ExceptionDetails.Value = "";
            this.ShowScript.Text = "";
            string showScript = "<script>alert(document.all('" + this.ExceptionDetails.UniqueID + "').value);</script>";
            TextBox txtStrikeRate = this.FormView1.FindControl("txtStrikerate") as TextBox;
            TextBox txtRolloverPrice = this.FormView1.FindControl("txtRolloverPrice") as TextBox;
            TextBox EventDateTextBox = this.FormView1.FindControl("txtElectionDate") as TextBox;
            TextBox txtPlannerFee = this.FormView1.FindControl("txtPlannerFee") as TextBox;
            TextBox txtFinalRolloverPrice = this.FormView1.FindControl("txtFinalRolloverPrice") as TextBox;
            TextBox txtValNewWarrants = this.FormView1.FindControl("txtValNewWarrants") as TextBox;
            TextBox txtClientPaysReceives = this.FormView1.FindControl("txtClientPaysReceives") as TextBox;
            TextBox txtShareClientReceives = this.FormView1.FindControl("txtShareClientReceives") as TextBox;
            DropDownList ddl = this.FormView1.FindControl("ddlRollOverAccNum") as DropDownList;
            RadioButton ElectionSameOptionRadioButton = (RadioButton)this.FormView1.FindControl("rbSameUnits");
            RadioButton ElectionAdjustOptionRadioButton = (RadioButton)this.FormView1.FindControl("rbAdjustUnits");
            ElectionSameOptionRadioButton.Checked = false;
            ElectionAdjustOptionRadioButton.Checked = false;
            txtPlannerFee.Text = "";
            txtStrikeRate.Text = "";
            txtRolloverPrice.Text = "";
            txtFinalRolloverPrice.Text = "";
            txtValNewWarrants.Text = "";
            txtClientPaysReceives.Text = "";
            txtShareClientReceives.Text = "";
            if (ddl.SelectedValue != "" && EventDateTextBox.Text != "")
            {

                string strRollOverAccNum = ddl.SelectedValue;
                strRollOverAccNum = strRollOverAccNum.Remove(3, 1);
                strRollOverAccNum = strRollOverAccNum.Insert(3, "D");
                DataTable dt = GetDeferredPrice(strRollOverAccNum, EventDateTextBox.Text);
                TextBox txtDefered = this.FormView1.FindControl("txtDeferedOverPrice") as TextBox;
                
                
                if (dt.Rows.Count > 0)
                {
                    txtDefered.Text = dt.Rows[0].ItemArray[0].ToString();
                    hdnStrikeRate.Value = GetStrikeRate(ddl.SelectedValue, this.ResetDate);
                    txtStrikeRate.Text = hdnStrikeRate.Value;
                    txtRolloverPrice.Text = ElectionPresenter.GetRollOverPrice(ddl.SelectedValue, EventDateTextBox.Text);
                    if (txtFinalRolloverPrice.Text == "")
                    {
                        txtFinalRolloverPrice.Text = txtRolloverPrice.Text;
                    }


                }
                else
                {
                    txtStrikeRate.Text = "";
                    this.ExceptionDetails.Value = "Deferred price is not available for the selected account number";
                    this.ShowScript.Text = showScript;
                }
            }
      
        }

       

        protected void txtcommissionpt_TextChanged(object sender, EventArgs e)
        {
            TextBox txtcommissionpt = this.FormView1.FindControl("txtcommissionpt") as TextBox;
            TextBox txtStrikeRate = this.FormView1.FindControl("txtStrikerate") as TextBox;
            TextBox txtRolloverPrice = this.FormView1.FindControl("txtRolloverPrice") as TextBox;
            TextBox txtPlannerFee = this.FormView1.FindControl("txtPlannerFee") as TextBox;
            TextBox txtFinalRolloverPrice = this.FormView1.FindControl("txtFinalRolloverPrice") as TextBox;
            //HiddenField hdnPlannerFee = this.FormView1.FindControl("hdnPlannerFee") as HiddenField;

            if (txtcommissionpt.Text != "" && Convert.ToDecimal(txtcommissionpt.Text) >0)
            {
                if (txtStrikeRate.Text != "" && Convert.ToDecimal(txtStrikeRate.Text) > 0)
                {
                    decimal strikeRate = Convert.ToDecimal(txtStrikeRate.Text);
                    string strStrikeRate = strikeRate.ToString("N1");
                    if (strStrikeRate.Contains("."))
                    {
                        strStrikeRate = strStrikeRate.Substring(strStrikeRate.IndexOf("."));
                        strStrikeRate = strStrikeRate.Remove(0, 1);
                        int SRate = Convert.ToInt32(strStrikeRate);
                        if (SRate < 5)
                        {
                            strikeRate = strikeRate + 1;
                            decimal plnrFee = (strikeRate * Convert.ToDecimal(txtcommissionpt.Text)) / 100;
                            txtPlannerFee.Text = plnrFee.ToString("N2");
                            hdnPlannerFee.Value = txtPlannerFee.Text;
                            if (txtRolloverPrice.Text != "" && Convert.ToDecimal(txtRolloverPrice.Text) != 0)
                            {
                                decimal RollOverPrice = Convert.ToDecimal(txtRolloverPrice.Text);
                                txtRolloverPrice.Text = RollOverPrice.ToString("N2");
                            }
                            else
                            {
                                txtRolloverPrice.Text = "0";
                            }
                            
                            txtFinalRolloverPrice.Text = Convert.ToString(Convert.ToDecimal(txtRolloverPrice.Text) - Convert.ToDecimal(txtPlannerFee.Text));
                        }
                        else
                        {
                            decimal PF = (strikeRate * Convert.ToDecimal(txtcommissionpt.Text)) / 100;
                            txtPlannerFee.Text = PF.ToString("N2");
                            hdnPlannerFee.Value = txtPlannerFee.Text;
                            txtFinalRolloverPrice.Text = Convert.ToString(Convert.ToDecimal(txtRolloverPrice.Text) - Convert.ToDecimal(txtPlannerFee.Text));
                        }


                    }
                    else
                    {
                        txtPlannerFee.Text = Convert.ToString((strikeRate * Convert.ToDecimal(txtcommissionpt.Text)) / 100);
                        hdnPlannerFee.Value = txtPlannerFee.Text;
                        txtFinalRolloverPrice.Text = Convert.ToString(Convert.ToDecimal(txtRolloverPrice.Text) - Convert.ToDecimal(txtPlannerFee.Text));
                    }

                }
                
            }
            else
            {
                txtFinalRolloverPrice.Text = txtRolloverPrice.Text;

            }

            
        }

        
        protected void txtElectionDate_TextChanged(object sender, EventArgs e)
        {
            DropDownList ddl = this.FormView1.FindControl("ddlRollOverAccNum") as DropDownList;
            TextBox Eventdate = this.FormView1.FindControl("txtElectionDate") as TextBox;
            DataTable dt1;
            if (ddl != null && ddl.Items.Count > 0)
            {                
                ddl.Items.Clear();
                ddl.Items.Add("--Please select--");
            }
            if (Eventdate.Text != "")
            {
                dt1 = GetRollOverAccNum(AccountNumber, Eventdate.Text);
                ddl.DataSource = dt1;
                ddl.DataValueField = "ROLLOVER_ACC_NUM";
                ddl.DataTextField = "ROLLOVER_ACC_NUM";
                ddl.DataBind();
            }
            //if (ddl.SelectedValue != "" && this.ResetDate != "")
            //{

            //    string strRollOverAccNum = ddl.SelectedValue;
            //    strRollOverAccNum = strRollOverAccNum.Remove(3, 1);
            //    strRollOverAccNum = strRollOverAccNum.Insert(3, "D");
            //    DataTable dt = GetDeferredPrice(strRollOverAccNum, this.ResetDate);
            //    TextBox txtDefered = this.FormView1.FindControl("txtDeferedOverPrice") as TextBox;
            //    if (dt.Rows.Count > 0)
            //        txtDefered.Text = dt.Rows[0].ItemArray[0].ToString();
                
            //}
        }

        public DataTable GetRollOverAccNum(string AccNum, string Effectivedate)
        {
            BTIADAL.WarrantsRst.IA_ACC_WRNT_ROLL_PRICEDataTable oT = null;
            BTIADAL.WarrantsRstTableAdapters.IA_ACC_WRNT_ROLL_PRICETableAdapter oTA = new BTIADAL.WarrantsRstTableAdapters.IA_ACC_WRNT_ROLL_PRICETableAdapter();

            using (BTIADAL.ITableAdpaterHelper ITaHelper = BTIADAL.TableAdapterHelperFactory.GetHelper(
                        this.DbConnectionString, oTA)
                        )
            {
                oT = oTA.GetDataByAccNum(AccNum, wfs.Utility.Util.GetDateFromString(Effectivedate));

            }

            return oT;

        }


        public DataTable GetDeferredPrice(string strRollOverAccNum,string PriceDate)
        {
           
            BTIADAL.WarrantsRst.IA_ACC_WRNT_PRICEDataTable oT = null;
            BTIADAL.WarrantsRstTableAdapters.IA_ACC_WRNT_PRICETableAdapter oTA = new BTIADAL.WarrantsRstTableAdapters.IA_ACC_WRNT_PRICETableAdapter();

            using (BTIADAL.ITableAdpaterHelper ITaHelper = BTIADAL.TableAdapterHelperFactory.GetHelper(
                       this.DbConnectionString, oTA)
                        )
            {
                oT = oTA.GetDataByAccPriceDate(strRollOverAccNum, wfs.Utility.Util.GetDateFromString(PriceDate));

           }

                  return oT;
        }

        public string GetStrikeRate(string strRollOverAccNum, string resetdate)
        {
            BTIADAL.WarrantsRst.IA_ACC_INV_ACTIONDataTable oT = null;
            BTIADAL.WarrantsRstTableAdapters.IA_ACC_INV_ACTIONTableAdapter oTA = new BTIADAL.WarrantsRstTableAdapters.IA_ACC_INV_ACTIONTableAdapter();

            using (BTIADAL.ITableAdpaterHelper ITaHelper = BTIADAL.TableAdapterHelperFactory.GetHelper(
                        this.DbConnectionString, oTA)
                        )
            {
                oT = oTA.GetDataByAccNumPriceDate(strRollOverAccNum, wfs.Utility.Util.GetDateFromString(resetdate));

            }
            if (oT.Rows.Count > 0)
                return oT.Rows[0].ItemArray[0].ToString();
            else
                return "";
          
        }

        protected void rbSameUnits_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton SameUnitsRadioButton = (RadioButton)sender;
            if (SameUnitsRadioButton.Checked == true)
                GetTotalValueNewWarrants();
            
            HiddenField RollOverType = this.FormView1.FindControl("RollOverType") as HiddenField;
            HiddenField ShareReceived = this.FormView1.FindControl("ShareReceived") as HiddenField;
            HiddenField Residual = this.FormView1.FindControl("ResidualAmount") as HiddenField;
            Residual.Value = strResidualAmount;
            RollOverType.Value = RollOverT;
            ShareReceived.Value = ShareReceive;

        }

        protected void rbAdjustUnits_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton AdjustUnitsRadioButton = (RadioButton)sender;
            if (AdjustUnitsRadioButton.Checked == true)
                GetTotalValueNewWarrants();

            HiddenField RollOverType = this.FormView1.FindControl("RollOverType") as HiddenField;
            HiddenField ShareReceived = this.FormView1.FindControl("ShareReceived") as HiddenField;
            HiddenField Residual = this.FormView1.FindControl("ResidualAmount") as HiddenField;
            Residual.Value = strResidualAmount;
            RollOverType.Value = RollOverT;
            ShareReceived.Value = ShareReceive;
        }

              
    }
}