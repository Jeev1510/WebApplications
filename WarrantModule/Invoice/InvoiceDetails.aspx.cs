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
    public partial class InvoiceDetails : CompositeWeb.Extensions.BasePage<PlannerInvoiceViewPresenter>, IPlannerInvoiceView
    {
        SuperWebControl.DateControl StartTranDate = null;
        SuperWebControl.DateControl EndTranDate = null;
        SuperWebControl.DateControl CommInvoicedate = null;
        SuperWebControl.SuperGridview gridView = null;
        DataTable objectDataSource = null;
        DateTime trxstartdate;
        DateTime trxenddate;
        DateTime comminvoicedate;

        public void onLoaded()
        {
            InitiateControls();

            if (!Page.IsPostBack)
            {
                StartTranDate.Text = DateTime.Today.ToString();
                EndTranDate.Text = DateTime.Today.ToString();
                loadGrid();
            }
        }

        private void InitiateControls()
        {
            StartTranDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "StartDate");
            EndTranDate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "EndDate");
            CommInvoicedate = (SuperWebControl.DateControl)FindControlRecursive(this.Master, "InvoiceDate");
            gridView = (SuperWebControl.SuperGridview)FindControlRecursive(this.Master, "InvoiceSuperGridView");
        }

        private void loadGrid()
        {
            trxstartdate = wfs.Utility.Util.GetDateFromString(StartTranDate.Text.ToString());
            trxenddate = wfs.Utility.Util.GetDateFromString(EndTranDate.Text.ToString());
            objectDataSource = this.Presenter.GetInvoice();

            gridView.DataSource = objectDataSource;
            gridView.DataBind();
        }
        public void Show_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            int? result = 0;
            trxstartdate = wfs.Utility.Util.GetDateFromString(StartTranDate.Text.ToString());
            trxenddate = wfs.Utility.Util.GetDateFromString(EndTranDate.Text.ToString());
            comminvoicedate = wfs.Utility.Util.GetDateFromString(CommInvoicedate.Text.ToString());

            this.Presenter.SaveInvoiceDetails(comminvoicedate, Master.UserName, ref result);
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
