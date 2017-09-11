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

namespace  WebApplication.WarrantModule
{
    public partial class Default :  CompositeWeb.Extensions.BasePage<CashElectionPresenter>, ICashElectionView
    {

    
    #region IRelatedPartyContainer Members
        public void onLoaded()
        {
        }
    #endregion
    }
}
