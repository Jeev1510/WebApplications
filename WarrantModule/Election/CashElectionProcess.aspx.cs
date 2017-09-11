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

//WebApplication.RelatedPartyModule.RelatedPartyContainer
namespace WebApplication.WarrantModule
{
    public partial class CashElectionProcess : CompositeWeb.Extensions.BasePage<CashElectionPresenter>, ICashElectionView
    {

        private void ShowResetdates()
        {
            if (!IsPostBack)
            {
                DropDownList ddl = (DropDownList)FindControlRecursive(this.Master,"ResetDateDropdown");
                ddl.DataSource = this.Presenter.GetResetDates();
                ddl.DataValueField = "Effective_Date";
                ddl.DataTextField = "Effective_Date";

                ddl.DataBind();

                ShowPositiondates(wfs.Utility.Util.GetDateFromString(ddl.SelectedValue));
            }
        }

        private void ShowPositiondates(DateTime ResetDate)
        {
            if (!IsPostBack)
            {
                DropDownList ddl = (DropDownList)FindControlRecursive(this.Master, "PositionDateDropdown");
                ddl.DataSource = this.Presenter.GetPositionDates(ResetDate,10);
                ddl.DataValueField = "ReturnDate";
                ddl.DataTextField = "ReturnDate";
                ddl.DataTextFormatString = "{0:dd/MM/yyyy}";
                ddl.DataBind();
            }
        }

        private void SetCashElectionDataSource(DateTime ResetDate, string Option, string AllOrNoneOnly, string UserID, DateTime ElectionDate,DateTime PositionDate)
        {
            DataTable CashElectionDataTable=null;
            SuperWebControl.SuperGridview grid = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "CashElectionSuperGridView");
            SuperWebControl.SuperGridview grid1 = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "CashElectionDetailSuperGridView");
            Label DisplayNumberLaabel = (Label)FindControlRecursive(this.Master, "DisplayNumberLaabel");
            if (Option == "Summary")
            {
                grid1.Visible = false;
                grid.Visible = true;
                CashElectionDataTable = this.Presenter.GetWarrantResetNone(ResetDate, Option, AllOrNoneOnly, UserID, ElectionDate,PositionDate);
                grid.DataSource = CashElectionDataTable;
                grid.DataBind();
                DisplayNumberLaabel.Text = CashElectionDataTable.Rows.Count.ToString();
            }
            else if (Option == "Detail")
            {
                grid.Visible = false;
                grid1.Visible = true;
                CashElectionDataTable = this.Presenter.GetWarrantResetNone(ResetDate, Option, AllOrNoneOnly, UserID, ElectionDate, PositionDate);
                grid1.DataSource = CashElectionDataTable;
                grid1.DataBind();
                DisplayNumberLaabel.Text = CashElectionDataTable.Rows.Count.ToString();
            }
            

        }
        public void SetCashElection()
        {
            string ResetDate = "";
            string ElectionOption = "";
            string ElectionOptionAllorNone = "";
            string UserID = "";
            string ElectionDate = "";
            string positiondate = "";

            DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            RadioButtonList OptionRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "OptionRadioButtonList");
            RadioButtonList ProcessRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "ProcessRadioButtonList");
            SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");
            DropDownList PositionDate = (DropDownList)FindControlRecursive(this.Master, "PositionDateDropdown");

            ElectionOption = OptionRadioButtonList.SelectedValue;
            ElectionOptionAllorNone = ProcessRadioButtonList.SelectedValue;
            ResetDate = ResetSWCDate.Text.ToString();
            UserID = wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name);
            ElectionDate = this.EventDate.Text.ToString();
            positiondate = PositionDate.Text.ToString();

            if (ElectionDate.Length != 0)
                {
                    SetCashElectionDataSource(wfs.Utility.Util.GetDateFromString(ResetDate), ElectionOption, ElectionOptionAllorNone, UserID, wfs.Utility.Util.GetDateFromString(ElectionDate), wfs.Utility.Util.GetDateFromString(positiondate));
                }
            else
                {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "ElectionDate", "alert('Please select the event date');", true);
                }
        }

        public void CashExecutionNoneButton_Click(object sender, EventArgs e)
        {
            Execute(sender, e);
        }
        public void DealExecutionNoneButton_Click(object sender, EventArgs e)
        {
            ExecuteDeal(sender, e);
        }

        public void ExecuteDeal(object sender, EventArgs e)
        {
            DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            bool isDealCreated=false;
            Presenter.CreateDeal(wfs.Utility.Util.GetDateFromString(ResetSWCDate.Text.ToString()));
            isDealCreated = Presenter.isDealCreated;
            if (isDealCreated == true)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventSuccess", "alert('Information saved successfully');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventSuccess", "alert('Error in creating deal record');", true);     
            }
        }

        public void Execute(object sender, EventArgs e)
        {
            RadioButtonList ProcessRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "ProcessRadioButtonList");
            DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");
            DropDownList PositionDate = (DropDownList)FindControlRecursive(this.Master, "PositionDateDropdown");
            RadioButtonList OptionRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "OptionRadioButtonList");

            DataTable CashElectionDataTable=null;
            string ResetDate = "";
            string ElectionOptionAllorNone = "";
            string UserID = "";
            string ElectionDate = "";
            string positiondate = "";

                
            ElectionOptionAllorNone = ProcessRadioButtonList.SelectedValue;
            ResetDate = ResetSWCDate.Text.ToString();
            UserID = wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name);
            ElectionDate = this.EventDate.Text.ToString();
            positiondate = PositionDate.Text.ToString();

            CashElectionDataTable = this.Presenter.GetWarrantResetNone(wfs.Utility.Util.GetDateFromString(ResetDate), "CreateEvent", ElectionOptionAllorNone, UserID, wfs.Utility.Util.GetDateFromString(ElectionDate), wfs.Utility.Util.GetDateFromString(positiondate));
            if (CashElectionDataTable.Rows.Count > 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventSuccess", "alert('Information saved successfully in WIAS');", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "EventFailure", "alert('Error in saving information');", true);
                return;
            }
            OptionRadioButtonList.Items[1].Selected = true;
            ProcessRadioButtonList.Items[1].Selected = true;
            
            SetCashElectionDataSource(wfs.Utility.Util.GetDateFromString(ResetDate), "Detail", "NoneOnly", UserID, wfs.Utility.Util.GetDateFromString(ElectionDate), wfs.Utility.Util.GetDateFromString(positiondate));
        }
        private void ExportToExcelFromDataTable(DataTable WarrantResetExcel, string excelfilename)
        {
            //object missing2 = Type.Missing;
            ////Create an Excel file
            //Microsoft.Office.Interop.Excel.Application objxl;
            //Microsoft.Office.Interop.Excel.Workbooks objwbs;
            //Microsoft.Office.Interop.Excel.Workbook objwb;
            //Microsoft.Office.Interop.Excel.Worksheet objws;
            //int colindex = 0;
            //int rowindex;
            //string workSpace = System.Configuration.ConfigurationManager.AppSettings["RPTWORKSPACE"];
            //objxl = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook WB = (Microsoft.Office.Interop.Excel.Workbook)objxl.Workbooks.Add(missing2);
            //objwbs = objxl.Workbooks;
            //objwb = (Microsoft.Office.Interop.Excel.Workbook)objwbs.Add(missing2);

            //objws = (Microsoft.Office.Interop.Excel.Worksheet)objwb.Worksheets.Add(missing2, missing2, missing2, missing2);
            ////load the columns names to the excel
            //foreach (DataColumn col in WarrantResetExcel.Columns)
            //{
            //    colindex += 1;
            //    objws.Cells[1, colindex] = col.ColumnName;

            //}
            //rowindex = 1;
            ////load the values to the excel
            //foreach (DataRow mrow in WarrantResetExcel.Rows)
            //{

            //    rowindex += 1;

            //    colindex = 0;

            //    foreach (DataColumn col in WarrantResetExcel.Columns)
            //    {

            //        colindex += 1;
            //        objws.Cells[rowindex, colindex] = mrow[col.ColumnName].ToString();

            //    }
            //}
            ////save in system
            //objwb.SaveAs(excelfilename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missing2, missing2, missing2, missing2, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, missing2, missing2, missing2, missing2);
            ////Release the excel object         
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(objws);
            //objxl.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(objxl);
            //objws = null;
            //objwb = null;
            //objwbs = null;
            //objxl = null;
            //OpenExcel(excelfilename);
        }
        private string OpenExcel(string FileName)
        {
            try
            {
                if (System.IO.File.Exists(FileName))
                {
                    string attachfilename = "";
                    attachfilename = "JDVRec" + ".xls";
                    string attachment = "attachment; filename=" + attachfilename;
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    HttpContext.Current.Response.WriteFile(FileName);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //Response.End();
                }
                return "Sucessfully completed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public void ReportButton_Click(object sender, EventArgs e)
        {
            
            DataTable CashElectionDataTable;
            string ResetDate = "";
            string ElectionOption = "";
            string ElectionOptionAllorNone = "";
            string UserID = "";
            string ElectionDate = "";
            string positionDate = "";

            DropDownList ResetSWCDate = (DropDownList)FindControlRecursive(this.Master, "ResetDateDropdown");
            RadioButtonList OptionRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "OptionRadioButtonList");
            RadioButtonList ProcessRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "ProcessRadioButtonList");
            SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");
            DropDownList PositionDate = (DropDownList)FindControlRecursive(this.Master, "PositionDateDropdown");

            ElectionOption = OptionRadioButtonList.SelectedValue;
            ElectionOptionAllorNone = ProcessRadioButtonList.SelectedValue;
            ResetDate = ResetSWCDate.Text.ToString();
            UserID = wfs.Utility.Util.GetNetworkLogon(this.Page.User.Identity.Name);
            ElectionDate = this.EventDate.Text.ToString();
            positionDate = PositionDate.Text.ToString();

            if (ElectionDate.Length != 0)
            {
                CashElectionDataTable = this.Presenter.GetWarrantResetNone(wfs.Utility.Util.GetDateFromString(ResetDate), ElectionOption, ElectionOptionAllorNone, UserID, wfs.Utility.Util.GetDateFromString(ElectionDate),wfs.Utility.Util.GetDateFromString(positionDate));
                if (CashElectionDataTable.Rows.Count > 0)
                {
                    string workSpace = System.Configuration.ConfigurationManager.AppSettings["RPTWORKSPACE"];
                    string xmlFilename = "";
                    string xslFileName = "WarrantSummaryAll.xsl";
                    if (!System.IO.Directory.Exists(workSpace))
                    {
                        System.IO.Directory.CreateDirectory(workSpace);
                    }
                    xmlFilename = workSpace + "\\" + "WarrantReset1.xml";
                    if (System.IO.File.Exists(xmlFilename))
                    {
                        System.IO.File.Delete(xmlFilename);
                    }
                    CashElectionDataTable.WriteXml(xmlFilename,false);
                    XMLtoEXCEL(xmlFilename, xslFileName, CashElectionDataTable);
                    //ExportToExcelFromDataTable(CashElectionDataTable, workSpace);

                    //CashElectionDataTable.WriteXml(workSpace, true);
                    //System.Xml.XmlDocument xmlToExcel = new System.Xml.XmlDocument();
                   
                    //if (File.Exists(FileName))
                    //{
                    //    xmlToExcel.LoadXml(workSpace);
                    //    System.Xml.XmlNodeList listExcel;
                    //    System.Xml.XmlNode NodelExcel;
                    //    listExcel = xmlToExcel.SelectNodes("//SP_SIS_Get_Warrant_Reset_None");
                        
                    //}
                    //objxl = new Microsoft.Office.Interop.Excel.Application();
                    //Microsoft.Office.Interop.Excel.Workbook WB = (Microsoft.Office.Interop.Excel.Workbook)objxl.Workbooks.Add(missing2);
                    //objwbs = objxl.Workbooks;
                    //objwb = (Microsoft.Office.Interop.Excel.Workbook)objwbs.Add(missing2);
                    //objws = (Microsoft.Office.Interop.Excel.Worksheet)objwb.Worksheets.Add(missing2, missing2, missing2, missing2);
                    //foreach (System.Xml.XmlNode NodelExcel in XmlNodeList)
                    //{

                    //    NodeCounter = NodeCounter +1;
                    //    objws.Cells[
                    //}

          }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "ElectionDate", "alert('Please enter/select the event date');", true);
            }

        }
        private void XMLtoEXCEL( string xmlfilename,string xslFileName,DataTable objWarrants)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Charset = "";
            DataSet oxmlDataSet = new DataSet();
            oxmlDataSet.ReadXml(xmlfilename);
            System.Xml.XmlDataDocument xdd = new System.Xml.XmlDataDocument(oxmlDataSet);
            System.Xml.Xsl.XslTransform xt = new System.Xml.Xsl.XslTransform();
            xt.Load(Server.MapPath(@"XSL\" + xslFileName));
            xt.Transform(xdd, null, Response.OutputStream);
            HttpContext.Current.Response.End();
        }
        private void XMLtoEXCEL_1(string htmfilename, string xslfilename,DataTable objWarrants)
        {
            DataSet oxmlDataSet = new DataSet();
            oxmlDataSet.Tables.Add(objWarrants);
            string strFilename = htmfilename;
            System.IO.FileStream fs = new System.IO.FileStream(strFilename,System.IO.FileMode.Create);
            System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(fs,System.Text.Encoding.Unicode);
            System.Xml.XmlDataDocument xmlDoc = new System.Xml.XmlDataDocument(oxmlDataSet);
            System.Xml.Xsl.XslTransform xslTran = new System.Xml.Xsl.XslTransform();
            xslTran.Load(Server.MapPath(@"XSL\" + xslfilename));
            xslTran.Transform(xmlDoc,null, xtw);
            oxmlDataSet.WriteXml(xtw);
            xtw.Close();
         }
        protected void OptionRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList OptionRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "OptionRadioButtonList");
            string ElectionOption = OptionRadioButtonList.SelectedValue;
            if (ElectionOption.Length != 0)
                SetCashElection();
        }

        protected void ProcessRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList ProcessRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "ProcessRadioButtonList");
            string ElectionOption = ProcessRadioButtonList.SelectedValue;
            if (ElectionOption.Length != 0)
                SetCashElection();
        }
        protected void ResetDateDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList OptionRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "OptionRadioButtonList");
            RadioButtonList ProcessRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "ProcessRadioButtonList");

            string ElectionOtion = OptionRadioButtonList.SelectedValue;
            if (ElectionOtion.Length != 0)
                SetCashElection();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Master.m_TaskList.IndexOf(Constant.Task_WarrantResetNone) < 0)
            {
                //Master.ShowNoAccess();
                //return;
                Response.Redirect("../AccessDenied.aspx");
            }
        }
        #region IRelatedPartyContainer Members
        public void onLoaded()
        {
            DateTime ResetDate;
            SuperWebControl.FormHeader CashElectionHeader = (SuperWebControl.FormHeader)FindControlRecursive(this.Master, "CashElectionHeader");
            this.CashElectionHeader.Title = "Warrant Reset - None";
            SuperWebControl.SuperGridview WarrantResetSummaryGridView = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "CashElectionSuperGridView");
            SuperWebControl.SuperGridview WarrantResetDetailGridView = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "CashElectionDetailSuperGridView");


            WarrantResetSummaryGridView.Menu.AddButton("Print To Excel", "doPrint()", "", " Print to excel", "btn1printtoEXCEL");
            WarrantResetDetailGridView.Menu.AddButton("Print To Excel", "doPrint()", "", " Print to excel", "btn2printtoEXCEL");


            if (!IsPostBack)
            {
                RadioButtonList OptionRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "OptionRadioButtonList");
                RadioButtonList ProcessRadioButtonList = (RadioButtonList)FindControlRecursive(this.Master, "ProcessRadioButtonList");
                SuperWebControl.DateControl EventDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EventDate");

                EventDate.Text = DateTime.Today.ToString();
                ShowResetdates();
                OptionRadioButtonList.Items[1].Selected = true;
                ProcessRadioButtonList.Items[1].Selected = true;
                
                string ElectionOption = OptionRadioButtonList.SelectedValue;
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
